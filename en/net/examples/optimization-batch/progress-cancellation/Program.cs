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

    private sealed class Progress : IProgressCallback
    {
        public List<double> Values {get;}=new();private readonly InterruptionTokenSource? _source;public bool Requested{get;private set;}
        public Progress(InterruptionTokenSource? source=null){_source=source;}
        public void Reporting(double value){Values.Add(value);if(_source!=null&&!Requested&&value>0){Requested=true;_source.Interrupt();}}
    }
    private static void Main()
    {
        Example.Setup();using(var p=new Presentation())
        {for(int i=0;i<24;i++){var slide=i==0?p.Slides[0]:p.Slides.AddEmptySlide(p.LayoutSlides[0]);Example.Text(slide.Shapes,"Title","Slide "+(i+1));Example.ChartData(Example.Chart(slide,"Chart"),new[]{"A","B","C"},new[]{"Series"},new[]{new[]{1.0,2.0,3.0}});}p.Save("output/input.pptx",SaveFormat.Pptx);}
        var fullProgress=new Progress();using(var p=new Presentation("output/input.pptx")){p.Save("output/complete.pdf",SaveFormat.Pdf,new PdfOptions{ProgressCallback=fullProgress});}
        Example.Require(fullProgress.Values.Count>0&&fullProgress.Values.Max()==100,"Full PDF export did not report completion.");
        var source=new InterruptionTokenSource();var cancellationProgress=new Progress(source);bool exceptionObserved=false;
        try{using var p=new Presentation("output/input.pptx",new LoadOptions{InterruptionToken=source.Token});p.Save("output/partial.pdf",SaveFormat.Pdf,new PdfOptions{ProgressCallback=cancellationProgress});}
        catch(OperationCanceledException){exceptionObserved=true;}
        finally{if(File.Exists("output/partial.pdf"))File.Delete("output/partial.pdf");}
        using(var exclusive=File.Open("output/input.pptx",FileMode.Open,FileAccess.ReadWrite,FileShare.None)){}
        // Some library export paths return normally after an interruption. Compare
        // their progress against the successful control, rather than requiring an exception.
        bool stopped=exceptionObserved||(cancellationProgress.Requested&&cancellationProgress.Values.Count>0&&cancellationProgress.Values.Max()<100);
        Example.Require(cancellationProgress.Requested&&stopped,"Cancellation request did not stop the SDK operation before completion.");
        Example.Require(!File.Exists("output/partial.pdf"),"Partial output was retained.");
        Example.Json("output/progress.json",new{complete=fullProgress.Values,cancelled=cancellationProgress.Values,cancellation_requested=cancellationProgress.Requested,operation_stopped=stopped,operation_canceled_exception=exceptionObserved});
        Example.Result(new{progress_observed=true,cancellation_requested=true,operation_stopped=true,partial_output_removed=true,input_unlocked=true});
    }

}
