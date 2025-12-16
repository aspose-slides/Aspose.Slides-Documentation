---
title: Android のプレゼンテーションでドーナツ グラフをカスタマイズする
linktitle: ドーナツ グラフ
type: docs
weight: 30
url: /ja/androidjava/doughnut-chart/
keywords:
- ドーナツ グラフ
- 中心ギャップ
- 穴のサイズ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でドーナツ グラフを作成およびカスタマイズする方法を解説します。PowerPoint 形式に対応した動的なプレゼンテーションを実現できます。"
---

## **ドーナツ グラフの中心ギャップを指定する**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java は、ドーナツ グラフの穴のサイズの指定をサポートしました。本項では、例を使ってドーナツ グラフの穴のサイズを指定する方法を確認します。

{{% /alert %}} 

ドーナツ グラフの穴のサイズを指定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) オブジェクトをインスタンス化します。
2. スライドにドーナツ グラフを追加します。
3. ドーナツ グラフの穴のサイズを指定します。
4. プレゼンテーションをディスクに書き出します。

以下の例では、ドーナツ グラフの穴のサイズを設定しています。
```java
// Presentation クラスのインスタンスを作成する
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

**複数のリングを持つ多層ドーナツを作成できますか？**

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

**「エクスプロード」ドーナツ（スライスが分離されたもの）はサポートされていますか？**

はい。Exploded Doughnut [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) と、データポイントのエクスプロージョン プロパティがあり、個々のスライスを分離できます。

**レポート用にドーナツ グラフの画像（PNG/SVG）を取得するにはどうすればよいですか？**

チャートはシェイプです。シェイプを [raster image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) にレンダリングするか、チャートを [SVG image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) にエクスポートできます。