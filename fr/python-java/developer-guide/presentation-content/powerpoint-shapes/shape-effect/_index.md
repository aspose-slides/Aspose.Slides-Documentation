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

Alors que les effets dans PowerPoint peuvent être utilises pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/python-java/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez creer des reflets convincants sur une forme, diffuser la lueur d'une forme, etc.

![Shape effect](shape-effect.png)

PowerPoint propose six effets qui peuvent etre appliques aux formes. Vous pouvez appliquer un ou plusieurs effets a une forme.

Certaines combinaisons d'effets sont plus reussies que d'autres. Pour cette raison, PowerPoint propose des options sous **Preset**. Les options Preset sont des combinaisons de deux effets ou plus dont on sait qu'elles donnent un bon rendu. Ainsi, en selectionnant un preset, vous n'aurez pas a perdre du temps a tester ou a combiner différents effets pour trouver une bonne combinaison.

Aspose.Slides propose des proprietes et des methodes sous la classe [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) qui vous permettent d'appliquer les memes effets aux formes dans les presentations PowerPoint.

## **Appliquer un effet d'ombre**

Aspose.Slides for Python via Java prend en charge les ombres externes et internes pour les formes. Vous pouvez personnaliser leur couleur, direction, distance et rayon de flou afin de correspondre au design de votre presentation.

### **Appliquer une ombre externe**

Utilisez une ombre externe pour faire ressortir une carte ou un panneau par rapport a l'arriere-plan de la diapositive. L'ombre depasse les bords de la forme, creant l'impression que la forme est sur-elevee au-dessus de la diapositive. Ajustez sa couleur, sa direction, sa distance et son rayon de flou pour correspondre a l'eclairage et au style de votre modele.

Ce code Python montre comment appliquer l'[effet d'ombre externe](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) a un rectangle:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Effet d'ombre](shadow_effect.png)

#### **Controler la direction de l'ombre lorsqu'une forme tourne**

Par defaut, l'ombre externe tourne avec la forme. Pour que des formes avec des rotations différentes semblent eclairees depuis la meme direction, appelez [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) avec `False` et utilisez [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) pour donner a leurs ombres la meme direction.

L'exemple cree deux fleches bleues avec des ombres grises decalées de 42 points vers la droite (0°). Il duplique ensuite la diapositive et fait pivoter les deux fleches de 90° dans le sens des aiguilles d'une montre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sur la deuxieme diapositive, la fleche de gauche projette son ombre vers le bas, tandis que la fleche de droite projette toujours son ombre vers la droite. La direction configuree reste a 0° pour les deux ombres.

![Rendu PowerPoint avant et apres une rotation de 90°. Les deux ombres commencent a droite. Apres rotation, l'ombre se deplace sous la fleche gauche et reste a droite de la fleche droite.](arrow-shadow-rotation.png)

### **Appliquer une ombre interne**

Lors de la reproduction du style visuel d'un modele, utilisez une ombre interne pour donner a une carte ou un panneau un aspect encastre. Une ombre externe s'etend a l'exterieur de la forme et la fait paraitre sur-elevee, tandis qu'une ombre interne teinte l'interieur de ses bords.

Appelez [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), puis configurez l'ombre renvoyee par [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Des valeurs de rayon de flou plus importantes produisent des bords plus doux.

Cet exemple Python cree une carte bleu clair avec une ombre interne gris fonce et l'enregistre au format PPTX. La direction de l'ombre est de 225 degrés, sa distance est de 7 points et son rayon de flou est de 6 points :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Rectangle bleu clair avec une ombre interne](inner_shadow_effect.png)

Pour supprimer l'ombre interne, appelez [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) sur le format d'effet de la forme.

### **Appliquer, modifier et supprimer une ombre predéfinie**

Appelez [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), puis utilisez [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) pour selectionner un [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). Pour changer de style, modifiez le préréglage sur la même forme. Appelez [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) pour supprimer l'ombre tout en conservant le remplissage et le contour.

