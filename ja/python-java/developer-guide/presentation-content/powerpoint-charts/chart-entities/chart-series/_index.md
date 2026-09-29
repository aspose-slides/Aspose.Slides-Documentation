---
title: Pythonでプレゼンテーションのチャート データ 系列を管理する
linktitle: データ系列
type: docs
url: /ja/python-java/chart-series/
keywords:
- チャート系列
- 系列のオーバーラップ
- 系列の色
- 系列名
- データポイント
- ワークブックセル
- 系列のギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、プレゼンテーション内のチャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。 [ChartSeries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/) は関連する値の集合を表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。 [ChartCategory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartcategory/) オブジェクトは、シリーズ間で共有されるラベルまたはグループ化された値を提供します。そのため、シリーズ名、カテゴリ、およびポイント値は [ChartDataCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/) オブジェクトに接続されており、表示テキストとしてだけ保存されているわけではありません。

典型的なカテゴリ チャートの場合、既定のワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズの値に使用します。 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#getCell) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトは既定データでチャートを作成する際に便利ですが、すべての既存チャートがこのレイアウトを使用しているとは限りません。読み込み済みのプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズ レベルの設定 (例: [ChartSeries.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getFormat)) は、1 つのシリーズ内のすべてのポイントの既定の外観を提供します。
- データ ポイント設定 (例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getFormat)) は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定が両方存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列のオーバーラップを設定する**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getOverlap) は、2D チャートで棒または列がどの程度重なるかを -100 から 100 パーセントの範囲で報告します。これは、親シリーズ グループ上の設定の読み取り専用の投影です。互換性のあるすべてのシリーズのオーバーラップを更新するには、[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setOverlap) を使用します。このオプションは、グループ化された棒または列を表示するチャート タイプに適用され、組み合わせチャート内の無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

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

![The series overlap](series_overlap.png)

## **シリーズの塗りつぶし色を変更する**

[ChartSeries.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getFormat) を使用して、シリーズ全体の既定の塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既にある場合、その [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getFormat) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青色塗りつぶしを適用します。

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

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化された列チャート用に作成されたデフォルト ワークブックでは、セル B1 が行 0、列 1 にあり、最初のシリーズ名が格納されています。以下の例の変数は、その構造を明示的に示しています。

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

既に [ChartSeries.getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getName) が参照しているセルを更新することもできます。このアプローチは、既存のチャートで特定の行や列を前提としないため安全です。

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

## **自動シリーズ塗りつぶし色を取得する**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズ塗りつぶしが明示的に定義されていない場合に使用される色です。このメソッドを呼び出すと計算された色が取得されますが、新しい塗りつぶしは割り当てられません。

次の例は、各既定シリーズの自動色を出力します。

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

既定チャート スタイルのサンプル出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **チャート系列の反転塗りつぶし色を設定する**

棒、列、バブル 系列の場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#setInvertIfNegative) を使用して負の値を別の塗りつぶしで表示できます。通常の系列塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で指定します。ワークブック内の負の数値は変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されています。

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

1 つのポイントだけに反転を有効にするには、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、シリーズ全体の反転を無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てているため、効果が確認できます。

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

1 つのポイントだけを空にしたい場合は、対応するワークブック セルを `None` に設定します。列チャートの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getValue) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートは空白値設定に従ってその値を空白として扱います。

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

散布図は X と Y のセルが別々に使用され、バブル チャートはサイズセルも使用します。削除したい値が格納されているセルだけをクリアしてください。系列内の他のポイントを保持したままにしたい場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御する**

値が含まれる非表示セルは空セルとは別のケースです。非表示のワークシート行や列のデータを含めるか除外するかについては、[Include Data from Hidden Rows and Columns](/slides/ja/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータが欠落していることを表し、`0` が入っているセルは既知の数値を表します。セルを空にしたい場合は、`None` を渡して [ChartDataCell.setValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#setValue) を呼び出します。数値ゼロはブランク セル設定に関係なくゼロのままです。

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setDisplayBlanksAs) を使用して、チャートが空セルをどのように表示するかを選択できます。この設定はチャート全体に適用され、空白をプロットする方法を変更しますが、空セルにゼロや補間値を自動で入れることはありません。

次の自己完結型サンプルは、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベルに、列 1 を値に使用し、行 0 にシリーズ名を格納します。最終データは `10, 20, empty, 30, 40` です。

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

各出力ファイルには保存前に設定されたモードが記録されます: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回だけ保存してください。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのワークブックで空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

見た目の効果はチャート タイプに依存します。折れ線グラフは 3 つのモードを比較しやすいですが、棒や列のチャートでは欠落したカテゴリをつなぐ線がないため `Span` は上記のような接続セグメントを生成できません。欠落した列とゼロ高さの列は見た目が似ていることがあります。同様に、マーカーだけの散布図には接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるわけではないので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は隣接する棒または列クラスタ間のスペースを、棒または列の幅のパーセンテージで表したものです。オーバーラップと同様に、ギャップ幅は個々のシリーズではなく親シリーズ グループに属します。グループ全体に対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出します。値を大きくするとクラスタ間の間隔が広がり、値を小さくすると密集します。

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

**どのチャート タイプがデータ 系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、系列ごとに同じ値構造や設定があるわけではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブルサイズを追加します。系列のタイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャート 系列グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のある系列を含みます。組み合わせチャートは複数のグループを含むことができるため、ある系列を介して取得したグループを変更しても、チャート内のすべての系列が必ずしも変更されるわけではありません。

**新しく作成したチャートには既定データが含まれますか？**

はい。既定では、[ShapeCollection.addChart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addChart) がサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データセットを追加する前に系列とカテゴリのコレクションをクリアできます。オーバーロードを使用すれば、既定データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

系列名、カテゴリ ラベル、データ ポイントの値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ 行と系列 値 行が揃うように配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするには？**

該当する値セルを `None` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。系列全体のポイントをすべて削除したい場合のみ、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapointcollection/#clear) を使用してください。カテゴリも削除する場合は、すべての系列の値がカテゴリ コレクションと整合するように更新してください。

**空白のポイントはどのように表示されますか？**

表示はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setDisplayBlanksAs) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションのデータ欠損の意味に合った設定を選択してください。完全なサンプルと視覚的比較については、[空セルの表示を制御する](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、列、バブル 系列の場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) が返す色を設定します。個々のポイントに対しては、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で動作を上書きできます。これらのメソッドは書式設定に影響しますが、保存されている数値そのものは変更しません。

**シリーズとポイントの両方が書式設定された場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは、明示的にシリーズの書式が定義されていればその書式を、定義されていなければ自動的なチャート スタイルとテーマを使用します。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められる系列の数に上限はありますか？**

Aspose.Slides には固定された系列数上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、描画時間、およびチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または離れすぎる場合は何を変更すべきですか？**

適切な親シリーズ グループに対して [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスタ間のスペースが広がり、値を小さくするとクラスタが近づきます。