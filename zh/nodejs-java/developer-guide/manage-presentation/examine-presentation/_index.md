---
title: 在 JavaScript 中检索和更新演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/nodejs-java/examine-presentation/
keywords:
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- 更新属性
- 检查 PPTX
- 检查 PPT
- 检查 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以实现更快速的洞察和更智能的内容审计。"
---
## **概述**

Aspose.Slides 可以识别演示文稿的格式并读取其文档元数据，而无需创建完整的演示文稿对象模型。当需要对文件进行分类、建立清单或在决定是否加载和处理演示文稿内容之前检查属性时，这非常有用。

本文演示了通过[PresentationFactory](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/)和[PresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/)进行轻量级检查，以及通过[DocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/)进行有针对性的更新。

## **检查演示文稿格式**

使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)在不创建[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)实例的情况下检查文件。[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/getloadformat/)方法会报告检测到的格式，例如 PPTX、PPT 或 ODP。

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **构建轻量级演示文稿清单**

在处理大量演示文稿文件时，您可能需要一个用于验证、索引或文档管理系统的紧凑清单。在这种情况下，使用[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)获取[PresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/)对象，然后调用[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)读取文档元数据。这种做法不会创建[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)实例，也不需要遍历完整的演示文稿对象模型。

[DocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/)公开的扩展属性提供了以下清单值：

| 方法 | 清单值 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getSlides) | 幻灯片总数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | 隐藏的幻灯片数量。 |
| [getNotes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getNotes) | 包含备注的幻灯片数量。 |
| [getParagraphs](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | 总段落数（如果可用）。 |
| [getWords](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getWords) | 总词数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | 音频和视频剪辑总数。 |

下面的示例读取这些值而不创建[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)对象，并打印紧凑的清单。它还将[DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs)与[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts)结合使用，以显示字体、主题和幻灯片标题等内容组。

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

每个[HeadingPair](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/headingpair/)通过[HeadingPair.getName](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/headingpair/#getName)提供组名，并通过[HeadingPair.getCount](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/headingpair/#getCount)提供该组中的项目数量。[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts)返回一个平铺、有序的数组，因此请按每个标题对指定的连续标题数量进行消费。

### **存储的元数据和格式限制**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)返回的清单属性反映了源文档中可用的元数据。Aspose.Slides 不会加载并遍历演示文稿对象模型来重新计算这些值。缺失的属性将使用默认值表示，如果上一次保存文件的应用程序未更新其文档属性，则存储的值可能已过时。

- **PPTX:** 此格式为幻灯片、备注、隐藏幻灯片、段落、词语和多媒体计数以及标题对和部件标题提供扩展文档属性。可用性取决于文档生成者写入的属性。
- **PPT:** 二进制格式可以存储相应的文档摘要属性。如果属性缺失或未由文档生成者刷新，Aspose.Slides 将返回其存储的或默认值，而不是从幻灯片计算得出。
- **ODP:** OpenDocument 元数据提供通用文档统计信息，例如页面、段落和词语计数，但这些值并不映射到每个 PowerPoint 特有的扩展属性。隐藏幻灯片、备注幻灯片、多媒体、标题对和部件标题元数据可能不可用，清单属性可能返回默认值。不要将零值或空数组视为对应内容缺失的权威证明。

在进行清单和初步检查时使用轻量级元数据方法。当结果必须反映内存中的更改，或需要验证实际演示文稿内容时，请加载演示文稿并检查其实时对象模型。

## **更新演示文稿属性**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)返回的属性也可以在不创建[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)实例的情况下进行更改。使用[PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/)应用更改，然后使用[PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/)写入绑定的演示文稿。

以下图像显示了原始文档属性。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下示例更改标题和最后保存时间，并将结果写入新文件：

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

以下图像显示了更新后的文档属性。

![PowerPoint 演示文稿的已更改文档属性](output_properties.png)

## **有用链接**

有关相关安全检查和保护设置，请参阅以下文章：

- [Password-Protect Presentations](/slides/zh/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/zh/nodejs-java/write-protected-presentation/)

## **常见问答**

**如何检查是否嵌入了字体以及具体是哪一些？**

加载演示文稿并使用[Presentation.getFontsManager](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getfontsmanager/)。调用[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/)获取嵌入的字体，调用[FontsManager.getFonts](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/fontsmanager/getfonts/)获取演示文稿使用的字体。比较两者即可找出渲染所需但未嵌入的字体。

**如何快速判断文件是否有隐藏幻灯片以及数量？**

当存储的文档元数据足够时，透过[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/)和[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/)读取[DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides)。这适用于轻量级清单。如果演示文稿在内存中已被修改，存储的元数据可能缺失或过时，或需要验证实时值，则遍历[Presentation.getSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getslides/)并检查每张幻灯片的[Slide.getHidden](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/gethidden/)方法。

**我能否检测是否使用了自定义幻灯片大小和方向，以及它们是否不同于默认设置？**

可以。加载演示文稿并调用[Presentation.getSlideSize](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getslidesize/)。使用[SlideSize.getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidesize/gettype/)、[SlideSize.getSize](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidesize/getsize/)和[SlideSize.getOrientation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slidesize/getorientation/)将当前设置与预期的预设和尺寸进行比较。

**有没有快速方法查看图表是否引用了外部数据源？**

有。定位每个[Chart](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/)并调用[ChartData.getDataSourceType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)。对于外部工作簿，调用[ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)。数据源类型和路径可识别外部引用，但验证目标是否可用需要单独的资源检查。

**如何评估可能导致渲染或 PDF 导出变慢的“重量级”幻灯片？**

没有单一的复杂度属性。遍历[Presentation.getSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/getslides/)以及每张幻灯片的[BaseSlide.getShapes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/#getShapes)集合。使用形状计数以及大图像、效果、动画或多媒体的存在作为筛选信号，并在将幻灯片视为确认的性能瓶颈之前进行代表性的渲染或导出测量。