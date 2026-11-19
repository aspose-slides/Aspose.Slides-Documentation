---
title: JavaScript を使用してプレゼンテーションの 3D チャートをカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/nodejs-java/3d-chart/
keywords:
- 3D チャート
- 回転
- 奥行き
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。JavaScript のサンプルで回転、高さの比率、チャートの奥行き、系列間の間隔を調整できます。"
---
## **概要**

Aspose.Slides for Node.js via Java では、[Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) メソッドを使用して 3D チャートの表示をカスタマイズできます。本記事では、回転、高さの比率、奥行き、直角軸、シリーズ間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と奥行きの設定**

以下の例では、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) を作成し、[ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) を使用して最初のスライドに積み上げ 3D 列チャートを追加します。デフォルトの系列とカテゴリを、各 3 つの値を持つ 2 系列に置き換えます。ワークシートインデックス `0` はチャートの最初のデータ ワークシートを示し、行 `0` が系列名、列 `0` がカテゴリ ラベルを保持します。

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) と [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) メソッドは、それぞれチャートの回転を 40 度と 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) は幅の 150% の深さに設定し、[setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) は透視投影の代わりに直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

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

## **3D チャートの高さ比率の調整**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) を使用して、3D チャートの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例では、デフォルト データ（3 系列と 4 カテゴリ）で [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) チャートを作成します。高さ比率を 50％、100％、200％ に設定した 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、奥行き、シリーズ間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変わります。

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

以下の画像は、同等の .NET 例における同じ高さ設定を示しており、Microsoft PowerPoint でエクスポートされています。小さいパーセンテージは平坦なシーンを、 大きいパーセンテージは同じチャートオブジェクト内でより高いシーンを生成します。PowerPoint はシーンに合わせて軸の目盛り間隔やラベルの配置を調整することもあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された高さの 3D 列チャート](height_percent_50.png) | ![幅の 100% に設定された高さの 3D 列チャート](height_percent_100.png) | ![幅の 200% に設定された高さの 3D 列チャート](height_percent_200.png) |

これらのメソッドはチャートのさまざまな側面を制御します。

| メソッド | 効果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D シーンの高さを幅のパーセンテージとして設定します。 |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | スライド上のチャートオブジェクトの高さをポイント単位で設定します。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D シーンの奥行きを幅のパーセンテージとして設定します。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | マーカー幅のパーセンテージとして、深さ軸に沿った系列間の間隔を設定します。 |

高さ設定は、円筒、円錐、ピラミッドのバリエーションを含む 3D 列および棒チャート、ならびに 3D 線、エリア、円、サーフェスチャートに影響します。上記の比較では、検証済みの `Column3D` 型が使用されています。この設定は、2D の `ClusteredColumn` チャートや `BubbleWith3D` チャートの外観は変更しません。これらの名前は [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) クラスのメンバーです。その他のチャート外観設定については、[Chart Formatting](/slides/ja/nodejs-java/chart-formatting/) を参照してください。

## **系列間のギャップの調整**

3D チャートの深さ軸に沿ったデータ系列間の距離を、マーカー幅のパーセンテージで表すために [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) を使用します。**0 から 500** の値を使用できます（両端含む）：`0` はギャップを除去し、値が大きくなるほど間隔が広がります。チャートの深さが固定されている場合、ギャップを増やすと深さ軸に沿ったマーカーが細くなります。

グループは [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) で取得します。この設定は、そのグループ内のすべての系列に適用され、アクセスに使用した系列だけに限定されません。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) は深さギャップを返し、親グループの設定を反映します。

この設定は、円筒、円錐、ピラミッドのバリエーションを含む 3D 列および棒チャート、ならびに 3D 線およびエリアチャートに影響します。外観は系列が深さ方向に配置されているか、クラスター化されているか、スタックされているかによって変わります。個別系列間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) クラスの `ChartType.Column3D` を使用します。

| メソッド | 効果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | マーカー幅のパーセンテージとして、深さ軸に沿った系列間の間隔を設定します。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | バーまたは列クラスター間の隣接間隔を、バーまたは列幅のパーセンテージとして設定します。 |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | チャート全体の深さを、チャート幅のパーセンテージとして設定します。 |

以下の自己完結型サンプルは、デフォルトのチャートデータ（3 系列と 4 カテゴリ）を使用します。データ、回転、ギャップ幅、チャートの深さはすべて同一で、ギャップ深さだけが変わる 2 つのプレゼンテーションを保存します。

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

以下の画像は、同等の .NET 例における同じギャップ深さ設定を示しており、Microsoft PowerPoint でエクスポートされています。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿った系列間にギャップのない 3D 列チャート](gap_depth_0.png) | ![深さ軸に沿った系列間に 500% のギャップがある 3D 列チャート](gap_depth_500.png) |

## **3D 系列タイプとバー形状の変更**

クラスター化されたシリンダー チャートでは、最初の系列はシリンダー形状のバーから始まります。この例では、各変更前後に [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) と [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) が返す整数値を出力します。表は対応する定数名を示しています。

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

| 最初の系列への変更 | 系列タイプ | バー形状 |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると、系列タイプも `ClusteredColumn3D` に変更されます。コードが系列タイプで分岐している場合は、形状変更後に `series.getType()` を呼び出してください。代入前にキャッシュされた値は依然として `ClusteredCone` の分岐を選択します。

![左から右へ、最初の系列がシリンダー、円錐、長方形の列として表示された PowerPoint 比較](series-shapes.png)

## **よくある質問**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの列チャートの 3D バリエーションと、[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) クラスで公開されている関連 3D タイプをサポートします。正確で最新の一覧は、インストールされているバージョンの API リファレンスの [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) メンバーを確認してください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像にエクスポートするには [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) を使用するか、[render the entire slide](/slides/ja/nodejs-java/convert-powerpoint-to-png/) を使用して PNG や JPEG 形式に変換できます。これは、ラスタプレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、ウェブページにチャートを埋め込む際に便利です。

**大規模な 3D チャートの作成およびレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最適な結果を得るには、3D 効果を最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限り系列ごとのデータポイント数を制限し、ターゲットの表示や印刷要件に合わせた適切な解像度とサイズで出力してください。