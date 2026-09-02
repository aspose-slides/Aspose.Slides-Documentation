---
title: "Pythonでプレゼンテーションのチャート系列を管理する"
linktitle: "データ系列"
type: docs
url: /ja/python-net/chart-series/
keywords:
- "チャート系列"
- "系列オーバーラップ"
- "系列の色"
- "カテゴリの色"
- "系列名"
- "データポイント"
- "系列ギャップ"
- "PowerPoint"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Pythonを使用してプレゼンテーションでチャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。 [ChartSeries](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/) は関連する値の 1 つのセットを表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。 [ChartCategory](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartcategory/) オブジェクトは、シリーズ間で共有されるラベルまたはグループ化値を提供します。したがって、シリーズ名、カテゴリ、ポイント値は、表示テキストとしてのみ保存されるのではなく、[ChartDataCell](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 をシリーズ名、列 0 をカテゴリ名、残りのセルをシリーズ値に使用します。[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) に渡されるワークシート、行、列インデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこのレイアウトを使用しているとは限りません。ロードされたプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズ レベルの設定 (例: [ChartSeries.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/format/)) は、1 つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。
- データ ポイントの設定 (例: [ChartDataPoint.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/format/)) は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.parent_series_group](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/parent_series_group/) を介してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りが設定されていない場合、チャート スタイルとテーマが自動外観を決定します。シリーズとポイントの書式設定が両方存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャート系列-PowerPoint](chart-series-powerpoint.png)

## **チャート系列のオーバーラップの設定**

[ChartSeries.overlap](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/overlap/) は、2D チャートで棒や列がどれだけ重なるかを -100 から 100 パーセントの範囲で報告します。これは親シリーズ グループ上の設定の読み取り専用投影です。[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/overlap/) を設定すると、そのグループ内のすべての互換性のあるシリーズが更新されます。このオプションは、グループ化された棒や列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 新しいチャートにはサンプルの系列、カテゴリ、値が含まれています。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りの色の変更**

[ChartSeries.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/format/) を使用して、シリーズ全体のデフォルト塗りを設定します。ポイントに明示的な塗りが既に設定されている場合は、その [ChartDataPoint.format](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/format/) 設定がそのポイントのシリーズ塗りを上書きします。

次の例は、最初のシリーズに単色の青塗りを適用します。

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

## **シリーズ名の変更**

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化された縦棒チャート用にデフォルトで作成されたワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズの名前が格納されています。以下の例の名前付き定数は、その構造を明示的に示しています。

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

また、[ChartSeries.name](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/name/) が既に参照しているセルを更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないため、安全です。

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

## **自動シリーズ塗り色の取得**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズ塗りが明示的に定義されていない場合に使用される色です。メソッドを呼び出すと計算された色が取得され、 新しい塗りは割り当てられません。

次の例は、デフォルトシリーズそれぞれの自動色を出力します。

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

デフォルト チャート スタイルのサンプル出力:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

正確な色はチャート スタイルとテーマに依存します。

## **シリーズの塗りを反転させる色の設定**

棒、縦棒、バブル シリーズの場合、[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/invert_if_negative/) を使用して、負の値を別の塗りで表示できます。通常のシリーズ塗りを単色に設定し、反転を有効にし、負の値用の色を [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) で割り当てます。ワークブック内の負の数値は変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されています。

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

![反転した単色塗り](inverted_solid_fill_color.png)

1 つのポイントだけに反転を有効にすることもできます。[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) を使用します。次の例では、シリーズ全体の反転は無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てて、効果を確認できるようにしています。

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

## **特定のデータ ポイント値のクリア**

1 つのポイントだけを空にしたい場合は、バックアップ ワークブック セルを `None` に設定します。縦棒チャートの場合、プロットされた値は [ChartDataPoint.value](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/value/) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはその値を空白として扱い、空白値設定に従って表示します。

次の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

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

散布図は X と Y のセルが別々に使用され、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。他のポイントを保持したままにしたい場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapointcollection/clear/) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **シリーズ ギャップ幅の設定**

ギャップ幅は、隣接する棒または列クラスタ間のスペースで、棒または列幅のパーセンテージで表されます。オーバーラップと同様に、ギャップ幅は個々のシリーズではなく、親シリーズ グループに属します。[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) をグループ全体に対して一度設定します。値が大きいほどクラスタ間のスペースが広がり、値が小さいほど密集します。

次の例はギャップ幅を変更し、最終的なプレゼンテーションだけを保存します。

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

**どのチャート タイプがデータ シリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズの値構造や設定はすべて同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。シリーズ タイプに合わせたデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャート 系列 グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/) は、グループ レベルのプロット設定を共有する互換性のあるシリーズを含みます。組み合わせチャートでは複数のグループを含めることができるため、あるシリーズを通して取得したグループを変更しても、必ずしもチャート内のすべてのシリーズが変更されるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[ShapeCollection.add_chart](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_chart/) がサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前にシリーズとカテゴリ コレクションの両方をクリアできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイント値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdataworkbook/) のセルを参照しています。参照先のセルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行が整合するようにし、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするにはどうすればよいですか？**

対象の値セルを `None` に設定して、ポイントのカテゴリ位置は保持したまま空白ポイントにします。すべてのポイントを削除したい場合のみ、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapointcollection/clear/) を使用してください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリ コレクションと整合するように更新してください。

**空白ポイントはどのように表示されますか？**

表示はチャート タイプと [Chart.display_blanks_as](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/display_blanks_as/) の設定に依存します。サポートされているチャートは、空白を間隔、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションのデータ欠損の意味に合った設定を選択してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、縦棒、バブル シリーズでは、[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/invert_if_negative/) を有効にし、[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) で負の値用の色を設定します。個々のポイントに対しては、[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) で動作を上書きできます。これらのプロパティは書式設定に影響しますが、保存されている数値には影響しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。その他のポイントは、明示的なシリーズ書式設定があればそれを使用し、シリーズ書式設定が定義されていない場合は自動的にチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ プロパティはレイアウトを制御し、ポイント レベルの書式設定の上書きにはなりません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には固定されたシリーズ数上限はありません。実際には、プレゼンテーション ファイルの制約、使用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が近すぎる、または遠すぎる場合は何を変更すべきですか？**

適切な親シリーズ グループで [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) を設定します。値を大きくするとクラスタ間のスペースが広がり、値を小さくするとクラスタが互いに近づきます。