---
title: Gérer les cellules de tableau dans les présentations avec JavaScript
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/nodejs-java/manage-cells/
keywords:
- cellule de tableau
- fusionner des cellules
- supprimer la bordure
- diviser la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérer les cellules de tableau PowerPoint en JavaScript : identifier les cellules fusionnées, supprimer les bordures, diviser les cellules et définir les couleurs d'arrière-plan et les images avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'accéder aux cellules de tableau et de les modifier dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, travailler avec la numérotation des cellules après fusion ou division, changer la couleur d'arrière‑plan d'une cellule et ajouter une image à l'intérieur d'une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d'une diapositive, mettre à jour le formatage des cellules via les propriétés des cellules et enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices zéro‑base pour accéder aux cellules de tableau dans l'ordre `(colonne, ligne)`.

## **Identifier une cellule de tableau fusionnée**

L'exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est un tableau. Il parcourt ensuite toutes les lignes et colonnes et utilise [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) pour identifier les cellules dans les zones fusionnées. Pour chaque correspondance, il affiche les coordonnées de la cellule dans l'ordre `ligne;colonne`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), et les coordonnées de départ de la région, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) et [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Supprimer les bordures des cellules de tableau**

Créez une [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et ajoutez un tableau à sa première diapositive avec [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Les largeurs de colonne, hauteurs de ligne et la position du tableau sont spécifiées en points. L'exemple définit les quatre bordures de la cellule sur [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), les rendant invisibles.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Fusionner des cellules de tableau**

Utilisez [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) pour combiner une plage rectangulaire de cellules de tableau en une seule cellule. Spécifiez les cellules aux coins supérieur gauche et inférieur droit de la plage. Le dernier argument détermine si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `false` maintient la fusion à l'intérieur de cette plage.

L'exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante s'étend sur deux colonnes et deux lignes, tandis que la grille sous‑jacent du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au formatage de la cellule fusionnée, utilisez sa position en haut à gauche : `table.get_Item(1, 1)` dans cet exemple. Les autres positions de la plage fusionnée restent partie de la grille du tableau, ainsi les indices des cellules en dehors de la plage ne changent pas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diviser les cellules de tableau**

La fusion des cellules dans l'exemple précédent préserve la grille du tableau. Diviser une cellule peut ajouter une nouvelle colonne à la grille et modifier les indices de colonne des cellules situées à sa droite. Aspose.Slides suit le modèle de grille de tableau de PowerPoint.

Cet exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points et appelle [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est passée pour créer deux cellules de largeur égale.

Après cette division, les deux moitiés sont accessibles via `table.get_Item(1, 1)` et `table.get_Item(2, 1)`. La grille du tableau possède maintenant cinq colonnes : les cellules initialement dans les colonnes 2 et 3 se déplacent respectivement vers les colonnes 3 et 4. Les indices de ligne restent inchangés. Utilisez ces indices de colonne mis à jour lors de l'accès aux cellules après la division.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Diviser les cellules fusionnées par portée de ligne ou de colonne**

Pour préparer les cellules de modèle fusionnées à la population de données, utilisez [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) pour diviser le long d'une frontière de ligne existante, ou [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) pour diviser le long d'une frontière de colonne.

L'argument `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; il est relatif à la région fusionnée :

- Division de ligne : `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Division de colonne : `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

L'exemple suppose qu'une présentation possède un tableau comme première forme de la première diapositive, avec `(1, 2)` et `(1, 3)` fusionnés verticalement. En commençant à partir de la position inférieure, il utilise [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) et [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) pour localiser l'origine et vérifie les deux portées. `splitByRowSpan(1)` sépare alors les lignes 2 et 3 pour les noms de produits. Pour une fusion horizontale de deux colonnes, utilisez `splitByColSpan(1)` à la place.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Récupérer les cellules résultantes du tableau après la division.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont une portée de 1 et [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) renvoie `false`. Des régions plus grandes peuvent rester partiellement fusionnées après une division.

Le texte original et son formatage restent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du formatage de la cellule comme le remplissage, les bordures et les marges. Remplissez les cellules après la division et définissez explicitement tout formatage de texte requis.

La présentation enregistrée contient des cellules séparées "Product A" et "Product B" avec le formatage des cellules du modèle conservé. Consultez la [Référence de l'API Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) pour plus de détails.

## **Modifier la couleur d'arrière‑plan d'une cellule de tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il utilise [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) pour sélectionner un remplissage uni et définit la couleur renvoyée par [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) sur rouge pour la cellule `(2, 3)`, dans la troisième colonne et la quatrième ligne.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter une image à l'intérieur d'une cellule de tableau**

Placez l'image d'entrée dans le répertoire de travail avant d'exécuter cet exemple. Elle charge l'image avec [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) et l'ajoute à la collection d'images de la présentation avec [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Elle affecte ensuite l'image au remplissage d'image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) étire l'image pour remplir la cellule, ce qui peut modifier son ratio d'aspect. Les largeurs de colonne et hauteurs de ligne sont en points. L'image chargée est libérée dans un bloc `finally` après avoir été ajoutée à la présentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis-je définir des épaisseurs et des styles de ligne différents pour chaque côté d'une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) possèdent des propriétés distinctes, de sorte que l'épaisseur et le style de chaque côté peuvent différer.

**Que se passe-t-il avec l'image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [mode de remplissage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). En mode étirement, l'image s'adapte à la nouvelle cellule ; en mode mosaïque, les tuiles sont recalculées.

**Puis-je attribuer un hyperlien à tout le contenu d'une cellule ?**

[Hyperlinks](/slides/fr/nodejs-java/manage-hyperlinks/) sont définis au niveau du texte (portion) à l'intérieur du cadre de texte de la cellule ou au niveau du tableau/forme entier. En pratique, vous affectez le lien à une portion ou à tout le texte de la cellule.

**Puis‑je définir des polices différentes au sein d'une même cellule ?**

Oui. Le cadre de texte d'une cellule prend en charge les [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (segments) avec un formatage indépendant — famille de police, style, taille et couleur.