---
title: Animer le texte PowerPoint en Python
linktitle: Texte animé
type: docs
weight: 60
url: /fr/python-net/animated-text/
keywords:
- texte animé
- animation de texte
- paragraphe animé
- animation de paragraphe
- effet d'animation
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créez du texte animé dynamique dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET, avec des exemples de code faciles à suivre et optimisés."
---

## **Aperçu**

Cet article montre comment animer du texte dans les présentations PowerPoint en utilisant Aspose.Slides pour Python. Vous apprendrez à ajouter des effets à des paragraphes individuels, à ajuster les déclencheurs et à lire les séquences d'animation existantes. À la fin, vous pourrez créer des flux de travail d'animation de texte réutilisables qui s'exportent au format PPTX standard et s'exécutent correctement dans PowerPoint.

## **Ajouter des effets d'animation de paragraphe**

La méthode [add_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/add_effect/) de la classe [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) vous permet d'appliquer un effet d'animation à un seul paragraphe. Le code d'exemple ci‑dessous montre comment procéder :
```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Sélectionnez le paragraphe à animer.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ajoutez un effet d'animation Fly au paragraphe sélectionné.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtenir les effets d'animation de paragraphe**

Il se peut que vous souhaitiez déterminer quels effets d'animation sont appliqués à un paragraphe — par exemple, si vous prévoyez de copier ces effets vers un autre paragraphe ou forme.

Aspose.Slides pour Python vous permet de récupérer tous les effets d'animation appliqués aux paragraphes d'un cadre de texte (forme). Le code d'exemple ci‑dessous montre comment obtenir les effets d'animation d'un paragraphe :
```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```


## **FAQ**

**Comment les animations de texte diffèrent‑elles des transitions de diapositive, et peuvent‑elles être combinées ?**

Les animations de texte contrôlent le comportement d’un objet au fil du temps sur une diapositive, tandis que les [transitions](/slides/fr/python-net/slide-transition/) contrôlent la façon dont les diapositives changent. Elles sont indépendantes et peuvent être utilisées conjointement ; l'ordre de lecture est régi par la chronologie des animations et les paramètres de transition.

**Les animations de texte sont‑elles conservées lors de l'exportation vers PDF ou images ?**

Non. Le PDF et les images matricielles sont statiques, vous ne verrez donc qu'un seul état de la diapositive sans mouvement. Pour conserver le mouvement, utilisez l'exportation en [vidéo](/slides/fr/python-net/convert-powerpoint-to-video/) ou en [HTML](/slides/fr/python-net/export-to-html5/).

**Les animations de texte fonctionnent‑elles dans les mises en page et le masque des diapositives ?**

Les effets appliqués aux objets de mise en page/masque sont hérités par les diapositives, mais leur synchronisation et leur interaction avec les animations au niveau de la diapositive dépendent de la séquence finale sur la diapositive.