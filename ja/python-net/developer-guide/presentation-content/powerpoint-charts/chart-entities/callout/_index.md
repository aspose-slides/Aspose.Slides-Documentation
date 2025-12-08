---
title: Python を使用したプレゼンテーションチャートの呼び出し線の管理
linktitle: 呼び出し線
type: docs
url: /ja/python-net/callout/
keywords:
- チャート呼び出し線
- 呼び出し線の使用
- データ ラベル
- ラベル形式
- Python
- Aspose.Slides
description: "簡潔なコード例で Aspose.Slides for Python .NET の呼び出し線を作成およびスタイル設定し、PPT、PPTX、ODP に対応してプレゼンテーションワークフローを自動化します。"
---

## **呼び出し線の使用**
**ShowLabelAsDataCallout** という新しいプロパティが **DataLabelFormat** クラスと **IDataLabelFormat** インターフェイスに追加されました。このプロパティは、指定されたチャートのデータラベルをデータ呼び出し線として表示するか、データラベルとして表示するかを決定します。以下の例では、呼び出し線を設定しています。
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].labels.default_data_label_format.show_label_as_data_callout = True
    chart.chart_data.series[0].labels[2].data_label_format.show_label_as_data_callout = False
    presentation.save("DisplayChartLabels_out.pptx", slides.export.SaveFormat.PPTX)
```


## **ドーナツ チャートの呼び出し線の設定**
Aspose.Slides for Python via .NET は、ドーナツチャートのシリーズ データラベル呼び出し線の形状を設定する機能を提供します。以下にサンプル例を示します。
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.DOUGHNUT, 10, 10, 500, 500, False)
    workBook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = False
    seriesIndex = 0
    while seriesIndex < 15:
        series = chart.chart_data.series.add(workBook.get_cell(0, 0, seriesIndex + 1, "SERIES " + str(seriesIndex)), chart.type)
        series.explosion = 0
        series.parent_series_group.doughnut_hole_size = 20
        series.parent_series_group.first_slice_angle = 351
        seriesIndex += 1
    categoryIndex = 0
    while categoryIndex < 15:
        chart.chart_data.categories.add(workBook.get_cell(0, categoryIndex + 1, 0, "CATEGORY " + str(categoryIndex)))
        i = 0
        while i < len(chart.chart_data.series):
            iCS = chart.chart_data.series[i]
            dataPoint = iCS.data_points.add_data_point_for_doughnut_series(workBook.get_cell(0, categoryIndex + 1, i + 1, 1))
            dataPoint.format.fill.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.fill_type = slides.FillType.SOLID
            dataPoint.format.line.fill_format.solid_fill_color.color = draw.Color.white
            dataPoint.format.line.width = 1
            dataPoint.format.line.style = slides.LineStyle.SINGLE
            dataPoint.format.line.dash_style = slides.LineDashStyle.SOLID
            if i == len(chart.chart_data.series) - 1:
                lbl = dataPoint.label
                lbl.text_format.text_block_format.autofit_type = slides.TextAutofitType.SHAPE
                lbl.data_label_format.text_format.portion_format.font_bold = 1
                lbl.data_label_format.text_format.portion_format.latin_font = slides.FontData("DINPro-Bold")
                lbl.data_label_format.text_format.portion_format.font_height = 12
                lbl.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
                lbl.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.light_gray
                lbl.data_label_format.format.line.fill_format.solid_fill_color.color = draw.Color.white
                lbl.data_label_format.show_value = False
                lbl.data_label_format.show_category_name = True
                lbl.data_label_format.show_series_name = False
                lbl.data_label_format.show_leader_lines = True
                lbl.data_label_format.show_label_as_data_callout = False
                chart.validate_chart_layout()
                lbl.as_i_layoutable.x += 0.5
                lbl.as_i_layoutable.y += 0.5
            i += 1
        categoryIndex +=1 
    pres.save("chart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**プレゼンテーションを PDF、HTML5、SVG、または画像に変換するときに呼び出し線は保持されますか？**

はい。呼び出し線はチャートのレンダリングの一部であるため、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/)、[HTML5](/slides/ja/python-net/export-to-html5/)、[SVG](/slides/ja/python-net/render-a-slide-as-an-svg-image/)、または[ラスタ画像](/slides/ja/python-net/convert-powerpoint-to-png/)へエクスポートする際に、スライドの書式設定とともに保持されます。

**カスタムフォントは呼び出し線で使用でき、エクスポート時に外観が保持されますか？**

はい。Aspose.Slides はプレゼンテーションへの[フォント埋め込み](/slides/ja/python-net/embedded-font/)をサポートしており、[PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) などのエクスポート時にフォント埋め込みを制御し、異なるシステムでも呼び出し線の外観が同じになるようにします。