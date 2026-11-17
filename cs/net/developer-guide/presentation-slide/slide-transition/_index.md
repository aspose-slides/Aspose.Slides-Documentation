---
title: Spravovat přechody snímků v prezentacích v .NET
linktitle: Přechod snímku
type: docs
weight: 90
url: /cs/net/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- použít přechod snímku
- pokročilý přechod snímku
- morph přechod
- typ přechodu
- efekt přechodu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte přechody snímků, nakonfigurujte automatické posunování snímků a přizpůsobte Morph a další efekty přechodů s Aspose.Slides pro .NET."
---
## **Přehled**

Slide transitions control how slides appear during a slide show. With Aspose.Slides for .NET, you can choose a transition effect for each slide, configure advancement by mouse click or timer, and adjust options specific to an effect. This article uses C# examples to apply transitions, set exact transition durations, manage slide timing, and create a Morph transition between two slides. The examples also show how to save the settings to a PPTX file.

## **Přidat přechod snímku**

Pro aplikaci přechodu načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a přistupte k vlastnosti snímku [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/). Nastavte její [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) a poté prezentaci uložte.

Následující příklad použije přechod Circle na první snímek a přechod Comb na druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Kolečkový přechod**

Vlastnost [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) rozhraní [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) řídí počet radiálních sektorů, které odhalují cílový snímek. Nastavte přechod snímku [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na Wheel z [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) před tím než získáte [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) jako [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

Tento příklad vytvoří dva identické páry snímků: černý snímek následovaný snímkem se zlatým obdélníkem. Cílové snímky používají počet paprsků 1 a 8, se stejnou [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) a explicitní [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 8 000 milisekund, aby byl rozdíl snadno pozorovatelný.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

Otevřete výstupní prezentaci v PowerPointu a spusťte prezentaci. Přesuňte se ze snímku 1 na snímek 2 a poté ze snímku 3 na snímek 4. V přehrávání PowerPointu ověřený počet paprsků 1 odhalí snímek jedním pootočením po směru hodinových ručiček; ověřený počet 8 odhalí snímek osmi radially sectorů současně. Obsah cíle a časování přechodu jsou identické, takže rozdíl je v počtu odhalovacích sektorů.

## **Přidat pokročilý přechod snímku**

Můžete nastavit, jak dlouho snímek zůstane na obrazovce a zda kliknutí myší posune prezentaci dál. Následující vlastnosti řídí toto chování:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) umožňuje divákovi posunout dál kliknutím myši.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) umožňuje automatické posunutí.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) určuje zpoždění před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak časované posunutí, aby divák mohl pokračovat kliknutím nebo čekáním na časovač. Pro použití pouze časovače nastavte [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) na `false`. Zpoždění řídí, kdy se prezentace posune dál; nenastavuje délku vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty k prvním třem snímkům a povolí automatické posunutí po 3, 5 a 7 sekundách. Kliknutí myší mohou také posunout tyto snímky. Použijte soubor `input.pptx` s alespoň třemi snímky.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Pro kontrolu, zda je časované posunutí povoleno, přečtěte [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Uložené zpoždění samo o sobě neindikuje, že je časovač aktivní.

Další příklad otevře výše uložený soubor, vypíše každý povolený časovač a zakáže automatické posunutí pro snímky se zpožděním delším než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizované nastavení.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Přesně ovládat časování přechodu**

Použijte [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/), abyste určili přesnou délku efektu přechodu v milisekundách. Vlastnost [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) snímku zpřístupňuje tato nastavení přes [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Vlastnost | Účel |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Nastavuje dobu trvání samotného efektu přechodu v milisekundách. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Nastavuje zpoždění před automatickým posunem snímku v milisekundách. Aktivujte [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/), aby se tento časovač spustil. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadána přesná doba. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) kontroluje jen efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Nastavte zpoždění automatického posunu samostatně. Když není nastaven explicitní čas, Aspose.Slides určuje dobu trvání efektu z typu přechodu a hodnoty [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Použít stejnou dobu na všechny snímky**

Pro jednotné tempo použijte stejný efekt a přesnou dobu trvání na každý snímek. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), a nastaví každému přechodu dobu 750 milisekund. Samostatně povolí automatické posunutí po 5 000 milisekundách a zakáže posunutí kliknutím myši, poté výsledek uloží jako PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Nastavte automatické posouvání nezávisle na době trvání efektu.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Nastavit různé doby pro jednotlivé snímky**

Různé snímky mohou používat různé doby efektů. Například použijte krátký přechod pro titulek a delší přechod pro úvod sekce. Tento příklad nastaví 500 milisekund pro první snímek a 1 200 milisekund pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Koordinovat přechody s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/net/export-to-html5/), nebo [video](/slides/cs/net/convert-powerpoint-to-video/) nastavte přesné doby přechodů před exportem, aby odpovídaly požadovanému tempu. Například použijte 600‑milisekundový fade mezi scénami a upravte zpoždění posunu každého snímku samostatně, aby byl dostatek času na jeho vyprávění nebo obsah.

