---
title: "Δημόσιο API και Ασυμβατότητες Πίσω Συμβατότητας στο Aspose.Slides για .NET 15.2.0"
linktitle: "Aspose.Slides για .NET 15.2.0"
type: docs
weight: 140
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- μετεγκατάσταση
- παλιός κώδικας
- σύγχρονος κώδικας
- παλιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των επιβαρυτικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}}

Αυτή η σελίδα παραθέτει όλα τα [προστιθέμενα](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) ή [αφαιρεθέντα](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for .NET 15.2.0.

{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Οι Μέθοδοι AddDataPointForDoughnutSeries Προστέθηκαν**
Τα δύο υπερφορτωμένα της μεθόδου IChartDataPointCollection.AddDataPointForDoughnutSeries() προστέθηκαν για την προσθήκη σημείων δεδομένων σε σειρές τύπου γραφήματος Donut.
#### **Η κλάση Aspose.Slides.SmartArt.SmartArtShape Κληρονόμησε από την κλάση Aspose.Slides.GeometryShape**
Η κλάση Aspose.Slides.SmartArt.SmartArtShape κληρονομείται από την κλάση Aspose.Slides.GeometryShape. Αυτή η αλλαγή βελτιώνει το μοντέλο αντικειμένων του Aspose.Slides και προσθέτει νέες δυνατότητες στην κλάση SmartArtShape.
#### **Προστέθηκαν Μέθοδοι για Αφαίρεση Σημείου Δεδομένων Γραφήματος και Κατηγορίας Γραφήματος κατά Δείκτη**
Η μέθοδος IChartDataPointCollection.RemoveAt(int index) προστέθηκε για την αφαίρεση σημείου δεδομένων γραφήματος με βάση τον δείκτη του.
Η μέθοδος IChartCategoryCollection.RemoveAt(int index) προστέθηκε για την αφαίρεση κατηγορίας γραφήματος με βάση τον δείκτη του.
#### **Η τιμή PptXPptY Προστέθηκε στην Απαρίθμηση Aspose.Slides.Animation.PropertyType**
Η τιμή PptXPptY προστέθηκε στην απαρίθμηση Aspose.Slides.Animation.PropertyType στο πλαίσιο διόρθωσης προβλήματος σειράς.
#### **Η μέθοδος System.Drawing.Color GetAutomaticSeriesColor() Προστέθηκε στην Aspose.Slides.Charts.IChartSeries**
Η μέθοδος GetAutomaticSeriesColor επιστρέφει ένα αυτόματο χρώμα σειράς βάσει του δείκτη σειράς και του στυλ γραφήματος. Αυτό το χρώμα χρησιμοποιείται εξ ορισμού εάν το FillType είναι ίσο με NotDefined.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```