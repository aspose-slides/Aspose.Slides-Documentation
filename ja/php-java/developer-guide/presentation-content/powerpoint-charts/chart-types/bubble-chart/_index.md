---
title: PHP を使用してプレゼンテーションでバブルチャートをカスタマイズ
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
description: "Aspose.Slides for PHP via Java を使用して PowerPoint で強力なバブルチャートを作成およびカスタマイズし、データ可視化を簡単に強化できます。"
---

## **バブルチャートサイズスケーリング**
Aspose.Slides for PHP via Java はバブルチャートサイズスケーリングのサポートを提供します。Aspose.Slides for PHP via Java の [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries#getBubbleSizeScale--)、[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeScale--)、および [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) メソッドが追加されました。以下にサンプル例を示します。 
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
メソッド [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) と [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) が [IChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries)、[IChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup) インターフェイスおよび関連クラスに追加されました。**BubbleSizeRepresentation** はバブルチャートにおけるバブルサイズ値の表現方法を指定します。可能な値は、[**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) と [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width) です。したがって、[**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) 列挙型が追加され、バブルチャートサイズとしてデータを表す方法を指定できます。以下にサンプルコードを示します。 
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

**「3-Dエフェクト付きバブルチャート」はサポートされていますか？ 通常のバブルチャートとどのように異なりますか？**

はい。別個のチャートタイプ「Bubble with 3-D」があります。バブルに3-Dスタイリングを適用しますが、追加の軸はありません。データは X-Y-S（サイズ）のままです。このタイプは [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) クラスで利用可能です。

**バブルチャートの系列数やデータポイント数に制限はありますか？**

API レベルでの厳密な上限はありません。制約はパフォーマンスや対象の PowerPoint バージョンによって決まります。可読性とレンダリング速度を考慮し、ポイント数は適切に抑えることを推奨します。

**エクスポートはバブルチャートの外観（PDF、画像）にどのように影響しますか？**

サポートされている形式へのエクスポートはチャートの外観を保持します。レンダリングは Aspose.Slides エンジンが実行します。ラスター/ベクター形式の場合、一般的なチャート描画ルール（解像度、アンチエイリアス）が適用されるため、印刷用に十分な DPI を選択してください。