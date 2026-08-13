---
title: Offentligt API och bakåtinkompatibla förändringar i Aspose.Slides för Java 15.11.0
linktitle: Aspose.Slides för Java 15.11.0
type: docs
weight: 190
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- migrering
- gammal kod
- modern kod
- gammal metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint PPT-, PPTX- och ODP-presentationer."
---
{{% alert color="info" %}} 

Den här sidan listar alla [tillagda](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) eller [borttagna](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) klasser, metoder, egenskaper osv., samt andra ändringar som införts med Aspose.Slides for Java 15.11.0 API.

{{% /alert %}} 
## **Ändringar i offentligt API**
#### **Föråldrade metoder i com.aspose.slides.DataLabelCollection-klassen har tagits bort**
Föråldrade metoder i com.aspose.slides.DataLabelCollection-klassen har tagits bort:

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


#### **Nya metoder getFirstSlideNumber() och setFirstSlideNumber() har lagts till i Presentation-klassen**
De nya metoderna getFirstSlideNumber() och setFirstSlideNumber() möjliggör att hämta eller sätta numret på den första bilden i en presentation.
När ett nytt värde för första bildens nummer anges, beräknas alla bildnummer om.

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