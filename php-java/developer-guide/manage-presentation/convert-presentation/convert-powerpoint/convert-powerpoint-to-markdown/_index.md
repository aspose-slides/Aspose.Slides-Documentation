---
title: Convert PowerPoint to Markdown in Java
type: docs
weight: 140
url: /php-java/convert-powerpoint-to-markdown/
keywords: "Convert PowerPoint to Markdown, Convert ppt to md, PowerPoint, PPT, PPTX, Presentation, Markdown, Java, Aspose.Slides for PHP via Java"
description: "Convert PowerPoint to Markdown in Java"
---

{{% alert color="info" %}} 

Support for PowerPoint to markdown conversion was implemented in [Aspose.Slides 23.7](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-23-7-release-notes/).

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint to markdown export is **without images** by default. If you want to export a PowerPoint document containing images, you need to set  `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` and also set the `BasePath` where the images referenced in the markdown document will be saved.

{{% /alert %}} 

## **Convert PowerPoint to Markdown**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) class to represent a presentation object.
2. Use the [Save ](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)method to save the object as a markdown file.

This Java code shows you how to convert PowerPoint to markdown:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.md", SaveFormat::Md);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }
```

## Convert PowerPoint to Markdown Flavor

Aspose.Slides allows you to convert PowerPoint to markdown (containing basic syntax), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, and 17 other markdown flavors.

This Java code shows you how to convert PowerPoint to CommonMark:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setFlavor(Flavor.CommonMark);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }
```

The 23 supported markdown flavors are [listed under the Flavor enumeration](https://reference.aspose.com/slides/php-java/com.aspose.slides/flavor/) from the [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/markdownsaveoptions/) class.

## **Convert Presentation Containing Images to Markdown**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/com.aspose.slides/markdownsaveoptions/) class provides properties and enumerations that allow you to use certain options or settings for the resulting markdown file. The [MarkdownExportType](https://reference.aspose.com/slides/php-java/com.aspose.slides/markdownexporttype/) enum, for example, can be set to values that determine how images are rendered or handled: `Sequential`, `TextOnly`, `Visual`.

### **Convert Images Sequentially**

If you want the images to appear individually one after the other in the resulting markdown, you have to choose the sequential option. This Java code shows you how to convert a presentation containing images to markdown:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setShowHiddenSlides(true);
    $markdownSaveOptions->setShowSlideNumber(true);
    $markdownSaveOptions->setFlavor(Flavor.Github);
    $markdownSaveOptions->setExportType(MarkdownExportType.Sequential);
    $markdownSaveOptions->setNewLineType(NewLineType.Windows);
    $pres->save("doc.md", new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }
```

### **Convert Images Visually**

If you want the images to appear together in the resulting markdown, you have to choose the visual option.   In this case, images will be saved to the current directory of the application (and a relative path will be built for them in the markdown document), or you can specify your preferred path and folder name.

This Java code demonstrates the operation:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $outPath = "c:/documents";
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setExportType(MarkdownExportType.Visual);
    $markdownSaveOptions->setImagesSaveFolderName("md-images");
    $markdownSaveOptions->setBasePath($outPath);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }
```
