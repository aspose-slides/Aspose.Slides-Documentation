---
title: Python を使用したプレゼンテーションでのチャート軸カスタマイズ
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
- 軸の位置
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションのレポートや可視化のためにチャート軸をカスタマイズする方法を紹介します。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用してチャート軸をカスタマイズする方法を説明します。計算された軸値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置設定、表示単位、対数スケーリングについて取り上げます。

## **チャートの縦軸で最大値を取得する方法**

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) を作成し、デフォルト データでエリア チャートを追加します。計算された軸値を取得する前に [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) を呼び出して、チャート レイアウトが最新であることを確認します。

軸の上限・下限を取得するには [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) と [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) を使用し、目盛り間隔は [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) と [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) を使用します。[getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) と [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) は日時軸に関連する時間単位スケールを提供します。例ではこれらの値をローカル変数に格納し、チャートを保存します。

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

[switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) を使用して、チャート データ内の系列とカテゴリの役割を入れ替えます。元のカテゴリは系列になり、元の系列はカテゴリになります。これによりデータのグループ化方法が変わりますが、水平軸と垂直軸を入れ替えるわけではありません。例では [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) を使用してデフォルト データを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替えます。結果として 4 系列・3 カテゴリのチャートが保存されます。

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

[setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) を使用してカテゴリ軸または数値軸の順序を逆にします。たとえば、横棒グラフでプロジェクトのステージをシートと同じ順序（計画、開発、テスト）で上から下へ表示できます。軸を逆にするとプロット方向が変わりますが、ワークブック データの並び替えや再配置は行われません。比較のために、[switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) は系列とカテゴリの役割を入れ替えます。

次の例は、3 ステージと 1 系列の横棒グラフを作成します。3 枚のスライド（通常順、カテゴリ逆、数値逆）を保存し、各コピーは同じデータセットを使用し、各コピーで 1 つの軸だけを逆にしています。

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
    # 水平数値軸を下部に保持します。
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # スライド 3: 水平数値スケールのみを逆にします。
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

軸を逆にすると、垂直軸をプロットの反対側に移動させることもできます。[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) は、設定対象の軸に対して他の軸がどこで交差するかを制御します。スライド 2 では、逆にしたカテゴリ軸に対して [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) を指定すると、水平数値軸が下部に保持されます。特定の交差位置を指定するには [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) を使用してください。方向を変更するときは、特にカスタム交差点が設定されている場合、交差設定を確認してください。元のプロット方向に戻すには `False` を渡して [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) を呼び出します。交差設定は別個に保持されます。

| 通常順 (スライド 1) | カテゴリ逆 (スライド 2) | 数値逆 (スライド 3) |
| --- | --- | --- |
| ![水平棒グラフ（通常のカテゴリ・数値軸順）](axis-order-normal.png) | ![水平棒グラフ（カテゴリが上から下へ表示）](axis-order-categories-reversed.png) | ![水平棒グラフ（数値軸が逆でゼロが右側）](axis-order-values-reversed.png) |
| カテゴリは下から上へ、数値は左から右へ増加します。 | 計画、開発、テストが上から下へ表示されます。数値とワークシート行の順序は変更されません。 | カテゴリは通常順のままで、数値は右から左へ増加します。カテゴリ軸は右側のゼロで交差します。 |

## **折れ線グラフで縦軸を非表示にする**

縦軸に対して `False` を渡して [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) を呼び出すと、軸が非表示になります。例ではデフォルト データの折れ線グラフを作成し、縦軸を非表示にして保存します。

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

## **折れ線グラフで横軸を非表示にする**

横軸に対して `False` を渡して [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) を呼び出すと、軸が非表示になります。例ではデフォルト データの折れ線グラフを作成し、横軸を非表示にして保存します。

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

## **カテゴリ軸を変更する**

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) を使用して、日付またはテキストのカテゴリ軸を選択します。この例では `ExistingChart.pptx` が必要で、最初のスライドの最初のシェイプがチャートで、カテゴリセルに数値の Excel 日付が格納されています。水平軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) を `False`、[setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) を `1`、[setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) を [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) に設定すると、主要目盛りが 1か月間隔で配置されます。

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

## **カテゴリ軸ラベル間隔を制御する**

チャートに多数のカテゴリがある場合、カテゴリやデータポイントを削除せずに表示ラベル数を減らすことができます。[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) に `False` を渡し、続いて [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) に希望するカテゴリ間隔を指定します。テキストカテゴリが通常順の場合、カウントは最初のカテゴリから始まります。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔 `3` は 3 番目ごとのラベルだけを表示し、表示ラベル間に 2 つのラベルが非表示になりますが、対応する列は削除されません。自動間隔は利用可能なスペースに基づいて決定され、必ずしもすべてのラベルを表示するわけではありません。

目盛りには別個の設定があります。[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) に `False` を渡し、[setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) で間隔を設定します。たとえば `1` は各カテゴリ間隔に目盛りを配置し、ラベルは 3 番目ごとに表示されます。[setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) で可視スタイルを設定すると結果が確認できます。自動間隔に戻すには、いずれかの自動設定セッターに `True` を再度渡します。

以下の自己完結型サンプルは 24 個のカテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 枚のスライド（自動間隔、ラベル間隔手動＋目盛り独立、再度自動間隔）を保存します。2 つのコピーは元のチャート データを保持します。入力プレゼンテーションは不要です。横向きラベル テキストにより密度の違いが分かりやすくなります。

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

    # スライド 2: 3番目ごとのラベルを表示し、各カテゴリに目盛りは残す。
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # スライド 3: チャートに両方の間隔を再び選択させる。
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**自動間隔 (スライド 1):** このレンダリングでは 2 番目のカテゴリラベルが表示され、2 行に折り返されます。自動結果はチャートのサイズ、フォント、レンダラにより変わります。

