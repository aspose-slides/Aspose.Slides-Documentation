---
title: PHPでプレゼンテーションチャートのプロット領域をカスタマイズ
linktitle: プロット領域
type: docs
url: /ja/php-java/chart-plot-area/
keywords:
- チャート
- プロット領域
- プロット領域の幅
- プロット領域の高さ
- プロット領域のサイズ
- レイアウトモード
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPointプレゼンテーションでAspose.Slides for PHP via Javaを使用してチャートのプロット領域をカスタマイズする方法をご紹介します。スライドのビジュアルを簡単に向上させましょう。"
---

## **チャートプロット領域の幅と高さを取得する**
Aspose.Slides for PHP via Java はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルト データでチャートを追加します。
1. 実際の値を取得する前に、[Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) メソッドを呼び出します。
1. チャートの左上隅に対するチャート要素の実際の X 位置（左）を取得します。
1. チャートの左上隅に対するチャート要素の実際の上位置を取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。
```php
  # Presentation クラスのインスタンスを作成する
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **チャートプロット領域のレイアウトモードを設定する**
Aspose.Slides for PHP via Java は、チャートプロット領域のレイアウトモードを設定するシンプルな API を提供します。メソッド [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) と [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) が [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) クラスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティはプロット領域を内部（軸や軸ラベルを含まない）でレイアウトするか、外部（軸や軸ラベルを含む）でレイアウトするかを指定します。2 つの可能な値は、[**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType) 列挙型で定義されています。

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - プロット領域のサイズがプロット領域のサイズを決定し、目盛りや軸ラベルは含まれないことを指定します。
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - プロット領域のサイズがプロット領域、目盛り、軸ラベルのサイズを決定することを指定します。

以下にサンプルコードを示します。
```php
  # Presentation クラスのインスタンスを作成する
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**実際の x、実際の y、実際の幅、実際の高さはどの単位で返されますか？**

ポイント単位です。1 インチ = 72 ポイントです。これは Aspose.Slides の座標単位です。

**プロット領域はコンテンツの面でチャート領域とどう違いますか？**

プロット領域はデータ描画領域（系列、グリッドライン、トレンドラインなど）です。チャート領域は周囲の要素（タイトル、凡例など）を含みます。3D チャートでは、プロット領域は壁・床や軸も含みます。

**レイアウトが手動の場合、プロット領域の x、y、幅、高さはどのように解釈されますか？**

これらはチャート全体サイズに対する割合（0〜1）で表されます。このモードでは自動配置が無効になり、設定した割合が使用されます。

**凡例を追加/移動した後、プロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側のチャート領域に配置されますが、レイアウトと利用可能なスペースに影響するため、自動配置が有効な場合にプロット領域が移動することがあります。（これは PowerPoint のチャートにおける標準的な動作です。）