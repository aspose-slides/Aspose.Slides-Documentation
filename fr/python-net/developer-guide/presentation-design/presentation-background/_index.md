---
title: Gérer les arrière-plans de présentation en Python
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/python-net/presentation-background/
keywords:
- arrière-plan de présentation
- arrière-plan de diapositive
- couleur unie
- couleur en dégradé
- arrière-plan d'image
- transparence de l'arrière-plan
- propriétés de l'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à définir des arrière-plans dynamiques dans PowerPoint et les fichiers OpenDocument à l'aide d'Aspose.Slides pour Python via .NET, avec des astuces de code pour améliorer vos présentations."
---

## **Vue d'ensemble**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière-plans de diapositive. Vous pouvez définir l'arrière‑plan d'une **diapositive normale** (une seule diapositive) ou d'une **diapositive maître** (s'applique à plusieurs diapositives à la fois).

![Arrière‑plan PowerPoint](powerpoint-background.png)

## **Définir un arrière‑plan de couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan d'une diapositive spécifique d'une présentation — même si la présentation utilise une diapositive maître. La modification s’applique uniquement à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez la [BackgroundType] de la diapositive sur `OWN_BACKGROUND`.
3. Définissez le [FillType] de l'arrière‑plan de la diapositive sur `SOLID`.
4. Utilisez la propriété `solid_fill_color` de [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour spécifier la couleur unie de l'arrière‑plan.
5. Enregistrez la présentation modifiée.

Le code Python suivant montre comment définir une couleur bleue unie comme arrière‑plan d'une diapositive normale :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set the background color of the slide to blue.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Save the presentation to disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir un arrière‑plan de couleur unie pour la diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan de la diapositive maître d’une présentation. La diapositive maître agit comme un modèle qui contrôle le formatage de toutes les diapositives, de sorte que choisir une couleur unie pour l’arrière‑plan de la diapositive maître l’applique à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez la [BackgroundType] de la diapositive maître (via `masters`) sur `OWN_BACKGROUND`.
3. Définissez le [FillType] de l'arrière‑plan de la diapositive maître sur `SOLID`.
4. Utilisez la propriété `solid_fill_color` de [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour spécifier la couleur unie de l'arrière‑plan.
5. Enregistrez la présentation modifiée.

Le code Python suivant montre comment définir une couleur unie (vert forêt) comme arrière‑plan de la diapositive maître :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Set the background color for the Master slide to Forest Green.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Save the presentation to disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir un arrière‑plan en dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une variation progressive des couleurs. Lorsqu’il est utilisé comme arrière‑plan de diapositive, le dégradé peut rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur en dégradé comme arrière‑plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez la [BackgroundType] de la diapositive sur `OWN_BACKGROUND`.
3. Définissez le [FillType] de l'arrière‑plan de la diapositive sur `GRADIENT`.
4. Utilisez la propriété `gradient_format` de [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour configurer les paramètres de dégradé souhaités.
5. Enregistrez la présentation modifiée.

Le code Python suivant montre comment définir une couleur en dégradé comme arrière‑plan d’une diapositive :

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Apply a gradient effect to the background.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Save the presentation to disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Utiliser une image comme arrière‑plan de diapositive**

En plus des remplissages unis et en dégradé, Aspose.Slides vous permet d’utiliser des images comme arrière‑plan de diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez la [BackgroundType] de la diapositive sur `OWN_BACKGROUND`.
3. Définissez le [FillType] de l'arrière‑plan de la diapositive sur `PICTURE`.
4. Chargez l'image que vous souhaitez utiliser comme arrière‑plan de la diapositive.
5. Ajoutez l'image à la collection d’images de la présentation.
6. Utilisez la propriété `picture_fill_format` de [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour affecter l'image à l'arrière‑plan.
7. Enregistrez la présentation modifiée.

Le code Python suivant montre comment définir une image comme arrière‑plan d’une diapositive :

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set background image properties.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Add the image to the presentation's image collection.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Save the presentation to disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

Le code suivant montre comment définir le type de remplissage d'arrière‑plan sur une image en mosaïque et modifier les propriétés de mosaïquage :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Set the image used for the background fill.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Set the picture fill mode to Tile and adjust the tile properties.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
Read more: [**Image mosaïquée comme texture**](/slides/fr/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l'image d'arrière‑plan**

Vous pouvez souhaiter ajuster la transparence de l’image d’arrière‑plan d’une diapositive afin que le contenu de la diapositive ressorte davantage. Le code Python suivant montre comment changer la transparence d’une image d’arrière‑plan de diapositive :

```python
transparency_value = 30  # For example.

# Get the collection of picture transform operations.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Find an existing fixed-percentage transparency effect.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Set the new transparency value.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Obtention de la valeur d'arrière‑plan de la diapositive**

Aspose.Slides fournit la classe [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) pour récupérer les valeurs effectives d’arrière‑plan d’une diapositive. Cette classe expose le [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) et le [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) effectifs.

En utilisant la propriété `background` de la classe [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), vous pouvez obtenir l’arrière‑plan effectif d’une diapositive.

Le code Python suivant montre comment obtenir la valeur d’arrière‑plan effectif d’une diapositive :

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Retrieve the effective background, taking into account master, layout, and theme.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Puis-je réinitialiser un arrière‑plan personnalisé et restaurer l'arrière‑plan du thème/mise en page ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l’arrière‑plan sera de nouveau hérité de la diapositive [mise en page](/slides/fr/python-net/slide-layout/)/[maître](/slides/fr/python-net/slide-master/) correspondante (c’est‑à‑dire du [arrière‑plan du thème](/slides/fr/python-net/presentation-theme/)).

**Que se passe-t-il à l'arrière‑plan si je change le thème de la présentation ultérieurement ?**

Si une diapositive possède son propre remplissage, il restera inchangé. Si l’arrière‑plan est hérité de la [mise en page](/slides/fr/python-net/slide-layout/)/[maître](/slides/fr/python-net/slide-master/), il sera mis à jour pour correspondre au [nouveau thème](/slides/fr/python-net/presentation-theme/).