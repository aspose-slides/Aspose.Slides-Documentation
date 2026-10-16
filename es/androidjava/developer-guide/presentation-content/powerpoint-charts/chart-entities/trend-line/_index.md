---
title: Añadir líneas de tendencia a los gráficos de presentación en Android
linktitle: Línea de tendencia
type: docs
url: /es/androidjava/trend-line/
keywords:
- gráfico
- línea de tendencia
- línea de tendencia exponencial
- línea de tendencia lineal
- línea de tendencia logarítmica
- línea de tendencia de media móvil
- línea de tendencia polinómica
- línea de tendencia de potencia
- línea de tendencia personalizada
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Añade y personaliza rápidamente líneas de tendencia en los gráficos de PowerPoint con Aspose.Slides para Android mediante Java — una guía práctica para captar la atención de tu audiencia."
---
## **Descripción general**

Este artículo explica cómo añadir líneas de tendencia a los gráficos de presentaciones mediante Aspose.Slides. Muestra cómo crear un gráfico, añadir líneas de tendencia a las series del gráfico y trabajar con varios tipos de líneas de tendencia, incluidos exponencial, lineal, logarítmico, media móvil, polinómico y de potencia.

También describe cómo añadir una línea personalizada a un gráfico insertando una forma de línea, e incluye una breve FAQ sobre los valores de proyección hacia adelante y hacia atrás de la línea de tendencia y si las líneas de tendencia se conservan al exportar a PDF o SVG y al representar los gráficos como imágenes.

## **Añadir una línea de tendencia**

Utilice [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) para añadir una línea de tendencia a una serie de un gráfico, seleccionando su tipo con [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/). El ejemplo crea un gráfico de columnas agrupadas con datos predeterminados y añade dos líneas de tendencia a cada una de sus tres series.

La línea de tendencia exponencial oculta su ecuación y el valor R² mediante [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) y [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), mientras que la línea de tendencia lineal es roja. La línea de tendencia logarítmica utiliza [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) para una etiqueta personalizada. La media móvil emplea un [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) de tres puntos de datos y un [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) personalizado.

La línea de tendencia polinómica tiene un [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) de tres y se extiende una categoría hacia adelante mediante [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-). La línea de tendencia de potencia se extiende una categoría hacia atrás mediante [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer la intersección de una línea de tendencia**

Utilice [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) para fijar el valor Y de una línea de tendencia en X = 0. Esta configuración es compatible con líneas de tendencia lineales, exponenciales y polinómicas.

Por ejemplo, un modelo de coste de producción puede necesitar empezar con costes fijos conocidos de 100, incluso cuando las mediciones a volúmenes de producción diferentes de cero sugieren una base distinta. Para una línea de tendencia lineal, fijar la intersección restringe la ecuación `y = ax + b` a `b = 100`; la pendiente se ajusta a los datos bajo esa restricción. No simplemente mueve una línea ya ajustada. La configuración de cruce de ejes controla dónde se encuentran los ejes del gráfico, no los coeficientes de la línea de tendencia ajustada.

El siguiente ejemplo crea un gráfico de dispersión (XY) con volúmenes de producción de 1 a 4 y costes de 170, 200, 230 y 260. Guarda el gráfico con la intersección automática predeterminada, fija la intersección a 100 y guarda un segundo PPTX. Los dos archivos difieren solo en la configuración de la intersección. La línea de tendencia muestra su ecuación y se extiende hasta X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Con el cálculo automático, estos datos producen `y = 30x + 140`. Al fijar la intersección a 100, se produce aproximadamente `y = 43.33x + 100`: el valor ajustado en cero coincide con la base conocida, mientras que la línea ya no pasa por cada punto de datos.

| Intersección automática | Intersección fija de 100 |
| --- | --- |
| ![Línea de tendencia lineal con una intersección calculada automáticamente de 140](intercept-automatic.png) | ![Línea de tendencia lineal con una intersección fija de 100](intercept-fixed.png) |

Ambas imágenes usan los mismos datos y escalas de ejes. Las líneas de tendencia se extienden hasta X = 0 para mostrar sus intersecciones.

De forma predeterminada, [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) devuelve `Double.NaN`, que representa una intersección no especificada en lugar de cero. La intersección se calcula automáticamente a partir de los datos.

## **Añadir una línea personalizada**

Una línea personalizada es una forma dibujada sobre el gráfico en lugar de una línea de tendencia calculada a partir de los datos de la serie. Este ejemplo utiliza [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) para añadir una línea horizontal a la diapositiva sobre el gráfico. La posición de la línea se especifica en coordenadas de la diapositiva, medidos en puntos, por lo que comienza en el borde izquierdo del gráfico y se sitúa a mitad de altura del gráfico. Su ancho coincide con el ancho del gráfico. El método [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) asigna a la línea un color rojo sólido.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Qué significan 'forward' y 'backward' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectada hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades de eje; para gráficos que no son de dispersión — en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al representar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/) o [SVG](/slides/es/androidjava/render-a-slide-as-an-svg-image/) y representa gráficos como imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del gráfico](/slides/es/androidjava/create-shape-thumbnails/) mismo.