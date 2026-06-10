---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for Java 15.11.0-ban
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for Java nyilvános API frissítéseit és visszafelé nem kompatibilis változásait, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}}

Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) vagy [eltávolított](/slides/hu/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) osztályt, metódust, tulajdonságot stb., valamint az Aspose.Slides for Java 15.11.0 API-val bevezetett egyéb változásokat.

{{% /alert %}}
## **Nyilvános API változások**
#### **A com.aspose.slides.DataLabelCollection osztály elavult metódusai törölve lettek**
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


#### **Új getFirstSlideNumber() és setFirstSlideNumber() metódusok kerültek hozzáadásra a Presentation osztályhoz**
Az új getFirstSlideNumber() és setFirstSlideNumber() metódusok lehetővé teszik az első dia számának lekérdezését vagy beállítását egy prezentációban.
Ha új első dia számérték kerül megadásra, az összes dia száma újraszámításra kerül.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```