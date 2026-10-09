---
title: Gérer les classeurs de graphiques dans les présentations en JavaScript
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/nodejs-java/chart-workbook/
keywords:
- classeur de graphique
- données de graphique
- cellule de classeur
- étiquette de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- cache de graphique
- récupération de classeur
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Node.js via Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire les données de graphique via des flux de classeur, utiliser les cellules du classeur comme étiquettes de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs de graphique.

Il couvre également le travail avec des classeurs externes comme sources de données de graphique. Les exemples démontrent comment créer et affecter un classeur externe, récupérer le chemin d’un classeur externe lié à un graphique, et modifier les données du graphique lorsque le classeur est disponible.

Pour les cellules de classeur représentant des données manquantes, voir [Contrôler l'affichage des cellules vides](/slides/fr/nodejs-java/chart-series/) pour la différence entre une cellule vide et zéro, ainsi qu’une comparaison en diagramme linéaire des modes d’affichage disponibles.

## **Inclure les données des lignes et colonnes masquées**

Utilisez [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) pour contrôler si un graphique trace les données provenant de lignes et colonnes de feuille masquées. Réglez-le sur `true` pour tracer uniquement les cellules visibles, ou sur `false` pour inclure à la fois les cellules visibles et masquées. Ce paramètre contrôle le traçage du graphique ; il ne masque ni n’affiche les lignes ou colonnes de la feuille.

La [sample presentation](hidden-source-data.pptx) contient un graphique à colonnes comme première forme de sa première diapositive. La feuille intégrée, `Sheet1`, contient la plage source suivante, `A1:C4`. La ligne 3 et la colonne C sont masquées, mais leurs cellules conservent des valeurs.

| Ligne de feuille de calcul | A : Mois | B : Vente au détail | C : Vente en gros (colonne masquée) |
| --- | --- | --- | --- |
| 2 | janvier | 10 | 30 |
| 3 (ligne masquée) | février | 40 | 60 |
| 4 | mars | 20 | 50 |

Accédez aux cellules sources via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) et lisez [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden) pour inspecter leur statut masqué. Cette méthode indique le statut masqué sans le modifier. Dans ce fichier, B2 est visible, B3 appartient à la ligne masquée, et C2 appartient à la colonne masquée ; l’exemple affiche `false`, `true` et `true` respectivement.

Pour cet exemple, rafraîchissez les données du graphique après modification du paramètre de traçage : conservez le classeur intégré avec [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) et rechargez‑le avec [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). Lors de l’inclusion de toutes les cellules, utilisez également [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) pour restaurer la plage complète, y compris la catégorie février masquée. Modifier simplement le drapeau n’est pas suffisant pour rafraîchir les données mises en cache de cet exemple ni les étiquettes de catégorie. L’exemple convertit le tampon Node.js retourné en tableau d’octets Java avant de le transmettre à la méthode d’écriture.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Actualiser les données du graphique depuis le classeur intégré.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Restaurer la plage source complète, y compris les catégories masquées.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

L’exemple enregistre deux versions de la présentation : une avec uniquement les valeurs de Vente au détail visibles (10 et 20), et une autre avec les six valeurs. Les images ci‑dessous illustrent les deux modes de traçage. La ligne 3 et la colonne C restent masquées dans les deux classeurs intégrés.

| Cellules visibles uniquement (`true`) | Toutes les cellules (`false`) |
| --- | --- |
| ![Cellules visibles uniquement : valeurs de Vente au détail 10 et 20 pour janvier et mars.](hidden_cells_True.png) | ![Toutes les cellules : valeurs de Vente au détail et Vente en gros pour janvier, février et mars.](hidden_cells_False.png) |

