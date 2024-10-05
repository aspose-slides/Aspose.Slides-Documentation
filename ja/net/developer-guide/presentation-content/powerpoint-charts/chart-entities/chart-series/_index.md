---
title: チャート系列
type: docs
url: /net/chart-series/
keywords: "チャート系列, 系列の色, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET における PowerPoint プレゼンテーションのチャート系列"
---

系列はチャートにプロットされた数字の行または列です。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列のオーバーラップを設定**

[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) プロパティを使用すると、2D チャート上で棒グラフや列がどれだけオーバーラップするかを指定できます (範囲: -100 から 100)。このプロパティは親系列グループのすべての系列に適用されます。これは適切なグループプロパティの投影です。したがって、このプロパティは読み取り専用です。

`ParentSeriesGroup.Overlap` の読み書き可能なプロパティを使用して、`Overlap` の希望の値を設定します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. スライドにクラスター化された列チャートを追加します。
1. 最初のチャート系列にアクセスします。
1. チャート系列の `ParentSeriesGroup` にアクセスし、系列の希望のオーバーラップ値を設定します。
1. 修正されたプレゼンテーションを PPTX ファイルに保存します。

この C# コードは、チャート系列のオーバーラップを設定する方法を示しています：

```c#
using (Presentation presentation = new Presentation())
{
    // チャートを追加
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.ChartData.Series;
    if (series[0].Overlap == 0)
    {
        // 系列のオーバーラップを設定
        series[0].ParentSeriesGroup.Overlap = -30;
    }

    // プレゼンテーションファイルをディスクに書き込みます
    presentation.Save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
}
```

## **系列の色を変更**
Aspose.Slides for .NET を使用すると、系列の色を次のように変更できます。

1. `Presentation` クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列にアクセスします。
1. 希望の塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正されたプレゼンテーションを保存します。

この C# コードは、系列の色を変更する方法を示しています：

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[1];
	
	point.Explosion = 30;
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **系列カテゴリの色を変更**
Aspose.Slides for .NET を使用すると、系列カテゴリの色を次のように変更できます。

1. `Presentation` クラスのインスタンスを作成します。
1. スライドにチャートを追加します。
1. 色を変更したい系列カテゴリにアクセスします。
1. 希望の塗りつぶしタイプと塗りつぶし色を設定します。
1. 修正されたプレゼンテーションを保存します。

この C# コードは、系列カテゴリの色を変更する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];
	
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **系列名を変更**

デフォルトでは、チャートの凡例名は、各列またはデータ行の上のセルの内容です。

私たちの例（サンプル画像）では、

* 列は *系列 1、系列 2、系列 3* です；
* 行は *カテゴリ 1、カテゴリ 2、カテゴリ 3、カテゴリ 4* です。

Aspose.Slides for .NET を使用すると、シリーズ名をチャートデータと凡例で更新または変更できます。

この C# コードは、チャートデータ `ChartDataWorkbook` の中で系列名を変更する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = "新しい名前";
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

