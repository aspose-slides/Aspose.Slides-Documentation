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
- couleur dégradée
- arrière-plan d'image
- transparence d'arrière-plan
- propriétés d'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à définir des arrière-plans dynamiques dans les fichiers PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via .NET, avec des astuces de code pour améliorer vos présentations."
---

## **Vue d’ensemble**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière‑plans de diapositives. Vous pouvez définir l'arrière‑plan d’une **diapositive normale** (une seule diapositive) ou d’une **diapositive maîtresse** (s’applique à plusieurs diapositives à la fois).

![Arrière‑plan PowerPoint](powerpoint-background.png)

## **Définir un arrière‑plan couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan pour une diapositive spécifique d’une présentation — même si la présentation utilise une diapositive maîtresse. La modification ne s’applique qu’à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez la propriété [BackgroundType] de la diapositive sur `OWN_BACKGROUND`.
3. Définissez la propriété [FillType] de l’arrière‑plan de la diapositive sur `SOLID`.
4. Utilisez la propriété `solid_fill_color` de [FillFormat] pour spécifier la couleur unie de l’arrière‑plan.
5. Enregistrez la présentation modifiée.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Définissez la couleur d'arrière‑plan de la diapositive en bleu.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Enregistrez la présentation sur le disque.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir un arrière‑plan couleur unie pour la diapositive maîtresse**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan de la diapositive maîtresse d’une présentation. La diapositive maîtresse agit comme un modèle qui contrôle le formatage de toutes les diapositives, ainsi choisir une couleur unie pour l’arrière‑plan de la diapositive maîtresse l’appliquera à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez la propriété [BackgroundType] de la diapositive maîtresse (via `masters`) sur `OWN_BACKGROUND`.
3. Définissez la propriété [FillType] de l’arrière‑plan de la diapositive maîtresse sur `SOLID`.
4. Utilisez la propriété `solid_fill_color` de [FillFormat] pour spécifier la couleur unie de l’arrière‑plan.
5. Enregistrez la présentation modifiée.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Définissez la couleur d'arrière‑plan de la diapositive maîtresse sur Vert forêt.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Enregistrez la présentation sur le disque.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir un arrière‑plan dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une variation progressive de couleur. Lorsqu’il est utilisé comme arrière‑plan de diapositive, le dégradé peut rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur de dégradé comme arrière‑plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez la propriété [BackgroundType] de la diapositive sur `OWN_BACKGROUND`.
3. Définissez la propriété [FillType] de l’arrière‑plan de la diapositive sur `GRADIENT`.
4. Utilisez la propriété `gradient_format` de [FillFormat] pour configurer vos paramètres de dégradé préférés.
5. Enregistrez la présentation modifiée.

```python
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Appliquez un effet de dégradé à l'arrière‑plan.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Enregistrez la présentation sur le disque.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Utiliser une image comme arrière‑plan de diapositive**

En plus des remplissages unis et dégradés, Aspose.Slides vous permet d’utiliser des images comme arrière‑plans de diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez la propriété [BackgroundType] de la diapositive sur `OWN_BACKGROUND`.
3. Définissez la propriété [FillType] de l’arrière‑plan de la diapositive sur `PICTURE`.
4. Chargez l'image que vous souhaitez utiliser comme arrière‑plan de la diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la propriété `picture_fill_format` de [FillFormat] pour assigner l'image comme arrière‑plan.
7. Enregistrez la présentation modifiée.

```python
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Définissez les propriétés de l'image d'arrière‑plan.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Chargez l'image.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Ajoutez l'image à la collection d'images de la présentation.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Enregistrez la présentation sur le disque.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Définissez l'image utilisée pour le remplissage de l'arrière‑plan.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Définissez le mode de remplissage d'image sur Tile et ajustez les propriétés de tuilage.
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
En savoir plus : [**Tile Picture As Texture**](/slides/fr/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l'image d'arrière‑plan**

Vous pouvez souhaiter ajuster la transparence de l'image d'arrière‑plan d'une diapositive afin de faire ressortir le contenu de la diapositive. Le code Python suivant montre comment modifier la transparence d'une image d'arrière‑plan de diapositive :

```python
transparency_value = 30  # Par exemple.

# Obtenez la collection d'opérations de transformation d'image.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Recherchez un effet de transparence à pourcentage fixe existant.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Définissez la nouvelle valeur de transparence.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Obtenir la valeur d'arrière‑plan de la diapositive**

Aspose.Slides fournit la classe [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) pour récupérer les valeurs effectives d’arrière‑plan d’une diapositive. Cette classe expose les objets effectifs [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) et [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/).

En utilisant la propriété `background` de la classe [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), vous pouvez obtenir l’arrière‑plan effectif d’une diapositive.

```python
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Récupérez l'arrière‑plan effectif, en tenant compte du maître, de la disposition et du thème.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**Puis-je réinitialiser un arrière‑plan personnalisé et restaurer l'arrière‑plan du thème/de la disposition ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l'arrière‑plan sera de nouveau hérité de la diapositive [layout](/slides/fr/python-net/slide-layout/)/[master](/slides/fr/python-net/slide-master/) correspondante (c’est‑à‑dire le [theme background](/slides/fr/python-net/presentation-theme/)).

**Que se passe-t-il à l'arrière‑plan si je change le thème de la présentation ultérieurement ?**

Si une diapositive possède son propre remplissage, il restera inchangé. Si l'arrière‑plan provient du [layout](/slides/fr/python-net/slide-layout/)/[master](/slides/fr/python-net/slide-master/), il sera mis à jour pour correspondre au [new theme](/slides/fr/python-net/presentation-theme/).