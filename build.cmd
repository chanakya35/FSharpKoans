@echo off
cls
if not exist "packages\FAKE" nuget install -Source "NuGet.org" FAKE -OutputDirectory packages -ExcludeVersion
packages\FAKE\tools\Fake.exe build.fsx
REM pause