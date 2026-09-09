---
title: Créer et appliquer des effets WordArt en Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /fr/python-java/wordart/
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
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer et personnaliser les effets WordArt dans Aspose.Slides pour Python via Java. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte professionnel en Python via Java."
---
## **Vue d'ensemble**

Les effets WordArt vous permettent d’ajouter du texte visuellement attrayant et stylisé à vos présentations PowerPoint. Avec Aspose.Slides, les développeurs peuvent créer, personnaliser et gérer programmaticalement le WordArt comme dans Microsoft PowerPoint — sans avoir besoin d’Office installé. Cet article donne un aperçu du travail avec le WordArt, y compris comment appliquer des transformations de texte, des styles de remplissage, des contours, des ombres et d’autres options de mise en forme pour rendre le contenu de votre présentation plus expressif et engageant. Le WordArt vous permet de traiter le texte comme un objet graphique. Il s’agit d’effets ou de modifications spéciales appliquées au texte pour le rendre plus attrayant ou visible.

## **Créer un modèle WordArt simple et l’appliquer au texte**

**Utilisation d’Aspose.Slides**

Tout d’abord, nous créons un texte simple avec ce code Python :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Ensuite, augmentez la taille de la police pour rendre l’effet plus visible :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Utilisation de Microsoft PowerPoint**

Accédez au menu des effets WordArt dans Microsoft PowerPoint :

![WordArt effects menu in PowerPoint](image-20200930113926-1.png)

Dans le menu à droite, vous pouvez choisir un effet WordArt prédéfini. Dans le menu à gauche, vous pouvez spécifier les paramètres pour un nouveau WordArt.

Voici quelques paramètres ou options disponibles :

![WordArt formatting options](image-20200930114015-3.png)

**Utilisation d’Aspose.Slides**

