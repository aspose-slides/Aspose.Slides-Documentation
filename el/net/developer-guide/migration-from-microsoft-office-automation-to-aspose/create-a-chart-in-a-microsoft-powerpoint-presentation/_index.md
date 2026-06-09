---
title: Δημιουργία διαγραμμάτων χρησιμοποιώντας VSTO και Aspose.Slides για .NET
linktitle: Δημιουργία διαγράμματος
type: docs
weight: 80
url: /el/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- δημιουργία διαγράμματος
- μετανάστευση
- VSTO
- αυτοματοποίηση Office
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να αυτοματοποιήσετε τη δημιουργία διαγράμματος PowerPoint σε C#. Αυτός ο πλήρης οδηγός βήμα προς βήμα δείχνει γιατί το Aspose.Slides for .NET είναι μια πιο γρήγορη, πιο ισχυρή εναλλακτική λύση προς Microsoft.Office.Interop."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να δημιουργήσετε και να προσαρμόσετε διαγράμματα σε παρουσιάσεις του Microsoft PowerPoint προγραμματιστικά χρησιμοποιώντας C#. Με το Aspose.Slides for .NET, μπορείτε να αυτοματοποιήσετε τη δημιουργία επαγγελματικών, δεδομένων-οδηγούμενων διαγραμμάτων χωρίς να εξαρτάστε από το Microsoft Office ή τις βιβλιοθήκες Interop. Το API παρέχει ένα πλούσιο σύνολο λειτουργιών για την κατασκευή γραμμικών διαγραμμάτων, διαγραμμάτων πίτας, διαγραμμάτων γραμμής και άλλων — όλα με πλήρη έλεγχο της εμφάνισης, των δεδομένων και της διάταξης. Είτε δημιουργείτε αναφορές, πίνακες εργαλείων ή επιχειρηματικές παρουσιάσεις, το Aspose.Slides σας βοηθά να παρέχετε υψηλής ποιότητας απεικονίσεις απευθείας από τις εφαρμογές .NET σας.

## **Παράδειγμα VSTO**

Αυτή η ενότητα δείχνει πώς να δημιουργήσετε ένα διάγραμμα σε μια παρουσίαση του Microsoft PowerPoint χρησιμοποιώντας **VSTO (Visual Studio Tools for Office)**. Με το VSTO, μπορείτε προγραμματιστικά να δημιουργήσετε και να προσαρμόσετε διαγράμματα συνδυάζοντας την αυτοματοποίηση του PowerPoint και του Excel. Το παρασχεθέν παράδειγμα δείχνει πώς να προσθέσετε ένα **3D clustered column chart**, να το γεμίσετε με δεδομένα από ένα φύλλο εργασίας του Excel, να ρυθμίσετε τη μορφοποίηση και τη διάταξη και να αποθηκεύσετε την τελική παρουσίαση — όλα από μέσα σε μια εφαρμογή .NET.

1. Δημιουργήστε ένα αντικείμενο παρουσίασης του Microsoft PowerPoint.
1. Προσθέστε μια κενή διαφάνεια στην παρουσίαση.
1. Προσθέστε ένα 3D clustered column chart και αποκτήστε πρόσβαση σε αυτό.
1. Δημιουργήστε ένα νέο αντικείμενο βιβλίου του Microsoft Excel και φορτώστε τα δεδομένα του διαγράμματος.
1. Αποκτήστε πρόσβαση στο φύλλο δεδομένων του διαγράμματος χρησιμοποιώντας το αντικείμενο βιβλίου του Excel.
1. Ορίστε το εύρος του διαγράμματος στο φύλλο και αφαιρέστε τις σειρές 2 και 3 από το διάγραμμα.
1. Τροποποιήστε τα δεδομένα κατηγοριών του διαγράμματος στο φύλλο δεδομένων του διαγράμματος.
1. Τροποποιήστε τα δεδομένα της σειράς 1 στο φύλλο δεδομένων του διαγράμματος.
1. Αποκτήστε πρόσβαση στον τίτλο του διαγράμματος και ορίστε τις ιδιότητες της γραμματοσειράς του.
1. Αποκτήστε πρόσβαση στον άξονα τιμών του διαγράμματος και ορίστε τη βασική μονάδα, τη δευτερεύουσα μονάδα, τη μέγιστη τιμή και τη ελάχιστη τιμή.
1. Αποκτήστε πρόσβαση στον άξονα βάθους (σειράς) του διαγράμματος και αφαιρέστε τον — χρησιμοποιείται μόνο μια σειρά σε αυτό το παράδειγμα.
1. Ορίστε τις γωνίες περιστροφής του διαγράμματος στις κατευθύνσεις X και Y.
1. Αποθηκεύστε την παρουσίαση.
1. Κλείστε τα αντικείμενα Microsoft Excel και PowerPoint.

