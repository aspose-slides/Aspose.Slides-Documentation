---
title: Publiczne API i niekompatybilne zmiany wstecz w Aspose.Slides for Java 15.11.0
linktitle: Aspose.Slides dla Java 15.11.0
type: docs
weight: 190
url: /pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- migracja
- kod dziedziczony
- nowoczesny kod
- dziedziczne podejście
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Przeglądaj aktualizacje publicznego API i zmiany łamiące kompatybilność w Aspose.Slides for Java, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 
Ta strona wymienia wszystkie [dodane](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) lub [usunięte](/slides/pl/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for Java 15.11.0.
{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Przestarzałe metody w klasie com.aspose.slides.DataLabelCollection zostały usunięte**
Przestarzałe metody w klasie com.aspose.slides.DataLabelCollection zostały usunięte:

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


#### **Dodano nowe metody getFirstSlideNumber() i setFirstSlideNumber() do klasy Presentation**
Nowe metody getFirstSlideNumber() i setFirstSlideNumber() umożliwiają pobranie lub ustawienie numeru pierwszego slajdu w prezentacji. Po określeniu nowej wartości numeru pierwszego slajdu wszystkie numery slajdów są przeliczane.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```