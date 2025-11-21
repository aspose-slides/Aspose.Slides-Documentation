---
title: .NET のプレゼンテーションで円グラフをカスタマイズ
linktitle: 円グラフ
type: docs
url: /ja/net/pie-chart/
keywords:
- 円グラフ
- グラフの管理
- グラフのカスタマイズ
- グラフ オプション
- グラフ設定
- プロット オプション
- スライスカラー
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で円グラフを作成・カスタマイズする方法を学び、PowerPoint へエクスポートし、数秒でデータストーリーテリングを強化します。"
---

## **パイ オブ パイおよびバー オブ パイ チャートの第二プロットオプション**

Aspose.Slides for .NET は、パイ オブ パイまたはバー オブ パイ チャートの第二プロットオプションをサポートするようになりました。このトピックでは、Aspose.Slides を使用してこれらのオプションを指定する方法をサンプルで示します。プロパティを指定するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスオブジェクトのインスタンスを作成します。
1. スライドにチャートを追加します。
1. チャートの第二プロットオプションを指定します。
1. プレゼンテーションをディスクに書き込みます。

以下の例では、パイ オブ パイ チャートのさまざまなプロパティを設定しています。
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();

// スライドにチャートを追加します
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// さまざまなプロパティを設定します
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// プレゼンテーションをディスクに保存します
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```


## **自動パイチャート スライスカラーの設定**

Aspose.Slides for .NET は、自動パイチャートのスライスカラーを設定するためのシンプルな API を提供します。サンプルコードは、上記のプロパティ設定を適用しています。

1. Presentation クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. チャートのタイトルを設定します。
1. 最初の系列の「値の表示」を設定します。
1. チャートデータシートのインデックスを設定します。
1. チャートデータのワークシートを取得します。
1. デフォルトで生成された系列とカテゴリを削除します。
1. 新しいカテゴリを追加します。
1. 新しい系列を追加します。

変更したプレゼンテーションを PPTX ファイルに書き込みます。
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
	// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
	Presentation presentation = new Presentation();

	// 最初のスライドにアクセスします
	ISlide slides = presentation.Slides[0];

	// デフォルト データでチャートを追加します
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// チャートのタイトルを設定します
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// 最初の系列で値を表示するように設定します
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// チャート データ シートのインデックスを設定します
	int defaultWorksheetIndex = 0;

	// チャート データのワークシートを取得します
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// デフォルトで生成された系列とカテゴリを削除します
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// 新しいカテゴリを追加します
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// 新しい系列を追加します
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// 系列データを入力します
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**「パイ オブ パイ」および「バー オブ パイ」バリエーションはサポートされていますか？**

はい、ライブラリは[サポート](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)しています。パイチャートの二次プロットとして「パイ オブ パイ」および「バー オブ パイ」タイプを含みます。

**チャートだけを画像（例：PNG）としてエクスポートできますか？**

はい、プレゼンテーション全体を含めずに、[チャート自体を画像としてエクスポート](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)できます（PNG など）。