---
title: Gérer les cellules de tableau dans les présentations avec Python
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/python-net/manage-cells/
keywords:
- cellule de tableau
- fusionner les cellules
- supprimer la bordure
- diviser la cellule
- image dans la cellule
- couleur d'arrière‑plan
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérer les cellules de tableau PowerPoint en Python : identifier les cellules fusionnées, supprimer les bordures, diviser les cellules et définir les couleurs d'arrière‑plan ainsi que les images avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'accéder aux cellules de tableau et de les modifier dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, travailler avec la numérotation des cellules après fusion ou division, changer la couleur d'arrière‑plan d'une cellule et ajouter une image à l'intérieur d'une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d’une diapositive, mettre à jour le format des cellules via leurs propriétés et enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices basés sur zéro. Les coordonnées dans cet article sont écrites sous la forme `(colonne, ligne)`.

## **Identifier une cellule de tableau fusionnée**

L’exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est un tableau. Il parcourt ensuite toutes les lignes et colonnes et utilise [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) pour identifier les cellules dans des zones fusionnées. Pour chaque correspondance, il affiche les coordonnées de la cellule dans l’ordre `ligne;colonne`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), ainsi que les coordonnées de départ de la région, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) et [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Supprimer les bordures des cellules du tableau**

Créez une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et ajoutez un tableau à sa première diapositive avec [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Les largeurs de colonnes, hauteurs de lignes et la position du tableau sont spécifiées en points. L’exemple définit les quatre bordures de la cellule sur [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), les rendant invisibles.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des bordures diagonales aux cellules**

Utilisez [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) pour tracer une ligne du coin supérieur gauche au coin inférieur droit, et [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) pour tracer une ligne du coin inférieur gauche au coin supérieur droit. Une diagonale peut marquer un en‑tête de coin ; les deux diagonales peuvent former un X pour indiquer qu’une cellule n’est pas applicable.

Chaque diagonale est un [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). Dans son [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/), définissez [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) sur [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) et choisissez une [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Réglez la [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) de la ligne en points.

L’exemple crée trois cellules dans une même ligne : une diagonale descendante rouge, une diagonale ascendante bleue et les deux diagonales. Les bordures supérieures, inférieures, gauche et droite restent inchangées.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Une diagonale est une propriété de formatage, pas une division de cellule. Chaque cellule conserve un seul [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); les zones de part et d’autre d’une diagonale ne peuvent pas être éditées indépendamment.

Le tableau enregistré, rendu dans Microsoft PowerPoint :

![Trois cellules de tableau montrant une diagonale rouge du coin supérieur gauche au coin inférieur droit, une diagonale bleue du coin inférieur gauche au coin supérieur droit, et les deux diagonales formant un X.](diagonal-cell-borders.png)

*De gauche à droite : diagonale descendante (rouge, 3 pt), diagonale ascendante (bleu, 5 pt) et les deux diagonales.*

## **Fusionner des cellules de tableau**

Utilisez [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) pour combiner une plage rectangulaire de cellules de tableau en une seule cellule. Spécifiez les cellules aux coins supérieur gauche et inférieur droit de la plage. Le dernier argument contrôle si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `False` maintient la fusion à l’intérieur de cette plage.

L’exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante s’étend sur deux colonnes et deux lignes, tandis que la grille sous‑jacente du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au formatage de la cellule fusionnée, utilisez sa position supérieure gauche : `table.rows[1][1]` dans cet exemple. Les autres positions de la plage fusionnée restent partie de la grille du tableau, de sorte que les indices des cellules situées à l’extérieur de la plage ne changent pas.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Diviser les cellules du tableau**

La fusion des cellules dans l’exemple précédent préserve la grille du tableau. Diviser une cellule peut introduire une nouvelle colonne de grille et modifier les indices de colonne des cellules situées à sa droite. Aspose.Slides suit le modèle de grille de tableau de PowerPoint.

Cet exemple crée un tableau 4 × 4 avec des colonnes et lignes de 70 points et appelle [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est transmise pour créer deux cellules de largeur égale.

Après cette division, les deux moitiés sont accessibles via `table.rows[1][1]` et `table.rows[1][2]`. La grille du tableau possède maintenant cinq colonnes : les cellules initialement en colonnes 2 et 3 se déplacent respectivement en colonnes 3 et 4. Les indices des lignes restent inchangés. Utilisez ces indices de colonne mis à jour lors de l’accès aux cellules après la division.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

<!-- visual-explanation:manage-cells:start -->
[![Une cellule non fusionnée de 70 points se divise en deux cellules de 35 points, ajoutant une cinquième colonne de grille et décalant les indices à droite.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*La division de largeur affecte la cellule (1, 1), en utilisant des indices (colonne, ligne) basés sur zéro. Les autres lignes conservent une cellule s’étendant sur les deux nouvelles positions de colonne.*
<!-- visual-explanation:manage-cells:end -->

### **Diviser les cellules fusionnées par étendue de ligne ou de colonne**

Pour préparer les cellules de modèle fusionnées à la population de données, utilisez [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) pour diviser le long d’une frontière de ligne existante, ou [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) pour diviser le long d’une frontière de colonne.

L’argument `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; il est relatif à la région fusionnée :

- Division de ligne : `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Division de colonne : `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

L’exemple suppose qu’une présentation possède un tableau comme première forme de la première diapositive, avec les cellules `(1, 2)` et `(1, 3)` fusionnées verticalement. En partant de la position inférieure, il utilise [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) et [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) pour localiser l’origine et vérifie les deux étendues. `split_by_row_span` avec un index de 1 sépare alors les lignes 2 et 3 pour les noms de produit. Pour une fusion horizontale de deux colonnes, utilisez `split_by_col_span` avec un index de 1 à la place.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Récupérer les cellules résultantes du tableau après la division.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont une étendue de 1 et [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) renvoie `False`. Des régions plus grandes peuvent rester partiellement fusionnées après une division.

Le texte original et son formatage demeurent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du formatage de la cellule (remplissage, bordures, marges). Remplissez les cellules après la division et définissez explicitement tout formatage de texte requis.

La présentation enregistrée contient les cellules séparées « Product A » et « Product B » avec le formatage du modèle conservé. Consultez la [Référence de l'API Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) pour plus de détails.

### **Diviser une cellule à une hauteur précise**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) prend la hauteur de la partie supérieure en points. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) prend le nombre de lignes de grille existantes dans la partie supérieure. Pour centrer verticalement une cellule de 40 points dans la colonne de droite, soustrayez 40 de la hauteur réelle de la cellule et répartissez l’espace restant également au-dessus et en dessous.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

La première division ajoute une ligne de grille, laissant les 90 points inférieurs dans `table.rows[1][1]`. La deuxième division sépare cette cellule en une cellule médiane de 40 points et une cellule inférieure de 50 points. Les trois cellules de la colonne de droite mesurent désormais 50, 40 et 50 points de haut, de haut en bas. La cellule de gauche s’étend sur les trois lignes à sa hauteur d’origine de 140 points.

![La cellule de gauche occupe toute la hauteur du tableau à côté de trois cellules avec « Middle » au centre.](split-by-height.png)

## **Modifier la couleur d'arrière-plan d'une cellule de tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il définit [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) sur solide et [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) sur rouge pour la cellule `(2, 3)`, située dans la troisième colonne et la quatrième ligne.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter une image à l'intérieur d'une cellule de tableau**

Placez l’image d’entrée dans le répertoire de travail avant d’exécuter cet exemple. Elle charge l’image avec [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) et l’ajoute à la collection d’images de la présentation avec [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Elle assigne ensuite l’image au remplissage image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) étire l’image pour remplir la cellule, ce qui peut modifier son rapport d’aspect. Les largeurs de colonnes et hauteurs de lignes sont en points. L’image chargée est libérée automatiquement à la fin de son bloc `with`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis-je définir des épaisseurs et styles de ligne différents pour chaque côté d'une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/), [bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/), [left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/), [right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) disposent de propriétés séparées, de sorte que l’épaisseur et le style de chaque côté puissent différer.

**Que se passe-t-il pour l'image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Avec l’étirement, l’image s’ajuste à la nouvelle cellule ; avec le carrelage, les carreaux sont recalculés.

**Puis-je affecter un hyperlien à tout le contenu d'une cellule ?**

Les [Hyperlinks](/slides/fr/python-net/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre texte de la cellule ou au niveau du tableau/la forme entière. En pratique, vous affectez le lien à une portion ou à l’ensemble du texte de la cellule.

**Puis-je définir différentes polices au sein d'une même cellule ?**

Oui. Le cadre texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runs) avec un formatage indépendant : famille de police, style, taille et couleur.