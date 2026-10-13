---
title: Personalizar ejes de gráfico en presentaciones usando JavaScript
linktitle: Eje del gráfico
type: docs
url: /es/nodejs-java/chart-axis/
keywords:
- eje del gráfico
- eje vertical
- eje horizontal
- personalizar eje
- manipular eje
- gestionar eje
- propiedades del eje
- valor máximo
- valor mínimo
- línea del eje
- formato de fecha
- título del eje
- posición del eje
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra cómo usar JavaScript con Aspose.Slides para Node.js vía Java para personalizar los ejes de los gráficos en presentaciones de PowerPoint para informes y visualizaciones."
---
## **Visión general**

Este artículo explica cómo personalizar los ejes de los gráficos con Aspose.Slides para Node.js a través de Java. Cubre valores de ejes calculados, el intercambio de filas y columnas del gráfico, la visibilidad del eje, los intervalos de etiquetas de categoría y marcas de graduación, categorías y formato de fechas, la rotación del título, la posición del eje, unidades de visualización y el escalado logarítmico.

## **Obtener los valores máximos en el eje vertical de los gráficos**

Cree una [Presentación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) y añada un gráfico de áreas con datos predeterminados. Llame a [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) antes de leer los valores de eje calculados para que el diseño del gráfico esté actualizado.

Lea [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) y [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) para los límites del eje, y [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) y [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) para los intervalos de marcas. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) y [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) proporcionan escalas de unidades de tiempo, que son relevantes para los ejes de fechas. El ejemplo guarda estos valores en variables locales y guarda el gráfico.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Intercambiar los datos entre ejes**

Utilice [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) para intercambiar los roles de series y categorías en los datos del gráfico. Cada categoría anterior se convierte en una serie, y cada serie anterior se convierte en una categoría. Esto cambia la forma en que se agrupan los datos; no intercambia los ejes horizontal y vertical. El ejemplo usa [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) para enlazar los datos predeterminados a `Sheet1!A1:D5`, incluida la fila de encabezado y la columna de categoría, antes de intercambiar filas y columnas. Guarda un gráfico con cuatro series y tres categorías.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desactivar el eje vertical para gráficos de líneas**

Llame a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) con `false` en el eje vertical para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje vertical oculto.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desactivar el eje horizontal para gráficos de líneas**

Llame a [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) con `false` en el eje horizontal para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje horizontal oculto.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cambiar un eje de categoría**

