---
title: ".NET でプレゼンテーションの円グラフをカスタマイズ"
linktitle: "円グラフ"
type: docs
url: /ja/net/pie-chart/
keywords:
- "円グラフ"
- "チャートの管理"
- "チャートのカスタマイズ"
- "チャートオプション"
- "チャート設定"
- "プロットオプション"
- "スライスの色"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides を使用して .NET で円グラフを作成およびカスタマイズします。二次プロットを設定し、データラベルを表示し、PowerPoint で自動スライスカラーを適用します。"
---
## **概要**

この記事では、Aspose.Slidesで円グラフを使用する方法を説明します。Pie of Pie および Bar of Pie グラフの二次プロットオプションの設定方法と、標準の円グラフで自動スライス着色を有効にする方法を示します。

例では、スライドへのグラフの追加、シリーズやラベル設定の調整、既定のグラフデータをカスタムのカテゴリと値に置き換えること、そして更新されたプレゼンテーションの保存といったグラフカスタマイズ作業に焦点を当てています。

## **Pie of Pie と Bar of Pie グラフの二次プロット オプション**

Aspose.Slides for .NET は、Pie of Pie と Bar of Pie グラフの二次プロットオプションをサポートしています。これらのオプションは、二次プロットのサイズと、データ ポイントが 2 つのプロット間でどのように分割されるかを制御します。

以下の例は、新しいプレゼンテーションに Pie of Pie グラフを作成し、データ ポイントの値をラベルとして表示します。[SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) プロパティは二次プロットのサイズをメイン プロットの 149% に設定します。[PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) はパーセンテージベースの分割を選択し、[PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) はしきい値を 53% に設定します。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **二次プロットのカテゴリを選択**

パーセンテージ値に関係なく特定のカテゴリを二次プロットでグループ化したい場合は、カスタム分割を使用します。たとえば、売上レポートで Online と Events を一緒に表示すると、読者はこれら 2 つのチャネルを比較でき、合計売上の 35% と 10% を占めていても問題ありません。

[PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) を [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) に設定し、[PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/) でポイントを選択します。コレクションの [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) メソッドは、シリーズ内のゼロベースインデックスまたはデータポイントオブジェクトのいずれかを受け入れます。この例では、インデックス 1 が Online を選択し、インデックス 3 のポイントが Events を選択します。Partners も一時的に追加され、[Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/) で除外されます。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// デフォルトのデータをチャネル別売上に置き換えます。
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Online をゼロベースインデックスで、Events をデータポイントオブジェクトで選択します。
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Partners を選択から除外しますが、ソース データは削除しません。
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) と Events (10) は二次プロットで別々のスライスとして表示されます。一次プロットでは、Retail (40) と Partners (15) と共に、値 45 の結合スライスとして表されます。Partners をカスタム選択から削除しても一次プロットに残り、カテゴリやその値がチャートのソース データから削除されることはありません。

以下の画像は、PowerPoint で保存されたプレゼンテーションを示しています。

![二次プロットに Online と Events があり、一次プロットでそれらの合計値 45 が表示された Pie of Pie グラフ](pie_of_pie_custom.png)

## **自動円グラフ スライスカラーの設定**

Aspose.Slides for .NET は、円グラフのスライスに自動的に異なる色を割り当てることができます。以下の例は、中央揃えのタイトルを持つ円グラフを作成し、既定のデータを 3 つの四半期カテゴリとその値に置き換えます。[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) プロパティは値 20、50、30 をラベルとして表示し、[IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) は各スライスに異なる色を有効にします。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// 中央揃えのチャートタイトルを追加します。
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// 最初のワークシートを使用してデフォルトデータを置き換えます。
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// 値を表示し、スライスに異なる色を割り当てます。
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Pie of Pie と Bar of Pie のバリエーションはサポートされていますか？**

はい、ライブラリはピーチャートの二次プロットをサポートしており、Pie of Pie および Bar of Pie タイプを含みます。[supports](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)

**チャートだけを画像 (例: PNG) としてエクスポートできますか？**

はい、プレゼンテーション全体をエクスポートせずに、[チャート自体を画像としてエクスポート](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)（PNG など）を行うことができます。