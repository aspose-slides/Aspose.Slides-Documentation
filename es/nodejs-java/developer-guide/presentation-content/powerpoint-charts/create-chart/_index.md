---
title: Crear o actualizar gráficos de presentaciones PowerPoint en JavaScript
linktitle: Crear o actualizar gráficos
type: docs
weight: 10
url: /es/nodejs-java/create-chart/
keywords:
- añadir gráfico
- crear gráfico
- editar gráfico
- cambiar gráfico
- actualizar gráfico
- gráfico de dispersión
- gráfico de pastel
- gráfico de líneas
- gráfico de árbol de mapa
- gráfico de bolsa
- gráfico de caja y bigotes
- gráfico de embudo
- gráfico de explosión radial
- gráfico de histograma
- gráfico de radar
- gráfico multicategoría
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Cree y personalice gráficos en presentaciones PowerPoint con Aspose.Slides para Node.js. Añada, formatee y edite gráficos con ejemplos prácticos de código en JavaScript."
---
## **Resumen**

Este artículo ofrece una guía completa sobre cómo crear y personalizar gráficos utilizando Aspose.Slides. Aprenderá a añadir programáticamente un gráfico a una diapositiva, poblarlo con datos y aplicar diversas opciones de formato para adaptarlo a sus requisitos de diseño específicos. A lo largo del artículo, se incluyen ejemplos de código detallados que ilustran cada paso, desde la inicialización de la presentación y el objeto gráfico hasta la configuración de series, ejes y leyendas. Siguiendo esta guía, obtendrá una comprensión sólida de cómo integrar la generación dinámica de gráficos en sus aplicaciones, optimizando el proceso de creación de presentaciones basadas en datos.

## **Crear un gráfico**

Los gráficos ayudan a las personas a visualizar rápidamente datos y obtener ideas que pueden no ser evidentes a simple vista en una tabla o hoja de cálculo.

**¿Por qué crear gráficos?**

Con los gráficos puede:

* agregar, condensar o resumir grandes cantidades de datos en una única diapositiva de una presentación
* revelar patrones y tendencias en los datos
* deducir la dirección y el impulso de los datos a lo largo del tiempo o respecto a una unidad de medida específica
* detectar valores atípicos, aberraciones, desviaciones, errores, datos sin sentido, etc.
* comunicar o presentar datos complejos

En PowerPoint, puede crear gráficos mediante la función *Insert* que ofrece plantillas para diseñar muchos tipos de gráficos. Con Aspose.Slides, puede crear tanto gráficos habituales (basados en tipos de gráfico populares) como gráficos personalizados.

{{% alert color="info" title="Note" %}}

Para crear gráficos, utilice la clase [ChartType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/). Los campos de esta clase corresponden a diferentes tipos de gráficos.

{{% /alert %}}

### **Crear gráficos de columnas agrupadas**

Esta sección explica cómo crear gráficos de columnas agrupadas usando Aspose.Slides. Aprenderá a inicializar una presentación, añadir un gráfico y personalizar sus elementos como título, datos, series, categorías y estilo. Siga los pasos a continuación para ver cómo se genera un gráfico de columnas agrupadas estándar:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Añadir un gráfico con algunos datos y especificar el tipo `ChartType.ClusteredColumn`.
1. Añadir un título al gráfico.
1. Acceder a la hoja de datos del gráfico.
1. Eliminar todas las series y categorías predeterminadas.
1. Añadir nuevas series y categorías.
1. Añadir nuevos datos al gráfico para las series.
1. Aplicar un color de relleno a las series del gráfico.
1. Añadir etiquetas a las series del gráfico.
1. Guardar la presentación modificada como archivo PPTX.

Este código C# muestra cómo crear un gráfico de columnas agrupadas:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancia una clase de presentación que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añade un gráfico con sus datos predeterminados
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Establece el título del gráfico
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // Establece que la primera serie muestre valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Establece el índice para la hoja de datos del gráfico
    var defaultWorksheetIndex = 0;
    // Obtiene la hoja de datos del gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Elimina las series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Añade nuevas series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Añade nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Obtiene la primera serie del gráfico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Ahora rellena los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Establece el color de relleno para la serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Obtiene la segunda serie del gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    // Rellena los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Establece el color de relleno para la serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Crear etiquetas personalizadas para cada categoría de la nueva serie
    // Establece la primera etiqueta para que muestre el nombre de la categoría
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Muestra el valor para la tercera etiqueta
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Guarda la presentación con el gráfico
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de dispersión**

Los gráficos de dispersión (también llamados diagramas de dispersión o gráficos xy) se utilizan a menudo para comprobar patrones o demostrar correlaciones entre dos variables.

Utilice un gráfico de dispersión cuando:

* disponga de datos numéricos emparejados
* tenga dos variables que se relacionen bien entre sí
* desee determinar si dos variables están relacionadas
* cuente con una variable independiente que tenga varios valores para una variable dependiente

