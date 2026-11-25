---
title: Java を使用したプレゼンテーションの 3D チャートのカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/java/3d-chart/
keywords:
- 3D チャート
- 回転
- 奥行き
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。Java のサンプルで回転、高さの比率、チャートの奥行き、シリーズ間の間隔を調整できます。"
---
## **概要**

Aspose.Slides for Java を使用すると、[IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) メソッドを介して 3D チャートのビューをカスタマイズできます。この記事では、回転、高さの比率、奥行き、直角軸、シリーズ間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と奥行きの設定**

以下の例では、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) を作成し、[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) を使用して最初のスライドに積み上げ 3D 列チャートを追加します。既定のシリーズとカテゴリを、各 3 つの値を持つ 2 つのシリーズに置き換えます。ワークシートインデックス `0` はチャートの最初のデータワークシートを示し、行 `0` がシリーズ名を、列 `0` がカテゴリラベルを保持します。

[setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) と [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) メソッドは、チャートの回転をそれぞれ 40 度と 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) は幅の 150% の奥行きに設定し、[setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) は遠近法の代わりに直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたチャートが含まれます。

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

## **3D チャートの表面に画像塗りつぶしを適用する**

3D チャートには、独立して塗りつぶせる 3 つの表面があります: [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--)、[back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--)、および [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--)。表面の [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) を `Picture` に設定し、画像を割り当てます。[picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) と表面の [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) の両方を `Stretch` に設定して、画像の 1 コピーが表面全体にフィットするようにします。

[arrow.png](arrow.png) を作業ディレクトリに保存します。例ではチャートを回転させ、垂直軸の最大値を上げて列間にフロアが見えるようにします。その後、スライドを2回クローンし、各スライドの別の表面に矢印を適用します。3 つのチャートはすべて同じデータ、視点、背景を保持します。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
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

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

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
| ![側壁に沿ってチャート内部を指す矢印](side-wall.png) | ![背面壁に沿って右方向を指す矢印](back-wall.png) | ![列間の床に沿って右方向を指す矢印](floor.png) |

## **3D チャートの高さ比率を調整する**

[IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) を使用して、3D チャートの高さを幅のパーセンテージで設定します。これにより、スライド上のチャートオブジェクトのサイズを変更せずに、3D シーンの比率が変わります。

以下の例では、既定データ（3 つのシリーズと 4 つのカテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) チャートを作成します。高さ比率を 50%、100%、200% に設定した 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、奥行き、シリーズ間の間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変わります。

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

以下の画像は、同等の .NET 例における同じ高さ設定を示しており、Microsoft PowerPoint でエクスポートされました。小さいパーセンテージはフラットなシーンを、 大きいパーセンテージは同じチャートオブジェクト内で高いシーンを生成します。PowerPoint はシーンに合わせて軸目盛り間隔やラベル配置を調整することがあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された高さの 3D 列チャート](height_percent_50.png) | ![幅の 100% に設定された高さの 3D 列チャート](height_percent_100.png) | ![幅の 200% に設定された高さの 3D 列チャート](height_percent_200.png) |

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D シーンの高さを幅のパーセンテージで指定します。 |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | スライド上のチャートオブジェクトの高さ（ポイント単位）。 |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D シーンの奥行きを幅のパーセンテージで指定します。 |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | マーカー幅のパーセンテージで、深度軸に沿ったシリーズ間の間隔を指定します。 |

この高さ設定は、シリンダー、コーン、ピラミッドバリエーションを含む 3D 列および棒チャート、ならびに 3D ライン、エリア、円、サーフェスチャートに影響します。上記の比較は検証済みの `Column3D` 型を使用しています。この設定は 2D の `ClusteredColumn` チャートや `BubbleWith3D` チャートの外観は変更しません。これらの名前は [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) クラスのメンバーです。その他のチャート外観設定については、[チャートの書式設定](/slides/ja/java/chart-formatting/) を参照してください。

## **シリーズ間のギャップを調整する**

[IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) を使用して、3D チャートの深度軸に沿ったデータシリーズ間の距離を、マーカー幅のパーセンテージで制御します。**0 から 500** の範囲の値を使用します（包括的）。`0` はギャップをなくし、値が大きくなるほど間隔が広がります。チャートの深さが固定されている場合、ギャップを増やすと深度軸に沿ってマーカーが細くなります。

[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) を介してグループにアクセスします。この設定は、そのグループ内のすべてのシリーズに適用され、アクセスに使用したシリーズだけに限定されません。[IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) は深度ギャップを返し、親グループの設定を反映します。

この設定は、シリンダー、コーン、ピラミッドバリエーションを含む 3D 列・棒チャート、ならびに 3D ライン・エリアチャートに影響します。外観はシリーズが深度方向に配置されているか、クラスター化されているか、積み上げられているかに依存します。個々のシリーズ間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) クラスの `ChartType.Column3D` を使用してください。

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | 深度軸に沿ったシリーズ間の間隔（マーカー幅のパーセンテージ） |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | 隣接する棒や列クラスター間の間隔（棒や列の幅のパーセンテージ） |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | チャート全体の深さ（チャート幅のパーセンテージ） |

以下の自己完結型例は、3 つのシリーズと 4 つのカテゴリを含む既定のチャートデータを使用します。データ、回転、ギャップ幅、チャートの深さが同一の 2 つのプレゼンテーションを保存し、ギャップ深度だけが変わります。

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

以下の画像は、同等の .NET 例における同じギャップ深度設定を示しており、Microsoft PowerPoint でエクスポートされました。

| ギャップ深度: 0% | ギャップ深度: 500% |
| --- | --- |
| ![深度軸に沿ったシリーズ間にギャップがない 3D 列チャート](gap_depth_0.png) | ![深度軸に沿ったシリーズ間に 500% のギャップがある 3D 列チャート](gap_depth_500.png) |

## **3D シリーズタイプとバー形状を変更する**

クラスタ化シリンダーチャートでは、最初のシリーズはシリンダー形状のバーで開始します。例では、各変更前後に [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) と [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) が返す整数値を出力します。表は対応する定数名を示しています。

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
| チャートを作成する | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone` にシリーズタイプを設定する | `ClusteredCone` | `Cone` |
| バー形状を `Box` に設定する | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると、シリーズタイプも `ClusteredColumn3D` に変更されます。コードでシリーズタイプに分岐している場合は、形状変更後に `series.getType()` を呼び出してください。変更前にキャッシュされた値は依然として `ClusteredCone` のブランチを選択します。

![PowerPoint の比較画像：最初のシリーズが左から順にシリンダー、コーン、長方形の列として表示される](series-shapes.png)

## **FAQ**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの列チャートの 3D バリアントと、[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) クラスで公開されている関連 3D タイプをサポートします。正確で最新の一覧については、インストール済みバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) メンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像にエクスポートするには [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) を使用するか、[スライド全体をレンダリング](/slides/ja/java/convert-powerpoint-to-png/) を使用して PNG や JPEG 形式に変換できます。ラスタプレビューが必要な場合や、PowerPoint を必要とせずにチャートを文書、ダッシュボード、ウェブページに埋め込む場合に便利です。

**大規模な 3D チャートの作成およびレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。ベストな結果を得るには、3D 効果は最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能な限りシリーズごとのデータ点数を制限し、ターゲットの表示や印刷要件に合わせた適切な解像度とサイズでレンダリングしてください。