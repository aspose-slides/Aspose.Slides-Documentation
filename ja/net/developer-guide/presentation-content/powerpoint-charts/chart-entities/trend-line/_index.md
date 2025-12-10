---
title: .NET でプレゼンテーションチャートにトレンドラインを追加
linktitle: トレンドライン
type: docs
url: /ja/net/trend-line/
keywords:
- チャート
- トレンドライン
- 指数トレンドライン
- 線形トレンドライン
- 対数トレンドライン
- 移動平均トレンドライン
- 多項式トレンドライン
- べきトレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint のチャートにトレンドラインを迅速に追加・カスタマイズし、聴衆を惹きつける実用的なガイドです。"
---

## **トレンドラインの追加**
Aspose.Slides for .NET は、さまざまなチャートのトレンドラインを管理するシンプルな API を提供します。

1. [プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. 任意のタイプのデフォルト データを持つチャートを追加します（この例では ChartType.ClusteredColumn を使用）。
4. 系列 1 に指数トレンドラインを追加します。
5. 系列 1 に線形トレンドラインを追加します。
6. 系列 2 に対数トレンドラインを追加します。
7. 系列 2 に移動平均トレンドラインを追加します。
8. 系列 3 に多項式トレンドラインを追加します。
9. 系列 3 にべきトレンドラインを追加します。
10. 修正されたプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードはトレンドライン付きチャートを作成する例です。
```c#
// 空のプレゼンテーションを作成
Presentation pres = new Presentation();

// クラスター化された縦棒グラフを作成
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// 系列1に指数トレンドラインを追加
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// 系列1に線形トレンドラインを追加
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// 系列2に対数トレンドラインを追加
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// 系列2に移動平均トレンドラインを追加
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// 系列3に多項式トレンドラインを追加
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// 系列3にべきトレンドラインを追加
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// プレゼンテーションを保存
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```


## **カスタムラインの追加**
Aspose.Slides for .NET は、チャートにカスタムラインを追加するシンプルな API を提供します。プレゼンテーションの選択したスライドにシンプルな直線を追加するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- インデックスを使用してスライドの参照を取得する
- Shapes オブジェクトの AddChart メソッドで新しいチャートを作成する
- Shapes オブジェクトの AddAutoShape メソッドで Line タイプの AutoShape を追加する
- 図形の線の色を設定する
- 修正されたプレゼンテーションを PPTX ファイルとして書き込む

以下のコードはカスタムライン付きチャートを作成する例です。
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

**トレンドラインの「forward」および「backward」とは何ですか？**

これはトレンドラインを前方または後方に投影した長さを示します。散布図（XY）チャートの場合は軸単位、散布図以外のチャートの場合はカテゴリ数で表されます。負の値は使用できません。

**トレンドラインは PDF や SVG にエクスポートしたり、スライドを画像としてレンダリングしたりしたときに保持されますか？**

はい。Aspose.Slides はプレゼンテーションを [PDF](/slides/ja/net/convert-powerpoint-to-pdf/) / [SVG](/slides/ja/net/render-a-slide-as-an-svg-image/) に変換し、チャートを画像としてレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、チャート自体の画像を [エクスポート](/slides/ja/net/create-shape-thumbnails/) するメソッドも利用可能です。