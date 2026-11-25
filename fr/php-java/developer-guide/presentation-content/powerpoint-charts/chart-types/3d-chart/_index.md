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
description: "Créer des graphiques 3D dans les présentations PowerPoint avec Aspose.Slides for PHP via Java. Ajustez la rotation, les proportions de hauteur, la profondeur du graphique et l'espacement entre les séries avec des exemples PHP."
---
## **Aperçu**

Aspose.Slides for PHP via Java vous permet de personnaliser la vue d’un graphique 3D via la méthode [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). Cet article montre comment ajuster la rotation, les proportions de hauteur, la profondeur, les axes à angle droit et l’espacement entre les séries, puis enregistrer la présentation au format PPTX.

## **Définir la rotation et la profondeur d’un graphique 3D**

L’exemple ci‑dessous crée une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et utilise [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) pour ajouter un graphique à colonnes 3D empilées à sa première diapositive. Il remplace les séries et catégories par défaut par deux séries contenant trois valeurs chacune. L’index de la feuille de calcul `0` identifie la première feuille de données du graphique ; la ligne `0` contient les noms des séries, et la colonne `0` contient les libellés des catégories.

Les méthodes [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) et [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) définissent la rotation du graphique à 40 et 270 degrés respectivement. [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) fixe sa profondeur à 150 % de sa largeur, tandis que [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) active des axes à angle droit au lieu de la perspective. La présentation résultante contient le graphique rempli avec ces paramètres de vue 3D.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Appliquer un remplissage d’image à la surface d’un graphique 3D**

Vous pouvez remplir indépendamment le [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), le [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) et le [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) d’un graphique 3D. Définissez le [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) de la surface sur `Picture` et assignez une image. Définissez à la fois le [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) et le [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) de la surface sur `Stretch` pour étirer une copie de l’image sur toute la surface.

Enregistrez [arrow.png](arrow.png) à côté du script PHP. L’exemple fait pivoter le graphique et augmente la valeur maximale de l’axe vertical afin que le plancher soit visible entre les colonnes. Il clone ensuite la diapositive deux fois et applique la flèche à une surface différente sur chaque diapositive. Les trois graphiques conservent les mêmes données, le même angle de vue et le même arrière‑plan.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint affiche les trois diapositives comme suit.

| Mur latéral | Mur arrière | Plancher |
| --- | --- | --- |
| ![Flèche pointant vers le diagramme le long du mur latéral](side-wall.png) | ![Flèche pointant vers la droite à travers le mur arrière](back-wall.png) | ![Flèche pointant vers la droite à travers le plancher entre les colonnes](floor.png) |

## **Ajuster les proportions de hauteur d’un graphique 3D**

Utilisez [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) pour définir la hauteur d’un graphique 3D en pourcentage de sa largeur. Cela modifie les proportions de la scène 3D sans redimensionner l’objet graphique sur la diapositive.

L’exemple suivant crée un graphique [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) avec les données par défaut : trois séries et quatre catégories. Il enregistre trois présentations avec des proportions de hauteur de 50 %, 100 % et 200 %. La position, la largeur et la hauteur du graphique restent fixes. Les données, la rotation, la profondeur, l’espacement des séries et le formatage sont identiques dans les trois fichiers ; seule la hauteur en pourcentage change.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Les images suivantes illustrent les mêmes réglages de hauteur dans l’exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint. Un pourcentage plus petit produit une scène plus plate, tandis qu’un pourcentage plus grand produit une scène plus haute dans le même objet graphique. PowerPoint peut également ajuster les intervalles des graduations des axes et le placement des libellés pour s’adapter à la scène.

| Hauteur : 50 % | Hauteur : 100 % | Hauteur : 200 % |
| --- | --- | --- |
| ![Graphique à colonnes 3D avec hauteur fixée à 50 % de sa largeur](height_percent_50.png) | ![Graphique à colonnes 3D avec hauteur fixée à 100 % de sa largeur](height_percent_100.png) | ![Graphique à colonnes 3D avec hauteur fixée à 200 % de sa largeur](height_percent_200.png) |

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | Hauteur de la scène 3D en pourcentage de sa largeur. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | Hauteur de l’objet graphique sur la diapositive, en points. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Profondeur de la scène 3D en pourcentage de sa largeur. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du repère. |

Le réglage de hauteur affecte les graphiques à colonnes et à barres 3D, y compris les variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en lignes, aires, secteurs et surfaces. La comparaison ci‑dessus utilise le type vérifié `Column3D`. Ce réglage ne modifie pas l’apparence d’un graphique 2D `ClusteredColumn` ou d’un graphique `BubbleWith3D` ; ces noms sont des membres de la classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Pour d’autres paramètres d’apparence du graphique, consultez [Chart Formatting](/slides/fr/php-java/chart-formatting/).

