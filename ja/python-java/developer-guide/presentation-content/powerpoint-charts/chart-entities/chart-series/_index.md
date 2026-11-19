---
title: Pythonでプレゼンテーションのチャート データ系列を管理
linktitle: データ系列
type: docs
url: /ja/python-java/chart-series/
keywords:
- チャート系列
- 系列オーバーラップ
- 系列色
- 系列名
- データポイント
- ワークブックセル
- 系列ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、プレゼンテーションでチャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、および負の値を管理する方法を学びます。"
---
## **概要**

チャートは、プロットされた値をワークブックのセルに保存するか、数値リテラルとして直接保存できます。[ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) は関連する値のセットを表し、各[ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) はそのシリーズ内のポイントを表します。[ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) オブジェクトは、シリーズが共有するラベルやグループ化値を提供します。デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、ポイント値はチャートワークブックの[ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) オブジェクトを使用します。

典型的なカテゴリチャートの場合、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズの値に使用します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルトデータでチャートを作成する際に便利ですが、すべての既存チャートが同じ構造を使用しているとは限りません。ロードされたプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

Chart 設定には以下の 3 つのスコープがあります：

- 系列レベルの設定（例: [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)）は、1 つの系列内のすべてのポイントのデフォルト外観を提供します。
- データポイントの設定（例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)）は、特定のポイントに対して系列の外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) に属する互換系列全体に適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスしてください。

明示的にポイントまたは系列の塗りつぶしが設定されていない場合、チャートスタイルとテーマが自動的な外観を決定します。系列とポイントの両方に書式設定が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャートシリーズ PowerPoint](chart-series-powerpoint.png)

クラスタ化シリンダー チャートの場合、[3D 系列タイプまたはバー形状の変更](/slides/ja/python-java/3d-chart/#change-the-3d-series-type-and-bar-shape) が最初の系列に与える影響を確認してください。

## **数値リテラルを使用したシリーズ値の設定**

シリーズの値がアプリケーション データや計算結果から来ており、ワークシートセル参照が不要な場合は、数値リテラルを使用します。各ポイントの [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) 結果を [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble) で設定する前に、[setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) に [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) を渡してください。

コレクション設定はその系列内のすべてのポイント値のソース タイプを制御します。各ポイント値の [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) メソッドは選択されたタイプを返します。コレクション設定を変更してタイプを切り替えてください。`Worksheet` の場合は [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) で参照セルにアクセスします。`DoubleLiterals` の場合は [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) または `setAsLiteralDouble` を使用して数値を直接読み書きします。

次の例は、デフォルトの系列とカテゴリを持つ縦棒グラフを作成し、最初の系列の既存ポイントに 10、20… と計算された値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

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

ポイント値のソース タイプは、チャートの内部または外部ワークブック構成を示す [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) とは別です。数値リテラルを使用しても、埋め込みワークブック自体は削除されません。この例では、カテゴリ ラベル、系列名、他の系列のためにワークブックは引き続き利用可能です。ワークブック管理の詳細は [Chart Workbook](/slides/ja/python-java/chart-workbook/) を参照してください。

散布図やバブル グラフの場合、[setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) と [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) を使用して [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) および [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) のソースを選択します。バブル グラフはさらに [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) を使用して [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) のソースを設定します。対象となる各ソースを `DoubleLiterals` に設定し、その値の `setAsLiteralDouble` メソッドで数値を割り当ててください。

## **チャート系列のオーバーラップの設定**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) は、2D チャートにおける棒や縦棒のオーバーラップ率（-100〜100％）を返します。これは親系列グループの設定の読み取り専用投影です。系列グループ全体のオーバーラップを更新するには、[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) を使用してください。このオプションは、グループ化された棒や縦棒を表示するチャートタイプに適用され、コンビネーション チャートの無関係な系列グループには影響しません。

次の例は、最初の系列を含むグループのオーバーラップを設定します。

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

    # 新しいチャートにはサンプル系列、カテゴリ、値が含まれています。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![系列のオーバーラップ](series_overlap.png)

## **系列の塗りつぶし色の変更**

[ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) を使用して、系列全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしが設定されている場合、その [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) が系列の塗りつぶしを上書きします。

次の例は、最初の系列に単色の青色塗りつぶしを適用します。

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

![系列の色](series_color.png)

## **系列名の変更**

系列名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスタ化縦棒チャート用に作成されたデフォルト ワークブックでは、セル B1（行 0、列 1）が最初の系列の名前を保持しています。以下の例では、その構造を明示する変数名が使用されています。

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

また、[ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) が参照しているセルを直接更新することもできます。この方法は、既存チャートの特定の行・列を前提としないため安全です。

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

![系列名](series_name.png)

### **複数セルから構成された名称の系列を作成する**

製品名と報告期間が別々のワークブックセルに格納されている場合、合成系列名が便利です。例えば、B1 の `Product A` と C1 の `2026` を結合して、両方のセルがソースにリンクしたまま単一の系列名にできます。

[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) で名前範囲を取得し、そのコレクションを [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) に渡します。`skipHiddenCells` 引数で非表示セルを除外するかどうかを指定できます：`True` は除外、`False` は含めます。この例では `False` を使用して名前範囲のすべてのセルを含めています。

次の例は、1 系列と 2 データポイントを持つプレゼンテーションを作成します。セル B1:C1 が系列名、A2:A3 がカテゴリ ラベル、B2:B3 が数値です。

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

    # これら 2 つのセルが系列名を供給します。
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # 別個のセルがカテゴリと数値データポイントを供給します。
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

結果として得られる系列名は `Product A 2026`（2 つのセル値の間にスペースが入ります）。凡例ではこの 1 つのエントリとして表示されます。以下の画像が結果を示しています。

![列グラフ（北と南の値）と合成系列名 Product A 2026 が凡例に表示されたもの](composite_series_name.png)

## **自動系列塗りつぶし色の取得**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、系列インデックスとチャートスタイルから計算された色を返します。これは、系列の塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すだけで色を取得でき、塗りつぶしは設定されません。

次の例は、デフォルト系列ごとの自動色を出力します。

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

デフォルトのチャートスタイルの場合のサンプル出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャートスタイルとテーマに依存します。

## **系列の負の値に対する塗りつぶしの反転設定**

棒、縦棒、バブル 系列では、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) を使用して負の値を別の塗りつぶしで表示できます。通常の系列塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で指定します。負の数値自体はワークブック内で変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が入ります。

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

