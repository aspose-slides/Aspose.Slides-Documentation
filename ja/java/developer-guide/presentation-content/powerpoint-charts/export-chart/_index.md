---
title: チャートのエクスポート
type: docs
weight: 90
url: /ja/java/export-chart/
---

## **チャート画像の取得**
Aspose.Slides for Javaは、特定のチャートの画像を抽出するサポートを提供します。以下にサンプル例を示します。

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```