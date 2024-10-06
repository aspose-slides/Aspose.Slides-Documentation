---
title: Gérer les cellules
type: docs
weight: 30
url: /python-net/manage-cells/
keywords: "Table, cellules fusionnées, cellules divisées, image dans cellule de table, Python, Aspose.Slides pour Python via .NET"
description: "Cellules de table dans des présentations PowerPoint en Python"
---

## **Identifier la cellule de table fusionnée**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la table à partir de la première diapositive. 
3. Parcourez les lignes et les colonnes de la table pour trouver les cellules fusionnées.
4. Imprimez un message lorsque des cellules fusionnées sont trouvées.

Ce code Python vous montre comment identifier les cellules de table fusionnées dans une présentation :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "SomePresentationWithTable.pptx") as pres:
    table = pres.slides[0].shapes[0] # en supposant que #0.Shape#0 est une table
    for i in range(len(table.rows)):
        for j in range(len(table.columns)):
            currentCell = table.rows[i][j]
            if currentCell.is_merged_cell:
                print("La cellule 01 fait partie d'une cellule fusionnée avec RowSpan=2 et ColSpan=3 à partir de la cellule 45.".format(
                    i, j, currentCell.row_span, currentCell.col_span, currentCell.first_row_index, currentCell.first_column_index))
```

## **Supprimer la bordure des cellules de table**
1. Créez une instance de la classe `Presentation`.
2. Obtenez une référence à une diapositive via son index. 
3. Définissez un tableau de colonnes avec des largeurs.
4. Définissez un tableau de lignes avec des hauteurs.
5. Ajoutez une table à la diapositive via la méthode `AddTable`.
6. Parcourez chaque cellule pour effacer les bordures supérieure, inférieure, droite et gauche.
7. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Python vous montre comment supprimer les bordures des cellules de table :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier PPTX
with slides.Presentation() as pres:
   # Accède à la première diapositive
    sld = pres.slides[0]

    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    dblCols = [ 50, 50, 50, 50 ]
    dblRows = [ 50, 30, 30, 30, 30 ]

    # Ajoute une forme de tableau à la diapositive
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Définit le format de bordure pour chaque cellule
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Écrit le fichier PPTX sur le disque
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Numérotation dans les cellules fusionnées**
Si nous fusionnons 2 paires de cellules (1, 1) x (2, 1) et (1, 2) x (2, 2), la table résultante sera numérotée. Ce code Python démontre le processus :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier PPTX
with slides.Presentation() as presentation:
    # Accède à la première diapositive
    sld = presentation.slides[0]

    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Ajoute une forme de tableau à la diapositive
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Définit le format de bordure pour chaque cellule
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Fusionne les cellules (1, 1) x (2, 1)
    tbl.merge_cells(tbl.rows[1][1], tbl.rows[2][1], False)

    # Fusionne les cellules (1, 2) x (2, 2)
    tbl.merge_cells(tbl.rows[1][2], tbl.rows[2][2], False)

    presentation.save("MergeCells_out.pptx", slides.export.SaveFormat.PPTX)
```

Nous fusionnons ensuite les cellules en fusionnant (1, 1) et (1, 2). Le résultat est une table contenant une grande cellule fusionnée au centre :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier PPTX
with slides.Presentation() as presentation:
    # Accède à la première diapositive
    slide = presentation.slides[0]

    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70]

    # Ajoute une forme de tableau à la diapositive
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Définit le format de bordure pour chaque cellule
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Fusionne les cellules (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Fusionne les cellules (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Fusionne les cellules (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][1], table.rows[1][2], True)

    # Écrit le fichier PPTX sur disque
    presentation.save("MergeCells1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Numérotation dans une cellule divisée**
Dans les exemples précédents, lorsque les cellules de table ont été fusionnées, la numération ou le système numérique dans d'autres cellules n'a pas changé.

Cette fois, nous prenons une table régulière (une table sans cellules fusionnées) et essayons de diviser la cellule (1,1) pour obtenir une table spéciale. Vous voudrez peut-être prêter attention à la numérotation de cette table, qui peut sembler étrange. Cependant, c'est ainsi que Microsoft PowerPoint numérote les cellules de table et Aspose.Slides fait la même chose.

Ce code Python démontre le processus que nous avons décrit :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier PPTX
with slides.Presentation() as presentation:
    # Accède à la première diapositive
    slide = presentation.slides[0]

    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Ajoute une forme de tableau à la diapositive
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Définit le format de bordure pour chaque cellule
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Fusionne les cellules (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Fusionne les cellules (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Divise la cellule (1, 1). 
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Écrit le fichier PPTX sur disque
    presentation.save("CellSplit_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Changer la couleur d'arrière-plan de la cellule de table**

Ce code Python vous montre comment changer la couleur d'arrière-plan d'une cellule de table :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    dblCols = [ 150, 150, 150, 150 ]
    dblRows = [ 50, 50, 50, 50, 50 ]

    # crée une nouvelle table
    table = slide.shapes.add_table(50, 50, dblCols, dblRows)

    # définit la couleur d'arrière-plan pour une cellule 
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter une image à l'intérieur d'une cellule de table**
1. Créez une instance de la classe `Presentation`.
2. Obtenez une référence à une diapositive via son index.
3. Définissez un tableau de colonnes avec une largeur.
4. Définissez un tableau de lignes avec une hauteur.
5. Ajoutez une table à la diapositive via la méthode `AddTable`. 
6. Créez un objet `Bitmap` pour contenir le fichier image.
7. Ajoutez l'image bitmap à l'objet `IPPImage`.
8. Définissez le `FillFormat` pour la cellule de table sur `Picture`.
9. Ajoutez l'image à la première cellule de la table.
10. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Python vous montre comment placer une image à l'intérieur d'une cellule de table lors de la création d'une table :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancie un objet de classe Presentation
with slides.Presentation() as presentation:
    # Accède à la première diapositive
    islide = presentation.slides[0]

    # Définit les colonnes avec des largeurs et les lignes avec des hauteurs
    dblCols =  [150, 150, 150, 150] 
    dblRows =  [100, 100, 100, 100, 90] 

    # Ajoute une forme de tableau à la diapositive
    tbl = islide.shapes.add_table(50, 50, dblCols, dblRows)

    # Crée un objet Image Bitmap pour contenir le fichier image
    image = draw.Bitmap(path + "aspose-logo.jpg")

    # Crée un objet IPPImage en utilisant l'objet bitmap
    imgx1 = presentation.images.add_image(image)

    # Ajoute l'image à la première cellule de la table
    tbl.rows[0][0].cell_format.fill_format.fill_type = slides.FillType.PICTURE
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture.image = imgx1

    # Enregistre le PPTX sur disque
    presentation.save("Image_In_TableCell_out.pptx", slides.export.SaveFormat.PPTX)
```