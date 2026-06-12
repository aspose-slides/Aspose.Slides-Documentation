---
title: Animovat text PowerPointu v JavaScriptu
linktitle: Animovaný Text
type: docs
weight: 60
url: /cs/nodejs-java/animated-text/
keywords:
- animovaný text
- animace textu
- animovaný odstavec
- animace odstavce
- efekt animace
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte dynamický animovaný text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js s přehlednými, optimalizovanými příklady kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s animovaným textem v Aspose.Slides aplikováním animačních efektů na jednotlivé odstavce a získáváním efektů již přiřazených odstavcům v textovém rámečku. Soustředí se na API metody používané k přidání animace na úrovni odstavce a kontrolu existujících animačních efektů odstavců v prezentaci.

## **Přidávání animačních efektů do odstavců**

Přidali jsme metodu [**addEffect()**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) do tříd [**Sequence**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Sequence) a [**Sequence**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Sequence). Tato metoda vám umožňuje přidat animační efekt k jednomu odstavci. Tento ukázkový kód vám ukazuje, jak přidat animační efekt k jednomu odstavci:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // vyberte odstavec pro přidání efektu
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // přidejte efekt Fly animace do vybraného odstavce
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Získání animačních efektů v odstavcích**

Můžete se rozhodnout zjistit animační efekty přidané k odstavci — například v jedné situaci chcete získat animační efekty v odstavci, protože plánujete tyto efekty použít u jiného odstavce nebo tvaru.

Aspose.Slides pro Node.js přes Java vám umožňuje získat všechny animační efekty aplikované na odstavce obsažené v textovém rámečku (tvaru). Tento ukázkový kód vám ukazuje, jak získat animační efekty v odstavci:

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

## **Často kladené otázky**

**Jak se animační efekty textu liší od přechodů snímků a lze je kombinovat?**

Animační efekty textu řídí chování objektu v čase na snímku, zatímco [přechody](/slides/cs/nodejs-java/slide-transition/) řídí, jak se snímky mění. Jsou nezávislé a lze je použít společně; pořadí přehrávání je určeno časovou osou animace a nastavením přechodu.

**Zůstávají animační efekty textu zachovány při exportu do PDF nebo obrázků?**

Ne. PDF a rastrové obrázky jsou statické, takže uvidíte jediný stav snímku bez pohybu. Pro zachování pohybu použijte export do [video](/slides/cs/nodejs-java/convert-powerpoint-to-video/) nebo [HTML](/slides/cs/nodejs-java/export-to-html5/).

**Fungují animační efekty textu v rozvrženích a hlavním snímku?**

Efekty aplikované na objekty rozvržení/master jsou zděděny snímky, ale jejich načasování a interakce s animacemi na úrovni snímku závisí na konečném pořadí na snímku.