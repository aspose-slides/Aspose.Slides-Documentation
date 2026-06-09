---
title: ΔΗΜΟΣΙΟ API ΚΑΙ ΜΗ ΣΥΜΒΑΤΕΣ ΠΙΣΩ ΑΛΛΑΓΕΣ ΣΤΟ Aspose.Slides ΓΙΑ .NET 16.1.0
linktitle: Aspose.Slides ΓΙΑ .NET 16.1.0
type: docs
weight: 220
url: /el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- μετάβαση
- παραδοσιακός κώδικας
- σύγχρονος κώδικας
- παραδοσιακή προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των κατατμητικών αλλαγών στο Aspose.Slides για .NET, ώστε να μεταβείτε ομαλά στις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP σας."
---
{{% alert color="primary" %}}

Αυτή η σελίδα απαριθμεί όλες τις [προστιθέμενες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) ή [αφαιρεθείσες](/slides/el/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides for .NET 16.1.0.

{{% /alert %}}
## **Αλλαγές Δημόσιου API**

#### **Η Ιδιότητα RotationAngle Προστέθηκε στα Διεπαφές IChartTextBlockFormat και ITextFrameFormat**

Η ιδιότητα RotationAngle προστέθηκε στις διεπαφές Aspose.Slides.Charts.IChartTextBlockFormat και Aspose.Slides.ITextFrameFormat.
Καθορίζει την προσαρμοσμένη περιστροφή που εφαρμόζεται στο κείμενο εντός του περιθωρίου.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


```
#### **Το OdpException Μεταφέρθηκε από το Aspose.Slides.Odp στο Namespace Aspose.Slides**