## **Ajuster l’écart entre les séries**

Utilisez [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) pour contrôler la distance entre les séries de données le long de l’axe de profondeur d’un graphique 3D, exprimée en pourcentage de la largeur du repère. Utilisez des valeurs comprises entre **0 et 500**, incluses : `0` supprime l’écart, tandis que des valeurs plus élevées augmentent l’espacement. Avec une profondeur de graphique fixe, augmenter l’écart rend les repères plus fins le long de l’axe de profondeur.

Accédez au groupe via [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). Le réglage s’applique à chaque série de ce groupe, pas seulement à la série utilisée pour y accéder. [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) renvoie l’écart de profondeur et reflète le réglage du groupe parent.

Ce réglage affecte les graphiques à colonnes et à barres 3D, y compris leurs variantes cylindre, cône et pyramide, ainsi que les graphiques 3D en lignes et aires. L’apparence dépend de la disposition des séries en profondeur, en groupes ou empilées. Pour une comparaison claire des écarts entre différentes séries, utilisez `ChartType::Column3D` de la classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

Ces méthodes contrôlent différents aspects du graphique :

| Méthode | Effet |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | Espacement entre les séries le long de l’axe de profondeur, en pourcentage de la largeur du repère. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | Espacement entre les regroupements de barres ou de colonnes adjacents, en pourcentage de la largeur de la barre ou de la colonne. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | Profondeur globale du graphique, en pourcentage de la largeur du graphique. |

L’exemple autonome suivant utilise les données de graphique par défaut, qui contiennent trois séries et quatre catégories. Il enregistre deux présentations avec des données, une rotation, une largeur d’écart et une profondeur de graphique identiques ; seul l’écart de profondeur varie.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Les images suivantes illustrent les mêmes réglages d’écart de profondeur dans l’exemple .NET équivalent et ont été exportées avec Microsoft PowerPoint.

| Écart de profondeur : 0 % | Écart de profondeur : 500 % |
| --- | --- |
| ![Graphique à colonnes 3D sans aucun écart entre les séries le long de l’axe de profondeur](gap_depth_0.png) | ![Graphique à colonnes 3D avec un écart de 500 % entre les séries le long de l’axe de profondeur](gap_depth_500.png) |

## **Modifier le type de série 3D et la forme de la barre**

Dans un graphique à cylindres groupés, la première série commence avec une forme de barre cylindrique. L’exemple affiche les valeurs entières renvoyées par [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) et [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) avant et après chaque modification. Le tableau donne les noms de constantes correspondants.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Modification de la première série | Type de série | Forme de la barre |
| --- | --- | --- |
| Créer le graphique | `ClusteredCylinder` | `Cylinder` |
| Définir le type de série sur `ClusteredCone` | `ClusteredCone` | `Cone` |
| Définir la forme de la barre sur `Box` | `ClusteredColumn3D` | `Box` |

Définir la forme sur `Box` change également le type de série en `ClusteredColumn3D`. Si votre code conditionne sur le type de série, appelez [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) après avoir changé la forme. Une valeur mise en cache avant l’affectation sélectionnerait encore la branche `ClusteredCone`.

![Comparaison PowerPoint montrant la première série sous forme de cylindres, de cônes et de colonnes rectangulaires de gauche à droite](series-shapes.png)

## **FAQ**

**Quels types de graphiques prennent en charge le mode 3D dans Aspose.Slides ?**

Aspose.Slides prend en charge les variantes 3D des graphiques à colonnes, notamment Column 3D, Clustered Column 3D, Stacked Column 3D et 100 % Stacked Column 3D, ainsi que les types 3D associés exposés via la classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). Pour une liste exacte et à jour, consultez les membres de [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) dans la référence API de votre version installée.

**Puis-je obtenir une image raster d’un graphique 3D pour un rapport ou le web ?**

Oui. Vous pouvez exporter un graphique sous forme d’image avec [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) ou [rendre toute la diapositive](/slides/fr/php-java/convert-powerpoint-to-png/) vers des formats tels que PNG ou JPEG. Cela est utile lorsque vous avez besoin d’un aperçu raster ou que vous souhaitez intégrer le graphique dans des documents, tableaux de bord ou pages web sans nécessiter PowerPoint.

**Quelle est la performance de la création et du rendu de grands graphiques 3D ?**

Les performances dépendent du volume de données et de la complexité visuelle. Pour de meilleurs résultats, limitez les effets 3D, évitez les textures lourdes sur les murs et les zones de tracé, réduisez le nombre de points de données par série lorsque c’est possible, et rendez à une résolution et des dimensions appropriées à l’affichage ou à l’impression cible.