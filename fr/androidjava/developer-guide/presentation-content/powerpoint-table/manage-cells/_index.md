---
title: Gérer les cellules de tableau dans les présentations sur Android
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/androidjava/manage-cells/
keywords:
- cellule de tableau
- fusionner les cellules
- supprimer la bordure
- diviser la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Gérer les cellules de tableau PowerPoint sur Android : identifier les cellules fusionnées, supprimer les bordures, diviser les cellules et définir les couleurs d'arrière-plan et les images avec Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'accéder aux cellules de tableau et de les modifier dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, travailler avec la numérotation des cellules après une fusion ou une division, changer la couleur d'arrière‑plan d’une cellule et ajouter une image à l’intérieur d’une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d’une diapositive, mettre à jour le format des cellules via leurs propriétés, puis enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices zéro‑based pour accéder aux cellules de tableau dans l’ordre `(column, row)`.

## **Identifier une cellule de tableau fusionnée**

L’exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est bien un tableau. Il parcourt ensuite toutes les lignes et colonnes et utilise [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) pour identifier les cellules dans des zones fusionnées. Pour chaque correspondance, il affiche les coordonnées de la cellule dans l’ordre `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), ainsi que les coordonnées de départ de la région, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) et [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Supprimer les bordures des cellules du tableau**

Créez une [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et ajoutez un tableau à sa première diapositive avec [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Les largeurs de colonnes, hauteurs de lignes et la position du tableau sont spécifiées en points. L’exemple définit les quatre bordures de chaque cellule sur [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), les rendant invisibles.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Fusionner des cellules de tableau**

Utilisez [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) pour combiner une plage rectangulaire de cellules en une seule cellule. Spécifiez les cellules aux coins supérieur‑gauche et inférieur‑droit de la plage. Le dernier argument contrôle si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `false` maintient la fusion à l’intérieur de cette plage.

L’exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante occupe deux colonnes et deux lignes, tandis que la grille sous‑jacente du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au format de la cellule fusionnée, utilisez sa position supérieure‑gauche : `table.get_Item(1, 1)` dans cet exemple. Les autres positions de la plage fusionnée restent partie de la grille du tableau, de sorte que les indices des cellules en dehors de la plage ne changent pas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diviser des cellules de tableau**

La fusion des cellules dans l’exemple précédent préserve la grille du tableau. Diviser une cellule peut introduire une nouvelle colonne de grille et modifier les indices de colonne des cellules situées à sa droite. Aspose.Slides suit le modèle de grille de tableau de PowerPoint.

Cet exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points et appelle [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est transmise pour créer deux cellules de largeur égale.

Après cette division, les deux moitiés sont accessibles via `table.get_Item(1, 1)` et `table.get_Item(2, 1)`. La grille du tableau comporte maintenant cinq colonnes : les cellules initialement situées dans les colonnes 2 et 3 se déplacent respectivement vers les colonnes 3 et 4. Les indices de ligne restent inchangés. Utilisez ces indices de colonne mis à jour lorsqu’il s’agit d’accéder aux cellules après la division.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Diviser les cellules fusionnées par étendue de ligne ou de colonne**

Pour préparer les cellules de modèle fusionnées à la population de données, utilisez [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) pour diviser le long d’une frontière de ligne existante, ou [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) pour diviser le long d’une frontière de colonne.

L’argument `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; il est relatif à la région fusionnée :

- Division de ligne : `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Division de colonne : `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

L’exemple part du principe qu’une présentation possède un tableau comme première forme de la première diapositive, avec les cellules `(1, 2)` et `(1, 3)` fusionnées verticalement. En partant de la position inférieure, il utilise [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) et [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) pour localiser l’origine et vérifie les deux étendues. `splitByRowSpan(1)` sépare ensuite les lignes 2 et 3 pour les noms de produit. Pour une fusion horizontale de deux colonnes, utilisez `splitByColSpan(1)` à la place.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Récupérer les cellules résultantes du tableau après la division.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont une étendue de 1 et [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) renvoie `false`. Des régions plus grandes peuvent rester partiellement fusionnées après une division.

Le texte original et son formatage demeurent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du format de la cellule (remplissage, bordures, marges). Remplissez les cellules après la division et définissez explicitement tout formatage de texte requis.

La présentation enregistrée contient des cellules distinctes « Product A » et « Product B » avec le formatage du modèle conservé. Consultez la [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) pour plus de détails.

## **Modifier la couleur d’arrière‑plan des cellules du tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il utilise [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) pour sélectionner un remplissage solide et définit la couleur renvoyée par [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) sur rouge pour la cellule `(2, 3)`, située dans la troisième colonne et la quatrième ligne.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter une image à l’intérieur d’une cellule de tableau**

Placez l’image d’entrée dans le répertoire de travail avant d’exécuter cet exemple. Elle charge l’image avec [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) et l’ajoute à la collection d’images de la présentation avec [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Elle assigne ensuite l’image au remplissage image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) étire l’image pour remplir la cellule, ce qui peut modifier son rapport d’aspect. Les largeurs de colonnes et hauteurs de lignes sont en points. L’image chargée est libérée dans un bloc `finally` après son ajout à la présentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis‑je définir des épaisseurs et des styles de ligne différents pour chaque côté d’une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) disposent de propriétés séparées, de sorte que l’épaisseur et le style de chaque côté peuvent différer.

**Que se passe‑t‑il pour l’image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Avec l’étirement, l’image s’ajuste à la nouvelle cellule ; avec le carrelage, les carreaux sont recalculés.

**Puis‑je affecter un hyperlien à tout le contenu d’une cellule ?**

Les [Hyperlinks](/slides/fr/androidjava/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre de texte de la cellule ou au niveau du tableau/la forme entière. En pratique, vous affectez le lien à une portion ou à tout le texte de la cellule.

**Puis‑je appliquer des polices différentes au sein d’une même cellule ?**

Oui. Le cadre de texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (runs) avec un formatage indépendant — famille, style, taille et couleur de police.