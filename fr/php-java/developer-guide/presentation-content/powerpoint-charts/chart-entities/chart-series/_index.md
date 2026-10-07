---
title: Gestion des séries de données de graphiques dans les présentations en PHP
linktitle: Séries de données
type: docs
url: /fr/php-java/chart-series/
keywords:
- série de graphique
- chevauchement des séries
- couleur de série
- nom de série
- point de donnée
- cellule de classeur
- écart de série
- valeur négative
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques, les points de données, les cellules de classeur, le formatage, le chevauchement, la largeur d'écart et les valeurs négatives dans les présentations avec PHP."
---
## **Vue d'ensemble**

Un graphique stocke ses données tracées dans un classeur de données de graphique. Un [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) représente un ensemble de valeurs connexes, et chaque [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) de la série fait référence à une ou plusieurs cellules du classeur. Les objets [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) fournissent les libellés ou les valeurs de regroupement partagés par les séries. Le nom de la série, les catégories et les valeurs des points sont donc liés à des objets [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) plutôt que stockés uniquement comme texte affiché.

Pour un graphique à barres catégoriques typique, le classeur par défaut utilise la ligne 0 pour les noms des séries, la colonne 0 pour les noms des catégories, et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCell) sont basés sur zéro. Cette disposition est utile lorsque vous créez un graphique avec des données par défaut, mais ne supposez pas que chaque graphique existant l’utilise. Pour une présentation chargée, examinez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du graphique ont trois portées différentes :

- Paramètres au niveau de la série, tels que [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat), définissent l’apparence par défaut pour tous les points d’une série.
- Paramètres au niveau du point de données, tels que [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat), remplacent l’apparence de la série pour un point.
- Les paramètres de groupe s’appliquent aux séries compatibles appartenant au même [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/). Accédez au groupe via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) lorsque vous devez définir des options telles que le chevauchement ou la largeur de l’écart.

Lorsqu’aucun remplissage explicite de point ou de série n’est défini, le style et le thème du graphique déterminent l’apparence automatique. Lorsque les deux formats, série et point, sont présents, le format du point prend le pas pour ce point.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement de la série du graphique**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getOverlap) indique dans quelle mesure les barres ou colonnes se chevauchent dans un graphique 2D, de –100 à 100 %. C’est une projection en lecture seule du paramètre sur le groupe de séries parent. Utilisez [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) pour mettre à jour chaque série compatible de ce groupe. Cette option s’applique aux types de graphique affichant des barres ou colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un graphique combiné.

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

![Le chevauchement de la série](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat) pour définir le remplissage par défaut d’une série entière. Si un point possède déjà un remplissage explicite, son paramètre [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat) remplace le remplissage de la série pour ce point.

L’exemple suivant applique un remplissage bleu plein à la première série :

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

Le nom d’une série est stocké dans le classeur de données du graphique et est généralement affiché dans la légende. Dans le classeur par défaut créé pour un graphique à colonnes groupées, la cellule B1 se trouve à la ligne 0, colonne 1 et contient le nom de la première série. Les variables nommées dans l’exemple suivant rendent cette structure explicite :

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

Vous pouvez également mettre à jour la cellule déjà référencée par [ChartSeries.getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getName). Cette approche évite de supposer une ligne et une colonne particulières dans un graphique existant :

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

### **Créer une série avec un nom provenant de plusieurs cellules**

Un nom de série composite est utile lorsqu’un nom de produit et une période de reporting sont stockés dans des cellules distinctes du classeur. Par exemple, vous pouvez combiner `Product A` en B1 et `2026` en C1 en un seul nom de série tout en conservant les deux parties liées à leurs cellules sources.

