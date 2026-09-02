---
title: Gérer les classeurs de graphiques dans les présentations avec JavaScript
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/nodejs-java/chart-workbook/
keywords:
- classeur de graphique
- données du graphique
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

Cet article explique comment travailler avec les classeurs de graphiques dans Aspose.Slides. Il montre comment lire et écrire les données de graphiques via des flux de classeur, utiliser les cellules du classeur comme étiquettes de données de graphique, accéder aux collections de feuilles de calcul et spécifier le type de source de données pour les valeurs des graphiques.

Il couvre également le travail avec des classeurs externes comme sources de données de graphiques. Les exemples démontrent comment créer et affecter un classeur externe, récupérer le chemin d'un classeur externe lié à un graphique, et modifier les données du graphique lorsque le classeur est disponible.

## **Lire et écrire des données de graphique depuis un classeur**

Aspose.Slides fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) et [writeWorkbookStream](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) qui permettent de lire et d'écrire les classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Note** que les données du graphique doivent être organisées de la même manière ou posséder une structure similaire à la source.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Valider la disposition du graphique après modification du classeur**

Lorsque vous remplacez un classeur incorporé par un classeur modifié, le graphique conserve ses collections de séries et de catégories d'origine. Cette incohérence peut provoquer l'échec de [Chart.validateChartLayout](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Chart#validateChartLayout--) avec une erreur d'index hors limites. Nettoyez les séries et catégories existantes avant d'écrire le classeur mis à jour dans le graphique.

```javascript
// Après avoir modifié le flux du classeur (p. ex., en utilisant Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Effacer les références de données existantes.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Le nettoyage des collections garantit que la structure des données du graphique est cohérente avec le nouveau classeur, permettant ainsi à `validateChartLayout` de s'exécuter sans erreurs.

## **Définir la cellule du classeur comme étiquette de données du graphique**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation) .
1. Obtenez une référence à une diapositive via son indice.
1. Ajoutez un graphique à bulles avec quelques données.
1. Accédez aux séries du graphique.
1. Définissez la cellule du classeur comme étiquette de données.
1. Enregistrez la présentation.

Ce code JavaScript montre comment définir une cellule de classeur comme étiquette de données du graphique :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instancie une classe de présentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gérer les feuilles de calcul**

Ce code JavaScript démontre une opération où la méthode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) est utilisée pour accéder à une collection de feuilles de calcul :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Spécifier le type de source de données**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Détecter les formats de classeur incorporés non pris en charge**

Aspose.Slides ne prend pas en charge le format de classeur Excel binaire (.xlsb) qui peut être incorporé dans certains graphiques. Vous pouvez utiliser la méthode `getEmbeddedWorkbookType` sur [ChartData](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdata/) avec l'énumération [WorkbookType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/workbooktype/) pour détecter les formats non pris en charge et ignorer ces graphiques.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // Le classeur incorporé est au format .xlsb, qui n’est pas pris en charge.
            continue;
        }

        // Lisez ou modifiez les données du classeur du graphique ici.
    }
} finally {
    presentation.dispose();
}
```

## **Classeur externe**

Aspose.Slides prend en charge les classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**

En utilisant les méthodes **`readWorkbookStream`** et **`setExternalWorkbook`**, vous pouvez soit créer un classeur externe à partir de zéro, soit rendre un classeur interne externe.

Ce code JavaScript démontre le processus de création d'un classeur externe :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream renvoie les octets du classeur sous forme de Buffer Node.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Définir le classeur externe**

En utilisant la méthode **`setExternalWorkbook`**, vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin du classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données dans les classeurs stockés à des emplacements distants ou dans des ressources, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif pour un classeur externe est fourni, il est automatiquement converti en chemin absolu.

Ce code JavaScript montre comment définir un classeur externe :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crée une instance de la classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Le deuxième paramètre de la méthode `setExternalWorkbook`, `updateChartData`, indique si le classeur Excel sera chargé ou non.

* Lorsque `updateChartData` est défini sur `false`, seul le chemin du classeur est mis à jour — les données du graphique ne seront pas chargées ou mises à jour à partir du classeur cible. Vous pouvez utiliser ce paramètre lorsqu’il est possible que le classeur cible n’existe pas ou soit indisponible.
* Lorsque `updateChartData` est défini sur `true`, les données du graphique sont mises à jour à partir du classeur cible.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crée une instance de la classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Obtenir le chemin du classeur source de données externe du graphique**

1. Créez une instance de la classe [Presentation](https://apireference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation) .
1. Obtenez une référence à une diapositive via son indice.
1. Créez un objet pour la forme du graphique.
1. Créez un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Spécifiez la condition pertinente en fonction du type de source étant le même que le type de source de données du classeur externe.

Ce code JavaScript démontre l'opération :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crée une instance de la classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Enregistre la présentation
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Modifier les données du graphique**

Vous pouvez modifier les données dans les classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu'un classeur externe ne peut pas être chargé, une exception est levée.

Ce code JavaScript est une implémentation du processus décrit :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crée une instance de la classe Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Récupérer un classeur depuis le cache du graphique**

Si un graphique utilise un classeur externe manquant ou indisponible, Aspose.Slides peut reconstruire le classeur du graphique à partir des données mises en cache dans la présentation. Créez un [LoadOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/loadoptions/), configurez-le avec [SpreadsheetOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/spreadsheetoptions/), et appelez [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) avec `true` avant d'ouvrir la présentation.

L'exemple JavaScript suivant ouvre une présentation dont le graphique référence un classeur externe indisponible et accède aux données récupérées via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Lire ou modifier les données du classeur récupéré ici.
} finally {
    presentation.dispose();
}
```

Si le classeur externe est indisponible et que la récupération est désactivée, Aspose.Slides lève une exception. Activez la récupération uniquement lorsque l'utilisation des données de graphique en cache constitue une solution de secours acceptable, car le cache peut ne pas contenir les modifications apportées au classeur externe après la dernière mise à jour de la présentation.

## **FAQ**

**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou incorporé ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ; si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers des classeurs externes sont-ils pris en charge, et comment sont-ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. Cela facilite la portabilité du projet ; cependant, la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis-je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Toutefois, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être utilisés qu’en tant que source.

**Aspose.Slides écrase-t-il le fichier XLSX externe lors de l'enregistrement de la présentation ?**

Non. La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) et l’utilise pour lire les données. Le fichier externe lui‑même n’est pas modifié lors de l’enregistrement de la présentation.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à supprimer la protection à l’avance ou à préparer une copie décryptée (par exemple en utilisant [Aspose.Cells](/cells/nodejs-java/)) et à créer le lien vers cette copie.

**Plusieurs graphiques peuvent-ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.