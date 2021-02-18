# Rockstar Music Library

Web app application for a rockstar music library to show song lyrics for 3 songs. The project has three parts

- Web API
- MVC
- React

## Author

- Sajal Sood
- sood.sa@northeastern.edu
- 001054338

## Client (front-end)

- [MVC](https://dotnet.microsoft.com/apps/aspnet/mvc)
- [React](https://reactjs.org/docs/getting-started.html)

## Service (back-end)

- [Web API](https://dotnet.microsoft.com/apps/aspnet/apis)

## How to run locally

1. [Download and install the .NET Core SDK](https://dotnet.microsoft.com/download)
2. Open a terminal such as **PowerShell**, **Command Prompt**, or **bash** and navigate to the `rs-api, rs-mvc, rs-react` folder where the `*.csproj` is located.
3. Install the dependencies in each project
    ```sh
    Install Newtonsoft.json - dotnet add package Newtonsoft.Json
    ```
4. Run the following `dotnet` commands:
    ```sh
    dotnet dev-certs https --trust
    dotnet build
    ```
5. - Web APi
    ```sh
    dotnet run --urls="https://localhost:5001"
    ```

    - MVC
    ```sh
    dotnet run --urls="https://localhost:5002"
    ```

    - React
    ```sh
    dotnet run --urls="https://localhost:5002"
    ```
5. Open your browser

## Folder Structure

### React Frontend

```
ClientApp/
  README.md
  node_modules/
  package.json
  public/
    images/
        <<static images>>
        <<static images>>
        <<static images>>
    index.html
    favicon.ico
  src/
    App.css
    App.js
    App.test.js
    index.css
    index.js
    logo.svg
```

### MVC Frontend

```
Controllers/
  SongsController.cs
Models/
    SongViewModel.cs
Views/
    Songs/
          Song.cshtml
Properties
.gitignore
Program.cs
Startup.cs
appsettings.Development.json
appsettings.json
rockstar.csproj
```

### API Backend

```
Controllers/
  SongController.cs
Models/
    SongModel.cs
Pages
Properties
.gitignore
Program.cs
Startup.cs
appsettings.Development.json
appsettings.json
rockstar.csproj
```

## Serving the data

The react application communicates with the dotnet server through an API Controller. The controller `SongController.cs` has two APIs:
1. HttpGet - `Song By Id`
2. HttpGet - `All Songs`

Both actions in the controller return a model data - `SongModel.cs`. 

```c#
public class SongModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Artist { get; set; }
    public string ImageUrl { get; set; }
    public string Lyrics { get; set; }
}
```

The lyrics are stored as Json Data which is served to react frontend and converted to HTML layout during the page rendering.

The name of the image is also served from the backend and an absolute path is contructed on nreact frontend. The absolute path corresponds to the static image which is located in the `public\images\****` folder.

