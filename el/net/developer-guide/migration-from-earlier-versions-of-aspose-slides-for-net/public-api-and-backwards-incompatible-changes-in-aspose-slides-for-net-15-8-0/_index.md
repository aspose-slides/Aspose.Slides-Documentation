---
title: Δημόσιο API και Αλλαγές που Σπάσαν τη Συμβατότητα Πίσω στην Aspose.Slides για .NET 15.8.0
linktitle: Aspose.Slides για .NET 15.8.0
type: docs
weight: 190
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- μετάβαση
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
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των αλλαγών που σπάζουν τη συμβατότητα στην Aspose.Slides για .NET, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="primary" %}} 
Αυτή η σελίδα απαριθμεί όλες τις [προστέθηκε](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) ή [αφαιρέθηκε](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for .NET 15.8.0 API.
{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Η Ιδιότητα DoughnutHoleSize Προστέθηκε στην IChartSeries και στην ChartSeries**
Καθορίζει το μέγεθος της τρύπας σε διάγραμμα ντόνατ.
``` csharp

 using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;
   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);
}
```