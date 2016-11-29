#!/bin/bash

# Potential Bugs:
# None for now


# Declaring Colors


# Changing Directory (assuming it is in the Downloads folder)
cd "$HOME/Downloads"


# Asking for file extension type
function filetype {

echo -e "File extension type ? (.xy.z)"
echo
read fltp

echo

echo -e "Name of file ?"
echo
read flnm

echo -e "Are you sure ? (Y/N)"
echo
read yn_flnm

if [ "$yn_flnm" == "y" ] || [ "yn_flnm" == "Y" ];
    then
        extr

elif [ "yn_flnm" == "n" ] || [ "yn_flnm" == "N" ];
    then
        restart


# Start the extraction commands
function extr {

echo -e "Starting extraction..."
echo

if [ "fltp" == "tar.gz"]
    then
        #do command to extract .tar.gz files
        
elif
