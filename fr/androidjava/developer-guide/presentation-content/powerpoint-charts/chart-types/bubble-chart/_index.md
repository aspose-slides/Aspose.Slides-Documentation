---
title: Graphique à Bulles
type: docs
url: /androidjava/bubble-chart/
---

## **Échelle de Taille du Graphique à Bulles**
Aspose.Slides pour Android via Java fournit un support pour l'échelle de taille des graphiques à bulles. Dans Aspose.Slides pour Android via Java, les méthodes [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) et [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) ont été ajoutées. Un exemple ci-dessous est donné.

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

## **Représenter les Données en tant que Tailles de Graphique à Bulles**
Les méthodes [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) et [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) ont été ajoutées aux interfaces [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesGroup) et aux classes connexes. **BubbleSizeRepresentation** spécifie comment les valeurs de taille des bulles sont représentées dans le graphique à bulles. Les valeurs possibles sont : [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) et [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). En conséquence, l'énumération [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BubbleSizeRepresentationType) a été ajoutée pour spécifier les façons possibles de représenter les données sous forme de tailles de graphique à bulles. Un exemple de code est donné ci-dessous.

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