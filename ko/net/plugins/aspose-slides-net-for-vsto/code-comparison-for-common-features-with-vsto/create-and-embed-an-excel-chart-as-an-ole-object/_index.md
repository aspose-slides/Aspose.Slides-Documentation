---
title: Excel 차트를 OLE 객체로 만들고 삽입하기
type: docs
weight: 70
url: /ko/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
아래 두 개의 코드 예시는 작업이 복잡하기 때문에 길고 자세합니다. Microsoft Excel 통합 문서를 만들고 차트를 만든 다음 차트를 삽입할 Microsoft PowerPoint 프레젠테이션을 생성합니다. OLE 개체는 원본 문서에 대한 링크를 포함하므로 사용자가 삽입된 파일을 더블 클릭하면 해당 파일과 응용 프로그램이 실행됩니다.
## **VSTO**
VSTO를 사용하여 다음 단계가 수행됩니다:

1. Microsoft Excel ApplicationClass 객체의 인스턴스를 생성합니다.
2. 시트가 하나 포함된 새 통합 문서를 생성합니다.
3. 시트에 차트를 추가합니다.
4. 통합 문서를 저장합니다.
5. 차트 데이터가 포함된 워크시트를 포함하는 Excel 통합 문서를 엽니다.
6. 시트에 대한 ChartObjects 컬렉션을 가져옵니다.
7. 복사할 차트를 가져옵니다.
8. Microsoft PowerPoint 프레젠테이션을 생성합니다.
9. 프레젠테이션에 빈 슬라이드를 추가합니다.
10. Excel 워크시트에서 차트를 클립보드로 복사합니다.
11. 차트를 PowerPoint 프레젠테이션에 붙여넣습니다.
12. 슬라이드에 차트를 배치합니다.
13. 프레젠테이션을 저장합니다.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Excel ApplicationClass 인스턴스를 위한 변수를 선언합니다.
	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();
	// Workbooks.Open 메서드 매개변수용 변수를 선언합니다.
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";
	object paramMissing = Type.Missing;
	// Chart.ChartWizard 메서드용 변수를 선언합니다.
	object paramChartFormat = 1;
	object paramCategoryLabels = 0;
	object paramSeriesLabels = 0;
	bool paramHasLegend = true;
	object paramTitle = "Sales by Quarter";
	object paramCategoryTitle = "Fiscal Quarter";
	object paramValueTitle = "Billions";

	try

	{

		// Excel ApplicationClass 객체의 인스턴스를 생성합니다.
	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();
		// 시트 1개가 포함된 새 워크북을 생성합니다.
		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);
		// 시트 이름을 변경합니다.
		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
		targetSheet.Name = "Quarterly Sales";
		// 시트에 차트용 데이터를 삽입합니다.
		//              A       B       C       D       E
		//     1                Q1      Q2      Q3      Q4
		//     2    N. America  1.5     2       1.5     2.5
		//     3    S. America  2       1.75    2       2
		//     4    Europe      2.25    2       2.5     2
		//     5    Asia        2.5     2.5     2       2.75
		SetCellValue(targetSheet, "A2", "N. America");
		SetCellValue(targetSheet, "A3", "S. America");
		SetCellValue(targetSheet, "A4", "Europe");
		SetCellValue(targetSheet, "A5", "Asia");
		SetCellValue(targetSheet, "B1", "Q1");
		SetCellValue(targetSheet, "B2", 1.5);
		SetCellValue(targetSheet, "B3", 2);
		SetCellValue(targetSheet, "B4", 2.25);
		SetCellValue(targetSheet, "B5", 2.5);
		SetCellValue(targetSheet, "C1", "Q2");
		SetCellValue(targetSheet, "C2", 2);
		SetCellValue(targetSheet, "C3", 1.75);
		SetCellValue(targetSheet, "C4", 2);
		SetCellValue(targetSheet, "C5", 2.5);
		SetCellValue(targetSheet, "D1", "Q3");
		SetCellValue(targetSheet, "D2", 1.5);
		SetCellValue(targetSheet, "D3", 2);
		SetCellValue(targetSheet, "D4", 2.5);
		SetCellValue(targetSheet, "D5", 2);
		SetCellValue(targetSheet, "E1", "Q4");
		SetCellValue(targetSheet, "E2", 2.5);
		SetCellValue(targetSheet, "E3", 2);
		SetCellValue(targetSheet, "E4", 2);
		SetCellValue(targetSheet, "E5", 2.75);
		// 차트 데이터를 포함하는 범위를 가져옵니다.
		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");
		// 시트에 대한 ChartObjects 컬렉션을 가져옵니다.
		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
		// 컬렉션에 차트를 추가합니다.
		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
		newChartObject.Name = "Sales Chart";
		// 데이터로 새로운 차트를 생성합니다.
		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);
		// 워크북을 저장합니다.
		newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
	finally
	{
		if (excelApplication != null)
		{
			// Excel을 종료합니다.
			excelApplication.Quit();
		}
	}
}

public void UseCopyPaste()
{
	// PowerPoint 객체에 대한 참조를 보유할 변수를 선언합니다.
	pptNS.Application powerpointApplication = null;
	pptNS.Presentation pptPresentation = null;
	pptNS.Slide pptSlide = null;
	pptNS.ShapeRange shapeRange = null;
	// Excel 객체에 대한 참조를 보유할 변수를 선언합니다.
	xlNS.Application excelApplication = null;
	xlNS.Workbook excelWorkBook = null;
	xlNS.Worksheet targetSheet = null;
	xlNS.ChartObjects chartObjects = null;
	xlNS.ChartObject existingChartObject = null;
	string paramPresentationPath = System.Windows.Forms.Application.StartupPath + @"\ChartTest.pptx";
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath + @"\ChartData.xlsx";
	object paramMissing = Type.Missing;

	try
	{
		// PowerPoint 인스턴스를 생성합니다.
		powerpointApplication =new pptNS.Application();
		// Excel 인스턴스를 생성합니다.
		excelApplication = new xlNS.Application();
		// 차트 데이터가 있는 워크시트를 포함하는 Excel 워크북을 엽니다.
		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing);
		// 차트를 포함하는 워크시트를 가져옵니다.
		targetSheet =
			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);
		// 시트에 대한 ChartObjects 컬렉션을 가져옵니다.
		chartObjects =
			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
		// 복사할 차트를 가져옵니다.
		existingChartObject =
			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));
		// PowerPoint 프레젠테이션을 생성합니다.
		pptPresentation =
			powerpointApplication.Presentations.Add(
			Microsoft.Office.Core.MsoTriState.msoTrue);
		// 프레젠테이션에 빈 슬라이드를 추가합니다.
		pptSlide =
			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);
		// Excel 워크시트에서 차트를 클립보드로 복사합니다.
		existingChartObject.Copy();
		// 차트를 PowerPoint 프레젠테이션에 붙여넣습니다.
		shapeRange = pptSlide.Shapes.Paste();
		// 슬라이드에 차트 위치를 지정합니다.
		shapeRange.Left = 60;
		shapeRange.Top = 100;
		// 프레젠테이션을 저장합니다.
		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
	finally
	{
		// PowerPoint 슬라이드 객체를 해제합니다.
		shapeRange = null;
		pptSlide = null;
		// Presentation 객체를 닫고 해제합니다.
		if (pptPresentation != null)
		{
			pptPresentation.Close();
			pptPresentation = null;
		}
		// PowerPoint를 종료하고 ApplicationClass 객체를 해제합니다.
		if (powerpointApplication != null)
		{
			powerpointApplication.Quit();
			powerpointApplication = null;
		}
		// Excel 객체들을 해제합니다.
		targetSheet = null;
		chartObjects = null;
		existingChartObject = null;
		// Excel Workbook 객체를 닫고 해제합니다.
		if (excelWorkBook != null)
		{
			excelWorkBook.Close(false, paramMissing, paramMissing);
			excelWorkBook = null;
		}
		// Excel을 종료하고 ApplicationClass 객체를 해제합니다.
		if (excelApplication != null)
		{
			excelApplication.Quit();
			excelApplication = null;
		}
		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
		GC.WaitForPendingFinalizers();
	}
}

