---
title: Tableau de Données du Graphique
type: docs
url: /fr/php-java/chart-data-table/
---

## **Définir les Propriétés de Police pour le Tableau de Données du Graphique**
Aspose.Slides pour PHP via Java fournit un support pour changer la couleur des catégories dans une série de couleurs.

1. Instancier un objet de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

 Un exemple d'échantillon est donné ci-dessous. 

```php
  # Création d'une présentation vide
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```