```c#
EnsurePowerPointIsRunning(true, true);

// Δημιουργήστε ένα αντικείμενο διαφάνειας.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Πρόσβαση στην πρώτη διαφάνεια της παρουσίασης.
objSlide = objPres.Slides[1];

// Επιλέξτε την πρώτη διαφάνεια και ορίστε τη διάταξή της.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Προσθέστε ένα προεπιλεγμένο διάγραμμα στη διαφάνεια.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Πρόσβαση στο προστιθέμενο διάγραμμα.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Πρόσβαση στα δεδομένα του διαγράμματος.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Δημιουργήστε ένα αντικείμενο βιβλίου Excel για εργασία με τα δεδομένα του διαγράμματος.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Πρόσβαση στο φύλλο δεδομένων για το διάγραμμα.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Ορίστε το εύρος δεδομένων για το διάγραμμα.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Εφαρμόστε το καθορισμένο εύρος στον πίνακα δεδομένων του διαγράμματος.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Ορίστε τιμές για τις κατηγορίες και τα αντίστοιχα δεδομένα σειρών.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Ορισμός τίτλου του διαγράμματος.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Πρόσβαση στον άξονα τιμών του διαγράμματος.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Ορίστε τις τιμές για τις μονάδες του άξονα.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Πρόσβαση στον άξονα βάθους του διαγράμματος.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Ορισμός περιστροφής του διαγράμματος.
ppChart.Rotation = 20;   // Τιμή-Υ
ppChart.Elevation = 15;  // Τιμή-Χ
ppChart.RightAngleAxes = false;

// Αποθήκευση της παρουσίασης ως αρχείο PPTX.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Κλείσιμο του βιβλίου εργασίας και της παρουσίασης.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
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

    // Δοκιμάστε να προσπελάσετε την ιδιότητα Name. Αν ρίξει εξαίρεση, εκκινήστε μια νέα παρουσίαση του PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // Το blnAddPresentation χρησιμοποιείται για να εξασφαλιστεί ότι έχει φορτωθεί μια παρουσίαση.
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

    // Το blnAddSlide χρησιμοποιείται για να εξασφαλιστεί ότι υπάρχει τουλάχιστον μία διαφάνεια στην παρουσίαση.
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

Το αποτέλεσμα:

![Το διάγραμμα που δημιουργήθηκε με χρήση VSTO](chart-created-using-VSTO.png)

## **Παράδειγμα Aspose.Slides for .NET**

Το παρακάτω παράδειγμα δείχνει πώς να δημιουργήσετε ένα απλό διάγραμμα σε μια παρουσίαση PowerPoint χρησιμοποιώντας Aspose.Slides for .NET. Αυτός ο κώδικας επιδεικνύει πώς να προσθέσετε ένα **3D clustered column chart**, να το γεμίσετε με δείγμα δεδομένων και να προσαρμόσετε την εμφάνισή του. Με μόνο μερικές γραμμές κώδικα, μπορείτε να δημιουργήσετε διαγράμματα δυναμικά και να τα ενσωματώσετε στις παρουσιάσεις σας χωρίς να χρησιμοποιήσετε το Microsoft Office.

1. Δημιουργήστε ένα αντικείμενο της κλάσης [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/).
1. Αποκτήστε μια αναφορά στην πρώτη διαφάνεια.
1. Προσθέστε ένα 3D clustered column chart και αποκτήστε πρόσβαση σε αυτό.
1. Αποκτήστε πρόσβαση στα δεδομένα του διαγράμματος.
1. Αφαιρέστε τις αχρησιμοποίητες Series 2 και Series 3.
1. Τροποποιήστε τις κατηγορίες του διαγράμματος ενημερώνοντας τις ετικέτες.
1. Ενημερώστε τις τιμές της Series 1.
1. Αποκτήστε πρόσβαση στον τίτλο του διαγράμματος και ορίστε τις ιδιότητες της γραμματοσειράς του.
1. Διαμορφώστε τον άξονα τιμών του διαγράμματος, συμπεριλαμβανομένων της βασικής μονάδας, της δευτερεύουσας μονάδας, των μέγιστων και ελάχιστων τιμών.
1. Ορίστε τις γωνίες περιστροφής του διαγράμματος στους άξονες X και Y.
1. Αποθηκεύστε την παρουσίαση σε μορφή PPTX.

```cs
// Δημιουργήστε μια κενή παρουσίαση.
using (Presentation presentation = new Presentation())
{
    // Πρόσβαση στην πρώτη διαφάνεια.
    ISlide slide = presentation.Slides[0];

    // Προσθήκη προεπιλεγμένου διαγράμματος.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Λήψη των δεδομένων του διαγράμματος.
    IChartData chartData = chart.ChartData;

    // Αφαίρεση των επιπλέον προεπιλεγμένων σειρών.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Τροποποίηση των ονομάτων κατηγοριών του διαγράμματος.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Ορισμός του δείκτη του φύλλου εργασίας δεδομένων του διαγράμματος.
    int worksheetIndex = 0;

    // Λήψη του βιβλίου εργασίας δεδομένων του διαγράμματος.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Τροποποίηση των τιμών των σειρών του διαγράμματος.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Ορισμός του τίτλου του διαγράμματος.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Ορισμός των επιλογών του άξονα.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Ορισμός της περιστροφής του διαγράμματος.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Αποθήκευση της παρουσίασης ως αρχείο PPTX.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

Το αποτέλεσμα:

![Το διάγραμμα που δημιουργήθηκε με χρήση Aspose.Slides for .NET](chart-created-using-aspose-slides.png)

## **Συχνές Ερωτήσεις**

**Μπορώ να δημιουργήσω άλλους τύπους διαγραμμάτων όπως πίτες, γραμμές ή ράβδους με το Aspose.Slides;**

Ναι. Το Aspose.Slides for .NET υποστηρίζει μια ευρεία γκάμα [τύπων διαγραμμάτων](/slides/el/net/create-chart/), συμπεριλαμβανομένων διαγραμμάτων πίτας, διαγραμμάτων γραμμής, ραβδωτών διαγραμμάτων, scatter plots, bubble charts και άλλων. Μπορείτε να καθορίσετε τον επιθυμητό τύπο διαγράμματος χρησιμοποιώντας την απαρίθμηση [ChartType](https://reference.aspose.com/slides/el/net/aspose.slides.charts/charttype/) όταν προσθέτετε ένα διάγραμμα.

**Μπορώ να εφαρμόσω προσαρμοσμένα στυλ ή θέματα στο διάγραμμα;**

Ναι. Μπορείτε να προσαρμόσετε πλήρως την εμφάνιση του διαγράµματος, συμπεριλαμβανομένων χρωμάτων, γραμματοσειρών, γεμισμάτων, περιγραμμάτων, γραμμών πλέγματος και διάταξης. Ωστόσο, η εφαρμογή θεμάτων Office ακριβώς όπως εμφανίζονται στο PowerPoint απαιτεί χειροκίνητη ρύθμιση των επιμέρους στυλ.

**Μπορώ να εξάγω το διάγραμμα ως εικόνα ξεχωριστά από τη διαφάνεια;**

Ναι, το Aspose.Slides σας επιτρέπει να εξάγετε οποιοδήποτε σχήμα —συμπεριλαμβανομένων διαγραμμάτων— ως ξεχωριστή εικόνα (π.χ., PNG, JPEG) χρησιμοποιώντας τη μέθοδο `GetImage` στο [σχήμα](https://reference.aspose.com/slides/el/net/aspose.slides/ishape/) του διαγράμματος.