Une cellule masquée contenant une valeur diffère d’une cellule vide. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) contrôle la façon dont les valeurs manquantes sont affichées ; il n’inclut ni n’exclut les données sources masquées. Voir [Contrôler l'affichage des cellules vides](/slides/fr/nodejs-java/chart-series/#control-the-display-of-empty-cells) pour un exemple.

## **Récupérer la plage de données d'un graphique**

Avant de mettre à jour les données du classeur dans une présentation existante, inspectez les plages sources afin d’identifier les cellules de feuille utilisées par chaque graphique. La méthode [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange) renvoie la plage de données actuelle sous forme de formule qualifiée de feuille, par exemple `Sheet1!$A$1:$D$5`. Ici, `Sheet1` est le nom de la feuille, `!` le sépare de la plage de cellules, et `$A$1:$D$5` identifie les cellules A1 à D5 incluses. Les signes dollars indiquent des références absolues de ligne et de colonne.

La méthode lit la plage actuelle sans modifier le graphique ni son classeur. Si le graphique n’utilise pas de classeur comme source de données, elle lève `InvalidOperationException`. Pour plus d’informations, voir la [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Cet exemple ouvre une présentation et examine les formes directement sur chaque diapositive à la recherche de graphiques. Il affiche le nom de chaque graphique et sa plage source. Si un graphique n’utilise pas de classeur, il affiche un message et poursuit avec le graphique suivant.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Lire et écrire des données de graphique à partir d'un classeur**

Aspose.Slides for Node.js via Java fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) et [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) qui permettent de lire et d’écrire les classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Note** que les données du graphique doivent être organisées de la même manière ou présenter une structure similaire à la source.

Cet exemple utilise une présentation contenant un graphique comme première forme de sa première diapositive. Il lit le classeur intégré dans un tableau d’octets, efface les séries et catégories existantes, puis réécrit le même classeur. Les modifications restent en mémoire ; l’exemple n’enregistre pas la présentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Valider la mise en page du graphique après modification du classeur**

Lorsque vous remplacez un classeur intégré par un classeur modifié, le graphique conserve ses collections de séries et de catégories d’origine. Cette incohérence peut entraîner l’échec de [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout) avec une erreur d’indice hors plage. Effacez les séries et catégories existantes avant d’écrire le classeur mis à jour dans le graphique. Cet exemple utilise un graphique qui est la première forme de la première diapositive. Le commentaire indique où l’édition du classeur aurait lieu ; l’exemple exécutable réécrit le classeur original et valide la mise en page en mémoire.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Modifier les octets du classeur ici, par exemple, à l'aide d'Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Effacer les collections supprime les références de données obsolètes avant que le classeur ne soit réécrit. Reconstruisez les éventuelles correspondances de séries et de catégories requises pour le classeur mis à jour avant d’utiliser le graphique.

## **Définir une cellule de classeur comme étiquette de données de graphique**

Vous pouvez utiliser le texte provenant des cellules du classeur comme étiquettes de données de graphique.

Cet exemple ajoute un graphique à bulles avec des données par défaut à la première diapositive d’une présentation existante. Il utilise les cellules A10:A12 de la feuille 0 pour les trois premières étiquettes de la première série, active les étiquettes provenant des cellules, et enregistre la présentation mise à jour.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gérer les feuilles de calcul**

La méthode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) fournit l’accès aux feuilles de calcul d’un classeur de graphique. Cet exemple crée un graphique en secteurs avec des données par défaut et affiche chaque nom de feuille dans la console.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Spécifier le type de source de données**

