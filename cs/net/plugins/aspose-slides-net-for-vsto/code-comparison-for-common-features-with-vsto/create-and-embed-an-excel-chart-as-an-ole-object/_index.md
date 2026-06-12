---
title: Vytvořit a vložit graf Excel jako OLE objekt
type: docs
weight: 70
url: /cs/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
Níže uvedené dva ukázkové kódy jsou dlouhé a podrobné, protože popisovaný úkol je složitý. Vytvoříte sešit Microsoft Excel, vytvoříte graf a poté vytvoříte prezentaci Microsoft PowerPoint, do které graf vložíte. OLE objekty obsahují odkazy na původní dokument, takže uživatel, který dvakrát klikne na vložený soubor, spustí soubor a jeho aplikaci.

## **VSTO**
Using VSTO, the following steps are performed:

1. Vytvořte instanci objektu Microsoft Excel ApplicationClass.
1. Vytvořte nový sešit s jedním listem.
1. Přidejte graf do listu.
1. Uložte sešit.
1. Otevřete sešit Excelu obsahující list s daty grafu.
1. Získejte kolekci ChartObjects pro list.
1. Získejte graf, který chcete kopírovat.
1. Vytvořte prezentaci Microsoft PowerPoint.
1. Přidejte do prezentace prázdný snímek.
1. Zkopírujte graf z listu Excelu do schránky.
1. Vložte graf do prezentace PowerPoint.
1. Umístěte graf na snímek.
1. Uložte prezentaci.

```csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Deklarujte proměnnou pro instanci třídy Excel ApplicationClass.
	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Deklarujte proměnné pro parametry metody Workbooks.Open.
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Deklarujte proměnné pro metodu Chart.ChartWizard.
	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Vytvořte instanci objektu Excel ApplicationClass.
	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Vytvořte nový sešit s 1 listem.
		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Změňte název listu.
		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// Vložte některá data pro graf do listu.
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
		// Získejte rozsah obsahující data grafu.
		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");
		// Získejte kolekci ChartObjects pro list.
		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
		// Přidejte graf do kolekce.
		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
		newChartObject.Name = "Sales Chart";
		// Vytvořte nový graf z dat.
		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);
		// Uložte sešit.
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
			// Zavřete Excel.
			excelApplication.Quit();
		}
	}
}

public void UseCopyPaste()
{
	// Deklarujte proměnné pro uchování odkazů na objekty PowerPointu.
	pptNS.Application powerpointApplication = null;
	pptNS.Presentation pptPresentation = null;
	pptNS.Slide pptSlide = null;
	pptNS.ShapeRange shapeRange = null;
	// Deklarujte proměnné pro uchování odkazů na objekty Excelu.
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
		// Vytvořte instanci PowerPointu.
		powerpointApplication =new pptNS.Application();
		// Vytvořte instanci Excelu.
		excelApplication = new xlNS.Application();
		// Otevřete sešit Excelu obsahující list s daty grafu.
		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing);
		// Získejte list, který obsahuje graf.
		targetSheet =
			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);
		// Získejte kolekci ChartObjects pro list.
		chartObjects =
			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
		// Získejte graf ke kopírování.
		existingChartObject =
			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));
		// Vytvořte prezentaci PowerPoint.
		pptPresentation =
			powerpointApplication.Presentations.Add(
			Microsoft.Office.Core.MsoTriState.msoTrue);
		// Přidejte prázdný snímek do prezentace.
		pptSlide =
			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);
		// Zkopírujte graf z listu Excelu do schránky.
		existingChartObject.Copy();
		// Vložte graf do prezentace PowerPoint.
		shapeRange = pptSlide.Shapes.Paste();
		// Umístěte graf na snímek.
		shapeRange.Left = 60;
		shapeRange.Top = 100;
		// Uložte prezentaci.
		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
	finally
	{
		// Uvolněte objekt snímku PowerPointu.
		shapeRange = null;
		pptSlide = null;
		// Zavřete a uvolněte objekt Presentation.
		if (pptPresentation != null)
		{
			pptPresentation.Close();
			pptPresentation = null;
		}
		// Ukončete PowerPoint a uvolněte objekt ApplicationClass.
		if (powerpointApplication != null)
		{
			powerpointApplication.Quit();
			powerpointApplication = null;
		}
		// Uvolněte objekty Excelu.
		targetSheet = null;
		chartObjects = null;
		existingChartObject = null;
		// Zavřete a uvolněte objekt sešitu Excelu.
		if (excelWorkBook != null)
		{
			excelWorkBook.Close(false, paramMissing, paramMissing);
			excelWorkBook = null;
		}
		// Ukončete Excel a uvolněte objekt ApplicationClass.
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
Using Aspose.Slides for .NET, the following steps are performed:

1. Vytvořte sešit pomocí Aspose.Cells pro .NET.
1. Vytvořte graf Microsoft Excel.
1. Nastavte velikost OLE grafu Excel.
1. Získejte obrázek grafu.
1. Vložte graf Excel jako OLE objekt do prezentace PPTX pomocí Aspose.Slides pro .NET.
1. Nahraďte obrázek změněného objektu obrázkem získaným v kroku 3, aby se vyřešil problém změněného objektu.
1. Zapište výstupní prezentaci na disk ve formátu PPTX.

```csharp

 static void Main(string[] args)

{

	//Vytvořte sešit
	Workbook wb = new Workbook();

	//Přidejte graf Excel
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Uložte sešit do proudu
	MemoryStream wbStream = wb.SaveToStream();

	//Vytvořte prezentaci
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];

	//Přidejte sešit na snímek
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Zapište výstupní prezentaci na disk
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Přidejte nový pracovní list pro naplnění buněk daty
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;

	//Naplnění DataSheet daty
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

	//Přidejte list s grafem
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";

	//Přidejte graf do ChartSheet s datovými řadami z DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Nastavení názvu grafu
	chart.Title.Text = "Sales by Quarter";

	//Nastavení popředí oblasti grafu
	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Nastavení pozadí oblasti grafu
	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Nastavení popředí oblasti grafu (chart area)
	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Nastavení názvu osy kategorií grafu
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//Nastavení názvu osy hodnot grafu
	chart.ValueAxis.Title.Text = "Billions";

	//Nastavte ChartSheet jako aktivní list
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
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)