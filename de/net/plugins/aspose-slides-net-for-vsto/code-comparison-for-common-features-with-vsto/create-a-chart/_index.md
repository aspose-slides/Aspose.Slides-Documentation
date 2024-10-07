---
title: Erstellt ein Diagramm
type: docs
weight: 60
url: /net/create-a-chart/
---

Die folgenden Codebeispiele beschreiben den Prozess, ein einfaches 3D gruppiertes Säulendiagramm mit VSTO hinzuzufügen. Sie erstellen eine Präsentationsinstanz, fügen ein Standarddiagramm hinzu. Dann verwenden Sie die Microsoft Excel-Arbeitsmappe, um auf die Diagrammdaten zuzugreifen und diese zu ändern sowie die Diagrammeigenschaften festzulegen. Schließlich speichern Sie die Präsentation.
## **VSTO**
Mit VSTO werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint-Präsentation.
1. Fügen Sie eine leere Folie zur Präsentation hinzu.
1. Fügen Sie ein 3D gruppiertes Säulendiagramm hinzu und greifen Sie darauf zu.
1. Erstellen Sie eine neue Microsoft Excel-Arbeitsmappeninstanz und laden Sie die Diagrammdaten.
1. Greifen Sie auf das Diagrammdatenarbeitsblatt über die Microsoft Excel-Arbeitsmappeninstanz zu.
1. Legen Sie den Diagrammbereich im Arbeitsblatt fest und entfernen Sie die Serien 2 und 3 aus dem Diagramm.
1. Ändern Sie die Kategoriedaten des Diagramms im Diagrammdatenarbeitsblatt.
1. Ändern Sie die Daten der Diagrammserie 1 im Diagrammdatenarbeitsblatt.
1. Greifen Sie nun auf den Diagrammtitel zu und legen Sie die Schriftart-bezogenen Eigenschaften fest.
1. Greifen Sie auf die Wertachse des Diagramms zu und legen Sie die Haupt- und Nebenwerte, den Maximal- und Minimalwert fest.
1. Greifen Sie auf die Tiefen- oder Serienachse des Diagramms zu und entfernen Sie diese, da in diesem Beispiel nur eine Serie verwendet wird.
1. Legen Sie nun die Rotationswinkel des Diagramms in X- und Y-Richtung fest.
1. Speichern Sie die Präsentation.
1. Schließen Sie die Instanzen von Microsoft Excel und PowerPoint.

``` csharp

 //Globale Variablen

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Instanziiere das Folienobjekt

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Greifen Sie auf die erste Folie der Präsentation zu

	objSlide = objPres.Slides[1];

	//Wählen Sie die erste Folie aus und legen Sie ihr Layout fest

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Fügen Sie ein Standarddiagramm in die Folie ein

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Greifen Sie auf das hinzugefügte Diagramm zu

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Greifen Sie auf die Diagrammdaten zu

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Erstellen Sie eine Instanz der Excel-Arbeitsmappe, um mit den Diagrammdaten zu arbeiten

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Zugriff auf das Datenarbeitsblatt für das Diagramm

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Festlegen des Bereichs des Diagramms

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Anwenden des festgelegten Bereichs auf die Diagrammdaten

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Festlegen der Werte für Kategorien und entsprechende Seriendaten

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Fahrräder";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Zubehör";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Reparaturen";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Kleidung";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Festlegen des Diagrammtitels

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "Verkäufe 2007";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Zugriff auf die Wertachse des Diagramms

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Festlegen der Werte für die Achsen

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Zugriff auf die Tiefenachse des Diagramms

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Festlegen der Diagrammrotation

	ppChart.Rotation = 20; //Y-Wert

	ppChart.Elevation = 15; //X-Wert

	ppChart.RightAngleAxes = false;

	// Speichern Sie die Präsentation als PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Schließen Sie die Arbeitsmappe und die Präsentation

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//Zusätzliche Methoden

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

	//Versuchen Sie, auf die Namenseigenschaft zuzugreifen. Wenn dies eine Ausnahme verursacht,

	//starten Sie eine neue Instanz von PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation wird verwendet, um sicherzustellen, dass eine Präsentation geladen ist

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

	//BlnAddSlide wird verwendet, um sicherzustellen, dass sich mindestens eine Folie in der

	//Präsentation befindet

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

``` 
## **Aspose.Slides**
Mit Aspose.Slides für .NET werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint-Präsentation.
1. Fügen Sie eine leere Folie zur Präsentation hinzu.
1. Fügen Sie ein 3D gruppiertes Säulendiagramm hinzu und greifen Sie darauf zu.
1. Greifen Sie auf das Diagrammdatenarbeitsblatt über eine Microsoft Excel-Arbeitsmappeninstanz zu.
1. Entfernen Sie die ungenutzten Serien 2 und 3.
1. Greifen Sie auf die Diagrammkategorien zu und ändern Sie die Beschriftungen.
1. Greifen Sie auf die Serie 1 zu und ändern Sie die Serienwerte.
1. Greifen Sie nun auf den Diagrammtitel zu und legen Sie die Schriftarteigenschaften fest.
1. Greifen Sie auf die Wertachse des Diagramms zu und legen Sie die Haupt- und Nebenwerte, den Maximal- und Minimalwert fest.
1. Legen Sie nun die Rotationswinkel des Diagramms in X- und Y-Richtung fest.
1. Speichern Sie die Präsentation im PPTX-Format.

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Erstellen Sie eine leere Präsentation

	using (PresentationEx pres = new PresentationEx())

	{

		//Zugriff auf die erste Folie

		SlideEx slide = pres.Slides[0];

		//Hinzufügen des Standarddiagramms

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Diagrammdaten abrufen

		ChartDataEx chartData = ppChart.ChartData;

		//Entfernen zusätzlicher Standardserien

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Ändern der Namen der Diagrammkategorien

		chartData.Categories[0].ChartDataCell.Value = "Fahrräder";

		chartData.Categories[1].ChartDataCell.Value = "Zubehör";

		chartData.Categories[2].ChartDataCell.Value = "Reparaturen";

		chartData.Categories[3].ChartDataCell.Value = "Kleidung";

		//Ändern der Diagrammserienwerte für die erste Kategorie

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Festlegen des Diagrammtitels

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "Verkäufe 2007";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Festlegen der Achswerte

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Festlegen der Diagrammrotation

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Speichern der Präsentation

		pres.Write("AsposeSampleChart.pptx");

	}

``` 
## **Beispielcode herunterladen**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772948)
- [Github](https://github.com/asposemarketplace/Aspose_for_VSTO/releases/download/3/Create.a.Chart.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20Chart%20\(Aspose.Slides\).zip)