---
title: Obtenir l'arrière-plan complet d'une diapositive à partir d'une présentation sous forme d'image
linktitle: Arrière-plan complet de la diapositive
type: docs
weight: 95
url: /fr/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- arrière‑plan de diapositive
- arrière‑plan final
- extraire l'arrière‑plan
- arrière‑plan complet
- arrière‑plan en image
- arrière‑plan PPT
- arrière‑plan PPTX
- arrière‑plan ODP
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Extrait les arrière‑plans complets des diapositives sous forme d'images à partir de présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides for Python via Java, simplifiant les flux de travail visuels."
---
## **Aperçu**

Dans les présentations PowerPoint, l'arrière‑plan d'une diapositive peut être constitué de plusieurs éléments, notamment l'image d'arrière‑plan de la diapositive, le thème de la présentation, le jeu de couleurs et les objets placés sur la diapositive maître ou la diapositive de mise en page.

Cet article montre comment extraire l'intégralité de l'arrière‑plan d'une diapositive sous forme d'image en utilisant Aspose.Slides for Python via Java. Comme il n'existe pas de méthode unique pour cette tâche, l'approche consiste à cloner la diapositive sélectionnée dans une présentation temporaire, à supprimer les formes de la diapositive, puis à convertir l'arrière‑plan résultant en image.

## **Obtenir l'arrière‑plan complet de la diapositive**

Aspose.Slides for Python via Java ne fournit pas de méthode simple pour extraire l'intégralité de l'arrière‑plan d'une diapositive de présentation sous forme d'image, mais vous pouvez suivre les étapes ci‑dessous pour le faire :

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez la taille de la diapositive à partir de la présentation.
1. Sélectionnez une diapositive.
1. Créez une présentation temporaire.
1. Définissez la même taille de diapositive dans la présentation temporaire.
1. Clonez la diapositive sélectionnée dans la présentation temporaire.
1. Supprimez les formes de la diapositive clonée.
1. Convertissez la diapositive clonée en image.

L'exemple de code suivant extrait l'intégralité de l'arrière‑plan de la diapositive de la présentation sous forme d'image.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Les dégradés complexes, les textures ou les remplissages d'image provenant d'une diapositive maître seront-ils conservés dans l'image d'arrière‑plan résultante ?**

Oui. Aspose.Slides rend les remplissages en dégradé, image et texture définis sur la diapositive, la disposition ou le maître. Si vous devez isoler l'apparence des maîtres hérités, [définissez un arrière‑plan personnalisé](/slides/fr/python-java/presentation-background/) sur la diapositive actuelle avant l'exportation.

**Puis-je ajouter un filigrane à l'image d'arrière‑plan résultante avant de l'enregistrer ?**

Oui. Vous pouvez [ajouter un filigrane](/slides/fr/python-java/watermark/) en forme ou image sur une [copie de travail de la diapositive](/slides/fr/python-java/clone-slides/) (placée derrière le reste du contenu) puis exporter. Cela vous permet de générer une image d'arrière‑plan avec le filigrane intégré.

**Puis-je obtenir l'arrière‑plan d'une disposition ou d'un maître spécifique sans le lier à une diapositive existante ?**

Oui. Accédez au maître ou à la disposition souhaité(e), appliquez‑le à une [diapositive temporaire](/slides/fr/python-java/clone-slides/) avec la taille requise, puis exportez cette diapositive pour obtenir l'arrière‑plan dérivé de cette disposition ou de ce maître.

**Existe‑t‑il des limitations de licence qui affectent l'exportation d'images ?**

Les fonctionnalités de rendu sont entièrement disponibles avec une [licence valide](/slides/fr/python-java/licensing/). En mode d'évaluation, la sortie peut comporter des limitations comme un filigrane. Activez la licence une fois par processus avant d'exécuter les exportations par lots.