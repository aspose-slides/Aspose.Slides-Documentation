---
title: "C#でのチャートシリーズの管理"
linktitle: "チャートシリーズ"
type: docs
url: /ja/net/chart-series/
keywords:
- "チャートシリーズ"
- "シリーズの重なり"
- "シリーズの色"
- "カテゴリの色"
- "シリーズ名"
- "データポイント"
- "シリーズ間隔"
- "PowerPoint"
- "プレゼンテーション"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "実用的なコード例とベストプラクティスを用いて、PowerPoint（PPT/PPTX）向けにC#でチャートシリーズを管理し、データプレゼンテーションを強化する方法を学びます。"
---

## **概要**

この記事では、Aspose.Slides for .NET における [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) の役割について、プレゼンテーション内でデータがどのように構造化・可視化されるかに焦点を当てて説明します。これらのオブジェクトは、チャート内のデータポイント、カテゴリ、外観パラメータの個別セットを定義する基礎要素を提供します。[ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) を使用することで、開発者は基になるデータソースをシームレスに統合し、情報の表示方法を完全に制御でき、洞察や分析を明確に伝える動的なデータ駆動型プレゼンテーションを実現できます。

シリーズとは、チャートにプロットされる数値の行または列です。

![チャートシリーズ PowerPoint](chart-series-powerpoint.png)

## **チャートシリーズの重なり設定**

[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) プロパティは、2D チャートにおける棒や柱の重なり具合を -100 から 100 の範囲で指定して制御します。このプロパティは個々のチャートシリーズではなくシリーズ グループに紐付いているため、シリーズ レベルでは読み取り専用です。重なり値を設定するには、`ParentSeriesGroup.Overlap` の読み書き可能プロパティを使用し、指定した重なりをそのグループ内のすべてのシリーズに適用します。

以下はプレゼンテーションを作成し、クラスター化柱状グラフを追加し、最初のチャートシリーズにアクセスして重なり設定を構成し、PPTX ファイルとして保存する C# の例です。
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルトデータでクラスター化された縦棒グラフを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // シリーズの重なりを設定します。
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // プレゼンテーションファイルをディスクに保存します。
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


結果:

![シリーズの重なり](series_overlap.png)

## **シリーズの塗りつぶし色の変更**

Aspose.Slides を使用すると、チャートシリーズの塗りつぶし色を簡単にカスタマイズでき、特定のデータポイントを強調したり、視覚的に魅力的なチャートを作成したりできます。これは [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/) オブジェクトを介して実現され、さまざまな塗りつぶしタイプ、カラー構成、その他の高度なスタイリング オプションがサポートされます。スライドにチャートを追加し、目的のシリーズにアクセスしたら、シリーズを取得して適切な塗りつぶし色を適用するだけです。単色塗りつぶしだけでなく、グラデーションやパターン塗りつぶしも利用でき、デザインの柔軟性が向上します。必要な色設定が完了したら、プレゼンテーションを保存して変更を確定します。

以下の C# コード例は、最初のシリーズの色を変更する方法を示しています。
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルトデータでクラスター化された縦棒グラフを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 最初のシリーズの色を設定します。
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // プレゼンテーションファイルをディスクに保存します。
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


結果:

![シリーズの色](series_color.png)

## **シリーズ名の変更**

 Aspose.Slides は、チャートシリーズの名前を簡単に変更できる機能を提供し、データを分かりやすく意味のある形でラベル付けできます。チャート データ内の該当するワークシート セルにアクセスすることで、データの提示方法をカスタマイズできます。この変更は、シリーズ名をデータのコンテキストに合わせて更新または明確化する必要がある場合に特に有用です。シリーズ名の変更後、プレゼンテーションを保存して変更を永続化できます。

以下はこのプロセスを実際に示す C# コード スニペットです。
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルトデータでクラスター化された縦棒グラフを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 最初のシリーズの名前を設定します。
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // プレゼンテーションファイルをディスクに保存します。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


別の方法でシリーズ名を変更する C# コードは次のとおりです。
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルトデータでクラスター化された縦棒グラフを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 最初のシリーズの名前を設定します。
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // プレゼンテーションファイルをディスクに保存します。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


結果:

![シリーズ名](series_name.png)

## **シリーズの自動塗りつぶし色の取得**

Aspose.Slides for .NET を使用すると、プロット領域内のチャートシリーズの自動塗りつぶし色を取得できます。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成した後、インデックスで目的のスライドへの参照を取得し、`ChartType.ClusteredColumn` などの希望するタイプでチャートを追加します。チャート内のシリーズにアクセスすれば、自動塗りつぶし色を取得できます。

以下の C# コードがこの手順を詳細に示しています。
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルトデータでクラスター化された縦棒グラフを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // シリーズの自動塗りつぶし色を取得します。
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```


出力:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **チャートシリーズの負の値用反転塗りつぶし色の設定**

データシリーズに正と負の両方の値が含まれる場合、すべての柱や棒を同じ色で塗るとチャートが読みづらくなります。Aspose.Slides for .NET では、負の値に自動的に適用される別の塗りつぶし色（反転塗りつぶし色）を割り当てることができ、負の値が一目で際立ちます。このセクションでは、そのオプションを有効にし、適切な色を選択し、更新されたプレゼンテーションを保存する方法を学びます。

以下のコード例が操作を示しています。
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 新しいカテゴリを追加します。
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // 新しいシリーズを追加します。
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // シリーズのデータを設定します。
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // シリーズの色設定を行います。
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```


結果:

![反転された単色塗りつぶし色](inverted_solid_fill_color.png)

単一のデータポイントだけの塗りつぶし色を反転させることもできます。目的の `IChartDataPoint` にアクセスし、その `InvertIfNegative` プロパティを `true` に設定します。

以下のコード例がその方法を示しています。
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // データポイントインデックス 2 が負の場合、色を反転します。
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **特定のデータポイントの値のクリア**

チャートにテスト用の値、外れ値、または不要なエントリが含まれている場合、シリーズ全体を再構築せずにそれらを削除したいことがあります。Aspose.Slides for .NET を使用すると、インデックスで任意のデータポイントを対象にし、その内容をクリアし、プロットを即座に更新して残りのポイントがシフトし、軸が自動的に再スケールされます。

以下のコード例が操作を示しています。
```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```


## **シリーズの間隔幅の設定**

間隔幅は隣接する柱や棒の間の空白量を制御します。間隔を広くすると個々のカテゴリが強調され、狭くすると密集したコンパクトな外観になります。Aspose.Slides for .NET を使用すると、シリーズ全体のこのパラメータを細かく調整でき、データを変更せずにプレゼンテーションに必要な視覚的バランスを実現できます。

以下のコード例は、シリーズの間隔幅を設定する方法を示しています。
```cs
ushort gapWidth = 30;

// 空のプレゼンテーションを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルトデータでチャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // プレゼンテーションをディスクに保存します。
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // GapWidth の値を設定します。
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // プレゼンテーションをディスクに保存します。
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


結果:

![間隔幅](gap_width.png)

## **FAQ**

**単一のチャートに含められるシリーズの数に上限はありますか？**

Aspose.Slides にはシリーズ数の固定上限はありません。実務上の上限はチャートの可読性とアプリケーションで利用可能なメモリに依存します。

**クラスター内の柱が互いに近すぎる、あるいは離れすぎる場合はどうすればよいですか？**

そのシリーズ（または親シリーズ グループ）の `GapWidth` 設定を調整します。値を大きくすると柱間のスペースが広がり、値を小さくすると柱が近づきます。