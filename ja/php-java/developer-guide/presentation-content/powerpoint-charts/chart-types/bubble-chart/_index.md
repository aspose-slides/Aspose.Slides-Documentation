---
title: PHP を使用してプレゼンテーションのバブルチャートをカスタマイズ
linktitle: バブルチャート
type: docs
url: /ja/php-java/bubble-chart/
keywords:
- バブルチャート
- バブルサイズ
- サイズスケーリング
- サイズ表現
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint で強力なバブルチャートを作成およびカスタマイズし、データ可視化を簡単に向上させましょう。"
---

## **バブルチャートのサイズスケーリング**
Aspose.Slides for PHP via Java はバブルチャートのサイズスケーリングをサポートします。Aspose.Slides for PHP via Java の [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbubblesizescale/)、[**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) および [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) メソッドが追加されました。以下にサンプル例を示します。　
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **バブルチャートサイズとしてデータを表す**
メソッド [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) と [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) が [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/)、[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) クラスおよび関連クラスに追加されました。**BubbleSizeRepresentation** はバブルチャートでバブルサイズの値がどのように表現されるかを指定します。可能な値は、[**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) と [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width) です。したがって、[**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) 列挙型が追加され、バブルチャートサイズとしてデータを表す可能な方法を指定します。以下にサンプルコードを示します。　
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**「3-D 効果付きバブルチャート」はサポートされていますか？通常のものと何が異なりますか？**

はい。別のチャートタイプ「Bubble with 3-D」があります。バブルに 3-D スタイルを適用しますが、追加の軸は追加されません。データは X-Y-S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) クラスで利用可能です。

**バブルチャートのシリーズ数とデータポイント数に制限はありますか？**

API レベルでの厳密な上限はありません。制約はパフォーマンスや対象の PowerPoint バージョンによって決まります。可読性と描画速度を考慮して、ポイント数は適切に抑えることを推奨します。

**エクスポートはバブルチャートの外観（PDF、画像）にどのように影響しますか？**

サポートされている形式へのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンが行います。ラスタ/ベクタ形式の場合、一般的なチャート描画ルール（解像度、アンチエイリアスなど）が適用されますので、印刷用に十分な DPI を選択してください。