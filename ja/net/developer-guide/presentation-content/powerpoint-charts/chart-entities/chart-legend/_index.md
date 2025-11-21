---
title: .NET でプレゼンテーションのチャート凡例をカスタマイズする
linktitle: チャート凡例
type: docs
url: /ja/net/chart-legend/
keywords:
- チャート凡例
- 凡例位置
- フォントサイズ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用してチャート凡例をカスタマイズし、調整された凡例フォーマットで PowerPoint プレゼンテーションを最適化します。"
---

## **凡例の位置設定**
凡例のプロパティを設定するには、以下の手順に従ってください。

- 【Presentation】クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
- スライドの参照を取得します。
- スライドにチャートを追加します。
- 凡例のプロパティを設定します。
- プレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、チャート凡例の位置とサイズを設定しています。
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();

// スライドの参照を取得します
ISlide slide = presentation.Slides[0];

// スライドにクラスター化された縦棒グラフを追加します
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

- `Presentation` クラスのインスタンスを作成します。
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



## **個別凡例エントリのフォントサイズ設定**
Aspose.Slides for .NET では、開発者が個々の凡例エントリのフォントサイズを設定できます。以下の手順に従ってください。

- `Presentation` クラスのインスタンスを作成します。
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

**凡例を有効にし、チャートが凡例の上に重ねるのではなく自動的にスペースを確保するようにできますか？**

はい。非オーバーレイモード（[Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`）を使用します。この場合、プロット領域が縮小して凡例を収めます。

**凡例ラベルを複数行にすることはできますか？**

はい。スペースが不足した場合、長いラベルは自動的に折り返されます。改行文字をシリーズ名に含めることで強制的に改行することもサポートされています。

**凡例をプレゼンテーションのテーマカラースキームに従わせるにはどうすればよいですか？**

凡例やそのテキストに対して明示的な色・塗りつぶし・フォントを設定しないでください。テーマから継承され、デザインが変更されたときに正しく更新されます。