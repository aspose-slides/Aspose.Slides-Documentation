---
title: .NET のプレゼンテーションでドーナツチャートをカスタマイズする
linktitle: ドーナツチャート
type: docs
weight: 30
url: /ja/net/doughnut-chart/
keywords:
- ドーナツチャート
- センターギャップ
- 穴のサイズ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してドーナツチャートを作成およびカスタマイズする方法を紹介します。PowerPoint 形式に対応し、動的なプレゼンテーションを実現します。"
---

## **ドーナツチャートのセンターギャップを指定する**
ドーナツチャートの穴のサイズを指定するには、以下の手順に従ってください。

- Presentationクラスをインスタンス化します。
- スライドにドーナツチャートを追加します。
- ドーナツチャートの穴のサイズを指定します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、ドーナツチャートの穴のサイズを設定しています。
```c#
// Presentation クラスのインスタンスを作成する
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// プレゼンテーションをディスクに保存する
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**複数のリングを持つマルチレベルのドーナツを作成できますか？**

はい。単一のドーナツチャートに複数のシリーズを追加すると、各シリーズが別々のリングになります。リングの順序はコレクション内のシリーズの順序で決まります。

**「エクスプロード」ドーナツ（スライスが分離されたもの）はサポートされていますか？**

はい。Exploded Doughnut[chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)というチャートタイプがあり、データポイントに爆発プロパティがあります。個々のスライスを分離できます。

**レポート用にドーナツチャートの画像（PNG/SVG）を取得するにはどうすればよいですか？**

チャートはシェイプです。[raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)にレンダリングするか、チャートを[SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)にエクスポートできます。