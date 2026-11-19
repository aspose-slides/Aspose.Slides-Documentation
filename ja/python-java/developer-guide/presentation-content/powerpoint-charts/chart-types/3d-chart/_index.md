---
title: Python を使用したプレゼンテーションの 3D チャートのカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/python-java/3d-chart/
keywords:
- 3D チャート
- 回転
- 奥行き
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。Python のサンプルで回転、高さの比率、チャートの奥行き、シリーズ間の間隔を調整できます。"
---
## **概要**

Aspose.Slides for Python via Java を使用すると、[Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) メソッドを使って 3D チャートの表示をカスタマイズできます。この記事では、回転、高さの比率、奥行き、直角軸、シリーズ間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と奥行きの設定**

以下の例は、[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) を作成し、[ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) を使用して最初のスライドに積み上げ 3D 縦棒チャートを追加します。デフォルトのシリーズとカテゴリを、各 3 つの値を持つ 2 つのシリーズに置き換えます。ワークシートインデックス `0` はチャートの最初のデータワークシートを示し、行 `0` がシリーズ名、列 `0` がカテゴリラベルを保持します。

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) と [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) メソッドは、それぞれチャートの回転を 40 度と 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) は幅の 150% の奥行きに設定し、[setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) は透視図法ではなく直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **3D チャートの高さの比率を調整**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) を使用して、3D チャートの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例は、デフォルトデータ（3 つのシリーズと 4 つのカテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) チャートを作成します。高さの比率 50%、100%、200% の 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、奥行き、シリーズ間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変更されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下の画像は、同等の .NET 例で同じ高さ設定を示しており、Microsoft PowerPoint でエクスポートされています。小さいパーセンテージは平坦なシーンを、 大きいパーセンテージは同じチャートオブジェクト内で高いシーンを生成します。PowerPoint はシーンに合わせて軸目盛り間隔やラベル配置を調整する場合があります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% の高さに設定された 3D 縦棒チャート](height_percent_50.png) | ![幅の 100% の高さに設定された 3D 縦棒チャート](height_percent_100.png) | ![幅の 200% の高さに設定された 3D 縦棒チャート](height_percent_200.png) |

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 3D シーンの高さを幅のパーセンテージで設定します。 |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | スライド上のチャートオブジェクトの高さ（ポイント単位）。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 幅のパーセンテージとしての 3D シーンの奥行き。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | マーカー幅のパーセンテージで表した、深さ軸に沿ったシリーズ間の間隔。 |

高さの設定は、シリンダー、円錐、ピラミッド バリエーションを含む 3D 縦棒および横棒チャート、ならびに 3D 線、エリア、円、サーフェスチャートに影響します。上記の比較は検証済みの `Column3D` タイプを使用しています。この設定は 2D の `ClusteredColumn` チャートや `BubbleWith3D` チャートの外観は変えません。これらの名前は [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) クラスのメンバーです。他のチャート外観設定については、[Chart Formatting](/slides/ja/python-java/chart-formatting/) を参照してください。

## **シリーズ間の間隔を調整**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) を使用して、3D チャートの深さ軸に沿ったデータシリーズ間の距離を、マーカー幅のパーセンテージで制御します。**0 から 500** の値を使用できます（両端含む）：`0` は間隔を削除し、値が大きくなるほど間隔が広がります。チャートの深さが固定されている場合、間隔を増やすと深さ軸に沿ったマーカーが細くなります。

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) でグループにアクセスします。この設定はそのグループ内のすべてのシリーズに適用され、アクセスに使用したシリーズだけに限定されません。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) は深さの間隔を返し、親グループの設定を反映します。

この設定は、シリンダー、円錐、ピラミッド バリエーションを含む 3D 縦棒・横棒チャート、ならびに 3D 線とエリアチャートに影響します。外観はシリーズが深さ方向に配置されているか、クラスター化されているか、積み上げられているかによって変わります。個別のシリーズ間の間隔を明確に比較するには、[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) クラスの `ChartType.Column3D` を使用してください。

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 深さ軸に沿ったシリーズ間の間隔（マーカー幅のパーセンテージ） |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | 隣接するバーまたは列クラスター間の間隔（バーまたは列幅のパーセンテージ） |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | チャート全体の奥行き（チャート幅のパーセンテージ） |

以下の自己完結型例は、デフォルトのチャートデータ（3 つのシリーズと 4 つのカテゴリ）を使用します。データ、回転、間隔幅、チャートの深さが同一の 2 つのプレゼンテーションを保存し、間隔の深さだけが変更されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下の画像は、同等の .NET 例で同じ間隔深さ設定を示しており、Microsoft PowerPoint でエクスポートされています。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿ってシリーズ間にギャップがない 3D 縦棒チャート](gap_depth_0.png) | ![深さ軸に沿ってシリーズ間に 500% のギャップがある 3D 縦棒チャート](gap_depth_500.png) |

## **3D シリーズ タイプとバー形状の変更**

クラスター化シリンダーチャートでは、最初のシリーズはシリンダー形状のバーから始まります。例では、各変更前後に [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) と [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) が返す整数値を出力します。表は対応する定数名を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 最初のシリーズへの変更 | シリーズ タイプ | バー形状 |
| --- | --- | --- |
| チャートの作成 | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone` にシリーズタイプを設定 | `ClusteredCone` | `Cone` |
| `Box` にバー形状を設定 | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると、シリーズタイプも `ClusteredColumn3D` に変更されます。コードがシリーズタイプで分岐している場合は、形状変更後に `series.getType()` を呼び出してください。割り当て前にキャッシュされた値は依然として `ClusteredCone` ブランチを選択します。

![PowerPoint の比較画像：左から右へ、最初のシリーズがシリンダー、円錐、長方形の列として表示](series-shapes.png)

## **よくある質問**

**Aspose.Slides がサポートする 3D モード対応のチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの列チャートの 3D バリエーションや、[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) クラスで公開されている関連 3D タイプをサポートしています。正確で最新の一覧については、インストール済みバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) のメンバーを確認してください。

**レポートや Web 用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) で画像としてエクスポートしたり、[スライド全体をレンダリング](/slides/ja/python-java/convert-powerpoint-to-png/) して PNG や JPEG 形式に変換できます。ラスタプレビューが必要な場合や、PowerPoint を必要とせずにチャートを文書、ダッシュボード、Web ページに埋め込む際に便利です。

**大規模な 3D チャートの作成とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。ベストな結果を得るには、3D 効果を最小限に抑え、壁やプロット領域への重いテクスチャを避け、可能な限りシリーズごとのデータポイント数を制限し、対象の表示や印刷要件に合わせた適切なサイズ（解像度と寸法）で出力をレンダリングしてください。