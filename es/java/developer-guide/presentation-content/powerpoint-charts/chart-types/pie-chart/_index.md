---
title: Gráfico de Pastel
type: docs
url: /java/pie-chart/
---

## **Opciones de Segundo Gráfico para Gráfico de Pastel y Gráfico de Pastel de Barra**
Aspose.Slides para Java ahora admite opciones de segundo gráfico para el Gráfico de Pastel de Pastel o el Gráfico de Pastel de Barra. En este tema, le mostraremos cómo especificar esas opciones usando Aspose.Slides. Para especificar las propiedades, haga esto:

1. Instanciar el objeto de clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agregar gráfico en la diapositiva.
1. Especificar las opciones de segundo gráfico del gráfico.
1. Escribir la presentación en el disco.

En el ejemplo dado a continuación, hemos establecido diferentes propiedades del Gráfico de Pastel de Pastel.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Agregar gráfico en la diapositiva
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Establecer diferentes propiedades
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Escribir la presentación en el disco
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Colores de Rebana Automáticos para Gráfico de Pastel**
Aspose.Slides para Java proporciona una API simple para establecer colores automáticos de rebanada de gráfico de pastel. El código de muestra aplica el establecimiento de las propiedades mencionadas anteriormente.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Agregar gráfico con datos predeterminados.
1. Establecer el título del gráfico.
1. Establecer la primera serie para Mostrar Valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de trabajo de datos del gráfico.
1. Eliminar las series y categorías generadas por defecto.
1. Agregar nuevas categorías.
1. Agregar nuevas series.

Escriba la presentación modificada en un archivo PPTX.

```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Agregar gráfico con datos predeterminados
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Estableciendo el título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Título de Ejemplo");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Establecer la primera serie para Mostrar Valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Estableciendo el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;

    // Obteniendo la hoja de trabajo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Eliminar las series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Agregando nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Primer Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Segundo Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Tercer Trimestre"));

    // Agregando nuevas series
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Serie 1"), chart.getType());

    // Ahora poblando los datos de la serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```