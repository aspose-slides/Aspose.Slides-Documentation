---
title: Gérer les cellules
type: docs
weight: 30
url: /androidjava/manage-cells/
keywords: "Table, cellules fusionnées, cellules divisées, image dans une cellule de tableau, Java, Aspose.Slides pour Android via Java"
description: "Cellules de tableau dans les présentations PowerPoint en Java"
---


## **Identifier les cellules de tableau fusionnées**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenir le tableau à partir de la première diapositive.
3. Itérer à travers les lignes et colonnes du tableau pour trouver les cellules fusionnées.
4. Imprimer un message lorsque des cellules fusionnées sont trouvées.

Ce code Java vous montre comment identifier les cellules de tableau fusionnées dans une présentation :

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // supposant que Slide#0.Shape#0 est un tableau
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("La cellule %d;%d fait partie de la cellule fusionnée avec RowSpan=%d et ColSpan=%d commençant à partir de la cellule %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Supprimer les bordures des cellules de tableau**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence de diapositive via son index.
3. Définir un tableau de colonnes avec largeur.
4. Définir un tableau de lignes avec hauteur.
5. Ajouter un tableau à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Itérer à travers chaque cellule pour effacer les bordures haut, bas, droite et gauche.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java vous montre comment supprimer les bordures des cellules de tableau :

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Ajoute une forme de tableau à la diapositive
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Définit le format de bordure pour chaque cellule
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Écrit le PPTX sur disque
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numérotation dans les cellules fusionnées**
Si nous fusionnons 2 paires de cellules (1, 1) x (2, 1) et (1, 2) x (2, 2), le tableau résultant sera numéroté. Ce code Java démontre le processus :

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
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

    // Fusionne les cellules (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Fusionne les cellules (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Nous fusionnons ensuite les cellules davantage en fusionnant (1, 1) et (1, 2). Le résultat est un tableau contenant une grande cellule fusionnée au centre :

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
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

    // Fusionne les cellules (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Fusionne les cellules (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Fusionne les cellules (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	//Écrit le fichier PPTX sur disque
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numérotation dans une cellule divisée**
Dans les exemples précédents, lorsque les cellules de tableau étaient fusionnées, la numérotation ou le système de numérotation dans d'autres cellules ne changeait pas.

Cette fois, nous prenons un tableau régulier (un tableau sans cellules fusionnées) et essayons ensuite de diviser la cellule (1,1) pour obtenir un tableau spécial. Vous voudrez peut-être prêter attention à la numérotation de ce tableau, qui peut être considérée comme étrange. Cependant, c'est ainsi que Microsoft PowerPoint numérote les cellules de tableau et Aspose.Slides fait la même chose.

Ce code Java démontre le processus que nous avons décrit :

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
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

    // Fusionne les cellules (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Fusionne les cellules (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Divise la cellule (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //Écrit le fichier PPTX sur disque
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Changer la couleur de fond d'une cellule de tableau**

Ce code Java vous montre comment changer la couleur de fond d'une cellule de tableau :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // crée un nouveau tableau
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // définit la couleur de fond pour une cellule 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ajouter une image à l'intérieur d'une cellule de tableau**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence de diapositive via son index.
3. Définir un tableau de colonnes avec largeur.
4. Définir un tableau de lignes avec hauteur.
5. Ajouter un tableau à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Créez un objet `Images` pour contenir le fichier image.
7. Ajoutez l'image `IImage` à l'objet `IPPImage`.
8. Définissez le `FillFormat` pour la cellule de tableau sur `Picture`.
9. Ajoutez l'image à la première cellule du tableau.
10. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java vous montre comment placer une image à l'intérieur d'une cellule de tableau lors de la création d'un tableau :

```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide islide = pres.getSlides().get_Item(0);

    // Définit les colonnes avec largeurs et les lignes avec hauteurs
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Ajoute une forme de tableau à la diapositive
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Crée un objet IPPImage en utilisant le fichier image
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ajoute l'image à la première cellule du tableau
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Sauvegarde le fichier PPTX sur disque
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```