---
title: Gráfico de Burbuja
type: docs
url: /androidjava/bubble-chart/
---

## **Escalado del Tamaño del Gráfico de Burbuja**
Aspose.Slides para Android a través de Java proporciona soporte para el escalado del tamaño del gráfico de burbuja. En Aspose.Slides para Android a través de Java, se han añadido los métodos [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) y [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-). A continuación, se presenta un ejemplo de muestra.

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

## **Representar Datos como Tamaños del Gráfico de Burbuja**
Se han añadido los métodos [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) y [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) a las interfaces [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) y las clases relacionadas. **BubbleSizeRepresentation** especifica cómo se representan los valores del tamaño de las burbujas en el gráfico de burbuja. Los valores posibles son: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) y [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). En consecuencia, se ha añadido el enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) para especificar las posibles formas de representar datos como tamaños de gráfico de burbuja. El código de muestra se presenta a continuación.

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