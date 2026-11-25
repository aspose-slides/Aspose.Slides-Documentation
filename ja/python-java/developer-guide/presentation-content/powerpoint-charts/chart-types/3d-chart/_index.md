---
title: Python を使用してプレゼンテーションの 3D チャートをカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/python-java/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。Python のサンプルで回転、高さ比率、チャートの深さ、シリーズ間の間隔を調整できます。"
---
## **概要**

Aspose.Slides for Python via Java を使用すると、[Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) メソッドを使って 3D グラフの表示をカスタマイズできます。本記事では、回転、高さ比率、深さ、直角軸、シリーズ間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D グラフの回転と深さの設定**

以下の例は、[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) を作成し、[ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) を使用して最初のスライドに積み上げ 3D 柱状グラフを追加します。既定のシリーズとカテゴリを、各 3 つの値を持つ 2 系列に置き換えます。ワークシートインデックス `0` はグラフの最初のデータ ワークシートを示し、行 `0` がシリーズ名、列 `0` がカテゴリ ラベルを保持します。

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) と [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) メソッドは、グラフの回転をそれぞれ 40 度と 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) は幅の 150% の深さに設定し、[setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) は遠近法ではなく直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

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

## **3D グラフの表面に画像塗りつぶしを適用**

3D グラフには、[側壁](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall)、[背面壁](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall)、[床](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) の 3 つの表面があり、個別に塗りつぶすことができます。表面の[塗りつぶしタイプ](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType)を `Picture` に設定し、画像を割り当てます。[画像塗りつぶしモード](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode)と表面の[画像タイプ](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType)を `Stretch` に設定して、画像の 1 コピーが表面全体にフィットするようにします。

作業ディレクトリに [arrow.png](arrow.png) を保存します。この例ではグラフを回転させ、縦軸の最大値を上げて床が柱の間に見えるようにします。その後スライドを 2 回複製し、各スライドで異なる表面に矢印を適用します。3 つのグラフすべてが同じデータ、視点、背景を保持します。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint は次のように 3 枚のスライドを表示します。

| 側壁 | 背面壁 | 床 |
| --- | --- | --- |
| ![側壁に沿ってグラフ内へ向かう矢印](side-wall.png) | ![背面壁を横切って右向きの矢印](back-wall.png) | ![柱の間の床を横切って右向きの矢印](floor.png) |

## **3D グラフの高さ比率の調整**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) を使用して、3D グラフの高さを幅のパーセンテージで設定します。これにより、スライド上のグラフ オブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例は、デフォルト データ（3 系列、4 カテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) グラフを作成し、高さ比率が 50%、100%、200% の 3 つのプレゼンテーションを保存します。グラフの位置、幅、高さは固定されたままです。データ、回転、深さ、シリーズ間隔、書式設定はすべて同一で、高さ比率だけが変わります。

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

以下の画像は、同等の .NET 例で同じ高さ設定を示したもので、Microsoft PowerPoint でエクスポートしたものです。小さいパーセンテージは平坦なシーンを、大きいパーセンテージは同じグラフ オブジェクト内でより高いシーンを生成します。PowerPoint はシーンに合わせて軸目盛り間隔やラベル位置を調整する場合があります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された高さを持つ 3D 柱状グラフ](height_percent_50.png) | ![幅の 100% に設定された高さを持つ 3D 柱状グラフ](height_percent_100.png) | ![幅の 200% に設定された高さを持つ 3D 柱状グラフ](height_percent_200.png) |

これらのメソッドはグラフのさまざまな側面を制御します:

| メソッド | 効果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 高さの 3D シーンを幅のパーセンテージとして設定します。 |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | スライド上のグラフオブジェクトの高さ（ポイント単位）を設定します。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 深さの 3D シーンを幅のパーセンテージとして設定します。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | マーカー幅のパーセンテージとして、深さ軸に沿ったシリーズ間の間隔を設定します。 |

高さ設定は、シリンダー、コーン、ピラミッド バリエーションを含む 3D 柱状・棒グラフや、3D 折れ線、面、円、サーフェス グラフに影響します。上記の比較は検証済みの `Column3D` タイプを使用しています。この設定は 2D の `ClusteredColumn` グラフや `BubbleWith3D` グラフの外観は変更しません。これらの名前は [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) クラスのメンバーです。他のチャート外観設定については、[チャートの書式設定](/slides/ja/python-java/chart-formatting/) を参照してください。

## **シリーズ間のギャップの調整**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) を使用して、3D グラフの深さ軸に沿ったデータ系列間の距離をマーカー幅のパーセンテージで制御します。**0 から 500**（含む）の値を使用します：`0` はギャップをなくし、値が大きいほど間隔が広くなります。チャートの深さが固定されている場合、ギャップを増やすと深さ軸に沿ったマーカーが細くなります。

グループは [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) を介して取得します。この設定はそのグループ内のすべての系列に適用され、アクセスに使用した系列だけに限定されません。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) は深さギャップを返し、親グループの設定を反映します。

この設定は、シリンダー、コーン、ピラミッド バリエーションを含む 3D 柱状・棒グラフや、3D 折れ線・面グラフに影響します。系列が深さ方向に配置されているか、クラスター化または積み上げられているかによって外観が変わります。個別系列間のギャップを明確に比較したい場合は、[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) クラスの `ChartType.Column3D` を使用してください。

これらのメソッドはグラフのさまざまな側面を制御します:

| メソッド | 効果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | マーカー幅のパーセンテージとして、深さ軸に沿ったシリーズ間の間隔を設定します。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | バーまたは柱クラスター間の隣接間隔をバーや柱の幅のパーセンテージとして設定します。 |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | グラフ全体の深さを幅のパーセンテージとして設定します。 |

以下の自己完結型サンプルは、デフォルト データ（3 系列、4 カテゴリ）を使用し、データ、回転、ギャップ幅、チャート深さは同一で、ギャップ深さだけが異なる 2 つのプレゼンテーションを保存します。

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

以下の画像は、同等の .NET 例で同じギャップ深さ設定を示したもので、Microsoft PowerPoint でエクスポートしたものです。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿うシリーズ間にギャップがない 3D 柱状グラフ](gap_depth_0.png) | ![深さ軸に沿うシリーズ間に 500% のギャップがある 3D 柱状グラフ](gap_depth_500.png) |

## **3D シリーズタイプとバー形状の変更**

クラスター化シリンダー グラフでは、最初の系列はシリンダー形状で始まります。例では、[ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) と [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) が各変更前後に返す整数値を出力します。対応する定数名は以下の表に示されています。

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

| 最初のシリーズへの変更 | シリーズタイプ | バー形状 |
| --- | --- | --- |
| グラフ作成 | `ClusteredCylinder` | `Cylinder` |
| 系列タイプを `ClusteredCone` に設定 | `ClusteredCone` | `Cone` |
| バー形状を `Box` に設定 | `ClusteredColumn3D` | `Box` |

バー形状を `Box` に設定すると、シリーズタイプも `ClusteredColumn3D` に変更されます。コードでシリーズタイプに分岐している場合は、形状変更後に `series.getType()` を呼び出してください。割り当て前にキャッシュされた値は依然として `ClusteredCone` の分岐を選択します。

![PowerPoint の比較: 左から右へ、最初のシリーズがシリンダー、コーン、長方形の柱として表示されます](series-shapes.png)

## **FAQ**

**Aspose.Slides の 3D モードに対応しているチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの 3D バリエーションの柱状グラフと、[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) クラスを通じて提供される関連 3D タイプをサポートします。正確で最新の一覧は、使用中のバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) メンバーを確認してください。

**レポートや Web 用に 3D グラフのラスター画像を取得できますか？**

はい。[Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) を使用してチャートを画像としてエクスポートするか、[スライド全体をレンダリング](/slides/ja/python-java/convert-powerpoint-to-png/) して PNG や JPEG などの形式で保存できます。これにより、ラスター プレビューが必要な場合や、PowerPoint を必要とせずにドキュメント、ダッシュボード、Web ページにチャートを埋め込むことが可能です。

**大規模な 3D グラフの構築とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最適な結果を得るには、3D エフェクトは最小限に抑え、壁やプロット領域への重いテクスチャは避け、可能であれば系列あたりのデータ ポイント数を制限し、ターゲット表示または印刷要件に合わせた適切な解像度とサイズでレンダリングしてください。