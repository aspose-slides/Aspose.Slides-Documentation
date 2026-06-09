---
title: Πώς να δημιουργήσετε διαγράμματα σε παρουσιάσεις στο .NET
linktitle: Δημιουργία διαγράμματος
type: docs
weight: 30
url: /el/net/how-to-create-charts-in-a-presentation/
keywords:
- μεταφορά
- δημιουργία διαγράμματος
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να δημιουργείτε διαγράμματα σε παρουσιάσεις PowerPoint PPT, PPTX και ODP στο .NET με το Aspose.Slides, χρησιμοποιώντας τόσο τα κληρονομικά όσο και τα σύγχρονα API διαγραμμάτων."
---
{{% alert color="primary" %}} 
Έχει κυκλοφορήσει ένα νέο [Aspose.Slides for .NET API](/slides/el/net/) και πλέον αυτό το μοναδικό προϊόν υποστηρίζει τη δυνατότητα δημιουργίας εγγράφων PowerPoint από το μηδέν και επεξεργασίας των υπαρχόντων.
{{% /alert %}} 
## **Υποστήριξη κώδικα κληρονομικού**
Για να χρησιμοποιήσετε τον κώδικα κληρονομικό που αναπτύχθηκε με εκδόσεις του Aspose.Slides για .NET παλαιότερες από την 13.x, πρέπει να κάνετε κάποιες μικρές αλλαγές στον κώδικά σας ώστε να λειτουργεί όπως πριν. Όλες οι κλάσεις που υπήρχαν στην παλιά έκδοση του Aspose.Slides για .NET στα ονόματα χώρου Aspose.Slide και Aspose.Slides.Pptx έχουν πλέον συγχωνευτεί σε ένα ενιαίο χώρο ονομάτων Aspose.Slides. Δείτε το παρακάτω απλό απόσπασμα κώδικα για τη δημιουργία ενός κανονικού διαγράμματος από το μηδέν στην παρουσίαση χρησιμοποιώντας το legacy Aspose.Slides API και ακολουθήστε τα βήματα που περιγράφουν πώς να μεταβείτε στο νέο συγχωνευμένο API.
## **Προσέγγιση legacy Aspose.Slides για .NET**
```c#
//Δημιουργήστε αντικείμενο της κλάσης PresentationEx που αντιπροσωπεύει αρχείο PPTX
using (PresentationEx pres = new PresentationEx())
{
    //Πρόσβαση στο πρώτο slide
    SlideEx sld = pres.Slides[0];

    // Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα
    ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

    //Ορισμός τίτλου διαγράμματος
    chart.ChartTitle.Text.Text = "Sample Title";
    chart.ChartTitle.Text.CenterText = true;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    //Ορισμός πρώτης σειράς ώστε να εμφανίζει τιμές
    chart.ChartData.Series[0].Labels.ShowValue = true;

    //Ορισμός του δείκτη του φύλλου δεδομένων διαγράμματος 
    int defaultWorksheetIndex = 0;

    //Λήψη του φύλλου εργασίας δεδομένων διαγράμματος
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Διαγραφή των προεπιλεγμένων παραγόμενων σειρών και κατηγοριών
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();
    int s = chart.ChartData.Series.Count;
    s = chart.ChartData.Categories.Count;

    //Προσθήκη νέας σειράς
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

    //Προσθήκη νέων κατηγοριών
    chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

    //Πάρε την πρώτη σειρά διαγράμματος
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Τώρα γεμίζουμε τα δεδομένα της σειράς
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

    //Ορισμός χρώματος γεμίσματος για τη σειρά
    series.Format.Fill.FillType = FillTypeEx.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;


    //Πάρε τη δεύτερη σειρά διαγράμματος
    series = chart.ChartData.Series[1];

    //Τώρα γεμίζουμε τα δεδομένα της σειράς
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
    series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

    //Ορισμός χρώματος γεμίσματος για τη σειρά
    series.Format.Fill.FillType = FillTypeEx.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    //Δημιουργία προσαρμοσμένων ετικετών για κάθε κατηγορία στη νέα σειρά

    //Η πρώτη ετικέτα θα εμφανίζει το όνομα της κατηγορίας
    DataLabelEx lbl = new DataLabelEx(series);
    lbl.ShowCategoryName = true;
    lbl.Id = 0;
    series.Labels.Add(lbl);

    //Εμφάνιση ονόματος σειράς για τη δεύτερη ετικέτα
    lbl = new DataLabelEx(series);
    lbl.ShowSeriesName = true;
    lbl.Id = 1;
    series.Labels.Add(lbl);

    //Εμφάνιση τιμής για την τρίτη ετικέτα
    lbl = new DataLabelEx(series);
    lbl.ShowValue = true;
    lbl.ShowSeriesName = true;
    lbl.Separator = "/";
    lbl.Id = 2;
    series.Labels.Add(lbl);

    //Εμφάνιση τιμής και προσαρμοσμένου κειμένου
    lbl = new DataLabelEx(series);
    lbl.TextFrame.Text = "My text";
    lbl.Id = 3;
    series.Labels.Add(lbl);

    //Αποθήκευση παρουσίασης με διάγραμμα
    pres.Write(@"D:\AsposeChart.pptx");
}
```



