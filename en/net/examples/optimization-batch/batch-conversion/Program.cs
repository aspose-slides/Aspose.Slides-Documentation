using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Runtime.Versioning;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;

[SupportedOSPlatform("windows")]
internal static class Program
{

    private sealed record JobResult(string Source,string Output,bool Success,string? Error);
    private static async Task<(JobResult[] Results,int Peak)> ConvertAll(string[] files,string directory,int workerLimit)
    {
        Directory.CreateDirectory(directory);var results=new ConcurrentBag<JobResult>();int active=0,peak=0;
        await Parallel.ForEachAsync(files,new ParallelOptions{MaxDegreeOfParallelism=workerLimit},(path,cancellation)=>
        {
            int current=Interlocked.Increment(ref active);int observed;
            do{observed=Volatile.Read(ref peak);if(current<=observed)break;}while(Interlocked.CompareExchange(ref peak,current,observed)!=observed);
            string identity=Example.Hash(Encoding.UTF8.GetBytes(Path.GetRelativePath("output/inputs",path)))[..12];
            string destination=Path.Combine(directory,Path.GetFileNameWithoutExtension(path)+"-"+identity+".pdf");
            try
            {using var p=new Presentation(path,new LoadOptions{LoadFormat=LoadFormat.Pptx});p.Save(destination,SaveFormat.Pdf);Example.Require(File.ReadAllBytes(destination).Take(5).SequenceEqual(Encoding.ASCII.GetBytes("%PDF-")),"Invalid PDF header.");results.Add(new(path,destination,true,null));}
            catch(Exception ex){if(File.Exists(destination))File.Delete(destination);results.Add(new(path,destination,false,ex.GetType().Name+": "+ex.Message));}
            finally{Interlocked.Decrement(ref active);}return ValueTask.CompletedTask;
        });
        return(results.OrderBy(r=>r.Source,StringComparer.Ordinal).ToArray(),peak);
    }
    private static async Task Main()
    {
        Example.Setup();Directory.CreateDirectory("output/inputs/a");Directory.CreateDirectory("output/inputs/b");
        foreach(var item in new[]{("a/shared.pptx","North"),("b/shared.pptx","South"),("later.pptx","Processed after failures")})
        {using var p=new Presentation();Example.Text(p.Slides[0].Shapes,"Text",item.Item2);p.Save("output/inputs/"+item.Item1,SaveFormat.Pptx);}
        File.WriteAllBytes("output/inputs/corrupt.pptx",new byte[]{0x50,0x4b,3,4,0,0,0});
        using(var p=new Presentation()){p.ProtectionManager.Encrypt("SyntheticExamplePassword");p.Save("output/inputs/locked.pptx",SaveFormat.Pptx);}
        string[] files=Directory.GetFiles("output/inputs","*.pptx",SearchOption.AllDirectories).OrderBy(p=>p,StringComparer.Ordinal).ToArray();
        var sequential=await ConvertAll(files,"output/sequential",1);var parallel=await ConvertAll(files,"output/parallel",2);
        foreach(var result in new[]{sequential,parallel})
        {Example.Require(result.Results.Count(r=>r.Success)==3&&result.Results.Count(r=>!r.Success)==2,"File outcomes differ.");Example.Require(result.Results.Where(r=>r.Success).Select(r=>r.Output).Distinct().Count()==3,"Output filenames collide.");Example.Require(result.Results.Single(r=>r.Source.EndsWith("later.pptx")).Success,"Later job did not run.");}
        Example.Require(sequential.Peak<=1&&parallel.Peak<=2,"Worker limit exceeded.");
        Example.Json("output/results.json",new{sequential=sequential.Results,parallel=parallel.Results,sequential_peak=sequential.Peak,parallel_peak=parallel.Peak});
        Example.Result(new{successes_per_run=3,failures_per_run=2,unique_outputs=true,worker_limits_observed=true,later_jobs_processed=true});
    }

}
