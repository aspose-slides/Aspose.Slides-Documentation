---
title: Connecteur
type: docs
weight: 190
url: /fr/python-net/examples/elements/connector/
keywords:
- connecteur
- ajouter un connecteur
- accéder à un connecteur
- supprimer un connecteur
- reconnecter des formes
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Dessinez et contrôlez les connecteurs en Python avec Aspose.Slides : ajoutez, routez, reroutez, définissez les points de connexion, les flèches et les styles pour relier des formes dans PPT, PPTX et ODP."
---
Montre comment connecter des formes avec des connecteurs et modifier leurs cibles en utilisant **Aspose.Slides for Python via .NET**.

## **Ajouter un connecteur**

Insérez une forme de connecteur entre deux points de la diapositive.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Ajouter une forme de connecteur coudé.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à un connecteur**

Récupérez la première forme de connecteur ajoutée à une diapositive.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Accéder au premier connecteur de la diapositive.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Supprimer un connecteur**

Supprimez un connecteur de la diapositive.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposons que la première forme soit un connecteur.
        connector = slide.shapes[0]

        # Supprimer le connecteur.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Reconnecter des formes**

Attachez un connecteur à deux formes en attribuant des cibles de départ et d'arrivée.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Ajouter la première forme rectangulaire.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Ajouter la deuxième forme rectangulaire.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Ajouter une forme de connecteur coudé.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Connecter le début du connecteur à la première forme.
        connector.start_shape_connected_to = shape1
        # Connecter la fin du connecteur à la deuxième forme.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```