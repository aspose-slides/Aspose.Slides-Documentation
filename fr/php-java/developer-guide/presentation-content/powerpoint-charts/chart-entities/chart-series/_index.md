---
title: Gérer les séries de données de graphique dans les présentations en PHP
linktitle: Séries de données
type: docs
url: /fr/php-java/chart-series/
keywords:
- séries de graphique
- chevauchement de séries
- couleur de série
- nom de série
- point de données
- cellule de classeur
- espacement de série
- valeur négative
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques, les points de données, les cellules de classeur, le formatage, le chevauchement, la largeur d'espacement et les valeurs négatives dans les présentations avec PHP."
---
## **Vue d'ensemble**

Un graphique peut stocker ses valeurs tracées dans des cellules du classeur ou directement sous forme de littéraux numériques. Un [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) représente un ensemble de valeurs liées, et chaque [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) représente un point de cette série. Les objets [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) fournissent les étiquettes ou les valeurs de regroupement partagées par les séries. Dans les graphiques créés avec des données par défaut, les noms de séries, les catégories et les valeurs des points utilisent des objets [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) du classeur du graphique.

Pour un graphique de catégorie typique, le classeur par défaut utilise la ligne 0 pour les noms des séries, la colonne 0 pour les noms des catégories, et les cellules restantes pour les valeurs des séries. Les index de feuille de calcul, de ligne et de colonne transmis à [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) sont basés sur zéro. Cette disposition est utile lorsque vous créez un graphique avec des données par défaut, mais ne supposez pas que chaque graphique existant l'utilise. Pour une présentation chargée, inspectez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du graphique ont trois portées différentes :

- Les paramètres au niveau de la série, comme [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), fournissent l'apparence par défaut pour tous les points d'une série.
- Les paramètres de point de données, comme [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), remplacent l'apparence de la série pour un point.
- Les paramètres de groupe s'appliquent aux séries compatibles qui appartiennent au même [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/). Accédez au groupe via [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) lorsque vous devez définir des options telles que le chevauchement ou la largeur d'espacement.

Lorsqu'aucun remplissage explicite de point ou de série n'est défini, le style et le thème du graphique déterminent l'apparence automatique. Lorsque les formats de série et de point sont tous deux présents, le format du point prime pour ce point.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir les valeurs de la série à l'aide de littéraux numériques**

Utilisez des littéraux numériques lorsque les valeurs de la série proviennent de données ou de calculs d'application et n'ont pas besoin de références aux cellules de la feuille de calcul. Appelez [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) avec [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) avant d'assigner le résultat de [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) de chaque point via [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Le paramètre de collection contrôle le type de source de toutes les valeurs de points de cette série. La méthode [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) de chaque valeur de point indique le type sélectionné ; modifiez-le via le paramètre de collection. Avec `Worksheet`, utilisez [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) pour accéder à la cellule référencée. Avec `DoubleLiterals`, utilisez [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) ou `setAsLiteralDouble` pour lire ou écrire le nombre directement.

L'exemple suivant crée un graphique à colonnes avec les séries et catégories par défaut, puis attribue les valeurs calculées 10, 20, etc. aux points existants de sa première série. Il enregistre la présentation, la rouvre et affiche les valeurs stockées.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Le type de source de la valeur du point est distinct de [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), qui identifie la configuration du classeur interne ou externe du graphique. Utiliser des littéraux numériques ne supprime pas, à lui seul, le classeur intégré. Dans cet exemple, le classeur reste disponible pour les libellés des catégories, les noms de séries et les autres séries. Voir [Chart Workbook](/slides/fr/php-java/chart-workbook/) pour la gestion du classeur.

