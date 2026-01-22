---
title: Gérer les classeurs de graphiques dans les présentations avec JavaScript
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/nodejs-java/chart-workbook/
keywords:
- classeur de graphique
- données du graphique
- cellule du classeur
- libellé de données
- feuille de calcul
- source de données
- classeur externe
- données externes
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez Aspose.Slides pour Node.js via Java : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---

## **Définir les données du graphique à partir du classeur**
Aspose.Slides fournit les méthodes [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) et [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) qui permettent de lire et d’écrire les classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Remarque** que les données du graphique doivent être organisées de la même manière ou doivent présenter une structure similaire à la source.

Ce code JavaScript montre une opération d'exemple :
```javascript
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


## **Définir la cellule du classeur comme étiquette de données du graphique**
1. Créer une instance de la classe [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenir une référence à une diapositive via son index.
1. Ajouter un graphique à bulles avec certaines données.
1. Accéder aux séries du graphique.
1. Définir la cellule du classeur comme une étiquette de données.
1. Enregistrer la présentation.

Ce code JavaScript montre comment définir une cellule de classeur comme étiquette de données du graphique :
```javascript
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
Ce code JavaScript montre une opération où la méthode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) est utilisée pour accéder à une collection de feuilles de calcul :
```javascript
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
Ce code JavaScript montre comment spécifier un type pour une source de données :
```javascript
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


## **Classeur externe**
Aspose.Slides prend en charge les classeurs externes comme source de données pour les graphiques.

### **Créer un classeur externe**
En utilisant les méthodes **`readWorkbookStream`** et **`setExternalWorkbook`**, vous pouvez soit créer un classeur externe à partir de zéro, soit rendre un classeur interne externe.

Ce code JavaScript montre le processus de création d'un classeur externe :
```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
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
En utilisant la méthode **`setExternalWorkbook`**, vous pouvez affecter un classeur externe à un graphique comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin vers le classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés dans des emplacements ou des ressources distants, vous pouvez toujours utiliser ces classeurs comme source de données externe. Si un chemin relatif pour un classeur externe est fourni, il est automatiquement converti en chemin complet.

Ce code JavaScript montre comment définir un classeur externe :
```javascript
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


Le paramètre `ChartData` (dans la méthode `setExternalWorkbook`) sert à spécifier si un classeur Excel sera chargé ou non. 

* Lorsque la valeur de `ChartData` est définie sur `false`, seul le chemin du classeur est mis à jour — les données du graphique ne seront pas chargées ou mises à jour depuis le classeur cible. Vous pouvez utiliser ce réglage lorsqu’il n’y a pas de classeur cible ou qu’il est indisponible. 
* Lorsque la valeur de `ChartData` est définie sur `true`, les données du graphique sont mises à jour à partir du classeur cible.
```javascript
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
1. Créer une instance de la classe [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenir une référence à une diapositive via son index.
1. Créer un objet pour la forme du graphique.
1. Créer un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du graphique.
1. Spécifier la condition pertinente en fonction du type source étant le même que le type de source de données du classeur externe.

Ce code JavaScript montre l'opération :
```javascript
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
Vous pouvez modifier les données des classeurs externes de la même manière que vous apportez des modifications au contenu des classeurs internes. Lorsqu'un classeur externe ne peut pas être chargé, une exception est levée.

Ce code JavaScript est une implémentation du processus décrit :
```javascript
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


## **FAQ**

**Puis-je déterminer si un graphique spécifique est lié à un classeur externe ou intégré ?**

Oui. Un graphique possède un [type de source de données](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers les classeurs externes sont-ils pris en charge, et comment sont-ils stockés ?**

Oui. Si vous spécifiez un chemin relatif, il est automatiquement converti en chemin absolu. Cela est pratique pour la portabilité du projet ; toutefois, notez que la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis-je utiliser des classeurs situés sur des ressources ou partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification de classeurs distants directement depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être utilisés qu’en tant que source.

**Aspose.Slides écrase-t‑il le XLSX externe lors de l’enregistrement de la présentation ?**

Non. La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) et l’utilise pour lire les données. Le fichier externe lui‑même n’est pas modifié lorsque la présentation est enregistrée.

**Que faire si le fichier externe est protégé par un mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à supprimer la protection au préalable ou à préparer une copie décryptée (par exemple en utilisant [Aspose.Cells](/cells/nodejs-java/)) et à y faire lien.

**Plusieurs graphiques peuvent-ils référencer le même classeur externe ?**

Oui. Chaque graphique stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque graphique lors du prochain chargement des données.