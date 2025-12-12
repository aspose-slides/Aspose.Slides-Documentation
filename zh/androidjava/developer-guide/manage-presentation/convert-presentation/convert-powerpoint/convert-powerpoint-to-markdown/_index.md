---
title: 将 PowerPoint 演示文稿转换为 Android 上的 Markdown
linktitle: PowerPoint 到 Markdown
type: docs
weight: 140
url: /zh/androidjava/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 到 MD
- 演示文稿 到 MD
- 幻灯片 到 MD
- PPT 到 MD
- PPTX 到 MD
- 将 PowerPoint 保存为 Markdown
- 将 演示文稿 保存为 Markdown
- 将 幻灯片 保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- PowerPoint
- 演示文稿
- Markdown
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 通过 Java 将 PowerPoint 幻灯片（PPT、PPTX）转换为干净的 Markdown，自动化文档编写并保持格式。"
---

{{% alert color="info" %}} 

在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-23-7-release-notes/) 中实现了 PowerPoint 到 markdown 的转换支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint 到 markdown 的导出默认 **不包含图像**。如果需要导出包含图像的 PowerPoint 文档，必须设置 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`，并设置 `BasePath`，以指定 markdown 文档中引用的图像保存位置。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个表示演示文稿对象的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 实例。  
2. 使用 [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) 方法将对象保存为 markdown 文件。

以下 Java 代码演示了如何将 PowerPoint 转换为 markdown：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将 PowerPoint 转换为 Markdown Flavor**

Aspose.Slides 支持将 PowerPoint 转换为 markdown（基本语法）、CommonMark、GitHub 风格 markdown、Trello、XWiki、GitLab 等 17 种其他 markdown 变体。

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


23 种受支持的 markdown 变体列在 [Flavor 枚举](https://reference.aspose.com/slides/androidjava/com.aspose.slides.flavor/) 中，可通过 [MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) 类进行设置。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markdownsaveoptions/) 类提供属性和枚举，允许您为生成的 markdown 文件指定特定选项或设置。例如，`MarkdownExportType` 枚举可设置为 `Sequential`、`TextOnly`、`Visual`，以决定图像的渲染或处理方式。

### **顺序转换图像**

如果希望图像在生成的 markdown 中依次单独出现，需要选择 `Sequential` 选项。以下 Java 代码演示了如何将包含图像的演示文稿转换为 markdown：
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

如果希望图像在生成的 markdown 中一起显示，需要选择 `Visual` 选项。此情况下，图像将保存到应用程序的当前目录（并在 markdown 文档中生成相对路径），或您可以指定自定义的路径和文件夹名称。

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


## **FAQ**

**超链接在导出为 Markdown 后是否保留？**

是的。文本 [超链接](/slides/zh/androidjava/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片 [过渡](/slides/zh/androidjava/slide-transition/) 和 [动画](/slides/zh/androidjava/powerpoint-animation/) 不会被转换。

**可以通过多线程运行来加速转换吗？**

可以在文件之间并行处理，但不要在多个线程间共享同一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 实例。每个文件使用独立的实例或进程，以避免竞争。

**图像会怎么处理——保存到哪里，路径是否为相对路径？**

[图像](/slides/zh/androidjava/image/) 会导出到专用文件夹，默认情况下 Markdown 文件使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持仓库结构的可预测性。