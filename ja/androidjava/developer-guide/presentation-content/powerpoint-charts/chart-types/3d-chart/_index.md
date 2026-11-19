---
title: Android のプレゼンテーションで 3D チャートをカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/androidjava/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。回転、高さ比率、チャートの深さ、シリーズ間の間隔を Java のサンプルで調整できます。"
---
## **概要**

Aspose.Slides for Android via Java を使用すると、[IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) メソッドで 3D チャートの表示をカスタマイズできます。この記事では、回転、高さの比率、深さ、直角軸、シリーズ間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と深さの設定**

以下の例は [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) を作成し、[IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) を使用して最初のスライドに積み上げ 3D 縦棒チャートを追加します。デフォルトの系列とカテゴリを、各 3 つの値を持つ 2 系列に置き換えます。ワークシートインデックス `0` はチャートの最初のデータワークシートを示し、行 `0` が系列名、列 `0` がカテゴリラベルを保持します。

[setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) と [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) メソッドはそれぞれチャートの回転を 40 度と 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) は幅の 150% の深さに設定し、[setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) は透視ではなく直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **3D チャートの高さ比率の調整**

[IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) を使用して、3D チャートの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例はデフォルト データ（3 系列と 4 カテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) チャートを作成します。高さ比率を 50%、100%、200% に設定した 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、深さ、シリーズ間隔、書式設定はすべてのファイルで同一で、変わるのは高さのパーセンテージだけです。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下の画像は同等の .NET サンプルで設定した高さを示しており、Microsoft PowerPoint でエクスポートされています。小さいパーセンテージは平坦なシーンを、 大きいパーセンテージは同一チャートオブジェクト内でより高いシーンを生成します。PowerPoint はシーンに合わせて軸目盛り間隔やラベル配置を調整することがあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![3D 縦棒チャート（幅の 50% の高さ）](height_percent_50.png) | ![3D 縦棒チャート（幅の 100% の高さ）](height_percent_100.png) | ![3D 縦棒チャート（幅の 200% の高さ）](height_percent_200.png) |

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D シーンの高さを幅のパーセンテージで指定します。 |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | スライド上のチャートオブジェクトの高さ（ポイント単位）。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D シーンの深さを幅のパーセンテージで指定します。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | マーカー幅のパーセンテージで、深さ軸に沿った系列間の間隔を設定します。 |

高さの設定は、円柱、円錐、ピラミッド バリエーションを含む 3D 縦棒・横棒チャートや、3D 折れ線、面、円、サーフェス チャートに影響します。上記の比較は `Column3D` タイプを使用しています。この設定は 2D の `ClusteredColumn` や `BubbleWith3D` には影響せず、これらは [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) クラスのメンバーです。その他のチャート外観設定については [Chart Formatting](/slides/ja/androidjava/chart-formatting/) を参照してください。

## **シリーズ間のギャップの調整**

[IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) を使用して、3D チャートの深さ軸に沿ったデータ系列間の距離を、マーカー幅のパーセンテージで制御します。使用できる値は **0 から 500**（両端含む）です。`0` はギャップを除去し、数値が大きくなるほど間隔が広がります。チャートの深さが固定されている場合、ギャップを増やすと深さ軸に沿ったマーカーが細くなります。

[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) でグループにアクセスします。この設定はそのグループ内のすべての系列に適用され、取得に使用した系列だけに限定されません。[IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) は深さギャップを返し、親グループの設定を反映します。

この設定は、円柱、円錐、ピラミッド バリエーションを含む 3D 縦棒・横棒チャートや 3D 折れ線・面チャートに影響します。系列が深さ方向に配置されているか、クラスター化されているか、積み上げられているかにより見た目が変わります。別々の系列間のギャップを明確に比較したい場合は、[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) クラスの `ChartType.Column3D` を使用してください。

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 深さ軸に沿った系列間の間隔を、マーカー幅のパーセンテージで指定します。 |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 隣接する棒または柱のクラスター間の間隔を、棒または柱の幅のパーセンテージで指定します。 |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | チャート全体の深さを、チャート幅のパーセンテージで指定します。 |

以下の自己完結型サンプルはデフォルト データ（3 系列と 4 カテゴリ）を使用し、データ、回転、ギャップ幅、チャートの深さは同一で、ギャップ深さのみが変化する 2 つのプレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

以下の画像は同等の .NET サンプルで設定したギャップ深さを示し、Microsoft PowerPoint でエクスポートされています。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿った系列間にギャップがない 3D 縦棒チャート](gap_depth_0.png) | ![深さ軸に沿った系列間に 500% のギャップがある 3D 縦棒チャート](gap_depth_500.png) |

## **3D 系列タイプと棒形状の変更**

クラスター化された円柱チャートでは、最初の系列は円柱形の棒で開始します。例では各変更前後に [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) と [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) が返す整数値を出力します。表は対応する定数名を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 最初の系列への変更 | 系列タイプ | 棒形状 |
| --- | --- | --- |
| チャート作成 | `ClusteredCylinder` | `Cylinder` |
| 系列タイプを `ClusteredCone` に設定 | `ClusteredCone` | `Cone` |
| 棒形状を `Box` に設定 | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると系列タイプも `ClusteredColumn3D` に変更されます。コードで系列タイプに分岐している場合は、形状変更後に `series.getType()` を呼び出してください。割り当て前にキャッシュされた値は依然として `ClusteredCone` の分岐を選択します。

![PowerPoint の比較画像：左から円柱、円錐、矩形柱として表示された最初の系列](series-shapes.png)

## **よくある質問**

**Aspose.Slides で 3D モードをサポートしているチャートタイプはどれですか？**

Aspose.Slides は列チャートの 3D バリエーション（Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D）をサポートし、[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) クラスで公開されている関連 3D タイプも含まれます。正確で最新のリストは、インストール済みバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) のメンバーを確認してください。

**レポートやウェブ向けに 3D チャートのラスタ画像を取得できますか？**

はい。[Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) を使用してチャートを画像としてエクスポートするか、[スライド全体をレンダリング](/slides/ja/androidjava/convert-powerpoint-to-png/) して PNG や JPEG 形式で取得できます。これにより、ラスタ プレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、Web ページにチャートを埋め込むことができます。

**大規模な 3D チャートの構築とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量と視覚的複雑さに依存します。ベストな結果を得るには、3D 効果は最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限り系列あたりのデータポイント数を制限し、ターゲットの表示または印刷要件に合わせた解像度とサイズで出力してください。