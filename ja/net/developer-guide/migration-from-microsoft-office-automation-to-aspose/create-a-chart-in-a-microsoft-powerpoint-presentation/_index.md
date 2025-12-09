---
title: VSTO と Aspose.Slides for .NET を使用してチャートを作成する
linktitle: チャートを作成
type: docs
weight: 80
url: /ja/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- チャート作成
- 移行
- VSTO
- Office 自動化
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "C# で PowerPoint のチャート作成を自動化する方法を学びます。このステップバイステップ ガイドでは、Aspose.Slides for .NET が Microsoft.Office.Interop よりも高速で、より強力な代替手段である理由を示します。"
---

## **概要**

この記事では、C# を使用して Microsoft PowerPoint プレゼンテーション内にチャートをプログラムで作成およびカスタマイズする方法を示します。Aspose.Slides for .NET を利用すれば、Microsoft Office や Interop ライブラリに依存せずに、プロフェッショナルでデータ駆動型のチャートを自動生成できます。API は、縦棒グラフ、円グラフ、折れ線グラフなど多数のチャートタイプを提供し、外観、データ、レイアウトをフルコントロールできます。レポート、ダッシュボード、ビジネスプレゼンテーションの作成において、.NET アプリケーションから直接高品質な可視化を提供できます。

## **VSTO の例**

このセクションでは、**VSTO (Visual Studio Tools for Office)** を使用して Microsoft PowerPoint プレゼンテーションにチャートを作成する方法を示します。VSTO を利用すれば、PowerPoint と Excel の自動化を組み合わせて、プログラムからチャートを生成・カスタマイズできます。以下の例では、**3D クラスタ化縦棒グラフ** を追加し、Excel ワークシートからデータを取得し、書式設定とレイアウトを調整し、最終的なプレゼンテーションを保存する手順を示します。

1. Microsoft PowerPoint プレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白スライドを追加します。
1. 3D クラスタ化縦棒グラフを追加し、アクセスします。
1. 新しい Microsoft Excel ブックのインスタンスを作成し、チャート データをロードします。
1. Excel ブック インスタンスを使用してチャート データ ワークシートにアクセスします。
1. ワークシートでチャート範囲を設定し、シリーズ 2 と 3 をチャートから削除します。
1. チャート データ ワークシートでカテゴリ データを変更します。
1. チャート データ ワークシートでシリーズ 1 のデータを変更します。
1. チャート タイトルにアクセスし、フォント関連プロパティを設定します。
1. チャートの値軸にアクセスし、主単位、補助単位、最大値、最小値を設定します。
1. チャートの深さ (系列) 軸にアクセスし、削除します—この例では 1 系列のみ使用します。
1. X 軸と Y 軸の回転角度を設定します。
1. プレゼンテーションを保存します。
1. Microsoft Excel と PowerPoint のインスタンスを閉じます。
```c#
EnsurePowerPointIsRunning(true, true);

// スライドオブジェクトをインスタンス化します。
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// プレゼンテーションの最初のスライドにアクセスします。
objSlide = objPres.Slides[1];

// 最初のスライドを選択し、レイアウトを設定します。
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// スライドに既定のチャートを追加します。
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// 追加されたチャートにアクセスします。
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// チャートデータにアクセスします。
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// チャートデータを操作するために Excel ブックのインスタンスを作成します。
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// チャート用のデータワークシートにアクセスします。
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// チャートのデータ範囲を設定します。
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// 指定した範囲をチャートデータテーブルに適用します。
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// カテゴリと各系列データの値を設定します。
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// チャートのタイトルを設定します。
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// チャートの値軸にアクセスします。
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// 軸の単位値を設定します。
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// チャートの奥行き軸にアクセスします。
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// チャートの回転を設定します。
ppChart.Rotation = 20;   // Y 値
ppChart.Elevation = 15;  // X 値
ppChart.RightAngleAxes = false;

// プレゼンテーションを PPTX ファイルとして保存します。
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// ブックとプレゼンテーションを閉じます。
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Name プロパティにアクセスしてみます。例外がスローされた場合は、PowerPoint の新しいインスタンスを開始します。
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation はプレゼンテーションがロードされていることを保証するために使用されます。
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide はプレゼンテーションに少なくとも1枚のスライドがあることを保証するために使用されます。
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```


結果:

![VSTO を使用して作成したチャート](chart-created-using-VSTO.png)

## **Aspose.Slides for .NET の例**

以下の例は、Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションにシンプルなチャートを作成する方法を示します。このコードは、**3D クラスタ化縦棒グラフ** を追加し、サンプル データで埋め込み、外観をカスタマイズする手順を示しています。数行のコードで動的にチャートを生成し、Microsoft Office を使用せずにプレゼンテーションに組み込むことができます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. 最初のスライドへの参照を取得します。
1. 3D クラスタ化縦棒グラフを追加し、アクセスします。
1. チャート データにアクセスします。
1. 未使用の Series 2 と Series 3 を削除します。
1. ラベルを更新してチャート カテゴリを変更します。
1. Series 1 の値を更新します。
1. チャート タイトルにアクセスし、フォント プロパティを設定します。
1. 主単位、補助単位、最大値、最小値を含む値軸を構成します。
1. X 軸と Y 軸の回転角度を設定します。
1. プレゼンテーションを PPTX 形式で保存します。
```cs
// 空のプレゼンテーションを作成します。
using (Presentation presentation = new Presentation())
{
    // 最初のスライドにアクセスします。
    ISlide slide = presentation.Slides[0];

    // デフォルトのチャートを追加します。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // チャートデータを取得します。
    IChartData chartData = chart.ChartData;

    // 余分なデフォルト系列を削除します。
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // チャートのカテゴリ名を変更します。
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // チャートデータのワークシートインデックスを設定します。
    int worksheetIndex = 0;

    // チャートデータのワークブックを取得します。
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // チャート系列の値を変更します。
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // チャートのタイトルを設定します。
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // 軸オプションを設定します。
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // チャートの回転を設定します。
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // プレゼンテーションを PPTX ファイルとして保存します。
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```


結果:

![Aspose.Slides for .NET を使用して作成したチャート](chart-created-using-aspose-slides.png)

## **FAQ**

**Aspose.Slides で円グラフ、折れ線グラフ、棒グラフなど他のタイプのチャートを作成できますか？**

はい。Aspose.Slides for .NET は、円グラフ、折れ線グラフ、棒グラフ、散布図、バブルチャートなど多数の[チャート タイプ](https://docs.aspose.com/slides/net/create-chart/)をサポートしています。チャートを追加する際に[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列挙体で目的のタイプを指定できます。

**チャートにカスタム スタイルやテーマを適用できますか？**

はい。色、フォント、塗りつぶし、輪郭、グリッドライン、レイアウトなど、チャートの外観を自由にカスタマイズできます。ただし、PowerPoint の Office テーマを完全に再現するには、個々のスタイルを手動で設定する必要があります。

**スライドとは別にチャートを画像としてエクスポートできますか？**

はい。Aspose.Slides を使用すると、チャートを含む任意のシェイプを `GetImage` メソッドで PNG や JPEG などの画像として個別にエクスポートできます。