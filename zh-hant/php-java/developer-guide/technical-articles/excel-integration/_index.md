---
title: 將 Excel 資料整合至 PowerPoint 簡報
linktitle: Excel 整合
type: docs
weight: 330
url: /zh-hant/php-java/excel-integration/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 透過 Java 從 Excel 活頁簿讀取資料。載入工作表與儲存格，並利用其值產生以資料驅動的 PowerPoint 簡報。"
---
## **簡介**

PowerPoint 簡報是展示與傳達資訊的強大工具。它們常與 Excel 活頁簿一起使用，其中 Excel 作為結構化資料的極佳來源，而 PowerPoint 則擅長將這些資料可視化呈現給觀眾。

在許多實務情境中，結合 Excel 與 PowerPoint 是必須的：郵件合併、填入資料表、為每筆資料記錄產生一張投影片（批次投影片產生）、製作訓練教材，以及將多個 Excel 報表整合成單一簡報等。

截至目前，使用 Aspose.Slides API 實作這類功能必須依賴像 Aspose.Cells 之類的第三方方案。儘管這些工具功能強大，但對僅需基本資料整合功能的使用者而言，往往過於複雜且成本高昂。

## **運作方式**

為了讓使用 Excel 資料更簡便、更順暢，Aspose.Slides 引入了用於從 Excel 活頁簿讀取資料並將內容匯入簡報的新類別。此功能為希望在簡報工作流程中利用 Excel 作為資料來源的 API 使用者開啟了強大的新可能性。

新功能設計為一般用途的資料存取，未整合至簡報文件物件模型（DOM）。這表示*它不允許編輯或儲存 Excel 檔案*——其唯一目的在於開啟活頁簿並瀏覽其內容以取得儲存格資料。

此功能的核心是全新的 [ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/exceldataworkbook/) 類別。此類別允許您從本機檔案或串流載入 Excel 活頁簿。載入後，它提供多個 [getCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/exceldataworkbook/#getCell) 方法的重載，您可依位置（例如列與欄索引或命名範圍）取得特定儲存格。

每次呼叫 [getCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/exceldataworkbook/#getCell) 皆會返回 [ExcelDataCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/exceldatacell/) 類別的實例。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直觀的方式提供其值的存取。

#### **匯入 Excel 圖表**

下一步擴充功能是 [ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/excelworkbookimporter/) 類別。此工具類別提供從 Excel 活頁簿匯入內容至簡報的功能。它包含多個 [addChartFromWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) 方法的重載，協助您從指定的 Excel 活頁簿取得選取的圖表，並依指定座標將其加入給定圖形集合的末端。

簡而言之，這是一個輕量且直接的 Excel 資料讀取 API——正是許多開發者所需，且不必承擔完整試算表處理函式庫的負擔。

## **開始編寫程式**

### **郵件合併情境示例**

以下範例將示範如何透過儲存在 Excel 活頁簿中的資料，產生多個簡報以實作簡易的郵件合併情境。

要開始，我們需要兩樣東西：
1. 包含資料的 Excel 活頁簿

![Excel 資料範例](example1_image0.png)

2. PowerPoint 簡報範本

![PowerPoint 範本範例](example1_image1.png)

```php
// 載入包含員工資料的 Excel 活頁簿。
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// 載入簡報範本。
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // 迭代 Excel 列（排除第 0 列的標題）。
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // 為每筆員工記錄建立新簡報。
        $employeePresentation = new Presentation();

        try {
            // 移除預設的空白投影片。
            $employeePresentation->getSlides()->removeAt(0);

            // 將範本投影片複製到新簡報中。
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // 從目標形狀取得段落（假設使用形狀索引 1）。
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // 用 Excel 資料取代佔位符。
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // 將個人化簡報儲存為單獨檔案。
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![結果](example1_image2.png)

### **Excel 表格範例**

在第二個範例中，我們僅將 Excel 表格中的資料複製，並以更具視覺吸引力的方式在 PowerPoint 投影片上顯示。

本範例重複使用第一個範例中的相同 Excel 活頁簿，該活頁簿包含一個簡單的員工表格。

```php
// 載入包含員工資料的 Excel 活頁簿。
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// 建立新的 PowerPoint 簡報。
$presentation = new Presentation();

try {
    // 在第一張投影片上新增表格形狀。
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // 使用 Excel 活頁簿的資料填充 PowerPoint 表格。
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // 將產生的簡報儲存為檔案。
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![結果](example2_image0.png)

### **匯入 Excel 圖表範例**

在此範例中，我們從先前範例所使用的 Excel 活頁簿的第一工作表匯入圖表。該圖表在最終簡報中將連結至外部活頁簿。

首先，我們根據員工表格在 Excel 活頁簿中新增一個圓餅圖。

![Excel 圖表範例](example3_image0.png)

```php
// 建立新的 PowerPoint 簡報。
$presentation = new Presentation();
try {
    // 取得第一張投影片的形狀集合。
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // 從活頁簿的第一個工作表匯入名為「Chart 1」的圖表，並將其加入形狀集合。
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // 將產生的簡報儲存為檔案。
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![結果](example3_image1.png)

### **匯入所有 Excel 圖表範例**

假設您擁有包含大量圖表的 Excel 活頁簿，且需要將所有圖表匯入至簡報。每個圖表都應放置於新投影片上。

以下程式碼會遍歷來源 Excel 檔案的所有工作表，從每個工作表中擷取圖表，並使用空白投影片版面將每個圖表加入至個別投影片。於最終簡報中，僅會嵌入圖表資料，而不會嵌入整個活頁簿。

```php
// 載入包含員工資料的 Excel 活頁簿。
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 建立新的 PowerPoint 簡報。
$presentation = new Presentation();
try {
    // 取得空白投影片版面。
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // 取得 Excel 活頁簿中所有工作表的名稱。
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // 取得工作表的圖表索引與圖表名稱對映。
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // 使用空白版面新增投影片。
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // 將指定的圖表從 Excel 活頁簿匯入至投影片的形狀集合。
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // 將產生的簡報儲存為檔案。
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **摘要**

此機制直接內建於 Aspose.Slides，可在同一位置同時處理 Excel 資料與簡報。它讓您能建立包含視覺圖表及以 Excel 表格形式呈現資料的投影片──無需額外函式庫或複雜整合。