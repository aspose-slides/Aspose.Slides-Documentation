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
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションのレポートや可視化のためにチャート軸をカスタマイズする方法をご紹介します。"
---
## **概要**

この記事では、Aspose.Slides for .NET を使用してチャート軸をカスタマイズする方法を説明します。計算された軸値、チャートの行と列の入れ替え、軸の表示、カテゴリ ラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置、表示単位、および対数スケーリングについて扱います。

## **チャートの垂直軸の最大値を取得する**

デフォルト データでエリア チャートを追加し、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) を作成します。計算された軸値を読む前に、チャート レイアウトを最新の状態にするために [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) を呼び出します。

軸の限界として [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) と [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) を読み取り、目盛り間隔として [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) と [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) を読み取ります。[ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) と [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) は日付軸に関連する時間単位スケールを提供します。例では、これらの値をローカル変数に格納し、チャートを保存します。

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

[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) を使用して、チャート データ内の系列とカテゴリの役割を入れ替えます。元のカテゴリは系列になり、元の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、水平軸と垂直軸を入れ替えるわけではありません。例では、[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) を使用してデフォルト データを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替える前に設定します。4 系列と 3 カテゴリのチャートを保存します。

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

## **軸のプロット順序を逆にする**

[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) を使用してカテゴリ軸または値軸の順序を逆にします。たとえば、水平棒グラフは、ワークシートと同じ順序で「計画」「開発」「テスト」のプロジェクト段階を上から下へ表示できます。軸を逆にすると描画方向が変わりますが、ブックデータの並び替えや再配置は行われません。比較として、[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) は系列とカテゴリの役割を入れ替えます。

以下の例は、3 つの段階と 1 系列の水平棒グラフを作成します。通常順序、逆順カテゴリ、逆順値の 3 つのスライドを持つプレゼンテーションを保存します。各コピーは同じデータセットを使用し、各コピーで 1 つの軸だけが逆になります。

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

// Slide 2: 最初のカテゴリを上部に表示します。
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// 水平値軸を下部に保ちます。
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: 水平数値スケールのみを逆にします。
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

軸を逆にすると、直交軸をプロットの反対側に移動させることもできます。[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) は、構成中の軸が他の軸と交差する位置を制御します。スライド 2 では、逆順カテゴリ軸に対して `Maximum` を設定すると、水平値軸は下部に残ります。特定の交差点を指定するには [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) を使用します。方向を変更するときは、特にチャートにカスタム交差点が設定されている場合、交差設定を確認してください。`IsPlotOrderReversed` を `false` に戻すと通常の描画方向が復元されます。交差設定は別個です。

