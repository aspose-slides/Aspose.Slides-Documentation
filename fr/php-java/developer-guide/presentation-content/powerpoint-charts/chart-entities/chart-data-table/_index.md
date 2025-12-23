---
title: Personnaliser les tableaux de données des graphiques dans les présentations avec PHP
linktitle: Table de données
type: docs
url: /fr/php-java/chart-data-table/
keywords:
- données du graphique
- table de données
- propriétés de police
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Personnalisez les tableaux de données des graphiques pour PPT et PPTX avec Aspose.Slides pour PHP via Java afin d'améliorer l'efficacité et l'attrait des présentations."
---

## **Définir les propriétés de police pour le tableau de données d'un graphique**
Aspose.Slides pour PHP via Java offre la prise en charge de la modification de la couleur des catégories dans une couleur de série.  

1. Instancier l'objet de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

L'exemple ci-dessous est fourni.  
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


## **FAQ**

**Puis-je afficher de petites clés de légende à côté des valeurs dans le tableau de données du graphique ?**

Oui. Le tableau de données prend en charge les [clés de légende](https://reference.aspose.com/slides/php-java/aspose.slides/datatable/setshowlegendkey/), et vous pouvez les activer ou les désactiver.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation en PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique comme partie de la diapositive, ainsi l'[PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/php-java/convert-powerpoint-to-html/)/[image](/slides/fr/php-java/convert-powerpoint-to-png/) exporté inclut le graphique avec son tableau de données.

**Les tableaux de données sont-ils pris en charge pour les graphiques provenant d'un fichier de modèle ?**

Oui. Pour tout graphique chargé depuis une présentation ou un modèle existant, vous pouvez vérifier et modifier si un tableau de données [est affiché](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/) à l'aide des propriétés du graphique.

**Comment puis‑je rapidement identifier quels graphiques d'un fichier ont le tableau de données activé ?**

Inspectez la propriété de chaque graphique indiquant si le tableau de données [est affiché](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/) et parcourez les diapositives pour identifier les graphiques où il est activé.