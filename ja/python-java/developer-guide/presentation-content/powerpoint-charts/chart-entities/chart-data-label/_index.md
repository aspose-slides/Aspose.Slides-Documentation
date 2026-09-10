---
title: Python を使用してプレゼンテーションのチャート データ ラベルを管理する
linktitle: データ ラベル
type: docs
url: /ja/python-java/chart-data-label/
keywords:
- チャート
- データ ラベル
- データ 精度
- パーセンテージ
- ラベル 距離
- ラベル 位置
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、スライドをより魅力的にする方法を学びます。"
---
## **はじめに**

チャートのデータ ラベルは、チャートのデータ系列または個々のデータ ポイントの詳細を表示します。読者はデータ系列をすばやく識別でき、チャートの理解もしやすくなります。

## **チャート データ ラベルでデータの精度を設定する**

この Python コードは、チャート データ ラベルのデータ精度を設定する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **パーセンテージをラベルとして表示する**

Aspose.Slides for Python via Java は、表示されたチャートにパーセンテージ ラベルを設定できます。この Python コードはその操作を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)
    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャート データ ラベルにパーセンテージ記号を設定する**

この Python コードは、チャート データ ラベルにパーセンテージ記号を設定する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")
    chart.getChartData().getSeries().clear()
    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # 赤のシリーズを追加します。
    series_cell = workbook.getCell(worksheet_index, 0, 1, "Reds")
    red_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.30, 0.50, 0.80, 0.65], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 1, jpype.JDouble(value))
        red_series.getDataPoints().addDataPointForBarSeries(data_cell)

    red_series.getFormat().getFill().setFillType(FillType.Solid)
    red_series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    red_label_format = red_series.getLabels().getDefaultDataLabelFormat()
    red_label_format.setShowValue(True)
    red_label_format.setNumberFormatLinkedToSource(False)
    red_label_format.setNumberFormat("0.0%")
    red_portion_format = red_label_format.getTextFormat().getPortionFormat()
    red_portion_format.setFontHeight(10)
    red_portion_format.getFillFormat().setFillType(FillType.Solid)
    red_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    # 青のシリーズを追加します。
    series_cell = workbook.getCell(worksheet_index, 0, 2, "Blues")
    blue_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.70, 0.50, 0.20, 0.35], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 2, jpype.JDouble(value))
        blue_series.getDataPoints().addDataPointForBarSeries(data_cell)

    blue_series.getFormat().getFill().setFillType(FillType.Solid)
    blue_series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)
    blue_label_format = blue_series.getLabels().getDefaultDataLabelFormat()
    blue_label_format.setShowValue(True)
    blue_label_format.setNumberFormatLinkedToSource(False)
    blue_label_format.setNumberFormat("0.0%")
    blue_portion_format = blue_label_format.getTextFormat().getPortionFormat()
    blue_portion_format.setFontHeight(10)
    blue_portion_format.getFillFormat().setFillType(FillType.Solid)
    blue_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **軸からラベルの距離を設定する**

この Python コードは、軸から描画されたチャートでカテゴリ軸からラベルの距離を設定する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ラベル位置の調整**

軸に依存しないチャート（例: 円グラフ）を作成する場合、チャートのデータ ラベルがエッジに近すぎることがあります。そのような場合、リーダー線がはっきり表示されるようにデータ ラベルの位置を調整する必要があります。

この Python コードは、円グラフでラベル位置を調整する方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**密集したチャートでデータ ラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー線、フォントサイズの縮小を組み合わせます。必要に応じて、一部のフィールド（例: カテゴリ）を非表示にするか、極端なポイントや重要なポイントにのみラベルを表示します。

**ゼロ、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータポイントをフィルタリングし、定義されたルールに従って 0、負の値、または欠損値の表示をオフにします。

**PDF/画像にエクスポートする際に、一貫したラベルスタイルを確保するにはどうすればよいですか？**

フォント（ファミリー、サイズ）を明示的に設定し、フォールバックを防ぐためにレンダリング側でフォントが利用可能か確認します。