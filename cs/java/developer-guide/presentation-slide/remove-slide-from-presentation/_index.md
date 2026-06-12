---
title: Odstranění snímků z prezentací v Javě
linktitle: Odstranit snímek
type: docs
weight: 30
url: /cs/java/remove-slide-from-presentation/
keywords:
- odstranit snímek
- smazat snímek
- odstranit nepoužitý snímek
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Jednoduše odstraňujte snímky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Javu. Získejte přehledné ukázky kódu a zefektivněte svůj pracovní proces."
---
## **Úvod**

Pokud se snímek (nebo jeho obsah) stane nadbytečným, můžete jej smazat. Aspose.Slides poskytuje třídu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), která zapouzdřuje [ISlideCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/), což je úložiště všech snímků v prezentaci. Používáním ukazatelů (reference nebo indexu) na známý objekt [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/) můžete určit snímek, který chcete odstranit. 

## **Odstranění snímku podle odkazu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) .
1. Získejte odkaz na snímek, který chcete odstranit, pomocí jeho ID nebo indexu.
1. Odstraňte odkazovaný snímek z prezentace.
1. Uložte upravenou prezentaci. 

Tento kód v jazyce Java ukazuje, jak odstranit snímek podle jeho odkazu:

```java
// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("demo.pptx");
try {
    // Přistupuje k snímku pomocí jeho indexu v kolekci snímků
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Odstraňuje snímek pomocí jeho odkazu
    pres.getSlides().remove(slide);
    
    // Uloží upravenou prezentaci
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Odstranění snímku podle indexu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) .
1. Odstraňte snímek z prezentace podle jeho pozice v indexu.
1. Uložte upravenou prezentaci. 

Tento kód v jazyce Java ukazuje, jak odstranit snímek podle jeho indexu:

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

Aspose.Slides poskytuje metodu [removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (ze třídy [Compress](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/)), která vám umožní smazat nechtěné a nepoužívané snímky rozložení. Tento kód v jazyce Java ukazuje, jak odstranit snímek rozložení z prezentace PowerPoint:

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

Aspose.Slides poskytuje metodu [removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (ze třídy [Compress](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compress/)), která vám umožní smazat nechtěné a nepoužívané hlavní snímky. Tento kód v jazyce Java ukazuje, jak odstranit hlavní snímek z prezentace PowerPoint:

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

Po smazání se [kolekce](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/) přeindexuje: každý následující snímek se posune o jednu pozici vlevo, takže předchozí čísla indexů jsou zastaralá. Pokud potřebujete stabilní odkaz, použijte trvalé ID snímku místo jeho indexu.

**Je ID snímku odlišné od jeho indexu a mění se, když jsou smazány sousední snímky?**

Ano. Index představuje pozici snímku a mění se při přidání nebo odebrání snímků. ID snímku je trvalý identifikátor a nemění se, když jsou jiné snímky smazány.

**Jak mazání snímku ovlivní sekce snímků?**

Pokud snímek patřil do sekce, tato sekce bude mít jednoduše o jeden snímek méně. Struktura sekce zůstane stejná; pokud sekce zůstane prázdná, můžete [odstranit nebo přeskupit sekce](/slides/cs/java/slide-section/) podle potřeby.

**Co se stane s poznámkami a komentáři připojenými ke snímku při jeho smazání?**

[Poznámky](/slides/cs/java/presentation-notes/) a [komentáře](/slides/cs/java/presentation-comments/) jsou vázány na konkrétní snímek a jsou s ním odstraněny. Obsah na ostatních snímcích zůstane nedotčený.

**Jak se liší mazání snímků od čištění nepoužívaných rozložení/mistrů?**

Mazání odstraňuje konkrétní běžné snímky z prezentace. Čištění nepoužívaných rozložení/mistrů odstraňuje snímky rozložení nebo hlavní snímky, na které nic neodkazuje, což snižuje velikost souboru, aniž by se měnil obsah zbývajících snímků. Tyto akce jsou doplňkové: typicky nejprve odstraňte snímky a pak vyčistěte nepoužívané rozložení a mistry.