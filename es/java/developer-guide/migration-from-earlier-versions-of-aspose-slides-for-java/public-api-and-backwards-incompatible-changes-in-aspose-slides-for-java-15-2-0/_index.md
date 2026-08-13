---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para Java 15.2.0
linktitle: Aspose.Slides para Java 15.2.0
type: docs
weight: 110
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
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
description: "Revisa las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para Java para migrar sin problemas tus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}}

Esta página enumera todas las [añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) clases, métodos, propiedades, etc., así como nuevas restricciones y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) introducidos con la API de Aspose.Slides para Java 15.2.0.

{{% /alert %}} {{% alert color="info" %}}

Se conocen problemas con algunas viñetas de imagen y objetos WordArt que se corregirán en Aspose.Slides para Java 15.2.0.

{{% /alert %}}
## **Cambios de la API pública**
### **addDataPointForDoughnutSeries methods have been added**
Se han añadido los métodos addDataPointForDoughnutSeries. Las dos sobrecargas del método IChartDataPointCollection.addDataPointForDoughnutSeries() se han añadido para agregar puntos de datos a series de tipo Doughnut.
### **com.aspose.slides.SmartArtShape class has been inherited from com.aspose.slides.GeometryShape class**
La clase com.aspose.slides.SmartArtShape ha heredado de la clase com.aspose.slides.GeometryShape. Este cambio mejora el modelo de objetos de Aspose.Slides y añade nuevas funcionalidades a la clase SmartArtShape.
### **IGradientStopCollection.add(...) and IGradientStopCollection.insert(...) methods have been changed**
La firma de IGradientStop add(float position, int presetColor) se ha sustituido por la firma IGradientStop addPresetColor(float position, int presetColor).

La firma del método IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) se ha sustituido por la firma IGradientStop addSchemeColor(float position, int schemeColor).

La firma del método IGradientStopCollection void insert(int index, float position, int presetColor) se ha sustituido por la firma void insertPresetColor(int index, float position, int presetColor).

La firma del método IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) se ha sustituido por la firma void insertSchemeColor(int index, float position, int schemeColor).
### **java.awt.Color getAutomaticSeriesColor() method has been added to com.aspose.slides.IChartSeries**
Se ha añadido el método java.awt.Color getAutomaticSeriesColor() a com.aspose.slides.IChartSeries. El método getAutomaticSeriesColor() devuelve un color automático de la serie basado en el índice de la serie y el estilo del gráfico. Este color se utiliza por defecto si FillType es igual a NotDefined.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **Method for removing chart data point and chart category by its index has been added**
Se ha añadido el método para eliminar puntos de datos y categorías de gráfico por su índice. Se ha añadido el método IChartDataPointCollection.removeAt(int index) para eliminar un punto de datos del gráfico por su índice. Se ha añadido el método IChartCategoryCollection.removeAt(int index) para eliminar una categoría del gráfico por su índice.
### **PptXPptY value has been added to com.aspose.slides.PropertyType enumeration**
Se ha añadido el valor PptXPptY a la enumeración com.aspose.slides.PropertyType en el contexto de una corrección de un problema de serialización.