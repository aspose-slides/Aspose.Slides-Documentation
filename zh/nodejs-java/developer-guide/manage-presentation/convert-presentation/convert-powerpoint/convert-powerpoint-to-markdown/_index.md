---
title: 在 JavaScript 中将 PowerPoint 转换为 Markdown
type: docs
weight: 140
url: /zh/nodejs-java/convert-powerpoint-to-markdown/
keywords: "将 PowerPoint 转换为 Markdown, 将 ppt 转换为 md, PowerPoint, PPT, PPTX, 演示文稿, Markdown, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中将 PowerPoint 转换为 Markdown"
---

{{% alert color="info" %}} 

已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-23-7-release-notes/) 中实现对 PowerPoint 到 markdown 转换的支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint 到 markdown 导出默认 **不包含图像**。如果您想导出包含图像的 PowerPoint 文档，需要调用 `markdownSaveOptions.setExportType(MarkdownExportType.Visual)`，并设置 `BasePath`，以指定 markdown 文档中引用的图像保存位置。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例以表示演示文稿对象。
2. 使用 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) 方法将对象保存为 markdown 文件。

下面的 JavaScript 代码演示了如何将 PowerPoint 转换为 markdown:
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


## **将 PowerPoint 转换为 Markdown 变体**

Aspose.Slides 允许您将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格的 markdown、Trello、XWiki、GitLab 以及其他 17 种 markdown 变体。

下面的 JavaScript 代码演示了如何将 PowerPoint 转换为 CommonMark:
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


这 23 种受支持的 markdown 变体已在来自 [MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) 类的 [Flavor 枚举](https://reference.aspose.com/slides/nodejs-java/aspose.slides/flavor/) 中列出。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownsaveoptions/) 类提供属性和枚举，可让您为生成的 markdown 文件使用特定的选项或设置。例如，您可以将 [MarkdownExportType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markdownexporttype/) 枚举设置为决定图像渲染或处理方式的值：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果您希望图像在生成的 markdown 中依次单独出现，需要选择 sequential 选项。下面的 JavaScript 代码演示了如何将包含图像的演示文稿转换为 markdown:
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


### **视觉转换图像**

如果您希望图像在生成的 markdown 中一起出现，需要选择 visual 选项。在这种情况下，图像将保存到应用程序的当前目录（并在 markdown 文档中构建相对路径），您也可以指定首选的路径和文件夹名称。

下面的 JavaScript 代码演示了该操作:
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


## **常见问题**

**超链接在导出为 Markdown 时会保留吗？**

是的。文本[超链接](/slides/zh/nodejs-java/manage-hyperlinks/)会保留为标准的 Markdown 链接。幻灯片[切换](/slides/zh/nodejs-java/slide-transition/)和[动画](/slides/zh/nodejs-java/powerpoint-animation/)不会被转换。

**我可以通过多线程运行来加速转换吗？**

可以对文件进行并行处理，但不要在多个线程之间[共享](/slides/zh/nodejs-java/multithreading/)同一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 实例。对每个文件使用单独的实例/进程以避免竞争。

**图像会怎样——保存在哪里，路径是相对的吗？**

[图像](/slides/zh/nodejs-java/image/)会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预测的仓库结构。