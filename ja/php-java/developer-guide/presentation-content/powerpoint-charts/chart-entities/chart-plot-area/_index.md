---
title: チャートプロットエリア
type: docs
url: /php-java/chart-plot-area/
---


## **チャートプロットエリアの幅と高さを取得する**
Aspose.Slides for PHP via Javaは、シンプルなAPIを提供します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 実際の値を取得する前に、メソッド[IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--)を呼び出します。
1. チャートの左上隅に対するチャート要素の実際のX位置（左）を取得します。
1. チャートの左上隅に対するチャート要素の実際の上部を取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。

```php
  # Presentationクラスのインスタンスを作成
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

## **チャートプロットエリアのレイアウトモードを設定する**
Aspose.Slides for PHP via Javaは、チャートプロットエリアのレイアウトモードを設定するためのシンプルなAPIを提供します。メソッド[**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-)と[**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--)が、[**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea)クラスと[**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea)インターフェイスに追加されました。プロットエリアのレイアウトが手動で定義されている場合、このプロパティは、プロットエリアを内部（軸と軸ラベルを含まない）または外部（軸と軸ラベルを含む）でレイアウトするかどうかを指定します。[**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType)列挙型で定義された2つの値があります。

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - プロットエリアのサイズは、目盛りと軸ラベルを含まないプロットエリアのサイズを決定することを指定します。
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - プロットエリアのサイズは、プロットエリア、目盛り、および軸ラベルのサイズを決定することを指定します。

サンプルコードは以下の通りです。

```php
  # Presentationクラスのインスタンスを作成
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