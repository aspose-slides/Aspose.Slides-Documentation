---
title: Správa přechodů snímků v prezentacích v .NET
linktitle: Přechod snímku
type: docs
weight: 90
url: /cs/net/slide-transition/
keywords:
- přechod snímku
- přidání přechodu snímku
- použití přechodu snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak přizpůsobit přechody snímků v Aspose.Slides pro .NET, s podrobným návodem krok za krokem pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak spravovat přechody snímků v prezentacích pomocí Aspose.Slides. Ukazuje, jak použít typy přechodů na snímky, nakonfigurovat chování přechodu, jako je postup po kliknutí nebo po uplynutí určeného času, zkontrolovat a zakázat automatické postupování, použít Morph přechod a jeho typy a nastavit možnosti efektu přechodu. Příklady ukazují, jak načíst nebo vytvořit prezentaci, upravit nastavení přechodu pro vybrané snímky a uložit výsledek jako soubor PPTX. Článek také odpovídá na často kladené otázky týkající se rychlosti přechodu, zvuků přechodu, aplikace stejného přechodu na více snímků a kontroly přechodu aktuálně nastaveného na snímku.

## **Přidání přechodu snímku**

Aby bylo pochopení snazší, demonstrovali jsme použití Aspose.Slides pro .NET k řízení jednoduchých přechodů snímků. Vývojáři mohou nejen aplikovat různé efekty přechodu na snímky, ale také přizpůsobit chování těchto efektů. Pro vytvoření jednoduchého efektu přechodu snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Použijte typ přechodu snímku na snímku z jednoho z efektů přechodu nabízených Aspose.Slides pro .NET pomocí výčtu TransitionType.
3. Zapište upravený soubor prezentace.

```c#
// Vytvořte instanci třídy Presentation pro načtení zdrojového souboru prezentace
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Použijte kruhový typ přechodu na snímku 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Použijte typ přechodu comb na snímku 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Uložte prezentaci na disk
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Přidání pokročilého přechodu snímku**

V předchozí sekci jsme aplikovali jen jednoduchý efekt přechodu na snímek. Nyní, aby byl tento jednoduchý efekt ještě lepší a řízenější, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Použijte typ přechodu snímku na snímku z jednoho z efektů přechodu nabízených Aspose.Slides pro .NET.
3. Můžete také nastavit přechod tak, aby postupoval po kliknutí, po uplynutí určité doby nebo obojí.
4. Pokud je přechod snímku nastaven na postup po kliknutí, přechod se posune pouze po kliknutí myší. Navíc, pokud je nastavena vlastnost Advance After Time, přechod se posune automaticky po uplynutí zadaného času.
5. Zapište upravenou prezentaci jako soubor prezentace.

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Použijte kruhový typ přechodu na snímku 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Nastavte dobu trvání přechodu na 3 sekundy
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Použijte typ přechodu comb na snímku 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Nastavte dobu trvání přechodu na 5 sekund
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Použijte zoomový typ přechodu na snímku 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Nastavte dobu trvání přechodu na 7 sekund
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Uložte prezentaci na disk
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Navíc, pomocí vlastnosti [AdvanceAfter](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/advanceafter/) můžete zkontrolovat, zda je přechod snímku nakonfigurován k přechodu na další snímek, nebo nastavení zakázat.

Tento C# kód ukazuje fungování:

```c#
// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Získá přechod snímku
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Zkontroluje, zda je povoleno nastavení Advance After Time
        if (slideTransition.AdvanceAfter)
        {
            // Vytiskne hodnotu Advance After Time
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Zakáže přechod po určité době, pokud je hodnota AdvanceAfterTime větší než 2 sekundy
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Morph přechod**

Aspose.Slides pro .NET nyní podporuje [Morph Transition](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/imorphtransition). Jedná se o nový morph přechod představený v PowerPoint 2019. Morph přechod umožňuje plynulé animování přesunu z jednoho snímku na další. Tento článek popisuje koncepci a způsob použití Morph přechodu. Pro efektivní použití Morph přechodu budete potřebovat dva snímky s alespoň jedním společným objektem. Nejjednodušší způsob je duplikovat snímek a poté přesunout objekt na druhém snímku na jiné místo.

Následující útržek kódu ukazuje, jak přidat klon snímku s nějakým textem do prezentace a nastavit přechod typu [morph type](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) na druhý snímek.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Typy Morph přechodu**

Byl přidán nový výčet [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitionmorphtype). Reprezentuje různé typy Morph přechodu snímku.

Výčet TransitionMorphType má tři členy:

- ByObject: Morph přechod bude proveden s ohledem na tvary jako nedělitelné objekty.
- ByWord: Morph přechod bude proveden přenášením textu po slovech, kde je to možné.
- ByChar: Morph přechod bude proveden přenášením textu po znacích, kde je to možné.

Následující útržek kódu ukazuje, jak nastavit morph přechod na snímek a změnit typ morph:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Nastavení efektů přechodu**

Aspose.Slides pro .NET podporuje nastavení efektů přechodu, například z černé, zleva, zprava atd. Pro nastavení efektu přechodu postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
- Získejte referenci na snímek.
- Nastavte efekt přechodu.
- Zapište prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/).

V níže uvedeném příkladu jsme nastavili efekty přechodu.

```c#
// Vytvořte instanci třídy Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Nastavte efekt
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Uložte prezentaci na disk
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Nastavte [Speed](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/speed/) přechodu pomocí nastavení [TransitionSpeed](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitionspeed/) (např. pomalá/střední/rychlá).

**Mohu ke přechodu připojit zvuk a nastavit jeho smyčku?**

Ano. Můžete vložit zvuk do přechodu a řídit chování pomocí nastavení jako [Sound](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/soundloop/), plus metadata jako [SoundIsBuiltIn](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) a [SoundName](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/soundname/).

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na každý snímek?**

Nastavte požadovaný typ přechodu v nastavení přechodu pro každý snímek; přechody jsou uloženy per snímek, takže aplikace stejného typu na všechny snímky poskytne jednotný výsledek.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Prozkoumejte [transition settings](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslide/slideshowtransition/) snímku a přečtěte jeho [transition type](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/type/); tato hodnota vám přesně řekne, který efekt je aplikován.