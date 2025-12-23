---
title: 在 PHP 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/php-java/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿转 MD
- 幻灯片转 MD
- PPT 转 MD
- PPTX 转 MD
- 将 PowerPoint 保存为 Markdown
- 将演示文稿保存为 Markdown
- 将幻灯片保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- PowerPoint
- 演示文稿
- Markdown
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将 PowerPoint 幻灯片（PPT、PPTX）转换为简洁的 Markdown，实现文档自动化并保持格式。"
---

## **概述**

Aspose.Slides for PHP via Java 可将演示文稿内容转换为 Markdown，让您能够在维基、Git 仓库和静态站点生成器中重新使用 PowerPoint（PPT、PPTX）和 OpenDocument（ODP）文件。该 API 在生成轻量级、可读的 Markdown 的同时保留幻灯片层次结构，从而可以自动化文档流水线，并保持源演示文稿与 Markdown 文件的完美同步。

PowerPoint 到 Markdown 的转换支持已在 [Aspose.Slides 23.7](https://releases.aspose.com/slides/php-java/release-notes/2023/aspose-slides-for-php-via-java-23-7-release-notes/) 中实现。

## **将演示文稿转换为 Markdown**

本节说明 Aspose.Slides 如何将 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX、ODP）转换为干净的 Markdown，保持原始幻灯片层次结构、文本和核心格式不变，以便您在文档或受版本控制的工作流中重复使用内容，而无需额外的人工操作。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例以表示演示文稿。  
1. 使用 [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 方法将其导出为 Markdown 文件。

下面的 PHP 代码演示了如何将 PowerPoint 演示文稿转换为 Markdown：
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```


## **将演示文稿转换为 Markdown 方言**

Aspose.Slides 允许您将 PowerPoint 演示文稿转换为使用基本语法的 Markdown，以及 CommonMark、GitHub 风格的 Markdown、Trello、XWiki、GitLab 和另外十七种 Markdown 方言。

下面的 PHP 代码演示了如何将 PowerPoint 演示文稿转换为 CommonMark：
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


支持的 23 种 Markdown 方言列在 [Flavor enumeration](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/) 中。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) 类提供属性和枚举，让您配置生成的 Markdown 文件。例如， [MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) 枚举指定图像的处理方式：`Sequential`、`TextOnly` 或 `Visual`。

{{% alert color="warning" %}}
默认情况下，PowerPoint 到 Markdown 的导出 **不包括图像**。若要嵌入图像，请调用 `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` 并设置 `BasePath`，该路径指定 Markdown 文件中引用的图像将保存的位置。
{{% /alert %}}

### **顺序转换图像**

如果您希望图像在生成的 Markdown 中逐个依次出现，必须选择 `Sequential` 选项。下面的 PHP 代码演示了如何将包含图像的演示文稿转换为 Markdown：
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


### **视觉方式转换图像**

如果您希望图像在生成的 Markdown 中一起出现，必须选择 `Visual` 选项。在此情况下，图像会保存到应用程序的当前目录（并在 Markdown 文档中生成相对路径），或您可以指定自定义的目录和文件夹名称。

下面的 PHP 代码演示了此操作：
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


## **常见问题**

**超链接在导出为 Markdown 时会保留吗？**

是的。文本 [hyperlinks](/slides/zh/php-java/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片[transitions](/slides/zh/php-java/slide-transition/)和[animations](/slides/zh/php-java/powerpoint-animation/) 则不会被转换。

**我可以通过多线程运行来加速转换吗？**

可以对文件进行并行处理，但不能在多个线程之间 [共享](/slides/zh/php-java/multithreading/) 同一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 实例。请为每个文件使用独立的实例/进程，以避免竞争。

**图像会怎样处理——保存在哪里，路径是否为相对路径？**

[Images](/slides/zh/php-java/image/) 会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预测的仓库结构。