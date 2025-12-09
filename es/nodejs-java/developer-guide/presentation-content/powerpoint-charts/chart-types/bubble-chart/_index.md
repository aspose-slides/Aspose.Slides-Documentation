---
title: Gráfico de burbuja
type: docs
url: /es/nodejs-java/bubble-chart/
---

## **Escalado de Tamaño de Gráficos de Burbuja**
Aspose.Slides for Node.js via Java proporciona soporte para el escalado del tamaño de los gráficos de burbuja. En Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) y [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) se han añadido métodos. A continuación se muestra un ejemplo de muestra. 
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Representar datos como tamaños de gráficos de burbuja**
Se han añadido los métodos [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) y [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) a las clases [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup) y clases relacionadas. **BubbleSizeRepresentation** especifica cómo se representan los valores de tamaño de burbuja en el gráfico de burbuja. Los valores posibles son: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) y [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). En consecuencia, el enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType) se ha añadido para especificar las formas posibles de representar datos como tamaños de gráficos de burbuja. A continuación se muestra un código de ejemplo.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Se admite un "gráfico de burbuja con efecto 3-D" y en qué se diferencia de uno normal?**

Sí. Existe un tipo de gráfico separado, "Bubble with 3-D". Aplica estilo 3‑D a las burbujas pero no agrega un eje adicional; los datos siguen siendo X‑Y‑S (tamaño). El tipo está disponible en la enumeración [chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

**¿Existe un límite en la cantidad de series y puntos en un gráfico de burbuja?**

No hay un límite estricto a nivel de API; las restricciones dependen del rendimiento y de la versión de PowerPoint objetivo. Se recomienda mantener un número razonable de puntos para una buena legibilidad y velocidad de renderizado.

**¿Cómo afecta la exportación a la apariencia de un gráfico de burbuja (PDF, imágenes)?**

La exportación a los formatos admitidos preserva la apariencia del gráfico; el renderizado lo realiza el motor de Aspose.Slides. Para formatos raster/vector, se aplican las reglas generales de renderizado de gráficos (resolución, anti‑aliasing), por lo que se debe elegir un DPI suficiente para la impresión.