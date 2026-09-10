---
title: Pythonでプレゼンテーションのチャート データ シリーズを管理
linktitle: データ シリーズ
type: docs
url: /ja/python-java/chart-series/
keywords:
- チャートシリーズ
- シリーズのオーバーラップ
- シリーズの色
- シリーズ名
- データポイント
- ワークブック セル
- シリーズのギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、プレゼンテーションでのチャート シリーズ、データ ポイント、ワークブック セル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。[ChartSeries](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/) は関連する値のセットを表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。[ChartCategory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartcategory/) オブジェクトは、シリーズが共有するラベルまたはグループ化値を提供します。そのため、シリーズ名、カテゴリ、ポイントの値は [ChartDataCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatacell/) オブジェクトに接続され、表示テキストとしてだけ保存されません。

典型的なカテゴリ チャートでは、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に使用し、残りのセルはシリーズ値に使用します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/#getCell) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成するときに便利ですが、すべての既存チャートがこれを使用しているとは限りません。ロード済みのプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります：

- シリーズ レベルの設定（例: [ChartSeries.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getFormat)）は、1 つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。
- データポイント レベルの設定（例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getFormat)）は、特定のポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定の両方が存在する場合、そのポイントに対してはポイントの書式設定が優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップを設定**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getOverlap) は、2D チャートで棒や列がどれだけオーバーラップするか（-100 から 100 パーセント）を報告します。これは親シリーズ グループの設定の読み取り専用の投影です。グループ内のすべての互換シリーズを更新するには、[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setOverlap) を使用します。このオプションは、グループ化された棒や列を表示するチャートタイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します：

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

    # 新しいチャートにはサンプルのシリーズ、カテゴリ、値が含まれています。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![The series overlap](series_overlap.png)

## **シリーズの塗りつぶし色を変更**

[ChartSeries.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getFormat) を使用して、シリーズ全体のデフォルトの塗りつぶしを設定します。ポイントに明示的な塗りつぶしがすでにある場合は、その [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getFormat) 設定がシリーズの塗りつぶしを上書きします。

以下の例は、最初のシリーズに単色の青い塗りつぶしを適用します：

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

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスタ化された縦棒チャート用にデフォルトで作成されたワークブックでは、セル B1（行 0、列 1）が最初のシリーズ名を保持しています。以下の例の名前付き変数は、その構造を明示的に示します：

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

また、[ChartSeries.getName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getName) が参照しているセルを直接更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないため安全です：

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

## **自動シリーズ塗りつぶし色を取得**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、シリーズインデックスとチャートスタイルから計算された色を返します。これは、シリーズの塗りつぶしが明示的に定義されていないときに使用される色です。このメソッドは計算された色を取得するだけで、新しい塗りつぶしを割り当てるわけではありません。

以下の例は、各デフォルトシリーズの自動色を出力します：

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

デフォルトのチャートスタイルに対するサンプル出力：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャートスタイルとテーマに依存します。

## **シリーズの反転塗りつぶし色を設定**

棒、縦棒、バブルシリーズの場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#setInvertIfNegative) を使用すると、負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値用の色を [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で割り当てます。ワークブック内の負の数値は変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が入ります：

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

1 つのポイントだけで反転を有効にするには、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、シリーズ全体の反転を無効にし、選択したポイントだけで有効にしています。そのポイントには負の値も設定して効果を確認できます：

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

## **特定のデータポイントの値をクリア**

ポイントだけを空にし、他のポイントはそのままにするには、バックエンドのワークブック セルを `None` に設定します。縦棒チャートの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#getValue) で取得できます。データポイントは同じカテゴリ位置に留まり、チャートは空白値設定に従ってその値を空白として扱います。

以下の例は、最初のシリーズの 2 番目のポイントだけをクリアします：

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

散布図は X と Y のセルが別々にあり、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。コレクション全体を削除したいとき以外は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。このメソッドはすべてのデータポイントを削除します。

## **シリーズのギャップ幅を設定**

ギャップ幅は隣接する棒または列クラスター間のスペースで、棒や列の幅のパーセンテージで表されます。オーバーラップと同様に、ギャップ幅は個々のシリーズではなく親シリーズ グループに属します。グループ全体に対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出します。値が大きいほどクラスター間のスペースが広がり、値が小さいほど密集します。

以下の例はギャップ幅を変更し、最終的なプレゼンテーションだけを保存します：

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

**どのチャートタイプがデータシリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/charttype/) 列挙体で表されるすべてのチャートタイプはチャート データを使用しますが、シリーズの値構造や設定はタイプごとに異なります。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブルサイズも追加します。シリーズ タイプに合わせたデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャートシリーズ グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のあるシリーズを含みます。組み合わせチャートは複数のグループを持つことができるため、あるシリーズを通じて取得したグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新規作成したチャートにはデフォルトデータが含まれますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addChart) がサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、シリーズとカテゴリのコレクションをクリアして完全にカスタム データを追加できます。オーバーロードを使用すれば、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブックのセルとどう接続されていますか？**

シリーズ名、カテゴリ ラベル、データポイントの値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する場合は、カテゴリ行とシリーズ値行が整合するように配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするには？**

対象となる値セルを `None` に設定すれば、そのポイントはカテゴリ位置に残りつつ空白ポイントとして扱われます。[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapointcollection/#clear) はそのシリーズのすべてのポイントを削除するため、部分的にクリアしたいときは使用しないでください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリコレクションと整合するように更新してください。

**空白ポイントはどのように表示されますか？**

結果はチャート タイプと、[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/#setDisplayBlanksAs) で設定された値に依存します。サポートされているチャートは、空白をギャップとして、ゼロ値として、あるいは隣接ポイントを結んで表示することができます。プレゼンテーションでの欠損データの意味に合わせて設定を選択してください。

**負の値はどのように書式設定されますか？**

棒、縦棒、バブルの対応シリーズでは、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) が返す色を設定します。個々のポイントに対しては [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で動作を上書きできます。これらのメソッドは書式設定に影響し、数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントで優先されます。他のポイントはシリーズの書式設定（明示的に定義されていない場合は自動的なチャートスタイルとテーマ）を使用し続けます。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められるシリーズ数に制限はありますか？**

Aspose.Slides には固定されたシリーズ数の上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性などが実用的な上限を決定します。

**列が近すぎる、または遠すぎる場合は何を変更すべきですか？**

適切な親シリーズ グループに対して [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが近づきます。