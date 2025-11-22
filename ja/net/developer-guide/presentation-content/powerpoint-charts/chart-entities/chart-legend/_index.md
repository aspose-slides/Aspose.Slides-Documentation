---
title: チャート凡例
type: docs
url: /ja/net/chart-legend/
keywords: "チャート凡例, 凡例フォントサイズ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint プレゼンテーションにおけるチャート凡例の位置設定とフォントサイズを C# または .NET で設定します"
---

## **凡例の位置設定**
凡例のプロパティを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- スライドへの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、チャート凡例の位置とサイズを設定しています。
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();

// スライドの参照を取得します
ISlide slide = presentation.Slides[0];

// スライドにクラスター化列チャートを追加します
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// 凡例のプロパティを設定します
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// プレゼンテーションをディスクに保存します
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```




## **凡例のフォントサイズの設定**
Aspose.Slides for .NET では、開発者が凡例のフォントサイズを設定できます。以下の手順に従ってください。

- `Presentation` クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。
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



## **個別凡例エントリのフォントサイズの設定**
Aspose.Slides for .NET では、開発者が個別の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- `Presentation` クラスをインスタンス化します。
- デフォルトのチャートを作成します。
- 凡例エントリにアクセスします。
- フォントサイズを設定します。
- 最小軸値を設定します。
- 最大軸値を設定します。
- プレゼンテーションをディスクに書き出します。
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


## **FAQ**

**凡例を有効にして、チャートが凡例の上に重ねるのではなく自動的にスペースを確保するようにできますか？**

はい。オーバーレイモードを無効にします（[Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`）。この場合、プロット領域は凡例を収めるために縮小されます。

**複数行の凡例ラベルを作成できますか？**

はい。ラベルが長い場合はスペースが不足すると自動的に折り返されます。また、シリーズ名に改行文字を入れることで強制改行も可能です。

**凡例をプレゼンテーションのテーマカラーに合わせるにはどうすればよいですか？**

凡例やそのテキストに対して明示的に色・塗りつぶし・フォントを設定しないでください。テーマから継承され、デザインが変わっても自動的に更新されます。