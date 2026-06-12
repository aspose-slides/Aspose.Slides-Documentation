---
title: Animujte text PowerPointu v Javě
linktitle: Animovaný text
type: docs
weight: 60
url: /cs/java/animated-text/
keywords:
  - animovaný text
  - animace textu
  - animovaný odstavec
  - animace odstavce
  - efekt animace
  - PowerPoint
  - OpenDocument
  - prezentace
  - Java
  - Aspose.Slides
description: "Vytvořte dynamický animovaný text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java s jednoduchými a optimalizovanými ukázkami kódu v jazyce Java."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s animovaným textem v Aspose.Slides aplikací animačních efektů na jednotlivé odstavce a získáváním efektů již přiřazených odstavcům v textovém rámci. Zaměřuje se na metody API používané k přidání animace na úrovni odstavce a ke kontrole existujících animačních efektů odstavců v prezentaci.

## **Přidat animační efekty k odstavcům**

Do tříd [**Sequence**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Sequence) a [**ISequence**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISequence) jsme přidali metodu [**addEffect()**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-). Tato metoda umožňuje přidat animační efekty k jedinému odstavci. Následující ukázkový kód vám ukazuje, jak přidat animační efekt k jednotlivému odstavci:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // vyberte odstavec pro přidání efektu
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // přidejte efekt Fly k vybranému odstavci
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Získat animační efekty odstavců**

Můžete potřebovat zjistit animační efekty přidané k odstavci – například v jednom scénáři chcete získat animační efekty v odstavci, protože je chcete použít pro jiný odstavec nebo tvar.

Aspose.Slides for Java vám umožňuje získat všechny animační efekty aplikované na odstavce obsažené v textovém rámci (tvaru). Následující ukázkový kód vám ukazuje, jak získat animační efekty v odstavci:

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

## **Často kladené otázky**

**Jak se animační efekty textu liší od přechodů snímků a lze je kombinovat?**

Animační efekty textu řídí chování objektu v čase na snímku, zatímco [transitions](/slides/cs/java/slide-transition/) řídí, jak se snímky mění. Jsou nezávislé a lze je použít společně; pořadí přehrávání je určeno časovou osou animací a nastavením přechodu.

**Zůstávají animační efekty textu zachovány při exportu do PDF nebo obrázků?**

Ne. PDF a rastrové obrázky jsou statické, takže uvidíte jediný stav snímku bez pohybu. Chcete-li zachovat pohyb, použijte export do [video](/slides/cs/java/convert-powerpoint-to-video/) nebo [HTML](/slides/cs/java/export-to-html5/).

**Fungují animační efekty textu v rozvrzích a v hlavním snímku?**

Efekty aplikované na objekty rozvržení/master jsou děděny snímky, ale jejich časování a interakce s animačními efekty na úrovni snímku závisí na konečné sekvenci na snímku.