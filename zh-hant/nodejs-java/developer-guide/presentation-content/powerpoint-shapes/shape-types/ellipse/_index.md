---
title: 在 JavaScript 中將橢圓形加入簡報
linktitle: 橢圓形
type: docs
weight: 30
url: /zh-hant/nodejs-java/ellipse/
keywords:
- 橢圓形
- 圖形
- 添加橢圓形
- 建立橢圓形
- 繪製橢圓形
- 格式化橢圓形
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Node.js 中建立、格式化與操作橢圓形，支援 PPT 與 PPTX 簡報——提供 JavaScript 程式碼範例。"
---
## **概覽**

這篇文章說明如何使用 Aspose.Slides 在 PowerPoint 投影片中新增橢圓形。它涵蓋建立簡單橢圓形、建立格式化的橢圓形，以及將更新後的簡報另存為 PPTX 檔案。也會提及相關問題，例如處理橢圓的位置與大小、控制堆疊順序，以及套用動畫效果。

## **建立橢圓形**
若要在簡報的選取投影片中新增簡單的橢圓形，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的執行個體。
- 使用索引取得投影片的參照。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Ellipse 的 AutoShape。
- 將修改後的簡報寫入為 PPTX 檔案。

在以下範例中，我們已將橢圓形新增至第一張投影片

```javascript
// 實例化表示 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增類型為橢圓形的 AutoShape
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // 將 PPTX 檔案寫入磁碟
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **建立格式化的橢圓形**
若要在投影片中新增格式較佳的橢圓形，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的執行個體。
- 使用索引取得投影片的參照。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Ellipse 的 AutoShape。
- 將橢圓形的填滿類型設為實心。
- 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FillFormat) 物件所提供的 SolidFillColor.Color 屬性設定橢圓形的顏色。
- 設定橢圓形邊框線的顏色。
- 設定橢圓形邊框線的寬度。
- 將修改後的簡報寫入為 PPTX 檔案。

在以下範例中，我們已將格式化的橢圓形新增至簡報的第一張投影片。

```javascript
// 實例化代表 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增類型為橢圓形的 AutoShape
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // 為橢圓形套用一些格式設定
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // 為橢圓形的線條套用一些格式設定
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // 將 PPTX 檔案寫入磁碟
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **常見問題**

**如何依照投影片單位設定橢圓形的精確位置與大小？**

座標與尺寸通常以 **點** 為單位指定。為取得可預測的結果，請以投影片尺寸為基礎進行計算，並在指派值之前將所需的公釐或英吋換算為點。

**如何將橢圓形置於其他物件之上或之下（控制堆疊順序）？**

透過將物件移至最前或送至最後的方式調整其繪圖順序。這樣即可讓橢圓形覆蓋其他物件或顯示其下方的物件。

**如何為橢圓形套用出現或強調的動畫效果？**

[Apply](/slides/zh-hant/nodejs-java/shape-animation/) 入口、強調或退出效果到形狀，並設定觸發條件與時間，以編排動畫的播放時機與方式。