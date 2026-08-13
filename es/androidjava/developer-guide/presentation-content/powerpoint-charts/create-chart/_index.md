---
title: Crear o actualizar gráficos de presentaciones PowerPoint en Android
linktitle: Crear o actualizar gráficos
type: docs
weight: 10
url: /es/androidjava/create-chart/
keywords:
- añadir gráfico
- crear gráfico
- editar gráfico
- cambiar gráfico
- actualizar gráfico
- gráfico disperso
- gráfico circular
- gráfico de líneas
- gráfico de mapa de árbol
- gráfico de cotizaciones
- gráfico de caja y bigotes
- gráfico de embudo
- gráfico de explosión
- gráfico de histograma
- gráfico de radar
- gráfico multicategoría
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Cree y personalice gráficos en presentaciones PowerPoint usando Aspose.Slides para Android. Añada, formatee y edite gráficos con ejemplos prácticos de código Java."
---
## **Descripción general**

Este artículo ofrece una guía completa sobre cómo crear y personalizar gráficos usando Aspose.Slides. Aprenderá a añadir programáticamente un gráfico a una diapositiva, poblarlo con datos y aplicar diversas opciones de formato para adaptarlo a sus requisitos de diseño específicos. A lo largo del artículo, ejemplos de código detallados ilustran cada paso, desde la inicialización de la presentación y el objeto gráfico hasta la configuración de series, ejes y leyendas. Siguiendo esta guía, obtendrá una comprensión sólida de cómo integrar la generación dinámica de gráficos en sus aplicaciones, simplificando el proceso de crear presentaciones basadas en datos.

## **Crear un gráfico**
Los gráficos ayudan a las personas a visualizar datos rápidamente y obtener conocimientos, lo que puede no ser evidente de inmediato a partir de una tabla o hoja de cálculo. 


**¿Por qué crear gráficos?**

Con los gráficos usted puede

* agregar, condensar o resumir grandes cantidades de datos en una sola diapositiva de una presentación
* exponer patrones y tendencias en los datos
* deducir la dirección y el impulso de los datos a lo largo del tiempo o respecto a una unidad de medida específica 
* detectar valores atípicos, aberraciones, desviaciones, errores, datos sin sentido, etc. 
* comunicar o presentar datos complejos

En PowerPoint, puede crear gráficos mediante la función de inserción, que proporciona plantillas utilizadas para diseñar muchos tipos de gráficos. Con Aspose.Slides, puede crear gráficos normales (basados en tipos de gráficos populares) y gráficos personalizados. 

{{% alert color="info" %}} 
Para permitirle crear gráficos, Aspose.Slides proporciona la clase [ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ChartType). Los campos de esta clase corresponden a diferentes tipos de gráficos.
{{% /alert %}} 

### **Crear gráficos normales**

_Pasos: Crear gráfico_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Pasos:</em> Crear gráfico de PowerPoint en Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Pasos:</em> Crear gráfico de presentación en Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Pasos:</em> Crear gráfico de presentación de PowerPoint en Java</strong></a>

_Pasos de código:_

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un gráfico con algunos datos y especifique el tipo de gráfico que prefiera. 
4. Añada un título al gráfico. 
5. Acceda a la hoja de cálculo de datos del gráfico. 
6. Elimine todas las series y categorías predeterminadas. 
7. Añada nuevas series y categorías. 
8. Añada nuevos datos al gráfico para las series. 
9. Añada un color de relleno para las series del gráfico. 
10. Añada etiquetas para las series del gráfico. 
11. Guarde la presentación modificada como archivo PPTX. 

Este código Java le muestra cómo crear un gráfico normal:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Añade un gráfico con sus datos predeterminados
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Establece el título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Establece el índice para la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de cálculo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina las series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Añade nuevas series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Añade nuevas categorías
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
    
    // Crea etiquetas personalizadas para cada categoría de la nueva serie
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

### **Crear gráficos de dispersión**
Los gráficos de dispersión (también conocidos como diagramas de dispersión o gráficos x‑y) se utilizan a menudo para comprobar patrones o demostrar correlaciones entre dos variables. 

Puede que desee usar un gráfico de dispersión cuando 

