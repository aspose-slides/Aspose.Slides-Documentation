---
title: Gráfico de pastel
type: docs
url: /es/nodejs-java/pie-chart/
---

## **Opciones de segundo trazado para los gráficos Pie of Pie y Bar of Pie**
Aspose.Slides for Node.js via Java ahora admite opciones de segundo trazado para los gráficos Pie of Pie o Bar of Pie. En este tema, le mostraremos cómo especificar esas opciones usando Aspose.Slides. Para especificar las propiedades, haga lo siguiente:

1. Instanciar el objeto de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Agregar un gráfico a la diapositiva.
3. Especificar las opciones de segundo trazado del gráfico.
4. Guardar la presentación en disco.

En el ejemplo a continuación, hemos configurado diferentes propiedades del gráfico Pie of Pie.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Añadir gráfico en la diapositiva
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Establecer diferentes propiedades
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Guardar la presentación en disco
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer colores automáticos de las porciones del gráfico de pastel**
Aspose.Slides for Node.js via Java proporciona una API simple para establecer colores automáticos de las porciones del gráfico de pastel. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Acceder a la primera diapositiva.
3. Agregar un gráfico con datos predeterminados.
4. Establecer el título del gráfico.
5. Configurar la primera serie para mostrar valores.
6. Establecer el índice de la hoja de datos del gráfico.
7. Obtener la hoja de trabajo de datos del gráfico.
8. Eliminar las series y categorías generadas por defecto.
9. Agregar nuevas categorías.
10. Agregar una nueva serie.

Guardar la presentación modificada en un archivo PPTX.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Añadir gráfico con datos predeterminados
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Establecer el título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Establecer la primera serie para mostrar valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Establecer el índice de la hoja de datos del gráfico
    var defaultWorksheetIndex = 0;
    // Obtener la hoja de datos del gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Eliminar series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Añadiendo nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Añadiendo nueva serie
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Ahora rellenando datos de la serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) un trazado secundario para gráficos de pastel, incluidos los tipos 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (por ejemplo, PNG) sin toda la presentación.