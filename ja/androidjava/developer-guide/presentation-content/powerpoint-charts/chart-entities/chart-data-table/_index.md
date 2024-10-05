---
title: チャートデータテーブル
type: docs
url: /androidjava/chart-data-table/
---

## **チャートデータテーブルのフォントプロパティを設定する**
Aspose.Slides for Android via Javaは、シリーズの色でカテゴリの色を変更するサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートテーブルを設定します。
1. フォントの高さを設定します。
1. 修正されたプレゼンテーションを保存します。

以下にサンプル例を示します。

```java
// 空のプレゼンテーションを作成
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```