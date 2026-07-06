---
title: 將 Excel 資料整合至 PowerPoint 簡報
linktitle: Excel 整合
type: docs
weight: 330
url: /zh-hant/net/excel-integration/
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
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides 中使用 ExcelDataWorkbook API 讀取 Excel 活頁簿的資料。載入工作表與儲存格，並利用其值產生資料驅動的 PowerPoint 簡報。"
---
## **簡介**

PowerPoint 簡報是顯示和傳達資訊的強大方式。它們常與 Excel 活頁簿一起使用，Excel 為結構化資料提供優秀的來源，而 PowerPoint 則擅長為觀眾視覺化這些資料。

有許多實務情境需要結合 Excel 與 PowerPoint：郵件合併、填充資料表、為每筆資料記錄生成一張投影片（批次投影片產生）、製作訓練教材，以及將多個 Excel 報告彙總到單一簡報等。

直到現在，使用 Aspose.Slides API 實作這類功能必須依賴第三方解決方案，如 Aspose.Cells。雖然這些工具功能強大，但對於只需要基本資料整合功能的使用者來說，可能過於複雜且成本高昂。

## **運作方式**

為了讓處理 Excel 資料更簡單且更順暢，Aspose.Slides 引入了新的類別，用於從 Excel 活頁簿讀取資料並將內容匯入簡報。此功能為想在簡報工作流程中使用 Excel 作為資料來源的 API 使用者開啟了強大的新可能性。

新的功能設計為一般用途的資料存取，並未整合至簡報文件物件模型（DOM）中。這意味著 *它不允許編輯或儲存 Excel 檔案*——它唯一的目的只是開啟活頁簿並瀏覽其內容以取得儲存格資料。

此功能的核心是全新的 [ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldataworkbook/) 類別。此類別允許您從本機檔案或串流載入 Excel 活頁簿。載入後，它提供多個 [GetCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldataworkbook/getcell/) 方法的重載，您可依位置（例如列與欄索引或命名範圍）取得特定儲存格。

每次呼叫 [GetCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldataworkbook/getcell/) 都會回傳一個 [ExcelDataCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldatacell/) 類別的實例。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直觀的方式提供其值。

#### **匯入 Excel 圖表**

要擴充功能的下一步是 [ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/) 類別。此實用程式類別提供從 Excel 活頁簿匯入內容至簡報的功能。它包含多個 [AddChartFromWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) 方法的重載，協助您從指定的 Excel 活頁簿取得選取的圖表，並依指定座標將其加入給定圖形集合的末端。

#### **匯入 Excel 表格**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/) 類別同樣包含多個 [AddTableFromWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) 方法的重載。這些方法允許您從指定工作表的特定儲存格範圍匯入，並依指定座標將其作為表格加入給定圖形集合的末端。

簡而言之，這是一個輕量且直接的 API 用於讀取 Excel 資料——正是許多開發者在不需要完整試算表處理庫的情況下所需要的。

## **開始程式碼**

### **郵件合併情境範例**

在以下範例中，我們將實作一個簡易的郵件合併情境，透過產生多個簡報來根據儲存在 Excel 活頁簿中的資料進行合併。

開始之前，我們需要兩樣東西：
1. 包含資料的 Excel 活頁簿

![Excel 資料範例](example1_image0.png)

2. PowerPoint 簡報範本

![PowerPoint 範本範例](example1_image1.png)

```csharp
// 載入包含員工資料的 Excel 活頁簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 載入簡報範本。
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// 迴圈處理 Excel 列（排除第 0 列標題）。
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // 為每筆員工記錄建立新的簡報。
    using Presentation employeePresentation = new Presentation();

    // 移除預設的空白投影片。
    employeePresentation.Slides.RemoveAt(0);

    // 將範本投影片克隆到新簡報中。
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // 從目標圖形取得段落（假設使用圖形索引 1）。
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // 使用 Excel 資料取代佔位符。
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // 將個人化的簡報儲存為單獨檔案。
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![結果](example1_image2.png)

### **Excel 表格範例**

在第二個範例中，我們僅將 Excel 表格中的資料複製，並以更具視覺效果的格式顯示在 PowerPoint 投影片上。

此範例中，我們重新使用第一個範例的同一個 Excel 活頁簿，內含簡易的員工表格。

```csharp
// 載入包含員工資料的 Excel 活頁簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 建立新的 PowerPoint 簡報。
using Presentation presentation = new Presentation();

// 在第一張投影片加入表格圖形。
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// 使用 Excel 活頁簿的資料填充 PowerPoint 表格。
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// 將產生的簡報儲存為檔案。
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![結果](example2_image0.png)

### **匯入 Excel 圖表範例**

在此範例中，我們從先前範例使用的 Excel 活頁簿的第一個工作表匯入圖表。該圖表在最終的簡報中將連結至外部活頁簿。

首先，我們根據員工表格在 Excel 活頁簿中加入一個圓形圖。

![Excel 圖表範例](example3_image0.png)

```csharp
// 建立新的 PowerPoint 簡報。
using Presentation presentation = new Presentation();

// 取得第一張投影片的圖形集合。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// 從活頁簿的第一張工作表匯入名稱為「Chart 1」的圖表，並將其加入圖形集合。
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// 將產生的簡報儲存為檔案。
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![結果](example3_image1.png)

### **匯入所有 Excel 圖表範例**

假設您有一個充滿圖表的 Excel 活頁簿，且需要將所有圖表匯入至簡報中。每個圖表都應放置在新的一張投影片上。

以下程式碼會遍歷來源 Excel 檔案的所有工作表，從每個工作表中擷取圖表，並使用空白投影片版面將每個圖表加入至單獨的投影片。在最終的簡報中，僅會嵌入圖表資料，而不會嵌入整個活頁簿。

```csharp
// 載入包含員工資料的 Excel 活頁簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 建立新的 PowerPoint 簡報。
using Presentation presentation = new Presentation();

// 取得空白投影片版面配置。
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// 取得 Excel 活頁簿中所有工作表的名稱。
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // 取得將圖表索引對應至圖表名稱的字典，以供該工作表使用。
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // 使用空白版面新增投影片。
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // 從 Excel 活頁簿匯入指定圖表至投影片的圖形集合。
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// 將產生的簡報儲存為檔案。
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **匯入 Excel 表格範例**

在此範例中，我們直接從 Excel 工作表匯入已格式化的表格至 PowerPoint 簡報。

來源 Excel 工作表包含一個已格式化的員工資料表格：

![Excel 表格範例](example4_image0.png)

```csharp
// 建立新的 PowerPoint 簡報。
using Presentation presentation = new Presentation();

// 取得第一張投影片的圖形集合。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// 從活頁簿的第一張工作表匯入表格，並將其加入圖形集合。
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// 將產生的簡報儲存為檔案。
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![結果](example4_image1.png)

## **總結**

此機制直接內建於 Aspose.Slides，可在同一個環境中結合 Excel 資料與簡報的操作。它讓您可建立包含視覺圖表與以 Excel 表格呈現資料的投影片——無需額外的程式庫或複雜的整合。