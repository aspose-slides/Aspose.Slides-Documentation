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
- mode de mise en page
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment personnaliser les zones de tracé des graphiques dans les présentations PowerPoint avec Aspose.Slides pour Java. Améliorez facilement l'aspect visuel de vos diapositives."
---

## **Obtenir la largeur et la hauteur d’une zone de traçage de graphique**
Aspose.Slides for Java fournit une API simple pour .

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) classe.
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec les données par défaut.
1. Appelez la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/IChart#validateChartLayout--) avant d’obtenir les valeurs réelles.
1. Obtient la position X réelle (gauche) de l’élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient le haut réel de l’élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur réelle de l’élément du graphique.
1. Obtient la hauteur réelle de l’élément du graphique.
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


## **Définir le mode de mise en page d’une zone de traçage de graphique**
Aspose.Slides for Java fournit une API simple pour définir le mode de mise en page de la zone de traçage du graphique. Les méthodes **setLayoutTargetType** et **getLayoutTargetType** ont été ajoutées à la classe **ChartPlotArea** et à l’interface **IChartPlotArea**. Si la mise en page de la zone de traçage est définie manuellement, cette propriété indique s’il faut mettre en page la zone de traçage par son intérieur (sans inclure les axes et les libellés d’axe) ou par son extérieur (en incluant les axes et les libellés d’axe). Deux valeurs possibles sont définies dans l’énumération **LayoutTargetType**.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Inner) - spécifie que la taille de la zone de traçage détermine la taille de la zone de traçage, sans inclure les marques de graduation et les libellés d’axe.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/java/com.aspose.slides/LayoutTargetType#Outer) - spécifie que la taille de la zone de traçage détermine la taille de la zone de traçage, les marques de graduation et les libellés d’axe.

Le code d’exemple est fourni ci‑dessous.
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


## **FAQ**

**Dans quelles unités sont retournés les x réels, y réels, largeur réelle et hauteur réelle ?**

En points ; 1 pouce = 72 points. Ce sont les unités de coordonnées d’Aspose.Slides.

**En quoi la zone de traçage diffère‑t‑elle de la zone de graphique en termes de contenu ?**

La zone de traçage est la région de dessin des données (séries, quadrillages, lignes de tendance, etc.) ; la zone de graphique comprend les éléments environnants (titre, légende, etc.). Dans les graphiques 3D, la zone de traçage comprend également les murs/plancher et les axes.

**Comment les x, y, largeur et hauteur de la zone de traçage sont‑ils interprétés lorsque la mise en page est manuelle ?**

Ils sont des fractions (0–1) de la taille globale du graphique ; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de traçage a‑t‑elle changé après l’ajout ou le déplacement de la légende ?**

La légende se trouve dans la zone de graphique à l’extérieur de la zone de traçage mais influence la mise en page et l’espace disponible, de sorte que la zone de traçage peut se déplacer lorsque le positionnement automatique est actif. (C’est le comportement standard des graphiques PowerPoint.)