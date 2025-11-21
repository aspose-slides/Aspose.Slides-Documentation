---
title: Zone de tracé du graphique
type: docs
url: /fr/nodejs-java/chart-plot-area/
---

## **Obtenir la largeur et la hauteur de la zone de tracé du graphique**

Aspose.Slides pour Node.js via Java fournit une API simple pour .  

1. Créer une instance de la classe[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter un graphique avec les données par défaut.
1. Appeler la méthode[Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) avant d’obtenir les valeurs réelles.
1. Obtient la position X réelle (gauche) de l’élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient le haut réel de l’élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur réelle de l’élément du graphique.
1. Obtient la hauteur réelle de l’élément du graphique.
```javascript
// Créez une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir le mode de disposition de la zone de tracé du graphique**

Aspose.Slides pour Node.js via Java fournit une API simple pour définir le mode de disposition de la zone de tracé du graphique. Les méthodes[**setLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) et[**getLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) ont été ajoutées à la classe[**ChartPlotArea**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea) et à la classe[**ChartPlotArea**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea). Si la disposition de la zone de tracé est définie manuellement, cette propriété indique s’il faut disposer la zone de tracé par son intérieur (sans inclure les axes et les libellés d’axes) ou par son extérieur (en incluant les axes et les libellés d’axes). Il existe deux valeurs possibles qui sont définies dans l’énumération[**LayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType) enum.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Inner) - indique que la taille de la zone de tracé détermine la taille de la zone de tracé, sans inclure les graduations et les libellés d’axes.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Outer) - indique que la taille de la zone de tracé détermine la taille de la zone de tracé, les graduations et les libellés d’axes.

Un exemple de code est fourni ci-dessous.
```javascript
// Créez une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Dans quelles unités sont retournés les X réels, Y réels, largeur réelle et hauteur réelle ?**

En points; 1 pouce = 72 points. Ce sont les unités de coordonnées d'Aspose.Slides.

**En quoi la zone de tracé diffère-t-elle de la zone du graphique en termes de contenu ?**

La zone de tracé est la région de tracé des données (séries, quadrillages, lignes de tendance, etc.); la zone du graphique comprend les éléments environnants (titre, légende, etc.). Dans les graphiques 3D, la zone de tracé inclut également les parois/plancher et les axes.

**Comment les X, Y, largeur et hauteur de la zone de tracé sont-ils interprétés lorsque la disposition est manuelle ?**

Ce sont des fractions (0-1) de la taille globale du graphique; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de tracé a-t-elle changé après l’ajout ou le déplacement de la légende ?**

La légende se situe dans la zone du graphique à l’extérieur de la zone de tracé mais influence la disposition et l’espace disponible, de sorte que la zone de tracé peut se déplacer lorsque le positionnement automatique est actif. (Ceci est le comportement standard des graphiques PowerPoint.)