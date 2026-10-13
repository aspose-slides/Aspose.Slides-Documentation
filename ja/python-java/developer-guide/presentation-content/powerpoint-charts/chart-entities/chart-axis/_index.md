---
title: Python を使用したプレゼンテーションでのチャート軸のカスタマイズ
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
description: "レポートや可視化のために、Java 経由で Python 用 Aspose.Slides を使用して PowerPoint プレゼンテーションのチャート軸をカスタマイズする方法を紹介します。"
---
## **概要**

このドキュメントでは、Aspose.Slides for Python via Java を使用してチャート軸をカスタマイズする方法を説明します。計算された軸の値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリ ラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置、表示単位、対数スケーリングについて取り上げます。

## **チャートの縦軸の最大値を取得する**

デフォルト データでエリア チャートを追加した [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) を作成します。計算された軸の値を取得する前に、チャートのレイアウトが最新になるように [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) を呼び出します。

[ getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) と [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) で軸の上下限を取得し、[getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) と [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) で目盛り間隔を取得します。[getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) と [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) は時間単位のスケールを提供し、日付軸で使用します。サンプルはこれらの値をローカル変数に格納し、チャートを保存します。

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

## **データを軸間で入れ替える**

[swapRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) を使用して、シリーズとカテゴリの役割を入れ替えます。元のカテゴリはシリーズになり、元のシリーズはカテゴリになります。データのグループ化方法が変わりますが、水平軸と垂直軸そのものは入れ替わりません。サンプルは [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) でデフォルト データを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行列を入れ替えた後、4 系列・3 カテゴリのチャートを保存します。

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

## **折れ線グラフの縦軸を非表示にする**

縦軸に対して `False` を渡して [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) を呼び出すことで非表示にします。サンプルはデフォルト データで折れ線グラフを作成し、縦軸を非表示にして保存します。

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

## **折れ線グラフの水平軸を非表示にする**

水平軸に対して `False` を渡して [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) を呼び出すことで非表示にします。サンプルはデフォルト データで折れ線グラフを作成し、水平軸を非表示にして保存します。

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

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) を使用して、日付軸またはテキスト軸を選択します。このサンプルは `ExistingChart.pptx` が必要で、最初のスライドの最初のシェイプがチャートで、カテゴリセルに数値の Excel 日付が格納されています。水平軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) に `False`、[setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) に `1`、[setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) に [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) を指定すると、主要目盛りが 1 ヶ月間隔で配置されます。

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

カテゴリが多数ある場合、カテゴリやデータポイントを削除せずに表示ラベル数を減らすことができます。[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) に `False` を設定し、希望のカテゴリ間隔を [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) に渡します。テキストカテゴリが通常順序の場合、カウントは最初のカテゴリから開始します。

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | カテゴリ 1, カテゴリ 2, カテゴリ 3, ... カテゴリ 24 |
| `2` | カテゴリ 1, カテゴリ 3, カテゴリ 5, ... カテゴリ 23 |
| `3` | カテゴリ 1, カテゴリ 4, カテゴリ 7, ... カテゴリ 22 |

`3` の間隔では 3 番目ごとのラベルが表示され、表示ラベル間に 2 つのラベルが隠れます。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて決定され、必ずしもすべてのラベルが表示されるわけではありません。

目盛りには別個の制御があります。[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) に `False` を設定し、[setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) で間隔を指定します。たとえば `1` を指定すると、ラベルが 3 カテゴリごとに表示されても、目盛りはすべてのカテゴリ間隔に配置されます。[setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) で可視スタイルを設定すると結果が確認できます。自動間隔に戻すには、いずれかの自動設定セッターを `True` にします。

以下の自己完結型サンプルは 24 カテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 枚のスライドを保存します：自動間隔、ラベル間隔のみ手動、そして自動間隔に復元したものです。2 つのコピーは元のチャート データを保持します。入力プレゼンテーションは不要です。水平ラベル テキストにより密度の違いが視覚的に把握しやすくなります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

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

    # スライド 2: 3 番目ごとのラベルを表示し、各カテゴリに目盛りは残します。
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # スライド 3: チャートに両方の間隔を再度選択させます。
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**自動間隔（スライド 1）:** このレンダリングでは、2 番目のカテゴリ ラベルごとに表示され、2 行に折り返されます。自動結果はチャート サイズ、フォント、レンダラーにより変わります。

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 番目ごとのラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も含めた 24 列すべてが同じ値で表示されます。スライド 3 は上記の自動表示に戻します。

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキスト カテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸など）でこのカテゴリ カウント間隔を使用します。列グラフでは水平軸、水平棒グラフではカテゴリ軸が垂直になるため、[getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) が返す軸に適用します。目盛り間隔は、シリーズ軸を持つチャートでも適用できます。

