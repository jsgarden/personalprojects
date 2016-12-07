#!/bin/bash

# Potential bugs:
# CORRECTED - Program crashes when entering auto remove's y or n

# Declaring colors
YEL='\033[1;33m'
WHT='\033[1;37m'
RED='\033[1;31m' # This is actually Light red
LGRN='\033[1;32m'
LCYN='\033[1;36m'
NC='\033[0m'

# Changing directory
cd "$HOME/Downloads"


# Ask for name of file
function filename {
 echo -e "${LGRN}Adi.sh (Automatic Deb Installer) by Jean-Simon Desjardins - https://github.com/jsgarden"
 echo
 echo -e "${YEL}Name of file ? (.deb)${WHT}"
 read flnm
 
 echo

 echo -e "${YEL}Are you sure ? (Y/N)${WHT}"
 read yn_flnm

 if [ "$yn_flnm" == "y" ] || [ "$yn_flnm" == "Y" ]
	then
		cmpl
		
 elif [ "$yn_flnm" == "n" ] || [ "$yn_flnm" == "N" ]
	then
		filename
		echo
		
 fi }



# Function for the sudo dpkg command
function cmpl {
 echo
 echo -e "${YEL}Launching Extraction${NC}"
 sleep 1
 sudo dpkg -i $flnm
 
 instl
 }
 
 
 
# Function for forced apt-get install
function instl {

 echo
 echo -e "${YEL}Launching Installation${NC}"
 sleep 1
 
 sudo apt-get install -f
 echo
 
 echo -e "${LGRN}Finished !"
 sleep 1
 echo
 autoremove
 echo
}

function autoremove {
 echo -e "${LCYN}Do you wish to run autoremove ? (Y/N) ${WHT}"
 read autorm
 
 if [ "$autorm" == "y" ] || [ "$autorm" == "Y" ]
	then
		echo
		echo -e "${LCYN}Cleaning...${NC}"
		sleep 1
		sudo apt-get autoremove
		echo
		echo -e "${LCYN}Done !${NC}"
		echo
		echo
		sleep 1
		restart
		
 elif ["$autorm" == "n" ] || [ "$autorm" == "N" ]
	then
		restart
fi }
 
 function restart {
 echo -e "${YEL}Restart (R) or exit (E) ?${WHT}"
 read re_instl
 echo
 
 if [ "$re_instl" == "r" ] || [ "$re_instl" == "R" ]
	then
		filename

elif [ "$re_instl" == "e" ] || [ "$re_instl" == "E" ]
	then
		echo -e "${RED}Exiting..."
		sleep 1
		exit
fi }


# Start the program
filename
