---
title: 在 JavaScript 中获取演示文稿的文本 Portion 边界
linktitle: Portion 边界
type: docs
weight: 47
url: /zh/nodejs-java/portion-bounds/
keywords:
- 文本 Portion 边界
- 文本 Portion
- 文本 部分
- 文本 坐标
- 文本 位置
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js（通过 Java）在 PowerPoint 演示文稿中检索文本 Portion 边界。"
---
## **概述**

文本 Portion 表示段落内部的特定文本片段，并允许您独立于周围内容对该片段进行操作。在 Aspose.Slides 中，Portion 可在需要检索文本片段的边界、仅对段落的一部分应用格式或更细致地控制文本行为时使用。

本文展示了如何使用 [Portion.getRect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/getrect/) 获取 Portion 的边界矩形。还展示了如何使用 [Portion.getCoordinates](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/getcoordinates/) 获取 Portion 开始位置的坐标。此外，还重点介绍了常见的与 Portion 相关的场景，例如对单个文本片段应用超链接、了解格式如何通过 Portion、Paragraph、TextFrame 和主题继承进行解析，以及处理指定字体不可用的情况。

## **获取文本 Portion 的边界**

使用 [Portion.getRect](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/getrect/) 检索文本 Portion 的边界矩形：

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **获取文本 Portion 的坐标**

使用 [Portion.getCoordinates](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/getcoordinates/) 检索文本 Portion 起始位置的坐标：

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我能否仅对单个段落中的部分文本应用超链接？**

是的，您可以[分配超链接](/slides/zh/nodejs-java/manage-hyperlinks/)到单个 Portion；只有该片段可点击，而不是整个段落。

**样式继承是如何工作的：Portion 会覆盖哪些属性，哪些属性来自 Paragraph 或 TextFrame？**

Portion 级别的属性拥有最高优先级。如果属性未在 [Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/) 上设置，Aspose.Slides 将从 [Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 中获取。如果在那里也未设置，Aspose.Slides 将使用 [TextFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/textframe/) 或 [theme](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/theme/) 的样式。

**如果为 Portion 指定的字体在目标机器或服务器上缺失，会发生什么？**

[字体替换规则](/slides/zh/nodejs-java/font-selection-sequence/) 将生效。文本可能会重新换行：度量、连字符以及宽度可能会变化，这对精确定位很重要。

**我能否为特定 Portion 设置文本填充透明度或渐变，而不影响段落的其余部分？**

可以，位于 [Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/) 级别的文本颜色、填充和透明度可以与相邻片段不同。