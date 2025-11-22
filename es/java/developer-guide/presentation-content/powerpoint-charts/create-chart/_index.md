---
title: Crear o actualizar gráficos de presentaciones PowerPoint en Java
linktitle: Crear gráfico
type: docs
weight: 10
url: /es/java/create-chart/
keywords: "Crear gráfico, gráfico disperso, gráfico circular, gráfico de mapa de árbol, gráfico bursátil, gráfico de caja y bigote, gráfico de histograma, gráfico embudo, gráfico radial, gráfico multicategoría, presentación PowerPoint, Java, Aspose.Slides for Java"
description: "Crear gráfico en una presentación PowerPoint en Java"
---

## Visión general

Este artículo describe cómo **crear gráficos de presentaciones PowerPoint en Java**. También puedes **actualizar los gráficos en Java**. Cubre los siguientes temas.

_Gráfico_: **Normal**
- [Java Crear gráfico PowerPoint](#java-create-powerpoint-chart)
- [Java Crear gráfico de presentación](#java-create-presentation-chart)
- [Java Crear gráfico de presentación PowerPoint](#java-create-powerpoint-presentation-chart)

_Gráfico_: **Disperso**
- [Java Crear gráfico disperso](#java-create-scattered-chart)
- [Java Crear gráfico PowerPoint disperso](#java-create-powerpoint-scattered-chart)
- [Java Crear gráfico de presentación PowerPoint disperso](#java-create-powerpoint-presentation-scattered-chart)

_Gráfico_: **Circular**
- [Java Crear gráfico circular](#java-create-pie-chart)
- [Java Crear gráfico PowerPoint circular](#java-create-powerpoint-pie-chart)
- [Java Crear gráfico de presentación PowerPoint circular](#java-create-powerpoint-presentation-pie-chart)

_Gráfico_: **Mapa de árbol**
- [Java Crear gráfico de mapa de árbol](#java-create-tree-map-chart)
- [Java Crear gráfico PowerPoint de mapa de árbol](#java-create-powerpoint-tree-map-chart)
- [Java Crear gráfico de presentación PowerPoint de mapa de árbol](#java-create-powerpoint-presentation-tree-map-chart)

_Gráfico_: **Bursátil**
- [Java Crear gráfico bursátil](#java-create-stock-chart)
- [Java Crear gráfico PowerPoint bursátil](#java-create-powerpoint-stock-chart)
- [Java Crear gráfico de presentación PowerPoint bursátil](#java-create-powerpoint-presentation-stock-chart)

_Gráfico_: **Caja y bigote**
- [Java Crear gráfico caja y bigote](#java-create-box-and-whisker-chart)
- [Java Crear gráfico PowerPoint caja y bigote](#java-create-powerpoint-box-and-whisker-chart)
- [Java Crear gráfico de presentación PowerPoint caja y bigote](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Gráfico_: **Embudado**
- [Java Crear gráfico embudado](#java-create-funnel-chart)
- [Java Crear gráfico PowerPoint embudado](#java-create-powerpoint-funnel-chart)
- [Java Crear gráfico de presentación PowerPoint embudado](#java-create-powerpoint-presentation-funnel-chart)

_Gráfico_: **Radial**
- [Java Crear gráfico radial](#java-create-sunburst-chart)
- [Java Crear gráfico PowerPoint radial](#java-create-powerpoint-sunburst-chart)
- [Java Crear gráfico de presentación PowerPoint radial](#java-create-powerpoint-presentation-sunburst-chart)

_Gráfico_: **Histograma**
- [Java Crear histograma](#java-create-histogram-chart)
- [Java Crear histograma PowerPoint](#java-create-powerpoint-histogram-chart)
- [Java Crear histograma de presentación PowerPoint](#java-create-powerpoint-presentation-histogram-chart)

_Gráfico_: **Radar**
- [Java Crear radar](#java-create-radar-chart)
- [Java Crear radar PowerPoint](#java-create-powerpoint-radar-chart)
- [Java Crear radar de presentación PowerPoint](#java-create-powerpoint-presentation-radar-chart)

_Gráfico_: **Multicategoría**
- [Java Crear gráfico multicategoría](#java-create-multi-category-chart)
- [Java Crear gráfico PowerPoint multicategoría](#java-create-powerpoint-multi-category-chart)
- [Java Crear gráfico de presentación PowerPoint multicategoría](#java-create-powerpoint-presentation-multi-category-chart)

_Gráfico_: **Mapa**
- [Java Crear gráfico mapa](#java-create-map-chart)
- [Java Crear gráfico PowerPoint mapa](#java-create-powerpoint-map-chart)
- [Java Crear gráfico de presentación PowerPoint mapa](#java-create-powerpoint-presentation-map-chart)

_Acción_: **Actualizar gráfico**
- [Java Actualizar gráfico PowerPoint](#java-update-powerpoint-chart)
- [Java Actualizar gráfico de presentación](#java-update-presentation-chart)
- [Java Actualizar gráfico de presentación PowerPoint](#java-update-powerpoint-presentation-chart)


## **Crear gráfico**
Los gráficos ayudan a las personas a visualizar datos rápidamente y obtener información, lo que puede no ser evidente de inmediato a partir de una tabla o hoja de cálculo. 


**¿Por qué crear gráficos?**

Al usar gráficos, puedes

* agregar, condensar o resumir grandes cantidades de datos en una sola diapositiva de una presentación
* exponer patrones y tendencias en los datos
* deducir la dirección y el impulso de los datos a lo largo del tiempo o con respecto a una unidad de medida específica 
* detectar valores atípicos, aberraciones, desviaciones, errores, datos sin sentido, etc. 
* comunicar o presentar datos complejos

En PowerPoint, puedes crear gráficos mediante la función de inserción, que proporciona plantillas usadas para diseñar muchos tipos de gráficos. Usando Aspose.Slides, puedes crear gráficos regulares (basados en tipos de gráficos populares) y gráficos personalizados. 

{{% alert color="primary" %}} 

Para permitirle crear gráficos, Aspose.Slides proporciona la clase [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType). Los campos de esta clase corresponden a diferentes tipos de gráficos. 

{{% /alert %}} 

### **Crear gráficos normales**

_Pasos: Crear gráfico_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint en Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Pasos:</em> Crear gráfico de presentación en Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint en Java</strong></a>

_Pasos de código:_

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con algunos datos y especificar el tipo de gráfico que prefieras. 
4. Añadir un título al gráfico. 
5. Acceder a la hoja de datos del gráfico. 
6. Borrar todas las series y categorías predeterminadas. 
7. Añadir nuevas series y categorías. 
8. Añadir algunos datos nuevos al gráfico para las series. 
9. Añadir un color de relleno para las series del gráfico. 
10. Añadir etiquetas para las series del gráfico. 
11. Guardar la presentación modificada como un archivo PPTX. 

Este código Java muestra cómo crear un gráfico normal:
```java
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Agrega un gráfico con sus datos predeterminados
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Establece el título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Establece la primera serie para mostrar valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Establece el índice para la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina las series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Agrega nuevas series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Agrega nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Obtiene la primera serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Ahora rellena los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Establece el color de relleno para la serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Obtiene la segunda serie del gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Rellena los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Establece el color de relleno para la serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
//Crear etiquetas personalizadas para cada categoría de la nueva serie
    // Establece la primera etiqueta para mostrar el nombre de la categoría
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Muestra el valor para la tercera etiqueta
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Guarda la presentación con el gráfico
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos dispersos**
Los gráficos dispersos (también conocidos como diagramas de dispersión o gráficos x‑y) se usan a menudo para comprobar patrones o demostrar correlaciones entre dos variables. 

Podrías querer usar un gráfico disperso cuando 

* tienes datos numéricos pareados
* tienes 2 variables que se combinan bien
* deseas determinar si 2 variables están relacionadas
* tienes una variable independiente que tiene múltiples valores para una variable dependiente

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Pasos:</em> Crear gráfico disperso en Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint disperso en Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint disperso en Java</strong></a>

1. Sigue los pasos mencionados arriba en [Crear gráficos normales](#creating-normal-charts)
2. Para el tercer paso, añade un gráfico con algunos datos y especifica tu tipo de gráfico como uno de los siguientes
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Representa un gráfico de dispersión._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representa un gráfico de dispersión conectado por curvas, con marcadores de datos._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Representa un gráfico de dispersión conectado por curvas, sin marcadores de datos._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representa un gráfico de dispersión conectado por líneas, con marcadores de datos._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Representa un gráfico de dispersión conectado por líneas, sin marcadores de datos._

Este código Java muestra cómo crear gráficos dispersos con diferentes series de marcadores: 
```java
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Crea el gráfico predeterminado
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Obtiene el índice de la hoja de datos del gráfico predeterminada
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina la serie de demostración
    chart.getChartData().getSeries().clear();
    
    // Agrega nuevas series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Obtiene la primera serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Agrega un nuevo punto (1:3) a la serie
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Agrega un nuevo punto (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Cambia el tipo de serie
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Cambia el marcador de la serie del gráfico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Obtiene la segunda serie del gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Agrega un nuevo punto (5:2) allí
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Agrega un nuevo punto (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Agrega un nuevo punto (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Agrega un nuevo punto (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Cambia el marcador de la serie del gráfico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos circulares**

Los gráficos circulares se usan mejor para mostrar la relación parte‑todo en los datos, especialmente cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si tus datos contienen muchas partes o etiquetas, podrías considerar usar un gráfico de barras en su lugar.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Pasos:</em> Crear gráfico circular en Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint circular en Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint circular en Java</strong></a>

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados junto con el tipo deseado (en este caso, [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Pie).
4. Acceder a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Borrar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Añadir nuevos puntos al gráfico y colores personalizados para los sectores del gráfico circular.
9. Establecer etiquetas para las series.
10. Establecer líneas guía para las etiquetas de series.
11. Establecer el ángulo de rotación para las diapositivas del gráfico circular.
12. Guardar la presentación modificada en un archivo PPTX

Este código Java muestra cómo crear un gráfico circular:
```java
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Agrega un gráfico con datos predeterminados
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Establece el título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Establece la primera serie para mostrar valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Establece el índice para la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina las series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Agrega nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Agrega nuevas series
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
//Rellena los datos de la serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // No funciona en la nueva versión
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Establece el borde del sector
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Establece el borde del sector
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Establece el borde del sector
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Crea etiquetas personalizadas para cada categoría de la nueva serie
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Muestra líneas de guía para el gráfico
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Establece el ángulo de rotación para los sectores del gráfico de pastel
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Guarda la presentación con un gráfico
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos de líneas**

Los gráficos de líneas (también conocidos como diagramas de líneas) se utilizan mejor cuando deseas demostrar cambios en el valor a lo largo del tiempo. Con un gráfico de líneas, puedes comparar muchos datos a la vez, seguir cambios y tendencias a lo largo del tiempo, resaltar anomalías en series de datos, etc.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Añadir un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.Line`).
1. Acceder a los datos del gráfico mediante IChartDataWorkbook.
1. Borrar las series y categorías predeterminadas.
1. Añadir nuevas series y categorías.
1. Añadir nuevos datos al gráfico para las series.
1. Guardar la presentación modificada en un archivo PPTX

Este código Java muestra cómo crear un gráfico de líneas:
```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Por defecto, los puntos en un gráfico de líneas están unidos por líneas rectas continuas. Si deseas que los puntos se unan mediante guiones, puedes especificar tu tipo de guion preferido así:
```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```


### **Crear gráficos de mapa de árbol**

Los gráficos de mapa de árbol se usan mejor para datos de ventas cuando deseas mostrar el tamaño relativo de categorías de datos y (al mismo tiempo) atraer rápidamente la atención hacia los ítems que son grandes contribuyentes a cada categoría. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Pasos:</em> Crear gráfico de mapa de árbol en Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint de mapa de árbol en Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint de mapa de árbol en Java</strong></a>

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados junto con el tipo deseado (en este caso, [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).TreeMap).
4. Acceder a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Borrar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Guardar la presentación modificada en un archivo PPTX

Este código Java muestra cómo crear un gráfico de mapa de árbol:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //rama 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //rama 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos bursátiles**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Pasos:</em> Crear gráfico bursátil en Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint bursátil en Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint bursátil en Java</strong></a>

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. Acceder a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Borrar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Especificar el formato de HiLowLines.
9. Guardar la presentación modificada en un archivo PPTX

Ejemplo de código Java usado para crear un gráfico bursátil:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos de caja y bigote**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Pasos:</em> Crear gráfico caja y bigote en Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint caja y bigote en Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint caja y bigote en Java</strong></a>

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. Acceder a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Borrar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Guardar la presentación modificada en un archivo PPTX

Este código Java muestra cómo crear un gráfico caja y bigote:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos embudados**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Pasos:</em> Crear gráfico embudado en Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint embudado en Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint embudado en Java</strong></a>


1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Funnel).
4. Guardar la presentación modificada en un archivo PPTX

El código Java muestra cómo crear un gráfico embudado:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos radiales**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Pasos:</em> Crear gráfico radial en Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint radial en Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint radial en Java</strong></a>

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados junto con el tipo deseado (en este caso, [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).sunburst).
4. Guardar la presentación modificada en un archivo PPTX

Este código Java muestra cómo crear un gráfico radial:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //rama 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //rama 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear histogramas**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Pasos:</em> Crear histograma en Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Pasos:</em> Crear histograma PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Pasos:</em> Crear histograma de presentación PowerPoint en Java</strong></a>

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtener una referencia a una diapositiva mediante su índice.
3. Añadir un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Histogram).
4. Acceder a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Borrar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Guardar la presentación modificada en un archivo PPTX

Este código Java muestra cómo crear un histograma:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Pasos:</em> Crear radar en Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Pasos:</em> Crear radar PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Pasos:</em> Crear radar de presentación PowerPoint en Java</strong></a>

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtener una referencia a una diapositiva mediante su índice. 
3. Añadir un gráfico con algunos datos y especificar tu tipo de gráfico preferido (`ChartType.Radar` en este caso).
4. Guardar la presentación modificada en un archivo PPTX

Este código Java muestra cómo crear un radar:
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos multicategoría**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Pasos:</em> Crear gráfico multicategoría en Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint multicategoría en Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint multicategoría en Java</strong></a>

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtener una referencia a una diapositiva mediante su índice. 
3. Añadir un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).ClusteredColumn).
4. Acceder a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Borrar las series y categorías predeterminadas.
6. Añadir nuevas series y categorías.
7. Añadir nuevos datos al gráfico para las series.
8. Guardar la presentación modificada en un archivo PPTX.

Este código Java muestra cómo crear un gráfico multicategoría:
```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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

    // Agregar series
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Guardar presentación con gráfico
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos de mapa**

Un gráfico de mapa es una visualización de un área que contiene datos. Los gráficos de mapa se usan mejor para comparar datos o valores entre regiones geográficas.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Pasos:</em> Crear gráfico mapa en Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Pasos:</em> Crear gráfico PowerPoint mapa en Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Pasos:</em> Crear gráfico de presentación PowerPoint mapa en Java</strong></a>

Este código Java muestra cómo crear un gráfico mapa:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Crear gráficos combinados**

Un gráfico combinado (o gráfico combo) combina dos o más tipos de gráficos en un solo diagrama. Este gráfico te permite resaltar, comparar o examinar diferencias entre dos o más conjuntos de datos, ayudándote a identificar relaciones entre ellos.

![The combination chart](combination_chart.png)

El siguiente código Java muestra cómo crear el gráfico combinado mostrado arriba en una presentación PowerPoint:
```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Establecer el título del gráfico.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Establecer la leyenda del gráfico.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Eliminar las series y categorías generadas por defecto.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Agregar nuevas categorías.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Agregar la primera serie.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Establecer el eje horizontal.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Establecer el eje vertical.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Establecer el color de las líneas de cuadrícula mayor vertical.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Establecer el eje horizontal secundario.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Establecer el eje vertical secundario.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```


## **Actualizar gráficos**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Pasos:</em> Actualizar gráfico PowerPoint en Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Pasos:</em> Actualizar gráfico de presentación en Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Pasos:</em> Actualizar gráfico de presentación PowerPoint en Java</strong></a>

1. Instanciar una clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que represente la presentación que contiene el gráfico que deseas actualizar. 
2. Obtener la referencia de una diapositiva usando su índice.
3. Recorrer todas las formas para encontrar el gráfico deseado.
4. Acceder a la hoja de datos del gráfico.
5. Modificar los datos de la serie del gráfico cambiando los valores de la serie.
6. Añadir una nueva serie y rellenar los datos en ella.
7. Guardar la presentación modificada como un archivo PPTX.

Este código Java muestra cómo actualizar un gráfico:
```java
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Obtener el gráfico con datos predeterminados
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Establecer el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;

    // Obtener la hoja de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Cambiar el nombre de la categoría del gráfico
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Obtener la primera serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Actualizando datos de la serie
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modificando el nombre de la serie
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Obtener la segunda serie del gráfico
    series = chart.getChartData().getSeries().get_Item(1);

    // Actualizando datos de la serie
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modificando el nombre de la serie
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Ahora, agregando una nueva serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Obtener la tercera serie del gráfico
    series = chart.getChartData().getSeries().get_Item(2);

    // Ahora poblando datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Guardar la presentación con el gráfico
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer rango de datos para gráficos**

Para establecer el rango de datos de un gráfico, haz lo siguiente:

1. Instanciar una clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) que represente la presentación que contiene el gráfico.
2. Obtener una referencia a una diapositiva mediante su índice.
3. Recorrer todas las formas para encontrar el gráfico deseado.
4. Acceder a los datos del gráfico y establecer el rango.
5. Guardar la presentación modificada como un archivo PPTX.

Este código Java muestra cómo establecer el rango de datos para un gráfico:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Usar marcadores predeterminados en gráficos**
Cuando usas un marcador predeterminado en los gráficos, cada serie del gráfico recibe automáticamente un símbolo de marcador predeterminado diferente.

Este código Java muestra cómo establecer automáticamente un marcador de serie de gráfico:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    //Obtener segunda serie del gráfico
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //Ahora poblando datos de la serie
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
