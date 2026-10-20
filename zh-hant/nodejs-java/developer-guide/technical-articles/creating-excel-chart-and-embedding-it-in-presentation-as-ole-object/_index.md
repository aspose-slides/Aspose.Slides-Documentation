---
title: 在簡報中建立 Excel 圖表並以 OLE 物件嵌入
type: docs
weight: 30
url: /zh-hant/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 圖表
- 嵌入圖表
- OLE 物件
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Cells for Node.js via Java 建立 Excel 圖表，並以 Aspose.Slides 將活頁簿嵌入 PowerPoint 簡報，包含圖表預覽。"
---
## **概述**

本文說明如何使用 Aspose.Cells for Node.js via Java 建立 Excel 柱狀圖，並將其活頁簿嵌入使用 Aspose.Slides for Node.js via Java 的 PowerPoint 簡報中。嵌入的活頁簿同時包含來源資料與圖表。另一張 PNG 預覽會在 OLE 物件啟用前於投影片上顯示圖表。

最終會得到嵌入的 Excel 物件，而非原生 PowerPoint 圖表。透過 OLE 編輯活頁簿需具備支援 OLE 啟動的桌面應用程式以及相容的 Excel 安裝。

## **先決條件**

安裝 `aspose.cells`、`aspose.slides.via.java` 與 `java` 的 Node.js 套件。將範例以兩個 CommonJS 腳本分別在不同的 Node.js 行程中執行：先執行 `create-chart.js`，再執行 `embed-chart.js`，並使用相同的工作目錄。兩個 Aspose 套件在載入時會初始化 Java 橋接器，因此範例必須分開執行。產生簡報時不需要安裝 Microsoft Office。

不需要事先存在的活頁簿或影像。第一個腳本會建立 `ChartWorkbook.xlsx` 與 `ChartPreview.png`；第二個腳本讀取這兩個檔案並將 `OutputChart.pptx` 寫入目前的工作目錄。於非評估模式執行時，請為兩個產品套用授權。

## **嵌入運作方式**

1. 建立包含資料工作表與圖表工作表的活頁簿。  
2. 將圖表工作表設為作用中，使活頁簿開啟時直接顯示圖表。  
3. 設定活頁簿的 OLE 顯示範圍，並將圖表渲染為 PNG。  
4. 將活頁簿儲存為 XLSX，並在另一個 Node.js 行程中將其位元組嵌入投影片。  
5. 將 PNG 設為 OLE 物件的預覽，並將簡報儲存為 PPTX。

活頁簿的顯示範圍與投影片上的框架扮演不同的角色。[setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) 使用從零開始的起始/結束列與欄索引。相對地，[ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) 使用上列、左欄、下列與右欄。範例將列索引 55 與欄索引 25 作為右下邊界；這些值僅為版面配置選擇，並非資料列或欄的數量。

投影片框架使用點 (points) 為單位。範例將其調整至投影片內部並置中，同時保留 PNG 的長寬比，而非將預覽拉伸至填滿投影片。

## **建立與嵌入圖表**

將第一個範例儲存為 `create-chart.js`。它會在 `DataSheet` 中填入四列五欄的數值。每一列會成為圖表的一個資料系列。儲存活頁簿前，會將 `ChartSheet` 設為作用中工作表。

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // 渲染圖表預覽並分別序列化可編輯的活頁簿。
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// 所有同步工作已完成; 停止 Java 橋接程序。
process.exit(0);
```

將下列範例儲存為 `embed-chart.js`。在 `create-chart.js` 產生兩個輸入檔案後執行它。此腳本會將 OLE 框置中，並保留預覽影像的長寬比。

第二個腳本會嵌入已儲存的活頁簿，並使用 PNG 作為其預覽。活頁簿會明確儲存為 XLSX，與傳遞給 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/) 的 `xlsx` 副檔名相符。PNG 直接從位元組載入，未經中介的點陣圖轉換。Java 橋接器需要明確的 Java 位元組陣列作為影像與活頁簿資料，並以 Java float 值指定投影片框架座標。透過 [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 設定可取代預設的 OLE 佔位圖。

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // 在投影片內部適應預覽，且不改變其長寬比。
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// 所有同步工作已完成; 停止 Java 橋接程序。
process.exit(0);
```

## **預期結果**

`OutputChart.pptx` 包含一張投影片，內有嵌入的 Excel 活頁簿與圖表預覽。活頁簿中有原始資料以及一個四系列的柱狀圖。預覽會置於投影片中央，且保留比例。

![Excel 柱狀圖作為嵌入活頁簿的預覽顯示](excel-chart-ole-preview.png)

在具備 Excel 的相容桌面 PowerPoint 環境中，雙擊該物件即可啟動並編輯嵌入的活頁簿。啟動與編輯取決於主機應用程式的 OLE 支援與安全性設定。

## **常見問題**

**為什麼需要預覽影像？**  
嵌入的活頁簿與投影片的預覽屬於不同的內容。提供圖表影像，使投影片顯示圖表，而非預設的「EMBEDDED OLE OBJECT」佔位符。請參閱 [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)。

**在程式碼中變更活頁簿時，預覽會自動更新嗎？**  
將預覽視為快照。當以程式方式更新活頁簿資料時，需要重新產生圖表影像，並同時取代預覽與嵌入的活頁簿資料。

**我可以使用 XLS 而非 XLSX 嗎？**  
可以。將活頁簿儲存為 XLS 格式，並使用 `xls` 作為嵌入資料的副檔名。副檔名必須與實際的活頁簿格式相符，僅變更副檔名不會轉換資料。

**為什麼物件在啟動後會改變大小？**  
當主機應用程式啟動活頁簿時，可能會更新 OLE 物件的呈現。活頁簿的 OLE 顯示範圍與投影片框架的尺寸皆會影響結果。請參閱 [PPTX 中圖表縮放的可行解決方案](/slides/zh-hant/java/working-solution-for-chart-resizing-in-pptx/)。

## **相關章節**

- [PPTX 中圖表縮放的可行解決方案](/slides/zh-hant/java/working-solution-for-chart-resizing-in-pptx/)
- [加入 OleObjectFrame 時的物件預覽問題](/slides/zh-hant/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)