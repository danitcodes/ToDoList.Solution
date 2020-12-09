# To Do List in C#

#### In-class Practice Assignment during Epicodus Coding School, C# Practice with test driven development, MSTest, and the Red, Green, Refactor workflow, 12.09.2020

#### By Danielle Thompson & Kail Sprague McRae

## Description

The app allows the user to add new items to a to do list. The user is also able to see a list of the tasks they have already added.

For example:

Program: Welcome to the To Do List.
Program: Would you like to add an item to your list or view your list? (Add/View)
User: Add
Program: Please enter the description for the new item.
User: Walk the dog.
Program: 'Walk the dog' has been added to your list. Would you like to add an item to your list or view your list? (Add/View)
User: View
Program: 1. Walk the dog.
Program: Would you like to add an item to your list or view your list? (Add/View)
Consider what the program should print if the user asks to view their list before they have added any items to it.

## Technologies used

- C# v 7.3
- .NET Core v 2.2
- dotnet script, REPL

## Installation Requirements

#### Installing Git
###### For Mac Users

- Access Terminal in your Finder, and open a new window. Install the package manager, (Homebrew) [https://brew.sh/], on your device by entering this line of code in Terminal: `$ /usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"`.
- Ensure Homebrew packages are run with this line of code: `echo 'export PATH=/usr/local/bin:$PATH' >> ~/.bash_profile`.
- Once homebrew is installed, install Git, a version control system for code writers, with this line of code `brew install git`.

###### For Windows Users

- Open a new Command Prompt window by typing "Cmd" in your computer's search bar.
- Determine whether you have 32-bit or 64-bit Windows by following these (instructions)[https://support.microsoft.com/en-us/help/13443/windows-which-version-am-i-running].
- Go to (Git Bash)[https://gitforwindows.org/], click on the "Download" button, and download the corresponding exe file from the Git for Windows site._
- Follow the instructions in the set up menu.

#### For Both Mac & Windows systems

- Once you have Git installed on your computer, go to this (GitHub repository)[https://github.com/dani-t-codes/ToDoList-w-Kaila], click the "Fork" button in the upper right hand corner of the page, and clone this application with the following command:`git clone https://github.com/dani-t-codes/ToDoList-w-Kaila`.


#### Installing C#, .NET, dotnet script, & MySQL

* Install C# and .Net according to your operating system below. 

###### For Mac
 * Download this .NET Core SDK (Software Development Kit)[https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer]. Clicking this link will prompt a .pkg file download from Microsoft.
* Open the .pkg file. This will launch an installer which will walk you through installation steps. Use the default settings the installer suggests.
* Confirm the installation is successful by opening your terminal and running the command $ dotnet --version, which should return something like: `2.2.105`. 

###### For Windows (10+)
* Download either the the 64-bit .NET Core SDK (Software Development Kit)[https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer]. Clicking these links will prompt a .exe file download from Microsoft.
* Open the file and follow the steps provided by the installer for your OS.
* Confirm the installation is successful by opening a new Windows PowerShell window and running the command dotnet --version. You should see something a response like this: `2.2.105`.

#### For Mac & Windows Operating Systems
* Install dotnet script with the following terminal command `dotnet tool install -g dotnet-script`.

#### Opening the Project on your Local System
Once the project has been cloned to your computer and you have all the necessary items on your local computer, open the project in the application of your choice ((Visual Code Studio)[https://code.visualstudio.com/] was used and is recommended by the application builder), and run the following...

* Navigate to the project folder on your Terminal or CMD.
* `dotnet build` will get bin/ and obj/ folders downloaded.
* `dotnet run` will run the application. 
* `dotnet restore` to install packages listed in project's boilerplate. 


### Specs

| Spec                                            | Input                        | Output                        |
| :---------------------------------------------- | :--------------------------- | :----------------------------|
| **Takes user To Do List item & adds to a list**    | User enters: "Walk the dog" | Return:  |



### Tests

Describe: listIt()
Test: listIt(userInput).toEqual(userOutput)
Expect: listIt("Walk the dog").toEqual("To Do List: Walk the Dog")


## Known bugs

No known bugs as of now. 

### Legal, or License

_MIT_ Copyright (c) 2020 *_Danielle Thompson, Kaila Sprague McRae_**
