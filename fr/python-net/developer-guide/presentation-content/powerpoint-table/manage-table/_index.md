---
title: Gérer la Table
type: docs
weight: 10
url: /python-net/manage-table/
keywords: "Table, créer une table, accéder à la table, rapport d'aspect de la table, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Créer et gérer une table dans des présentations PowerPoint en Python"

---

Une table dans PowerPoint est un moyen efficace d'afficher et de représenter des informations. Les informations dans une grille de cellules (disposées en lignes et en colonnes) sont simples et faciles à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), l'interface [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/), la classe [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/), l'interface [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) et d'autres types pour vous permettre de créer, mettre à jour et gérer des tables dans tous types de présentations.

## **Créer une Table de Zéro**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive via son index.
3. Définissez un tableau de `columnWidth`.
4. Définissez un tableau de `rowHeight`.
5. Ajoutez un objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) à la diapositive via la méthode `add_table(x, y, column_widths, row_heights)`.
6. Parcourez chaque [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) pour appliquer un formatage aux bordures hautes, basses, droites et gauches.
7. Fusionnez les deux premières cellules de la première ligne de la table.
8. Accédez à la [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) d'un [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/).
9. Ajoutez du texte à la [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

Ce code Python vous montre comment créer une table dans une présentation :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates a Presentation class that represents a PPTX file
with slides.Presentation() as pres:
    # Accesses the first slide
    sld = pres.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [50, 50, 50]
    dblRows =  [50, 30, 30, 30, 30]

    # Adds a table shape to the slide
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Sets the border format for each cell
    for row in range(len(tbl.rows)):
        for cell in range(len(tbl.rows[row])):
            tbl.rows[row][cell].cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_top.width = 5

            tbl.rows[row][cell].cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            tbl.rows[row][cell].cell_format.border_bottom.width =5

            tbl.rows[row][cell].cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            tbl.rows[row][cell].cell_format.border_left.width = 5

            tbl.rows[row][cell].cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_right.width = 5


    # Merges cells 1 & 2 of row 1
    tbl.merge_cells(tbl.rows[0][0], tbl.rows[1][1], False)

    # Adds some text to the merged cell
    tbl.rows[0][0].text_frame.text = "Cellules Fusionnées"

    # Saves the presentation to Disk
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numérotation dans une Table Standard**

Dans une table standard, la numérotation des cellules est simple et commence par zéro. La première cellule d'une table est indexée comme 0,0 (colonne 0, rangée 0).

Par exemple, les cellules d'une table avec 4 colonnes et 4 lignes sont numérotées de cette manière :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ce code Python vous montre comment spécifier la numérotation pour les cellules dans une table :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates a Presentation class that represents a PPTX file
with slides.Presentation() as pres:
    # Accesses the first slide
    sld = pres.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [70, 70, 70, 70]
    dblRows =  [70, 70, 70, 70]

    # Adds a table shape to slide
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Sets the border format for each cell
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

    # Saves presentation to disk
    pres.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à une Table Existante**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

2. Obtenez une référence à la diapositive contenant la table via son index.

3. Créez un objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) et définissez-le sur null.

4. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) jusqu'à ce que la table soit trouvée.

   Si vous suspectez que la diapositive avec laquelle vous travaillez contient une seule table, vous pouvez simplement vérifier toutes les formes qu'elle contient. Lorsqu'une forme est identifiée comme une table, vous pouvez la convertir en objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Mais si la diapositive avec laquelle vous travaillez contient plusieurs tables, il est préférable de rechercher la table dont vous avez besoin via son `alternative_text`.

5. Utilisez l'objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) pour travailler avec la table. Dans l'exemple ci-dessous, nous avons ajouté une nouvelle ligne à la table.

6. Enregistrez la présentation modifiée.

Ce code Python vous montre comment accéder et travailler avec une table existante :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates a Presentation class that represents a PPTX file
with slides.Presentation(path + "UpdateExistingTable.pptx") as pres:
    # Accesses the first slide
    sld = pres.slides[0]

    # Initializes null TableEx
    tbl = None

    # Iterates through the shapes and sets a reference to the table found
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Sets the text for the first column of the second row
    tbl.rows[0][1].text_frame.text = "Nouveau"

    # Saves the modified presentation to disk
    pres.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Aligner le Texte dans la Table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive via son index.
3. Ajoutez un objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) à la diapositive.
4. Accédez à un objet [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) de la table.
5. Accédez à l'[ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/).
6. Alignez le texte verticalement.
7. Enregistrez la présentation modifiée.

Ce code Python vous montre comment aligner le texte dans une table :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    # Gets the first slide 
    slide = presentation.slides[0]

    # Defines columns with widths and rows with heights
    dblCols =  [120, 120, 120, 120]
    dblRows =  [100, 100, 100, 100]

    # Adds the table shape to the slide
    tbl = slide.shapes.add_table(100, 50, dblCols, dblRows)
    tbl.rows[1][0].text_frame.text = "10"
    tbl.rows[2][0].text_frame.text = "20"
    tbl.rows[3][0].text_frame.text = "30"

    # Accesses the text frame
    txtFrame = tbl.rows[0][0].text_frame

    # Creates the Paragraph object for the text frame
    paragraph = txtFrame.paragraphs[0]

    # Creates the Portion object for paragraph
    portion = paragraph.portions[0]
    portion.text = "texte ici"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Aligns the text vertically
    cell = tbl.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Saves the presentation to disk
    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir le Formatage du Texte au Niveau de la Table**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive via son index.
3. Accédez à un objet [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) de la diapositive.
4. Définissez la `font_height` pour le texte.
5. Définissez l'`alignment` et le `margin_right`.
6. Définissez le `text_vertical_type`.
7. Enregistrez la présentation modifiée.

Ce code Python vous montre comment appliquer vos options de formatage préférées au texte d'une table :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    someTable = presentation.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Sets the table cells' font height
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.set_text_format(portionFormat)

    # Sets the table cells' text alignment and right margin in one call
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.set_text_format(paragraphFormat)

    # Sets the table cells' text vertical type
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.set_text_format(textFrameFormat)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir les Propriétés de Style de la Table**

Aspose.Slides vous permet de récupérer les propriétés de style pour une table afin que vous puissiez utiliser ces détails pour une autre table ou ailleurs. Ce code Python vous montre comment obtenir les propriétés de style à partir d'un style de table prédéfini :

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Verrouiller le Rapport d'Aspect de la Table**

Le rapport d'aspect d'une forme géométrique est le rapport de ses tailles dans différentes dimensions. Aspose.Slides a fourni la propriété `aspect_ratio_locked` pour vous permettre de verrouiller le paramètre de rapport d'aspect pour les tables et d'autres formes.

Ce code Python vous montre comment verrouiller le rapport d'aspect pour une table :

```c#
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])
    print("Verrouiller le rapport d'aspect défini : {0}".format(table.shape_lock.aspect_ratio_locked))

    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked

    print("Verrouiller le rapport d'aspect défini : {0}".format(table.shape_lock.aspect_ratio_locked))

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```