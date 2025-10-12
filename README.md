# Setup the project
## Step 1
In order to build and run the website, make sure that you have installed below tools before doing any further steps.

+ [ASP.NET 9.0+](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
+ [Sqlite 3.50+](https://sqlite.org/download.html)

For a simple check, open your OS default terminal (**PowerShell** for Windows, Linux users would already know which one they're using) and run following commands
```bash
dotnet.exe --version    # on Linux, it's 'dotnet --version'
sqlite3.exe --version   # on Linux, it's 'sqlite3 --version'
```

If it produces a red error message, then you must install the tools as stated. If not, you may skip this and process to next steps

## Step 2
Open File Explorer (Linux users should already know what I'm mentioning about) and choose a desired location that you want to install the project. Then, left click on the navigation bar that have the name of the folder you chosen (e.g: '**Downloads/') and hit **Ctrl + C** keybind.

After that, open the terminal again and run:
```bash```
cd <delete this and replace by hitting 'CTRL + V' keybind>
```bash

Then, you can clone/install the repository/project by typing
```bash
git clone https://github.com/Boryslavir/WDP-Assessment-3 && cd WDP-Assessment-3/ && ls
```
If you see any thing that ends with `.csproj` then you are good to move onto the next step

## Step 3
Within the current directory/folder, install the following tools in order to run the website
```bash
dotnet add . package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
dotnet add . package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add . package Microsoft.AspNetCore.Identity.UI
dotnet add . package Microsoft.EntityFrameworkCore.Sqlite
dotnet add . package Microsoft.EntityFrameworkCore.Tools
dotnet add . package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

After finish installing those, you have 2 options to go with:
### Step 3.1. Open the website using the OS default terminal (author's recommended option)
Within the terminal, run the following command which automatically open up the website for you based on your default web browser
```bash
dotnet watch -v diag
```

### Step 3.2. Open the website using the Visual Studio Code
Close the current terminal and open up Visual Studio Code. Hit **Ctrl + K** then **Ctrl + O** follow up straight away. Remember that I told you to take note on your desired install folder? Go to there and click on the **WDP-Assessment-3/** folder (remeber, CLICK ON IT ONLY). Hit the button that said `Open` or similar.

Then, open up the terminal (search it up on Google on how to do it if you don't know, it's very easy) and run the below command to get the website up and running
```bash
dotnet watch -v diag
```

## Step 4
> [!NOTE]
> From here, depends on which options you choose in `Step 3`, the step to run it is fairly similar to each other. I will assume that you choose to do the `Step 3.1.`

If you ever go to the <AI Image> page, it would likely to raise an issue related to database. In that case, run the following command in sequences
```bash
dotnet tool install --global dotnet-ef
dotnet-ef migrations add AIImage
dotnet-ef database update
```

## Step 5
This one not actually a step, but rather, something you've to do in order to test different roles accessibility on the website. Follow the database intructions from **Week 9 Tutorial** if you do it in **Visual Studio Code**. Otherwise, run the following commands within the terminal (Make sure you still inside the '**WDP-Assessment-3/**' folder)
```bash
sqlite3.exe -header -table app.db

# Something like this will show up 'sqlite> [type-here]'
select Id, Email, UserName from AspNetUsers;

# Take notes on the 'ID' column
insert into AspNetRoles(Text, ConcurrencyStamp, Name, NormalizedName) values (1, 'NULL', 'admin', 'ADMIN'), (2, 'NULL', 'user', 'USER');

# Replace the placeholders with those IDs that I asked you to take note on
# '1' = admin access level, and '2' = user access level
insert into AspNetUserRoles(UserId, RoleId) values ([paste-the-ID-here], 1), ([paste-the-ID-here], 2);
```
