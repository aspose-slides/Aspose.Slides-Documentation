---
title: 在 PPTX 中圖表調整大小的可行解決方案
type: docs
weight: 40
url: /zh-hant/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- 圖表調整大小
- Excel 圖表
- OLE 物件
- 嵌入圖表
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 嵌入的 Excel OLE 物件時，修復 PPTX 中意外的圖表調整大小問題。設定固定的圖表尺寸，以保持圖表與 OLE 框的大小一致。"
---
## **概述**

使用 Aspose 元件在 PowerPoint 簡報中以 OLE 物件嵌入的 Excel 圖表，在首次啟用後可能會變更大小。這會導致圖表在啟用前後的外觀出現明顯差異。本文說明產生調整大小的原因，並展示如何透過將固定圖表尺寸與 OLE 框匹配來防止此問題。

在 [在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)，我們說明了如何使用 Aspose.Cells for Node.js via Java 建立 Excel 圖表，並使用 Aspose.Slides for Node.js via Java 將其嵌入 PowerPoint 簡報。為了解決 [物件預覽問題](/slides/zh-hant/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)，我們將圖表圖像指派給圖表的 OLE 物件框。於輸出簡報中，當您雙擊顯示圖表圖像的 OLE 物件框時，Excel 圖表會被啟用。使用者可以編輯嵌入的 Excel 活頁簿，然後透過點擊已啟用活頁簿之外的區域返回投影片。使用者返回投影片時，OLE 物件框的大小會發生變化，而且調整比例會依據 OLE 物件框與嵌入的 Excel 活頁簿的原始大小而有所不同。

## **調整大小的原因**

嵌入的 Excel 活頁簿有其自身的視窗尺寸，Excel 會嘗試在物件首次啟用時保留該尺寸。投影片上的 OLE 框則有獨立定義的尺寸。當 Excel 活頁簿被啟用時，Excel 與 PowerPoint 會協商物件的大小，以在嵌入過程中保持其比例。因此，活頁簿視窗與 OLE 框之間的差異會導致物件調整大小。

## **可行的解決方案**

將圖表尺寸與投影片上的 OLE 框匹配，且保持圖表尺寸獨立於活頁簿視窗。此解決方案適用於新簡報或既有範本。

此範例需要 Aspose.Cells for Node.js via Java 與 Aspose.Slides for Node.js via Java。安裝 `aspose.cells`、`aspose.slides.via.java` 與 `java` Node.js 套件。於不同的 Node.js 行程中執行下方兩個 CommonJS 腳本，使用相同的工作目錄，因為兩個 Aspose 套件在載入時皆會初始化 Java 橋接。它會在活動圖表工作表上建立簡單的直條圖，並以 XLS 格式嵌入活頁簿。未指派圖表預覽影像；圖表會在 PowerPoint 中 OLE 物件被啟用時顯示。

此範例建立一個新的簡報，使用 9.5 × 4 吋的 OLE 框，該框位於左邊緣 0.5 吋、上方 1 吋處。投影片的座標與尺寸使用點（每英吋 72 點）表示。若使用既有簡報，請參閱 [使用範本](#use-a-template)。

## **設定固定圖表大小**

將 [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) 設為 false，以使圖表尺寸獨立於活頁簿視窗。透過 [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) 與 [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight) 設定 [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) 的尺寸，並以每英吋 96 像素將點轉換為像素：684 × 288 點的框相當於 912 × 384 像素的圖表。將 [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) 設為 `PrintSizeType` 的 CUSTOM 值。範例使用 [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) 嵌入活頁簿，並以 9.5 × 4 吋的 OLE 框儲存簡報。

將此第一個腳本儲存為 `create-fixed-chart.js`。它會產生 `chart-fixed-size.xls`，其中圖表大小為 912 × 384 像素，與第二個腳本使用的 684 × 288 點框相匹配。無需提供輸入活頁簿。
```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // 匹配 OLE 框的尺寸（單位為點，每英吋 72 點）。
    const width = 684; // 9.5 吋。
    const height = 288; // 4 吋。

    chart.setSizeWithWindow(false);
    // 將點轉換為圖表像素，使用每英吋 96 像素。
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// 所有同步工作已完成；停止 Java 橋接程序。
process.exit(0);
```

將第二個腳本儲存為 `embed-fixed-chart.js`，並在 `create-fixed-chart.js` 之後執行。它會讀取產生的 XLS 活頁簿，並儲存為 `chart-fixed-size.pptx`。Java 橋接需要明確的 Java 位元組陣列作為活頁簿資料，並以 Java 浮點數提供框的座標與尺寸。`xls` 副檔名符合活頁簿的儲存格式。
```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // 投影片座標與尺寸以點為單位（每英吋 72 點）。
    const width = 684; // 9.5 吋。
    const height = 288; // 4 吋。
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// 所有同步工作已完成；停止 Java 橋接程序。
process.exit(0);
```

## **使用範本**

既有簡報的尺寸邏輯相同。要套用此範例：

1. 載入範本簡報，而非建立空的簡報。
1. 確認第一張投影片至少包含三個圖形，然後使用索引為 2 的圖形作為佔位元。
1. 從該圖形取得框的寬度與高度，取代使用固定值 684 與 288。於活頁簿建立腳本中使用相同尺寸，保持尺寸計算不變，並在嵌入前重新產生 XLS 活頁簿。
1. 在佔位元位置加入 OLE 框，取代使用固定座標 36 與 72。
1. 在儲存簡報前移除佔位元。

## **FAQ**

**為什麼嵌入的 Excel 圖表在 PowerPoint 中啟用後會改變大小？**

這是因為 Excel 在首次啟用時嘗試還原原始視窗大小，而 PowerPoint 中的 OLE 物件框具有自己的尺寸。PowerPoint 與 Excel 會協商大小以維持長寬比，從而導致調整大小。

**如何保持圖表與 OLE 框的尺寸一致？**

將固定的圖表尺寸設為與 OLE 框相匹配，並在嵌入活頁簿前使用自訂的圖表列印尺寸。上述範例展示了所需的設定與單位換算。

**僅匹配活頁簿視窗大小是否足夠？**

僅匹配活頁簿視窗大小並不能可靠地防止 OLE 框在啟用後變更大小。請使用如範例所示的固定圖表尺寸。

**此解決方案同時適用於基於範本的簡報與新簡報嗎？**

是的。對於範本，使用佔位元的尺寸與位置。對於新簡報，直接指定框的尺寸與位置。

**我可以將此範例用於其他試算表程式建立的圖表嗎？**

此範例使用 Aspose.Cells 建立的 Excel 活頁簿。未示範其他試算表程式的啟用行為。

## **相關章節**

- [在簡報中建立 Excel 圖表並將其嵌入為 OLE 物件](/slides/zh-hant/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)