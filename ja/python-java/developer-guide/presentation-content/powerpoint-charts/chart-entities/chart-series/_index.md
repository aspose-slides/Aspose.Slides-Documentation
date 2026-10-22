---
title: Python でのプレゼンテーションにおけるチャート データ シリーズの管理
linktitle: データ シリーズ
type: docs
url: /ja/python-java/chart-series/
keywords:
- チャート シリーズ
- シリーズ オーバーラップ
- シリーズ 色
- シリーズ 名
- データ ポイント
- ワークブック セル
- シリーズ ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、プレゼンテーションにおけるチャート シリーズ、データ ポイント、ワークブック セル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートは描画された値をワークブックのセルに保存することも、数値リテラルとして直接保存することもできます。![ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) は関連する値のセットを表し、![ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) はそのシリーズ内の点を表します。![ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) オブジェクトはシリーズ間で共有されるラベルまたはグループ化値を提供します。デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、および点の値はチャート ワークブックの ![ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) オブジェクトから取得されます。

典型的なカテゴリ チャートでは、デフォルト ワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。![ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこのレイアウトを使用しているとは限りません。ロードしたプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には 3 つのスコープがあります。

- シリーズ レベルの設定は、![ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) のように、1 つのシリーズ内のすべての点に対するデフォルトの外観を提供します。
- データ ポイント設定は、![ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) のように、特定の点に対してシリーズの外観を上書きします。
- グループ設定は、同じ ![ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) に属する互換シリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、![ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスします。

明示的な点またはシリーズの塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズと点の書式設定が両方存在する場合、点の書式設定がその点に対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **数値リテラルを使用してシリーズ値を設定する**

シリーズの値がアプリケーション データや計算結果から取得され、ワークシートのセル参照が不要な場合は、数値リテラルを使用します。各点の ![getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) 結果を ![setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble) で割り当てる前に、![setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) に ![DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) を指定します。

コレクション設定は、そのシリーズ内のすべての点値のソース タイプを制御します。各点値の ![getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) メソッドは選択されたタイプを報告します。コレクション設定を変更してタイプを変更してください。`Worksheet` の場合は ![getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) で参照セルにアクセスします。`DoubleLiterals` の場合は ![getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) または `setAsLiteralDouble` を使用して数値を直接読み書きします。

以下の例は、デフォルトのシリーズとカテゴリを持つ縦棒グラフを作成し、最初のシリーズの既存点に 10、20、… と計算された値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

点の値ソース タイプは、![ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) とは別物で、チャートの内部または外部ワークブック構成を識別します。数値リテラルを使用しても、埋め込みワークブック自体は削除されません。この例では、カテゴリ ラベル、シリーズ名、および他のシリーズのためにワークブックは引き続き利用可能です。ワークブックの管理については、[Chart Workbook](/slides/ja/python-java/chart-workbook/) を参照してください。

散布図やバブル チャートでは、![setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) と ![setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) を使用して、![getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) と ![getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) のソースを選択します。バブル チャートでは、![setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) も使用して、![getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) のソースを設定します。各対象ソースを `DoubleLiterals` に設定し、`setAsLiteralDouble` メソッドで数値を割り当ててください。

## **チャートシリーズのオーバーラップを設定する**

![ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) は、2D チャートにおける棒または列のオーバーラップ率を -100 から 100 パーセントで返します。これは親シリーズ グループの設定の読み取り専用投影です。![ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) を使用して、そのグループ内のすべての互換シリーズのオーバーラップを更新します。このオプションは、グループ化された棒や列を表示するチャート タイプに適用され、組み合わせチャートで無関係なシリーズ グループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # 新しいチャートにはサンプルシリーズ、カテゴリ、および値が含まれています。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The series overlap](series_overlap.png)

## **シリーズの塗りつぶし色を変更する**

![ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。点に明示的な塗りつぶしが既に設定されている場合は、![ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) の設定がその点のシリーズ塗りつぶしを上書きします。

以下の例は、最初のシリーズに単色の青塗りつぶしを適用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The color of the series](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャート データ ワークブックに格納され、通常は凡例に表示されます。クラスタ化縦棒チャート用にデフォルトで作成されたワークブックでは、セル B1 が行 0、列 1 にあり、最初のシリーズ名が格納されています。次の例の変数はその構造を明示的に示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

また、![ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) が参照しているセルを直接更新することもできます。このアプローチは、既存チャートで特定の行や列を前提としないため安全です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The series name](series_name.png)

### **複数セルから名前を作成するシリーズ**

製品名と報告期間が別々のワークブック セルに格納されている場合、複合シリーズ名が役立ちます。例えば、B1 の `Product A` と C1 の `2026` を組み合わせて、両方のソース セルにリンクされた単一のシリーズ名にできます。

![ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) を使用して名前範囲を取得し、そのコレクションを ![ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) に渡します。`skipHiddenCells` 引数は非表示セルを除外するかどうかを制御します: `True` は除外し、`False` は含めます。この例では `False` を使用して名前範囲のすべてのセルを含めています。

次の例は、1 つのシリーズと 2 つのデータ ポイントを持つプレゼンテーションを作成します。セル B1:C1 がシリーズ名のみを提供し、A2:A3 がカテゴリ ラベル、B2:B3 が数値を提供します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # これら2つのセルがシリーズ名を提供します。
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # 個別のセルがカテゴリと数値データポイントを提供します。
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果のシリーズ名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例は両方の列に対して 1 つのエントリとして表示されます。下の画像が結果を示しています。

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動シリーズ塗りつぶし色を取得する**

![ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズ塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すだけで計算された色を取得し、新しい塗りつぶしは割り当てられません。

以下の例は、各デフォルトシリーズの自動色を出力します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

デフォルトのチャート スタイルに対するサンプル出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **シリーズの負の塗りつぶし色を反転させる**

棒、縦棒、バブル シリーズでは、![ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値の色を ![ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で指定します。ワークブック内の負の数値は変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 つのシリーズに置き換えます。ワークシートの行 0 がシリーズ名、列 0 がカテゴリ名、列 1 が値を保持します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The inverted solid fill color](inverted_solid_fill_color.png)

ポイント単位で反転を有効にするには、![ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択したポイントのみ反転を有効にしています。そのポイントには負の値も割り当てられ、効果が確認できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **特定のデータ ポイントの値をクリアする**

他のポイントを削除せずに 1 点だけ空にしたい場合は、対応するワークブック セルを `None` に設定します。縦棒チャートでは、プロットされた値は ![ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) を通じて取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空白として扱います。

次の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

散布図は X と Y のセルが別々で、バブルチャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。コレクション全体を削除したいとき以外は、![ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。

## **空セルの表示を制御する**

値が入っている非表示セルは、空セルとは別の扱いです。非表示の行や列のデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータが欠落していることを表し、`0` が入っているセルは既知の数値を表します。![ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) に `None` を渡すとセルを空にできます。数値のゼロはブランク設定に関係なくゼロのままです。

![Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、ワークブック セル自体にゼロや補間値を入れることはありません。

次の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。![ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベル、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Day 3 を本当に空にし、カテゴリとデータポイントは保持します。
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

各出力ファイルは保存前に設定したモードを保持します: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存してください。

以下の比較は 3 つのファイルで同じデータがどのように表示されるかを示しています。すべてのケースで Day 3 はワークブックで空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

見た目の効果はチャート タイプに依存します。折れ線グラフは 3 つのモードを比較しやすいですが、棒や縦棒グラフは欠損カテゴリの間に線がないため、`Span` は接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図も接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限りませんので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は隣接する棒または列クラスタ間のスペースで、棒や列の幅に対するパーセンテージで表されます。オーバーラップと同様に、これは個々のシリーズではなく親シリーズ グループに属します。グループ全体に対して一度だけ ![ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスタ間のスペースが広がり、値を小さくすると密集します。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![The gap width](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ シリーズをサポートしていますか？**

![ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 列挙で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズごとの値構造や設定は同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブルサイズを追加します。シリーズ タイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列グループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

![ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) は、グループ レベルのプロット設定を共有する互換シリーズを含みます。組み合わせチャートでは複数のグループを持つことができるため、あるシリーズを通じて取得したグループ設定が必ずしもチャート内のすべてのシリーズに影響するわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、![ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) はサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイントの値はすべて ![ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) のセルを参照します。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行が整合するようにし、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 点だけをクリアするにはどうすればよいですか？**

該当する値セルを `None` に設定して、ポイントのカテゴリ位置は保持したまま空点として残します。ポイント全体を削除したいときは、![ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) を使用してください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリ コレクションと整合するように更新してください。

**空点はどのように表示されますか？**

表示結果はチャート タイプと ![Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションに合わせて適切な設定を選択してください。完全な例とビジュアル比較については、[Control the Display of Empty Cells](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、縦棒、バブル シリーズでは、![ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、![ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) が返す色を設定します。個々のポイントについては、![ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で動作を上書きできます。これらのメソッドは書式設定に影響し、保存されている数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは、明示的なシリーズ書式設定がある場合はそれを使用し、シリーズ書式設定が未定義の場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイント レベルの書式設定の上書きとはなりません。

**チャートに含められるシリーズの数に上限はありますか？**

Aspose.Slides には固定されたシリーズ数上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、描画時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または離れすぎる場合はどうすべきですか？**

適切な親シリーズ グループに対して ![ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスタ間のスペースが広がり、小さくするとクラスタがより近くなります。