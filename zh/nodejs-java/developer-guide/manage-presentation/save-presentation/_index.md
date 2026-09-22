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
description: "使用 Aspose.Slides 在 JavaScript 中将 PowerPoint 和 OpenDocument 演示文稿保存为文件或流，并配置 PPTX 输出和进度报告。"
---
## **概述**

创建演示文稿或[打开现有演示文稿](/slides/zh/nodejs-java/open-presentation/)后，使用[Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save)方法写入结果。Aspose.Slides for Node.js via Java 可以将演示文稿保存为文件或流，支持 PowerPoint、OpenDocument、PDF 等格式。以下章节介绍标准保存操作以及 PPTX 输出可用的选项。

## **将演示文稿保存到文件**

要将演示文稿保存到文件，请向[Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save)方法传递输出路径和一个[SaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/)值。该格式值决定 Aspose.Slides 创建的文件类型。

以下示例创建一个演示文稿并将其保存为 PPTX 文件：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // 在此添加或修改演示文稿内容。

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以原始格式保存演示文稿**

在文件和流检测示例、新创建的演示文稿的行为以及源格式与输出格式的区别方面，请参阅[确定原始演示文稿格式](/slides/zh/nodejs-java/detect-presentation-source-format/)。

在批处理应用程序中，输入格式可能事先未知。加载文件后，可通过[Presentation.getSourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSourceFormat)方法读取其原始格式。将得到的[SourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sourceformat/)值传递给[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/#toSaveFormat)以获取对应的[SaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/)值，然后使用[Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save)写入修改后的演示文稿。

以下完整示例遍历输入目录中的每个文件，更新其标题，并以加载时的格式保存到输出目录：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/#toSaveFormat) 将 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 和 PowerPoint XML 映射到相应的演示文稿保存格式。它仅映射演示文稿源格式；并非用于选择 PDF、HTML、TIFF 或图像等导出格式。传递不受支持或无效的[SourceFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sourceformat/)值会导致错误。

传统的 PPT、PPS 和 POT 文件使用相同的二进制容器。当此类演示文稿从没有文件扩展名的流中加载时，PPS 或 POT 文件可能会被识别为 PPT。如果需要保留这些遗留子类型，请单独保存原始文件名或格式元数据，并在选择输出文件名和格式时使用它们。

## **将演示文稿保存到流**

若不依赖最终文件路径写入演示文稿，可向[Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save)方法传递可写流和一个[SaveFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveformat/)值。当输出需要从 Web 服务返回、存储在数据库中或在内存中处理时，此方法非常有用。

以下示例将新演示文稿保存到文件流：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **使用预定义视图类型保存演示文稿**

您可以指定 PowerPoint 打开已保存演示文稿时的初始视图。保存前，使用带有[ViewType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewtype/)值的[ViewProperties.setLastView](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/viewproperties/#setLastView)方法。

以下示例将 Slide Master 视图配置为初始视图：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **以严格的 Office Open XML 格式保存演示文稿**

要创建符合 Office Open XML 严格配置文件的 PPTX 文件，需实例化一个[PptxOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxoptions/)，并使用其[setConformance](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxoptions/#setConformance)方法，传入[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict)。然后将该选项传递给[Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save)方法。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **以 Zip64 模式保存 Office Open XML 格式的演示文稿**

标准 ZIP 存档对每个条目的压缩和未压缩大小、存档的总体大小以及条目数量都有限制。由于 PPTX 文件是 ZIP 存档，极大的演示文稿可能会超出这些限制。ZIP64 扩展提升了相应的大小和条目数量限制。

使用[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode)方法可控制 Aspose.Slides 是否写入 ZIP64 扩展：

- [IfNecessary](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/zip64mode/#IfNecessary) 仅在演示文稿超过标准 ZIP 限制时使用 ZIP64。这是默认模式。
- [Never](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/zip64mode/#Never) 禁用 ZIP64 扩展。
- [Always](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/zip64mode/#Always) 始终写入 ZIP64 扩展。

以下示例始终为输出演示文稿启用 ZIP64 扩展：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
如果使用[Zip64Mode.Never](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/zip64mode/#Never)且演示文稿无法适应标准 ZIP 限制，保存操作将抛出[PptxException](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **使用压缩级别保存 Office Open XML 格式的演示文稿**

对于 PPTX 输出，您可以使用[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) 方法在保存速度和文件大小之间取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compressionlevel/) 类提供以下值：

- [None](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compressionlevel/#None) 不进行压缩地存储数据。
- [Level1](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compressionlevel/#Level1) 提供最快的压缩速度，但压缩后文件最大。
- [Level2](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compressionlevel/#Level2) 至 [Level5](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compressionlevel/#Level5) 逐步倾向于更小的输出，而牺牲保存速度。
- [Level6](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compressionlevel/#Level6) 在保存速度和文件大小之间取得平衡。这是默认级别。
- [Level7](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compressionlevel/#Level7) 和 [Level8](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compressionlevel/#Level8) 更进一步倾向于更小的输出，而牺牲保存速度。
- [Level9](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/compressionlevel/#Level9) 提供最强的压缩，但需要最长的处理时间。

以下示例将演示文稿保存为无压缩：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

以下示例使用最高压缩级别：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **保存演示文稿时不刷新缩略图**

当演示文稿保存为 PPTX 时，[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制其文档缩略图：

- `true` 在保存过程中重新生成缩略图。这是默认值。
- `false` 保留现有缩略图。如果演示文稿没有缩略图，Aspose.Slides 不会生成。

以下示例将演示文稿保存时不刷新其缩略图：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
禁用缩略图刷新可以减少保存 PPTX 文件所需的时间。
{{% /alert %}}

## **以百分比保存进度更新**

要监视保存操作，请使用 Java 代理实现[IProgressCallback](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/)接口，并将实现传递给[SaveOptions.setProgressCallback](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/saveoptions/#setProgressCallback)方法。Aspose.Slides 随后会在导出期间调用[IProgressCallback.reporting](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iprogresscallback/#reporting-double-)方法，提供进度值。

以下示例将 PDF 导出的进度报告到控制台：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供了一个基于 Aspose.Slides API 的免费[PowerPoint Splitter](https://products.aspose.app/slides/zh/splitter)。它可将演示文稿中选定的幻灯片保存为单独的 PPT 或 PPTX 文件。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持增量或“快速保存”？**

不支持。每次保存操作都会写入完整的输出文件，而不是仅更新已更改的部分。

**多个线程可以保存同一个 Presentation 实例吗？**

不可以。[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 实例[不具备线程安全](/slides/zh/nodejs-java/multithreading/)。每次只能由单个线程访问并保存该实例。

**保存演示文稿时，超链接和外部链接文件会怎样？**

[超链接](/slides/zh/nodejs-java/manage-hyperlinks/) 保留在演示文稿中。Aspose.Slides 不会复制外部链接的文件，因此保存后的演示文稿仍需能够访问这些位置。

**我可以保存文档元数据，如作者、标题、公司和创建日期吗？**

可以。在保存之前设置相应的[文档属性](/slides/zh/nodejs-java/presentation-properties/)，Aspose.Slides 会将其写入输出文件。