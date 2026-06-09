---
title: Δημόσιο API και Αλλαγές που δεν είναι Συμβατές προς τα Πίσω σε Aspose.Slides για .NET 14.10.0
linktitle: Aspose.Slides για .NET 14.10.0
type: docs
weight: 120
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- μεταφορά
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
description: "Ανασκοπήστε τις ενημερώσεις του δημόσιου API και τις διασπαστικές αλλαγές σε Aspose.Slides για .NET ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 

Αυτή η σελίδα καταγράφει όλα τα [προστιθέμενα](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) ή [αφαιρεθέντα](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) κλάσεις, μεθόδους, ιδιότητες κτλ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides για .NET 14.10.0.

{{% /alert %}} 
## **Αλλαγές Δημοσίου API**
#### **Έχει Προστεθεί ο Τύπος Πεδίου Aspose.Slides.FieldType.Footer**
Ο τύπος πεδίου Footer έχει προστεθεί για την υλοποίηση της δυνατότητας δημιουργίας πεδίων αυτού του τύπου και για έγκυρη σειριοποίηση παρουσίασης.
#### **Το Στοιχείο Enum ShapeElementFillSource.Own Έχει Διαγραφεί**
Το στοιχείο enum ShapeElementFillSource.Own έχει διαγραφεί επειδή είναι διπλό. Χρησιμοποιήστε ShapeElementFillSource.Shape αντί για ShapeElementFillSource.Own.
#### **Έχουν Προσθεθεί Μέθοδοι για Αφαίρεση Σημείων Δεδομένων Γραφήματος, Κατηγοριών**
Οι παρακάτω μέθοδοι, που επιτρέπουν την αφαίρεση σημείου δεδομένων γραφήματος από μια συλλογή σημείων δεδομένων γραφήματος, έχουν προστεθεί:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

Η παρακάτω μέθοδος, που επιτρέπει την αφαίρεση κατηγορίας γραφήματος από τη συλλογή που την περιέχει, έχει προστεθεί:

IChartCategory.Remove()

``` csharp

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
    pres.Save(outPath, SaveFormat.Pptx);
}
``` 
#### **Οι Παρωχημένες Ιδιότητες Aspose.Slides.ParagraphFormat Έχουν Αφαιρεθεί**
Οι ιδιότητες BulletChar, BulletColor, BulletColorFormat, BulletFont, BulletHeight, BulletType, IsBulletHardColor, IsBulletHardFont, NumberedBulletStartWith, NumberedBulletStyle έχουν αφαιρεθεί. Σήμειωσαν ως παρωχημένες εδώ και πολύ καιρό.
#### **Αχρήστεροι και Παρωχημένοι Κατασκευαστές Έχουν Αφαιρεθεί**
Οι παρακάτω κατασκευαστές έχουν αφαιρεθεί:

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