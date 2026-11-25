---
title: PHP を使用したプレゼンテーションの 3D グラフのカスタマイズ
linktitle: 3D グラフ
type: docs
url: /ja/php-java/3d-chart/
keywords:
- 3D グラフ
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションに 3D グラフを作成します。回転、高さの比率、グラフの深さ、系列間の間隔を PHP のサンプルで調整できます。"
---
## **概要**

Aspose.Slides for PHP via Java は、[Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) メソッドを使用して 3D グラフの表示をカスタマイズできます。この記事では、回転、高さの比率、深さ、直角軸、系列間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D グラフの回転と深さの設定**

以下の例は、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を作成し、[ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) を使用して 1 枚目のスライドに積み上げ 3D 縦棒グラフを追加します。既定の系列とカテゴリをそれぞれ 3 つの値を持つ 2 系列に置き換えます。ワークシートインデックス `0` はグラフの最初のデータ ワークシートを示し、行 `0` に系列名、列 `0` にカテゴリ ラベルが格納されます。

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) および [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) メソッドは、グラフの回転をそれぞれ 40 度と 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) は幅の 150% の深さに設定し、[setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) は遠近法の代わりに直角軸を有効にします。結果として得られるプレゼンテーションには、これらの 3D 表示設定が適用されたグラフが含まれます。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **3D グラフ表面への画像塗りつぶしの適用**

3D グラフの [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/)、[back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/)、および [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) を個別に塗りつぶすことができます。表面の [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) を `Picture` に設定し、画像を割り当てます。[picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) と表面の [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) の両方を `Stretch` に設定すると、画像の 1 枚が表面全体に伸びます。

[arrow.png](arrow.png) を PHP スクリプトの隣に保存します。この例では、グラフを回転させ、垂直軸の最大値を上げて列間に床が見えるようにします。その後、スライドを 2 回複製し、各スライドの別の表面に矢印を適用します。3 つのグラフはすべて同じデータ、視点、背景を保持します。

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint は、次のように 3 枚のスライドを表示します。

| 側壁 | 背面壁 | 床 |
| --- | --- | --- |
| ![側壁に沿ってチャート内に向かう矢印](side-wall.png) | ![背面壁を横切って右向きの矢印](back-wall.png) | ![列間の床を横切って右向きの矢印](floor.png) |

## **3D グラフの高さ比率の調整**

[Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) を使用して、3D グラフの高さを幅のパーセンテージで設定します。これにより、スライド上のグラフオブジェクトのサイズを変更せずに 3D シーンの比率が変わります。

以下の例は、デフォルト データ (3 系列、4 カテゴリ) を持つ [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) グラフを作成します。高さ比率が 50%、100%、200% の 3 つのプレゼンテーションを保存します。グラフの位置、幅、高さは固定されたままです。データ、回転、深さ、系列間隔、書式設定はすべてのファイルで同一で、高さのパーセンテージだけが変わります。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

以下の画像は、同等の .NET 例における同じ高さ設定を示しており、Microsoft PowerPoint でエクスポートされています。パーセンテージが小さいほどシーンは平坦になり、パーセンテージが大きいほど同じグラフオブジェクト内でシーンが高くなります。PowerPoint はシーンに合わせて軸目盛りの間隔やラベルの配置を調整することもあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% の高さに設定された 3D 縦棒グラフ](height_percent_50.png) | ![幅の 100% の高さに設定された 3D 縦棒グラフ](height_percent_100.png) | ![幅の 200% の高さに設定された 3D 縦棒グラフ](height_percent_200.png) |

これらのメソッドはチャートの異なる側面を制御します:

| メソッド | 効果 |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 3D シーンの高さを幅のパーセンテージで表したもの。 |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | スライド上のチャートオブジェクトの高さ（ポイント単位）。 |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 3D シーンの深さを幅のパーセンテージで表したもの。 |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 深度軸に沿った系列間の間隔（マーカー幅のパーセンテージ）。 |