* dispone de datos numéricos emparejados
* tiene 2 variables que se relacionan bien entre sí
* desea determinar si 2 variables están relacionadas
* tiene una variable independiente que posee múltiples valores para una variable dependiente

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Pasos:</em> Crear gráfico de dispersión en Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Pasos:</em> Crear gráfico de dispersión de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Pasos:</em> Crear gráfico de dispersión de presentación PowerPoint en Java</strong></a>

1. Siga los pasos mencionados anteriormente en [Crear gráficos normales](#creating-normal-charts)
2. Para el tercer paso, añada un gráfico con algunos datos y especifique su tipo de gráfico como uno de los siguientes
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Representa un gráfico de dispersión._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Representa un gráfico de dispersión conectado por curvas, con marcadores de datos._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Representa un gráfico de dispersión conectado por curvas, sin marcadores de datos._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Representa un gráfico de dispersión conectado por líneas, con marcadores de datos._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Representa un gráfico de dispersión conectado por líneas, sin marcadores de datos._

Este código Java le muestra cómo crear gráficos de dispersión con diferentes series de marcadores: 

```java
import com.aspose.slides.*;

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
    
    // Añade nuevas series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Obtiene la primera serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Añade un nuevo punto (1:3) a la serie
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Añade un nuevo punto (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Cambia el tipo de la serie
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Cambia el marcador de la serie del gráfico
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
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
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Crear gráficos circulares**

Los gráficos circulares se utilizan mejor para mostrar la relación parte‑total en los datos, sobre todo cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si sus datos contienen muchas partes o etiquetas, puede considerar usar un gráfico de columnas en su lugar.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Pasos:</em> Crear gráfico circular en Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Pasos:</em> Crear gráfico circular de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Pasos:</em> Crear gráfico circular de presentación PowerPoint en Java</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados junto con el tipo deseado (en este caso, [ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ChartType).Pie).
4. Acceda a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Añada nuevos puntos a los gráficos y colores personalizados para los sectores del gráfico circular.
9. Defina etiquetas para las series.
10. Defina líneas guía para las etiquetas de las series.
11. Establezca el ángulo de rotación para las diapositivas del gráfico circular.
12. Guarde la presentación modificada como archivo PPTX

Este código Java le muestra cómo crear un gráfico circular:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancia una clase de presentación que representa un archivo PPTX
Presentation pres = new Presentation();
try {
    // Accede a la primera diapositiva
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Añade un gráfico con datos predeterminados
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Establece el título del gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Establece el índice para la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtiene la hoja de cálculo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Elimina las series y categorías generadas por defecto
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Añade nuevas categorías
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Añade nuevas series
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Rellena los datos de la serie
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // No funciona en la nueva versión
    // Añadiendo nuevos puntos y estableciendo el color del sector
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
    
    // Muestra líneas guía para el gráfico
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Establece el ángulo de rotación para los sectores del gráfico circular
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Saves the presentation with a chart
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Crear gráficos de líneas**

Los gráficos de líneas (también conocidos como diagramas de líneas) se utilizan mejor cuando desea demostrar cambios en el valor a lo largo del tiempo. Con un gráfico de líneas, puede comparar muchos datos a la vez, seguir cambios y tendencias a lo largo del tiempo, resaltar anomalías en series de datos, etc.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados junto con el tipo deseado (en este caso, `ChartType.Line`).
1. Guarde la presentación modificada como archivo PPTX

Este código Java le muestra cómo crear un gráfico de líneas:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Por defecto, los puntos en un gráfico de líneas están unidos por líneas continuas rectas. Si desea que los puntos se unan mediante guiones, puede especificar su tipo de guión preferido de esta forma:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Crear gráficos de mapa de árbol**

Los gráficos de mapa de árbol se utilizan mejor para datos de ventas cuando desea mostrar el tamaño relativo de las categorías de datos y (al mismo tiempo) llamar rápidamente la atención sobre los elementos que son grandes contribuyentes a cada categoría. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Pasos:</em> Crear gráfico de mapa de árbol en Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Pasos:</em> Crear gráfico de mapa de árbol de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Pasos:</em> Crear gráfico de mapa de árbol de presentación PowerPoint en Java</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados junto con el tipo deseado (en este caso, [ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ChartType).TreeMap).
4. Acceda a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Guarde la presentación modificada como archivo PPTX

Este código Java le muestra cómo crear un gráfico de mapa de árbol:

```java
import com.aspose.slides.*;

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

### **Crear gráficos de cotizaciones**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Pasos:</em> Crear gráfico de cotizaciones en Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Pasos:</em> Crear gráfico de cotizaciones de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Pasos:</em> Crear gráfico de cotizaciones de presentación PowerPoint en Java</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ChartType).OpenHighLowClose).
4. Acceda a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Especifique el formato de HiLowLines.
9. Guarde la presentación modificada como archivo PPTX

Ejemplo de código Java utilizado para crear un gráfico de cotizaciones:

```java
import com.aspose.slides.*;

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

### **Crear gráficos de caja y bigotes**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Pasos:</em> Crear gráfico de caja y bigotes en Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Pasos:</em> Crear gráfico de caja y bigotes de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Pasos:</em> Crear gráfico de caja y bigotes de presentación PowerPoint en Java</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ChartType).BoxAndWhisker).
4. Acceda a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Guarde la presentación modificada como archivo PPTX

Este código Java le muestra cómo crear un gráfico de caja y bigotes:

```java
import com.aspose.slides.*;

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

### **Crear gráficos de embudo**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Pasos:</em> Crear gráfico de embudo en Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Pasos:</em> Crear gráfico de embudo de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Pasos:</em> Crear gráfico de embudo de presentación PowerPoint en Java</strong></a>


1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ChartType).Funnel).
4. Guarde la presentación modificada como archivo PPTX

