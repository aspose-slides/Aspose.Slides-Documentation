---
title: チャートの凡例
type: docs
url: /net/chart-legend/
keywords: "チャート 凡例, 凡例のフォントサイズ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションのチャート凡例の位置とフォントサイズを設定する"
---

## **凡例の位置設定**
凡例のプロパティを設定するためには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、チャートの凡例の位置とサイズを設定しています。

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

// Get reference of the slide
ISlide slide = presentation.Slides[0];

// Add a clustered column chart on the slide
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Set Legend Properties
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Write presentation to disk
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **凡例のフォントサイズを設定**
Aspose.Slides for .NET では、開発者が凡例のフォントサイズを設定することを可能にしています。以下の手順に従ってください：

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


## **個別の凡例のフォントサイズを設定**
Aspose.Slides for .NET では、開発者が個々の凡例エントリのフォントサイズを設定することを可能にしています。以下の手順に従ってください：

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