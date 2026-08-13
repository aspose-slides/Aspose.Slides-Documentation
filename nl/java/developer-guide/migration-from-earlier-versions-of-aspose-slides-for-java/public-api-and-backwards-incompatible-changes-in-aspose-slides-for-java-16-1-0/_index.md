---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides for Java 16.1.0
linktitle: Aspose.Slides for Java 16.1.0
type: docs
weight: 200
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/
keywords:
- migratie
- legacy-code
- moderne code
- legacy-benadering
- moderne benadering
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en doorbrekende wijzigingen in Aspose.Slides for Java om uw PowerPoint PPT-, PPTX- en ODP‑presentatieoplossingen soepel te migreren."
---
{{% alert color="info" %}} 

Deze pagina geeft een overzicht van alle [added](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) of [removed](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-16-1-0/) klassen, methoden, eigenschappen enzovoort, en andere veranderingen die geïntroduceerd zijn met de Aspose.Slides for Java 16.1.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**


#### **Methoden getRotationAngle() en setRotationAngle() zijn toegevoegd aan de IChartTextBlockFormat- en ITextFrameFormat-interfaces**
Methoden getRotationAngle() en setRotationAngle() zijn toegevoegd aan de interfaces com.aspose.slides.IChartTextBlockFormat en com.aspose.slides.ITextFrameFormat. Ze bieden toegang tot de aangepaste rotatie die op de tekst in het begrenzingsvak wordt toegepast.

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