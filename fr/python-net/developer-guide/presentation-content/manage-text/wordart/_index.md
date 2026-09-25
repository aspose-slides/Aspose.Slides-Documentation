---
title: Créer et appliquer des effets WordArt en Python
linktitle: WordArt
type: docs
weight: 110
url: /fr/python-net/wordart/
keywords:
- WordArt
- créer WordArt
- modèle WordArt
- effet WordArt
- effet d'ombre
- effet de réflexion
- effet de lueur
- transformation WordArt
- effet 3D
- effet d'ombre externe
- effet d'ombre interne
- Python
- Aspose.Slides
description: "Créer et personnaliser des effets WordArt dans Aspose.Slides pour Python via .NET. Ce guide pas à pas aide les développeurs à améliorer les présentations avec du texte professionnel en Python."
---
## **Vue d'ensemble**

Les effets WordArt vous permettent de styliser le texte avec des remplissages, contours, ombres, reflets, lueurs, transformations et formatage 3D. Cet article explique comment créer et personnaliser ces effets dans les présentations PowerPoint à l’aide d’Aspose.Slides for Python via .NET, sans Microsoft Office installé.

## **Créer un modèle WordArt simple et l’appliquer au texte**

Les exemples suivants construisent un style WordArt simple en définissant le texte, la police, le remplissage en motif et le contour.

