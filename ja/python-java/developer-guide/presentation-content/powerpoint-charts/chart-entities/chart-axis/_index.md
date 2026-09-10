---
title: Python を使用したプレゼンテーションのチャート軸のカスタマイズ
linktitle: チャート軸
type: docs
url: /ja/python-java/chart-axis/
keywords:
- チャート軸
- 縦軸
- 横軸
- 軸のカスタマイズ
- 軸の操作
- 軸の管理
- 軸のプロパティ
- 最大値
- 最小値
- 軸線
- 日付形式
- 軸タイトル
- 軸位置
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "レポートや可視化のための PowerPoint プレゼンテーションで、Aspose.Slides for Python via Java を使用してチャート軸をカスタマイズする方法を紹介します。"
---
## **概要**

この記事では、Aspose.Slides でチャートの軸をカスタマイズする方法を説明します。実際の軸値の取得、軸間のデータの入れ替え、折れ線グラフの縦軸または横軸の非表示、カテゴリ軸の種類変更、カテゴリ軸値の日付形式設定、軸タイトルの回転、軸位置の設定、値軸の表示単位の設定方法を示します。

## **チャートの縦軸の最大値を取得する**

Aspose.Slides for Python via Java を使用すると、縦軸の最小値と最大値を取得できます。次の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 軸上の実際の最大値を取得します。
1. 軸上の実際の最小値を取得します。
1. 軸の実際の主要単位を取得します。
1. 軸の実際の副単位を取得します。
1. 軸の実際の主要単位スケールを取得します。
1. 軸の実際の副単位スケールを取得します。

このサンプルコードは、上記の手順の実装例であり、Python で必要な値を取得する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # プレゼンテーションを保存します
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **軸間のデータを入れ替える**

Aspose.Slides を使用すると、軸間のデータをすばやく入れ替えることができます。縦軸（y 軸）のデータが横軸（x 軸）に移動し、逆も同様です。

この Python コードは、チャートで軸間のデータ入れ替えを実行する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # チャートのデフォルト データをワークブックに読み込みます — switchRowColumn はワークブックを転置します、
    # そのため、最初にデータを入力する必要があります
    workbook = chart.getChartData().getChartDataWorkbook()

    # 行と列を入れ替えます
    chart.getChartData().switchRowColumn()

    # プレゼンテーションを保存します
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **折れ線グラフの縦軸を無効にする**

この Python コードは、折れ線グラフの縦軸を非表示にする方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **折れ線グラフの横軸を無効にする**

このコードは、折れ線グラフの横軸を非表示にする方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **カテゴリ軸を変更する**

[setCategoryAxisType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#setCategoryAxisType) メソッドを使用すると、希望するカテゴリ軸の種類（**date** または **text**）を指定できます。この Python コードはその操作をデモンストレーションします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **カテゴリ軸値の日付形式を設定する**

Aspose.Slides for Python via Java では、カテゴリ軸値の日付形式を設定できます。この操作は以下の Python コードで示されています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャート軸タイトルの回転角度を設定する**

Aspose.Slides for Python via Java を使用して、チャート軸タイトルの回転角度を設定できます。この Python コードがその方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **カテゴリ軸または値軸の軸位置を設定する**

Aspose.Slides for Python via Java で、カテゴリ軸または値軸の軸位置を設定できます。この Python コードはタスクの実行方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャート値軸の表示単位を設定する**

Aspose.Slides for Python via Java では、チャート値軸の表示単位を設定できます。その結果、軸はその単位で目盛ラベルをスケーリングします。たとえば、[DisplayUnitType.Millions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/displayunittype/#Millions) を使用すると、最大 60,000,000 の軸は 0 から 60 と表示されます。この Python コードは操作をデモンストレーションします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**軸が交差する位置（軸交差）をどのように設定しますか？**

軸は [crossing setting](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#setCrossType) を提供します。ゼロ、最大カテゴリ/値、または特定の数値で交差させるかを選択できます。これは X 軸を上下にシフトしたり、基準線を強調したりする際に便利です。

**軸に対して目盛りの位置（crossing、outside、inside）をどのように指定できますか？**

[tick mark position](https://reference.aspose.com/slides/ja/python-java/aspose.slides/axis/#setMajorTickMark) を "cross"、"outside"、または "inside" に設定します。これにより可読性が向上し、特に小さなチャートでスペースを節約できます。