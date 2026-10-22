---
title: Gérer les classeurs de graphiques dans les présentations avec PHP
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/php-java/chart-workbook/
keywords:
- classeur de graphique
- données de graphique
- cellule de classeur
- libellé de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- cache de graphique
- récupération de classeur
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez Aspose.Slides pour PHP via Java : gérez facilement les classeurs de graphiques aux formats PowerPoint et OpenDocument pour rationaliser les données de vos présentations."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire des données de graphique via des flux de classeur, utiliser les cellules du classeur comme libellés de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du graphique.

Il couvre également l’utilisation de classeurs externes comme sources de données pour les graphiques. Les exemples montrent comment créer et affecter un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules de classeur représentant des données manquantes, voir [Contrôler l'affichage des cellules vides](/slides/fr/php-java/chart-series/) pour la différence entre une cellule vide et zéro, ainsi qu’une comparaison en graphique linéaire des modes d’affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) pour contrôler si un graphique trace les données provenant de lignes et colonnes de feuille masquées. Réglez‑le sur `true` pour tracer uniquement les cellules visibles, ou sur `false` pour inclure à la fois les cellules visibles et masquées. Ce paramètre contrôle le traçage du graphique ; il ne masque ni n’affiche les lignes ou colonnes de la feuille.

La [sample presentation](hidden-source-data.pptx) contient un graphique en colonne comme première forme de sa première diapositive. La feuille de calcul intégrée, `Sheet1`, possède la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules contiennent toujours des valeurs.

| Ligne de feuille | A : Mois | B : Vente au détail | C : Vente en gros (colonne masquée) |
| --- | --- | --- | --- |
| 2 | janvier | 10 | 30 |
| 3 (ligne masquée) | février | 40 | 60 |
| 4 | mars | 20 | 50 |

Accédez aux cellules source via [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) et lisez [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) pour inspecter leur statut masqué. Cette méthode indique le statut masqué sans le modifier. Dans ce fichier, B2 est visible, B3 appartient à la ligne masquée et C2 appartient à la colonne masquée ; l’exemple affiche `false`, `true` et `true`, respectivement.

Pour cet exemple, rafraîchissez les données du graphique après avoir modifié le paramètre de traçage : conservez le classeur intégré avec [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) et rechargez‑le avec [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Lors de l’inclusion de toutes les cellules, utilisez également [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) pour restaurer la plage complète, incluant la catégorie février masquée. Modifier simplement le drapeau ne suffit pas à actualiser les données de graphique mises en cache et les libellés de catégorie de cet exemple.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Actualiser les données du graphique à partir du classeur intégré.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Restaurer la plage source complète, y compris les catégories masquées.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

L’exemple enregistre deux versions de la présentation : une avec uniquement les valeurs de vente au détail visibles (10 et 20) et une autre avec les six valeurs. Les images ci‑dessous illustrent les deux modes de traçage. La ligne 3 et la colonne C restent masquées dans les deux classeurs intégrés.

| Seulement les cellules visibles (`true`) | Toutes les cellules (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur diffère d’une cellule vide. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) contrôle la façon dont les valeurs manquantes sont affichées ; il n’inclut ni n’exclut les données sources masquées. Voir [Contrôler l'affichage des cellules vides](/slides/fr/php-java/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Récupérer la plage de données d'un graphique**

Avant de mettre à jour les données du classeur dans une présentation existante, inspectez les plages source afin d’identifier quelles cellules de feuille chaque graphique utilise. La méthode [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) renvoie la plage de données actuelle sous forme de formule qualifiée par la feuille, comme `Sheet1!$A$1:$D$5`. Ici, `Sheet1` est le nom de la feuille, `!` le sépare de la plage de cellules, et `$A$1:$D$5` identifie les cellules A1 à D5 incluses. Les signes dollar indiquent des références absolues de ligne et de colonne.

La méthode lit la plage actuelle sans modifier le graphique ni son classeur. Si le graphique n’utilise pas de classeur comme source de données, elle lève une exception. Pour plus d’informations, consultez la [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Cet exemple ouvre une présentation et parcourt les formes de chaque diapositive à la recherche de graphiques. Il affiche le nom de chaque graphique et sa plage source. Si un graphique n’utilise pas de classeur, il affiche un message et passe au graphique suivant.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Lire et écrire des données de graphique depuis un classeur**

Aspose.Slides for PHP via Java fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) et [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) qui permettent de lire et d’écrire les classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Note** : les données du graphique doivent être organisées de la même manière ou disposer d’une structure similaire à la source.

Cet exemple utilise une présentation avec un graphique comme première forme de sa première diapositive. Il lit le classeur intégré dans un tableau d’octets, supprime les séries et catégories existantes, puis réécrit le même classeur. Les modifications restent en mémoire ; l’exemple ne sauvegarde pas la présentation.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Valider la disposition du graphique après modification du classeur**

Lorsque vous remplacez un classeur intégré par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut provoquer l’échec de [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) avec une erreur « index out of range ». Supprimez les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique. Cet exemple utilise un graphique qui est la première forme de la première diapositive. Le commentaire indique où l’édition du classeur aurait lieu ; l’exemple exécutable réécrit le classeur original et valide la disposition en mémoire.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Modifier les octets du classeur ici, par exemple en utilisant Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Supprimer les collections élimine les références de données obsolètes avant que le classeur ne soit réécrit. Reconstruisez les mappages de séries et de catégories nécessaires pour le classeur mis à jour avant d’utiliser le graphique.

## **Définir des formats numériques personnalisés pour les cellules du classeur**

Utilisez [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) pour contrôler l’apparence des valeurs numériques dans le classeur intégré d’un graphique. Par exemple, un rapport peut nécessiter d’afficher un taux de conversion en pourcentage avec quatre décimales et un coefficient avec cinq décimales. Conservez les deux valeurs sous forme numérique afin qu’elles restent disponibles pour les calculs et le traçage du graphique.

Un format numérique modifie l’affichage, pas la valeur stockée. Le format `0.0000%` affiche `0.125` comme `12.5000%` ; il ne remplace pas le nombre stocké par `12.5`. De même, `0.00000` affiche `0.1234567` comme `0.12346` sans arrondir la valeur stockée. Si le format personnalisé est une chaîne vide (`""`), le format renvoyé par [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) est utilisé à la place.

L’exemple suivant crée un graphique en colonne et accède à ses cellules via [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). Sur la feuille 0, B2 contient le taux de conversion et C2 le coefficient. Les deux cellules alimentent les valeurs du graphique. L’exemple active également les libellés de valeur liés aux formats source.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Les formats de cellule du classeur sont distincts des formats appliqués directement aux axes du graphique ou aux libellés de données. Dans cet exemple, chaque libellé affiche la valeur de sa cellule source parce que [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) est réglé sur `true`, et suit le format numérique source parce que [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) est réglé sur `true`. Après avoir enregistré et rouvert la présentation, les libellés affichent `12.5000%` et `0.12346`, comme indiqué ci‑dessous. L’axe vertical utilise son propre format numérique, assigné avec [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) à `0.00`, avec [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) réglé sur `false`.

Pour formater un libellé de données de façon indépendante, désactivez son indicateur de liaison à la source (`false`) et assignez‑lui un format avec [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Cela ne modifie pas le format de la cellule du classeur. Par exemple, un format de libellé indépendant `0.00` affichera la première valeur comme `0.13`, tandis que B2 continuera d’afficher `12.5000%`. Voir [Chart Data Labels](/slides/fr/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) pour le formatage direct des libellés.

L’image ci‑dessous a été rendue à partir de la présentation enregistrée après sa réouverture :

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Utiliser une cellule du classeur comme libellé de données du graphique**

Vous pouvez utiliser le texte des cellules du classeur comme libellés de données du graphique.

Cet exemple ajoute un graphique à bulles avec des données par défaut à la première diapositive d’une présentation existante. Il utilise les cellules A10 : A12 de la feuille 0 pour les trois premiers libellés de la première série, active les libellés provenant des cellules et enregistre la présentation mise à jour.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gérer les feuilles de calcul**

La méthode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) fournit l’accès aux feuilles du classeur d’un graphique. Cet exemple crée un graphique circulaire avec des données par défaut et imprime chaque nom de feuille dans la console.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Spécifier le type de source de données**

Les valeurs des points de série peuvent également être stockées directement comme littéraux numériques. Voir [Set Series Values Using Numeric Literals](/slides/fr/php-java/chart-series/#set-series-values-using-numeric-literals) pour un exemple complet qui les enregistre et les lit. Le type de source des valeurs de points est indépendant de la configuration interne ou externe du classeur du graphique ; l’utilisation de littéraux numériques ne supprime pas, à elle seule, le classeur intégré.

Cet exemple crée un graphique en colonnes 3D avec des données par défaut et définit deux noms de séries en utilisant des sources de données différentes. Le premier nom utilise un littéral de chaîne ; le second utilise la cellule C1 de la feuille 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) sélectionne la source pour chaque nom. L’exemple enregistre la présentation avec les noms de séries mis à jour.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Détecter les formats de classeur intégrés non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être intégré dans certains graphiques. Vous pouvez utiliser la méthode `getEmbeddedWorkbookType` sur [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) avec l’énumération [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple inspecte les formes de la première diapositive d’une présentation existante, ignore les formes qui ne sont pas des graphiques et affiche un message de diagnostic pour chaque graphique contenant un classeur .xlsb intégré.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Lire ou modifier les données du classeur de graphique prises en charge ici.
    }
} finally {
    $presentation->dispose();
}
```

## **Classeur externe**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

Utilisez [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) et [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) pour exporter le classeur intégré d’un graphique vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique circulaire avec des données par défaut et exporte son classeur. L’écriture du fichier est terminée avant d’affecter le classeur externe comme source de données du graphique, puis la présentation liée est enregistrée.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Affecter un classeur externe**

En utilisant la méthode [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également servir à mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés sur des emplacements distants ou des ressources, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif est fourni, il est automatiquement converti en chemin complet.

Cet exemple utilise un classeur externe dont la feuille nommée `Sheet1` contient un nom de série en B1, des noms de catégories en A2 : A4 et des valeurs numériques en B2 : B4. L’exemple crée un graphique circulaire, lie le classeur et utilise [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) pour mapper A1 : B4 à une série et trois catégories. Il enregistre la présentation avec le graphique lié.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le paramètre `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) contrôle le chargement du classeur.

* Lorsque `updateChartData` est `false`, seul le chemin du classeur est mis à jour. Les données du graphique ne sont pas chargées ni mises à jour depuis le classeur cible, le classeur pouvant être indisponible.
* Lorsque `updateChartData` est `true`, les données du graphique sont mises à jour depuis le classeur cible.

L’exemple suivant affecte une URL factice avec `updateChartData` réglé sur `false`. Il conserve les données par défaut du graphique circulaire et enregistre la présentation sans charger le classeur indisponible.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Obtenir le chemin du classeur source de données externe d’un graphique**

Pour identifier le classeur lié à un graphique, vérifiez si le graphique utilise une source de données externe et récupérez son chemin de classeur.

Cet exemple inspecte la première forme de la première diapositive d’une présentation avec un classeur externe lié. Si c’est un graphique lié à un classeur externe, l’exemple affiche [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) dans la console. Il enregistre ensuite une copie de la présentation.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Modifier les données du graphique**

Vous pouvez modifier les données des classeurs externes de la même façon que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Cet exemple utilise un graphique qui est la première forme de la première diapositive et qui est lié à un classeur externe accessible. Il définit la valeur soutenue par la cellule du premier point de données de la première série à 100 et enregistre la présentation mise à jour. Modifier les valeurs des cellules peut mettre à jour le fichier XLSX externe lié, utilisez donc une copie si vous devez préserver le classeur d’origine.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Récupérer un classeur depuis le cache du graphique**

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez un [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), appelez [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) et réglez [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) sur `true` avant d’ouvrir la présentation.

L’exemple PHP suivant récupère les données du classeur pour un graphique qui est la première forme de la première diapositive et qui référence un classeur externe indisponible. Il accède aux données récupérées via [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) et [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) :

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Lire ou modifier les données du classeur récupéré ici.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. N’activez la récupération que lorsque l’utilisation des données mises en cache du graphique constitue une solution de repli acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis‑je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) et un [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vérifier qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, de sorte que le déplacement du classeur peut nécessiter la mise à jour du lien.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent servir de source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

La présentation stocke un [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Modifier les données de graphique basées sur des cellules peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors du lien. Une approche courante consiste à supprimer la protection au préalable ou à préparer une copie décryptée (par exemple avec [Aspose.Cells](https://reference.aspose.com/cells/java/)) et à la lier.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.