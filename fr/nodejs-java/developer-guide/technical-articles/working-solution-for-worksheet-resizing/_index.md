---
title: Solution opérationnelle pour le redimensionnement de la feuille de calcul
type: docs
weight: 20
url: /fr/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- image d'aperçu
- redimensionnement d'image
- Excel
- feuille de calcul
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Corrigez le redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux méthodes pour garder les cadres d'objet cohérents—scaler le cadre ou la feuille—dans les formats PPT et PPTX."
---
{{% alert color="info" title="Note" %}}

Les feuilles de calcul Excel intégrées comme objets OLE dans une présentation PowerPoint à l’aide des composants Aspose peuvent changer de taille de manière inattendue après leur première activation. Ce comportement crée une différence visuelle notable entre l’objet OLE avant et après l’activation. Cet article explique le problème et décrit deux façons de le résoudre.

{{% /alert %}}

## **Contexte**

Dans l’article [Gérer OLE](/slides/fr/nodejs-java/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint en utilisant Aspose.Slides for Node.js via Java. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté une image de la zone de feuille de calcul sélectionnée au cadre d’objet OLE. Dans la présentation générée, lorsque vous double-cliquez sur le cadre d’objet OLE affichant l’image de la feuille, le classeur Excel est activé. Les utilisateurs peuvent apporter les modifications souhaitées au classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille du cadre d’objet OLE changera lorsque l’utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre d’objet OLE et du classeur Excel incorporé.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d’origine lors de la première activation. En revanche, le cadre d’objet OLE possède ses propres dimensions. Selon Microsoft, lorsqu’il est activé, le classeur Excel et PowerPoint négocient la taille afin de conserver les proportions correctes dans le cadre du processus d’intégration. Le redimensionnement intervient en fonction des différences entre la taille de la fenêtre Excel et la taille et la position du cadre d’objet OLE.

## **Solution opérationnelle**

Il existe deux solutions possibles pour éviter l’effet de redimensionnement.

- Redimensionner le cadre OLE dans la présentation PowerPoint pour correspondre à la hauteur et à la largeur totales des lignes et colonnes sélectionnées.  
- Conserver la taille du cadre OLE constante et redimensionner les lignes et colonnes sélectionnées pour qu’elles tiennent à l’intérieur.

### **Redimensionner la taille du cadre OLE**

Cette approche définit la taille du cadre OLE afin de correspondre à la hauteur et à la largeur totales des lignes et colonnes sélectionnées dans la feuille de calcul Excel incorporée.

L’exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de la première feuille à l’aide d’indices basés sur zéro. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) définit la plage affichée. L’aperçu est rendu à 96 DPI, et ses dimensions en pixels sont converties en points en utilisant 72 points par pouce. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) intègre le classeur modifié dans un cadre aux dimensions indiquées. L’aperçu est affecté via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) pour remplacer le texte « EMBEDDED OLE OBJECT » du cadre de substitution dans la présentation enregistrée.

Installez les packages `aspose.cells`, `aspose.slides.via.java` et `java` et placez le fichier `sample.xlsx` dans le répertoire de travail. Pour chaque approche, exécutez d’abord le script de préparation, puis le script d’intégration dans un processus Node.js séparé dans le même répertoire. Les deux packages Aspose initialisent séparément le pont Java.

Enregistrez ce script de préparation sous le nom `prepare-frame-scaled.js` et lancez‑le avec `node prepare-frame-scaled.js`. Il crée `frame-scaled.xlsx` et `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Tout le travail synchrone est terminé; arrêtez le processus de pont Java.
process.exit(0);
```

Enregistrez ce script d’intégration sous le nom `embed-frame-scaled.js` et lancez‑le avec `node embed-frame-scaled.js`. Il lit ces fichiers et génère `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Tout le travail synchrone est terminé ; arrêtez le processus de pont Java.
process.exit(0);
```

L’assistant d’aperçu définit [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) sur la plage sélectionnée et supprime les marges, en‑têtes et pieds de page. Avec [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) activé, [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) rend la plage sous forme d’image PNG. L’assistant enregistre l’image PNG dans un fichier pour l’utiliser dans la présentation.

### **Redimensionner la taille de la zone de cellules**