Utilice [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) para elegir un eje de categoría de fecha o texto. Este ejemplo requiere `ExistingChart.pptx`, con un gráfico como la primera forma de la primera diapositiva y celdas de categoría que contienen valores numéricos de fechas de Excel. Cambia el eje horizontal a un eje de fecha. Llamar a [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) con `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) con `1` y [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) con `TimeUnitType.Months` coloca marcas principales a intervalos de un mes.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar los intervalos de etiquetas del eje de categoría**

Cuando un gráfico tiene muchas categorías, reduzca el número de etiquetas de eje visibles sin eliminar categorías o puntos de datos. Llame a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) con `false`, luego pase el intervalo de categoría deseado a [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Para categorías de texto en su orden normal, la cuenta comienza en la primera categoría:

| Intervalo | Etiquetas mostradas en el ejemplo |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Un intervalo de `3` muestra cada tercera etiqueta, dejando dos etiquetas ocultas entre las mostradas. No elimina las columnas correspondientes. El espaciado automático elige un intervalo en función del espacio disponible; no necesariamente muestra todas las etiquetas.

Las marcas de graduación tienen controles separados. Llame a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) con `false` y use [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) para establecer su intervalo. Por ejemplo, `1` mantiene una marca de graduación en cada intervalo de categoría mientras las etiquetas aparecen solo cada tercera categoría. Use [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) con un estilo visible para poder ver el resultado. Llamar a cualquiera de los setters de espaciado automático con `true` de nuevo permite que el gráfico elija ese intervalo nuevamente.

El siguiente ejemplo autocontenido crea 24 categorías y una serie, luego guarda tres diapositivas en `CategoryAxisIntervals.pptx`: espaciado automático, espaciado manual de etiquetas con marcas de graduación independientes y espaciado automático restaurado. Las dos copias conservan los datos originales del gráfico. No se requiere una presentación de entrada. El texto de etiqueta horizontal facilita observar la diferencia de densidad.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Diapositiva 2: mostrar cada tercera etiqueta, pero mantener una marca de graduación para cada categoría.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Diapositiva 3: permitir que el gráfico elija ambos intervalos nuevamente.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Espaciado automático (diapositiva 1):** En esta representación, se muestra cada segunda etiqueta de categoría y se envuelve en dos líneas. El resultado automático puede variar según el tamaño del gráfico, las fuentes y el motor de renderizado.

![Espaciado automático de etiquetas de categoría con las 24 columnas visibles](category-axis-automatic.png)

**Espaciado manual (diapositiva 2):** Cada tercera etiqueta se muestra en una línea, mientras que las marcas de graduación permanecen en cada intervalo de categoría. Todas las 24 columnas, incluidas las que no tienen etiquetas, siguen visibles con los mismos valores. La diapositiva 3 restaura la apariencia automática mostrada arriba.

![Espaciado manual de etiquetas de categoría de tres con las 24 columnas visibles](category-axis-manual.png)

### **Elegir el eje y el intervalo correctos**

Utilice este intervalo de recuento de categorías para un eje de categoría de texto, como el eje de categoría de un gráfico de columnas, líneas, áreas o barras. En un gráfico de columnas, es el eje horizontal. En un gráfico de barras horizontal, el eje de categoría es vertical, por lo que se aplican estos ajustes al eje devuelto por [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). El espaciado de marcas de graduación también se aplica a un eje de serie en los gráficos que lo tengan.

No utilice el espaciado de etiquetas de categoría para establecer la escala numérica de un eje de valor. En un eje de valor, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) especifica una diferencia en los valores: por ejemplo, una unidad mayor de `10` produce marcas en 0, 10, 20, etc., cuando el eje comienza en cero. Un intervalo de etiqueta de categoría de `3` cuenta posiciones de categoría, independientemente de sus valores de datos. Los gráficos de dispersión y burbuja usan ejes de valor en lugar de un eje de categoría de texto. Para un eje de fecha, use unidades mayores basadas en tiempo y escalas como se describe en [Cambiar un eje de categoría](#cambiar-un-eje-de-categoría).

## **Establecer el formato de fecha para los valores del eje de categoría**

El ejemplo sustituye los datos predeterminados del gráfico por cuatro valores anuales. Las fechas se almacenan como números de serie OLE Automation en la primera hoja de cálculo (índice `0`), calculados como el número de días transcurridos desde el 30 de diciembre de 1899 para esas fechas. El cálculo en JavaScript usa marcas de tiempo UTC y divide la diferencia por 86 400 000 milisegundos por día. Utilice [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) con `CategoryAxisType.Date`, llame a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) con `false` y pase `yyyy` a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) para que las etiquetas de categoría muestren años de cuatro cifras independientemente del formato de la celda.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer un ángulo de rotación para el título del eje del gráfico**

Llame a [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) con `true` en el eje vertical, proporcione el texto del título y use [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) para rotar el título. El ángulo se mide en grados; este ejemplo guarda un gráfico de columnas con su título del eje de valores girado 90 grados.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer la posición del eje en un eje de categoría o de valor**

Utilice [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) para controlar si el eje de valores cruza el eje de categoría entre categorías o en marcas de categoría. Esta configuración se aplica a los ejes de categoría. El ejemplo lo establece en `true` en el eje de categoría horizontal de un gráfico de columnas y guarda el resultado.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer la unidad de visualización en un eje de valor del gráfico**

Utilice [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) para escalar las etiquetas de un eje de valor sin cambiar los datos subyacentes. Con [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) establecido en `Millions`, un valor de 60 000 000 se muestra como 60. El ejemplo crea un gráfico de columnas y aplica la unidad de visualización de millones a su eje vertical.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Configurar un eje de valor logarítmico**

Un eje de valor logarítmico es útil cuando los valores positivos abarcan varios órdenes de magnitud. Por ejemplo, un servicio podría recibir 10, 100, 1 000, 10 000 y 100 000 solicitudes en cinco periodos. En una escala lineal, los valores menores aparecen agrupados cerca de cero. Una escala logarítmica facilita comparar su crecimiento relativo: las mismas distancias representan las mismas proporciones en lugar de las mismas diferencias.

Llame a [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) con `true` en el eje de valor y use [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) para elegir la base. Esto cambia cómo se muestran los valores existentes; no modifica los datos ni añade una línea de tendencia logarítmica. Una línea de tendencia representa una relación ajustada en los datos y es una característica separada.

### **Elegir el eje de valor y la base**

Para un gráfico de líneas o columnas, el eje de valor se obtiene con [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Para un gráfico de barras horizontal, se obtiene con [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Los gráficos de dispersión y burbuja tienen dos ejes de valor, por lo que se elige el eje horizontal para los valores X, el eje vertical para los valores Y, o ambos. No aplique escalado logarítmico a un eje de categoría.

La base logarítmica predeterminada es `10`. Para gráficos PPTX, use una base de `2` a `1000`, inclusive; también se admiten bases fraccionarias como `2.5`. Con base `10`, potencias sucesivas como 10, 100, 1 000 y 10 000 están espaciadas de forma uniforme.

### **Comparar el escalado lineal y logarítmico**

El siguiente ejemplo autocontenido crea un gráfico de líneas con los cinco recuentos de solicitudes en la primera diapositiva, luego clona esa diapositiva y habilita un eje de valor logarítmico de base 10 en la segunda. Ambas diapositivas conservan los mismos datos.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Mantener la primera diapositiva lineal y cambiar solo la escala del eje de valores de la copia.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Escala lineal (diapositiva 1):** Las mismas distancias verticales representan las mismas diferencias en los recuentos de solicitudes. El valor más alto domina el gráfico, dificultando distinguir los valores menores.

![Gráfico de líneas en PowerPoint que muestra cinco recuentos de solicitudes en un eje de valor lineal](value-axis-linear.png)

**Escala logarítmica (diapositiva 2):** Las mismas distancias verticales representan las mismas proporciones. Cada periodo tiene diez veces más solicitudes que el anterior, por lo que los puntos forman una línea recta ascendente en la escala logarítmica de base 10. Las etiquetas del eje siguen mostrando los recuentos de solicitudes originales.

![Los mismos cinco recuentos de solicitudes en PowerPoint en un eje de valor logarítmico de base 10](value-axis-logarithmic.png)

### **Manejar valores cero y negativos**

Una escala logarítmica solo puede mostrar valores estrictamente positivos. Verifique los datos antes de habilitarla. Si los valores cero o negativos son significativos, mantenga una escala lineal o muéstrelos por separado. Si excluir esos valores es apropiado para el análisis, explique la omisión. No los reemplace silenciosamente por números positivos pequeños, ya que eso cambia el significado de los datos. Cualquier límite mínimo o máximo configurado manualmente para un eje logarítmico también debe ser positivo.

## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Utilice [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) para seleccionar el comportamiento del cruce. Para especificar un valor numérico de cruce, use [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Estas configuraciones le permiten mover el cruce del eje a una línea base adecuada.

**¿Cómo puedo posicionar las etiquetas de marcas respecto al eje?**

Llame a [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) usando [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` o `None`. Para controlar las propias marcas de graduación, use [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) o [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); estos son independientes del posicionamiento de las etiquetas.