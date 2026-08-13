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
description: "Aspose.Slides for Java でドーナツ グラフを作成およびカスタマイズする方法を学び、PowerPoint 形式に対応した動的なプレゼンテーションを実現します。"
---
## **概要**

本記事では、Aspose.Slides でドーナツ グラフをスライドに追加し、中心の穴のサイズを設定し、プレゼンテーションを保存する方法を示します。`setDoughnutHoleSize` メソッドに焦点を当て、コード内でこのグラフ タイプをカスタマイズするために必要な基本的な手順をデモします。

また、複数の系列を使用して複数のリングを作成する、分割ドーナツ グラフの操作、グラフをラスター画像または SVG としてエクスポートするなど、関連するドーナツ グラフ シナリオをカバーする簡易 FAQ も含まれています。

## **ドーナツ グラフの中心ギャップの指定**
{{% alert color="info" %}} 

Aspose.Slides for Java は、ドーナツ グラフの穴のサイズを指定できるようになりました。このトピックでは、例を使ってドーナツ グラフの穴のサイズを指定する方法を説明します。

{{% /alert %}} 

ドーナツ グラフの穴のサイズを指定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) オブジェクトをインスタンス化します。
1. スライドにドーナツ グラフを追加します。
1. ドーナツ グラフの穴のサイズを指定します。
1. プレゼンテーションを書き出してディスクに保存します。

以下の例では、ドーナツ グラフの穴のサイズを設定しています。

```java
import com.aspose.slides.*;

// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // プレゼンテーションを書き込む
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### 複数のリングを持つ多層ドーナツを作成できますか？

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

### "エクスプロード" ドーナツ（スライスが分離されたもの）はサポートされますか？

はい。Exploded Doughnut という[チャート タイプ](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/)があり、データポイントに爆発プロパティが用意されています。個々のスライスを分離できます。

### レポート用にドーナツ グラフの画像（PNG/SVG）を取得するにはどうすればよいですか？

チャートはシェイプです。これを[ラスター画像](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getImage-int-float-float-)にレンダリングするか、[SVG 画像](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)としてエクスポートできます。