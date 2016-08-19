@echo off
cls
if not exist "packages\FAKE" nuget install FAKE -OutputDirectory packages -ExcludeVersion
packages\FAKE\tools\Fake.exe build.fsx
REM pause