Utilisez [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCellCollection) pour récupérer la plage de noms, puis transmettez cette collection à [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/#add). Le paramètre `skipHiddenCells` contrôle l’inclusion des cellules masquées : `true` les exclut, `false` les inclut. Cet exemple utilise `false` pour inclure chaque cellule de la plage de noms.

L’exemple suivant crée une présentation avec une série et deux points de données. Les cellules B1:C1 ne fournissent que le nom de la série ; A2:A3 fournissent les libellés de catégorie, et B2:B3 fournissent les valeurs numériques.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Ces deux cellules fournissent le nom de la série.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Des cellules séparées fournissent les catégories et les points de données numériques.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le nom de série résultant est `Product A 2026`, avec un espace entre les deux valeurs de cellules. La légende l’affiche comme une seule entrée pour les deux colonnes. L’image ci‑dessous illustre le résultat :

![Graphique à colonnes avec valeurs Nord et Sud et le nom de série composite Product A 2026 dans la légende](composite_series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) renvoie la couleur calculée à partir de l’index de la série et du style du graphique. C’est la couleur utilisée lorsque le remplissage de la série n’a pas été défini explicitement. L’appel de la méthode lit la couleur calculée ; il ne crée pas de nouveau remplissage.

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

## **Définir la couleur de remplissage inversée pour une série de graphique**

Pour les séries à barres, colonnes et bulles, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage de la série normale en plein, activez l’inversion, et affectez la couleur des valeurs négatives via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Les nombres négatifs restent inchangés dans le classeur ; seule leur couleur d’affichage change.

L’exemple suivant remplace les données de graphique par défaut par une série. La ligne 0 de la feuille contient le nom de la série, la colonne 0 les noms de catégorie, et la colonne 1 les valeurs :

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

![La couleur de remplissage plein inversé](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un point via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l’effet soit visible :

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

Pour rendre un point vide sans supprimer les autres points, définissez sa cellule de classeur sous‑jacent sur `null`. Pour un graphique à colonnes, la valeur tracée est disponible via [ChartDataPoint.getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getValue). Le point de données reste à la même position de catégorie, mais le graphique considère sa valeur comme vide selon les paramètres de valeurs vides du graphique.

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

Les graphiques en nuage utilisent des cellules X et Y séparées, et les graphiques à bulles utilisent également une cellule de taille. Effacez uniquement la cellule qui représente la valeur que vous souhaitez retirer. N’appellez pas [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) lorsque vous souhaitez conserver les autres points, car cette méthode supprime tous les points de la collection.

## **Contrôler l’affichage des cellules vides**

Les cellules masquées contenant des valeurs constituent un cas distinct des cellules vides. Pour inclure ou exclure des données provenant de lignes et colonnes de feuille masquées, consultez [Include Data from Hidden Rows and Columns](/slides/fr/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Une cellule de classeur vide représente des données manquantes ; une cellule contenant `0` représente une valeur numérique connue. Appelez [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) avec `null` pour rendre une cellule vide. Un zéro numérique reste un zéro quel que soit le paramètre de cellule vide.

Utilisez [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) pour choisir comment le graphique affiche les cellules vides. Ce paramètre s’applique à l’ensemble du graphique. Il change la manière dont les blancs sont tracés, sans remplir la cellule vide du classeur avec zéro ou une valeur interpolée.

L’exemple autonome suivant crée un graphique en courbes avec une série, efface la valeur du jour 3, et enregistre le même graphique avec chaque mode. Aucun fichier d’entrée n’est requis. Le [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) utilise la feuille 0, la colonne 0 pour les libellés de catégorie, et la colonne 1 pour les valeurs ; la ligne 0 contient le nom de la série. Les données finales sont `10, 20, empty, 30, 40`.

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

Chaque fichier de sortie stocke le mode assigné avant l’enregistrement : `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` et `empty_cells_Span.pptx`. Pour enregistrer une seule version, assignez le mode souhaité et enregistrez la présentation une fois au lieu d’itérer sur les modes.

La comparaison ci‑dessous montre les mêmes données dans les trois fichiers. Le jour 3 est vide dans le classeur dans chaque cas :

![Graphiques en lignes avec données identiques : Gap interrompt la ligne au jour 3, Zero fait tomber la ligne à zéro, et Span relie le jour 2 au jour 4.](display_blanks_as.png)

L’effet visible dépend du type de graphique. Un graphique en lignes rend les trois modes faciles à comparer. Les graphiques à barres et à colonnes n’ont pas de ligne à connecter à travers une catégorie manquante, de sorte que `Span` ne peut pas produire le segment de connexion montré ci‑dessus ; une colonne manquante et une colonne de hauteur zéro peuvent également se ressembler. De même, un graphique en nuage avec seulement des marqueurs n’a aucune ligne de connexion. N’attendez pas trois résultats distincts pour chaque type de graphique ; vérifiez la sortie pour le type que vous utilisez.

## **Définir la largeur de l’écart entre les séries**

La largeur de l’écart est l’espace entre les groupes de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, il appartient au groupe de séries parent plutôt qu’à une série individuelle. Appelez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) une fois pour le groupe. Une valeur plus grande crée plus d’espace entre les groupes ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur de l’écart et enregistre uniquement la présentation finale :

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

![La largeur de l’écart](gap_width.png)

## **FAQ**

**Quels types de graphiques prennent en charge les séries de données ?**

Tous les types de graphiques représentés par l’énumération [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) utilisent des données de graphique, mais leurs séries n’ont pas toutes la même structure de valeurs ou les mêmes paramètres. Par exemple, les graphiques à catégories utilisent des catégories et des valeurs, les graphiques en nuage utilisent des valeurs X et Y, et les graphiques à bulles ajoutent des tailles de bulle. Utilisez la méthode de création de points de données qui correspond au type de série. Les options telles que le chevauchement et la largeur de l’écart s’appliquent uniquement aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de graphique ?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) contient des séries compatibles qui partagent des paramètres de tracé au niveau du groupe. Un graphique combiné peut contenir plusieurs groupes, de sorte que la modification du groupe atteinte via une série ne modifie pas nécessairement toutes les séries du graphique.

**Un graphique nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) crée des séries, des catégories et des valeurs d’exemple. Vous pouvez modifier ces cellules ou vider les collections de séries et de catégories avant d’ajouter un jeu de données totalement personnalisé. Une surcharge peut également créer un graphique sans données par défaut.

