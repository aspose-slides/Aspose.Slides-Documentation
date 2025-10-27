---
title: Manage Presentation Tables with Python
linktitle: Manage Table
type: docs
weight: 10
url: /fr/python-net/manage-table/
keywords:
- add table
- create table
- access table
- aspect ratio
- align text
- text formatting
- table style
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Create & edit tables in PowerPoint and OpenDocument slides with Aspose.Slides for Python via .NET. Discover simple code examples to streamline your table workflows."
---

## **Vue d’ensemble**

Une table dans PowerPoint est un moyen efficace de présenter des informations. Des informations disposées dans une grille de cellules (lignes et colonnes) sont simples à comprendre.

Aspose.Slides fournit la classe [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), la classe [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) et d’autres types associés pour vous aider à créer, mettre à jour et gérer des tables dans n’importe quelle présentation.

## **Créer des tables à partir de zéro**

Cette section montre comment créer une table à partir de zéro avec Aspose.Slides en ajoutant une forme de table à une diapositive, en définissant ses lignes et colonnes, et en définissant des tailles précises. Vous verrez également comment remplir les cellules avec du texte, ajuster l’alignement et les bordures, et personnaliser l’apparence de la table.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive par son index.
3. Définissez un tableau de largeurs de colonnes.
4. Définissez un tableau de hauteurs de lignes.
5. Ajoutez une [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) à la diapositive.
6. Parcourez chaque [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) et formatez ses bordures supérieure, inférieure, droite et gauche.
7. Fusionnez les deux premières cellules de la première ligne de la table.
8. Accédez au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) d’une [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/).
9. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment créer une table dans une présentation :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Merge cells from (row 0, col 0) to (row 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Add text to the merged cell.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Save the presentation to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numérotation dans les tables standard**

Dans une table standard, la numérotation des cellules est simple et commence à zéro. La première cellule d’une table possède l’indice (0, 0) (colonne 0, ligne 0).

Par exemple, dans une table de 4 colonnes sur 4 lignes, les cellules sont numérotées ainsi :

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

L’exemple Python suivant montre comment référencer les cellules en utilisant cette numérotation zéro‑based :

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Accéder à une table existante**

Cette section explique comment localiser et travailler avec une table existante dans une présentation à l’aide d’Aspose.Slides. Vous apprendrez à trouver la table sur une diapositive, à accéder à ses lignes, colonnes et cellules, et à mettre à jour le contenu ou le formatage.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive contenant la table par son index.
3. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) jusqu’à trouver la table.
4. Utilisez l’objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) pour travailler avec la table.
5. Enregistrez la présentation modifiée.

{{% alert color="info" %}}

Si la diapositive contient plusieurs tables, il est préférable de rechercher la table dont vous avez besoin par sa propriété `alternative_text`.

{{% /alert %}}

L’exemple Python suivant montre comment accéder à une table existante et travailler avec :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class to load a PPTX file.
with slides.Presentation("sample.pptx") as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    table = None

    # Iterate through shapes and reference the first table found.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Set the text of the first cell in the first row.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Save the modified presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Aligner le texte dans les tables**

Cette section montre comment contrôler l’alignement du texte à l’intérieur des cellules de table à l’aide d’Aspose.Slides. Vous apprendrez à définir l’alignement horizontal et vertical des cellules afin de garder votre contenu clair et cohérent.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez un objet [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) à la diapositive.
4. Accédez à un objet [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) de la table.
5. Alignez le texte verticalement.
6. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment aligner le texte dans une table :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Center the text and set vertical orientation.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Save the presentation to disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la mise en forme du texte au niveau de la table**

Cette section montre comment appliquer une mise en forme du texte au niveau de la table dans Aspose.Slides afin que chaque cellule hérite d’un style cohérent et unifié. Vous apprendrez à définir globalement la taille des polices, les alignements et les marges.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Ajoutez une [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) à la diapositive.
4. Définissez la taille de police (hauteur de police) pour le texte.
5. Définissez l’alignement des paragraphes et les marges.
6. Définissez l’orientation verticale du texte.
7. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment appliquer vos options de mise en forme préférées au texte d’une table :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Set the font size for all table cells.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Set right-aligned text and a right margin for all table cells.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Set the vertical text orientation for all table cells.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Appliquer les styles de table intégrés**

Aspose.Slides vous permet de formater les tables en utilisant des styles prédéfinis directement dans le code. L’exemple montre la création d’une table, l’application d’un style intégré, et l’enregistrement du résultat — une méthode efficace pour garantir un formatage professionnel et cohérent.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Verrouiller le ratio d’aspect des tables**

Le ratio d’aspect d’une forme est le rapport entre ses dimensions. Aspose.Slides fournit la propriété `aspect_ratio_locked`, qui permet de verrouiller le ratio d’aspect pour les tables et les autres formes.

L’exemple Python suivant montre comment verrouiller le ratio d’aspect d’une table :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis‑je activer la direction de lecture de droite à gauche (RTL) pour une table entière et le texte de ses cellules ?**

Oui. La table expose une propriété [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), et les paragraphes possèdent [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). L’utilisation des deux garantit l’ordre RTL correct et le rendu à l’intérieur des cellules.

**Comment empêcher les utilisateurs de déplacer ou de redimensionner une table dans le fichier final ?**

Utilisez les [verrous de forme](/slides/fr/python-net/applying-protection-to-presentation/) pour désactiver le déplacement, le redimensionnement, la sélection, etc. Ces verrous s’appliquent également aux tables.

**L’insertion d’une image à l’intérieur d’une cellule comme arrière‑plan est‑elle prise en charge ?**

Oui. Vous pouvez définir un [remplissage d’image](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) pour une cellule ; l’image couvrira la zone de la cellule selon le mode choisi (étirement ou mosaïque).