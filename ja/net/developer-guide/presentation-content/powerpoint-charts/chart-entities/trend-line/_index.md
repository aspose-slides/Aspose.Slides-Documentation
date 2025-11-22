---
title: トレンドライン
type: docs
url: /ja/net/trend-line/
keywords: "トレンドライン, カスタムライン PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにトレンドラインとカスタムラインを追加します"
---

## **トレンドラインの追加**
Aspose.Slides for .NET は、さまざまなチャートのトレンドラインを管理するためのシンプルな API を提供します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと任意の種類のチャートを追加します（この例では ChartType.ClusteredColumn を使用）。
4. チャート系列 1 に指数トレンドラインを追加します。
5. チャート系列 1 に線形トレンドラインを追加します。
6. チャート系列 2 に対数トレンドラインを追加します。
7. チャート系列 2 に移動平均トレンドラインを追加します。
8. チャート系列 3 に多項式トレンドラインを追加します。
9. チャート系列 3 にべきトレンドラインを追加します。
10. 変更したプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードは、トレンドライン付きのチャートを作成するために使用されます。
```c#
// 空のプレゼンテーションを作成
Presentation pres = new Presentation();

// クラスター化カラムチャートを作成
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
tredLineLog.AddTextFrameForOverriding("New log trend line");

// チャート系列 2 に移動平均トレンドラインを追加
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// チャート系列 3 に多項式トレンドラインを追加
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// チャート系列 3 にべきトレンドラインを追加
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// プレゼンテーションを保存
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```


## **カスタムラインの追加**
Aspose.Slides for .NET は、チャートにカスタムラインを追加するためのシンプルな API を提供します。プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください：

- Presentation クラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapes オブジェクトが提供する AddChart メソッドを使用して新しいチャートを作成します
- Shapes オブジェクトが提供する AddAutoShape メソッドを使用して、Line タイプの AutoShape を追加します
- 形状の線の色を設定します
- 変更したプレゼンテーションを PPTX ファイルとして書き込みます

以下のコードは、カスタムライン付きのチャートを作成するために使用されます。
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


## **FAQ**

**トレンドラインの「forward」と「backward」は何を意味しますか？**

トレンドラインを前方または後方に延長した長さです。散布 (XY) チャートの場合は軸単位、散布でないチャートの場合はカテゴリ数で表されます。負の値は使用できません。

**プレゼンテーションを PDF や SVG にエクスポートしたり、スライドを画像としてレンダリングしたりしたときに、トレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/net/convert-powerpoint-to-pdf/)/[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、チャート自体の画像を [エクスポート](/slides/ja/net/create-shape-thumbnails/) するメソッドも利用可能です。