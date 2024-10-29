---
title: API público y cambios incompatibles hacia atrás en Aspose.Slides para Java 15.11.0
type: docs
weight: 190
url: /es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [agregadas](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) o [eliminadas](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para Java 15.11.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Métodos obsoletos en la clase com.aspose.slides.DataLabelCollection han sido eliminados**
Métodos obsoletos en la clase com.aspose.slides.DataLabelCollection han sido eliminados:

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


#### **Se han añadido nuevos métodos getFirstSlideNumber() y setFirstSlideNumber() a la clase Presentation**
Los nuevos métodos getFirstSlideNumber() y setFirstSlideNumber() permiten obtener o establecer el número de la primera diapositiva en una presentación.
Cuando se especifica un nuevo valor de número de primera diapositiva, se recalculan todos los números de las diapositivas.

``` java

 Presentation pres = new Presentation(path);

int firstSlideNumber = pres.getFirstSlideNumber();

pres.setFirstSlideNumber(10);

pres.save(newPath, SaveFormat.Pptx);

```