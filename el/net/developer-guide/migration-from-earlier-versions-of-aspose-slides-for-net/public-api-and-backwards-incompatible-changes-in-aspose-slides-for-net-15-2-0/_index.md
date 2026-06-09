---
title: Δημόσιο API και Αντίστροφες Ασυμβατες Αλλαγές στο Aspose.Slides για .NET 15.2.0
linktitle: Aspose.Slides για .NET 15.2.0
type: docs
weight: 140
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- μετανάστευση
- κληρονομικός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση ενημερώσεων του δημόσιου API και ανατρεπτικών αλλαγών στο Aspose.Slides για .NET για ομαλή μετάβαση των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) ή [αφαιρεθείσες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides για .NET 15.2.0 API.

{{% /alert %}} 
## **Δημόσιες αλλαγές API**
#### **Οι μέθοδοι AddDataPointForDoughnutSeries προστέθηκαν**
Οι δύο υπερφορτώσεις της μεθόδου IChartDataPointCollection.AddDataPointForDoughnutSeries() προστέθηκαν για την προσθήκη σημείων δεδομένων σε σειρές τύπου διαγράμματος Doughnut.
#### **Η κλάση Aspose.Slides.SmartArt.SmartArtShape κληρονομείται από την κλάση Aspose.Slides.GeometryShape**
Η κλάση Aspose.Slides.SmartArt.SmartArtShape κληρονομείται από την κλάση Aspose.Slides.GeometryShape. Αυτή η αλλαγή βελτιώνει το μοντέλο αντικειμένων του Aspose.Slides και προσθέτει νέες δυνατότητες στην κλάση SmartArtShape.
#### **Προστέθηκαν μέθοδοι για την αφαίρεση σημείου δεδομένων γραφήματος και κατηγορίας γραφήματος κατά δείκτη**
Η μέθοδος IChartDataPointCollection.RemoveAt(int index) προστέθηκε για την αφαίρεση σημείου δεδομένων γραφήματος με βάση τον δείκτη του.
Η μέθοδος IChartCategoryCollection.RemoveAt(int index) προστέθηκε για την αφαίρεση κατηγορίας γραφήματος με βάση τον δείκτη της.
#### **Η τιμή PptXPptY προστέθηκε στην απαρίθμηση Aspose.Slides.Animation.PropertyType**
Η τιμή PptXPptY προστέθηκε στην απαρίθμηση Aspose.Slides.Animation.PropertyType στο πλαίσιο διόρθωσης προβλήματος σειριοποίησης.
#### **Η μέθοδος System.Drawing.Color GetAutomaticSeriesColor() προστέθηκε στην Aspose.Slides.Charts.IChartSeries**
Η μέθοδος GetAutomaticSeriesColor επιστρέφει ένα αυτόματο χρώμα σειράς βασιζόμενο στον δείκτη σειράς και στο στυλ διαγράμματος. Αυτό το χρώμα χρησιμοποιείται εξ' ορισμού εάν το FillType ισούται με NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```