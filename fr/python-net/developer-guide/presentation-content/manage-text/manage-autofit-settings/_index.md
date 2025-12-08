---
title: Améliorez vos présentations avec AutoFit en Python
linktitle: Paramètres Autofit
type: docs
weight: 30
url: /fr/python-net/manage-autofit-settings/
keywords:
- zone de texte
- ajustement automatique
- ne pas ajuster automatiquement
- adapter le texte
- réduire le texte
- envelopper le texte
- redimensionner la forme
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à gérer les paramètres AutoFit dans Aspose.Slides pour Python via .NET afin d'optimiser l'affichage du texte dans vos présentations PowerPoint et OpenDocument et d'améliorer la lisibilité du contenu."
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Redimensionner la forme pour corriger le texte** pour la zone de texte — il redimensionne automatiquement la zone de texte afin que son texte y tienne toujours.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte de la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte — augmente sa hauteur—pour lui permettre de contenir davantage de texte.  
* Lorsque le texte de la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte — diminue sa hauteur—pour supprimer l'espace redondant.

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d’ajustement automatique pour une zone de texte :

* **Ne pas ajuster automatiquement**
* **Réduire le texte en cas de dépassement**
* **Redimensionner la forme pour ajuster le texte**
* **Envelopper le texte dans la forme.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET propose des options similaires—certaines propriétés de la classe [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)—qui vous permettent de contrôler le comportement d’ajustement automatique des zones de texte dans les présentations.

## **Redimensionner les formes pour ajuster le texte**

Si vous souhaitez que le texte d’une zone tienne toujours dans celle‑ci après modification, vous devez utiliser l’option **Redimensionner la forme pour corriger le texte**. Pour spécifier ce réglage, définissez la propriété [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) de la classe [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) sur `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code Python montre comment spécifier qu’un texte doit toujours tenir dans sa zone dans une présentation PowerPoint :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) afin que tout le texte tienne. Si le texte devient plus court, l’inverse se produit.

## **Ne pas ajuster automatiquement**

Si vous souhaitez qu’une zone de texte ou une forme conserve ses dimensions quel que soit le texte qu’elle contient, vous devez utiliser l’option **Ne pas ajuster automatiquement**. Pour spécifier ce réglage, définissez la propriété [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) de la classe [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) sur `NONE`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code Python montre comment spécifier qu’une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Lorsque le texte devient trop long pour sa zone, il déborde.

## **Réduire le texte en cas de dépassement**

Si un texte devient trop long pour sa zone, l’option **Réduire le texte en cas de dépassement** vous permet de spécifier que la taille et l’interligne du texte doivent être réduits pour qu’il tienne dans la zone. Pour spécifier ce réglage, définissez la propriété [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) de la classe [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) sur `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code Python montre comment spécifier qu’un texte doit être rétréci en cas de dépassement dans une présentation PowerPoint :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
Lorsque l’option **Réduire le texte en cas de dépassement** est utilisée, le réglage s’applique uniquement lorsque le texte devient trop long pour sa zone.
{{% /alert %}}

## **Envelopper le texte**

Si vous souhaitez que le texte d’une forme soit renvoyé à la ligne à l’intérieur de cette forme lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Envelopper le texte dans la forme**. Pour spécifier ce réglage, vous devez définir la propriété [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) de la classe [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) sur `NullableBool.TRUE`.

Ce code Python montre comment utiliser le réglage Envelopper le texte dans une présentation PowerPoint :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}}
Si vous définissez la propriété `wrap_text` sur `NullableBool.FALSE` pour une forme, lorsque le texte à l’intérieur de la forme devient plus long que la largeur de la forme, le texte dépasse les bordures de la forme sur une seule ligne.
{{% /alert %}}

## **FAQ**

**Les marges internes du cadre de texte affectent-elles l’AutoFit ?**  
Oui. Le remplissage (marges internes) réduit la zone utilisable pour le texte, de sorte que l’AutoFit s’active plus tôt — il rétrécit la police ou redimensionne la forme plus tôt. Vérifiez et ajustez les marges avant de régler l’AutoFit.

**Comment l’AutoFit interagit‑il avec les retours à la ligne manuels et souples ?**  
Les sauts forcés restent en place, et l’AutoFit adapte la taille de la police et l’interligne autour d’eux. Supprimer les sauts inutiles réduit souvent l’intensité de la réduction de texte par l’AutoFit.

**Le changement de police du thème ou le déclenchement d’une substitution de police influence‑t‑il les résultats de l’AutoFit ?**  
Oui. La substitution par une police aux métriques différentes modifie la largeur/hauteur du texte, ce qui peut modifier la taille finale de la police et le renvoi à la ligne. Après tout changement ou substitution de police, revérifiez les diapositives.