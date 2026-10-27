---
title: Process multiple presentations in a loop
description: Process a list of presentations using your own application loop.
type: docs
url: /features/process-multiple-files/
weight: 270
feature_id: process-multiple-files
feature_group: operations
translationKey: slides-feature-process-multiple-files
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
---

## **Overview**

Run the library's single-presentation operations over a collection of files. Your application controls the file list, output names, error handling and scheduling. This gives you a straightforward way to convert or edit many presentations using the same processing steps.

## **Usage example**

This C# example uses Aspose.Slides for .NET. It creates two valid PPTX files and one deliberately truncated ZIP file, then processes the list in a caller-managed loop. Each input has its own error handling: two PDFs are saved and the invalid input is reported without stopping the loop.

For setup, see [Install Aspose.Slides for .NET](/slides/net/installation/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var files = new[] { "alpha.pptx", "invalid.pptx", "bravo.pptx" };
foreach (var path in new[] { files[0], files[2] })
{
    using var source = new Presentation();
    var title = source.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 80);
    title.TextFrame.Text = Path.GetFileNameWithoutExtension(path);
    source.Save(path, SaveFormat.Pptx);
}
File.WriteAllBytes(files[1], new byte[] { 0x50, 0x4b, 0x03, 0x04 });
foreach (var path in files)
{
    try
    {
        using var presentation = new Presentation(path);
        var output = Path.ChangeExtension(path, ".pdf");
        presentation.Save(output, SaveFormat.Pdf);
        Console.WriteLine($"Saved: {output}");
    }
    catch (Exception error)
    {
        Console.WriteLine($"Failed: {path}: {error.GetType().Name}");
    }
}
```

## **FAQ**

### **Is there a built-in bulk conversion queue?**

No. The loop and per-file results belong to your application. Keep failures isolated so one problematic file does not stop the remaining work.

### **How do I continue when one input cannot be opened?**

Catch and record errors separately for each input, as above. Continue with the next file and retain enough context to retry failed items later.

### **How should I avoid output filename collisions?**

Map each input to a unique output path. A basename alone can collide across folders; include a relative directory or an application-generated identifier and define an overwrite policy.

## **Guides**

- [Low-Code Presentation Operations in .NET](/slides/net/low-code-presentation-operations/)

Related feature: [Process separate presentations in parallel](/slides/features/parallel-processing/).