El código Java le muestra cómo crear un gráfico de embudo:

```java
import com.aspose.slides.*;

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

### **Crear gráficos de explosión**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Pasos:</em> Crear gráfico de explosión en Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Pasos:</em> Crear gráfico de explosión de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Pasos:</em> Crear gráfico de explosión de presentación PowerPoint en Java</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados junto con el tipo deseado (en este caso, [ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ChartType).sunburst).
4. Guarde la presentación modificada como archivo PPTX

Este código Java le muestra cómo crear un gráfico de explosión:

```java
import com.aspose.slides.*;

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

### **Crear gráficos de histograma**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Pasos:</em> Crear gráfico de histograma en Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Pasos:</em> Crear gráfico de histograma de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Pasos:</em> Crear gráfico de histograma de presentación PowerPoint en Java</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ChartType).Histogram).
4. Acceda a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Guarde la presentación modificada como archivo PPTX

Este código Java le muestra cómo crear un gráfico de histograma:

```java
import com.aspose.slides.*;

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Crear gráficos de radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Pasos:</em> Crear gráfico de radar en Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Pasos:</em> Crear gráfico de radar de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Pasos:</em> Crear gráfico de radar de presentación PowerPoint en Java</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Añada un gráfico con algunos datos y especifique su tipo de gráfico preferido (`ChartType.Radar` en este caso).
4. Guarde la presentación modificada como archivo PPTX

Este código Java le muestra cómo crear un gráfico de radar:

```java
import com.aspose.slides.*;

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
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Pasos:</em> Crear gráfico multicategoría de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Pasos:</em> Crear gráfico multicategoría de presentación PowerPoint en Java</strong></a>

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Añada un gráfico con datos predeterminados junto con el tipo deseado ([ChartType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ChartType).ClusteredColumn).
4. Acceda a los datos del gráfico mediante [IChartDataWorkbook](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Elimine las series y categorías predeterminadas.
6. Añada nuevas series y categorías.
7. Añada nuevos datos al gráfico para las series.
8. Guarde la presentación modificada como archivo PPTX.

Este código Java le muestra cómo crear un gráfico multicategoría:

```java
import com.aspose.slides.*;

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

    // Añadiendo series
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

Un gráfico de mapa es una visualización de una zona que contiene datos. Los gráficos de mapa se utilizan mejor para comparar datos o valores entre regiones geográficas.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Pasos:</em> Crear gráfico de mapa en Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Pasos:</em> Crear gráfico de mapa de PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Pasos:</em> Crear gráfico de mapa de presentación PowerPoint en Java</strong></a>

Este código Java le muestra cómo crear un gráfico de mapa:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Crear gráficos combinados**

Un gráfico combinado (o combo) combina dos o más tipos de gráficos en un solo diagrama. Este gráfico le permite destacar, comparar o examinar diferencias entre dos o más conjuntos de datos, ayudándole a identificar relaciones entre ellos.

![El gráfico combinado](combination_chart.png)

El siguiente código Java muestra cómo crear el gráfico combinado que se muestra arriba en una presentación PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Añadir nuevas categorías.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Añadir la primera serie.
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

    // Establecer el color de las líneas de cuadrícula principales verticales.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Pasos:</em> Actualizar gráfico de PowerPoint en Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Pasos:</em> Actualizar gráfico de presentación en Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Pasos:</em> Actualizar gráfico de presentación PowerPoint en Java</strong></a>

1. Instancie una clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation) que represente la presentación que contiene el gráfico que desea actualizar.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Recorra todas las formas para encontrar el gráfico deseado.
4. Acceda a la hoja de cálculo de datos del gráfico.
5. Modifique los datos de la serie del gráfico cambiando los valores de la serie.
6. Añada una nueva serie y rellene los datos en ella.
7. Guarde la presentación modificada como archivo PPTX.

Este código Java le muestra cómo actualizar un gráfico:

```java
import com.aspose.slides.*;

// Abre la presentación que contiene el gráfico a actualizar
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Accede a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Obtiene el gráfico de la diapositiva
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Establece el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;

    // Obtiene la hoja de cálculo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Cambia el nombre de la categoría del gráfico
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Obtiene la primera serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Ahora actualizando los datos de la serie
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Modificando el nombre de la serie
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Obtiene la segunda serie del gráfico
    series = chart.getChartData().getSeries().get_Item(1);

    // Ahora actualizando los datos de la serie
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Modificando el nombre de la serie
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Ahora, añadiendo una nueva serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Obtiene la tercera serie del gráfico
    series = chart.getChartData().getSeries().get_Item(2);

    // Ahora rellenando los datos de la serie
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

## **Establecer rango de datos para un gráfico**

Para establecer el rango de datos de un gráfico, haga lo siguiente:

1. Instancie una clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation) que represente la presentación que contiene el gráfico.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Recorra todas las formas para encontrar el gráfico deseado.
4. Acceda a los datos del gráfico y establezca el rango.
5. Guarde la presentación modificada como archivo PPTX.

