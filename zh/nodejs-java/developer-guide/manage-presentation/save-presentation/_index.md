---
title: 在 JavaScript 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/nodejs-java/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存演示文稿
- 保存幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 将演示文稿保存为文件
- 将演示文稿保存为流
- 预定义视图类型
- 严格的 Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 JavaScript 中保存演示文稿——导出为 PowerPoint 或 OpenDocument，同时保留布局、字体和效果。"
---

## **概述**

[在 JavaScript 中打开演示文稿](/slides/zh/nodejs-java/open-presentation/) 介绍了如何使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类打开演示文稿。本文说明了如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建演示文稿还是修改现有演示文稿，完成后都需要保存。使用 Aspose.Slides for Node.js，您可以保存到 **file** 或 **stream**。本文解释了保存演示文稿的不同方式。

## **将演示文稿保存到文件**

通过调用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的 `save` 方法将演示文稿保存到文件。向该方法传递文件名和保存格式。以下示例展示了如何使用 Aspose.Slides 保存演示文稿。
```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 在此执行一些操作...

    // 将演示文稿保存到文件。
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **将演示文稿保存到流**

您可以通过向 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的 `save` 方法传递输出流，将演示文稿保存到流。演示文稿可以写入多种流类型。在下面的示例中，我们创建一个新演示文稿并将其保存到文件流。
```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // 将演示文稿保存到流中。
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```


## **使用预定义视图类型保存演示文稿**

Aspose.Slides 允许您通过 [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/) 类设置生成的演示文稿打开时 PowerPoint 使用的初始视图。使用来自 [ViewType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/) 枚举的值调用 [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) 方法。
```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **以严格的 Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以严格的 Office Open XML 格式保存演示文稿。保存时使用 [PptxOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/) 类并设置其 conformance 属性。如果设置 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict)，输出文件将以严格的 Office Open XML 格式保存。

以下示例创建一个演示文稿并以严格的 Office Open XML 格式保存它。
```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation();
try {
    // 以严格的 Office Open XML 格式保存演示文稿。
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```


## **在 Zip64 模式下以 Office Open XML 格式保存演示文稿**

Office Open XML 文件是一个 ZIP 存档，对任何文件的未压缩大小、压缩大小以及存档的总大小都施加 4 GB (2^32 字节) 的限制，并且将文件数量限制为 65,535 (2^16‑1) 个。ZIP64 格式扩展将这些限制提升至 2^64。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) 方法允许您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

此方法可配合以下模式使用：

- [IfNecessary] 仅在演示文稿超出上述限制时使用 ZIP64 格式扩展。这是默认模式。
- [Never] 从不使用 ZIP64 格式扩展。
- [Always] 始终使用 ZIP64 格式扩展。

以下代码演示了如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX：
```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="注意" color="warning" %}}
当使用 [Zip64Mode.Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) 保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **保存演示文稿时不刷新缩略图**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制将演示文稿保存为 PPTX 时的缩略图生成：

- 若设为 `true`，保存期间刷新缩略图。这是默认值。
- 若设为 `false`，保留当前缩略图。如果演示文稿没有缩略图，则不生成。

以下代码将演示文稿保存为 PPTX，且不刷新其缩略图。
```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```


{{% alert title="信息" color="info" %}}
此选项有助于减少以 PPTX 格式保存演示文稿所需的时间。
{{% /alert %}}

## **以百分比保存进度更新**

通过在 [SaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) 及其子类上使用 [setProgressCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) 方法来配置保存进度报告。提供实现了 [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/) 接口的 Java 代理；在导出期间，回调会接收定期的百分比更新。

以下代码片段展示了如何使用 `IProgressCallback`。
```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // 在此使用进度百分比值。
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="信息" color="info" %}}
Aspose 使用其自身 API 开发了一个 [免费 PowerPoint Splitter 应用](https://products.aspose.app/slides/splitter)。该应用可通过将选定幻灯片另存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**是否支持“快速保存”（增量保存），仅写入更改？**

否。每次保存都会创建完整的目标文件；不支持增量“快速保存”。

**从多个线程保存相同的 Presentation 实例是否线程安全？**

否。一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 实例[不是线程安全的](/slides/zh/nodejs-java/multithreading/)；请在单个线程中进行保存。

**保存时超链接和外部链接文件会怎样？**

[Hyperlinks](/slides/zh/nodejs-java/manage-hyperlinks/) 会被保留。外部链接文件（例如通过相对路径的视频）不会自动复制——请确保引用的路径仍然可访问。

**我可以设置/保存文档元数据（作者、标题、公司、日期）吗？**

是。支持标准 [document properties](/slides/zh/nodejs-java/presentation-properties/)，并将在保存时写入文件。