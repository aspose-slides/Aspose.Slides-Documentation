---
title: Gérer les cellules de tableau dans les présentations avec Python
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/python-java/manage-cells/
keywords:
- cellule de tableau
- fusionner les cellules
- supprimer la bordure
- diviser la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérer les cellules de tableau PowerPoint en Python : identifier les cellules fusionnées, supprimer les bordures, diviser les cellules et définir les couleurs d’arrière-plan ainsi que les images avec Aspose.Slides pour Python via Java."
---
## **Vue d’ensemble**

Aspose.Slides vous permet d'accéder et de modifier les cellules de tableau dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, travailler avec la numérotation des cellules après fusion ou division, changer la couleur d’arrière-plan d’une cellule et ajouter une image à l’intérieur d’une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d’une diapositive, mettre à jour le formatage des cellules via les propriétés de cellule et enregistrer la présentation modifiée au format PPTX.

Aspose.Slides utilise des indices zéro-basés pour accéder aux cellules de tableau dans l’ordre `(column, row)`.

## **Identifier une cellule de tableau fusionnée**

L’exemple ouvre une présentation existante et accède à la première forme de la première diapositive en tant que tableau. Il suppose que la diapositive et la forme existent et que la forme est un tableau. Il parcourt ensuite toutes les lignes et colonnes et utilise [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) pour identifier les cellules dans les régions fusionnées. Pour chaque correspondance, il imprime les coordonnées de la cellule dans l’ordre `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) et les coordonnées de départ de la région, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) et [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Supprimer les bordures des cellules de tableau**

Créez une [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) et ajoutez un tableau à sa première diapositive avec [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Les largeurs de colonne, hauteurs de ligne et la position du tableau sont spécifiées en points. L’exemple définit les quatre bordures de cellule sur [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), les rendant invisibles.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Fusionner les cellules de tableau**

Utilisez [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) pour combiner une plage rectangulaire de cellules de tableau en une seule cellule. Spécifiez les cellules aux coins supérieur gauche et inférieur droit de la plage. Le dernier argument contrôle si la fusion peut inclure des cellules en dehors de la plage spécifiée ; `False` maintient la fusion à l’intérieur de cette plage.

L’exemple crée un tableau 4x4 avec des colonnes et lignes de 70 points, puis fusionne les quatre cellules centrales de `(1, 1)` à `(2, 2)`. La cellule résultante s’étend sur deux colonnes et deux lignes, tandis que la grille sous-jacente du tableau conserve quatre colonnes et quatre lignes. Pour accéder au contenu ou au formatage de la cellule fusionnée, utilisez sa position supérieure gauche : `table.get_Item(1, 1)` dans cet exemple. Les autres positions de la plage fusionnée restent partie de la grille du tableau, de sorte que les indices des cellules en dehors de la plage ne changent pas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Diviser les cellules de tableau**

La fusion de cellules dans l’exemple précédent préserve la grille du tableau. Diviser une cellule peut introduire une nouvelle colonne de grille et modifier les indices de colonne des cellules situées à sa droite. Aspose.Slides suit le modèle de grille de tableau de PowerPoint.

Cet exemple crée un tableau 4x4 avec des colonnes et lignes de 70 points et appelle [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) sur la cellule `(1, 1)`. La moitié de la largeur de 70 points de la cellule est transmise pour créer deux cellules de largeur égale.

Après cette division, les deux moitiés sont accessibles via `table.get_Item(1, 1)` et `table.get_Item(2, 1)`. La grille du tableau compte maintenant cinq colonnes : les cellules initialement en colonnes 2 et 3 se déplacent respectivement vers les colonnes 3 et 4. Les indices de ligne restent inchangés. Utilisez ces indices de colonne mis à jour lors de l’accès aux cellules après la division.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Diviser les cellules fusionnées par étendue de ligne ou de colonne**

Pour préparer les cellules de modèle fusionnées à la population de données, utilisez [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) pour diviser le long d’une frontière de ligne existante, ou [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) pour diviser le long d’une frontière de colonne.

L’argument `index` compte les lignes dans la partie supérieure ou les colonnes dans la partie gauche de la division ; il est relatif à la région fusionnée :

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

L’exemple suppose qu’une présentation possède un tableau comme première forme de la première diapositive, avec les cellules `(1, 2)` et `(1, 3)` fusionnées verticalement. En partant de la position inférieure, il utilise [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) et [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) pour localiser l’origine et vérifie les deux étendues. `splitByRowSpan(1)` sépare alors les lignes 2 et 3 pour les noms de produits. Pour une fusion horizontale de deux colonnes, utilisez `splitByColSpan(1)` à la place.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Récupérer les cellules résultantes du tableau après la division.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

La grille du tableau et les indices des cellules environnantes restent inchangés. Récupérez les cellules résultantes par leurs coordonnées ; ici, les deux ont une étendue de 1 et [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) renvoie `False`. Des régions plus grandes peuvent rester partiellement fusionnées après une division.

Le texte original et son formatage restent dans la cellule supérieure (ou gauche) ; la nouvelle cellule est vide mais hérite du formatage de la cellule tel que remplissage, bordures et marges. Remplissez les cellules après la division et définissez explicitement tout formatage de texte requis.

La présentation enregistrée contient les cellules séparées « Product A » et « Product B » avec le formatage de cellule du modèle conservé. Voir la [Référence de l’API Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) pour plus de détails.

## **Modifier la couleur d’arrière‑plan de la cellule de tableau**

Cet exemple crée un tableau avec des colonnes de 150 points et des lignes de 50 points. Il utilise [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) pour sélectionner un remplissage uni et définit la couleur renvoyée par [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) sur rouge pour la cellule `(2, 3)`, dans la troisième colonne et la quatrième ligne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajouter une image à l’intérieur d’une cellule de tableau**

Placez l’image d’entrée dans le répertoire de travail avant d’exécuter cet exemple. Elle charge l’image avec [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) et l’ajoute à la collection d’images de la présentation avec [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Elle attribue ensuite l’image au remplissage d’image de la cellule `(0, 0)`, la première cellule du tableau.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) étire l’image pour remplir la cellule, ce qui peut modifier son ratio d’aspect. Les largeurs de colonne et hauteurs de ligne sont en points. L’image chargée est libérée dans un bloc `finally` après avoir été ajoutée à la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je définir des épaisseurs et des styles de ligne différents pour les différents côtés d’une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) possèdent des propriétés séparées, de sorte que l’épaisseur et le style de chaque côté puissent différer.

**Que se passe-t-il avec l’image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Avec l’étirement, l’image s’ajuste à la nouvelle cellule ; avec le carrelage, les tuiles sont recalculées.

**Puis‑je affecter un hyperlien à tout le contenu d’une cellule ?**

[Hyperlinks](/slides/fr/python-java/manage-hyperlinks/) sont définis au niveau du texte (portion) à l’intérieur du cadre de texte de la cellule ou au niveau du tableau/forme entier. En pratique, vous affectez le lien à une portion ou à tout le texte de la cellule.

**Puis‑je définir des polices différentes au sein d’une même cellule ?**

Oui. Le cadre de texte d’une cellule prend en charge les [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (runs) avec un formatage indépendant : famille de police, style, taille et couleur.