---
title: ドーナツ グラフ
type: docs
weight: 30
url: /ja/net/doughnut-chart/
keywords: "ドーナツ グラフ, 中央ギャップ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint プレゼンテーションで C# または .NET のドーナツ グラフの中心ギャップを指定"
---

## **ドーナツ グラフの中心ギャップを指定**
ドーナツ グラフの穴のサイズを指定するには、以下の手順に従ってください:

- Instantiate [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- スライドにドーナツ グラフを追加します。
- ドーナツ グラフの穴のサイズを指定します。
- プレゼンテーションをディスクに保存します。

以下の例では、ドーナツ グラフの穴のサイズを設定しています。
```c#
 // Presentation クラスのインスタンスを作成
 Presentation presentation = new Presentation();

 IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
 chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

 // プレゼンテーションをディスクに保存
 presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**複数のリングを持つマルチレベルのドーナツを作成できますか？**

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

**「エクスプロード」ドーナツ（スライスが分離されたもの）はサポートされていますか？**

はい。Exploded Doughnut の[チャートタイプ](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) とデータポイントのエクスプロージョン プロパティがあり、個々のスライスを分離できます。

**レポート用にドーナツ グラフの画像（PNG/SVG）を取得するにはどうすればよいですか？**

チャートはシェイプです。[ラスタ画像](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) にレンダリングしたり、チャートを[SVG画像](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) にエクスポートしたりできます。