---
title: 3D チャート
type: docs
url: /ja/net/3d-chart/
keywords: "3D チャート、rotationX、rotationY、depthpercent、PowerPoint プレゼンテーション、C#、Csharp、Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションの 3D チャートの rotationX、rotationY、および depthpercents を設定する"
---

## **3D チャートの RotationX、RotationY および DepthPercents プロパティを設定する**
Aspose.Slides for .NET はこれらのプロパティを設定するためのシンプルな API を提供します。以下の記事では、X、Y の回転や **DepthPercents** などのさまざまなプロパティの設定方法を紹介します。サンプルコードは、前述のプロパティの設定を適用します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータでチャートを追加します。
4. Rotation3D プロパティを設定します。
5. 変更したプレゼンテーションを書き出して PPTX ファイルに保存します。
```c#
// Presentation クラスのインスタンスを作成
Presentation presentation = new Presentation();
           
// 最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// デフォルト データでチャートを追加
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// チャート データ シートのインデックスを設定
int defaultWorksheetIndex = 0;

// チャート データ ワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// シリーズを追加
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

// 2 番目のチャートシリーズを取得
IChartSeries series = chart.ChartData.Series[1];

// シリーズ データを設定中
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// OverLap 値を設定
series.ParentSeriesGroup.Overlap = 100;         

// プレゼンテーションをディスクに保存
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **よくある質問**

**Aspose.Slides ではどのチャートタイプが 3D モードをサポートしていますか？**

Aspose.Slides は、Column 3D、Clustered Column 3D、Stacked Column 3D、100% Stacked Column 3D などの 3D カラムチャートのバリエーションと、[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体で公開されている関連 3D タイプをサポートしています。正確で最新の一覧については、インストールされているバージョンの API リファレンスにある [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) メンバーをご確認ください。

**レポートやウェブ用に 3D チャートのラスタ画像を取得できますか？**

はい。チャートを画像としてエクスポートするには [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) を使用するか、[render the entire slide](/slides/ja/net/convert-powerpoint-to-png/) を使用して PNG や JPEG 形式に変換できます。ピクセル単位で正確なプレビューが必要な場合や、PowerPoint を使用せずにドキュメント、ダッシュボード、ウェブページにチャートを埋め込みたい場合に便利です。

**大規模な 3D チャートの作成およびレンダリングのパフォーマンスはどうですか？**

パフォーマンスはデータ量と視覚的な複雑さに依存します。最良の結果を得るには、3D 効果は最小限に抑え、壁やプロット領域に重いテクスチャを使用しないようにし、可能であればシリーズあたりのデータポイント数を制限し、対象の表示または印刷要件に合わせて適切なサイズ（解像度と寸法）の出力にレンダリングしてください。