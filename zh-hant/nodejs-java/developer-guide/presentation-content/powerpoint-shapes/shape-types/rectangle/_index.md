---
title: 在 JavaScript 中向簡報添加矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh-hant/nodejs-java/rectangle/
keywords:
- 新增矩形
- 建立矩形
- 矩形形狀
- 簡單矩形
- 格式化矩形
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "透過在 Node.js 的 Aspose.Slides 中使用 JavaScript 添加矩形，提升您的 PowerPoint 簡報——輕鬆以程式設計方式設計和修改形狀。"
---
## **概述**

本篇文章說明如何使用 Aspose.Slides 在 PowerPoint 投影片中加入矩形形狀。內容包括建立簡單矩形、建立格式化矩形，以及將更新後的簡報儲存為 PPTX 檔案。  
您還會看到如何套用基本的矩形格式設定，例如實心填色、線條顏色與線寬。另外，文章的 FAQ 也會指向相關的矩形操作，包括圓角、圖片填充、視覺效果、超連結、形狀鎖定、匯出選項與實際屬性。

## **將矩形加入投影片**

如同先前的主題，本篇同樣是介紹加入圖形，而本次要討論的圖形是矩形。在本主題中，我們說明了開發人員如何使用 Aspose.Slides 在投影片中加入簡單或已格式化的矩形。  

若要在簡報的特定投影片中加入簡單矩形，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
- 使用索引取得投影片的參照。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Rectangle 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape)。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們在簡報的第一張投影片加入了一個簡單的矩形。

```javascript
// 實例化表示 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增橢圓類型的 AutoShape
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // 將 PPTX 檔案寫入磁碟
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將格式化矩形加入投影片**

若要在投影片中加入格式化的矩形，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
- 使用索引取得投影片的參照。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Rectangle 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape)。
- 將矩形的 [Fill Type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FillType) 設為 Solid。
- 使用與 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape) 物件相關聯的 [FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FillFormat) 之 [SolidFillColor.setColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) 方法，設定矩形的顏色。
- 設定矩形線條的顏色。
- 設定矩形線條的寬度。
- 將修改後的簡報寫入為 PPTX 檔案。

上述步驟已在以下範例中實作。

```javascript
// 實例化表示 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增橢圓類型的 AutoShape
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // 為橢圓形狀套用一些格式設定
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // 為橢圓的線條套用一些格式設定
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // 將 PPTX 檔案寫入磁碟
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**如何新增帶圓角的矩形？**  
使用圓角的 [shape type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapetype/)，並在圖形屬性中調整角半徑；也可以透過幾何調整對每個角單獨套用圓角。

**如何使用圖片（紋理）填滿矩形？**  
選取圖片 [fill type](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/)，提供圖像來源，並設定 [stretching/tiling modes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/picturefillmode/)。

**矩形可以有陰影和發光效果嗎？**  
可以。可使用 [Outer/inner shadow, glow, and soft edges](/slides/zh-hant/nodejs-java/shape-effect/) 並透過可調參數設定。

**我可以將矩形變成帶有超連結的按鈕嗎？**  
可以。透過在點擊形狀時 [Assign a hyperlink](/slides/zh-hant/nodejs-java/manage-hyperlinks/)（跳轉至投影片、檔案、網址或電子郵件）來實作。

**如何保護矩形免於移動或變更？**  
使用形狀鎖定：可禁止移動、調整大小、選取或文字編輯，以維持版面配置。

**可以將矩形轉換為點陣圖或 SVG 嗎？**  
是的。您可以使用 [render the shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage) 以指定的大小/比例產生影像，或使用 [export it as SVG](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/) 以向量形式匯出。

**如何快速取得考慮佈景主題與繼承的矩形實際（有效）屬性？**  
請使用 [shape’s effective properties](/slides/zh-hant/nodejs-java/shape-effective-properties/)：此 API 會回傳已考慮佈景主題樣式、版面配置與本地設定的計算後值，簡化格式分析。