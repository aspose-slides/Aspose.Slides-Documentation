---
title: Texte Animé
type: docs
weight: 60
url: /python-net/animated-text/
keywords: "Texte animé, Effets d'animation, Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajoutez du texte animé et des effets à une présentation PowerPoint en Python"
---

## Ajout d'Effets d'Animation aux Paragraphes

Nous avons ajouté la méthode [**add_effect()**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) aux classes [**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) et [**ISequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/). Cette méthode vous permet d'ajouter des effets d'animation à un seul paragraphe. Ce code d'exemple vous montre comment ajouter un effet d'animation à un seul paragraphe :

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as presentation:
    # sélectionner le paragraphe pour ajouter un effet
    autoShape = presentation.slides[0].shapes[0]
    paragraph = autoShape.text_frame.paragraphs[0]

    # ajouter un effet d'animation de type Fly au paragraphe sélectionné
    effect = presentation.slides[0].timeline.main_sequence.add_effect(paragraph, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.LEFT, slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("AnimationEffectinParagraph.pptx", slides.export.SaveFormat.PPTX)
```



## Obtention des Effets d'Animation dans les Paragraphes

Vous pouvez décider de découvrir les effets d'animation ajoutés à un paragraphe, par exemple, dans un scénario, vous souhaitez obtenir les effets d'animation dans un paragraphe parce que vous prévoyez d'appliquer ces effets à un autre paragraphe ou à une forme.

Aspose.Slides pour Python via .NET vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Ce code d'exemple vous montre comment obtenir les effets d'animation dans un paragraphe :

```py
import aspose.slides as slides

with slides.Presentation("AnimationEffectinParagraph.pptx") as pres:
    sequence = pres.slides[0].timeline.main_sequence
    autoShape = pres.slides[0].shapes[0]
    for paragraph in autoShape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print("Le paragraphe \"" + paragraph.text + "\" a un effet de type " + str(effects[0].type) + ".")
```