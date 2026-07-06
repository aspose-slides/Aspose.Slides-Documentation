---
title: 在 Java 簡報中取得段落邊界
linktitle: 段落邊界
type: docs
weight: 43
url: /zh-hant/java/paragraph-bounds/
keywords:
- 段落邊界
- 段落座標
- 段落大小
- 文字框
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中取得段落邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概觀**

本文說明如何取得 Aspose.Slides 中段落的邊界、大小與座標。它展示了如何透過使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IParagraph#getRect--) 從 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 取得段落矩形、如何取得表格儲存格文字框內段落的座標，並強調測量單位、文字換行對邊界的影響、像素轉換以及有效段落格式化值等重要細節。

## **取得段落的矩形座標**

使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IParagraph#getRect--) 取得段落的外接矩形。

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **取得表格儲存格文字框內段落的大小**

若要取得表格儲存格文字框內 [IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 的大小與座標，請使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IParagraph#getRect--)。返回的矩形是相對於表格儲存格文字框的，因此在需要投影片層級座標時，需加上表格位置與儲存格偏移。

以下範例取得表格儲存格內段落的邊界，並在投影片上繪製矩形以視覺化這些邊界：

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**段落座標以何種單位測量？**

以點（point）為單位，1 英吋等於 72 點。此單位適用於投影片上所有座標與尺寸。

**文字換行會影響段落的邊界嗎？**

會。若為 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/) 啟用了 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)，文字會依區域寬度自動斷行，從而改變段落的實際邊界。

**段落座標能可靠地映射到匯出映像的像素嗎？**

能。使用下列公式將點轉換為像素：pixels = points x (DPI / 72)。結果取決於渲染或匯出時所選擇的 DPI。

**如何取得「有效」的段落格式化參數，並考慮樣式繼承？**

使用 [effective paragraph formatting data structure](/slides/zh-hant/java/shape-effective-properties/)；它會回傳縮排、間距、換行、RTL 等最終合併的值。