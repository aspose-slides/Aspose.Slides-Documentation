---
title: Προσαρμογή Υπομνημάτων Διαγραμμάτων σε Παρουσιάσεις σε .NET
linktitle: Υπόμνημα Διαγράμματος
type: docs
url: /el/net/chart-legend/
keywords:
- υπόμνημα διαγράμματος
- θέση υπομνήματος
- μέγεθος γραμματοσειράς
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Προσαρμόστε τα υπόμνηματα διαγραμμάτων με το Aspose.Slides για .NET ώστε να βελτιστοποιήσετε τις παρουσιάσεις PowerPoint με προσαρμοσμένη μορφοποίηση υπομνήματος."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET παρέχει επιλογές για προσαρμογή των υπομνημάτων διαγραμμάτων σε παρουσιάσεις PowerPoint. Αυτό το άρθρο δείχνει πώς να τοποθετήσετε και να ορίσετε το μέγεθος ενός υπομνήματος, να ορίσετε το μέγεθος γραμματοσειράς για ολόκληρο το υπόμνημα, να μορφοποιήσετε μια μεμονωμένη είσοδο υπομνήματος και να αποκρύψετε ή να επαναφέρετε επιλεγμένες εισόδους.

Το FAQ καλύπτει σχετικές συμπεριφορές, όπως η διατήρηση χώρου για το υπόμνημα, η προβολή ετικετών πολλαπλών γραμμών και η κληρονόμηση μορφοποίησης από το θέμα της παρουσίασης.

## **Τοποθέτηση Υπομνήματος**

Χρησιμοποιήστε τις ιδιότητες [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), και [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) του υπομνήματος για να καθορίσετε τη θέση και το μέγεθός του ως κλάσματα των διαστάσεων του διαγράμματος.

Αυτό το παράδειγμα δημιουργεί μια παρουσίαση και προσθέτει ένα συγκεντρωμένο ραβδόγραμμα με προεπιλεγμένα δεδομένα στην πρώτη διαφάνεια. Διαιρώντας τις επιθυμητές μετατοπίσεις και διαστάσεις του υπομνήματος με το πλάτος και το ύψος του διαγράμματος, μετατρέπονται σε σχετικές τιμές: το υπόμνημα μετατοπίζεται κατά 50 σημεία από την επάνω αριστερή γωνία του διαγράμματος και έχει μέγεθος 100 κατά 100 σημεία.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Ορισμός Μεγέθους Γραμματοσειράς Υπομνήματος**

Χρησιμοποιήστε το [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) του υπομνήματος για να έχετε πρόσβαση στη μορφοποίηση του κειμένου και ορίστε το [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) σε σημεία.

Αυτό το παράδειγμα δημιουργεί ένα διάγραμμα με προεπιλεγμένα δεδομένα και ορίζει το κείμενο του υπομνήματος στα 20 σημεία. Επίσης, απενεργοποιεί τα αυτόματα όρια για τον κάθετο άξονα και ορίζει την περιοχή του από -5 έως 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Ορισμός Μεγέθους Γραμματοσειράς Μιας Μεμονωμένης Εγγραφής Υπομνήματος**

Χρησιμοποιήστε τη συλλογή [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) του υπομνήματος για να αποκτήσετε πρόσβαση στη μορφοποίηση μιας συγκεκριμένης εγγραφής. Οι δείκτες των εγγραφών είναι μηδενικής βάσης, έτσι ο δείκτης `1` αναφέρεται στη δεύτερη εγγραφή.

Αυτό το παράδειγμα δημιουργεί ένα συγκεντρωμένο ραβδόγραμμα του οποίου τα προεπιλεγμένα δεδομένα περιλαμβάνουν τουλάχιστον δύο σειρές. Μορφοποιεί τη δεύτερη εγγραφή υπομνήματος με έντονη, πλάγια και μπλε κείμενο μεγέθους 20 σημεία.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Απόκρυψη Μεμονωμένων Εγγραφών Υπομνήματος**

Για να εξαιρέσετε μια βοηθητική σειρά από το υπόμνημα διατηρώντας τα δεδομένα της ορατά, ορίστε το [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) σε `true` μέσω του [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Αυτό αποκρύπτει μόνο την επιλεγμένη εγγραφή υπομνήματος· δεν αφαιρεί τη σειρά ή τα σημεία δεδομένων της. Αντίστροφα, ορίζοντας το [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) σε `false` αποκρύπτει όλο το υπόμνημα.

Το παρακάτω παράδειγμα δημιουργεί ένα συγκεντρωτικό ραβδόγραμμα με πολλαπλές σειρές χρησιμοποιώντας προεπιλεγμένα δεδομένα. Αποκρύπτει τη δεύτερη εγγραφή υπομνήματος της σειράς (δείκτης `1`) και αποθηκεύει την παρουσίαση. Στη συνέχεια επαναφέρει την εγγραφή ορίζοντας το `Hide` σε `false` και αποθηκεύει ένα δεύτερο αντίγραφο. Οι στήλες παραμένουν ορατές και στα δύο αρχεία.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Επαναφέρετε την ίδια εγγραφή χωρίς να αλλάξετε τα δεδομένα του διαγράμματος.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Η παρακάτω σύγκριση δείχνει το ίδιο διάγραμμα με όλες τις εγγραφές υπομνήματος ορατές και με τη Σειρά 2 κρυφή από το υπόμνημα· όλες οι στήλες παραμένουν ορατές.

![Σύγκριση διαγράμματος με όλες τις εγγραφές υπομνήματος ορατές και με τη Σειρά 2 κρυφή από το υπόμνημα· όλες οι στήλες παραμένουν ορατές.](hide-legend-entry.png)

Σε διαγράμματα στήλης, ράβδου και γραμμής, οι εγγραφές υπομνήματος αναγνωρίζουν σειρές. Για διαγράμματα πίτας, αναγνωρίζουν μεμονωμένα σημεία δεδομένων (κόνες), οπότε χρησιμοποιήστε το [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) στην επιλεγμένη κόνα. Το API τεκμηριώνει αυτήν την ιδιότητα σημείου δεδομένων για τους τύπους διαγραμμάτων `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` και `BarOfPie`. Μην υποθέτετε ότι ισχύει για διαγράμματα δακτυλίου, τα οποία δεν περιλαμβάνονται σε αυτή τη λίστα.

## **Συχνές Ερωτήσεις**

**Μπορώ να κάνω το διάγραμμα να διαθέσει χώρο για το υπόμνημα αντί να το επικάλυψη;**

Ναι. Ορίστε το [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) σε `false` για να κρατήσετε χώρο για το υπόμνημα αντί να επιτρέψετε τη επικάλυψή του στην περιοχή σχεδίασης.

**Μπορώ να δημιουργήσω ετικέτες υπομνήματος πολλαπλών γραμμών;**

Ναι. Οι μεγάλες ετικέτες μπορούν να αναδιπλώνονται όταν το διαθέσιμο πλάτος είναι ανεπαρκές. Μπορείτε επίσης να χρησιμοποιήσετε χαρακτήρες νέας γραμμής στα ονόματα των σειρών για να ζητήσετε διακοπές γραμμής.

**Πώς μπορώ να κάνω το υπόμνημα να ακολουθεί τη χρωματική παλέτα του θέματος της παρουσίασης;**

Αφήστε τα χρώματα, τις γεμίσεις και τις γραμματοσειρές του υπομνήματος ακαθορισμένα ώστε να κληρονομεί τη μορφοποίηση του θέματος. Η ρητή μορφοποίηση παρακάμπτει τις αντίστοιχες ρυθμίσεις θέματος.