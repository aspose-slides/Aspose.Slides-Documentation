---
title: Convert PowerPoint Presentations to Markdown in .NET
linktitle: PowerPoint to Markdown
type: docs
weight: 140
url: /net/convert-powerpoint-to-markdown/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to MD
- presentation to MD
- slide to MD
- PPT to MD
- PPTX to MD
- save PowerPoint as Markdown
- save presentation as Markdown
- save slide as Markdown
- save PPT as MD
- save PPTX as MD
- export PPT to MD
- export PPTX to MD
- Markdown image export
- CDN image links
- PowerPoint
- presentation
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Convert PPT and PPTX presentations to Markdown in .NET and control where exported bitmap, metafile, and SVG images are saved and referenced."
---

## **Overview**

Aspose.Slides for .NET can convert PPT and PPTX presentations to Markdown for documentation, static-site, content-migration, and version-control workflows. You can choose a Markdown flavor, control how slide content is rendered, and decide where exported images are stored and how the generated Markdown references them.

By default, Markdown export uses text-only output. To export visual content, set the [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/exporttype/) property to the `Sequential` or `Visual` value from the [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.export/markdownexporttype/) enumeration. `Sequential` renders slide items separately and in order, whereas `Visual` keeps grouped items together to preserve their visual relationship. The `TextOnly` value does not emit image resources, so the image-saving events are not invoked in that mode.

## **Convert a Presentation to Markdown**

Load the source file with the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class, and then call the [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method with the `Md` value from the [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) enumeration.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Select a Markdown Flavor**

The [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/flavor/) property controls the Markdown specification used for the output. The [Flavor](https://reference.aspose.com/slides/net/aspose.slides.export/flavor/) enumeration includes CommonMark, GitHub Flavored Markdown, and other supported variants.

The following example exports a presentation as CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Export Images Using the Default Local-Saving Behavior**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/) class provides two properties for locally saved images:

- [BasePath](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/basepath/) specifies the base directory for the Markdown document and its resources.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) specifies the image subdirectory. Its default value is `Images`.

The following example renders visual content, writes images to `output/assets`, and creates relative image references in the Markdown document:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

This behavior also serves as the fallback when a custom image-saving handler returns `false`.

## **Customize Image Saving and Markdown Links**

Use the [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/imagesaving/) event for non-SVG bitmap and metafile resources emitted during Markdown export. Its [MarkdownImageSavingHandler](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) delegate receives the [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) object, its [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), and the generated Markdown link as a `ref string` parameter. Save or upload the image with the supplied format, and replace `link` with the reference that must appear in the Markdown output.

Resources emitted in SVG format are handled separately. Subscribe to the [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) event, whose [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) delegate receives an [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage/) object and the `ref string link` parameter. An SVG has no `ImageFormat` argument; write or upload its XML data from the [ISvgImage.SvgData](https://reference.aspose.com/slides/net/aspose.slides/isvgimage/svgdata/) property instead. Depending on the export mode and visual grouping, an SVG in the source presentation can be rasterized or combined with other content; the resulting non-SVG resource is then passed to `ImageSaving`. Subscribe to both events when every exported visual resource requires custom processing.

The handler return value determines who processes the image:

- Return `true` after the handler has saved, uploaded, transformed, or otherwise processed the image and assigned a valid value to `link`. Aspose.Slides writes that value to the Markdown document and does not perform its default local save.
- Return `false` to let Aspose.Slides save the image locally and generate its link according to [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/basepath/) and [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Important" %}}

A handler that returns `true` takes responsibility for the image. If it returns `true` without assigning a valid, nonempty link, the export fails with an `InvalidOperationException`.

{{% /alert %}}

### **Save Images to a CDN Origin Directory and Use External URLs**

The following example treats `cdn-origin/presentations/quarterly-report` as a mounted or synchronized CDN origin directory. Each handler extracts the generated file name, saves the image to that custom directory, and replaces the generated local reference with a public CDN URL. The sample itself performs no network upload: the URL becomes valid only after the directory is mounted as the CDN origin or its files are published to the CDN. For object storage, replace the file-system write with the storage SDK's upload operation and assign `link` only after the upload succeeds.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

The bitmap handler deliberately returns `false` for images smaller than 128 × 128 pixels, so Aspose.Slides saves those images to `output/fallback-images` using the default behavior. Larger bitmap and metafile resources, as well as SVG resources, are handled by the custom code. For example, a generated local reference such as `fallback-images/image1.png` becomes `https://cdn.example.com/presentations/quarterly-report/image1.png`. The handlers use operating-system paths only when writing files; links written to Markdown use forward slashes and URL-escaped file names. Apply the same rule when building relative links: use `/`, not the platform-specific directory separator.

## **FAQ**

**Can one handler process both raster images and SVG images?**

No. Use [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/imagesaving/) for emitted bitmap and metafile resources and [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) for resources emitted as SVG. The former provides an [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) object and an [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/); the latter provides an [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage/) object whose SVG data can be read from [ISvgImage.SvgData](https://reference.aspose.com/slides/net/aspose.slides/isvgimage/svgdata/). A source SVG that is rasterized during export is processed by `ImageSaving` instead.

**What happens when an image-saving handler returns `false`?**

Aspose.Slides uses its default local-saving behavior. The image location and generated reference are controlled by [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/basepath/) and [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Can a handler provide a URL without saving the image locally?**

Yes. The handler can upload the image to object storage or pass it to another service, assign the resulting URL to `link`, and return `true`. The handler must complete the processing itself; returning `true` prevents the default local save.

**Why does Markdown export throw an `InvalidOperationException` from a handler?**

This exception occurs when the handler returns `true` but does not provide a valid link. Assign the relative path or external URL that should be written to Markdown before returning `true`.

**Which path separator should image links use?**

Use forward slashes in Markdown links and URLs. Use `Path.Combine` only for file-system paths, then construct or normalize the Markdown reference separately.

**Are hyperlinks preserved during Markdown export?**

Yes. Text [hyperlinks](/slides/net/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/net/slide-transition/) and [animations](/slides/net/powerpoint-animation/) are not converted.

**Can presentations be converted to Markdown in parallel?**

You can process different presentation files in parallel, but do not share the same [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance between threads. Follow the [multithreading guidelines](/slides/net/multithreading/) and use a separate instance for each file.
