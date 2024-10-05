---
title: ツリーマップとサンバーストチャートのデータポイント
type: docs
url: /php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Aspose.Slides for PHPをJava経由で使用したサンバーストグラフ"
description: "Aspose.Slides for PHPをJava経由で使用したサンバーストグラフ、サンバースト図、サンバーストチャート、放射状チャート、放射状グラフ、または多層円グラフ。"
---

PowerPointチャートの他のタイプの中には、二つの「階層型」タイプ - **ツリーマップ**と**サンバースト**チャート（サンバーストグラフ、サンバースト図、放射状チャート、放射状グラフ、多層円グラフとも呼ばれます）があります。これらのチャートは、葉から枝のトップまでのツリーとして整理された階層データを表示します。葉は系列データポイントによって定義され、各後続のネストされたグルーピングレベルは対応するカテゴリによって定義されます。Aspose.Slides for PHPをJava経由で使用することで、サンバーストチャートとツリーマップのデータポイントをフォーマットできます。

ここにサンバーストチャートがあります。Series1列のデータが葉ノードを定義し、他の列が階層データポイントを定義します。

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しいサンバーストチャートを追加することから始めましょう：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="関連情報" %}} 
- [**サンバーストチャートの作成**](/slides/php-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

チャートのデータポイントをフォーマットする必要がある場合、次のものを使用する必要があります：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager)、 
[IChartDataPointLevel](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel)クラス 
および [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPoint#getDataPointLevels--)メソッド 
は、ツリーマップとサンバーストチャートのデータポイントをフォーマットするためのアクセスを提供します。 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager)
はマルチレベルカテゴリにアクセスするために使用されます - それは 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel)オブジェクトのコンテナを表します。
基本的に、データポイント専用のプロパティが追加された 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartCategoryLevelsManager)のラッパーです。 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel)クラスには
二つのメソッドがあります： [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getFormat--) と 
[**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getLabel--) は
対応する設定へのアクセスを提供します。
## **データポイントの値を表示**
「Leaf 4」データポイントの値を表示します：

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントラベルと色を設定**
「Branch 1」データラベルをカテゴリ名の代わりに系列名（「Series1」）を表示するように設定します。次に、テキスト色を黄色に設定します：

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データポイントのブランチカラーを設定**
「Steam 4」ブランチの色を変更します：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)