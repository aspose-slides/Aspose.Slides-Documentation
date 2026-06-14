---
title: 使用 Java 在簡報中自訂圖表資料表
linktitle: 資料表
type: docs
url: /zh-hant/java/chart-data-table/
keywords:
- 圖表資料
- 資料表
- 字型屬性
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Java 搭配 Aspose.Slides 為 PPT 與 PPTX 自訂圖表資料表，提升簡報的效率與吸引力。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表資料表。它展示如何為圖表顯示資料表，並透過設定字型屬性（如粗體樣式和字型高度）自訂文字格式。範例說明了載入簡報、加入圖表、啟用圖表資料表、套用字型設定，並儲存更新後的簡報。

此外，還簡要回答了有關在圖表資料表中顯示圖例鍵、在匯出時保留資料表、處理從現有簡報或範本載入的圖表，以及快速找出已啟用資料表的圖表等常見問題。

## **設定圖表資料表的字型屬性**
Aspose.Slides for Java 提供變更系列顏色中類別顏色的支援。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別物件。
1. 在投影片上加入圖表。
1. 設定圖表資料表。
1. 設定字型高度。
1. 儲存已修改的簡報。

以下提供範例程式碼。

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

**我可以在圖表資料表的數值旁顯示小型圖例鍵嗎？**

可以。資料表支援[圖例鍵](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-)，您可以自行開啟或關閉。

**在將簡報匯出為 PDF、HTML 或圖像時，資料表會被保留嗎？**

會。Aspose.Slides 會將圖表作為投影片的一部份渲染，因此匯出的[PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)、[image](/slides/zh-hant/java/convert-powerpoint-to-png/) 都會包含帶有資料表的圖表。

**從範本檔案產生的圖表是否支援資料表？**

會。對於任何從現有簡報或範本載入的圖表，您都可以使用圖表屬性檢查並變更資料表[是否顯示](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/#hasDataTable--)。

**如何快速找出檔案中哪些圖表已啟用資料表？**

檢查每個圖表的屬性以判斷資料表[是否顯示](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/chart/#hasDataTable--)，並遍歷投影片即可找出已啟用的圖表。