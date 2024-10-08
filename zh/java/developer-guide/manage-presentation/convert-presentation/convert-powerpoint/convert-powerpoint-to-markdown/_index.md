---
title: 在 Java 中将 PowerPoint 转换为 Markdown
type: docs
weight: 140
url: /java/convert-powerpoint-to-markdown/
keywords: "将 PowerPoint 转换为 Markdown, 将 ppt 转换为 md, PowerPoint, PPT, PPTX, 演示, Markdown, Java, Aspose.Slides for Java"
description: "在 Java 中将 PowerPoint 转换为 Markdown"
---

{{% alert color="info" %}} 

在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/) 中实现了对 PowerPoint 转换为 Markdown 的支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint 到 Markdown 的导出默认是 **不包含图像** 的。如果您想导出包含图像的 PowerPoint 文档，需要设置 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` 并设置 `BasePath`，以便在 Markdown 文档中引用的图像将被保存。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例以表示演示文稿对象。
2. 使用 [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 方法将对象保存为 Markdown 文件。

以下 Java 代码演示了如何将 PowerPoint 转换为 Markdown：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## 将 PowerPoint 转换为 Markdown 风格

Aspose.Slides 允许您将 PowerPoint 转换为基本语法的 Markdown、CommonMark、GitHub 风格的 Markdown、Trello、XWiki、GitLab 以及其他 17 种 Markdown 风格。

以下 Java 代码演示了如何将 PowerPoint 转换为 CommonMark：

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

支持的 23 种 Markdown 风格在 [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) 类的 [Flavor 枚举](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) 下列出。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) 类提供了允许您为生成的 Markdown 文件使用某些选项或设置的属性和枚举。例如，[MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) 枚举可以设置为确定图像如何呈现或处理的值：`Sequential`，`TextOnly`，`Visual`。

### **顺序转换图像**

如果您希望图像在生成的 Markdown 中一个接一个地出现，则必须选择顺序选项。以下 Java 代码演示了如何将包含图像的演示文稿转换为 Markdown：

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

### **视觉上转换图像**

如果您希望图像在生成的 Markdown 中一起出现，则必须选择视觉选项。在这种情况下，图像将被保存到应用程序的当前目录（在 Markdown 文档中将为它们构建相对路径），或者您可以指定您首选的路径和文件夹名称。

以下 Java 代码演示了该操作：

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