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
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;
using Aspose.Slides.Warnings;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void CompressPicture()
    {
        CreateInput();
        long before=new FileInfo("output/input.pptx").Length;
        bool compressed;
        using (var presentation = new Presentation("output/input.pptx"))
        {
            var frame = Example.Named<IPictureFrame>(presentation.Slides[0], "Oversized image");
            compressed = frame.PictureFormat.CompressImage(true, PicturesCompression.Dpi96);
            presentation.Save("output/compressed.pptx", SaveFormat.Pptx);
            Example.Render(presentation, "output/after.png");
        }
        VerifyOutput(before, compressed);
    }
}
