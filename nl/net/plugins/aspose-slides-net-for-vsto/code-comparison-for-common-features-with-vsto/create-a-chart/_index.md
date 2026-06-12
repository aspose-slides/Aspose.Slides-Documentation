---
title: Maak een grafiek
type: docs
weight: 60
url: /nl/net/create-a-chart/
---
De onderstaande codevoorbeelden beschrijven het proces van het toevoegen van een eenvoudige 3D gegroepeerde kolomgrafiek met VSTO. U maakt een presentatie‑instantie aan, voegt er een standaardgrafiek aan toe. Vervolgens gebruikt u een Microsoft Excel‑werkmap om de grafiekgegevens te benaderen en te wijzigen, evenals de grafiekeigenschappen in te stellen. Ten slotte slaat u de presentatie op.

## **VSTO**
Using VSTO, the following steps are performed:

1. Maak een instantie van een Microsoft PowerPoint‑presentatie aan.
1. Voeg een lege dia toe aan de presentatie.
1. Voeg een 3D gegroepeerde kolomgrafiek toe en benader deze.
1. Maak een nieuwe Microsoft Excel‑werkmap‑instantie aan en laad de grafiekgegevens.
1. Benader het werkblad met grafiekgegevens via de Microsoft Excel‑werkmap‑instantie.
1. Stel het grafiekbereik in op het werkblad in en verwijder reeks 2 en 3 uit de grafiek.
1. Wijzig de categorie‑gegevens van de grafiek in het werkblad met grafiekgegevens.
1. Wijzig de gegevens van reeks 1 van de grafiek in het werkblad met grafiekgegevens.
1. Benader nu de grafiektitel en stel de lettertype‑gerelateerde eigenschappen in.
1. Benader de waardenas van de grafiek en stel de hoofd‑eenheid, sub‑eenheden, maximale en minimale waarden in.
1. Benader de diepte‑ of reeksenas en verwijder deze, want in dit voorbeeld wordt slechts één reeks gebruikt.
1. Stel nu de rotatiehoeken van de grafiek in X‑ en Y‑richting in.
1. Sla de presentatie op.
1. Sluit de instanties van Microsoft Excel en PowerPoint.

``` csharp

 //Globale variabelen

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Instantieer diaobject

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Benader de eerste dia van de presentatie

	objSlide = objPres.Slides[1];

	//Selecteer de eerste dia en stel de lay-out in

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Voeg een standaardgrafiek toe aan de dia

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Benader de toegevoegde grafiek

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Benader de grafiekgegevens

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Maak een instantie van een Excel-werkmap om met grafiekgegevens te werken

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Benader het gegevenswerkblad voor de grafiek

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Instellen van het bereik van de grafiek

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Pas het ingestelde bereik toe op de grafiekdatatabel

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Instellen van waarden voor categorieën en respectieve seriedata

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Instellen van de grafiektitel

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Benaderen van de waardenas van de grafiek

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Instellen van eenheden voor de waardenas

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Benaderen van de diepte-as van de grafiek

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Instellen van de grafiekrotatie

	ppChart.Rotation = 20; //Y-waarde

	ppChart.Elevation = 15; //X-waarde

	ppChart.RightAngleAxes = false;

	// Sla de presentatie op als een PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Sluit werkmap en presentatie

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

	//Probeer de naam‑eigenschap te benaderen. Als dit een uitzondering veroorzaakt

	//start een nieuwe instantie van PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation wordt gebruikt om te zorgen dat er een presentatie geladen is

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

	//BlnAddSlide wordt gebruikt om te zorgen dat er minstens één dia in de

	//presentatie

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

1. Maak een instantie van een Microsoft PowerPoint‑presentatie aan.
1. Voeg een lege dia toe aan de presentatie.
1. Voeg een 3D gegroepeerde kolomgrafiek toe en benader deze.
1. Benader het werkblad met grafiekgegevens via een Microsoft Excel‑werkmap‑instantie.
1. Verwijder ongebruikte reeksen 2 en 3.
1. Benader de grafiekcategorieën en wijzig de labels.
1. Benader reeks 1 en wijzig de reekswerwaarden.
1. Benader nu de grafiektitel en stel de lettertype‑eigenschappen in.
1. Benader de waardenas van de grafiek en stel de hoofd‑eenheid, sub‑eenheden, maximale en minimale waarden in.
1. Stel nu de rotatiehoeken van de grafiek in X‑ en Y‑richting in.
1. Sla de presentatie op in PPTX‑formaat.

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Lege presentatie maken

	using (PresentationEx pres = new PresentationEx())

	{

		//Eerste dia benaderen

		SlideEx slide = pres.Slides[0];

		//Standaardgrafiek toevoegen

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Grafiekgegevens ophalen

		ChartDataEx chartData = ppChart.ChartData;

		//Extra standaardreeksen verwijderen

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Grafiekcategoriënamen wijzigen

		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//Grafiekseriewaarden voor eerste categorie wijzigen

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Grafiektitel instellen

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Aswaarden instellen

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Grafiekrotatie instellen

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Presentatie opslaan

		pres.Write("AsposeSampleChart.pptx");

	}

}
``` 
## **Download Sample Code**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)