---
title: Python でプレゼンテーションの 3D グラフをカスタマイズ
linktitle: 3D グラフ
type: docs
url: /ja/python-net/3d-chart/
keywords:
- 3D グラフ
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションに 3D グラフを作成します。Python のサンプルで回転、高さの比率、グラフの深さ、系列間の間隔を調整できます。"
---
## **概要**

Aspose.Slides for Python via .NET を使用すると、[Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) プロパティを使用して 3D グラフの表示をカスタマイズできます。本記事では、回転、高さの比率、深さ、直角軸、系列間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D グラフの回転と深さの設定**

以下の例は、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) を使用して最初のスライドに積み上げ 3D 縦棒グラフを追加します。既定の系列とカテゴリを、各 3 つの値を持つ 2 系列に置き換えます。ワークシートインデックス `0` はグラフの最初のデータワークシートを示し、行 `0` が系列名、列 `0` がカテゴリラベルを保持します。

[rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) と [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) プロパティはそれぞれチャートの回転を 40 度と 270 度に設定します。[depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) は幅の 150% の深さに設定し、[right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) は遠近法ではなく直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **3D グラフの表面に画像塗りつぶしを適用**

[side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/)、[back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/)、[floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) の各面を個別に塗りつぶすことができます。サーフェスの[fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) を `PICTURE` に設定し、画像を割り当てます。画像をサーフェス全体に 1 枚だけ表示させるには、[picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) とサーフェスの[picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) の両方を `STRETCH` に設定します。

作業ディレクトリに [arrow.png](arrow.png) を保存します。この例はチャートを回転させ、縦軸の最大値を上げてフロアが列の間に表示されるようにします。スライドを 2 回複製し、各スライドの異なるサーフェスに矢印を適用します。3 つのチャートはすべて同じデータ、視点、背景を共有します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint は次のように 3 つのスライドを表示します。

| サイド壁 | 背面壁 | フロア |
| --- | --- | --- |
| ![サイド壁に沿ってグラフに向かう矢印](side-wall.png) | ![背面壁を右方向に指す矢印](back-wall.png) | ![列の間のフロアを右方向に指す矢印](floor.png) |

## **3D グラフの高さ比率の調整**

[Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) を使用して、3D グラフの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変えずに 3D シーンの比率が変わります。

以下の例は、デフォルトデータ（3 系列と 4 カテゴリ）を持つ [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) グラフを作成します。高さ比率を 50%、100%、200% に設定した 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、深さ、系列間隔、書式設定はすべてのファイルで同一であり、変わるのは高さパーセンテージだけです。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

以下の画像は、Microsoft PowerPoint を使用して生成されたプレゼンテーションからエクスポートしたものです。小さいパーセンテージは平坦なシーンを、 大きいパーセンテージは同じチャートオブジェクト内で高いシーンを生成します。PowerPoint はシーンに合わせて軸目盛り間隔やラベル配置を調整する場合があります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された高さの 3D 縦棒グラフ](height_percent_50.png) | ![幅の 100% に設定された高さの 3D 縦棒グラフ](height_percent_100.png) | ![幅の 200% に設定された高さの 3D 縦棒グラフ](height_percent_200.png) |

これらのプロパティはチャートの異なる側面を制御します。

| プロパティ | 効果 |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | 3D シーンの高さを幅のパーセンテージで表したもの。 |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | スライド上のチャートオブジェクトの高さ（ポイント単位）。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 3D シーンの深さを幅のパーセンテージで表したもの。 |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | マーカー幅のパーセンテージで表した、深さ軸に沿った系列間の間隔。 |

