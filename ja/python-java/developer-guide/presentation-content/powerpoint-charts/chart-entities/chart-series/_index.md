---
title: Pythonでプレゼンテーションのチャート系列を管理する
linktitle: データ系列
type: docs
url: /ja/python-java/chart-series/
keywords:
- チャート系列
- 系列の重なり
- 系列の色
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
description: "Aspose.Slides for Python via Java を使用して、プレゼンテーション内のチャート系列、データポイント、ワークブックセル、書式設定、重なり、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。[ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) は関連する値のセットを表し、系列内の各 [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。[ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) オブジェクトは系列が共有するラベルまたはグループ化値を提供します。そのため、系列名、カテゴリ、およびポイントの値は、表示テキストだけでなく [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートの場合、デフォルト ワークブックは行 0 を系列名に、列 0 をカテゴリ名に使用し、残りのセルを系列値に使用します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこれを使用しているとは限りません。ロードされたプレゼンテーションの場合、ワークブックの値を変更する前に、系列、カテゴリ、およびデータ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- 系列レベルの設定（例: [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)）は、1 つの系列内のすべてのポイントのデフォルトの外観を提供します。
- データポイントの設定（例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)）は、1 つのポイントの系列外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) に属する互換性のある系列に適用されます。重なりやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) を使用してグループにアクセスします。

明示的なポイントまたは系列の塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。系列とポイントの両方の書式設定が存在する場合、そのポイントに対してはポイントの書式設定が優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列の重なりを設定する**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) は、2D チャートで棒または列がどれだけ重なるかを -100% から 100% の範囲で報告します。これは親系列グループの設定の読み取り専用投影です。対象グループ内のすべての互換系列を更新するには [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) を使用します。このオプションはグループ化された棒や列を表示するチャート種類に適用され、コンビネーション チャートの無関係な系列グループには影響しません。

以下の例は、最初の系列を含むグループの重なりを設定します：

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

    # 新しいチャートにはサンプル系列、カテゴリ、および値が含まれています。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![The series overlap](series_overlap.png)

## **系列の塗りつぶしカラーを変更する**

[ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) を使用して、系列全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既に設定されている場合、[ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) の設定がそのポイントの系列塗りつぶしを上書きします。

以下の例は、最初の系列に単色の青色塗りつぶしを適用します：

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

結果：

![The color of the series](series_color.png)

## **系列名を変更する**

系列名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスタ化列チャートのデフォルト ワークブックでは、セル B1 が行 0、列 1 にあり、最初の系列の名前が格納されています。以下の例の名前付き変数は、その構造を明示しています：

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

また、[ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) が既に参照しているセルを更新することもできます。この方法は既存チャートで特定の行や列を想定しないので安全です：

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

結果：

![The series name](series_name.png)

### **複数セルから名前を作成する系列**

製品名と報告期間が別々のワークブック セルに格納されている場合、複合系列名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を結合して、両方のセルにリンクされた単一の系列名にできます。

[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) を使用して名前範囲を取得し、そのコレクションを [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) に渡します。`skipHiddenCells` 引数は非表示セルを含めるかどうかを制御します：`True` は除外し、`False` は含めます。この例では `False` を使用して名前範囲のすべてのセルを含めています。

以下の例は、1 系列と 2 データポイントを持つプレゼンテーションを作成します。セル B1:C1 が系列名のみを供給し、A2:A3 がカテゴリ ラベル、B2:B3 が数値を供給します。

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

    # これらの 2 つのセルが系列名を供給します。
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # 別々のセルがカテゴリと数値データポイントを供給します。
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

結果として得られる系列名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例ではこの名前が 1 つのエントリとして両列に表示されます。以下の画像が結果を示しています：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動系列塗りつぶしカラーを取得する**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、系列インデックスとチャートスタイルから計算されたカラーを返します。これは系列塗りつぶしが明示的に定義されていない場合に使用されるカラーです。メソッドを呼び出すと計算されたカラーが取得されますが、新しい塗りつぶしは設定されません。

以下の例は、各デフォルト系列の自動カラーを出力します：

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

デフォルトチャートスタイルの例出力：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確なカラーはチャートスタイルとテーマに依存します。

