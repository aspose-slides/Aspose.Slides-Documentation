---
title: Personalizar gráficos de pastel en presentaciones usando Java
linktitle: Gráfico de pastel
type: docs
url: /es/java/pie-chart/
keywords:
- gráfico de pastel
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración de gráfico
- opciones de trazado
- color de porción
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos de pastel en Java con Aspose.Slides, exportables a PowerPoint, impulsando su narrativa de datos en segundos."
---

## **Opciones de segunda trama para gráficos Pie of Pie y Bar of Pie**
Aspose.Slides for Java ahora admite opciones de segunda trama para gráficos Pie of Pie o Bar of Pie. En este tema, le mostraremos cómo especificar esas opciones usando Aspose.Slides. Para especificar las propiedades, haga lo siguiente:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Agregar un gráfico en la diapositiva.
1. Especificar las opciones de segunda trama del gráfico.
1. Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos configurado diferentes propiedades del gráfico Pie of Pie.
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
    
    // Guardar la presentación en disco
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer colores automáticos de las porciones del gráfico de pastel**
Aspose.Slides for Java proporciona una API sencilla para establecer colores automáticos de las porciones del gráfico de pastel. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Establecer el título del gráfico.
1. Configurar la primera serie para Mostrar Valores.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener la hoja de cálculo de datos del gráfico.
1. Eliminar las series y categorías generadas por defecto.
1. Agregar nuevas categorías.
1. Agregar una nueva serie.

Guardar la presentación modificada en un archivo PPTX.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Agregar gráfico con datos predeterminados
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Establecer el título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Establecer la primera serie para Mostrar Valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Establecer el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;

    // Obtener la hoja de cálculo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Eliminar series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Agregar nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Agregar una nueva serie
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Ahora rellenando datos de la serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Se admiten las variaciones 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) una segunda trama para gráficos de pastel, incluidas los tipos 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) (por ejemplo PNG) sin la presentación completa.