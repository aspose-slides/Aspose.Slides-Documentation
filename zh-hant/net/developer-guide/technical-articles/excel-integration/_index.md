---
title: 將 Excel 資料整合至 PowerPoint 簡報
linktitle: Excel 整合
type: docs
weight: 330
url: /zh-hant/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
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
description: "使用 ExcelDataWorkbook API 在 Aspose.Slides 中讀取 Excel 活頁簿的資料。載入工作表與儲存格，並利用其值產生以資料為驅動的 PowerPoint 簡報。"
---
## **簡介**

PowerPoint 簡報是展示與傳達資訊的強大工具。它們常與 Excel 活頁簿結合使用，Excel 作為結構化資料的極佳來源，而 PowerPoint 則擅長將這些資料以視覺化方式呈現給觀眾。

結合 Excel 與 PowerPoint 在許多實務情境中都是必需的：郵件合併、填充資料表格、依每筆資料產生單一投影片（批次投影片產生）、製作訓練教材，以及將多個 Excel 報表合併成一個簡報等。

到目前為止，使用 Aspose.Slides API 實作這類功能必須依賴像 Aspose.Cells 之類的第三方解決方案。雖然這些工具功能強大，但對於只需要基本資料整合功能的使用者來說，往往過於複雜且成本高昂。

## **運作原理**

為了讓 Excel 資料的使用更簡易且順暢，Aspose.Slides 推出了用於從 Excel 活頁簿讀取資料並將內容匯入簡報的新類別。此功能為希望在簡報工作流程中將 Excel 作為資料來源的 API 使用者開啟了強大的新可能性。

此新功能設計為一般用途的資料存取，未整合至簡報文件物件模型 (DOM)。這表示 *它不允許編輯或儲存 Excel 檔案* — 唯一的目的在於開啟活頁簿並瀏覽其內容以取得儲存格資料。

此功能的核心是全新的 [ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldataworkbook/) 類別。此類別允許您從本機檔案或串流載入 Excel 活頁簿。載入後，它提供多個 [GetCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldataworkbook/getcell/) 方法的重載，您可依儲存格位置（例如列與欄索引或命名範圍）取得特定儲存格。

每次呼叫 [GetCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldataworkbook/getcell/) 都會回傳 [ExcelDataCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldatacell/) 類別的實例。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直覺的方式讓您取得其值。

#### **匯入 Excel 圖表**

擴充功能的下一步是 [ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/) 類別。此工具類別提供將 Excel 活頁簿內容匯入簡報的功能。它包含多個 [AddChartFromWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) 方法的重載，協助您從指定的 Excel 活頁簿取得選取的圖表，並依指定座標將其加入給定圖形集合的末端。

#### **匯入 Excel 表格**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/) 類別同樣包含多個 [AddTableFromWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) 方法的重載。這些方法允許您從指定工作表匯入特定儲存格範圍，並依指定座標將其作為表格加入給定圖形集合的末端。

簡言之，這是一套輕量且直接的 API，用於讀取 Excel 資料 —— 正是許多開發人員所需，且不需承擔完整試算表處理函式庫的負擔。

## **讓我們編寫程式**

### **郵件合併情境範例**

在下列範例中，我們將實作一個簡單的郵件合併情境，透過根據儲存在 Excel 活頁簿中的資料產生多個簡報。

要開始，我們需要兩樣東西：
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

// 迭代 Excel 列（排除第 0 行的標題）。
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // 為每筆員工紀錄建立新的簡報。
    using Presentation employeePresentation = new Presentation();

    // 移除預設的空白投影片。
    employeePresentation.Slides.RemoveAt(0);

    // 將範本投影片複製至新簡報。
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // 從目標圖形取得段落（假設使用圖形索引 1）。
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // 用 Excel 資料取代佔位字串。
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // 將個人化的簡報儲存為個別檔案。
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![結果](example1_image2.png)

### **Excel 表格範例**

在第二個範例中，我們僅將 Excel 表格中的資料複製並以更具視覺吸引力的格式顯示於 PowerPoint 投影片上。

此範例中，我們重複使用第一個範例的同一個 Excel 活頁簿，其中包含一個簡單的員工表格。

```csharp
// 載入包含員工資料的 Excel 活頁簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 建立新的 PowerPoint 簡報。
using Presentation presentation = new Presentation();

// 在第一張投影片上新增表格圖形。
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// 用 Excel 活頁簿的資料填充 PowerPoint 表格。
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

在此範例中，我們從先前範例所使用的 Excel 活頁簿的第一個工作表匯入圖表。該圖表在產生的簡報中將連結至外部活頁簿。

首先，我們根據員工表格在 Excel 活頁簿中新增一個圓餅圖。

![Excel 圖表範例](example3_image0.png)

```csharp
// 建立新的 PowerPoint 簡報.
using Presentation presentation = new Presentation();

// 取得第一張投影片的圖形集合.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// 從工作簿的第一個工作表匯入名為 "Chart 1" 的圖表，並將其加入圖形集合.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// 將產生的簡報儲存為檔案.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![結果](example3_image1.png)

### **匯入所有 Excel 圖表範例**

假設您有一本包含大量圖表的 Excel 活頁簿，且需要將所有圖表匯入簡報。每個圖表都應放置於新的一張投影片上。

以下程式碼會遍歷來源 Excel 檔案中的所有工作表，從每個工作表提取圖表，並使用空白投影片版面將每個圖表加入至各自的投影片中。於產生的簡報中，僅嵌入圖表資料，並不包括整本活頁簿。

```csharp
// 載入包含員工資料的 Excel 活頁簿.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 建立新的 PowerPoint 簡報.
using Presentation presentation = new Presentation();

// 取得空白投影片版面.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// 取得 Excel 活頁簿中所有工作表的名稱.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // 取得將圖表索引對映至圖表名稱的字典（針對該工作表）.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // 使用空白版面新增投影片.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // 將指定的圖表從 Excel 活頁簿匯入至投影片的圖形集合中.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// 將產生的簡報儲存為檔案.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **匯入 Excel 表格範例**

在此範例中，我們直接將 Excel 工作表中的格式化表格匯入 PowerPoint 簡報。

來源 Excel 工作表包含一個帶有員工資料的格式化表格：

![Excel 表格範例](example4_image0.png)

```csharp
// 建立新的 PowerPoint 簡報.
using Presentation presentation = new Presentation();

// 取得第一張投影片的圖形集合.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// 從活頁簿的第一個工作表匯入表格，並將其加入圖形集合.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// 將產生的簡報儲存為檔案.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![結果](example4_image1.png)

## **總結**

此機制直接內建於 Aspose.Slides，將 Excel 資料與簡報的操作結合於同一場所。它讓您能建立包含視覺化圖表及以 Excel 表格形式呈現資料的投影片 —— 無需任何額外函式庫或複雜的整合。