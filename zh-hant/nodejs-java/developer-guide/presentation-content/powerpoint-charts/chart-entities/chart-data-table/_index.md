---
title: 使用 JavaScript 在簡報中自訂圖表資料表
linktitle: 資料表
type: docs
url: /zh-hant/nodejs-java/chart-data-table/
keywords:
- 圖表資料
- 資料表
- 字體屬性
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，透過 JavaScript 自訂 PPT 與 PPTX 的圖表資料表，以提升簡報的效率與吸引力。"
---
## **概述**

本文說明了如何在 Aspose.Slides 中使用圖表資料表。它展示了如何為圖表顯示資料表，並透過設定字體屬性（例如粗體樣式和字體高度）來自訂文字格式。範例示範了載入簡報、加入圖表、啟用圖表資料表、套用字體設定，並儲存更新後的簡報。它亦包含關於在圖表資料表中顯示圖例鍵、在匯出時保留資料表、處理從現有簡報或範本載入的圖表，以及找出已啟用資料表之圖表的常見問題簡短回答。

## **設定圖表資料表的字體屬性**

Aspose.Slides for Node.js via Java 提供了變更系列色彩中類別顏色的支援。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別物件。
1. 在投影片上加入圖表。
1. 設定圖表資料表。
1. 設定字體高度。
1. 儲存已修改的簡報。

以下提供範例程式碼。  

```javascript
// 建立空白簡報
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以在圖表資料表的數值旁顯示小圖例鍵嗎？**

是的。資料表支援[圖例鍵](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datatable/setshowlegendkey/)，您可以自行開啟或關閉。

**在將簡報匯出為 PDF、HTML 或圖片時，資料表會被保留嗎？**

是的。Aspose.Slides 會將圖表渲染為投影片的一部份，因此匯出的[PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 皆會包含帶有資料表的圖表。

**從範本檔案載入的圖表是否支援資料表？**

是的。對於任何從現有簡報或範本載入的圖表，您都可以使用圖表屬性檢查並變更資料表是否[顯示](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/hasdatatable/)。

**如何快速找出檔案中哪些圖表已啟用資料表？**

檢查每個圖表的屬性以判斷資料表是否[顯示](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/hasdatatable/)，然後遍歷投影片以找出已啟用資料表的圖表。