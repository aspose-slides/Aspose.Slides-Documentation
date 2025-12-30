---
title: Personnaliser les zones de tracé des graphiques de présentation en PHP
linktitle: Zone de tracé
type: docs
url: /fr/php-java/chart-plot-area/
keywords:
- graphique
- zone de tracé
- largeur de la zone de tracé
- hauteur de la zone de tracé
- taille de la zone de tracé
- mode de disposition
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment personnaliser les zones de tracé des graphiques dans les présentations PowerPoint avec Aspose.Slides for PHP via Java. Améliorez facilement l'apparence de vos diapositives."
---

## **Obtenir la largeur et la hauteur d’une zone de tracé de graphique**
Aspose.Slides for PHP via Java fournit une API simple pour .  

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter un graphique avec les données par défaut.
1. Appeler la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) avant de récupérer les valeurs réelles.
1. Obtient la position X réelle (gauche) de l’élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient le haut réel de l’élément du graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur réelle de l’élément du graphique.
1. Obtient la hauteur réelle de l’élément du graphique.
```php
  # Créez une instance de la classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir le mode de disposition d’une zone de tracé de graphique**
Aspose.Slides for PHP via Java fournit une API simple pour définir le mode de disposition de la zone de tracé du graphique. Les méthodes [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) et [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) ont été ajoutées aux classes [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) et à l’interface [**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea). Si la disposition de la zone de tracé est définie manuellement, cette propriété indique si la zone de tracé doit être disposée par son intérieur (sans les axes et les étiquettes d’axes) ou par son extérieur (avec les axes et les étiquettes d’axes). Il existe deux valeurs possibles définies dans l’énumération [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType) :

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - indique que la taille de la zone de tracé détermine la taille de la zone de tracé, sans inclure les marques de graduation et les étiquettes d’axes.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - indique que la taille de la zone de tracé détermine la taille de la zone de tracé, les marques de graduation et les étiquettes d’axes.

Le code d’exemple est fourni ci‑dessous.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Dans quelles unités sont renvoyés les x réels, y réels, la largeur réelle et la hauteur réelle ?**

En points ; 1 pouce = 72 points. Ce sont les unités de coordonnées d’Aspose.Slides.

**En quoi la zone de tracé diffère‑t‑elle de la zone du graphique en termes de contenu ?**

La zone de tracé est la région de dessin des données (séries, quadrillages, lignes de tendance, etc.) ; la zone du graphique comprend les éléments environnants (titre, légende, etc.). Dans les graphiques 3D, la zone de tracé comprend également les murs/plancher et les axes.

**Comment les x, y, largeur et hauteur de la zone de tracé sont‑ils interprétés lorsque la disposition est manuelle ?**

Ils sont exprimés en fractions (0–1) de la taille globale du graphique ; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de tracé a‑t‑elle changé après l’ajout/le déplacement de la légende ?**

La légende se situe dans la zone du graphique en dehors de la zone de tracé mais influence la disposition et l’espace disponible, de sorte que la zone de tracé peut se déplacer lorsque le positionnement automatique est actif. (C’est le comportement standard des graphiques PowerPoint.)