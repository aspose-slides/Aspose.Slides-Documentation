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
- exportPPTX to MD
- PowerPoint
- presentation
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Convert PowerPoint slides—PPT, PPTX—to clean Markdown with Aspose.Slides for .NET, automate documentation and keep formatting."
---

{{% alert color="info" %}} 

Support for PowerPoint to markdown conversion was implemented in [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint to markdown export is **without images** by default. If you want to export a PowerPoint document containing images, you need to set `ExportType = MarkdownExportType.Visual` and set the BasePath where the images referenced in the markdown document will be saved.

{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class to represent a presentation object.
2. Use the [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)method to save the object as a markdown file.

This C# code shows you how to convert PowerPoint to markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **Convert PowerPoint to Markdown Flavor**

Aspose.Slides allows you to convert PowerPoint to markdown (containing basic syntax), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, and 17 other markdown flavors.

This C# code shows you how to convert PowerPoint to CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

The 23 supported markdown flavors are [listed under the Flavor enumeration](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) from the [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) class.

## **Convert Presentation Containing Images to Markdown**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) class provides properties and enumerations that allow you to use certain options or settings for the resulting markdown file. The [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enum, for example, can be set to values that determine how images are rendered or handled: `Sequential`, `TextOnly`, `Visual`.

### **Convert Images Sequentially**

If you want the images to appear individually one after the other in the resulting markdown, you have to choose the sequential option. This C# code shows you how to convert a presentation containing images to markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Convert Images Visually**

If you want the images to appear together in the resulting markdown, you have to choose the visual option.   In this case, images will be saved to the current directory of the application (and a relative path will be built for them in the markdown document), or you can specify your preferred path and folder name.

This C# code demonstrates the operation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **FAQ**

**Do hyperlinks survive the export to Markdown?**

Yes. Text [hyperlinks](/slides/net/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/net/slide-transition/) and [animations](/slides/net/powerpoint-animation/) are not converted.

**Can I speed up conversion by running it in multiple threads?**

You can parallelize across files, but [don’t share](/slides/net/multithreading/) the same [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance across threads. Use separate instances/processes per file to avoid contention.

**What happens to images—where are they saved, and are the paths relative?**

[Images](/slides/net/image/) are exported to a dedicated folder, and the Markdown file references them with relative paths by default. You can configure the base output path and asset folder name to keep a predictable repository structure.
