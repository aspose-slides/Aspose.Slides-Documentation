---
title: Java を使用したプレゼンテーションのドーナツ グラフのカスタマイズ
linktitle: ドーナツ グラフ
type: docs
weight: 30
url: /ja/java/doughnut-chart/
keywords:
- ドーナツ グラフ
- 中心ギャップ
- 穴のサイズ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でドーナツ グラフを作成およびカスタマイズする方法を学び、PowerPoint 形式の動的プレゼンテーションに対応します。"
---

## **ドーナツ グラフの中心ギャップを指定する**
{{% alert color="primary" %}} 

Aspose.Slides for Javaは、ドーナツ グラフの穴のサイズの指定をサポートするようになりました。このトピックでは、例を使ってドーナツ グラフの穴のサイズを指定する方法を確認します。

{{% /alert %}} 

ドーナツ グラフの穴のサイズを指定するには、以下の手順に従ってください。

1. Presentation オブジェクトをインスタンス化します。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 
1. スライドにドーナツ グラフを追加します。
1. ドーナツ グラフの穴のサイズを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、ドーナツ グラフの穴のサイズを設定しています。
```java
// Presentation クラスのインスタンスを作成する
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // プレゼンテーションをディスクに保存する
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**複数リングのマルチレベルドーナツを作成できますか？**

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

**「エクスプローデッド」ドーナツ（分離されたスライス）はサポートされていますか？**

はい。Exploded Doughnut [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) があり、データポイントにエクスプロージョン プロパティがあります。個々のスライスを分離できます。

**レポート用にドーナツ グラフの画像（PNG/SVG）を取得するにはどうすればよいですか？**

チャートはシェイプです。チャートを[raster image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) にレンダリングするか、[SVG image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) にエクスポートできます。