| 通常順序（スライド 1） | カテゴリ逆順（スライド 2） | 値逆順（スライド 3） |
| --- | --- | --- |
| ![通常のカテゴリと値軸順序の水平棒グラフ](axis-order-normal.png) | ![カテゴリが上から下へ表示された水平棒グラフ](axis-order-categories-reversed.png) | ![値軸が逆で右側がゼロの水平棒グラフ](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | 計画、開発、テストが上から下へ並びます。値とワークブックの行順序は変更されません。 | カテゴリは通常順序のまま、値は右から左へ増加します。カテゴリ軸は右側のゼロで交差します。 |

## **折れ線グラフの垂直軸を非表示にする**

垂直軸の [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) を `false` に設定して非表示にします。例ではデフォルト データで折れ線グラフを作成し、垂直軸を非表示にして保存します。

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

水平軸の [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) を `false` に設定して非表示にします。例ではデフォルト データで折れ線グラフを作成し、水平軸を非表示にして保存します。

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

## **チャートのグリッドラインを表示または非表示にする**

[ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) と [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/) を読み取って、軸が表示するグリッドラインを確認します。両プロパティは読み取り専用です。[MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/) のライン塗りつぶしを使用して、補助グリッドラインを表示または非表示にします。表示するには可視色の実体塗りつぶしを設定し、非表示にするには `FillType.NoFill` を使用します。主グリッドラインの対応設定は [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat` です。グリッドラインの塗りつぶしを変更しても軸の可視性や目盛りは保持されます。

このクラスター化カラム チャートの垂直軸は、主グリッドラインが表示され、補助グリッドラインが非表示の状態で開始します。例では補助グリッドラインをオレンジで表示し、保存前に再び非表示にします。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| 補助グリッドライン表示 | 補助グリッドライン非表示 |
| --- | --- |
| ![垂直軸の主グリッドライン間にオレンジの補助グリッドラインがある](minor-gridlines-enabled.png) | ![同じカラムチャートで主グリッドラインのみが表示される](minor-gridlines-hidden.png) |

## **カテゴリ軸を変更する**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) を設定して、日付軸またはテキスト軸を選択します。この例では `ExistingChart.pptx`（最初のスライドの最初のシェイプとしてチャートがあり、カテゴリ セルに数値の Excel 日付が含まれる）を使用します。水平軸を日付軸に変更します。[IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) を `false`、[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) を `1`、[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) を月に設定すると、主目盛りが 1 カ月間隔になります。

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

### **データからカテゴリ軸の種類を判定する**

カテゴリを設定した後に [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) を呼び出し、続いて [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) を読み取って選択状態を確認します。テキスト ラベルまたは数値の日付が入力される場合に便利です。このメソッドは呼び出し時にタイプを決定し、後からデータが変化しても再評価は行いません。カテゴリを置き換えた後に再度呼び出します。

以下の例はテキストカテゴリのチャートを作成し `Text` と出力します。その後カテゴリ セルの値を日付に置き換えて再度メソッドを呼び出し、`Date` と出力します。日付は [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate) が返す数値の OLE Automation 値として格納され、文字列ではありません。[CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) はそれらの表示形式を制御しますが、テキストを数値日付に変換しません。カテゴリ セルの詳細は [Chart Workbook](/slides/ja/net/chart-workbook/) を参照してください。

入力がテキストカテゴリまたは数値日付であることが分かっている場合は自動判定を使用します。通常の数値ラベル、混在カテゴリ、または空データの場合は、目的に合わせて明示的に [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) を設定してください。数値だけではカテゴリが日付を表すと判断できません。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // テキスト

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // 日付

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **カテゴリ軸ラベル間隔を制御する**

カテゴリが多数あるチャートでは、カテゴリやデータポイントを削除せずに表示ラベル数を減らすことができます。[IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) を `false` に設定し、[TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) に希望のカテゴリ間隔を指定します。テキストカテゴリが通常順序の場合、カウントは最初のカテゴリから開始します。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔 `3` は 3 番目ごとのラベルのみ表示し、表示ラベル間に 2 つのラベルを隠します。対応する列は削除されません。自動間隔は利用可能なスペースに基づき決定され、必ずしも全ラベルを表示するわけではありません。

目盛りには別の制御があります。[IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) を `false` にし、[TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) で間隔を設定します。たとえば `1` は各カテゴリ間隔に目盛りを配置し、ラベルは 3 カテゴリごとに表示されます。[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) を可視スタイルに設定すると結果が確認できます。自動間隔プロパティを `true` に戻すと、チャートが再び自動で間隔を選択します。

以下の自己完結型例は 24 カテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 つのスライドを保存します。自動間隔、ラベル間隔手動設定（目盛りは独立）、自動間隔復元です。2 つのコピーは元のチャート データを保持します。入力プレゼンテーションは不要です。水平ラベル テキストにより密度の違いが分かりやすくなります。

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

// Slide 2: 3番目ごとのラベルを表示し、すべてのカテゴリに目盛りを残す。
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slide 3: チャートに両方の間隔を再び自動選択させる。
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**自動間隔（スライド 1）:** このレンダリングでは 2 番目ごとのカテゴリ ラベルが表示され、2 行に折り返されます。自動結果はチャートのサイズ、フォント、レンダラにより変わります。

![すべての 24 列が表示された自動カテゴリ ラベル間隔](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 番目ごとのラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も含め、24 列すべてが同じ値で可視です。スライド 3 は上記の自動外観に戻します。

![すべての 24 列が表示された手動カテゴリ ラベル間隔（3）](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキスト カテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸）にこのカテゴリ間隔を使用します。列グラフでは水平軸、水平棒グラフでは垂直軸がカテゴリ軸になるため、[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) に適用してください。目盛り間隔は系列軸があるチャートにも適用されます。

カテゴリ ラベル間隔を値軸の数値スケールに使用しないでください。値軸では [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) が値の差を指定します（例: `10` の主単位は 0, 10, 20 ...）。カテゴリ ラベル間隔 `3` はデータ値に関係なくカテゴリ位置を数えるだけです。散布図やバブルチャートはテキスト カテゴリ軸ではなく値軸を使用します。日付軸の場合は、[カテゴリ軸を変更する](#change-a-category-axis) に記載の時間ベースの主単位とスケールを使用してください。

## **カテゴリ軸の値に日付書式を設定する**

例ではデフォルトのチャート データを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation のシリアル番号として格納されます。[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) を日付軸に設定し、[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) を無効にし、[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) に `yyyy` を割り当てて、セル書式に関係なくカテゴリ ラベルが 4 桁の年として表示されるようにします。

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

垂直軸で [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) を有効にし、タイトル テキストを提供し、[RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) を設定してタイトルを回転させます。角度は度で測定され、例では値軸タイトルを 90 度回転させた列グラフを保存します。

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

[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) を使用して、値軸がカテゴリ軸とカテゴリ間またはカテゴリ目盛り位置で交差するかを制御します。このプロパティはカテゴリ軸に適用されます。例では列グラフの水平カテゴリ軸に `true` を設定し、結果を保存します。

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

## **チャート値軸の表示単位を設定する**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) を設定して、基になるデータを変更せずに値軸ラベルをスケーリングします。[DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) を `Millions` に設定すると、60,000,000 の値が 60 と表示されます。例では列グラフを作成し、垂直軸にミリオン表示単位を適用します。

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

対数値軸は、正の値が数桁にわたって分布する場合に便利です。たとえば、あるサービスが 5 期間で 10、100、1,000、10,000、100,000 件のリクエストを受け取るとします。線形スケールでは小さい値がゼロ付近に密集して見えます。対数スケールでは、等間隔が等比率を表すため、相対的な増加が比較しやすくなります。

値軸の [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) を `true` に設定し、[LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) で基数を選択します。これにより既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは追加されません。トレンドラインはデータにフィットした関係を表す別機能です。

### **値軸と基数を選択する**

折れ線グラフまたは列グラフの場合、値軸は [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) です。水平棒グラフの場合は [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) が該当します。散布図やバブルチャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、または両方を選択してください。カテゴリ軸に対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000`（整数）までの基数が使用可能で、`2.5` のような小数基数もサポートされます。基数 `10` では 10、100、1,000、10,000 などの連続したべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の自己完結型例は、最初のスライドに 5 つのリクエスト数で折れ線グラフを作成し、スライドを複製して 2 番目のスライドで基数 10 の対数値軸を有効にします。両スライドは同じデータを保持します。

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

// 最初のスライドは線形のままにし、コピーの値軸のスケールだけを変更します。
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**線形スケール（スライド 1）:** 等しい垂直距離はリクエスト数の等しい差を表します。最大値がチャートを支配し、低い値が区別しにくくなります。

![線形値軸で 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前回の 10 倍になるため、基数 10 のスケールでは直線的に上昇する線になります。軸ラベルは元のリクエスト数をそのまま表示します。

![基数 10 の対数値軸で同じ 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-logarithmic.png)

### **ゼロと負の値の取り扱い**

対数スケールは厳密に正の値のみ表示できます。有効化する前にデータを確認してください。ゼロまたは負の値が意味を持つ場合は線形スケールを維持するか、別途表示してください。分析上それらの値を除外することが妥当であれば、その理由を説明します。小さな正の数で置き換えることはデータの意味を変えるため避けてください。対数軸の手動で設定した最小値または最大値も正である必要があります。

## **FAQ**

**軸が他の軸と交差する位置（軸交差点）をどう設定しますか？**

[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) を使用して交差動作を選択します。数値の交差点を指定する場合は [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) を設定します。これらの設定により、軸交差点を適切な基準線に移動できます。

**目盛りラベルを軸に対してどのように配置しますか？**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) を [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) の `Low`、`High`、`NextTo`、または `None` で設定します。目盛り自体を制御するには、[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) または [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) を使用します。これらはラベル配置とは別の設定です。