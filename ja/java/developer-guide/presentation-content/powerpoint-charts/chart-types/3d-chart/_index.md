---
title: Java を使用したプレゼンテーションでの 3D チャートのカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/java/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。回転、高さの比率、チャートの深さ、シリーズ間の間隔を Java のサンプルで調整できます。"
---
## **概要**

Aspose.Slides for Java を使用すると、[IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) メソッドで 3D グラフの表示をカスタマイズできます。この記事では、回転、高さの比率、奥行き、直角軸、シリーズ間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D グラフの回転と深さの設定**

以下の例は [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) を作成し、[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) を使用して最初のスライドにスタックされた 3D 縦棒グラフを追加します。既定のシリーズとカテゴリを、各 3 つの値を持つ 2 つのシリーズに置き換えます。ワークシートインデックス `0` はグラフの最初のデータワークシートを識別し、行 `0` がシリーズ名、列 `0` がカテゴリラベルを保持します。

[setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) および [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) メソッドは、グラフの回転をそれぞれ 40 度と 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) は幅の 150% の深さに設定し、[setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) は透視ではなく直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

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

## **3D グラフの高さ比率の調整**

[IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) を使用して、3D グラフの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例はデフォルトデータ（3 つのシリーズと 4 つのカテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) チャートを作成します。高さ比率が 50%、100%、200% の 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、深さ、シリーズ間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変わります。

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

以下の画像は、同等の .NET 例における同じ高さ設定を示しており、Microsoft PowerPoint でエクスポートされています。小さいパーセンテージは平坦なシーンを、 大きいパーセンテージは同じチャートオブジェクト内でより高いシーンを生成します。PowerPoint はシーンに合わせて軸目盛り間隔やラベル配置を調整することもあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% の高さに設定された 3D 縦棒グラフ](height_percent_50.png) | ![幅の 100% の高さに設定された 3D 縦棒グラフ](height_percent_100.png) | ![幅の 200% の高さに設定された 3D 縦棒グラフ](height_percent_200.png) |

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 幅に対するパーセンテージとしての 3D シーンの高さ。 |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | スライド上のチャートオブジェクトの高さ（ポイント単位）。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 幅に対するパーセンテージとしての 3D シーンの深さ。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | マーカー幅に対するパーセンテージとして、深さ軸に沿ったシリーズ間の間隔。 |

高さ設定は、シリンダー、コーン、ピラミッドのバリエーションを含む 3D 縦棒・横棒グラフ、および 3D 折れ線、エリア、円、サーフェス グラフに影響します。上記の比較は検証済みの `Column3D` 型を使用しています。この設定は 2D の `ClusteredColumn` グラフや `BubbleWith3D` グラフの外観は変更しません。これらの名前は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) クラスのメンバーです。他のチャート外観設定については、[Chart Formatting](/slides/ja/java/chart-formatting/) を参照してください。

## **シリーズ間のギャップの調整**

[IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) を使用して、3D グラフの深さ軸に沿ったデータシリーズ間の距離を、マーカー幅のパーセンテージで制御します。**0 から 500** の値を使用できます（0 でギャップなし、値が大きくなるほど間隔が広がります）。チャートの深さが固定されている場合、ギャップを増やすと深さ軸に沿ったマーカーが細くなります。

[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) を通じてグループにアクセスします。この設定はそのグループ内のすべてのシリーズに適用され、アクセスに使用したシリーズだけに限定されません。[IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) は深さギャップを返し、親グループの設定を反映します。

この設定はシリンダー、コーン、ピラミッドのバリエーションを含む 3D 縦棒・横棒グラフ、ならびに 3D 折れ線・エリア グラフに影響します。外観はシリーズが深さ方向に配置されているか、クラスター化されているか、スタックされているかによって変わります。別々のシリーズ間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) クラスの `ChartType.Column3D` を使用してください。

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 深さ軸に沿ったシリーズ間の間隔、マーカー幅のパーセンテージとして。 |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 隣接する棒または列クラスター間の間隔、棒または列幅のパーセンテージとして。 |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | チャート全体の深さ、チャート幅のパーセンテージとして。 |

以下の自己完結型の例は、3 つのシリーズと 4 つのカテゴリを含むデフォルトのチャートデータを使用します。データ、回転、ギャップ幅、チャートの深さが同一の 2 つのプレゼンテーションを保存し、ギャップ深さだけが変わります。

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

以下の画像は、同等の .NET 例における同じギャップ深さ設定を示しており、Microsoft PowerPoint でエクスポートされています。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿ったシリーズ間にギャップがない 3D 縦棒グラフ](gap_depth_0.png) | ![深さ軸に沿ったシリーズ間に 500% のギャップがある 3D 縦棒グラフ](gap_depth_500.png) |

## **3D シリーズタイプとバー形状の変更**

クラスター化シリンダーチャートでは、最初のシリーズはシリンダー形状のバーで始まります。例では、各変更前後に [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) と [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) が返す整数値を出力します。表は対応する定数名を示します。

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

| 最初のシリーズへの変更 | シリーズタイプ | バー形状 |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると、シリーズタイプも `ClusteredColumn3D` に変更されます。コードでシリーズタイプに分岐している場合は、形状変更後に `series.getType()` を呼び出してください。代入前にキャッシュされた値は依然として `ClusteredCone` の分岐を選択します。

![PowerPoint の比較画像：左から右へ、最初のシリーズがシリンダー、コーン、矩形柱として表示されています](series-shapes.png)

## **FAQ**

**Aspose.Slides で 3D モードに対応しているチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの 3D 柱状グラフのバリエーションと、[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) クラスで公開されている関連 3D タイプをサポートしています。正確で最新の一覧については、インストール済みバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) メンバーを確認してください。

**レポートやウェブ用に 3D グラフのラスタ画像を取得できますか？**

はい。[Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) を使用してチャートを画像としてエクスポートするか、[render the entire slide](/slides/ja/java/convert-powerpoint-to-png/) を使用して PNG や JPEG 形式で保存できます。ラスタプレビューが必要な場合や、PowerPoint が不要な状態でドキュメント、ダッシュボード、ウェブページにチャートを埋め込みたい場合に便利です。

**大規模な 3D グラフの構築とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量と視覚的な複雑さに依存します。最適な結果を得るには、3D 効果は最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限りシリーズあたりのデータポイント数を制限し、ターゲットの表示や印刷要件に合わせた適切な解像度とサイズで出力してください。