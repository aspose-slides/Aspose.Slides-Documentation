---
title: Python を使用したプレゼンテーションでのチャート データ ラベルの管理
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
description: "PowerPoint プレゼンテーションにおいて、Aspose.Slides for Python via Java を使用してチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **はじめに**

データ ラベルは、チャートの系列や個々のデータ ポイントに関する情報を表示し、読者が値を識別してチャートを理解できるようにします。本記事では、値の書式設定、パーセンテージの表示、ラベル テキストの取得、軸の最大値を超えるラベルの制御、カテゴリ軸ラベルの間隔調整、円グラフラベルの位置設定方法について説明します。

## **チャート データ ラベルの数値精度を設定**

[setNumberFormatOfValues](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) を使用して系列の値の書式を設定します。この例では、デフォルト データで折れ線グラフを作成し、データ表を表示し、最初の系列に値ラベルを有効にします。書式 `#,##0.00` は千位区切りと小数点以下 2 桁を表示し、元の値は変更しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **パーセンテージをラベルとして表示**

積み上げ縦棒グラフの場合、各値をカテゴリ合計に対するパーセンテージに換算し、[getTextFrameForOverriding](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) が返すテキスト フレームにテキストを割り当てます。この例はデフォルトのチャート データを使用し、8 ポイント フォントで小数点以下 2 桁のパーセンテージを表示します。合計が 0 のカテゴリは除外して除算エラーを回避します。チャート データが変更された場合は、カスタム ラベル テキストを再計算してください。

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
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャート データ ラベルにパーセンテージ記号を設定**

値が分数で保存されている場合は、[setNumberFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabelformat/#setNumberFormat) を使用してパーセンテージ表示します。[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) に `False` を渡すと、ソース セルとは独立してラベル書式が適用されます。

この例では、4 つのカテゴリに対して赤と青の系列を持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値は合計で 1 になります。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下 2 桁を使用します。両系列とも白色の 10 ポイント ラベル テキストを使用します。

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
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **データ ラベルの実際のテキストを取得**

[getActualLabelText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabel/#getActualLabelText) を使用して、データ ラベル設定から生成されたテキストを取得します。レポート作成時のラベル抽出、プレゼンテーション内容の検索、生成チャートの検証などに便利です。以下の例では、デフォルトの[data label format](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabelformat/) がカテゴリ名、系列名、値を組み合わせて表示します。あるポイントは値をパーセンテージで表示し、別のポイントは[getTextFrameForOverriding](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) から取得したカスタム テキストを使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

データ ポイントに格納された数値は `0.75` のままで、ラベルが `75%` とカテゴリ名と系列名を併せて表示しても、元の数値は変わりません。カスタム テキストは生成されたラベル テキストを置き換えます。どちらの場合でも [getActualLabelText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabel/#getActualLabelText) は結果のラベル文字列を返します。表示されているラベルだけを抽出したい場合は、上記の例のように [isVisible](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabel/#isVisible) を別途確認してください。

## **軸の最大値を超えるデータ ラベルを制御**

軸範囲を手動で制限すると、一部のデータ ポイントが最大値を超えることがあります。[setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) を使用して、これらのデータ ラベルを表示するかどうかを制御します。この設定はラベルの表示/非表示を切り替えるだけで、軸範囲や元のデータ値は変更しません。

以下の例では、値が 60 と 120 の 2D クラスタ化縦棒グラフを作成し、[setAutomaticMaxValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#setAutomaticMaxValue) に `False` を渡して自動最大値を無効にし、縦軸の最大値を [setMaxValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#setMaxValue) で 100 に設定します。最初のスライドは最大値を超えるラベルを表示し、コピーしたスライドは非表示にします。両スライドは `DataLabelsOverMaximum.pptx` として保存されます。

[setShowValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabelformat/#setShowValue) で値ラベルを有効にします。チャート レベルの設定だけでは個別ラベルの表示状態を上書きできません。この例では、系列全体の値表示を有効にし、[setPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabelformat/#setPosition) で各列の外側端にラベルを配置します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下の画像は Microsoft PowerPoint でレンダリングした保存スライドです。`True` の場合、ラベル **120** が上端に表示されます。`False` の場合は非表示になります。ラベル **60** は引き続き表示され、軸最大値は **100** のままで、2 番目のデータ ポイントはどちらの場合も **120** です。

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
この例は値軸を持つ 2D 縦棒グラフを使用しています。円グラフやドーナツ グラフなど、値軸を持たないチャートにはこのような軸最大値の制限は適用できません。
{{% /alert %}}

## **軸からのラベル間隔を設定**

[setLabelOffset](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#setLabelOffset) を使用して、カテゴリ軸ラベルと軸との間隔を制御します。値は軸ラベルの最大フォント サイズのパーセンテージです。この例ではクラスタ化縦棒グラフを作成し、横軸ラベルのオフセットを 500 に設定します。この設定は個々のデータ ポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

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

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ラベル位置の調整**

円グラフでは、データ ラベルの位置を調整して間隔を広げ、リーダー ラインの配置スペースを確保します。

この例では、最初のデータ ポイントの値を表示し、ラベルをスライスの外側に配置し、[setX](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabel/#setX) と [setY](https://reference.aspose.com/slides/ja/python-java/aspose.slides/datalabel/#setY) で水平・垂直オフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![円グラフで調整されたデータ ラベル位置](pie-chart-adjusted-label.png)

## **FAQ**

**密集したチャートでデータ ラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー ライン、フォント サイズの縮小を組み合わせ、必要に応じて一部の項目（例: カテゴリ）を非表示にするか、極端な値や重要なポイントのみラベルを表示します。

**ゼロ、負、または空の値だけラベルを無効にするにはどうすればよいですか？**

ラベルを有効化する前にデータ ポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを適用します。

**PDF/画像へエクスポートした際にラベルのスタイルを一貫させるにはどうすればよいですか？**

フォント ファミリーとサイズを明示的に設定し、レンダリング環境にそのフォントが存在することを確認してフォールバックを防止します。