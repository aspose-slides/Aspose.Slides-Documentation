---
title: Crear e Incrustar un Gráfico de Excel como un Objeto OLE
type: docs
weight: 70
url: /es/net/create-and-embed-an-excel-chart-as-an-ole-object/
---

Los dos ejemplos de código a continuación son largos y detallados porque la tarea que describen es compleja. Creas un libro de trabajo de Microsoft Excel, creas un gráfico y luego creas la presentación de Microsoft PowerPoint en la que incrustarás el gráfico. Los objetos OLE contienen enlaces al documento original, por lo que un usuario que haga doble clic en el archivo incrustado abrirá el archivo y su aplicación.
## **VSTO**
Utilizando VSTO, se llevan a cabo los siguientes pasos:

1. Crear una instancia del objeto Microsoft Excel ApplicationClass.
1. Crear un nuevo libro de trabajo con una hoja en él.
1. Agregar un gráfico a la hoja.
1. Guardar el libro de trabajo.
1. Abrir el libro de trabajo de Excel que contiene la hoja de trabajo con los datos del gráfico.
1. Obtener la colección ChartObjects para la hoja.
1. Obtener el gráfico a copiar.
1. Crear una presentación de Microsoft PowerPoint.
1. Agregar una diapositiva en blanco a la presentación.
1. Copiar el gráfico de la hoja de trabajo de Excel en el portapapeles.
1. Pegar el gráfico en la presentación de PowerPoint.
1. Posicionar el gráfico en la diapositiva.
1. Guardar la presentación.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Declarar una variable para la instancia de la clase Excel ApplicationClass.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Declarar variables para los parámetros del método Workbooks.Open.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Declarar variables para el método Chart.ChartWizard.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Ventas por Trimestre";

	object paramCategoryTitle = "Trimestre Fiscal";

	object paramValueTitle = "Miles de millones";

	try

	{

		// Crear una instancia del objeto Excel ApplicationClass.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Crear un nuevo libro de trabajo con 1 hoja en él.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Cambiar el nombre de la hoja.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Ventas Trimestrales";

		// Insertar algunos datos para el gráfico en la hoja.

		//              A       B       C       D       E

		//     1                T1      T2      T3      T4

		//     2    N. América  1.5     2       1.5     2.5

		//     3    S. América  2       1.75    2       2

		//     4    Europa      2.25    2       2.5     2

		//     5    Asia        2.5     2.5     2       2.75

		SetCellValue(targetSheet, "A2", "N. América");

		SetCellValue(targetSheet, "A3", "S. América");

		SetCellValue(targetSheet, "A4", "Europa");

		SetCellValue(targetSheet, "A5", "Asia");

		SetCellValue(targetSheet, "B1", "T1");

		SetCellValue(targetSheet, "B2", 1.5);

		SetCellValue(targetSheet, "B3", 2);

		SetCellValue(targetSheet, "B4", 2.25);

		SetCellValue(targetSheet, "B5", 2.5);

		SetCellValue(targetSheet, "C1", "T2");

		SetCellValue(targetSheet, "C2", 2);

		SetCellValue(targetSheet, "C3", 1.75);

		SetCellValue(targetSheet, "C4", 2);

		SetCellValue(targetSheet, "C5", 2.5);

		SetCellValue(targetSheet, "D1", "T3");

		SetCellValue(targetSheet, "D2", 1.5);

		SetCellValue(targetSheet, "D3", 2);

		SetCellValue(targetSheet, "D4", 2.5);

		SetCellValue(targetSheet, "D5", 2);

		SetCellValue(targetSheet, "E1", "T4");

		SetCellValue(targetSheet, "E2", 2.5);

		SetCellValue(targetSheet, "E3", 2);

		SetCellValue(targetSheet, "E4", 2);

		SetCellValue(targetSheet, "E5", 2.75);

		// Obtener el rango que contiene los datos del gráfico.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Obtener la colección ChartObjects para la hoja.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Agregar un gráfico a la colección.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Gráfico de Ventas";

		// Crear un nuevo gráfico de los datos.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Guardar el libro de trabajo.

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

			// Cerrar Excel.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Declarar variables para mantener referencias a objetos de PowerPoint.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Declarar variables para mantener referencias a objetos de Excel.

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

		// Crear una instancia de PowerPoint.

		powerpointApplication =new pptNS.Application();

		// Crear una instancia de Excel.

		excelApplication = new xlNS.Application();

		// Abrir el libro de trabajo de Excel que contiene la hoja de trabajo con los datos del gráfico.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Obtener la hoja de trabajo que contiene el gráfico.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Ventas Trimestrales"]);

		// Obtener la colección ChartObjects para la hoja.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Obtener el gráfico a copiar.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Gráfico de Ventas"));

		// Crear una presentación de PowerPoint.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Agregar una diapositiva en blanco a la presentación.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Copiar el gráfico de la hoja de trabajo de Excel en el portapapeles.

		existingChartObject.Copy();

		// Pegar el gráfico en la presentación de PowerPoint.

		shapeRange = pptSlide.Shapes.Paste();

		// Posicionar el gráfico en la diapositiva.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Guardar la presentación.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Liberar el objeto de la diapositiva de PowerPoint.

		shapeRange = null;

		pptSlide = null;

		// Cerrar y liberar el objeto de Presentación.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Salir de PowerPoint y liberar el objeto ApplicationClass.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Liberar los objetos de Excel.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Cerrar y liberar el objeto Workbook de Excel.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Salir de Excel y liberar el objeto ApplicationClass.

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
Utilizando Aspose.Slides para .NET, se llevan a cabo los siguientes pasos:

1. Crear un libro de trabajo utilizando Aspose.Cells para .NET.
1. Crear un gráfico de Microsoft Excel.
1. Establecer el tamaño OLE del gráfico de Excel.
1. Obtener una imagen del gráfico.
1. Incrustar el gráfico de Excel como un objeto OLE dentro de la presentación PPTX utilizando Aspose.Slides para .NET.
1. Reemplazar la imagen del objeto cambiado con la imagen obtenida en el paso 3 para resolver el problema del objeto cambiado.
1. Escribir la presentación de salida en disco en formato PPTX.

``` csharp

 static void Main(string[] args)

{

	//Crear un libro de trabajo

	Workbook wb = new Workbook();

	//Agregar un gráfico de Excel

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Guardar el libro de trabajo en un stream

	MemoryStream wbStream = wb.SaveToStream();

	//Crear una presentación

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	//Agregar el libro de trabajo en la diapositiva

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Escribir la presentación de salida en disco

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Agregar una nueva hoja de trabajo para poblar celdas con datos

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "DataSheet";

	dataSheet.Name = sheetName;

	//Poblar DataSheet con datos

	dataSheet.Cells["A2"].PutValue("N. América");

	dataSheet.Cells["A3"].PutValue("S. América");

	dataSheet.Cells["A4"].PutValue("Europa");

	dataSheet.Cells["A5"].PutValue("Asia");

	dataSheet.Cells["B1"].PutValue("T1");

	dataSheet.Cells["B2"].PutValue(1.5);

	dataSheet.Cells["B3"].PutValue(2);

	dataSheet.Cells["B4"].PutValue(2.25);

	dataSheet.Cells["B5"].PutValue(2.5);

	dataSheet.Cells["C1"].PutValue("T2");

	dataSheet.Cells["C2"].PutValue(2);

	dataSheet.Cells["C3"].PutValue(1.75);

	dataSheet.Cells["C4"].PutValue(2);

	dataSheet.Cells["C5"].PutValue(2.5);

	dataSheet.Cells["D1"].PutValue("T3");

	dataSheet.Cells["D2"].PutValue(1.5);

	dataSheet.Cells["D3"].PutValue(2);

	dataSheet.Cells["D4"].PutValue(2.5);

	dataSheet.Cells["D5"].PutValue(2);

	dataSheet.Cells["E1"].PutValue("T4");

	dataSheet.Cells["E2"].PutValue(2.5);

	dataSheet.Cells["E3"].PutValue(2);

	dataSheet.Cells["E4"].PutValue(2);

	dataSheet.Cells["E5"].PutValue(2.75);

	//Agregar una hoja de gráfico

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "ChartSheet";

	//Agregar un gráfico en ChartSheet con series de datos de DataSheet

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Configuración del título del gráfico

	chart.Title.Text = "Ventas por Trimestre";

	//Configuración del color de primer plano del área de trazado

	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Configuración del color de fondo del área de trazado

	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Configuración del color de primer plano del área del gráfico

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Configuración del título del eje de categorías del gráfico

	chart.CategoryAxis.Title.Text = "Trimestre Fiscal";

	//Configuración del título del eje de valores del gráfico

	chart.ValueAxis.Title.Text = "Miles de millones";

	//Establecer ChartSheet como hoja activa

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
## **Descargar Código de Ejemplo**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772950)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip)