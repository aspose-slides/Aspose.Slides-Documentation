---
title: JavaScript を使用してプレゼンテーション内の 3D チャートをカスタマイズする
linktitle: 3D チャート
type: docs
url: /ja/nodejs-java/3d-chart/
keywords:
- 3D チャート
- 回転
- 深度
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーションに 3D チャートを作成します。JavaScript の例を使って、回転、高さの比率、チャートの深さ、シリーズ間の間隔を調整します。"
---
## **概要**

Aspose.Slides for Node.js via Java を使用すると、[Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) メソッドを使用して 3D グラフの表示をカスタマイズできます。本記事では、回転、高さの比率、深さ、直角軸、シリーズ間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D グラフの回転と深さの設定**

以下の例では、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) を作成し、[ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) を使用して最初のスライドに 3D 積み上げ縦棒グラフを追加します。デフォルトのシリーズとカテゴリを、各 3 つの値を持つ 2 つのシリーズに置き換えます。ワークシートインデックス `0` はチャートの最初のデータワークシートを示し、行 `0` がシリーズ名、列 `0` がカテゴリラベルを保持します。

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) と [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) メソッドはそれぞれチャートの回転を 40 度と 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) は幅の 150% の深さに設定し、[setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) は遠近法の代わりに直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **3D グラフの表面に画像塗りつぶしを適用する**

3D グラフの [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/)、[back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/)、[floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) を個別に塗りつぶすことができます。表面の [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) を `Picture` に設定し、画像を割り当てます。[picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) と表面の [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) の両方を `Stretch` に設定すると、画像の 1 枚が表面全体にフィットします。

[arrow.png](arrow.png) を作業ディレクトリに保存します。例ではチャートを回転させ、垂直軸の最大値を上げて柱間に床が見えるようにしています。その後、スライドを 2 回複製し、各スライドの別の表面に矢印を適用します。3 つのチャートはすべて同じデータ、視点、背景を保持します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint は 3 つのスライドを次のように表示します。

| 側面壁 | 背面壁 | 床 |
| --- | --- | --- |
| ![側壁に沿ってチャートに向かう矢印](side-wall.png) | ![背面壁を横切って右向きの矢印](back-wall.png) | ![柱間の床を横切って右向きの矢印](floor.png) |

## **3D グラフの高さ比率を調整する**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) を使用して、3D グラフの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例では、既定データ（3 系列、4 カテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) チャートを作成します。高さ比率 50%、100%、200% の 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、深さ、シリーズ間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変わります。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下の画像は、同等の .NET の例における同じ高さ設定を示しており、Microsoft PowerPoint でエクスポートされています。パーセンテージが小さいほど平坦なシーンになり、大きいほど同じチャートオブジェクト内で高さのあるシーンになります。PowerPoint はシーンに合わせて軸目盛り間隔やラベル配置を調整する場合があります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された 3D 縦棒グラフ](height_percent_50.png) | ![幅の 100% に設定された 3D 縦棒グラフ](height_percent_100.png) | ![幅の 200% に設定された 3D 縦棒グラフ](height_percent_200.png) |

これらのメソッドはチャートのさまざまな側面を制御します。

| メソッド | 効果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D シーンの高さを幅のパーセンテージで表したもの |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | スライド上のチャートオブジェクトの高さ（ポイント単位） |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D シーンの深さを幅のパーセンテージで表したもの |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 深度軸に沿ったシリーズ間の間隔（マーカー幅のパーセンテージ） |

高さ設定は、円柱、円錐、ピラミッドバリアントを含む 3D 縦棒・横棒チャートや、3D 折れ線、エリア、円、サーフェスチャートに影響します。上記の比較は、検証済みの `Column3D` タイプを使用しています。この設定は、2D の `ClusteredColumn` チャートや `BubbleWith3D` チャートの外観は変更しません。これらの名前は [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) クラスのメンバーです。他のチャート外観設定については、[チャートの書式設定](/slides/ja/nodejs-java/chart-formatting/) を参照してください。

## **シリーズ間のギャップを調整する**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) を使用して、3D チャートの深度軸に沿ったデータシリーズ間の距離をマーカー幅のパーセンテージで制御します。**0 から 500** の値を使用できます（0 はギャップを削除し、値が大きくなるほど間隔が広がります）。チャートの深さが固定されている場合、ギャップを増やすと深度軸に沿ったマーカーが細くなります。

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) を通じてグループにアクセスします。この設定は、そのグループ内のすべてのシリーズに適用され、アクセスに使用したシリーズだけに限定されません。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) は深さギャップを返し、親グループの設定を反映します。

この設定は、円柱、円錐、ピラミッドバリアントを含む 3D 縦棒・横棒チャートや、3D 折れ線・エリアチャートに影響します。外観はシリーズが深さ方向に配置されているか、クラスター化されているか、積み上げられているかによって変わります。個別シリーズ間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) クラスの `ChartType.Column3D` を使用してください。

これらのメソッドはチャートのさまざまな側面を制御します。

| メソッド | 効果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 深度軸に沿ったシリーズ間の間隔（マーカー幅のパーセンテージ） |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | 隣接する棒または縦棒クラスター間の間隔（棒または縦棒幅のパーセンテージ） |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | チャート全体の深さ（チャート幅のパーセンテージ） |

以下の自己完結型例では、デフォルトのチャートデータ（3 系列、4 カテゴリ）を使用します。データ、回転、ギャップ幅、チャートの深さが同一の 2 つのプレゼンテーションを保存し、ギャップ深さだけが変わります。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下の画像は、同等の .NET の例における同じギャップ深さ設定を示しており、Microsoft PowerPoint でエクスポートされています。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深度軸に沿ったシリーズ間にギャップがない 3D 縦棒チャート](gap_depth_0.png) | ![深度軸に沿ったシリーズ間に 500% のギャップがある 3D 縦棒チャート](gap_depth_500.png) |

## **3D シリーズタイプと棒の形状を変更する**

クラスター化されたシリンダーチャートでは、最初のシリーズはシリンダー形状の棒で始まります。例では、各変更前後に [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) と [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) が返す整数値を出力します。表は対応する定数名を示しています。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 最初のシリーズへの変更 | シリーズタイプ | 棒形状 |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると、シリーズタイプも `ClusteredColumn3D` に変更されます。コードがシリーズタイプで分岐している場合は、形状変更後に `series.getType()` を呼び出してください。代入前にキャッシュされた値は依然として `ClusteredCone` の分岐を選択します。

![PowerPoint の比較画像：最初のシリーズが左から右へシリンダー、円錐、矩形縦棒として表示される](series-shapes.png)

## **よくある質問**

**Aspose.Slides で 3D モードをサポートしているチャートタイプはどれですか？**

Aspose.Slides は、列チャートの 3D バリアント（Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D）および [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) クラスで公開されている関連 3D タイプをサポートしています。正確で最新のリストについては、インストール済みバージョンの API リファレンス内の [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) メンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像にエクスポートするには [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) を使用するか、[スライド全体をレンダリング](/slides/ja/nodejs-java/convert-powerpoint-to-png/) を使用して PNG や JPEG などの形式に変換できます。ラスタプレビューが必要な場合や、PowerPoint を使用せずにチャートを文書、ダッシュボード、ウェブページに埋め込む場合に便利です。

**大規模な 3D チャートの構築とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最適な結果を得るには、3D エフェクトを最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限りシリーズあたりのデータポイント数を制限し、ターゲットの表示または印刷要件に合わせた適切な解像度とサイズで出力をレンダリングしてください。