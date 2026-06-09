---
title: Δημόσιο API και Μη Συμβατικές Πίσω Αλλαγές στο Aspose.Slides για Java 15.8.0
linktitle: Aspose.Slides για Java 15.8.0
type: docs
weight: 160
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/
keywords:
- μετάβαση
- κληρονομικός κώδικας
- σύγχρονος κώδικας
- κληρονομική προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των διατρητικών αλλαγών στο Aspose.Slides for Java για ομαλή μεταφορά των λύσεων παρουσίασης PowerPoint PPT, PPTX και ODP σας."
---
{{% alert color="primary" %}} 
Αυτή η σελίδα καταγράφει όλες τις [προστιθέμενες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) ή [αφαιρεθείσες](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-8-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το Aspose.Slides for Java 15.8.0 API.
{{% /alert %}} 
## **Αλλαγές Δημόσιου API**
#### **Οι μέθοδοι getDoughnutHoleSize(), setDoughnutHoleSize(byte) προστέθηκαν στο IChartSeries και στο ChartSeries**
Καθορίζει το μέγεθος του κεντρικού τρύπα σε διάγραμμα δακτυλίου.
``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);

chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);                   

pres.save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

```