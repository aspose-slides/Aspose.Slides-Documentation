---
title: PHPでプレゼンテーションチャートのプロット領域をカスタマイズする
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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションのチャートプロット領域をカスタマイズする方法をご紹介します。スライドのビジュアルを簡単に向上させましょう。"
---

## **チャート プロット領域の幅と高さを取得する**
Aspose.Slides for PHP via Java はシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルト データでチャートを追加します。
1. 実際の値を取得する前にメソッド[IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) を呼び出します。
1. チャート要素の左上隅に対する実際の X 位置（左）を取得します。
1. チャート要素の左上隅に対する実際の上位置を取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。
```php
  # Presentation クラスのインスタンスを作成します
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


## **チャート プロット領域のレイアウト モードを設定する**
Aspose.Slides for PHP via Java は、チャート プロット領域のレイアウト モードを設定するシンプルな API を提供します。メソッド[**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) と[**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) が[**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) クラスおよび[**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea) インターフェイスに追加されました。プロット領域のレイアウトが手動で定義されている場合、このプロパティは領域を内部（軸と軸ラベルを含まない）でレイアウトするか、外部（軸と軸ラベルを含む）でレイアウトするかを指定します。2 つの可能な値は[**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType) 列挙型で定義されています。

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - プロット領域サイズが領域サイズを決定し、目盛りや軸ラベルは含まれません。
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - プロット領域サイズが領域サイズ、目盛り、軸ラベルを決定します。

サンプルコードは以下のとおりです。
```php
  # Presentation クラスのインスタンスを作成
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


## **FAQ**

**実際の x、実際の y、実際の幅、実際の高さはどの単位で返されますか？**

ポイント単位です。1 インチ = 72 ポイント。これは Aspose.Slides の座標単位です。

**プロット領域とチャート領域はコンテンツの観点でどう異なりますか？**

プロット領域はデータ描画領域（系列、グリッドライン、トレンドラインなど）です。チャート領域はタイトルや凡例などの周囲要素を含みます。3D チャートの場合、プロット領域には壁/床および軸も含まれます。

**レイアウトが手動の場合、プロット領域の x、y、幅、高さはどのように解釈されますか？**

チャート全体サイズに対する比率（0–1）として解釈されます。このモードでは自動位置決めが無効になり、設定した比率が使用されます。

**凡例を追加/移動した後にプロット領域の位置が変わったのはなぜですか？**

凡例はプロット領域の外側にあるチャート領域に配置されますが、レイアウトと利用可能なスペースに影響するため、自動位置決めが有効な場合にプロット領域がシフトすることがあります。（PowerPoint のチャートで標準的な動作です。）