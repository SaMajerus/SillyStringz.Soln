# Sillystringz Factory Floor Manager

#### By Sam Majerus

#### A web application that Doctor Sillystringz uses to manage his factory. Provides information on currently-employed Engineers, installed Machines, the Engineers' respective Repair Licenses/Certifications, and more.   
<br>

## Technologies Used

* C# (C-sharp)
* .NET 5 
* Markdown
* ASP.NET Core
* ASP.NET Core - MVC 
* MySQL
* SQL Database (DB) files 
* Razor
* Entity Framework Core  (also known as 'EF Core')
* EF Core - DB Migrations
* ViewBag
* Layout files 
* CSHTML5 
* JSON
* Git Bash (Used in: Local Cmd-line Terminal, navigation of local directories)
* GitHub (Remote repositories)
* GitHub template repository (MSTest)
<br><br>


## Description

The program starts by printing out a greeting to the User on the Splash page. From here, the User can navigate to one of 3 places: a page that lists the Machines, one that lists the Engineers, or one that lists the Licenses. (The blue text strings are indeed hyperlinks, but they function more like buttons in this context.) 
Note that this application is the Minimum-Viable-Product iteration, meaning that the features available here are of the Baseline variety. 


Current '' CAN/CAN'T '' cases--
User CAN: 
  * Add a Machine and/or License for a given Engineer. 
  * Add a Machine for a given License. 
  * Add a License for a given Machine.
  * Add a Machine with an empty list of Engineers.
  * Add an Engineer with an empty list of Machines. 
  * Add a License for a given Engineer. (From the Engineer's 'Details' page.)
  * Add one or more Machines for a given Engineer (with-/without- Licenses assigned to the Engineers and/or to the Machines).
  * Delete a given Engineer from the list of Engineers (with-/without- assigned Licenses and/or Machines). 
  * Delete a given Machine from the list of Machines (with-/without- assigned Engineers and/or Licenses).
  * Delete a given License from the list of Licenses (with-[[without- assigned Engineers and/or Machines). 


User CAN'T: 
  * Add an Engineer for a given License (with-/without- assigned Machines). 
  * Delete an Engineer, go back a couple of pages, and access that employee's Details page. 



Resources I found to be helpful whilst developing this application-- 
* [Configuring a Primary Key - Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations#configuring-a-primary-key)
* [Help with an 'Internal Server Error' that occurs when population of a SelectList dropdown element fails](https://stackoverflow.com/questions/26585495/there-is-no-viewdata-item-of-type-ienumerableselectlistitem-that-has-the-key)


## Setup/Installation Requirements

* All that's required to run this application -- at minimum -- is: a decently-performing laptop, and a reliable Internet connection. (The latter is really only required for 'Cloning from GitHub' this time around, however.) 

* To Clone the program from the GitHub repo to your local machine:

  * 1.) Click the green button labelled 'Code'. Under the 'HTTPS' tab, there are 3 Options. This program will work best with Option 1, so move on to Step 2. <br> 

  * 2.) Copy the link. Then, in Git BASH, navigate to the folder you want to put the files in. This can be your Desktop directory, or a different subfolder, whatever you prefer. Next, still in the Git BASH console, type the following (with the copied-link in place of 'HTTPS') and hit ENTER: 'git clone HTTPS' Several lines of text will come up in the console -- that's the files being copied into whichever directory/folder you're in currently. Then, do the following once your prompt line reappears: While still in the console window, type 'pwd' and press ENTER. This will display your current file path. Copy that by highlighting it and pressing 'Ctrl-C', and then pasting it in an easily-accessible word processor like Notepad for reference. Next, open File Explorer, and navigate to through your files according to that File Path you just copy-pasted for reference. Once you've done this, move on to Step 3. <br>

  * 3.) To ensure that you can find this folder again in the Steps that follow, please do the following: right-click the containing folder (in which the newly-copied files are stored) and select the option that says 'Pin to Quick Access'.  Move on to Step 4. <br>

  * 4.) Open VS Code. Then, click on the page icon at the top of the left-hand toolbar. Then click 'Open Folder'. When the Windows File Explorer window appears, navigate to and select the containing folder you pinned in the previous step. Once you've selected the folder and clicked the button to open the folder in VS Code, move on to Step 5. <br>

  * 5.) Open a New Terminal (shortcut is Ctrl+Shift+`). Then, in the command line, navigate to the "HairSalon" subdirectory by typing  'cd HairSalon'  then pressing ENTER.   
  Next, type  'dotnet restore'  and press ENTER. This ensures that everything required to run the program is updated and ready to go.   (Your command prompt will show up again once the operation is complete; DO NOT kill the terminal or close VS Code.) <br>
  Once that's done, move on to the next Section.     (DO NOT Navigate to any other directories between now and then!!  Otherwise, the Program will not run.) <br>


* Importing the SQL file--    
  * Import sam_majerus.sql into MySQL Workbench as 'Sam_Majerus'.  (The following steps apply only for Windows-OS devices)  
    * A. Opening MySQL Workbench 
      1)  Open Windows PowerShell.  Once the prompt appears, enter the following command (without single-quotes) to log into MySQL:  'mysql -uroot -pepicodus' 
          After the resulting operation completes, Minimize the window. 
      2)  Open MySQL Workbench.  Double-click on the localhost, log in with your password. (Username should be 'root' or something similar) 
      <br>

    * B. Importing the SQL file  (numbering continues from part A)  
      3)  In the Navigator on the left-hand side, click the Administration tab. Then, under the 'Management' subsection, click 'Data Import/Restore'. 
      4)  Under 'Import Options', select 'Import from Self-Contained File'.  Then, at the end of the directory address box, navigate to the Top Level of the project, and select the SQL file.   
        * Last parts of the address should be:  '[containing folder(s)]\SillyStringz.Soln\sam_majerus_wk12.sql'.
      5)  Next under 'Default Schema to be Imported To', click the 'New' button and enter the name 'Sam_Majerus'.  Then, select this new Schema from the dropdown. 
      6)  Lastly, under the box titled 'Imp... Schema Objects', click on the dropdown and select 'Dump Structure Only'.  Then click the 'Start Import' button. 
  At this point, simply minimize MySQL Workbench.  
<br>


* Setting up the 'appsettings.json' file 
Whilst viewing the 'HairSalon' directory  (~/HairSalon), enter the command 'code appsettings.json' into the terminal. Then, in the empty file that opens (and has the name 'appsettings.json'), copy/paste the following into it.  

```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=sam_majerus;uid=YOUR-SQL-USERNAME;pwd=YOUR-SQL-PASSWORD;"
  }
}
```
Replace 'YOUR-SQL-USERNAME' and 'YOUR-SQL-PASSWORD' with your MySQL username and password, respectively, and then save the file (Ctrl-S). 
<br>


* Running the Program 
  <!-- IMPORTANT: If your current directory location is not the same as it was for the most recent Step, the instructions that follow WILL NOT WORK.  -->
  
  * In your GIT BASH command line, enter this command:  'dotnet run' .   The files will be compiled and then the application will be started. 
  In the terminal, once the last line of prompts says something like    ''Ctrl-C to end the Application'',  'Ctrl + Left-click' the 'localhost:5000' link. A new tab will open in your browser -- and the rest should be self-explanitory. 

  To run the program again after a given session ends, simply reenter   dotnet run   as before.
<br><br>


* If you get an error, here are Troubleshooting steps to try (In Order): 
  * 9 times out of 10, an error message will appear if you try to run the program whilst being in the wrong directory location.  
  To make sure you're in the right place, do the following. 
    * In your Git Bash command line, enter the command  'pwd'.  The Path leading to your current Folder (a.k.a. Directory) location will be printed out.   
    If the last 3 Directories in that Path DO NOT match the following snippet, then you're located in the wrong place. ('CONTAINER' represents your Containing Folder, which is what Contains the Program's Parent/Root folder):          .../CONTAINER/SillyStringz.Soln/Factory 

  * If you're in the Right Place:  try entering the command  'dotnet restore'.  Once its process is completed, try entering  'dotnet run' again. 

  * Still not working?  Save a copy of this document, then move the Program's folder to the Recycle bin and Delete it. Then, try installing it from GitHub again using the above steps. 

  * If it STILL won't work:  Please don't hesitate to reach out via Email.  In addition to uncropped screenshots of the issue (send them as Attachments), please also include your Contact Info (along which method is best for contacting you).   This allows me to better assist you with Troubleshooting.  
<br><br>


* Closing the Program 
  * A. Browser tab & VS Code 
    * Close the browser tab.  
    * In VS Code, do  'File > Close Folder'  (or 'Ctrl-K F'). When that operation is complete, you may close VS Code. 
  
  * B. MySQL Workbench & Windows PowerShell 
    * Close MySQL Workbench. 
    * Un-Minimize Windows PowerShell, and enter the command  'exit'.  Once the command finishes (it should be lightning fast), you may close the window. 
<br><br><br>



## Known Bugs
* When user tries to add an Engineer for a given License entry, they get an 'Internal Server Error' (ISE) that says "NullReferenceException: Object reference not set to an instance of an object."   Strangely, this does not happen when they add a Machine for the given License entry. (Note: this only happens when clicking the ActionLink while on the 'Details' View-page for a given License.) 
<br>


## License

Email me at ladolego@gmail.com for questions, ideas, concerns, or even any issues that you run into. You may also clone or Fork the content in this Repo to fiddle around with it, if you like.

Licensed through MIT. Copyright (c) 10/14/2022, Samuel Majerus.