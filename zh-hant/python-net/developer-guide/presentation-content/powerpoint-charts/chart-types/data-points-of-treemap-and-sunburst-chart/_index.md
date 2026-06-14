---
title: 在 Python 中自訂 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap 圖表
- Sunburst 圖表
- 資料點
- 標籤顏色
- 分支顏色
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 treemap 與 sunburst 圖表中管理資料點，並相容於 PowerPoint 與 OpenDocument 格式。"
---
## **簡介**

在其他 PowerPoint 圖表類型之中，有兩種階層型圖表 — **Treemap** 和 **Sunburst**（亦稱 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi-Level Pie Chart）。這些圖表以樹狀結構呈現階層資料——由樹葉到分支的頂部。樹葉由系列資料點定義，而每個後續的巢狀分組層級則由相應的類別定義。Aspose.Slides for Python via .NET 允許您在 Python 中格式化 Sunburst 圖表和 Treemap 圖表的資料點。

以下是一個 Sunburst 圖表，Series1 欄位的資料定義了葉節點，其餘欄位則定義階層資料點：

![Sunburst chart example](sunburst_example.png)

讓我們從在簡報中新增一個 Sunburst 圖表開始：

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="See also" %}}
- [**建立 Sunburst 圖表**](/slides/zh-hant/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

如果您需要格式化圖表資料點，請使用以下 API：

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointlevelsmanager/)、[ChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointlevel/) 與 [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) 屬性。它們提供存取 Treemap 和 Sunburst 圖表資料點格式設定的方式。[ChartDataPointLevelsManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) 用於存取多層類別；它代表一個 [ChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointlevel/) 物件的容器。它本質上是 [ChartCategoryLevelsManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartcategorylevelsmanager/) 的封裝，並具備針對資料點的額外屬性。[ChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointlevel/) 類型公開兩個屬性 — [format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointlevel/format/) 和 [label](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/chartdatapointlevel/label/) — 讓您存取相對應的設定。

## **顯示資料點值**

本節說明如何在 Treemap 和 Sunburst 圖表中顯示單一資料點的值。您將看到如何為選取的點啟用值標籤。

顯示「Leaf 4」資料點的值：

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **設定資料點的標籤和顏色**

本節說明如何為 Treemap 和 Sunburst 圖表中的單一資料點設定自訂標籤與顏色。您將學習如何存取特定資料點、指派標籤，並套用實心填色以突顯重要節點。

將「Branch 1」資料標籤設定為顯示系列名稱（「Series1」）而非類別名稱，並將文字顏色設為黃色：

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **設定資料點的分支顏色**

使用分支顏色可控制在 Treemap 和 Sunburst 圖表中父節點與子節點的視覺分組。本節說明如何為特定資料點設定自訂分支顏色，以便突顯重要的子樹並提升圖表可讀性。

變更「Stem 4」分支的顏色：

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **常見問題**

**我可以變更 Sunburst/Treemap 中區段的順序（排序）嗎？**

不能。PowerPoint 會自動排序區段（通常依值遞減、順時針排列）。Aspose.Slides 會遵循此行為：您無法直接變更順序；只能透過前置處理資料來達成。

**簡報主題如何影響區段和標籤的顏色？**

圖表顏色會繼承簡報的 [主題/調色板](/slides/zh-hant/python-net/presentation-theme/)，除非您明確設定填色或字型。若需一致的結果，請在所需層級鎖定實心填色與文字格式。

**匯出為 PDF/PNG 時會保留自訂的分支顏色與標籤設定嗎？**

會。匯出簡報時，圖表設定（填色、標籤）會在輸出格式中保留下來，因為 Aspose.Slides 會以已套用格式的圖表進行渲染。

**我能計算標籤/元素的實際座標，以在圖表上方自訂覆蓋物的位置嗎？**

可以。在圖表版面配置驗證完成後，`actual_x`/`actual_y` 會提供元素（例如 [DataLabel](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.charts/datalabel/)）的實際座標，協助精確定位覆蓋物。