---
title: Vytvořit graf
type: docs
weight: 60
url: /cs/net/create-a-chart/
---
Níže uvedené ukázky kódu popisují proces přidání jednoduchého 3D seskupeného sloupcového grafu pomocí VSTO. Vytvoříte instanci prezentace, přidáte do ní výchozí graf. Pak použijete sešit Microsoft Excel k přístupu a úpravě dat grafu a také k nastavení vlastností grafu. Nakonec prezentaci uložíte.

## **VSTO**
Při použití VSTO jsou provedeny následující kroky:

1. Vytvořte instanci prezentace Microsoft PowerPoint.  
1. Přidejte do prezentace prázdný snímek.  
1. Přidejte 3D seskupený sloupcový graf a získáte k němu přístup.  
1. Vytvořte novou instanci sešitu Microsoft Excel a načtěte data grafu.  
1. Získáte přístup k listu s daty grafu pomocí instance sešitu Microsoft Excel.  
1. Nastavte oblast grafu v listu a odstraňte řady 2 a 3 z grafu.  
1. Upravte data kategorií grafu v listu s daty grafu.  
1. Upravte data řady 1 v listu s daty grafu.  
1. Nyní získejte přístup k názvu grafu a nastavte vlastnosti písma.  
1. Získejte přístup k ose hodnot grafu a nastavte hlavní jednotku, vedlejší jednotky, maximální a minimální hodnotu.  
1. Získejte přístup k ose hloubky nebo sériové ose a odstraňte ji, protože v tomto příkladu je použita pouze jedna řada.  
1. Nyní nastavte úhly rotace grafu ve směru X a Y.  
1. Uložte prezentaci.  
1. Uzavřete instance Microsoft Excel a PowerPoint.

``` csharp

 //Globální proměnné

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);
	//Vytvořit objekt snímku
	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
	//Získejte přístup k prvnímu snímku prezentace
	objSlide = objPres.Slides[1];
	//Vyberte první snímek a nastavte jeho rozložení
	objSlide.Select();
	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;
	//Přidejte výchozí graf do snímku
	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);
	//Získejte přístup k přidanému grafu
	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;
	//Získejte přístup k datům grafu
	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;
	//Vytvořte instanci sešitu Excel pro práci s daty grafu
	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;
	//Přístup k listu s daty grafu
	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];
	//Nastavení oblasti grafu
	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");
	//Aplikace nastavené oblasti na tabulku dat grafu
	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
	tbl1.Resize(tRange);
	//Nastavení hodnot pro kategorie a příslušná data řad
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";
	//Nastavení názvu grafu
	ppChart.ChartTitle.Font.Italic = true;
	ppChart.ChartTitle.Text = "2007 Sales";
	ppChart.ChartTitle.Font.Size = 18;
	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();
	//Přístup k ose hodnot grafu
	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
	//Nastavení jednotek osy hodnot
	valaxis.MajorUnit = 2000.0F;
	valaxis.MinorUnit = 1000.0F;
	valaxis.MinimumScale = 0.0F;
	valaxis.MaximumScale = 4000.0F;
	//Přístup k ose hloubky grafu
	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
	Depthaxis.Delete();
	//Nastavení rotace grafu
	ppChart.Rotation = 20; //Y‑hodnota
	ppChart.Elevation = 15; //X‑hodnota
	ppChart.RightAngleAxes = false;
	//Uložení prezentace jako PPTX
	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
	//Zavřít sešit a prezentaci
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

	//Zkuste získat vlastnost name. Pokud způsobí výjimku, pak
	//spusťte novou instanci PowerPointu
	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation se používá k zajištění, že je načtena prezentace
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

	//BlnAddSlide se používá k zajištění, že existuje alespoň jeden snímek v
	//prezentaci
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
Při použití Aspose.Slides pro .NET jsou provedeny následující kroky:

1. Vytvořte instanci prezentace Microsoft PowerPoint.  
1. Přidejte do prezentace prázdný snímek.  
1. Přidejte 3D seskupený sloupcový graf a získáte k němu přístup.  
1. Získáte přístup k listu s daty grafu pomocí instance sešitu Microsoft Excel.  
1. Odstraňte nepoužívané řady 2 a 3.  
1. Získejte přístup ke kategoriím grafu a upravte popisky.  
1. Získejte přístup k řadě 1 a upravte její hodnoty.  
1. Nyní získejte přístup k názvu grafu a nastavte vlastnosti písma.  
1. Získejte přístup k ose hodnot grafu a nastavte hlavní jednotku, vedlejší jednotky, maximální a minimální hodnotu.  
1. Nyní nastavte úhly rotace grafu ve směru X a Y.  
1. Uložte prezentaci do formátu PPTX.

``` csharp

 public static void GEN_ASPOSE_Chart()
{
	//Vytvořit prázdnou prezentaci
	using (PresentationEx pres = new PresentationEx())
	{
		//Přístup k prvnímu snímku
		SlideEx slide = pres.Slides[0];
		//Přidání výchozího grafu
		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);
		//Získání dat grafu
		ChartDataEx chartData = ppChart.ChartData;
		//Odstranění nadbytečných výchozích řad
		chartData.Series.RemoveAt(1);
		chartData.Series.RemoveAt(1);
		//Úprava názvů kategorií grafu
		chartData.Categories[0].ChartDataCell.Value = "Bikes";
		chartData.Categories[1].ChartDataCell.Value = "Accessories";
		chartData.Categories[2].ChartDataCell.Value = "Repairs";
		chartData.Categories[3].ChartDataCell.Value = "Clothing";
		//Úprava hodnot řady grafu pro první kategorii
		chartData.Series[0].Values[0].Value = 1000;
		chartData.Series[0].Values[1].Value = 2500;
		chartData.Series[0].Values[2].Value = 4000;
		chartData.Series[0].Values[3].Value = 3000;
		//Nastavení názvu grafu
		ppChart.HasTitle = true;
		ppChart.ChartTitle.Text.Text = "2007 Sales";
		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;
		format.FontItalic = NullableBool.True;
		format.FontHeight = 18;
		format.FillFormat.FillType = FillTypeEx.Solid;
		format.FillFormat.SolidFillColor.Color = Color.Black;

		//Nastavení hodnot osy
		ppChart.ValueAxis.IsAutomaticMaxValue = false;
		ppChart.ValueAxis.IsAutomaticMinValue = false;
		ppChart.ValueAxis.IsAutomaticMajorUnit = false;
		ppChart.ValueAxis.IsAutomaticMinorUnit = false;
		ppChart.ValueAxis.MaxValue = 4000.0F;
		ppChart.ValueAxis.MinValue = 0.0F;
		ppChart.ValueAxis.MajorUnit = 2000.0F;
		ppChart.ValueAxis.MinorUnit = 1000.0F;
		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;
		//Nastavení rotace grafu
		ppChart.Rotation3D.RotationX = 15;
		ppChart.Rotation3D.RotationY = 20;
		//Uložení prezentace
		pres.Write("AsposeSampleChart.pptx");
	}
}
``` 
## **Stáhnout ukázkový kód**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)