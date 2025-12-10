---
title: Gérer les cellules de tableau dans les présentations avec Java
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/java/manage-cells/
keywords:
- cellule de tableau
- fusionner des cellules
- supprimer la bordure
- scinder une cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Gérez facilement les cellules de tableau dans PowerPoint avec Aspose.Slides pour Java. Maîtrisez l'accès, la modification et le style des cellules rapidement pour une automatisation fluide des diapositives."
---

## **Identifier une cellule de tableau fusionnée**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenir le tableau de la première diapositive. 
3. Parcourir les lignes et colonnes du tableau pour trouver les cellules fusionnées.
4. Afficher un message lorsque des cellules fusionnées sont trouvées.

Ce code Java montre comment identifier les cellules de tableau fusionnées dans une présentation :
```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // en supposant que Slide#0.Shape#0 est un tableau
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Supprimer les bordures des cellules de tableau**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive par son index. 
3. Définir un tableau de colonnes avec largeur.
4. Définir un tableau de lignes avec hauteur.
5. Ajouter un tableau à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Parcourir chaque cellule pour effacer les bordures supérieure, inférieure, droite et gauche.
7. Enregistrer la présentation modifiée au format PPTX.

Ce code Java montre comment supprimer les bordures des cellules de tableau :
```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Ajoute la forme de tableau à la diapositive
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

    // Enregistre le PPTX sur le disque
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Numérotation dans les cellules fusionnées**
Si nous fusionnons 2 paires de cellules (1, 1) x (2, 1) et (1, 2) x (2, 2), le tableau résultant sera numéroté. Ce code Java montre le processus :
```java
// Instancie la classe Presentation qui représente un fichier PPTX
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

    // Fusionne les cellules (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Fusionne les cellules (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Fusionne les cellules (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	//Enregistre le fichier PPTX sur le disque
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Numérotation dans une cellule scindée**
Dans les exemples précédents, lorsque les cellules du tableau étaient fusionnées, la numérotation ou le système de numération des autres cellules ne changeait pas. 

Cette fois‑ci, nous prenons un tableau standard (un tableau sans cellules fusionnées) puis nous essayons de scinder la cellule (1,1) pour obtenir un tableau spécial. Vous voudrez peut‑être prêter attention à la numérotation de ce tableau, qui peut sembler étrange. Cependant, c’est ainsi que Microsoft PowerPoint numérote les cellules de tableau et Aspose.Slides fait de même. 

Ce code Java montre le processus décrit :
```java
// Instancie la classe Presentation qui représente un fichier PPTX
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

    // Fusionne les cellules (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Fusionne les cellules (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Scinde la cellule (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //Writes le fichier PPTX sur le disque
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier la couleur d'arrière‑plan d'une cellule de tableau**
Ce code Java montre comment changer la couleur d'arrière‑plan d'une cellule de tableau :
```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // crée une nouvelle table
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // définit la couleur d'arrière-plan d'une cellule
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Ajouter une image à l'intérieur d'une cellule de tableau**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive par son index.
3. Définir un tableau de colonnes avec largeur.
4. Définir un tableau de lignes avec hauteur.
5. Ajouter un tableau à la diapositive via la méthode [AddTable](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Créer un objet `Images` pour contenir le fichier image.
7. Ajouter l'image `IImage` à l'objet `IPPImage`.
8. Définir le `FillFormat` de la cellule de tableau sur `Picture`.
9. Ajouter l'image à la première cellule du tableau.
10. Enregistrer la présentation modifiée au format PPTX

Ce code Java montre comment placer une image à l'intérieur d'une cellule de tableau lors de la création d'un tableau :
```java
// Instancie la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide islide = pres.getSlides().get_Item(0);

    // Définit les colonnes avec leurs largeurs et les lignes avec leurs hauteurs
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Ajoute une forme de tableau à la diapositive
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Crée un objet IPPImage à partir du fichier image
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

    // Enregistre le fichier PPTX sur le disque
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis-je définir des épaisseurs et styles de ligne différents pour chaque côté d'une même cellule ?**  
Oui. Les bordures [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) possèdent des propriétés distinctes, de sorte que l'épaisseur et le style de chaque côté puissent différer. Cela découle logiquement du contrôle de bordure par côté d'une cellule présenté dans l'article.

**Que se passe-t-il avec l'image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**  
Le comportement dépend du [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile). En mode stretch, l'image s'ajuste à la nouvelle cellule ; en mode tile, les tuiles sont recalculées. L'article mentionne les modes d'affichage de l'image dans une cellule.

**Puis-je assigner un hyperlien à tout le contenu d'une cellule ?**  
Les [Hyperlinks](/slides/fr/java/manage-hyperlinks/) sont définis au niveau du texte (portion) à l'intérieur du cadre texte de la cellule ou au niveau de l'ensemble du tableau/forme. En pratique, vous attribuez le lien à une portion ou à tout le texte de la cellule.

**Puis-je définir différentes polices au sein d'une même cellule ?**  
Oui. Le cadre texte d'une cellule prend en charge les [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (runs) avec un formatage indépendant — famille de police, style, taille et couleur.