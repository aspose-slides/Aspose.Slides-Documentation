---
title: 在 Android 上從簡報取得段落邊界
linktitle: 段落邊界
type: docs
weight: 43
url: /zh-hant/androidjava/paragraph-bounds/
keywords:
- 段落邊界
- 段落座標
- 段落大小
- 文字框
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android 透過 Java 取得段落邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概覽**

本文說明如何取得 Aspose.Slides 中段落的邊界、大小與座標。示範如何使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraph#getRect--) 從 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 取得段落矩形，如何取得表格儲存格文字框內段落的座標，並強調測量單位、文字換行對邊界的影響、像素轉換以及有效段落格式值等重要細節。

## **取得段落的矩形座標**

使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraph#getRect--) 取得段落的邊界矩形。

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **取得表格儲存格 TextFrame 內段落的大小**

若要取得表格儲存格文字框中 [IParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph/) 的大小與座標，請使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraph#getRect--)。返回的矩形是相對於表格儲存格文字框的，因此在需要幻燈片層級座標時，需加上表格位置與儲存格偏移量。

以下範例取得表格儲存格內段落的邊界，並在幻燈片上繪製矩形以視覺化這些邊界：

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

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

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

使用點（point）作為單位，1 英吋等於 72 點。此單位適用於幻燈片上所有座標與尺寸。

**文字換行會影響段落的邊界嗎？**

會。若為 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 啟用了 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)，文字會依區域寬度自動斷行，從而改變段落實際的邊界。

**段落座標能可靠地映射到匯出圖像的像素嗎？**

能。可使用以下公式將點轉換為像素：像素 = 點 × (DPI / 72)。結果取決於渲染或匯出時所選的 DPI。

**如何取得考慮樣式繼承後的「有效」段落格式參數？**

使用 [effective paragraph formatting data structure](/slides/zh-hant/androidjava/shape-effective-properties/)，它會回傳縮排、間距、換行、RTL 等最終合併的值。