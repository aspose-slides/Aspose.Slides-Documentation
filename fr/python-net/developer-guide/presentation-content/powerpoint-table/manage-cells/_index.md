---
title: Gérer les cellules de tableau dans les présentations avec Python
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/python-net/manage-cells/
keywords:
- cellule de tableau
- fusionner des cellules
- supprimer la bordure
- scinder la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Gérez facilement les cellules de tableau dans PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Maîtrisez l'accès, la modification et le style des cellules rapidement pour une automatisation fluide des diapositives."
---

## **Vue d'ensemble**

Cet article montre comment travailler avec les cellules de tableau dans les présentations à l'aide d'Aspose.Slides. Vous apprendrez à détecter les cellules fusionnées, à effacer ou personnaliser les bordures des cellules, et à comprendre comment PowerPoint numérote les cellules après les opérations de fusion et de division afin de pouvoir prévoir l'indexation dans des mises en page complexes. L'article démontre également les tâches de formatage courantes—comme changer le remplissage d'arrière-plan d’une cellule—et montre comment placer une image directement à l’intérieur d’une cellule de tableau avec les paramètres de remplissage d'image. Chaque scénario est accompagné d’exemples Python concis qui créent ou modifient des tableaux puis enregistrent la présentation mise à jour, afin que vous puissiez adapter rapidement les extraits à vos propres diapositives.

## **Identifier les cellules de tableau fusionnées**

Les tableaux contiennent souvent des cellules fusionnées pour les en‑têtes ou pour regrouper des données liées. Dans cette section, vous verrez comment déterminer si une cellule donnée appartient à une région fusionnée et comment référencer la cellule maîtresse (en haut à gauche) afin de lire ou formater tout le bloc de façon cohérente.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Récupérez le tableau de la première diapositive.
1. Parcourez les lignes et colonnes du tableau pour trouver les cellules fusionnées.
1. Affichez un message lorsqu’une cellule fusionnée est trouvée.

Le code Python suivant identifie les cellules de tableau fusionnées dans une présentation :

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Assuming the first shape on the first slide is a table.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Supprimer les bordures des cellules de tableau**

Parfois, les bordures du tableau distraient du contenu ou créent du désordre visuel. Cette section montre comment supprimer les bordures des cellules sélectionnées—ou des côtés spécifiques d’une cellule—afin d’obtenir une mise en page plus épurée et mieux alignée avec le design de votre diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Récupérez la diapositive par son index.
1. Définissez un tableau de largeurs de colonne.
1. Définissez un tableau de hauteurs de ligne.
1. Ajoutez un tableau à la diapositive en utilisant la méthode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
1. Parcourez chaque cellule pour effacer les bordures supérieure, inférieure, gauche et droite.
1. Enregistrez la présentation modifiée au format PPTX.

Le code Python suivant montre comment supprimer les bordures des cellules de tableau :

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Clear the border fill for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Save the PPTX file to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numérotation des cellules fusionnées**

Si vous fusionnez deux paires de cellules—par exemple, (1, 1) × (2, 1) et (1, 2) × (2, 2)—le tableau résultant conserve la même numérotation de cellules que le tableau sans fusion. Le code Python suivant illustre ce comportement :

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Merge cells (1,1) and (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Merge cells (1, 2) and (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Sortie :

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Numérotation des cellules scindées**

Dans l’exemple précédent, lorsque les cellules du tableau étaient fusionnées, la numérotation des autres cellules ne changeait pas. Cette fois‑ci, nous créons un tableau normal (sans cellules fusionnées) puis scindons la cellule (1, 1) pour produire un tableau spécial. Faites attention à la numérotation de ce tableau — elle peut sembler inhabituelle. Cependant, c’est ainsi que Microsoft PowerPoint numérote les cellules de tableau, et Aspose.Slides suit le même comportement.

Le code Python suivant montre ce comportement :

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Split cell (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Sortie :

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Modifier la couleur d'arrière-plan d'une cellule de tableau**

L’exemple Python suivant montre comment changer la couleur d’arrière-plan d’une cellule de tableau :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Create a new table.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Set the background color for a cell.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Insérer des images dans les cellules de tableau**

Cette section montre comment insérer une image dans une cellule de tableau avec Aspose.Slides. Elle couvre l’application d’un remplissage d’image à la cellule cible et la configuration des options d’affichage telles que l’étirement ou le carrelage.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Définissez un tableau de largeurs de colonne.
1. Définissez un tableau de hauteurs de ligne.
1. Ajoutez un tableau à la diapositive avec la méthode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
1. Chargez l’image depuis un fichier.
1. Ajoutez l’image à la présentation pour obtenir un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
1. Définissez le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la cellule du tableau sur `PICTURE`.
1. Appliquez l’image à la cellule du tableau et choisissez un mode de remplissage (ex. : `STRETCH`).
1. Enregistrez la présentation au format PPTX.

Le code Python suivant montre comment placer une image à l’intérieur d’une cellule de tableau lors de la création du tableau :

```python
import aspose.slides as slides

# Instantiate a Presentation object.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Load the image and add it to the presentation to obtain a PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Apply the image to the first table cell.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Save the presentation to disk.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis‑je définir des épaisseurs et styles de ligne différents pour les différents côtés d’une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) possèdent des propriétés séparées, de sorte que l’épaisseur et le style de chaque côté peuvent différer. Cela découle logiquement du contrôle des bordures par côté démontré dans l’article.

**Que se passe‑t‑il avec l’image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [mode de remplissage](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Avec l’étirement, l’image s’ajuste à la nouvelle cellule ; avec le carrelage, les tuiles sont recalculées. L’article décrit les modes d’affichage de l’image dans une cellule.

**Puis‑je attribuer un hyperlien à tout le contenu d’une cellule ?**

Les [hyperliens](/slides/fr/python-net/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre de texte de la cellule ou au niveau du tableau/forme entier. En pratique, vous affectez le lien à une portion ou à tout le texte de la cellule.

**Puis‑je définir différentes polices au sein d’une même cellule ?**

Oui. Le cadre de texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) avec un formatage indépendant — famille de police, style, taille et couleur.