---
title: Aplikace animací tvarů v prezentacích v .NET
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/net/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat animace tvarů v prezentacích PowerPoint pomocí Aspose.Slides pro .NET. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [charts](/slides/cs/net/animated-charts/). Dodávají prezentacím nebo jejich částem život.

## **Proč používat animace v prezentacích?**

Používáním animací můžete

* ovládat průběh informací
* zdůraznit důležité body
* zvýšit zájem nebo zapojení publika
* usnadnit čtení, vstřebání nebo zpracování obsahu
* upoutat pozornost čtenářů nebo diváků na důležité části v prezentaci

PowerPoint poskytuje mnoho možností a nástrojů pro animace a animační efekty v kategoriích **entrance**, **exit**, **emphasis** a **motion paths**.

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy, které potřebujete pro práci s animacemi v prostoru názvů [Aspose.Slides.Animation](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/).
* Aspose.Slides poskytuje více než **150 animačních efektů** v výčtu [EffectType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttype). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) efektům používaným v PowerPointu.

## **Použití animace na TextBox**

Aspose.Slides pro .NET umožňuje aplikovat animaci na text ve tvaru.

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape).
4. Přidejte text do [IAutoShape.TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/properties/textframe).
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt k [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape).
7. Nastavte vlastnost [TextAnimation.BuildType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/textanimation/properties/buildtype) na hodnotu z [BuildType Enumeration](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/buildtype).
8. Uložte prezentaci na disk jako soubor PPTX.

Tento C# kód ukazuje, jak aplikovat efekt `Fade` na AutoShape a nastavit animaci textu na hodnotu *By 1st Level Paragraphs*:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Přidá nový AutoShape s textem
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Přidá tři odstavce, aby měl build podle odstavců něco, čím může procházet.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Získá hlavní sekvenci snímku.
    ISequence sequence = sld.Timeline.MainSequence;

    // Přidá efekt Fade animace ke tvaru
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animuje text tvaru podle odstavců první úrovně
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Uloží soubor PPTX na disk
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 
Kromě aplikování animací na text můžete také aplikovat animace na jediný [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph). Viz [**Animated Text**](/slides/cs/net/animated-text/).
{{% /alert %}} 

## **Použití animace na PictureFrame**

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe) na snímku. 
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt k [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe).
8. Uložte prezentaci na disk jako soubor PPTX.

Tento C# kód ukazuje, jak aplikovat efekt `Fly` na rámeček obrázku:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Vytváří instanci třídy prezentace, která představuje soubor prezentace.
using (Presentation pres = new Presentation())
{
    // Načte obrázek, který bude přidán do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Přidá rámeček obrázku na snímek
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Přidá efekt Fly zleva animace k rámečku obrázku
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Uloží soubor PPTX na disk
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Použití animace na tvar**

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape). 
4. Přidejte `Bevel` [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape) (když je tento objekt kliknut, animace se spustí).
5. Vytvořte sekvenci efektů na tvaru Bevel.
6. Vytvořte vlastní `UserPath`.
7. Přidejte příkazy pro pohyb na `UserPath`.
8. Uložte prezentaci na disk jako soubor PPTX.

Tento C# kód ukazuje, jak aplikovat efekt `PathFootball` (path football) na tvar:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Vytváří instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Vytvoří efekt PathFootball pro existující tvar od nuly.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Přidá animační efekt PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Vytvoří něco jako „tlačítko“.
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Vytvoří sekvenci efektů pro tlačítko.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Vytvoří vlastní uživatelskou cestu. Naše objekt bude přesunut až po kliknutí na tlačítko.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Přidá příkazy pro pohyb, protože vytvořená cesta je prázdná.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Uloží soubor PPTX na disk
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Získání animačních efektů aplikovaných na tvar**

Následující příklady ukazují, jak použít metodu `GetEffectsByShape` z rozhraní [ISequence](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/) k získání všech animačních efektů aplikovaných na tvar.

**Příklad 1: Získání animačních efektů aplikovaných na tvar na normálním snímku**

