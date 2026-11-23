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
description: "Použijte přechody snímků, nastavte automatické posouvání snímků a přizpůsobte Morph a další efekty přechodu pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Přechody snímků řídí, jak se snímky zobrazují během prezentace. S Aspose.Slides pro .NET můžete pro každý snímek zvolit efekt přechodu, nastavit postupování kliknutím myši nebo časovačem a upravit možnosti specifické pro daný efekt. Tento článek používá příklady v C#, aby ukázal, jak použít přechody, nastavit přesnou délku přechodu, spravovat časování snímků a vytvořit přechod Morph mezi dvěma snímky. Příklady také ukazují, jak uložit nastavení do souboru PPTX.

## **Přidání přechodu snímku**

Chcete‑li použít přechod, načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a přistupte k vlastnosti snímku [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/). Nastavte její [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) a poté prezentaci uložte.

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

## **Přechod Wheel**

Vlastnost [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) rozhraní [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) určuje počet radiálních sektorů, které odhalují cílový snímek. Nastavte [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) snímku na Wheel z [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) před tím, než získáte [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) jako [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

Tento příklad vytvoří dva identické páry snímků: černý snímek následovaný snímkem se zlatým obdélníkem. Cílové snímky použijí počty paprsků 1 a 8, se stejnou [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) a výslovnou [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 8 000 ms, aby byl rozdíl snadno pozorovatelný.

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

Otevřete výstupní prezentaci v PowerPointu a spusťte prezentaci. Přejděte ze snímku 1 na snímek 2 a poté ze snímku 3 na snímek 4. Při přehrávání v PowerPointu ověřený počet paprsků 1 odhalí snímek jedním otáčením po směru hodinových ručiček; ověřený počet 8 odhalí snímek osmma radiálními sektory najednou. Obsah cílového snímku i časování přechodu jsou identické, rozdíl je pouze v počtu odhalovacích sektorů.

## **Rozplynutí přes černou s přechodem Reveal**

Nastavte typ přechodu cílového snímku na Reveal a poté použijte [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) k nastavení [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/). Příklad vytvoří tyrkysový zdrojový snímek a korálový cílový snímek, pak oba klony, abyste mohli porovnat stejný dvousekundový přechod s vypnutým a zapnutým rozplynutím.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

V prezentaci PowerPoint přejděte ze snímku 1 na snímek 2. Tyrkysová barva se přímo rozplyne na korálovou. Poté přejděte ze snímku 3 na snímek 4. Obrazovka se na okamžik zčerná až na téměř černé, než se objeví korálový snímek. Oba snímky si zachovají své původní barvy pozadí.

Níže jsou řádky s rámečky z PowerPointu po půlsekundových intervalech. Porovnejte střední snímek v každém řádku a uvidíte vliv nastavení.

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **Přidání pokročilého přechodu snímku**

Můžete nastavit, jak dlouho snímek zůstane na obrazovce a zda kliknutí myší posune prezentaci dál. Následující vlastnosti řídí toto chování:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) umožňuje uživateli postupovat kliknutím myši.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) povoluje automatické postoupnutí.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) udává prodlevu před automatickým posunem v milisekundách.

Povolte jak kliknutí, tak časované posouvání, aby si uživatel mohl buď kliknutím pokračovat, nebo počkat na časovač. Chcete‑li použít jen časovač, nastavte [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) na `false`. Prodleva určuje, kdy se prezentace posune; nenastavuje délku samotného vizuálního přechodu.

Tento příklad přiřadí různé efekty prvním třem snímkům a povolí automatické posouvání po 3, 5 a 7 sekundách. Kliknutí myší mohou tyto snímky také posunout. Použijte soubor `input.pptx` s alespoň třemi snímky.

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