Este código Java le muestra cómo establecer el rango de datos para un gráfico:

```java
import com.aspose.slides.*;

// Abre la presentación que contiene el gráfico
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usar marcadores predeterminados en los gráficos**

Cuando usa un marcador predeterminado en los gráficos, cada serie del gráfico obtiene automáticamente diferentes símbolos de marcador predeterminados.

Este código Java le muestra cómo establecer automáticamente un marcador de serie de gráfico:

```java
import com.aspose.slides.*;

// Abre la presentación que contiene el gráfico
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
    // Obtener segunda serie del gráfico
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Ahora rellenando los datos de la serie
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

## **Preguntas frecuentes**

### ¿Qué tipos de gráficos son compatibles con Aspose.Slides?

Aspose.Slides es compatible con una amplia gama de [tipos de gráficos](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/charttype/), incluidos columnas, líneas, circulares, áreas, de dispersión, histogramas, de radar y muchos más. Esta flexibilidad le permite elegir el tipo de gráfico más adecuado para sus necesidades de visualización de datos.

### ¿Cómo añado un nuevo gráfico a una diapositiva?

Para añadir un gráfico, primero crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/) , recupera la diapositiva deseada usando su índice y, a continuación, llama al método para añadir un gráfico, especificando el tipo de gráfico y los datos iniciales. Este proceso integra el gráfico directamente en su presentación.

### ¿Cómo puedo actualizar los datos mostrados en un gráfico?

Puede actualizar los datos de un gráfico accediendo a su libro de datos ([IChartDataWorkbook](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichartdataworkbook/)), eliminando cualquier serie y categoría predeterminada y, a continuación, añadiendo sus datos personalizados. Esto le permite refrescar el gráfico para reflejar los datos más recientes.

### ¿Es posible personalizar la apariencia del gráfico?

Sí, Aspose.Slides ofrece amplias opciones de personalización. Puede modificar colores, fuentes, etiquetas, leyendas y otros [elementos de formato](/slides/es/androidjava/chart-entities/) para adaptar la apariencia del gráfico a sus requisitos de diseño específicos.