---
title: 在 Android 上從簡報取得段落邊界
linktitle: 段落
type: docs
weight: 60
url: /zh-hant/androidjava/paragraph/
keywords:
- 段落邊界
- 文字區塊邊界
- 段落座標
- 區塊座標
- 段落大小
- 文字區塊大小
- 文字框
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "瞭解如何在 Aspose.Slides for Android（透過 Java）中取得段落與文字區塊的邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中取得段落與文字區塊的邊界、大小與座標。它展示了如何使用 `getRect()` 取得 `TextFrame` 中段落的矩形、如何取得表格儲存格文字框內段落與區塊的座標，並強調了度量單位、文字換行對邊界的影響、像素轉換以及有效段落格式值等重要細節。

## **在 TextFrame 中取得段落與區塊座標**
使用 Aspose.Slides for Android via Java，開發人員現在可以取得 TextFrame 的段落集合中段落的矩形座標。它同時也允許您取得[區塊的座標](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPortion#getCoordinates--)（位於段落的區塊集合中）。在本主題中，我們將透過範例示範如何取得段落的矩形座標以及段落內區塊的位置。

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
使用[**getRect()**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraph#getRect--)方法，開發人員可以取得段落的邊界矩形。

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

## **取得表格儲存格 TextFrame 內段落與區塊的大小與座標**

要在表格儲存格的文字框中取得[Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Portion)或[Paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Paragraph)的大小與座標，您可以使用[IPortion.getRect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPortion#getRect--)與[IParagraph.getRect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IParagraph#getRect--)方法。

以下範例程式碼示範了上述操作：

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

**段落與文字區塊的座標以何種單位回傳？**

以點 (point) 為單位，1 英吋 = 72 點。此單位適用於投影片上所有的座標與尺寸。

**文字換行會影響段落的邊界嗎？**

會。若在[TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/)中啟用了[換行](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)功能，文字會依區域寬度斷行，從而改變段落的實際邊界。

**段落座標能可靠地對映到匯出影像的像素嗎？**

能。使用以下公式將點轉換為像素：像素 = 點 × (DPI / 72)。結果取決於渲染/匯出時所選擇的 DPI。

**如何取得考慮樣式繼承後的「有效」段落格式參數？**

使用[有效段落格式資料結構](/slides/zh-hant/androidjava/shape-effective-properties/)，它會回傳縮排、間距、換行、RTL 等最終合併的值。