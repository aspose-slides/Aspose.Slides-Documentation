---
title: Gérer les arrière-plans de présentation en Python
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/python-net/presentation-background/
keywords:
- arrière-plan de présentation
- arrière‑plan de diapositive
- couleur unie
- couleur dégradée
- arrière‑plan image
- transparence d'arrière‑plan
- propriétés d'arrière‑plan
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à définir des arrière‑plans dynamiques dans les fichiers PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET, avec des astuces de code pour améliorer vos présentations."
---

## **Aperçu**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière‑plan de diapositive. Vous pouvez définir l’arrière‑plan d’une **diapositive normale** (une diapositive unique) ou d’une **diapositive maître** (appliquée à plusieurs diapositives à la fois).

![PowerPoint background](powerpoint-background.png)

## **Définir un arrière‑plan couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan d’une diapositive spécifique d’une présentation — même si la présentation utilise une diapositive maître. La modification ne s’applique qu’à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositive sur `OWN_BACKGROUND`.
3. Définissez le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `SOLID`.
4. Utilisez la propriété `solid_fill_color` de [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour spécifier la couleur d’arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment définir une couleur bleue unie comme arrière‑plan d’une diapositive normale :
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Définissez la couleur d'arrière-plan de la diapositive en bleu.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Enregistrez la présentation sur le disque.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir un arrière‑plan couleur unie pour la diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan de la diapositive maître d’une présentation. La diapositive maître agit comme un modèle qui contrôle le formatage de toutes les diapositives, de sorte que le choix d’une couleur unie pour l’arrière‑plan de la diapositive maître s’applique à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositive maître (via `masters`) sur `OWN_BACKGROUND`.
3. Définissez le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de l’arrière‑plan de la diapositive maître sur `SOLID`.
4. Utilisez la propriété `solid_fill_color` de [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour spécifier la couleur d’arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment définir une couleur verte forêt comme arrière‑plan d’une diapositive maître :
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Définissez la couleur d'arrière-plan de la diapositive maître en vert forêt.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Enregistrez la présentation sur le disque.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir un arrière‑plan dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une transition graduelle de couleur. Lorsqu’il est utilisé comme arrière‑plan de diapositive, le dégradé peut donner un aspect plus artistique et professionnel aux présentations. Aspose.Slides vous permet de définir une couleur de dégradé comme arrière‑plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositive sur `OWN_BACKGROUND`.
3. Définissez le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `GRADIENT`.
4. Utilisez la propriété `gradient_format` de [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour configurer les paramètres de dégradé souhaités.
5. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment définir une couleur de dégradé comme arrière‑plan d’une diapositive :
```python
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Appliquez un effet de dégradé à l'arrière-plan.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Enregistrez la présentation sur le disque.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir une image comme arrière‑plan de diapositive**

En plus des remplissages unis et dégradés, Aspose.Slides vous permet d’utiliser des images comme arrière‑plan de diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositive sur `OWN_BACKGROUND`.
3. Définissez le [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `PICTURE`.
4. Chargez l’image que vous souhaitez utiliser comme arrière‑plan de diapositive.
5. Ajoutez l’image à la collection d’images de la présentation.
6. Utilisez la propriété `picture_fill_format` de [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) pour affecter l’image à l’arrière‑plan.
7. Enregistrez la présentation modifiée.

L’exemple Python suivant montre comment définir une image comme arrière‑plan d’une diapositive :
```python
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Définissez les propriétés de l'image d'arrière-plan.
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


L’extrait de code suivant montre comment définir le type de remplissage d’arrière‑plan sur une image mosaïquée et modifier les propriétés de mosaïquage :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Définissez l'image utilisée pour le remplissage d'arrière-plan.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Définissez le mode de remplissage d'image sur Tile et ajustez les propriétés de la mosaïque.
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
En savoir plus: [**Tile Picture As Texture**](/slides/fr/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l’image d’arrière‑plan**

Vous pouvez souhaiter ajuster la transparence de l’image d’arrière‑plan d’une diapositive afin que le contenu de la diapositive ressorte davantage. Le code Python suivant montre comment modifier la transparence d’une image d’arrière‑plan de diapositive :
```python
transparency_value = 30  # Par exemple.

# Obtenez la collection des opérations de transformation d'image.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Trouvez un effet de transparence à pourcentage fixe existant.
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


## **Obtenir la valeur d’arrière‑plan de la diapositive**

Aspose.Slides fournit la classe [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) pour récupérer les valeurs d’arrière‑plan effectives d’une diapositive. Cette classe expose le [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) et le [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) effectifs.

En utilisant la propriété `background` de la classe [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), vous pouvez obtenir l’arrière‑plan effectif d’une diapositive.

L’exemple Python suivant montre comment obtenir la valeur d’arrière‑plan effective d’une diapositive :
```python
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Récupérez l'arrière-plan effectif en tenant compte du maître, de la mise en page et du thème.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```


## **FAQ**

**Puis‑je réinitialiser un arrière‑plan personnalisé et restaurer l’arrière‑plan du thème/mise en page ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l’arrière‑plan sera de nouveau hérité de la [mise en page](/slides/fr/python-net/slide-layout/)/[maître](/slides/fr/python-net/slide-master/) correspondante (c’est‑à‑dire du [arrière‑plan du thème](/slides/fr/python-net/presentation-theme/)).

**Que se passe‑t‑il avec l’arrière‑plan si je change plus tard le thème de la présentation ?**

Si une diapositive possède son propre remplissage, celui‑ci reste inchangé. Si l’arrière‑plan est hérité de la [mise en page](/slides/fr/python-net/slide-layout/)/[maître](/slides/fr/python-net/slide-master/), il se met à jour pour correspondre au [nouveau thème](/slides/fr/python-net/presentation-theme/).