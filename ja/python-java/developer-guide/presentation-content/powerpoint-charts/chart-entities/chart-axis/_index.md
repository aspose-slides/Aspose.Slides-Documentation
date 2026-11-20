---
title: Python を使用したプレゼンテーションでのチャート軸のカスタマイズ
linktitle: チャート軸
type: docs
url: /ja/python-java/chart-axis/
keywords:
- チャート軸
- 垂直軸
- 水平軸
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
description: "レポートや可視化のために、Java 経由で Python 用 Aspose.Slides を使用して PowerPoint プレゼンテーションのチャート軸をカスタマイズする方法を学びます。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用してチャート軸をカスタマイズする方法を説明します。計算された軸値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置、表示単位、および対数スケーリングについてカバーします。

## **チャートの縦軸の最大値を取得する**

[プレゼンテーション](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) を作成し、デフォルトデータのエリアチャートを追加します。計算された軸値を取得する前に、チャートのレイアウトが最新になるように [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) を呼び出します。

軸の上限と下限を取得するには [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) と [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) を使用し、目盛り間隔は [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) と [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) を使用します。[getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) と [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) は日付軸に関連する時間単位スケールを提供します。この例ではこれらの値をローカル変数に保存し、チャートを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **軸間のデータを入れ替える**

[switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) を使用して、チャートデータ内の系列とカテゴリの役割を交換します。元のカテゴリは系列になり、元の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、横軸と縦軸を入れ替えるわけではありません。この例では [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) を使用してデフォルトデータを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替えます。結果として 4 系列・3 カテゴリのチャートが保存されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **軸のプロット順序を逆にする**

[setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) を使用してカテゴリ軸または値軸の順序を逆転させます。たとえば、水平棒グラフでプロジェクトのフェーズを「計画」「開発」「テスト」の順に上から下へ表示できます。軸を逆にするとプロット方向が変わりますが、ワークブックのデータを並べ替えたり再配置したりはしません。比較として、[switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) は系列とカテゴリの役割を交換します。

以下の例は、3 つのフェーズと 1 系列の水平棒グラフを作成します。3 枚のスライドを保存します：通常順序、カテゴリ逆順、値逆順。各コピーは同じデータセットを使用し、各コピーで逆になる軸は 1 つだけです。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # スライド 2: 最初のカテゴリを上部に表示します。
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # 水平の値軸を下部に保ちます。
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # スライド 3: 水平数値スケールのみを逆にします。
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

軸を逆にすると、垂直軸をプロットの反対側に移動させることもできます。[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) は、設定対象の軸に対して他方の軸がどこで交差するかを制御します。スライド 2 では、逆転したカテゴリ軸に対して [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) を指定すると、水平値軸は下部に残ります。特定の交差点を指定するには [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) を使用します。方向を変更する際は、特にカスタム交差点が設定されている場合に交差設定を確認してください。元のプロット方向に戻すには `False` を渡して [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) を呼び出します。交差設定は別個です。

| 通常順序 (スライド 1) | カテゴリ逆順 (スライド 2) | 値逆順 (スライド 3) |
| --- | --- | --- |
| ![通常のカテゴリと値軸順序の水平棒グラフ](axis-order-normal.png) | ![上から下へ表示されるカテゴリの水平棒グラフ](axis-order-categories-reversed.png) | ![右側がゼロになる逆順値軸の水平棒グラフ](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | 計画、開発、テストが上から下へ表示されます。値とワークブックの行順序は変更されません。 | カテゴリは通常順序のまま、値は右から左へ増加します。カテゴリ軸は右側ゼロで交差します。 |

## **折れ線グラフの縦軸を非表示にする**

縦軸に対して `False` を渡して [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) を呼び出すと非表示にできます。この例ではデフォルトデータの折れ線グラフを作成し、縦軸を非表示にして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **折れ線グラフの横軸を非表示にする**

横軸に対して `False` を渡して [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) を呼び出すと非表示にできます。この例ではデフォルトデータの折れ線グラフを作成し、横軸を非表示にして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャートのグリッドラインを表示または非表示にする**

[getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) と [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines) を呼び出して、軸が表示するグリッドラインを確認します。マイナーグリッドラインを表示するには [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) を取得し、線の塗りを実線の可視色に設定します。非表示にするには塗りを [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill) に設定します。メジャーグリッドラインの塗りを変更するには [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) を使用します。塗りを変更しても軸の可視性や目盛りは保持されます。

この集合棒状チャートの縦軸は最初はメジャーグリッドラインのみが表示されています。例ではマイナーグリッドラインを濃いオレンジで表示し、保存前に再び非表示にします。各ステップでグリッドラインの可視性を出力します。

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

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230)
    axis = chart.getAxes().getVerticalAxis()
    print(f"Initial: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    minor_fill = axis.getMinorGridLinesFormat().getLine().getFillFormat()
    minor_fill.setFillType(FillType.Solid)
    minor_fill.getSolidFillColor().setColor(Color(255, 140, 0))
    print(f"Enabled: minor={axis.getShowMinorGridLines()}")

    minor_fill.setFillType(FillType.NoFill)
    print(f"Hidden: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| マイナーグリッドライン表示 | マイナーグリッドライン非表示 |
| --- | --- |
| ![縦軸のメジャーグリッドライン間に表示されたオレンジのマイナーグリッドライン](minor-gridlines-enabled.png) | ![メジャーグリッドラインのみが表示された同じ棒グラフ](minor-gridlines-hidden.png) |

## **カテゴリ軸を変更する**

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) を使用して日付軸またはテキスト軸を選択します。この例は `ExistingChart.pptx`（最初のスライドの最初のシェイプにチャートがあり、カテゴリセルに数値の Excel 日付が入っている）を前提としています。水平軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) に `False`、[setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) に `1`、[setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) に [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) を指定すると、メジャー目盛りが 1 ヶ月間隔になります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **データからカテゴリ軸の種類を自動判定する**

