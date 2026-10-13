---
title: Personalizar ejes de gráficos en presentaciones en Android
linktitle: Eje de gráfico
type: docs
url: /es/androidjava/chart-axis/
keywords:
- eje de gráfico
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
- Android
- Java
- Aspose.Slides
description: "Descubra cómo usar Aspose.Slides para Android mediante Java para personalizar los ejes de los gráficos en presentaciones de PowerPoint para informes y visualizaciones."
---
## **Visión general**

Este artículo explica cómo personalizar los ejes de los gráficos con Aspose.Slides para Android mediante Java. Cubre valores calculados de los ejes, intercambio de filas y columnas del gráfico, visibilidad del eje, intervalos de etiquetas de categoría y de marcas de graduación, categorías de fechas y su formato, rotación del título, posicionamiento del eje, unidades de visualización y escalado logarítmico.

## **Obtener los valores máximos en el eje vertical de los gráficos**

Cree una [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) y añada un gráfico de áreas con datos predeterminados. Llame a [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) antes de leer los valores calculados del eje para que el diseño del gráfico esté actualizado.

Lea [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) y [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) para los límites del eje, y [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) y [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) para los intervalos de marcas. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) y [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) proporcionan escalas de unidades de tiempo, que son relevantes para ejes de fecha. El ejemplo almacena estos valores en variables locales y guarda el gráfico.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Intercambiar datos entre ejes**

Utilice [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) para intercambiar los roles de series y categorías en los datos del gráfico. Cada categoría anterior se convierte en una serie y cada serie anterior se convierte en una categoría. Esto cambia la forma en que se agrupan los datos; no intercambia los ejes horizontal y vertical. El ejemplo usa [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) para vincular los datos predeterminados a `Sheet1!A1:D5`, incluida la fila de encabezado y la columna de categoría, antes de intercambiar filas y columnas. Guarda un gráfico con cuatro series y tres categorías.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desactivar el eje vertical para gráficos de líneas**

Llame a [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) con `false` en el eje vertical para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje vertical oculto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desactivar el eje horizontal para gráficos de líneas**

Llame a [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) con `false` en el eje horizontal para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje horizontal oculto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cambiar un eje de categoría**

