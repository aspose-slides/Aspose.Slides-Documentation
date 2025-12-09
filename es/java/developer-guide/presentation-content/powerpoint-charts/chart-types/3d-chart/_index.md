---
title: Personalizar gráficos 3D en presentaciones usando Java
linktitle: Gráfico 3D
type: docs
url: /es/java/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos 3-D en Aspose.Slides para Java, con soporte para archivos PPT y PPTX - mejore sus presentaciones hoy."
---

## **Establecer las propiedades RotationX, RotationY y DepthPercents del gráfico 3D**
Aspose.Slides for Java proporciona una API sencilla para establecer estas propiedades. Este artículo le ayudará a cómo establecer diferentes propiedades como **Rotación X,Y, DepthPercents**, etc. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) clase.
1. Acceder a la primera diapositiva.
1. Añadir un gráfico con datos predeterminados.
1. Establecer las propiedades Rotation3D.
1. Guardar la presentación modificada en un archivo PPTX.
```java
Presentation pres = new Presentation();
try {
    // Acceder a la primera diapositiva
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Añadir gráfico con datos predeterminados
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Establecer el índice de la hoja de datos del gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtener la hoja de cálculo de datos del gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Añadir series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Añadir categorías
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Establecer propiedades Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Tomar la segunda serie del gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Ahora llenando los datos de la serie
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Establecer valor OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Guardar la presentación en disco
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Qué tipos de gráfico admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidos Column 3D, Clustered Column 3D, Stacked Column 3D y 100% Stacked Column 3D, junto con tipos 3D relacionados expuestos a través de la clase [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) en la referencia de la API de la versión instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen mediante la [API de gráficos](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) o [renderizar toda la diapositiva](/slides/es/java/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa pixel‑perfecta o desea incrustar el gráfico en documentos, paneles o páginas web sin requerir PowerPoint.

**¿Qué tan eficiente es la creación y el renderizado de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a una salida de tamaño adecuado (resolución y dimensiones) que coincida con la pantalla o las necesidades de impresión del destino.