Ici, nous appliquons le remplissage de motif [PatternStyle.SmallGrid](https://reference.aspose.com/slides/fr/python-java/aspose.slides/patternstyle/#SmallGrid) au texte et ajoutons une bordure noire au texte avec ce code :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Le texte résultant :

![Text with a pattern fill and black outline](image-20200930114108-4.png)

## **Application d’autres effets WordArt**

**Utilisation de Microsoft PowerPoint**

Depuis l’interface du programme, vous pouvez appliquer ces effets au texte, à un bloc de texte, à une forme ou à un élément similaire :

![Text and shape effects in PowerPoint](image-20200930114129-5.png)

Par exemple, les effets Ombre, Réflexion et Lueur peuvent être appliqués au texte ; les effets Format 3D et Rotation 3D peuvent être appliqués à un bloc de texte ; l’effet Bords doux peut être appliqué à une forme (il reste actif même lorsqu’aucun effet Format 3D n’est défini).

### **Application des effets d’ombre**

Le code Python suivant applique un effet d’ombre uniquement au texte :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

L’API Aspose.Slides prend en charge trois types d’ombres : [OuterShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/innershadow/) et [PresetShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presetshadow/).

Avec [PresetShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presetshadow/), vous pouvez appliquer une ombre au texte à l’aide de valeurs prédéfinies.

**Utilisation de Microsoft PowerPoint**

Dans PowerPoint, vous ne pouvez utiliser qu’un type d’ombre. Voici un exemple :

![Shadow settings in PowerPoint](image-20200930114225-6.png)

**Utilisation d’Aspose.Slides**

Aspose.Slides vous permet même d’appliquer deux types d’ombres simultanément : [InnerShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/innershadow/) et [PresetShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presetshadow/).

**Remarques :**

- Lorsque [OuterShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/outershadow/) et [PresetShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presetshadow/) sont utilisés ensemble, seul l’effet [OuterShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/outershadow/) est appliqué.
- Si [OuterShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/outershadow/) et [InnerShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/innershadow/) sont utilisés simultanément, l’effet résultant ou appliqué dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l’effet est doublé. Mais dans PowerPoint 2007, l’effet [OuterShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/outershadow/) est appliqué.

### **Appliquer une réflexion au texte**

Nous ajoutons une réflexion au texte avec cet exemple de code en Python via Java :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Appliquer un effet de lueur au texte**

Nous appliquons l’effet de lueur au texte pour le faire briller ou se démarquer à l’aide de ce code :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

Le résultat de l’opération :

![Text with a glow effect](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
Vous pouvez modifier les paramètres de l’ombre, de la réflexion et de la lueur. Les propriétés des effets sont définies séparément pour chaque portion du texte.
{{% /alert %}}

### **Utilisation des transformations dans WordArt**

Utilisez [TextFrameFormat.setTransform](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setTransform) pour transformer tout le bloc de texte :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Le résultat :

![Text with an arch transformation](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
Microsoft PowerPoint et Aspose.Slides for Python via Java proposent un certain nombre de types de transformation prédéfinis.
{{% /alert %}}

**Utilisation de PowerPoint**

Pour accéder aux types de transformation prédéfinis, allez dans : **Format** → **Effet de texte** → **Transformation**

**Utilisation d’Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l’énumération [TextShapeType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textshapetype/).

### **Appliquer des effets 3D au texte et aux formes**

Nous appliquons un effet 3D à une forme de texte avec cet exemple de code :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Le texte et sa forme résultants :

![Text shape with 3D effects](image-20200930114816-9.png)

Nous appliquons un effet 3D au texte avec ce code Python :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Le résultat de l’opération :

![Text with 3D effects](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
L’application d’effets 3D au texte ou à ses formes et les interactions entre effets sont régies par certaines règles.

Considérez une scène pour le texte et la forme contenant ce texte. L’effet 3D comprend une représentation d’objet 3D et la scène dans laquelle l’objet est placé.

- Lorsque la scène est définie à la fois pour la forme et pour le texte, la scène de la forme prend le pas — la scène du texte est ignorée.
- Lorsque la forme n’a pas de scène propre mais possède une représentation 3D, la scène du texte est utilisée.
- Sinon — lorsqu’aucun effet 3D n’est présent sur la forme — la forme reste plate et l’effet 3D s’applique uniquement au texte.

Ces règles concernent les méthodes [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getLightRig) et [ThreeDFormat.getCamera](https://reference.aspose.com/slides/fr/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Appliquer des effets d’ombre externe au texte**

Aspose.Slides for Python via Java fournit les classes [OuterShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/outershadow/) et [InnerShadow](https://reference.aspose.com/slides/fr/python-java/aspose.slides/innershadow/) qui permettent d’appliquer des effets d’ombre au texte dans un [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/). Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez la référence d’une diapositive en utilisant son indice.
3. Ajoutez une forme rectangulaire à la diapositive.
4. Accédez au cadre de texte associé à la forme.
5. Désactivez le remplissage de la forme.
6. Activez l’effet d’ombre externe.
7. Définissez le rayon de flou de l’ombre.
8. Définissez la direction de l’ombre.
9. Définissez la distance de l’ombre.
10. Alignez l’ombre en haut à gauche.
11. Définissez la couleur de l’ombre sur noir.
12. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Ce code d’exemple en Python via Java — une implémentation des étapes ci‑dessus — montre comment appliquer l’effet d’ombre externe au texte :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Obtenir la référence de la diapositive
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une AutoShape de type Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Ajouter un TextFrame au rectangle
    auto_shape.addTextFrame("Aspose TextBox")

    # Désactiver le remplissage de la forme au cas où nous voulons obtenir l'ombre du texte
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Ajouter une ombre externe et définir tous les paramètres nécessaires
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Enregistrer la présentation sur le disque
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Appliquer l’effet d’ombre interne aux formes**

Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez la référence de la diapositive.
3. Ajoutez une forme rectangulaire.
4. Activez l’effet d’ombre interne.
5. Définissez tous les paramètres nécessaires.
6. Définissez le type de couleur de l’ombre sur une couleur de thème.
7. Définissez la couleur de thème.
8. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Ce code d’exemple (basé sur les étapes ci‑dessus) montre comment appliquer l’effet d’ombre interne au texte d’une forme en Python via Java :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Obtenir la référence de la diapositive
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une AutoShape de type Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Ajouter un TextFrame au rectangle
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Activer l'effet InnerShadow
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Définir tous les paramètres nécessaires
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Définir le ColorType comme Schéma
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Définir la couleur du schéma
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Enregistrer la présentation
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je utiliser les effets WordArt avec différentes polices ou scripts (par ex., arabe, chinois) ?**

Oui, Aspose.Slides prend en charge Unicode et fonctionne avec toutes les principales polices et scripts. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quel que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices du système.

**Puis‑je appliquer les effets WordArt aux éléments du masque des diapositives ?**

Oui, vous pouvez appliquer des effets WordArt aux formes sur les masques de diapositives, y compris les espaces réservés de titre, les pieds de page ou le texte d’arrière‑plan. Les modifications apportées à la mise en page du masque seront répercutées sur toutes les diapositives associées.

**Les effets WordArt influent‑ils sur la taille du fichier de présentation ?**

Légèrement. Les effets WordArt comme les ombres, les lueurs et les remplissages en dégradé peuvent augmenter légèrement la taille du fichier en raison des métadonnées de mise en forme supplémentaires, mais la différence est généralement négligeable.

**Puis‑je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?**

Oui, vous pouvez rendre les diapositives contenant du WordArt en images (par ex., PNG, JPEG) à l’aide de [Shape.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) ou de [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage). Cela vous permet de prévisualiser le résultat en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.