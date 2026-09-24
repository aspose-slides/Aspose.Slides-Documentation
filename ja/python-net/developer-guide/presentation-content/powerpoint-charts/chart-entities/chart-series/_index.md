---
title: Python でプレゼンテーションのチャート データ シリーズを管理
linktitle: データシリーズ
type: docs
url: /ja/python-net/chart-series/
keywords:
- チャートシリーズ
- シリーズ オーバーラップ
- シリーズの色
- カテゴリの色
- シリーズ名
- データポイント
- シリーズ間ギャップ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python を使用してプレゼンテーションでチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに格納します。 [ChartSeries](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/) は関連する値のセットを表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。 [ChartCategory](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartcategory/) オブジェクトはシリーズが共有するラベルまたはグループ化値を提供します。したがって、シリーズ名、カテゴリ、およびポイントの値は、表示テキストとしてだけでなく、[ChartDataCell](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートでは、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に使用し、残りのセルにシリーズ値を格納します。[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこれを使用しているとは限りません。読み込んだプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

Chart settings have three different scopes:

- Series-level settings, such as [ChartSeries.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/format/), provide the default appearance for all points in one series.
- Data-point settings, such as [ChartDataPoint.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/format/), override the series appearance for one point.
- Group settings apply to compatible series that belong to the same [ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/). Access the group through [ChartSeries.parent_series_group](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/parent_series_group/) when you need to set options such as overlap or gap width.

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの両方の書式設定が存在する場合、そのポイントに対してはポイントの書式設定が優先されます。

![チャートシリーズ（PowerPoint）](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップを設定**

[ChartSeries.overlap](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/overlap/) は、2D チャートにおける棒または列のオーバーラップ率（-100%〜100%）を示します。これは親シリーズ グループの設定の読み取り専用の投影です。グループ内のすべての互換シリーズを更新するには、[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/overlap/) を設定します。このオプションは、グループ化された棒や列を表示するチャートタイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 新しいチャートにはサンプルのシリーズ、カテゴリ、値が含まれています。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶし色を変更**

[ChartSeries.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/format/) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしがすでに設定されている場合は、その [ChartDataPoint.format] 設定がそのポイントのシリーズ塗りつぶしを上書きします。

以下の例は、最初のシリーズに単色の青塗りつぶしを適用します:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![シリーズの色](series_color.png)

## **シリーズ名を変更**

シリーズ名はチャート データ ワークブックに格納され、通常は凡例に表示されます。クラスタ化された縦棒チャート用のデフォルト ワークブックでは、セル B1（行 0、列 1）に最初のシリーズ名が格納されています。以下の例の名前付き定数は、その構造を明示的に示しています:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

また、[ChartSeries.name] がすでに参照しているセルを更新することもできます。この方法により、既存チャートで特定の行や列を前提とせずに済みます:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![シリーズ名](series_name.png)

## **自動シリーズ塗りつぶし色を取得**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すと計算された色を取得しますが、新しい塗りつぶしは設定されません。

以下の例は、デフォルトの各シリーズの自動色を出力します:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

デフォルトのチャート スタイルの例出力:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確な色はチャート スタイルとテーマによって決まります。

## **チャートシリーズの反転塗りつぶし色を設定**

棒、縦棒、バブルシリーズでは、[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/invert_if_negative/) を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) で負の値の色を指定します。負の数値はワークブック内では変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャート データを 1 つのシリーズに置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されます:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![反転した単色塗りつぶし色](inverted_solid_fill_color.png)

[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) を使用して、個々のポイントに対して反転を有効にできます。以下の例では、シリーズ全体の反転は無効にし、選択したポイントのみ反転を有効にしています。そのポイントには負の値も割り当てているので、効果が確認できます:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **特定のデータ ポイントの値をクリア**

他のポイントを削除せずに 1 つのポイントを空にするには、その裏付けとなるワークブックセルを `None` に設定します。縦棒チャートの場合、プロットされた値は [ChartDataPoint.value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/value/) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空白として扱います。

以下の例は、最初のシリーズの 2 番目のポイントのみをクリアします:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

散布図は X と Y のセルを別々に使用し、バブルチャートはサイズ用のセルも使用します。削除したい値に対応するセルだけをクリアしてください。他のポイントを保持したい場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapointcollection/clear/) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御**

空のワークブックセルは欠損データを表し、`0` を含むセルは既知の数値を表します。[ChartDataCell.value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatacell/value/) を `None` に設定するとセルを空にできます。数値の 0 はブランクセル設定に関係なく 0 のままです。

[Chart.display_blanks_as](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/display_blanks_as/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空のワークブックセルを 0 や補間値で埋めることはありません。

以下の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook] はワークシート 0、列 0 をカテゴリ ラベルに、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Day 3 を実際に空のままにし、カテゴリとデータポイントは保持します。
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

各出力ファイルは保存前に設定されたモードを保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回保存すれば、モードごとに繰り返す必要はありません。

以下の比較は 3 つのファイルすべてで同じデータを示しています。いずれの場合もワークブックの Day 3 は空です:

![同一データの折れ線グラフ：Gap は Day 3 で線を切断し、Zero は線をゼロまで下げ、Span は Day 2 から Day 4 を接続](display_blanks_as.png)

見た目の効果はチャートの種類に依存します。折れ線グラフは 3 つのモードを比較しやすくなります。棒グラフや縦棒グラフは欠損カテゴリを跨ぐ線がないため、`SPAN` は上記のような接続部分を生成できません。欠損した列と高さゼロの列は見た目が似ることがあります。同様に、マーカーのみの散布図も接続線がありません。すべてのチャートタイプで 3 つの異なる結果が得られるとは限らないため、使用するタイプの出力を確認してください。

## **シリーズのギャップ幅を設定**

ギャップ幅は隣接する棒または列のクラスター間のスペースで、棒や列の幅のパーセンテージで表されます。オーバーラップと同様に、個々のシリーズではなく親シリーズ グループに属します。グループ全体に対して [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) を一度設定します。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密集します。

以下の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![ギャップ幅](gap_width.png)

## **FAQ**

**どのチャートタイプがデータシリーズをサポートしていますか？**

[ChartType] 列挙体で表されるすべてのチャートタイプはチャート データを使用しますが、シリーズは同じ値構造や設定を持つわけではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブルチャートはバブルサイズを追加します。シリーズのタイプに合ったデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅といったオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャートシリーズ グループとは何ですか？**

[ChartSeriesGroup] は、グループレベルのプロット設定を共有する互換性のあるシリーズを含みます。組み合わせチャートは複数のグループを含むことができるため、あるシリーズを通じてアクセスしたグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新しく作成したチャートにはデフォルトデータが含まれますか？**

はい。デフォルトでは、[ShapeCollection.add_chart] はサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データを追加する前にシリーズとカテゴリのコレクションを両方クリアできます。オーバーロードを使用すれば、デフォルトデータなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データポイントの値は [ChartDataWorkbook] のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを作成する際は、カテゴリ行とシリーズ値行を揃えて配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく、1 つのポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `None` に設定すると、ポイントのカテゴリ位置は空のまま保持されます。[ChartDataPointCollection.clear] はそのシリーズのすべてのポイントを削除したいときにのみ使用してください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリ コレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

結果はチャートの種類と [Chart.display_blanks_as] に依存します。サポート対象のチャートは、空白をギャップ、ゼロ値、または隣接ポイントを接続する形で表示できます。プレゼンテーションでの欠損データの意味に合わせて設定を選択してください。完全な例とビジュアル比較は [空セルの表示を制御](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポート対象の棒、縦棒、バブルシリーズでは、[ChartSeries.invert_if_negative] を有効にし、[ChartSeries.inverted_solid_fill_color] を設定します。個々のポイントに対しては [ChartDataPoint.invert_if_negative] で動作を上書きできます。これらのプロパティは書式設定に影響し、格納された数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定を使用し、シリーズ書式が定義されていない場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅といったグループプロパティはレイアウトを制御し、ポイントレベルの書式設定を上書きするものではありません。

**チャートが含められるシリーズ数に上限はありますか？**

Aspose.Slides は固定的なシリーズ数上限を設けていません。実際には、プレゼンテーションファイルの制約、利用可能なメモリ、描画時間、およびチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合は何を変更すべきですか？**

適切な親シリーズ グループで [ChartSeriesGroup.gap_width] を設定してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターがより密接になります。