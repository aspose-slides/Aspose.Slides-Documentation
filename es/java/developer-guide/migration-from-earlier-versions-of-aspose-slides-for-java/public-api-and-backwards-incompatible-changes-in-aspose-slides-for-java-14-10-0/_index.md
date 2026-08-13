---
title: Cambios de API pública y incompatibilidades retroactivas en Aspose.Slides for Java 14.10.0
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
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

Esta página enumera todas las [añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) clases, métodos, propiedades y demás, cualquier nueva restricción y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introducidos con la API de Aspose.Slides for Java 14.10.0.

{{% /alert %}} 
## **Cambios de la API pública**
### **Se ha añadido el método com.aspose.slides.FieldType.getFooter()**
El método getFooter() devuelve el tipo de campo de pie de página. Se ha añadido para permitir la creación de campos de este tipo y para una serialización válida de la presentación.
### **Se ha eliminado el elemento com.aspose.slides.ShapeElementFillSource.Own**
El elemento ShapeElementFillSource.Own se ha eliminado por estar duplicado. Use ShapeElementFillSource.Shape en lugar de ShapeElementFillSource.Own.
### **Se han añadido métodos para eliminar puntos de datos de gráficos y categorías**
**Los siguientes métodos, que permiten eliminar un punto de datos de gráfico de una colección de puntos de datos, se han añadido:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**El siguiente método, que permite eliminar una categoría de gráfico de la colección contenedora, se ha añadido:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // eliminar con ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // eliminar con ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // eliminar con ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);
```
### **Se han eliminado los métodos obsoletos de Aspose.Slides.ParagraphFormat**
Los métodos getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() y los métodos set correspondientes se han eliminado. Fueron marcados como obsoletos hace mucho tiempo.
### **Se han eliminado los constructores inútiles y obsoletos**
Se han eliminado los siguientes constructores:

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)