---
title: Δημιουργία γραφήματος
type: docs
weight: 60
url: /el/net/create-a-chart/
---
Τα παραδείγματα κώδικα παρακάτω περιγράφουν τη διαδικασία προσθήκης ενός απλού 3D ομάδοποιημένου γραφήματος στηλών χρησιμοποιώντας VSTO. Δημιουργείτε ένα στιγμιότυπο παρουσίασης, προσθέτετε ένα προεπιλεγμένο γράφημα σε αυτήν. Στη συνέχεια χρησιμοποιείτε το βιβλίο εργασίας Microsoft Excel για να έχετε πρόσβαση και να τροποποιήσετε τα δεδομένα του γραφήματος, μαζί με τον καθορισμό ιδιοτήτων του γραφήματος. Τέλος, αποθηκεύετε την παρουσίαση.
## **VSTO**
Με τη χρήση του VSTO, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο παρουσίασης Microsoft PowerPoint.
1. Προσθέστε μια κενή διαφάνεια στην παρουσίαση.
1. Προσθέστε ένα 3D ομάδοποιημένο γράφημα στηλών και αποκτήστε πρόσβαση σε αυτό.
1. Δημιουργήστε ένα νέο στιγμιότυπο Microsoft Excel Workbook και φορτώστε τα δεδομένα του γραφήματος.
1. Αποκτήστε πρόσβαση στο φύλλο δεδομένων του γραφήματος χρησιμοποιώντας το στιγμιότυπο Microsoft Excel Workbook.
1. Ορίστε το εύρος του γραφήματος στο φύλλο και αφαιρέστε τις σειρές 2 και 3 από το γράφημα.
1. Τροποποιήστε τα δεδομένα κατηγοριών του γραφήματος στο φύλλο δεδομένων.
1. Τροποποιήστε τα δεδομένα της σειράς 1 του γραφήματος στο φύλλο δεδομένων.
1. Τώρα, αποκτήστε πρόσβαση στον τίτλο του γραφήματος και ορίστε τις ιδιότητες της γραμματοσειράς.
1. Αποκτήστε πρόσβαση στον άξονα τιμών του γραφήματος και ορίστε τη βασική μονάδα, τις δευτερεύουσες μονάδες, τη μέγιστη τιμή και τις ελάχιστες τιμές.
1. Αποκτήστε πρόσβαση στο βάθος του γραφήματος ή στον άξονα σειρών και αφαιρέστε το, καθώς σε αυτό το παράδειγμα χρησιμοποιείται μόνο μία σειρά.
1. Τώρα, ορίστε τις γωνίες περιστροφής του γραφήματος στις κατευθύνσεις X και Y.
1. Αποθηκεύστε την παρουσίαση.
1. Κλείστε τα στιγμιότυπα των Microsoft Excel και PowerPoint.

``` csharp

 //Καθολικές μεταβλητές

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Δημιουργία αντικειμένου διαφάνειας

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης

	objSlide = objPres.Slides[1];

	//Επιλογή της πρώτης διαφάνειας και καθορισμός της διάταξής της

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Προσθήκη προεπιλεγμένου γραφήματος στη διαφάνεια

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Πρόσβαση στο προστιθέμενο γράφημα

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Πρόσβαση στα δεδομένα του γραφήματος

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Δημιουργία στιγμιότυπου βιβλίου εργασίας Excel για εργασία με τα δεδομένα του γραφήματος

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Πρόσβαση στο φύλλο εργασίας δεδομένων για το γράφημα

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Ορισμός του εύρους του γραφήματος

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Εφαρμογή του ορισμένου εύρους στον πίνακα δεδομένων του γραφήματος

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Ορισμός τιμών για τις κατηγορίες και τα αντίστοιχα δεδομένα σειράς

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Ορισμός τίτλου γραφήματος

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Πρόσβαση στον άξονα τιμών του γραφήματος

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Ορισμός μονάδων άξονα τιμών

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Πρόσβαση στον άξονα βάθους του γραφήματος

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Ορισμός περιστροφής γραφήματος

	ppChart.Rotation = 20; //Τιμή Y

	ppChart.Elevation = 15; //Τιμή X

	ppChart.RightAngleAxes = false;

	// Αποθήκευση της παρουσίασης ως PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Κλείσιμο του βιβλίου εργασίας και της παρουσίασης

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

	//Δοκιμή πρόσβασης στην ιδιότητα Name. Εάν προκαλέσει εξαίρεση τότε

	//δημιουργία νέου στιγμιότυπου PowerPoint

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation χρησιμοποιείται για να διασφαλίσει ότι υπάρχει φορτωμένη παρουσίαση

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

	//blnAddSlide χρησιμοποιείται για να διασφαλίσει ότι υπάρχει τουλάχιστον μια διαφάνεια στο

	//παρουσίαση

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
Χρησιμοποιώντας το Aspose.Slides για .NET, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε ένα στιγμιότυπο παρουσίασης Microsoft PowerPoint.
1. Προσθέστε μια κενή διαφάνεια στην παρουσίαση.
1. Προσθέστε ένα 3D ομάδοποιημένο γράφημα στηλών και αποκτήστε πρόσβαση σε αυτό.
1. Αποκτήστε πρόσβαση στο φύλλο δεδομένων του γραφήματος χρησιμοποιώντας ένα στιγμιότυπο Microsoft Excel Workbook.
1. Αφαιρέστε τις αχρησιμοποίητες σειρές 2 και 3.
1. Αποκτήστε πρόσβαση στις κατηγορίες του γραφήματος και τροποποιήστε τις ετικέτες.
1. Αποκτήστε πρόσβαση στη σειρά 1 και τροποποιήστε τις τιμές της σειράς.
1. Τώρα, αποκτήστε πρόσβαση στον τίτλο του γραφήματος και ορίστε τις ιδιότητες της γραμματοσειράς.
1. Αποκτήστε πρόσβαση στον άξονα τιμών του γραφήματος και ορίστε τη βασική μονάδα, τις δευτερεύουσες μονάδες, τη μέγιστη τιμή και τις ελάχιστες τιμές.
1. Τώρα, ορίστε τις γωνίες περιστροφής του γραφήματος στις κατευθύνσεις X και Y.
1. Αποθηκεύστε την παρουσίαση σε μορφή PPTX.

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Create empty presentation
	//Δημιουργία κενής παρουσίασης

	using (PresentationEx pres = new PresentationEx())

	{

		//Accessing first slide
		//Πρόσβαση στην πρώτη διαφάνεια

		SlideEx slide = pres.Slides[0];

		//Addding default chart
		//Προσθήκη προεπιλεγμένου γραφήματος

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Getting Chart data
		//Λήψη δεδομένων γραφήματος

		ChartDataEx chartData = ppChart.ChartData;

		//Removing Extra default series
		//Αφαίρεση επιπλέον προεπιλεγμένων σειρών

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Modifying chart categories names
		//Τροποποίηση ονομάτων κατηγοριών γραφήματος

		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//Modifying chart series values for first category
		//Τροποποίηση τιμών σειράς γραφήματος για την πρώτη κατηγορία

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Setting Chart title
		//Ορισμός τίτλου γραφήματος

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Setting Axis values
		//Ορισμός τιμών άξονα

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Setting Chart rotation
		//Ορισμός περιστροφής γραφήματος

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Saving Presentation
		//Αποθήκευση παρουσίασης

		pres.Write("AsposeSampleChart.pptx");

	}

``` 
## **Λήψη Δειγματικού Κώδικα**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)