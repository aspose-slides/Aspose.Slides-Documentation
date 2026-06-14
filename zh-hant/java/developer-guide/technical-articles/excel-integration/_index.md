---
title: 将 Excel 数据整合至 PowerPoint 简报
linktitle: Excel 整合
type: docs
weight: 330
url: /zh-hant/java/excel-integration/
keywords:
- Excel
- 活页簿
- 读取 Excel
- 整合 Excel
- 数据来源
- 合并列印
- 导入表格
- Excel 转 PowerPoint
- PowerPoint
- 简报
- Java
- Aspose.Slides
description: "在 Aspose.Slides 中使用 ExcelDataWorkbook API 读取 Excel 活页簿数据。加载工作表和单元格，并利用其值生成以数据驱动的 PowerPoint 简报。"
---
## **簡介**

PowerPoint 簡報是一種強大的資訊展示與傳達方式。它常與 Excel 活頁簿結合使用，Excel 提供結構化資料來源，而 PowerPoint 則擅長將這些資料視覺化呈現給觀眾。

在許多實務情境中，結合 Excel 與 PowerPoint 是必需的：郵件合併、填充資料表、為每筆資料記錄產生一張投影片（批次投影片產生）、製作教學教材，以及將多個 Excel 報表彙整成一份簡報等。

過去，要使用 Aspose.Slides API 實作此類功能必須依賴第三方解決方案，例如 Aspose.Cells。雖然這些工具功能完整，但對於僅需基本資料整合功能的使用者而言，可能過於複雜且成本高昂。

## **運作方式**

為了讓 Excel 資料的使用更簡單、流程更順暢，Aspose.Slides 引入了用於讀取 Excel 活頁簿並將內容匯入簡報的新類別。此功能為希望在簡報工作流程中以 Excel 作為資料來源的 API 使用者開啟了全新可能性。

新功能屬於一般用途的資料存取，並未整合至簡報文件物件模型（DOM）中。也就是說*它不允許編輯或儲存 Excel 檔案*——它的唯一目的在於開啟活頁簿並導覽其內容以取得儲存格資料。

此功能的核心是全新的 [ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/exceldataworkbook/) 類別。該類別允許從本機檔案或串流載入 Excel 活頁簿。載入後，提供多個 [getCell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) 方法的重載，您可以藉由位置（例如列與欄索引或命名範圍）取得特定儲存格。

每次呼叫 [getCell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) 都會回傳一個 [ExcelDataCell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/exceldatacell/) 例項。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直觀的方式提供其值存取。

#### **匯入 Excel 圖表**

接下來的擴充功能是 [ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/excelworkbookimporter/) 類別。此實用程式類別提供將 Excel 活頁簿內容匯入簡報的功能。它包含多個 [addChartFromWorkbook](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) 方法的重載，可協助您從指定的 Excel 活頁簿中取得選取的圖表，並依給定座標將其加入指定形狀集合的末端。

簡言之，這是一套輕量且直接的 API，用於讀取 Excel 資料——正是許多開發者在不需要完整試算表處理函式庫時所需要的功能。

## **讓我們寫程式**

### **合併列印情境範例**

在下列範例中，我們將實作一個簡單的合併列印情境，根據儲存在 Excel 活頁簿中的資料產生多份簡報。

開始之前，我們需要兩樣東西：
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
    // 迴圈處理 Excel 行（排除第 0 列的標題）。
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // 為每筆員工記錄建立新的簡報。
        Presentation employeePresentation = new Presentation();

        try {
            // 移除預設的空白投影片。
            employeePresentation.getSlides().removeAt(0);

            // 將範本投影片克隆至新簡報中。
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // 從目標形狀取得段落（假設使用形狀索引 1）。
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // 以 Excel 資料取代佔位符。
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // 將個人化簡報儲存為單獨檔案。
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

在第二個範例中，我們直接從 Excel 表格複製資料，並以更具視覺吸引力的方式顯示於 PowerPoint 投影片上。

此範例再次使用第一個範例的相同 Excel 活頁簿，該活頁簿包含一個簡易的員工表格。

```java
// 載入包含員工資料的 Excel 活頁簿。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 建立新的 PowerPoint 簡報。
Presentation presentation = new Presentation();

try {
    // 在第一張投影片新增表格形狀。
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // 使用 Excel 活頁簿的資料填滿 PowerPoint 表格。
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // 將產生的簡報儲存為檔案。
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![結果](example2_image0.png)

### **匯入 Excel 圖表範例**

此範例示範從前述範例所使用的 Excel 活頁簿第一個工作表匯入圖表。圖表將在最終的簡報中連結至外部活頁簿。

首先，我們在 Excel 活頁簿中依據員工表格加入一個圓形圖（Pie chart）。

![Excel 圖表範例](example3_image0.png)

```java
// 建立新的 PowerPoint 簡報。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片的形狀集合。
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // 從活頁簿第一張工作表匯入名稱為 "Chart 1" 的圖表，並將其加入形狀集合。
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // 將產生的簡報儲存為檔案。
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![結果](example3_image1.png)

### **匯入全部 Excel 圖表範例**

假設您擁有一個充滿圖表的 Excel 活頁簿，且需要將所有圖表匯入簡報，每個圖表都放在新的一張投影片上。

以下程式碼會遍歷來源 Excel 檔案的所有工作表，從每個工作表中擷取圖表，並使用空白投影片版面將每張圖表加入各自的投影片。最終的簡報僅嵌入圖表資料，並不會包含整個活頁簿。

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
        // 取得對應圖表索引與圖表名稱的映射表（針對該工作表）。
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // 使用空白版面新增投影片。
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // 從 Excel 活頁簿匯入指定圖表至投影片的形狀集合。
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // 將產生的簡報儲存為檔案。
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **總結**

此機制直接內建於 Aspose.Slides，將 Excel 資料與簡報的操作結合於同一環境。透過它，您可以在簡報中建立含視覺圖表與 Excel 表格形式資料的投影片，且不需額外的函式庫或複雜整合。