**Comment les objets du graphique sont‑ils liés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données font référence à des cellules d’un [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Modifier une cellule référencée met à jour l’élément de graphique correspondant. Lorsque vous créez des données personnalisées, maintenez les lignes de catégories et les lignes de valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point sans supprimer toute la série ?**

Définissez la cellule de valeur concernée sur `null` pour conserver la position de catégorie du point en tant que point vide. Utilisez [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) uniquement lorsque vous avez l’intention de supprimer tous les points de cette série. Si vous supprimez également des catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de graphique et de la valeur configurée via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs). Les graphiques pris en charge peuvent afficher les blancs comme des écarts, comme des valeurs zéro, ou en reliant les points voisins. Choisissez le réglage qui correspond à la signification des données manquantes dans votre présentation. Consultez [Contrôler l’affichage des cellules vides](#control-the-display-of-empty-cells) pour un exemple complet et une comparaison visuelle.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries à barres, colonnes et bulles prises en charge, appelez [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) et définissez la couleur renvoyée par [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Vous pouvez remplacer le comportement pour un point individuel avec [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel format l’emporte lorsqu’une série et un point sont tous deux formatés ?**

Le formatage explicite du point de données prend le pas pour ce point. Les autres points continuent d’utiliser le format de série explicite ou, lorsque le format de série n’est pas défini, le style et le thème automatiques du graphique. Les paramètres de groupe tels que le chevauchement et la largeur de l’écart contrôlent la disposition et ne sont pas des remplacements de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu’un graphique peut contenir ?**

Aspose.Slides n’impose pas de limite fixe séparée au nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du graphique déterminent une limite raisonnable.

**Que faut‑il modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Appelez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les groupes, ou diminuez‑la pour rapprocher les groupes les uns des autres.