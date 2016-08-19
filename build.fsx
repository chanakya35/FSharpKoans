// include Fake lib
#r @"./packages/FAKE/tools/Fakelib.dll"
open Fake
open System

RestorePackages()

// Properties
let buildDir = "./build/"

// Targets
Target "Clean" (fun _ ->
    CleanDir buildDir
)

// Default target
Target "Default" (fun _ ->
    trace "Hello world from FAKE dude!"
)

Target "BuildApp" (fun _ ->
    !! "**/*.fsproj"
        |> MSBuildRelease buildDir "Build"
        |> Log "FSharpKoans build: "
)

Target "RunTests" (fun _ ->
    !! (buildDir + "*.Test.dll")
        |> NUnit (fun p ->
            {p with
                DisableShadowCopy = true;
                OutputFile = buildDir + "TestResults.xml" })  
)

Target "Run" (fun _ ->
    ignore(Shell.Exec "./build/FSharpKoans.exe") 
)

// Dependencies
"Clean"
    ==> "BuildApp"
    ==> "Run"
    ==> "Default"

// start build
RunTargetOrDefault "Default"