Cet exemple crée un graphique à colonnes 3D avec des données par défaut et définit deux noms de séries en utilisant des sources de données différentes. Le premier nom utilise un littéral de chaîne ; le second utilise la cellule C1 de la feuille 0. L’énumération [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) sélectionne la source pour chaque nom. L’exemple enregistre la présentation avec les noms de séries mis à jour.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Détecter les formats de classeur intégré non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être intégré dans certains graphiques. Vous pouvez utiliser la méthode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) sur [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) conjointement avec l’énumération [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques. Cet exemple inspecte les formes de la première diapositive d’une présentation existante, ignore les formes qui ne sont pas des graphiques, et affiche un message de diagnostic pour chaque graphique contenant un classeur .xlsb intégré.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Lire ou modifier les données de classeur de graphique prises en charge ici.
    }
} finally {
    presentation.dispose();
}
```

## **Classeur externe**

Aspose.Slides prend en charge l’utilisation de classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

Utilisez [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) et [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) pour exporter un classeur de graphique intégré vers un fichier et lier le graphique à ce classeur externe.

Cet exemple crée un graphique en secteurs avec des données par défaut et exporte son classeur. Il termine l’écriture du fichier avant d’attribuer le classeur externe comme source de données du graphique, puis enregistre la présentation liée.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Définir un classeur externe**

En utilisant la méthode [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook), vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également servir à mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés sur des emplacements distants ou des ressources, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif est fourni pour un classeur externe, il est automatiquement converti en chemin complet.

Cet exemple utilise un classeur externe dont la feuille nommée `Sheet1` contient un nom de série en B1, des noms de catégories en A2:A4, et des valeurs numériques en B2:B4. L’exemple crée un graphique en secteurs, lie le classeur, et utilise [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) pour mapper A1:B4 à une série et trois catégories. Il enregistre la présentation avec le graphique lié.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le paramètre `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) contrôle le chargement du classeur.

* When `updateChartData` is `false`, only the workbook path is updated. The chart data is not loaded or updated from the target workbook, so the workbook can be unavailable.
* When `updateChartData` is `true`, the chart data is updated from the target workbook.

L’exemple suivant affecte une URL factice avec `updateChartData` réglé sur `false`. Il conserve les données par défaut du graphique en secteurs et enregistre la présentation sans charger le classeur indisponible.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Obtenir le chemin du classeur source de données externe d'un graphique**

Pour identifier le classeur lié à un graphique, vérifiez si le graphique utilise une source de données externe et récupérez son chemin de classeur.

Cet exemple inspecte la première forme de la première diapositive d’une présentation comportant un classeur externe lié. Si c’est un graphique lié à un classeur externe, l’exemple affiche [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) dans la console. Il enregistre ensuite une copie de la présentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Modifier les données du graphique**

Vous pouvez modifier les données des classeurs externes de la même façon que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

Cet exemple utilise un graphique qui est la première forme de la première diapositive et qui est lié à un classeur externe accessible. Il définit la valeur soutenue par la cellule du premier point de données de la première série à 100 et enregistre la présentation mise à jour. La modification des valeurs de cellules peut mettre à jour le fichier XLSX externe lié, utilisez donc une copie si vous devez préserver le classeur d’origine.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Récupérer un classeur à partir du cache du graphique**

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), appelez [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), et définissez [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) sur `true` avant d’ouvrir la présentation.

L’exemple JavaScript suivant récupère les données du classeur pour un graphique qui est la première forme de la première diapositive et qui référence un classeur externe indisponible. Il accède aux données récupérées via [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData) et [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Lire ou modifier les données du classeur récupéré ici.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l’utilisation des données de graphique mises en cache constitue une solution de repli acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**  
Oui. Un graphique possède un [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType) et un [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont-ils pris en charge, et comment sont-ils stockés ?**  
Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. La présentation stocke le chemin absolu dans le fichier PPTX, de sorte que le déplacement du classeur peut nécessiter une mise à jour du lien.

**Puis-je utiliser des classeurs situés sur des ressources ou partages réseau ?**  
Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge ; ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase-t-il le fichier XLSX externe lors de l'enregistrement de la présentation ?**  
La présentation stocke un [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). La modification des données de graphique soutenues par des cellules peut également mettre à jour le fichier XLSX local lié. Utilisez une copie du classeur si l’original doit rester inchangé.

**Que faire si le fichier externe est protégé par un mot de passe ?**  
Aspose.Slides n’accepte pas de mot de passe lors du lien. Une approche courante consiste à lever la protection au préalable ou à préparer une copie déchiffrée (par exemple avec [Aspose.Cells](https://reference.aspose.com/cells/java/)) et à lier cette copie.

**Plusieurs graphiques peuvent-ils référencer le même classeur externe ?**  
Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier se reflétera dans chaque graphique lors du prochain chargement des données.