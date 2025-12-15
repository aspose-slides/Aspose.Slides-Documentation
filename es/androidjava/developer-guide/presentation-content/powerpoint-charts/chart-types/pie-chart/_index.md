---
title: Personalizar gráficos de pastel en presentaciones en Android
linktitle: Gráfico de pastel
type: docs
url: /es/androidjava/pie-chart/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo crear y personalizar gráficos de pastel en Java con Aspose.Slides para Android, exportables a PowerPoint, impulsando su narración de datos en segundos."
---

## **Opciones de segunda trama para gráficos de pastel de pastel y barra de pastel**
Aspose.Slides para Android mediante Java ahora admite opciones de segunda trama para gráficos de pastel de pastel o barra de pastel. En este tema, le mostraremos cómo especificar esas opciones usando Aspose.Slides. Para especificar las propiedades, haga lo siguiente:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Agregar un gráfico a la diapositiva.
3. Especificar las opciones de segunda trama del gráfico.
4. Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos establecido diferentes propiedades del gráfico de pastel de pastel.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Añadir gráfico en la diapositiva
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


## **Establecer colores automáticos de porciones del gráfico de pastel**
Aspose.Slides para Android mediante Java proporciona una API sencilla para establecer colores automáticos de las porciones del gráfico de pastel. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Acceder a la primera diapositiva.
3. Agregar un gráfico con datos predeterminados.
4. Establecer el título del gráfico.
5. Configurar la primera serie para Mostrar Valores.
6. Establecer el índice de la hoja de datos del gráfico.
7. Obtener la hoja de cálculo de datos del gráfico.
8. Eliminar las series y categorías generadas por defecto.
9. Agregar nuevas categorías.
10. Agregar nuevas series.

Guardar la presentación modificada en un archivo PPTX.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Añadir gráfico con datos predeterminados
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Configurar el título del gráfico
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

    // Añadir nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Añadir nuevas series
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Ahora rellenando los datos de la serie
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

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [soporta](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) una trama secundaria para gráficos de pastel, incluidas las variantes 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (por ejemplo PNG) sin necesidad de toda la presentación.