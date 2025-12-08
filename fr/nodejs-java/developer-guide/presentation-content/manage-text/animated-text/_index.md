---
title: Texte animé
type: docs
weight: 60
url: /fr/nodejs-java/animated-text/
keywords: "Texte animé dans PowerPoint"
description: "Texte animé dans PowerPoint avec Java"
---

## **Ajout d'effets d'animation aux paragraphes**

Nous avons ajouté la méthode [**addEffect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) aux classes [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) et [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence). Cette méthode vous permet d'ajouter des effets d'animation à un seul paragraphe. Le code d'exemple suivant montre comment ajouter un effet d'animation à un seul paragraphe :
```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // sélectionner le paragraphe pour ajouter l'effet
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // ajouter l'effet d'animation Fly au paragraphe sélectionné
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Obtention des effets d'animation dans les paragraphes**

Vous pouvez décider de découvrir les effets d'animation ajoutés à un paragraphe — par exemple, dans un scénario, vous souhaitez obtenir les effets d'animation d'un paragraphe car vous prévoyez d'appliquer ces effets à un autre paragraphe ou à une forme.

Aspose.Slides for Node.js via Java vous permet d'obtenir tous les effets d'animation appliqués aux paragraphes contenus dans un cadre de texte (forme). Le code d'exemple suivant montre comment obtenir les effets d'animation dans un paragraphe :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```


## **FAQ**

**En quoi les animations de texte diffèrent‑elles des transitions de diapositive, et peuvent‑elles être combinées ?**

Les animations de texte contrôlent le comportement d'un objet au fil du temps sur une diapositive, tandis que [transitions](/slides/fr/nodejs-java/slide-transition/) contrôlent la façon dont les diapositives changent. Elles sont indépendantes et peuvent être utilisées ensemble ; l'ordre de lecture est régi par la chronologie des animations et les paramètres de transition.

**Les animations de texte sont‑elles conservées lors de l'exportation vers PDF ou images ?**

Non. Les PDF et les images raster sont statiques, vous verrez donc un seul état de la diapositive sans mouvement. Pour conserver le mouvement, utilisez l'exportation [video](/slides/fr/nodejs-java/convert-powerpoint-to-video/) ou [HTML](/slides/fr/nodejs-java/export-to-html5/).

**Les animations de texte fonctionnent‑elles dans les mises en page et le masque des diapositives ?**

Les effets appliqués aux objets de mise en page/masque sont hérités par les diapositives, mais leur chronologie et leur interaction avec les animations au niveau de la diapositive dépendent de la séquence finale sur la diapositive.