---
title: .NET でプレゼンテーションのチャートにトレンドラインを追加
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
- パワートレンドライン
- カスタムトレンドライン
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint のチャートにトレンドラインをすばやく追加・カスタマイズし、聴衆を引きつける実用的なガイド。"
---
## **概要**

この記事では、Aspose.Slides を使用してプレゼンテーションのチャートにトレンドラインを追加する方法を説明します。チャートの作成、チャート系列へのトレンドラインの追加、指数、線形、対数、移動平均、多項式、パワーなど複数のトレンドラインタイプの操作方法を示します。

また、ライン シェイプを挿入してチャートにカスタムラインを追加する方法を説明し、前方および後方へのトレンドライン投影値や、PDF や SVG へのエクスポート時、スライドを画像として描画した際にトレンドラインが保持されるかどうかに関する簡単な FAQ を含みます。

## **トレンドラインの追加**

[ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) を使用してチャート系列にトレンドラインを追加し、[TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/) でタイプを選択します。この例では、既定データのクラスター化縦棒チャートを作成し、3 つの系列それぞれに 2 本のトレンドラインを追加します。

指数トレンドラインは、[DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) と [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/) を使用して方程式と決定係数を非表示にし、線形トレンドラインは赤色に設定されます。対数トレンドラインは[AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/)でカスタム ラベルを設定します。移動平均は 3 データ ポイントの[Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) とカスタム[TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) を使用します。

多項式トレンドラインは[Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) が 3 で、[Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/) によって 1 カテゴリ前方に拡張されます。パワー トレンドラインは[Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/) により 1 カテゴリ後方に拡張されます。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **トレンドラインのインターセプトの設定**

[Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) を使用して、X = 0 のときのトレンドラインの Y 値を固定します。この設定は線形、指数、または多項式トレンドラインでサポートされています。

たとえば、生産コストモデルでは、非ゼロの生産量で測定したベースラインが異なる場合でも、既知の固定コスト 100 から開始する必要があることがあります。線形トレンドラインの場合、インターセプトを固定すると方程式 `y = ax + b` の `b = 100` が固定され、傾きはその制約の下でデータに合わせてフィットします。これは既にフィットされた直線を単に移動させるものではありません。軸の交差設定はチャートの軸が交わる位置を制御し、フィットされたトレンドラインの係数を変更するものではありません。

以下の例は、1 から 4 の生産量とコスト 170、200、230、260 を使用した散布図 (XY) チャートを作成します。デフォルトの自動インターセプトでチャートを保存し、インターセプトを 100 に設定して 2 番目の PPTX を保存します。2 つのファイルはインターセプト設定のみが異なります。トレンドラインは方程式を表示し、X = 0 まで延長されます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

自動計算の場合、これらのデータは `y = 30x + 140` を生成します。インターセプトを 100 に設定すると、約 `y = 43.33x + 100` となります。ゼロでのフィット値が既知のベースラインと一致し、直線はすべてのデータポイントを通過しなくなります。

| 自動インターセプト | インターセプト 100 の固定 |
| --- | --- |
| ![自動計算されたインターセプト 140 の線形トレンドライン](intercept-automatic.png) | ![インターセプト 100 が固定された線形トレンドライン](intercept-fixed.png) |

両方の画像は同じデータと軸スケールを使用しています。トレンドラインはインターセプトを示すために X = 0 まで延長されています。

既定では、プロパティは `double.NaN` を保持し、これはインターセプトが未指定であることを表し、ゼロではありません。インターセプトはデータから自動的に計算されます。

## **カスタムラインの追加**

カスタムラインは、系列データから計算されたトレンドラインではなく、チャート上に描画されるシェイプです。この例では、[IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) を使用して、チャート上に水平線をスライドに追加します。線の位置はポイント単位のスライド座標で指定され、チャートの左端から始まり、チャートの半分の高さに配置されます。幅はチャートの幅と同じです。[LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) によって線は実線の赤色になります。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **FAQ**

**トレンドラインの「forward」と「backward」は何を意味しますか？**

前方/後方に投影されたトレンドラインの長さを表します。散布図 (XY) チャートの場合は軸単位、非散布図の場合はカテゴリ数で表されます。負の値は使用できません。

**プレゼンテーションを PDF や SVG にエクスポートしたり、スライドを画像としてレンダリングしたりするときにトレンドラインは保持されますか？**

はい。Aspose.Slides はプレゼンテーションを[PDF](/slides/ja/net/convert-powerpoint-to-pdf/)または[SVG](/slides/ja/net/render-a-slide-as-an-svg-image/)に変換し、チャートを画像としてレンダリングします。トレンドラインはチャートの一部としてこれらの操作中に保持されます。また、チャート自体の画像を[エクスポート](/slides/ja/net/create-shape-thumbnails/)するメソッドも利用可能です。