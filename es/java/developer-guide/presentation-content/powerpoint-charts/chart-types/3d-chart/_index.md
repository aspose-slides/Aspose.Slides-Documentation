---
title: Gráfico 3D
type: docs
url: /es/java/3d-chart/
---

## **Establecer las propiedades RotationX, RotationY y DepthPercents de Gráfico 3D**
Aspose.Slides para Java proporciona una API simple para establecer estas propiedades. Este siguiente artículo te ayudará a configurar diferentes propiedades como **Rotación X, Rotación Y, DepthPercents** etc. El código de muestra aplica la configuración de las propiedades mencionadas anteriormente.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accede a la primera diapositiva.
1. Agrega un gráfico con datos predeterminados.
1. Establece las propiedades Rotation3D.
1. Escribe la presentación modificada en un archivo PPTX.

```java
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Agrega un gráfico con datos predeterminados
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Establecer el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtener la hoja de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Agregar series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.getType());
    
    // Agregar categorías
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Categoría 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Categoría 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Categoría 3"));
    
    // Establecer las propiedades Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Tomar la segunda serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Ahora populando los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Establecer el valor de OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Escribir la presentación en disco
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```