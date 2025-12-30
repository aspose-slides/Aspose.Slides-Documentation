---
title: Personnaliser les graphiques 3D dans les présentations avec PHP
linktitle: Graphique 3D
type: docs
url: /fr/php-java/3d-chart/
keywords:
- graphique 3D
- rotation
- profondeur
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à créer et à personnaliser des graphiques 3D dans Aspose.Slides pour PHP via Java, avec prise en charge des fichiers PPT et PPTX — améliorez vos présentations dès aujourd'hui."
---

## **Définir les propriétés RotationX, RotationY et DepthPercents d'un graphique 3D**
Aspose.Slides for PHP via Java fournit une API simple pour définir ces propriétés. L’article suivant vous aidera à définir différentes propriétés telles que **X,Y Rotation, DepthPercents** etc. Le code d’exemple applique la définition des propriétés susmentionnées.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Accéder à la première diapositive.
3. Ajouter un graphique avec des données par défaut.
4. Définir les propriétés Rotation3D.
5. Enregistrer la présentation modifiée dans un fichier PPTX.
```php
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter un graphique avec les données par défaut
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Définir l'index de la feuille de données du graphique
    $defaultWorksheetIndex = 0;
    # Récupérer la feuille de données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Ajouter des séries
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Ajouter des catégories
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Définir les propriétés Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Prendre la deuxième série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Maintenant remplissage des données de la série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Définir la valeur Overlap
    $series->getParentSeriesGroup()->setOverlap(100);
    # Enregistrer la présentation sur le disque
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100% Stacked Column 3D, ainsi que les types 3D associés exposés via la classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image raster d’un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique vers une image via l’[API du graphique](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) ou [rendre toute la diapositive](/slides/fr/php-java/convert-powerpoint-to-png/) vers des formats comme PNG ou JPEG. Ceci est utile lorsque vous avez besoin d’un aperçu pixel‑par‑pixel ou souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages Web sans nécessiter PowerPoint.

**Quelle est la performance lors de la création et du rendu de grands graphiques 3D ?**

La performance dépend du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque cela est possible, et rendez la sortie à une taille appropriée (résolution et dimensions) correspondant à l’affichage ou aux besoins d’impression cibles.