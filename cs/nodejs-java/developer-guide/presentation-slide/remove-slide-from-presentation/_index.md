---
title: Odstranění snímků z prezentací v JavaScriptu
linktitle: Odstranit snímek
type: docs
weight: 30
url: /cs/nodejs-java/remove-slide-from-presentation/
keywords:
- odstranit snímek
- smazat snímek
- odstranit nepoužívaný snímek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše odstraňujte snímky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js. Získejte přehledné ukázky kódu a zefektivněte svůj pracovní postup."
---
## **Úvod**

Pokud se snímek (nebo jeho obsah) stane nadbytečným, můžete jej odstranit. Aspose.Slides poskytuje třídu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/), která zapouzdřuje [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/), což je úložiště pro všechny snímky v prezentaci. Pomocí ukazatelů (reference nebo indexu) na známý objekt [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/) můžete specifikovat snímek, který chcete odstranit.

## **Odstranění snímku podle reference**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte referenci na snímek, který chcete odstranit, pomocí jeho ID nebo indexu.
1. Odstraňte odkazovaný snímek z prezentace.
1. Uložte upravenou prezentaci. 

Tento JavaScriptový kód ukazuje, jak odstranit snímek pomocí jeho reference:

```javascript
// Vytvořte objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Přistupuje k snímku pomocí jeho indexu v kolekci snímků
    var slide = pres.getSlides().get_Item(0);
    // Odstraňuje snímek pomocí jeho reference
    pres.getSlides().remove(slide);
    // Uloží upravenou prezentaci
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Odstranění snímku podle indexu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Odstraňte snímek z prezentace pomocí jeho pozice indexu.
1. Uložte upravenou prezentaci. 

Tento JavaScriptový kód ukazuje, jak odstranit snímek pomocí jeho indexu:

```javascript
// Instancuje objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Odstraňuje snímek pomocí jeho indexu
    pres.getSlides().removeAt(0);
    // Uloží upravenou prezentaci
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Odstranění nepoužívaného rozložení snímku**

Aspose.Slides poskytuje metodu [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) (třídy [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/)), která vám umožní odstranit nechtěná a nepoužívaná rozložení snímků. Tento JavaScriptový kód ukazuje, jak odstranit rozložení snímku z prezentace PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odstranění nepoužívaného hlavního snímku**

Aspose.Slides poskytuje metodu [removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (třídy [Compress](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/compress/)), která vám umožní odstranit nechtěné a nepoužívané hlavní snímky. Tento JavaScriptový kód ukazuje, jak odstranit hlavní snímek z prezentace PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Co se stane s indexy snímků po smazání snímku?**

Po smazání se [collection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/) znovu indexuje: každý následující snímek se posune o jednu pozici doleva, takže předchozí čísla indexů jsou zastaralá. Pokud potřebujete stabilní odkaz, použijte trvalé ID snímku místo jeho indexu.

**Je ID snímku odlišné od jeho indexu a mění se, když jsou smazány sousední snímky?**

Ano. Index je pozice snímku a změní se, pokud jsou snímky přidány nebo odebrány. ID snímku je trvalý identifikátor a nemění se, když jsou smazány jiné snímky.

**Jak ovlivňuje smazání snímku sekce snímků?**

Pokud snímek patřil do sekce, tato sekce bude jednoduše o jeden snímek méně. Struktura sekcí zůstává; pokud sekce bude prázdná, můžete [odebrat nebo přeuspořádat sekce](/slides/cs/nodejs-java/slide-section/) podle potřeby.

**Co se stane s poznámkami a komentáři připojenými k snímku po jeho smazání?**

[Notes](/slides/cs/nodejs-java/presentation-notes/) a [comments](/slides/cs/nodejs-java/presentation-comments/) jsou svázány s konkrétním snímkem a jsou odstraněny spolu s ním. Obsah na ostatních snímcích není ovlivněn.

**Čím se liší mazání snímků od vyčištění nepoužívaných rozložení/mistrovských snímků?**

Mazání odstraňuje konkrétní běžné snímky z prezentace. Vyčištění nepoužívaných rozložení/mistrovských snímků odstraňuje rozložení nebo hlavní snímky, na které se nic neodkazuje, čímž zmenší velikost souboru, aniž by změnilo obsah zbylých snímků. Tyto akce jsou doplňkové: obvykle se nejprve maže a pak se provádí vyčištění.