## **系列の反転塗りつぶしカラーを設定する**

棒、列、バブル系列では、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) を使用して負の値を別の塗りつぶしで表示できます。通常の系列塗りつぶしを単色に設定し、反転を有効にし、負の値用のカラーを [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で指定します。負の数値はワークブック内では変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が入ります：

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

結果：

![The inverted solid fill color](inverted_solid_fill_color.png)

ポイント単位で反転を有効にするには [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、系列全体の反転は無効にし、選択したポイントだけ反転を有効にしています。そのポイントには負の値も割り当てて効果を確認します：

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

他のポイントを残したまま 1 ポイントだけを空にしたい場合、その裏付けワークブック セルを `None` に設定します。列チャートの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートはブランク設定に従ってその値を空として扱います。

以下の例は、最初の系列の 2 番目のポイントだけをクリアします：

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

散布図は X と Y のセルが別々に、バブルチャートはサイズセルも使用します。削除したい値が入っているセルだけをクリアしてください。ポイントをすべて削除したいとき以外は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) は使用しないでください。このメソッドはコレクション内のすべてのデータポイントを削除します。

## **空セルの表示を制御する**

値が入っている非表示セルは、空セルとは別扱いです。非表示の行や列からデータを含めるか除外する方法は、[Include Data from Hidden Rows and Columns](/slides/ja/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータが欠損していることを表し、`0` が入っているセルは既知の数値を表します。セルを空にしたい場合は、`None` を渡して [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) を呼び出します。数値のゼロは空セル設定に関係なくゼロのままです。

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、ワークブックのセルをゼロや補間値で埋めることはありません。

以下のセルフコンテインド例は、1 系列の折れ線グラフを作成し、3 日目の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 にカテゴリ ラベル、列 1 に値、行 0 に系列名を使用します。最終データは `10, 20, empty, 30, 40` です。

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

    # Day 3 を本当に空にしたまま、カテゴリとデータポイントは保持します。
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

各出力ファイルは保存前に設定されたモードを名前に保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存してください。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。3 日目は常にワークブックで空です：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャートの種類によって異なります。折れ線グラフは 3 つのモードを比較しやすいですが、棒や列のチャートでは欠損カテゴリを結ぶ線がないため、`Span` は上記のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図でも接続線はありません。すべてのチャートタイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **系列ギャップ幅を設定する**

ギャップ幅は隣接する棒または列クラスター間のスペースで、棒または列幅のパーセンテージで表されます。重なりと同様に、これは個々の系列ではなく親系列グループに属します。グループに対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密集します。

以下の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します：

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

結果：

![The gap width](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、系列の値構造や設定は同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。系列タイプに合ったデータポイント作成メソッドを使用してください。重なりやギャップ幅などのオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャート 系列 グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) は、同じグループレベルのプロット設定を共有する互換性のある系列を含みます。コンビネーション チャートは複数のグループを含むことができるため、ある系列を通じて取得したグループを変更しても、必ずしもチャート内のすべての系列が変更されるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) がサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データセットを追加する前に系列とカテゴリ コレクションの両方をクリアできます。オーバーロードを使用すればデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

系列名、カテゴリ ラベル、データポイントの値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行と系列値行を整列させ、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**系列全体ではなく 1 ポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `None` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) はその系列のすべてのポイントを削除したいときにのみ使用してください。カテゴリも削除する場合は、すべての系列がカテゴリ コレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

表示はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションの目的に合った設定を選択してください。完全な例とビジュアル比較は [空セルの表示を制御する](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、列、バブル 系列については、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で返されるカラーを設定します。個々のポイントに対しては [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で上書きできます。これらのメソッドは書式設定に影響しますが、保存されている数値には影響しません。

**系列とポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは、明示的な系列書式設定があればそれを使用し、系列書式設定が未定義の場合は自動的なチャート スタイルとテーマが適用されます。重なりやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定を上書きしません。

**チャートに含められる系列の数に上限はありますか？**

Aspose.Slides には固定された系列数上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

適切な親系列グループに対して [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、小さくするとクラスターが近づきます。