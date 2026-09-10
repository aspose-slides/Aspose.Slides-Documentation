---
title: 在 Python 中自訂 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 圖表
- Sunburst 圖表
- 階層圖表
- 資料點
- 資料標籤
- 分支顏色
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 建立階層資料，並自訂 Treemap 與 Sunburst 圖表的層級、標籤與顏色。"
---
## **概述**

Treemap 和 Sunburst 圖表顯示相同類型的階層資料，但它們使用不同的版面配置。Treemap 以嵌套矩形呈現階層，矩形面積代表葉節點的數值。Sunburst 則以同心環呈現：最高層級的群組位於中心附近，葉節點類別則在外圍環上。

在 Aspose.Slides for Python via Java 中，每個數值都是一個 [ChartDataPoint](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/)。其 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) 方法提供對葉節點及其父群組的存取。本篇文章說明此對應關係，並示範如何使用相同的樣本資料建立與格式化兩種圖表類型。

![顯示 Consumer 和 Business 分支的 Treemap 圖表](treemap-hierarchy.png)

![顯示相同 Consumer 和 Business 階層的 Sunburst 圖表](sunburst-hierarchy.png)

## **了解類別、資料點與層級**

以下範例使用了三個類別層級和一個數值系列：

| 分支 | 主幹 | 葉節點 | 收入 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每一列會建立一個葉節點類別和一個資料點。類別分組層級描述了從該葉節點到其父層的路徑。對於第一列，路徑為 `Consumer > Computers > Laptops`。

[ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) 回傳的索引由葉節點向上遞增：

| `getDataPointLevels()` 索引 | 邏輯層級 | Treemap 表示 | Sunburst 表示 |
| ---: | --- | --- | --- |
| `0` | 葉節點 | 值矩形 | 外環段 |
| `1` | 主幹 | 父矩形或標題 | 中環段 |
| `2` | 分支 | 頂層矩形或標題 | 內環段 |

此順序對兩種圖表皆相同，即使它們的視覺版面不同。父層段落會被多個葉節點共用。若要格式化它，請使用該群組中第一個資料點的相應層級。例如，`Consumer` 分支以 `Laptops` 點開始，而 `Software` 主幹則以 `Licenses` 點開始。保留對這些點的參考比使用未說明的表達式如 `data_points.get_Item(0)` 或 `data_points.get_Item(6)` 更清晰且安全。

## **建立與自訂兩種圖表**

以下完整範例在第一張投影片建立 Treemap，於第二張投影片建立 Sunburst。它建立階層、顯示 `Tablets` 的數值、對選取層級套用固定顏色、格式化分支標籤，並儲存簡報。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # 新增葉節點類別。僅在新群組開始時設定分組項目；
        # 隨後的類別會保留在該群組中，直至設定其他項目。

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # 在 Tablets 葉節點上顯示類別與值。
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # 透過該分支的第一個葉節點格式化 Consumer 分支。
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # 透過該主幹的第一個葉節點格式化 Software 主幹。
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout 會影響 Treemap 的父標籤；Sunburst 使用環段。
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

類別儲存格與數值儲存格使用相同的工作表列，因此它們的集合位置保持對齊。當您操作既有圖表而非建立新圖表時，請先檢查類別列，並將欲格式化的資料點與層級儲存為具名參考。

## **行為與實務考量**

### **Treemap 與 Sunburst 的差異**

- Treemap 以面積傳達數值，以嵌套矩形傳達階層。此圖表類型中，使用 [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#setParentLabelLayout) 方法控制父標籤的顯示方式。
- Sunburst 以角度傳達數值，以環深度傳達階層。 [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartseries/#setParentLabelLayout) 不會控制其環標籤。
- 兩種圖表皆使用相同的類別分組層級與由 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) 回傳的葉節點至父層順序，故資料建構與層級格式化程式碼可共用。
- 父層的數值由其下屬葉節點計算得出。不要為分支或主幹額外新增數值點。

### **排序與區段順序**

圖表版面引擎決定矩形與環段的最終位置。請在加入資料前先將相關類別列排在一起，但不要依賴特定的矩形位置或起始角度。若順序本身具意義，請將其寫入標籤或使用具明確類別軸的圖表類型。

### **佈景主題與固定色彩**

未格式化的圖表層級會繼承簡報佈景主題的顏色。範例使用明確的 RGB 填色以獲得可預測的輸出。若圖表需隨佈景主題變化，請改用配色方案色彩而非固定 RGB，且避免覆寫每個層級。變更分支或主幹填色後，也請檢查標籤對比度。

### **標籤與可用空間**

當段落過小時，PowerPoint 可能會隱藏或截斷標籤。增大圖表尺寸、縮短類別名稱或減少顯示的標籤欄位通常能產生更清晰的結果。標籤可透過 [DataLabelFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/) 結合類別名稱、系列名稱與數值，但啟用所有欄位往往會使階層圖表難以閱讀。

### **匯出與渲染**

儲存為 PPTX 可保留圖表的可編輯性。當 Aspose.Slides 將簡報渲染為 PDF 或影像時，支援的填色與標籤設定會一併呈現。字型替換與可用版面空間的微小差異可能改變換行或標籤可見性，請安裝所需字型並驗證重要的匯出目標。

## **常見問題**

**為什麼變更父層級會影響多個葉節點？**  
分支或主幹是共用的視覺段落。其 [ChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/chartdatapointlevel/) 可透過任一後代葉節點取得，但格式化屬於共享的父段落，而非僅屬於該葉節點。

**為什麼資料標籤消失了？**  
首先在標籤的 [DataLabelFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/datalabelformat/) 物件上啟用所需欄位。然後檢查該段落是否有足夠空間。Treemap 的父標籤版面、圖表尺寸、標籤長度、字型大小以及啟用的欄位數量都會影響標籤是否能顯示。

**我可以設定區段的確切順序或座標嗎？**  
您可以控制來源列的順序並確保每個群組連續，但無法指定 Treemap 矩形或 Sunburst 角度的精確座標。圖表版面引擎會根據階層、數值與可用空間自行計算。

**為什麼在變更簡報佈景主題後顏色會改變？**  
基於佈景主題的填色設計會隨簡報調色板變化。對必須固定的層級套用明確的 RGB 顏色，或在需要隨新佈景主題調整時保留配色方案色彩。

**自訂格式在 PDF 和影像匯出時會保留嗎？**  
會，支援的圖表填色與標籤設定會在渲染時一併納入。為確保跨系統結果一致，請提供必要的字型，並測試最終匯出尺寸，因為標籤適配受版面配置影響。

## **另見**

- [建立 Treemap 圖表](/slides/zh-hant/python-java/create-chart/#create-tree-map-charts)
- [建立 Sunburst 圖表](/slides/zh-hant/python-java/create-chart/#create-sunburst-charts)
- [匯出簡報圖表](/slides/zh-hant/python-java/export-chart/)
- [管理簡報佈景主題](/slides/zh-hant/python-java/presentation-theme/)