---
title: Создание и встраивание диаграммы Excel в качестве OLE-объекта
type: docs
weight: 70
url: /ru/net/create-and-embed-an-excel-chart-as-an-ole-object/
---

Два примера кода ниже длинные и подробные, потому что рассматриваемая задача сложная. Вы создаете книгу Microsoft Excel, создаете диаграмму, а затем создаете презентацию Microsoft PowerPoint, в которую вы встроите диаграмму. OLE-объекты содержат ссылки на оригинальный документ, поэтому пользователь, дважды щелкнув на встроенном файле, запустит файл и его приложение.
## **VSTO**
С использованием VSTO выполняются следующие шаги:

1. Создайте экземпляр объекта Microsoft Excel ApplicationClass.
1. Создайте новую книгу с одним листом в ней.
1. Добавьте диаграмму на лист.
1. Сохраните книгу.
1. Откройте книгу Excel, содержащую рабочий лист с данными для диаграммы.
1. Получите коллекцию ChartObjects для листа.
1. Получите диаграмму для копирования.
1. Создайте презентацию Microsoft PowerPoint.
1. Добавьте пустой слайд в презентацию.
1. Скопируйте диаграмму с рабочего листа Excel в буфер обмена.
1. Вставьте диаграмму в презентацию PowerPoint.
1. Разместите диаграмму на слайде.
1. Сохраните презентацию.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Объявите переменную для экземпляра Excel ApplicationClass.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Объявите переменные для параметров метода Workbooks.Open.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Объявите переменные для метода Chart.ChartWizard.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Продажи по кварталам";

	object paramCategoryTitle = "Фискальный квартал";

	object paramValueTitle = "Миллиарды";

	try

	{

		// Создайте экземпляр объекта Excel ApplicationClass.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Создайте новую книгу с 1 листом в ней.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Измените имя листа.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Продажи по кварталам";

		// Вставьте данные для диаграммы на лист.

		//              A       B       C       D       E

		//     1                Q1      Q2      Q3      Q4

		//     2    Северная Америка  1.5     2       1.5     2.5

		//     3    Южная Америка  2       1.75    2       2

		//     4    Европа      2.25    2       2.5     2

		//     5    Азия        2.5     2.5     2       2.75

		SetCellValue(targetSheet, "A2", "Северная Америка");

		SetCellValue(targetSheet, "A3", "Южная Америка");

		SetCellValue(targetSheet, "A4", "Европа");

		SetCellValue(targetSheet, "A5", "Азия");

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

		// Получите диапазон, содержащий данные диаграммы.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Получите коллекцию ChartObjects для листа.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Добавьте диаграмму в коллекцию.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Диаграмма Продаж";

		// Создайте новую диаграмму из данных.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Сохраните книгу.

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

			// Закройте Excel.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Объявите переменные для хранения ссылок на объекты PowerPoint.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Объявите переменные для хранения ссылок на объекты Excel.

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

		// Создайте экземпляр PowerPoint.

		powerpointApplication =new pptNS.Application();

		// Создайте экземпляр Excel.

		excelApplication = new xlNS.Application();

		// Откройте книгу Excel, содержащую рабочий лист с данными для диаграммы.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Получите рабочий лист, который содержит диаграмму.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Продажи по кварталам"]);

		// Получите коллекцию ChartObjects для листа.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Получите диаграмму для копирования.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Диаграмма Продаж"));

		// Создайте презентацию PowerPoint.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Добавьте пустой слайд в презентацию.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Скопируйте диаграмму с рабочего листа Excel в буфер обмена.

		existingChartObject.Copy();

		// Вставьте диаграмму в презентацию PowerPoint.

		shapeRange = pptSlide.Shapes.Paste();

		// Разместите диаграмму на слайде.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Сохраните презентацию.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Освободите объект слайда PowerPoint.

		shapeRange = null;

		pptSlide = null;

		// Закройте и освободите объект Presentation.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Закройте PowerPoint и освободите объект ApplicationClass.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Освободите объекты Excel.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Закройте и освободите объект Excel Workbook.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Закройте Excel и освободите объект ApplicationClass.

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
С использованием Aspose.Slides для .NET выполняются следующие шаги:

1. Создайте книгу с использованием Aspose.Cells для .NET.
1. Создайте диаграмму Microsoft Excel.
1. Установите размер OLE диаграммы Excel.
1. Получите изображение диаграммы.
1. Вставьте диаграмму Excel в качестве OLE-объекта в презентацию PPTX, используя Aspose.Slides для .NET.
1. Замените измененное изображение объекта изображением, полученным на шаге 3, чтобы решить проблему с изменением объекта.
1. Запишите выходную презентацию на диск в формате PPTX.

``` csharp

 static void Main(string[] args)

{

	//Создайте книгу

	Workbook wb = new Workbook();

	//Добавьте диаграмму Excel

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Сохраните книгу в поток

	MemoryStream wbStream = wb.SaveToStream();

	//Создайте презентацию

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	//Добавьте книгу на слайд

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Запишите выходную презентацию на диск

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Добавьте новый рабочий лист, чтобы заполнить ячейки данными

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "DataSheet";

	dataSheet.Name = sheetName;

	//Заполните DataSheet данными

	dataSheet.Cells["A2"].PutValue("Северная Америка");

	dataSheet.Cells["A3"].PutValue("Южная Америка");

	dataSheet.Cells["A4"].PutValue("Европа");

	dataSheet.Cells["A5"].PutValue("Азия");

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

	//Добавьте диаграмму

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "ChartSheet";

	//Добавьте диаграмму на ChartSheet с сериями данных из DataSheet

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Установите заголовок диаграммы

	chart.Title.Text = "Продажи по кварталам";

	//Установите цвет переднего плана области графика

	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Установите цвет фона области графика

	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Установите цвет переднего плана области диаграммы

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Установите заголовок оси категорий для диаграммы

	chart.CategoryAxis.Title.Text = "Фискальный квартал";

	//Установите заголовок оси значений для диаграммы

	chart.ValueAxis.Title.Text = "Миллиарды";

	//Установите ChartSheet как активный лист

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

	oof.Image = pres.Images.AddImage((System.Drawing.Image)imgChart);

}

}

``` 
## **Скачать образец кода**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772950)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip)