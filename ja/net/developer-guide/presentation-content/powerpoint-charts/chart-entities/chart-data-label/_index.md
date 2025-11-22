---
title: チャート データ ラベル
type: docs
url: /ja/net/chart-data-label/
keywords: "チャート データ ラベル,label 距離, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint のチャート データ ラベルと距離を設定する"
---

チャートのデータ ラベルは、チャートのデータ シリーズまたは個々のデータ ポイントに関する詳細を示します。読者はデータ シリーズをすばやく識別でき、チャートの理解もしやすくなります。

## **チャート データ ラベルのデータ精度を設定する**

この C# コードは、チャート データ ラベルのデータ 精度を設定する方法を示します。
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```


## **ラベルとしてパーセンテージを表示**

Aspose.Slides for .NET は、表示されるチャートにパーセンテージ ラベルを設定できます。この C# コードはその操作を示します。
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// チャートを含むプレゼンテーションを保存します
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```


## **チャート データ ラベルにパーセンテージ記号を設定**

この C# コードは、チャート データ ラベルにパーセンテージ記号を設定する方法を示します。
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();

// インデックスでスライドの参照を取得します
ISlide slide = presentation.Slides[0];

// スライドに PercentsStackedColumn チャートを作成します
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// NumberFormatLinkedToSource を false に設定します
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// チャート データ ワークシートを取得します
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// 新しい系列を追加します
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// 系列の塗りつぶし色を設定します
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// LabelFormat プロパティを設定します
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// 新しい系列を追加します
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// 塗りつぶしタイプと色を設定します
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// プレゼンテーションをディスクに保存します
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```


## **軸からラベルまでの距離を設定**

この C# コードは、軸からプロットされたチャートのカテゴリ 軸へのラベル距離を設定する方法を示します。
```c#
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();

// スライドの参照を取得します
ISlide sld = presentation.Slides[0];

// スライド上にチャートを作成します
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// 軸からラベルまでの距離を設定します
ch.Axes.HorizontalAxis.LabelOffset = 500;

// プレゼンテーションをディスクに保存します
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```


## **ラベル位置の調整**

軸に依存しないチャート（例えば円グラフ）を作成すると、チャートのデータ ラベルがエッジに近すぎることがあります。その場合、リーダー ラインが明確に表示されるようにデータ ラベルの位置を調整する必要があります。

この C# コードは、円グラフのラベル位置を調整する方法を示します。
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![円グラフ-調整ラベル](pie-chart-adjusted-label.png)

## **FAQ**

**密集したチャートでデータ ラベルが重なるのを防ぐには？**

自動ラベル配置、リーダー ライン、フォント サイズの削減を組み合わせます。必要に応じて一部のフィールド（例: カテゴリ）を非表示にするか、極端または重要なポイントのみにラベルを表示します。

**ゼロ、負、または空の値に対してのみラベルを無効にするには？**

ラベルを有効にする前にデータ ポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを適用します。

**PDF/画像にエクスポートするときにラベル スタイルを一貫させるには？**

フォント（ファミリ、サイズ）を明示的に設定し、レンダリング側でフォントが利用可能か確認してフォント フォールバックを防止します。