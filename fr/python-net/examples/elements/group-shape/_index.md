---
title: Forme de groupe
type: docs
weight: 170
url: /fr/python-net/examples/elements/group-shape/
keywords:
- groupe
- ajouter forme de groupe
- accéder forme de groupe
- supprimer forme de groupe
- dissocier les formes
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Travailler avec les formes de groupe en Python à l'aide d'Aspose.Slides : créer et dissocier, réorganiser les formes enfants, définir les transformations et les limites dans PowerPoint et OpenDocument."
---
Exemples de création de groupes de formes, d'accès à ceux-ci, de dissociation et de suppression à l'aide d'**Aspose.Slides for Python via .NET**.

## **Ajouter une forme de groupe**

Créer un groupe contenant deux formes de base.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Ajouter une forme de groupe.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à une forme de groupe**

Récupérer la première forme de groupe d'une diapositive.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Accéder à la première forme de groupe sur la diapositive.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Supprimer une forme de groupe**

Supprimer une forme de groupe de la diapositive.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposons que la première forme soit une forme de groupe.
        group = slide.shapes[0]

        # Supprimer la forme de groupe.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Dissocier les formes**

Déplacer les formes hors d'un conteneur de groupe.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposons que la première forme soit une forme de groupe.
        group = slide.shapes[0]

        # Déplacer les formes hors du groupe.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```