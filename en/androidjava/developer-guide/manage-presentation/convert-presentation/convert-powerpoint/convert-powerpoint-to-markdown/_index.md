---
title: Convert PowerPoint Presentations to Markdown on Android
linktitle: PowerPoint to Markdown
type: docs
weight: 140
url: /androidjava/convert-powerpoint-to-markdown/
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
- Android
- Java
- Aspose.Slides
description: "Convert PowerPoint slides—PPT, PPTX—to clean Markdown with Aspose.Slides for Android via Java, automate documentation and keep formatting."
---

Aspose.Slides supports presentation-to-markdown conversion.

{{% alert color="warning" %}} 

PowerPoint to markdown export is **without images** by default. If you want to export a PowerPoint document containing images, you need to set  `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` and also set the `BasePath` where the images referenced in the markdown document will be saved.

{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class to represent a presentation object.
2. Use the [Save ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)method to save the object as a markdown file.

This Java code shows you how to convert PowerPoint to markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PowerPoint to Markdown Flavor**

Aspose.Slides allows you to convert PowerPoint to markdown (containing basic syntax), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, and 17 other markdown flavors.

This Java code shows you how to convert PowerPoint to CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

The 23 supported markdown flavors are [listed under the Flavor enumeration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/) from the [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) class.

## **Convert a Presentation Containing Images to Markdown**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) class provides properties and enumerations that allow you to use certain options or settings for the resulting markdown file. The [MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/) enum, for example, can be set to values that determine how images are rendered or handled: `Sequential`, `TextOnly`, `Visual`.

### **Convert Images Sequentially**

If you want the images to appear individually one after the other in the resulting markdown, you have to choose the sequential option. This Java code shows you how to convert a presentation containing images to markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convert Images Visually**

If you want the images to appear together in the resulting markdown, you have to choose the visual option.   In this case, images will be saved to the current directory of the application (and a relative path will be built for them in the markdown document), or you can specify your preferred path and folder name.

This Java code demonstrates the operation:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Do hyperlinks survive the export to Markdown?**

Yes. Text [hyperlinks](/slides/androidjava/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/androidjava/slide-transition/) and [animations](/slides/androidjava/powerpoint-animation/) are not converted.

**Can I speed up conversion by running it in multiple threads?**

You can parallelize across files, but [don’t share](/slides/androidjava/multithreading/) the same [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) instance across threads. Use separate instances/processes per file to avoid contention.

**What happens to images—where are they saved, and are the paths relative?**

[Images](/slides/androidjava/image/) are exported to a dedicated folder, and the Markdown file references them with relative paths by default. You can configure the base output path and asset folder name to keep a predictable repository structure.
