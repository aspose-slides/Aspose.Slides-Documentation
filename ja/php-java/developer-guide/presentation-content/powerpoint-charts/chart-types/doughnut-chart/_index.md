---
title: PHP を使用してプレゼンテーションのドーナツ チャートをカスタマイズする
linktitle: ドーナツチャート
type: docs
weight: 30
url: /ja/php-java/doughnut-chart/
keywords:
- ドーナツチャート
- センターギャップ
- 穴のサイズ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint 形式に対応した動的なプレゼンテーション用のドーナツチャートの作成とカスタマイズ方法を学びましょう。"
---

## **ドーナツ チャートのセンターギャップを指定する**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java は、ドーナツ チャートの穴のサイズの指定をサポートするようになりました。このトピックでは、例を使ってドーナツ チャートの穴のサイズを指定する方法を見ていきます。

{{% /alert %}} 

ドーナツ チャートの穴のサイズを指定するには、以下の手順に従ってください。

1. Presentation オブジェクトをインスタンス化します。
1. スライドにドーナツ チャートを追加します。
1. ドーナツ チャートの穴のサイズを指定します。
1. プレゼンテーションをディスクに保存します。

以下の例では、ドーナツ チャートの穴のサイズを設定しています。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # プレゼンテーションをディスクに保存
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**複数のリングを持つマルチレベルのドーナツを作成できますか？**

はい。単一のドーナツ チャートに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

**「エクスプロード」ドーナツ（分割されたスライス）はサポートされていますか？**

はい。Exploded Doughnut チャートタイプと、データ ポイントに対するエクスプロージョン プロパティがあります。個々のスライスを分離することができます。

**レポート用にドーナツ チャートの画像（PNG/SVG）を取得するにはどうすればよいですか？**

チャートはシェイプです。ラスタ画像にレンダリングしたり、SVG 画像としてエクスポートしたりできます。

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)
[chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)
[raster image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)
[SVG image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg)