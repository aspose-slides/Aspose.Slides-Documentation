---
title: Personalizar gráficos de burbujas en presentaciones usando Java
linktitle: Gráfico de burbujas
type: docs
url: /es/java/bubble-chart/
keywords:
- gráfico de burbujas
- tamaño de burbuja
- escalado de tamaño
- representación de tamaño
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Cree y personalice potentes gráficos de burbujas en PowerPoint con Aspose.Slides para Java y mejore fácilmente la visualización de sus datos."
---

## **Escala de tamaño de gráfico de burbujas**
Aspose.Slides for Java proporciona soporte para la escala de tamaño de gráficos de burbujas. En Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) y [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) se han añadido los métodos. A continuación se muestra un ejemplo de muestra. 
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Representar datos como tamaños de gráfico de burbujas**
Se han añadido los métodos [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) y [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) a las interfaces [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup) y a las clases relacionadas. **BubbleSizeRepresentation** especifica cómo se representan los valores de tamaño de burbuja en el gráfico de burbujas. Los valores posibles son: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Area) y [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType#Width). En consecuencia, se ha añadido el enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/java/com.aspose.slides/BubbleSizeRepresentationType) para especificar las formas posibles de representar los datos como tamaños de gráfico de burbujas. A continuación se muestra el código de ejemplo.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Se admite un "gráfico de burbujas con efecto 3-D", y en qué se diferencia de uno normal?**

Sí. Existe un tipo de gráfico separado, "Bubble with 3-D". Aplica estilo 3-D a las burbujas pero no añade un eje adicional; los datos siguen siendo X-Y-S (tamaño). El tipo está disponible en la clase [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

**¿Existe un límite en la cantidad de series y puntos en un gráfico de burbujas?**

No hay un límite estricto a nivel de API; las restricciones dependen del rendimiento y de la versión de PowerPoint de destino. Se recomienda mantener un número razonable de puntos para la legibilidad y la velocidad de renderizado.

**¿Cómo afectará la exportación a la apariencia de un gráfico de burbujas (PDF, imágenes)?**

La exportación a formatos compatibles preserva la apariencia del gráfico; el renderizado lo realiza el motor de Aspose.Slides. Para formatos raster/vector, se aplican las reglas generales de renderizado de gráficos (resolución, anti-aliasing), por lo que debe elegirse un DPI suficiente para la impresión.