---
title: 在 Android 上自訂簡報中的圖表資料表
linktitle: 資料表
type: docs
url: /zh-hant/androidjava/chart-data-table/
keywords:
- 圖表資料
- 資料表
- 字型屬性
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中自訂 PPT 與 PPTX 的圖表資料表，以提升簡報的效率與吸引力。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表資料表。它展示了如何為圖表顯示資料表，並透過設定字型屬性（例如粗體樣式和字型高度）來自訂文字格式。範例示範了載入簡報、加入圖表、啟用圖表資料表、套用字型設定，並儲存更新後的簡報。

## **設定圖表資料表的字型屬性**
Aspose.Slides for Android via Java 提供了在系列色彩中變更類別顏色的支援。

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別物件。
1. 在投影片上新增圖表。
1. 設定圖表資料表。
1. 設定字型高度。
1. 儲存已修改的簡報。

以下提供範例。

```java
// 建立空白簡報
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以在圖表資料表的數值旁顯示小圖例鍵嗎？**

是的。資料表支援 [legend keys](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-)，您可以開啟或關閉它們。

**將簡報匯出為 PDF、HTML 或圖片時，資料表會保留嗎？**

是的。Aspose.Slides 會將圖表渲染為投影片的一部分，因此匯出的 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)/[image](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 會包含帶有資料表的圖表。

**從範本檔案建立的圖表是否支援資料表？**

是的。對於任何從現有簡報或範本載入的圖表，您都可以使用圖表的屬性檢查並變更資料表是否 [is shown](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/#hasDataTable--)。

**我該如何快速找到檔案中哪些圖表已啟用資料表？**

檢查每個圖表的屬性，以判斷資料表是否 [is shown](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/chart/#hasDataTable--)，然後遍歷投影片以找出已啟用資料表的圖表。