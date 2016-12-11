using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Speech.Synthesis;

namespace Jarvis
{
    class Program
    {
        private static SpeechSynthesizer synth = new SpeechSynthesizer();



        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            // Set a male voice
            synth.SelectVoiceByHints(VoiceGender.Male);

            // Greet the user vocally
            synth.Speak("Welcome to Jarvis version one point 0");

            #region perfCounters
            // Pull current CPU load in %
            PerformanceCounter perfCpu = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            perfCpu.NextValue();

            // Pull current RAM load in available Mbytes
            PerformanceCounter perfMem = new PerformanceCounter("Memory", "Available MBytes");
            perfMem.NextValue();

            // Get system uptime in seconds
            PerformanceCounter perfUptime = new PerformanceCounter("System", "System Up Time");
            perfUptime.NextValue();
            #endregion

            TimeSpan uptimeSpan = TimeSpan.FromSeconds(perfUptime.NextValue());
            string systemUptimeMessage = string.Format("The current system up time is {0} days {1} hours {2} minutes {3} seconds",
                (int)uptimeSpan.TotalDays,
                (int)uptimeSpan.Hours,
                (int)uptimeSpan.Minutes,
                (int)uptimeSpan.Seconds
                );

            // Tell user current system uptime
            synth.Speak(systemUptimeMessage);

            while (true)   // Infinite while loop
            {
                int currentCpuPercentage = (int)perfCpu.NextValue();
                int currentAvailableMemory = (int)perfMem.NextValue();

                // Print current CPU load to console every 1 sec
                Console.WriteLine("CPU Load        : {0}%", currentCpuPercentage);
                Console.WriteLine("Available Memory: {0}Mb", currentAvailableMemory);
                Console.WriteLine();

                // Only tell us when CPU usage is over 80%
                if(currentCpuPercentage > 80)
                {
                    if(currentCpuPercentage == 100)
                    {
                        string cpuLoadMessage = String.Format("WARNING: Holy crap your CPU is about to catch fire!", currentCpuPercentage);
                        Speak(cpuLoadMessage, VoiceGender.Male);
                    }
                    else
                    {
                        string cpuLoadMessage = String.Format("The current CPU load is {0} percent", currentCpuPercentage);
                        Speak(cpuLoadMessage, VoiceGender.Male);
                    }


                }

                // Only tell us when less than 1GB of RAM is available
                if(currentAvailableMemory < 1024)
                {
                    string memAvailableMessage = String.Format("You currently have {0} megabytes of memory available", currentAvailableMemory);
                    Speak(memAvailableMessage, VoiceGender.Male);

                }

                Thread.Sleep(1000);
            }//end of loop
        }


        /// <summary>
        /// Speaks with a selected voice
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voicegender"></param>
        public static void Speak(string message, VoiceGender voiceGender)
        {
            synth.SelectVoiceByHints(voiceGender);
            synth.Speak(message);
        }

        /// <summary>
        /// Speaks with a select voice at a selected speed
        /// </summary>
        /// <param name="message"></param>
        /// <param name="voicegender"></param>
        /// <param name="rate"></param>
        public static void Speak(string message, VoiceGender voiceGender, int rate)
        {
            synth.Rate = rate;
            Speak(message, voiceGender);
        }
    }
}
