---
title: Convert PowerPoint Presentations to Markdown in PHP
linktitle: PowerPoint to Markdown
type: docs
weight: 140
url: /php-java/convert-powerpoint-to-markdown/
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
- PHP
- Aspose.Slides
description: "Convert PowerPoint slides — PPT, PPTX — to clean Markdown with Aspose.Slides for PHP via Java, automate documentation and keep formatting."
---

## **Introduction**

Aspose.Slides allows you to convert PowerPoint presentations to Markdown, which can be useful for documentation workflows, static site generation, content migration, and version-controlled text publishing. The API supports direct export from PPT and PPTX presentations to MD files and provides additional options to control how slide content is represented in the resulting Markdown document.

You can export presentations as plain Markdown, choose from multiple Markdown flavors such as CommonMark and GitHub Flavored Markdown, and configure how images are handled during export. For presentations that contain visual content, Aspose.Slides also lets you save images to a separate folder and reference them from the generated Markdown file.

{{% alert color="warning" %}}

PowerPoint-to-Markdown export is **without images** by default. If you want to export a PowerPoint document containing images, you need to set `ExportType = MarkdownExportType::Visual` and specify `BasePath`, where the images referenced in the Markdown document will be saved.

{{% /alert %}}

## **Convert a Presentation to Markdown**

This section explains how Aspose.Slides converts PowerPoint and OpenDocument presentations (PPT, PPTX, ODP) into clean Markdown, keeping the original slide hierarchy, text, and core formatting intact so you can reuse the content in documentation or version‑controlled workflows without extra manual effort.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class to represent the presentation.
1. Use the [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) method to export it as a Markdown file.

This PHP code shows how to convert a PowerPoint presentation to Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Convert a Presentation to Markdown Flavor**

Aspose.Slides lets you convert PowerPoint presentations to Markdown with basic syntax, as well as to CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab, and seventeen other Markdown flavors.

The following PHP code demonstrates how to convert a PowerPoint presentation to CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

The 23 supported Markdown flavors are listed in the [Flavor enumeration](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/).

## **Convert a Presentation Containing Images to Markdown**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) class exposes properties and enumerations that let you configure the resulting Markdown file. For example, the [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) enumeration specifies how images are handled: `Sequential`, `TextOnly`, or `Visual`.

{{% alert color="warning" %}}

By default, PowerPoint‑to‑Markdown export **does not include images**. To embed images, call `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` and set the `BasePath` that specifies where the images referenced in the Markdown file will be saved.

{{% /alert %}}

### **Convert Images Sequentially**

If you want the images to appear individually, one after the other, in the resulting Markdown, you must choose the `Sequential` option. The following PHP code shows how to convert a presentation containing images to Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Convert Images Visually**

If you want the images to appear together in the resulting Markdown, you must choose the `Visual` option. In this case, the images are saved to the application’s current directory (and a relative path is generated for them in the Markdown document), or you can specify your preferred directory and folder name.

The following PHP code demonstrates the operation:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Do hyperlinks survive the export to Markdown?**

Yes. Text [hyperlinks](/slides/php-java/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/php-java/slide-transition/) and [animations](/slides/php-java/powerpoint-animation/) are not converted.

**Can I speed up conversion by running it in multiple threads?**

You can parallelize across files, but [don’t share](/slides/php-java/multithreading/) the same [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) instance across threads. Use separate instances/processes per file to avoid contention.

**What happens to images—where are they saved, and are the paths relative?**

[Images](/slides/php-java/image/) are exported to a dedicated folder, and the Markdown file references them with relative paths by default. You can configure the base output path and asset folder name to keep a predictable repository structure.
