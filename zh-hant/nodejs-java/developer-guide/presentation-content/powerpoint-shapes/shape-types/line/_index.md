---
title: 在 JavaScript 中向簡報新增線條形狀
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/nodejs-java/line/
keywords:
- 線條
- 建立線條
- 新增線條
- 普通線條
- 設定線條
- 自訂線條
- 虛線樣式
- 箭頭
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "學習如何使用 JavaScript 與 Aspose.Slides for Node.js 在 PowerPoint 簡報中操作線條格式。探索屬性、方法與範例。"
---
## **概覽**

Aspose.Slides 允許您以程式方式向 PowerPoint 投影片中加入線條形狀。本文將說明如何建立簡單的線條以及如何自訂線條使其顯示為箭頭。

您將學習如何將線條形狀加入投影片，調整其外觀，並儲存更新後的簡報。範例著重於實務的線條格式設定，如樣式、寬度、虛線模式、箭頭樣式和填充顏色。

## **建立純線**

若要在簡報中選取的投影片上加入簡單的純線，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 物件公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Line 的 AutoShape。
- 將修改後的簡報寫入為 PPTX 檔案。

在下方範例中，我們已將線條新增至簡報的第一張投影片。

```javascript
// 實例化表示 PPTX 檔案的 PresentationEx 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增類型為 line 的 AutoShape
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // 將 PPTX 寫入磁碟
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **建立箭頭形狀線條**

Aspose.Slides for Node.js via Java 亦允許開發人員設定線條的某些屬性，使其外觀更佳。現在讓我們嘗試設定幾個屬性，使線條呈現箭頭形狀。請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 物件公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Line 的 AutoShape。
- 將 [Line Style](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LineStyle) 設為 Aspose.Slides for Node.js via Java 所提供的其中一種樣式。
- 設定線條的寬度。
- 將線條的 [Dash Style](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LineDashStyle) 設為 Aspose.Slides for Node.js via Java 所提供的其中一種樣式。
- 設定線條起點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LineArrowheadLength)。
- 設定線條終點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/LineArrowheadLength)。
- 將修改後的簡報寫入為 PPTX 檔案。

```javascript
// 實例化表示 PPTX 檔案的 PresentationEx 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增類型為 line 的 AutoShape
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // 對線條套用一些格式設定
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // 將 PPTX 寫入磁碟
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以將一般線條轉換為連接器，使其「自動貼齊」形狀嗎？**

不行。一般線條（型別為 [Line](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/)）不會自動變為連接器。若要使其貼齊形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/connector/) 類型以及用於連接的 [corresponding APIs](/slides/zh-hant/nodejs-java/connector/)。

**如果線條的屬性是從佈景主題繼承而來，且難以確定最終值，我該怎麼辦？**

透過 `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` 類別，[Read the effective properties](/slides/zh-hant/nodejs-java/shape-effective-properties/)——這些類別已考慮繼承與佈景主題樣式。

**我可以鎖定線條以防止編輯（移動、調整大小）嗎？**

可以。形狀提供的 [lock objects](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/getautoshapelock/) 可讓您禁止編輯操作。