---
title: Crear o Actualizar Gráficos de Presentación de PowerPoint en Java
linktitle: Crear Gráfico
type: docs
weight: 10
url: /es/androidjava/create-chart/
keywords: "Crear gráfico, gráfico disperso, gráfico circular, gráfico de mapa de árbol, gráfico de acciones, gráfico de caja y bigote, gráfico de histograma, gráfico de embudo, gráfico de sol, gráfico multisección, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Crear gráfico en presentación de PowerPoint en Java"
---

## Resumen

Este artículo describe cómo **crear gráficos de presentación de PowerPoint en Java**. También puedes **actualizar los gráficos en Java**. Cubre estos temas.

_Gráfico_: **Normal**
- [Java Crear Gráfico de PowerPoint](#java-create-powerpoint-chart)
- [Java Crear Gráfico de Presentación](#java-create-presentation-chart)
- [Java Crear Gráfico de Presentación de PowerPoint](#java-create-powerpoint-presentation-chart)

_Gráfico_: **Disperso**
- [Java Crear Gráfico Disperso](#java-create-scattered-chart)
- [Java Crear Gráfico Disperso de PowerPoint](#java-create-powerpoint-scattered-chart)
- [Java Crear Gráfico Disperso de Presentación de PowerPoint](#java-create-powerpoint-presentation-scattered-chart)

_Gráfico_: **Circular**
- [Java Crear Gráfico Circular](#java-create-pie-chart)
- [Java Crear Gráfico Circular de PowerPoint](#java-create-powerpoint-pie-chart)
- [Java Crear Gráfico Circular de Presentación de PowerPoint](#java-create-powerpoint-presentation-pie-chart)

_Gráfico_: **Mapa de Árbol**
- [Java Crear Gráfico de Mapa de Árbol](#java-create-tree-map-chart)
- [Java Crear Gráfico de Mapa de Árbol de PowerPoint](#java-create-powerpoint-tree-map-chart)
- [Java Crear Gráfico de Mapa de Árbol de Presentación de PowerPoint](#java-create-powerpoint-presentation-tree-map-chart)

_Gráfico_: **Acciones**
- [Java Crear Gráfico de Acciones](#java-create-stock-chart)
- [Java Crear Gráfico de Acciones de PowerPoint](#java-create-powerpoint-stock-chart)
- [Java Crear Gráfico de Acciones de Presentación de PowerPoint](#java-create-powerpoint-presentation-stock-chart)

_Gráfico_: **Caja y Bigote**
- [Java Crear Gráfico de Caja y Bigote](#java-create-box-and-whisker-chart)
- [Java Crear Gráfico de Caja y Bigote de PowerPoint](#java-create-powerpoint-box-and-whisker-chart)
- [Java Crear Gráfico de Caja y Bigote de Presentación de PowerPoint](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Gráfico_: **Embudo**
- [Java Crear Gráfico de Embudo](#java-create-funnel-chart)
- [Java Crear Gráfico de Embudo de PowerPoint](#java-create-powerpoint-funnel-chart)
- [Java Crear Gráfico de Embudo de Presentación de PowerPoint](#java-create-powerpoint-presentation-funnel-chart)

_Gráfico_: **Sol**
- [Java Crear Gráfico de Sol](#java-create-sunburst-chart)
- [Java Crear Gráfico de Sol de PowerPoint](#java-create-powerpoint-sunburst-chart)
- [Java Crear Gráfico de Sol de Presentación de PowerPoint](#java-create-powerpoint-presentation-sunburst-chart)

_Gráfico_: **Histograma**
- [Java Crear Gráfico de Histograma](#java-create-histogram-chart)
- [Java Crear Gráfico de Histograma de PowerPoint](#java-create-powerpoint-histogram-chart)
- [Java Crear Gráfico de Histograma de Presentación de PowerPoint](#java-create-powerpoint-presentation-histogram-chart)

_Gráfico_: **Radar**
- [Java Crear Gráfico de Radar](#java-create-radar-chart)
- [Java Crear Gráfico de Radar de PowerPoint](#java-create-powerpoint-radar-chart)
- [Java Crear Gráfico de Radar de Presentación de PowerPoint](#java-create-powerpoint-presentation-radar-chart)

_Gráfico_: **Multisección**
- [Java Crear Gráfico Multisección](#java-create-multi-category-chart)
- [Java Crear Gráfico Multisección de PowerPoint](#java-create-powerpoint-multi-category-chart)
- [Java Crear Gráfico Multisección de Presentación de PowerPoint](#java-create-powerpoint-presentation-multi-category-chart)

_Gráfico_: **Mapa**
- [Java Crear Gráfico de Mapa](#java-create-map-chart)
- [Java Crear Gráfico de Mapa de PowerPoint](#java-create-powerpoint-map-chart)
- [Java Crear Gráfico de Mapa de Presentación de PowerPoint](#java-create-powerpoint-presentation-map-chart)

_Acción_: **Actualizar Gráfico**
- [Java Actualizar Gráfico de PowerPoint](#java-update-powerpoint-chart)
- [Java Actualizar Gráfico de Presentación](#java-update-presentation-chart)
- [Java Actualizar Gráfico de Presentación de PowerPoint](#java-update-powerpoint-presentation-chart)


## **Crear Gráfico**
Los gráficos ayudan a las personas a visualizar datos rápidamente y obtener información que puede no ser inmediatamente obvia a partir de una tabla o una hoja de cálculo. 


**¿Por qué crear gráficos?**

Usando gráficos, puedes

* agregar, condensar o resumir grandes cantidades de datos en una sola diapositiva de una presentación
* exponer patrones y tendencias en los datos
* deducir la dirección y el impulso de los datos a lo largo del tiempo o con respecto a una unidad de medida específica 
* identificar valores atípicos, aberraciones, desviaciones, errores, datos absurdos, etc. 
* comunicar o presentar datos complejos

En PowerPoint, puedes crear gráficos a través de la función de inserción, que proporciona plantillas utilizadas para diseñar muchos tipos de gráficos. Usando Aspose.Slides, puedes crear gráficos regulares (basados en tipos de gráficos populares) y gráficos personalizados. 

{{% alert color="primary" %}} 

Para permitirte crear gráficos, Aspose.Slides proporciona la clase [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType). Los campos de esta clase corresponden a diferentes tipos de gráficos.

{{% /alert %}} 

### **Creando Gráficos Normales**

_Pasos: Crear Gráfico_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Pasos:</em> Crear Gráfico de PowerPoint en Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Pasos:</em> Crear Gráfico de Presentación en Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Pasos:</em> Crear Gráfico de Presentación de PowerPoint en Java</strong></a>

_Pasos de Código:_

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un gráfico con algunos datos y especifica tu tipo de gráfico preferido. 
4. Agrega un título para el gráfico. 
5. Accede a la hoja de datos del gráfico.
6. Borra todas las series y categorías predeterminadas.
7. Agrega nuevas series y categorías.
8. Agrega algunos nuevos datos de gráfico para las series de gráfico.
9. Agrega un color de relleno para las series de gráfico.
10. Agrega etiquetas para las series de gráfico. 
11. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo crear un gráfico normal:

```java
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Agrega un gráfico con sus datos predeterminados
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Establece el Título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Título de Ejemplo");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Establece la primera serie para mostrar valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Establece el índice para la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de trabajo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina las series y categorías generadas automáticamente
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Agrega nuevas series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Serie 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Serie 2"),chart.getType());
    
    // Agrega nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Categoría 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Categoría 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Categoría 3"));
    
    // Toma la primera serie de gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Ahora pobla los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Establece el color de relleno para la serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Toma la segunda serie de gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Población de datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Establece el color de relleno para la serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Crea etiquetas personalizadas para cada categoría para la nueva serie
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

### **Creando Gráficos Dispersos**
Los gráficos dispersos (también conocidos como gráficos dispersos o gráficos x-y) se utilizan a menudo para verificar patrones o demostrar correlaciones entre dos variables.

Es posible que desees usar un gráfico disperso cuando 

* tienes datos numéricos pareados
* tienes 2 variables que se emparejan bien
* deseas determinar si 2 variables están relacionadas
* tienes una variable independiente que tiene múltiples valores para una variable dependiente

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Pasos:</em> Crear Gráfico Disperso en Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Pasos:</em> Crear Gráfico Disperso de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Pasos:</em> Crear Gráfico Disperso de Presentación de PowerPoint en Java</strong></a>

1. Por favor, sigue los pasos mencionados anteriormente en [Creando Gráficos Normales](#creating-normal-charts)
2. En el tercer paso, agrega un gráfico con algunos datos y especifica tu tipo de gráfico como uno de los siguientes
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Representa un gráfico disperso._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representa un gráfico disperso conectado por curvas, con marcadores de datos._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Representa un gráfico disperso conectado por curvas, sin marcadores de datos._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representa un gráfico disperso conectado por líneas, con marcadores de datos._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Representa un gráfico disperso conectado por líneas, sin marcadores de datos._

Este código Java te muestra cómo crear un gráfico disperso con una serie diferente de marcadores:

```java
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Crea el gráfico predeterminado
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Obtiene el índice de la hoja de datos del gráfico predeterminado
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de trabajo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina las series de demostración
    chart.getChartData().getSeries().clear();
    
    // Agrega nuevas series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Serie 2"), chart.getType());
    
    // Toma la primera serie de gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Agrega un nuevo punto (1:3) a la serie
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Agrega un nuevo punto (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Cambia el tipo de serie
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Cambia el marcador de la serie de gráfico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Toma la segunda serie de gráfico
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Agrega un nuevo punto (5:2) ahí
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Agrega un nuevo punto (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Agrega un nuevo punto (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Agrega un nuevo punto (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Cambia el marcador de la serie de gráfico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creando Gráficos Circulares**

Los gráficos circulares son mejores para mostrar la relación parte-todo en los datos, especialmente cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si tus datos contienen muchas partes o etiquetas, es posible que desees considerar usar un gráfico de barras en su lugar.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Pasos:</em> Crear Gráfico Circular en Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Pasos:</em> Crear Gráfico Circular de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Pasos:</em> Crear Gráfico Circular de Presentación de PowerPoint en Java</strong></a>

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva mediante su índice.
3. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).Pie).
4. Accede a los datos del gráfico [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Borra las series y categorías predeterminadas.
6. Agrega nuevas series y categorías.
7. Agrega nuevos datos de gráfico para las series de gráfico.
8. Agrega nuevos puntos para los gráficos y agrega colores personalizados para los sectores del gráfico circular.
9. Establece etiquetas para las series.
10. Establece líneas líderes para las etiquetas de las series.
11. Establece el ángulo de rotación para las diapositivas del gráfico circular.
12. Escribe la presentación modificada en un archivo PPTX.

Este código Java te muestra cómo crear un gráfico circular:

```java
// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Agrega un gráfico con datos predeterminados
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Establece el Título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Título de Ejemplo");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Establece la primera serie para mostrar valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Establece el índice para la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de trabajo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina las series y categorías generadas automáticamente
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Agrega nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Primer Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Segundo Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Tercer Trimestre"));
    
    // Agrega nuevas series
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Serie 1"), chart.getType());
    
    // Pobla los datos de la serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // No funciona en la nueva versión
    // Agregar nuevos puntos y establecer el color del sector
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
    
    // Crea etiquetas personalizadas para cada categoría para la nueva serie
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
    
    // Muestra líneas líderes para el gráfico
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Establece el Ángulo de Rotación para los Sectores del Gráfico Circular
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Guarda la presentación con un gráfico
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creando Gráficos de Línea**

Los gráficos de línea (también conocidos como gráficos de líneas) son mejores en situaciones donde deseas demostrar cambios en el valor a lo largo del tiempo. Usando un gráfico de línea, puedes comparar muchos datos a la vez, rastrear cambios y tendencias a lo largo del tiempo, resaltar anomalías en las series de datos, etc.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.Line`).
1. Accede a los datos del gráfico IChartDataWorkbook.
1. Borra las series y categorías predeterminadas.
1. Agrega nuevas series y categorías.
1. Agrega nuevos datos de gráfico para las series de gráfico.
1. Escribe la presentación modificada en un archivo PPTX.

Este código Java te muestra cómo crear un gráfico de línea:

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Por defecto, los puntos en un gráfico de línea están unidos por líneas continuas rectas. Si deseas que los puntos sean unidos por guiones en su lugar, puedes especificar tu tipo de guión preferido de esta manera:

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **Creando Gráficos de Mapa de Árbol**

Los gráficos de mapa de árbol son mejores para datos de ventas cuando deseas mostrar el tamaño relativo de las categorías de datos y (al mismo tiempo) atraer rápidamente la atención a los elementos que son grandes contribuyentes a cada categoría. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Pasos:</em> Crear Gráfico de Mapa de Árbol en Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Pasos:</em> Crear Gráfico de Mapa de Árbol de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Pasos:</em> Crear Gráfico de Mapa de Árbol de Presentación de PowerPoint en Java</strong></a>

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).TreeMap).
4. Accede a los datos del gráfico [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Borra las series y categorías predeterminadas.
6. Agrega nuevas series y categorías.
7. Agrega nuevos datos de gráfico para las series de gráfico.
8. Escribe la presentación modificada en un archivo PPTX.

Este código Java te muestra cómo crear un gráfico de mapa de árbol:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //rama 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Hoja1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tallo1");
    leaf.getGroupingLevels().setGroupingItem(2, "Rama1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Hoja2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Hoja3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tallo2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Hoja4"));

    //rama 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Hoja5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tallo3");
    leaf.getGroupingLevels().setGroupingItem(2, "Rama2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Hoja6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Hoja7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tallo4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Hoja8"));

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

### **Creando Gráficos de Acciones**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Pasos:</em> Crear Gráfico de Acciones en Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-create-powerpoint-stock-chart"><strong><em>Pasos:</em> Crear Gráfico de Acciones de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Pasos:</em> Crear Gráfico de Acciones de Presentación de PowerPoint en Java</strong></a>

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtén una referencia de la diapositiva mediante su índice.
3. Agrega un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).OpenHighLowClose).
4. Accede a los datos del gráfico [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Borra las series y categorías predeterminadas.
6. Agrega nuevas series y categorías.
7. Agrega nuevos datos de gráfico para las series de gráfico.
8. Especifica el formato de HiLowLines.
9. Escribe la presentación modificada en un archivo PPTX.

El siguiente código de muestra de Java se utiliza para crear un gráfico de acciones:

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

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Abrir"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "Alto"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Bajo"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Cerrar"), chart.getType());

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

### **Creando Gráficos de Caja y Bigote**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Pasos:</em> Crear Gráfico de Caja y Bigote en Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-create-powerpoint-box-and-whisker-chart"><strong><em>Pasos:</em> Crear Gráfico de Caja y Bigote de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Pasos:</em> Crear Gráfico de Caja y Bigote de Presentación de PowerPoint en Java</strong></a>

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un gráfico con datos predeterminados junto con el tipo ([ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).BoxAndWhisker).
4. Accede a los datos del gráfico [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Borra las series y categorías predeterminadas.
6. Agrega nuevas series y categorías.
7. Agrega nuevos datos de gráfico para las series de gráfico.
8. Escribe la presentación modificada en un archivo PPTX.

Este código Java te muestra cómo crear un gráfico de caja y bigote:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Categoría 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Categoría 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Categoría 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Categoría 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Categoría 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Categoría 1"));

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

### **Creando Gráficos de Embudo**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Pasos:</em> Crear Gráfico de Embudo en Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Pasos:</em> Crear Gráfico de Embudo de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Pasos:</em> Crear Gráfico de Embudo de Presentación de PowerPoint en Java</strong></a>


1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).Funnel).
4. Escribe la presentación modificada en un archivo PPTX.

El siguiente código de Java te muestra cómo crear un gráfico de embudo:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Categoría 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Categoría 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Categoría 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Categoría 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Categoría 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Categoría 6"));

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

### **Creando Gráficos de Sol**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Pasos:</em> Crear Gráfico de Sol en Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Pasos:</em> Crear Gráfico de Sol de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Pasos:</em> Crear Gráfico de Sol de Presentación de PowerPoint en Java</strong></a>

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un gráfico con datos predeterminados junto con el tipo deseado (en este caso, [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).sunburst).
4. Escribe la presentación modificada en un archivo PPTX.

Este código Java te muestra cómo crear un gráfico de sol:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //rama 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Hoja1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tallo1");
    leaf.getGroupingLevels().setGroupingItem(2, "Rama1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Hoja2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Hoja3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tallo2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Hoja4"));

    //rama 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Hoja5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tallo3");
    leaf.getGroupingLevels().setGroupingItem(2, "Rama2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Hoja6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Hoja7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tallo4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Hoja8"));

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

### **Creando Gráficos de Histograma**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Pasos:</em> Crear Gráfico de Histograma en Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Pasos:</em> Crear Gráfico de Histograma de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Pasos:</em> Crear Gráfico de Histograma de Presentación de PowerPoint en Java</strong></a>

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Agrega un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).Histogram).
4. Accede a los datos del gráfico [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Borra las series y categorías predeterminadas.
6. Agrega nuevas series y categorías.
7. Escribe la presentación modificada en un archivo PPTX.

Este código Java te muestra cómo crear un gráfico de histograma:

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creando Gráficos de Radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Pasos:</em> Crear Gráfico de Radar en Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Pasos:</em> Crear Gráfico de Radar de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Pasos:</em> Crear Gráfico de Presentación de Radar de PowerPoint en Java</strong></a>

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtén una referencia de la diapositiva a través de su índice. 
3. Agrega un gráfico con algunos datos y especifica tu tipo de gráfico preferido (`ChartType.Radar` en este caso).
4. Escribe la presentación modificada en un archivo PPTX.

Este código Java te muestra cómo crear un gráfico de radar:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creando Gráficos Multisección**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Pasos:</em> Crear Gráfico Multisección en Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Pasos:</em> Crear Gráfico Multisección de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Pasos:</em> Crear Gráfico Multisección de Presentación de PowerPoint en Java</strong></a>

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
2. Obtén una referencia de la diapositiva a través de su índice. 
3. Agrega un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).ClusteredColumn).
4. Accede a los datos del gráfico [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Borra las series y categorías predeterminadas.
6. Agrega nuevas series y categorías.
7. Agrega nuevos datos de gráfico para las series de gráfico.
8. Escribe la presentación modificada en un archivo PPTX.

Este código Java te muestra cómo crear un gráfico multisección:

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
    category.getGroupingLevels().setGroupingItem(1, "Grupo1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Grupo2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Grupo3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Grupo4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // Agregar Series
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Serie 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Guarda la presentación con el gráfico
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creando Gráficos de Mapa**

Un gráfico de mapa es una visualización de un área que contiene datos. Los gráficos de mapa son mejores para comparar datos o valores en regiones geográficas.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Pasos:</em> Crear Gráfico de Mapa en Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Pasos:</em> Crear Gráfico de Mapa de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Pasos:</em> Crear Gráfico de Mapa de Presentación de PowerPoint en Java</strong></a>

Este código Java te muestra cómo crear un gráfico de mapa:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Creando Gráficos Combinados**

Un gráfico combinado (o gráfico combo) es un gráfico que combina dos o más gráficos en un solo gráfico. Tal gráfico te permite resaltar, comparar o revisar las diferencias entre dos (o más) conjuntos de datos. De esta manera, ves la relación (si la hay) entre los conjuntos de datos. 

![combination-chart-ppt](combination-chart-ppt.png)

Este código Java te muestra cómo crear un gráfico combinado en PowerPoint:

```java
private static void createComboChart()
{
    Presentation pres = new Presentation();
    {
        IChart chart = createChart(pres.getSlides().get_Item(0));
        addFirstSeriesToChart(chart);
        addSecondSeriesToChart(chart);
        pres.save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart createChart(ISlide slide)
{
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 1, "Serie 1"), chart.getType());
    chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 2, "Serie 2"), chart.getType());

    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Categoría 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Categoría 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Categoría 3"));

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 30));
    
    series = chart.getChartData().getSeries().get_Item(1);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 60));
    
    return chart;
}

private static void addFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 3, "Serie 3"), ChartType.ScatterWithSmoothLines);

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 0, 1, 3),
            workbook.getCell(worksheetIndex, 0, 2, 5));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 3, 10),
            workbook.getCell(worksheetIndex, 1, 4, 13));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 2, 3, 20),
            workbook.getCell(worksheetIndex, 2, 4, 15));

    series.setPlotOnSecondAxis(true);
}

private static void addSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 5, "Serie 4"),
            ChartType.ScatterWithStraightLinesAndMarkers);

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 3, 5),
            workbook.getCell(worksheetIndex, 1, 4, 2));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 5, 10),
            workbook.getCell(worksheetIndex, 1, 6, 7));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 2, 5, 15),
            workbook.getCell(worksheetIndex, 2, 6, 12));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 3, 5, 12),
            workbook.getCell(worksheetIndex, 3, 6, 9));

    series.setPlotOnSecondAxis(true);
}
```

## **Actualizar Gráficos**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Pasos:</em> Actualizar Gráfico de PowerPoint en Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Pasos:</em> Actualizar Gráfico de Presentación en Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Pasos:</em> Actualizar Gráfico de Presentación de PowerPoint en Java</strong></a>

1. Instancia una clase de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que representa la presentación que contiene el gráfico que deseas actualizar.
2. Obtén la referencia de una diapositiva utilizando su índice.
3. Recorre todas las formas para encontrar el gráfico deseado.
4. Accede a la hoja de datos del gráfico.
5. Modifica los datos de las series del gráfico cambiando los valores de las series.
6. Agrega una nueva serie y pobla los datos en ella.
7. Escribe la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo actualizar un gráfico:

```java
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Obtiene el gráfico con datos predeterminados
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Establece el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;

    // Obtiene la hoja de trabajo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Cambia el nombre de la categoría del gráfico
    fact.getCell(defaultWorksheetIndex, 1, 0, "Categoría Modificada 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Categoría Modificada 2");

    // Toma la primera serie de gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Ahora actualiza los datos de la serie
    fact.getCell(defaultWorksheetIndex, 0, 1, "Nueva_Serie1");// Modifica el nombre de la serie
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Toma la segunda serie de gráfico
    series = chart.getChartData().getSeries().get_Item(1);

    // Ahora actualiza los datos de la serie
    fact.getCell(defaultWorksheetIndex, 0, 2, "Nueva_Serie2");// Modifica el nombre de la serie
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Ahora, agrega una nueva serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Serie 3"), chart.getType());

    // Toma la tercera serie de gráfico
    series = chart.getChartData().getSeries().get_Item(2);

    // Ahora pobla los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Guarda la presentación con el gráfico
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Rango de Datos para Gráficos**

Para establecer el rango de datos para un gráfico, haz lo siguiente:

1. Instancia una clase de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) que representa la presentación que contiene el gráfico.
2. Obtén una referencia de la diapositiva a través de su índice.
3. Recorre todas las formas para encontrar el gráfico deseado.
4. Accede a los datos del gráfico y establece el rango.
5. Guarda la presentación modificada como un archivo PPTX.

Este código Java te muestra cómo establecer el rango de datos para un gráfico:

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

## **Usar Marcadores Predeterminados en Gráficos**
Cuando usas un marcador predeterminado en gráficos, cada serie de gráficos recibe automáticamente diferentes símbolos de marcador predeterminados.

Este código Java te muestra cómo establecer un marcador de serie de gráfico automáticamente:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Serie 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2