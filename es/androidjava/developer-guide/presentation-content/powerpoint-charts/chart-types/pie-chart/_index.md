---
title: Gráfico de Pastel
type: docs
url: /es/androidjava/pie-chart/
---

## **Opciones de Segundo Gráfico para Gráfico de Pastel de Pastel y Gráfico de Pastel de Barra**
Aspose.Slides para Android a través de Java ahora admite opciones de segundo gráfico para Gráfico de Pastel de Pastel o Gráfico de Pastel de Barra. En este tema, le mostraremos cómo especificar esas opciones utilizando Aspose.Slides. Para especificar las propiedades, haga lo siguiente:

1. Instancie el objeto de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Agregue un gráfico en la diapositiva.
1. Especifique las opciones de segundo gráfico del gráfico.
1. Escriba la presentación en disco.

En el ejemplo que se muestra a continuación, hemos establecido diferentes propiedades del Gráfico de Pastel de Pastel.

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
    
    // Escribir presentación en disco
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Colores de Rebanadas de Gráfico de Pastel Automáticos**
Aspose.Slides para Android a través de Java proporciona una API simple para establecer colores de rebanadas de gráfico de pastel automáticos. El código de ejemplo aplica la configuración de las propiedades mencionadas anteriormente.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Agregue un gráfico con datos predeterminados.
1. Establezca el Título del gráfico.
1. Establezca la primera serie para Mostrar Valores.
1. Establezca el índice de la hoja de datos del gráfico.
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

    // Estableciendo el Título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Título de Ejemplo");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Establecer la primera serie para Mostrar Valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Estableciendo el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;

    // Obtener la hoja de trabajo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Eliminar las series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Agregar nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Primer Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Segundo Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Tercer Trimestre"));

    // Agregar nuevas series
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