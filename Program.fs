open System
open System.IO

let LengthClass length =
    if length < 1024L then "Small"
    else if length < 1024L * 1024L then "Medium"
    else "Large"

let FileSizeGroups dirName =
    dirName
    |> System.IO.Directory.EnumerateFiles
    |> Seq.map (fun name ->
        let info = new FileInfo(name)
        (name, info.Length))
    |> Seq.groupBy (fun(name, length) -> LengthClass length)
printfn "%A" (FileSizeGroups @"/home/jacqueline/Desktop")
printfn "***********************************************************"
let Extensions (dir : string) =
    Directory.EnumerateFiles(dir)
    |> Seq.map (fun name -> Path.GetExtension(name))
    |> Seq.distinct
printfn "%A" (Extensions @"/home/jacqueline/Desktop")


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code