V minulosti jste se naučili, jak přidávat animační efekty do tvarů v prezentacích PowerPoint. Následující ukázkový kód ukazuje, jak získat efekty aplikované na první tvar na prvním normálním snímku v prezentaci `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Získá hlavní sekvenci animací snímku.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Získá první tvar na prvním snímku.
    IShape shape = firstSlide.Shapes[0];

    // Získá animační efekty aplikované na tvar.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Příklad 2: Získání všech animačních efektů, včetně těch zděděných ze zástupných objektů**

Pokud má tvar na normálním snímku zástupné objekty, které jsou umístěny na snímku rozložení a/nebo hlavním snímku, a byly k těmto zástupným objektům přidány animační efekty, pak budou během prezentace přehrány všechny efekty tvaru, včetně těch zděděných ze zástupných objektů.

Předpokládejme, že máme soubor prezentace PowerPoint `sample.pptx` s jedním snímkem obsahujícím pouze tvar patičky s textem „Made with Aspose.Slides“ a na tento tvar je aplikován efekt **Random Bars**.

![Animace tvaru snímku](slide-shape-animation.png)

Předpokládejme také, že na zástupný objekt patičky na **layout** snímku je aplikován efekt **Split**.

![Animace tvaru rozložení](layout-shape-animation.png)

A nakonec je na zástupný objekt patičky na **master** snímku aplikován efekt **Fly In**.

![Animace tvaru hlavního snímku](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `GetBasePlaceholder` z rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) k přístupu k zástupným objektům tvaru a získání animačních efektů aplikovaných na tvar patičky, včetně těch zděděných ze zástupných objektů umístěných na snímcích rozložení a hlavního snímku.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získá animační efekty tvaru na normálním snímku.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Získá animační efekty zástupného objektu na snímku rozložení.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Získá animační efekty zástupného objektu na hlavním snímku.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Změna časových vlastností animačního efektu**

Aspose.Slides pro .NET vám umožňuje měnit časové vlastnosti animačního efektu.

This is the Animation Timing pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Tyto jsou odpovídající položky mezi PowerPoint Timing a vlastnostmi [Effect.Timing](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/properties/timing):
- Rozbalovací seznam **Start** v PowerPoint Timing odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/properties/triggertype).
- PowerPoint Timing **Duration** odpovídá vlastnosti [Effect.Timing.Duration](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/properties/duration). Délka animace (v sekundách) je celkový čas, který animace potřebuje k dokončení jednoho cyklu.
- PowerPoint Timing **Delay** odpovídá vlastnosti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/properties/triggerdelaytime).
- PowerPoint Timing **Repeat** rozbalovací seznam odpovídá těmto vlastnostem:
  * vlastnost [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatcount), která popisuje *počet* opakování efektu;
  * příznak [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilendslide), který určuje, zda se efekt opakuje až do konce snímku;
  * příznak [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilnextclick), který určuje, zda se efekt opakuje až do dalšího kliknutí.
- Zaškrtávací políčko **Rewind when done playing** v PowerPoint Timing odpovídá vlastnosti [Effect.Timing.Rewind](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/rewind/).

Takto můžete změnit vlastnosti Effect Timing:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte nové hodnoty pro potřebné vlastnosti [Effect.Timing](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/properties/timing).
3. Uložte upravený soubor PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Získá první efekt hlavní sekvence.
    IEffect effect = sequence[0];

    // Změní TriggerType efektu na spuštění při kliknutí
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Změní dobu trvání efektu
    effect.Timing.Duration = 3f;

    // Změní TriggerDelayTime efektu
    effect.Timing.TriggerDelayTime = 0.5f;

    // Pokud je hodnota Repeat efektu "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Změní Repeat efektu na "Do dalšího kliknutí"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Změní Repeat efektu na "Do konce snímku"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Zapne Rewind efektu
        effect.Timing.Rewind = true;
    
    // Uloží soubor PPTX na disk
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Zvuk animačního efektu**

Aspose.Slides poskytuje následující vlastnosti, které vám umožní pracovat se zvuky v animačních efektech: 
- [IEffect.Sound](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Přidání zvuku animačního efektu**

Tento C# kód ukazuje, jak přidat zvuk animačního efektu a zastavit jej, když začne další efekt:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Přidá audio do kolekce audio v prezentaci
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Získá hlavní sekvenci snímku.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Získá první efekt hlavní sekvence
	IEffect firstEffect = sequence[0];

	// Zkontroluje, zda efekt nemá zvuk
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Přidá zvuk k prvnímu efektu
		firstEffect.Sound = effectSound;
	}

	// Získá první interaktivní sekvenci snímku.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Nastaví příznak efektu "Stop previous sound"
	interactiveSequence[0].StopPreviousSound = true;

	// Uloží soubor PPTX na disk
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extrahování zvuku animačního efektu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte hlavní sekvenci efektů. 
4. Extrahujte [Sound](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/sound/) vložený do každého animačního efektu. 

Tento C# kód ukazuje, jak extrahovat zvuk vložený do animačního efektu:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Vytváří instanci třídy prezentace, která představuje soubor prezentace.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získá hlavní sekvenci snímku.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrahuje zvuk efektu do pole bytů
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Po animaci**

Aspose.Slides pro .NET vám umožňuje změnit vlastnost After animation (po animaci) animačního efektu.

![example1_image](shape-after-animation.png)

Rozbalovací seznam **After animation** v PowerPointu odpovídá těmto vlastnostem: 

- vlastnost [IEffect.AfterAnimationType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/afteranimationtype/) popisuje typ po animaci:
  * PowerPoint **More Colors** odpovídá typu [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** odpovídá typu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/) (výchozí typ po animaci);
  * PowerPoint **Hide After Animation** odpovídá typu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/);
- vlastnost [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/afteranimationcolor/) definuje formát barvy po animaci. Tato vlastnost funguje ve spojení s typem [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/). Pokud typ změníte na jiný, barva po animaci bude vymazána.

Tento C# kód ukazuje, jak změnit efekt po animaci:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Změní typ po animaci na Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Nastaví barvu po animaci
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Uloží soubor PPTX na disk
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animovat text**

Aspose.Slides poskytuje následující vlastnosti, které vám umožní pracovat s blokem *Animate text* animačního efektu:

- vlastnost [IEffect.AnimateTextType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/animatetexttype/) popisuje typ animace textu efektu. Text tvaru může být animován:
  - Vše najednou ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/animatetexttype/) typ)
  - Po slově ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/animatetexttype/) typ)
  - Po písmenu ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/animatetexttype/) typ)
- vlastnost [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/delaybetweentextparts/) nastavuje prodlevu mezi animovanými částmi textu (slovy nebo písmeny). Kladná hodnota udává procento trvání efektu. Záporná hodnota určuje prodlevu v sekundách.

Takto můžete změnit vlastnosti Effect Animate text:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte vlastnost [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itextanimation/buildtype/) na hodnotu [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/buildtype/) pro vypnutí režimu animace *By Paragraphs*.
3. Nastavte nové hodnoty pro vlastnosti [IEffect.AnimateTextType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/animatetexttype/) a [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Uložte upravený soubor PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Změní typ textové animace efektu na "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Změní typ animace textu efektu na "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Nastaví prodlevu mezi slovy na 20% trvání efektu
    firstEffect.DelayBetweenTextParts = 20f;

    // Uloží soubor PPTX na disk
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

### Jak mohu zajistit, že animace jsou zachovány při publikaci prezentace na web?

Pro export do HTML5 použijte [Export to HTML5](/slides/cs/net/export-to-html5/) a povolte [options](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/) zodpovědné za animace [shape](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animateshapes/) a [transition](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animatetransitions/). Běžné HTML nepřehrává animace snímků, zatímco HTML5 ano.

### Jak změna z-order (pořadí vrstev) tvarů ovlivňuje animaci?

Animace a pořadí vykreslování jsou nezávislé: efekt řídí časování a typ objevování/zmizení, zatímco [z-order](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/zorderposition/) určuje, co překrývá co. Viditelný výsledek je dán jejich kombinací. (Toto je obecné chování PowerPointu; model efektů a tvarů Aspose.Slides následuje stejnou logiku.)

### Existují omezení při převodu animací na video pro určité efekty?

Obecně jsou [animace podporovány](/slides/cs/net/convert-powerpoint-to-video/), ale v ojedinělých případech nebo u specifických efektů může dojít k odlišnému zobrazení. Doporučujeme testovat s efekty, které používáte, a s verzí knihovny.