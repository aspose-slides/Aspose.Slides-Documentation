---
title: Gérer les arrière-plans de présentation en Python via Java
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/python-java/presentation-background/
keywords:
- arrière-plan de présentation
- arrière-plan de diapositive
- couleur unie
- couleur dégradée
- arrière-plan d'image
- transparence d'arrière-plan
- propriétés d'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à définir des arrière-plans dynamiques dans les fichiers PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via Java, avec des astuces de code pour améliorer vos présentations."
---
## **Introduction**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière‑plan de diapositive. Vous pouvez définir l'arrière‑plan d'une **diapositive normale** (une seule diapositive) ou d'une **diapositive maître** (s’applique à plusieurs diapositives à la fois).

![PowerPoint background](powerpoint-background.png)

## **Définir un arrière‑plan de couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan d’une diapositive spécifique dans une présentation—même si la présentation utilise une diapositive maître. La modification ne s’applique qu’à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#getsolidfillcolor) sur [FillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/) pour spécifier la couleur de remplissage solide.
5. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment définir une couleur bleue unie comme arrière‑plan d’une diapositive normale :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Créez une instance de la classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Définissez la couleur d'arrière-plan de la diapositive en bleu.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Enregistrez la présentation sur le disque.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir un arrière‑plan de couleur unie pour une diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan de la diapositive maître d’une présentation. La diapositive maître agit comme modèle qui contrôle la mise en forme de toutes les diapositives ; ainsi, lorsqu’une couleur unie est choisie pour l’arrière‑plan de la diapositive maître, elle s’applique à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/backgroundtype/) de la diapositive maître (via [getMasters](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getmasters)) sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) de l’arrière‑plan de la diapositive maître sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#getsolidfillcolor) pour spécifier la couleur de remplissage solide.
5. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment définir une couleur verte unie comme arrière‑plan d’une diapositive maître :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Créez une instance de la classe Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Définissez la couleur d'arrière-plan de la diapositive maître en vert.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Enregistrez la présentation sur le disque.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir un arrière‑plan dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une variation graduelle de couleur. Utilisé comme arrière‑plan de diapositive, le dégradé peut rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur dégradée comme arrière‑plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Gradient`.
4. Utilisez la méthode [getGradientFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#getgradientformat) sur [FillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/) pour configurer les paramètres de dégradé souhaités.
5. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment définir une couleur dégradée comme arrière‑plan d’une diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Créez une instance de la classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Appliquez un effet de dégradé à l'arrière-plan.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Ajoutez les couleurs du dégradé. Sans arrêts de dégradé, l'arrière-plan revient à une rampe noire-blanche par défaut.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Enregistrez la présentation sur le disque.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir une image comme arrière‑plan de diapositive**

En plus des remplissages unis et dégradés, Aspose.Slides vous permet d’utiliser des images comme arrière‑plan de diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Picture`.
4. Chargez l’image que vous souhaitez utiliser comme arrière‑plan de diapositive.
5. Ajoutez l’image à la collection d’images de la présentation.
6. Utilisez la méthode [getPictureFillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#getpicturefillformat) sur [FillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/) pour affecter l’image à l’arrière‑plan.
7. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment définir une image comme arrière‑plan d’une diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Créez une instance de la classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Définissez les propriétés de l'image d'arrière-plan.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Chargez l'image.
    image = Images.fromFile("Tulips.jpg")
    # Ajoutez l'image à la collection d'images de la présentation.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Enregistrez la présentation sur le disque.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L’exemple de code suivant montre comment définir le type de remplissage d’arrière‑plan sur une image en mosaïque et modifier les propriétés de mosaïquage :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Définissez l'image utilisée pour le remplissage de l'arrière-plan.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Définissez le mode de remplissage de l'image sur Tuile et ajustez les propriétés de la tuile.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
En savoir plus : [Tile Picture as Texture](/slides/fr/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l’image d’arrière‑plan**

Vous pouvez souhaiter ajuster la transparence de l’image d’arrière‑plan d’une diapositive afin que le contenu de la diapositive ressorte davantage. Le code Python suivant montre comment modifier la transparence d’une image d’arrière‑plan de diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Par exemple.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Obtenez la collection des opérations de transformation d'image.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Trouvez un effet de transparence à pourcentage fixe existant.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Définissez la nouvelle valeur de transparence.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtenir la valeur d’arrière‑plan de la diapositive**

Aspose.Slides vous permet de récupérer les valeurs d’arrière‑plan effectives d’une diapositive à l’aide de la méthode [getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/background/#geteffective) sur [Background](https://reference.aspose.com/slides/fr/python-java/aspose.slides/background/). Les données renvoyées exposent les formats de remplissage et d’effet effectifs.

En utilisant la méthode [getBackground](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getbackground) de la classe [BaseSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/), vous pouvez obtenir l’arrière‑plan d’une diapositive.

L’exemple Python suivant montre comment obtenir la valeur d’arrière‑plan effective d’une diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Créez une instance de la classe Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Récupérez l'arrière-plan effectif, en tenant compte du maître, de la mise en page et du thème.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je réinitialiser un arrière‑plan personnalisé et restaurer l’arrière‑plan du thème / mise en page ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l’arrière‑plan sera de nouveau hérité de la diapositive [layout](/slides/fr/python-java/slide-layout/)/[master](/slides/fr/python-java/slide-master/) correspondante (c’est‑à‑dire du [background du thème](/slides/fr/python-java/presentation-theme/)).

**Que se passe‑t‑il avec l’arrière‑plan si je change plus tard le thème de la présentation ?**

Si une diapositive possède son propre remplissage, celui‑ci restera inchangé. Si l’arrière‑plan est hérité du [layout](/slides/fr/python-java/slide-layout/)/[master](/slides/fr/python-java/slide-master/), il sera mis à jour pour correspondre au [nouveau thème](/slides/fr/python-java/presentation-theme/).