Pro GIF a video koordinujte výstupní snímkovou frekvenci s délkou efektu: 600 milisekund odpovídá 18 snímkům při 30 snímcích za sekundu. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a časové možnosti podporuje zvolený exportní formát, a proveďte náhled výstupu pro potvrzení synchronizace.

### **Načíst existující dobu přechodu**

Přečtěte [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) před úpravou přechodu, abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastavena žádná explicitní doba; nezáporná hodnota určuje uloženou dobu v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/), aby tuto dobu určil. Nastavení typu přechodu může inicializovat dobu, takže nejprve prozkoumejte původní nastavení.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Přechod Morph**

Přechod Morph animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph naklonujte snímek, přesuňte nebo změňte velikost objektu v klonu a aplikujte přechod Morph na druhý snímek. To umožní přechodu animovat odpovídající objekty mezi jejich původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, naklonuje snímek a změní pozici a velikost obdélníku v klonu. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a podívejte se na efekt během prezentace.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Typy přechodu Morph**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) určuje, jak Morph porovnává a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) zachází s každým tvarem jako s celým objektem.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animuje text porovnáním slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animuje text porovnáním znaků, kde je to možné.

Nastavte přechod [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na Morph před tím, než získáte jeho [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). Hodnota pak poskytuje rozhraní [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/), jehož vlastnost [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) vybírá režim porovnání.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

<!-- visual-explanation:slide-transition:start -->
[![Jednotky pro párování Morph zobrazené jako celý tvar, jednotlivá slova a jednotlivé znaky.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph může porovnávat celé tvary, slova nebo znaky, kde je to možné. Tyto rámečky označují porovnávací jednotky místo pozorovaného pohybu. Příklad vybírá ByWord na druhém snímku.*
<!-- visual-explanation:slide-transition:end -->

## **Nastavit efekty přechodu**

Některé přechody nabízejí další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na vybraném typu přechodu [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). Nejprve nastavte typ a poté použijte odpovídající rozhraní z jeho [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

Následující příklad použije přechod Cut na první snímek souboru `input.pptx`. Nastavuje [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) prostřednictvím [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/), aby přechod začínal z černé obrazovky.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **Často kladené dotazy**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/), pokud potřebujete přesnou dobu trvání efektu v milisekundách. Použijte [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium nebo Fast, a není nastavena explicitní doba. Tato nastavení řídí efekt přechodu nezávisle na zpoždění automatického posunu.

**Mohu k přechodu připojit zvuk a nechat jej opakovat?**

Ano. Přiřaďte vložený zvuk k [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), nastavte [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) na StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/), a povolte [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). Zvuk se bude opakovat až do dalšího zvukového události v prezentaci.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Projděte kolekci [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) prezentace a nastavte každému snímku přechod [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na stejnou hodnotu. V tomtéž cyklu nastavte také časování a možnosti efektu, aby chování bylo napříč snímky konzistentní.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Přečtěte vlastnost [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) ze [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) snímku. Vrací hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/); None znamená, že není aplikován žádný efekt přechodu.