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
- 将 演示文稿 保存为 Markdown
- 将 幻灯片 保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 将 PPT 导出为 MD
- 将 PPTX 导出为 MD
- PowerPoint
- 演示文稿
- Markdown
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 将 PowerPoint 幻灯片（PPT、PPTX）转换为干净的 Markdown，自动化文档编写并保持格式。"
---

{{% alert color="info" %}} 

已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/java/aspose-slides-for-java-23-7-release-notes/) 中实现对 PowerPoint 到 markdown 转换的支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint 转 markdown 导出默认 **不包含图像**。如果要导出包含图像的 PowerPoint 文档，需要设置 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`，并且还需设置 `BasePath`，用于保存 markdown 文档中引用的图像。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例，以表示演示文稿对象。  
2. 使用 [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 方法将对象保存为 markdown 文件。

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将 PowerPoint 转换为 Markdown 变体**

Aspose.Slides 允许将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格的 markdown、Trello、XWiki、GitLab 以及其他 17 种 markdown 变体。

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


这 23 种受支持的 markdown 变体在 [Flavor 枚举](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) 中列出，来自 [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) 类。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) 类提供属性和枚举，允许您为生成的 markdown 文件使用特定选项或设置。例如，可以将 [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) 枚举设置为以下值，以决定图像的呈现或处理方式：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果希望图像在生成的 markdown 中逐个依次出现，则需要选择 sequential（顺序）选项。下面的 Java 代码演示如何将包含图像的演示文稿转换为 markdown：

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


### **视觉方式转换图像**

如果希望图像在生成的 markdown 中一起出现，则需要选择 visual（视觉）选项。在这种情况下，图像将保存到应用程序的当前目录（并在 markdown 文档中为其构建相对路径），也可以指定您偏好的路径和文件夹名称。

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


## **常见问题**

**超链接在导出为 Markdown 后会保留吗？**

会。文本 [hyperlinks](/slides/zh/java/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/java/slide-transition/) 和 [animations](/slides/zh/java/powerpoint-animation/) 不会被转换。

**我可以通过多线程运行来加快转换速度吗？**

可以对文件进行并行处理，但不要在多个线程之间 [共享](/slides/zh/java/multithreading/) 同一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 实例。每个文件使用独立的实例/进程，以避免竞争。

**图像会怎样处理——保存到哪里，路径是相对的吗？**

[Images](/slides/zh/java/image/) 会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预期的仓库结构。