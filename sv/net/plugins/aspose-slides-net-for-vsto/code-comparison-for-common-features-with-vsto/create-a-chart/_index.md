---
title: Skapa ett diagram
type: docs
weight: 60
url: /sv/net/create-a-chart/
---
Kodexemplen nedan beskriver processen för att lägga till ett enkelt 3D‑klustrat stapeldiagram med VSTO. Du skapar en presentationsinstans, lägger till ett standarddiagram i den. Sedan använder du en Microsoft Excel‑arbetsbok för att komma åt och ändra diagramdata samt ställa in diagramegenskaper. Slutligen sparas presentationen.

## **VSTO**
Using VSTO, the following steps are performed:

1. Skapa en instans av en Microsoft PowerPoint‑presentation.  
2. Lägg till en tom bild i presentationen.  
3. Lägg till ett 3D‑klustrat stapeldiagram och få åtkomst till det.  
4. Skapa en ny Microsoft Excel‑arbetsbokinstans och läs in diagramdata.  
5. Få åtkomst till diagramdatabladet med hjälp av Microsoft Excel‑arbetsbokinstansen från arbetsboken.  
6. Ange diagramområdet i bladet och ta bort serierna 2 och 3 från diagrammet.  
7. Ändra diagramkategoridata i diagramdatabladet.  
8. Ändra diagramserie 1:s data i diagramdatabladet.  
9. Nu, få åtkomst till diagramrubriken och ställ in de teckenrelaterade egenskaperna.  
10. Få åtkomst till diagrammets värdeaxel och ställ in huvudenheten, mindre enheter, maxvärde och minvärde.  
11. Få åtkomst till diagrammets djup‑ eller serieaxel och ta bort den, eftersom i det här exemplet används bara en serie.  
12. Nu, ställ in diagrammets rotationsvinklar i X‑ och Y‑riktning.  
13. Spara presentationen.  
14. Stäng instanserna av Microsoft Excel och PowerPoint.

``` csharp

 //Globala variabler

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Instansiera bildobjekt

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Åtkomst till den första bilden i presentationen

	objSlide = objPres.Slides[1];

	//Välj första bilden och sätt dess layout

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Lägg till ett standarddiagram på bilden

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Åtkomst till det tillagda diagrammet

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Åtkomst till diagramdata

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Skapa instans av Excel‑arbetsbok för att arbeta med diagramdata

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Åtkomst till dataarbetsbladet för diagrammet

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Ställ in diagrammets område

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Applicera det angivna området på diagrammets datatabell

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Ställ in värden för kategorier och respektive seriedata

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Ställ in diagramrubrik

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Åtkomst till diagrammets värdeaxel

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Ställ in enheter för värdeaxeln

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Åtkomst till diagrammets djupaxel

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Ställ in diagramrotation

	ppChart.Rotation = 20; //Y-Value

	ppChart.Elevation = 15; //X-Value

	ppChart.RightAngleAxes = false;

	// Spara presentationen som en PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Stäng arbetsbok och presentation

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

	//Försök åtkomst till name‑egenskapen. Om det orsakar ett undantag så

	//starta en ny instans av PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation används för att säkerställa att en presentation är laddad

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

	//BlnAddSlide används för att säkerställa att det finns minst en bild i

	//presentation

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

1. Skapa en instans av en Microsoft PowerPoint‑presentation.  
2. Lägg till en tom bild i presentationen.  
3. Lägg till ett 3D‑klustrat stapeldiagram och få åtkomst till det.  
4. Få åtkomst till diagramdatabladet med hjälp av en Microsoft Excel‑arbetsbokinstans från arbetsboken.  
5. Ta bort oanvända serierna 2 och 3.  
6. Få åtkomst till diagramkategorierna och ändra etiketterna.  
7. Få åtkomst till serie 1 och ändra serievärdena.  
8. Nu, få åtkomst till diagramrubriken och ställ in teckensegenskaperna.  
9. Få åtkomst till diagrammets värdeaxel och ställ in huvudenheten, mindre enheter, maxvärde och minvärde.  
10. Nu, ställ in diagrammets rotationsvinklar i X‑ och Y‑riktning.  
11. Spara presentationen i PPTX‑format.

``` csharp

 public static void GEN_ASPOSE_Chart()
{
	//Skapa en tom presentation
	using (PresentationEx pres = new PresentationEx())
	{
		//Åtkomst till första bilden
		SlideEx slide = pres.Slides[0];
		//Lägger till standarddiagram
		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);
		//Hämtar diagramdata
		ChartDataEx chartData = ppChart.ChartData;
		//Tar bort extra standardserier
		chartData.Series.RemoveAt(1);
		chartData.Series.RemoveAt(1);
		//Modifierar diagramkategoriernas namn
		chartData.Categories[0].ChartDataCell.Value = "Bikes";
		chartData.Categories[1].ChartDataCell.Value = "Accessories";
		chartData.Categories[2].ChartDataCell.Value = "Repairs";
		chartData.Categories[3].ChartDataCell.Value = "Clothing";
		//Modifierar diagramseriens värden för första kategori
		chartData.Series[0].Values[0].Value = 1000;
		chartData.Series[0].Values[1].Value = 2500;
		chartData.Series[0].Values[2].Value = 4000;
		chartData.Series[0].Values[3].Value = 3000;
		//Ställer in diagramrubrik
		ppChart.HasTitle = true;
		ppChart.ChartTitle.Text.Text = "2007 Sales";
		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;
		format.FontItalic = NullableBool.True;
		format.FontHeight = 18;
		format.FillFormat.FillType = FillTypeEx.Solid;
		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Ställer in axelvärden
		ppChart.ValueAxis.IsAutomaticMaxValue = false;
		ppChart.ValueAxis.IsAutomaticMinValue = false;
		ppChart.ValueAxis.IsAutomaticMajorUnit = false;
		ppChart.ValueAxis.IsAutomaticMinorUnit = false;
		ppChart.ValueAxis.MaxValue = 4000.0F;
		ppChart.ValueAxis.MinValue = 0.0F;
		ppChart.ValueAxis.MajorUnit = 2000.0F;
		ppChart.ValueAxis.MinorUnit = 1000.0F;
		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;
		//Ställer in diagramrotation
		ppChart.Rotation3D.RotationX = 15;
		ppChart.Rotation3D.RotationY = 20;
		//Sparar presentationen
		pres.Write("AsposeSampleChart.pptx");
	}
}
``` 
## **Download Sample Code**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)