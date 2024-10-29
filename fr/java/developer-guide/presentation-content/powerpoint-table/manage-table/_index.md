---
title: Gérer le Tableau
type: docs
weight: 10
url: /fr/java/manage-table/
keywords: "Table, créer un tableau, accéder au tableau, rapport d'aspect du tableau, présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Créer et gérer des tableaux dans des présentations PowerPoint en Java"
---

Un tableau dans PowerPoint est un moyen efficace d'afficher et de représenter des informations. Les informations dans une grille de cellules (organisées en lignes et en colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table), l'interface [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable), la classe [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) , l'interface [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) et d'autres types pour vous permettre de créer, mettre à jour et gérer des tableaux dans tous les types de présentations.

## **Créer un Tableau à Partir de Rien**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Itérez à travers chaque [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) pour appliquer le formatage aux bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne du tableau.
8. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) d'un [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/).
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

Ce code Java vous montre comment créer un tableau dans une présentation :

```java
// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Définit les colonnes avec des largeurs et les lignes avec des hauteurs
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
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Ajoute du texte à la cellule fusionnée
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Cellules Fusionnées");

    // Enregistre la présentation sur le disque
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numérotation dans un Tableau Standard**

Dans un tableau standard, la numérotation des cellules est simple et commence à zéro. La première cellule d'un tableau est indexée comme 0,0 (colonne 0, ligne 0).

Par exemple, les cellules dans un tableau de 4 colonnes et 4 lignes sont numérotées de cette manière :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code Java vous montre comment spécifier la numérotation des cellules dans un tableau :

```java
// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Définit les colonnes avec des largeurs et les lignes avec des hauteurs
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

## **Accéder à un Tableau Existant**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).

2. Obtenez une référence à la diapositive contenant le tableau par son index.

3. Créez un objet [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) et définissez-le sur null.

4. Itérez à travers tous les objets [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) jusqu'à ce que le tableau soit trouvé.

   Si vous suspectez que la diapositive avec laquelle vous traitez contient un seul tableau, vous pouvez simplement vérifier toutes les formes qu'elle contient. Lorsqu'une forme est identifiée comme un tableau, vous pouvez la convertir en un objet [Table](https://reference.aspose.com/slides/java/com.aspose.slides/Table). Mais si la diapositive avec laquelle vous traitez contient plusieurs tableaux, il est préférable de rechercher le tableau dont vous avez besoin par son [setAlternativeText(String value)](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Utilisez l'objet [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) pour travailler avec le tableau. Dans l'exemple ci-dessous, nous avons ajouté une nouvelle ligne au tableau.

6. Enregistrez la présentation modifiée.

Ce code Java vous montre comment accéder et travailler avec un tableau existant :

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialise un TableEx null
    ITable tbl = null;

    // Itère à travers les formes et définit une référence au tableau trouvé
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Définit le texte pour la première colonne de la deuxième ligne
            tbl.get_Item(0, 1).getTextFrame().setText("Nouveau");
        }
    }
    
    // Enregistre la présentation modifiée sur le disque
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Aligner le Texte dans le Tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) à la diapositive.
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) à partir du tableau.
5. Accédez à l'[ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/).
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

Ce code Java vous montre comment aligner le texte dans un tableau :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Ajoute la forme de tableau à la diapositive
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Accède à l'élément texte
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Crée l'objet Paragraph pour l'élément texte
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Crée l'objet Portion pour le paragraphe
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Texte ici");
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

## **Définir la Mise en Forme du Texte au Niveau du Tableau**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive par son index.
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/ITable) à partir de la diapositive.
4. Définissez le [setFontHeight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pour le texte.
5. Définissez le [setAlignment(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) et [setMarginRight(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Définissez le [setTextVerticalType(byte value)](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Enregistrez la présentation modifiée.

Ce code Java vous montre comment appliquer vos préférences de formatage au texte d'un tableau :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Supposons que la première forme sur la première diapositive soit un tableau
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Définit la hauteur de police des cellules du tableau
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Définit l'alignement du texte des cellules du tableau et la marge droite en une seule étape
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Définit le type de texte vertical des cellules du tableau
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les Propriétés de Style du Tableau**

Aspose.Slides vous permet de récupérer les propriétés de style d'un tableau afin que vous puissiez utiliser ces détails pour un autre tableau ou ailleurs. Ce code Java vous montre comment obtenir les propriétés de style d'un style de tableau prédéfini :

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // change le style prédéfini par défaut
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verrouiller le Rapport d'Aspect du Tableau**

Le rapport d'aspect d'une forme géométrique est le rapport de ses tailles dans différentes dimensions. Aspose.Slides fournit la propriété [**setAspectRatioLocked**](https://reference.aspose.com/slides/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) pour vous permettre de verrouiller le paramètre de rapport d'aspect pour les tableaux et d'autres formes.

Ce code Java vous montre comment verrouiller le rapport d'aspect pour un tableau :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Verrouillage du rapport d'aspect défini : " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // inverser

    System.out.println("Verrouillage du rapport d'aspect défini : " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```