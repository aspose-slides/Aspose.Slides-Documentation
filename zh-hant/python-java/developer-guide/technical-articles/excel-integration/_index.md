---
title: 將 Excel 資料整合至 PowerPoint 簡報
linktitle: Excel 整合
type: docs
weight: 330
url: /zh-hant/python-java/excel-integration/
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
- Python
- Java
- Aspose.Slides
description: "使用 ExcelDataWorkbook API，於 Aspose.Slides for Python via Java 中讀取 Excel 活頁簿資料。載入工作表與儲存格，並使用其值產生資料驅動的 PowerPoint 簡報。"
---
## **簡介**

PowerPoint 簡報是展示與傳達資訊的強大工具。它們常與 Excel 活頁簿結合使用，Excel 提供結構化資料的絕佳來源，而 PowerPoint 則擅長將這些資料以視覺化方式呈現給觀眾。

在許多實務情境中，結合 Excel 與 PowerPoint 是必須的：郵件合併、填充資料表格、為每筆資料記錄產生一張投影片（批次投影片產生）、製作訓練教材，以及將多份 Excel 報告彙總成一個簡報等。

過去，使用 Aspose.Slides API 實作此類功能需要依賴第三方解決方案，例如 Aspose.Cells。雖然這些工具功能完整，但對於僅需基本資料整合功能的使用者而言，往往過於複雜且成本偏高。

## **運作方式**

為了讓使用 Excel 資料變得更簡易、更順暢，Aspose.Slides 引入了用於從 Excel 活頁簿讀取資料並匯入簡報內容的新類別。此功能為希望在簡報工作流程中以 Excel 作為資料來源的 API 使用者開啟了全新可能性。

新功能設計為一般用途的資料存取，並未整合至簡報文件物件模型（DOM）中。也就是說，*它不支援編輯或儲存 Excel 檔案*——唯一目的在於開啟活頁簿並瀏覽其內容以取得儲存格資料。

此功能的核心是全新的 [ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/exceldataworkbook/) 類別。該類別允許您從本機檔案或串流載入 Excel 活頁簿。載入後，它提供多個 [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/exceldataworkbook/#getCell) 方法的重載，您可以依儲存格位置（例如列與欄索引或命名範圍）取得特定儲存格。

每次呼叫 [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/exceldataworkbook/#getCell) 都會回傳一個 [ExcelDataCell](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/exceldatacell/) 物件。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直觀的方式提供其值的存取。

#### **匯入 Excel 圖表**

接下來的擴充功能是 [ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/excelworkbookimporter/) 類別。此實用程式類別提供將 Excel 活頁簿內容匯入簡報的功能。它包含多個 [ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) 方法的重載，協助您從指定的 Excel 活頁簿取得選取的圖表，並依指定座標將其加入至給定圖形集合的末端。

#### **匯入 Excel 表格**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/excelworkbookimporter/) 類別同樣包含多個 [ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) 方法的重載。這些方法允許您從指定工作表的特定儲存格範圍匯入資料，並依指定座標將其作為表格加入至給定圖形集合的末端。

簡言之，這是一套輕量且直觀的 API，用於讀取 Excel 資料——正是許多開發人員在不想引入完整試算表處理函式庫時所需要的。

## **讓我們編寫程式碼**

### **郵件合併情境範例**

以下範例示範如何透過 Excel 活頁簿中的資料，產生多個簡報以實作簡易的郵件合併情境。

開始前，我們需要兩樣東西：

1. 含有資料的 Excel 活頁簿  

   ![Excel data example](example1_image0.png)

2. PowerPoint 簡報範本  

   ![PowerPoint template example](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# 載入含有員工資料的 Excel 活頁簿。
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# 載入簡報範本。
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # 迴圈處理 Excel 列 (排除第 0 列的標題)。
    for row_index in range(1, 5):

        # 為每筆員工紀錄建立簡報。
        employee_presentation = Presentation()

        try:
            # 移除預設的空白投影片。
            employee_presentation.getSlides().removeAt(0)

            # 將範本投影片複製到簡報中。
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # 從目標圖形取得段落 (假設使用圖形索引 1)。
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # 用 Excel 資料取代佔位字串。
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # 將個人化簡報儲存為個別檔案。
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![Result](example1_image2.png)

### **Excel 表格範例**

在第二個範例中，我們直接將 Excel 表格資料複製並以更具視覺吸引力的方式顯示於 PowerPoint 投影片上。

此範例重複使用第一個範例的 Excel 活頁簿，該活頁簿含有一個簡易的員工表格。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# 載入包含員工資料的 Excel 活頁簿。
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# 建立 PowerPoint 簡報。
presentation = Presentation()

try:
    # 在第一張投影片加入表格圖形。
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # 使用 Excel 活頁簿的資料填充 PowerPoint 表格。
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # 将產生的簡報儲存為檔案。
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example2_image0.png)

### **匯入 Excel 圖表範例**

此範例示範如何從先前範例使用的 Excel 活頁簿的第一張工作表匯入圖表，且圖表在最終簡報中會連結至外部活頁簿。

首先，我們在 Excel 活頁簿中依員工表格新增一個圓餅圖。

![Excel Chart example](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# 建立 PowerPoint 簡報。
presentation = Presentation()
try:
    # 取得第一張投影片的圖形集合。
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # 從活頁簿的第一張工作表匯入名為 "Chart 1" 的圖表，並將其加入圖形集合。
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # 將產生的簡報儲存為檔案。
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example3_image1.png)

### **匯入全部 Excel 圖表範例**

假設您手上有一個充滿圖表的 Excel 活頁簿，且需要將所有圖表匯入簡報；每個圖表都放在一張新投影片上。

以下程式碼會遍歷來源 Excel 檔案的全部工作表，從每個工作表提取圖表，並使用空白投影片版面將每個圖表加入獨立的投影片。於最終簡報中只會嵌入圖表資料，而不會嵌入整個活頁簿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# 載入包含員工資料的 Excel 活頁簿。
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# 建立 PowerPoint 簡報。
presentation = Presentation()
try:
    # 取得空白投影片版面。
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # 移除預設投影片，以使結果每個圖表產生一張投影片。
    presentation.getSlides().removeAt(0)

    # 取得 Excel 活頁簿中所有工作表的名稱。
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # 取得工作表的圖表索引與圖表名稱對應的映射表。
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # 使用空白版面新增投影片。
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # 從 Excel 活頁簿匯入指定圖表至投影片的圖形集合。
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # 將產生的簡報儲存為檔案。
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **匯入 Excel 表格範例**

此範例示範直接從 Excel 工作表匯入已格式化的表格至 PowerPoint 簡報。

來源 Excel 工作表包含一個已格式化的員工資料表格：

![Excel Table example](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# 建立 PowerPoint 簡報。
presentation = Presentation()
try:
    # 取得第一張投影片及其圖形集合。
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # 從活頁簿的第一張工作表匯入表格並加入圖形集合。
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # 將產生的簡報儲存為檔案。
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Result](example4_image1.png)

## **總結**

此機制直接內建於 Aspose.Slides，讓您在同一個環境中同時處理 Excel 資料與簡報。它使您能在不需額外函式庫或複雜整合的情況下，建立包含視覺化圖表與 Excel 表格資料的投影片。