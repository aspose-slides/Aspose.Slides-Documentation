---
title: 將 Excel 資料整合至 PowerPoint 簡報
linktitle: Excel 整合
type: docs
weight: 330
url: /zh-hant/androidjava/excel-integration/
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
- Android
- Java
- Aspose.Slides
description: "使用 ExcelDataWorkbook API 在 Aspose.Slides 中讀取 Excel 活頁簿資料。載入工作表與儲存格，並利用其值產生以資料為驅動的 PowerPoint 簡報。"
---
## **簡介**

PowerPoint 簡報是顯示與傳遞資訊的強大方式。它們常與 Excel 活頁簿一起使用，Excel 提供了優秀的結構化資料來源，而 PowerPoint 則擅長將這些資料視覺化呈現給觀眾。

有許多實務情境需要結合 Excel 與 PowerPoint：郵件合併、填充資料表格、針對每筆資料產生一張投影片（批次投影片產生）、製作訓練教材，以及將多個 Excel 報表合併成單一簡報，僅列舉其中幾項。

直到現在，使用 Aspose.Slides API 實作此類功能仍需依賴像 Aspose.Cells 等第三方解決方案。雖然這些工具功能強大，但對於僅需基本資料整合功能的使用者而言，往往過於複雜且成本高昂。

## **運作方式**

為了讓 Excel 資料的使用更簡便、流程更順暢，Aspose.Slides 推出了用於讀取 Excel 活頁簿資料並將內容匯入簡報的新類別。此功能為想在簡報工作流程中將 Excel 作為資料來源的 API 使用者開啟了全新的強大可能性。

此新功能旨在提供通用資料存取，並未整合至簡報文件物件模型 (DOM)。這意味著*它不允許編輯或儲存 Excel 檔案*——其唯一目的在於開啟活頁簿，並瀏覽其內容以取得儲存格資料。

此功能的核心是全新的[ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/exceldataworkbook/) 類別。此類別允許您從本機檔案或串流載入 Excel 活頁簿。載入後，它提供多個[getCell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) 方法的重載，您可藉由位置（例如列與欄索引或已命名的範圍）取得特定儲存格。

每次呼叫[getCell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) 都會回傳[ExcelDataCell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/exceldatacell/) 類別的實例。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直觀的方式讓您取得其值。

#### **匯入 Excel 圖表**

下一步擴充功能是[ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/excelworkbookimporter/) 類別。此工具類別提供將 Excel 活頁簿內容匯入簡報的功能。它包含多個[addChartFromWorkbook](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) 方法的重載，協助您從指定的 Excel 活頁簿取得所選圖表，並依指定座標將其加入給定形狀集合的末端。

簡而言之，這是一套輕量且直接的 API，用於讀取 Excel 資料——正是許多開發者在不需完整試算表處理函式庫負擔下所需要的功能。

## **讓我們開始編寫程式**

### **郵件合併情境範例**

在以下範例中，我們將實作簡易的郵件合併情境，透過根據 Excel 活頁簿中儲存的資料產生多個簡報。

要開始，我們需要兩項內容：

1. 含有資料的 Excel 活頁簿

![Excel 資料範例](example1_image0.png)

2. PowerPoint 簡報範本

![PowerPoint 範本範例](example1_image1.png)

```java
// 載入包含員工資料的 Excel 活頁簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 載入簡報範本。
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // 逐行遍歷 Excel 資料列（排除第 0 列標題）。
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // 為每筆員工紀錄建立新簡報。
        Presentation employeePresentation = new Presentation();

        try {
            // 移除預設的空白投影片。
            employeePresentation.getSlides().removeAt(0);

            // 將範本投影片複製到新簡報中。
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // 從目標形狀取得段落（假設使用形狀索引 1）。
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // 用 Excel 資料取代佔位字串。
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // 將個人化的簡報儲存為獨立檔案。
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
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

在第二個範例中，我們僅簡單地從 Excel 表格複製資料，並以更具視覺吸引力的方式顯示於 PowerPoint 投影片上。

此範例中，我們重複使用第一個範例的相同 Excel 活頁簿，該活頁簿包含一個簡易的員工表格。

```java
// 載入包含員工資料的 Excel 活頁簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 建立新的 PowerPoint 簡報。
Presentation presentation = new Presentation();

try {
    // 在第一張投影片加入表格形狀。
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // 用 Excel 活頁簿的資料填充 PowerPoint 表格。
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // 將產生的簡報儲存至檔案。
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![結果](example2_image0.png)

### **匯入 Excel 圖表範例**

在此範例中，我們從先前範例所使用的 Excel 活頁簿的第一個工作表匯入圖表。該圖表在最終簡報中將連結至外部活頁簿。

首先，我們依據員工表格在 Excel 活頁簿中加入一個圓餅圖。

![Excel 圖表範例](example3_image0.png)

```java
// 建立新的 PowerPoint 簡報。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片的形狀集合。
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // 從活頁簿的第一張工作表匯入名為「Chart 1」的圖表，並將其加入形狀集合。
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // 將產生的簡報儲存至檔案。
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![結果](example3_image1.png)

### **匯入所有 Excel 圖表範例**

假設您有一個滿載圖表的 Excel 活頁簿，且需要將所有圖表匯入簡報。每個圖表都應置於新的一張投影片上。

以下程式碼會遍歷來源 Excel 檔案的全部工作表，從每個工作表提取圖表，並使用空白投影片版面將每個圖表加入各自的投影片。於最終簡報中，僅嵌入圖表資料，不會包含整個活頁簿。

```java
// 載入包含員工資料的 Excel 活頁簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 建立新的 PowerPoint 簡報。
Presentation presentation = new Presentation();
try {
    // 取得空白投影片版面配置。
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // 取得 Excel 活頁簿中所有工作表的名稱。
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // 取得將圖表索引對映至圖表名稱的映射表，針對該工作表。
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // 使用空白版面新增投影片。
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // 從 Excel 活頁簿匯入指定的圖表至投影片的形狀集合。
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // 將產生的簡報儲存至檔案。
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **摘要**

此機制直接內建於 Aspose.Slides，將 Excel 資料與簡報的處理合而為一。它讓您能製作包含視覺化圖表與以 Excel 表格形式呈現之資料的投影片，而無需額外的函式庫或複雜的整合。