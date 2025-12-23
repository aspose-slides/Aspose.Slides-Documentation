---
title: Gérer les marqueurs de données de graphique dans les présentations avec PHP
linktitle: Marqueur de données
type: docs
url: /fr/php-java/chart-data-marker/
keywords:
- graphique
- point de données
- marqueur
- options de marqueur
- taille du marqueur
- type de remplissage
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment personnaliser les marqueurs de données de graphique dans Aspose.Slides pour PHP, en renforçant l'impact des présentations aux formats PPT et PPTX avec des exemples de code clairs."
---

## **Définir les options de marqueur de graphique**
Les marqueurs peuvent être définis sur les points de données du graphique dans des séries particulières. Pour définir les options de marqueur de graphique, suivez les étapes ci‑dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Créer le graphique par défaut.
- Définir l’image.
- Sélectionner la première série du graphique.
- Ajouter un nouveau point de données.
- Enregistrer la présentation sur le disque.

Dans l’exemple ci‑dessous, nous avons défini les options de marqueur de graphique au niveau des points de données.
```php
  # Création d'une présentation vide
  # Accéder à la première diapositive
  # Création du graphique par défaut
  # Obtention de l'index de la feuille de calcul de données du graphique par défaut
  # Obtention de la feuille de calcul de données du graphique
  # Supprimer la série de démonstration
  # Ajouter une nouvelle série
  # Charger l'image 1
  # Charger l'image 2
  # Prendre la première série du graphique
  # Ajouter un nouveau point (1:3) ici.
  # Modification du marqueur de la série du graphique
  # Enregistrer la présentation avec le graphique
  $pres = new Presentation();
  try {
    # Access first slide
    $slide = $pres->getSlides()->get_Item(0);
    # Creating the default chart
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Getting the default chart data WorkSheet index
    $defaultWorksheetIndex = 0;
    # Getting the chart data WorkSheet
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Delete demo series
    $chart->getChartData()->getSeries()->clear();
    # Add new series
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Load the picture 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Load the picture 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Take first chart series
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Add new point (1:3) there.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Changing the chart series marker
    $series->getMarker()->setSize(15);
    # Save presentation with chart
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Quelles formes de marqueurs sont disponibles immédiatement ?**

Des formes standard sont disponibles (cercle, carré, losange, triangle, etc.) ; la liste est définie par la classe [MarkerStyleType](https://reference.aspose.com/slides/php-java/aspose.slides/markerstyletype/). Si vous avez besoin d’une forme non standard, utilisez un marqueur avec un remplissage d’image pour émuler des visuels personnalisés.

**Les marqueurs sont-ils conservés lors de l’exportation d’un graphique vers une image ou un SVG ?**

Oui. Lors du rendu des graphiques vers des [formats raster](/slides/fr/php-java/convert-powerpoint-to-png/) ou lors de l’enregistrement des [shapes as SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/), les marqueurs conservent leur apparence et leurs paramètres, y compris la taille, le remplissage et le contour.