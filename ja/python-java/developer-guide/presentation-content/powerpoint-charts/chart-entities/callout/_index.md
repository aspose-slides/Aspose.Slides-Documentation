---
title: Python を使用したプレゼンテーション チャートの吹き出し管理
linktitle: 吹き出し
type: docs
url: /ja/python-java/callout/
keywords:
- チャート 吹き出し
- 吹き出し の使用
- データ ラベル
- ラベル 書式
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python via Java 用 Aspose.Slides で吹き出しを作成およびスタイル設定し、簡潔なコード例で PPT および PPTX に対応してプレゼンテーション ワークフローを自動化します。"
---
## **概要**

この記事では、Aspose.Slides でチャート データ ラベルの吹き出しの使用方法について説明します。ラベルを吹き出しとして表示するために [setShowLabelAsDataCallout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) メソッドの使用方法、ドーナツ グラフの吹き出し関連ラベル設定の構成方法、そしてプレゼンテーションを PDF、HTML5、SVG、ラスタ画像形式にエクスポートしたときに吹き出しとその外観が保持されることに触れています。

## **吹き出しの使用**

[DataLabelFormat] クラスの [getShowLabelAsDataCallout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) および [setShowLabelAsDataCallout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) メソッドは、チャート データ ラベルを吹き出しとして表示するか、通常のデータ ラベルとして表示するかを決定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ドーナツ グラフの吹き出し設定**

Aspose.Slides for Python via Java は、ドーナツ グラフの系列データ ラベルの吹き出し形状の設定をサポートしています。以下の例でこれを示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **よくある質問**

**プレゼンテーションを PDF、HTML5、SVG、または画像に変換するときに吹き出しは保持されますか？**

はい。吹き出しはチャートのレンダリングの一部であるため、[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/)、[HTML5](/slides/ja/python-java/export-to-html5/)、[SVG](/slides/ja/python-java/render-a-slide-as-an-svg-image/)、または[ラスタ画像](/slides/ja/python-java/convert-powerpoint-to-png/)にエクスポートすると、スライドの書式設定と共に保持されます。

**カスタム フォントは吹き出しで機能し、エクスポート時に外観が保持されますか？**

はい。Aspose.Slides はプレゼンテーションへの[フォント埋め込み](/slides/ja/python-java/embedded-font/)をサポートしており、[PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) などへのエクスポート時にフォント埋め込みを制御することで、異なるシステム間でも吹き出しの外観が同一に保たれます。