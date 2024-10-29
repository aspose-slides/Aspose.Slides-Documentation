---
title: Zone de traçage du graphique
type: docs
url: /fr/androidjava/chart-plot-area/
---


## **Obtenir la largeur, la hauteur de la zone de traçage du graphique**
Aspose.Slides pour Android via Java fournit une API simple pour .

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) classe.
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Appelez la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) avant d'obtenir les valeurs réelles.
1. Obtenez la position X réelle (gauche) de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtenez le haut réel de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtenez la largeur réelle de l'élément graphique.
1. Obtenez la hauteur réelle de l'élément graphique.

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

## **Définir le mode de mise en page de la zone de traçage du graphique**
Aspose.Slides pour Android via Java fournit une API simple pour définir le mode de mise en page de la zone de traçage du graphique. Les méthodes [**setLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) et [**getLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) ont été ajoutées à la classe [**ChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea) et à l'interface [**IChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartPlotArea). Si la mise en page de la zone de traçage est définie manuellement, cette propriété spécifie si la zone de traçage doit être disposée selon son intérieur (n'incluant pas les axes et les étiquettes d'axe) ou à l'extérieur (y compris les axes et les étiquettes d'axe). Il existe deux valeurs possibles qui sont définies dans l'énumération [**LayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Inner) - spécifie que la taille de la zone de traçage doit déterminer la taille de la zone de traçage, sans inclure les marques de graduation et les étiquettes d'axe.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Outer) - spécifie que la taille de la zone de traçage doit déterminer la taille de la zone de traçage, les marques de graduation et les étiquettes d'axe.

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