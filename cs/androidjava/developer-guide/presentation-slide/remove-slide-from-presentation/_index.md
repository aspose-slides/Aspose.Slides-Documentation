---
title: Odstranit snímky z prezentací na Androidu
linktitle: Odstranit snímek
type: docs
weight: 30
url: /cs/androidjava/remove-slide-from-presentation/
keywords:
- odstranit snímek
- smazat snímek
- odstranit nepoužívaný snímek
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Jednoduše odstraňujte snímky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Android. Získejte přehledné ukázky Java kódu a zlepšete svůj pracovní postup."
---
## **Úvod**

Pokud se snímek (nebo jeho obsah) stane nadbytečným, můžete jej smazat. Aspose.Slides poskytuje třídu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/), která zapouzdřuje [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/), což je úložiště všech snímků v prezentaci. Pomocí ukazatelů (reference nebo index) na známý objekt [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/) můžete určit snímek, který chcete odstranit.

## **Odstranění snímku podle reference**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte referenci na snímek, který chcete odstranit, pomocí jeho ID nebo indexu.
1. Odstraňte referencovaný snímek z prezentace.
1. Uložte upravenou prezentaci.  

Tento Java kód ukazuje, jak odstranit snímek podle reference:

```java
// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("demo.pptx");
try {
    // Přistupuje k snímku přes jeho index v kolekci snímků
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Odstraní snímek pomocí jeho reference
    pres.getSlides().remove(slide);
    
    // Uloží upravenou prezentaci
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Odstranění snímku podle indexu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Odstraňte snímek z prezentace podle jeho pozice v indexu.
1. Uložte upravenou prezentaci.  

Tento Java kód ukazuje, jak odstranit snímek podle indexu:

```java
// Vytvoří objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("demo.pptx");
try {
    // Odstraní snímek pomocí jeho indexu
    pres.getSlides().removeAt(0);
    
    // Uloží upravenou prezentaci
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Odstranění nepoužívaných snímků rozložení**

Aspose.Slides poskytuje metodu [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (z třídy [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/)), která vám umožní smazat nežádoucí a nepoužívané snímky rozložení. Tento Java kód ukazuje, jak odstranit snímek rozložení z prezentace PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranění nepoužívaných hlavních snímků**

Aspose.Slides poskytuje metodu [removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (z třídy [Compress](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/compress/)), která vám umožní smazat nežádoucí a nepoužívané hlavní snímky. Tento Java kód ukazuje, jak odstranit hlavní snímek z prezentace PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **Často kladené otázky**

**Co se stane s indexy snímků po smazání snímku?**

Po smazání se [collection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/) přeindexuje: každý následující snímek se posune o jednu pozici doleva, takže předchozí čísla indexů jsou zastaralá. Pokud potřebujete stabilní odkaz, použijte trvalé ID snímku místo jeho indexu.

**Je ID snímku odlišné od jeho indexu a mění se, když jsou smazány sousední snímky?**

Ano. Index je pozice snímku a mění se, když jsou snímky přidány nebo odstraněny. ID snímku je trvalý identifikátor a nemění se, když jsou smazány jiné snímky.

**Jak mazání snímku ovlivní sekce snímků?**

Pokud snímek patřil do sekce, tato sekce jednoduše bude mít o jeden snímek méně. Struktura sekce zůstává; pokud sekce zůstane prázdná, můžete ji [remove or reorganize sections](/slides/cs/androidjava/slide-section/) podle potřeby.

**Co se stane s poznámkami a komentáři připojenými ke snímku po jeho smazání?**

[Notes](/slides/cs/androidjava/presentation-notes/) a [comments](/slides/cs/androidjava/presentation-comments/) jsou svázány s konkrétním snímkem a jsou odstraněny spolu s ním. Obsah na ostatních snímcích zůstává nedotčený.

**Jak se liší mazání snímků od čištění nepoužívaných rozložení/mistrů?**

Mazání odstraňuje konkrétní normální snímky z balíčku. Čištění nepoužívaných rozložení/mistrů odstraňuje rozložení nebo hlavní snímky, na které se již nikdo neodkazuje, čímž snižuje velikost souboru, aniž by měnilo obsah zbývajících snímků. Tyto akce jsou doplňkové: typicky nejprve mažete, pak čistíte.