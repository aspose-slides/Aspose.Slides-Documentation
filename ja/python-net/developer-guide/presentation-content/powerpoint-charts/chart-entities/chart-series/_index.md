---
title: Pythonでチャートデータ系列を管理する
linktitle: データ系列
type: docs
url: /ja/python-net/chart-series/
keywords:
- チャート系列
- 系列のオーバーラップ
- 系列の色
- カテゴリの色
- 系列名
- データポイント
- 系列ギャップ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "PythonでPowerPoint（PPT/PPTX）のチャートデータ系列を管理する方法を学び、実用的なコード例とベストプラクティスでデータプレゼンテーションを強化します。"
---

## **概要**

この記事では、Aspose.Slides for Python における [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) の役割を説明し、プレゼンテーション内でデータがどのように構造化され視覚化されるかに焦点を当てています。これらのオブジェクトは、チャート内で個々のデータポイント、カテゴリ、および外観パラメータのセットを定義する基礎要素を提供します。[ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) を使用することで、開発者は基になるデータソースをシームレスに統合し、情報の表示方法を完全にコントロールできるため、洞察と分析を明確に伝える動的かつデータ駆動型のプレゼンテーションを実現できます。

シリーズは、チャートにプロットされる数値の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **シリーズのオーバーラップを設定**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) プロパティは、2D チャートで棒や列がどの程度重なるかを -100 から 100 の範囲で指定します。このプロパティは個々のチャートシリーズではなくシリーズグループに関連付けられているため、シリーズレベルでは読み取り専用です。オーバーラップの値を設定するには、`parent_series_group.overlap` 読み書き可能プロパティを使用し、指定したオーバーラップをそのグループ内のすべてのシリーズに適用します。

以下は、プレゼンテーションを作成し、クラスター化列チャートを追加し、最初のチャートシリーズにアクセスしてオーバーラップ設定を構成し、PPTX ファイルとして保存する Python の例です:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化列チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # 系列のオーバーラップを設定します。
        series.parent_series_group.overlap = series_overlap

    # プレゼンテーションファイルをディスクに保存します。
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶし色を変更**

Aspose.Slides を使用すれば、チャートシリーズの塗りつぶし色を簡単にカスタマイズでき、特定のデータポイントを強調したり、視覚的に魅力的なチャートを作成したりできます。これは [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/) オブジェクトを通じて実現され、さまざまな塗りつぶしタイプ、カラー設定、その他の高度なスタイリングオプションがサポートされています。スライドにチャートを追加し、目的のシリーズにアクセスしたら、シリーズを取得して適切な塗りつぶし色を適用します。単色塗りつぶしだけでなく、グラデーションやパターン塗りつぶしも利用でき、デザインの柔軟性が向上します。必要な色設定が完了したら、プレゼンテーションを保存して変更を確定します。

以下の Python コード例は、最初のシリーズの色を変更する方法を示しています:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化列チャートを追加します。
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

## **シリーズの名前を変更**

Aspose.Slides は、チャートシリーズの名前を簡単に変更できる機能を提供し、データを明確かつ意味のある方法でラベル付けできます。チャートデータ内の該当するワークシートセルにアクセスすることで、データの表示方法をカスタマイズできます。この変更は、シリーズ名をデータのコンテキストに合わせて更新または明確化する必要がある場合に特に有用です。シリーズ名を変更したら、プレゼンテーションを保存して変更を永続化できます。

以下は、このプロセスを実際に示す Python コードスニペットです。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化列チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # 最初のシリーズの名前を設定します。
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # プレゼンテーションファイルをディスクに保存します。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


別の方法でシリーズ名を変更する Python コードは次のとおりです。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化列チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # 最初のシリーズの名前を設定します。
    series.name.as_cells[0].value = series_name

    # プレゼンテーションファイルをディスクに保存します。
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


結果:

![シリーズの名前](series_name.png)

## **シリーズの自動塗りつぶし色を取得**

Aspose.Slides for Python を使用すると、プロット領域内のチャートシリーズの自動塗りつぶし色を取得できます。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成した後、インデックスで目的のスライドへの参照を取得し、好みのタイプ（例: `ChartType.CLUSTERED_COLUMN`）でチャートを追加します。チャート内のシリーズにアクセスすると、自動塗りつぶし色を取得できます。

以下の Python コードはこの手順を詳細に示しています。
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # デフォルトデータでクラスター化列チャートを追加します。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # 系列の塗りつぶし色を取得します。
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


例の出力:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **シリーズの反転塗りつぶし色を設定**

データシリーズに正の値と負の値が混在する場合、すべての列や棒を同じ色で塗るとチャートが読みづらくなります。Aspose.Slides for Python では、負の値に対して自動的に適用される別の塗りつぶし（反転塗りつぶし色）を割り当てることができ、負の値が一目で際立ちます。このセクションでは、オプションの有効化方法、適切な色の選択方法、更新されたプレゼンテーションの保存方法を学びます。

以下のコード例は操作方法を示しています:
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

    # 新しい系列を追加します。
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # 系列データを入力します。
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # 系列の色設定を行います。
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


結果:

![反転した単色塗りつぶし色](inverted_solid_fill_color.png)

単一のデータポイントだけに反転塗りつぶし色を適用することもできます。目的の `ChartDataPoint` にアクセスし、その `invert_if_negative` プロパティを `True` に設定してください。

以下のコード例はその方法を示しています:
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

チャートにテスト値や外れ値、古いエントリが含まれていて、シリーズ全体を再構築せずに削除したい場合があります。Aspose.Slides for Python では、インデックスで任意のデータポイントを指定し、その内容をクリアし、残りのポイントがシフトし、軸が自動的に再スケーリングされるようにプロットを即座に更新できます。

以下のコード例が操作を示しています:
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

ギャップ幅は隣接する列や棒の間の空白の量を制御します。ギャップが広いほど個々のカテゴリが強調され、狭いほど密集したコンパクトな外観になります。Aspose.Slides for Python を使用すると、シリーズ全体のこのパラメータを微調整でき、データを変更せずにプレゼンテーションに必要な視覚的バランスを実現できます。

以下のコード例は、シリーズのギャップ幅を設定する方法を示しています:
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

Aspose.Slides には、追加できるシリーズ数に固定の上限はありません。実際の上限はチャートの可読性とアプリケーションで利用可能なメモリによって決まります。

**クラスター内の列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

そのシリーズ（または親シリーズグループ）の [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) 設定を調整します。値を大きくすると列間のスペースが広がり、値を小さくすると列が近づきます。