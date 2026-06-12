---
title: Přístup k snímkům prezentace v .NET
linktitle: Přístup ke snímku
type: docs
weight: 20
url: /cs/net/access-slide-in-presentation/
keywords:
- přístup ke snímku
- index snímku
- ID snímku
- pozice snímku
- změna pozice
- vlastnosti snímku
- číslo snímku
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak přistupovat k snímkům a spravovat je v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Zvyšte produktivitu pomocí ukázek kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides získat a spravovat snímky v prezentaci. Ukazuje, jak načíst snímky podle jejich nulového indexu ze sbírky `Slides` a jak získat snímek podle jeho jedinečného ID pomocí metody `GetSlideById`.

Také se dozvíte, jak změnit pozici snímku nastavením vlastnosti `SlideNumber` a jak určit počáteční číslo snímku pro prezentaci pomocí vlastnosti `FirstSlideNumber`. Příklady demonstrují načtení prezentace, získání odkazů na snímky, aktualizaci pořadí nebo číslování snímků a uložení upravené prezentace.

## **Přístup ke snímku podle indexu**

Všechny snímky v prezentaci jsou uspořádány číselně podle jejich pozice, počínaje 0. První snímek je přístupný pomocí indexu 0; druhý snímek je přístupný pomocí indexu 1; atd.

Třída Presentation, která představuje soubor prezentace, zpřístupňuje všechny snímky jako kolekci [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection) (kolekci objektů [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/) ). Tento C# kód ukazuje, jak získat snímek podle jeho indexu:

```c#
// Vytvoří objekt Presentation, který představuje soubor prezentace
Presentation presentation = new Presentation("AccessSlides.pptx");

// Získá odkaz na snímek pomocí jeho indexu
ISlide slide = presentation.Slides[0];
```

## **Přístup ke snímku podle ID**

Každý snímek v prezentaci má přiřazené jedinečné ID. Pomocí metody [GetSlideById](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/getslidebyid) (zpřístupněné třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)) můžete cílit na toto ID. Tento C# kód ukazuje, jak zadat platné ID snímku a získat tento snímek pomocí metody [GetSlideById](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/methods/getslidebyid):

```c#
// Vytváří objekt Presentation, který představuje soubor prezentace
Presentation presentation = new Presentation("AccessSlides.pptx");

// Získá ID snímku
uint id = presentation.Slides[0].SlideId;

// Přistupuje k snímku pomocí jeho ID
IBaseSlide slide = presentation.GetSlideById(id);
```

## **Změna pozice snímku**

Aspose.Slides umožňuje změnit pozici snímku. Například můžete určit, že první snímek se má stát druhým snímkem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získáte odkaz na snímek (jehož pozici chcete změnit) pomocí jeho indexu
1. Nastavte novou pozici snímku pomocí vlastnosti [SlideNumber](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/slidenumber/).
1. Uložte upravenou prezentaci.

Tento C# kód demonstruje operaci, při níž je snímek na pozici 1 přesunut na pozici 2:

```c#
// Vytvoří objekt Presentation, který představuje soubor prezentace
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // Získá snímek, jehož pozice bude změněna
    ISlide sld = pres.Slides[0];

    // Nastaví novou pozici snímku
    sld.SlideNumber = 2;

    // Uloží upravenou prezentaci
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

První snímek se stal druhým; druhý snímek se stal prvním. Když změníte pozici snímku, ostatní snímky jsou automaticky upraveny.

## **Nastavení čísla snímku**

Pomocí vlastnosti [FirstSlideNumber](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/firstslidenumber/) (zpřístupněné třídou [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)) můžete určit nové číslo pro první snímek v prezentaci. Tato operace způsobí přepočet čísel ostatních snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte číslo snímku.
1. Nastavte číslo snímku.
1. Uložte upravenou prezentaci.

Tento C# kód demonstruje operaci, při níž je první číslo snímku nastaveno na 10:

```c#
 // Vytváří objekt Presentation, který představuje soubor prezentace
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // Získá číslo snímku
    int firstSlideNumber = presentation.FirstSlideNumber;

    // Nastaví číslo snímku
    presentation.FirstSlideNumber=10;
    
    // Uloží upravenou prezentaci
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

Pokud chcete první snímek přeskočit, můžete číslování zahájit od druhého snímku (a pro první snímek skrýt číslování) tímto způsobem:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // Nastaví číslo pro první snímek prezentace
    presentation.FirstSlideNumber = 0;

    // Zobrazí čísla snímků pro všechny snímky
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // Skryje číslo snímku pro první snímek
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // Uloží upravenou prezentaci
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Odpovídá číslo snímku, které uživatel vidí, nulovému indexu ve sbírce?**

Číslo zobrazované na snímku může začínat libovolnou hodnotou (např. 10) a nemusí odpovídat indexu; vztah řídí nastavení [první číslo snímku](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/firstslidenumber/).

**Ovlivňují skryté snímky indexování?**

Ano. Skrytý snímek zůstává ve sbírce a je započítán při indexování; „skrytý“ se vztahuje k zobrazování, nikoli k jeho pozici ve sbírce.

**Mění se index snímku, když jsou přidány nebo odebrány jiné snímky?**

Ano. Indexy vždy odrážejí aktuální pořadí snímků a jsou přepočítány při vložení, odstranění a přesunutí.