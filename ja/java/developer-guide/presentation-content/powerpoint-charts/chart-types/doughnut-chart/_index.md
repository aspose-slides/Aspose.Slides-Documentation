---
title: Java を使用したプレゼンテーションでのドーナツチャートのカスタマイズ
linktitle: ドーナツチャート
type: docs
weight: 30
url: /ja/java/doughnut-chart/
keywords:
- ドーナツチャート
- 中心ギャップ
- 穴のサイズ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、動的なプレゼンテーション向けに PowerPoint 形式をサポートするドーナツチャートの作成とカスタマイズ方法をご紹介します。"
---

## **Change Center Gap in Doughnut Chart**
{{% alert color="primary" %}} 

Aspose.Slides for Java は、ドーナツ グラフの穴のサイズを指定できるようになりました。本記事では、例を使ってドーナツ グラフの穴のサイズを指定する方法を説明します。

{{% /alert %}} 

ドーナツ グラフの穴のサイズを指定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) オブジェクトをインスタンス化します。
1. スライドにドーナツ グラフを追加します。
1. ドーナツ グラフの穴のサイズを指定します。
1. プレゼンテーションをディスクに保存します。

以下の例では、ドーナツ グラフの穴のサイズを設定しています。
```java
// Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // プレゼンテーションをディスクに保存します
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Can I create a multi-level doughnut with multiple rings?**

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

**Is an "exploded" doughnut (separated slices) supported?**

はい。エクスプロード ドーナツ[chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)があり、データ ポイントに爆発プロパティがあります。個々のスライスを分離できます。

**How can I get an image of a doughnut chart (PNG/SVG) for a report?**

グラフはシェイプです。ラスタ画像にレンダリングしたり、[SVG画像](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)にエクスポートしたりできます。