---
title: Puntos de Datos del Gráfico Treemap y Sunburst
type: docs
url: /es/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords: "Gráfico Sunburst en Aspose.Slides para Java"
description: "Gráfico Sunburst, Diagrama Sunburst, Gráfico Sunburst, Gráfico Radial o Gráfico Circular Multinivel con Aspose.Slides para Java."
---

Entre otros tipos de gráficos de PowerPoint, hay dos tipos "jerárquicos": **Treemap** y **Sunburst** (también conocido como Gráfico Sunburst, Diagrama Sunburst, Gráfico Radial o Gráfico Circular Multinivel). Estos gráficos muestran datos jerárquicos organizados como un árbol - desde las hojas hasta la parte superior de la rama. Las hojas se definen por los puntos de datos de la serie, y cada nivel de agrupamiento anidado subsiguiente se define por la categoría correspondiente. Aspose.Slides para Java permite formatear puntos de datos de los gráficos Sunburst y Treemap en Java.

Aquí hay un Gráfico Sunburst, donde los datos en la columna Series1 definen los nodos hoja, mientras que otras columnas definen los puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Comencemos agregando un nuevo gráfico Sunburst a la presentación:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Ver también" %}} 
- [**Creando Gráfico Sunburst**](/slides/es/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


Si hay necesidad de formatear puntos de datos del gráfico, debemos usar lo siguiente:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) clases 
y [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) método 
proporcionan acceso para formatear puntos de datos de los gráficos Treemap y Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) 
se usa para acceder a categorías multinivel - representa el contenedor de 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) objetos. 
Básicamente es un envoltorio para 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) con 
las propiedades añadidas específicas para puntos de datos. 
La clase [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) tiene 
dos métodos: [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) y 
[**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) que 
proporcionan acceso a configuraciones correspondientes.
## **Mostrar Valor del Punto de Datos**
Mostrar el valor del punto de datos "Hoja 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Establecer Etiqueta y Color del Punto de Datos**
Establecer la etiqueta de datos "Rama 1" para mostrar el nombre de la serie ("Series1") en lugar del nombre de la categoría. Luego, establecer el color del texto en amarillo:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Establecer Color de la Rama del Punto de Datos**
Cambiar el color de la rama "Tallo 4":

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)