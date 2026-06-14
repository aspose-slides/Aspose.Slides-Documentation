---
title: Tạo và Nhúng Biểu Đồ Excel dưới Dạng Đối Tượng OLE
type: docs
weight: 70
url: /vi/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
Hai ví dụ mã bên dưới dài và chi tiết vì nhiệm vụ mà chúng mô tả khá phức tạp. Bạn tạo một workbook Microsoft Excel, tạo một biểu đồ và sau đó tạo bản trình bày Microsoft PowerPoint mà bạn sẽ nhúng biểu đồ vào. Các đối tượng OLE chứa liên kết đến tài liệu gốc, vì vậy người dùng nhấp đúp vào tệp nhúng sẽ mở tệp và ứng dụng của nó.

## **VSTO**
Sử dụng VSTO, các bước sau được thực hiện:

1. Tạo một thể hiện của đối tượng Microsoft Excel ApplicationClass.
1. Tạo một workbook mới với một sheet trong đó.
1. Thêm biểu đồ vào sheet.
1. Lưu workbook.
1. Mở workbook Excel chứa worksheet có dữ liệu biểu đồ.
1. Lấy bộ sưu tập ChartObjects cho sheet.
1. Lấy biểu đồ để sao chép.
1. Tạo một bản trình bày Microsoft PowerPoint.
1. Thêm một slide trống vào bản trình bày.
1. Sao chép biểu đồ từ worksheet Excel vào clipboard.
1. Dán biểu đồ vào bản trình bày PowerPoint.
1. Định vị biểu đồ trên slide.
1. Lưu bản trình bày.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Khai báo một biến cho thể hiện của Excel ApplicationClass instance.
	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Khai báo các biến cho các tham số của phương thức Workbooks.Open method parameters.
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Khai báo các biến cho phương thức Chart.ChartWizard method.
	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Tạo một thể hiện của đối tượng Excel ApplicationClass object.
	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Tạo một workbook mới với 1 sheet trong đó.
		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Đổi tên của sheet.
		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// Chèn một số dữ liệu cho biểu đồ vào sheet.
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

		// Lấy phạm vi chứa dữ liệu biểu đồ.
		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Lấy bộ sưu tập ChartObjects cho sheet.
		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Thêm một Chart vào bộ sưu tập.
		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// Tạo một biểu đồ mới từ dữ liệu.
		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Lưu workbook.
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

			// Đóng Excel.
			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Khai báo các biến để giữ tham chiếu tới các đối tượng PowerPoint objects.
	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Khai báo các biến để giữ tham chiếu tới các đối tượng Excel objects.
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

		// Tạo một thể hiện của PowerPoint.
		powerpointApplication =new pptNS.Application();

		// Tạo một thể hiện của Excel.
		excelApplication = new xlNS.Application();

		// Mở workbook Excel chứa worksheet với dữ liệu biểu đồ.
		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Lấy worksheet chứa biểu đồ.
		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// Lấy bộ sưu tập ChartObjects cho sheet.
		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Lấy biểu đồ để sao chép.
		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// Tạo một bản trình bày PowerPoint.
		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Thêm một slide trống vào bản trình bày.
		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Sao chép biểu đồ từ worksheet Excel vào clipboard.
		existingChartObject.Copy();

		// Dán biểu đồ vào bản trình bày PowerPoint.
		shapeRange = pptSlide.Shapes.Paste();

		// Định vị biểu đồ trên slide.
		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Lưu bản trình bày.
		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Giải phóng đối tượng slide PowerPoint.
		shapeRange = null;

		pptSlide = null;

		// Đóng và giải phóng đối tượng Presentation object.
		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Thoát PowerPoint và giải phóng đối tượng ApplicationClass object.
		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Giải phóng các đối tượng Excel.
		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Đóng và giải phóng đối tượng Workbook Excel.
		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Thoát Excel và giải phóng đối tượng ApplicationClass object.
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
Sử dụng Aspose.Slides cho .NET, các bước sau được thực hiện:

1. Tạo một workbook bằng Aspose.Cells cho .NET.
1. Tạo một biểu đồ Microsoft Excel.
1. Đặt kích thước OLE cho biểu đồ Excel.
1. Lấy hình ảnh của biểu đồ.
1. Nhúng biểu đồ Excel dưới dạng OLE Object vào bản trình bày PPTX bằng Aspose.Slides cho .NET.
1. Thay thế hình ảnh đối tượng đã thay đổi bằng hình ảnh thu được ở bước 3 để giải quyết vấn đề đối tượng thay đổi.
1. Ghi bản trình bày đầu ra ra đĩa ở định dạng PPTX.

``` csharp

 static void Main(string[] args)

{

	//Tạo một workbook
	Workbook wb = new Workbook();

	//Thêm một biểu đồ excel
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Lưu workbook vào stream
	MemoryStream wbStream = wb.SaveToStream();

	//Tạo một bản trình chiếu
	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	//Thêm workbook vào slide
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Ghi bản trình chiếu đầu ra ra đĩa
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Thêm một worksheet mới để điền dữ liệu vào các ô
	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "DataSheet";

	dataSheet.Name = sheetName;

	//Điền dữ liệu vào DataSheet
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

	//Thêm một sheet biểu đồ
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "ChartSheet";

	//Thêm một biểu đồ vào ChartSheet với chuỗi dữ liệu từ DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Đặt tiêu đề cho biểu đồ
	chart.Title.Text = "Sales by Quarter";

	//Đặt màu nền phía trước của vùng vẽ
	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Đặt màu nền của vùng vẽ
	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Đặt màu nền phía trước cho vùng biểu đồ
	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Đặt tiêu đề cho trục danh mục của biểu đồ
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//Đặt tiêu đề cho trục giá trị của biểu đồ
	chart.ValueAxis.Title.Text = "Billions";

	//Đặt ChartSheet làm sheet hoạt động
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
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)