---
title: 在Java中将PowerPoint转换为Markdown
type: docs
weight: 140
url: /androidjava/convert-powerpoint-to-markdown/
keywords: "将PowerPoint转换为Markdown, 将ppt转换为md, PowerPoint, PPT, PPTX, 演示文稿, Markdown, Java, Aspose.Slides for Android via Java"
description: "在Java中将PowerPoint转换为Markdown"
---

{{% alert color="info" %}} 

在[Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/)中实现了对PowerPoint到Markdown转换的支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint到Markdown导出默认情况下是**没有图像**的。如果您想导出包含图像的PowerPoint文档，需要设置 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`，并设置`BasePath`，以便在Markdown文档中引用的图像将被保存。

{{% /alert %}} 

## **将PowerPoint转换为Markdown**

1. 创建一个[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)类的实例，以表示演示文稿对象。
2. 使用[Save ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)方法将对象保存为Markdown文件。

以下Java代码展示了如何将PowerPoint转换为Markdown：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## 将PowerPoint转换为Markdown风格

Aspose.Slides允许您将PowerPoint转换为包含基本语法的Markdown、CommonMark、GitHub风味的Markdown、Trello、XWiki、GitLab和其他17种Markdown风格。

以下Java代码展示了如何将PowerPoint转换为CommonMark：

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

支持的23种Markdown风格在[Flavor枚举](https://reference.aspose.com/slides/androidjava/com.aspose.slides/flavor/)中列出，来自[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/)类。

## **将包含图像的演示文稿转换为Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/)类提供了允许您使用某些选项或设置的属性和枚举，用于生成的Markdown文件。例如，[MarkdownExportType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownexporttype/)枚举可以设置为确定如何渲染或处理图像的值：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果您希望图像在生成的Markdown中一个接一个地出现，您必须选择顺序选项。以下Java代码展示了如何将包含图像的演示文稿转换为Markdown：

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

### **视觉转换图像**

如果您希望图像在生成的Markdown中一起出现，您必须选择视觉选项。在这种情况下，图像将保存到应用程序的当前目录（并在Markdown文档中为其构建相对路径），或者您可以指定首选的路径和文件夹名称。

以下Java代码演示了这一操作：

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