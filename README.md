# MusicFall2016

##Starter code for ASP.NET Core MVC assignment

After cloning this repo, it is necessary to build the database. Use the Package Manager Console for this. Note that `createdb` is a name that identifies the migration. Pick any name that is self-descriptive of what the migration is intended to do.

    PM> add-migration createdb
    PM> update database

(These commands might generate errors: `Project "Default" is not found`)

This might be due to some ongoing tooling changes. If you get this, do the following

Change to the directorory containing the project.json file (modify the directory name if you called it something else):

    PM> cd src/MusicFall2016

Then use these commands:

    PM> dotnet ef migrations add createdb
    PM> dotnet ef database update