L'exemple duplique le rectangle a chaque etape afin que vous puissiez comparer les quatre etats cote a cote sur une meme diapositive. Les deux ombres sont decalées de 10 points. Une direction de 225° place la premiere ombre au-dessus et a gauche du rectangle. Une direction de 45° place la seconde en dessous et a droite.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Original | First preset | Second preset | After removal |
| :---: | :---: | :---: | :---: |
| ![Pas d'ombre](preset_shadow_original.png) | ![OmbreHautGauche](preset_shadow_top_left.png) | ![OmbreBasDroite](preset_shadow_bottom_right.png) | ![Pas d'ombre apres suppression](preset_shadow_removed.png) |

## **Appliquer un effet de reflexion**

Pour appliquer un effet de reflexion avec Aspose.Slides for Python via Java, vous pouvez ajouter une reflexion semblable a un mirroir aux formes, en ajustant des parametres tels que la distance, la transparence et la taille. Cet effet améliore l'esthetique de vos presentations en donnant aux formes un aspect plus poli et sophistique. Il est facile a mettre en oeuvre avec un code simple, permettant une application rapide sur plusieurs elements pour un design coherent.

Ce code Python montre comment appliquer l'[effet de reflexion](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) a une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Effet de reflexion](reflection_effect.png)

## **Appliquer un effet de lueur**

Pour appliquer un effet de lueur a une forme avec Aspose.Slides for Python via Java, vous pouvez ajouter une aura douce et lumineuse autour des formes, en ajustant des proprietes comme la couleur et la taille. Cet effet aide les formes a se demarquer et ajoute un element visuel attractif et accrocheur a votre presentation. Il est facile a mettre en oeuvre avec peu de code, ameliorant l'aspect general de vos diapositives.

Ce code Python montre comment appliquer l'[effet de lueur](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) a une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Effet de lueur](glow_effect.png)

## **Appliquer un effet de bords doux**

Pour appliquer un effet de bords doux avec Aspose.Slides for Python via Java, vous pouvez creer une transition lisse et floue autour des bords d'une forme. Cet effet ajoute un aspect plus subtil et raffine, parfait pour les conceptions necessitant une apparence douce et plus legere. Vous pouvez facilement ajuster des parametres comme le rayon pour obtenir l'effet souhaite sur differentes formes de votre presentation.

Ce code Python montre comment appliquer l'[effet de bords doux](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) a une forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Effet de bords doux](soft_edges_effect.png)

## **Appliquer un effet de flou**

Utilisez le flou de forme pour adoucir le remplissage et le contour d'une forme tout en conservant la forme editable. Appelez [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) sur le format d'effet de la forme. Le rayon est mesure en points (1/72 pouce) : utilisez une valeur non negative, les valeurs plus grandes produisant un flou plus prononce. Un rayon de zero laisse l'apparence inchangée.

Le parametre [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) controle les limites visibles de l'effet. Avec `False`, le flou est limite aux limites peinte d'origine, y compris le contour. Avec `True`, le flou peut s'etendre au-dela de ces limites. Aucun des deux reglage ne modifie la position ou les dimensions de la forme.

La comparaison ci-dessous utilise le meme remplissage, le meme contour et les meme dimensions de forme tout au long. La premiere rangée utilise `grow = False` ; la deuxieme rangée utilise `grow = True`.

![Rectangle original compare avec des rayons de flou de 5 et 15 points, avec grow desactive et active](shape_blur_comparison.png)

Cet exemple Python cree un rectangle orange avec un contour bleu fonce, applique un flou de 5 points, puis le met a jour avec un flou de 15 points en appelant de nouveau [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Il enregistre les deux etats floutes, puis appelle [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) et enregistre la forme sans flou.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le flou de forme affecte le remplissage et le contour ensemble. Un effet de bords doux estompe les bords de la forme, tandis que le flou d'ombre adoucit uniquement l'ombre. Les effets de transformation d'image operent sur le contenu de l'image ; cet exemple applique le flou directement au format d'effet de la forme sans convertir la forme en image.

## **FAQ**

**Puis-je appliquer plusieurs effets à la même forme ?**

Oui, vous pouvez combiner différents effets, tels que l'ombre, la reflexion et la lueur, sur une seule forme pour créer une apparence plus dynamique.

**À quels types de formes puis-je appliquer des effets ?**

Vous pouvez appliquer des effets à diverses formes, notamment les autoshapes, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis‑je appliquer des effets à des formes groupées ?**

Oui, vous pouvez appliquer des effets à des formes groupées. L'effet sera appliqué à l'ensemble du groupe.