Pour les graphiques en dispersion et à bulles, utilisez [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) et [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) pour choisir les sources de [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) et [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). Les graphiques à bulles utilisent également [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) pour [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Définissez chaque source applicable sur `DoubleLiterals` avant d'assigner des nombres via la méthode `setAsLiteralDouble` de cette valeur.

## **Définir le chevauchement des séries du graphique**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) indique le degré de chevauchement des barres ou des colonnes dans un graphique 2D, de -100 à 100 pour cent. C'est une projection en lecture seule du paramètre du groupe de séries parent. Utilisez [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) pour mettre à jour chaque série compatible de ce groupe. Cette option s'applique aux types de graphiques affichant des barres ou colonnes groupées ; elle n'affecte pas les groupes de séries non liés dans un graphique combiné.

L'exemple suivant définit le chevauchement pour le groupe contenant la première série :

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Le nouveau graphique contient des séries d'exemple, des catégories et des valeurs.
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

![The series overlap](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) pour définir le remplissage par défaut d'une série entière. Si un point a déjà un remplissage explicite, son paramètre [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) remplace le remplissage de la série pour ce point.

L'exemple suivant applique un remplissage bleu solide à la première série :

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

![The color of the series](series_color.png)

## **Modifier le nom de la série**

Le nom d'une série est stocké dans le classeur de données du graphique et apparaît généralement dans la légende. Dans le classeur par défaut créé pour un graphique à colonnes regroupées, la cellule B1 se situe à la ligne 0, colonne 1 et contient le nom de la première série. Les variables nommées dans l'exemple suivant rendent cette structure explicite :

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

Vous pouvez également mettre à jour la cellule déjà référencée par [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Cette approche évite de supposer une ligne ou une colonne particulière dans un graphique existant :

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

![The series name](series_name.png)

### **Créer une série avec un nom provenant de plusieurs cellules**

Un nom de série composite est utile lorsqu'un nom de produit et une période de rapport sont stockés dans des cellules distinctes du classeur. Par exemple, vous pouvez combiner `Product A` en B1 et `2026` en C1 en un seul nom de série tout en conservant les deux parties liées à leurs cellules sources.

Utilisez [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) pour récupérer la plage de noms, puis transmettez cette collection à [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Le paramètre `skipHiddenCells` contrôle l'inclusion des cellules cachées : `true` les exclut, `false` les inclut. Cet exemple utilise `false` pour inclure chaque cellule de la plage de noms.

L'exemple suivant crée une présentation avec une série et deux points de données. Les cellules B1:C1 fournissent uniquement le nom de la série ; A2:A3 fournissent les libellés des catégories, et B2:B3 fournissent les valeurs numériques.

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

    // Des cellules distinctes fournissent les catégories et les points de données numériques.
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

Le nom de série résultant est `Product A 2026`, avec un espace entre les deux valeurs de cellule. La légende l'affiche comme une seule entrée pour les deux colonnes. L'image ci‑dessous illustre le résultat :

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) renvoie la couleur calculée à partir de l'index de la série et du style du graphique. C'est la couleur utilisée lorsque le remplissage de la série n'est pas explicitement défini. L'appel de la méthode lit la couleur calculée ; il n'attribue pas de nouveau remplissage.

L'exemple suivant affiche la couleur automatique de chaque série par défaut :

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

Pour les séries de barres, de colonnes et de bulles, [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage de la série normale sur solide, activez l'inversion et attribuez la couleur de la valeur négative via [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Les nombres négatifs restent inchangés dans le classeur ; seul leur couleur d'affichage change.

L'exemple suivant remplace les données du graphique par défaut par une série. La ligne 0 de la feuille de calcul contient le nom de la série, la colonne 0 contient les noms des catégories, et la colonne 1 contient les valeurs :

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Vous pouvez activer l'inversion pour un point via [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Dans l'exemple suivant, l'inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l'effet soit visible :

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

## **Effacer la valeur d'un point de données spécifique**

Pour rendre un point vide sans supprimer les autres points, définissez sa cellule de classeur sous‑jacente sur `null`. Pour un graphique à colonnes, la valeur tracée est disponible via [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Le point de données reste à la même position de catégorie, mais le graphique considère sa valeur comme vide conformément aux paramètres de valeurs vides du graphique.

L'exemple suivant efface uniquement le deuxième point de la première série :

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

Les graphiques en dispersion utilisent des cellules X et Y séparées, et les graphiques à bulles utilisent également une cellule de taille. Effacez uniquement la cellule qui représente la valeur que vous souhaitez supprimer. N'appelez pas [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) lorsque vous voulez conserver les autres points, car cette méthode supprime chaque point de données de la collection.

## **Contrôler l'affichage des cellules vides**

Les cellules masquées contenant des valeurs constituent un cas distinct des cellules vides. Pour inclure ou exclure des données des lignes et colonnes masquées d'une feuille de calcul, consultez [Include Data from Hidden Rows and Columns](/slides/fr/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Une cellule de classeur vide représente des données manquantes ; une cellule contenant `0` représente une valeur numérique connue. Appelez [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) avec `null` pour rendre une cellule vide. Un zéro numérique reste un zéro quel que soit le paramètre de cellule vide.

Utilisez [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) pour choisir comment le graphique affiche les cellules vides. Ce paramètre s'applique à l'ensemble du graphique. Il modifie la façon dont les blancs sont tracés, sans remplir la cellule de classeur vide avec zéro ou une valeur interpolée.

L'exemple autonome suivant crée un graphique en courbes avec une série, efface la valeur du Jour 3 et enregistre le même graphique avec chaque mode. Aucun fichier d'entrée n'est requis. Le [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) utilise la feuille 0, la colonne 0 pour les libellés de catégorie, et la colonne 1 pour les valeurs ; la ligne 0 contient le nom de la série. Les données finales sont `10, 20, empty, 30, 40`.

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

Chaque fichier de sortie stocke le mode assigné avant l'enregistrement : `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` et `empty_cells_Span.pptx`. Pour enregistrer une seule version, attribuez le mode souhaité et enregistrez la présentation une fois au lieu d'itérer sur les modes.

La comparaison ci‑dessous montre les mêmes données dans les trois fichiers. Le Jour 3 est vide dans le classeur dans chaque cas :

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

L'effet visible dépend du type de graphique. Un graphique en courbes rend les trois modes faciles à comparer. Les graphiques à barres et à colonnes n'ont pas de ligne à connecter au travers d'une catégorie manquante, donc `Span` ne peut pas produire le segment de connexion illustré ci‑dessus ; une colonne manquante et une colonne de hauteur zéro peuvent également se ressembler. De même, un graphique en dispersion avec uniquement des marqueurs n'a pas de ligne de connexion. N'attendez pas trois résultats distincts pour chaque type de graphique ; vérifiez la sortie pour le type que vous utilisez.

## **Définir la largeur d'espacement des séries**

La largeur d'espacement est l'espace entre les clusters de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, elle appartient au groupe de séries parent plutôt qu'à une seule série. Appelez [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) une fois pour le groupe. Une valeur plus grande crée plus d'espace entre les clusters ; une valeur plus petite les rend plus denses.

L'exemple suivant modifie la largeur d'espacement et n'enregistre que la présentation finale :

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

![The gap width](gap_width.png)

## **FAQ**

**Quels types de graphiques prennent en charge les séries de données ?**

Toutes les types de graphiques représentés par l'énumération [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) utilisent des données de graphique, mais leurs séries n'ont pas toutes la même structure de valeurs ou les mêmes paramètres. Par exemple, les graphiques de catégorie utilisent des catégories et des valeurs, les graphiques en dispersion utilisent les valeurs X et Y, et les graphiques à bulles ajoutent les tailles de bulles. Utilisez la méthode de création de point de données qui correspond au type de série. Les options telles que le chevauchement et la largeur d'espacement ne s'appliquent qu'aux groupes de barres ou de colonnes compatibles.

**Qu'est‑ce qu'un groupe de séries de graphique ?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) contient des séries compatibles qui partagent des paramètres de tracé au niveau du groupe. Un graphique combiné peut contenir plusieurs groupes, de sorte que modifier le groupe atteint via une série ne modifie pas forcément toutes les séries du graphique.

**Un graphique nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) crée des séries, des catégories et des valeurs d'exemple. Vous pouvez modifier ces cellules ou vider les collections de séries et de catégories avant d'ajouter un jeu de données entièrement personnalisé. Une surcharge peut également créer un graphique sans données par défaut.

**Comment les objets de graphique sont‑ils reliés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données référencent des cellules d'un [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Modifier une cellule référencée met à jour l'élément de graphique correspondant. Lorsque vous créez des données personnalisées, maintenez les lignes de catégories et les lignes de valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point au lieu de toute la série ?**

Définissez la cellule de valeur concernée sur `null` pour conserver la position de catégorie du point comme point vide. Utilisez [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) uniquement lorsque vous souhaitez supprimer tous les points de cette série. Si vous supprimez également les catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de graphique et de la valeur configurée via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Les graphiques pris en charge peuvent afficher les blancs comme des espaces, comme des valeurs zéro, ou en connectant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation. Voir [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pour un exemple complet et une comparaison visuelle.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries de barres, de colonnes et de bulles prises en charge, appelez [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) et définissez la couleur renvoyée par [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Vous pouvez remplacer le comportement pour un point individuel avec [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel format l'emporte lorsqu'une série et un point sont tous deux formatés ?**

Le formatage explicite du point de données prime pour ce point. Les autres points continuent d'utiliser le format de série explicite ou, si le format de série n'est pas défini, le style et le thème automatiques du graphique. Les paramètres de groupe tels que le chevauchement et la largeur d'espacement contrôlent la disposition et ne sont pas des remplacements de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu'un graphique peut contenir ?**

Aspose.Slides n'impose pas de limite fixe séparée au nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du graphique déterminent une limite raisonnable.

**Que dois‑je modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Appelez [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l'espace entre les clusters, ou diminuez‑la pour rapprocher les clusters.