---
title: Gérer le Placeholder
type: docs
weight: 10
url: /fr/python-net/manage-placeholder/
keywords: "Placeholder, Texte de Placeholder, Texte d'invite, Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Modifier le texte du Placeholder et le texte d'invite dans les présentations PowerPoint en Python"
---

## **Modifier le Texte dans un Placeholder**

En utilisant [Aspose.Slides pour Python via .NET](/slides/fr/python-net/), vous pouvez trouver et modifier des placeholders sur des diapositives dans des présentations. Aspose.Slides vous permet d'apporter des modifications au texte d'un placeholder.

**Prérequis** : Vous avez besoin d'une présentation contenant un placeholder. Vous pouvez créer une telle présentation dans l'application standard Microsoft PowerPoint.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans le placeholder de cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et passez la présentation en argument.
2. Obtenez une référence de diapositive par son index.
3. Parcourez les formes pour trouver le placeholder.
4. Castifiez la forme du placeholder en [`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) et changez le texte en utilisant le [`TextFrame`](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) associé à l[`AutoShape`](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
5. Enregistrez la présentation modifiée.

Ce code Python montre comment changer le texte dans un placeholder :

```python
import aspose.slides as slides

# Instancie une classe Presentation
with slides.Presentation(path + "ReplacingText.pptx") as pres:
    # Accède à la première diapositive
    sld = pres.slides[0]

    # Parcourt les formes pour trouver le placeholder
    for shp in sld.shapes:
        if shp.placeholder != None:
            # Change le texte dans chaque placeholder
            shp.text_frame.text = "Ceci est un Placeholder"

    # Enregistre la présentation sur le disque
    pres.save("output_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le Texte d'Invité dans un Placeholder**
Les mises en page standard et préconstruites contiennent des textes d'invite de placeholder tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous-titre***. En utilisant Aspose.Slides, vous pouvez insérer vos textes d'invite préférés dans les mises en page des placeholders.

Ce code Python vous montre comment définir le texte d'invite dans un placeholder :

```python
import aspose.slides as slides

with slides.Presentation(path + "Presentation2.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.slide.shapes: # Parcourt la diapositive
        if shape.placeholder != None and type(shape) is slides.AutoShape:
            text = ""
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE: # PowerPoint affiche "Cliquez pour ajouter un titre". 
                text = "Ajouter un Titre"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE: # Ajoute un sous-titre.
                text = "Ajouter un Sous-titre"

            shape.text_frame.text = text

            print("Placeholder avec texte : {text}".format(text = text))

    pres.save("Placeholders_PromptText.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la Transparence de l'Image du Placeholder**

Aspose.Slides vous permet de définir la transparence de l'image d'arrière-plan dans un placeholder de texte. En ajustant la transparence de l'image dans un tel cadre, vous pouvez faire ressortir le texte ou l'image (selon les couleurs du texte et de l'image).

Ce code Python vous montre comment définir la transparence pour un arrière-plan d'image (à l'intérieur d'une forme) :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoShape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    
    autoShape.fill_format.fill_type = slides.FillType.PICTURE
    with open("image.png", "rb") as in_file:
        autoShape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(in_file)

        autoShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        autoShape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)

```