---
title: Appliquer des effets de forme aux présentations avec Python via Java
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/python-java/shape-effect/
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Transformez vos fichiers PPT et PPTX avec des effets de forme avancés grâce à Aspose.Slides pour Python via Java — créez des diapositives percutantes et professionnelles en quelques secondes."
---
## **Introduction**

Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/python-java/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser l’éclat d’une forme, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme. 

* Certaines combinaisons d'effets sont plus esthétiques que d'autres. Pour cette raison, PowerPoint propose des options sous **Préréglage**. Les options de Préréglage sont essentiellement des combinaisons de deux effets ou plus connues pour être harmonieuses. Ainsi, en sélectionnant un préréglage, vous n’aurez pas à perdre du temps à tester ou combiner différents effets pour trouver une belle combinaison.

Aspose.Slides fournit des propriétés et des méthodes dans la classe [EffectFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effectformat/) qui vous permettent d’appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d'ombre**

Ce code Python vous montre comment appliquer l'effet d'ombre externe ([EffectFormat.getOuterShadowEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effectformat/#getOuterShadowEffect)) à un rectangle :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY)
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Appliquer un effet de réflexion**

Ce code Python vous montre comment appliquer l'effet de réflexion à une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(55)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4)

    presentation.save("reflection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Appliquer un effet de lueur**

Ce code Python vous montre comment appliquer l'effet de lueur à une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Appliquer un effet de bords doux**

Ce code Python vous montre comment appliquer un effet de bords doux à une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)

    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15)

    presentation.save("softEdges.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je appliquer plusieurs effets à la même forme ?**

Oui, vous pouvez combiner différents effets, tels que l’ombre, la réflexion et la lueur, sur une même forme pour créer une apparence plus dynamique.

**À quelles formes puis‑je appliquer des effets ?**

Vous pouvez appliquer des effets à diverses formes, notamment les formes automatiques, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis‑je appliquer des effets à des formes groupées ?**

Oui, vous pouvez appliquer des effets à des formes groupées. L’effet sera appliqué à l’ensemble du groupe.