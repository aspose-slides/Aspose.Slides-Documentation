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
description: "Transformez vos fichiers PPT, PPTX et ODP avec des effets de forme avancés grâce à Aspose.Slides for Python — créez des diapositives saisissantes et professionnelles en quelques secondes."
---
## **Introduction**

Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/python-net/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets de PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser la lueur d'une forme, etc.

![Effet de forme](shape-effect.png)

PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme.

Certaines combinaisons d'effets sont plus esthétiques que d'autres. Pour cette raison, PowerPoint propose des options sous **Préréglage**. Les options de Préréglage sont essentiellement une combinaison reconnue de deux effets ou plus. Ainsi, en sélectionnant un préréglage, vous n'aurez pas à perdre du temps à tester ou à combiner différents effets pour trouver une belle combinaison.

Aspose.Slides fournit des propriétés et des méthodes dans la classe [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) qui vous permettent d'appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d'ombre**

Aspose.Slides for Python via .NET prend en charge les ombres externes et internes pour les formes. Vous pouvez personnaliser leur couleur, direction, distance et rayon de flou pour correspondre au design de votre présentation.

### **Appliquer une ombre externe**

Utilisez une ombre externe pour faire ressortir une carte ou un panneau par rapport à l'arrière-plan de la diapositive. L'ombre s'étend au-delà des bords de la forme, créant l'impression que la forme est surélevée au-dessus de la diapositive. Ajustez sa couleur, direction, distance et rayon de flou pour correspondre à l'éclairage et au style de votre modèle.

Ce code Python montre comment appliquer l'[effet d'ombre externe](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) à un rectangle:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Effet d'ombre](shadow_effect.png)

### **Appliquer une ombre interne**

Lorsque vous reproduisez le style visuel d'un modèle, utilisez une ombre interne pour donner à une carte ou un panneau un aspect encastré. Une ombre externe s'étend à l'extérieur de la forme et la fait paraître surélevée, tandis qu'une ombre interne ombre l'intérieur de ses bords.

Appelez [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), puis configurez [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Des valeurs de rayon de flou plus élevées produisent des bords plus doux.

Cet exemple Python crée une carte bleu clair avec une ombre interne gris foncé et l'enregistre en fichier PPTX :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Rectangle bleu clair avec une ombre interne](inner_shadow_effect.png)

Pour supprimer l'ombre interne, appelez [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) sur le format d'effet de la forme.

## **Appliquer un effet de réflexion**

Pour appliquer un effet de réflexion dans Aspose.Slides for Python via .NET, vous pouvez ajouter une réflexion semblable à un miroir aux formes, en ajustant des paramètres tels que la distance, la transparence et la taille. Cet effet améliore l'esthétique de vos présentations en donnant aux formes un aspect plus poli et sophistiqué. Il est facile à mettre en œuvre avec du code simple, permettant une application rapide sur plusieurs éléments pour un design cohérent.

Ce code Python montre comment appliquer l'[effet de réflexion](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) à une forme :

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

![Effet de réflexion](reflection_effect.png)

## **Appliquer un effet de lueur**

Pour appliquer un effet de lueur à une forme dans Aspose.Slides for Python via .NET, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des propriétés comme la couleur et la taille. Cet effet aide à faire ressortir les formes et ajoute un élément visuel attrayant et saisissant à votre présentation. Il est facile à mettre en œuvre avec peu de code, améliorant l'aspect général de vos diapositives.

Ce code Python montre comment appliquer l'[effet de lueur](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) à une forme :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Effet de lueur](glow_effect.png)

## **Appliquer un effet de bords doux**

Pour appliquer un effet de bords doux dans Aspose.Slides for Python via .NET, vous pouvez créer une transition lisse et floue autour des bords d'une forme. Cet effet ajoute un aspect plus subtil et raffiné, parfait pour les conceptions qui nécessitent une apparence douce et plus légère. Vous pouvez facilement ajuster des paramètres comme le rayon pour obtenir l'effet souhaité sur différentes formes de votre présentation.

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

![Effet de bords doux](soft_edges_effect.png)

## **FAQ**

**Puis-je appliquer plusieurs effets à la même forme ?**
Oui, vous pouvez combiner différents effets, tels que l'ombre, la réflexion et la lueur, sur une seule forme pour créer une apparence plus dynamique.

**À quelles formes puis-je appliquer des effets ?**
Vous pouvez appliquer des effets à diverses formes, y compris les autoshapes, graphiques, tableaux, images, objets SmartArt, objets OLE, et plus encore.

**Puis-je appliquer des effets aux formes groupées ?**
Oui, vous pouvez appliquer des effets aux formes groupées. L'effet sera appliqué à l'ensemble du groupe.