---
title: Gestion des tables de présentation en Java
linktitle: Gérer le tableau
type: docs
weight: 10
url: /fr/java/manage-table/
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
- Java
- Aspose.Slides
description: "Créer et modifier des tableaux dans les diapositives PowerPoint avec Aspose.Slides pour Java. Découvrez des exemples de code simples pour rationaliser vos flux de travail de tableau."
---
## **Introduction**

Un tableau dans PowerPoint est un moyen efficace d'afficher et de présenter des informations. Les informations dans une grille de cellules (organisées en lignes et colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Table), l'interface [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITable), la classe [Cell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/cell/) , l'interface [ICell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icell/) et d'autres types pour vous permettre de créer, mettre à jour et gérer des tableaux dans toutes sortes de présentations. 

## **Créer un tableau à partir de zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive à l’aide de son index. 
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Parcourez chaque [ICell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau. 
8. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/) d'un [ICell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icell/). 
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

Ce code Java vous montre comment créer un tableau dans une présentation:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Ajoute une forme de tableau à la diapositive
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Définit le format de bordure pour chaque cellule
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Fusionne les cellules 1 et 2 de la ligne 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Ajoute du texte à la cellule fusionnée
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Enregistre la présentation sur le disque
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numérotation dans un tableau standard**

Dans un tableau standard, la numérotation des cellules est simple et commence à zéro. La première cellule d’un tableau est indexée à 0,0 (colonne 0, ligne 0). 

Par exemple, les cellules d’un tableau de 4 colonnes et 4 lignes sont numérotées de la façon suivante:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code Java vous montre comment spécifier la numérotation des cellules dans un tableau:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Ajoute une forme de tableau à la diapositive
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Définit le format de bordure pour chaque cellule
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Enregistre la présentation sur le disque
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Accéder à un tableau existant**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).

2. Obtenez une référence à la diapositive contenant le tableau à l’aide de son index. 

3. Créez un objet [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITable) et initialisez-le à null.

4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) jusqu’à ce que le tableau soit trouvé.

   Si vous pensez que la diapositive que vous traitez ne contient qu’un seul tableau, vous pouvez simplement vérifier toutes les formes qu’elle contient. Lorsqu’une forme est identifiée comme un tableau, vous pouvez la convertir en objet [Table](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Table). Mais si la diapositive contient plusieurs tableaux, il est préférable de rechercher le tableau souhaité via son [setAlternativeText(String value)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Utilisez l'objet [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITable) pour travailler avec le tableau. Dans l'exemple ci‑dessous, nous avons ajouté une nouvelle ligne au tableau.

6. Enregistrez la présentation modifiée.

Ce code Java vous montre comment accéder à un tableau existant et le manipuler:

```java
import com.aspose.slides.*;

// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialise la TableEx à null
    ITable tbl = null;

    // Parcourt les formes et définit une référence vers le tableau trouvé
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Définit le texte pour la première colonne de la deuxième ligne
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Enregistre la présentation modifiée sur le disque
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Trouver la cellule qui possède un cadre de texte**

Lorsque du code générique de traitement du texte reçoit un [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) d’un tableau, utilisez la méthode [ITextFrame.getParentCell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentCell--) pour récupérer le [ICell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icell/) propriétaire. Pour un cadre de texte d’une cellule de tableau, [ITextFrame.getParentCell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentCell--) renvoie le propriétaire et [ITextFrame.getParentShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentShape--) renvoie `null`, bien que le tableau lui‑même soit une forme.

Les coordonnées de la cellule sont accessibles via les méthodes en lecture seule [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icell/#getFirstColumnIndex--) et [ICell.getFirstRowIndex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icell/#getFirstRowIndex--). [ITextFrame.getParentCell](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#getParentCell--) fournit également une navigation en lecture seule : elle renvoie le propriétaire mais ne modifie pas la propriété. Vérifiez toujours que la cellule renvoyée n’est pas `null` avant de l’utiliser.

Pour un exemple complet qui identifie les propriétaires de cellules de tableau et de formes, y compris les formes associées aux nœuds SmartArt, voir [Search and Replace Text](/slides/fr/java/search-and-replace-text/).

## **Aligner le texte dans un tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive à l’aide de son index. 
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITable) à la diapositive. 
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) du tableau. 
5. Accédez au [IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/) du [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/).
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

Ce code Java vous montre comment aligner le texte dans un tableau:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Ajoute la forme de tableau à la diapositive
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Accède au cadre de texte
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Crée l'objet Paragraph pour le cadre de texte
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Crée l'objet Portion pour le paragraphe
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Aligne le texte verticalement
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Enregistre la présentation sur le disque
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir le format du texte au niveau du tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive à l’aide de son index. 
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ITable) depuis la diapositive.
4. Définissez le [setFontHeight(float value)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour le texte. 
5. Définissez le [setAlignment(int value)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) et le [setMarginRight(float value)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Définissez le [setTextVerticalType(byte value)](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Enregistrez la présentation modifiée. 

Ce code Java vous montre comment appliquer vos options de formatage préférées au texte d’un tableau:

```java
import com.aspose.slides.*;

// Crée une instance de la classe Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Supposons que la première forme de la première diapositive soit un tableau
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Définit la hauteur de police des cellules du tableau
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Définit l'alignement du texte des cellules du tableau et la marge droite en un seul appel
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Définit le type vertical du texte des cellules du tableau
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les propriétés de style du tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d’un tableau afin de les utiliser pour un autre tableau ou ailleurs. Ce code Java vous montre comment obtenir les propriétés de style d’un style de tableau prédéfini:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // modifie le thème de style prédéfini par défaut 

    // Obtient le style prédéfini du tableau
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Applique le style prédéfini récupéré à un autre tableau
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verrouiller le taux d’aspect d’un tableau**

Le taux d’aspect d’une forme géométrique est le rapport de ses dimensions. Aspose.Slides fournit la propriété [**setAspectRatioLocked**](https://reference.aspose.com/slides/fr/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) pour vous permettre de verrouiller le réglage du taux d’aspect pour les tableaux et autres formes. 

Ce code Java vous montre comment verrouiller le taux d’aspect pour un tableau:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // inverser

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**

Oui. Le tableau expose une méthode [setRightToLeft](https://reference.aspose.com/slides/fr/java/com.aspose.slides/table/#setRightToLeft-boolean-), et les paragraphes possèdent [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). L’utilisation des deux garantit le bon ordre RTL et le rendu correct à l’intérieur des cellules.

**How can I prevent users from moving or resizing a table in the final file?**

Utilisez les [shape locks](/slides/fr/java/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tableaux.

**Is inserting an image inside a cell as a background supported?**

Oui. Vous pouvez définir un [picture fill](https://reference.aspose.com/slides/fr/java/com.aspose.slides/picturefillformat/) pour une cellule ; l’image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).