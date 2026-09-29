---
title: Gérer les séries de données de graphique dans les présentations en PHP
linktitle: Séries de données
type: docs
url: /fr/php-java/chart-series/
keywords:
- série de graphique
- chevauchement de séries
- couleur de série
- nom de série
- point de données
- cellule de classeur
- écart de série
- valeur négative
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques, les points de données, les cellules de classeur, le formatage, le chevauchement, la largeur d’écart et les valeurs négatives dans les présentations avec PHP."
---
## **Vue d'ensemble**

Un graphique stocke ses données tracées dans un classeur de données de graphique. Un [ChartSeries](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/) représente un ensemble de valeurs liées, et chaque [ChartDataPoint](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/) de la série fait référence à une ou plusieurs cellules du classeur. Les objets [ChartCategory](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartcategory/) fournissent les libellés ou les valeurs de regroupement partagés par les séries. Le nom de la série, les catégories et les valeurs des points sont donc liés aux objets [ChartDataCell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/), plutôt que d’être stockés uniquement comme texte d’affichage.

Pour un graphique à catégories typique, le classeur par défaut utilise la ligne 0 pour les noms de séries, la colonne 0 pour les noms de catégories, et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/#getCell) sont basés sur zéro. Cette disposition est utile lorsque vous créez un graphique avec des données par défaut, mais ne supposez pas que chaque graphique existant l’utilise. Pour une présentation chargée, examinez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du graphique ont trois portées différentes :

