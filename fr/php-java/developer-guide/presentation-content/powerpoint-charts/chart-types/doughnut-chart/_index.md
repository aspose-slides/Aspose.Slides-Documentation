---
title: Graphique en Anneau
type: docs
weight: 30
url: /fr/php-java/doughnut-chart/
---

## **Modifier l'Espace au Centre du Graphique en Anneau**
{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java prend désormais en charge la spécification de la taille du trou dans un graphique en anneau. Dans ce sujet, nous verrons avec un exemple comment spécifier la taille du trou dans un graphique en anneau.

{{% /alert %}} 

Pour spécifier la taille du trou dans un graphique en anneau, veuillez suivre les étapes ci-dessous :

1. Instancier l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. Ajouter un graphique en anneau sur la diapositive.
1. Spécifier la taille du trou dans un graphique en anneau.
1. Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini la taille du trou dans un graphique en anneau.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Écrire la présentation sur le disque
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```