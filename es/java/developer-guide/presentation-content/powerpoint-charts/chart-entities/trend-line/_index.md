---
title: Añadir líneas de tendencia a los gráficos de presentación en Java
linktitle: Línea de tendencia
type: docs
url: /es/java/trend-line/
keywords:
- gráfico
- línea de tendencia
- línea de tendencia exponencial
- línea de tendencia lineal
- línea de tendencia logarítmica
- línea de tendencia de promedio móvil
- línea de tendencia polinómica
- línea de tendencia de potencia
- línea de tendencia personalizada
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Añade y personaliza rápidamente líneas de tendencia en los gráficos de PowerPoint con Aspose.Slides para Java — una guía práctica para captar la atención de tu audiencia."
---

## **Agregar línea de tendencia**
Aspose.Slides for Java provides a simple API for managing different chart Trend Lines:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados y cualquiera de los tipos deseados (este ejemplo utiliza ChartType.ClusteredColumn).
1. Agregar línea de tendencia exponencial para la serie 1 del gráfico.
1. Agregar línea de tendencia lineal para la serie 1 del gráfico.
1. Agregar línea de tendencia logarítmica para la serie 2 del gráfico.
1. Agregar línea de tendencia de promedio móvil para la serie 2 del gráfico.
1. Agregar línea de tendencia polinómica para la serie 3 del gráfico.
1. Agregar línea de tendencia de potencia para la serie 3 del gráfico.
1. Escribir la presentación modificada en un archivo PPTX.

The following code is used to create a chart with Trend Lines.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Crear un gráfico de columnas agrupadas
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Añadiendo línea de tendencia exponencial para la serie 1 del gráfico
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Añadiendo línea de tendencia lineal para la serie 1 del gráfico
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Añadiendo línea de tendencia logarítmica para la serie 2 del gráfico
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Añadiendo línea de tendencia de promedio móvil para la serie 2 del gráfico
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Añadiendo línea de tendencia polinómica para la serie 3 del gráfico
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Añadiendo línea de tendencia de potencia para la serie 3 del gráfico
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Guardando la presentación
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Agregar línea personalizada**
Aspose.Slides for Java ofrece una API sencilla para agregar líneas personalizadas en un gráfico. Para agregar una línea sencilla a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)
- Obtener la referencia de una diapositiva mediante su Índice
- Crear un nuevo gráfico utilizando el método AddChart expuesto por el objeto Shapes
- Agregar un AutoShape de tipo Línea utilizando el método AddAutoShape expuesto por el objeto Shapes
- Establecer el Color de las líneas de la forma.
- Escribir la presentación modificada como un archivo PPTX

The following code is used to create a chart with Custom Lines.
```java
// Crear una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Qué significan 'forward' y 'backward' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades del eje; para gráficos que no son de dispersión — en número de categorías. Sólo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/java/convert-powerpoint-to-pdf/)/[SVG](/slides/es/java/render-a-slide-as-an-svg-image/) y renderiza gráficos en imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del gráfico](/slides/es/java/create-shape-thumbnails/).