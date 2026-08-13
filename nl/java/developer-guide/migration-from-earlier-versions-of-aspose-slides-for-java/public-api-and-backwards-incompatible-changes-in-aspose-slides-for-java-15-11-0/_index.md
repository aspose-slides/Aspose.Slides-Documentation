---
title: Openbare API en achterwaarts incompatibele wijzigingen in Aspose.Slides voor Java 15.11.0
linktitle: Aspose.Slides voor Java 15.11.0
type: docs
weight: 190
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- migratie
- legacycode
- moderne code
- legacy‑benadering
- moderne benadering
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de updates van de openbare API en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT, PPTX en ODP presentatietoepassingen soepel te migreren."
---
{{% alert color="info" %}} 
Deze pagina geeft een overzicht van alle [added](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) of [removed](/slides/nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die zijn geïntroduceerd met de Aspose.Slides for Java 15.11.0 API.
{{% /alert %}} 
## **Wijzigingen in de openbare API**
#### **Obsolete methoden in de klasse com.aspose.slides.DataLabelCollection zijn verwijderd**
Obsolete methoden in de klasse com.aspose.slides.DataLabelCollection zijn verwijderd:

DataLabelCollection.getNumberFormat()
DataLabelCollection.setNumberFormat(String value)
DataLabelCollection.getLinkedSource()
DataLabelCollection.setLinkedSource(boolean value)
DataLabelCollection.getDelete()
DataLabelCollection.setDelete(boolean value)
DataLabelCollection.getFormat()
DataLabelCollection.setFormat(Format value)
DataLabelCollection.getPosition()
DataLabelCollection.setPosition(int value)
DataLabelCollection.getSeparator()
DataLabelCollection.setSeparator(String value)
DataLabelCollection.getShowLegendKey()
DataLabelCollection.setShowLegendKey(boolean value)
DataLabelCollection.getShowLeaderLines()
DataLabelCollection.setShowLeaderLines(boolean value)
DataLabelCollection.getShowCategoryName()
DataLabelCollection.setShowCategoryName(boolean value)
DataLabelCollection.getShowValue()
DataLabelCollection.setShowValue(boolean value)
DataLabelCollection.getShowPercentage()
DataLabelCollection.setShowPercentage(boolean value)
DataLabelCollection.getShowSeriesName()
DataLabelCollection.setShowSeriesName(boolean value)
DataLabelCollection.getShowBubbleSize()
DataLabelCollection.setShowBubbleSize(boolean value)


#### **Nieuwe methoden getFirstSlideNumber() en setFirstSlideNumber() zijn toegevoegd aan de klasse Presentation**
De nieuwe methoden getFirstSlideNumber() en setFirstSlideNumber() stellen u in staat om het nummer van de eerste dia in een presentatie op te vragen of in te stellen.
Wanneer een nieuwe waarde voor het nummer van de eerste dia wordt opgegeven, worden alle dia‑nummers opnieuw berekend.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    int firstSlideNumber = pres.getFirstSlideNumber();

    pres.setFirstSlideNumber(10);

    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```