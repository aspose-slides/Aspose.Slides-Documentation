---
title: "在 Python 中自動化 PowerPoint 產生：輕鬆建立動態簡報"
linktitle: 在 Python 中自動化 PowerPoint 產生
type: docs
weight: 20
url: /zh-hant/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- 雲端平台
- 雲端整合
- 自動化 PowerPoint 產生
- 程式化產生簡報
- PowerPoint 自動化
- 動態投影片建立
- 自動化商業報告
- PPT 自動化
- Python 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 自動化 PowerPoint 產生：在雲端應用程式中建立含圖表、表格與項目符號的商業簡報。"
---
## **簡介**

當內容頻繁變更時，手動建立簡報會變得重複且乏味。每週報告、訓練教材與客戶簡報通常具有相同的結構，但每次交付都需要新的資料。

Aspose.Slides for Python via Java 可讓您從 Python 應用程式產生這些簡報。您可以將投影片生成整合到 Web 入口網站、排程工作與雲端工作者，使用來自資料庫、API 或上傳檔案的資料。

## **在 Python 中使用 PowerPoint 自動化的常見案例**

- **商業報告與儀表板：** 將銷售數字與績效指標轉換為圖表與表格。  
- **個人化銷售簡報：** 在保持一致設計的同時，使用客戶特定資料填充投影片。  
- **教育內容：** 從結構化資料組合課程、測驗與課程摘要。  
- **資料與 AI 驅動的洞見：** 使用分析或語言處理服務的結果作為簡報內容。  
- **媒體型投影片：** 結合上傳的圖片或螢幕截圖與說明文字。  
- **文件工作流程：** 將其他工具提取的內容映射到簡報版面。  
- **開發者工具：** 從專案資料產生發行摘要、技術概覽或示範。

## **先決條件**

請依照[安裝](/slides/zh-hant/python-java/installation/)設定 Python、Java、JPype 與 Aspose.Slides。若為雲端部署，亦請參閱[雲端平台上的 Slides](/slides/zh-hant/python-java/slides-on-cloud-platforms/)。

此範例使用固定的商業資料，無需資料庫或外部服務即可執行。將這些值替換為您應用程式的資料，以便整合至報告工作流程中。

{{% alert color="info" title="注意" %}}
您可以在未取得授權的情況下試用此範例，但評估輸出會包含浮水印，且受評估限制。詳情與臨時授權資訊請參閱[評估 Aspose.Slides](/slides/zh-hant/python-java/evaluate-aspose-slides/)。
{{% /alert %}}

## **建立簡報**

以下完整腳本會建立包含四張投影片的單一簡報。每個步驟皆使用同一個簡報，最後一步將其儲存為 `presentation.pptx`。

### **建立標題投影片**

使用新[簡報]https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/ 的第一張投影片，並套用標題版面配置。將其標題與副標題占位符填入報告標題與受眾資訊。

![標題投影片](slide_0.png)

### **新增含柱狀圖的投影片**

新增一張空白投影片，並使用[ShapeCollection.addChart]https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addChart建立圖表。於其內嵌工作簿中填入五個區域與一個銷售系列。這些數值在 PowerPoint 中仍可編輯。

![含圖表的投影片](slide_1.png)

### **新增含表格的投影片**

使用[ShapeCollection.addTable]https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addTable建立表格，並在兩欄中填入指標名稱與數值。此範例透過 JPype 以顯式的 Java double 陣列傳遞欄寬與列高。

![含表格的投影片](slide_2.png)

### **新增摘要投影片與項目符號**

建立文字形狀，並為每個待辦項目新增[Paragraph]https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/paragraph/。對每段落套用符號項目符號與黑色文字，並移除形狀的填滿與輪廓。

![含摘要的投影片](slide_3.png)

### **儲存簡報**

使用[Presentation.save]https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save寫入 PowerPoint 檔案。在 `finally` 區塊中以[Presentation.dispose]https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#dispose釋放簡報。

### **完整 Python 範例**

將此腳本儲存於可寫入的目錄，並以先前設定的 Python 環境執行。僅在必要時啟動 JVM，且在行程結束前維持其可用。若用於 Notebook 或服務，請參閱[JVM 生命周期指南](/slides/zh-hant/python-java/limitations-and-api-differences/#import-the-library)。

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
        # 建立標題投影片。
        title_slide = presentation.getSlides().get_Item(0)
        title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
        title_slide.setLayoutSlide(title_layout)
        title_shape = title_slide.getShapes().get_Item(0)
        subtitle_shape = title_slide.getShapes().get_Item(1)
        title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
        subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

        # 新增圖表投影片。
        blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
        chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
        chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
        chart.getLegend().setPosition(LegendPositionType.Bottom)
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
        chart.getChartTitle().setOverlay(False)

        workbook = chart.getChartData().getChartDataWorkbook()
        worksheet_index = 0
        sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
        for row_index, (region, amount) in enumerate(sales, start=1):
            category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
            chart.getChartData().getCategories().add(category_cell)

        series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for row_index, (region, amount) in enumerate(sales, start=1):
            value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        # 新增表格投影片。
        table_slide = presentation.getSlides().addEmptySlide(blank_layout)
        column_widths = JArray(JDouble)([200, 100])
        row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
        table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
        metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
        for row_index, (metric, value) in enumerate(metrics):
            table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
            table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

        # 新增摘要投影片。
        summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
        bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
        bullet_list.getFillFormat().setFillType(FillType.NoFill)
        bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        paragraphs = bullet_list.getTextFrame().getParagraphs()
        paragraphs.clear()
        action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
        for text in action_items:
            paragraph = create_bullet_paragraph(text)
            paragraphs.add(paragraph)

        presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

圖示顯示 Java 範例中對應的投影片。外觀可能因安裝的字型與評估模式而異。

## **在雲端應用程式中使用範例**

在建立簡報前取得報告資料，然後將其傳遞至圖表、表格與文字產生步驟。為每個工作使用不同的輸出路徑。儲存後，您的應用程式可以將檔案上傳至物件儲存，或作為下載回傳。

在同一工作者程序內，於多個工作間保持 JVM 執行，並在工作完成時釋放相應的簡報。將報告設計所需的字型與部署一起打包，以減少環境間的差異。

## **結論**

此範例使用可編輯的圖表、表格與文字，從 Python 產生完整的商業簡報。將範例資料替換為應用程式資料，即可將相同方法套用於定期報告、客戶簡報與教育教材。

## **常見問題**

**此腳本是否需要 Microsoft PowerPoint 或 Excel？**

不需要。Aspose.Slides 會在未安裝任何應用程式的情況下建立投影片與圖表的內嵌工作簿。

**為何表格範例使用 Java 陣列？**

底層方法接受 Java double 陣列。使用顯式的陣列可清楚表達透過 JPype 傳遞的數值型別。

**我可以將相同的簡報另存為 PDF 或 ODP 嗎？**

可以。在釋放之前，以相對應的[SaveFormat]https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/值另存為其他輸出檔名。請參閱[支援的檔案格式](/slides/zh-hant/python-java/supported-file-formats/)了解各格式的功能。

**我可以使用品牌化的模板嗎？**

可以。載入您的模板取代建立空白簡報，然後依該模板調整版面配置與占位符的選取。此範例假設使用全新預設簡報的版面與占位符順序。