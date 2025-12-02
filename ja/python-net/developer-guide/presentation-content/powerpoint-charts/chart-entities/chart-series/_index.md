---
title: Pythonでチャート データシリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/python-net/chart-series/
keywords:
- チャートシリーズ
- シリーズの重なり
- シリーズの色
- カテゴリの色
- シリーズ名
- データポイント
- シリーズ間隔
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "実践的なコード例とベストプラクティスを用いて、PowerPoint（PPT/PPTX）向けに Python でチャート データシリーズを管理し、データプレゼンテーションを向上させる方法を学びます。"
---

## **概要**

この記事では、Aspose.Slides for Python における [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) の役割について説明します。データがプレゼンテーション内でどのように構造化され、視覚化されるかに焦点を当てています。これらのオブジェクトは、チャート内の個々のデータポイント、カテゴリ、および外観パラメータのセットを定義する基礎要素を提供します。 [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) を使用することで、開発者は基礎データソースをシームレスに統合し、情報の表示方法を完全に制御でき、洞察や分析を明確に伝える動的でデータ駆動型のプレゼンテーションを実現できます。

シリーズは、チャートにプロットされた数字の行または列です。

![チャートシリーズ PowerPoint](chart-series-powerpoint.png)

## **シリーズの重なりの設定**

The [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) プロパティは、-100 から 100 の範囲で指定することにより、2D チャートにおける棒や列の重なり具合を制御します。このプロパティは個々のチャートシリーズではなくシリーズ グループに関連付けられているため、シリーズレベルでは読み取り専用です。重なりの値を設定するには、`parent_series_group.overlap` 読み書き可能プロパティを使用し、指定した重なりをそのグループ内のすべてのシリーズに適用します。

以下は、プレゼンテーションを作成し、クラスター化された縦棒グラフを追加し、最初のチャートシリーズにアクセスして重なり設定を構成し、結果を PPTX ファイルとして保存する方法を示す Python の例です。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルト データでクラスター化された縦棒チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # シリーズの重なりを設定します。
        series.parent_series_group.overlap = series_overlap

    # プレゼンテーション ファイルをディスクに保存します。
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![シリーズの重なり](series_overlap.png)

## **シリーズの塗りつぶし色の変更**

Aspose.Slides は、チャートシリーズの塗りつぶし色をカスタマイズすることを容易にし、特定のデータポイントを強調し、視覚的に魅力的なチャートを作成できます。これは、さまざまな塗りつぶしタイプ、色設定、その他の高度なスタイリング オプションをサポートする [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/) オブジェクトを使用して実現します。スライドにチャートを追加し、目的のシリーズにアクセスしたら、シリーズを取得して適切な塗りつぶし色を適用するだけです。単色の塗りつぶしに加えて、グラデーションやパターン塗りつぶしを利用してデザインの柔軟性を高めることもできます。要件に合わせて色を設定したら、プレゼンテーションを保存して更新された外観を確定します。

以下の Python コード例は、最初のシリーズの色を変更する方法を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルト データでクラスター化された縦棒チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # 最初のシリーズの色を設定します。
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # プレゼンテーション ファイルをディスクに保存します。
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![シリーズの色](series_color.png)

## **シリーズの名前の変更**

Aspose.Slides は、チャートシリーズの名前を変更する簡単な方法を提供し、データに対して明確で意味のあるラベル付けを容易にします。チャートデータ内の関連するワークシートセルにアクセスすることで、開発者はデータの提示方法をカスタマイズできます。この変更は、シリーズ名をデータの文脈に応じて更新または明確化する必要がある場合に特に有用です。シリーズの名前を変更した後、プレゼンテーションを保存して変更を永続化できます。

以下は、このプロセスを実際に示す Python コードスニペットです。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルト データでクラスター化された縦棒チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # 最初のシリーズの名前を設定します。
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # プレゼンテーション ファイルをディスクに保存します。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


以下の Python コードは、シリーズ名を変更する別の方法を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルト データでクラスター化された縦棒チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # 最初のシリーズの名前を設定します。
    series.name.as_cells[0].value = series_name

    # プレゼンテーション ファイルをディスクに保存します。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


結果:

![シリーズ名](series_name.png)

## **シリーズの自動塗りつぶし色の取得**

Aspose.Slides for Python を使用すると、プロット領域内のチャートシリーズの自動塗りつぶし色を取得できます。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成した後、インデックスで目的のスライドへの参照を取得し、好みのタイプ（例: `ChartType.CLUSTERED_COLUMN`）でチャートを追加します。チャート内のシリーズにアクセスすることで、自動塗りつぶし色を取得できます。

以下の Python コードは、このプロセスを詳細に示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルト データでクラスター化された縦棒チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # シリーズの塗りつぶし色を取得します。
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


出力例:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **シリーズの反転塗りつぶし色の設定**

データシリーズに正の値と負の値の両方が含まれる場合、すべての列や棒を同じ色で塗るだけではチャートが読みにくくなります。Aspose.Slides for Python では、負の値（ゼロ以下）に自動的に適用される別の塗りつぶしである反転塗りつぶし色を割り当てることができ、負の値を一目で際立たせることができます。このセクションでは、そのオプションを有効にし、適切な色を選択し、更新されたプレゼンテーションを保存する方法を学びます。

以下のコード例は、この操作を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 新しいカテゴリを追加します。
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # 新しいシリーズを追加します。
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # シリーズのデータを設定します。
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # シリーズのカラー設定を行います。
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![反転した実線塗りつぶし色](inverted_solid_fill_color.png)

シリーズ全体ではなく、単一のデータポイントの塗りつぶし色を反転させることもできます。目的の `ChartDataPoint` にアクセスし、その `invert_if_negative` プロパティを `True` に設定するだけです。

以下のコード例は、その方法を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```


## **特定のデータポイントのデータクリア**

チャートにテスト用の値、外れ値、または古いエントリが含まれている場合、シリーズ全体を再構築せずにそれらを削除したいことがあります。Aspose.Slides for Python を使用すると、インデックスで任意のデータポイントを対象にし、その内容をクリアし、プロットを即座に更新して残りのポイントがシフトし、軸が自動的に再スケーリングされます。

以下のコード例は、この操作を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```


## **シリーズの隙間幅の設定**

隙間幅は隣接する列や棒の間の空白の量を制御します。隙間が広いほど個々のカテゴリが強調され、隙間が狭いほど密度の高い、コンパクトな外観になります。Aspose.Slides for Python を通じて、シリーズ全体のこのパラメータを微調整でき、基礎データを変更せずにプレゼンテーションが必要とする視覚的バランスを正確に実現できます。

以下のコード例は、シリーズの隙間幅を設定する方法を示しています。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# 空のプレゼンテーションを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルト データでチャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # プレゼンテーションをディスクに保存します。
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # gap_width の値を設定します。
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # プレゼンテーションをディスクに保存します。
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![隙間幅](gap_width.png)

## **FAQ**

**単一のチャートに含められるシリーズの数に上限はありますか？**

Aspose.Slides には、追加できるシリーズ数に固定された上限はありません。実際の上限は、チャートの可読性とアプリケーションで利用可能なメモリ量によって決まります。

**クラスター内の列が近すぎる、または離れすぎる場合はどうすればよいですか？**

そのシリーズ（または親シリーズ グループ）の [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) 設定を調整してください。値を上げると列間のスペースが広がり、下げると列が近くなります。