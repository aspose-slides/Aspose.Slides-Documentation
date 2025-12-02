---
title: 在 Java 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/java/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿 转 MD
- 幻灯片 转 MD
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 将 PowerPoint 幻灯片（PPT、PPTX）转换为干净的 Markdown，实现文档自动化并保持格式。"
---

{{% alert color="info" %}} 

PowerPoint 到 markdown 转换的支持已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/) 中实现。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint 到 markdown 导出默认 **不包含图像**。如果需要导出包含图像的 PowerPoint 文档，必须设置 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` 并指定 `BasePath`，以便在 markdown 文档中引用的图像保存到该路径。

{{% /alert %}} 

## **将PowerPoint转换为Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例来表示演示文稿对象。  
2. 使用 [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 方法将对象保存为 markdown 文件。

下面的 Java 代码演示了如何将 PowerPoint 转换为 markdown：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## 将PowerPoint转换为Markdown格式

Aspose.Slides 允许将 PowerPoint 转换为 markdown（基本语法）、CommonMark、GitHub Flavored Markdown、Trello、XWiki、GitLab 以及其他 17 种 markdown 格式。

下面的 Java 代码演示了如何将 PowerPoint 转换为 CommonMark：
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


23 种受支持的 markdown 格式列在 [Flavor 枚举](https://reference.aspose.com/slides/java/com.aspose.slides.flavor/) 中，属于 [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) 类。

## **将包含图像的演示文稿转换为Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) 类提供属性和枚举，允许您为生成的 markdown 文件使用特定选项或设置。例如，`MarkdownExportType` 枚举可以设置为以下值，以决定图像的呈现或处理方式：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果希望图像在生成的 markdown 中一个接一个单独出现，需要选择 `Sequential` 选项。下面的 Java 代码演示了如何将包含图像的演示文稿转换为 markdown：
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


### **可视化转换图像**

如果希望图像在生成的 markdown 中一起出现，需要选择 `Visual` 选项。此时，图像将保存到应用程序的当前目录（在 markdown 文档中会生成相对路径），或者您可以指定自定义的路径和文件夹名称。

下面的 Java 代码演示了此操作：
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
