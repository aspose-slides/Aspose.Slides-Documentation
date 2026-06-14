---
title: 將 Excel 資料整合至 PowerPoint 簡報
linktitle: Excel 整合
type: docs
weight: 330
url: /zh-hant/nodejs-java/excel-integration/
keywords:
- Excel
- 活頁簿
- 讀取 Excel
- 整合 Excel
- 資料來源
- 郵件合併
- 匯入表格
- Excel 轉 PowerPoint
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中讀取 Excel 活頁簿資料。載入工作表與儲存格，並利用其值產生資料驅動的 PowerPoint 簡報。"
---
## **簡介**

PowerPoint 簡報是一種強大的資訊展示與傳達方式。它們常與 Excel 活頁簿結合使用，Excel 提供結構化資料來源，而 PowerPoint 則擅長將這些資料視覺化給觀眾。

在許多實務情境中，結合 Excel 與 PowerPoint 是必要的：郵件合併、填充資料表格、為每筆資料記錄產生一張投影片（批次投影片產生）、製作訓練教材，以及將多個 Excel 報告合併成單一簡報，僅列舉幾例。

直到現在，使用 Aspose.Slides API 實作這類功能需要依賴像 Aspose.Cells 之類的第三方解決方案。雖然這些工具功能完整，但對只需要基本資料整合功能的使用者而言，往往過於複雜且成本高昂。

## **運作方式**

為了讓 Excel 資料的使用更簡便、流程更順暢，Aspose.Slides 引入了新類別，用於從 Excel 活頁簿讀取資料並將內容匯入簡報。此功能為 API 使用者提供了在簡報工作流程中以 Excel 作為資料來源的強大新可能性。

新功能設計為一般用途的資料存取，並未整合至簡報文件物件模型（DOM）。這表示*它不允許編輯或儲存 Excel 檔案*——唯一目的在於開啟活頁簿並瀏覽其內容以取得儲存格資料。

此功能的核心是全新的[ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/exceldataworkbook/)類別。此類別允許您從本機檔案或串流載入 Excel 活頁簿。載入後，它提供多種[ getCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/exceldataworkbook/#getCell) 方法的重載，您可以依照位置（例如列與欄索引或命名範圍）取得特定儲存格。

每次呼叫[ getCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/exceldataworkbook/#getCell) 皆會回傳一個[ExcelDataCell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/exceldatacell/)實例。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直覺的方式提供其值。

#### **匯入 Excel 圖表**

接下來的擴充功能是[ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/excelworkbookimporter/)類別。此實用程式類別提供將 Excel 活頁簿內容匯入簡報的功能。它包含多種[ addChartFromWorkbook](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) 方法的重載，協助您從指定的 Excel 活頁簿中取得選取的圖表，並依座標將其新增至給定圖形集合的末端。

簡而言之，這是一個輕量且直觀的 API，用於讀取 Excel 資料——正是許多開發者在不需要完整試算表處理函式庫時所需要的。

## **讓我們寫程式**

### **郵件合併情境範例**

以下範例將示範如何透過 Excel 活頁簿中的資料，產生多個簡報，以實作簡易的郵件合併情境。

開始之前，我們需要兩樣東西：
1. 含有資料的 Excel 活頁簿

![Excel 資料範例](example1_image0.png)

2. PowerPoint 範本範例

![PowerPoint 範本範例](example1_image1.png)

```js
// 載入包含員工資料的 Excel 活頁簿。
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// 載入簡報範本。
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // 遍歷 Excel 列（排除第 0 行的標題）。
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // 為每筆員工紀錄建立新簡報。
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // 移除預設的空白投影片。
            employeePresentation.getSlides().removeAt(0);

            // 將範本投影片克隆至新簡報中。
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // 從目標圖形取得段落（假設使用圖形索引 1）。
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // 以 Excel 資料取代佔位字元。
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // 將個人化簡報儲存為單獨檔案。
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![結果](example1_image2.png)

### **Excel 表格範例**

在第二個範例中，我們僅將 Excel 表格中的資料複製，並以更具視覺吸引力的格式顯示於 PowerPoint 投影片上。

此範例重新使用第一個範例的相同 Excel 活頁簿，其中包含一個簡易的員工表格。

```js
// 載入包含員工資料的 Excel 活頁簿。
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// 建立新的 PowerPoint 簡報。
let presentation = new aspose.slides.Presentation();

try {
    // 在第一張投影片加入表格圖形。
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // 使用 Excel 活頁簿的資料填充 PowerPoint 表格。
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // 將產生的簡報儲存為檔案。
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![結果](example2_image0.png)

### **匯入 Excel 圖表範例**

本範例將從前一個範例所使用的 Excel 活頁簿的第一個工作表匯入圖表。匯入的圖表在最終簡報中會連結至外部活頁簿。

首先，我們根據員工表格在 Excel 活頁簿中新增一個圓餅圖。

![Excel 圖表範例](example3_image0.png)

```js
// 建立新的 PowerPoint 簡報。
let presentation = new aspose.slides.Presentation();
try {
    // 取得第一張投影片的圖形集合。
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // 從活頁簿的第一張工作表匯入名稱為「Chart 1」的圖表，並將其加入圖形集合。
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // 將產生的簡報儲存為檔案。
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![結果](example3_image1.png)

### **匯入全部 Excel 圖表範例**

想像一下您手上有一個充滿圖表的 Excel 活頁簿，且需要將所有圖表全部匯入簡報。每個圖表都應放置在新的一張投影片上。

以下程式碼會遍歷來源 Excel 檔案的所有工作表，從每個工作表中擷取圖表，並使用空白投影片版面將每個圖表新增至獨立的投影片。最終的簡報中僅會嵌入圖表資料，而不會包含整個活頁簿。

```js
// 載入包含員工資料的 Excel 活頁簿。
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 建立新的 PowerPoint 簡報。
let presentation = new aspose.slides.Presentation();
try {
    // 取得空白投影片版面配置。
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // 取得 Excel 活頁簿中所有工作表的名稱。
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // 取得將圖表索引對映至圖表名稱的映射表（用於該工作表）。
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // 使用空白版面新增投影片。
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // 將指定的圖表從 Excel 活頁簿匯入至投影片的圖形集合中。
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // 將產生的簡報儲存為檔案。
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **總結**

此機制直接內建於 Aspose.Slides，將 Excel 資料與簡報的處理合併於同一環境。它讓您能在簡報中建立視覺化圖表與以 Excel 表格呈現的資料——無需額外函式庫或複雜整合。