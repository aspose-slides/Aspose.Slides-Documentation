---
title: Zone de texte
type: docs
weight: 40
url: /fr/python-net/examples/elements/text-box/
keywords:
- zone de texte
- ajouter zone de texte
- accéder à la zone de texte
- supprimer la zone de texte
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Créer et formater des zones de texte en Python avec Aspose.Slides : définir les polices, l'alignement, le retour à la ligne, l'ajustement automatique et les liens pour peaufiner les diapositives PowerPoint et OpenDocument."
---
Dans Aspose.Slides, une **zone de texte** est représentée par un `AutoShape`. Presque toutes les formes peuvent contenir du texte, mais une zone de texte typique n'a ni remplissage ni bordure et n'affiche que du texte.

Ce guide explique comment ajouter, accéder et supprimer des zones de texte par programme.

## **Ajouter une zone de texte**

Une zone de texte n'est qu'un `AutoShape` sans remplissage ni bordure et contenant du texte formaté. Voici comment en créer une :

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Créez une forme rectangulaire (remplie par défaut avec bordure et aucun texte).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Supprimez le remplissage et la bordure pour qu'elle ressemble à une zone de texte typique.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Définissez le format du texte.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Attribuez le texte réel.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Remarque :** Tout `AutoShape` contenant un `TextFrame` non vide peut fonctionner comme une zone de texte.

## **Accéder aux zones de texte par contenu**

Pour trouver toutes les zones de texte contenant un mot-clé spécifique (par ex. "Slide"), parcourez les formes et vérifiez leur texte :

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Seules les AutoShapes peuvent contenir du texte éditable.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Faire quelque chose avec la zone de texte correspondante.
                    pass
```

## **Supprimer les zones de texte par contenu**

Cet exemple trouve et supprime toutes les zones de texte de la première diapositive qui contiennent un mot-clé spécifique :

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Trouvez les formes à supprimer qui sont des AutoShapes contenant le mot "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Supprimez chaque forme correspondante de la diapositive.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Astuce :** Créez toujours une copie de la collection de formes avant de la modifier pendant l'itération pour éviter les erreurs de modification de collection.