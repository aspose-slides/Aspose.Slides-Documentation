---
title: Gérer les cellules de tableau dans les présentations avec Python
linktitle: Gérer les cellules
type: docs
weight: 30
url: /fr/python-java/manage-cells/
keywords:
- cellule de tableau
- fusionner des cellules
- supprimer la bordure
- diviser la cellule
- image dans la cellule
- couleur d'arrière-plan
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gérez facilement les cellules de tableau dans PowerPoint avec Aspose.Slides pour Python via Java. Maîtrisez l'accès, la modification et le style des cellules rapidement pour une automatisation fluide des diapositives."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d'accéder et de modifier les cellules de tableau dans les présentations PowerPoint. Cet article explique comment identifier les cellules de tableau fusionnées, supprimer les bordures des cellules, travailler avec la numérotation des cellules après fusion ou division, changer la couleur d'arrière-plan d'une cellule et ajouter une image à l'intérieur d'une cellule de tableau. Les exemples montrent comment créer ou ouvrir une présentation, obtenir un tableau à partir d'une diapositive, mettre à jour le formatage des cellules via les propriétés des cellules, et enregistrer la présentation modifiée en fichier PPTX.

## **Identifier une cellule de tableau fusionnée**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenir le tableau de la première diapositive.
3. Itérer à travers les lignes et colonnes du tableau pour trouver les cellules fusionnées.
4. Afficher un message lorsqu'une cellule fusionnée est trouvée.

Ce code Python vous montre comment identifier les cellules de tableau fusionnées dans une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Suppose que la première forme sur la première diapositive est un tableau.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Supprimer les bordures des cellules de tableau**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenir une référence à une diapositive par son indice.
3. Définir une liste de largeurs de colonnes.
4. Définir une liste de hauteurs de lignes.
5. Ajouter un tableau à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addTable).
6. Itérer à travers chaque cellule pour effacer les bordures supérieure, inférieure, droite et gauche.
7. Enregistrer la présentation modifiée en fichier PPTX.

Ce code Python vous montre comment supprimer les bordures des cellules de tableau :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Accéder à la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Définir les largeurs de colonnes et les hauteurs de lignes.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Ajouter un tableau à la diapositive.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Définir le format de bordure pour chaque cellule.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Enregistrer la présentation au format PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numérotation dans les cellules fusionnées**

Si nous fusionnons deux paires de cellules, (1, 1) et (2, 1), ainsi que (1, 2) et (2, 2), le tableau résultant conserve sa numérotation des cellules. Ce code Python montre le processus :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Accéder à la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Définir les largeurs des colonnes et les hauteurs des lignes.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Ajouter un tableau à la diapositive.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Définir le format des bordures pour chaque cellule.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Fusionner les cellules (1, 1) et (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Fusionner les cellules (1, 2) et (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Enregistrer la présentation au format PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nous fusionnons ensuite les cellules davantage en fusionnant (1, 1) et (1, 2). Le résultat est un tableau contenant une grande cellule fusionnée au centre :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Accéder à la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Définir les largeurs des colonnes et les hauteurs des lignes.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Ajouter un tableau à la diapositive.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Définir le format des bordures pour chaque cellule.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Fusionner les cellules (1, 1) et (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Fusionner les cellules (1, 2) et (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Fusionner les cellules (1, 1) et (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Enregistrer la présentation au format PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numérotation dans une cellule scindée**

Dans les exemples précédents, la fusion des cellules de tableau n'a pas modifié la numérotation des autres cellules.

Cette fois, nous prenons un tableau standard (sans cellules fusionnées) et nous essayons de scinder la cellule (1, 1) pour obtenir un tableau spécial. Vous pouvez porter attention à la numérotation de ce tableau, qui peut sembler étrange. Cependant, c’est ainsi que Microsoft PowerPoint numérote les cellules de tableau et Aspose.Slides fait de même.

Ce code Python montre le processus décrit :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Accéder à la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Définir les largeurs des colonnes et les hauteurs des lignes.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Ajouter un tableau à la diapositive.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Définir le format des bordures pour chaque cellule.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Diviser la cellule (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Enregistrer la présentation au format PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifier la couleur d'arrière-plan d'une cellule de tableau**

Ce code Python montre comment changer la couleur d'arrière-plan d'une cellule de tableau :

```python
import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Accéder à la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Définir les largeurs des colonnes et les hauteurs des lignes.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Ajouter un tableau à la diapositive.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Définir la couleur d'arrière-plan d'une cellule.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Enregistrer la présentation au format PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajouter une image à l'intérieur d'une cellule de tableau**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenir une référence à une diapositive par son indice.
3. Définir une liste de largeurs de colonnes.
4. Définir une liste de hauteurs de lignes.
5. Ajouter un tableau à la diapositive via la méthode [addTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addTable).
6. Charger le fichier image en utilisant [Images.fromFile](https://reference.aspose.com/slides/fr/python-java/aspose.slides/images/#fromFile).
7. Ajouter l'image à la présentation pour créer un objet [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/).
8. Définir le type de remplissage de la cellule du tableau via [FillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/) sur [FillType.Picture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/#Picture).
9. Ajouter l'image à la première cellule du tableau.
10. Enregistrer la présentation modifiée en fichier PPTX.

Ce code Python montre comment placer une image à l'intérieur d'une cellule de tableau lors de la création d'un tableau :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Accéder à la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Définir les largeurs des colonnes et les hauteurs des lignes.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Ajouter un tableau à la diapositive.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Créer une image de présentation à partir du fichier image.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Ajouter l'image à la première cellule du tableau.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Enregistrer la présentation au format PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je définir des épaisseurs et des styles de ligne différents pour chaque côté d'une même cellule ?**

Oui. Les bordures [top](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cellformat/#getBorderRight) possèdent des propriétés distinctes, ainsi l'épaisseur et le style de chaque côté peuvent différer. Cela découle logiquement du contrôle des bordures par côté pour une cellule démontré dans l'article.

**Que se passe-t-il pour l'image si je modifie la taille de la colonne/ligne après avoir défini une image comme arrière‑plan de la cellule ?**

Le comportement dépend du [fill mode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillmode/) (stretch/tile). Avec l'étirement, l'image s'ajuste à la nouvelle cellule ; avec le carrelage, les tuiles sont recalculées. L'article mentionne les modes d'affichage de l'image dans une cellule.

**Puis-je attribuer un hyperlien à tout le contenu d'une cellule ?**

[Hyperlinks](/slides/fr/python-java/manage-hyperlinks/) sont définis au niveau du texte (portion) à l'intérieur du cadre de texte de la cellule ou au niveau de l'ensemble du tableau/forme. En pratique, vous attribuez le lien à une portion ou à tout le texte de la cellule.

**Puis-je définir différentes polices au sein d'une même cellule ?**

Oui. Le cadre de texte d'une cellule prend en charge les [portions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) (runs) avec un formatage indépendant — famille de police, style, taille et couleur.