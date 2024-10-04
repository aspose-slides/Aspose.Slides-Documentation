---
title: Línea de Tendencia
type: docs
url: /es/androidjava/trend-line/
---

## **Agregar Línea de Tendencia**
Aspose.Slides para Android a través de Java proporciona una API simple para gestionar diferentes Líneas de Tendencia de gráficos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtén la referencia de una diapositiva por su índice.
1. Agrega un gráfico con datos predeterminados junto con cualquier tipo deseado (este ejemplo utiliza ChartType.ClusteredColumn).
1. Agregando línea de tendencia exponencial para la serie de gráfico 1.
1. Agregando línea de tendencia lineal para la serie de gráfico 1.
1. Agregando línea de tendencia logarithmica para la serie de gráfico 2.
1. Agregando línea de tendencia de promedio móvil para la serie de gráfico 2.
1. Agregando línea de tendencia polinómica para la serie de gráfico 3.
1. Agregando línea de tendencia potencia para la serie de gráfico 3.
1. Escribe la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico con Líneas de Tendencia.

```java
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation();
try {
    // Crear un gráfico de columnas agrupadas
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Agregando línea de tendencia exponencial para la serie de gráfico 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Agregando línea de tendencia lineal para la serie de gráfico 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Agregando línea de tendencia logarítmica para la serie de gráfico 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("Nueva línea de tendencia logarítmica");
    
    // Agregando línea de tendencia de promedio móvil para la serie de gráfico 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("Nuevo Nombre de Línea de Tendencia");
    
    // Agregando línea de tendencia polinómica para la serie de gráfico 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Agregando línea de tendencia de potencia para la serie de gráfico 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Guardando la presentación
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Agregar Línea Personalizada**
Aspose.Slides para Android a través de Java proporciona una API simple para agregar líneas personalizadas en un gráfico. Para agregar una línea simple a una diapositiva seleccionada de la presentación, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)
- Obtén la referencia de una diapositiva utilizando su índice
- Crea un nuevo gráfico usando el método AddChart expuesto por el objeto Shapes
- Agrega una AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes
- Establece el color de las líneas de la forma.
- Escribe la presentación modificada como un archivo PPTX

El siguiente código se utiliza para crear un gráfico con Líneas Personalizadas.

```java
// Crea una instancia de la clase Presentation
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