---
title: 차트 만들기
type: docs
weight: 60
url: /ko/net/create-a-chart/
---
다음 코드 예제는 VSTO를 사용하여 간단한 3D 클러스터형 열 차트를 추가하는 과정을 설명합니다. 프레젠테이션 인스턴스를 생성하고 기본 차트를 추가합니다. 그런 다음 Microsoft Excel 워크북을 사용하여 차트 데이터를 액세스하고 수정하며 차트 속성을 설정합니다. 마지막으로 프레젠테이션을 저장합니다.

## **VSTO**
Using VSTO, the following steps are performed:

1. Microsoft PowerPoint 프레젠테이션 인스턴스를 생성합니다.
1. 프레젠테이션에 빈 슬라이드를 추가합니다.
1. 3D 클러스터형 열 차트를 추가하고 접근합니다.
1. 새 Microsoft Excel Workbook 인스턴스를 생성하고 차트 데이터를 로드합니다.
1. Workbook에서 Microsoft Excel Workbook 인스턴스를 사용하여 차트 데이터 워크시트에 접근합니다.
1. 워크시트에서 차트 범위를 설정하고 차트에서 시리즈 2와 3을 제거합니다.
1. 차트 데이터 워크시트에서 차트 카테고리 데이터를 수정합니다.
1. 차트 데이터 워크시트에서 차트 시리즈 1 데이터를 수정합니다.
1. 이제 차트 제목에 접근하고 글꼴 관련 속성을 설정합니다.
1. 차트 값 축에 접근하고 주요 단위, 보조 단위, 최대값 및 최소값을 설정합니다.
1. 차트 깊이(또는 시리즈 축)에 접근하고, 이 예제에서는 하나의 시리즈만 사용하므로 해당 축을 제거합니다.
1. 이제 X와 Y 방향으로 차트 회전 각도를 설정합니다.
1. 프레젠테이션을 저장합니다.
1. Microsoft Excel 및 PowerPoint 인스턴스를 닫습니다.

``` csharp

 //전역 변수

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//슬라이드 객체 인스턴스화

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//프레젠테이션의 첫 번째 슬라이드에 접근

	objSlide = objPres.Slides[1];

	//첫 번째 슬라이드를 선택하고 레이아웃을 설정

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//슬라이드에 기본 차트를 추가

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//추가된 차트에 접근

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//차트 데이터에 접근

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//차트 데이터를 처리하기 위해 Excel 워크북 인스턴스 생성

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//차트를 위한 데이터 워크시트에 접근

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//차트 범위 설정

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//설정된 범위를 차트 데이터 테이블에 적용

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//카테고리와 해당 시리즈 데이터 값 설정

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//차트 제목 설정

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//차트 값 축에 접근

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//값 축 단위 설정

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//차트 깊이 축에 접근

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//차트 회전 설정

	ppChart.Rotation = 20; //Y-값

	ppChart.Elevation = 15; //X-값

	ppChart.RightAngleAxes = false;

	// 프레젠테이션을 PPTX 형식으로 저장

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//워크북과 프레젠테이션 닫기

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//보조 메서드

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

	//이름 속성에 접근을 시도합니다. 예외가 발생하면

	//PowerPoint 새 인스턴스를 시작합니다

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation은 프레젠테이션이 로드되어 있는지를 보장하기 위해 사용됩니다

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

	//BlnAddSlide는 프레젠테이션에 최소 하나의 슬라이드가 있는지를 보장하기 위해 사용됩니다

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
Using Aspose.Slides for .NET, the following steps are performed:

1. Microsoft PowerPoint 프레젠테이션 인스턴스를 생성합니다.
1. 프레젠테이션에 빈 슬라이드를 추가합니다.
1. 3D 클러스터형 열 차트를 추가하고 접근합니다.
1. Workbook에서 Microsoft Excel Workbook 인스턴스를 사용하여 차트 데이터 워크시트를 접근합니다.
1. 사용되지 않는 시리즈 2와 3을 제거합니다.
1. 차트 카테고리에 접근하고 레이블을 수정합니다.
1. 시리즈 1에 접근하고 시리즈 값을 수정합니다.
1. 이제 차트 제목에 접근하고 글꼴 속성을 설정합니다.
1. 차트 값 축에 접근하고 주요 단위, 보조 단위, 최대값 및 최소값을 설정합니다.
1. 이제 X와 Y 방향으로 차트 회전 각도를 설정합니다.
1. 프레젠테이션을 PPTX 형식으로 저장합니다.

``` csharp

 public static void GEN_ASPOSE_Chart()
{
	//빈 프레젠테이션 생성
	using (PresentationEx pres = new PresentationEx())
	{
		//첫 번째 슬라이드에 접근
		SlideEx slide = pres.Slides[0];
		//기본 차트 추가
		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);
		//차트 데이터 가져오기
		ChartDataEx chartData = ppChart.ChartData;
		//여분의 기본 시리즈 제거
		chartData.Series.RemoveAt(1);
		chartData.Series.RemoveAt(1);
		//차트 카테고리 이름 수정
		chartData.Categories[0].ChartDataCell.Value = "Bikes";
		chartData.Categories[1].ChartDataCell.Value = "Accessories";
		chartData.Categories[2].ChartDataCell.Value = "Repairs";
		chartData.Categories[3].ChartDataCell.Value = "Clothing";
		//첫 번째 카테고리에 대한 차트 시리즈 값 수정
		chartData.Series[0].Values[0].Value = 1000;
		chartData.Series[0].Values[1].Value = 2500;
		chartData.Series[0].Values[2].Value = 4000;
		chartData.Series[0].Values[3].Value = 3000;
		//차트 제목 설정
		ppChart.HasTitle = true;
		ppChart.ChartTitle.Text.Text = "2007 Sales";
		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;
		format.FontItalic = NullableBool.True;
		format.FontHeight = 18;
		format.FillFormat.FillType = FillTypeEx.Solid;
		format.FillFormat.SolidFillColor.Color = Color.Black;


		//축 값 설정
		ppChart.ValueAxis.IsAutomaticMaxValue = false;
		ppChart.ValueAxis.IsAutomaticMinValue = false;
		ppChart.ValueAxis.IsAutomaticMajorUnit = false;
		ppChart.ValueAxis.IsAutomaticMinorUnit = false;
		ppChart.ValueAxis.MaxValue = 4000.0F;
		ppChart.ValueAxis.MinValue = 0.0F;
		ppChart.ValueAxis.MajorUnit = 2000.0F;
		ppChart.ValueAxis.MinorUnit = 1000.0F;
		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;
		//차트 회전 설정
		ppChart.Rotation3D.RotationX = 15;
		ppChart.Rotation3D.RotationY = 20;
		//프레젠테이션 저장
		pres.Write("AsposeSampleChart.pptx");
	}
}
``` 
## **샘플 코드 다운로드**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)