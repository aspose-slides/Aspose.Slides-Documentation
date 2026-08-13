---
title: Cambios de la API pública y incompatibilidades retroactivas en Aspose.Slides for Java 15.11.0
linktitle: Aspose.Slides for Java 15.11.0
type: docs
weight: 190
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios disruptivos en Aspose.Slides for Java para migrar sin problemas tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las [añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) o [eliminadas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-11-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides for Java 15.11.0.

{{% /alert %}} 
## **Cambios de la API pública**
#### **Métodos obsoletos en la clase com.aspose.slides.DataLabelCollection han sido eliminados**
Se han eliminado los métodos obsoletos en la clase com.aspose.slides.DataLabelCollection:

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


#### **Se han añadido los nuevos métodos getFirstSlideNumber() y setFirstSlideNumber() a la clase Presentation**
Los nuevos métodos getFirstSlideNumber() y setFirstSlideNumber() permiten obtener o establecer el número de la primera diapositiva en una presentación.
Cuando se especifica un nuevo valor para el número de la primera diapositiva, se recalculan todos los números de diapositiva.

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