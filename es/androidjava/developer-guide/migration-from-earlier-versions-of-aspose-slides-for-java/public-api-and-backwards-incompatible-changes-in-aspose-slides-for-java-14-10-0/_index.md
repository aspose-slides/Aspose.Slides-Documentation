---
title: API Pública y Cambios Incompatibles hacia Atrás en Aspose.Slides para Java 14.10.0
type: docs
weight: 90
url: /es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), métodos, propiedades y demás, cualquier nueva restricción y otros [cambios](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introducidos con la API de Aspose.Slides para Java 14.10.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Se ha agregado el método com.aspose.slides.FieldType.getFooter()**
El método getFooter() devuelve el tipo de campo de pie de página. Se ha agregado para implementar la posibilidad de crear campos de este tipo y para la serialización válida de presentaciones.
### **El elemento com.aspose.slides.ShapeElementFillSource.Own ha sido eliminado**
El elemento ShapeElementFillSource.Own ha sido eliminado por duplicado. Usa ShapeElementFillSource.Shape en lugar de ShapeElementFillSource.Own.
### **Se han agregado métodos para eliminar puntos de datos de gráficos y categorías**
**Se han agregado los siguientes métodos, que permiten eliminar un punto de datos de gráfico de una colección de puntos de datos:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Se ha agregado el siguiente método, que permite eliminar una categoría de gráfico de la colección contenida:**

IChartCategory.remove()

``` java

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
### **Se han eliminado métodos obsoletos de Aspose.Slides.ParagraphFormat**
Se han eliminado los métodos getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() y los métodos set correspondientes. Han sido marcados como obsoletos desde hace mucho tiempo.
### **Se han eliminado constructores innecesarios y obsoletos**
Los siguientes constructores han sido eliminados:

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