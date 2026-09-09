---
title: Animer le texte PowerPoint avec Python via Java
linktitle: Texte animé
type: docs
weight: 60
url: /fr/python-java/animated-text/
keywords:
- texte animé
- animation de texte
- paragraphe animé
- animation de paragraphe
- effet d'animation
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Créez du texte animé dynamique dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via Java, avec des exemples de code Python faciles à suivre et optimisés."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec du texte animé dans Aspose.Slides en appliquant des effets d'animation à des paragraphes individuels et en récupérant les effets déjà attribués aux paragraphes d'un cadre de texte. Il se concentre sur les méthodes API utilisées pour ajouter des animations au niveau du paragraphe et inspecter les effets d'animation de paragraphe existants dans une présentation.

## **Ajouter des effets d'animation aux paragraphes**

La méthode [addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect) de la classe [Sequence](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/) vous permet d'ajouter des effets d'animation à un seul paragraphe. Ce code d'exemple montre comment ajouter un effet d'animation à un seul paragraphe :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Sélectionner le paragraphe auquel ajouter un effet.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ajouter un effet d'animation Fly au paragraphe sélectionné.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtenir les effets d'animation des paragraphes**

Vous pouvez souhaiter récupérer les effets d'animation appliqués à un paragraphe — par exemple, pour appliquer ces effets à un autre paragraphe ou à une forme.

Aspose.Slides for Python via Java vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Ce code d'exemple montre comment obtenir les effets d'animation appliqués à un paragraphe :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**En quoi les animations de texte diffèrent-elles des transitions de diapositive, et peuvent-elles être combinées ?**

Les animations de texte contrôlent le comportement d'un objet au fil du temps sur une diapositive, tandis que les [transitions](/slides/fr/python-java/slide-transition/) contrôlent la façon dont les diapositives changent. Elles sont indépendantes et peuvent être utilisées conjointement ; l'ordre de lecture est régi par la chronologie des animations et les paramètres de transition.

**Les animations de texte sont-elles conservées lors de l'exportation vers PDF ou images ?**

Non. Les PDF et les images raster sont statiques, vous ne verrez qu'un état unique de la diapositive sans mouvement. Pour conserver le mouvement, utilisez l'exportation [vidéo](/slides/fr/python-java/convert-powerpoint-to-video/) ou [HTML](/slides/fr/python-java/export-to-html5/).

**Les animations de texte fonctionnent-elles dans les mises en page et le masque de diapositive ?**

Les effets appliqués aux objets de mise en page/masque sont hérités par les diapositives, mais leur synchronisation et leur interaction avec les animations au niveau de la diapositive dépendent de la séquence finale sur la diapositive.