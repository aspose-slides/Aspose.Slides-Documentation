---
title: Δημόσιο API και Ασυμβατότητες Προς Τα Πίσω στην Aspose.Slides για Java 16.1.0
linktitle: Aspose.Slides για Java 16.1.0
type: docs
weight: 200
url: /el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- μετανάστευση
- παλαιός κώδικας
- σύγχρονος κώδικας
- παλαιά προσέγγιση
- σύγχρονη προσέγγιση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Ανασκόπηση των ενημερώσεων του δημόσιου API και των αλλαγών‑σπασίματος στην Aspose.Slides για Java, ώστε να μεταφέρετε ομαλά τις λύσεις παρουσίασης PowerPoint PPT, PPTX και ODP."
---
{{% alert color="info" %}} 
Αυτή η σελίδα απαριθμεί όλα τα [προστέθηκαν](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) ή [αφαιρέθηκαν](/slides/el/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) κλάσεις, μεθόδους, ιδιότητες κ.λπ., καθώς και άλλες αλλαγές που εισήχθησαν με το API του Aspose.Slides για Java 16.1.0.
{{% /alert %}} 
## **Αλλαγές δημόσιου API**
#### **Οι μέθοδοι getRotationAngle() και setRotationAngle() προστέθηκαν στις διεπαφές IChartTextBlockFormat και ITextFrameFormat**
Οι μέθοδοι getRotationAngle() και setRotationAngle() προστέθηκαν στις διεπαφές com.aspose.slides.IChartTextBlockFormat και com.aspose.slides.ITextFrameFormat.
Παρέχουν πρόσβαση στην προσαρμοσμένη περιστροφή που εφαρμόζεται στο κείμενο μέσα στο περιοριστικό πλαίσιο.
``` java
import com.aspose.slides.*;




Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

series.getLabels().getDefaultDataLabelFormat().setShowValue (true);

series.getLabels().getDefaultDataLabelFormat().getTextFormat ().getTextBlockFormat().setRotationAngle(65);

chart.setTitle(true);

chart.getChartTitle().addTextFrameForOverriding("Custom title").getTextFrameFormat().setRotationAngle(-30);

pres.save("out.pptx", SaveFormat.Pptx);


```