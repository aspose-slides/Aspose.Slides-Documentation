---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro Java 15.11.0
linktitle: Aspose.Slides pro Java 15.11.0
type: docs
weight: 190
url: /cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a zásadní změny v Aspose.Slides pro Java, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) nebo [odstraněno](/slides/cs/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) třídy, metody, vlastnosti a další změny zavedené v API Aspose.Slides pro Java 15.11.0.

{{% /alert %}} 
## **Změny veřejného API**
#### **Zastaralé metody ve třídě com.aspose.slides.DataLabelCollection byly odstraněny**
Zastaralé metody ve třídě com.aspose.slides.DataLabelCollection byly odstraněny:

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


#### **Do třídy Presentation byly přidány nové metody getFirstSlideNumber() a setFirstSlideNumber()**
Nové metody getFirstSlideNumber() a setFirstSlideNumber() umožňují získat nebo nastavit číslo první snímku v prezentaci.
Když je zadána nová hodnota čísla první snímku, jsou přepočítána všechna čísla snímků.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```