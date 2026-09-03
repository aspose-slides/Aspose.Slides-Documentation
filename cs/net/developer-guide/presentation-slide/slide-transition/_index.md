---
title: Spravovat přechody snímků v prezentacích v .NET
linktitle: Přechod snímku
type: docs
weight: 90
url: /cs/net/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- aplikovat přechod snímku
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
description: "Aplikujte přechody snímků, nakonfigurujte automatické posouvání snímků a přizpůsobte Morph a další efekty přechodu pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Časové přechody řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides pro .NET můžete pro každý snímek vybrat efekt přechodu, nakonfigurovat postup pomocí kliknutí myší nebo časovače a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v C#, aby aplikoval přechody, nastavil přesné trvání přechodu, spravoval načasování snímků a vytvořil přechod Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidat přechod snímku**

Pro aplikaci přechodu načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a přistupte k vlastnosti [SlideShowTransition](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/slideshowtransition/). Nastavte její [Type](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/type/) na hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitiontype/), poté prezentaci uložte.

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

## **Přidat pokročilý přechod snímku**

Můžete nastavit, jak dlouho snímek zůstává na obrazovce a zda kliknutí myší postupuje v prezentaci. Následující vlastnosti řídí toto chování:

- [AdvanceOnClick](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/advanceonclick/) umožňuje divákovi postoupit kliknutím myší.
- [AdvanceAfter](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/advanceafter/) umožňuje automatické postoupení.
- [AdvanceAfterTime](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/advanceaftertime/) určuje prodlevu před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak časované postoupení, aby divák mohl pokračovat kliknutím nebo čekáním na časovač. Pro použití jen časovače nastavte [AdvanceOnClick](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/advanceonclick/) na `false`. Prodleva řídí, kdy se prezentace posune dál; nenastavuje trvání vizuálního efektu přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatické posunutí po 3, 5 a 7 sekundách. Kliknutí myší také může posunout tyto snímky. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Pro kontrolu, zda je časované posunutí povoleno, přečtěte [AdvanceAfter](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/advanceafter/). Samotná uložená prodleva neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatické posunutí pro snímky s prodlevou delší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

## **Přesně ovládat načasování přechodu**

Použijte [Duration](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/duration/) k určení přesné délky efektu přechodu v milisekundách. Vlastnost [SlideShowTransition](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/slideshowtransition/) snímku expose tyto nastavení prostřednictvím [ISlideShowTransition](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/):

| Vlastnost | Účel |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/duration/) | Nastavuje trvání samotného efektu přechodu v milisekundách. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Nastavuje prodlevu před automatickým posunem snímku v milisekundách. Aktivujte [AdvanceAfter](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/advanceafter/) pro zapnutí tohoto časovače. |
| [Speed](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/speed/) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium nebo Fast. Používá se, když není zadáno explicitní trvání. |

[Duration](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/duration/) řídí pouze efekt přechodu; neurčuje, jak dlouho snímek zůstává viditelný. Prodlevu automatického posunu nastavejte samostatně. Když není zadáno explicitní trvání, Aspose.Slides určuje trvání efektu z typu přechodu a hodnoty [Speed](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Použít stejné trvání na každý snímek**

Pro konzistentní tempo použijte stejný efekt a přesné trvání na každý snímek. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitiontype/), a každému přechodu nastaví trvání 750 milisekund. Samostatně povolí automatické posunutí po 5 000 milisekundách a zakáže posun kliknutím myší, poté výsledek uloží jako PPTX.

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

    // Nakonfigurujte automatické posouvání nezávisle na trvání efektu.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Nastavit různá trvání pro jednotlivé snímky**

Různé snímky mohou používat různá trvání efektů. Například použijte krátký přechod pro titulní snímek a delší přechod pro úvod sekce. Tento příklad nastaví 500 milisekund pro první snímek a 1 200 milisekund pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

