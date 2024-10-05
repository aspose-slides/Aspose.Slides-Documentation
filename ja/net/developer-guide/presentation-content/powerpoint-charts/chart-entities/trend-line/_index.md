---
title: トレンドライン
type: docs
url: /net/trend-line/
keywords: "トレンドライン, カスタムライン PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにトレンドラインとカスタムラインを追加する"
---

## **トレンドラインを追加する**
Aspose.Slides for .NET は、さまざまなチャートのトレンドラインを管理するためのシンプルな API を提供します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. 任意の種類（この例では ChartType.ClusteredColumn を使用）でデフォルトデータを含むチャートを追加します。
1. チャート系列 1 に指数トレンドラインを追加します。
1. チャート系列 1 に線形トレンドラインを追加します。
1. チャート系列 2 に対数トレンドラインを追加します。
1. チャート系列 2 に移動平均トレンドラインを追加します。
1. チャート系列 3 に多項式トレンドラインを追加します。
1. チャート系列 3 にべき乗トレンドラインを追加します。
1. 修正されたプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードは、トレンドラインを含むチャートを作成するために使用されます。

```c#
// 空のプレゼンテーションを作成
Presentation pres = new Presentation();

// クラスター型の列チャートを作成
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// チャート系列 1 に指数トレンドラインを追加
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// チャート系列 1 に線形トレンドラインを追加
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

// チャート系列 2 に対数トレンドラインを追加
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("新しい対数トレンドライン");

// チャート系列 2 に移動平均トレンドラインを追加
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "新しいトレンドライン名";

// チャート系列 3 に多項式トレンドラインを追加
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// チャート系列 3 にべき乗トレンドラインを追加
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// プレゼンテーションを保存
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```

## **カスタムラインを追加する**
Aspose.Slides for .NET は、チャートにカスタムラインを追加するためのシンプルな API を提供します。選択したスライドにシンプルなプレーンラインを追加するには、以下の手順に従ってください：

- Presentation クラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapes オブジェクトが公開する AddChart メソッドを使用して新しいチャートを作成します
- Shapes オブジェクトが公開する AddAutoShape メソッドを使用して、ラインタイプの AutoShape を追加します
- 形状のラインの色を設定します。
- 修正されたプレゼンテーションを PPTX ファイルとして書き込みます

以下のコードは、カスタムラインを含むチャートを作成するために使用されます。

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```