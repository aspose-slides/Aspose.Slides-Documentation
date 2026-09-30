---
title: 使用 Python 在簡報中自訂圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/python-net/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 客製化圖表圖例，以量身訂做的圖例格式優化 PowerPoint 簡報。"
---
## **概觀**

Aspose.Slides for Python via .NET 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本篇文章說明如何定位與調整圖例大小、設定整個圖例的字型大小、格式化單一圖例項目，以及隱藏或還原所選項目。  
FAQ 內容涵蓋相關行為，包括為圖例保留空間、顯示多行標籤，以及從簡報主題繼承格式設定。

## **圖例定位**

使用圖例的 [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), 與 [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) 屬性，以圖表尺寸的比例指定其位置與大小。  

此範例建立簡報，並在第一張投影片中加入具有預設資料的叢集柱狀圖。將期望的圖例偏移與尺寸除以圖表的寬度與高度，即可轉換為相對值：圖例相對於圖表左上角偏移 50 點，大小為 100 × 100 點。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # 表示圖例相對於圖表的位置與大小
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **設定圖例的字型大小**

使用圖例的 [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) 取得其文字格式，並以點數設定 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/)。  

此範例建立具有預設資料的圖表，並將圖例文字設定為 20 點。同時停用垂直軸的自動界限，並將其範圍設為 -5 到 10。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **設定單一圖例項目的字型大小**

使用圖例的 [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) 集合以取得特定項目的格式。項目索引是從零開始計算，因此索引 `1` 代表第二個項目。  

此範例建立預設資料至少包含兩個系列的叢集柱狀圖。它將第二個圖例項目格式化為粗體、斜體、20 點藍色文字。

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **隱藏單一圖例項目**

若要在保留資料可見的情況下，將輔助系列從圖例中排除，請透過 [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/) 將 [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) 設為 `True`。這僅會隱藏選取的圖例項目，並不會移除系列或其資料點。相較之下，將 [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) 設為 `False` 會隱藏整個圖例。  

以下範例使用預設資料建立具有多個系列的叢集柱狀圖。它隱藏第二個系列的圖例項目（索引 `1`）並儲存簡報。接著透過將 [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) 設為 `False` 來還原該項目，並儲存第二個副本。兩個檔案中的柱狀仍保持可見。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # 在不更改圖表資料的情況下還原相同的項目。
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

以下比較顯示相同圖表在全部項目可見與第二項目隱藏的兩種情況。第二系列的柱狀保持不變。

![全部圖例項目可見與第二系列圖例項目被隱藏的圖表比較；所有柱狀均保持可見。](hide-legend-entry.png)

在直條圖、橫條圖與折線圖中，圖例項目用以識別系列。對於圓餅圖，則是識別個別資料點（切片），因此請在選取的切片上使用 [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/)。API 對 `PIE`、`PIE3D`、`EXPLODED_PIE`、`EXPLODED_PIE3D`、`PIE_OF_PIE` 以及 `BAR_OF_PIE` 圖表類型說明了此資料點屬性。請勿假設此屬性亦適用於甜甜圈圖，因該圖未列於清單中。

## **常見問題**

**我可以讓圖表為圖例保留空間而不是覆蓋它嗎？**  
可以。將 [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) 設為 `False`，即可為圖例保留空間，而非讓其覆蓋繪圖區域。

**我可以製作多行圖例標籤嗎？**  
可以。當可用寬度不足時，長標籤會自動換行。您也可以在系列名稱中加入換行字元以要求換行。

**我要如何讓圖例遵循簡報主題的配色方案？**  
不要設定圖例的顏色、填充與字型，讓其自行繼承主題格式。若明確設定則會覆寫相應的主題設定。