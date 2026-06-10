---
title: PowerPoint szöveg animálása Androidon
linktitle: Animált szöveg
type: docs
weight: 60
url: /hu/androidjava/animated-text/
keywords:
- animált szöveg
- szöveg animáció
- animált bekezdés
- bekezdés animáció
- animációs hatás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Dinamikus animált szöveget hozhat létre PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android használatával, könnyen követhető, optimalizált Java kódpéldákkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat animált szöveggel az Aspose.Slides-ban animációs hatások alkalmazásával az egyes bekezdésekre, valamint a már bekezdésekhez rendelt hatások lekérdezésével egy szövegkeretben. Az API-módszerekre összpontosít, amelyek a bekezdés-szintű animációk hozzáadását és a meglévő bekezdésanimációs hatások vizsgálatát teszik lehetővé egy bemutatóban.

## **Animációs hatások hozzáadása bekezdésekhez**

Hozzáadtuk a [**addEffect()**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) metódust a [**Sequence**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Sequence) és a [**ISequence**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISequence) osztályokhoz. Ez a metódus lehetővé teszi animációs hatások hozzáadását egyetlen bekezdéshez. Az alábbi minta kód megmutatja, hogyan adhat animációs hatást egyetlen bekezdéshez:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // válassza ki a bekezdést a hatás hozzáadásához
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // adja hozzá a Fly animációs hatást a kiválasztott bekezdéshez
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Animációs hatások lekérése bekezdésekhez**

Előfordulhat, hogy meg szeretné tudni, milyen animációs hatások kerültek egy bekezdéshez – például egy esetben a bekezdés animációs hatásait szeretné lekérni, mert ezeket a hatásokat egy másik bekezdésre vagy alakzatra szeretné alkalmazni.  
Az Aspose.Slides for Android via Java lehetővé teszi, hogy lekérje az összes animációs hatást, amely a szövegkeretben (alakzatban) lévő bekezdésekre alkalmazott. Az alábbi minta kód megmutatja, hogyan kérheti le egy bekezdés animációs hatásait:

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

## **GYIK**

**Miként különböznek a szöveganimációk a diavetítési átmenetektől, és kombinálhatók-e?**  
A szöveganimációk vezérlik egy objektum viselkedését az időben egy dián, míg a [átmenetek](/slides/hu/androidjava/slide-transition/) szabályozzák, hogyan változnak a diák. Függetlenek egymástól, és együtt is használhatók; a lejátszási sorrendet az animációs idővonal és a transzíció beállítások határozzák meg.

**Megmaradnak a szöveganimációk PDF vagy képek exportálakor?**  
Nem. A PDF és a raszteres képek statikusak, így a diát csak egyetlen állapotban, mozgás nélkül látja. A mozgás megőrzéséhez használjon [videó](/slides/hu/androidjava/convert-powerpoint-to-video/) vagy [HTML](/slides/hu/androidjava/export-to-html5/) exportot.

**Működnek a szöveganimációk elrendezésekben és a dia mesterben?**  
A elrendezés/mester objektumokra alkalmazott hatások öröklődnek a diákra, de időzítésük és a dia-szintű animációkkal való kölcsönhatásuk a dián lévő végső sorrendtől függ.