カテゴリを設定した後に [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) を呼び出し、続いて [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) で結果を確認します。テキストラベルまたは数値の日付がチャートに与えられる場合に便利です。このメソッドは呼び出し時にタイプを決定し、その後のデータ変更を自動的に再評価する永続モードはありません。カテゴリを置き換えた後に再度呼び出してください。

以下の例はテキストカテゴリのチャートを作成し、選択されたタイプが [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text) のときに `True` を出力します。その後、カテゴリセルの値を日付に置き換え、再度メソッドを呼び出して選択タイプが [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) のときに `True` を出力します。日付は数値の OLE Automation 値として保存され、1899 年 12 月 30 日からの経過日数で表されます。[setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) は表示形式を制御しますが、テキストを数値日付に変換するわけではありません。カテゴリセルの詳細は [Chart Workbook](/slides/ja/python-java/chart-workbook/) を参照してください。

入力がテキストカテゴリまたは数値日付であることが分かっている場合は自動判定を使用してください。通常の数値ラベル、混合カテゴリ、空データの場合は、意図した意味に合わせて明示的に [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) を呼び出してください。数値だけではカテゴリが日付を表すとは限りません。

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CategoryAxisType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series_name = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.getCell(0, i + 1, 0, label)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # True

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # True

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **カテゴリ軸ラベルの間隔を制御する**

カテゴリが多数あるチャートでは、カテゴリやデータポイントを削除せずに表示ラベル数を減らすことができます。まず [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) に `False` を渡し、続いて希望のカテゴリ間隔を [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) に指定します。テキストカテゴリが通常順序の場合、カウントは最初のカテゴリから始まります。

