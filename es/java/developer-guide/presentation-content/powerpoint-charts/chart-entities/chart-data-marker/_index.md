---
title: Administrar marcadores de datos de gráfico en presentaciones usando Java
linktitle: Marcador de datos
type: docs
url: /es/java/chart-data-marker/
keywords:
- gráfica
- punto de datos
- marcador
- opciones de marcador
- tamaño del marcador
- tipo de relleno
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a personalizar los marcadores de datos de gráfico en Aspose.Slides para Java, mejorando el impacto de las presentaciones en formatos PPT y PPTX con ejemplos claros de código Java."
---

## **Establecer opciones de marcador de gráfico**
Los marcadores pueden establecerse en los puntos de datos del gráfico dentro de series específicas. Para establecer opciones de marcador de gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Tomar la primera serie del gráfico.
- Añadir un nuevo punto de datos.
- Guardar la presentación en disco.

En el ejemplo a continuación, hemos establecido las opciones de marcador de gráfico a nivel de puntos de datos.
```java
// Creando presentación vacía
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Creando el gráfico predeterminado
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Obteniendo el índice de la hoja de cálculo de datos del gráfico predeterminado
    int defaultWorksheetIndex = 0;
    
    // Obteniendo la hoja de cálculo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Eliminar serie de demostración
    chart.getChartData().getSeries().clear();
    
    // Añadir nueva serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Cargar la imagen 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Cargar la imagen 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Tomar la primera serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Añadir nuevo punto (1:3) allí.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Cambiando el marcador de la serie del gráfico
    series.getMarker().setSize(15);
    
    // Guardar presentación con gráfico
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Qué formas de marcador están disponibles de forma predeterminada?**

Las formas estándar están disponibles (círculo, cuadrado, diamante, triángulo, etc.); la lista está definida por la clase [MarkerStyleType](https://reference.aspose.com/slides/java/com.aspose.slides/markerstyletype/). Si necesita una forma no estándar, use un marcador con relleno de imagen para emular elementos visuales personalizados.

**¿Se conservan los marcadores al exportar un gráfico a una imagen o SVG?**

Sí. Al renderizar gráficos a [formatos raster](/slides/es/java/convert-powerpoint-to-png/) o al guardar [formas como SVG](/slides/es/java/render-a-slide-as-an-svg-image/), los marcadores conservan su apariencia y configuración, incluido el tamaño, el relleno y el contorno.