Utilice [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) para elegir un eje de categoría de fecha o de texto. Este ejemplo requiere `ExistingChart.pptx`, con un gráfico como la primera forma en la primera diapositiva y celdas de categoría que contienen valores de fecha de Excel numéricos. Cambia el eje horizontal a un eje de fecha. Llamar a [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) con `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) con `1` y [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) con `TimeUnitType.Months` coloca marcas mayores a intervalos de un mes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controlar intervalos de etiquetas del eje de categoría**

Cuando un gráfico tiene muchas categorías, reduzca el número de etiquetas de eje visibles sin eliminar categorías ni puntos de datos. Llame a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) con `false`, y luego pase el intervalo de categoría deseado a [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Para categorías de texto en su orden normal, la cuenta comienza en la primera categoría:

| Intervalo | Etiquetas mostradas en el ejemplo |
| --- | --- |
| `1` | Categoría 1, Categoría 2, Categoría 3, ... Categoría 24 |
| `2` | Categoría 1, Categoría 3, Categoría 5, ... Categoría 23 |
| `3` | Categoría 1, Categoría 4, Categoría 7, ... Categoría 22 |

Un intervalo de `3` muestra cada tercera etiqueta, dejando dos etiquetas ocultas entre las mostradas. No elimina las columnas correspondientes. El espaciado automático elige un intervalo basado en el espacio disponible; no necesariamente muestra todas las etiquetas.

Las marcas de graduación tienen controles separados. Llame a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) con `false` y utilice [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) para establecer su intervalo. Por ejemplo, `1` mantiene una marca en cada intervalo de categoría mientras las etiquetas aparecen sólo cada tercera categoría. Use [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) con un estilo visible para poder ver el resultado. Volver a establecer cualquiera de los setters automáticos con `true` permite que el gráfico elija nuevamente ese intervalo.

El siguiente ejemplo autocontenido crea 24 categorías y una serie, y guarda tres diapositivas en `CategoryAxisIntervals.pptx`: espaciado automático, espaciado manual de etiquetas con marcas de graduación independientes y restauración del espaciado automático. Las dos copias conservan los datos originales del gráfico. No se necesita una presentación de entrada. El texto de la etiqueta horizontal facilita ver la diferencia de densidad.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Diapositiva 2: mostrar cada tercera etiqueta, pero mantener una marca de graduación para cada categoría.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Diapositiva 3: permitir que el gráfico elija ambos intervalos nuevamente.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Espaciado automático (diapositiva 1):** En esta representación, se muestra cada segunda etiqueta de categoría y se ajusta a dos líneas. El resultado automático puede variar según el tamaño del gráfico, las fuentes y el motor de renderizado.

![Espaciado automático de etiquetas de categoría con las 24 columnas visibles](category-axis-automatic.png)

**Espaciado manual (diapositiva 2):** Cada tercera etiqueta se muestra en una línea, mientras las marcas de graduación permanecen en cada intervalo de categoría. Las 24 columnas, incluidas las que no tienen etiquetas, siguen visibles con los mismos valores. La diapositiva 3 restaura la apariencia automática mostrada arriba.

![Espaciado manual de etiquetas de categoría con intervalo de tres y las 24 columnas visibles](category-axis-manual.png)

### **Elegir el eje y intervalo correctos**

Utilice este intervalo de recuento de categorías para un eje de categoría de texto, como el eje de categoría de un gráfico de columnas, líneas, áreas o barras. En un gráfico de columnas, es el eje horizontal. En un gráfico de barras horizontal, el eje de categoría es vertical, por lo que aplique estos ajustes al eje devuelto por [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). El espaciado de marcas también se aplica a un eje de serie en gráficos que lo poseen.

No utilice el espaciado de etiquetas de categoría para establecer la escala numérica de un eje de valor. En un eje de valor, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) especifica una diferencia en valores: por ejemplo, una unidad mayor de `10` produce marcas en 0, 10, 20, etc., cuando el eje comienza en cero. Un intervalo de etiqueta de categoría de `3` cuenta posiciones de categoría, sin importar sus valores de datos. Los gráficos de dispersión y burbuja utilizan ejes de valor en lugar de un eje de categoría de texto. Para un eje de fecha, use unidades mayores basadas en tiempo y escalas como se describe en [Cambiar un eje de categoría](#change-a-category-axis).

## **Establecer el formato de fecha para los valores del eje de categoría**

El ejemplo sustituye los datos predeterminados del gráfico por cuatro valores anuales. Las fechas se almacenan como números de serie OLE Automation en la primera hoja de cálculo (índice `0`), calculados como el número de días desde el 30 de diciembre de 1899, para estas fechas. Ambos calendarios usan UTC y se borran antes de establecer las fechas para que el horario de verano y la hora del día actual no afecten al cálculo. Use [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) con `CategoryAxisType.Date`, llame a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) con `false` y pase `yyyy` a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) para que las etiquetas de categoría muestren años de cuatro dígitos independientemente del formato de la celda.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer un ángulo de rotación para el título del eje del gráfico**

Llame a [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) con `true` en el eje vertical, proporcione el texto del título y use [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) para rotar el título. El ángulo se mide en grados; este ejemplo guarda un gráfico de columnas con el título del eje de valores rotado 90 grados.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer la posición del eje en un eje de categoría o de valor**

Utilice [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) para controlar si el eje de valor cruza el eje de categoría entre categorías o en las marcas de categoría. Este ajuste se aplica a los ejes de categoría. El ejemplo lo establece en `true` en el eje de categoría horizontal de un gráfico de columnas y guarda el resultado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer la unidad de visualización en un eje de valor del gráfico**

Use [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) para escalar las etiquetas de un eje de valor sin cambiar los datos subyacentes. Con [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) configurado a `Millions`, un valor de 60 000 000 se muestra como 60. El ejemplo crea un gráfico de columnas y aplica la unidad de visualización en millones a su eje vertical.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Configurar un eje de valor logarítmico**

Un eje de valor logarítmico es útil cuando los valores positivos abarcan varios órdenes de magnitud. Por ejemplo, un servicio podría recibir 10, 100, 1 000, 10 000 y 100 000 solicitudes durante cinco períodos. En una escala lineal, los valores menores aparecen muy juntos cerca del cero. Una escala logarítmica facilita comparar su crecimiento relativo: distancias iguales representan razones iguales en lugar de diferencias iguales.

Llame a [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) con `true` en el eje de valor y use [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) para elegir la base. Esto cambia la forma en que se muestran los valores existentes; no modifica los datos ni añade una línea de tendencia logarítmica. Una línea de tendencia representa una relación ajustada a los datos y es una característica separada.

### **Elegir el eje de valor y la base**

Para un gráfico de líneas o columnas, el eje de valor se obtiene con [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Para un gráfico de barras horizontal, se obtiene con [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Los gráficos de dispersión y burbuja tienen dos ejes de valor, por lo que elija el eje horizontal para los valores X, el eje vertical para los valores Y, o ambos. No aplique escalado logarítmico a un eje de categoría.

La base logarítmica predeterminada es `10`. Para gráficos PPTX, use una base entre `2` y `1000`, inclusive; también se admiten bases fraccionarias como `2.5`. Con base `10`, las potencias sucesivas 10, 100, 1 000 y 10 000 quedan espaciadas uniformemente.

### **Comparar escalado lineal y logarítmico**

El siguiente ejemplo autocontenido crea un gráfico de líneas con los cinco recuentos de solicitudes en la primera diapositiva, luego clona esa diapositiva y habilita un eje de valor logarítmico base 10 en la segunda. Ambas diapositivas conservan los mismos datos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Mantener la primera diapositiva lineal y cambiar solo la escala del eje de valores de la copia.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Escala lineal (diapositiva 1):** Distancias verticales iguales representan diferencias iguales en los recuentos de solicitudes. El valor más grande domina el gráfico, lo que dificulta distinguir los valores menores.

![Gráfico de líneas en PowerPoint que muestra cinco recuentos de solicitudes en un eje de valor lineal](value-axis-linear.png)

**Escala logarítmica (diapositiva 2):** Distancias verticales iguales representan razones iguales. Cada período tiene diez veces más solicitudes que el anterior, por lo que los puntos forman una línea recta ascendente en la escala base 10. Las etiquetas del eje siguen mostrando los recuentos originales de solicitudes.

![Los mismos cinco recuentos de solicitudes en PowerPoint en un eje de valor logarítmico base 10](value-axis-logarithmic.png)

### **Manejar valores cero y negativos**

Una escala logarítmica sólo puede representar valores estrictamente positivos. Verifique los datos antes de habilitarla. Si los valores cero o negativos son significativos, mantenga una escala lineal o muéstrelos por separado. Si excluir esos valores es apropiado para el análisis, explique la omisión. No los reemplace silenciosamente por números positivos pequeños, ya que eso altera el significado de los datos. Cualquier mínimo o máximo configurado manualmente para un eje logarítmico también debe ser positivo.

## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Utilice [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) para seleccionar el comportamiento del cruce. Para especificar un valor numérico de cruce, use [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Estas configuraciones le permiten mover el cruce del eje a una línea base adecuada.

**¿Cómo puedo posicionar las etiquetas de marcas respecto al eje?**

Llame a [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) usando [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` o `None`. Para controlar las propias marcas de graduación, use [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) o [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); estos son independientes de la posición de las etiquetas.