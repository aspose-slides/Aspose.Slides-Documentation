---
title: PowerPoint szöveg animálása Java-ban
linktitle: Animált szöveg
type: docs
weight: 60
url: /hu/java/animated-text/
keywords:
- animált szöveg
- szöveg animáció
- animált bekezdés
- bekezdés animáció
- animációs effektus
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Dinamikus animált szöveget hozhat létre PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java segítségével, könnyen követhető, optimalizált Java kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat animált szöveggel az Aspose.Slides-ban animációs effektusok alkalmazásával egyes bekezdésekre, valamint hogyan kérdezheti le a szövegkeretben már hozzárendelt effektusokat. A bekezdés‑szintű animáció hozzáadásához és a meglévő bekezdés‑animációs effektusok vizsgálatához használt API metódusokra összpontosít.

## **Animációs effektusok hozzáadása bekezdésekhez**

Hozzáadtuk az [**addEffect()**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) metódust a [**Sequence**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Sequence) és [**ISequence**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISequence) osztályokhoz. Ez a metódus lehetővé teszi, hogy egyetlen bekezdéshez adjunk animációs effektust. Az alábbi példa kód megmutatja, hogyan adhatunk animációs effektust egy bekezdéshez:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // válassza ki a bekezdést a hatás hozzáadásához
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // adja hozzá a Fly animációs effektust a kiválasztott bekezdéshez
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Animációs effektusok lekérése bekezdésekből**

Előfordulhat, hogy meg szeretné tudni egy bekezdéshez hozzáadott animációs effektusokat – például egy helyzetben azt szeretné lekérni, hogy milyen animációs effektusok vannak egy bekezdésben, mert azokat egy másik bekezdésre vagy alakzatra kívánja alkalmazni.

Az Aspose.Slides for Java lehetővé teszi, hogy lekérje az összes animációs effektust, amely a szövegkeretben (alakzat) található bekezdésekre alkalmazott. Az alábbi példa kód megmutatja, hogyan kaphatja meg a bekezdés animációs effektusait:

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

**Miben különbözik a szöveg animáció a diaátmenetektől, és kombinálhatóak-e?**

A szöveg animációk szabályozzák egy objektum viselkedését az időben a dián, míg a [transitions](/slides/hu/java/slide-transition/) a diák cseréjének módját szabályozza. Függetlenek egymástól, és együtt is használhatók; a lejátszási sorrendet az animáció idővonal és a átmenet beállítások határozzák meg.

**Megmaradnak a szöveg animációk PDF‑re vagy képekre exportáláskor?**

Nem. A PDF és a raszteres képek statikusak, így a dia egyetlen állapotát láthatja mozgás nélkül. A mozgás megőrzéséhez használjon [video](/slides/hu/java/convert-powerpoint-to-video/) vagy [HTML](/slides/hu/java/export-to-html5/) exportot.

**Működnek a szöveg animációk elrendezésekben és a dia mesterben?**

Az elrendezés/mester objektumokra alkalmazott effektusok öröklődnek a diákra, azonban azok időzítése és a dia szintű animációkkal való kölcsönhatása a dián lévő végső sorrendtől függ.