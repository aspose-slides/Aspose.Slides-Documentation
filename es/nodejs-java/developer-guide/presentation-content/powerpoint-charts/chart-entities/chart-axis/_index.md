---
title: "Eje del gráfico"
type: docs
url: /es/nodejs-java/chart-axis/
keywords: "Eje de gráfico de PowerPoint, Gráficos de presentación, Java, Manipular eje de gráfico, Datos del gráfico"
description: "Cómo editar el eje de un gráfico de PowerPoint en JavaScript"
---

## **Obtener los valores máximos en el eje vertical de los gráficos**

Aspose.Slides for Node.js a través de Java le permite obtener los valores mínimo y máximo en un eje vertical. Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Agregue un gráfico con datos predeterminados.
1. Obtenga el valor máximo real en el eje.
1. Obtenga el valor mínimo real en el eje.
1. Obtenga la unidad mayor real del eje.
1. Obtenga la unidad menor real del eje.
1. Obtenga la escala de unidad mayor real del eje.
1. Obtenga la escala de unidad menor real del eje.

Este código de ejemplo —una implementación de los pasos anteriores— muestra cómo obtener los valores requeridos en JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // Guarda la presentación
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Intercambiar los datos entre ejes**

Aspose.Slides le permite intercambiar rápidamente los datos entre ejes: los datos representados en el eje vertical (eje y) se trasladan al eje horizontal (eje x) y viceversa. 

Este código JavaScript le muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // Cambia filas y columnas
    chart.getChartData().switchRowColumn();
    // Guarda la presentación
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Desactivar el eje vertical en gráficos de líneas**

Este código JavaScript le muestra cómo ocultar el eje vertical en un gráfico de líneas:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Desactivar el eje horizontal en gráficos de líneas**

Este código le muestra cómo ocultar el eje horizontal en un gráfico de líneas:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Cambiar el eje de categorías**

Usando la propiedad **CategoryAxisType**, puede especificar el tipo de eje de categorías que prefiera (**date** o **text**). Este código en JavaScript demuestra la operación: 
```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Establecer el formato de fecha para el valor del eje de categorías**

Aspose.Slides for Node.js a través de Java le permite establecer el formato de fecha para un valor del eje de categorías. La operación se demuestra en este código JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```


## **Establecer el ángulo de rotación para el título del eje del gráfico**

Aspose.Slides for Node.js a través de Java le permite establecer el ángulo de rotación para el título de un eje de gráfico. Este código JavaScript demuestra la operación:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer la posición del eje en un eje de categorías o de valores**

Aspose.Slides for Node.js a través de Java le permite establecer la posición del eje en un eje de categorías o de valores. Este código JavaScript muestra cómo realizar la tarea:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Habilitar la etiqueta de unidad de visualización en el eje de valores del gráfico**

Aspose.Slides for Node.js a través de Java le permite configurar un gráfico para mostrar una etiqueta de unidad en su eje de valores del gráfico. Este código JavaScript demuestra la operación:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de eje)?**

Los ejes ofrecen una [configuración de cruce](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/): puede elegir cruzar en cero, en la categoría/valor máximo, o en un valor numérico específico. Esto es útil para desplazar el eje X hacia arriba o abajo o para enfatizar una línea base.

**¿Cómo puedo posicionar las etiquetas de marcas respecto al eje (junto, fuera, dentro)?**

Establezca la [posición de la etiqueta](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) a "cross", "outside" o "inside". Esto afecta la legibilidad y ayuda a conservar espacio, especialmente en gráficos pequeños.