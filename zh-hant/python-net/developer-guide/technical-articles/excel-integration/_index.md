---
title: 將 Excel 資料整合至 PowerPoint 簡報
linktitle: Excel 整合
type: docs
weight: 330
url: /zh-hant/python-net/excel-integration/
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
- Python
- Aspose.Slides
description: "在 Aspose.Slides 中使用 ExcelDataWorkbook API 讀取 Excel 活頁簿的資料。載入工作表與儲存格，並使用其值產生資料驅動的 PowerPoint 簡報。"
---
## **簡介**

PowerPoint 簡報是展示與傳達資訊的強大方式。它們常與 Excel 活頁簿結合使用，Excel 作為結構化資料的優秀來源，而 PowerPoint 則善於為觀眾視覺化這些資料。

在許多實務情境中，結合 Excel 和 PowerPoint 是必需的：郵件合併、填充資料表、為每筆資料紀錄產生一張投影片（批次投影片產生）、製作訓練教材，以及將多個 Excel 報告合併成單一簡報等，僅列舉幾例。

直到目前，使用 Aspose.Slides API 實作此類功能仍須依賴像 Aspose.Cells 等第三方解決方案。雖然這些工具功能強大，但對僅需要基本資料整合功能的使用者而言，可能過於複雜且成本高昂。

## **運作方式**

為了讓 Excel 資料的使用更簡易、更流暢，Aspose.Slides 引入了用於從 Excel 活頁簿讀取資料並匯入內容至簡報的新類別。此功能為想在簡報工作流程中以 Excel 作為資料來源的 API 使用者開啟了強大的新可能性。

此新功能設計為一般用途的資料存取，並未整合至簡報文件物件模型（DOM）。這表示 *它不允許編輯或儲存 Excel 檔案*——其唯一目的在於開啟活頁簿並瀏覽其內容，以取得儲存格資料。

此功能的核心是全新的 [ExcelDataWorkbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.excel/exceldataworkbook/) 類別。此類別允許您從本機檔案或串流載入 Excel 活頁簿。載入後，它提供多個 [get_cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) 方法的重載，您可依照儲存格位置（例如列與欄索引或命名範圍）取得特定儲存格。

每次呼叫 [get_cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.excel/exceldataworkbook/get_cell/) 都會回傳 [ExcelDataCell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.excel/exceldatacell/) 類別的實例。此物件代表 Excel 活頁簿中的單一儲存格，並以簡單直觀的方式提供其值的存取。

#### **匯入 Excel 圖表**

接下來的擴充步驟是 [ExcelWorkbookImporter](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.importing/excelworkbookimporter/) 類別。此公用程式類別提供從 Excel 活頁簿匯入內容至簡報的功能。它包含多個 [add_chart_from_workbook](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.importing/excelworkbookimporter/add_chart_from_workbook/) 方法的重載，協助您從指定的 Excel 活頁簿取得選取的圖表，並依指定坐標將其加入至給定形狀集合的末端。

簡而言之，這是一套輕量且直接的 API 用於讀取 Excel 資料——正是許多開發者在不需要完整試算表處理庫負擔時所需要的。

## **開始編寫程式**

### **郵件合併情境範例**

在以下範例中，我們將透過依據儲存在 Excel 活頁簿中的資料產生多份簡報，實作一個簡易的郵件合併情境。

要開始，我們需要兩樣東西：
1. 包含資料的 Excel 活頁簿

![Excel data example](example1_image0.png)

2. PowerPoint 簡報範本

![PowerPoint template example](example1_image1.png)

```py
import aspose.slides as slides

# 載入包含員工資料的 Excel 活頁簿。
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# 載入簡報範本。
with slides.Presentation("PresentationTemplate.pptx") as template_presentation:

    # 迭代 Excel 列（排除第 0 列的標頭）。
    for row_index in range(1, 5):

        # 為每筆員工記錄建立新簡報。
        with slides.Presentation() as employee_presentation:

            # 移除預設的空白投影片。
            employee_presentation.slides.remove_at(0)

            # 將範本投影片克隆到新簡報中。
            slide = employee_presentation.slides.add_clone(template_presentation.slides[0])

            # 從目標圖形取得段落（假設使用圖形索引 1）。
            paragraphs = slide.shapes[1].text_frame.paragraphs

            # 用 Excel 資料取代佔位符。
            employee_name = workbook.get_cell(worksheet_index, row_index, 0).value
            name_portion = paragraphs[0].portions[0]
            name_portion.text = name_portion.text.replace("{{EmployeeName}}", employee_name)

            department = workbook.get_cell(worksheet_index, row_index, 1).value
            department_portion = paragraphs[1].portions[0]
            department_portion.text = department_portion.text.replace("{{Department}}", department)

            years_of_service = str(workbook.get_cell(worksheet_index, row_index, 2).value)
            years_portion = paragraphs[2].portions[0]
            years_portion.text = years_portion.text.replace("{{YearsOfService}}", years_of_service)

            # 將個人化簡報儲存為獨立檔案。
            employee_presentation.save(f"{employee_name} Report.pptx", slides.export.SaveFormat.PPTX)
```

