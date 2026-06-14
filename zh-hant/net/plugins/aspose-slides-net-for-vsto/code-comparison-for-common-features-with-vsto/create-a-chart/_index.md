---
title: 建立圖表
type: docs
weight: 60
url: /zh-hant/net/create-a-chart/
---
以下的程式碼範例說明了使用 VSTO 新增簡易 3D 群組直條圖的流程。您會建立 PowerPoint 簡報實例，向其中新增預設圖表，接著使用 Microsoft Excel 工作簿存取並修改圖表資料，同時設定圖表屬性。最後，儲存簡報。
## **VSTO**
使用 VSTO，執行以下步驟：

1. 建立 Microsoft PowerPoint 簡報的實例。
1. 向簡報新增空白投影片。
1. 新增 3D 群組直條圖並存取它。
1. 建立新的 Microsoft Excel Workbook 實例並載入圖表資料。
1. 使用 Microsoft Excel Workbook 實例從工作簿存取圖表資料工作表。
1. 在工作表中設定圖表範圍，並從圖表中移除第 2 與第 3 系列。
1. 在圖表資料工作表中修改圖表類別資料。
1. 在圖表資料工作表中修改圖表第 1 系列的資料。
1. 取得圖表標題並設定字型相關屬性。
1. 取得圖表值軸，設定主單位、次單位、最大值與最小值。
1. 取得圖表深度或系列軸，將其移除（此範例僅使用一個系列）。
1. 設定圖表在 X 與 Y 方向的旋轉角度。
1. 儲存簡報。
1. 關閉 Microsoft Excel 與 PowerPoint 的實例。

``` csharp

 //全域變數

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//實例化投影片物件

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//存取簡報的第一張投影片

	objSlide = objPres.Slides[1];

	//選取第一張投影片並設定其版面配置

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//在投影片中新增預設圖表

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//存取新增的圖表

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//存取圖表資料

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//建立 Excel 工作簿實例以處理圖表資料

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//存取圖表的資料工作表

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//設定圖表的範圍

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//在圖表資料表套用設定的範圍

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//設定類別及對應系列資料的值

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//設定圖表標題

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//存取圖表值軸

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//設定值軸單位

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//存取圖表深度軸

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//設定圖表旋轉

	ppChart.Rotation = 20; //Y 軸值
	ppChart.Elevation = 15; //X 軸值
	ppChart.RightAngleAxes = false;

	// 將簡報儲存為 PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//關閉工作簿與簡報

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//Supplementary methods

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

	//嘗試存取名稱屬性。如果導致例外則
	//啟動新的 PowerPoint 實例
	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation 用於確保已載入簡報

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

	//BlnAddSlide 用於確保簡報中至少有一張投影片
	//簡報
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
使用 Aspose.Slides for .NET，執行以下步驟：

1. 建立 Microsoft PowerPoint 簡報的實例。
1. 向簡報新增空白投影片。
1. 新增 3D 群組直條圖並存取它。
1. 使用 Microsoft Excel Workbook 實例從工作簿存取圖表資料工作表。
1. 移除未使用的第 2 與第 3 系列。
1. 取得圖表類別並修改標籤。
1. 取得第 1 系列並修改系列值。
1. 取得圖表標題並設定字型屬性。
1. 取得圖表值軸，設定主單位、次單位、最大值與最小值。
1. 設定圖表在 X 與 Y 方向的旋轉角度。
1. 將簡報儲存為 PPTX 格式。

``` csharp

 public static void GEN_ASPOSE_Chart()
{
	//建立空白簡報
	using (PresentationEx pres = new PresentationEx())
	{
		//存取第一張投影片
		SlideEx slide = pres.Slides[0];
		//新增預設圖表
		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);
		//取得圖表資料
		ChartDataEx chartData = ppChart.ChartData;
		//移除多餘的預設系列
		chartData.Series.RemoveAt(1);
		chartData.Series.RemoveAt(1);
		//修改圖表類別名稱
		chartData.Categories[0].ChartDataCell.Value = "Bikes";
		chartData.Categories[1].ChartDataCell.Value = "Accessories";
		chartData.Categories[2].ChartDataCell.Value = "Repairs";
		chartData.Categories[3].ChartDataCell.Value = "Clothing";
		//修改第一類別的圖表系列值
		chartData.Series[0].Values[0].Value = 1000;
		chartData.Series[0].Values[1].Value = 2500;
		chartData.Series[0].Values[2].Value = 4000;
		chartData.Series[0].Values[3].Value = 3000;
		//設定圖表標題
		ppChart.HasTitle = true;
		ppChart.ChartTitle.Text.Text = "2007 Sales";
		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;
		format.FontItalic = NullableBool.True;
		format.FontHeight = 18;
		format.FillFormat.FillType = FillTypeEx.Solid;
		format.FillFormat.SolidFillColor.Color = Color.Black;

		//設定座標軸值
		ppChart.ValueAxis.IsAutomaticMaxValue = false;
		ppChart.ValueAxis.IsAutomaticMinValue = false;
		ppChart.ValueAxis.IsAutomaticMajorUnit = false;
		ppChart.ValueAxis.IsAutomaticMinorUnit = false;
		ppChart.ValueAxis.MaxValue = 4000.0F;
		ppChart.ValueAxis.MinValue = 0.0F;
		ppChart.ValueAxis.MajorUnit = 2000.0F;
		ppChart.ValueAxis.MinorUnit = 1000.0F;
		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;
		//設定圖表旋轉
		ppChart.Rotation3D.RotationX = 15;
		ppChart.Rotation3D.RotationY = 20;
		//儲存簡報
		pres.Write("AsposeSampleChart.pptx");
	}
}
``` 
## **下載範例程式碼**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)