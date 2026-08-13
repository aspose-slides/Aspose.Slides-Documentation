---
title: Δημόσιος API και Αλλαγές που δεν είναι Συμβατές με Παλαιότερες Εκδόσεις στο Aspose.Slides for .NET 14.10.0
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- μετεγκατάσταση
- κώδικας κληρονομίας
- σύγχρονος κώδικας
- κληρονομική προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των αλλαγών που προκαλούν σπασίματα στο Aspose.Slides for .NET για ομαλή μεταφορά των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}}
Αυτή η σελίδα παραθέτει όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) ή [αφαιρεθείσες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 14.10.0 API.
{{% /alert %}}
## **Δημόσιο API Αλλαγές**
#### **Ο τύπος πεδίου Aspose.Slides.FieldType.Footer έχει προστεθεί**
Ο τύπος πεδίου Footer έχει προστεθεί για την υλοποίηση της δυνατότητας δημιουργίας πεδίων αυτού του τύπου και για έγκυρη σειριοποίηση παρουσίασης.
#### **Το στοιχείο Enum ShapeElementFillSource.Own έχει διαγραφεί**
Το στοιχείο Enum ShapeElementFillSource.Own έχει διαγραφεί ως διπλότυπο. Χρησιμοποιήστε ShapeElementFillSource.Shape αντί για ShapeElementFillSource.Own.
#### **Προστέθηκαν μέθοδοι για αφαίρεση σημείων δεδομένων γραφήματος, κατηγοριών**
Οι ακόλουθες μέθοδοι, που επιτρέπουν την αφαίρεση σημείου δεδομένων γραφήματος από μια συλλογή σημείων δεδομένων γραφήματος, έχουν προστεθεί:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Η ακόλουθη μέθοδος, η οποία επιτρέπει την αφαίρεση μιας κατηγορίας γραφήματος από τη συλλογή που την περιέχει, έχει προστεθεί:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //αφαίρεση με ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //αφαίρεση με ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//αφαίρεση με ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```
#### **Οι Απαρχαιωμένες Ιδιότητες Aspose.Slides.ParagraphFormat έχουν αφαιρεθεί**
Οι ιδιότητες BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle έχουν αφαιρεθεί. Είχαν χαρακτηριστεί ως απαρχαιωμένες εδώ και πολύ καιρό.
#### **Μη χρήσιμες και απαρχαιωμένες Κατασκευαστές έχουν αφαιρεθεί**
Οι ακόλουθοι κατασκευαστές έχουν αφαιρεθεί:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)