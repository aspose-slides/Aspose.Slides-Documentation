---
title: PHP を使用した Treemap および Sunburst チャートのデータポイントのカスタマイズ
linktitle: Treemap と Sunburst チャートのデータポイント
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint 形式に対応した Treemap および Sunburst チャートのデータポイントを管理する方法を学びます。"
---

PowerPointの他のチャートタイプの中で、階層型と呼ばれる2つのタイプがあります - **Treemap** と **Sunburst** チャート（Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph、または Multi Level Pie Chart とも呼ばれます）。これらのチャートは、葉から枝のトップまでツリー構造として階層データを表示します。葉はシリーズのデータポイントで定義され、次のネストされたグループ化レベルは対応するカテゴリで定義されます。Aspose.Slides for PHP via Java は Sunburst Chart と Treemap のデータポイントの書式設定を可能にします。

以下は Sunburst Chart です。Series1 列のデータが葉ノードを定義し、他の列が階層データポイントを定義します:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

プレゼンテーションに新しい Sunburst チャートを追加することから始めましょう：
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


{{% alert color="primary" title="See also" %}} 
- [**PowerPoint プレゼンテーション チャートの作成または更新 (PHP)**](/slides/ja/php-java/create-chart/)
{{% /alert %}}

チャートのデータポイントを書式設定する必要がある場合、以下を使用します：

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevelsmanager/), [**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) クラスと [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) メソッドは、Treemap と Sunburst チャートのデータポイントの書式設定へのアクセスを提供します。

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevelsmanager/) はマルチレベルカテゴリへアクセスするために使用され、[**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) オブジェクトのコンテナを表します。基本的には [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/) のラッパーで、データポイント専用のプロパティが追加されています。 [**ChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/) クラスは、[**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/#getFormat) と [**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointlevel/#getLabel) の2つのメソッドを持ち、対応する設定へのアクセスを提供します。

## **データポイントの値を表示**

「Leaf 4」データポイントの値を表示します：
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **データポイントのラベルと色を設定**

「Branch 1」データラベルをカテゴリ名ではなくシリーズ名（「Series1」）を表示するように設定します。その後、テキスト色を黄色に設定します：
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **データポイントのブランチ色を設定**

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

いいえ。PowerPoint はセグメントを自動的にソートします（通常は降順で時計回り）。Aspose.Slides はこの動作をそのまま反映するため、直接順序を変更することはできません。データを事前処理することで実現します。

**プレゼンテーションのテーマはセグメントやラベルの色にどのように影響しますか？**

チャートの色は、明示的に塗りつぶしやフォントを設定しない限り、プレゼンテーションの[テーマ/パレット](/slides/ja/php-java/presentation-theme/)を継承します。一定の結果を得るには、必要なレベルで実体塗りつぶしとテキスト書式設定を固定してください。

**PDF/PNG へのエクスポートはカスタムブランチ色とラベル設定を保持しますか？**

はい。プレゼンテーションをエクスポートする際、チャートの設定（塗りつぶし、ラベル）は出力形式に保持されます。Aspose.Slides はチャートの書式設定を適用した状態でレンダリングするためです。

**チャート上にカスタムオーバーレイを配置するためにラベルや要素の実際の座標を計算できますか？**

はい。チャートのレイアウトが検証された後、要素（例: [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/)）の実際の *x* と *y* が取得可能になり、オーバーレイの正確な配置に役立ちます。