Chaque exemple crée une nouvelle présentation et ajoute un rectangle à sa première diapositive ; aucun fichier d’entrée n’est requis. Le premier exemple définit le texte sur « Aspose.Slides ». La position et les dimensions de la forme sont exprimées en points :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Définissez la police sur Arial Black à 36 points pour rendre le formatage plus visible :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Appliquez un motif [SMALL_GRID](https://reference.aspose.com/slides/fr/python-net/aspose.slides/patternstyle/) avec un premier plan orange foncé et un arrière‑plan blanc, puis ajoutez un contour de texte noir d’une largeur de 1 point :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Le texte résultant :

![Le modèle WordArt simple](WordArt_template.png)

## **Appliquer d’autres effets WordArt**

Les exemples suivants démontrent comment appliquer des ombres, reflets, lueurs, transformations et effets 3D au texte.

### **Appliquer des effets d’ombre externe**

Une ombre externe ajoute de la profondeur en plaçant une ombre derrière le texte. Vous pouvez personnaliser sa couleur, sa direction, sa distance, son rayon de flou, son échelle et son biais.

Cet exemple appelle [enable_outer_shadow_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) et définit une ombre noire avec un rayon de flou de 4 points, une direction de 230 degrés et une distance de 30 points. Des valeurs d’échelle à 100 conservent la taille de l’ombre, tandis qu’un biais horizontal l’incline de 20 degrés. La transformation alpha règle son opacité à 32 % :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Le texte résultant :

![L’effet d’ombre externe](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Lorsque les ombres externes et prédéfinies sont utilisées ensemble, seule l’ombre externe est appliquée.  
- Si les ombres externes et internes sont utilisées simultanément, l’effet résultant dépend de la version de PowerPoint. Par exemple, sous PowerPoint 2013, l’effet est doublé, tandis que sous PowerPoint 2007, seule l’ombre externe est appliquée.  
{{% /alert %}}

### **Appliquer des effets de réflexion**

Une réflexion crée une copie miroir du texte. Ajustez sa position, son échelle, son flou et son opacité pour contrôler son apparence.

Cet exemple appelle [enable_reflection_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/effectformat/enable_reflection_effect/) et renverse la réflexion verticalement avec une échelle de –100 %. Il utilise un rayon de flou de 0,5 point et une distance de 4,72 points. L’opacité diminue de 60 % à 0,9 % entre les positions 0 % et 60 % le long de la réflexion :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

Le texte résultant :

![L’effet de réflexion](reflection_effect.png)

### **Appliquer des effets de lueur**

Une lueur ajoute un contour coloré doux autour du texte. Ajustez sa couleur, son opacité et son rayon pour contrôler l’effet.

Cet exemple appelle [enable_glow_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/effectformat/enable_glow_effect/) et applique une lueur rouge avec une opacité de 54 % et un rayon de 7 points :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Le texte résultant :

![L’effet de lueur](glow_effect.png)

### **Appliquer des transformations WordArt**

Les transformations WordArt courbent, étirent ou déforment un bloc de texte.

Définissez [transform](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/transform/) sur [ARCH_UP_POUR](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textshapetype/) pour courber le cadre de texte complet vers le haut :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Le texte résultant :

![La transformation WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via .NET fournit un ensemble de [types de transformation pré‑définis](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textshapetype/).  
{{% /alert %}}

### **Appliquer des effets 3D aux formes et au texte**

Vous pouvez appliquer des effets 3D à une forme ou à son texte. Les chanfreins, l’extrusion, l’éclairage et les paramètres de caméra contrôlent l’apparence résultante.

L’exemple suivant utilise [ThreeDFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/) pour ajouter des chanfreins circulaires, une extrusion orange et un contour rouge foncé au rectangle. Les dimensions du chanfrein, la hauteur d’extrusion, la largeur du contour et la profondeur sont mesurées en points. Un matériau plastique, un éclairage équilibré pivoté de 40 degrés autour de l’axe Z, et une caméra en perspective définissent son apparence :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

La forme résultante :

![L’effet 3D sur la forme](shape_3D_effect.png)

Cet exemple applique un formatage 3D similaire au texte via [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/three_d_format/). De petits chanfreins façonnent les bords des lettres, tandis que l’extrusion et l’éclairage donnent de la profondeur au texte :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Le texte résultant :

![L’effet 3D sur le texte](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
L’application d’effets 3D au texte ou à leurs formes — ainsi que l’interaction entre ces effets — est régie par des règles spécifiques. Considérez une scène impliquant à la fois le texte et la forme qui le contient. Un effet 3D comprend la représentation 3D de l’objet et la scène dans laquelle il est placé.

- Si une scène est définie à la fois pour la forme et pour le texte, la scène de la forme prime et celle du texte est ignorée.  
- Si la forme n’a pas de scène propre mais possède une représentation 3D, la scène du texte est utilisée.  
- Si la forme ne possède aucun effet 3D, elle est traitée comme plate et l’effet 3D s’applique uniquement au texte.  

Ces comportements concernent les propriétés [ThreeDFormat.light_rig](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/light_rig/) et [ThreeDFormat.camera](https://reference.aspose.com/slides/fr/python-net/aspose.slides/threedformat/camera/).  
{{% /alert %}}

Pour garder le texte plat et lisible tout en conservant le format 3D de la forme, consultez [Keep Text Flat on a 3D Shape](/slides/fr/python-net/3d-presentation/) pour une comparaison des deux réglages et un exemple complet en Python.

## **FAQ**

**Puis‑je utiliser les effets WordArt avec différentes polices ou scripts (par ex. arabe, chinois) ?**

Oui, Aspose.Slides for Python via .NET prend en charge Unicode et fonctionne avec toutes les principales polices et scripts. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quel que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices système.

**Puis‑je appliquer les effets WordArt aux éléments du masque de diapositive ?**

Oui, vous pouvez appliquer les effets WordArt aux formes des masques de diapositives, y compris les espaces réservés de titre, les pieds de page ou le texte d’arrière‑plan. Les modifications apportées à la mise en page du masque seront répercutées sur toutes les diapositives associées.

**Les effets WordArt affectent‑ils la taille du fichier de présentation ?**

Légèrement. Les effets WordArt comme les ombres, les lueurs et les remplissages dégradés peuvent augmenter légèrement la taille du fichier en raison des métadonnées de formatage ajoutées, mais la différence est généralement négligeable.

**Puis‑je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?**

Oui, vous pouvez rendre les diapositives contenant du WordArt en images (par ex. PNG, JPEG) à l’aide de [Slide.get_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/get_image/), ou rendre des formes individuelles avec [Shape.get_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/get_image/). Cela vous permet de prévisualiser le résultat en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.