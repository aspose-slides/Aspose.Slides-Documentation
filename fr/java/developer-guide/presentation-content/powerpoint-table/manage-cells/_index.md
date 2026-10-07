---
title: Gérer les cellules de tableau dans les présentations avec Java
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/java/manage-cells/
keywords:
- cellule de tableau
- fusion de cellules
- supprimer la bordure
- diviser la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Gérer les cellules de tableau PowerPoint en Java : identifier les cellules fusionnées, supprimer les bordures, diviser les cellules et définir les couleurs d’arrière‑plan ainsi que les images avec Aspose.Slides pour Java."
---
## **Aperçu**

Aspose.Slides vous permet d'accéder aux cellules de tableau et de les modifier dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, gérer la numérotation des cellules après fusion ou division, changer la couleur d'arrière‑plan d’une cellule et ajouter une image à l’intérieur d’une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d’une diapositive, mettre à jour le formatage des cellules via les propriétés de la cellule, et enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices à base zéro pour accéder aux cellules de tableau dans l’ordre `(colonne, ligne)`.

## **Identifier une cellule de tableau fusionnée**

L’exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est un tableau. Il parcourt ensuite toutes les lignes et toutes les colonnes et utilise [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) pour identifier les cellules dans les régions fusionnées. Pour chaque correspondance, il affiche les coordonnées de la cellule dans l’ordre `row;column`, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--) et les coordonnées de départ de la région, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) et [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **Supprimer les bordures des cellules de tableau**

Créez une [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) et ajoutez un tableau à sa première diapositive avec [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Les largeurs de colonne, hauteurs de ligne et la position du tableau sont spécifiées en points. L’exemple définit les quatre bordures de la cellule sur [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), les rendant invisibles.

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

Utilisez [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) pour combiner une plage rectangulaire de cellules de tableau en une seule cellule. Spécifiez les cellules aux coins supérieur gauche et inférieur droit de la plage. Le dernier argument contrôle si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `false` maintient la fusion à l’intérieur de cette plage.

L’exemple crée un tableau de 4 × 4 avec des colonnes et lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante s’étend sur deux colonnes et deux lignes, tandis que la grille sous‑jacente du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au formatage de la cellule fusionnée, utilisez sa position en haut à gauche : `table.get_Item(1, 1)` dans cet exemple. Les autres positions de la plage fusionnée restent membres de la grille du tableau, ainsi les indices des cellules en dehors de la plage ne changent pas.

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

## **Diviser les cellules de tableau**

La fusion des cellules dans l’exemple précédent préserve la grille du tableau. Diviser une cellule peut introduire une nouvelle colonne dans la grille et modifier les indices de colonne des cellules situées à sa droite. Aspose.Slides suit le modèle de grille de tableau de PowerPoint.

Cet exemple crée un tableau de 4 × 4 avec des colonnes et lignes de 70 points et appelle [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est utilisée pour créer deux cellules de même largeur.

Après cette division, les deux moitiés sont accessibles via `table.get_Item(1, 1)` et `table.get_Item(2, 1)`. La grille du tableau comporte maintenant cinq colonnes : les cellules initialement dans les colonnes 2 et 3 passent aux colonnes 3 et 4, respectivement. Les indices de ligne restent inchangés. Utilisez ces indices de colonne mis à jour lors de l’accès aux cellules après la division.

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

Pour préparer les cellules de modèle fusionnées à la population de données, utilisez [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) pour diviser le long d’une frontière de ligne existante, ou [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) pour diviser le long d’une frontière de colonne.

La valeur `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; elle est relative à la région fusionnée :

- Division de ligne : `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Division de colonne : `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

L’exemple suppose qu’une présentation possède un tableau comme première forme de la première diapositive, avec `(1, 2)` et `(1, 3)` fusionnés verticalement. En commençant depuis la position inférieure, il utilise [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) et [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) pour localiser l’origine et vérifie les deux étendues. `splitByRowSpan(1)` sépare alors les lignes 2 et 3 pour les noms de produit. Pour une fusion horizontale sur deux colonnes, utilisez `splitByColSpan(1)` à la place.

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

        // Récupérer les cellules résultantes du tableau après division.
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

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont une étendue de 1 et [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) renvoie `false`. Des régions plus grandes peuvent rester partiellement fusionnées après une division.

Le texte original et son formatage restent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du formatage de la cellule comme le remplissage, les bordures et les marges. Remplissez les cellules après la division et définissez explicitement tout formatage de texte requis.

La présentation enregistrée contient des cellules distinctes « Product A » et « Product B » avec le formatage de cellule du modèle conservé. Consultez la [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) pour plus de détails.

## **Modifier la couleur d’arrière‑plan d’une cellule de tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il utilise [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) pour sélectionner un remplissage uni et définit la couleur renvoyée par [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) sur rouge pour la cellule `(2, 3)`, dans la troisième colonne et la quatrième ligne.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Placez l’image d’entrée dans le répertoire de travail avant d’exécuter cet exemple. Elle charge l’image avec [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) et l’ajoute à la collection d’images de la présentation avec [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Elle assigne ensuite l’image au remplissage image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) étire l’image pour remplir la cellule, ce qui peut modifier son rapport d’aspect. Les largeurs de colonne et les hauteurs de ligne sont en points. L’image chargée est libérée dans un bloc `finally` après son ajout à la présentation.

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

**Puis-je définir des épaisseurs et styles de ligne différents pour chaque côté d’une même cellule ?**

Oui. Les bordures [haut](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bas](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[gauche](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[droite](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) ont des propriétés séparées, de sorte que l’épaisseur et le style de chaque côté peuvent différer.

**Que se passe-t-il pour l’image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [mode de remplissage](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/). En mode étirement, l’image s’ajuste à la nouvelle cellule ; en mode répétition, les carreaux sont recalculés.

**Puis-je assigner un hyperlien à tout le contenu d’une cellule ?**

[Hyperliens](/slides/fr/java/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre de texte de la cellule ou au niveau de l’ensemble du tableau/forme. En pratique, vous assignez le lien à une portion ou à tout le texte de la cellule.

**Puis-je définir différentes polices au sein d’une même cellule ?**

Oui. Le cadre de texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (segments) avec un formatage indépendant — famille de police, style, taille et couleur.