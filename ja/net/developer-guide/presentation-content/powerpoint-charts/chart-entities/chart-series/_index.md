---
title: .NET のプレゼンテーションでチャート データ シリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/net/chart-series/
keywords:
- チャートシリーズ
- シリーズ オーバーラップ
- シリーズ 色
- カテゴリ 色
- シリーズ 名
- データポイント
- シリーズ ギャップ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "実用的なコード例とベストプラクティスを用いて、PowerPoint（PPT/PPTX）用の C# でチャートシリーズを管理し、データ プレゼンテーションを強化する方法を学びます。"
---

## **概要**

本記事では、Aspose.Slides for .NET における [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) の役割について、プレゼンテーション内でデータがどのように構造化され、視覚化されるかに焦点を当てて説明します。これらのオブジェクトは、チャート内のデータポイント、カテゴリ、および外観パラメータを個別に定義する基礎要素を提供します。[ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) を使用することで、開発者は基礎データソースをシームレスに統合し、情報の表示方法を完全にコントロールでき、洞察と分析を明確に伝える動的なデータ駆動型プレゼンテーションを実現できます。

シリーズは、チャートにプロットされる行または列の数値です。

![チャートシリーズ PowerPoint](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップの設定**

[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) プロパティは、-100 から 100 の範囲を指定することで 2D チャートにおける棒と列のオーバーラップ方法を制御します。このプロパティは個々のチャートシリーズではなくシリーズ グループに関連付けられているため、シリーズ レベルでは読み取り専用です。オーバーラップ値を設定するには、`ParentSeriesGroup.Overlap` の読み書き可能プロパティを使用し、指定したオーバーラップをそのグループ内のすべてのシリーズに適用します。

以下は、プレゼンテーションを作成し、クラスター化された列チャートを追加し、最初のチャートシリーズにアクセスしてオーバーラップ設定を構成し、結果を PPTX ファイルとして保存する方法を示す C# の例です。
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスター化列チャートを追加します。
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
![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶし色の変更**

Aspose.Slides を使用すると、チャートシリーズの塗りつぶし色を簡単にカスタマイズでき、特定のデータポイントを強調表示し、視覚的に魅力的なチャートを作成できます。これは、さまざまな塗りつぶしタイプ、カラー設定、その他の高度なスタイリングオプションをサポートする [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/) オブジェクトを使用して実現します。スライドにチャートを追加し、目的のシリーズにアクセスしたら、シリーズを取得して適切な塗りつぶし色を適用するだけです。単色塗りつぶしだけでなく、グラデーションやパターン塗りつぶしも利用でき、デザインの柔軟性が向上します。要件に合わせて色を設定したら、プレゼンテーションを保存して更新された外観を確定します。

以下の C# コード例は、最初のシリーズの色を変更する方法を示しています。
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスター化列チャートを追加します。
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
![シリーズの色](series_color.png)

## **シリーズ名の変更**

Aspose.Slides は、チャートシリーズの名前を簡単に変更できる機能を提供し、データを分かりやすく意味のある形でラベル付けできるようにします。チャートデータ内の該当するワークシートセルにアクセスすることで、データの表示方法をカスタマイズできます。この変更は、シリーズ名をデータのコンテキストに合わせて更新または明確化する必要がある場合に特に有用です。シリーズの名前を変更した後、プレゼンテーションを保存して変更を永続化できます。

以下の C# コードスニペットは、このプロセスを実際に示しています。
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスター化列チャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 最初のシリーズの名前を設定します。
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // プレゼンテーション ファイルをディスクに保存します。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


以下の C# コードは、シリーズ名を変更する別の方法を示しています。
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスター化列チャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 最初のシリーズの名前を設定します。
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // プレゼンテーション ファイルをディスクに保存します。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


結果:
![シリーズ名](series_name.png)

## **シリーズの自動塗りつぶし色の取得**

Aspose.Slides for .NET は、プロット領域内のチャートシリーズに対して自動塗りつぶし色を取得できる機能を提供します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成した後、インデックスで目的のスライドへの参照を取得し、好みのタイプ（例: `ChartType.ClusteredColumn`）でチャートを追加します。チャート内のシリーズにアクセスすることで、自動塗りつぶし色を取得できます。

以下の C# コードは、このプロセスを詳細に示しています。
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // デフォルト データでクラスター化列チャートを追加します。
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


## **チャートシリーズの反転塗りつぶし色の設定**

データシリーズに正と負の値が混在している場合、すべての列や棒を同じ色で塗るとチャートが読みにくくなります。Aspose.Slides for .NET は、負の値に自動的に適用される別の塗りつぶし（反転塗りつぶし色）を割り当てることで、負の値を一目で目立たせることができます。このセクションでは、そのオプションを有効にし、適切な色を選択し、更新されたプレゼンテーションを保存する方法を学びます。

以下のコード例は、この操作を示しています。
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
![反転した単色塗りつぶしカラー](inverted_solid_fill_color.png)

単一のデータポイントに対してだけ塗りつぶし色を反転させることもできます。目的の `IChartDataPoint` にアクセスし、その `InvertIfNegative` プロパティを true に設定してください。

以下のコード例は、その方法を示しています。
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

    // インデックス2のデータポイントが負の場合に色を反転します。
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **特定のデータポイントの値のクリア**

チャートにテスト用の値や外れ値、古いエントリが含まれていることがありますが、シリーズ全体を再構築せずにそれらを削除したい場合があります。Aspose.Slides for .NET は、インデックスで任意のデータポイントを対象にし、その内容をクリアし、プロットを即座に更新して残りのポイントがシフトし、軸が自動的に再スケーリングされるようにできます。

以下のコード例は、この操作を示しています。
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


## **シリーズのギャップ幅の設定**

ギャップ幅は隣接する列や棒の間の空白量を制御します。ギャップが広いと各カテゴリが強調され、狭いとより密集したコンパクトな外観になります。Aspose.Slides for .NET を使用すれば、シリーズ全体のこのパラメータを微調整でき、基になるデータを変更せずにプレゼンテーションに必要な視覚的バランスを正確に実現できます。

以下のコード例は、シリーズのギャップ幅を設定する方法を示しています。
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
![ギャップ幅](gap_width.png)

## **FAQ**

**単一のチャートが保持できるシリーズの数に上限はありますか？**

Aspose.Slides には、追加できるシリーズ数に固定された上限はありません。実際の上限は、チャートの可読性およびアプリケーションで利用可能なメモリによって決まります。

**クラスター内の列が互いに近すぎる、または離れすぎる場合はどうすればよいですか？**

そのシリーズ（または親シリーズグループ）の `GapWidth` 設定を調整します。値を大きくすると列間のスペースが広がり、値を小さくすると列が近づきます。