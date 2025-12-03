---
title: Personnaliser les zones de tracé des graphiques de présentation en Java
linktitle: Zone de tracé
type: docs
url: /fr/java/chart-plot-area/
keywords:
- graphique
- zone de tracé
- largeur de la zone de tracé
- hauteur de la zone de tracé
- taille de la zone de tracé
- mode de disposition
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment personnaliser les zones de tracé des graphiques dans les présentations PowerPoint avec Aspose.Slides pour Java. Améliorez facilement l'aspect visuel de vos diapositives."
---

## **Obtenir la largeur et la hauteur de la zone de tracé du graphique**
Aspose.Slides for Java fournit une API simple pour .  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Appelez la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) avant d'obtenir les valeurs réelles.
1. Obtient la position X réelle (gauche) de l'élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient le haut réel de l'élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur réelle de l'élément du graphique.
1. Obtient la hauteur réelle de l'élément du graphique.
```java
// Créer une instance de la classe Presentation
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


## **Définir le mode de disposition de la zone de tracé du graphique**
Aspose.Slides for Java fournit une API simple pour définir le mode de disposition de la zone de tracé du graphique. Les méthodes [**setLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) et [**getLayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) ont été ajoutées aux classes [**ChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/ChartPlotArea) et à l'interface [**IChartPlotArea**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartPlotArea). Si la disposition de la zone de tracé est définie manuellement, cette propriété indique si la zone de tracé doit être disposée par son intérieur (sans inclure les axes et les étiquettes d'axe) ou par son extérieur (en incluant les axes et les étiquettes d'axe). Il existe deux valeurs possibles définies dans l'énumération [**LayoutTargetType**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - spécifie que la taille de la zone de tracé déterminera la taille de la zone de tracé, sans inclure les marques de graduation et les étiquettes d'axe.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - spécifie que la taille de la zone de tracé déterminera la taille de la zone de tracé, les marques de graduation et les étiquettes d'axe.

Un exemple de code est fourni ci-dessous.
```java
// Créer une instance de la classe Presentation
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


## **FAQ**

**Dans quelles unités sont renvoyés les x réels, y réels, largeur réelle et hauteur réelle ?**

En points ; 1 pouce = 72 points. Ce sont les unités de coordonnées d'Aspose.Slides.

**En quoi la zone de tracé diffère-t-elle de la zone du graphique en termes de contenu ?**

La zone de tracé est la région de dessin des données (séries, lignes de grille, lignes de tendance, etc.) ; la zone du graphique comprend les éléments environnants (titre, légende, etc.). Dans les graphiques 3D, la zone de tracé inclut également les parois/plancher et les axes.

**Comment les x, y, largeur et hauteur de la zone de tracé sont-ils interprétés lorsque la disposition est manuelle ?**

Ils sont exprimés en fractions (0‑1) de la taille globale du graphique ; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de tracé a-t-elle changé après l'ajout ou le déplacement de la légende ?**

La légende se trouve dans la zone du graphique, en dehors de la zone de tracé, mais elle influence la disposition et l'espace disponible, de sorte que la zone de tracé peut se déplacer lorsque le positionnement automatique est actif. (C’est le comportement standard des graphiques PowerPoint.)