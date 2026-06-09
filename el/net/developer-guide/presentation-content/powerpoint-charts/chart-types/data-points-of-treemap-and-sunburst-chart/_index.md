---
title: Προσαρμογή σημείων δεδομένων σε διαγράμματα Treemap και Sunburst στο .NET
linktitle: Σημεία δεδομένων σε διαγράμματα Treemap και Sunburst
type: docs
url: /el/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- διάγραμμα treemap
- διάγραμμα sunburst
- σημείο δεδομένων
- χρώμα ετικέτας
- χρώμα κλάδου
- PowerPoint
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να διαχειρίζεστε σημεία δεδομένων σε διαγράμματα treemap και sunburst με Aspose.Slides για .NET, συμβατά με μορφές PowerPoint."
---
## **Εισαγωγή**

Μεταξύ άλλων τύπων διαγραμμάτων PowerPoint, υπάρχουν δύο «ιεραρχικοί» τύποι - **Treemap** και **Sunburst** διάγραμμα (επίσης γνωστό ως Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph ή Multi Level Pie Chart). Αυτά τα διαγράμματα εμφανίζουν ιεραρχικά δεδομένα οργανωμένα ως δέντρο - από τα φύλλα έως την κορυφή του κλάδου. Τα φύλλα ορίζονται από τα σημεία δεδομένων της σειράς, και κάθε επόμενο ενσωματωμένο επίπεδο ομαδοποίησης ορίζεται από την αντίστοιχη κατηγορία. Aspose.Slides for .NET επιτρέπει τη μορφοποίηση των σημείων δεδομένων του Sunburst Chart και του Treemap σε C#.

Ακολουθεί ένα διάγραμμα Sunburst, όπου τα δεδομένα στη στήλη Series1 ορίζουν τα φύλλα, ενώ οι άλλες στήλες ορίζουν ιεραρχικά σημεία δεδομένων:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Ας ξεκινήσουμε με την προσθήκη ενός νέου διαγράμματος Sunburst στην παρουσίαση:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Δείτε επίσης" %}} 
- [**Δημιουργία διαγράμματος Sunburst**](/slides/el/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Αν χρειάζεται να μορφοποιήσετε τα σημεία δεδομένων του διαγράμματος, πρέπει να χρησιμοποιήσετε τα εξής:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapointlevel) κλάσεις 
και [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) ιδιότητα 
παρέχουν πρόσβαση στη μορφοποίηση των σημείων δεδομένων των διαγραμμάτων Treemap και Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/el/net/aspose.slides.charts/IChartDataPointLevelsManager) 
χρησιμοποιείται για την πρόσβαση σε κατηγορίες πολλαπλών επιπέδων - αποτελεί το δοχείο των 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/el/net/aspose.slides.charts/IChartDataPointLevel) αντικειμένων. 
Βασικά, είναι ένας wrapper για 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/el/net/aspose.slides.charts/IChartCategoryLevelsManager) με 
τις ιδιότητες που προστέθηκαν ειδικά για τα σημεία δεδομένων. 
Η κλάση [**IChartDataPointLevel**](https://reference.aspose.com/slides/el/net/aspose.slides.charts/IChartDataPointLevel) έχει 
δύο ιδιότητες: [**Format**](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapointlevel/properties/format) και 
[**DataLabel**](https://reference.aspose.com/slides/el/net/aspose.slides.charts/ichartdatapointlevel/properties/label) που 
παρέχουν πρόσβαση στις αντίστοιχες ρυθμίσεις.
## **Εμφάνιση τιμής σημείου δεδομένων**
Εμφανίστε την τιμή του σημείου δεδομένων «Leaf 4»:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Ορισμός ετικέτας και χρώματος σημείου δεδομένων**
Ορίστε την ετικέτα δεδομένων του «Branch 1» ώστε να εμφανίζει το όνομα σειράς («Series1») αντί για το όνομα κατηγορίας. Στη συνέχεια ορίστε το χρώμα κειμένου σε κίτρινο:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Ορισμός χρώματος κλάδου σημείου δεδομένων**

Αλλαγή χρώματος του κλάδου «Stem 4»:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Συχνές ερωτήσεις**

**Μπορώ να αλλάξω τη σειρά (ταξινόμηση) των τμημάτων σε Sunburst/Treemap;**

Όχι. Το PowerPoint ταξινομεί αυτόματα τα τμήματα (συνήθως κατά φθίνουσες τιμές, δεξιόστροφα). Η Aspose.Slides αντανακλά αυτή τη συμπεριφορά: δεν μπορείτε να αλλάξετε τη σειρά άμεσα· μπορείτε να το πετύχετε προεπεξεργάζοντας τα δεδομένα.

**Πώς επηρεάζει το θέμα της παρουσίασης τα χρώματα των τμημάτων και των ετικετών;**

Τα χρώματα του διαγράμματος κληρονομούν το [theme/palette](/slides/el/net/presentation-theme/) της παρουσίασης, εκτός εάν ορίσετε ρητά γεμίσματα/γραμματοσειρές. Για συνεπή αποτελέσματα, κλειδώστε τα συμπαγή γεμίσματα και τη μορφοποίηση κειμένου στα απαιτούμενα επίπεδα.

**Θα διατηρήσει η εξαγωγή σε PDF/PNG τα προσαρμοσμένα χρώματα κλάδων και τις ρυθμίσεις ετικετών;**

Ναι. Κατά την εξαγωγή της παρουσίασης, οι ρυθμίσεις του διαγράμματος (γεμίσματα, ετικέτες) διατηρούνται στα έξοδα μορφές επειδή η Aspose.Slides αποδίδει με την εφαρμοσμένη μορφοποίηση του διαγράμματος.

**Μπορώ να υπολογίσω τις πραγματικές συντεταγμένες μιας ετικέτας/στοιχείου για προσαρμοσμένη τοποθέτηση επικάλυψης πάνω στο διάγραμμα;**

Ναι. Μετά την επαλήθευση της διάταξης του διαγράμματος, τα `ActualX`/`ActualY` είναι διαθέσιμα για τα στοιχεία (π.χ., ένα [DataLabel](https://reference.aspose.com/slides/el/net/aspose.slides.charts/datalabel/)), κάτι που βοηθά στην ακριβή τοποθέτηση των επικάλυψεων.