高さ設定は、円柱、円錐、ピラミッド バリアントを含む 3D 縦棒・横棒グラフ、および 3D 折れ線、面、円、サーフェス グラフに影響します。上記の比較は確認済みの `COLUMN_3D` タイプを使用しています。この設定は 2D の `CLUSTERED_COLUMN` グラフや `BUBBLE_WITH_3D` グラフの外観は変更しません。これらの名前は [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体のメンバーです。その他のグラフ外観設定については、[Chart Formatting](/slides/ja/python-net/chart-formatting/) を参照してください。

## **系列間のギャップの調整**

[ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) を使用して、3D グラフの深さ軸に沿ったデータ系列間の距離を、マーカー幅のパーセンテージで制御します。**0 から 500**（含む）の値を使用します。`0` はギャップをなくし、値が大きくなるほど間隔が広がります。チャートの深さが固定されている場合、ギャップを拡大すると深さ軸に沿ったマーカーが細くなります。

[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) を介してグループにアクセスします。この設定はそのグループ内のすべての系列に適用され、アクセスに使用した系列だけに限定されません。[ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) は読み取り専用で、親グループの設定を反映します。

この設定は、円柱、円錐、ピラミッド バリアントを含む 3D 縦棒・横棒グラフ、および 3D 折れ線・面グラフに影響します。系列が深さ方向に配置されているか、クラスター化または積み上げられているかに応じて外観が変わります。別々の系列間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体の `ChartType.COLUMN_3D` を使用してください。

これらのプロパティはチャートの異なる側面を制御します。

| プロパティ | 効果 |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 深さ軸に沿った系列間の間隔（マーカー幅のパーセンテージ）。 |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | 隣接する棒または縦棒クラスター間の間隔（棒または縦棒幅のパーセンテージ）。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | チャート全体の深さ（チャート幅のパーセンテージ）。 |

以下のセルフコンテインド例は、デフォルトのチャートデータ（3 系列と 4 カテゴリ）を使用します。データ、回転、ギャップ幅、チャート深さは同一で、ギャップ深さだけが異なる 2 つのプレゼンテーションを保存します。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

以下の画像は、Microsoft PowerPoint を使用して生成されたプレゼンテーションからエクスポートしたものです。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿った系列間のギャップがない 3D 縦棒グラフ](gap_depth_0.png) | ![深さ軸に沿った系列間のギャップが 500% の 3D 縦棒グラフ](gap_depth_500.png) |

## **3D 系列タイプとバー形状の変更**

クラスター化円柱チャートでは、最初の系列は円柱バーで開始します。この例は、各変更前後に [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) と [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) を読み取ります。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| 最初の系列への変更 | `type` | `bar_3d_shape` |
| --- | --- | --- |
| チャート作成 | `CLUSTERED_CYLINDER` | `CYLINDER` |
| `type` を `CLUSTERED_CONE` に設定 | `CLUSTERED_CONE` | `CONE` |
| `bar_3d_shape` を `BOX` に設定 | `CLUSTERED_COLUMN_3D` | `BOX` |

`BOX` に形状を設定すると、系列タイプも `CLUSTERED_COLUMN_3D` に変更されます。コードが系列タイプに分岐している場合は、形状を変更した後に `series.type` を再取得してください。割り当て前にキャッシュされた値は依然として `CLUSTERED_CONE` ブランチを選択します。

![左から右へ、円柱、円錐、長方形柱として表示された最初の系列の PowerPoint 比較](series-shapes.png)

## **FAQ**

**Aspose.Slides で 3D モードに対応しているグラフタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D など、縦棒グラフの 3D バリアントと、[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体で公開されている関連 3D タイプをサポートします。正確で最新の一覧については、使用しているバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) のメンバーを確認してください。

**レポートや Web 用に 3D グラフのラスタ画像を取得できますか？**

はい。チャートを画像にエクスポートするには [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) を使用するか、スライド全体を [render the entire slide](/slides/ja/python-net/convert-powerpoint-to-png/) して PNG や JPEG 形式で保存できます。これにより、ラスタプレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、Web ページにチャートを埋め込むことが可能です。

**大規模な 3D グラフの構築とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。ベストな結果を得るためには、3D 効果は最小限に抑え、壁やプロット領域への重いテクスチャを避け、可能な限り系列ごとのデータポイント数を制限し、対象の表示または印刷要件に合わせた適切な解像度とサイズで出力してください。