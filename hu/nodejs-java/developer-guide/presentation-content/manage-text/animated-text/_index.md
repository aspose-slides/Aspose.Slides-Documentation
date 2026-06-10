---
title: PowerPoint szöveg animálása JavaScript-ben
linktitle: Animált szöveg
type: docs
weight: 60
url: /hu/nodejs-java/animated-text/
keywords:
- animált szöveg
- szöveg animáció
- animált bekezdés
- bekezdés animáció
- animációs hatás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Készíts dinamikus animált szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Node.js segítségével, könnyen követhető, optimalizált kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat animált szöveggel az Aspose.Slides-ban, animációs hatások alkalmazásával egyes bekezdésekre, valamint a már egy szövegdobozban (keretben) bekezdésekhez rendelt hatások lekérésével. Az API metódusokra összpontosít, amelyek bekezdés‑szintű animációt adnak hozzá, és a már létező bekezdés‑animációs hatásokat vizsgálják egy bemutatóban.

## **Animációs hatások hozzáadása bekezdésekhez**

Hozzáadtuk az [**addEffect()**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) metódust a [**Sequence**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Sequence) és a [**Sequence**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Sequence) osztályokhoz. Ez a metódus lehetővé teszi, hogy animációs hatásokat adjunk egyetlen bekezdéshez. Ez a mintakód megmutatja, hogyan adhatunk animációs hatást egy bekezdéshez:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // válassza ki a bekezdést a hatás hozzáadásához
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // adja hozzá a Fly animációs hatást a kiválasztott bekezdéshez
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Animációs hatások lekérése bekezdésekben**

Előfordulhat, hogy meg szeretné tudni, milyen animációs hatások lettek egy bekezdéshez hozzáadva – például egy helyzetben azt szeretné lekérni a bekezdés animációs hatásait, mert ezeket a hatásokat egy másik bekezdésre vagy alakzatra kívánja alkalmazni.  
Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy lekérje az összes animációs hatást, amely a szövegdobozban (alakzatban) található bekezdésekre van alkalmazva. Ez a mintakód megmutatja, hogyan kérheti le egy bekezdés animációs hatásait:

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

## **GYIK**

**Hogyan különböznek a szöveganimációk a diaátmenetektől, és kombinálhatók-e?**  
A szöveganimációk egy objektum viselkedését szabályozzák az idő múlásával egy dián, míg a [átmenetek](/slides/hu/nodejs-java/slide-transition/) azt irányítják, hogyan változnak a diák. Egymástól függetlenek, és együtt is használhatók; a lejátszási sorrendet az animáció idővonal és a transition beállítások határozzák meg.

**Megmaradnak a szöveganimációk PDF‑re vagy képekre exportáláskor?**  
Nem. A PDF és a raszteres képek statikusak, így a diát egyetlen állapotban, mozgás nélkül látja. A mozgás megőrzéséhez használjon [videót](/slides/hu/nodejs-java/convert-powerpoint-to-video/) vagy [HTML](/slides/hu/nodejs-java/export-to-html5/) exportot.

**Működnek a szöveganimációk elrendezésekben és a dia-mesteren?**  
Az elrendezés/mesterobjektumokra alkalmazott hatásokat a diák öröklik, de azok időzítése és a dia‑szintű animációkkal való kölcsönhatása a dián végső sorrendtől függ.