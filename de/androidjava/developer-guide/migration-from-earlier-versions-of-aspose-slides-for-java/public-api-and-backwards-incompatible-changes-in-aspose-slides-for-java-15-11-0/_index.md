---
title: Öffentliche API und nicht abwärtskompatible Änderungen in Aspose.Slides für Java 15.11.0
type: docs
weight: 190
url: /de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) oder [entfernten](/slides/de/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) Klassen, Methoden, Eigenschaften und so weiter sowie andere Änderungen auf, die mit der Aspose.Slides für Java 15.11.0 API eingeführt wurden.

{{% /alert %}} 
## **Änderungen der öffentlichen API**
#### **Veraltete Methoden in der Klasse com.aspose.slides.DataLabelCollection wurden gelöscht**
Veraltete Methoden in der Klasse com.aspose.slides.DataLabelCollection wurden gelöscht:

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


#### **Neue Methoden getFirstSlideNumber() und setFirstSlideNumber() wurden der Presentation-Klasse hinzugefügt**
Neue Methoden getFirstSlideNumber() und setFirstSlideNumber() ermöglichen es, die Nummer der ersten Folie in einer Präsentation abzurufen oder festzulegen.  
Wenn ein neuer Wert für die erste Foliennummer angegeben wird, werden alle Foliennummern neu berechnet.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```