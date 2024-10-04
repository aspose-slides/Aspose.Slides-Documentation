---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para PHP a través de Java 14.10.0
type: docs
weight: 90
url: /php-java/api-publica-y-cambios-incompatibles-hacia-atras-en-aspose-slides-para-java-14-10-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las [clases añadidas](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/), métodos, propiedades, y así sucesivamente, cualquier nueva restricción y otros [cambios](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) introducidos con la API Aspose.Slides para PHP a través de Java 14.10.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **El método com.aspose.slides.FieldType::getFooter() ha sido añadido**
El método getFooter() devuelve el tipo de campo de pie de página. Se ha añadido para la implementación de la posibilidad de crear campos de este tipo y para una serialización de presentación válida.
### **El elemento com.aspose.slides.ShapeElementFillSource.Own ha sido eliminado**
El elemento ShapeElementFillSource.Own ha sido eliminado como duplicado. Utilice ShapeElementFillSource.Shape en lugar de ShapeElementFillSource.Own.
### **Se han añadido métodos para eliminar puntos de datos de gráficos y categorías**
**Se han añadido los siguientes métodos, que permiten eliminar un punto de datos de gráfico de una colección de puntos de datos de gráfico:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**Se ha añadido el siguiente método, que permite eliminar una categoría de gráfico de la colección que la contiene:**

IChartCategory.remove()

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 400, true);
  $chart->getChartData()->getCategories()->get_Item(0)->remove();// eliminar con ChartCategory.remove()

  $chart->getChartData()->getCategories()->remove($chart->getChartData()->getCategories()->get_Item(0));// eliminar con ChartCategoryCollection.remove()

  foreach($chart->getChartData()->getSeries() as $ser) {
    $ser->getDataPoints()->get_Item(0)->remove();// eliminar con ChartDataPoint.remove()

    $ser->getDataPoints()->remove($ser->getDataPoints()->get_Item(0));// ChartDataPointCollection.remove()

  }
  $pres->save("presentation.pptx", SaveFormat::Pptx);

```
### **Se han eliminado métodos obsoletos de Aspose.Slides.ParagraphFormat**
Los métodos getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() y los métodos de conjunto correspondientes han sido eliminados. Se marcaron como obsoletos hace mucho tiempo.
### **Se han eliminado constructores no útiles y obsoletos**
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