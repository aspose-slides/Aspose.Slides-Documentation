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
- libellé de donnée
- feuille de calcul
- source de données
- classeur externe
- données externes
- cache du graphique
- récupération du classeur
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez Aspose.Slides pour PHP via Java: gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire les données de graphique via des flux de classeur, utiliser les cellules du classeur comme libellés de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs du graphique.

Il couvre également le travail avec des classeurs externes comme sources de données de graphique. Les exemples démontrent comment créer et affecter un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique, et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules du classeur représentant des données manquantes, voir [Contrôler l'affichage des cellules vides](/slides/fr/php-java/chart-series/) pour la différence entre une cellule vide et zéro, ainsi qu’une comparaison en graphique linéaire des différents modes d’affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/setplotvisiblecellsonly/) pour contrôler si un graphique trace les données provenant de lignes et colonnes masquées de la feuille de calcul. Définissez‑le sur `true` pour tracer uniquement les cellules visibles, ou sur `false` pour inclure à la fois les cellules visibles et masquées. Ce paramètre contrôle le tracé du graphique ; il ne masque ni n’affiche les lignes ou colonnes de la feuille de calcul.

Téléchargez [hidden-source-data.pptx](hidden-source-data.pptx) et placez‑le dans le répertoire de travail. Sa première diapositive contient un graphique à colonnes comme première forme. La feuille de calcul intégrée, `Sheet1`, contient la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules contiennent toujours des valeurs.

| Ligne de feuille | A : Mois | B : Retail | C : Wholesale (colonne masquée) |
| --- | --- | --- | --- |
| 2 | Janvier | 10 | 30 |
| 3 (ligne masquée) | Février | 40 | 60 |
| 4 | Mars | 20 | 50 |

Accédez aux cellules source via [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/getchartdataworkbook/) et lisez [ChartDataCell::isHidden](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdatacell/ishidden/) pour inspecter leur statut masqué. Cette méthode indique le statut masqué sans le modifier. Dans ce fichier, B2 est visible, B3 appartient à la ligne masquée, et C2 appartient à la colonne masquée ; l’exemple affiche `false`, `true` et `true` respectivement.

Pour cet exemple, rafraîchissez les données du graphique après avoir modifié le paramètre de tracé : conservez le classeur intégré avec [readWorkbookStream](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/readworkbookstream/) et rechargez‑le avec [writeWorkbookStream](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/writeworkbookstream/). Lors de l’inclusion de toutes les cellules, utilisez également [setRange](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/setrange/) pour restaurer la plage complète, y compris la catégorie février masquée. Modifier simplement le drapeau n’est pas suffisant pour actualiser les données et les libellés de catégorie mis en cache dans cet exemple.

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
                // Rétablir la plage source complète, y compris les catégories masquées.
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

L’exemple enregistre `hidden_cells_true.pptx` avec uniquement les valeurs Retail visibles (10 et 20), et `hidden_cells_false.pptx` avec les six valeurs. Les images ci‑dessous illustrent les deux modes de tracé. La ligne 3 et la colonne C restent masquées dans les deux classeurs intégrés.

| Seulement les cellules visibles (`true`) | Toutes les cellules (`false`) |
| --- | --- |
| ![Cellules visibles uniquement : valeurs Retail 10 et 20 pour janvier et mars.](hidden_cells_True.png) | ![Toutes les cellules : valeurs Retail et Wholesale pour janvier, février et mars.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur est différente d’une cellule vide. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/setdisplayblanksas/) contrôle la façon dont les valeurs manquantes sont affichées ; il n’inclut pas et n’exclut pas les données sources masquées. Voir [Contrôler l'affichage des cellules vides](/slides/fr/php-java/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Lire et écrire des données de graphique depuis un classeur**

Aspose.Slides for PHP via Java fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/readworkbookstream/) et [writeWorkbookStream](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/writeworkbookstream/) qui permettent de lire et d’écrire les classeurs de données de graphiques (contenant des données de graphique modifiées avec Aspose.Cells). **Remarque** : les données du graphique doivent être organisées de la même manière ou disposer d’une structure similaire à la source.

Cet exemple ouvre `chart.pptx`, qui doit contenir un graphique comme première forme de sa première diapositive. Il lit le classeur intégré dans un tableau d’octets, supprime les séries et catégories existantes, puis réécrit le même classeur. Les modifications restent en mémoire ; l’exemple ne sauve pas la présentation.

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

Lorsque vous remplacez un classeur intégré par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut entraîner l’échec de [Chart::validateChartLayout](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/validatechartlayout/) avec une erreur d’indice hors limites. Supprimez les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique. Cet exemple nécessite `chart.pptx` avec un graphique comme première forme de sa première diapositive. Le commentaire indique où l’édition du classeur aurait lieu ; l’exemple exécutable réécrit le classeur original et valide la disposition en mémoire.

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

Supprimer les collections élimine les références de données obsolètes avant que le classeur ne soit réécrit. Reconstituez les mappages de séries et de catégories nécessaires pour le classeur mis à jour avant d’utiliser le graphique.

## **Définir une cellule de classeur comme libellé de données du graphique**

Vous pouvez utiliser le texte des cellules de classeur comme libellés de données du graphique. Les étapes suivantes montrent comment lier les libellés d’un graphique à bulles aux cellules de son classeur de données.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Accédez à la première diapositive par son indice zéro‑based.
1. Ajoutez un graphique à bulles avec des données par défaut.
1. Accédez aux séries du graphique.
1. Définissez la cellule du classeur comme libellé de données.
1. Enregistrez la présentation.

Cet exemple ouvre `chart2.pptx`, qui doit contenir au moins une diapositive, et ajoute un graphique à bulles avec des données par défaut. Il utilise les cellules A10 :A12 de la feuille 0 pour les trois premiers libellés de la première série, active les libellés provenant des cellules, et enregistre le résultat dans `resultchart.pptx`.

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

La méthode [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/getworksheets/) fournit l’accès aux feuilles de calcul d’un classeur de graphique. Cet exemple crée un graphique circulaire avec des données par défaut et imprime chaque nom de feuille de calcul dans la console.

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

Cet exemple crée un graphique à colonnes 3D avec des données par défaut et définit deux noms de séries en utilisant des sources de données différentes. Le premier nom utilise un littéral de chaîne ; le second utilise la cellule C1 de la feuille 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/datasourcetype/) sélectionne la source pour chaque nom. Le résultat est enregistré dans `pres.pptx`.

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