## **Νέα προσέγγιση Aspose.Slides για .NET 13.x**
``` csharp
//Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX//Δημιουργήστε αντικείμενο της κλάσης Presentation που αντιπροσωπεύει αρχείο PPTX
Presentation pres = new Presentation();

//Πρόσβαση στο πρώτο slide
ISlide sld = pres.Slides[0];

// Προσθήκη διαγράμματος με προεπιλεγμένα δεδομένα
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Ορισμός τίτλου διαγράμματος
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Ορισμός πρώτης σειράς ώστε να εμφανίζει τιμές
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Ορισμός του δείκτη του φύλλου δεδομένων διαγράμματος
int defaultWorksheetIndex = 0;

//Λήψη του φύλλου εργασίας δεδομένων διαγράμματος
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Διαγραφή των προεπιλεγμένων παραγόμενων σειρών και κατηγοριών
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Προσθήκη νέας σειράς
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Προσθήκη νέων κατηγοριών
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Πάρε την πρώτη σειρά διαγράμματος
IChartSeries series = chart.ChartData.Series[0];

//Τώρα γεμίζουμε τα δεδομένα της σειράς

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Ορισμός χρώματος γεμίσματος για τη σειρά
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Πάρε τη δεύτερη σειρά διαγράμματος
series = chart.ChartData.Series[1];

//Τώρα γεμίζουμε τα δεδομένα της σειράς
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Ορισμός χρώματος γεμίσματος για τη σειρά
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Δημιουργία προσαρμοσμένων ετικετών για κάθε κατηγορία στη νέα σειρά

//Η πρώτη ετικέτα θα εμφανίζει το όνομα της κατηγορίας
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Show value for third label
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Αποθήκευση παρουσίασης με διάγραμμα
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Δείτε το παρακάτω απλό απόσπασμα κώδικα για τη δημιουργία ενός διασκορπισμένου διαγράμματος από το μηδέν στην παρουσίαση χρησιμοποιώντας το legacy Aspose.Slides API και πώς να το επιτύχετε με το νέο συγχωνευμένο API.

## **Προσέγγιση legacy Aspose.Slides για .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Δημιουργία προεπιλεγμένου διαγράμματος
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Λήψη του δείκτη του προεπιλεγμένου φύλλου δεδομένων διαγράμματος
    int defaultWorksheetIndex = 0;

    //Πρόσβαση στο φύλλο δεδομένων διαγράμματος
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Διαγραφή δείγματος σειράς
    chart.ChartData.Series.Clear();

    //Προσθήκη νέας σειράς
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Λήψη πρώτης σειράς διαγράμματος
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Προσθήκη νέου σημείου (1:3) εκεί.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Προσθήκη νέου σημείου (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Επεξεργασία τύπου σειράς
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Αλλαγή του δείκτη σειράς διαγράμματος
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Λήψη δεύτερης σειράς διαγράμματος
    series = chart.ChartData.Series[1];

    //Προσθήκη νέου σημείου (5:2) εκεί.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Προσθήκη νέου σημείου (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Προσθήκη νέου σημείου (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Προσθήκη νέου σημείου (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Αλλαγή του δείκτη σειράς διαγράμματος
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **Νέα προσέγγιση Aspose.Slides για .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Δημιουργία του προεπιλεγμένου διαγράμματος
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Λήψη του δείκτη του προεπιλεγμένου φύλλου δεδομένων διαγράμματος
int defaultWorksheetIndex = 0;

//Πρόσβαση στο φύλλο δεδομένων διαγράμματος
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Διαγραφή δείγματος σειράς
chart.ChartData.Series.Clear();

//Προσθήκη νέας σειράς
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Λήψη πρώτης σειράς διαγράμματος
IChartSeries series = chart.ChartData.Series[0];

//Προσθήκη νέου σημείου (1:3) εκεί.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Προσθήκη νέου σημείου (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Επεξεργασία τύπου σειράς
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Αλλαγή δεικτών σειράς διαγράμματος
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Λήψη δεύτερης σειράς διαγράμματος
series = chart.ChartData.Series[1];

//Προσθήκη νέου σημείου (5:2) εκεί.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Προσθήκη νέου σημείου (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Προσθήκη νέου σημείου (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Προσθήκη νέου σημείου (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Αλλαγή δεικτών σειράς διαγράμματος
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```