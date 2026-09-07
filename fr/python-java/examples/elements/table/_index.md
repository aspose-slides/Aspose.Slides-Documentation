---
title: Tableau
type: docs
weight: 120
url: /fr/python-java/examples/elements/table/
keywords:
- exemple de code
- tableau
- ajouter tableau
- accéder tableau
- supprimer tableau
- fusionner cellules
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Travaillez avec les tableaux dans Aspose.Slides for Python via Java : ajoutez, accédez, supprimez et fusionnez des cellules dans les présentations PowerPoint et OpenDocument."
---
Exemples d'ajout de tableaux, d'accès à ceux‑ci, de suppression et de fusion de cellules en utilisant **Aspose.Slides for Python via Java**.

Installez le package comme décrit dans [Installation](/slides/fr/python-java/installation/). Chaque exemple importe `asposeslides` avant de démarrer la JVM, puis importe l'API après le démarrage de la JVM.

## **Ajouter un tableau**

Créez un tableau simple avec deux lignes et deux colonnes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)
finally:
    presentation.dispose()
```

## **Accéder à un tableau**

Récupérez la première forme de tableau sur la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Accéder au premier tableau sur la diapositive.
    first_table = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Table):
            first_table = shape
            break
finally:
    presentation.dispose()
```

## **Supprimer un tableau**

Supprimez un tableau d'une diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    slide.getShapes().remove(table)
finally:
    presentation.dispose()
```

## **Fusionner les cellules du tableau**

Fusionnez les cellules adjacentes d'un tableau en une seule cellule.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    widths = jpype.JArray(jpype.JDouble)([80, 80])
    heights = jpype.JArray(jpype.JDouble)([30, 30])
    table = slide.getShapes().addTable(50, 50, widths, heights)

    # Fusionner les cellules.
    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), False)
finally:
    presentation.dispose()
```