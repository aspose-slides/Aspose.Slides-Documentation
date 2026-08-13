---
title: Android のプレゼンテーションでドーナツチャートをカスタマイズする
linktitle: ドーナツチャート
type: docs
weight: 30
url: /ja/androidjava/doughnut-chart/
keywords:
- ドーナツチャート
- 中心ギャップ
- 穴のサイズ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でドーナツチャートを作成およびカスタマイズする方法を紹介します。PowerPoint 形式に対応した動的なプレゼンテーションを実現します。"
---
## **概要**

この記事では、Aspose.Slides でドーナツ グラフを操作する方法を、スライドにチャートを追加し、中心の穴のサイズを設定し、プレゼンテーションを保存する手順を示します。`setDoughnutHoleSize` メソッドに焦点を当て、コードでこのチャートタイプをカスタマイズするために必要な基本的な手順を実演します。

また、複数の系列を使用して複数のリングを作成する、エクスプロード ドーナツ チャートの操作、チャートをラスタ画像または SVG としてエクスポートするなど、関連するドーナツチャート シナリオをカバーする簡潔な FAQ も含まれています。

## **ドーナツチャートの中心ギャップを指定する**
{{% alert color="info" %}} 
Aspose.Slides for Android via Java は、ドーナツチャートの穴のサイズを指定する機能をサポートしました。このトピックでは、例を使ってドーナツチャートの穴のサイズを指定する方法を確認します。
{{% /alert %}} 

ドーナツチャートの穴のサイズを指定するには、以下の手順に従ってください。

1. Presentation オブジェクトをインスタンス化します。[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation)。
2. スライドにドーナツチャートを追加します。
3. ドーナツチャートの穴のサイズを指定します。
4. プレゼンテーションをディスクに書き込みます。

以下の例では、ドーナツチャートの穴のサイズを設定しています。

```java
import com.aspose.slides.*;

// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // プレゼンテーションをディスクに保存
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### 複数のリングを持つマルチレベルドーナツを作成できますか？

はい。単一のドーナツチャートに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

### 「エクスプロード」ドーナツ（分離されたスライス）はサポートされていますか？

はい。Exploded Doughnut [チャート タイプ](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/) があり、データポイントに対してエクスプロージョン プロパティが使用可能です。個々のスライスを分離できます。

### レポート用にドーナツチャートの画像（PNG/SVG）を取得するにはどうすればよいですか？

チャートはシェイプです。チャートを [ラスタ画像](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) にレンダリングするか、[SVG 画像](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) にエクスポートできます。