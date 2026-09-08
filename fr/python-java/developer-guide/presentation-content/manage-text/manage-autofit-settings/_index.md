---
title: Améliorez vos présentations avec AutoFit en Python
linktitle: Paramètres AutoFit
type: docs
weight: 30
url: /fr/python-java/manage-autofit-settings/
keywords:
- zone de texte
- autofit
- ne pas autofit
- adapter le texte
- réduire le texte
- envelopper le texte
- redimensionner la forme
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à gérer les paramètres AutoFit dans Aspose.Slides pour Python via Java afin d'optimiser l'affichage du texte dans vos présentations PowerPoint et OpenDocument et d'améliorer la lisibilité du contenu."
---
## **Introduction**

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Resize shape to fix text** pour la zone de texte — il redimensionne automatiquement la zone de texte afin de garantir que son texte y rentre toujours. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte de la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte — augmente sa hauteur — pour lui permettre de contenir davantage de texte. 
* Lorsque le texte de la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte — diminue sa hauteur — pour éliminer l'espace superflu. 

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d’ajustement automatique pour une zone de texte :

* **Ne pas ajuster automatiquement**
* **Réduire le texte en cas de dépassement**
* **Redimensionner la forme pour faire tenir le texte**
* **Envelopper le texte dans la forme.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java propose des options similaires — certaines propriétés de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/) — qui vous permettent de contrôler le comportement d’ajustement automatique pour les zones de texte dans les présentations. 

## **Redimensionner une forme pour faire tenir le texte**

Si vous souhaitez que le texte d’une zone tienne toujours dans cette zone après des modifications, vous devez utiliser l’option **Resize shape to fix text**. Pour spécifier ce paramètre, utilisez la méthode [setAutofitType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setAutofitType) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/)) avec [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code Python montre comment spécifier qu’un texte doit toujours tenir dans sa zone dans une présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) afin que tout le texte y tienne. Si le texte devient plus court, l’inverse se produit. 

## **Ne pas ajuster automatiquement**

Si vous souhaitez qu’une zone de texte ou une forme conserve ses dimensions quels que soient les changements apportés au texte qu’elle contient, vous devez utiliser l’option **Do not Autofit**. Pour spécifier ce paramètre, utilisez la méthode [setAutofitType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setAutofitType) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/)) avec [None](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textautofittype/#None). 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code Python montre comment spécifier qu’une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lorsque le texte devient trop long pour sa zone, il déborde. 

## **Réduire le texte en cas de dépassement**

Si un texte devient trop long pour sa zone, grâce à l’option **Shrink text on overflow**, vous pouvez spécifier que la taille et l’espacement du texte doivent être réduits afin qu’il tienne dans sa zone. Pour spécifier ce paramètre, utilisez la méthode [setAutofitType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setAutofitType) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/)) avec [Normal](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code Python montre comment spécifier qu’un texte doit être réduit en cas de dépassement dans une présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
Lorsque l’option **Shrink text on overflow** est utilisée, le paramètre n’est appliqué que lorsque le texte devient trop long pour sa zone.
{{% /alert %}}

## **Envelopper le texte**

Si vous souhaitez que le texte d’une forme s’enroule à l’intérieur de cette forme lorsque le texte dépasse la bordure de la forme (seulement en largeur), vous devez utiliser le paramètre **Wrap text in shape**. Pour spécifier ce paramètre, utilisez la méthode [setWrapText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setWrapText) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/)) avec [NullableBool.True](https://reference.aspose.com/slides/fr/python-java/aspose.slides/nullablebool/#True).

Ce code Python montre comment utiliser le paramètre Envelopper le texte dans une présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
Si vous utilisez la méthode [setWrapText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setWrapText) avec [NullableBool.False] pour une forme, lorsque le texte à l’intérieur de la forme devient plus long que la largeur de la forme, le texte s’étend au‑delà des bordures de la forme sur une seule ligne. 
{{% /alert %}}

## **FAQ**

**Les marges internes du cadre de texte affectent-elles l’AutoFit ?**

Oui. Le remplissage (marges internes) réduit la zone utilisable pour le texte, de sorte que l’AutoFit intervient plus tôt — en réduisant la police ou en redimensionnant la forme plus rapidement. Vérifiez et ajustez les marges avant d’affiner l’AutoFit.

**Comment l’AutoFit interagit‑il avec les sauts de ligne manuels et souples ?**

Les sauts forcés restent en place, et l’AutoFit ajuste la taille de la police et l’espacement autour d’eux. Supprimer les sauts inutiles réduit souvent l’agressivité avec laquelle l’AutoFit doit réduire le texte.

**Le fait de changer la police du thème ou de déclencher une substitution de police influence‑t‑il les résultats de l’AutoFit ?**

Oui. Substituer par une police avec des métriques de glyphes différentes modifie la largeur/hauteur du texte, ce qui peut changer la taille finale de la police et le retour à la ligne. Après tout changement ou substitution de police, revérifiez les diapositives.