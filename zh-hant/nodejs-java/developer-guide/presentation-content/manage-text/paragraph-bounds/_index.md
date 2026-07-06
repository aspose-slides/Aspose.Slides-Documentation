---
title: 從 JavaScript 中的簡報取得段落界限
linktitle: 段落界限
type: docs
weight: 43
url: /zh-hant/nodejs-java/paragraph-bounds/
keywords:
- 段落界限
- 段落座標
- 段落大小
- 文字框
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "瞭解如何透過 Java 在 Aspose.Slides for Node.js 中取得段落界限，以優化 PowerPoint 簡報中的文字定位。"
---
## **概觀**

本文說明如何取得 Aspose.Slides 中段落的界限、大小和座標。它展示了如何使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/getrect/) 從 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 取得段落矩形，如何取得表格儲存格文字框內的段落座標，並強調重要細節，例如測量單位、文字自動換行對界限的影響、像素轉換以及有效段落格式化參數。

## **取得段落的矩形座標**

使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/getrect/) 取得段落的外接矩形。

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **取得表格儲存格文字框內段落的大小**

若要取得表格儲存格文字框中 [Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/) 的大小和座標，請使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/paragraph/getrect/)。返回的矩形是相對於表格儲存格文字框的，因此在需要幻燈片層級座標時，需要加上表格位置和儲存格偏移。

以下範例取得表格儲存格內的段落界限，並在幻燈片上繪製矩形以視覺化這些界限：

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**段落座標以何種單位測量？**

它們以點 (point) 為單位，1 吋等於 72 點。此單位適用於幻燈片上所有的座標與尺寸。

**文字自動換行會影響段落的界限嗎？**

是。若為 [TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 啟用 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/setwraptext/)，文字會根據區域寬度自動斷行，從而改變段落的實際界限。

**段落座標能可靠地映射到匯出影像的像素嗎？**

可以。使用以下公式將點轉換為像素：pixel = point × (DPI / 72)。結果取決於渲染或匯出時選擇的 DPI。

**如何取得考慮樣式繼承的「有效」段落格式參數？**

使用 [effective paragraph formatting data structure](/slides/zh-hant/nodejs-java/shape-effective-properties/)；它會回傳縮排、間距、換行、RTL 等最終合併的值。