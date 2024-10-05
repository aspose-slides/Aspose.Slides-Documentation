---
title: 3Dチャート
type: docs
url: /net/3d-chart/
keywords: "3dチャート, rotationX, rotationY, depthpercent, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETのPowerPointプレゼンテーションで3DチャートのrotationX、rotationY、およびdepthpercentsを設定します"
---

## **3DチャートのRotationX、RotationY、およびDepthPercentsプロパティを設定する**
Aspose.Slides for .NETは、これらのプロパティを設定するためのシンプルなAPIを提供しています。次の記事では、X、Y回転、**DepthPercents**などの異なるプロパティの設定方法を説明します。サンプルコードは、上記のプロパティを設定する方法を示しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. Rotation3Dプロパティを設定します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

```c#
// Presentationクラスのインスタンスを作成
Presentation presentation = new Presentation();
           
// 最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// デフォルトデータでチャートを追加
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// チャートデータシートのインデックスを設定
int defaultWorksheetIndex = 0;

// チャートデータワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// シリーズを追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "シリーズ 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "シリーズ 2"), chart.Type);

// カテゴリを追加
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "カテゴリ 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "カテゴリ 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "カテゴリ 3"));

// Rotation3Dプロパティを設定
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// 2番目のチャートシリーズを取得
IChartSeries series = chart.ChartData.Series[1];

// 現在、シリーズデータをポピュレート
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// OverLapの値を設定
series.ParentSeriesGroup.Overlap = 100;         

// プレゼンテーションをディスクに書き込む
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```