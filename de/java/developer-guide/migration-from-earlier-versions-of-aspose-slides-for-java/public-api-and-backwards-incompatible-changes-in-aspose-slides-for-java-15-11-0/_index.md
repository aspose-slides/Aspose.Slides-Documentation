---
title: Öffentliche API und abwärtsinkompatible Änderungen in Aspose.Slides für Java 15.11.0
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- Migration
- Legacy-Code
- Moderner Code
- Legacy-Ansatz
- Moderner Ansatz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überblick über öffentliche API‑Updates und breaking changes in Aspose.Slides für Java, um Ihre PowerPoint‑PPT-, PPTX‑ und ODP‑Präsentationslösungen reibungslos zu migrieren."
---
{{% alert color="info" %}} 
Diese Seite listet alle [added](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) oder [removed](/slides/de/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) Klassen, Methoden, Eigenschaften usw. sowie weitere Änderungen, die mit der Aspose.Slides for Java 15.11.0 API eingeführt wurden.
{{% /alert %}} 
## **Public API Changes**
#### **Veraltete Methoden in der Klasse com.aspose.slides.DataLabelCollection wurden entfernt**
Veraltete Methoden in der Klasse com.aspose.slides.DataLabelCollection wurden entfernt:

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

#### **Neue Methoden getFirstSlideNumber() und setFirstSlideNumber() wurden der Klasse Presentation hinzugefügt**
Die neuen Methoden getFirstSlideNumber() und setFirstSlideNumber() ermöglichen das Abrufen bzw. Festlegen der Nummer der ersten Folie in einer Präsentation.  
Wenn ein neuer Wert für die Nummer der ersten Folie angegeben wird, werden alle Foliennummern neu berechnet.

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