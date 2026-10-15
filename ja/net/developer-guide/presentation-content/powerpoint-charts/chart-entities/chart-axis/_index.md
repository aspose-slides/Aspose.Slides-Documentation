---
title: .NET のプレゼンテーションでチャート軸をカスタマイズする
linktitle: チャート軸
type: docs
url: /ja/net/chart-axis/
keywords:
- チャート軸
- 垂直軸
- 水平軸
- 軸のカスタマイズ
- 軸の操作
- 軸の管理
- 軸のプロパティ
- 最大値
- 最小値
- 軸線
- 日付書式
- 軸タイトル
- 軸位置
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "レポートや可視化のために、PowerPoint プレゼンテーションのチャート軸をカスタマイズする方法を Aspose.Slides for .NET を使用して学びましょう。"
---
## **概要**

この記事では、Aspose.Slides for .NET を使用してチャート軸をカスタマイズする方法を説明します。計算された軸の値、チャートの行列の入れ替え、軸の表示/非表示、カテゴリ ラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置、表示単位、および対数スケーリングについて解説します。

## **チャートの垂直軸の最大値を取得する**

[プレゼンテーション](https://reference.aspose.com/slides/net/aspose.slides/presentation/) を作成し、デフォルト データのエリア チャートを追加します。計算された軸値を取得する前に、チャート レイアウトが最新になるように [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) を呼び出します。

軸の範囲については [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) と [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) を読み取り、目盛り間隔については [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) と [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) を読み取ります。[ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) と [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) は時間単位のスケールを提供し、日付軸に関連します。例ではこれらの値をローカル変数に格納し、チャートを保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **軸間のデータを入れ替える**

[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) を使用して、チャート データ内の系列とカテゴリの役割を入れ替えます。元のカテゴリは系列になり、元の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、水平軸と垂直軸を入れ替えるわけではありません。例では [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) を使用してデフォルト データを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行列を入れ替える前に設定します。4 系列と 3 カテゴリのチャートを保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **軸の描画順序を逆にする**

[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) を使用して、カテゴリ軸または値軸の順序を逆にします。たとえば、水平棒グラフでプロジェクトの段階を「計画 → 開発 → テスト」の順に上から下へ表示できます。軸を逆にすると描画方向が変わりますが、ワークブック データの並び替えや再配置は行われません。比較として、[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) は系列とカテゴリの役割を入れ替えます。

次の例は、3 段階と 1 系列の水平棒グラフを作成します。3 つのスライドを保存します：通常順、カテゴリ逆順、値逆順。それぞれのコピーは同じデータセットを使用し、各コピーで 1 つの軸だけを逆にしています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Slide 2: display the first category at the top.
// スライド 2: 最初のカテゴリを上部に表示します。
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Keep the horizontal value axis at the bottom.
// 水平値軸を下部に保持します。
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: reverse only the horizontal numeric scale.
// スライド 3: 水平数値スケールのみを逆にします。
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

軸を逆にすると、直交する軸をプロットの反対側に移動させることもできます。[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) は、設定対象の軸に対する他方の軸の交差位置を制御します。スライド 2 では、逆にしたカテゴリ軸で `Maximum` を設定すると、水平値軸は下部に留まります。特定の交差点を設定するには [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) を使用します。方向を変更する際は、カスタム交差点が既に設定されている場合に特に、交差設定を確認してください。`IsPlotOrderReversed` を `false` に戻すと通常の描画方向に復元します。交差設定は別枠です。

| 通常順 (スライド 1) | カテゴリ逆順 (スライド 2) | 値逆順 (スライド 3) |
| --- | --- | --- |
| ![通常のカテゴリ軸と値軸の順序の水平棒グラフ](axis-order-normal.png) | ![上から下へ表示されるカテゴリの水平棒グラフ](axis-order-categories-reversed.png) | ![右側にゼロがある逆向き値軸の水平棒グラフ](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | 計画、開発、テストが上から下へ並びます。値とワークブック行の順序は変更されません。 | カテゴリは通常順のまま、値は右から左へ増加します。カテゴリ軸は右側のゼロで交差します。 |

## **折れ線グラフの垂直軸を非表示にする**

垂直軸の [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) を `false` に設定して非表示にします。例ではデフォルト データの折れ線グラフを作成し、垂直軸を非表示にして保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **折れ線グラフの水平軸を非表示にする**

水平軸の [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) を `false` に設定して非表示にします。例ではデフォルト データの折れ線グラフを作成し、水平軸を非表示にして保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **カテゴリ軸を変更する**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) を設定して、日付カテゴリ軸またはテキストカテゴリ軸を選択します。この例では `ExistingChart.pptx` が必要で、最初のスライドの最初の図形がチャートで、カテゴリ セルには数値の Excel 日付が格納されています。水平軸を日付軸に変更します。[IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) を `false`、[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) を `1`、[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) を months に設定すると、主要目盛りが 1 か月間隔で配置されます。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **カテゴリ軸ラベル間隔を制御する**

カテゴリが多数あるチャートでは、カテゴリやデータ ポイントを削除せずに表示ラベルの数を減らすことができます。[IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) を `false` に設定し、[TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) に希望のカテゴリ間隔を指定します。テキストカテゴリが通常順の場合、カウントは最初のカテゴリから始まります。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` の間隔は 3 番目ごとのラベルを表示し、表示ラベル間に 2 つのラベルが非表示になります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて間隔を選択しますが、必ずしもすべてのラベルを表示するわけではありません。

目盛りは別個に制御できます。[IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) を `false` にし、[TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) で間隔を設定します。たとえば `1` にすると、カテゴリ間隔ごとに目盛りは残りますが、ラベルは 3 カテゴリごとにのみ表示されます。[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) を可視スタイルに設定して結果を確認してください。いずれかの自動間隔プロパティを `true` に戻すと、チャートが再び自動で間隔を選択します。

次の自己完結型例は 24 カテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 スライドを保存します：自動間隔、ラベル間隔を手動で設定したもの（目盛りは独立）、および自動間隔に復元したものです。2 つのコピーは元のチャート データを保持します。入力プレゼンテーションは不要です。水平ラベル テキストにより密度の違いが分かりやすくなります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Slide 2: 3 番目ごとのラベルを表示し、すべてのカテゴリに目盛りを残す。
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slide 3: チャートに両方の間隔を再度自動選択させる。
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**自動間隔 (スライド 1):** この描画では 2 つごとのカテゴリ ラベルが表示され、2 行に折り返されます。自動結果はチャートのサイズ、フォント、レンダーによって変わります。

![すべての 24 列が表示された自動カテゴリ ラベル間隔](category-axis-automatic.png)

**手動間隔 (スライド 2):** 3 つごとのラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も含め、すべての 24 列が同じ値で表示されます。スライド 3 は上記の自動外観に復元します。

![すべての 24 列が表示された手動間隔（間隔 3）](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキスト カテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸など）にこのカテゴリ数間隔を使用します。列グラフでは水平軸、水平棒グラフではカテゴリ軸が垂直になるため、[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) に適用します。目盛り間隔は、シリーズ軸を持つチャートのシリーズ軸にも適用できます。

カテゴリ ラベル間隔は、値軸の数値スケールを設定するために使用しないでください。値軸では、[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) が値の差を指定します。たとえば `10` の主要単位は、軸が 0 から開始する場合に 0、10、20... の目盛りを作ります。カテゴリ ラベル間隔 `3` はデータ値に関係なく、カテゴリ の位置をカウントします。散布図やバブル チャートはテキスト カテゴリ軸ではなく値軸を使用します。日付軸の場合は、[カテゴリ軸を変更する](#change-a-category-axis) で説明した時間ベースの主要単位とスケールを使用してください。

## **カテゴリ軸の値の日時書式を設定する**

例ではデフォルトのチャート データを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation のシリアル番号として格納されています。[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) を日付軸に設定し、[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) を無効にして、[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) に `yyyy` を割り当てることで、セルの書式設定に関係なくカテゴリ ラベルに 4 桁の年が表示されます。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **チャート軸タイトルの回転角度を設定する**

垂直軸で [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) を有効にし、タイトル テキストを設定し、[RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) で回転させます。角度は度で測定され、例では値軸タイトルを 90 度回転させた列グラフを保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **カテゴリ軸または値軸の軸位置を設定する**

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) を使用して、値軸がカテゴリ軸のカテゴリ間またはカテゴリ目盛り上で交差するかを制御します。このプロパティはカテゴリ軸に適用されます。例では列グラフの水平カテゴリ軸に `true` を設定し、結果を保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **値軸の表示単位を設定する**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) を設定して、基になるデータを変更せずに値軸ラベルをスケーリングします。[DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) を `Millions` に設定すると、60,000,000 が 60 と表示されます。例では列グラフを作成し、垂直軸にミリオン表示単位を適用します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **対数値軸を構成する**

対数値軸は、正の値が数桁にわたって分布する場合に有用です。たとえば、あるサービスが 5 期間で 10、100、1,000、10,000、100,000 のリクエストを受け取ったとします。線形スケールでは小さい値がゼロ付近に密集して表示されます。対数スケールにすると、等間隔が等比率を表すため、相対的な成長を比較しやすくなります。

値軸の [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) を `true` にし、[LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) で基数を選択します。これにより既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは変更されません。トレンドラインはデータに対するフィットした関係を表す別機能です。

### **値軸と基数を選択する**

折れ線または列グラフの場合、値軸は [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) です。水平棒グラフの場合は [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) です。散布図やバブル チャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、または両方を選択します。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000`（整数）までの基数が使用でき、`2.5` のような小数基数もサポートされます。基数 `10` の場合、10、100、1,000、10,000 などの連続したべき乗が等間隔になります。

### **線形スケーリングと対数スケーリングの比較**

次の自己完結型例は、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、そのスライドを複製して 2 番目のスライドで基数 10 の対数値軸を有効にします。両スライドは同じデータを保持します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// 最初のスライドは線形のままにし、コピーの値軸スケールだけを変更します。
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**線形スケール (スライド 1):** 等しい垂直距離はリクエスト数の等しい差を表します。最大値がチャートを支配し、 小さい値が区別しにくくなります。

![線形値軸上の 5 つのリクエスト数を示す折れ線グラフ](value-axis-linear.png)

**対数スケール (スライド 2):** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前の期間の 10 倍になるため、基数 10 のスケールでは点がまっすぐ上向きの直線を描きます。軸ラベルは元のリクエスト数をそのまま表示します。

![基数 10 の対数値軸上の同じ 5 つのリクエスト数](value-axis-logarithmic.png)

### **ゼロおよび負の値の取り扱い**

対数スケールは厳密に正の値のみ表示できます。適用前にデータを確認してください。ゼロや負の値が意味を持つ場合は、線形スケールを使用するか、別途表示してください。分析上それらの値を除外するのが妥当な場合は、除外した旨を説明します。小さな正の数に置き換えることはデータの意味を変えてしまうため行わないでください。対数軸に手動で設定した最小値または最大値も正である必要があります。

## **FAQ**

**軸が交差する位置（軸交差点）を設定する方法は？**

[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) を使用して交差動作を選択します。数値の交差点を指定するには、[CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) を設定します。これらの設定により、軸交差点を適切な基準線に移動できます。

**目盛りラベルを軸に対してどのように配置できますか？**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) を [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) とともに使用します：`Low`、`High`、`NextTo`、`None`。目盛り自体を制御するには、[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) または [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) を使用します。これらはラベル位置設定とは別です。