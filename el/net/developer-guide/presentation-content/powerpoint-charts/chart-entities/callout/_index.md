---
title: Διαχείριση υποσημειώσεων σε διαγράμματα παρουσίασης στο .NET
linktitle: Υποσημείωση
type: docs
url: /el/net/callout/
keywords:
- υποσημείωση διαγράμματος
- χρήση υποσημείωσης
- ετικέτα δεδομένων
- μορφή ετικέτας
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Δημιουργήστε και μορφοποιήστε υποσημειώσεις στο Aspose.Slides για .NET με σύντομα παραδείγματα κώδικα C#, συμβατά με PPT και PPTX, για αυτοματοποίηση των ροών εργασίας παρουσίασης."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να δουλεύετε με υποσημειώσεις για ετικέτες δεδομένων γραφημάτων στο Aspose.Slides. Δείχνει πώς να χρησιμοποιήσετε την ιδιότητα `ShowLabelAsDataCallout` για να εμφανίζετε τις ετικέτες ως υποσημειώσεις, πώς να διαμορφώσετε τις ρυθμίσεις ετικετών σχετικές με υποσημειώσεις για ένα γράφημα Doughnut, και σημειώνει ότι οι υποσημειώσεις και η εμφάνισή τους διατηρούνται όταν οι παρουσιάσεις εξάγονται σε PDF, HTML5, SVG και μορφές raster εικόνας.

## **Χρήση Υποσημειώσεων**

Νέα ιδιότητα **ShowLabelAsDataCallout** προστέθηκε στην κλάση **DataLabelFormat** και στη διεπαφή **IDataLabelFormat**, η οποία καθορίζει εάν η ετικέτα δεδομένων του συγκεκριμένου γραφήματος θα εμφανίζεται ως υποσημείωση ή ως ετικέτα δεδομένων. Στο παρακάτω παράδειγμα, έχουμε ορίσει τις υποσημειώσεις.

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;
    presentation.Save("DisplayChartLabels_out.pptx", SaveFormat.Pptx);
}
```

## **Ορισμός Υποσημείωσης για Γράφημα Doughnut**

Το Aspose.Slides for .NET παρέχει υποστήριξη για τον ορισμό του σχήματος υποσημείωσης ετικέτας δεδομένων σειράς για ένα γράφημα Doughnut. Παρακάτω δίνεται ένα παράδειγμα.

```c#
Presentation pres = new Presentation("testc.pptx");
ISlide slide = pres.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 10, 10, 500, 500, false);
IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = false;
int seriesIndex = 0;
while (seriesIndex < 15)
{
	IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.Type);
	series.Explosion = 0;
	series.ParentSeriesGroup.DoughnutHoleSize = (byte)20;
	series.ParentSeriesGroup.FirstSliceAngle = 351;
	seriesIndex++;
}
int categoryIndex = 0;
while (categoryIndex < 15)
{
	chart.ChartData.Categories.Add(workBook.GetCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
	int i = 0;
	while (i < chart.ChartData.Series.Count)
	{
		IChartSeries iCS = chart.ChartData.Series[i];
		IChartDataPoint dataPoint = iCS.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(0, categoryIndex + 1, i + 1, 1));
		dataPoint.Format.Fill.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
		dataPoint.Format.Line.Width = 1;
		dataPoint.Format.Line.Style = LineStyle.Single;
		dataPoint.Format.Line.DashStyle = LineDashStyle.Solid;
		if (i == chart.ChartData.Series.Count - 1)
		{
			IDataLabel lbl = dataPoint.Label;
			lbl.TextFormat.TextBlockFormat.AutofitType = TextAutofitType.Shape;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
			lbl.DataLabelFormat.TextFormat.PortionFormat.LatinFont = new FontData("DINPro-Bold");
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontHeight = 12;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.LightGray;
			lbl.DataLabelFormat.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
			lbl.DataLabelFormat.ShowValue = false;
			lbl.DataLabelFormat.ShowCategoryName = true;
			lbl.DataLabelFormat.ShowSeriesName = false;
			//lbl.DataLabelFormat.ShowLabelAsDataCallout = true;
			lbl.DataLabelFormat.ShowLeaderLines = true;
			lbl.DataLabelFormat.ShowLabelAsDataCallout = false;
			chart.ValidateChartLayout();
			lbl.AsILayoutable.X = (float)lbl.AsILayoutable.X + (float)0.5;
			lbl.AsILayoutable.Y = (float)lbl.AsILayoutable.Y + (float)0.5;
		}
		i++;
	}
	categoryIndex++;
}
pres.Save("chart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Συχνές Ερωτήσεις**

**Διατηρούνται οι υποσημειώσεις κατά τη μετατροπή μιας παρουσίασης σε PDF, HTML5, SVG ή εικόνες;**

Ναι. Οι υποσημειώσεις αποτελούν μέρος της απόδοσης του γραφήματος, επομένως όταν εξάγετε σε [PDF](/slides/el/net/convert-powerpoint-to-pdf/),[HTML5](/slides/el/net/export-to-html5/),[SVG](/slides/el/net/render-a-slide-as-an-svg-image/), ή [raster images](/slides/el/net/convert-powerpoint-to-png/), διατηρούνται μαζί με τη μορφοποίηση της διαφάνειας.

**Λειτουργούν οι προσαρμοσμένες γραμματοσειρές στις υποσημειώσεις και μπορεί η εμφάνισή τους να διατηρηθεί κατά την εξαγωγή;**

Ναι. Το Aspose.Slides υποστηρίζει [embedding fonts](/slides/el/net/embedded-font/) στην παρουσίαση και ελέγχει την ενσωμάτωση γραμματοσειρών κατά τις εξαγωγές, όπως στο [PDF](/slides/el/net/convert-powerpoint-to-pdf/), διασφαλίζοντας ότι οι υποσημειώσεις διατηρούν την ίδια εμφάνιση σε διαφορετικά συστήματα.