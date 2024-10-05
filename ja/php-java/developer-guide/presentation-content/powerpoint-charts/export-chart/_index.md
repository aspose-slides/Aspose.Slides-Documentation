---
title: チャートのエクスポート
type: docs
weight: 90
url: /php-java/export-chart/
---

## **チャート画像の取得**
Aspose.Slides for PHP via Javaは、特定のチャートの画像を抽出するサポートを提供します。以下にサンプル例を示します。

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```