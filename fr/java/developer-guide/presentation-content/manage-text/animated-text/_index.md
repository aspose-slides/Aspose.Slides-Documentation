---
title: Texte Animé
type: docs
weight: 60
url: /java/animated-text/
keywords: "Texte animé dans PowerPoint"
description: "Texte animé dans PowerPoint avec Java"
---

## Ajouter des Effets d'Animation aux Paragraphes

Nous avons ajouté la méthode [**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) aux classes [**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) et [**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence). Cette méthode vous permet d'ajouter des effets d'animation à un seul paragraphe. Ce code d'exemple vous montre comment ajouter un effet d'animation à un seul paragraphe :

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // sélectionner le paragraphe pour ajouter un effet
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ajouter un effet d'animation de Vol au paragraphe sélectionné
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## Obtenir les Effets d'Animation dans les Paragraphes

Vous pourriez décider de découvrir les effets d'animation ajoutés à un paragraphe—par exemple, dans un scénario, vous souhaitez obtenir les effets d'animation dans un paragraphe parce que vous prévoyez d'appliquer ces effets à un autre paragraphe ou forme.

Aspose.Slides pour Java vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Ce code d'exemple vous montre comment obtenir les effets d'animation dans un paragraphe :

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Le paragraphe \"" + paragraph.getText() + "\" a un effet de type " + effects[0].getType() + ".");
    }
} finally {
    pres.dispose();
}
```