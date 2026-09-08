---
title: Animer le texte PowerPoint en Python via Java
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
## **Aperçu**

Cet article explique comment travailler avec du texte animé dans Aspose.Slides en appliquant des effets d’animation à des paragraphes individuels et en récupérant les effets déjà affectés aux paragraphes d’un cadre de texte. Il se concentre sur les méthodes API utilisées pour ajouter une animation au niveau du paragraphe et inspecter les effets d’animation de paragraphe existants dans une présentation.

## **Ajouter des effets d'animation aux paragraphes**

La méthode [addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect) de la classe [Sequence](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/) vous permet d’ajouter des effets d’animation à un seul paragraphe. Ce code d’exemple montre comment ajouter un effet d’animation à un paragraphe unique :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # Sélectionnez le paragraphe auquel ajouter un effet.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ajoutez un effet d'animation Fly au paragraphe sélectionné.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtenir les effets d'animation des paragraphes**

Vous pouvez décider de découvrir les effets d’animation ajoutés à un paragraphe—par exemple, dans un scénario où vous souhaitez récupérer les effets d’animation d’un paragraphe afin de les appliquer à un autre paragraphe ou à une forme.

Aspose.Slides for Python via Java vous permet d’obtenir tous les effets d’animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Ce code d’exemple montre comment récupérer les effets d’animation d’un paragraphe :

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

**Comment les animations de texte diffèrent‑elles des transitions de diapositive, et peuvent‑elles être combinées ?**

Les animations de texte contrôlent le comportement d’un objet dans le temps sur une diapositive, tandis que les [transitions](/slides/fr/python-java/slide-transition/) contrôlent la manière dont les diapositives changent. Elles sont indépendantes et peuvent être utilisées ensemble ; l’ordre de lecture est régulé par la chronologie des animations et les paramètres de transition.

**Les animations de texte sont‑elles conservées lors de l’exportation vers PDF ou images ?**

Non. Les PDF et les images matricielles sont statiques, vous ne verrez donc qu’un seul état de la diapositive sans mouvement. Pour conserver le mouvement, utilisez l’exportation [vidéo](/slides/fr/python-java/convert-powerpoint-to-video/) ou [HTML](/slides/fr/python-java/export-to-html5/).

**Les animations de texte fonctionnent‑elles dans les dispositions et le masque des diapositives ?**

Les effets appliqués aux objets de mise en page/masque sont hérités par les diapositives, mais leur synchronisation et leur interaction avec les animations au niveau de la diapositive dépendent de la séquence finale sur la diapositive.