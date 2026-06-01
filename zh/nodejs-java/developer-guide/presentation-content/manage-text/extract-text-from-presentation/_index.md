---
title: JavaScript 中的高级演示文稿文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/nodejs-java/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从 PowerPoint 提取文本
- 从 OpenDocument 提取文本
- 从 PPT 提取文本
- 从 PPTX 提取文本
- 从 ODP 提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从 PowerPoint 检索文本
- 从 OpenDocument 检索文本
- 从 PPT 检索文本
- 从 PPTX 检索文本
- 从 ODP 检索文本
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，快速提取 PowerPoint 和 OpenDocument 演示文稿中的文本。遵循我们的简明分步指南，节省时间。"
---
## **概述**

从演示文稿中提取文本是开发人员处理幻灯片内容时常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 文件，还是 OpenDocument 演示文稿（ODP），访问和检索文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了一份完整指南，讲解如何使用 Aspose.Slides for Node.js via Java 高效地从多种演示文稿格式（包括 PPT、PPTX 和 ODP）中提取文本。您将学习如何系统地遍历演示文稿元素，以准确获取所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for Node.js via Java 提供了 [SlideUtil](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/) 类。该类公开了多个重载的静态方法，可用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用 [getAllTextBoxes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) 方法。此方法接受一个幻灯片对象作为参数。执行后，方法会扫描整个幻灯片的文本并返回一个 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 对象数组，保留所有文本格式。

以下代码片段提取演示文稿第一张幻灯片的所有文本：



## **从演示文稿提取文本**

要扫描整个演示文稿的文本，请使用由 [SlideUtil](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/) 类公开的 [getAllTextFrames](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) 静态方法。它接受两个参数：

1. 第一个参数是一个表示 PowerPoint 或 OpenDocument 演示文稿的 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 对象，文本将从中提取。
1. 第二个参数是一个 `boolean` 值，指示在扫描演示文稿文本时是否应包括母版幻灯片。

该方法返回一个 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 对象数组，包含文本格式信息。下面的代码扫描演示文稿的文本和格式细节，包括母版幻灯片。

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **分类和快速文本提取**

[PresentationFactory](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/) 类同样提供了从演示文稿中提取所有文本的方法：

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textextractionarrangingmode/) 枚举参数指示文本提取结果的组织方式，可设置为以下值：
- `Unarranged` - 未排列 - 原始文本，不考虑其在幻灯片上的位置。
- `Arranged` - 已排列 - 文本按照幻灯片上的顺序排列。

在对速度要求极高的情况下，可使用未排列模式；它比已排列模式更快。

[PresentationText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationtext/) 表示从演示文稿提取的原始文本。其 `getSlidesText` 方法返回一个对象数组，每个对象代表相应幻灯片上的文本。每个幻灯片文本对象具有以下方法：

- `getText` 方法返回幻灯片形状内的文本。
- `getMasterText` 方法返回与该幻灯片关联的母版幻灯片形状内的文本。
- `getLayoutText` 方法返回与该幻灯片关联的版式幻灯