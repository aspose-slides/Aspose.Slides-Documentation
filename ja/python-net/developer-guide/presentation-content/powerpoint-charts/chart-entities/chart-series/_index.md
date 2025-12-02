---
title: Pythonでチャート データシリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/python-net/chart-series/
keywords:
- チャートシリーズ
- シリーズの重なり
- シリーズの色
- カテゴリ色
- シリーズ名
- データポイント
- シリーズ間隔
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) 用の Pythonでチャート データシリーズを管理する方法を、実用的なコード例とベストプラクティスとともに学び、データプレゼンテーションを強化します。"
---

## **概要**

この記事では、Aspose.Slides for Python における [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) の役割について説明し、プレゼンテーション内でデータがどのように構造化され、可視化されるかに焦点を当てます。これらのオブジェクトは、チャート内のデータポイント、カテゴリ、外観パラメータの個々のセットを定義する基礎要素を提供します。[ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) を使用することで、開発者は基盤となるデータソースをシームレスに統合し、情報の表示方法を完全にコントロールでき、動的でデータ駆動型のプレゼンテーションを実現し、洞察と分析を明確に伝えることができます。

シリーズは、チャートにプロットされる数値の行または列です。

![チャートシリーズ](chart-series-powerpoint.png)

## **シリーズの重なり設定**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) プロパティは、2D チャートにおける棒や柱の重なりを -100 から 100 の範囲で指定して制御します。このプロパティは個々のチャートシリーズではなくシリーズ グループに関連付けられているため、シリーズレベルでは読み取り専用です。重なりの値を設定するには、`parent_series_group.overlap` の読み書き可能なプロパティを使用し、そのグループ内のすべてのシリーズに指定した重なりを適用します。

以下は、プレゼンテーションを作成し、クラスター化された縦棒グラフを追加し、最初のチャートシリーズにアクセスして重なり設定を構成し、結果を PPTX ファイルとして保存する方法を示す Python の例です。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化された縦棒グラフを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # シリーズの重なりを設定します。
        series.parent_series_group.overlap = series_overlap

    # プレゼンテーションファイルをディスクに保存します。
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![シリーズの重なり](series_overlap.png)

## **シリーズの塗りつぶし色の変更**

Aspose.Slides を使用すると、チャートシリーズの塗りつぶし色を簡単にカスタマイズでき、特定のデータポイントを強調表示したり、視覚的に魅力的なチャートを作成したりできます。これは、さまざまな塗りつぶしタイプ、カラー設定、その他の高度なスタイリングオプションをサポートする [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/) オブジェクトを使用して実現します。スライドにチャートを追加し、目的のシリーズにアクセスしたら、シリーズを取得して適切な塗りつぶし色を適用するだけです。単色塗りつぶしだけでなく、グラデーションやパターン塗りつぶしも活用でき、デザインの柔軟性が高まります。要件に合わせて色を設定したら、プレゼンテーションを保存して更新された外観を確定します。

以下の Python コード例は、最初のシリーズの色を変更する方法を示しています。
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化された縦棒グラフを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # 最初のシリーズの色を設定します。
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # プレゼンテーションファイルをディスクに保存します。
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![シリーズの色](series_color.png)

## **シリーズの名前変更** 

Aspose.Slides は、チャートシリーズの名前を簡単に変更できる方法を提供し、データに対してわかりやすく意味のあるラベル付けを容易にします。チャートデータ内の該当するワークシートセルにアクセスすることで、開発者はデータの表示方法をカスタマイズできます。データのコンテキストに応じてシリーズ名を更新または明確化する必要がある場合に特に有用です。シリーズの名前を変更した後、プレゼンテーションを保存して変更を永続化できます。

以下は、このプロセスを実際に実演する Python コード スニペットです。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化された縦棒グラフを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # 最初のシリーズの名前を設定します。
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # プレゼンテーションファイルをディスクに保存します。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


以下の Python コードは、シリーズ名を変更する代替方法を示しています。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化された縦棒グラフを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # 最初のシリーズの名前を設定します。
    series.name.as_cells[0].value = series_name

    # プレゼンテーションファイルをディスクに保存します。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


結果:

![シリーズ名](series_name.png)

## **シリーズの自動塗りつぶし色取得**

Aspose.Slides for Python は、プロット領域内のチャートシリーズに対して自動塗りつぶし色を取得できるようにします。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成した後、インデックスで目的のスライドへの参照を取得し、好みのタイプ（例:`ChartType.CLUSTERED_COLUMN`）でチャートを追加します。チャート内のシリーズにアクセスすれば、自動塗りつぶし色を取得できます。

以下の Python コードは、このプロセスを詳しく示しています。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化された縦棒グラフを追加します。
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


## **シリーズの反転塗りつぶし色を設定**

データシリーズに正の値と負の値の両方が含まれる場合、すべての棒や柱を同じ色で塗るだけではチャートが読みにくくなることがあります。Aspose.Slides for Python は、負の値に自動的に適用される別個の塗りつぶし（反転塗りつぶし色）を割り当てることができ、負の値が一目で目立つようになります。このセクションでは、そのオプションを有効にし、適切な色を選択し、更新されたプレゼンテーションを保存する方法を学びます。

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

    # シリーズの色設定を行います。
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![反転した実線塗りつぶし色](inverted_solid_fill_color.png)

単一のデータポイントだけに塗りつぶし色を反転させることもできます。目的の `ChartDataPoint` にアクセスし、その `invert_if_negative` プロパティを `True` に設定するだけです。

以下のコード例は、これを実行する方法を示しています。
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


## **特定のデータポイントのデータをクリア**

時折、チャートにテスト値、外れ値、または不要なエントリが含まれており、シリーズ全体を作り直すことなくそれらを削除したいことがあります。Aspose.Slides for Python は、インデックスで任意のデータポイントを対象にして内容をクリアし、プロットを即座にリフレッシュし、残りのポイントがシフトし、軸が自動的に再スケーリングされるようにできます。

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


## **シリーズのギャップ幅を設定**

ギャップ幅は隣接する柱や棒の間の空白量を制御します。ギャップが広いと各カテゴリが強調され、狭いとより密集したコンパクトな外観になります。Aspose.Slides for Python を使用すると、シリーズ全体に対してこのパラメータを微調整でき、基になるデータを変更せずにプレゼンテーションに必要な視覚的バランスを正確に実現できます。

以下のコード例は、シリーズのギャップ幅を設定する方法を示しています。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# 空のプレゼンテーションを作成します。
with slides.Presentation() as presentation:

    # 最初のスライドにアクセスします。
    slide = presentation.slides[0]

    # デフォルトデータでチャートを追加します。
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

![ギャップ幅](gap_width.png)

## **FAQ**

**単一のチャートに含められるシリーズの数に制限はありますか？**

Aspose.Slides は、追加できるシリーズ数に固定の上限を課していません。実用的な上限は、チャートの可読性とアプリケーションで利用可能なメモリによって決まります。

**クラスタ内の列が近すぎる、または離れすぎる場合はどうすればよいですか？**

そのシリーズ（または親シリーズ グループ）の [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) 設定を調整します。値を増やすと列間の間隔が広がり、減らすとより近くなります。