1. Siga los pasos de [Crear gráficos de columnas agrupadas](#create-clustered-column-charts).
2. En el tercer paso, añada un gráfico con algunos datos y especifique su tipo de gráfico como uno de los siguientes:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Representa un gráfico de dispersión._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representa un gráfico de dispersión conectado por curvas, con marcadores de datos._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Representa un gráfico de dispersión conectado por curvas, sin marcadores de datos._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representa un gráfico de dispersión conectado por líneas, con marcadores de datos._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Representa un gráfico de dispersión conectado por líneas, sin marcadores de datos._

Este código JavaScript muestra cómo crear un gráfico de dispersión con diferentes marcadores para cada serie:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancia una clase de presentación que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Crea el gráfico predeterminado
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Obtiene el índice de la hoja de datos del gráfico predeterminada
    var defaultWorksheetIndex = 0;
    // Obtiene la hoja de datos del gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Elimina la serie de demostración
    chart.getChartData().getSeries().clear();
    // Añade nuevas series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Obtiene la primera serie del gráfico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Añade un nuevo punto (1:3) a la serie
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Añade un nuevo punto (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Cambia el tipo de serie
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Cambia el marcador de la serie del gráfico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Obtiene la segunda serie del gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    // Añade un nuevo punto (5:2) allí
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Añade un nuevo punto (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Añade un nuevo punto (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Añade un nuevo punto (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Cambia el marcador de la serie del gráfico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de pastel**

Los gráficos de pastel se utilizan preferentemente para mostrar la relación parte‑todo en los datos, sobre todo cuando los datos contienen etiquetas categóricas con valores numéricos. No obstante, si sus datos contienen muchas partes o etiquetas, quizá prefiera usar un gráfico de barras.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados y especificar el tipo [ChartType.Pie](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#Pie).
4. Acceder al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/).
5. Eliminar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Añadir nuevos puntos al gráfico y aplicar colores personalizados a los sectores del pastel.
9. Establecer etiquetas para las series.
10. Activar líneas guías para las etiquetas de las series.
11. Definir el ángulo de rotación de los sectores del pastel.
12. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico de pastel:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancia una clase de presentación que representa un archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accede a la primera diapositiva
    var slides = pres.getSlides().get_Item(0);
    // Añade un gráfico con datos predeterminados
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Establece el título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Configura la primera serie para que muestre valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Establece el índice para la hoja de datos del gráfico
    var defaultWorksheetIndex = 0;
    // Obtiene la hoja de datos del gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Elimina las series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Añade nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Añade nuevas series
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Rellena los datos de la serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // No funciona en la nueva versión
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Establece el borde del sector
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Establece el borde del sector
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Establece el borde del sector
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // Crea etiquetas personalizadas para cada categoría de la nueva serie
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Muestra líneas guía para el gráfico
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Establece el ángulo de rotación para los sectores del gráfico de pastel
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Guarda la presentación con el gráfico
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de líneas**

Los gráficos de líneas (también llamados diagramas de líneas) se utilizan mejor en situaciones donde se desea mostrar variaciones de valores a lo largo del tiempo. Con un gráfico de líneas, puede comparar una gran cantidad de datos de una vez, seguir cambios y tendencias en el tiempo, resaltar anomalías en series de datos y más.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Añadir un gráfico con datos predeterminados y especificar el tipo [ChartType.Line](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#Line).
1. Acceder al libro de datos del gráfico ([ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/)).
1. Eliminar las series y categorías predeterminadas.
1. Añadir nuevas series y categorías.
1. Añadir nuevos datos al gráfico para las series.
1. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico de líneas:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Por defecto, los puntos en un gráfico de líneas se unen mediante líneas continuas rectas. Si desea que los puntos se unan mediante guiones, puede especificar el tipo de guion preferido así:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de árbol de mapa**

Los gráficos de árbol de mapa se utilizan mejor para datos de ventas cuando se quiere mostrar el tamaño relativo de las categorías de datos y atraer rápidamente la atención a los elementos que son grandes contribuyentes dentro de cada categoría.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados y especificar el tipo [ChartType.Treemap](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#Treemap).
4. Acceder al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/).
5. Eliminar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico de árbol de mapa:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // rama 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // rama 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de bolsa**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados y especificar el tipo [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#OpenHighLowClose).
4. Acceder al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/).
5. Eliminar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Especificar el formato de las líneas alto‑bajo.
9. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico de bolsa:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de caja y bigotes**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados y especificar el tipo [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#BoxAndWhisker).
4. Acceder al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/).
5. Eliminar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico de caja y bigotes:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de embudo**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados y especificar el tipo [ChartType.Funnel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#Funnel).
4. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico de embudo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de explosión radial**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados y especificar el tipo [ChartType.Sunburst](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#Sunburst).
4. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico de explosión radial:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // rama 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // rama 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de histograma**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados y especificar el tipo [ChartType.Histogram](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#Histogram).
4. Acceder al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/).
5. Eliminar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico de histograma:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Crear gráficos de radar**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con algunos datos y especificar su tipo de gráfico preferido ([ChartType.Radar](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#Radar) en este caso).
4. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico de radar:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos multicategoría**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados y especificar el tipo [ChartType.ClusteredColumn](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/#ClusteredColumn).
4. Acceder al libro de datos del gráfico [ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/).
5. Eliminar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo crear un gráfico multicategoría:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Añadiendo series
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Guardar presentación con el gráfico
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos de mapa**

Los gráficos de mapa visualizan datos geográficos y ayudan a comparar valores entre regiones.

Este código JavaScript muestra cómo crear un gráfico de mapa:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Crear gráficos combinados**

Un gráfico combinado (o combo) combina dos o más tipos de gráficos en un solo diagrama. Este gráfico le permite resaltar, comparar o examinar diferencias entre dos o más conjuntos de datos, facilitando la identificación de relaciones entre ellos.

![The combination chart](combination_chart.png)

El siguiente código JavaScript muestra cómo crear el gráfico combinado mostrado arriba en una presentación de PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Establecer el título del gráfico.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Establecer la leyenda del gráfico.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Eliminar las series y categorías generadas por defecto.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Agregar nuevas categorías.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Agregar la primera serie.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Establecer el eje horizontal.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Establecer el eje vertical.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Establecer el color de las líneas de cuadrícula principales verticales.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Establecer el eje horizontal secundario.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Establecer el eje vertical secundario.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Actualizar gráficos**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) que represente la presentación que contiene el gráfico que desea actualizar.
2. Obtener una referencia a una diapositiva mediante su índice.
3. Recorrer todas las formas para encontrar el gráfico deseado.
4. Acceder a la hoja de datos del gráfico.
5. Modificar la serie de datos del gráfico cambiando los valores de la serie.
6. Añadir una nueva serie y poblar sus datos.
7. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo actualizar un gráfico:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Acceder al primer marcador de diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Obtener el gráfico con datos predeterminados
    var chart = sld.getShapes().get_Item(0);
    // Establecer el índice de la hoja de datos del gráfico
    var defaultWorksheetIndex = 0;
    // Obtener la hoja de datos del gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Cambiar el nombre de la categoría del gráfico
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Obtener la primera serie del gráfico
    var series = chart.getChartData().getSeries().get_Item(0);
    // Actualizando ahora los datos de la serie
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Modificando el nombre de la serie
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Obtener la segunda serie del gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    // Actualizando ahora los datos de la serie
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Modificando el nombre de la serie
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Ahora, añadiendo una nueva serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Obtener la tercera serie del gráfico
    series = chart.getChartData().getSeries().get_Item(2);
    // Poblando ahora los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Guardar la presentación con el gráfico
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Establecer rango de datos para un gráfico**

Para establecer el rango de datos de un gráfico, haga lo siguiente:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) que represente la presentación que contiene el gráfico.
2. Obtener una referencia a una diapositiva mediante su índice.
3. Recorrer todas las formas para encontrar el gráfico deseado.
4. Acceder a los datos del gráfico y establecer el rango.
5. Guardar la presentación modificada como archivo PPTX.

Este código JavaScript muestra cómo establecer el rango de datos de un gráfico:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usar marcadores predeterminados en los gráficos**

Al usar marcadores predeterminados en los gráficos, cada serie del gráfico recibe automáticamente un símbolo de marcador diferente.

Este código JavaScript muestra cómo establecer automáticamente un marcador de serie de gráfico:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Obtener la segunda serie del gráfico
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Ahora poblando los datos de la serie
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Preguntas frecuentes**

**¿Qué tipos de gráficos admite Aspose.Slides?**

Aspose.Slides admite una amplia variedad de [tipos de gráficos](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/charttype/), incluidos barras, líneas, pastel, área, dispersión, histograma, radar y muchos más. Esta flexibilidad le permite elegir el tipo de gráfico más adecuado para sus necesidades de visualización de datos.

**¿Cómo añado un nuevo gráfico a una diapositiva?**

Para añadir un gráfico, primero crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/), recupera la diapositiva deseada mediante su índice y luego llama al método para añadir un gráfico, especificando el tipo de gráfico y los datos iniciales. Este proceso integra el gráfico directamente en su presentación.

**¿Cómo puedo actualizar los datos mostrados en un gráfico?**

Puede actualizar los datos de un gráfico accediendo a su libro de datos ([ChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/)), eliminando las series y categorías predeterminadas y luego añadiendo sus propios datos personalizados. Esto le permite refrescar programáticamente el gráfico para reflejar la información más reciente.

**¿Es posible personalizar la apariencia del gráfico?**

Sí, Aspose.Slides ofrece amplias opciones de personalización. Puede modificar colores, fuentes, etiquetas, leyendas y otros [elementos de formato](/slides/es/nodejs-java/chart-entities/) para adaptar la apariencia del gráfico a sus requisitos de diseño específicos.