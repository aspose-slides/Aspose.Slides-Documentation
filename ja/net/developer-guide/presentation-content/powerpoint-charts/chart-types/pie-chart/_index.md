---
title: パイチャート
type: docs
url: /net/pie-chart/
keywords: "パイチャート, プロットオプション, スライスの色, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointプレゼンテーションのパイチャートプロットオプションとスライスの色"
---

## **パイオブパイおよびバーオブパイチャートのための第2プロットオプション**
Aspose.Slides for .NETは、パイオブパイまたはバーオブパイチャートのための第2プロットオプションをサポートしています。このトピックでは、Aspose.Slidesを使用してこれらのオプションを指定する方法を例を挙げて説明します。プロパティを指定するためには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの第2プロットオプションを指定します。
1. プレゼンテーションをディスクに保存します。

以下の例では、パイオブパイチャートの異なるプロパティを設定しています。

```c#
// プレゼンテーションクラスのインスタンスを作成
Presentation presentation = new Presentation();

// スライドにチャートを追加
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// 異なるプロパティを設定
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// プレゼンテーションをディスクに保存
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **自動的なパイチャートスライスの色を設定**
Aspose.Slides for .NETは、自動的なパイチャートスライスの色を設定するためのシンプルなAPIを提供しています。サンプルコードは、上記のプロパティを設定します。

1. プレゼンテーションクラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. チャートタイトルを設定します。
1. 最初のシリーズを値を表示するように設定します。
1. チャートデータシートのインデックスを設定します。
1. チャートデータワークシートを取得します。
1. デフォルトで生成された系列とカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しいシリーズを追加します。

修正されたプレゼンテーションをPPTXファイルに書き込みます。

```c#
// PPTXファイルを表すプレゼンテーションクラスをインスタンス化
using (Presentation presentation = new Presentation())
{
	// PPTXファイルを表すプレゼンテーションクラスをインスタンス化
	Presentation presentation = new Presentation();

	// 最初のスライドにアクセス
	ISlide slides = presentation.Slides[0];

	// デフォルトデータでチャートを追加
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// チャートタイトルを設定
	chart.ChartTitle.AddTextFrameForOverriding("サンプルタイトル");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// 最初のシリーズを値を表示するように設定
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// チャートデータシートのインデックスを設定
	int defaultWorksheetIndex = 0;

	// チャートデータワークシートを取得
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// デフォルトで生成された系列とカテゴリを削除
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// 新しいカテゴリを追加
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "第1四半期"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "第2四半期"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "第3四半期"));

	// 新しいシリーズを追加
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "シリーズ1"), chart.Type);

	// 現在、シリーズデータを入力
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```