![すべての 24 列が表示された自動カテゴリラベル間隔](category-axis-automatic.png)

**手動間隔 (スライド 2):** 3 番目ごとのラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も含めて 24 列すべてが同じ値で表示されます。スライド 3 は上記の自動表示に戻ります。

![すべての 24 列が表示された手動カテゴリラベル間隔 (3)](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキストカテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸）にこのカテゴリカウント間隔を使用します。列グラフでは水平軸、横棒グラフではカテゴリ軸が垂直になるため、[getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) が返す軸に設定してください。目盛り間隔は、系列軸を持つチャートのシリーズ軸にも適用できます。

カテゴリラベル間隔は数値軸のスケール設定には使用しないでください。数値軸では [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) が値の差を指定します（例: `10` の主要単位は 0、10、20…）。カテゴリラベル間隔 `3` はデータ値に関係なくカテゴリ位置を数えるだけです。散布図やバブルチャートはテキストカテゴリ軸ではなく数値軸を使用します。日付軸の場合は、[カテゴリ軸を変更する](#change-a-category-axis) で説明した時間ベースの主要単位とスケールを使用してください。

## **カテゴリ軸値の日時書式を設定する**

例ではデフォルト データを 4 つの年次値に置き換えます。日時は最初のワークシート（インデックス `0`）に OLE Automation のシリアル番号（1899 年 12 月 30 日からの日数）として格納されます。[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) に [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) を指定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) を `False`、[setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) に `yyyy` を渡すことで、セルの書式設定に関係なくカテゴリ ラベルが 4 桁の年で表示されます。

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

垂直軸に対して `True` を渡して [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) を呼び出し、タイトル テキストを設定し、タイトルのテキスト ブロック書式で回転角度を指定します。角度は度単位です。この例では列グラフの値軸タイトルを 90 度回転させて保存します。

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

## **カテゴリ軸または数値軸の軸位置を設定する**

[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) を使用して、数値軸がカテゴリ軸のカテゴリ間またはカテゴリ目盛り位置で交差するかを制御します。この設定はカテゴリ軸に適用されます。例では列グラフの水平カテゴリ軸に `True` を設定し、結果を保存します。

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

## **チャート数値軸の表示単位を設定する**

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) を使用して、基になるデータを変更せずに数値軸のラベルをスケーリングします。[DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) を `Millions` に設定すると、60,000,000 が 60 と表示されます。例では列グラフを作成し、垂直軸にミリオン表示単位を適用します。

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

## **対数数値軸を構成する**

対数数値軸は、正の値が数桁にわたって広がる場合に便利です。たとえば、あるサービスが 5 期間で 10、100、1,000、10,000、100,000 件のリクエストを受け取るとします。線形スケールでは小さい値がゼロ付近に密集して表示されますが、対数スケールでは相対的な成長が比較しやすくなります。等間隔は等比率を表します。

数値軸に対して `True` を渡して [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) を呼び出し、[setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) で基数を選択します。これにより既存の値の表示が変わりますが、データ自体や対数トレンドラインは変更されません。トレンドラインはデータに対するフィッティング機能であり、別の機能です。

### **数値軸と基数の選択**

折れ線または列グラフの場合、数値軸は [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) が返します。横棒グラフの場合は [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) が返します。散布図やバブルチャートは 2 つの数値軸を持つため、X 値用に水平軸、Y 値用に垂直軸、または両方を選択してください。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000`（整数）までの基数が使用でき、`2.5` のような小数基数もサポートされます。基数 `10` の場合、10、100、1,000、10,000 などの連続したべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の自己完結型サンプルは、リクエスト数 5 つを持つ折れ線グラフをスライド 1 に作成し、同じスライドをクローンしてスライド 2 の数値軸を基数 10 の対数スケールに変更します。両方のスライドは同じデータを保持します。

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

    # 最初のスライドは線形のままにし、コピーの値軸スケールだけを変更します。
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**線形スケール (スライド 1):** 等しい垂直距離はリクエスト数の等しい差を表し、最大値がチャートを支配し、較小値が見にくくなります。

![線形数値軸で 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-linear.png)

**対数スケール (スライド 2):** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前回の 10 倍なので、基数 10 のスケールでは直線的に上昇する直線になります。軸ラベルは元のリクエスト数をそのまま表示します。

![PowerPoint で基数 10 の対数数値軸上に同じ 5 つのリクエスト数を示す](value-axis-logarithmic.png)

### **ゼロおよび負の値の取り扱い**

対数スケールは正の値のみ表示できます。使用前にデータを確認してください。ゼロや負の値が意味を持つ場合は、線形スケールを使用するか、別々に表示してください。分析上それらの値を除外する場合は、除外した理由を説明してください。小さな正の数で静かに置き換えてはいけません。対数軸の手動で設定した最小値・最大値も正である必要があります。

## **FAQ**

**軸が交差する位置（軸交差）を数値で設定するにはどうすればよいですか？**

[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) を使って交差の動作を選択します。数値の交差位置を指定するには [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) を使用します。これらの設定で軸交差点を適切なベースラインに移動できます。

**目盛りラベルを軸に対してどのように位置付けできますか？**

[setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) に [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) の `Low`、`High`、`NextTo`、`None` のいずれかを指定します。目盛り自体を制御するには [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) または [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) を使用してください。これらはラベル位置設定とは別です。