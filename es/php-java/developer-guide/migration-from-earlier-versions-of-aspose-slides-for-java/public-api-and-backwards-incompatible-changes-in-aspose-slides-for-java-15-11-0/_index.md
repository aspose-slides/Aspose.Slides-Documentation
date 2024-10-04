---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para PHP a través de Java 15.11.0
type: docs
weight: 190
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc. [agregados](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) o [eliminados](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/), y otros cambios introducidos con la API de Aspose.Slides para PHP a través de Java 15.11.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se han eliminado métodos obsoletos en la clase com.aspose.slides.DataLabelCollection**
Se han eliminado métodos obsoletos en la clase com.aspose.slides.DataLabelCollection:

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


#### **Se han agregado nuevos métodos getFirstSlideNumber() y setFirstSlideNumber() a la clase Presentation**
Los nuevos métodos getFirstSlideNumber() y setFirstSlideNumber() permiten obtener o establecer el número de la primera diapositiva en una presentación.
Cuando se especifica un nuevo valor para el número de la primera diapositiva, todos los números de diapositivas se recalculan.

```php
  $pres = new Presentation($path);
  $firstSlideNumber = $pres->getFirstSlideNumber();
  $pres->setFirstSlideNumber(10);
  $pres->save($newPath, SaveFormat::Pptx);

```