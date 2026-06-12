---
title: Animovat text v PowerPointu na Androidu
linktitle: Animovaný text
type: docs
weight: 60
url: /cs/androidjava/animated-text/
keywords:
- animovaný text
- animace textu
- animovaný odstavec
- animace odstavce
- efekt animace
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte dynamický animovaný text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android, s snadno sledovatelnými a optimalizovanými příklady kódu v Javě."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s animovaným textem v Aspose.Slides pomocí aplikace animačních efektů na jednotlivé odstavce a získávání efektů již přiřazených odstavcům v textovém rámci. Zaměřuje se na API metody používané k přidání animace na úrovni odstavce a inspekci existujících animačních efektů odstavců v prezentaci.

## **Přidání animačních efektů k odstavcům**

Přidali jsme metodu [**addEffect()**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) do tříd [**Sequence**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Sequence) a [**ISequence**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISequence). Tato metoda vám umožňuje přidat animační efekty k jedinému odstavci. Tento ukázkový kód ukazuje, jak přidat animační efekt k jedinému odstavci:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // vyberte odstavec pro přidání efektu
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // přidejte efekt animace Fly do vybraného odstavce
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Získání animačních efektů odstavců**

Možná budete chtít zjistit animační efekty přidané k odstavci – například v jednom scénáři chcete získat animační efekty v odstavci, protože je plánujete použít u jiného odstavce nebo tvaru.

Aspose.Slides pro Android přes Java umožňuje získat všechny animační efekty aplikované na odstavce obsažené v textovém rámci (tvaru). Tento ukázkový kód ukazuje, jak získat animační efekty v odstavci:

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

**Jak se animační text liší od přechodů snímků a lze je kombinovat?**

Animace textu řídí chování objektu v čase na snímku, zatímco [transitions](/slides/cs/androidjava/slide-transition/) řídí, jak se snímky mění. Jsou nezávislé a mohou být použity společně; pořadí přehrávání je určeno časovou osou animace a nastavením přechodu.

**Zachovají se animační texty při exportu do PDF nebo obrázků?**

Ne. PDF a rastrové obrázky jsou statické, takže uvidíte jediný stav snímku bez pohybu. Pro zachování pohybu použijte export do [video](/slides/cs/androidjava/convert-powerpoint-to-video/) nebo [HTML](/slides/cs/androidjava/export-to-html5/).

**Fungují animace textu v rozvrzích a v hlavním snímku?**

Efekty aplikované na objekty rozvržení/hlavního snímku jsou děděny snímky, ale jejich časování a interakce s animacemi na úrovni snímku závisí na závěrečné sekvenci na snímku.