![結果](example1_image2.png)

### **Excel 表格範例**

在第二個範例中，我們僅將 Excel 表格中的資料複製，並以更具視覺吸引力的方式顯示於 PowerPoint 投影片上。

此範例中，我們重複使用第一個範例的相同 Excel 活頁簿，其中包含一個簡易的員工表格。

```py
# 載入包含員工資料的 Excel 活頁簿。
workbook = slides.excel.ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# 建立新的 PowerPoint 簡報。
with slides.Presentation() as presentation:

    # 在第一張投影片加入表格圖形。
    table = presentation.slides[0].shapes.add_table(
        50, 200,
        [200, 200, 200],
        [30, 30, 30, 30, 30]
    )

    # 使用 Excel 活頁簿的資料填充 PowerPoint 表格。
    for row_index in range(0, 5):
        for column_index in range(0, 3):
            cell_value = str(workbook.get_cell(worksheet_index, row_index, column_index).value)
            table.columns[column_index][row_index].text_frame.text = cell_value

    # 將產生的簡報儲存為檔案。
    presentation.save("Table.pptx", slides.export.SaveFormat.PPTX)
```

![結果](example2_image0.png)

### **匯入 Excel 圖表範例**

在此範例中，我們從先前範例使用的 Excel 活頁簿的第一個工作表匯入圖表。該圖表在最終簡報中將會連結至外部活頁簿。

首先，我們根據員工表格在 Excel 活頁簿中新增一個圓餅圖。

![Excel Chart example](example3_image0.png)

```py
# 建立新的 PowerPoint 簡報。
with slides.Presentation() as presentation:
    # 取得第一張投影片的圖形集合。
    shapes = presentation.slides[0].shapes

    # 從活頁簿的第一個工作表匯入名稱為 "Chart 1" 的圖表，並將其加入圖形集合。
    slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
        shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # 將產生的簡報儲存為檔案。
    presentation.save("Chart.pptx", slides.export.SaveFormat.PPTX)
```

![結果](example3_image1.png)

### **匯入全部 Excel 圖表範例**

假設您有一本充滿圖表的 Excel 活頁簿，需要將所有圖表匯入至簡報中。每個圖表應放置於新的一張投影片上。

以下程式碼會遍歷來源 Excel 檔案的所有工作表，從每個工作表擷取圖表，並使用空白投影片版面將每個圖表加入至各自的投影片。於最終簡報中，僅會嵌入圖表資料，並不會包含整本活頁簿。

```py
# 載入包含員工資料的 Excel 活頁簿。
workbook = slides.excel.ExcelDataWorkbook("ExcelWithCharts.xlsx")

# 建立新的 PowerPoint 簡報。
with slides.Presentation() as presentation:
    # 取得空白投影片版面配置。
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # 取得 Excel 活頁簿中所有工作表的名稱。
    worksheet_names = workbook.get_worksheet_names()

    for name in worksheet_names:
        # 取得將圖表索引對映至圖表名稱的字典（針對該工作表）。
        worksheet_charts = workbook.get_charts_from_worksheet(name)
        
        for chart in worksheet_charts:
            # 使用空白版面新增投影片。
            slide = presentation.slides.add_empty_slide(blank_layout)

            # 從 Excel 活頁簿匯入指定圖表至投影片的圖形集合。
            slides.importing.ExcelWorkbookImporter.add_chart_from_workbook(
                slide.shapes, 10, 10, workbook, name, chart.key, False)

    # 將產生的簡報儲存為檔案。
    presentation.save("Charts.pptx", slides.export.SaveFormat.PPTX)
```

## **總結**

此機制直接內建於 Aspose.Slides，將 Excel 資料與簡報的操作合二為一。它讓您能在不需其他函式庫或複雜整合的情況下，建立包含視覺化圖表與以 Excel 表格呈現資料的投影片。