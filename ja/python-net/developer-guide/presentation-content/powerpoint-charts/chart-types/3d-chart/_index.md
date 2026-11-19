---
title: Python でプレゼンテーションの 3D チャートをカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/python-net/3d-chart/
keywords:
- 3D チャート
- 回転
- 奥行き
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。Python の例で回転、高さの比率、チャートの奥行き、シリーズ間の間隔を調整できます。"
---
## **概要**

Aspose.Slides for Python via .NET を使用すると、[Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) プロパティを介して 3D チャートの表示をカスタマイズできます。本記事では、回転、高さの比率、奥行き、直角軸、シリーズ間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と奥行きの設定**

以下の例は、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) を作成し、[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) を使用して最初のスライドに積み上げ 3D 縦棒チャートを追加します。デフォルトのシリーズとカテゴリを、各 3 つの値を持つ 2 つのシリーズに置き換えます。ワークシートインデックス `0` はチャートの最初のデータワークシートを示し、行 `0` がシリーズ名、列 `0` がカテゴリラベルを保持します。

[rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) と [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) プロパティは、チャートの回転をそれぞれ 40 度と 270 度に設定します。[depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) は幅の 150% の奥行きに設定し、[right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) はパースペクティブの代わりに直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

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

## **3D チャートの高さの比率を調整する**

[Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) を使用して、3D チャートの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例は、デフォルトデータ（3 つのシリーズと 4 つのカテゴリ）を持つ [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) チャートを作成します。高さの比率を 50%、100%、200% に設定した 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、奥行き、シリーズ間隔、書式設定は 3 つのファイルすべてで同一で、高さのパーセンテージだけが変わります。

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

以下の画像は、Microsoft PowerPoint を使用して生成されたプレゼンテーションからエクスポートしたものです。小さいパーセンテージはより平坦なシーンを、 大きいパーセンテージは同じチャートオブジェクト内でより高いシーンを生成します。PowerPoint はシーンに合わせて軸目盛り間隔やラベル配置を調整することがあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% の高さに設定された 3D 縦棒チャート](height_percent_50.png) | ![幅の 100% の高さに設定された 3D 縦棒チャート](height_percent_100.png) | ![幅の 200% の高さに設定された 3D 縦棒チャート](height_percent_200.png) |

これらのプロパティはチャートのさまざまな側面を制御します。

| プロパティ | 効果 |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | 3D シーンの高さを幅のパーセンテージで表したもの。 |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | スライド上のチャートオブジェクトの高さ（ポイント）。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 3D シーンの奥行きを幅のパーセンテージで表したもの。 |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | マーカー幅のパーセンテージで表した、奥行き軸に沿ったシリーズ間の間隔。 |

この高さ設定は、シリンダー、コーン、ピラミッドバリアントを含む 3D 縦棒および横棒チャート、ならびに 3D 線、エリア、円、サーフェスチャートに影響します。上記の比較は検証済みの `COLUMN_3D` タイプを使用しています。この設定は 2D の `CLUSTERED_COLUMN` チャートや `BUBBLE_WITH_3D` チャートの外観は変更しません。これらの名前は [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体のメンバーです。他のチャート外観設定については、[Chart Formatting](/slides/ja/python-net/chart-formatting/) を参照してください。

## **シリーズ間のギャップを調整する**

[ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) を使用して、3D チャートの奥行き軸に沿ったデータシリーズ間の距離を、マーカー幅のパーセンテージで制御します。**0 から 500**（両端含む）の値を使用します：`0` はギャップを除去し、値が大きくなるほど間隔が広がります。チャートの奥行きが固定されている場合、ギャップを増やすと奥行き軸に沿ったマーカーが細くなります。

[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) でグループにアクセスします。この設定はそのグループ内のすべてのシリーズに適用され、アクセスに使用したシリーズだけに限られません。[ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) は読み取り専用で、親グループの設定を反映します。

この設定は、シリンダー、コーン、ピラミッドバリアントを含む 3D 縦棒・横棒チャート、および 3D 線・エリアチャートに影響します。外観はシリーズが奥行き方向に配置されているか、クラスター化されているか、積み上げられているかに依存します。個別シリーズ間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体の `ChartType.COLUMN_3D` を使用してください。

これらのプロパティはチャートのさまざまな側面を制御します。

| プロパティ | 効果 |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 奥行き軸に沿ったシリーズ間の間隔を、マーカー幅のパーセンテージで表したもの。 |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | 隣接する棒または縦棒クラスター間の間隔を、棒または縦棒の幅のパーセンテージで表したもの。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | チャート幅のパーセンテージで表した、全体的なチャートの奥行き。 |

以下の自己完結型例は、デフォルトのチャートデータ（3 つのシリーズと 4 つのカテゴリ）を使用します。データ、回転、ギャップ幅、チャート奥行きが同一の 2 つのプレゼンテーションを保存し、ギャップ奥行きだけが変わります。

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

| ギャップ奥行き: 0% | ギャップ奥行き: 500% |
| --- | --- |
| ![奥行き軸に沿ってシリーズ間にギャップがない 3D 縦棒チャート](gap_depth_0.png) | ![奥行き軸に沿ってシリーズ間に 500% のギャップがある 3D 縦棒チャート](gap_depth_500.png) |

## **3D シリーズタイプと棒形状を変更する**

クラスター化シリンダーチャートでは、最初のシリーズはシリンダー形状の棒で始まります。例では、各変更前後に [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) と [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) を読み取ります。

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

| 最初のシリーズへの変更 | type | bar_3d_shape |
| --- | --- | --- |
| チャートを作成 | `CLUSTERED_CYLINDER` | `CYLINDER` |
| `type` を `CLUSTERED_CONE` に設定 | `CLUSTERED_CONE` | `CONE` |
| `bar_3d_shape` を `BOX` に設定 | `CLUSTERED_COLUMN_3D` | `BOX` |

`BOX` に形状を設定すると、シリーズタイプも `CLUSTERED_COLUMN_3D` に変更されます。コードがシリーズタイプで分岐している場合、形状変更後に `series.type` を読み取ってください。代入前にキャッシュされた値は依然として `CLUSTERED_CONE` ブランチを選択します。

![左から右へ、最初のシリーズがシリンダー、コーン、矩形縦棒として表示される PowerPoint の比較](series-shapes.png)

## **よくある質問**

**Aspose.Slides で 3D モードをサポートしているチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D を含む、縦棒チャートの 3D バリアントや、[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 列挙体で公開されている関連 3D タイプをサポートしています。正確で最新の一覧については、インストール済みバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) メンバーを確認してください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。[Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) を使用してチャートを画像としてエクスポートしたり、[render the entire slide](/slides/ja/python-net/convert-powerpoint-to-png/) を使用して PNG や JPEG 形式に変換できます。ラスタプレビューが必要な場合や、PowerPoint を使用せずにチャートをドキュメント、ダッシュボード、ウェブページに埋め込む場合に便利です。

**大規模な 3D チャートの構築およびレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最適な結果を得るには、3D 効果は最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能であればシリーズあたりのデータポイント数を制限し、ターゲットの表示や印刷要件に合わせた適切なサイズ（解像度と寸法）の出力にレンダリングしてください。