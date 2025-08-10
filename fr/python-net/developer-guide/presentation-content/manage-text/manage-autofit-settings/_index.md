---
title: Améliorez vos présentations avec l’ajustement automatique en Python
linktitle: Paramètres d’ajustement automatique
type: docs
weight: 30
url: /fr/python-net/manage-autofit-settings/
keywords:
- zone de texte
- ajustement automatique
- ne pas ajuster automatiquement
- adapter le texte
- réduire le texte
- renvoi à la ligne
- redimensionner la forme
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment gérer les paramètres d’ajustement automatique dans Aspose.Slides for Python via .NET afin d’optimiser l’affichage du texte dans vos présentations PowerPoint et OpenDocument et d’améliorer la lisibilité du contenu."
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Redimensionner la forme pour ajuster le texte** pour la zone de texte—il redimensionne automatiquement la zone de texte pour s'assurer que son texte s'y ajuste toujours.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte dans la zone de texte devient plus long ou plus grand, PowerPoint augmente automatiquement la zone de texte—augmente sa hauteur—pour permettre l'ajout de plus de texte.
* Lorsque le texte dans la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte—diminue sa hauteur—pour libérer de l'espace superflu.

Dans PowerPoint, ce sont les 4 paramètres ou options importants qui contrôlent le comportement d'auto-ajustement pour une zone de texte :

* **Ne pas auto-ajuster**
* **Réduire le texte en cas de débordement**
* **Redimensionner la forme pour ajuster le texte**
* **Renvoyer le texte dans la forme.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides pour Python via .NET fournit des options similaires—certaines propriétés sous la classe [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)—qui vous permettent de contrôler le comportement d'auto-ajustement pour les zones de texte dans les présentations.

## **Redimensionner la Forme pour Ajuster le Texte**

Si vous souhaitez que le texte dans une zone s'ajuste toujours à cette zone après des modifications du texte, vous devez utiliser l'option **Redimensionner la forme pour ajuster le texte**. Pour spécifier ce paramètre, définissez la propriété [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de la classe [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) sur `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code Python vous montre comment spécifier qu'un texte doit toujours s'ajuster dans sa zone dans une présentation PowerPoint :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.SHAPE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) pour s'assurer que tout le texte s'y ajuste. Si le texte devient plus court, l'inverse se produit.

## **Ne Pas Auto-Ajuster**

Si vous souhaitez qu'une zone de texte ou une forme conserve ses dimensions, peu importe les modifications apportées au texte qu'elle contient, vous devez utiliser l'option **Ne pas auto-ajuster**. Pour spécifier ce paramètre, définissez la propriété [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de la classe [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) sur `NONE`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code Python vous montre comment spécifier qu'une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

Lorsque le texte devient trop long pour sa zone, il déborde.

## **Réduire le Texte en Cas de Débordement**

Si un texte devient trop long pour sa zone, grâce à l'option **Réduire le texte en cas de débordement**, vous pouvez spécifier que la taille et l'espacement du texte doivent être réduits pour s'ajuster à sa zone. Pour spécifier ce paramètre, définissez la propriété [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de la classe [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) sur `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code Python vous montre comment spécifier qu'un texte doit être réduit en cas de débordement dans une présentation PowerPoint :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NORMAL

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

Lorsque l'option **Réduire le texte en cas de débordement** est utilisée, le paramètre ne s'applique que lorsque le texte devient trop long pour sa zone.

{{% /alert %}}

## **Renvoyer le Texte**

Si vous souhaitez que le texte dans une forme soit renvoyé à l'intérieur de cette forme lorsque le texte dépasse la limite de la forme (largeur seulement), vous devez utiliser le paramètre **Renvoyer le texte dans la forme**. Pour spécifier ce paramètre, vous devez définir la propriété [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)) sur `1`.

Ce code Python vous montre comment utiliser le paramètre Renvoie de texte dans une présentation PowerPoint :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE
    textFrameFormat.wrap_text = 1

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}}

Si vous définissez la propriété `wrap_text` sur `0` pour une forme, lorsque le texte à l'intérieur de la forme devient plus long que la largeur de la forme, le texte déborde les limites de la forme sur une seule ligne.

{{% /alert %}}