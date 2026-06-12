---
title: Crea e incorpora un grafico Excel come oggetto OLE
type: docs
weight: 70
url: /it/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
I due esempi di codice seguenti sono lunghi e dettagliati perché il compito che descrivono è complesso. Si crea una cartella di lavoro Microsoft Excel, si crea un grafico e poi si crea la presentazione Microsoft PowerPoint in cui incorporare il grafico. Gli oggetti OLE contengono collegamenti al documento originale, quindi un utente che fa doppio clic sul file incorporato avvierà il file e la sua applicazione.

## **VSTO**
Utilizzando VSTO, vengono eseguiti i seguenti passaggi:

1. Creare un'istanza dell'oggetto Microsoft Excel ApplicationClass.
2. Creare una nuova cartella di lavoro con un foglio.
3. Aggiungere il grafico al foglio.
4. Salvare la cartella di lavoro.
5. Aprire la cartella di lavoro Excel contenente il foglio di lavoro con i dati del grafico.
6. Ottenere la raccolta ChartObjects per il foglio.
7. Ottenere il grafico da copiare.
8. Creare una presentazione Microsoft PowerPoint.
9. Aggiungere una diapositiva vuota alla presentazione.
10. Copiare il grafico dal foglio di lavoro Excel negli appunti.
11. Incollare il grafico nella presentazione PowerPoint.
12. Posizionare il grafico nella diapositiva.
13. Salvare la presentazione.

```csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Dichiarare una variabile per l'istanza di Excel ApplicationClass.
	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Dichiarare le variabili per i parametri del metodo Workbooks.Open.
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Dichiarare le variabili per il metodo Chart.ChartWizard.
	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Creare un'istanza dell'oggetto Excel ApplicationClass.
	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Creare una nuova cartella di lavoro con 1 foglio.
		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Modificare il nome del foglio.
		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// Inserire alcuni dati per il grafico nel foglio.

		//              A       B       C       D       E

		//     1                Q1      Q2      Q3      Q4

		//     2    America del Nord  1.5     2       1.5     2.5

		//     3    America del Sud   2       1.75    2       2

		//     4    Europa            2.25    2       2.5     2

		//     5    Asia              2.5     2.5     2       2.75

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

		// Ottenere l'intervallo contenente i dati del grafico.
		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Ottenere la collezione ChartObjects per il foglio.
		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Aggiungere un grafico alla collezione.
		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// Creare un nuovo grafico dei dati.
		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Salvare la cartella di lavoro.
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

			// Chiudere Excel.
			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Dichiarare le variabili per contenere riferimenti agli oggetti PowerPoint.
	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Dichiarare le variabili per contenere riferimenti agli oggetti Excel.
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

		// Creare un'istanza di PowerPoint.
		powerpointApplication =new pptNS.Application();

		// Creare un'istanza di Excel.
		excelApplication = new xlNS.Application();

		// Aprire la cartella di lavoro Excel contenente il foglio con i dati del grafico.
		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Ottenere il foglio di lavoro che contiene il grafico.
		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// Ottenere la collezione ChartObjects per il foglio.
		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Ottenere il grafico da copiare.
		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// Creare una presentazione PowerPoint.
		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Aggiungere una diapositiva vuota alla presentazione.
		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Copiare il grafico dal foglio di lavoro Excel negli appunti.
		existingChartObject.Copy();

		// Incollare il grafico nella presentazione PowerPoint.
		shapeRange = pptSlide.Shapes.Paste();

		// Posizionare il grafico sulla diapositiva.
		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Salvare la presentazione.
		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Rilasciare l'oggetto diapositiva di PowerPoint.
		shapeRange = null;

		pptSlide = null;

		// Chiudere e rilasciare l'oggetto Presentazione.
		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Uscire da PowerPoint e rilasciare l'oggetto ApplicationClass.
		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Rilasciare gli oggetti Excel.
		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Chiudere e rilasciare l'oggetto cartella di lavoro Excel.
		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Uscire da Excel e rilasciare l'oggetto ApplicationClass.
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
Utilizzando Aspose.Slides per .NET, vengono eseguiti i seguenti passaggi:

1. Creare una cartella di lavoro usando Aspose.Cells per .NET.
2. Creare un grafico Microsoft Excel.
3. Impostare le dimensioni OLE del grafico Excel.
4. Ottenere un'immagine del grafico.
5. Incorporare il grafico Excel come oggetto OLE all'interno di una presentazione PPTX utilizzando Aspose.Slides per .NET.
6. Sostituire l'immagine dell'oggetto modificato con l'immagine ottenuta al punto 3 per gestire il problema dell'oggetto modificato.
7. Scrivere la presentazione di output su disco in formato PPTX.

```csharp

 static void Main(string[] args)

{

	//Crea una cartella di lavoro
	Workbook wb = new Workbook();

	//Aggiungi un grafico Excel
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Salva la cartella di lavoro su stream
	MemoryStream wbStream = wb.SaveToStream();

	//Crea una presentazione
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];

	//Aggiungi la cartella di lavoro nella diapositiva
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Scrivi la presentazione di output su disco
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Aggiungi un nuovo foglio di lavoro per popolare le celle con i dati
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;

	//Popola DataSheet con i dati
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

	//Aggiungi un foglio grafico
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";

	//Aggiungi un grafico in ChartSheet con serie di dati da DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Impostazione del titolo del grafico
	chart.Title.Text = "Sales by Quarter";

	//Impostazione del colore di primo piano dell'area del grafico
	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Impostazione del colore di sfondo dell'area del grafico
	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Impostazione del colore di primo piano dell'area del grafico
	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Impostazione del titolo dell'asse di categoria del grafico
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//Impostazione del titolo dell'asse dei valori del grafico
	chart.ValueAxis.Title.Text = "Billions";

	//Imposta ChartSheet come foglio attivo
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
## **Scarica il codice di esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)