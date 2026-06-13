---
title: Excel चार्ट को OLE ऑब्जेक्ट के रूप में बनाएं और एम्बेड करें
type: docs
weight: 70
url: /hi/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
नीचे दिए गए दो कोड उदाहरण लंबे और विस्तृत हैं क्योंकि वे जिस कार्य का विवरण दे रहे हैं वह जटिल है। आप एक Microsoft Excel वर्कबुक बनाते हैं, एक चार्ट बनाते हैं और फिर Microsoft PowerPoint प्रस्तुति बनाते हैं जिसमें आप चार्ट को एम्बेड करेंगे। OLE ऑब्जेक्ट मूल दस्तावेज़ के लिंक रखते हैं इसलिए जो उपयोगकर्ता एम्बेडेड फ़ाइल पर डबल-क्लिक करता है वह फ़ाइल और उसके एप्लिकेशन को लॉन्च करेगा।

## **VSTO**
VSTO का उपयोग करके, निम्नलिखित चरण किए जाते हैं:

1. Microsoft Excel ApplicationClass ऑब्जेक्ट का एक उदाहरण बनाएं।
2. एक नई वर्कबुक बनाएँ जिसमें एक शीट हो।
3. शीट में एक चार्ट जोड़ें।
4. वर्कबुक को सहेजें।
5. चार्ट डेटा वाली वर्कशीट वाली Excel वर्कबुक खोलें।
6. शीट के लिए ChartObjects संग्रह प्राप्त करें।
7. कॉपी करने के लिए चार्ट प्राप्त करें।
8. Microsoft PowerPoint प्रस्तुति बनाएं।
9. प्रस्तुति में एक खाली स्लाइड जोड़ें।
10. Excel वर्कशीट से चार्ट को क्लिपबोर्ड पर कॉपी करें।
11. चार्ट को PowerPoint प्रस्तुति में पेस्ट करें।
12. स्लाइड पर चार्ट को स्थित करें।
13. प्रस्तुति को सहेजें।

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Excel ApplicationClass इंस्टेंस के लिए एक वैरिएबल घोषित करें।

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Workbooks.Open मेथड पैरामीटर के लिए वैरिएबल्स घोषित करें।

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Chart.ChartWizard मेथड के लिए वैरिएबल्स घोषित करें।

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Excel ApplicationClass ऑब्जेक्ट का एक इंस्टेंस बनाएं।

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// 1 शीट वाली नई वर्कबुक बनाएं।

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// शीट का नाम बदलें।

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// चार्ट के लिए शीट में कुछ डेटा डालें।

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

		// चार्ट डेटा रखता हुआ रेंज प्राप्त करें।

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// शीट के लिए ChartObjects कलेक्शन प्राप्त करें।

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// कलेक्शन में एक नया चार्ट जोड़ें।

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// डेटा से नया चार्ट बनाएं।

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// वर्कबुक को सेव करें।

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

			// Excel को बंद करें।

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// PowerPoint ऑब्जेक्ट्स के रेफ़रेंस रखने के लिए वैरिएबल्स घोषित करें।

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Excel ऑब्जेक्ट्स के रेफ़रेंस रखने के लिए वैरिएबल्स घोषित करें।

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

		// PowerPoint का एक इंस्टेंस बनाएं।

		powerpointApplication =new pptNS.Application();

		// Excel का एक इंस्टेंस बनाएं।

		excelApplication = new xlNS.Application();

		// चार्ट डेटा वाली वर्कशीट वाली Excel वर्कबुक खोलें।

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// वह वर्कशीट प्राप्त करें जिसमें चार्ट है।

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// शीट के लिए ChartObjects कलेक्शन प्राप्त करें।

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// कॉपी करने के लिए चार्ट प्राप्त करें।

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// एक PowerPoint प्रस्तुति बनाएं।

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// प्रस्तुति में एक खाली स्लाइड जोड़ें।

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// चार्ट को Excel वर्कशीट से क्लिपबोर्ड पर कॉपी करें।

		existingChartObject.Copy();

		// चार्ट को PowerPoint प्रस्तुति में पेस्ट करें।

		shapeRange = pptSlide.Shapes.Paste();

		// स्लाइड पर चार्ट की स्थिति निर्धारित करें।

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// प्रस्तुति को सेव करें।

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// PowerPoint स्लाइड ऑब्जेक्ट को रिलीज़ करें।

		shapeRange = null;

		pptSlide = null;

		// Presentation ऑब्जेक्ट को बंद करें और रिलीज़ करें।

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// PowerPoint को बंद करें और ApplicationClass ऑब्जेक्ट को रिलीज़ करें।

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Excel ऑब्जेक्ट्स को रिलीज़ करें।

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Excel Workbook ऑब्जेक्ट को बंद करें और रिलीज़ करें।

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Excel को बंद करें और ApplicationClass ऑब्जेक्ट को रिलीज़ करें।

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
Aspose.Slides for .NET का उपयोग करके, निम्नलिखित चरण किए जाते हैं:

1. Aspose.Cells for .NET का उपयोग करके एक वर्कबुक बनाएं।
2. Microsoft Excel चार्ट बनाएं।
3. Excel चार्ट का OLE आकार सेट करें।
4. चार्ट की एक छवि प्राप्त करें।
5. Aspose.Slides for .NET का उपयोग करके PPTX प्रस्तुति में Excel चार्ट को OLE ऑब्जेक्ट के रूप में एम्बेड करें।
6. ऑब्जेक्ट बदलने की समस्या को हल करने के लिए चरण 3 में प्राप्त छवि से ऑब्जेक्ट बदली हुई छवि को बदलें।
7. आउटपुट प्रस्तुति को डिस्क पर PPTX फ़ॉर्मेट में लिखें।

``` csharp

 static void Main(string[] args)

{

	//Create a workbook
	Workbook wb = new Workbook();

	//Add an excel chart
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Save the workbook to stream
	MemoryStream wbStream = wb.SaveToStream();

	//Create a presentation
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];

	//Add the workbook on slide
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Write the output presentation on disk
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Add a new worksheet to populate cells with data
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;

	//Populate DataSheet with data
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

	//Add a chart sheet
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";

	//Add a chart in ChartSheet with data series from DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Setting Chart's Title
	chart.Title.Text = "Sales by Quarter";

	//Setting the foreground color of the plot area
	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Setting the background color of the plot area
	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Setting the foreground color of the chart area
	chart.ChartArea.Area.BackgroundColor = Color.White;
	chart.Title.TextFont.Size = 16;

	//Setting the title of category axis of the chart
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//Setting the title of value axis of the chart
	chart.ValueAxis.Title.Text = "Billions";

	//Set ChartSheet an active sheet
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
## **सैंपल कोड डाउनलोड करें**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)