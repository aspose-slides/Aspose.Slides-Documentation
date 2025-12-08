---
title: Animierter Text
type: docs
weight: 60
url: /de/nodejs-java/animated-text/
keywords: "Animierter Text in PowerPoint"
description: "Animierter Text in PowerPoint mit Java"
---

## **Animationseffekte zu Absätzen hinzufügen**

Wir haben die [**addEffect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) Methode zu den Klassen [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) und [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) hinzugefügt. Diese Methode ermöglicht es Ihnen, Animations­effekte zu einem einzelnen Absatz hinzuzufügen. Dieses Beispiel‑Code zeigt, wie man einen Animations­effekt zu einem einzelnen Absatz hinzufügt:
```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Absatz auswählen, um einen Effekt hinzuzufügen
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // Fly-Animationseffekt zum ausgewählten Absatz hinzufügen
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Abrufen der Animations­effekte in Absätzen**

Sie möchten möglicherweise die zu einem Absatz hinzugefügten Animations­effekte ermitteln – zum Beispiel, wenn Sie die Animations­effekte eines Absatzes benötigen, um sie auf einen anderen Absatz oder ein anderes Shape anzuwenden.

Aspose.Slides für Node.js via Java ermöglicht es Ihnen, alle auf Absätze in einem Text‑Frame (Shape) angewendeten Animations­effekte abzurufen. Dieser Beispiel‑Code zeigt, wie man die Animations­effekte in einem Absatz erhält:
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

**Wie unterscheiden sich Textanimationen von Folienübergängen, und können sie kombiniert werden?**

Textanimationen steuern das Verhalten von Objekten über die Zeit auf einer Folie, während [Übergänge](/slides/de/nodejs-java/slide-transition/) bestimmen, wie Folien wechseln. Sie sind unabhängig und können gemeinsam verwendet werden; die Wiedergabereihenfolge wird durch die Animations‑Zeitachse und die Übergangseinstellungen bestimmt.

**Werden Textanimationen beim Exportieren in PDF oder Bilder beibehalten?**

Nein. PDF‑ und Rasterbilder sind statisch, daher sehen Sie einen einzelnen Folienzustand ohne Bewegung. Um die Bewegung zu erhalten, verwenden Sie den Export als [Video](/slides/de/nodejs-java/convert-powerpoint-to-video/) oder [HTML](/slides/de/nodejs-java/export-to-html5/).

**Funktionieren Textanimationen in Layouts und im Folienmaster?**

Auf Layout‑/Master‑Objekte angewendete Effekte werden von den Folien geerbt, jedoch hängen deren Timing und Interaktion mit Folien‑Animationen von der endgültigen Reihenfolge auf der Folie ab.