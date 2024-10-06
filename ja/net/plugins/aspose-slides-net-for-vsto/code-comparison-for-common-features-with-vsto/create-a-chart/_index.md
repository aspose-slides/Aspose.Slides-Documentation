---
title: チャートを作成する
type: docs
weight: 60
url: /ja/net/create-a-chart/
---

以下のコード例は、VSTOを使用してシンプルな3Dクラスター化カラムチャートを追加するプロセスを説明しています。プレゼンテーションのインスタンスを作成し、デフォルトのチャートを追加します。次に、Microsoft Excelワークブックを使用してチャートデータにアクセスし、チャートプロパティを設定します。最後に、プレゼンテーションを保存します。
## **VSTO**
VSTOを使用して、以下の手順が実行されます。

1. Microsoft PowerPointプレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空のスライドを追加します。
1. 3Dクラスター化カラムチャートを追加し、それにアクセスします。
1. チャートデータを読み込むために新しいMicrosoft Excelワークブックのインスタンスを作成します。
1. ワークブックからMicrosoft Excelワークブックのインスタンスを使用してチャートデータワークシートにアクセスします。
1. ワークシート内のチャート範囲を設定し、チャートからシリーズ2と3を削除します。
1. チャートデータワークシート内のチャートカテゴリデータを修正します。
1. チャートデータワークシート内のチャートシリーズ1データを修正します。
1. その後、チャートタイトルにアクセスし、フォント関連のプロパティを設定します。
1. チャート値軸にアクセスし、主要単位、小単位、最大値、最小値を設定します。
1. チャートの深さまたは系列軸にアクセスし、この例では1つの系列のみが使用されているため、それを削除します。
1. その後、XおよびY方向のチャート回転角度を設定します。
1. プレゼンテーションを保存します。
1. Microsoft ExcelとPowerPointのインスタンスを閉じます。

``` csharp

 //グローバル変数

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//スライドオブジェクトをインスタンス化

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//プレゼンテーションの最初のスライドにアクセス

	objSlide = objPres.Slides[1];

	//最初のスライドを選択し、そのレイアウトを設定

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//スライドにデフォルトチャートを追加

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//追加されたチャートにアクセス

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//チャートデータにアクセス

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//チャートデータで作業するためのExcelワークブックのインスタンスを作成

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//チャートのためのデータワークシートにアクセス

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//チャートの範囲を設定

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//設定した範囲をチャートデータテーブルに適用

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//カテゴリおよびそれぞれのシリーズデータの値を設定

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

	ppChart.ChartTitle.Text = "2007年の売上";

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

	//チャートの深さ軸にアクセス

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//チャート回転を設定

	ppChart.Rotation = 20; //Y値

	ppChart.Elevation = 15; //X値

	ppChart.RightAngleAxes = false;

	// プレゼンテーションをPPTXとして保存

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//ワークブックとプレゼンテーションを閉じる

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//補足メソッド

public static void StartPowerPoint()

{

	objPPT = new Microsoft.Office.Interop.PowerPoint.Application();

	objPPT.Visible = MsoTriState.msoTrue;

	//  objPPT.WindowState = PowerPoint.PpWindowState.ppWindowMaximized

}

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

	//名前プロパティにアクセスを試みます。例外が発生した場合

	//新しいインスタンスのPowerPointを開始します

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentationは、プレゼンテーションが読み込まれていることを保証するために使用されます

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

	//BlnAddSlideは、プレゼンテーションに少なくとも1つのスライドがあることを保証するために使用されます

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
## **Aspose.Slides**
Aspose.Slides for .NETを使用して、以下の手順が実行されます。

1. Microsoft PowerPointプレゼンテーションのインスタンスを作成します。
1. プレゼンテーションに空のスライドを追加します。
1. 3Dクラスター化カラムチャートを追加し、それにアクセスします。
1. ワークブックからMicrosoft Excelワークブックのインスタンスを使用してチャートデータワークシートにアクセスします。
1. 使用していないシリーズ2と3を削除します。
1. チャートカテゴリにアクセスし、ラベルを修正します。
1. シリーズ1にアクセスし、シリーズの値を修正します。
1. その後、チャートタイトルにアクセスし、フォントプロパティを設定します。
1. チャート値軸にアクセスし、主要単位、小単位、最大値、最小値を設定します。
1. その後、XおよびY方向のチャート回転角度を設定します。
1. プレゼンテーションをPPTX形式で保存します。

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//空のプレゼンテーションを作成

	using (PresentationEx pres = new PresentationEx())

	{

		//最初のスライドにアクセス

		SlideEx slide = pres.Slides[0];

		//デフォルトチャートを追加

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//チャートデータを取得

		ChartDataEx chartData = ppChart.ChartData;

		//余分なデフォルトシリーズを削除

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//チャートカテゴリ名を修正

		chartData.Categories[0].ChartDataCell.Value = "自転車";

		chartData.Categories[1].ChartDataCell.Value = "アクセサリ";

		chartData.Categories[2].ChartDataCell.Value = "修理";

		chartData.Categories[3].ChartDataCell.Value = "衣類";

		//最初のカテゴリのチャートシリーズ値を修正

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//チャートタイトルを設定

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007年の売上";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//軸の値を設定

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//チャート回転を設定

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//プレゼンテーションを保存

		pres.Write("AsposeSampleChart.pptx");

	}

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772948)
- [Github](https://github.com/asposemarketplace/Aspose_for_VSTO/releases/download/3/Create.a.Chart.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20Chart%20\(Aspose.Slides\).zip)