---
title: 將 Excel 資料整合至 PowerPoint 簡報
linktitle: Excel 整合
type: docs
weight: 330
url: /zh-hant/cpp/excel-integration/
keywords:
- Excel
- 活頁簿
- 讀取 Excel
- 整合 Excel
- 資料來源
- 郵件合併
- 匯入表格
- Excel 匯入 PowerPoint
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 ExcelDataWorkbook API 在 Aspose.Slides 中讀取 Excel 活頁簿的資料。載入工作表與儲存格，並使用其值產生資料驅動的 PowerPoint 簡報。"
---
## **簡介**

PowerPoint 簡報是顯示與傳達資訊的強大方式。它們常與 Excel 活頁簿一起使用，Excel 提供結構化資料的絕佳來源，而 PowerPoint 則擅長為觀眾將這些資料可視化。

有許多實務情境需要結合 Excel 與 PowerPoint：郵件合併、填充資料表、為每筆資料記錄產生一張投影片（批次投影片產生）、製作訓練教材，以及將多個 Excel 報表整合成單一簡報等。

過去，使用 Aspose.Slides API 實作這類功能必須依賴像 Aspose.Cells 之類的第三方解決方案。雖然這些工具功能完整，但對於僅需要基本資料整合功能的使用者而言，往往過於複雜且成本高昂。

## **運作方式**

為了讓 Excel 資料的使用更簡易、更流暢，Aspose.Slides 推出了可從 Excel 活頁簿讀取資料並匯入至簡報的新類別。此功能為想在簡報工作流程中將 Excel 作為資料來源的 API 使用者開啟了全新可能性。

這項新功能設計為一般用途的資料存取，並未整合至簡報文件物件模型（DOM）。也就是說*它不允許編輯或儲存 Excel 檔案*——其唯一目的在於開啟活頁簿並導覽其內容以取得儲存格資料。

此功能的核心是全新的[ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.excel/exceldataworkbook/)類別。此類別允許您從本機檔案或串流載入 Excel 活頁簿。載入後，它提供多個[GetCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.excel/exceldataworkbook/getcell/)方法的重載，您可以依位置（例如列與欄索引或已命名範圍）取得特定儲存格。

每次呼叫[GetCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.excel/exceldataworkbook/getcell/)都會回傳一個[ExcelDataCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.excel/exceldatacell/)類別的實例。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直觀的方式提供其值。

#### **匯入 Excel 圖表**

接下來的擴充功能是[ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.import/excelworkbookimporter/)類別。此工具類別提供將 Excel 活頁簿內容匯入至簡報的功能。它包含多個[AddChartFromWorkbook](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/)方法的重載，協助您從指定的 Excel 活頁簿取得選定的圖表，並依指定座標將其加入至給定圖形集合的末端。

簡而言之，這是一個輕量且直接的 API，用於讀取 Excel 資料——正是許多開發者在不需要完整試算表處理函式庫的情況下所需的功能。

## **讓我們開始編碼**

### **郵件合併情境範例**

在以下範例中，我們將實作簡易的郵件合併情境，根據儲存在 Excel 活頁簿中的資料產生多份簡報。

開始之前，我們需要兩樣東西：
1. 含有資料的 Excel 活頁簿

![Excel 資料範例](example1_image0.png)

2. PowerPoint 簡報範本

![PowerPoint 範本範例](example1_image1.png)

```cpp
// 載入包含員工資料的 Excel 活頁簿。
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// 載入簡報範本。
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // 遍歷 Excel 列（排除第 0 列的標題）。
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // 為每筆員工記錄建立新簡報。
    auto employeePresentation = MakeObject<Presentation>();

    // 移除預設的空白投影片。
    employeePresentation->get_Slides()->RemoveAt(0);

    // 將範本投影片複製到新簡報中。
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // 從目標圖形取得段落（假設使用圖形索引 1）。
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // 將佔位符替換為來自 Excel 的資料。
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // 將個人化簡報儲存為個別檔案。
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![結果](example1_image2.png)

### **Excel 表格範例**

在第二個範例中，我們只要從 Excel 表格複製資料，並以更具視覺吸引力的格式顯示於 PowerPoint 投影片上。

本例仍使用第一個範例的相同 Excel 活頁簿，其中包含一個簡易的員工表格。

```cpp
// 載入包含員工資料的 Excel 活頁簿。
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// 建立新的 PowerPoint 簡報。
auto presentation = MakeObject<Presentation>();

// 在第一張投影片加入表格形狀。
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// 將 PowerPoint 表格以 Excel 活頁簿的資料填入。
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// 將產生的簡報儲存至檔案。
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![結果](example2_image0.png)

### **匯入 Excel 圖表範例**

本例將從前述範例所使用的 Excel 活頁簿的第一個工作表匯入圖表。圖表會在最終簡報中連結至外部活頁簿。

首先，我們在 Excel 活頁簿中根據員工表格加入一個圓餅圖。

![Excel 圖表範例](example3_image0.png)

```cpp
// 建立新的 PowerPoint 簡報。
auto presentation = MakeObject<Presentation>();

// 取得第一張投影片的形狀集合。
auto shapes = presentation->get_Slide(0)->get_Shapes();

// 從活頁簿的第一個工作表匯入名為「Chart 1」的圖表，並將其新增至形狀集合。
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// 將產生的簡報儲存至檔案。
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![結果](example3_image1.png)

### **匯入所有 Excel 圖表範例**

想像您有一本充滿圖表的 Excel 活頁簿，且需要將所有圖表匯入至簡報。每個圖表應放置於一張新的投影片上。

以下程式碼會遍歷來源 Excel 檔案的所有工作表，從每個工作表擷取圖表，並使用空白投影片版面將每個圖表加入至單獨的投影片。最終簡報中僅會嵌入圖表資料，而不會包含整本活頁簿。

```cpp
// 載入包含員工資料的 Excel 活頁簿。
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// 建立新的 PowerPoint 簡報。
auto presentation = MakeObject<Presentation>();

// 取得空白投影片版面。
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// 取得 Excel 活頁簿中所有工作表的名稱。
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // 取得將圖表索引對映至圖表名稱的字典（針對此工作表）。
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // 使用空白版面新增投影片。
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // 從 Excel 活頁簿匯入指定圖表至投影片的形狀集合。
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// 將產生的簡報儲存至檔案。
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **總結**

此機制直接內建於 Aspose.Slides，將 Excel 資料與簡報的操作合併於同一處。它讓您能在不需額外函式庫或複雜整合的前提下，建立含有視覺化圖表與 Excel 表格資料的投影片。