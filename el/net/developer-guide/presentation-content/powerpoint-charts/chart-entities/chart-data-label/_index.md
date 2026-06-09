---
title: Διαχείριση ετικετών δεδομένων γραφημάτων σε παρουσιάσεις στο .NET
linktitle: Ετικέτα Δεδομένων
type: docs
url: /el/net/chart-data-label/
keywords:
- γράφημα
- ετικέτα δεδομένων
- ακρίβεια δεδομένων
- ποσοστό
- απόσταση ετικέτας
- θέση ετικέτας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να προσθέτετε και να μορφοποιείτε ετικέτες δεδομένων γραφημάτων σε παρουσιάσεις PowerPoint χρησιμοποιώντας το Aspose.Slides για .NET για πιο ελκυστικές διαφάνειες."
---
## **Εισαγωγή**

Οι ετικέτες δεδομένων σε ένα γράφημα εμφανίζουν λεπτομέρειες για τις σειρές δεδομένων του γραφήματος ή για μεμονωμένα σημεία δεδομένων. Επιτρέπουν στους αναγνώστες να αναγνωρίζουν γρήγορα τις σειρές δεδομένων και κάνουν τα γραφήματα πιο εύκολα στην κατανόηση.

## **Ορισμός ακρίβειας δεδομένων στις ετικέτες δεδομένων του γραφήματος**

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε την ακρίβεια δεδομένων σε μια ετικέτα δεδομένων γραφήματος:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **Εμφάνιση ποσοστού ως ετικετών**

Το Aspose.Slides για .NET σας επιτρέπει να ορίσετε ετικέτες ποσοστού σε εμφανιζόμενα γραφήματα. Αυτός ο κώδικας C# επιδεικνύει τη λειτουργία:

```c#
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// Αποθηκεύει την παρουσίαση που περιέχει το γράφημα
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Ορισμός συμβόλου ποσοστού με ετικέτες δεδομένων γραφήματος**

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε το σύμβολο ποσοστού για μια ετικέτα δεδομένων γραφήματος:

```c#
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
Presentation presentation = new Presentation();

// Λαμβάνει μια αναφορά διαφάνειας μέσω του δείκτη της
ISlide slide = presentation.Slides[0];

// Δημιουργεί το γράφημα PercentsStackedColumn σε μια διαφάνεια
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Ορίζει το NumberFormatLinkedToSource σε false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Λαμβάνει το φύλλο εργασίας δεδομένων του γραφήματος
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Προσθέτει νέα σειρά
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Ορίζει το χρώμα γεμίσματος της σειράς
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Ορίζει τις ιδιότητες του LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Προσθέτει νέα σειρά
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Ορίζει τον τύπο γεμίσματος και το χρώμα
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Γράφει την παρουσίαση στο δίσκο
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Ορισμός απόστασης ετικέτας από άξονα**

Αυτός ο κώδικας C# δείχνει πώς να ορίσετε την απόσταση ετικέτας από έναν άξονα κατηγορίας όταν εργάζεστε με γράφημα σχεδιασμένο από άξονες:

```c#
// Δημιουργεί ένα αντικείμενο της κλάσης Presentation
Presentation presentation = new Presentation();

// Λαμβάνει μια αναφορά σε διαφάνεια
ISlide sld = presentation.Slides[0];

// Δημιουργεί ένα γράφημα στη διαφάνεια
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Ορίζει την απόσταση ετικέτας από έναν άξονα
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Γράφει την παρουσίαση στο δίσκο
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Ρύθμιση θέσης ετικέτας**

Όταν δημιουργείτε ένα γράφημα που δεν βασίζεται σε κανέναν άξονα, όπως ένα διάγραμμα πίτας, οι ετικέτες δεδομένων του γραφήματος μπορεί να είναι πολύ κοντά στην άκρη του. Σε μια τέτοια περίπτωση, πρέπει να ρυθμίσετε τη θέση της ετικέτας δεδομένων ώστε οι γραμμές οδηγίας να εμφανίζονται καθαρά.

Αυτός ο κώδικας C# δείχνει πώς να ρυθμίσετε τη θέση της ετικέτας σε ένα διάγραμμα πίτας:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αποτρέψω την επικάλυψη ετικετών δεδομένων σε πυκνά γραφήματα;**

Συνδυάστε αυτόματη τοποθέτηση ετικετών, γραμμές οδηγίας και μειωμένο μέγεθος γραμματοσειράς· εάν χρειαστεί, κρύψτε ορισμένα πεδία (π.χ. την κατηγορία) ή εμφανίστε ετικέτες μόνο για ακραία/σημαντικά σημεία.

**Πώς μπορώ να απενεργοποιήσω τις ετικέτες μόνο για τιμές μηδέν, αρνητικές ή κενές;**

Φιλτράρετε τα σημεία δεδομένων πριν ενεργοποιήσετε τις ετικέτες και απενεργοποιήστε την εμφάνιση για τιμές 0, αρνητικές τιμές ή ελλιπείς τιμές σύμφωνα με έναν ορισμένο κανόνα.

**Πώς μπορώ να εξασφαλίσω συνεπή στυλ ετικετών κατά την εξαγωγή σε PDF/εικόνες;**

Ορίστε ρητά τις γραμματοσειρές (οικογένεια, μέγεθος) και βεβαιωθείτε ότι η γραμματοσειρά είναι διαθέσιμη στο περιβάλλον απόδοσης για να αποφύγετε την εναλλακτική χρήση.