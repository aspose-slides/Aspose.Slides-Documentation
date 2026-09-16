---
title: Export Presentations to XAML in .NET
linktitle: Presentation to XAML
type: docs
weight: 30
url: /net/export-to-xaml/
keywords:
- export PowerPoint
- export OpenDocument
- export presentation
- convert PowerPoint
- convert OpenDocument
- convert presentation
- PowerPoint to XAML
- OpenDocument to XAML
- presentation to XAML
- PPT to XAML
- PPTX to XAML
- ODP to XAML
- save PPT as XAML
- save PPTX as XAML
- save ODP as XAML
- export PPT to XAML
- export PPTX to XAML
- export ODP to XAML
- .NET
- C#
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument slides to XAML in .NET using Aspose.Slides—quick, Office-free solution that keeps your layout intact."
---

## **Overview**

This article explains how to export PowerPoint presentations to XAML using Aspose.Slides. It includes a brief introduction to XAML, shows how to save a presentation to XAML with default settings, and demonstrates how to customize the export through [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/), including exporting hidden slides. The article also answers a few common questions related to fallback fonts, XAML stack compatibility, and hidden slide export behavior.

## **About XAML**

XAML is an XML-based markup language used to describe user interfaces in frameworks such as WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), and Xamarin.Forms.

You can work with XAML files in a visual designer or write and edit the markup directly.

## **Export Presentations to XAML With Default Options**

The following C# example shows how to export a presentation to XAML with default settings:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

By default, the exported slides are saved in a `pres` subfolder of the process's current working directory, as returned by [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). The folder is created automatically, and any required images are saved there as well.

The output folder name is taken from the source file name without its extension. For `pres.pptx`, the output files are named `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, and so on. Even if you pass an absolute path to the input presentation, the output folder is created relative to the current working directory, rather than alongside the input file.

## **Export Presentations to XAML With Custom Options**

Use the [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/) interface to control how Aspose.Slides exports a presentation to XAML.

To save the output to a custom location, implement [IXamlOutputSaver](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloutputsaver/) and assign an instance of your implementation to the [OutputSaver](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/outputsaver/) property of [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/).

To include hidden slides in the XAML output, set the [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) property to `true`, as shown in the following C# example:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Capture All Generated XAML Artifacts**

A XAML export can produce a XAML document for each exported slide plus separate images and supporting resources. Assign a custom [IXamlOutputSaver](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloutputsaver/) to [XamlOptions.OutputSaver](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/outputsaver/) to receive these artifacts instead of using the default file-system saver. Start the export with the XAML-specific [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) overload that accepts XAML options.

### **Understand the Callback Lifecycle**

The exporter calls [IXamlOutputSaver.Save](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloutputsaver/save/) separately for each generated artifact:

- `path` identifies the artifact and may include relative directories. Retain this information because XAML may reference resources using relative paths.
- `data` contains the artifact's bytes. Images and other binary resources must not be decoded as text.
- The saver is responsible for retaining or persisting the data before returning. The examples copy each byte array into application-owned memory.
- Treat export as successful only when the presentation save operation returns and every callback has completed successfully. Do not swallow storage errors or start unobserved background writes. If persistence happens afterward, report overall success only after that step also succeeds.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) also applies to a custom saver. Its default value, `false`, excludes hidden-slide XAML documents. Setting it to `true` includes them and any resources required for their export. Resource counts depend on the presentation; do not assume one callback per slide or a fixed callback order.

### **Export to Memory and Inspect the Artifacts**

This complete example loads `pres.pptx`, collects every artifact in a [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2), and prints its name, type, and byte count. It preserves the supplied names exactly. Duplicate names cause collection to fail instead of silently overwriting an artifact.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Decode only XAML, and only when textual inspection is needed.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Call `InMemoryXamlExample.Run` from your application. Extension checks are useful for inspection; retain all artifacts, including unfamiliar resource types. Leave the bytes unchanged when storing or transmitting them. Use [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) only for XAML that needs textual processing.

### **Package Collected Artifacts in a ZIP Archive**

This independent example collects the export, validates its names, and writes the original bytes into a ZIP archive. A unique archive name separates concurrent export jobs. ZIP entries use forward slashes and retain relative directories. Unsafe names or names that collide after normalization reject the entire package before it is written.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // The ZIP directory has been finalized by disposal before reporting success.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Call `ZipXamlExample.Run` from your application. The example uses [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) to write one local archive; the exporter itself does not write loose XAML or image files. For remote storage, replace the archive-writing stage with uploads of the collected byte arrays. Use an export-job identifier plus the full relative artifact name as a blob key, or store the job identifier, relative name, and binary data in a database row. Publish the job only after all uploads complete or the database transaction commits. Clean up partial output if persistence fails.

For large presentations, a custom saver can persist each artifact directly to application storage to avoid keeping an additional copy of the entire export in application memory. The exporter still collects all generated artifacts in memory before calling the saver. Keep each callback synchronous from the exporter's perspective: return only after the destination has accepted the bytes, and allow failures to reach the caller.

### **Preserve Resource Names and Verify References**

- Normalize path separators when the destination requires it, but preserve relative directories. Do not use only [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) unless every generated name is known to be unique and resource references remain valid.
- Apply destination-specific name validation. When writing loose files, reject rooted paths and traversal segments, resolve the destination with [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath), and verify it stays beneath the intended export directory, including the directory separator in the containment check. Use an application-controlled directory without symbolic links that could redirect writes.
- Use a separate saver and storage namespace for each export job. Detect collisions after separator normalization and according to the destination's case-sensitivity rules.
- Before publishing, parse each XAML document as XML and inspect its file-based resource references, such as image `Source` or `ImageSource` attributes. Resolve each relative URI against the containing XAML artifact's directory, normalize the resulting storage name, and confirm that the corresponding dictionary key, ZIP entry, or stored object exists. Treat external URIs and XAML markup expressions separately from relative file names.

For example, if `pres/Slide_1.xaml` references `images/image1.png`, the stored resource must be available as `pres/images/image1.png`. Keeping just `image1.png` would break that relationship. For object storage, preserve the same layout beneath the job prefix and make those resource URLs accessible to the XAML consumer. Reopen the completed ZIP to verify entry names and resource bytes, and load representative slides in the target XAML environment to confirm that images resolve correctly.

## **FAQ**

**How can I ensure predictable fonts if the original font is not available on the machine?**

Set [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — it is used as a fallback font during export when the original is missing. This does not guarantee that the generated XAML references the fallback font or that the font is available on the target machine. Ensure that the fonts referenced by the XAML are available in the environment where it is displayed.

**Is the exported XAML intended only for WPF, or can it be used in other XAML stacks as well?**

Aspose.Slides exports WPF XAML through its public API. Compatibility with other XAML stacks, such as UWP and Xamarin.Forms, is not guaranteed. Test the generated markup in your target environment.

**Are hidden slides supported, and how can I prevent them from being exported by default?**

By default, hidden slides are not included. You can control this behavior via [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — keep it disabled if you do not need to export them.
