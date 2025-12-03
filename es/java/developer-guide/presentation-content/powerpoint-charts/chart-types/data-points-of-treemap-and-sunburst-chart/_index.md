---
title: Personalizar puntos de datos en gráficos Treemap y Sunburst usando Java
linktitle: Puntos de datos en gráficos Treemap y Sunburst
type: docs
url: /es/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- gráfico treemap
- gráfico sunburst
- punto de datos
- color de etiqueta
- color de rama
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo administrar los puntos de datos en gráficos treemap y sunburst con Aspose.Slides para Java, compatible con los formatos de PowerPoint."
---

Entre los demás tipos de gráficos de PowerPoint, existen dos tipos “jerárquicos”: el gráfico **Treemap** y el **Sunburst** (también conocido como Gráfico Sunburst, Diagrama Sunburst, Gráfico Radial, Gráfico Radial o Gráfico de Tartas de Múltiples Niveles). Estos gráficos muestran datos jerárquicos organizados como un árbol, de las hojas hasta la parte superior de la rama. Las hojas se definen por los puntos de datos de la serie, y cada nivel de agrupación anidado subsiguiente se define por la categoría correspondiente. Aspose.Slides for Java permite formatear los puntos de datos del gráfico Sunburst y Treemap en Java.

Aquí hay un gráfico Sunburst, donde los datos en la columna Series1 definen los nodos hoja, mientras que otras columnas definen puntos de datos jerárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Comencemos añadiendo un nuevo gráfico Sunburst a la presentación:
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
- [**Crear gráfico Sunburst**](/slides/es/java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Si es necesario formatear los puntos de datos del gráfico, debemos usar lo siguiente:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) clases 
y [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) método 
proporcionan acceso para formatear los puntos de datos de los gráficos Treemap y Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevelsManager) 
se utiliza para acceder a categorías multinivel; representa el contenedor de 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) objetos. 
Básicamente es un wrapper para 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartCategoryLevelsManager) con 
las propiedades añadidas específicas para los puntos de datos. 
La clase [**IChartDataPointLevel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel) tiene 
dos métodos: [**getFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getFormat--) y 
[**getDataLabel**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataPointLevel#getLabel--) que 
proporcionan acceso a la configuración correspondiente.
## **Mostrar valor del punto de datos**
Mostrar el valor del punto de datos "Leaf 4":
```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Establecer etiqueta y color del punto de datos**
Establecer la etiqueta del dato "Branch 1" para que muestre el nombre de la serie ("Series1") en lugar del nombre de la categoría. Luego establecer el color del texto a amarillo:
```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Establecer color de rama del punto de datos**
Cambiar el color de la rama "Steam 4":
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

## **Preguntas frecuentes**

**¿Puedo cambiar el orden (clasificación) de los segmentos en Sunburst/Treemap?**

No. PowerPoint clasifica los segmentos automáticamente (normalmente por valores descendentes, en sentido horario). Aspose.Slides refleja este comportamiento: no se puede cambiar el orden directamente; se consigue preprocesando los datos.

**¿Cómo afecta el tema de la presentación a los colores de los segmentos y las etiquetas?**

Los colores del gráfico heredan el [tema/paleta](/slides/es/java/presentation-theme/) de la presentación a menos que se establezcan explícitamente rellenos o fuentes. Para resultados consistentes, fije rellenos sólidos y el formato de texto en los niveles requeridos.

**¿La exportación a PDF/PNG preserva los colores personalizados de las ramas y la configuración de las etiquetas?**

Sí. Al exportar la presentación, la configuración del gráfico (rellenos, etiquetas) se conserva en los formatos de salida porque Aspose.Slides renderiza con el formato del gráfico aplicado.

**¿Puedo calcular las coordenadas reales de una etiqueta/elemento para colocar una superposición personalizada sobre el gráfico?**

Sí. Después de validar el diseño del gráfico, las coordenadas reales *x* e *y* están disponibles para los elementos (por ejemplo, un [DataLabel](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/)), lo que ayuda a posicionar con precisión superposiciones.