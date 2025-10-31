---
title: Obtenir l'intégralité de l'arrière-plan d'une diapositive d'une présentation sous forme d'image
linktitle: Arrière-plan complet de la diapositive
type: docs
weight: 95
url: /fr/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- diapositive
- arrière-plan
- arrière-plan de diapositive
- arrière-plan final
- arrière-plan en image
- PowerPoint
- OpenDocument
- présentation
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Extrayez les arrière-plans complets des diapositives sous forme d'images à partir de présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via .NET, simplifiant les flux de travail visuels."
---

## **Obtenir l'intégralité de l'arrière-plan de la diapositive**

Dans les présentations PowerPoint, l'arrière‑plan d'une diapositive peut être composé de plusieurs éléments. En plus de l'image définie comme le [arrière-plan de diapositive](/slides/fr/python-net/presentation-background/), l'arrière‑plan final peut être influencé par le thème de la présentation, le schéma de couleurs et les formes placées sur la diapositive maître et la diapositive de mise en page.

Aspose.Slides pour Python ne fournit pas de méthode simple pour extraire l'intégralité de l'arrière‑plan d'une diapositive de présentation sous forme d'image, mais vous pouvez suivre les étapes ci‑dessous pour le faire :
1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la taille de la diapositive à partir de la présentation.
3. Sélectionnez une diapositive.
4. Créez une présentation temporaire.
5. Définissez la même taille de diapositive dans la présentation temporaire.
6. Clonez la diapositive sélectionnée dans la présentation temporaire.
7. Supprimez les formes de la diapositive clonée.
8. Convertissez la diapositive clonée en image.

L'exemple de code suivant extrait l'intégralité de l'arrière‑plan de la diapositive de la présentation sous forme d'image.
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

## **FAQ**

**Les dégradés complexes, textures ou remplissages d'image provenant d'une diapositive maître seront-ils conservés dans l'image d'arrière‑plan résultante ?**

Oui. Aspose.Slides rend les remplissages de type dégradé, image et texture définis sur la diapositive, la mise en page ou le maître. Si vous devez isoler l'apparence des maîtres hérités, [définissez un arrière‑plan propre](/slides/fr/python-net/presentation-background/) sur la diapositive actuelle avant l'exportation.

**Puis-je ajouter un filigrane à l'image d'arrière‑plan résultante avant de l'enregistrer ?**

Oui. Vous pouvez [ajouter un filigrane](/slides/fr/python-net/watermark/) sous forme de forme ou d'image sur une [copie de la diapositive](/slides/fr/python-net/clone-slides/) de travail (placée derrière le reste du contenu) puis exporter. Cela vous permet de générer une image d'arrière‑plan avec le filigrane intégré.

**Puis-je obtenir l'arrière‑plan d'une mise en page ou d'un maître spécifique sans le lier à une diapositive existante ?**

Oui. Accédez au maître ou à la mise en page souhaité(e), appliquez‑le à une [diapositive temporaire](/slides/fr/python-net/clone-slides/) avec la taille requise, puis exportez cette diapositive pour obtenir l'arrière‑plan dérivé de cette mise en page ou de ce maître.

**Existe‑t‑il des limitations de licence affectant l'exportation d'images ?**

Les fonctionnalités de rendu sont entièrement disponibles avec une [licence valide](/slides/fr/python-net/licensing/). En mode d'évaluation, la sortie peut comporter des limitations comme un filigrane. Activez la licence une fois par processus avant d'exécuter des exportations par lots.