- Paramètres au niveau de la série, tels que [ChartSeries.getFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#getFormat), fournissent l’apparence par défaut pour tous les points d’une série.
- Paramètres de point de données, tels que [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/#getFormat), remplacent l’apparence de la série pour un point.
- Les paramètres de groupe s’appliquent aux séries compatibles qui appartiennent au même [ChartSeriesGroup](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseriesgroup/). Accédez au groupe via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#getParentSeriesGroup) lorsque vous devez définir des options telles que le chevauchement ou la largeur d’écart.

Lorsqu’aucun remplissage explicite de point ou de série n’est défini, le style et le thème du graphique déterminent l’apparence automatique. Lorsque les formats de série et de point sont tous deux présents, le format du point a la priorité pour ce point.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries de graphique**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#getOverlap) indique le degré de chevauchement des barres ou des colonnes dans un graphique 2D, de -100 à 100 pour cent. C’est une projection en lecture seule du paramètre sur le groupe parent de séries. Utilisez [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseriesgroup/#setOverlap) pour mettre à jour toutes les séries compatibles de ce groupe. Cette option s’applique aux types de graphiques qui affichent des barres ou des colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un graphique combiné.

L’exemple suivant définit le chevauchement pour le groupe qui contient la première série :

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Le nouveau graphique contient des séries, des catégories et des valeurs d'exemple.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Le résultat :

![Le chevauchement des séries](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [ChartSeries.getFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#getFormat) pour définir le remplissage par défaut d’une série entière. Si un point possède déjà un remplissage explicite, son paramètre [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/#getFormat) remplace le remplissage de la série pour ce point.

L’exemple suivant applique un remplissage bleu uni à la première série :

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Le résultat :

![La couleur de la série](series_color.png)

## **Modifier le nom de la série**

Le nom d’une série est stocké dans le classeur de données du graphique et est normalement affiché dans la légende. Dans le classeur par défaut créé pour un histogramme groupé, la cellule B1 se trouve à la ligne 0, colonne 1 et contient le nom de la première série. Les variables nommées dans l’exemple suivant rendent cette structure explicite :

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Vous pouvez également mettre à jour la cellule déjà référencée par [ChartSeries.getName](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#getName). Cette approche évite de supposer une ligne ou une colonne particulière dans un graphique existant :

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Le résultat :

![Le nom de la série](series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) renvoie la couleur calculée à partir de l’indice de la série et du style du graphique. C’est la couleur utilisée lorsque le remplissage de la série n’a pas été explicitement défini. Appeler la méthode lit la couleur calculée ; elle n’affecte pas le remplissage.

L’exemple suivant affiche la couleur automatique de chaque série par défaut :

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Exemple de sortie pour le style de graphique par défaut :

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Les couleurs exactes dépendent du style et du thème du graphique.

## **Définir la couleur de remplissage inversé pour une série de graphique**

Pour les séries en barres, colonnes et bulles, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#setInvertIfNegative) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage normal de la série en solide, activez l’inversion et attribuez la couleur des valeurs négatives via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Les nombres négatifs restent inchangés dans le classeur ; seule leur couleur d’affichage change.

L’exemple suivant remplace les données de graphique par défaut par une seule série. La ligne 0 de la feuille contient le nom de la série, la colonne 0 contient les noms de catégorie, et la colonne 1 contient les valeurs :

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Le résultat :

![La couleur de remplissage solide inversé](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un point via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l’effet soit visible :

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Effacer la valeur d’un point de données spécifique**

Pour rendre un point vide sans supprimer les autres points, définissez la cellule du classeur sous-jacente sur `null`. Pour un histogramme, la valeur tracée est accessible via [ChartDataPoint.getValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/#getValue). Le point de données reste à la même position de catégorie, mais le graphique traite sa valeur comme vide selon les paramètres de valeurs vides du graphique.

L’exemple suivant efface uniquement le deuxième point de la première série :

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Les graphiques en nuage utilisent des cellules X et Y séparées, et les graphiques à bulles utilisent également une cellule de taille. Effacez uniquement la cellule qui représente la valeur que vous souhaitez supprimer. N’appellez pas [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapointcollection/#clear) lorsque vous voulez conserver les autres points, car cette méthode supprime tous les points de données de la collection.

## **Contrôler l’affichage des cellules vides**

Les cellules masquées contenant des valeurs constituent un cas distinct des cellules vides. Pour inclure ou exclure des données des lignes et colonnes de feuille masquées, consultez [Include Data from Hidden Rows and Columns](/slides/fr/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Une cellule de classeur vide représente des données manquantes ; une cellule contenant `0` représente une valeur numérique connue. Appelez [ChartDataCell::setValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/#setValue) avec `null` pour rendre une cellule vide. Un zéro numérique reste zéro quel que soit le paramètre des cellules vides.

Utilisez [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/#setDisplayBlanksAs) pour choisir comment le graphique affiche les cellules vides. Ce paramètre s’applique à tout le graphique. Il modifie la façon dont les vides sont tracés, sans remplir la cellule de classeur vide avec zéro ou une valeur interpolée.

L’exemple autonome suivant crée un graphique en ligne avec une série, efface la valeur du jour 3, et enregistre le même graphique avec chaque mode. Aucun fichier d’entrée n’est requis. Le [ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/) utilise la feuille 0, la colonne 0 pour les libellés de catégorie, et la colonne 1 pour les valeurs ; la ligne 0 contient le nom de la série. Les données finales sont `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Laisser le jour 3 réellement vide, tout en conservant sa catégorie et son point de données.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Chaque fichier de sortie stocke le mode attribué avant l’enregistrement : `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` et `empty_cells_Span.pptx`. Pour enregistrer une seule version, attribuez le mode souhaité et enregistrez la présentation une fois plutôt que d’itérer sur les modes.

La comparaison ci‑dessous montre les mêmes données dans les trois fichiers. Le jour 3 est vide dans le classeur dans tous les cas :

![Graphiques en ligne avec données identiques : Gap interrompt la ligne au jour 3, Zero fait chuter la ligne à zéro, et Span relie le jour 2 au jour 4.](display_blanks_as.png)

L’effet visible dépend du type de graphique. Un graphique en ligne facilite la comparaison des trois modes. Les graphiques en barres et en colonnes n’ont pas de ligne à connecter à travers une catégorie manquante, de sorte que `Span` ne peut pas produire le segment de connexion illustré ci‑dessus ; une colonne manquante et une colonne de hauteur zéro peuvent également se ressembler. De même, un nuage de points avec uniquement des marqueurs n’a pas de ligne de connexion. N’attendez pas trois résultats distincts pour chaque type de graphique ; vérifiez le résultat pour le type que vous utilisez.

## **Définir la largeur d’écart de la série**

La largeur d’écart est l’espace entre les groupes de barres ou colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, elle appartient au groupe parent de séries plutôt qu’à une seule série. Appelez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseriesgroup/#setGapWidth) une fois pour le groupe. Une valeur plus grande crée davantage d’espace entre les groupes ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur d’écart et n’enregistre que la présentation finale :

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Le résultat :

![La largeur d’écart](gap_width.png)

## **FAQ**

**Quels types de graphiques prennent en charge les séries de données ?**

Tous les types de graphiques représentés par l’énumération [ChartType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/) utilisent des données de graphique, mais leurs séries n’ont pas toutes la même structure de valeurs ni les mêmes paramètres. Par exemple, les graphiques à catégories utilisent des catégories et des valeurs, les graphiques en nuage utilisent des valeurs X et Y, et les graphiques à bulles ajoutent des tailles de bulles. Utilisez la méthode de création de point de données qui correspond au type de série. Les options telles que le chevauchement et la largeur d’écart s’appliquent uniquement aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de graphique ?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseriesgroup/) contient des séries compatibles qui partagent des paramètres de tracé au niveau du groupe. Un graphique combiné peut contenir plusieurs groupes, de sorte que la modification du groupe atteint via une série ne change pas forcément toutes les séries du graphique.

**Un graphique nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [ShapeCollection.addChart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/#addChart) crée des séries, catégories et valeurs d’exemple. Vous pouvez modifier ces cellules ou vider les collections de séries et de catégories avant d’ajouter un jeu de données totalement personnalisé. Une surcharge peut également créer un graphique sans données par défaut.

**Comment les objets de graphique sont‑ils connectés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données référencent des cellules d’un [ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/). Modifier une cellule référencée met à jour l’élément de graphique correspondant. Lorsque vous créez des données personnalisées, maintenez les lignes de catégories et les lignes de valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point sans supprimer toute la série ?**

Définissez la cellule de valeur concernée sur `null` pour conserver la position de catégorie du point comme point vide. Utilisez [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapointcollection/#clear) uniquement lorsque vous avez l’intention de supprimer tous les points de cette série. Si vous supprimez également des catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de graphique et de la valeur configurée via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/#setDisplayBlanksAs). Les graphiques pris en charge peuvent afficher les vides sous forme d’écarts, de valeurs zéro ou en connectant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation. Consultez [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pour un exemple complet et une comparaison visuelle.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries en barres, colonnes et bulles prises en charge, appelez [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#setInvertIfNegative) et définissez la couleur renvoyée par [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Vous pouvez remplacer le comportement pour un point individuel avec [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel format l’emporte lorsque la série et le point sont tous deux formatés ?**

Le formatage explicite du point de données a la priorité pour ce point. Les autres points continuent d’utiliser le format de série explicite ou, si le format de série n’est pas défini, le style et le thème automatiques du graphique. Les paramètres de groupe tels que le chevauchement et la largeur d’écart contrôlent la mise en page et ne constituent pas des surcharges de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu’un graphique peut contenir ?**

Aspose.Slides n’impose pas de limite fixe séparée au nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du graphique déterminent une limite raisonnable.

**Que faut‑il modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Appelez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartseriesgroup/#setGapWidth) sur le groupe parent de séries approprié. Augmentez la valeur pour élargir l’espace entre les groupes, ou diminuez‑la pour rapprocher les groupes.