---
title: 将 PowerPoint 转换为 Markdown
type: docs
weight: 140
url: /php-java/convert-powerpoint-to-markdown/
keywords: "将 PowerPoint 转换为 Markdown, 将 ppt 转换为 md, PowerPoint, PPT, PPTX, 演示文稿, Markdown, Java, Aspose.Slides for PHP via Java"
description: "将 PowerPoint 转换为 Markdown"
---

{{% alert color="info" %}} 

对 PowerPoint 到 markdown 转换的支持是在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-23-7-release-notes/) 中实现的。

{{% /alert %}} 

{{% alert color="warning" %}} 

默认情况下，PowerPoint 到 markdown 导出是**不包含图像的**。如果您想导出包含图像的 PowerPoint 文档，则需要设置 `markdownSaveOptions.setExportType(MarkdownExportType::Visual)`，并设置 `BasePath`，以便在 markdown 文档中引用的图像将被保存。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类的实例，以表示演示文稿对象。
2. 使用 [Save ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 方法将对象保存为 markdown 文件。

以下 PHP 代码演示了如何将 PowerPoint 转换为 markdown：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.md", SaveFormat::Md);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 将 PowerPoint 转换为 Markdown 风格

Aspose.Slides 允许您将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格的 markdown、Trello、XWiki、GitLab 和其他 17 种 markdown 风格。

以下 PHP 代码演示了如何将 PowerPoint 转换为 CommonMark：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setFlavor(Flavor->CommonMark);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

23 种支持的 markdown 风格在 [MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) 类的 [Flavor 枚举](https://reference.aspose.com/slides/php-java/aspose.slides/flavor/) 中列出。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/markdownsaveoptions/) 类提供了允许您对生成的 markdown 文件使用某些选项或设置的属性和枚举。例如，[MarkdownExportType](https://reference.aspose.com/slides/php-java/aspose.slides/markdownexporttype/) 枚举可以设置为确定图像如何渲染或处理的值：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果您希望图像一个接一个地单独出现在生成的 markdown 中，您必须选择顺序选项。以下 PHP 代码演示了如何将包含图像的演示文稿转换为 markdown：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setShowHiddenSlides(true);
    $markdownSaveOptions->setShowSlideNumber(true);
    $markdownSaveOptions->setFlavor(Flavor->Github);
    $markdownSaveOptions->setExportType(MarkdownExportType::Sequential);
    $markdownSaveOptions->setNewLineType(NewLineType::Windows);
    $pres->save("doc.md", array(1, 2, 3, 4, 5, 6, 7, 8, 9 ), SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **视觉转换图像**

如果您希望图像在生成的 markdown 中一起出现，您必须选择视觉选项。在这种情况下，图像将被保存到应用程序的当前目录（在 markdown 文档中将为它们构建相对路径），或者您可以指定您喜欢的路径和文件夹名称。

以下 PHP 代码演示了该操作：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $outPath = "c:/documents";
    $markdownSaveOptions = new MarkdownSaveOptions();
    $markdownSaveOptions->setExportType(MarkdownExportType::Visual);
    $markdownSaveOptions->setImagesSaveFolderName("md-images");
    $markdownSaveOptions->setBasePath($outPath);
    $pres->save("pres.md", SaveFormat::Md, $markdownSaveOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```