この C# コードは、`Series` を通じて系列名を凡例で変更する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.ChartData.Series[0];
    
    IStringChartValue name = series.Name;
    name.AsCells[0].Value = "新しい名前";   
}
```

## **チャート系列の塗りつぶし色を設定**

Aspose.Slides for .NET を使用すると、プロットエリア内のチャート系列の自動塗りつぶし色を次のように設定できます。

1. `Presentation` クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. 希望のタイプに基づいてデフォルトデータを持つチャートを追加します（以下の例では、`ChartType.ClusteredColumn` を使用）。
1. チャート系列にアクセスし、塗りつぶし色を自動に設定します。
1. プレゼンテーションを PPTX ファイルに保存します。

この C# コードは、チャート系列の自動塗りつぶし色を設定する方法を示しています：

```c#
using (Presentation presentation = new Presentation())
{
    // クラスター化された列チャートを作成
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // 系列の塗りつぶし形式を自動に設定
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series[i].GetAutomaticSeriesColor();
    }

    // プレゼンテーションファイルをディスクに書き込みます
    presentation.Save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
}
```

## **チャート系列の塗りつぶし色を反転させる**
Aspose.Slides を使用すると、プロットエリア内のチャート系列の塗りつぶし色を反転させることができます。

1. `Presentation` クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. 希望のタイプに基づいてデフォルトデータを持つチャートを追加します（以下の例では、`ChartType.ClusteredColumn` を使用）。
1. チャート系列にアクセスし、塗りつぶし色を反転させます。
1. プレゼンテーションを PPTX ファイルに保存します。

この C# コードは、操作を示しています：

```c#
Color inverColor = Color.Red;
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 新しい系列とカテゴリを追加
    chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "系列 1"), chart.Type);
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "カテゴリ 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "カテゴリ 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "カテゴリ 3"));

    // 最初のチャート系列を取得し、系列データを設定
    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;
    pres.Save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);               
}
```

## **値が負のときに系列を反転させる**
Aspose.Slides を使用すると、`IChartDataPoint.InvertIfNegative` および `ChartDataPoint.InvertIfNegative` プロパティを使用して反転を設定できます。プロパティを使用して反転を設定すると、データポイントは負の値になったときにその色を反転させます。

この C# コードは、操作を示しています：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
	IChartSeriesCollection series = chart.ChartData.Series;
	chart.ChartData.Series.Clear();

	series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -2));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

	series[0].InvertIfNegative = false;

	series[0].DataPoints[2].InvertIfNegative = true;

	pres.Save("out.pptx", SaveFormat.Pptx);
}
```

## **特定のデータポイントのデータをクリア**
Aspose.Slides for .NET を使用すると、特定のチャート系列の `DataPoints` データを次のようにクリアできます。

1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. インデックスを使用してチャートの参照を取得します。
4. すべてのチャート `DataPoints` を反復処理し、`XValue` と `YValue` を null に設定します。
5. 特定のチャート系列のすべての `DataPoints` をクリアします。
6. 修正されたプレゼンテーションを PPTX ファイルに書き込みます。

この C# コードは、操作を示しています：

```c#
using (Presentation pres = new Presentation("TestChart.pptx"))
{
	ISlide sl = pres.Slides[0];

	IChart chart = (IChart)sl.Shapes[0];

	foreach (IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
	{
		dataPoint.XValue.AsCell.Value = null;
		dataPoint.YValue.AsCell.Value = null;
	}

	chart.ChartData.Series[0].DataPoints.Clear();

	pres.Save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
}
```

## **系列のギャップ幅を設定**
Aspose.Slides for .NET を使用すると、**`GapWidth`** プロパティを通じて系列のギャップ幅を設定できます。

1. `Presentation` クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. デフォルトデータを持つチャートを追加します。
4. 任意のチャート系列にアクセスします。
5. `GapWidth` プロパティを設定します。
6. 修正されたプレゼンテーションを PPTX ファイルに保存します。

この C# コードは、系列のギャップ幅を設定する方法を示しています：

```c#
// 空のプレゼンテーションを作成 
Presentation presentation = new Presentation();

// プレゼンテーションの最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// デフォルトデータを持つチャートを追加
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 0, 0, 500, 500);

// チャートデータシートのインデックスを設定
int defaultWorksheetIndex = 0;

// チャートデータワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.Type);

// カテゴリを追加
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "カテゴリ 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "カテゴリ 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "カテゴリ 3"));

// 2 番目のチャート系列を取得
IChartSeries series = chart.ChartData.Series[1];

// 系列データを設定
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// ギャップ幅の値を設定
series.ParentSeriesGroup.GapWidth = 50;

// プレゼンテーションをディスクに保存
presentation.Save("GapWidth_out.pptx", SaveFormat.Pptx);
```