Při přípravě [animated GIF](/slides/cs/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/net/export-to-html5/) nebo [video](/slides/cs/net/convert-powerpoint-to-video/) nastavte přesná trvání přechodů před exportem, aby odpovídala zamýšlenému tempu. Například použijte 600 ms fade mezi scénami a upravte prodlevu posunu každého snímku samostatně, aby byl dostatek času na jeho vyprávění nebo obsah.

Pro GIF a video koordinujte výstupní počet snímků za sekundu s trváním efektu: 600 ms odpovídá 18 snímkům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte, jaké efekty a časové možnosti podporuje zvolený formát exportu, a předhlédněte výstup, aby byla synchronizace ověřena.

### **Načíst existující trvání přechodu**

Přečtěte [Duration](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/duration/) před úpravou přechodu, abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastaveno žádné explicitní trvání; nezáporná hodnota určuje uložené trvání v milisekundách. Není‑nastavená hodnota není vypočítaná doba přehrávání: Aspose.Slides používá typ přechodu a [Speed](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/speed/) k určení této doby. Nastavení typu přechodu může inicializovat trvání, proto nejprve prozkoumejte původní nastavení.

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

## **Morph přechod**

Morph přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph zkopírujte snímek, přesunete nebo změníte velikost objektu na kopii a aplikujte Morph přechod na druhý snímek. Tímto získá přechod odpovídající objekty, které se budou animovat mezi původním a upraveným stavem.

Následující příklad vytvoří snímek s textovým obdélníkem, zkopíruje snímek a změní pozici a velikost obdélníku na kopii. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a uvidíte efekt během prezentace.

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

## **Typy Morph přechodu**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitionmorphtype/) řídí, jak Morph přiřazuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitionmorphtype/) upravuje každou tvar jako celý objekt.
- [ByWord](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitionmorphtype/) animuje text přístupem k odpovídajícím slovům, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitionmorphtype/) animuje text přístupem k odpovídajícím znakům, kde je to možné.

Nastavte přechod [Type](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/type/) na Morph před přístupem k jeho [Value](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/value/). Hodnota pak poskytuje rozhraní [IMorphTransition](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/imorphtransition/), jehož vlastnost [MorphType](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/imorphtransition/morphtype/) vybírá režim přiřazení.

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

## **Nastavit efekty přechodu**

Některé přechody expose další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na vybraném [Type](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/type/). Nejprve nastavte typ, poté použijte příslušné rozhraní z jeho [Value](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/value/).

Následující příklad použije Cut přechod na první snímek `input.pptx`. Nastaví [FromBlack](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) přes [IOptionalBlackTransition](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/ioptionalblacktransition/), aby přechod začínal z černé obrazovky.

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

## **Často kladené otázky**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Upřednostněte [Duration](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/duration/), když potřebujete přesnou délku efektu v milisekundách. Použijte [Speed](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/slideshowtransition/speed/), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitionspeed/) – Slow, Medium nebo Fast – a není nastavena explicitní délka. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického posunu.

**Mohu k přechodu připojit zvuk a nechat ho smyčkovat?**

Ano. Přiřaďte vložený zvuk k [Sound](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/sound/), nastavte [SoundMode](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/soundmode/) na StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitionsoundmode/), a povolte [SoundLoop](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/soundloop/). Zvuk bude smyčkovat až do dalšího zvukového události v prezentaci.

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na všechny snímky?**

Projděte kolekci [Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) prezentace a nastavte pro každý snímek jeho přechod [Type](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/type/) na stejnou hodnotu. V tomtéž cyklu nastavte jakékoli časové a efektové možnosti, aby chování zůstalo konzistentní napříč snímky.

**Jak mohu zkontrolovat, který přechod je aktuálně nastaven na snímku?**

Přečtěte vlastnost [Type](https://reference.aspose.com/slides/cs/net/aspose.slides/islideshowtransition/type/) ze snímku [SlideShowTransition](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/slideshowtransition/). Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/cs/net/aspose.slides.slideshow/transitiontype/); None znamená, že není aplikován žádný efekt přechodu.