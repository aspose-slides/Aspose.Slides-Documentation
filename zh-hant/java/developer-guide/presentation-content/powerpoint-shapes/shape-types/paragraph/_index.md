---
title: 在 Java 中從簡報取得段落邊界
linktitle: 段落
type: docs
weight: 60
url: /zh-hant/java/paragraph/
keywords:
- 段落邊界
- 文字片段邊界
- 段落座標
- 片段座標
- 段落大小
- 文字片段大小
- 文字框
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中取得段落與文字片段的邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概述**

本文說明如何取得 Aspose.Slides 中段落與文字片段的邊界、大小與座標。它展示了如何使用 `getRect()` 取得 `TextFrame` 中段落的矩形、如何取得表格儲存格文字框內段落與片段的座標，並強調了測量單位、文字換行對邊界的影響、像素轉換以及有效段落格式化值等重要細節。

## **在 TextFrame 中取得段落與片段座標**
使用 Aspose.Slides for Java，開發人員現在可以取得 TextFrame 中段落集合內段落的矩形座標。它同時允許您取得段落中片段集合的[片段的座標](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPortion#getCoordinates--)。在本主題中，我們將透過範例說明如何取得段落的矩形座標以及段落內片段的位置。

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **取得段落的矩形座標**
使用[**getRect()**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IParagraph#getRect--) 方法，開發人員可以取得段落的邊界矩形。

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **取得表格儲存格 TextFrame 內段落與片段的大小**
若要取得表格儲存格文字框中[Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Portion)或[Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Paragraph)的大小與座標，可使用[IPortion.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPortion#getRect--)與[IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IParagraph#getRect--) 方法。

此範例程式碼演示上述操作：

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**段落與文字片段的座標以什麼單位回傳？**

以點 (point) 為單位，1 英吋 = 72 點。此單位適用於投影片上所有座標與尺寸。

**文字換行會影響段落的邊界嗎？**

會。如果在[TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/)中啟用[wrapping](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframeformat/#setWrapText-byte-)，文字會依區域寬度換行，從而改變段落的實際邊界。

**段落座標能可靠地映射到匯出影像的像素嗎？**

可以。可使用以下公式將點轉換為像素：pixels = points × (DPI / 72)。結果取決於渲染/匯出時所選的 DPI。

**如何取得「有效」的段落格式化參數，以考慮樣式繼承？**

使用[effective paragraph formatting data structure](/slides/zh-hant/java/shape-effective-properties/)；它會回傳縮排、間距、換行、RTL 以及其他屬性的最終合併值。