![反転した単色塗りつぶしの色](inverted_solid_fill_color.png)

1 ポイントだけに反転を適用するには、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、系列全体の反転は無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てて効果を確認します。

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

## **特定のデータポイントの値をクリアする**

ポイントだけを空にし、他のポイントを残すには、バックアップ用ワークブックセルを `None` に設定します。縦棒チャートの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空として扱います。

次の例は、最初の系列の 2 番目のポイントだけをクリアします。

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

散布図は X と Y のセルが別々にあり、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。系列全体のポイントを削除したい場合以外は [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。このメソッドはコレクション内のすべてのデータポイントを削除します。

## **空セルの表示制御**

値を含む非表示セルは、空セルとは別のケースです。非表示の行や列からデータを含めるか除外する方法については、[Include Data from Hidden Rows and Columns](/slides/ja/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブックセルはデータ欠損を表し、`0` を含むセルは既知の数値を表します。`None` を渡して [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) を呼び出すとセルが空になります。数値のゼロはブランク設定に関係なくゼロのままです。

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白をプロットする方法を変えますが、ワークブックセル自体にゼロや補間値を埋め込むことはありません。

次の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアした上で、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベル、列 1 を値に使用し、行 0 に系列名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

    # Day 3 を実際に空のままにし、カテゴリとデータポイントは保持します。
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

各出力ファイルは保存前に設定したモードを保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つだけ保存したい場合は、目的のモードを設定してプレゼンテーションを一度だけ保存してください。

以下の比較は 3 つのファイルすべてで同じデータを示しています。Day 3 のセルはすべて空です。

![折れ線グラフ（同一データ）: Gap は Day 3 でラインを切断、Zero はラインをゼロにし、Span は Day 2 から Day 4 を接続](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線グラフは 3 つのモードを簡単に比較できますが、棒や縦棒グラフは欠損したカテゴリを接続するラインがないため、`Span` は上図のような接続部分を生成できません。欠損した列とゼロ高さの列は見た目が似ることがあります。マーカーのみの散布図もラインがないため同様です。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **系列ギャップ幅の設定**

ギャップ幅は隣接する棒または縦棒クラスタ間のスペースで、棒または縦棒幅のパーセンテージで表されます。オーバーラップと同様に、これは系列ではなく親系列グループに属します。グループ全体に対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスタ間の間隔が広がり、値を小さくすると密集します。

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

![ギャップ幅](gap_width.png)

## **系列線の表示／非表示**

系列線はチャートの関連部分を視覚的に接続します。サポートされているスタック棒および OfPie チャートで、[ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSeriesLines) を使用して表示または非表示にできます。2 次元スタック棒および縦棒チャートでは、カテゴリ間のスタック境界を接続します。Pie of Pie と Bar of Pie では、メイン プロットとサブ プロットを接続します。この設定は他のチャート タイプの一般的なコネクタではありません。

グループは [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) を介して取得します。この設定はグループ内のすべての系列に適用されます。[ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#hasSeriesLines) は読み取り専用で、親グループの設定を反映します。設定を変更するにはグループのセッターを呼び出してください。

次の例は、デフォルト データを持つ [PieOfPie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#PieOfPie) チャートを作成し、系列線を有効にしたバージョンと無効にしたバージョンの 2 つのプレゼンテーションを保存して比較します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400)
    series = chart.getChartData().getSeries().get_Item(0)
    series_group = series.getParentSeriesGroup()

    series_group.setSeriesLines(True)
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx)

    series_group.setSeriesLines(False)
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 系列線 有効 | 系列線 無効 |
| --- | --- |
| ![系列線が有効な Pie of Pie チャート](series_lines_enabled.png) | ![系列線が無効な Pie of Pie チャート](series_lines_disabled.png) |
| 2 本の線がメイン パイをサブ パイに接続します。 | 2 本のパイは表示されたままですが、接続線は非表示になります。 |

系列線は、データ ラベルのリーダー線（ラベルをデータポイントに接続）、グリッド線（軸上の間隔を示す）、および折れ線グラフのデータ値を表す線とは異なります。この設定はそれらの要素を制御しません。

## **FAQ**

**どのチャート タイプがデータ系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはデータを使用しますが、系列ごとに値の構造や設定が異なります。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。系列タイプに合ったデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または縦棒グループにのみ適用されます。

**チャート系列グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換系列を含みます。コンビネーション チャートは複数のグループを保持できるため、ある系列を介して取得したグループを変更しても、チャート内のすべての系列が必ずしも変わるわけではありません。

**新しく作成したチャートはデフォルト データを含んでいますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) がサンプル系列、カテゴリ、値を作成します。これらのセルを編集したり、完全にカスタム データ セットを追加する前に系列とカテゴリのコレクションをクリアしたりできます。オーバーロードを使用すれば、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

系列名、カテゴリ ラベル、データポイントの値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを作成する場合は、各ポイントが意図したカテゴリの下にプロットされるように、カテゴリ 行と系列値 行を揃えて配置してください。

**系列全体ではなく 1 ポイントだけをクリアするには？**

対象の値セルを `None` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。系列全体のポイントを削除したいときは [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) を使用してください。このメソッドはその系列のすべてのデータポイントを削除します。

**空のポイントはどのように表示されますか？**

表示はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションの欠損データの意味に合う設定を選択してください。完全な例とビジュアル比較は [空セルの表示制御](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、縦棒、バブル 系列では、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) が返す色を設定します。個別のポイントに対しては [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で動作を上書きできます。これらのメソッドは書式設定に影響し、数値自体は変更しません。

**系列とポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的な系列書式設定、または系列書式が未定義の場合は自動的なチャートスタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定を上書きしません。

**チャートに含められる系列の数に上限はありますか？**

Aspose.Slides には固定された系列数の上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

適切な親系列グループに対して [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスタ間のスペースが広がり、値を小さくするとクラスタが近くなります。