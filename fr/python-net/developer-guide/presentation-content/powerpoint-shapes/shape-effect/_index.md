---
title: Appliquer des effets de forme dans les présentations avec Python
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/python-net/shape-effect
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Transformez vos fichiers PPT, PPTX et ODP avec des effets de forme avancés grâce à Aspose.Slides for Python—créez des diapositives percutantes et professionnelles en quelques secondes."
---
## **Introduction**

Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/python-net/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des reflets convaincants sur une forme, étendre la lueur d’une forme, etc.

![Shape effect](shape-effect.png)

PowerPoint fournit six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

Certaines combinaisons d’effets sont plus réussies que d’autres. Pour cette raison, PowerPoint propose des options sous **Preset**. Les options Preset sont essentiellement une combinaison connue et esthétique de deux effets ou plus. Ainsi, en sélectionnant un preset, vous n’aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une belle combinaison.

Aspose.Slides propose des propriétés et des méthodes sous la classe [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) qui vous permettent d’appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d’ombre**

Aspose.Slides for Python via .NET prend en charge les ombres externes et internes pour les formes. Vous pouvez personnaliser leur couleur, direction, distance et rayon de flou pour correspondre au design de votre présentation.

### **Appliquer une ombre externe**

Utilisez une ombre externe pour faire ressortir une carte ou un panneau par rapport à l’arrière‑plan de la diapositive. L’ombre s’étend au‑delà des bords de la forme, créant l’impression que la forme est surélevée au‑dessus de la diapositive. Ajustez sa couleur, direction, distance et rayon de flou pour correspondre à l’éclairage et au style de votre modèle.

Ce code Python montre comment appliquer l’[effet d’ombre externe](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) à un rectangle :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Shadow effect](shadow_effect.png)

### **Appliquer une ombre interne**

Lors de la reproduction du style visuel d’un modèle, utilisez une ombre interne pour donner à une carte ou un panneau un aspect en retrait. Une ombre externe s’étend à l’extérieur de la forme et la fait paraître surélevée, tandis qu’une ombre interne ombre l’intérieur de ses bords.

Appelez [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), puis configurez [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Des valeurs de rayon de flou plus élevées produisent des bords plus doux.

Cet exemple Python crée une carte bleu clair avec une ombre interne gris foncé et l’enregistre au format PPTX :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Pour supprimer l’ombre interne, appelez [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) sur le format d’effet de la forme.

### **Appliquer, modifier et supprimer une ombre prédéfinie**

Appelez [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) et définissez la propriété [preset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) de l’ombre sur une valeur [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Pour changer de style, modifiez le preset sur la même forme. Appelez [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) pour supprimer l’ombre tout en conservant le remplissage et le contour.

Cet exemple montre quatre étapes côte à côte sur une même diapositive. Il clone le rectangle avant chaque modification afin que vous puissiez comparer les résultats. Les deux ombres sont décalées de 10 points. Une direction de 225° place la première ombre en haut à gauche du rectangle, et 45° place la seconde en bas à droite.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| Original | Premier preset | Deuxième preset | Après suppression |
| :---: | :---: | :---: | :---: |
| ![No shadow](preset_shadow_original.png) | ![Top-left drop shadow](preset_shadow_top_left.png) | ![Bottom-right drop shadow](preset_shadow_bottom_right.png) | ![No shadow after removal](preset_shadow_removed.png) |

## **Appliquer un effet de réflexion**

Pour appliquer un effet de réflexion dans Aspose.Slides for Python via .NET, vous pouvez ajouter une réflexion miroir aux formes, en ajustant des paramètres tels que la distance, la transparence et la taille. Cet effet améliore l’esthétique de vos présentations en donnant aux formes un aspect plus poli et sophistiqué. Il est facile à mettre en œuvre avec un code simple, permettant une application rapide sur plusieurs éléments pour un design cohérent.

Ce code Python montre comment appliquer l’[effet de réflexion](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) à une forme :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Reflection effect](reflection_effect.png)

## **Appliquer un effet de lueur**

Pour appliquer un effet de lueur à une forme dans Aspose.Slides for Python via .NET, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des propriétés comme la couleur et la taille. Cet effet aide les formes à se démarquer et ajoute un élément visuel attrayant à votre présentation. Il est facile à mettre en œuvre avec peu de code, améliorant l’aspect global de vos diapositives.

Ce code Python montre comment appliquer l’[effet de lueur](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) à une forme :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Glow effect](glow_effect.png)

## **Appliquer un effet de bords doux**

Pour appliquer un effet de bords doux dans Aspose.Slides for Python via .NET, vous pouvez créer une transition lisse et floue autour des bords d’une forme. Cet effet ajoute un rendu plus subtil et raffiné, parfait pour les conceptions qui nécessitent une apparence douce. Vous pouvez facilement ajuster des paramètres comme le rayon pour obtenir l’effet désiré sur diverses formes de votre présentation.

Ce code Python montre comment appliquer les [bords doux](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) à une forme :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Soft edges effect](soft_edges_effect.png)

## **Appliquer un effet de flou**

Utilisez le flou de forme pour adoucir le remplissage et le contour d’une forme tout en gardant la forme éditable. Appelez [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) sur le format d’effet de la forme. Le rayon est mesuré en points (1/72 pouce) : utilisez une valeur non négative, les valeurs plus élevées produisant un flou plus fort. Un rayon de zéro laisse l’apparence inchangée.

Le paramètre [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) contrôle les limites visibles de l’effet. Avec `False`, le flou est limité aux limites peintes d’origine, y compris le contour. Avec `True`, le flou peut s’étendre au‑delà de ces limites. Aucun des deux réglages ne modifie la position ou les dimensions de la forme.

La comparaison ci‑dessous utilise le même remplissage, contour et dimensions de forme tout au long. La première rangée utilise `grow = False` ; la seconde rangée utilise `grow = True`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Cet exemple Python crée un rectangle orange avec un contour bleu foncé, applique un flou de 5 points, puis le met à jour avec un flou de 15 points en rappelant [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) à nouveau. Il enregistre les deux états flous, puis appelle [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) et enregistre la forme sans flou.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Le flou de forme affecte le remplissage et le contour simultanément. Un effet de bords doux estompe les bords de la forme, tandis que le flou d’ombre adoucit uniquement l’ombre. Les effets de transformation d’image opèrent sur le contenu de l’image ; cet exemple applique le flou directement au format d’effet de la forme sans convertir la forme en image.

## **FAQ**

**Puis‑je appliquer plusieurs effets à la même forme ?**

Oui, vous pouvez combiner différents effets, tels que l’ombre, la réflexion et la lueur, sur une même forme pour créer un aspect plus dynamique.

**À quelles formes puis‑je appliquer des effets ?**

Vous pouvez appliquer des effets à diverses formes, notamment les formes automatiques, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis‑je appliquer des effets à des formes groupées ?**

Oui, vous pouvez appliquer des effets à des formes groupées. L’effet s’appliquera à l’ensemble du groupe.