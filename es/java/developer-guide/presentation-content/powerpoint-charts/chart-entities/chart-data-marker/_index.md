---
title: Marcador de Datos del Gráfico
type: docs
url: /es/java/chart-data-marker/
---

## **Establecer Opciones de Marcador del Gráfico**
Los marcadores se pueden establecer en puntos de datos del gráfico dentro de series particulares. Para establecer opciones de marcador del gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Crear el gráfico por defecto.
- Establecer la imagen.
- Tomar la primera serie del gráfico.
- Agregar un nuevo punto de datos.
- Escribir la presentación en el disco.

En el ejemplo dado a continuación, hemos establecido las opciones de marcador del gráfico a nivel de puntos de datos.

```java
// Creando una presentación vacía
Presentation pres = new Presentation();
try {
    // Accediendo a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Creando el gráfico por defecto
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Obteniendo el índice de la hoja de trabajo de datos del gráfico por defecto
    int defaultWorksheetIndex = 0;
    
    // Obteniendo la hoja de trabajo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Eliminar la serie de demostración
    chart.getChartData().getSeries().clear();
    
    // Agregar nueva serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.getType());

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
    
    // Cambiando el marcador de la serie del gráfico
    series.getMarker().setSize(15);
    
    // Guardar presentación con gráfico
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```