## **Détecter les formats de classeur intégré non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être intégré dans certains graphiques. Vous pouvez utiliser la méthode `getEmbeddedWorkbookType` sur [ChartData](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple inspecte les formes de la première diapositive de `sample.pptx`, ignore les formes qui ne sont pas des graphiques, et affiche un message de diagnostic pour chaque graphique contenant un classeur .xlsb intégré.

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

Utilisez [readWorkbookStream](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/readworkbookstream/) et [setExternalWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/setexternalworkbook/) pour exporter un classeur de graphique intégré vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique circulaire avec des données par défaut, écrit son classeur dans `externalWorkbook1.xlsx`, et termine l’écriture du fichier avant d’affecter le fichier comme source de données du graphique. Il enregistre la présentation liée dans `externalWorkbook.pptx`.

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

En utilisant la méthode [setExternalWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/setexternalworkbook/), vous pouvez assigner un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés à distance ou dans des ressources, vous pouvez toujours les utiliser comme source de données externe. Si le chemin relatif d’un classeur externe est fourni, il est automatiquement converti en chemin complet.

Cet exemple nécessite `externalWorkbook.xlsx` dans le répertoire de travail. Sa feuille de calcul nommée `Sheet1` doit contenir un nom de série en B1, des noms de catégorie en A2 :A4, et des valeurs numériques en B2 :B4. L’exemple crée un graphique circulaire, lie le classeur, et utilise [setRange](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/setrange/) pour mapper A1 :B4 à une série et trois catégories. Il enregistre le résultat dans `Presentation_with_externalWorkbook.pptx`.

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

Le paramètre `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/setexternalworkbook/) contrôle si le classeur est chargé.

* Lorsque `updateChartData` est `false`, seul le chemin du classeur est mis à jour. Les données du graphique ne sont pas chargées ni mises à jour depuis le classeur cible, de sorte que le classeur peut être indisponible.
* Lorsque `updateChartData` est `true`, les données du graphique sont mises à jour depuis le classeur cible.

L’exemple suivant affecte une URL factice avec `updateChartData` défini sur `false`. Il conserve les données par défaut du graphique circulaire et enregistre la présentation sans charger le classeur indisponible.

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

Pour identifier le classeur lié à un graphique, vérifiez d’abord si le graphique utilise une source de données externe. Si c’est le cas, vous pouvez récupérer le chemin du classeur en suivant ces étapes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
1. Accédez à la première diapositive par son indice zéro‑based.
1. Vérifiez que la première forme est un graphique.
1. Lisez le type de source de données du graphique.
1. Si la source est un classeur externe, lisez son chemin.

Cet exemple ouvre `externalWorkbook.pptx`, créé dans l’exemple précédent, et examine la première forme de la première diapositive. Si c’est un graphique lié à un classeur externe, l’exemple affiche [getExternalWorkbookPath](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) dans la console. Il enregistre ensuite une copie de la présentation dans `Result.pptx`.

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

Vous pouvez modifier les données des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Cet exemple nécessite `presentation.pptx` avec un graphique comme première forme de sa première diapositive et un classeur externe accessible. Il définit la valeur basée sur la cellule du premier point de données de la première série à 100 et enregistre la présentation dans `presentation_out.pptx`. La modification des valeurs de cellules peut mettre à jour le fichier XLSX externe lié, utilisez donc une copie si vous devez conserver le classeur original.

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

### **Récupérer un classeur à partir du cache du graphique**

Si un graphique utilise un classeur externe qui manque ou est indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez [LoadOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/), appelez [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/setspreadsheetoptions/), et définissez [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fr/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) sur `true` avant d’ouvrir la présentation.

L’exemple PHP suivant ouvre `presentation.pptx`, dont la première forme de la première diapositive doit être un graphique faisant référence à un classeur externe indisponible, et accède aux données récupérées via [Chart::getChartData](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/getchartdata/) et [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/getchartdataworkbook/) :

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

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données mises en cache du graphique constitue une solution de repli acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis‑je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/getdatasourcetype/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/getexternalworkbookpath/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers des classeurs externes sont‑ils pris en charge, et comment sont‑ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, de sorte que le déplacement du classeur peut nécessiter la mise à jour du lien.

**Puis‑je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge ; ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase‑t‑il le fichier XLSX externe lors de l’enregistrement de la présentation ?**

La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/getexternalworkbookpath/). La modification des données du graphique basées sur des cellules peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à supprimer la protection au préalable ou à préparer une copie décryptée (par exemple avec [Aspose.Cells](https://reference.aspose.com/cells/java/)) et à lier cette copie.

**Plusieurs graphiques peuvent‑ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.