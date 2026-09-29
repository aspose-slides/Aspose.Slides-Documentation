---
title: Python でプレゼンテーションのチャート データ シリーズを管理する
linktitle: データ シリーズ
type: docs
url: /ja/python-net/chart-series/
keywords:
- チャート シリーズ
- シリーズ オーバーラップ
- シリーズ 色
- カテゴリ 色
- シリーズ 名称
- データ ポイント
- シリーズ ギャップ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python を使用してプレゼンテーション内のチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。[ChartSeries](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/) は関連する値のセットを表し、シリーズ内の各[ChartDataPoint](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/)は1つ以上のワークブック セルを参照します。[ChartCategory](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartcategory/) オブジェクトはシリーズが共有するラベルまたはグループ化値を提供します。そのため、シリーズ名、カテゴリ、およびポイント値は、表示テキストとしてだけでなく、[ChartDataCell](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートでは、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に使用し、残りのセルにシリーズの値を格納します。[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこの構造を使用しているとは限りません。ロードされたプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、およびデータ ポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります。

- シリーズレベルの設定は、[ChartSeries.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/format/) のように、1 つのシリーズ内のすべてのポイントの既定の外観を提供します。
- データポイントの設定は、[ChartDataPoint.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/format/) のように、1 つのポイントのシリーズ外観を上書きします。
- グループ設定は、同じ[ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/)に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.parent_series_group](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/parent_series_group/) を通じてグループにアクセスします。

明示的なポイントまたはシリーズの塗りが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの両方の書式設定が存在する場合、そのポイントに対してはポイントの書式設定が優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート シリーズのオーバーラップを設定**

[ChartSeries.overlap](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/overlap/) は、2D チャートでバーまたは列がどれだけ重なるか（-100% から 100%）を示します。これは、親シリーズ グループの設定の読み取り専用の投影です。[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/overlap/) を設定すると、そのグループ内のすべての互換シリーズが更新されます。このオプションは、グループ化されたバーまたは列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 新しいチャートにはサンプルシリーズ、カテゴリ、値が含まれています。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りの色を変更**

[ChartSeries.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/format/) を使用して、シリーズ全体の既定の塗りを設定します。ポイントに既に明示的な塗りが設定されている場合、その[ChartDataPoint.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/format/) の設定がそのポイントのシリーズ塗りを上書きします。

以下の例は、最初のシリーズに単色の青塗りを適用します:

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

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化された列チャート用に作成されたデフォルトのワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズの名前が含まれます。以下の例の名前定数はその構造を明示的に示しています:

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

また、[ChartSeries.name](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/name/) がすでに参照しているセルを更新することもできます。このアプローチは、既存のチャートで特定の行や列を想定することを避けます:

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

## **自動シリーズ塗り色を取得**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズの塗りが明示的に定義されていない場合に使用される色です。メソッドを呼び出すと計算された色が取得され、新しい塗りは設定されません。

以下の例は、各デフォルトシリーズの自動色を出力します:

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

正確な色はチャート スタイルとテーマに依存します。

## **チャートシリーズの反転塗り色を設定**

バー、列、バブル シリーズの場合、[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/invert_if_negative/) を使用すると、負の値を別の塗りで表示できます。通常のシリーズ塗りを単色に設定し、反転を有効にし、[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) で負の値の色を指定します。負の数はワークブック内では変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されています:

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

![反転単色塗り色](inverted_solid_fill_color.png)

1 つのポイントだけで反転を有効にするには、[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てて、効果が確認できるようにしています:

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

## **特定のデータポイントの値をクリア**

他のポイントを削除せずに 1 つのポイントを空にするには、その基になるワークブック セルを `None` に設定します。列チャートの場合、プロットされた値は[ChartDataPoint.value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/value/)で取得できます。データポイントは同じカテゴリ位置に留まりますが、チャートは空白値設定に従ってその値を空白として扱います。

以下の例は、最初のシリーズの 2 番目のポイントだけをクリアします:

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

散布図は X と Y の別々のセルを使用し、バブルチャートはサイズ セルも使用します。削除したいのは値を表すセルだけです。他のポイントを保持したい場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapointcollection/clear/) を呼び出さないでください。このメソッドはコレクション内のすべてのデータポイントを削除します。

## **空セルの表示を制御**

値を含む非表示セルは、空セルとは別のケースです。非表示のワークシート行や列のデータを含める/除外する方法については、[Include Data from Hidden Rows and Columns](/slides/ja/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータが欠落していることを表し、`0` を含むセルは既知の数値を表します。[ChartDataCell.value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatacell/value/) を `None` に設定するとセルが空になります。空セル設定に関係なく、数値のゼロはゼロのままです。

[Chart.display_blanks_as](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/display_blanks_as/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空のワークブック セルにゼロや補間値を埋め込むことはありません。

以下の自己完結型例は、1 系列の折れ線チャートを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベルに、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

各出力ファイルは保存前に設定されたモードを保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを設定してプレゼンテーションを一度だけ保存し、モードを繰り返し適用しないでください。

以下の比較は、3 つのファイルすべてで同じデータを示しています。いずれの場合もワークブックでは Day 3 が空です:

![同一データの折れ線チャート: Gap は Day 3 で線を切り、Zero は線をゼロまで下げ、Span は Day 2 から Day 4 を接続します。](display_blanks_as.png)

見た目の効果はチャート タイプによります。折れ線チャートは 3 つのモードを比較しやすいですが、棒や列チャートは欠損したカテゴリを接続する線がないため、`SPAN` は上記のような接続セグメントを生成できません。欠損列とゼロ高の列は見た目が似ることがあります。同様に、マーカーのみの散布図も接続ラインがありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプの出力を確認してください。

## **シリーズのギャップ幅を設定**

ギャップ幅は隣接するバーまたは列クラスター間のスペースで、バーまたは列幅のパーセンテージで表されます。オーバーラップと同様に、個々のシリーズではなく親シリーズ グループに属します。[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) をグループに対して一度設定します。値を大きくするとクラスター間の間隔が広がり、値を小さくするとクラスターが密になります。

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

## **よくある質問**

**どのチャート タイプがデータシリーズをサポートしますか？**

[ChartType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャート タイプはデータを使用しますが、シリーズの値構造や設定はタイプごとに異なります。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブルサイズを追加します。シリーズ タイプに合ったデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のあるバーまたは列グループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換シリーズを含みます。組み合わせチャートは複数のグループを持つことができるため、あるシリーズを通じて取得したグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[ShapeCollection.add_chart](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_chart/) はサンプルシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データポイント値はすべて[ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/) のセルを参照しています。参照されているセルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行を揃えて、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `None` に設定すると、ポイントのカテゴリ位置は維持したまま空のポイントとなります。シリーズ全体のポイントをすべて削除したい場合のみ、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapointcollection/clear/) を使用してください。カテゴリも削除する場合は、すべてのシリーズがカテゴリ コレクションと整合するように値を更新してください。

**空のポイントはどのように表示されますか？**

結果はチャート タイプと[Chart.display_blanks_as](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/display_blanks_as/) の設定に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションのデータ欠損の意味に合った設定を選択してください。完全な例と視覚的比較については、[空セルの表示を制御](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされているバー、列、バブル シリーズでは、[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/invert_if_negative/) を有効にし、[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) で負の値の色を設定します。個々のポイントに対しては[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) で動作を上書きできます。これらのプロパティは書式設定に影響し、保存されている数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらの書式が優先されますか？**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは、明示的なシリーズ書式が定義されていればそれを使用し、定義されていなければ自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅といったグループプロパティはレイアウトを制御し、ポイントレベルの書式設定の上書きにはなりません。

**チャートが保持できるシリーズ数に制限はありますか？**

Aspose.Slides には固定されたシリーズ数の上限はありません。実際の制限は、プレゼンテーション ファイルのサイズ、利用可能なメモリ、レンダリング時間、そしてチャートの可読性によって決まります。

**列が近すぎる、または離れすぎる場合は何を変更すべきですか？**

適切な親シリーズ グループに対して[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) を設定します。値を大きくするとクラスター間の間隔が広がり、値を小さくするとクラスターが近づきます。