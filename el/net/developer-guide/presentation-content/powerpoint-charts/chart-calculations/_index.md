---
title: Βελτιστοποίηση Υπολογισμών Διαγραμμάτων για Παρουσιάσεις σε .NET
linktitle: Υπολογισμοί Διαγραμμάτων
type: docs
weight: 50
url: /el/net/chart-calculations/
keywords:
- υπολογισμοί διαγραμμάτων
- στοιχεία διαγράμματος
- θέση στοιχείου
- πραγματική θέση
- θυγατρικό στοιχείο
- γονικό στοιχείο
- τιμές διαγράμματος
- πραγματική τιμή
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Κατανοήστε τους υπολογισμούς διαγράμματος, τις ενημερώσεις δεδομένων και τον έλεγχο ακρίβειας στο Aspose.Slides for .NET για PPT και PPTX, με πρακτικά παραδείγματα κώδικα C#."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει API για εργασία με υπολογισμούς διαγραμμάτων και δεδομένα διάταξης σε παρουσιάσεις. Αυτό το άρθρο δείχνει πώς να ανακτήσετε τις πραγματικές τιμές των στοιχείων του διαγράμματος, συμπεριλαμβανομένης της πραγματικής θέσης και του μεγέθους των στοιχείων που υλοποιούν το `IActualLayout` και των πραγματικών τιμών των αξόνων του διαγράμματος. Εξηγεί επίσης ότι αυτές οι τιμές γεμίζουν μετά την επικύρωση της διάταξης του διαγράμματος.

Επιπλέον, το άρθρο επιδεικνύει πώς να λάβετε τη πραγματική θέση των γονικών στοιχείων του διαγράμματος και πώς να κρύψετε στοιχεία του διαγράμματος όπως ο τίτλος, οι άξονες, η υπόμνηση και οι γραμμές πλέγματος. Μαζί, αυτά τα παραδείγματα σας βοηθούν να εξετάσετε τις πληροφορίες διάταξης του διαγράμματος και να ελέγξετε την ορατότητα των στοιχείων του διαγράμματος σε παρουσιάσεις PowerPoint προγραμματιστικά.

## **Υπολογισμός Πραγματικών Τιμών Στοιχείων Διαγράμματος**
Το Aspose.Slides for .NET παρέχει ένα απλό API για την λήψη αυτών των ιδιοτήτων. Αυτό θα σας βοηθήσει να υπολογίσετε τις πραγματικές τιμές των στοιχείων του διαγράμματος. Οι πραγματικές τιμές περιλαμβάνουν τη θέση των στοιχείων που υλοποιούν τη διεπαφή IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) και τις πραγματικές τιμές των αξόνων (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Αποθήκευση παρουσίασης
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```



## **Υπολογισμός Πραγματικής Θέσης Γονικών Στοιχείων Διαγράμματος**
Το Aspose.Slides for .NET παρέχει ένα απλό API για την λήψη αυτών των ιδιοτήτων. Οι ιδιότητες του IActualLayout παρέχουν πληροφορίες για τη πραγματική θέση του γονικού στοιχείου του διαγράμματος. Είναι απαραίτητο να καλέσετε τη μέθοδο IChart.ValidateChartLayout() προηγουμένως για να γεμίσετε τις ιδιότητες με τις πραγματικές τιμές.

```c#
// Δημιουργία κενής παρουσίασης
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```



## **Απόκρυψη Στοιχείων Διαγράμματος**
Αυτό το θέμα σας βοηθά να κατανοήσετε πώς να κρύψετε πληροφορίες από το διάγραμμα. Χρησιμοποιώντας το Aspose.Slides for .NET μπορείτε να κρύψετε **Τίτλο, Κατακόρυφο Άξονα, Οριζόντιο Άξονα** και **Γραμμές Πλέγματος** από το διάγραμμα. Το παρακάτω παράδειγμα κώδικα δείχνει πώς να χρησιμοποιήσετε αυτές τις ιδιότητες.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Απόκρυψη τίτλου διαγράμματος
    chart.HasTitle = false;

    ///Απόκρυψη άξονα τιμών
    chart.Axes.VerticalAxis.IsVisible = false;

    //Ορατότητα άξονα κατηγορίας
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Απόκρυψη υπόμνησης
    chart.HasLegend = false;

    //Απόκρυψη κύριων γραμμών πλέγματος
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Ορισμός χρώματος γραμμής σειράς
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **Συχνές Ερωτήσεις**

**Λειτουργούν τα εξωτερικά βιβλία εργασίας Excel ως πηγή δεδομένων και πώς αυτό επηρεάζει τον επανυπολογισμό;**

Ναι. Ένα διάγραμμα μπορεί να αναφέρεται σε εξωτερικό βιβλίο εργασίας: όταν συνδέεστε ή ανανεώνετε την εξωτερική πηγή, οι τύποι και οι τιμές λαμβάνονται από αυτό το βιβλίο, και το διάγραμμα αντικατοπτρίζει τις ενημερώσεις κατά τις λειτουργίες ανοίγματος/επεξεργασίας. Το API σας επιτρέπει να [καθορίσετε το εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/setexternalworkbook/) διαδρομή και να διαχειριστείτε τα συνδεδεμένα δεδομένα.

**Μπορώ να υπολογίσω και να εμφανίσω ευθείες τάσεων χωρίς να υλοποιήσω τη παλινδρόμηση μόνος μου;**

Ναι. Οι [γραμμές τάσης](/slides/el/net/trend-line/) (γραμμικές, εκθετικές και άλλες) προστίθενται και ενημερώνονται από το Aspose.Slides· οι παράμετροι τους επανυπολογίζονται αυτόματα από τα δεδομένα των σειρών, ώστε να μην χρειάζεται να υλοποιήσετε τους δικούς σας υπολογισμούς.

**Εάν μια παρουσίαση περιέχει πολλαπλά διαγράμματα με εξωτερικούς συνδέσμους, μπορώ να ελέγξω ποιο βιβλίο εργασίας χρησιμοποιεί κάθε διάγραμμα για τις υπολογιζόμενες τιμές;**

Ναι. Κάθε διάγραμμα μπορεί να δείχνει στο δικό του [εξωτερικό βιβλίο εργασίας](https://reference.aspose.com/slides/el/net/aspose.slides.charts/chartdata/setexternalworkbook/), ή μπορείτε να δημιουργήσετε/αντικαταστήσετε ένα εξωτερικό βιβλίο εργασίας ανά διάγραμμα ανεξάρτητα από τα άλλα.