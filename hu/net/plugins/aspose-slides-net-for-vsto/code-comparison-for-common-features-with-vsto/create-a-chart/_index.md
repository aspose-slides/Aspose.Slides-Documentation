---
title: Diagram létrehozása
type: docs
weight: 60
url: /hu/net/create-a-chart/
---
Az alábbi kódrészletek leírják egy egyszerű 3D csoportos oszlopdiagram VSTO-val történő hozzáadásának folyamatát. Létrehoz egy prezentációpéldányt, hozzáad egy alapértelmezett diagramot. Ezután a Microsoft Excel munkafüzetet használja a diagram adatok elérésére és módosítására, valamint a diagram tulajdonságainak beállítására. Végül menti a prezentációt.
## **VSTO**
A VSTO használatával a következő lépések hajtódnak végre:

1. Hozzon létre egy Microsoft PowerPoint prezentációpéldányt.
1. Adjon hozzá egy üres diát a prezentációhoz.
1. Adjon hozzá egy 3D csoportos oszlopdiagramot, és nyissa meg.
1. Hozzon létre egy új Microsoft Excel munkafüzetpéldányt, és töltse be a diagram adatokat.
1. A munkafüzetből a Microsoft Excel Workbook példányt használva érje el a diagram adatlapját.
1. Állítsa be a diagram tartományát a munkalapon, és távolítsa el a 2. és 3. sorozatot a diagramról.
1. Módosítsa a diagram kategóriaadatait a diagram adatlapján.
1. Módosítsa az 1. sorozat adatait a diagram adatlapján.
1. Ezután érje el a diagram címét, és állítsa be a betűtípussal kapcsolatos tulajdonságokat.
1. Érje el a diagram értéktengelyét, és állítsa be a fő egységet, a kisebb egységeket, a maximális és minimális értékeket.
1. Érje el a diagram mélységi vagy sorozat tengelyét, és távolítsa el azt; ebben a példában csak egy sorozat van használva.
1. Ezután állítsa be a diagram forgatási szögeit X és Y irányban.
1. Mentse a prezentációt.
1. Zárja be a Microsoft Excel és PowerPoint példányokat.

``` csharp

 //Globális változók

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Diát objektum példányosítása

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//A prezentáció első diájának elérése

	objSlide = objPres.Slides[1];

	//Első dia kiválasztása és elrendezésének beállítása

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Alapértelmezett diagram hozzáadása a diára

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Hozzáadott diagram elérése

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Diagram adatainak elérése

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Excel munkafüzet példány létrehozása a diagram adatokkal való munkához

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//A diagram adatlapjának elérése

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Diagram tartományának beállítása

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Beállított tartomány alkalmazása a diagram adat táblán

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Kategóriák és a hozzájuk tartozó sorozatok adatainak beállítása

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Diagram címének beállítása

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Diagram értéktengelyének elérése

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Diagram tengely egységeinek beállítása

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Diagram mélységi tengelyének elérése

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Diagram forgatásának beállítása

	ppChart.Rotation = 20; //Y-érték

	ppChart.Elevation = 15; //X-érték

	ppChart.RightAngleAxes = false;

	// A prezentáció mentése PPTX formátumban

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Munkafüzet és a prezentáció bezárása

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

	//Próbálja elérni a name tulajdonságot. Ha kivételt dob, akkor

	//új PowerPoint példány indítása

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation arra szolgál, hogy biztosítsa, hogy egy prezentáció betöltve van

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

	//BlnAddSlide arra szolgál, hogy biztosítsa, hogy legalább egy dia van a

	//prezentációban

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
Az Aspose.Slides for .NET használatával a következő lépések hajtódnak végre:

1. Hozzon létre egy Microsoft PowerPoint prezentációpéldányt.
1. Adjon hozzá egy üres diát a prezentációhoz.
1. Adjon hozzá egy 3D csoportos oszlopdiagramot, és nyissa meg.
1. A munkafüzetből a Microsoft Excel Workbook példányt használva érje el a diagram adatlapját.
1. Távolítsa el a nem használt 2. és 3. sorozatokat.
1. Érje el a diagram kategóriákat, és módosítsa a címkéket.
1. Érje el az 1. sorozatot, és módosítsa a sorozat értékeit.
1. Ezután érje el a diagram címét, és állítsa be a betűtípus tulajdonságait.
1. Érje el a diagram értéktengelyét, és állítsa be a fő egységet, a kisebb egységeket, a maximális és minimális értékeket.
1. Ezután állítsa be a diagram forgatási szögeit X és Y irányban.
1. Mentse a prezentációt PPTX formátumban.

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Üres prezentáció létrehozása

	using (PresentationEx pres = new PresentationEx())

	{

		//Az első dia elérése

		SlideEx slide = pres.Slides[0];

		//Alapértelmezett diagram hozzáadása

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Diagram adatainak lekérése

		ChartDataEx chartData = ppChart.ChartData;

		//Felesleges alapértelmezett sorozatok eltávolítása

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Diagram kategória nevek módosítása

		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//Diagram sorozat értékek módosítása az első kategóriához

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Diagram címének beállítása

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Tengely értékek beállítása

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Diagram forgatásának beállítása

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Prezentáció mentése

		pres.Write("AsposeSampleChart.pptx");

	}

}
``` 
## **Minta kód letöltése**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)