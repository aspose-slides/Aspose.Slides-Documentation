---
title: "JavaScript 中的高级演示文稿文本提取"
linktitle: "提取文本"
type: docs
weight: 90
url: /zh/nodejs-java/extract-text-from-presentation/
keywords:
- "提取文本"
- "从幻灯片提取文本"
- "从演示文稿提取文本"
- "从 PowerPoint 提取文本"
- "从 OpenDocument 提取文本"
- "从 PPT 提取文本"
- "从 PPTX 提取文本"
- "从 ODP 提取文本"
- "检索文本"
- "从幻灯片检索文本"
- "从演示文稿检索文本"
- "从 PowerPoint 检索文本"
- "从 OpenDocument 检索文本"
- "从 PPT 检索文本"
- "从 PPTX 检索文本"
- "从 ODP 检索文本"
- "PowerPoint"
- "OpenDocument"
- "演示文稿"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "使用 Aspose.Slides for Node.js via Java 快速提取 PowerPoint 和 OpenDocument 演示文稿中的文本。遵循我们的简明分步指南，节省时间。"
---
## **概述**

从演示文稿中提取文本是开发人员处理幻灯片内容时常见且必需的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 格式文件，还是 OpenDocument 演示文稿（ODP），获取文本数据对于分析、自动化、索引或内容迁移都可能至关重要。

本文提供了一个全面指南，教您如何使用 Aspose.Slides for Node.js via Java 高效地从各种演示文稿格式（包括 PPT、PPTX 和 ODP）中提取文本。您将学习如何系统地遍历演示文稿元素，准确检索所需的文本内容。

## **从幻灯片中提取文本**

Aspose.Slides for Node.js via Java 提供了[SlideUtil](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/)类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用[getAllTextBoxes](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-)方法。此方法接受一个幻灯片对象作为参数。执行时，方法会扫描整张幻灯片的文本并返回一个[TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)对象数组，保留任何文本格式。

下面的代码片段提取了演示文稿第一张幻灯片的所有文本：

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

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

## **从演示文稿中提取文本**

要扫描整个演示文稿的文本，请使用[SlideUtil](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/)类公开的[getAllTextFrames](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-)静态方法。它接受两个参数：

1. 首先，一个代表 PowerPoint 或 OpenDocument 演示文稿的[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)对象，用于提取文本。
1. 其次，一个 `boolean` 值，指示在扫描演示文稿文本时是否应包括母版幻灯片。

该方法返回一个[TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/)对象数组，包含文本格式信息。下面的代码从演示文稿（包括母版幻灯片）中扫描文本及其格式细节。

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

## **分类且快速的文本提取**

[PresentationFactory](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationfactory/)类同样提供了从演示文稿中提取所有文本的方法：

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textextractionarrangingmode/) 枚举参数指示组织文本提取结果的模式，可设置为以下值：
- `Unarranged` - 原始文本，不考虑其在幻灯片上的位置。
- `Arranged` - 文本按幻灯片上的顺序排列。

当速度至关重要时，可使用未排列模式；它比排列模式更快。

[PresentationText](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentationtext/) 表示从演示文稿中提取的原始文本。其 `getSlidesText` 方法返回一个对象数组，每个对象代表相应幻灯片上的文本。每个幻灯片文本对象包含以下方法：

- `getText` 方法返回幻灯片形状内的文本。
- `getMasterText` 方法返回与该幻灯片关联的母版幻灯片形状内的文本。
- `getLayoutText` 方法返回与该幻灯片关联的版式幻灯片形状内的文本。
- `getNotesText` 方法返回与该幻灯片关联的备注幻灯片形状内的文本。
- `getCommentsText` 方法返回与该幻灯片关联的评论中的文本。

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **常见问答**

**Aspose.Slides 在文本提取过程中处理大型演示文稿的速度如何？**

Aspose.Slides 针对高性能进行了优化，能够处理甚至[大型演示文稿](/slides/zh/nodejs-java/open-presentation/)，适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**

可以。Aspose.Slides 能从许多幻灯片元素提取文本，包括表格和图表相关对象，您可以访问并分析常见演示结构中的文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**

您可以使用 Aspose.Slides 的免费试用版进行文本提取，虽然会有[某些限制](/slides/zh/nodejs-java/licensing/)，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。