private void ThisAddIn_Startup(object sender, System.EventArgs e)
{
	CreateNewChartInExcel();
	UseCopyPaste();
}
``` 
## **Aspose.Slides**
Aspose.Slides for .NET을 사용하여 다음 단계가 수행됩니다:

1. Aspose.Cells for .NET을 사용하여 통합 문서를 생성합니다.
2. Microsoft Excel 차트를 생성합니다.
3. Excel 차트의 OLE 크기를 설정합니다.
4. 차트의 이미지를 가져옵니다.
5. Aspose.Slides for .NET을 사용하여 Excel 차트를 PPTX 프레젠테이션 내부의 OLE 개체로 삽입합니다.
6. 객체가 변경된 문제를 해결하기 위해 단계 3에서 얻은 이미지로 객체 변경 이미지를 교체합니다.
7. 출력 프레젠테이션을 PPTX 형식으로 디스크에 저장합니다.

``` csharp

 static void Main(string[] args)

{

	// 워크북을 생성합니다
	Workbook wb = new Workbook();

	// Excel 차트를 추가합니다
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	// 워크북을 스트림에 저장합니다
	MemoryStream wbStream = wb.SaveToStream();

	// 프레젠테이션을 생성합니다
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];

	// 슬라이드에 워크북을 추가합니다
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	// 출력 프레젠테이션을 디스크에 씁니다
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	// 데이터를 채우기 위해 새 워크시트를 추가합니다
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;

	// DataSheet에 데이터를 채웁니다
	dataSheet.Cells["A2"].PutValue("N. America");
	dataSheet.Cells["A3"].PutValue("S. America");
	dataSheet.Cells["A4"].PutValue("Europe");
	dataSheet.Cells["A5"].PutValue("Asia");
	dataSheet.Cells["B1"].PutValue("Q1");
	dataSheet.Cells["B2"].PutValue(1.5);
	dataSheet.Cells["B3"].PutValue(2);
	dataSheet.Cells["B4"].PutValue(2.25);
	dataSheet.Cells["B5"].PutValue(2.5);
	dataSheet.Cells["C1"].PutValue("Q2");
	dataSheet.Cells["C2"].PutValue(2);
	dataSheet.Cells["C3"].PutValue(1.75);
	dataSheet.Cells["C4"].PutValue(2);
	dataSheet.Cells["C5"].PutValue(2.5);
	dataSheet.Cells["D1"].PutValue("Q3");
	dataSheet.Cells["D2"].PutValue(1.5);
	dataSheet.Cells["D3"].PutValue(2);
	dataSheet.Cells["D4"].PutValue(2.5);
	dataSheet.Cells["D5"].PutValue(2);
	dataSheet.Cells["E1"].PutValue("Q4");
	dataSheet.Cells["E2"].PutValue(2.5);
	dataSheet.Cells["E3"].PutValue(2);
	dataSheet.Cells["E4"].PutValue(2);
	dataSheet.Cells["E5"].PutValue(2.75);

	// 차트 시트를 추가합니다
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";

	// DataSheet의 데이터 시리즈를 사용하여 ChartSheet에 차트를 추가합니다
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);

	// 차트 제목 설정
	chart.Title.Text = "Sales by Quarter";

	// 플롯 영역의 전경색 설정
	chart.PlotArea.Area.ForegroundColor = Color.White;

	// 플롯 영역의 배경색 설정
	chart.PlotArea.Area.BackgroundColor = Color.White;

	// 차트 영역의 전경색 설정
	chart.ChartArea.Area.BackgroundColor = Color.White;
	chart.Title.TextFont.Size = 16;

	// 차트 카테고리 축 제목 설정
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	// 차트 값 축 제목 설정
	chart.ValueAxis.Title.Text = "Billions";

	// ChartSheet를 활성 시트로 설정합니다
	wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
	return chartSheetIdx;

}

private static void AddExcelChartInPresentation(PresentationEx pres, SlideEx sld, Stream wbStream, Bitmap imgChart)

{

	float oleWidth = pres.SlideSize.Size.Width;
	float oleHeight = pres.SlideSize.Size.Height;
	int x = 0;
	byte[] chartOleData = new byte[wbStream.Length];
	wbStream.Position = 0;
	wbStream.Read(chartOleData, 0, chartOleData.Length);
	OleObjectFrameEx oof = null;
	oof = sld.Shapes.AddOleObjectFrame(x, 0, oleWidth, oleHeight, "Excel.Sheet.8", chartOleData);
    using (MemoryStream imageStream = new MemoryStream())
    {
        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
        imageStream.Position = 0;
        IPPImage ppImage = pres.Images.AddImage(imageStream);
        oof.SubstitutePictureFormat.Picture.Image = ppImage;
    }

}
``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)