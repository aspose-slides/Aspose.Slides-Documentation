---
title: PHP を使用したプレゼンテーションでの 3D チャートのカスタマイズ
linktitle: 3D チャート
type: docs
url: /ja/php-java/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PowerPoint プレゼンテーションに 3D チャートを作成します。回転、高さの比率、チャートの深さ、系列間の間隔を PHP の例で調整できます。"
---
## **概要**

Aspose.Slides for PHP via Java は、[Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) メソッドを使用して 3D チャートの表示をカスタマイズできます。この記事では、回転、高さの比率、深さ、直角軸、系列間の間隔を調整し、プレゼンテーションを PPTX 形式で保存する方法を示します。

## **3D チャートの回転と深さの設定**

以下の例は、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を作成し、[ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) を使用して最初のスライドに積み上げ 3D 縦棒チャートを追加します。デフォルトの系列とカテゴリを、各 3 つの値を持つ 2 系列に置き換えます。ワークシート インデックス `0` はチャートの最初のデータ ワークシートを示し、行 `0` に系列名、列 `0` にカテゴリ ラベルが格納されます。

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) と [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) メソッドは、それぞれチャートの回転を 40 度および 270 度に設定します。[setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) は幅の 150% の深さを設定し、[setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) は遠近法の代わりに直角軸を有効にします。結果として得られるプレゼンテーションには、これら 3D 表示設定が適用されたチャートが含まれます。

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

## **3D チャートの高さ比率の調整**

[Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) を使用して、3D チャートの高さを幅のパーセンテージで設定します。これにより、スライド上のチャート オブジェクト自体のサイズを変更せずに 3D シーンの比例が変わります。

以下の例は、デフォルト データ（3 系列と 4 カテゴリ）を持つ [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) チャートを作成します。高さ比率を 50%、100%、200% にした 3 つのプレゼンテーションを保存します。チャートの位置、幅、高さは固定されたままです。データ、回転、深さ、系列間隔、書式設定はすべてのファイルで同一で、高さパーセンテージだけが変わります。

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

以下の画像は、同等の .NET サンプルでの高さ設定を示しており、Microsoft PowerPoint でエクスポートされています。パーセンテージが小さいほどシーンは平坦になり、パーセンテージが大きいほど同一チャート オブジェクト内でシーンが高くなります。PowerPoint はシーンに合わせて軸目盛りの間隔やラベル配置を自動調整することがあります。

| 高さ: 50% | 高さ: 100% | 高さ: 200% |
| --- | --- | --- |
| ![幅の 50% に設定された 3D 縦棒チャート](height_percent_50.png) | ![幅の 100% に設定された 3D 縦棒チャート](height_percent_100.png) | ![幅の 200% に設定された 3D 縦棒チャート](height_percent_200.png) |

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 3D シーンの高さを幅のパーセンテージで指定します。 |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | スライド上のチャート オブジェクトの高さ（ポイント単位）。 |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 3D シーンの深さを幅のパーセンテージで指定します。 |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 深さ軸に沿った系列間の間隔（マーカー幅のパーセンテージ）。 |

高さ設定は、シリンダー、コーン、ピラミッド バリエーションを含む 3D 縦棒・横棒チャート、ならびに 3D 線、エリア、円、サーフェス チャートに影響します。上記の比較は、検証済みの `Column3D` タイプを使用しています。この設定は 2D の `ClusteredColumn` チャートや `BubbleWith3D` チャートの外観は変更しません。これらはすべて [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) クラスのメンバーです。その他のチャート外観設定については、[チャートの書式設定](/slides/ja/php-java/chart-formatting/) を参照してください。

## **系列間のギャップの調整**

[ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) を使用して、3D チャートの深さ軸に沿った系列間の距離をマーカー幅のパーセンテージで制御します。**0 から 500**（両端含む）の値を使用できます：`0` はギャップをなくし、値が大きくなるほど間隔が広がります。チャートの深さが固定されている場合、ギャップを増やすと深さ軸に沿ったマーカーが細くなります。

[ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) でグループにアクセスします。この設定はそのグループ内のすべての系列に適用され、アクセスに使用した系列だけに限定されません。[ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) は深さギャップを返し、親グループの設定を反映します。

この設定は、シリンダー、コーン、ピラミッド バリエーションを含む 3D 縦棒・横棒チャート、および 3D 線・エリア チャートに影響します。系列が深さ方向に配置されているか、クラスター化または積み上げかによって外観が変わります。個別系列間のギャップを明確に比較したい場合は、[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) クラスの `ChartType::Column3D` を使用してください。

これらのメソッドはチャートのさまざまな側面を制御します：

| メソッド | 効果 |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | 深さ軸に沿った系列間の間隔（マーカー幅のパーセンテージ）。 |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | 隣接する棒または縦棒クラスター間の間隔（棒または縦棒幅のパーセンテージ）。 |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | チャート全体の深さを幅のパーセンテージで指定します。 |

以下のサンプルはデフォルト データ（3 系列・4 カテゴリ）を使用し、データ、回転、ギャップ幅、チャート深さは同一で、ギャップ深さだけが異なる 2 つのプレゼンテーションを保存します。

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

以下の画像は、同等の .NET サンプルでのギャップ深さ設定を示しており、Microsoft PowerPoint でエクスポートされています。

| ギャップ深さ: 0% | ギャップ深さ: 500% |
| --- | --- |
| ![深さ軸に沿って系列間のギャップがない 3D 縦棒チャート](gap_depth_0.png) | ![深さ軸に沿って系列間に 500% のギャップがある 3D 縦棒チャート](gap_depth_500.png) |

## **3D 系列タイプとバー形状の変更**

クラスター化シリンダー チャートでは、最初の系列は円柱形のバーで開始します。サンプルは各変更前後に [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) と [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) が返す整数値を出力します。表は対応する定数名を示しています。

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

| 最初の系列の変更 | 系列タイプ | バー形状 |
| --- | --- | --- |
| チャートを作成 | `ClusteredCylinder` | `Cylinder` |
| 系列タイプを `ClusteredCone` に設定 | `ClusteredCone` | `Cone` |
| バー形状を `Box` に設定 | `ClusteredColumn3D` | `Box` |

形状を `Box` に設定すると系列タイプも `ClusteredColumn3D` に変わります。コードが系列タイプで分岐している場合は、形状変更後に [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) を呼び出してください。変更前にキャッシュされた値は依然として `ClusteredCone` の分岐を選択する可能性があります。

![左から右へ、最初の系列が円柱、円錐、長方形の柱として表示された PowerPoint の比較](series-shapes.png)

## **FAQ**

**Aspose.Slides のどのチャート タイプが 3D モードをサポートしていますか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D など、列チャートの 3D バリエーションと、[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) クラスで公開されている関連 3D タイプをサポートします。正確かつ最新の一覧は、インストール済みバージョンの API リファレンスで [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) メンバーを確認してください。

**レポートや Web 用に 3D チャートのラスター画像を取得できますか？**

はい。チャートを画像にエクスポートするには [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) を使用するか、スライド全体を PNG や JPEG などの形式で [render the entire slide](/slides/ja/php-java/convert-powerpoint-to-png/) できます。これにより、ラスタ プレビューが必要な場合や、PowerPoint を必要とせずにドキュメント、ダッシュボード、Web ページにチャートを埋め込むことができます。

**大規模な 3D チャートの作成とレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量と視覚的な複雑さに依存します。最適な結果を得るには、3D エフェクトを最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能であれば系列あたりのデータ ポイント数を制限し、ターゲット ディスプレイまたは印刷要件に合わせた適切な解像度とサイズで出力してください。