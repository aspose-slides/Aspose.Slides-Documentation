---
title: Hyperlien
type: docs
weight: 130
url: /fr/python-net/examples/elements/hyperlink/
keywords:
- hyperlien
- ajouter un hyperlien
- accéder à un hyperlien
- supprimer hyperlien
- mettre à jour hyperlien
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Ajouter, modifier et supprimer des hyperliens en Python avec Aspose.Slides: texte du lien, formes, diapositives, URL et e-mail; définir les cibles et les actions pour PPT, PPTX et ODP."
---
Démontre l'ajout, l'accès, la suppression et la mise à jour des hyperliens sur les formes en utilisant **Aspose.Slides for Python via .NET**.

## **Ajouter un hyperlien**

Créez une forme rectangulaire avec un hyperlien pointant vers un site Web externe.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à un hyperlien**

Lisez les informations d'hyperlien à partir de la portion de texte d'une forme.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Supprimer un hyperlien**

Supprimez l'hyperlien du texte d'une forme.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Mettre à jour un hyperlien**

Modifiez la cible d'un hyperlien existant. Utilisez `HyperlinkManager` pour modifier le texte contenant déjà un hyperlien, ce qui reproduit la façon dont PowerPoint met à jour les hyperliens en toute sécurité.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Modifier un hyperlien dans du texte existant doit être fait via
        # HyperlinkManager plutôt que de définir la propriété directement.
        # Cela reproduit la façon dont PowerPoint met à jour les hyperliens en toute sécurité.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```