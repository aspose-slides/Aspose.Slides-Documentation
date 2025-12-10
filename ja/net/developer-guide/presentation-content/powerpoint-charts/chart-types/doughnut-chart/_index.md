---
title: .NET でプレゼンテーションのドーナツ グラフをカスタマイズする
linktitle: ドーナツ チャート
type: docs
weight: 30
url: /ja/net/doughnut-chart/
keywords:
- ドーナツ グラフ
- 中心ギャップ
- 穴のサイズ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してドーナツ グラフを作成およびカスタマイズし、PowerPoint 形式の動的プレゼンテーションをサポートする方法を紹介します。"
---

## **ドーナツ グラフの中心ギャップを指定する**
ドーナツ グラフの穴のサイズを指定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスをインスタンス化します。
- スライドにドーナツ グラフを追加します。
- ドーナツ グラフの穴のサイズを指定します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、ドーナツ グラフの穴のサイズを設定しています。
```c#
 // Presentation クラスのインスタンスを作成する
 Presentation presentation = new Presentation();

 IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
 chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

 // プレゼンテーションをディスクに保存する
 presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**マルチレベルのドーナツを複数のリングで作成できますか？**

はい。単一のドーナツ グラフに複数の系列を追加すると、各系列が別々のリングになります。リングの順序は、コレクション内の系列の順序で決まります。

**「エクスプロード」ドーナツ（分割されたスライス）はサポートされていますか？**

はい。エクスプロード ドーナツの[チャート タイプ](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)があり、データ ポイントに対してエクスプロージョン プロパティがあります。個々のスライスを分離できます。

**レポート用にドーナツ グラフの画像（PNG/SVG）を取得するにはどうすればよいですか？**

チャートはシェイプです。[ラスタ 画像](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)にレンダリングしたり、[SVG 画像](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)としてエクスポートしたりできます。