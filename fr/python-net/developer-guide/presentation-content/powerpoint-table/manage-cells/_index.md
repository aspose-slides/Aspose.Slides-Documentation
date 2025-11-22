---
title: Gestion des cellules de tableau dans les présentations avec Python
linktitle: Gestion des cellules
type: docs
weight: 30
url: /fr/python-net/manage-cells/
keywords:
- cellule de tableau
- fusion de cellules
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

Cet article montre comment travailler avec les cellules de tableau dans les présentations à l’aide d’Aspose.Slides. Vous apprendrez à détecter les cellules fusionnées, à effacer ou personnaliser les bordures des cellules, et à comprendre comment PowerPoint numérote les cellules après les opérations de fusion et de division afin de pouvoir prévoir l’indexation dans des mises en page complexes. L’article montre également des tâches de mise en forme courantes—comme changer le remplissage d’arrière‑plan d’une cellule—et montre comment placer une image directement dans une cellule de tableau avec les paramètres de remplissage d’image. Chaque scénario est accompagné d’exemples Python concis qui créent ou modifient des tableaux puis enregistrent la présentation mise à jour, afin que vous puissiez adapter les extraits à vos propres diapositives rapidement.

## **Identifier les cellules de tableau fusionnées**

Les tableaux contiennent souvent des cellules fusionnées pour les en‑têtes ou pour regrouper des données liées. Dans cette section, vous verrez comment déterminer si une cellule donnée appartient à une région fusionnée et comment référencer la cellule maître (en haut à gauche) afin de lire ou formater tout le bloc de manière cohérente.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Récupérez le tableau depuis la première diapositive.
1. Parcourez les lignes et colonnes du tableau pour trouver les cellules fusionnées.
1. Affichez un message lorsqu’une cellule fusionnée est détectée.

Le code Python suivant identifie les cellules de tableau fusionnées dans une présentation :
```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # En supposant que la première forme de la première diapositive est un tableau.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```


## **Supprimer les bordures des cellules de tableau**

Parfois les bordures du tableau distraient du contenu ou créent un encombrement visuel. Cette section montre comment supprimer les bordures de cellules sélectionnées—ou de côtés spécifiques d’une cellule—afin d’obtenir une mise en page plus épurée et mieux alignée avec le design de votre diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Récupérez la diapositive par son index.
1. Définissez un tableau de largeurs de colonnes.
1. Définissez un tableau de hauteurs de lignes.
1. Ajoutez un tableau à la diapositive à l’aide de la méthode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
1. Parcourez chaque cellule pour effacer les bordures supérieure, inférieure, gauche et droite.
1. Enregistrez la présentation modifiée au format PPTX.

Le code Python suivant montre comment supprimer les bordures des cellules de tableau :
```python
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation() as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Définir les colonnes avec leurs largeurs et les lignes avec leurs hauteurs.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Ajouter une forme de tableau à la diapositive.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Effacer le remplissage des bordures pour chaque cellule.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **Numérotation dans les cellules fusionnées**

Si vous fusionnez deux paires de cellules—par exemple, (1, 1) × (2, 1) et (1, 2) × (2, 2)—le tableau résultant conserve la même numérotation de cellules que le tableau sans fusion. Le code Python suivant illustre ce comportement :
```python
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation() as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Définir les colonnes avec leurs largeurs et les lignes avec leurs hauteurs.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Ajouter une forme de tableau à la diapositive.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Fusionner les cellules (1,1) et (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Fusionner les cellules (1, 2) et (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Afficher les indices des cellules.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```


Sortie :
```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```


## **Numérotation dans les cellules séparées**

Dans l’exemple précédent, lorsque les cellules du tableau étaient fusionnées, la numérotation des autres cellules ne changeait pas. Cette fois‑ci, nous créons un tableau standard (sans cellules fusionnées) puis séparons la cellule (1, 1) pour produire un tableau spécial. Faites attention à la numérotation de ce tableau — elle peut sembler inhabituelle. Cependant, c’est ainsi que Microsoft PowerPoint numérote les cellules de tableau, et Aspose.Slides suit le même comportement.

Le code Python suivant démontre ce comportement :
```python
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier PPTX.
with slides.Presentation() as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Définir les largeurs des colonnes et les hauteurs des lignes.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Ajouter une forme de tableau à la diapositive.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Diviser la cellule (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Afficher les indices des cellules.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Enregistrer le fichier PPTX sur le disque.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```


Sortie :
```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```


## **Modifier la couleur d’arrière‑plan d’une cellule de tableau**

L’exemple Python suivant montre comment modifier la couleur d’arrière‑plan d’une cellule de tableau :
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Créer un nouveau tableau.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Définir la couleur d'arrière-plan d'une cellule.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```


## **Insérer des images dans les cellules de tableau**

Cette section montre comment insérer une image dans une cellule de tableau avec Aspose.Slides. Elle couvre l’application d’un remplissage d’image à la cellule cible et la configuration des options d’affichage telles que l’étirement ou le carrelage.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Récupérez une référence à la diapositive par son index.
1. Définissez un tableau de largeurs de colonnes.
1. Définissez un tableau de hauteurs de lignes.
1. Ajoutez un tableau à la diapositive avec la méthode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
1. Chargez l’image depuis un fichier.
1. Ajoutez l’image aux images de la présentation pour obtenir un [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).
1. Définissez la propriété [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de la cellule à `PICTURE`.
1. Appliquez l’image à la cellule de tableau et choisissez un mode de remplissage (par ex., `STRETCH`).
1. Enregistrez la présentation au format PPTX.

Le code Python suivant montre comment placer une image à l’intérieur d’une cellule de tableau lors de la création du tableau :
```python
import aspose.slides as slides

# Instancier un objet Presentation.
with slides.Presentation() as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Définir les largeurs des colonnes et les hauteurs des lignes.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Ajouter une forme de tableau à la diapositive.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Charger l'image et l'ajouter à la présentation pour obtenir un PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Appliquer l'image à la première cellule du tableau.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Enregistrer la présentation sur le disque.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis‑je définir des épaisseurs et des styles de ligne différents pour chaque côté d’une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) possèdent des propriétés séparées, de sorte que l’épaisseur et le style de chaque côté peuvent différer. Cela découle logiquement du contrôle des bordures par côté démontré dans l’article.

**Que se passe‑t‑il avec l’image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Avec l’étirement, l’image s’ajuste à la nouvelle cellule ; avec le carrelage, les tuiles sont recalculées. L’article mentionne les modes d’affichage de l’image dans une cellule.

**Puis‑je attribuer un hyperlien à tout le contenu d’une cellule ?**

[Hyperlinks](/slides/fr/python-net/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre de texte de la cellule ou au niveau de l’ensemble du tableau/shape. En pratique, vous assignez le lien à une portion ou à tout le texte de la cellule.

**Puis‑je définir des polices différentes au sein d’une même cellule ?**

Oui. Le cadre de texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) avec une mise en forme indépendante — famille, style, taille et couleur de police.