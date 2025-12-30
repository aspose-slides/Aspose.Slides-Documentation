---
title: Personnaliser les graphiques en anneau dans les présentations avec PHP
linktitle: Graphique en anneau
type: docs
weight: 30
url: /fr/php-java/doughnut-chart/
keywords:
- graphique en anneau
- écart central
- taille du trou
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des graphiques en anneau dans Aspose.Slides pour PHP via Java, prenant en charge les formats PowerPoint pour des présentations dynamiques."
---

## **Spécifier l'écart central dans un diagramme en anneau**
{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java prend désormais en charge la spécification de la taille du trou dans un diagramme en anneau. Dans ce sujet, nous verrons avec un exemple comment spécifier la taille du trou dans un diagramme en anneau.

{{% /alert %}} 

Pour spécifier la taille du trou dans un diagramme en anneau, suivez les étapes ci‑dessous :

1. Instancier l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Ajouter un diagramme en anneau sur la diapositive.
1. Spécifier la taille du trou dans un diagramme en anneau.
1. Enregistrer la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini la taille du trou dans un diagramme en anneau.
```php
  # Créez une instance de la classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Enregistrez la présentation sur le disque
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis‑je créer un diagramme en anneau à plusieurs niveaux avec plusieurs anneaux ?**

Oui. Ajoutez plusieurs séries à un seul diagramme en anneau — chaque série devient un anneau distinct. L'ordre des anneaux est déterminé par l'ordre des séries dans la collection.

**Un diagramme en anneau « explosé » (tranches séparées) est‑il pris en charge ?**

Oui. Il existe un type de diagramme Exploded Doughnut [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) et une propriété d'explosion sur les points de données ; vous pouvez séparer des tranches individuelles.

**Comment obtenir une image d'un diagramme en anneau (PNG/SVG) pour un rapport ?**

Un diagramme est une forme ; vous pouvez le rendre sous forme d'[image raster](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) ou exporter le diagramme vers une [image SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg).