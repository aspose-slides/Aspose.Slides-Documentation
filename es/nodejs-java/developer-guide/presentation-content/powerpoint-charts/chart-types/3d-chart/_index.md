---
title: Gráfico 3D
type: docs
url: /es/nodejs-java/3d-chart/
---

## **Establecer las propiedades RotationX, RotationY y DepthPercents de un gráfico 3D**

Aspose.Slides para Node.js a través de Java ofrece una API sencilla para configurar estas propiedades. El siguiente artículo le ayudará a establecer diferentes propiedades como **Rotación X,Y, DepthPercents**, etc. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) clase.
1. Acceda a la primera diapositiva.
1. Añada un gráfico con datos predeterminados.
1. Establezca las propiedades Rotation3D.
1. Grabe la presentación modificada en un archivo PPTX.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Acceder a la primera diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Añadir gráfico con datos predeterminados
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Establecer el índice de la hoja de datos del gráfico
    var defaultWorksheetIndex = 0;
    // Obtener la hoja de datos del gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Añadir series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Añadir categorías
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Establecer propiedades Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Tomar la segunda serie del gráfico
    var series = chart.getChartData().getSeries().get_Item(1);
    // Ahora poblando los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Establecer valor de Superposición
    series.getParentSeriesGroup().setOverlap(100);
    // Guardar la presentación en disco
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Qué tipos de gráfico admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidos Column 3D, Clustered Column 3D, Stacked Column 3D y 100% Stacked Column 3D, junto con tipos 3D relacionados expuestos a través de la enumeración [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) en la referencia de la API de la versión que tenga instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen mediante la [chart API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) o [render the entire slide](/slides/es/nodejs-java/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto resulta útil cuando necesita una vista previa exacta pixel a pixel o desea incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué tan eficaz es la creación y renderizado de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trazado, limite la cantidad de puntos de datos por serie siempre que sea posible y renderice a un tamaño de salida adecuado (resolución y dimensiones) que coincida con la pantalla o las necesidades de impresión del destino.