数値軸のスケール設定にカテゴリ ラベル間隔を使用しないでください。数値軸では [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) が値の差を指定します（例：`10` の主要単位は 0、10、20…）。カテゴリ ラベル間隔 `3` はデータ値に関係なくカテゴリ位置をカウントします。散布図やバブルチャートはテキスト カテゴリ軸ではなく数値軸を使用します。日付軸の場合は、[Change a Category Axis](#change-a-category-axis) で説明した時間ベースの主要単位とスケールを使用してください。

## **カテゴリ軸の値の日時形式を設定する**

サンプルはデフォルト データを 4 つの年間値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation のシリアル番号として格納され、1899 年 12 月 30 日からの日数で表されます。[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) に [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) を指定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) に `False`、[setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) に `yyyy` を渡すことで、セル書式に依存せず 4 桁の年だけをカテゴリ ラベルに表示します。

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

垂直軸に対して `True` で [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) を呼び出し、タイトル テキストを設定し、タイトルのテキスト ブロック書式で回転角度を指定します。角度は度数で測定され、本サンプルは値軸タイトルを 90 度回転させた列グラフを保存します。

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

[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) を使用して、値軸がカテゴリ軸とカテゴリ間またはカテゴリ目盛り上で交差するかを制御します。この設定はカテゴリ軸に適用されます。サンプルは列グラフの水平カテゴリ軸で `True` に設定し、結果を保存します。

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

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) を使用して、基になるデータを変更せずに値軸ラベルのスケールを変更します。[DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) を `Millions` に設定すると、60,000,000 が 60 と表示されます。サンプルは列グラフを作成し、垂直軸にミリオン単位を適用します。

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

正の値が数桁にわたって広がる場合、対数値軸は有用です。たとえば、あるサービスが 5 つの期間で 10、100、1,000、10,000、100,000 件のリクエストを受け取ったとします。線形スケールでは小さい値がゼロ付近に密集して見えますが、対数スケールでは等間隔が等しい比率を表すため、相対的な増加が比較しやすくなります。

値軸に対して `True` で [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) を呼び出し、[setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) で基数を選択します。これにより既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは変更されません。トレンドラインはデータに適合した別の機能です。

### **値軸と基数の選択**

折れ線または列グラフの場合、値軸は [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) が返します。水平棒グラフの場合は [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) が返します。散布図やバブルチャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、または両方を使用します。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX のチャートでは `2` から `1000`（整数）までの基数が使用可能で、`2.5` のような小数基数もサポートされています。基数 `10` の場合、10、100、1,000、10,000 といった連続するべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の自己完結型サンプルは、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、そのスライドをコピーして 2 枚目のスライドで基数 10 の対数値軸を有効にします。両方のスライドは同じデータを保持します。

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

**線形スケール（スライド 1）:** 等しい垂直距離がリクエスト数の等しい差を表します。最大値がチャートを支配し、より小さい値が区別しづらくなります。

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離が等しい比率を表します。各期間のリクエスト数は前の期間の 10 倍になるため、基数 10 のスケール上では直線的に上昇します。軸ラベルは元のリクエスト数をそのまま表示します。

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **ゼロおよび負の値の取り扱い**

対数スケールは正の値のみ表示できます。使用前にデータを確認してください。ゼロまたは負の値が意味を持つ場合は、線形スケールを維持するか、別々に表示してください。除外が分析上妥当な場合は、その理由を説明します。小さな正の数で置き換えるとデータの意味が変わるため、黙って置き換えてはいけません。対数軸の手動で設定した最小値・最大値も正の数である必要があります。

## **FAQ**

**軸が交差する位置（crossing）を数値で指定するにはどうすればよいですか？**

[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) を使用して交差動作を選択し、数値の交差位置を指定するには [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) を使用します。これらの設定により、軸交差点を適切な基準線に移動できます。

**目盛りラベルを軸に対してどのように配置できますか？**

[TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) の `Low`、`High`、`NextTo`、`None` のいずれかを使用して [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) を呼び出します。目盛り自体を制御するには、[setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) または [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) を使用します。これらはラベル位置設定とは別です。