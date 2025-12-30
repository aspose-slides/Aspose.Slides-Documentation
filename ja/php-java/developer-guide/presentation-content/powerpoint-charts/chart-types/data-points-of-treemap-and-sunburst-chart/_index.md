---
title: PHP を使用したツリーマップおよびサンバースト チャートのデータポイントのカスタマイズ
linktitle: ツリーマップおよびサンバースト チャートのデータポイント
type: docs
url: /ja/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- ツリーマップ チャート
- サンバースト チャート
- データポイント
- ラベル色
- ブランチ色
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint 形式に対応したツリーマップおよびサンバースト チャートのデータポイントの管理方法を学びます。"
---

PowerPoint の他のチャートタイプの中で、階層型のチャートが 2 つあります - **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、または Multi Level Pie Chart とも呼ばれます）。これらのチャートは、葉から枝のトップまでツリー構造で階層データを表示します。葉はシリーズのデータポイントで定義され、次のネストされたグルーピングレベルは対応するカテゴリで定義されます。Aspose.Slides for PHP via Java は Sunburst Chart と Treemap のデータポイントの書式設定を可能にします。

以下は Sunburst Chart の例で、Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義しています：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加してみましょう：
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


{{% alert color="primary" title="参考" %}} 
- [**Sunburst チャートの作成**](/slides/ja/php-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

チャートのデータポイントの書式設定が必要な場合は、次のものを使用します：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) classes 
and [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPoint#getDataPointLevels--) method 
provide access to format data points of Treemap and Sunburst charts.

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager) はマルチレベルカテゴリへアクセスするために使用され、[**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) オブジェクトのコンテナを表します。

基本的には [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartCategoryLevelsManager) のラッパーで、データポイント固有のプロパティが追加されています。

[**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) クラスには 2 つのメソッドがあります: [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getFormat--) と [**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getLabel--)。これらは対応する設定にアクセスするために使用されます。

## **データポイントの値を表示**

「Leaf 4」データポイントの値を表示します：
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルと色を設定**

「Branch 1」データラベルをカテゴリ名ではなくシリーズ名 ("Series1") に設定し、テキスト色を黄色に変更します：
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データポイントのブランチの色を設定**

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

## **FAQ**

**Sunburst/Treemap のセグメントの順序（ソート）を変更できますか？**

いいえ。PowerPoint はセグメントを自動的に並べ替えます（通常は値の降順、時計回り）。Aspose.Slides も同様に動作し、直接順序を変更することはできません。データを前処理して順序を調整してください。

**プレゼンテーションのテーマはセグメントとラベルの色にどのように影響しますか？**

チャートの色は、明示的に塗りつぶしやフォントを設定しない限り、プレゼンテーションの[テーマ/パレット](/slides/ja/php-java/presentation-theme/)を継承します。結果を一貫させるには、必要なレベルで実体塗りとテキスト書式を固定してください。

**PDF/PNG へのエクスポートでカスタムブランチの色やラベル設定は保持されますか？**

はい。プレゼンテーションをエクスポートする際、チャートの設定（塗りつぶし、ラベル）は出力フォーマットに保持されます。Aspose.Slides はチャートの書式設定を適用したままレンダリングするためです。

**チャート上にカスタムオーバーレイを配置するために、ラベルや要素の実際の座標を計算できますか？**

はい。チャートのレイアウトが検証された後、要素（例として [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/)）の実際の *x* と *y* が取得可能となり、オーバーレイの正確な位置決めに役立ちます。