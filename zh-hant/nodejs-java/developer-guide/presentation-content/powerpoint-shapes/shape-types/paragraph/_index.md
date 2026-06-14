---
title: 從 JavaScript 簡報中取得段落邊界
linktitle: 段落
type: docs
weight: 60
url: /zh-hant/nodejs-java/paragraph/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js 在 JavaScript 中取得段落與文字片段的邊界，以優化 PowerPoint 簡報中的文字定位。"
---
## **概觀**

本篇說明如何取得 Aspose.Slides 中段落與文字片段的範圍、大小與座標。展示如何使用 `getRect()` 取得 `TextFrame` 中段落的矩形、如何取得表格儲存格文字框內段落與片段的座標，並強調測量單位、文字換行對範圍的影響、像素換算以及有效段落格式值等重要細節。

## **在 TextFrame 中取得段落與片段座標**
使用 Aspose.Slides for Node.js via Java，開發人員現在可以取得 TextFrame 段落集合中段落的矩形座標。亦可取得段落中片段集合的[the coordinates of portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Portion#getCoordinates--)。本主題將透過範例示範如何取得段落的矩形座標及段落內片段的位置。

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```


## **取得段落的矩形座標**
使用 [**getRect()**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Paragraph#getRect--) 方法即可取得段落的邊界矩形。

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **取得表格儲存格文字框內段落與片段的大小**

若要取得表格儲存格文字框內[Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Portion)或[Paragraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Paragraph)的大小與座標，可使用[Portion.getRect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Portion#getRect--) 與[Paragraph.getRect](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Paragraph#getRect--) 方法。

以下範例程式碼示範上述操作：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**段落與文字片段的座標以何種單位回傳？**

以點（point）為單位，1 吋 = 72 點。此單位適用於投影片上的所有座標與尺寸。

**文字換行會影響段落的範圍嗎？**

會。若在[TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/) 中啟用[wrapping](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/setwraptext/)，文字會依區域寬度自動斷行，進而改變段落實際的範圍。

**段落座標能否可靠地映射到匯出影像的像素？**

能。使用以下公式將點轉換為像素：pixels = points × (DPI / 72)。結果取決於渲染/匯出時所選的 DPI。

**如何取得考慮樣式繼承後的「有效」段落格式參數？**

使用[effective paragraph formatting data structure](/slides/zh-hant/nodejs-java/shape-effective-properties/)，它會回傳縮排、間距、換行、RTL 等最終合併後的值。