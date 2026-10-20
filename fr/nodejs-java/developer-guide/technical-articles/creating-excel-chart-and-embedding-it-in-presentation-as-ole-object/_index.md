---
title: Créer des graphiques Excel et les intégrer dans des présentations en tant qu'objets OLE
type: docs
weight: 30
url: /fr/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- graphique Excel
- intégrer le graphique
- objet OLE
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer un graphique Excel avec Aspose.Cells pour Node.js via Java et intégrer le classeur dans une présentation PowerPoint avec Aspose.Slides, incluant un aperçu du graphique."
---
## **Vue d'ensemble**

Cet article montre comment créer un diagramme à barres Excel avec Aspose.Cells pour Node.js via Java et incorporer son classeur dans une présentation PowerPoint avec Aspose.Slides pour Node.js via Java. Le classeur incorporé contient à la fois les données source et le diagramme. Un aperçu PNG séparé affiche le diagramme sur la diapositive avant l'activation de l'objet OLE.

Le résultat est un objet Excel incorporé, pas un diagramme PowerPoint natif. La modification du classeur via OLE nécessite une application de bureau qui prend en charge l'activation OLE et une installation Excel compatible.

## **Prérequis**

Installez les packages Node.js `aspose.cells`, `aspose.slides.via.java` et `java`. Exécutez les exemples en tant que deux scripts CommonJS dans des processus Node.js séparés : d'abord `create-chart.js`, puis `embed-chart.js`, en utilisant le même répertoire de travail. Les deux packages Aspose initialisent le pont Java lors du chargement, c’est pourquoi ces exemples les maintiennent dans des processus séparés. Microsoft Office n’est pas requis pour générer la présentation avec ces bibliothèques.

Aucun classeur ou image existant n’est requis. Le premier script crée `ChartWorkbook.xlsx` et `ChartPreview.png`; le second lit ces fichiers et écrit `OutputChart.pptx` dans le répertoire de travail actuel. Appliquez les licences pour les deux produits lors de l’exécution hors mode d’évaluation.

## **Comment l’intégration fonctionne**

1. Créez un classeur avec une feuille de données et une feuille de diagramme.  
1. Activez la feuille de diagramme afin que le classeur s’ouvre sur le diagramme.  
1. Définissez la plage d’affichage OLE du classeur et rendez le diagramme au format PNG.  
1. Enregistrez le classeur au format XLSX et intégrez ses octets dans une diapositive dans un processus Node.js séparé.  
1. Attribuez le PNG comme aperçu de l’objet OLE et enregistrez la présentation au format PPTX.

La plage d’affichage du classeur et le cadre sur la diapositive ont des rôles différents. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) prend des indices de ligne et de colonne de début/fin basés sur zéro. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) quant à lui prend la ligne supérieure, la colonne gauche, la ligne inférieure et la colonne droite. L’exemple utilise l’indice de ligne 55 et l’indice de colonne 25 comme limites inférieure‑droite ; ces valeurs sont des choix de mise en page, pas le nombre de lignes ou de colonnes de données.

Le cadre de la diapositive utilise des points. L’exemple l’ajuste à l’intérieur de la diapositive et le centre tout en préservant le rapport d’aspect du PNG, plutôt que d’étirer l’aperçu pour remplir la diapositive.

## **Créer et incorporer le diagramme**

Enregistrez le premier exemple sous le nom `create-chart.js`. Il remplit `DataSheet` avec quatre lignes et cinq colonnes de valeurs. Chaque ligne devient une série de diagramme. `ChartSheet` est sélectionnée comme feuille active avant l’enregistrement du classeur.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Rendre l'aperçu du diagramme et sérialiser le classeur modifiable séparément.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Tout le travail synchrone est terminé ; arrêtez le processus du pont Java.
process.exit(0);
```

Enregistrez l’exemple suivant sous le nom `embed-chart.js`. Exécutez‑le après que `create-chart.js` ait créé les deux fichiers d’entrée. Il centre le cadre OLE et préserve le rapport d’aspect de l’image d’aperçu.

Le second script intègre le classeur enregistré et utilise le PNG comme aperçu. Le classeur est explicitement enregistré au format XLSX, correspondant à l’extension `xlsx` transmise à [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). Le PNG est chargé directement à partir de ses octets sans conversion bitmap intermédiaire. Le pont Java nécessite des tableaux d’octets Java explicites pour l’image et les données du classeur, ainsi que des valeurs flottantes Java pour les coordonnées du cadre de la diapositive. L’affecter via [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) remplace le placeholder OLE par défaut.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Ajuster l'aperçu dans la diapositive sans changer son rapport d'aspect.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Tout le travail synchrone est terminé ; arrêtez le processus du pont Java.
process.exit(0);
```

## **Résultat attendu**

`OutputChart.pptx` contient une diapositive avec un classeur Excel incorporé et un aperçu du diagramme. Le classeur contient les données originales et un diagramme à colonnes avec quatre séries. L’aperçu est centré sur la diapositive et conserve ses proportions.

![Diagramme à colonnes Excel affiché comme aperçu d’un classeur incorporé](excel-chart-ole-preview.png)

Dans un environnement PowerPoint de bureau compatible avec Excel disponible, double‑cliquez sur l’objet pour activer et modifier le classeur incorporé. L’activation et la modification dépendent de la prise en charge OLE de l’application hôte et des paramètres de sécurité.

## **FAQ**

**Pourquoi une image d’aperçu est‑elle nécessaire ?**  
Le classeur incorporé et son aperçu de diapositive sont des contenus séparés. Fournissez une image de diagramme afin que la diapositive affiche le diagramme au lieu du placeholder par défaut « EMBEDDED OLE OBJECT ». Voir [Problème d’aperçu d’objet lors de l’ajout d’OleObjectFrame](/slides/fr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**L’aperçu se met‑il à jour automatiquement lorsque je modifie le classeur dans le code ?**  
Considérez l’aperçu comme une capture instantanée. Lors de la mise à jour des données du classeur par programmation, régénérez l’image du diagramme et remplacez l’aperçu ainsi que les données du classeur incorporé.

**Puis‑je utiliser XLS au lieu de XLSX ?**  
Oui. Enregistrez le classeur au format XLS et utilisez `xls` comme extension des données incorporées. L’extension doit correspondre au format réel du classeur ; modifier uniquement l’extension ne convertit pas les données.

**Pourquoi l’objet peut‑il changer de taille après activation ?**  
L’application hôte peut mettre à jour la présentation de l’objet OLE lorsqu’elle active le classeur. La plage d’affichage OLE du classeur et les dimensions du cadre de la diapositive comptent toutes les deux. Voir [Solution fonctionnelle pour le redimensionnement du diagramme dans PPTX](/slides/fr/java/working-solution-for-chart-resizing-in-pptx/).

## **Sections connexes**

- [Solution fonctionnelle pour le redimensionnement du diagramme dans PPTX](/slides/fr/java/working-solution-for-chart-resizing-in-pptx/)
- [Problème d’aperçu d’objet lors de l’ajout d’OleObjectFrame](/slides/fr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)