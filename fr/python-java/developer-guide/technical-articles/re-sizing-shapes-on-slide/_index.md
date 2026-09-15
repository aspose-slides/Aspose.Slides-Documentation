---
title: Redimensionner les formes sur les diapositives de présentation en Python via Java
type: docs
weight: 110
url: /fr/python-java/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- modifier la taille de la forme
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Python via Java — automatisez les ajustements de mise en page des diapositives et augmentez votre productivité."
---
## **Aperçu**

L'une des questions les plus fréquentes des clients d'Aspose.Slides pour Python via Java porte sur la façon de redimensionner les formes afin que, lorsque la taille de la diapositive change, les données ne soient pas tronquées. Cet article technique court montre comment faire cela.

## **Redimensionner les formes**

Pour éviter que les formes ne se désalignent lorsque la taille de la diapositive change, mettez à jour la position et les dimensions de chaque forme afin qu’elles correspondent à la nouvelle mise en page de la diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Charger le fichier de présentation.
presentation = Presentation("sample.ppt")
try:
    # Obtenir la taille originale de la diapositive.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Obtenir la nouvelle taille de la diapositive.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Redimensionner et repositionner les formes sur chaque diapositive.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Mettre à l'échelle la taille de la forme.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Mettre à l'échelle la position de la forme.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
Les tableaux ne nécessitent aucun traitement spécial : définir la largeur et la hauteur d'un tableau redimensionne proportionnellement ses colonnes et lignes, de sorte qu'un redimensionnement supplémentaire des hauteurs de lignes et des largeurs de colonnes appliquerait le ratio deux fois.
{{% /alert %}} 

Le code ci‑dessus ne modifie que les formes des diapositives. Les diapositives maîtres et les diapositives de mise en page conservent leurs propres formes, il faut donc les redimensionner également lorsque vous souhaitez que l’ensemble de la présentation suive la nouvelle taille de diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Obtenir la taille originale de la diapositive.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Obtenir la nouvelle taille de la diapositive.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Mettre à l'échelle la taille de la forme.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Mettre à l'échelle la position de la forme.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Mettre à l'échelle la taille de la forme.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Mettre à l'échelle la position de la forme.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Mettre à l'échelle la taille de la forme.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Mettre à l'échelle la position de la forme.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Pourquoi les formes sont‑elles déformées ou tronquées après le redimensionnement d’une diapositive ?**

Lorsque vous redimensionnez une diapositive, les formes conservent leur position et leur taille d'origine, sauf si l'échelle est modifiée explicitement. Cela peut entraîner le recadrage du contenu ou le désalignement des formes.

**Le code fourni fonctionne‑t‑il pour tous les types de formes ?**

Oui. La définition de la hauteur et de la largeur fonctionne de la même manière pour les zones de texte, les images, les graphiques et les tableaux.

**Comment redimensionner les tableaux lors du redimensionnement d’une diapositive ?**

Redimensionnez la forme du tableau elle‑même, exactement comme n’importe quelle autre forme. Ses lignes et colonnes s’ajustent proportionnellement, il ne faut donc pas les redimensionner à nouveau par la suite.

**Ce redimensionnement fonctionnera‑t‑il pour les diapositives maîtres et les diapositives de mise en page ?**

Oui, mais vous devez également parcourir [Presentation.getMasters](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getMasters) et [Presentation.getLayoutSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getLayoutSlides) et appliquer la même logique de mise à l’échelle à leurs formes afin d’assurer la cohérence de l’ensemble de la présentation.

**Puis‑je changer l’orientation d’une diapositive (portrait/paysage) en même temps que le redimensionnement ?**

Oui. Vous pouvez utiliser [SlideSize.setOrientation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/#setOrientation) pour changer l’orientation. Assurez‑vous de définir la logique de mise à l’échelle en conséquence afin de préserver la mise en page.

**Existe‑t‑il une limite à la taille de diapositive que je peux définir ?**

Aspose.Slides prend en charge les tailles personnalisées, mais des tailles très grandes peuvent affecter les performances ou la compatibilité avec certaines versions de PowerPoint.

**Comment empêcher les formes à rapport d’aspect fixe de se déformer ?**

Vous pouvez vérifier la méthode [getAspectRatioLocked](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) du verrou de forme avant de mettre à l’échelle. Si elle est verrouillée, ajustez la largeur ou la hauteur proportionnellement plutôt que de les mettre à l’échelle individuellement.