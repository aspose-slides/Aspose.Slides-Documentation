---
title: Línea de tendencia
type: docs
url: /es/nodejs-java/trend-line/
---

## **Agregar línea de tendencia**

Aspose.Slides for Node.js a través de Java proporciona una API sencilla para administrar diferentes líneas de tendencia de gráficos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquiera de los tipos deseados (este ejemplo usa ChartType.ClusteredColumn).
1. Añadiendo línea de tendencia exponencial para la serie 1 del gráfico.
1. Añadiendo línea de tendencia lineal para la serie 1 del gráfico.
1. Añadiendo línea de tendencia logarítmica para la serie 2 del gráfico.
1. Añadiendo línea de tendencia de promedio móvil para la serie 2 del gráfico.
1. Añadiendo línea de tendencia polinómica para la serie 3 del gráfico.
1. Añadiendo línea de tendencia de potencia para la serie 3 del gráfico.
1. Guardar la presentación modificada en un archivo PPTX.

El siguiente código se usa para crear un gráfico con líneas de tendencia.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    // Crear un gráfico de columnas agrupadas
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Agregar línea de tendencia exponencial para la serie 1 del gráfico
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Agregar línea de tendencia lineal para la serie 1 del gráfico
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Agregar línea de tendencia logarítmica para la serie 2 del gráfico
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Agregar línea de tendencia de promedio móvil para la serie 2 del gráfico
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Agregar línea de tendencia polinómica para la serie 3 del gráfico
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Agregar línea de tendencia de potencia para la serie 3 del gráfico
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Guardar la presentación
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Agregar línea personalizada**

Aspose.Slides for Node.js a través de Java proporciona una API sencilla para agregar líneas personalizadas en un gráfico. Para agregar una línea simple y plana a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)
- Obtener la referencia de una diapositiva usando su Índice
- Crear un nuevo gráfico usando el método AddChart expuesto por el objeto Shapes
- Agregar una AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes
- Establecer el Color de las líneas de la forma.
- Guardar la presentación modificada como un archivo PPTX

El siguiente código se usa para crear un gráfico con líneas personalizadas.
```javascript
// Crear una instancia de la clase Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Qué significan 'forward' y 'backward' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades del eje; para gráficos que no son de dispersión — en número de categorías. Sólo se permiten valores no negativos.

**¿Se conserva la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/es/nodejs-java/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del gráfico](/slides/es/nodejs-java/create-shape-thumbnails/).