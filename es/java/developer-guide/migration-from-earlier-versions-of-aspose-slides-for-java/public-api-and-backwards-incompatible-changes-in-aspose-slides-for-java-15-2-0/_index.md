---
title: API Pública y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para Java 15.2.0
type: docs
weight: 110
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [agregadas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) clases, métodos, propiedades, etc., nuevas restricciones y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) introducidos con la API Aspose.Slides para Java 15.2.0.

{{% /alert %}} {{% alert color="primary" %}} 

Hay problemas conocidos con algunas viñetas de imagen y objetos de WordArt que serán corregidos en Aspose.Slides para Java 15.2.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Se han agregado los métodos addDataPointForDoughnutSeries**
Se han agregado dos sobrecargas del método IChartDataPointCollection.addDataPointForDoughnutSeries() para agregar puntos de datos en series del tipo Doughnut.
### **La clase com.aspose.slides.SmartArtShape ha heredado de la clase com.aspose.slides.GeometryShape**
La clase com.aspose.slides.SmartArtShape ha heredado de la clase com.aspose.slides.GeometryShape. Este cambio mejora el modelo de objeto de Aspose.Slides y agrega nuevas características a la clase SmartArtShape.
### **Se han cambiado los métodos IGradientStopCollection.add(...) e IGradientStopCollection.insert(...)**
La firma de IGradientStop add(float position, int presetColor) se reemplaza con la firma IGradientStop addPresetColor(float position, int presetColor).

La firma del método IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) se reemplaza con la firma IGradientStop addSchemeColor(float position, int schemeColor).

La firma del método IGradientStopCollection void insert(int index, float position, int presetColor) se reemplaza con la firma void insertPresetColor(int index, float position, int presetColor).

La firma del método IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) se reemplaza con la firma void insertSchemeColor(int index, float position, int schemeColor).
### **Se ha añadido el método java.awt.Color getAutomaticSeriesColor() a com.aspose.slides.IChartSeries**
El método getAutomaticSeriesColor() devuelve un color automático de la serie basado en el índice de la serie y el estilo del gráfico. Este color se utiliza por defecto si FillType es igual a NotDefined.
﻿

``` java

 Presentacion pres = new Presentacion();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Se ha añadido un método para eliminar un punto de datos de gráfico y una categoría de gráfico por su índice**
Se ha añadido el método IChartDataPointCollection.removeAt(int index) para eliminar un punto de datos de gráfico por su índice.
Se ha añadido el método IChartCategoryCollection.removeAt(int index) para eliminar una categoría de gráfico por su índice.
### **Se ha añadido el valor PptXPptY a la enumeración com.aspose.slides.PropertyType**
Se ha añadido el valor PptXPptY a la enumeración com.aspose.slides.PropertyType en el ámbito de una corrección de problemas de serialización.