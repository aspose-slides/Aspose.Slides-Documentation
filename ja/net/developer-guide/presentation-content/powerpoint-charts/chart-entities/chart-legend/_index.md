---
title: .NET のプレゼンテーションでチャート凡例をカスタマイズ
linktitle: チャート凡例
type: docs
url: /ja/net/chart-legend/
keywords:
- チャート凡例
- 凡例の位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してチャート凡例をカスタマイズし、目的に合わせた凡例の書式設定で PowerPoint プレゼンテーションを最適化します。"
---

## **凡例の位置設定**
凡例のプロパティを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、チャート凡例の位置とサイズを設定しています。
```c#
// Presentation クラスのインスタンスを作成
Presentation presentation = new Presentation();

// スライドの参照を取得
ISlide slide = presentation.Slides[0];

// スライドにクラスター化された列チャートを追加
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// 凡例のプロパティを設定
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// プレゼンテーションをディスクに保存
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```




## **凡例のフォントサイズの設定**
Aspose.Slides for .NET では、開発者が凡例のフォントサイズを設定できます。以下の手順に従ってください。

- `Presentation` クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに保存します。
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```



## **個別の凡例エントリのフォントサイズの設定**
Aspose.Slides for .NET では、開発者が個別の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- `Presentation` クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに保存します。
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **よくある質問**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

はい。非オーバーレイ モード（[Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/)=`false`）を使用します。この場合、プロット領域が縮小して凡例を収めます。

**Can I make multi-line legend labels?**

はい。スペースが不足すると長いラベルは自動的に折り返されます。改行文字をシリーズ名に入れることで強制改行もサポートされます。

**How do I make the legend follow the presentation theme’s color scheme?**

凡例やそのテキストに明示的な色・塗りつぶし・フォントを設定しないでください。テーマから継承され、デザインが変更されたときに正しく更新されます。