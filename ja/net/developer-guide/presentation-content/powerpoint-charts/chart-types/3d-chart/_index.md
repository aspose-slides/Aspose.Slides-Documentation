---
title: .NET でプレゼンテーションの 3D チャートをカスタマイズする
linktitle: 3D チャート
type: docs
url: /ja/net/3d-chart/
keywords:
- 3D チャート
- 回転
- 深さ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で 3-D チャートを作成およびカスタマイズする方法を学び、PPT と PPTX ファイルに対応し、プレゼンテーションを今すぐ強化しましょう。"
---

## **3D チャートの RotationX、RotationY、DepthPercents プロパティの設定**
Aspose.Slides for .NET は、これらのプロパティを設定するためのシンプルな API を提供します。以下の記事では、X、Y の回転や **DepthPercents** などのさまざまなプロパティの設定方法を説明します。サンプルコードは、前述のプロパティの設定を適用しています。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. Rotation3D プロパティを設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。
```c#
// Presentation クラスのインスタンスを作成
Presentation presentation = new Presentation();
           
// 最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// デフォルトデータでチャートを追加
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// チャート データ シートのインデックスを設定
int defaultWorksheetIndex = 0;

// チャート データ ワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// カテゴリを追加
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Rotation3D プロパティを設定
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// 2 番目のチャート系列を取得
IChartSeries series = chart.ChartData.Series[1];

// 系列データを設定中
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Overlap 値を設定
series.ParentSeriesGroup.Overlap = 100;         

// プレゼンテーションをディスクに保存
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Aspose.Slides で 3D モードをサポートするチャートタイプはどれですか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの 3D バリアントの縦棒グラフをサポートし、[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙型を通じて関連する 3D タイプも公開しています。正確で最新の一覧については、インストール済みバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) メンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスター画像を取得できますか？**

はい。チャートを画像としてエクスポートするには、[chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) を使用するか、[スライド全体をレンダリング](/slides/ja/net/convert-powerpoint-to-png/) して PNG や JPEG 形式で保存できます。ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずにチャートを文書、ダッシュボード、ウェブページに埋め込みたい場合に便利です。

**大規模な 3D チャートの作成およびレンダリングはどの程度のパフォーマンスですか？**

パフォーマンスはデータ量とビジュアルの複雑さに依存します。最適な結果を得るためには、3D 効果は最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能であれば系列ごとのデータポイント数を制限し、ターゲットの表示や印刷要件に合わせた適切な解像度とサイズで出力をレンダリングしてください。