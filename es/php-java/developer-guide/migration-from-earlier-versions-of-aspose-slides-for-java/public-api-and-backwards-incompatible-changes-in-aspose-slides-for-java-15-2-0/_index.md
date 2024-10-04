---
title: API público y cambios incompatibles en Aspose.Slides para PHP a través de Java 15.2.0
type: docs
weight: 110
url: /es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las [clases añadidas](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/), métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) introducidos con la API de Aspose.Slides para PHP a través de Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

Hay problemas conocidos con algunos viñetas de imagen y objetos WordArt que se solucionarán en Aspose.Slides para PHP a través de Java 15.2.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Se han añadido los métodos addDataPointForDoughnutSeries**
Se han añadido los dos sobrecargas del método IChartDataPointCollection.addDataPointForDoughnutSeries() para añadir puntos de datos en series de tipo Doughnut.
### **La clase com.aspose.slides.SmartArtShape ha heredado de la clase com.aspose.slides.GeometryShape**
La clase com.aspose.slides.SmartArtShape ha heredado de la clase com.aspose.slides.GeometryShape. Este cambio mejora el modelo de objeto de Aspose.Slides y añade nuevas funcionalidades a la clase SmartArtShape.
### **Se han cambiado los métodos IGradientStopCollection.add(...) e IGradientStopCollection.insert(...)**
La firma de IGradientStop add(float position, int presetColor) se ha reemplazado con la firma IGradientStop addPresetColor(float position, int presetColor).

La firma del método IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) se ha reemplazado con la firma IGradientStop addSchemeColor(float position, int schemeColor).

La firma del método IGradientStopCollection void insert(int index, float position, int presetColor) se ha reemplazado con la firma void insertPresetColor(int index, float position, int presetColor).

La firma del método IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) se ha reemplazado con la firma void insertSchemeColor(int index, float position, int schemeColor).
### **Se ha añadido el método java.awt.Color getAutomaticSeriesColor() a com.aspose.slides.IChartSeries**
El método getAutomaticSeriesColor() devuelve un color automático de la serie basado en el índice de la serie y el estilo del gráfico. Este color se usa por defecto si FillType es igual a NotDefined.
﻿

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
  for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
    $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
  }
```
### **Se ha añadido un método para eliminar un punto de datos de gráfico y categoría de gráfico por su índice**
Se ha añadido el método IChartDataPointCollection.removeAt(int index) para eliminar un punto de datos de gráfico por su índice.
Se ha añadido el método IChartCategoryCollection.removeAt(int index) para eliminar una categoría de gráfico por su índice.
### **Se ha añadido el valor PptXPptY a la enumeración com.aspose.slides.PropertyType**
Se ha añadido el valor PptXPptY a la enumeración com.aspose.slides.PropertyType en el marco de una solución de problemas de serialización.