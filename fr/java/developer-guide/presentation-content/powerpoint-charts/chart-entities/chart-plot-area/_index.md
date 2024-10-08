---
title: Zone de tracé du graphique
type: docs
url: /fr/java/chart-plot-area/
---

## **Obtenir la largeur, la hauteur de la zone de tracé du graphique**
Aspose.Slides pour Java offre une API simple pour.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Appelez la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) avant d'obtenir les valeurs réelles.
1. Obtient la position X réelle (gauche) de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtient le sommet réel de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur réelle de l'élément graphique.
1. Obtient la hauteur réelle de l'élément graphique.

```java
// Créez une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir le mode de mise en page de la zone de tracé du graphique**
Aspose.Slides pour Java fournit une API simple pour définir le mode de mise en page de la zone de tracé du graphique. Les méthodes [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) et [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) ont été ajoutées à la classe [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) et à l'interface [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea). Si la mise en page de la zone de tracé est définie manuellement, cette propriété spécifie s'il faut mettre en page la zone de tracé par l'intérieur (sans inclure les axes et les étiquettes d'axes) ou par l'extérieur (en incluant les axes et les étiquettes d'axes). Il existe deux valeurs possibles définies dans l'énumération [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - spécifie que la taille de la zone de tracé doit déterminer la taille de la zone de tracé, sans inclure les marques de graduation et les étiquettes d'axes.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - spécifie que la taille de la zone de tracé doit déterminer la taille de la zone de tracé, les marques de graduation et les étiquettes d'axes.

Un exemple de code est donné ci-dessous.

```java
// Créez une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```