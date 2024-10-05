---
title: チャートデータテーブル
type: docs
url: /php-java/chart-data-table/
---

## **チャートデータテーブルのフォントプロパティを設定する**
Aspose.Slides for PHP via Javaは、系列色内のカテゴリの色を変更するサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントサイズを設定します。
1. 修正されたプレゼンテーションを保存します。

以下にサンプル例を示します。

```php
  # 空のプレゼンテーションを作成
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```