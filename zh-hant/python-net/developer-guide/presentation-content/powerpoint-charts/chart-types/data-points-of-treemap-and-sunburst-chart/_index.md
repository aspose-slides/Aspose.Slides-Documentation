---
title: 在 Python 中自訂 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/python-net/data-points-of-treemap-and-sunburst-chart/
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
- Aspose.Slides
description: "瞭解如何使用 Aspose.Slides for Python via .NET 建立階層資料，並自訂 Treemap 與 Sunburst 圖表的層級、標籤與顏色。"
---
## **概觀**

Treemap 與 Sunburst 圖表顯示相同類型的階層資料，但它們使用不同的版面配置。Treemap 以嵌套矩形呈現階層，矩形面積代表葉節點的數值。Sunburst 則以同心環呈現：最高層級的群組位於中心附近，葉節點類別則在最外環。

在 Aspose.Slides for Python via .NET 中，每個數值都是一個[ChartDataPoint](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/)。其[ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/)集合提供對葉節點及其父層群組的存取。本篇說明此對應關係，並示範如何使用相同的樣本資料建立與格式化兩種圖表類型。

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **了解類別、資料點與層級**

以下範例使用三個類別層級以及一個數值系列：

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

每一列會建立一個葉節點類別與一個資料點。類別群組層級描述從該葉節點到其父層的路徑。第一列的路徑為 `Consumer > Computers > Laptops`。

[ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) 的索引由葉節點向上遞增：

| `data_point_levels` 索引 | 邏輯層級 | Treemap 表示 | Sunburst 表示 |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

此順序在兩種圖表類型中相同，儘管它們的視覺版面不同。父層區段會被多個葉節點共用。若要格式化它，請使用該群組中第一個資料點的對應層級。例如，`Consumer` 分支從 `Laptops` 點開始，而 `Software` 主幹則從 `Licenses` 點開始。保留對這些點的參考比使用未說明的表達式如 `data_points[0]` 或 `data_points[6]` 更清晰且安全。

## **建立與自訂兩種圖表類型**

以下完整範例在第一張投影片上建立 Treemap，第二張投影片上建立 Sunburst。它會建構階層、顯示 `Tablets` 的數值、對選取的層級套用固定顏色、格式化分支標籤，並儲存簡報。

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # 新增葉節點類別。僅在開始新群組時設定分組項目；其後的類別會保持在該群組中，直到設定其他項目。
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # 在 Tablets 葉節點上顯示類別與值。
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # 透過該分支的第一個葉節點格式化 Consumer 分支。
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # 透過該主幹的第一個葉節點格式化 Software 主幹。
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout 會影響 Treemap 的父標籤；Sunburst 使用環段。
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

類別儲存格與數值儲存格使用相同的工作表列，因此它們的集合位置保持對齊。當您處理現有圖表而非建立新圖表時，請先檢查類別列，並儲存欲格式化的資料點與層級的具名參考。

## **行為與實務考量**

### **Treemap 與 Sunburst 差異**

- Treemap 使用面積傳達數值，使用嵌套矩形傳達階層。此圖表類型的[ChartSeries.parent_label_layout](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/parent_label_layout/)屬性控制父標籤的顯示方式。
- Sunburst 使用角度傳達數值，使用環深度傳達階層。[ChartSeries.parent_label_layout](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartseries/parent_label_layout/)不會控制其環標籤。
- 兩種圖表使用相同的類別群組層級與相同的葉節點到父層順序 (`data_point_levels`)，因此資料建構與層級格式化程式碼可以共用。
- 父層數值是由其下屬葉節點計算得出。請勿為分支或主幹另外新增數值點。

### **排序與區段順序**

圖表版面引擎決定矩形與環區段的最終位置。在加入資料前，請先將相關類別列排在一起，但不要依賴特定的矩形位置或起始角度。若順序本身具有意義，請將其寫入標籤或改用具有明確類別軸的圖表類型。

### **主題與固定顏色**

未格式化的圖表層級會繼承簡報主題的顏色。範例使用明確的 RGB 填色以確保輸出可預測。若圖表需跟隨主題變更，請改用配色方案顏色而非固定 RGB，並避免對每個層級皆重新設定。更改分支或主幹的填色後，也請檢查標籤的對比度。

### **標籤與可用空間**

當區段過小時，PowerPoint 可能會隱藏或截斷標籤。放大圖表、縮短類別名稱，或顯示較少的標籤欄位通常可產生更清晰的結果。標籤可透過[DataLabelFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabelformat/)結合類別名稱、系列名稱與數值，但同時啟用所有欄位往往會使階層圖表難以閱讀。

### **匯出與轉換**

儲存為 PPTX 可保持圖表可編輯。當 Aspose.Slides 將簡報轉換為 PDF 或影像時，支援的填色與標籤設定會隨圖表一起轉換。字型置換與可用版面空間的細微差異可能改變換行或標籤可見性，因此請安裝所需字型並驗證重要的匯出目標。

## **常見問題**

**為何變更父層會影響多個葉節點？**

分支或主幹是共用的視覺區段。其[ChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointlevel/)可以透過任一子葉節點存取，但格式屬於共用的父區段，而非僅屬於該葉節點。

**為何資料標籤遺失？**

首先在標籤的[DataLabelFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabelformat/)物件上啟用所需欄位，然後檢查該區段是否有足夠空間。Treemap 的父標籤版面、圖表尺寸、標籤長度、字型大小以及啟用的欄位數量，都會影響標籤是否能顯示。

**我可以設定區段的精確順序或座標嗎？**

您可以控制來源列的順序並保持每個群組連續，但無法直接指定 Treemap 矩形或 Sunburst 角度的精確位置。圖表版面引擎會根據階層、數值與可用空間自行計算。

**為何更換簡報主題後顏色會改變？**

基於主題的填色會追隨簡報調色盤。對必須保持不變的層級套用明確的 RGB 顏色，或在需要隨主題調整時保留配色方案顏色。

**自訂格式在 PDF 與影像匯出時會保留嗎？**

會的，支援的圖表填色與標籤設定在轉換過程中會一併保留。為確保跨系統的一致性，請提供所需字型並測試最終匯出尺寸，因為標籤的適配取決於版面配置。

## **相關參考**

- [Create Treemap charts](/slides/zh-hant/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/zh-hant/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/zh-hant/python-net/export-chart/)
- [Manage presentation themes](/slides/zh-hant/python-net/presentation-theme/)