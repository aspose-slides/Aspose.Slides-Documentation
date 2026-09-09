---
title: "Améliorez vos présentations avec AutoFit en Python"
linktitle: "Paramètres d'AutoFit"
type: docs
weight: 30
url: /fr/python-java/manage-autofit-settings/
keywords:
- zone de texte
- ajustement automatique
- ne pas ajuster automatiquement
- ajuster le texte
- réduire le texte
- envelopper le texte
- redimensionner la forme
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à gérer les paramètres d'AutoFit dans Aspose.Slides pour Python via Java afin d'optimiser l'affichage du texte dans vos présentations PowerPoint et OpenDocument et d'améliorer la lisibilité du contenu."
---
## **Introduction**

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Redimensionner la forme pour ajuster le texte** pour la zone de texte — il redimensionne automatiquement la zone de texte afin de garantir que son texte y corresponde toujours.

![Zone de texte dans PowerPoint](textbox-in-powerpoint.png)

* Lorsque le texte dans la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte — augmente sa hauteur — pour lui permettre de contenir plus de texte.
* Lorsque le texte dans la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte — diminue sa hauteur — pour supprimer l'espace excédentaire.

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d’ajustement automatique (autofit) d’une zone de texte :

* **Ne pas ajuster automatiquement**
* **Réduire le texte en cas de débordement**
* **Redimensionner la forme pour ajuster le texte**
* **Envelopper le texte dans la forme.**

![options d'autofit PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java fournit des options similaires—certaines propriétés de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/)—qui vous permettent de contrôler le comportement d’ajustement automatique des zones de texte dans les présentations.

## **Redimensionner une forme pour ajuster le texte**

Si vous souhaitez que le texte d’une boîte s’ajuste toujours à cette boîte après des modifications du texte, vous devez utiliser l’option **Redimensionner la forme pour ajuster le texte**. Pour spécifier ce paramètre, utilisez la méthode [setAutofitType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setAutofitType) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/)) avec [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textautofittype/#Shape).

![paramètre toujours ajuster PowerPoint](alwaysfit-setting-powerpoint.png)

Ce code Python montre comment spécifier que le texte doit toujours s’ajuster à sa boîte dans une présentation PowerPoint :

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

Si vous souhaitez qu’une zone de texte ou une forme conserve ses dimensions quelles que soient les modifications du texte qu’elle contient, vous devez utiliser l’option **Ne pas ajuster automatiquement**. Pour spécifier ce paramètre, utilisez la méthode [setAutofitType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setAutofitType) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/)) avec [None](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textautofittype/#None).

![paramètre ne pas ajuster automatiquement PowerPoint](donotautofit-setting-powerpoint.png)

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
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Lorsque le texte devient trop long pour sa boîte, il déborde.

## **Réduire le texte en cas de débordement**

Si le texte devient trop long pour sa boîte, vous pouvez utiliser l’option **Réduire le texte en cas de débordement** pour spécifier que la taille et l’espacement du texte doivent être réduits afin qu’il tienne dans sa boîte. Pour spécifier ce paramètre, utilisez la méthode [setAutofitType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setAutofitType) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/)) avec [Normal](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textautofittype/#Normal).

![paramètre réduire texte débordement PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code Python montre comment spécifier que le texte doit être réduit en cas de débordement dans une présentation PowerPoint :

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
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
Lorsque l’option **Réduire le texte en cas de débordement** est utilisée, le paramètre n’est appliqué que lorsque le texte devient trop long pour sa boîte.
{{% /alert %}}

## **Envelopper le texte**

Si vous souhaitez que le texte d’une forme s’enroule à l’intérieur de cette forme lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Envelopper le texte dans la forme**. Pour spécifier ce paramètre, utilisez la méthode [setWrapText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setWrapText) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/)) avec [NullableBool.True_](https://reference.aspose.com/slides/fr/python-java/aspose.slides/nullablebool/#True).

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
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Avertissement" color="warning" %}} 
Si vous utilisez la méthode [setWrapText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setWrapText) avec [NullableBool.False](https://reference.aspose.com/slides/fr/python-java/aspose.slides/nullablebool/#False) pour une forme, lorsque le texte à l’intérieur de la forme devient plus long que la largeur de la forme, le texte dépasse les bordures de la forme sur une seule ligne.
{{% /alert %}}

## **FAQ**

**Les marges internes du cadre de texte affectent-elles l’AutoFit ?**

Oui. Le remplissage (marges internes) réduit la zone utilisable pour le texte, de sorte que l’AutoFit intervient plus tôt — réduisant la police ou redimensionnant la forme plus rapidement. Vérifiez et ajustez les marges avant d’optimiser l’AutoFit.

**Comment l’AutoFit interagit‑il avec les sauts de ligne manuels et souples ?**

Les sauts imposés restent en place, et l’AutoFit ajuste la taille de police et l’espacement autour d’eux. Supprimer les sauts inutiles réduit souvent l’agressivité avec laquelle l’AutoFit doit réduire le texte.

**Le changement de police du thème ou la substitution de police affecte‑t-il les résultats de l’AutoFit ?**

Oui. Remplacer une police par une autre avec des métriques de glyphes différentes modifie la largeur/hauteur du texte, ce qui peut changer la taille finale de la police et le retour à la ligne. Après tout changement ou substitution de police, revérifiez les diapositives.