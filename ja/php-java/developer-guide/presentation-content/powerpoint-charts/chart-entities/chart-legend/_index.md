---
title: PHP を使用したプレゼンテーションのチャート凡例のカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/php-java/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してチャート凡例をカスタマイズし、調整された凡例書式設定で PowerPoint プレゼンテーションを最適化します。"
---

## **凡例の位置設定**
凡例のプロパティを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、チャート凡例の位置とサイズを設定しています。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # スライドの参照を取得
    $slide = $pres->getSlides()->get_Item(0);
    # スライドにクラスタード カラム チャートを追加
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # 凡例のプロパティを設定
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # プレゼンテーションを書き出し
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **凡例のフォントサイズを設定する**
Aspose.Slides for PHP via Java を使用すると、開発者は凡例のフォントサイズを設定できます。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **個別凡例エントリのフォントサイズを設定する**
Aspose.Slides for PHP via Java を使用すると、開発者は個別の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**凡例を有効にして、チャートが凡例の上に重ねるのではなく自動的にスペースを確保するようにできますか？**

はい。非オーバーレイモード（[setOverlay(false)](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/)）を使用します。この場合、プロット領域が縮小して凡例を収めます。

**凡例ラベルを複数行にすることはできますか？**

はい。スペースが不足すると長いラベルは自動的に折り返されます。改行文字（\n）を系列名に含めることで強制改行も可能です。

**凡例をプレゼンテーションテーマのカラースキームに従わせるにはどうすればよいですか？**

凡例やそのテキストに明示的な色・塗り・フォントを設定しないでください。テーマから継承され、デザインが変更されても正しく更新されます。