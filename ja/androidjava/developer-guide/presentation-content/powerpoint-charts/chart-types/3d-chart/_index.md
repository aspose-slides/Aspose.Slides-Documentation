---
title: Android でプレゼンテーションの 3D チャートをカスタマイズ
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
description: "Aspose.Slides for Android via Java を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。Java のサンプルで回転、高さの比率、チャートの深さ、系列間の間隔を調整します。"
---
## **Overview**

Aspose.Slides for Android via Java を使用すると、[IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) メソッドを使用して 3D チャートのビューをカスタマイズできます。本記事では、回転、高さの比率、深さ、直角軸、系列間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と深さの設定**

以下の例では、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) を作成し、[IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) を使用して最初のスライドに積み上げ 3D 列チャートを追加します。デフォルトの系列とカテゴリを、各 3 つの値を持つ 2 系列に置き換えます。ワークシートインデックス `0` はチャートの最初のデータワークシートを示し、行 `0` に系列名、列 `0` にカテゴリラベルが格納されます。

[setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) と [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) メソッドは、チャートの回転をそれぞれ 40 度と 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) は幅の 150% の深さに設定し、[setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) は透視投影の代わりに直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

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

## **3D チャート表面への画像塗りつぶしの適用**

3D チャートには、[side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--)、[back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--)、[floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) の 3 つの表面があり、それぞれ独立して塗りつぶすことができます。表面の [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) を `Picture` に設定し、画像を割り当てます。[picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) と表面の [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) の両方を `Stretch` に設定すると、画像が表面全体に 1 枚でフィットします。

[arrow.png](arrow.png) を作業ディレクトリに保存します。例ではチャートを回転させ、垂直軸の最大値を上げて列の間に床が見えるようにします。その後スライドを 2 回複製し、各スライドの別の表面に矢印を適用します。3 つのチャートはすべて同じデータ、視点、背景を保持します。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    IPPImage arrow = presentation.getImages().addImage(image);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint は次のように 3 つのスライドを表示します。

| 側壁 | 背面壁 | 床 |
| --- | --- | --- |
| ![側壁に沿ってチャート内に向かう矢印](side-wall.png) | ![背面壁を横切って右向きの矢印](back-wall.png) | ![列の間の床を横切って右向きの矢印](floor.png) |

## **3D チャートの高さ比率の調整**

[IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) を使用して、3D チャートの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例では、デフォルトデータ（3 系列、4 カテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) チャートを作成します。高さ比率を 50%、100%、200% に設定した 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、深さ、系列間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変わります。

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

以下の画像は、同等の .NET 例における同じ高さ設定を示し、Microsoft PowerPoint を使用してエクスポートしたものです。パーセンテージが小さいほど平坦なシーンになり、大きいほど同じチャートオブジェクト内で高さのあるシーンになります。PowerPoint はシーンに合わせて軸目盛り間隔やラベル配置を調整する場合があります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された高さの 3D 列チャート](height_percent_50.png) | ![幅の 100% に設定された高さの 3D 列チャート](height_percent_100.png) | ![幅の 200% に設定された高さの 3D 列チャート](height_percent_200.png) |

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D シーンの高さを幅のパーセンテージで設定します。 |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | スライド上のチャートオブジェクトの高さ（ポイント単位）です。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D シーンの深さを幅のパーセンテージで設定します。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 深さ軸に沿った系列間の間隔を、マーカー幅のパーセンテージで設定します。 |

高さ設定は、シリンダー、コーン、ピラミッド バリアントを含む 3D 列チャートおよび棒チャート、ならびに 3D 折れ線、エリア、円、サーフェスチャートに影響します。上記の比較では、検証済みの `Column3D` タイプを使用しています。この設定は、2D の `ClusteredColumn` チャートや `BubbleWith3D` チャートの外観は変更せず、これらの名前は [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) クラスのメンバーです。他のチャート外観設定については、[Chart Formatting](/slides/ja/androidjava/chart-formatting/) を参照してください。

## **系列間のギャップの調整**

[IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) を使用して、3D チャートの深さ軸に沿ったデータ系列間の距離をマーカー幅のパーセンテージで制御します。使用できる値は **0 から 500**（両端含む）です。`0` はギャップをなくし、値が大きくなるほど間隔が広がります。チャートの深さが固定されている場合、ギャップを増やすと深さ軸に沿ったマーカーが細くなります。

[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) を介してグループにアクセスします。この設定は、そのグループ内のすべての系列に適用され、アクセスに使用した系列だけに限定されません。[IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) は深さギャップを返し、親グループの設定を反映します。

この設定は、シリンダー、コーン、ピラミッド バリアントを含む 3D 列チャートおよび棒チャート、ならびに 3D 折れ線およびエリアチャートに影響します。外観は系列が深さ方向に配置されているか、クラスター化されているか、積み上げられているかに依存します。個別系列間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) クラスの `ChartType.Column3D` を使用してください。

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 深さ軸に沿った系列間の間隔を、マーカー幅のパーセンテージで設定します。 |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 隣接する棒または列クラスター間の間隔を、棒または列幅のパーセンテージで設定します。 |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | チャート全体の深さを、チャート幅のパーセンテージで設定します。 |

以下の自己完結型例では、デフォルトのチャートデータ（3 系列、4 カテゴリ）を使用します。データ、回転、ギャップ幅、チャート深さが同一の 2 つのプレゼンテーションを保存し、ギャップ深さだけが変わります。

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

以下の画像は、同等の .NET 例における同じギャップ深さ設定を示し、Microsoft PowerPoint を使用してエクスポートしたものです。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿った系列間にギャップがない 3D 列チャート](gap_depth_0.png) | ![深さ軸に沿った系列間に 500% のギャップがある 3D 列チャート](gap_depth_500.png) |

## **3D 系列タイプと棒形状の変更**

クラスター化シリンダー チャートでは、最初の系列はシリンダー形状の棒で開始します。例では、各変更前後に [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) と [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) が返す整数値を出力します。表は対応する定数名を示しています。

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
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると、系列タイプも `ClusteredColumn3D` に変更されます。コードが系列タイプで分岐している場合は、形状変更後に `series.getType()` を呼び出してください。割り当て前にキャッシュされた値は依然として `ClusteredCone` の分岐を選択します。

![左から右へ、最初の系列がシリンダー、コーン、長方形列として表示される PowerPoint の比較](series-shapes.png)

## **よくある質問**

**Aspose.Slides がサポートする 3D モード対応のチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D など、列チャートの 3D バリアントと、[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) クラスで公開されている関連 3D タイプをサポートしています。正確で最新の一覧については、インストール済みバージョンの API リファレンスの [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) メンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像としてエクスポートするには [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) を使用するか、[スライド全体をレンダリング](/slides/ja/androidjava/convert-powerpoint-to-png/) して PNG や JPEG 形式に出力できます。これにより、ラスタプレビューが必要な場合や、PowerPoint を使用せずにチャートを文書、ダッシュボード、ウェブページに埋め込むことが可能です。

**大規模な 3D チャートの構築およびレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量と視覚的な複雑さに依存します。最適な結果を得るには、3D 効果を最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限り系列ごとのデータポイント数を制限し、ターゲットの表示や印刷要件に合わせた適切な解像度とサイズで出力してください。