---
title: .NET のプレゼンテーションでチャートデータシリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/net/chart-series/
keywords:
- チャートシリーズ
- シリーズの重なり
- シリーズの色
- カテゴリの色
- シリーズ名
- データポイント
- シリーズのギャップ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) 用の C# でチャートシリーズを管理する方法を、実用的なコード例とベストプラクティスを通じて学び、データプレゼンテーションを強化します。"
---

## **概要**

本稿では Aspose.Slides for .NET における [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) の役割について説明し、プレゼンテーション内でデータがどのように構造化され可視化されるかに焦点を当てます。これらのオブジェクトは、チャート内の個々のデータポイント、カテゴリ、および外観パラメータを定義する基礎要素を提供します。[ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) を使用することで、開発者は基になるデータ ソースをシームレスに統合し、情報の表示方法を完全に制御できるため、洞察と分析を明確に伝える動的なデータ駆動型プレゼンテーションを作成できます。

Series は、チャートにプロットされる数値の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Chart Series の Overlap 設定**

[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) プロパティは、2D チャートにおいてバーや列がどの程度重なるかを -100 から 100 の範囲で指定して制御します。このプロパティは個々のチャート Series ではなく Series グループに関連付けられているため、Series レベルでは読み取り専用です。Overlap の値を設定するには、`ParentSeriesGroup.Overlap` の読み書き可能なプロパティを使用し、指定した Overlap をそのグループ内のすべての Series に適用します。

以下は、プレゼンテーションを作成し、クラスター化列チャートを追加し、最初の Chart Series にアクセスして Overlap 設定を構成し、結果を PPTX ファイルとして保存する C# のサンプルです。
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスタ化列チャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // シリーズのオーバーラップを設定します。
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // プレゼンテーション ファイルをディスクに保存します。
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


結果:

![The series overlap](series_overlap.png)

## **Series の塗りつぶし色の変更**

Aspose.Slides を使用すると、チャート Series の塗りつぶし色を簡単にカスタマイズでき、特定のデータポイントを強調したり、視覚的に魅力的なチャートを作成したりできます。これは [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/) オブジェクトを介して実現され、さまざまな塗りつぶしタイプ、カラー設定、その他高度なスタイリング オプションがサポートされます。スライドにチャートを追加し、目的の Series にアクセスしたら、Series を取得して適切な塗りつぶし色を適用します。単色塗りつぶしに加えて、グラデーションやパターン塗りつぶしも利用でき、デザインの柔軟性が向上します。必要なカラー設定が完了したら、プレゼンテーションを保存して外観の変更を確定します。

次の C# コード例は、最初の Series の色を変更する方法を示しています。
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスタ化列チャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 最初のシリーズの色を設定します。
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // プレゼンテーション ファイルをディスクに保存します。
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


結果:

![The color of the series](series_color.png)

## **Series 名の変更**

Aspose.Slides は、チャート Series の名前を簡単に変更できる機能を提供し、データを分かりやすく意味のある形でラベル付けできます。チャート データ内の該当するワークシート セルにアクセスすることで、開発者はデータの提示方法をカスタマイズできます。この変更は、Series 名をデータのコンテキストに合わせて更新または明確化する必要がある場合に特に有用です。Series 名を変更したら、プレゼンテーションを保存して変更を永続化します。

以下は、このプロセスを実際に示す C# コード スニペットです。
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスタ化列チャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 最初のシリーズの名前を設定します。
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // プレゼンテーション ファイルをディスクに保存します。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


次の C# コードは、Series 名を変更する別の方法を示しています。
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスタ化列チャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 最初のシリーズの名前を設定します。
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // プレゼンテーション ファイルをディスクに保存します。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


結果:

![The series name](series_name.png)

## **Series の自動塗りつぶし色取得**

Aspose.Slides for .NET を使用すると、プロット領域内のチャート Series の自動塗りつぶし色を取得できます。まず [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成し、インデックスで目的のスライドへの参照を取得します。その後、好みのタイプ（例: `ChartType.ClusteredColumn`）のチャートを追加します。チャート内の Series にアクセスすれば、自動塗りつぶし色を取得できます。

以下の C# コードは、この手順を詳細に示しています。
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスタ化列チャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // シリーズの塗りつぶし色を取得します。
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


## **Chart Series の Invert 塗りつぶし色設定**

データ Series に正負両方の値が含まれる場合、すべての列やバーを同じ色で塗るとチャートが読みにくくなります。Aspose.Slides for .NET では、負の値に対して自動的に適用される別の塗りつぶし色（Invert 塗りつぶし色）を割り当てることができ、負の値を一目で判別できるようになります。このセクションでは、そのオプションを有効にし、適切な色を選択し、更新されたプレゼンテーションを保存する方法を学びます。

次のコード例は、この操作を示しています。
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

    // シリーズのデータを入力します。
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

![The inverted solid fill color](inverted_solid_fill_color.png)

単一のデータポイントだけに Invert 塗りつぶし色を適用することもできます。対象の `IChartDataPoint` にアクセスし、その `InvertIfNegative` プロパティを true に設定してください。

以下のコード例は、その手順を示しています。
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

    // インデックス 2 のデータポイントが負の場合、色を反転します。
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **特定データポイントの値クリア**

チャートにテスト データや外れ値、古いエントリが含まれており、Series 全体を再構築せずに削除したい場合があります。Aspose.Slides for .NET は、インデックスで任意のデータポイントを対象にし、その内容をクリアしてプロットを即座に更新できるため、残りのポイントがシフトし、軸が自動的に再スケーリングされます。

次のコード例は、この操作を示しています。
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


## **Series の Gap Width 設定**

Gap Width は隣接する列やバー間の空白量を制御します。広いギャップは個々のカテゴリを強調し、狭いギャップは密度の高いコンパクトな外観を実現します。Aspose.Slides for .NET を使用すると、Series 全体に対してこのパラメータを微調整でき、データ自体を変更せずにプレゼンテーションに求められる視覚的バランスを正確に得られます。

次のコード例は、Series の Gap Width を設定する方法を示しています。
```cs
ushort gapWidth = 30;

// 空のプレゼンテーションを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルト データでチャートを追加します。
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

![The gap width](gap_width.png)

## **FAQ**

**単一のチャートが保持できる Series の数に上限はありますか？**

Aspose.Slides には追加できる Series の固定上限はありません。実際の上限はチャートの可読性とアプリケーションで利用可能なメモリ量によって決まります。

**クラスター内の列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

その Series（または親 Series グループ）の `GapWidth` 設定を調整してください。値を大きくすると列間のスペースが広がり、値を小さくすると列が近づきます。