---
title: 在 JavaScript 中保存演示文稿
linktitle: 保存演示文稿
type: docs
weight: 80
url: /zh/nodejs-java/save-presentation/
keywords:
- 保存 PowerPoint
- 保存 OpenDocument
- 保存 演示文稿
- 保存 幻灯片
- 保存 PPT
- 保存 PPTX
- 保存 ODP
- 演示文稿 保存为文件
- 演示文稿 保存为流
- 预定义视图类型
- 严格的 Office Open XML 格式
- Zip64 模式
- 刷新缩略图
- 保存进度
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js 通过 Java 保存演示文稿——导出为 PowerPoint 或 OpenDocument，同时保留布局、字体和效果。"
---
## **概述**

[Open Presentations in JavaScript](/slides/zh/nodejs-java/open-presentation/) 描述了如何使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类打开演示文稿。本文说明如何创建和保存演示文稿。[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类包含演示文稿的内容。无论是从头创建还是修改现有演示文稿，完成后都需要保存。使用 Aspose.Slides for Node.js，您可以保存为 **file** 或 **stream**。本文解释了保存演示文稿的不同方式。

## **将演示文稿保存到文件**

通过调用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的 `save` 方法将演示文稿保存到文件。向该方法传递文件名和保存格式。以下示例展示了如何使用 Aspose.Slides 保存演示文稿。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

您可以通过向 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的 `save` 方法传递输出流来将演示文稿保存到流。演示文稿可以写入多种流类型。下面的示例创建一个新演示文稿并将其保存到文件流。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Aspose.Slides 允许您通过 [ViewProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/) 类设置生成的演示文稿打开时 PowerPoint 使用的初始视图。使用 [setLastView](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/#setLastView) 方法并提供来自 [ViewType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewtype/) 枚举的值。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以严格的 Office Open XML 格式保存演示文稿**

Aspose.Slides 允许您以 Strict Office Open XML 格式保存演示文稿。使用 [PptxOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxoptions/) 类并在保存时设置其 conformance 属性。如果设置了 [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict)，输出文件将以 Strict Office Open XML 格式保存。

下面的示例创建演示文稿并以 Strict Office Open XML 格式保存。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **以 Zip64 模式在 Office Open XML 格式中保存演示文稿**

Office Open XML 文件是一个 ZIP 存档，对任意文件的未压缩大小、压缩后大小以及存档的总大小都限制为 4 GB（2^32 字节），并且存档最多只能包含 65 535（2^16‑1）个文件。ZIP64 格式扩展将这些限制提升至 2^64。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) 方法允许您在保存 Office Open XML 文件时选择何时使用 ZIP64 格式扩展。

此方法可与以下模式一起使用：

- [IfNecessary] 仅在演示文稿超过上述限制时使用 ZIP64 格式扩展。这是默认模式。
- [Never] 永不使用 ZIP64 格式扩展。
- [Always] 始终使用 ZIP64 格式扩展。

以下代码演示如何在启用 ZIP64 格式扩展的情况下将演示文稿保存为 PPTX 文件：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
当使用 [Zip64Mode.Never](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/zip64mode/#Never) 保存时，如果演示文稿无法以 ZIP32 格式保存，将抛出 [PptxException](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **在 Office Open XML 格式中使用压缩级别保存演示文稿**

处理大型演示文稿时，您可以调节压缩级别以在文件大小和处理时间之间取得平衡。根据需求，您可能更倾向于更快的处理速度或更小的输出文件。

Aspose.Slides 提供了 [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) 方法，允许您指定在 Office Open XML 格式下保存演示文稿时使用的压缩级别。

可用的压缩级别如下：

- [**None**]：不进行任何压缩。文件保持原样存储。
- [**Level1**]：最快的压缩速度，压缩比最低。
- [**Level2**]：比 **Level1** 稍好压缩比的更快压缩。
- [**Level3**]：在处理时间影响适中的情况下提供比 **Level2** 更好的压缩。
- [**Level4**]：提供比 **Level3** 更好的压缩。
- [**Level5**]：在 **Level4** 基础上进一步提升压缩，同时增加处理时间。
- [**Level6**]：标准压缩，在处理速度和文件大小之间提供良好平衡。这是 *默认压缩级别*。
- [**Level7**]：比 **Level6** 更好的压缩，但处理速度较慢。
- [**Level8**]：提供比 **Level7** 更好的压缩。
- [**Level9**]：最高压缩率。产生最小的文件大小，但需要最长的处理时间。

以下示例演示如何以 *无压缩* 的方式将演示文稿保存为 PPTX 文件：

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

此示例展示如何以 *最高压缩* 的方式将演示文稿保存为 PPTX 文件：

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **保存演示文稿时不刷新缩略图**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制在将演示文稿保存为 PPTX 时是否生成缩略图：

- 如果设置为 `true`，保存期间会刷新缩略图。这是默认行为。
- 如果设置为 `false`，保留当前缩略图。如果演示文稿没有缩略图，则不会生成。

下面的代码将演示文稿保存为 PPTX 而不刷新其缩略图。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert title="Info" color="info" %}}
此选项有助于减少以 PPTX 格式保存演示文稿所需的时间。
{{% /alert %}}

## **以百分比形式保存进度更新**

保存进度报告通过在 [SaveOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveoptions/) 及其子类上使用 [setProgressCallback](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) 方法进行配置。提供实现了 [IProgressCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/) 接口的 Java 代理；在导出期间，回调会定期收到百分比更新。

以下代码片段展示如何使用 `IProgressCallback`。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // 在这里使用进度百分比值。
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

{{% alert title="Info" color="info" %}}
Aspose 使用自身 API 开发了一个 [free PowerPoint Splitter app](https://products.aspose.app/slides/zh/splitter)。该应用可通过将选定的幻灯片保存为新的 PPTX 或 PPT 文件，将演示文稿拆分为多个文件。
{{% /alert %}}

## **常见问题**

**“快速保存”（增量保存）是否受支持，仅写入更改？**  
不支持。每次保存都会重新创建完整的目标文件，增量“快速保存”不受支持。

**是否可以从多个线程安全地保存同一 Presentation 实例？**  
不可以。一个 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例 [isn’t thread-safe](/slides/zh/nodejs-java/multithreading/)，请在单线程中进行保存。

**保存时超链接和外部链接文件会怎样？**  
[Hyperlinks](/slides/zh/nodejs-java/manage-hyperlinks/) 会被保留。外部链接的文件（例如通过相对路径引用的视频）不会自动复制——请确保相应路径仍然可访问。

**我能设置/保存文档元数据（作者、标题、公司、日期）吗？**  
可以。标准的 [document properties](/slides/zh/nodejs-java/presentation-properties/) 受支持，保存时会写入文件中。