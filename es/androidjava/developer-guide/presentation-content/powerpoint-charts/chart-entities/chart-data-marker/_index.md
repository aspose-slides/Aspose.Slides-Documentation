---
title: Administrar marcadores de datos de gráficos en presentaciones en Android
linktitle: Marcador de datos
type: docs
url: /es/androidjava/chart-data-marker/
keywords:
- gráfico
- punto de datos
- marcador
- opciones de marcador
- tamaño del marcador
- tipo de relleno
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Personaliza los marcadores de datos de gráficos en Aspose.Slides para Android, mejorando el impacto de la presentación en formatos PPT y PPTX con ejemplos claros de código Java."
---

## **Establecer opciones de marcador de gráfico**
Los marcadores se pueden establecer en los puntos de datos del gráfico dentro de series específicas. Para configurar las opciones de marcador del gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Obtener la primera serie del gráfico.
- Añadir un nuevo punto de datos.
- Guardar la presentación en disco.

En el ejemplo mostrado a continuación, hemos configurado las opciones de marcador del gráfico a nivel de puntos de datos.
```java
// Crear presentación vacía
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Crear el gráfico predeterminado
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Obtener el índice de la hoja de cálculo de datos del gráfico predeterminado
    int defaultWorksheetIndex = 0;
    
    // Obtener la hoja de cálculo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Eliminar la serie de demostración
    chart.getChartData().getSeries().clear();
    
    // Agregar nueva serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Cargar la imagen 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Cargar la imagen 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Tomar la primera serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Agregar nuevo punto (1:3) allí.
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
    
    // Cambiar el marcador de la serie del gráfico
    series.getMarker().setSize(15);
    
    // Guardar la presentación con el gráfico
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Qué formas de marcador están disponibles de forma predeterminada?**
Están disponibles formas estándar (círculo, cuadrado, diamante, triángulo, etc.); la lista está definida por la clase [MarkerStyleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markerstyletype/). Si necesita una forma no estándar, utilice un marcador con relleno de imagen para emular visuales personalizadas.

**¿Se conservan los marcadores al exportar un gráfico a una imagen o SVG?**
Sí. Al renderizar gráficos a [formatos raster](/slides/es/androidjava/convert-powerpoint-to-png/) o guardar [formas como SVG](/slides/es/androidjava/render-a-slide-as-an-svg-image/), los marcadores mantienen su apariencia y configuración, incluyendo tamaño, relleno y contorno.