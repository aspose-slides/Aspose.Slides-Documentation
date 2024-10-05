---
title: Microsoft PowerPoint プレゼンテーションでのチャート作成
type: docs
weight: 80
url: /net/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

チャートは、プレゼンテーションで広く使用されるデータの視覚的表現です。この記事では、[VSTO](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) と [Aspose.Slides for .NET](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) を使用して、Microsoft PowerPoint 内でプログラム的にチャートを作成するためのコードを示します。

{{% /alert %}} 
## **チャートの作成**
以下のコード例では、VSTO を使用してシンプルな 3D クラスター コラム チャートを追加するプロセスを説明します。プレゼンテーションインスタンスを作成し、デフォルトのチャートを追加します。その後、Microsoft Excel ワークブックを使用して、チャートデータにアクセスし、チャートプロパティを設定します。最後に、プレゼンテーションを保存します。
## **VSTO の例**
VSTO を使用して、以下の手順を実行します。

1. Microsoft PowerPoint プレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. **3D クラスター コラム** チャートを追加し、それにアクセスします。
1. 新しい Microsoft Excel ワークブックインスタンスを作成し、チャートデータをロードします。
1. ワークブックから Microsoft Excel ワークブックインスタンスを使用してチャートデータワークシートにアクセスします。
1. ワークシート内のチャート範囲を設定し、チャートから系列 2 と 3 を削除します。
1. チャートデータワークシートでチャートカテゴリデータを変更します。
1. チャートデータワークシートでチャート系列 1 のデータを変更します。
1. 現在、チャートタイトルにアクセスし、フォント関連のプロパティを設定します。
1. チャート値軸にアクセスし、主要単位、補助単位、最大値、最小値を設定します。
1. チャートの深さまたは系列軸にアクセスし、この例では 1 つの系列のみが使用されるため、それを削除します。
1. 現在、X および Y 方向におけるチャートの回転角度を設定します。
1. プレゼンテーションを保存します。
1. Microsoft Excel および PowerPoint のインスタンスを閉じます。

**VSTOで作成された出力プレゼンテーション** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



```c#
EnsurePowerPointIsRunning(true, true);

//スライドオブジェクトのインスタンスを作成
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

//プレゼンテーションの最初のスライドにアクセス
objSlide = objPres.Slides[1];

//最初のスライドを選択し、そのレイアウトを設定
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

//スライドにデフォルトのチャートを追加
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

//追加したチャートにアクセス
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

//チャートデータにアクセス
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

//チャートデータを操作するための Excel ワークブックインスタンスを作成
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

//チャートのデータワークシートにアクセス
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

//チャートの範囲を設定
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

//チャートデータテーブルに範囲を適用
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

//カテゴリとそれに対応する系列データの値を設定

((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "自転車";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "アクセサリ";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "修理";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "衣類";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

//チャートタイトルを設定
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 年の売上";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

//チャート値軸にアクセス
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

//値軸の単位を設定
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

//チャート深さ軸にアクセス
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

//チャートの回転を設定
ppChart.Rotation = 20; //Y-値
ppChart.Elevation = 15; //X-値
ppChart.RightAngleAxes = false;

// プレゼンテーションを PPTX として保存
objPres.SaveAs("C:\\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
//objPres.SaveAs(@"..\..\..\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

//ワークブックとプレゼンテーションを閉じる
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
    //
    //名前プロパティにアクセスを試みます。例外が発生した場合は
    //新しいインスタンスの PowerPoint を起動します
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }
    //
    //blnAddPresentation は、プレゼンテーションが読み込まれていることを確認するために使用されます
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
    //
    //BlnAddSlide は、少なくとも 1 つのスライドが
    //プレゼンテーションにあることを確認するために使用されます
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




## **Aspose.Slides for .NET の例**
Aspose.Slides for .NET を使用して、以下の手順を実行します。

1. Microsoft PowerPoint プレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空白のスライドを追加します。
1. **3D クラスター コラム** チャートを追加し、それにアクセスします。
1. ワークブックから Microsoft Excel ワークブックインスタンスを使用してチャートデータワークシートにアクセスします。
1. 使用されていない系列 2 と 3 を削除します。
1. チャートカテゴリにアクセスし、ラベルを変更します。
1. 系列 1 にアクセスし、系列の値を変更します。
1. 現在、チャートタイトルにアクセスし、フォントプロパティを設定します。
1. チャート値軸にアクセスし、主要単位、補助単位、最大値、最小値を設定します。
1. 現在、X および Y 方向におけるチャートの回転角度を設定します。
1. プレゼンテーションを PPTX 形式で保存します。

**Aspose.Slides で作成された出力プレゼンテーション**

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

```csharp
//空のプレゼンテーションを作成
using (Presentation pres = new Presentation())
{

    //最初のスライドにアクセス
    ISlide slide = pres.Slides[0];

    //デフォルトチャートを追加
    IChart ppChart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20F, 30F, 400F, 300F);

    //チャートデータを取得
    IChartData chartData = ppChart.ChartData;

    //余分なデフォルトの系列を削除
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    //チャートカテゴリ名を変更
    chartData.Categories[0].AsCell.Value = "自転車";
    chartData.Categories[1].AsCell.Value = "アクセサリ";
    chartData.Categories[2].AsCell.Value = "修理";
    chartData.Categories[3].AsCell.Value = "衣類";

    //チャートデータシートのインデックスを設定
    int defaultWorksheetIndex = 0;


    //チャートデータワークシートを取得
    IChartDataWorkbook fact = ppChart.ChartData.ChartDataWorkbook;

    //最初のカテゴリのチャート系列値を変更
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, 3000));

    //チャートタイトルを設定
    ppChart.HasTitle = true;
    ppChart.ChartTitle.AddTextFrameForOverriding("2007 年の売上");
    IPortionFormat format = ppChart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;


    ////軸の値を設定
    ppChart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    ppChart.Axes.VerticalAxis.MaxValue = 4000.0F;
    ppChart.Axes.VerticalAxis.MinValue = 0.0F;
    ppChart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    ppChart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    ppChart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    //チャートの回転を設定
    ppChart.Rotation3D.RotationX = 15;
    ppChart.Rotation3D.RotationY = 20;

    //プレゼンテーションを保存
    pres.Save("AsposeSampleChart.pptx", SaveFormat.Pptx);
}
```



{{% alert color="primary" %}} 

## **リソース**
この記事で使用したプロジェクトとファイルは、私たちのウェブサイトからダウンロードできます：

- [VSTO 生成のプレゼンテーションをダウンロード](http://docs.aspose.com:8082/docs/download/attachments/87523560/VSTOSampleChart.pptx)。
- [Aspose.Slides によって生成されたサンプルチャートをダウンロード](http://docs.aspose.com:8082/docs/download/attachments/87523560/AsposeSampleChart.pptx)。

{{% /alert %}}