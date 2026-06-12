---
title: Openbare API en terugwaartse incompatibele wijzigingen in Aspose.Slides voor Java 15.11.0
linktitle: Aspose.Slides voor Java 15.11.0
type: docs
weight: 190
url: /nl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- migratie
- legacycode
- moderne code
- legacy-aanpak
- moderne aanpak
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Bekijk de openbare API-updates en brekende wijzigingen in Aspose.Slides voor Java om uw PowerPoint PPT-, PPTX- en ODP-presentatieoplossingen soepel te migreren."
---
{{% alert color="primary" %}} 

Deze pagina geeft een overzicht van alle toegevoegde of verwijderde klassen, methoden, eigenschappen enzovoort, en andere wijzigingen die zijn geïntroduceerd met de Aspose.Slides for Java 15.11.0 API.

{{% /alert %}} 
## **Openbare API-wijzigingen**
#### **Verouderde methoden in de class com.aspose.slides.DataLabelCollection zijn verwijderd**
Verouderde methoden in de class com.aspose.slides.DataLabelCollection zijn verwijderd:

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


#### **Nieuwe methoden getFirstSlideNumber() en setFirstSlideNumber() zijn toegevoegd aan de Presentation-klasse**
De nieuwe methoden getFirstSlideNumber() en setFirstSlideNumber() maken het mogelijk om het nummer van de eerste dia in een presentatie op te vragen of in te stellen.
Wanneer een nieuwe waarde voor het eerste dia-nummer wordt opgegeven, worden alle dia-nummers opnieuw berekend.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```