---
title: 在 JavaScript 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/nodejs-java/convert-powerpoint-to-markdown/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 JavaScript 中使用 Aspose.Slides for Node.js（通过 Java）将 PowerPoint 幻灯片（PPT、PPTX）转换为整洁的 Markdown，自动化文档并保留格式。"
---

{{% alert color="warning" %}} 

PowerPoint 到 markdown 的导出默认**不含图像**。如果要导出包含图像的 PowerPoint 文档，需要调用 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`，并设置 `BasePath`，以便将 markdown 文档中引用的图像保存到指定位置。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例，以表示演示文稿对象。  
2. 使用 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) 方法，将对象保存为 markdown 文件。

下面的 JavaScript 代码演示了如何将 PowerPoint 转换为 markdown：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将 PowerPoint 转换为 Markdown Flavor**

Aspose.Slides 允许将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub flavored markdown、Trello、XWiki、GitLab 以及另外 17 种 markdown flavor。

下面的 JavaScript 代码演示了如何将 PowerPoint 转换为 CommonMark：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


受支持的 23 种 markdown flavor 列在 [Flavor 枚举](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) 中，可从 [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) 类获取。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) 类提供属性和枚举，可让您为生成的 markdown 文件使用特定选项或设置。例如，可将 [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) 枚举设置为 `Sequential`、`TextOnly`、`Visual`，以确定图像的渲染或处理方式。

### **顺序转换图像**

如果希望图像在生成的 markdown 中逐个单独出现，需要选择 `Sequential` 选项。下面的 JavaScript 代码演示了如何将包含图像的演示文稿转换为 markdown：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **可视化转换图像**

如果希望图像在生成的 markdown 中一起出现，需要选择 `Visual` 选项。此时，图像将保存到应用程序的当前目录（并在 markdown 文档中为其构建相对路径），也可以指定首选的路径和文件夹名称。

下面的 JavaScript 代码演示了该操作：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**超链接在导出为 Markdown 时会被保留吗？**

会。文本[超链接](/slides/zh/nodejs-java/manage-hyperlinks/)会被保留为标准 Markdown 链接。幻灯片[切换](/slides/zh/nodejs-java/slide-transition/)和[动画](/slides/zh/nodejs-java/powerpoint-animation/)则不会被转换。

**可以通过多线程运行来加快转换速度吗？**

可以对文件进行并行处理，但不要在多个线程之间[共享](/slides/zh/nodejs-java/multithreading/)同一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 实例。请为每个文件使用独立的实例或进程，以避免竞争。

**图像会怎样处理——保存到哪里，路径是相对的吗？**

[图像](/slides/zh/nodejs-java/image/)会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预测的仓库结构。