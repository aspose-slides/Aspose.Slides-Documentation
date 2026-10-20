---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 40
url: /fr/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement du graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Corrige le redimensionnement inattendu des graphiques dans les fichiers PPTX lors de l’utilisation d’objets OLE Excel intégrés avec Aspose.Slides pour Node.js via Java. Définit des dimensions de graphique fixes pour maintenir la cohérence des tailles du graphique et du cadre OLE."
---
## **Aperçu**

Les graphiques Excel intégrés en tant qu’objets OLE dans les présentations PowerPoint à l’aide des composants Aspose peuvent changer de taille après leur première activation. Cela peut entraîner une différence visible de l’apparence du graphique avant et après l’activation. Cet article explique pourquoi le redimensionnement se produit et montre comment l’empêcher en faisant correspondre les dimensions fixes du graphique au cadre OLE.

Dans [Créer des graphiques Excel et les incorporer en tant qu’objets OLE dans des présentations](/slides/fr/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells for Node.js via Java et l’incorporer dans une présentation PowerPoint à l’aide d’Aspose.Slides for Node.js via Java. Pour résoudre le [problème d’aperçu d’objet](/slides/fr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué l’image du graphique au cadre d’objet OLE du graphique. Dans la présentation générée, lorsque vous double‑cliquez sur le cadre d’objet OLE affichant l’image du graphique, le graphique Excel est activé. Les utilisateurs peuvent modifier le classeur Excel incorporé, puis revenir à la diapositive en cliquant en dehors du classeur activé. La taille du cadre d’objet OLE change lorsque l’utilisateur revient à la diapositive, et le facteur de redimensionnement varie selon les tailles d’origine à la fois du cadre d’objet OLE et du classeur Excel incorporé.

## **Cause du redimensionnement**

Le classeur Excel incorporé possède ses propres dimensions de fenêtre, que Excel tente de conserver lors de la première activation de l’objet. Le cadre OLE sur la diapositive a des dimensions définies de façon indépendante. Lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille de l’objet afin de maintenir ses proportions dans le cadre du processus d’incorporation. Les différences entre la fenêtre du classeur et le cadre OLE peuvent donc entraîner le redimensionnement de l’objet.

## **Solution fonctionnelle**

Faites correspondre la taille du graphique au cadre OLE de la diapositive et maintenez les dimensions du graphique indépendantes de la fenêtre du classeur. Cette solution fonctionne avec une présentation nouvelle ou un modèle existant.

L’exemple nécessite Aspose.Cells for Node.js via Java et Aspose.Slides for Node.js via Java. Installez les packages Node.js `aspose.cells`, `aspose.slides.via.java` et `java`. Exécutez les deux scripts CommonJS ci‑dessus dans des processus Node.js séparés, en utilisant le même répertoire de travail, car les deux packages Aspose initialisent le pont Java lors du chargement. Il crée un graphique à colonnes simple sur une feuille de graphique active et incorpore le classeur au format XLS. Aucun aperçu du graphique n’est attribué ; le graphique devient visible lorsque l’objet OLE est activé dans PowerPoint.

L’exemple crée une nouvelle présentation avec un cadre OLE de 9,5 × 4 pouces positionné à 0,5 pouce du bord gauche et 1 pouce du haut. Les coordonnées et dimensions de la diapositive sont en points (72 points par pouce). Pour une présentation existante, voir [Utiliser un modèle](#use-a-template).

## **Définir une taille de graphique fixe**

Définissez [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) sur false afin que les dimensions du graphique soient indépendantes de la fenêtre du classeur. Définissez les dimensions du [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) via [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) et [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), en convertissant les points en pixels à l’aide de 96 pixels par pouce : un cadre mesurant 684 × 288 points correspond à un graphique de 912 × 384 pixels. Définissez [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) sur la valeur CUSTOM de `PrintSizeType`. L’exemple incorpore le classeur avec [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) et enregistre une présentation avec un cadre OLE de 9,5 × 4 pouces.

Enregistrez ce premier script sous `create-fixed-chart.js`. Il crée `chart-fixed-size.xls` avec un graphique mesurant 912 × 384 pixels, correspondant au cadre de 684 × 288 points utilisé par le second script. Aucun classeur d’entrée n’est requis.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Faire correspondre les dimensions du cadre OLE en points (72 points par pouce).
    const width = 684; // 9,5 pouces.
    const height = 288; // 4 pouces.

    chart.setSizeWithWindow(false);
    // Convertir les points en pixels du graphique en utilisant 96 pixels par pouce.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Tout le travail synchrone est terminé ; arrêter le processus de pont Java.
process.exit(0);
```

Enregistrez le deuxième script sous `embed-fixed-chart.js` et exécutez‑le après `create-fixed-chart.js`. Il lit le classeur XLS généré et enregistre `chart-fixed-size.pptx`. Le pont Java nécessite un tableau d’octets Java explicite pour les données du classeur ainsi que des valeurs flottantes Java pour les coordonnées et dimensions du cadre. L’extension `xls` correspond au format enregistré du classeur.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Les coordonnées et dimensions de la diapositive sont en points (72 points par pouce).
    const width = 684; // 9,5 pouces.
    const height = 288; // 4 pouces.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Tout le travail synchrone est terminé ; arrêter le processus de pont Java.
process.exit(0);
```

## **Utiliser un modèle**

La logique de dimensionnement est la même pour une présentation existante. Pour adapter l’exemple :

1. Chargez la présentation modèle au lieu de créer une présentation vide.
1. Vérifiez que la première diapositive contient au moins trois formes, puis utilisez la forme à l’index 2 comme espace réservé.
1. Prenez la largeur et la hauteur du cadre à partir de cette forme au lieu d’utiliser les valeurs fixes 684 et 288. Utilisez les mêmes dimensions dans le script de création du classeur, en conservant les calculs de dimensionnement inchangés, et regénérez le classeur XLS avant de l’incorporer.
1. Ajoutez le cadre OLE à la position de l’espace réservé au lieu des coordonnées fixes 36 et 72.
1. Supprimez l’espace réservé avant d’enregistrer la présentation.

## **FAQ**

**Pourquoi mon graphique Excel incorporé change-t-il de taille après son activation dans PowerPoint ?**

Cela se produit parce qu’Excel tente de restaurer la taille d’origine de la fenêtre lors de la première activation, alors que le cadre de l’objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de préserver le rapport d’aspect, ce qui peut entraîner le redimensionnement.

**Comment puis‑je garder les tailles du graphique et du cadre OLE cohérentes ?**

Définissez des dimensions de graphique fixes qui correspondent au cadre OLE et utilisez une taille d’impression de graphique personnalisée avant d’incorporer le classeur. L’exemple ci‑dessus montre les paramètres requis et les conversions d’unités.

**Le fait de faire correspondre la taille de la fenêtre du classeur suffit‑il ?**

Faire correspondre uniquement la taille de la fenêtre du classeur ne garantit pas d’empêcher le cadre OLE de changer de taille après l’activation. Utilisez des dimensions de graphique fixes comme indiqué dans l’exemple.

**Cette solution fonctionne‑t‑elle avec les présentations basées sur un modèle et les nouvelles présentations ?**

Oui. Pour un modèle, utilisez les dimensions et la position de l’espace réservé. Pour une nouvelle présentation, spécifiez directement les dimensions et la position du cadre.

**Puis‑je utiliser cet exemple avec des graphiques créés dans d’autres programmes de tableur ?**

L’exemple utilise un classeur Excel créé avec Aspose.Cells. Il ne montre pas le comportement d’activation pour d’autres programmes de tableur.

## **Sections connexes**

- [Créer des graphiques Excel et les incorporer en tant qu’objets OLE dans des présentations](/slides/fr/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)