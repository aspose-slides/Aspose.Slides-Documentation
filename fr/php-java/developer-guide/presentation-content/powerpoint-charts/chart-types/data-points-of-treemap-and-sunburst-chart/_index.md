---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst avec PHP
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graphique treemap
- graphique sunburst
- point de données
- couleur du libellé
- couleur de branche
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à gérer les points de données dans les graphiques treemap et sunburst avec Aspose.Slides pour PHP via Java, compatible avec les formats PowerPoint."
---

Parmi les autres types de graphiques PowerPoint, il existe deux types « hiérarchiques » – **Treemap** et **Sunburst** (également appelés Graphique Sunburst, Diagramme Sunburst, Graphique radial, Graphique radiale ou Diagramme circulaire à plusieurs niveaux). Ces graphiques affichent des données hiérarchiques organisées sous forme d’arbre – des feuilles jusqu’au sommet de la branche. Les feuilles sont définies par les points de données de la série, et chaque niveau de regroupement imbriqué suivant est défini par la catégorie correspondante. Aspose.Slides for PHP via Java permet de formater les points de données du graphique Sunburst et du Treemap.

Voici un graphique Sunburst, où les données de la colonne Series1 définissent les nœuds feuille, tandis que les autres colonnes définissent les points de données hiérarchiques :

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Commençons par ajouter un nouveau graphique Sunburst à la présentation :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="Voir aussi" %}} 
- [**Création d'un graphique Sunburst**](/slides/fr/php-java/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

S’il est nécessaire de formater les points de données du graphique, nous devons utiliser ce qui suit :

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager), [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) classes et la méthode [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPoint#getDataPointLevels--) permettent d’accéder au formatage des points de données des graphiques Treemap et Sunburst. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevelsManager) est utilisé pour accéder aux catégories à plusieurs niveaux – il représente le conteneur des objets [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel). En gros c’est un wrapper pour [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartCategoryLevelsManager) avec des propriétés ajoutées spécifiques aux points de données. La classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel) possède deux méthodes : [**getFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getFormat--) et [**getDataLabel**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataPointLevel#getLabel--) qui offrent l’accès aux paramètres correspondants.

## **Afficher la valeur d'un point de données**
Afficher la valeur du point de données « Leaf 4 » :
```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Définir le libellé et la couleur d'un point de données**
Définissez le libellé du point de données « Branch 1 » pour afficher le nom de la série (« Series1 ») au lieu du nom de catégorie. Puis définissez la couleur du texte en jaune :
```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Définir la couleur d’une branche de point de données**
Modifier la couleur de la branche « Steam 4 » :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Puis-je modifier l’ordre (tri) des segments dans Sunburst/Treemap ?**  
Non. PowerPoint trie les segments automatiquement (généralement par valeur décroissante, dans le sens des aiguilles d’une montre). Aspose.Slides reproduit ce comportement : vous ne pouvez pas modifier l’ordre directement ; vous devez le faire en prétraitant les données.

**Comment le thème de la présentation affecte-t-il les couleurs des segments et des libellés ?**  
Les couleurs du graphique héritent du [thème/palette](/slides/fr/php-java/presentation-theme/) de la présentation sauf si vous définissez explicitement les remplissages/polices. Pour des résultats cohérents, verrouillez les remplissages solides et le formatage du texte aux niveaux requis.

**L’exportation en PDF/PNG conservera-t-elle les couleurs personnalisées des branches et les paramètres des libellés ?**  
Oui. Lors de l’exportation de la présentation, les paramètres du graphique (remplissages, libellés) sont conservés dans les formats de sortie car Aspose.Slides rend le graphique avec le formatage appliqué.

**Puis-je calculer les coordonnées réelles d’un libellé/élément pour un placement personnalisé de superposition au-dessus du graphique ?**  
Oui. Après la validation de la mise en page du graphique, les coordonnées réelles *x* et *y* sont disponibles pour les éléments (par exemple, un [DataLabel](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/)), ce qui facilite le positionnement précis des superpositions.