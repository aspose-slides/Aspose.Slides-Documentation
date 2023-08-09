---
title: Convert PowerPoint to Markdown in C#
type: docs
weight: 140
url: /net/convert-powerpoint-to-markdown/
keywords: "Convert PowerPoint to Markdown, Convert ppt to md, PowerPoint, PPT, PPTX, Presentation, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "Convert PowerPoint to Markdown in C#"
---

{{% alert color="info" %}} 

Support for PowerPoint to markdown conversion was implemented in [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/).

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

## Convert PowerPoint to Markdown Flavor

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

The [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) class provides properties and enum that allow you to use certain options or settings for the resulting markdown file. The [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enum, for example, can be set to values that determine how images are rendered or handled: `Sequential`, `TextOnly`, `Visual`.

### **Convert Images Sequentially**

If you want the images to appear individually one after the other in the resulting markdown, you have to choose the sequential option. This C# code shows you how to convert a presentation containing images to markdown:

```c#
[C#]
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

