---
title: Python でプレゼンテーションのチャート データ系列を管理する
linktitle: データ系列
type: docs
url: /ja/python-java/chart-series/
keywords:
- チャート 系列
- 系列 オーバーラップ
- 系列 カラー
- 系列 名称
- データ ポイント
- ワークブック セル
- 系列 ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、プレゼンテーションでチャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに格納します。[ChartSeries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/) は関連する値のセットを表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。[ChartCategory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartcategory/) オブジェクトはシリーズが共有するラベルまたはグルーピング値を提供します。そのため、シリーズ名、カテゴリ、ポイント値は [ChartDataCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/) オブジェクトに接続され、表示テキストとしてのみ格納されません。

典型的なカテゴリ チャートの場合、既定のワークブックは行 0 をシリーズ名、列 0 をカテゴリ名に使用し、残りのセルにシリーズ値を格納します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#getCell) に渡されるワークシート、行、列インデックスは 0 基準です。このレイアウトは既定データでチャートを作成するときに便利ですが、すべての既存チャートがこれを使用しているとは限りません。読み込んだプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズ レベルの設定 (例: [ChartSeries.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getFormat)) は、1 つのシリーズ内のすべてのポイントの既定の外観を提供します。
- データ ポイント設定 (例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getFormat)) は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動外観を決定します。シリーズとポイントの書式設定の両方が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列のオーバーラップを設定**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getOverlap) は、2D チャートでバーまたは列がどれだけ重なるかを -100 から 100 パーセントで報告します。これは親シリーズ グループ上の設定の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setOverlap) を使用します。このオプションは、グループ化されたバーまたは列を表示するチャート タイプに適用され、コンビネーション チャートの無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します：

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

## **シリーズの塗りつぶしカラーを変更**

[ChartSeries.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getFormat) を使用して、シリーズ全体の既定の塗りつぶしを設定します。ポイントに明示的な塗りつぶしがすでにある場合、その [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getFormat) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青塗りつぶしを適用します：

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

## **シリーズ名を変更**

シリーズ名はチャート データ ワークブックに格納され、通常は凡例に表示されます。クラスター化列チャート用に作成された既定のワークブックでは、セル B1 が行 0、列 1 にあり、最初のシリーズの名前が含まれています。以下の例の変数名はその構造を明示しています：

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

また、[ChartSeries.getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getName) が参照しているセルを直接更新することもできます。この方法は、既存チャートで特定の行や列を前提としないため安全です：

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

## **自動シリーズ塗りつぶしカラーを取得**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、シリーズインデックスとチャート スタイルから計算されたカラーを返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用されるカラーです。このメソッドは計算されたカラーを取得するだけで、新しい塗りつぶしを割り当てることはありません。

次の例は、既定シリーズそれぞれの自動カラーを出力します：

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

既定チャート スタイルのサンプル出力：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確なカラーはチャート スタイルとテーマに依存します。

## **シリーズの反転塗りつぶしカラーを設定**

棒、列、バブル系列では、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#setInvertIfNegative) を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値用カラーを [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で取得して割り当てます。ワークブック上の負の数値は変更せず、表示カラーだけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 がシリーズ名、列 0 がカテゴリ名、列 1 が値です：

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

1 つのポイントだけで反転を有効にするには、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択したポイントだけで有効にしています。そのポイントには負の値も割り当てて効果を確認します：

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

## **特定のデータ ポイントの値をクリア**

他のポイントを削除せずに 1 つのポイントだけを空にするには、バックエンドのワークブック セルを `None` に設定します。列チャートの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getValue) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートは空白として扱います。

次の例は、最初のシリーズの 2 番目のポイントだけをクリアします：

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

散布図は X と Y のセルが別々にあり、バブル図はサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。系列全体のポイントを保持したい場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御**

空のワークブック セルはデータ欠損を表し、`0` を含むセルは既知の数値を表します。セルを空にしたい場合は、`None` を渡して [ChartDataCell.setValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/#setValue) を呼び出します。数値のゼロは空セル設定に関わらずゼロのままです。

チャート全体に対して空セルの表示方法を選択するには、[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setDisplayBlanksAs) を使用します。この設定は空白のプロット方法を変更し、空セルをゼロまたは補完値で埋めることはありません。

次のセルフコンテインド例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 にカテゴリ ラベル、列 1 に値を使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です：

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

各出力ファイルは保存前に設定したモードを保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存してください。

以下の比較は 3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はワークブック上で常に空です：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線グラフは 3 つのモードを比較しやすいですが、棒や列のチャートは欠損カテゴリをつなぐ線がないため `Span` は上記のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図も接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズ ギャップ幅を設定**

ギャップ幅は隣接する棒または列クラスター間のスペースで、棒または列幅のパーセンテージで表されます。オーバーラップと同様に、これは個々のシリーズではなく親シリーズ グループに属します。グループに対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出します。値が大きいほどクラスター間のスペースが増え、値が小さいほど密集します。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します：

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

**どのチャート タイプがデータ 系列をサポートしますか？**

[ChartType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはデータを使用しますが、系列の値構造や設定はすべて同じではありません。例えば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブルサイズを追加します。系列タイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャート 系列グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/) は、グループ レベルのプロット設定を共有する互換系列を含みます。コンビネーション チャートは複数のグループを持つことができるため、ある系列を通して到達したグループを変更しても、チャート内のすべての系列が変更されるとは限りません。

**新規作成したチャートは既定データを含みますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addChart) がサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前に系列とカテゴリのコレクションをクリアできます。オーバーロードを使用して既定データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイント値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/) のセルを参照します。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行が整列していることを確認し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**系列全体ではなく 1 つのポイントだけをクリアするには？**

該当する値セルを `None` に設定して、ポイントのカテゴリ位置は保持しつつ空のポイントにします。シリーズ全体のポイントを削除したい場合のみ、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapointcollection/#clear) を使用してください。カテゴリも削除する場合は、すべての系列がカテゴリ コレクションに合わせて値を整列させるように更新してください。

**空のポイントはどのように表示されますか？**

表示結果はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setDisplayBlanksAs) で設定した値に依存します。対応チャートは空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションで欠損データの意味に合った設定を選択してください。完全な例とビジュアル比較は「空セルの表示を制御」を参照してください。

**負の値はどのように書式設定されますか？**

サポートされる棒、列、バブル 系列では、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) が返すカラーを設定します。個別のポイントに対しては、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で上書きできます。これらのメソッドは書式設定に影響し、数値自体は変更しません。

**系列とポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的な系列書式設定を使用するか、系列書式が未定義の場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められる系列数に上限はありますか？**

Aspose.Slides には固定された系列数上限は設けられていません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または離れすぎる場合はどうすればよいですか？**

適切な親シリーズ グループに対して [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、小さくするとクラスターが近づきます。