| 間隔 | 例のラベル表示 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` の間隔は 3 番目ごとのラベルだけを表示し、表示ラベル間に 2 つのラベルが非表示になります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて決定され、必ずしもすべてのラベルを表示するわけではありません。

目盛りにも個別の設定があります。[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) に `False` を渡し、[setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) で間隔を設定します。たとえば `1` はカテゴリ間隔ごとに目盛りを残し、ラベルは 3 カテゴリごとに表示します。目に見えるスタイルで [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) を使用して結果を確認してください。自動間隔設定に `True` を再度渡すと、チャートが自動で間隔を選択します。

以下の自己完結型例は 24 個のカテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 枚のスライドを保存します：自動間隔、手動ラベル間隔（目盛りは独立）、自動間隔に復元します。2 コピーは元のチャートデータを保持します。入力プレゼンテーションは不要です。水平ラベルテキストが密度の違いを視覚的に分かりやすくします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # スライド 2: 3番目ごとのラベルだけを表示し、各カテゴリに目盛りは残す。
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # スライド 3: チャートに両方の間隔を再び自動選択させる。
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**自動間隔 (スライド 1)：** このレンダリングでは 2 番目ごとのカテゴリラベルが表示され、2 行に折り返されます。自動結果はチャートのサイズ、フォント、レンダラーにより変わります。

![すべての 24 列が表示された自動カテゴリラベル間隔](category-axis-automatic.png)

**手動間隔 (スライド 2)：** 3 番目ごとのラベルが 1 行で表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も含めて 24 列すべてが同じ値で可視です。スライド 3 は上記の自動表示に戻ります。

![すべての 24 列が表示された手動カテゴリラベル間隔 (3)](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキストカテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸）に対してこのカテゴリ間隔を使用します。列グラフでは水平軸、水平棒グラフでは垂直軸が該当します。その場合は [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) で取得した軸に設定してください。目盛り間隔は系列軸があるチャートでも適用できます。

カテゴリラベル間隔は値軸の数値スケールを設定するために使用しないでください。値軸では [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) が数値の差を指定します（例：`10` は 0、10、20…）。一方、カテゴリラベル間隔 `3` はデータ値に関係なくカテゴリ位置を数えるだけです。散布図やバブルチャートはテキストカテゴリ軸ではなく値軸を使用します。日付軸の場合は、[Change a Category Axis](#change-a-category-axis) で説明した時間ベースのメジャー単位とスケールを使用してください。

## **カテゴリ軸の値に対する日付書式を設定する**

例ではデフォルトチャートデータを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation のシリアル番号として保存され、1899 年 12 月 30 日からの経過日数で表されます。[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) に [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) を指定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) に `False`、[setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) に `yyyy` を渡すことで、セル書式に関係なくカテゴリラベルが 4 桁の西暦で表示されます。

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャート軸タイトルの回転角度を設定する**

縦軸に対して `True` を渡して [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) を呼び出し、タイトルテキストを設定し、テキストブロックの書式で回転角度を指定します。角度は度数で測定され、例では縦軸タイトルを 90 度回転させた列グラフを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **カテゴリ軸または値軸の軸位置を設定する**

[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) を使用して、値軸がカテゴリ軸とカテゴリ間隔の間で交差するか、カテゴリ目盛り上で交差するかを制御します。この設定はカテゴリ軸に適用されます。例では列グラフの水平カテゴリ軸に `True` を設定し、結果を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャート値軸の表示単位を設定する**

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) を使用すると、基になるデータを変更せずに値軸ラベルをスケーリングできます。[DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) を `Millions` に設定すると、60,000,000 が 60 と表示されます。例では列グラフを作成し、縦軸にミリオン単位を適用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **対数値軸を構成する**

正の値が数桁にわたって広がる場合、対数値軸が有用です。たとえば、あるサービスが 5 期間でそれぞれ 10、100、1,000、10,000、100,000 件のリクエストを受けたとします。線形スケールでは小さい値がゼロ付近に密集して見えますが、対数スケールにすると相対的な増加が比較しやすくなります。等間隔は等比率を表します。

値軸に対して `True` を渡して [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) を呼び出し、[setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) で基数を選択します。これにより既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは変更されません。トレンドラインはデータのフィットした関係を表す別機能です。

### **値軸と基数の選択**

折れ線や列グラフの場合、値軸は [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) で取得します。水平棒グラフの場合は [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) が返す軸です。散布図とバブルチャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、または両方を使用します。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000` までの整数基数が使用できますが、`2.5` などの小数基数もサポートされています。基数 `10` の場合、10、100、1,000、10,000 といった連続したべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の自己完結型例は、最初のスライドに 5 つのリクエスト数を持つ折れ線チャートを作成し、そのスライドを複製して 2 枚目で基数 10 の対数値軸を有効にします。両スライドは同じデータを保持します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # 最初のスライドは線形のままにし、コピーの値軸のスケールだけを変更します。
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**線形スケール (スライド 1)：** 等しい垂直距離はリクエスト数の等しい差を表します。最大値がチャートを支配し、より小さな値が見分けにくくなります。

![線形値軸上の 5 つのリクエスト数を示す折れ線グラフ](value-axis-linear.png)

**対数スケール (スライド 2)：** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前回の 10 倍になるため、基数 10 のスケールでは直線的に上昇する線になります。軸ラベルは元のリクエスト数をそのまま表示します。

![基数 10 の対数値軸上の同じ 5 つのリクエスト数](value-axis-logarithmic.png)

### **ゼロと負の値の取り扱い**

対数スケールは正の値のみを表示できます。適用前にデータを確認してください。ゼロまたは負の値が意味を持つ場合は、線形スケールを維持するか、別個に表示してください。分析上それらの値を除外する場合は、除外した理由を説明してください。小さな正の数で静かに置き換えることはデータの意味を変えるため避けてください。対数軸の手動で設定した最小値や最大値も正の数である必要があります。

## **FAQ**

**軸が他方と交差する位置（軸交差）をどう設定しますか？**

[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) で交差動作を選択し、数値の交差位置を指定するには [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) を使用します。これらの設定により、軸交差点を適切な基準線に移動できます。

**目盛りラベルの位置を軸に対してどう調整しますか？**

[setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) に [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) の `Low`、`High`、`NextTo`、`None` を指定します。目盛り自体を制御するには、[setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) または [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) を使用します。これらはラベル位置設定とは別です。