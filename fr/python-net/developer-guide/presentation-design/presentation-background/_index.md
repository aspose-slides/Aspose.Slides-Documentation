---
title: Arrière-plan de la présentation
type: docs
weight: 20
url: /python-net/presentation-background/
keywords: "arrière-plan PowerPoint, définir l'arrière-plan, Python, Aspose.Slides pour Python via .NET"
description: "Définir l'arrière-plan dans une présentation PowerPoint en Python"
---

Les couleurs unies, les couleurs dégradées et les images sont souvent utilisées comme images d'arrière-plan pour les diapositives. Vous pouvez définir l'arrière-plan soit pour une **diapositive normale** (diapositive unique) ou pour une **diapositive maîtresse** (plusieurs diapositives à la fois).

<img src="powerpoint-background.png" alt="powerpoint-background" />

## **Définir une couleur unie comme arrière-plan pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour une diapositive spécifique dans une présentation (même si cette présentation contient une diapositive maîtresse). Le changement d'arrière-plan n'affecte que la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) pour l'arrière-plan de la diapositive sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) exposée par [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour spécifier une couleur unie pour l'arrière-plan.
5. Enregistrez la présentation modifiée.

Ce code Python vous montre comment définir une couleur unie (bleu) comme arrière-plan pour une diapositive normale :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crée une instance de la classe Presentation
with slides.Presentation() as pres:
    # Définit la couleur d'arrière-plan de la première ISlide sur Bleu
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.slides[0].background.fill_format.solid_fill_color.color = draw.Color.blue
    # Écrit la présentation sur le disque
    pres.save("ContentBG_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir une couleur unie comme arrière-plan pour une diapositive maîtresse**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour la diapositive maîtresse dans une présentation. La diapositive maîtresse agit comme un modèle qui contient et contrôle les paramètres de formatage pour toutes les diapositives. Par conséquent, lorsque vous sélectionnez une couleur unie comme arrière-plan pour la diapositive maîtresse, ce nouvel arrière-plan sera utilisé pour toutes les diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) pour la diapositive maîtresse (`Masters`) sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) pour l'arrière-plan de la diapositive maîtresse sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) exposée par [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour spécifier une couleur unie pour l'arrière-plan.
5. Enregistrez la présentation modifiée.

Ce code Python vous montre comment définir une couleur unie (vert forêt) comme arrière-plan pour une diapositive maîtresse dans une présentation :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crée une instance de la classe Presentation
with slides.Presentation() as pres:
    # Définit la couleur d'arrière-plan de la Master ISlide sur Vert Forêt
    pres.masters[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.masters[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.masters[0].background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Écrit la présentation sur le disque
    pres.save("SetSlideBackgroundMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir une couleur dégradée comme arrière-plan pour une diapositive**

Un dégradé est un effet graphique basé sur un changement progressif de couleur. Les couleurs dégradées, lorsqu'elles sont utilisées comme arrière-plans pour les diapositives, donnent aux présentations un aspect artistique et professionnel. Aspose.Slides vous permet de définir une couleur dégradée comme arrière-plan pour les diapositives dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) pour l'arrière-plan de la diapositive maîtresse sur `Gradient`.
4. Utilisez la propriété [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) exposée par [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour spécifier vos paramètres de dégradé préférés.
5. Enregistrez la présentation modifiée.

Ce code Python vous montre comment définir une couleur dégradée comme arrière-plan pour une diapositive :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crée une instance de la classe Presentation
with slides.Presentation(path + "SetBackgroundToGradient.pptx") as pres:
    # Applique l'effet de dégradé à l'arrière-plan
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.GRADIENT
    pres.slides[0].background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Écrit la présentation sur le disque
    pres.save("ContentBG_Grad_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir une image comme arrière-plan pour une diapositive**

Outre les couleurs unies et les couleurs dégradées, Aspose.Slides permet également de définir des images comme arrière-plan pour les diapositives dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) pour l'arrière-plan de la diapositive maîtresse sur `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme arrière-plan de la diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la propriété [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) exposée par [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour définir l'image comme arrière-plan.
7. Enregistrez la présentation modifiée.

Ce code Python vous montre comment définir une image comme arrière-plan pour une diapositive :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crée une instance de la classe Presentation
with slides.Presentation(path + "SetImageAsBackground.pptx") as pres:
    # Définit les conditions pour l'image d'arrière-plan
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.PICTURE
    pres.slides[0].background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Charge l'image
    img = draw.Bitmap(path + "Tulips.jpg")

    # Ajoute l'image à la collection d'images de la présentation
    imgx = pres.images.add_image(img)

    pres.slides[0].background.fill_format.picture_fill_format.picture.image = imgx

    # Écrit la présentation sur le disque
    pres.save("ContentBG_Img_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Modifier la transparence de l'image d'arrière-plan**

Vous souhaiterez peut-être ajuster la transparence de l'image d'arrière-plan d'une diapositive pour faire ressortir le contenu de la diapositive. Ce code Python vous montre comment changer la transparence pour une image d'arrière-plan de diapositive :

```python
transparencyValue = 30 # par exemple

# Obtient une collection d'opérations de transformation d'image
imageTransform = pres.slides[0].background.fill_format.picture_fill_format.picture.image_transform

transparencyOperation = None
# Trouve un effet de transparence avec un pourcentage fixe.
for operation in imageTransform:
    if type(operation) is slides.AlphaModulateFixed:
        transparencyOperation = operation
        break

# Définit la nouvelle valeur de transparence.
if transparencyOperation is None:
    imageTransform.add_alpha_modulate_fixed_effect(100 - transparencyValue)
else:
    transparencyOperation.amount = (100 - transparencyValue)
```

## **Obtenir la valeur de l'arrière-plan de la diapositive**

Aspose.Slides fournit l'interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) pour vous permettre d'obtenir les valeurs effectives des arrière-plans de diapositives. Cette interface contient des informations sur le [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) effectif et l'[EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) effectif.

En utilisant la propriété [Background](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/#properties) de la classe [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), vous pouvez obtenir la valeur effective pour un arrière-plan de diapositive.

Ce code Python vous montre comment obtenir la valeur d'arrière-plan effective d'une diapositive :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crée une instance de la classe Presentation
with slides.Presentation(path + "SamplePresentation.pptx") as pres:

    effBackground = pres.slides[0].background.get_effective()

    if effBackground.fill_format.fill_type == slides.FillType.SOLID:
        print("Couleur de remplissage : " + str(effBackground.fill_format.solid_fill_color))
    else:
        print("Type de remplissage : " + str(effBackground.fill_format.fill_type))
```