Pro kontrolu, zda je časované posouvání povoleno, přečtěte [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Pouze uložená prodleva neznamená, že je časovač aktivní.

Další příklad otevře výše uložený soubor, nahlásí každý povolený časovač a zakáže automatické posouvání pro snímky s prodlevou delší než dvě sekundy. Pro tyto snímky povolí kliknutí myší a uloží aktualizovaná nastavení.

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

## **Přesné řízení načasování přechodu**

Použijte [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) k určení přesné délky efektu přechodu v milisekundách. Vlastnost snímku [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) tuto konfiguraci zveřejňuje skrze [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Vlastnost | Účel |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Nastavuje dobu trvání samotného efektu přechodu v milisekundách. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Udává prodlevu před automatickým posunem snímku v milisekundách. Pro aktivaci tohoto časovače zapněte [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Vybere předdefinovanou kategorii rychlosti z [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium nebo Fast. Používá se, pokud není zadána přesná doba. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) řídí jen samotný efekt přechodu; neurčuje, jak dlouho snímek zůstane viditelný. Nastavte prodlevu automatického posunu zvlášť. Když není zadána explicitní doba, Aspose.Slides určí dobu trvání podle typu přechodu a hodnoty [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Použít stejnou dobu na každý snímek**

Pro jednotné tempo použijte stejný efekt a přesnou dobu na všechny snímky. Tento příklad načte `input.pptx`, vybere Fade z [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) a nastaví každému přechodu dobu 750 ms. Zároveň povolí automatické posouvání po 5 000 ms a zakáže posouvání kliknutím, poté uloží výsledek jako PPTX.

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

    // Nastavte automatické posouvání nezávisle na trvání efektu.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Nastavit různé doby pro jednotlivé snímky**

Různé snímky mohou mít různé doby efektů. Například použijte krátký přechod pro úvodní snímek a delší pro úvod sekce. Tento příklad nastaví 500 ms pro první snímek a 1 200 ms pro druhý. Použijte soubor `input.pptx` s alespoň dvěma snímky.

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

### **Koordinace přechodů s animovaným výstupem**

Při přípravě [animated GIF](/slides/cs/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/cs/net/export-to-html5/) nebo [video](/slides/cs/net/convert-powerpoint-to-video/) nastavte přesné doby přechodů před exportem, aby odpovídaly zamýšlenému tempu. Například použijte 600 ms fade mezi scénami a samostatně upravte prodlevu posunu každého snímku, aby byl dostatek času na komentář nebo obsah.

U GIF a videa sladte rychlost snímků výstupu s délkou efektu: 600 ms odpovídá 18 rámcům při 30 fps. V HTML5 povolte animované přechody v nastavení exportu. Zkontrolujte podporované efekty a časování cílového formátu a proveďte náhled výstupu, aby byl synchronizován.

### **Načtení existující délky přechodu**

Před úpravou přechodu si přečtěte [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/), abyste zjistili, zda je uložena explicitní hodnota. Hodnota `-1` znamená, že není nastavená žádná explicitní doba; nezáporná hodnota udává uloženou dobu v milisekundách. Nenastavená hodnota není vypočtená doba přehrávání: Aspose.Slides používá typ přechodu a [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) k určení této doby. Nastavení typu přechodu může inicializovat dobu, proto nejprve zkontrolujte původní nastavení.

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

Morph přechod animuje změny mezi objekty na po sobě jdoucích snímcích. Pro vytvoření jednoduchého efektu Morph klonujte snímek, posuňte nebo změňte velikost objektu na klonu a použijte přechod Morph na druhý snímek. Tím se vytvoří animace mezi původní a upravenou verzí objektu.

Následující příklad vytvoří snímek s obdélníkem obsahujícím text, klonuje snímek a změní pozici a velikost obdélníku na klonu. Poté pro druhý snímek vybere Morph z výčtu [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/). Otevřete uložený soubor v prohlížeči prezentací, který podporuje Morph, a podívejte se na efekt během prezentace.

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

## **Typy Morph přechodů**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) určuje, jak Morph přiřazuje a animuje obsah:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) zachází s každým tvarem jako s celým objektem.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animuje text porovnáním slov, kde je to možné.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) animuje text porovnáním znaků, kde je to možné.

Nejprve nastavte [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) přechodu na Morph, pak přistupte k [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). Hodnota pak poskytne rozhraní [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/), jehož vlastnost [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) vybírá režim přiřazování.

Tento příklad otevře prezentaci vytvořenou v předchozí kapitole a nakonfiguruje druhý snímek tak, aby používal animaci Morph založenou na slovech.

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
[![Morph matching units shown as a whole shape, individual words, and individual characters.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph může přiřadit celé tvary, slova nebo znaky, kde je to možné. Tyto rámečky identifikují přiřazovací jednotky místo pozorovaného pohybu. Příklad volí ByWord na druhém snímku.*
<!-- visual-explanation:slide-transition:end -->

## **Nastavení efektů přechodu**

Některé přechody odhalují další možnosti, například směr nebo zda efekt začíná z černé obrazovky. Dostupné možnosti závisí na zvoleném [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/). Nejprve nastavte typ a poté použijte odpovídající rozhraní z [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

Následující příklad použije přechod Cut na první snímek `input.pptx`. Nastaví [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) přes rozhraní [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/), aby přechod začínal z černé obrazovky.

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

Ano. Upřednostněte [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/), když potřebujete přesnou dobu trvání v milisekundách. Použijte [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/), když stačí předdefinovaná kategorie [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) — Slow, Medium nebo Fast — a není nastavena explicitní doba. Tato nastavení řídí efekt přechodu nezávisle na prodlevě automatického posouvání.

**Mohu k přechodu přiřadit zvuk a nechat jej smyčkovat?**

Ano. Přiřaďte vložený zvuk k [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), nastavte [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) na StartSound z výčtu [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/), a povolte [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). Zvuk se bude opakovat, dokud nenastane další zvuková událost v prezentaci.

**Jaký je nejrychlejší způsob, jak nastavit stejný přechod na všechny snímky?**

Projděte kolekci [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) v prezentaci a pro každý snímek nastavte přechod [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) na stejnou hodnotu. V téže smyčce nastavte také časování a volby efektu, aby chování bylo konzistentní napříč snímky.

**Jak zjistit, který přechod je aktuálně nastavený na snímku?**

Přečtěte si vlastnost [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) z [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) snímku. Vrátí hodnotu z výčtu [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/); None označuje, že není aplikován žádný efekt přechodu.