Cette approche redimensionne la hauteur des lignes sélectionnées et la largeur des colonnes sélectionnées afin de correspondre à une taille de cadre OLE personnalisée.

L’exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de la première feuille à l’aide d’indices basés sur zéro. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) définit la plage affichée, et l’assistant redimensionne cette plage pour l’adapter à un cadre de 400 points de large sur 100 points de haut. Après avoir enregistré le classeur modifié dans un fichier, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) l’intègre à la taille spécifiée. Un aperçu rendu à 96 DPI est affecté via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), de sorte que la présentation enregistrée affiche les cellules sélectionnées au lieu du texte de substitution par défaut.

Enregistrez ce script de préparation sous le nom `prepare-cells-scaled.js` et lancez‑le avec `node prepare-cells-scaled.js`. Il crée `cells-scaled.xlsx` et `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Tout le travail synchrone est terminé ; arrêtez le processus de pont Java.
process.exit(cellsPrepared ? 0 : 1);
```

Enregistrez ce script d’intégration sous le nom `embed-cells-scaled.js` et lancez‑le avec `node embed-cells-scaled.js`. Il lit ces fichiers et génère `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Tout le travail synchrone est terminé ; arrêtez le processus de pont Java.
process.exit(0);
```

L’assistant de mise à l’échelle calcule des ratios de largeur et de hauteur séparés pour la plage sélectionnée, en conservant les largeurs relatives de ses colonnes et les hauteurs relatives de ses lignes. Il convertit les dimensions calculées de points en pouces avant de les appliquer avec [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) et [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). La plage sélectionnée doit avoir une largeur et une hauteur non nulles.

Cet assistant d’aperçu rend la plage redimensionnée à l’aide de [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Il limite [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) à cette plage, supprime les marges, en‑têtes et pieds de page, et enregistre l’image PNG dans un fichier.

## **Conclusion**

{{% alert color="info" title="Note" %}}

Il existe deux approches pour corriger le problème de redimensionnement de la feuille de calcul. Choisissez celle qui correspond le mieux à vos exigences et à votre cas d’utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, il n’existe aucune limite à la taille du cadre OLE dans cette solution.

{{% /alert %}}

## **FAQ**

**Pourquoi une feuille de calcul Excel incorporée change-t-elle de taille lors de sa première activation dans PowerPoint ?**

Cela se produit parce qu’Excel tente de conserver la taille originale de la fenêtre lorsqu’il est activé, alors que le cadre d’objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de maintenir le ratio d’aspect, ce qui peut entraîner le redimensionnement.

**Est‑il possible d’éliminer complètement ce problème de redimensionnement ?**

Oui. En redimensionnant le cadre OLE pour qu’il corresponde à la taille de la plage de cellules Excel ou en redimensionnant la plage de cellules pour qu’elle corresponde à la taille souhaitée du cadre OLE, vous pouvez empêcher le redimensionnement indésirable.

**Quelle méthode de mise à l’échelle devrais‑je utiliser, le redimensionnement du cadre OLE ou le redimensionnement de la plage de cellules ?**

Choisissez le **redimensionnement du cadre OLE** si vous souhaitez conserver les tailles d’origine des lignes et colonnes Excel. Choisissez le **redimensionnement de la plage de cellules** si vous désirez une taille fixe pour le cadre OLE dans votre présentation.

**Ces solutions fonctionneront‑elles si ma présentation est basée sur un modèle ?**

Oui. Les deux solutions fonctionnent pour les présentations créées à partir de modèles et pour celles créées à partir de zéro.

**Y a‑t‑il une limite à la taille du cadre OLE lorsqu’on utilise ces méthodes ?**

Non. Vous pouvez donner au cadre d’objet OLE n’importe quelle taille tant que vous définissez correctement l’échelle.

**Existe‑t‑il un moyen d’éviter le texte de substitution « EMBEDDED OLE OBJECT » dans PowerPoint ?**

Oui. En prenant un instantané de la plage de cellules Excel cible et en l’affectant comme image de substitution du cadre OLE, vous pouvez afficher une image d’aperçu personnalisée à la place du texte de substitution par défaut.

## **Articles associés**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/fr/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)