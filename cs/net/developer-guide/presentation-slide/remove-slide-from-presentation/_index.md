---
title: Odstranění snímků z prezentací v .NET
linktitle: Odstranit snímek
type: docs
weight: 30
url: /cs/net/remove-slide-from-presentation/
keywords:
- odstranit snímek
- smazat snímek
- odstranit nepoužívaný snímek
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Jednoduše odstraňujte snímky z prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Získejte přehledné ukázky kódu v C# a zefektivněte svůj pracovní postup."
---
## **Úvod**

Pokud se snímek (nebo jeho obsah) stane nadbytečným, můžete jej smazat. Aspose.Slides poskytuje třídu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) , která zapouzdřuje [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection), což je úložiště pro všechny snímky v prezentaci. Pomocí ukazatelů (reference nebo index) na známý objekt [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/) můžete určit snímek, který chcete odstranit. 

## **Odstranění snímku pomocí reference**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
1. Získejte referenci na snímek, který chcete odstranit, podle jeho ID nebo indexu.
1. Odstraňte referencovaný snímek z prezentace.
1. Uložte upravenou prezentaci. 

Tento C# kód ukazuje, jak odstranit snímek pomocí jeho reference:

```c#
// Vytvoří objekt Presentation, který reprezentuje soubor prezentace
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Přistupuje k snímku pomocí jeho indexu v kolekci snímků
    ISlide slide = pres.Slides[0];

    // Odstraňuje snímek pomocí jeho reference
    pres.Slides.Remove(slide);

    // Uloží upravenou prezentaci
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Odstranění snímku pomocí indexu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
1. Odstraňte snímek z prezentace podle jeho pozice v indexu.
1. Uložte upravenou prezentaci. 

Tento C# kód ukazuje, jak odstranit snímek pomocí jeho indexu:

```c#
// Vytvoří objekt Presentation, který představuje soubor prezentace
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Odstraňuje snímek pomocí jeho indexu
    pres.Slides.RemoveAt(0);

    // Uloží upravenou prezentaci
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Odstranění nepoužívaných snímků rozložení**

Aspose.Slides poskytuje metodu [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (třídy [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) ), která vám umožní smazat nechtěné a nepoužívané snímky rozložení. Tento C# kód ukazuje, jak odstranit snímek rozložení z prezentace PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Odstranění nepoužívaných hlavních snímků**

Aspose.Slides poskytuje metodu [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (třídy [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) ), která vám umožní smazat nechtěné a nepoužívané hlavní snímky. Tento C# kód ukazuje, jak odstranit hlavní snímek z prezentace PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Co se stane s indexy snímků po smazání snímku?**

Po smazání se [kolekce](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/) přeindexuje: každý následující snímek se posune o jednu pozici doleva, takže předchozí čísla indexů jsou neplatná. Pokud potřebujete stabilní odkaz, použijte trvalé ID snímku místo jeho indexu.

**Je ID snímku odlišné od jeho indexu a mění se, když jsou smazány sousední snímky?**

Ano. Index představuje pozici snímku a změní se, když jsou snímky přidány nebo odebrány. ID snímku je trvalý identifikátor a nemění se, když jsou jiné snímky smazány.

**Jak smazání snímku ovlivní sekce snímků?**

Pokud snímek patřil do sekce, tato sekce bude mít o jeden snímek méně. Struktura sekcí zůstává; pokud sekce zůstane prázdná, můžete [odstranit nebo přeskupit sekce](/slides/cs/net/slide-section/) podle potřeby.

**Co se stane s poznámkami a komentáři připojenými k snímku, když je smazán?**

[Notes](/slides/cs/net/presentation-notes/) a [comments](/slides/cs/net/presentation-comments/) jsou vázány na konkrétní snímek a jsou s ním odstraněny. Obsah na ostatních snímcích zůstává nedotčen.

**Jak se liší mazání snímků od čištění nepoužívaných rozložení/hlavních šablon?**

Mazání odstraňuje konkrétní běžné snímky z prezentace. Čištění nepoužívaných rozložení/hlavních šablon odstraňuje snímky rozložení nebo hlavní snímky, na které se nic neodkazuje, čímž se zmenší velikost souboru, aniž by se změnil obsah zbývajících snímků. Tyto akce jsou doplňkové: obvykle se nejprve maže a poté provádí čištění.