この高さ設定は、円柱、円錐、ピラミッド バリエーションを含む 3D 縦棒・横棒グラフ、および 3D 折れ線、面、円、サーフェス グラフに影響します。上記の比較は検証済みの `Column3D` タイプを使用しています。この設定は 2D の `ClusteredColumn` グラフや `BubbleWith3D` グラフの外観は変更しません。これらの名前は [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) クラスのメンバーです。その他のチャート外観設定については、[Chart Formatting](/slides/ja/php-java/chart-formatting/) を参照してください。

## **系列間のギャップの調整**

[ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) を使用して、3D グラフの深度軸に沿ったデータ系列間の距離をマーカー幅のパーセンテージで制御します。**0 から 500** の範囲の値を使用します（0 はギャップをなくし、値が大きいほど間隔が広がります）。チャートの深さが固定されている場合、ギャップを大きくすると深度軸に沿ったマーカーが細くなります。

[ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスします。この設定は、そのグループ内のすべての系列に適用され、アクセスに使用した系列だけに限定されません。[ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) は深度ギャップを返し、親グループの設定を反映します。

この設定は、円柱、円錐、ピラミッド バリエーションを含む 3D 縦棒・横棒グラフ、および 3D 折れ線・面グラフに影響します。外観は系列が深度方向に配置されているか、クラスター化されているか、積み上げられているかによって変わります。別々の系列間のギャップを明確に比較するには、[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) クラスの `ChartType::Column3D` を使用してください。

これらのメソッドはチャートの異なる側面を制御します:

| メソッド | 効果 |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 深度軸に沿った系列間の間隔（マーカー幅のパーセンテージ）。 |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | 隣接する棒または縦棒クラスター間の間隔（棒または縦棒幅のパーセンテージ）。 |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | チャート全体の深さ（チャート幅のパーセンテージ）。 |

以下の自己完結型例は、3 系列と 4 カテゴリを含むデフォルトのチャートデータを使用します。データ、回転、ギャップ幅、チャートの深さが同一の 2 つのプレゼンテーションを保存し、ギャップ深さだけが変わります。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

以下の画像は、同等の .NET 例における同じギャップ深さ設定を示しており、Microsoft PowerPoint でエクスポートされています。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深度軸に沿った系列間にギャップがない 3D 縦棒グラフ](gap_depth_0.png) | ![深度軸に沿った系列間に 500% のギャップがある 3D 縦棒グラフ](gap_depth_500.png) |

## **3D 系列タイプと棒形状の変更**

クラスター化されたシリンダー グラフでは、最初の系列はシリンダー形状の棒で始まります。この例では、各変更前後に [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) と [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) が返す整数値を出力します。表には対応する定数名が示されています。

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 最初の系列への変更 | 系列タイプ | 棒形状 |
| --- | --- | --- |
| チャートの作成 | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone` に系列タイプを設定 | `ClusteredCone` | `Cone` |
| `Box` に棒形状を設定 | `ClusteredColumn3D` | `Box` |

`Box` に形状を設定すると、系列タイプも `ClusteredColumn3D` に変更されます。コードが系列タイプで分岐している場合は、形状変更後に [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) を呼び出してください。割り当て前にキャッシュされた値は依然として `ClusteredCone` の分岐を選択します。

![PowerPoint の比較画像：最初の系列が左からシリンダー、円錐、矩形柱として表示](series-shapes.png)

## **よくある質問**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は、列グラフの 3D バリエーション（Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D）と、[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) クラスで提供される関連する 3D タイプをサポートしています。正確で最新の一覧については、インストール済みバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) のメンバーを確認してください。

**レポートやウェブ用に 3D グラフのラスタ画像を取得できますか？**

はい。[Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) を使用してグラフを画像としてエクスポートするか、[スライド全体をレンダリング](/slides/ja/php-java/convert-powerpoint-to-png/) して PNG や JPEG 形式に変換できます。ラスタ プレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、ウェブページにグラフを埋め込む際に便利です。

**大規模な 3D グラフの構築とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量と視覚的な複雑さに依存します。最適な結果を得るには、3D 効果を最小限に抑え、壁やプロット領域への重いテクスチャを避け、可能な限り系列ごとのデータポイント数を制限し、ターゲットとなる表示や印刷の要件に合わせた適切な解像度とサイズで出力をレンダリングしてください。