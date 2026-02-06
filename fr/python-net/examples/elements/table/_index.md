---
title: Tableau
type: docs
weight: 120
url: /fr/python-net/examples/elements/table/
keywords:
- tableau
- ajouter tableau
- accéder tableau
- supprimer tableau
- fusionner cellules
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Créer et mettre en forme des tableaux en Python avec Aspose.Slides : insérer des données, fusionner des cellules, styliser les bordures, aligner le contenu, et importer/exporter pour PPT, PPTX et ODP."
---
Exemples d'ajout de tableaux, d'accès à ceux-ci, de suppression et de fusion de cellules à l'aide de **Aspose.Slides for Python via .NET**.

## **Ajouter un tableau**

Créez un tableau simple avec deux lignes et deux colonnes.

```py
def add_table():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Définir les largeurs de colonnes et les hauteurs de lignes.
        widths = [80, 80]
        heights = [30, 30]

        # Ajouter une forme de tableau à la diapositive.
        table = slide.shapes.add_table(50, 50, widths, heights)

        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à un tableau**

Récupérez la première forme de tableau sur la diapositive.

```py
def access_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Accéder au premier tableau sur la diapositive.
        first_table = next(shape for shape in slide.shapes if isinstance(shape, slides.Table))
```

## **Supprimer un tableau**

Supprimez un tableau d'une diapositive.

```py
def remove_table():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposer que la première forme est un tableau.
        table = slide.shapes[0]

        # Supprimer le tableau de la diapositive.
        slide.shapes.remove(table)

        presentation.save("table_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Fusionner des cellules de tableau**

Fusionnez les cellules adjacentes d'un tableau en une seule cellule.

```py
def merge_table_cells():
    with slides.Presentation("table.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposer que la première forme est un tableau.
        table = slide.shapes[0]

        # Fusionner les cellules.
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        presentation.save("cells_merged.pptx", slides.export.SaveFormat.PPTX)
```