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
description: "使用 ExcelDataWorkbook API 在 Aspose.Slides 中讀取 Excel 活頁簿的資料。載入工作表與儲存格，並利用其值產生以資料為驅動的 PowerPoint 簡報。"
---
## **簡介**

PowerPoint 簡報是一種強大的資訊展示與傳遞方式。它們常與 Excel 活頁簿結合使用，Excel 提供結構化的資料來源，而 PowerPoint 則善於將資料視覺化呈現給觀眾。

在許多實務情境中，結合 Excel 與 PowerPoint 是必須的：郵件合併、填充資料表格、為每筆資料產生一張投影片（批次投影片產生）、製作訓練教材，以及將多個 Excel 報表彙總成一個簡報，僅列舉幾例。

過去，使用 Aspose.Slides API 實作此類功能需要依賴第三方解決方案，例如 Aspose.Cells。雖然這些工具功能完整，但對於僅需基本資料整合功能的使用者而言，往往過於複雜且成本較高。

## **運作方式**

為了讓 Excel 資料的使用更加簡便、流暢，Aspose.Slides 引入了新的類別，用於讀取 Excel 活頁簿並將內容匯入簡報。此功能為想在簡報工作流程中利用 Excel 作為資料來源的 API 使用者開啟了強大的新可能性。

新功能設計為通用資料存取，並未整合至簡報文件物件模型（DOM）。也就是說*它不允許編輯或儲存 Excel 檔案*——它的唯一目的在於開啟活頁簿並瀏覽其內容以取得儲存格資料。

此功能的核心是全新 [ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldataworkbook/) 類別。此類別允許您從本機檔案或串流載入 Excel 活頁簿。載入後，它提供多個 [GetCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldataworkbook/getcell/) 方法的重載，您可依位置（例如列與欄索引或命名範圍）取得特定儲存格。

每次呼叫 [GetCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldataworkbook/getcell/) 都會回傳一個 [ExcelDataCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.excel/exceldatacell/) 類別的實例。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直觀的方式讓您存取其值。

#### **匯入 Excel 圖表**

接下來的擴充功能是 [ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/) 類別。此工具類別提供將 Excel 活頁簿內容匯入簡報的功能。它包含多個 [AddChartFromWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) 方法的重載，協助您從指定的 Excel 活頁簿中取得選取的圖表，並依指定座標將其加入給定形狀集合的末端。

簡而言之，這是一套輕量且直接的 API，用於讀取 Excel 資料——正是許多開發者在不需要完整試算表處理函式庫時所需的解決方案。

## **開始撰寫程式碼**

### **郵件合併情境範例**

在下列範例中，我們將實作一個簡易的郵件合併情境，根據儲存在 Excel 活頁簿中的資料產生多個簡報。

要開始，我們需要兩樣東西：
1. 包含資料的 Excel 活頁簿

![Excel data example](example1_image0.png)

2. PowerPoint 簡報範本

![PowerPoint template example](example1_image1.png)

```csharp
// 載入含有員工資料的 Excel 活頁簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 載入簡報範本。
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// 迴圈處理 Excel 列（排除第 0 列的標題）。
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // 為每筆員工記錄建立一個新簡報。
    using Presentation employeePresentation = new Presentation();

    // 移除預設的空白投影片。
    employeePresentation.Slides.RemoveAt(0);

    // 將範本投影片複製到新簡報中。
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // 從目標圖形取得段落（假設使用圖形索引 1）。
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // 使用 Excel 資料取代佔位字串。
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // 將個人化的簡報保存為獨立檔案。
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Result](example1_image2.png)

### **Excel 表格範例**

在第二個範例中，我們直接從 Excel 表格複製資料，並以更具視覺效果的方式在 PowerPoint 投影片上呈現。

此範例重複使用第一個範例中的相同 Excel 活頁簿，其中含有一個簡易的員工表格。

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

// 使用 Excel 活頁簿的資料填滿 PowerPoint 表格。
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// 將產生的簡報儲存至檔案。
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Result](example2_image0.png)

### **匯入 Excel 圖表範例**

在此範例中，我們從前一個範例使用的 Excel 活頁簿的第一個工作表匯入圖表。匯入的圖表在最終簡報中會連結至外部活頁簿。

首先，我們在 Excel 活頁簿中根據員工表格新增一個圓餅圖。

![Excel Chart example](example3_image0.png)

```csharp
// 建立新的 PowerPoint 簡報。
using Presentation presentation = new Presentation();

// 取得第一張投影片的圖形集合。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// 從活頁簿的第一張工作表匯入名為 "Chart 1" 的圖表，並加入圖形集合。
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// 將產生的簡報儲存為檔案。
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Result](example3_image1.png)

### **匯入全部 Excel 圖表範例**

想像您有一個充滿圖表的 Excel 活頁簿，需要將所有圖表匯入簡報。每個圖表都應該放在新的一張投影片上。

以下程式碼會遍歷來源 Excel 檔案的所有工作表，從每個工作表中抽取圖表，並使用空白投影片版面將每個圖表加入各自的投影片。最終簡報中只會嵌入圖表資料，而不會包含整個活頁簿。

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
    // 取得將圖表索引對應至圖表名稱的字典（針對此工作表）。
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // 使用空白版面新增投影片。
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // 從 Excel 活頁簿匯入指定圖表至投影片的圖形集合中。
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// 將產生的簡報儲存為檔案。
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **摘要**

此機制直接內建於 Aspose.Slides，將 Excel 資料與簡報的處理結合於同一平台。它讓您能在不額外引入其他函式庫或複雜整合的情況下，建立包含視覺圖表與 Excel 表格資料的投影片。