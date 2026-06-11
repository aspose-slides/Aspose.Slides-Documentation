---
title: Utwórz wykres
type: docs
weight: 60
url: /pl/net/create-a-chart/
---
Poniższe przykłady kodu opisują proces dodawania prostego wykresu kolumnowego 3D skumulowanego przy użyciu VSTO. Tworzysz instancję prezentacji, dodajesz do niej domyślny wykres. Następnie używasz skoroszytu Microsoft Excel, aby uzyskać dostęp i zmodyfikować dane wykresu oraz ustawić właściwości wykresu. Na koniec zapisujesz prezentację.

## **VSTO**
Using VSTO, the following steps are performed:

1. Utwórz instancję prezentacji Microsoft PowerPoint.  
2. Dodaj pusty slajd do prezentacji.  
3. Dodaj wykres kolumnowy 3D skumulowany i uzyskaj do niego dostęp.  
4. Utwórz nową instancję skoroszytu Microsoft Excel i wczytaj dane wykresu.  
5. Uzyskaj dostęp do arkusza danych wykresu, używając instancji skoroszytu Microsoft Excel.  
6. Ustaw zakres wykresu w arkuszu i usuń serie 2 oraz 3 z wykresu.  
7. Zmodyfikuj dane kategorii wykresu w arkuszu danych wykresu.  
8. Zmodyfikuj dane serii 1 wykresu w arkuszu danych wykresu.  
9. Teraz uzyskaj dostęp do tytułu wykresu i ustaw właściwości czcionki.  
10. Uzyskaj dostęp do osi wartości wykresu i ustaw jednostkę główną, jednostki pomocnicze, maksymalną oraz minimalną wartość.  
11. Uzyskaj dostęp do osi głębokości lub osi serii i usuń ją, ponieważ w tym przykładzie używana jest tylko jedna seria.  
12. Teraz ustaw kąty obrotu wykresu w kierunku X i Y.  
13. Zapisz prezentację.  
14. Zamknij instancje Microsoft Excel i PowerPoint.

```csharp

 //Zmienne globalne

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Utwórz obiekt slajdu

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Uzyskaj dostęp do pierwszego slajdu prezentacji

	objSlide = objPres.Slides[1];

	//Wybierz pierwszy slajd i ustaw jego układ

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Dodaj domyślny wykres na slajdzie

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Uzyskaj dostęp do dodanego wykresu

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Uzyskaj dostęp do danych wykresu

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Utwórz instancję skoroszytu Excel do pracy z danymi wykresu

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Uzyskiwanie arkusza danych dla wykresu

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Ustawianie zakresu wykresu

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Zastosowanie ustawionego zakresu w tabeli danych wykresu

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Ustawianie wartości dla kategorii i odpowiadających danych serii

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Ustawianie tytułu wykresu

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Uzyskiwanie osi wartości wykresu

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Ustawianie jednostek osi wartości

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Uzyskiwanie osi głębokości wykresu

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Ustawianie obrotu wykresu

	ppChart.Rotation = 20; //Wartość-Y

	ppChart.Elevation = 15; //Wartość-X

	ppChart.RightAngleAxes = false;

	//Zapisz prezentację jako PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Zamknij skoroszyt i prezentację

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

	//Spróbuj uzyskać dostęp do właściwości Name. Jeśli spowoduje to wyjątek, to

	//uruchom nową instancję programu PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation jest używane, aby zapewnić wczytanie prezentacji

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

	//BlnAddSlide jest używane, aby zapewnić co najmniej jeden slajd w

	//prezentacji

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

1. Utwórz instancję prezentacji Microsoft PowerPoint.  
2. Dodaj pusty slajd do prezentacji.  
3. Dodaj wykres kolumnowy 3D skumulowany i uzyskaj do niego dostęp.  
4. Uzyskaj dostęp do arkusza danych wykresu, używając instancji skoroszytu Microsoft Excel.  
5. Usuń nieużywane serie 2 i 3.  
6. Uzyskaj dostęp do kategorii wykresu i zmodyfikuj etykiety.  
7. Uzyskaj dostęp do serii 1 i zmodyfikuj wartości serii.  
8. Teraz uzyskaj dostęp do tytułu wykresu i ustaw właściwości czcionki.  
9. Uzyskaj dostęp do osi wartości wykresu i ustaw jednostkę główną, jednostki pomocnicze, maksymalną oraz minimalną wartość.  
10. Teraz ustaw kąty obrotu wykresu w kierunku X i Y.  
11. Zapisz prezentację w formacie PPTX.

```csharp

 public static void GEN_ASPOSE_Chart()
{
	//Utwórz pustą prezentację
	using (PresentationEx pres = new PresentationEx())
	{
		//Uzyskiwanie pierwszego slajdu
		SlideEx slide = pres.Slides[0];
		//Dodawanie domyślnego wykresu
		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);
		//Pobieranie danych wykresu
		ChartDataEx chartData = ppChart.ChartData;
		//Usuwanie dodatkowych domyślnych serii
		chartData.Series.RemoveAt(1);
		chartData.Series.RemoveAt(1);
		//Modyfikowanie nazw kategorii wykresu
		chartData.Categories[0].ChartDataCell.Value = "Bikes";
		chartData.Categories[1].ChartDataCell.Value = "Accessories";
		chartData.Categories[2].ChartDataCell.Value = "Repairs";
		chartData.Categories[3].ChartDataCell.Value = "Clothing";
		//Modyfikowanie wartości serii wykresu dla pierwszej kategorii
		chartData.Series[0].Values[0].Value = 1000;
		chartData.Series[0].Values[1].Value = 2500;
		chartData.Series[0].Values[2].Value = 4000;
		chartData.Series[0].Values[3].Value = 3000;
		//Ustawianie tytułu wykresu
		ppChart.HasTitle = true;
		ppChart.ChartTitle.Text.Text = "2007 Sales";
		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;
		format.FontItalic = NullableBool.True;
		format.FontHeight = 18;
		format.FillFormat.FillType = FillTypeEx.Solid;
		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Ustawianie wartości osi
		ppChart.ValueAxis.IsAutomaticMaxValue = false;
		ppChart.ValueAxis.IsAutomaticMinValue = false;
		ppChart.ValueAxis.IsAutomaticMajorUnit = false;
		ppChart.ValueAxis.IsAutomaticMinorUnit = false;
		ppChart.ValueAxis.MaxValue = 4000.0F;
		ppChart.ValueAxis.MinValue = 0.0F;
		ppChart.ValueAxis.MajorUnit = 2000.0F;
		ppChart.ValueAxis.MinorUnit = 1000.0F;
		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;
		//Ustawianie obrotu wykresu
		ppChart.Rotation3D.RotationX = 15;
		ppChart.Rotation3D.RotationY = 20;
		//Zapisywanie prezentacji
		pres.Write("AsposeSampleChart.pptx");
	}
}
``` 
## **Download Sample Code**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)