---
title: Obtenir l'Arrière-Plan de la Diapositive de Présentation Complète en Tant qu'Image
type: docs
weight: 95
url: /fr/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositive
- arrière-plan
- arrière-plan de diapositive
- arrière-plan en une image
- PowerPoint
- PPT
- PPTX
- présentation PowerPoint
- Python
- Aspose.Slides pour Python
---

Dans les présentations PowerPoint, l'arrière-plan de la diapositive peut se composer de nombreux éléments. En plus de l'image définie comme [arrière-plan de diapositive](/slides/fr/python-net/presentation-background/), l'arrière-plan final peut être influencé par le thème de la présentation, le schéma de couleurs et les formes placées sur la diapositive principale et la diapositive de mise en page.

Aspose.Slides pour Python ne fournit pas de méthode simple pour extraire l'arrière-plan complet de la diapositive de présentation en tant qu'image, mais vous pouvez suivre les étapes ci-dessous pour le faire :
1. Charger la présentation à l'aide de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir la taille de la diapositive à partir de la présentation.
1. Sélectionner une diapositive.
1. Créer une présentation temporaire.
1. Définir la même taille de diapositive dans la présentation temporaire.
1. Cloner la diapositive sélectionnée dans la présentation temporaire.
1. Supprimer les formes de la diapositive clonée.
1. Convertir la diapositive clonée en une image.

L'exemple de code suivant extrait l'arrière-plan complet de la diapositive de présentation en tant qu'image.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```