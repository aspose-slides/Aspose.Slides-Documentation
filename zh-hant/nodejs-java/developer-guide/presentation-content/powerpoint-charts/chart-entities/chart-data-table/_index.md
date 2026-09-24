---
title: 使用 JavaScript 在簡報中自訂圖表資料表格
linktitle: 資料表格
type: docs
url: /zh-hant/nodejs-java/chart-data-table/
keywords:
- 圖表資料
- 資料表格
- 字型屬性
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 簡報中自訂圖表資料表格的字型、邊框與圖例標記。"
---
## **概述**

Aspose.Slides for Node.js via Java 讓您可以顯示圖表的資料表格，並自訂其文字格式、邊框與圖例標記。本文說明如何啟用表格、格式化文字、控制各類邊框，以及顯示或隱藏圖例標記。範例會將設定好的圖表儲存為 PPTX 檔案。

## **設定字型屬性**

若要顯示圖表的資料表格，請將 `true` 傳入 [setDataTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/setdatatable/)。使用 [getChartDataTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/getchartdatatable/) 取得表格並設定其文字格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別載入簡報。
1. 在第一張投影片加入群組柱狀圖。
1. 啟用圖表的資料表格。
1. 使用 [setFontBold](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setfontbold) 讓文字加粗，並將 `20` 傳入 [setFontHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setfontheight) 以設定 20 點字體。
1. 儲存已修改的簡報。

以下範例需要工作目錄中有 `input.pptx`（至少包含一張投影片），會在位置 (50, 50) 以寬 600 點、高 400 點的尺寸加入預設資料的圖表。儲存的 `output.pptx` 會包含已啟用資料表格且套用指定字型設定的圖表。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **自訂資料表格邊框**

使用 [Chart.setDataTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/setdatatable/) 啟用表格，並透過 [Chart.getChartDataTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/getchartdatatable/) 取得它。您可以獨立控制三種邊框：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datatable/setborderhorizontal/) 控制水平儲存格邊框。
- [setBorderVertical](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datatable/setbordervertical/) 控制垂直儲存格邊框。
- [setBorderOutline](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datatable/setborderoutline/) 控制表格的外框。

將 `true` 傳入每個方法即可顯示相應邊框，傳入 `false` 則隱藏。以下範例建立一個預設資料的群組柱狀圖，顯示水平邊框與外框，隱藏垂直邊框。此範例不需要任何輸入檔案。圖表的位置與大小皆以點為單位指定。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下表比較使用相同圖表資料與圖例標記設定的四種情況。從全部啟用邊框開始，每個變體只關閉一種邊框設定。左下角的變體與範例的邊框設定相同。

![所有邊框皆啟用、無水平邊框、無垂直邊框、無外框的圖表資料表格](data-table-borders.png)

## **顯示或隱藏圖例標記**

圖例標記是資料表格中系列名稱旁的小彩色標示，能協助讀者將每一列對應到圖表的系列。將 `true` 傳入 [setShowLegendKey](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datatable/setshowlegendkey/) 即可顯示這些標記，傳入 `false` 則隱藏。

圖表的獨立圖例由 [Chart.setLegend](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/setlegend/) 控制。這兩項設定互不影響：隱藏獨立圖例不會隱藏資料表格內的標記，隱藏表格標記也不會隱藏獨立圖例。

以下範例建立一個預設資料的圖表，啟用資料表格，並在表格內顯示圖例標記，同時隱藏獨立圖例。所有表格邊框皆明確啟用。此範例不需要輸入簡報。若只想隱藏表格的標記，請將 `false` 傳入 [setShowLegendKey](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datatable/setshowlegendkey/)。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下表比較同一張表格在圖例標記顯示與隱藏的情況。所有邊框皆保持啟用，且兩種情況下獨立圖例皆為隱藏。

![左側顯示圖例標記、右側隱藏圖例標記的圖表資料表格](data-table-legend-keys.png)

## **常見問題**

**我可以在圖表的資料表格中顯示圖例標記嗎？**

可以。將 `true` 傳入 [setShowLegendKey](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datatable/setshowlegendkey/) 以顯示圖例標記，傳入 `false` 則隱藏。

**將簡報匯出為 PDF、HTML 或影像時，資料表格會被保留嗎？**

會。Aspose.Slides 在匯出至 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)、[HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/) 或 [images](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 時，會將圖表及其已顯示的資料表格一併渲染為投影片的一部分。

**我可以在從範本載入的圖表中使用資料表格嗎？**

可以。對於從既有簡報或範本載入的圖表，使用 [hasDataTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/hasdatatable/) 與 [setDataTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/setdatatable/) 來檢查或變更其資料表格是否顯示。

**我要如何找出已啟用資料表格的圖表？**

遍歷每張投影片上的形狀，辨識出圖表，並呼叫其 [hasDataTable](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/hasdatatable/) 方法。返回值為 `true` 表示該圖表已啟用資料表格。