'TODO:1. Change Procedure name to your own procedure name
'TODO:2.  Add Json package to the resources
'TODO:3. Create A Project Class
'TODO:4.  Create A Json file for the Project Class
'TODO:5.  Refactor writeFile procedure to take a string for data input
'TODO:6.  move the input variable up to the global class variable access
'TODO:7.  Seralize Project Class
'TODO:8.  Deseralize The Project json Class
'TODO:9.  Use snippets (insert comment) to add comments to procedures and functions
'TODO:10.Refactor your code to create subfolders in a separate procedure
'TODO:11.Remove reference comments

Module Module1

    'READ: 'More information on file reading and writing in the coursebook: pg 68: FileRead
    'https://drive.google.com/file/d/1qwb9Sq3bf9sWPdAUeiFX_xM1Knb4Ikpp/view


    Dim ProjectName As String
    Dim FullDirectory As String
    Sub Main()

        Dim input As String = 0
        While input <> "exit"
            Console.WriteLine("please enter product name.")
            ProjectName = Console.ReadLine
            Console.WriteLine("Please enter a command  Exit | create")
            input = Console.ReadLine.ToString()

            If input = "create" Then
                MakeFoldersAndFiles()
            End If
        End While

    End Sub
    Private Sub MakeFoldersAndFiles()
        'TODO: Add Json database
        'TODO: Change MakeP2PProjectFolders to MakeProjectFolders



        Dim newFolderPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop
        If ProjectName = "" Then
            ProjectName = " Not Set\"
        End If

        '  My.Computer.FileSystem.CreateDirectory(newFolderPath + ProjectName)
        CreateProjectFolder(newFolderPath, ProjectName)
        newFolderPath += "\" + ProjectName
        FullDirectory = newFolderPath

        'This creates the chronovault folder
        CreateProjectFolder(newFolderPath, "\ChronoVaultApp")
        CreateProjectFolder($"{newFolderPath}\ChronoVaultApp", "Source Code")
        CreateProjectFolder($"{newFolderPath}\ChronoVaultApp", "Project Files")

        'Creates folder structure for documentation
        CreateProjectFolder(newFolderPath, "\Docs")
        CreateProjectFolder($"{newFolderPath}\Docs", "App Dev Doc")

        'This is a folder for screenshots
        CreateProjectFolder(newFolderPath, "\Screenshots")

        'Creates the testing folder
        CreateProjectFolder(newFolderPath, "\Testing")
        CreateProjectFolder($"{newFolderPath}\Testing", "Git Repository Link")

        'Creates a ReadMe.txt outside of a folder
        WriteFile("ReadMe.txt", newFolderPath)


        Console.WriteLine("Project created in: " + FullDirectory)
    End Sub

    Private Sub WriteFile(fileName As String, location As String)
        'Ref:https://docs.microsoft.com/en-us/dotnet/visual-basic/developing-apps/programming/drives-directories-files/how-to-write-text-to-files-with-a-streamwriter

        If fileName <> "" Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(location + "\" + fileName + ".txt", True)
            file.WriteLine("This console app is a simple project‑starter tool. You type in a project name and a command, and when you choose create, it automatically builds a full folder setup on your Desktop. It makes folders for the app, docs, screenshots, and testing, and it also drops in a basic ReadMe file you can edit later.

To run it, just start the program (either through Visual Studio or by opening the compiled EXE) and follow the prompts in the console.

The app creates a main project folder with subfolders like ChronoVaultApp, Docs, Screenshots, and Testing, plus a starter ReadMe.txt.

The project was created by Kimberly Aguilar, with guidance from course materials and class instruction.")
            file.Close()
        End If
    End Sub


    Sub CreateProjectFolder(newFolderPath As String, ProjectName As String)
        My.Computer.FileSystem.CreateDirectory(newFolderPath + "\" + ProjectName)
    End Sub
End Module