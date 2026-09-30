---
title: Gérer les tableaux de présentation en JavaScript
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/nodejs-java/manage-table/
keywords:
- ajouter un tableau
- créer un tableau
- accéder au tableau
- rapport d'aspect
- aligner le texte
- formatage du texte
- style de tableau
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer et modifier des tableaux dans les diapositives PowerPoint avec JavaScript et Aspose.Slides pour Node.js. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tableau."
---
## **Introduction**

Les tableaux dans PowerPoint organisent les informations en lignes et colonnes, facilitant la lecture et la comparaison des valeurs.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , la classe [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) , ainsi que d'autres types pour vous permettre de créer, mettre à jour et gérer les tableaux dans les présentations.

## **Créer un tableau à partir de zéro**

Créez un tableau en spécifiant sa position, la largeur des colonnes et la hauteur des lignes. Après l'avoir ajouté à une diapositive, vous pouvez formater les bordures des cellules, fusionner des cellules et insérer du texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Définissez un tableau des largeurs de colonnes en points.
4. Définissez un tableau des hauteurs de lignes en points.
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-).
6. Parcourez chaque [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez à la cellule fusionnée via sa méthode [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--).
9. Définissez le texte dans la cellule fusionnée.
10. Enregistrez la présentation modifiée.

L'exemple ci-dessous crée un tableau avec trois colonnes et cinq lignes aux coordonnées (100, 50) points. Il applique des bordures rouges d'une largeur de 5 points, fusionne les deux premières cellules de la première ligne et enregistre le résultat sous le nom `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numérotation dans un tableau standard**

Dans un tableau standard, les index des cellules commencent à zéro et utilisent l'ordre (colonne, ligne). La première cellule a l'index (0, 0).

Par exemple, les cellules d'un tableau de 4 colonnes et 4 lignes sont numérotées de cette façon :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Cet exemple crée le tableau 4 × 4 illustré ci‑dessus, avec des largeurs de colonnes et des hauteurs de lignes de 70 points ainsi que des bordures de cellules rouges d'une largeur de 5 points. Les coordonnées illustrent les index des cellules ; l'exemple laisse les cellules vides et enregistre le tableau sous le nom `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accéder à un tableau existant**

Les tableaux sont stockés dans la collection de formes d'une diapositive. Parcourez les formes pour localiser un tableau, puis utilisez la classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) pour lire ou mettre à jour ses cellules.

1. Chargez la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive contenant le tableau par son index.
3. Parcourez les objets [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) et arrêtez‑vous lorsqu'un tableau est trouvé. Si la diapositive contient plusieurs tableaux, utilisez [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) pour identifier celui dont vous avez besoin.
4. Mettez à jour le texte dans la cellule cible.
5. Enregistrez la présentation modifiée.

L'exemple ci‑dessus ouvre `UpdateExistingTable.pptx` et trouve le premier tableau de la première diapositive. Il définit la cellule à la colonne 0, ligne 1 à `New` et enregistre le résultat sous le nom `table1_out.pptx`. L'entrée doit contenir au moins une diapositive, et le premier tableau de cette diapositive doit comporter au moins une colonne et deux lignes.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Pour redimensionner une ligne dans un tableau existant et comprendre pourquoi sa hauteur réelle peut dépasser le minimum demandé, consultez [Contrôler la hauteur des lignes](/slides/fr/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Trouver la cellule qui possède un cadre de texte**

Lorsque du code générique de traitement de texte reçoit un [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) d'un tableau, utilisez la méthode [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) pour récupérer la [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) propriétaire. Pour un cadre de texte d'une cellule de tableau, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) renvoie le propriétaire et [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) renvoie `null`, même si le tableau lui‑même est une forme.

Les coordonnées de la cellule sont accessibles via les méthodes en lecture seule [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) et [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) fournit également une navigation en lecture seule : elle renvoie le propriétaire mais ne modifie pas la propriété. Vérifiez toujours que la cellule renvoyée n'est pas `null` avant de l'utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, consultez [Rechercher et remplacer du texte](/slides/fr/nodejs-java/search-and-replace-text/).

## **Aligner le texte dans un tableau**

Vous pouvez contrôler l'ancrage vertical et la direction du texte des cellules individuelles d'un tableau. L'exemple de cette section centre le texte dans la première cellule et le fait pivoter de 270 degrés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) à la diapositive.
4. Accédez à un objet [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) du tableau.
5. Accédez au premier [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) et définissez son texte et sa couleur.
6. Définissez l'ancrage vertical de la cellule et la direction du texte à l'aide de [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) et [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Enregistrez la présentation modifiée.

Cet exemple crée un tableau 4 × 4 avec des largeurs de colonnes de 120 points et des hauteurs de lignes de 100 points. Il met en forme le texte de la cellule (0, 0), ajoute des valeurs aux cellules restantes de la première ligne et enregistre le résultat sous le nom `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir le formatage du texte au niveau du tableau**

Utilisez [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) pour appliquer le formatage du texte à toutes les cellules d'un tableau. Ses surcharges acceptent le formatage de la portion, du paragraphe et du cadre de texte, ce qui vous permet de définir ces propriétés sans parcourir chaque cellule.

1. Chargez la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Accédez à un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) de la diapositive.
4. Définissez la taille de la police en utilisant [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) pour le texte.
5. Définissez l'alignement du paragraphe et la marge droite à l'aide de [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) et [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Définissez la direction du texte à l'aide de [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Enregistrez la présentation modifiée.

L'exemple ci‑dessous ouvre `table.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il définit la taille de la police à 25 points, aligne les paragraphes à droite avec une marge droite de 20 points et rend le texte vertical. La présentation formatée est enregistrée sous le nom `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtenir les propriétés du style de tableau**

Utilisez [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) pour lire le style prédéfini d'un tableau et [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) pour l'attribuer. Cet exemple applique [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) à un tableau, affiche la valeur du style, et attribue le même style à un second tableau. Les deux tableaux sont enregistrés dans `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verrouiller le rapport d'aspect d'un tableau**

Le rapport d'aspect d'un tableau est le rapport entre sa largeur et sa hauteur. Utilisez [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) pour verrouiller ce rapport pour un tableau.

L'exemple ci‑dessus ouvre `pres.pptx`, qui doit contenir au moins une diapositive avec un tableau comme première forme. Il affiche l'état de verrouillage actuel, active le verrouillage du rapport d'aspect, affiche l'état mis à jour (`true`), et enregistre le résultat sous le nom `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis-je activer la direction de lecture de droite à gauche (RTL) pour un tableau entier et le texte dans ses cellules ?**

Oui. Le tableau expose une méthode [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-), et les paragraphes possèdent [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Utiliser les deux garantit le bon ordre RTL et le rendu correct à l'intérieur des cellules.

**Comment puis‑je empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les [verrous de forme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s'appliquent également aux tableaux.

**L'insertion d'une image à l'intérieur d'une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [remplissage d'image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) pour une cellule ; l'image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).