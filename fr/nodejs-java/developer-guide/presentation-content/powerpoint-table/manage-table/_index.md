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
- mise en forme du texte
- style de tableau
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer et modifier des tableaux dans les diapositives PowerPoint avec JavaScript et Aspose.Slides pour Node.js. Découvrez des exemples de code simples pour simplifier vos flux de travail de tableaux."
---

Un tableau dans PowerPoint est un moyen efficace d'afficher et de présenter des informations. Les informations disposées dans une grille de cellules (organisées en lignes et colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table), la classe [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) et d'autres types pour vous permettre de créer, mettre à jour et gérer des tableaux dans tous types de présentations.

## **Créer un tableau à partir de zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Définissez un tableau `columnWidth`.  
4. Définissez un tableau `rowHeight`.  
5. Ajoutez un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) à la diapositive en utilisant la méthode [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).  
6. Parcourez chaque [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.  
7. Fusionnez les deux premières cellules de la première ligne du tableau.  
8. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) d’une [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/).  
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).  
10. Enregistrez la présentation modifiée.

Ce code JavaScript vous montre comment créer un tableau dans une présentation :
```javascript
// Instancie une classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Ajoute une forme de tableau à la diapositive
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Définit le format de bordure pour chaque cellule
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Fusionne les cellules 1 et 2 de la ligne 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Ajoute du texte à la cellule fusionnée
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Enregistre la présentation sur le disque
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Numérotation dans un tableau standard**

Dans un tableau standard, la numérotation des cellules est simple et commence à zéro. La première cellule d’un tableau est indexée 0,0 (colonne 0, ligne 0).

Par exemple, les cellules d’un tableau de 4 colonnes et 4 lignes sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code JavaScript vous montre comment spécifier la numérotation des cellules dans un tableau :
```javascript
// Instancie une classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Ajoute une forme de tableau à la diapositive
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Définit le format de bordure pour chaque cellule
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Enregistre la présentation sur le disque
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Accéder à un tableau existant**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  

2. Obtenez la référence de la diapositive contenant le tableau via son index.  

3. Créez un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) et initialisez‑le à null.  

4. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) jusqu’à ce que le tableau soit trouvé.  

   Si vous pensez que la diapositive que vous traitez ne contient qu’un seul tableau, vous pouvez simplement vérifier toutes les formes qu’elle contient. Lorsqu’une forme est identifiée comme un tableau, vous pouvez la convertir en objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table). Mais si la diapositive contient plusieurs tableaux, il vaut mieux rechercher le tableau souhaité via sa méthode [setAlternativeText(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).  

5. Utilisez l’objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) pour travailler avec le tableau. Dans l’exemple ci‑dessous, nous avons ajouté une nouvelle ligne au tableau.  

6. Enregistrez la présentation modifiée.

Ce code JavaScript vous montre comment accéder à un tableau existant et le manipuler :
```javascript
// Instancie la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Accède à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Initialise TableEx à null
    var tbl = null;
    // Parcourt les formes et définit une référence vers le tableau trouvé
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Définit le texte pour la première colonne de la deuxième ligne
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Enregistre la présentation modifiée sur le disque
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Aligner le texte dans un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) à la diapositive.  
4. Accédez à un objet [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) depuis le tableau.  
5. Accédez au [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) du [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).  
6. Alignez le texte verticalement.  
7. Enregistrez la présentation modifiée.

Ce code JavaScript vous montre comment aligner le texte dans un tableau :
```javascript
// Crée une instance de la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Récupère la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Ajoute la forme de tableau à la diapositive
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Accède au cadre de texte
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Crée l'objet Paragraph pour le cadre de texte
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Crée l'objet Portion pour le paragraphe
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Aligne le texte verticalement
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Enregistre la présentation sur le disque
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir le formatage du texte au niveau du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Accédez à un objet [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Table) depuis la diapositive.  
4. Définissez la hauteur de police avec [setFontHeight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Définissez l’alignement avec [setAlignment(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) et la marge droite avec [setMarginRight(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Définissez le type de texte vertical avec [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Enregistrez la présentation modifiée.

Ce code JavaScript vous montre comment appliquer vos options de formatage préférées au texte d’un tableau :
```javascript
// Crée une instance de la classe Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Supposons que la première forme de la première diapositive soit un tableau
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Définit la hauteur de police des cellules du tableau
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Définit l'alignement du texte des cellules du tableau et la marge droite en un seul appel
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Définit le type de texte vertical des cellules du tableau
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d’un tableau afin que vous puissiez réutiliser ces détails pour un autre tableau ou ailleurs. Ce code JavaScript vous montre comment obtenir les propriétés de style à partir d’un style de tableau prédéfini :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// modifier le thème de style prédéfini par défaut
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Verrouiller le rapport d’aspect d’un tableau**

Le rapport d’aspect d’une forme géométrique est le rapport de ses dimensions dans différents axes. Aspose.Slides fournit la propriété [**setAspectRatioLocked**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) pour vous permettre de verrouiller le réglage du rapport d’aspect des tableaux et d’autres formes.

Ce code JavaScript vous montre comment verrouiller le rapport d’aspect d’un tableau :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// inverser
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis‑je activer la direction de lecture de droite à gauche (RTL) pour l’ensemble d’un tableau et le texte de ses cellules ?**

Oui. Le tableau expose la méthode [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/setrighttoleft/), et les paragraphes ont [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). L’utilisation des deux assure le bon ordre RTL et le rendu à l’intérieur des cellules.

**Comment empêcher les utilisateurs de déplacer ou de redimensionner un tableau dans le fichier final ?**

Utilisez les verrous de forme pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tableaux.

**L’insertion d’une image à l’intérieur d’une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) pour une cellule ; l’image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).