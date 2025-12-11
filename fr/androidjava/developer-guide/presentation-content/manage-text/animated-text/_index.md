---
title: Animer le texte PowerPoint sur Android
linktitle: Texte animé
type: docs
weight: 60
url: /fr/androidjava/animated-text/
keywords:
- texte animé
- animation de texte
- paragraphe animé
- animation de paragraphe
- effet d'animation
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Créer du texte animé dynamique dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Android, avec des exemples de code Java optimisés et faciles à suivre."
---

## **Ajouter des effets d'animation aux paragraphes**

Nous avons ajouté la méthode [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) aux classes [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) et [**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence). Cette méthode vous permet d’ajouter des effets d’animation à un seul paragraphe. Le code d’exemple ci‑dessous montre comment ajouter un effet d’animation à un paragraphe unique :
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // sélectionner le paragraphe pour ajouter l'effet
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ajouter l'effet d'animation Fly au paragraphe sélectionné
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Obtenir les effets d'animation des paragraphes**

Il se peut que vous souhaitiez connaître les effets d’animation appliqués à un paragraphe — par exemple, dans un scénario où vous devez récupérer les effets d’un paragraphe afin de les appliquer à un autre paragraphe ou à une forme.

Aspose.Slides for Android via Java vous permet d’obtenir tous les effets d’animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Le code d’exemple ci‑dessous montre comment récupérer les effets d’animation d’un paragraphe :
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```


## **FAQ**

**Comment les animations de texte diffèrent‑elles des transitions de diapositive, et peuvent‑elles être combinées ?**

Les animations de texte contrôlent le comportement d’un objet au fil du temps sur une diapositive, tandis que les [transitions](/slides/fr/androidjava/slide-transition/) contrôlent la façon dont les diapositives changent. Elles sont indépendantes et peuvent être utilisées ensemble ; l’ordre de lecture est régi par la chronologie des animations et les paramètres de transition.

**Les animations de texte sont‑elles conservées lors de l’exportation vers PDF ou images ?**

Non. Les PDF et les images raster sont statiques, vous ne verrez donc qu’un seul état de la diapositive sans mouvement. Pour conserver le mouvement, utilisez l’exportation en [vidéo](/slides/fr/androidjava/convert-powerpoint-to-video/) ou en [HTML](/slides/fr/androidjava/export-to-html5/).

**Les animations de texte fonctionnent‑elles dans les dispositions et le masque des diapositives ?**

Les effets appliqués aux objets de disposition/masque sont hérités par les diapositives, mais leur chronologie et leur interaction avec les animations au niveau de la diapositive dépendent de la séquence finale sur la diapositive.