---
title: "Použití animací tvarů v prezentacích v .NET"
linktitle: "Animace tvaru"
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
- použít animaci
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat animace tvarů v prezentacích PowerPoint s Aspose.Slides pro .NET. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](/slides/cs/net/animated-charts/). Oživují prezentace nebo jejich součásti. 

## **Proč používat animace v prezentacích?**

Pomocí animací můžete 

* řídit tok informací
* zdůraznit důležité body
* zvýšit zájem nebo zapojení publika
* usnadnit čtení, vstřebání nebo zpracování obsahu
* přitáhnout pozornost čtenářů nebo diváků k důležitým částem v prezentaci

PowerPoint poskytuje mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **odchod**, **zdůraznění** a **cesty pohybu**. 

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy, které potřebujete pro práci s animacemi v rámci jmenného prostoru [Aspose.Slides.Animation](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/), 
* Aspose.Slides nabízí více než **150 animačních efektů** v rámci výčtu [EffectType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttype). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) jako ty používané v PowerPointu.

## **Použití animace na TextBoxu**

Aspose.Slides pro .NET vám umožňuje aplikovat animaci na text ve tvaru. 

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/) .
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape). 
4. Přidejte text do [IAutoShape.TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/properties/textframe).
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt k [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape).
7. Nastavte vlastnost [TextAnimation.BuildType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/textanimation/properties/buildtype) na hodnotu z výčtu [BuildType Enumeration](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/buildtype).
8. Uložte prezentaci na disk jako soubor PPTX.

Tento C# kód ukazuje, jak aplikovat efekt `Fade` na AutoShape a nastavit animaci textu na hodnotu *By 1st Level Paragraphs*:

```c#
// Instancuje třídu prezentace, která představuje soubor prezentace.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Přidá nový AutoShape s textem
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Získá hlavní sekvenci snímku.
    ISequence sequence = sld.Timeline.MainSequence;

    // Přidá efekt animace Fade do tvaru
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animuje text tvaru podle odstavců první úrovně
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Uloží soubor PPTX na disk
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Kromě aplikace animací na text můžete také aplikovat animace na jednotlivý [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph). Viz [**Animated Text**](/slides/cs/net/animated-text/).

{{% /alert %}} 

## **Použití animace na PictureFrame**

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/) .
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe) na snímku. 
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt k [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe).
8. Uložte prezentaci na disk jako soubor PPTX.

Tento C# kód ukazuje, jak aplikovat efekt `Fly` na rámeček obrázku:

```c#
// Instancuje třídu prezentace, která představuje soubor prezentace.
using (Presentation pres = new Presentation())
{
    // Načte obrázek, který bude přidán do kolekce obrázků prezentace
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Přidá rámeček s obrázkem do snímku
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Přidá animační efekt Fly zleva do rámečku obrázku
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Uloží soubor PPTX na disk
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Použití animace na tvar**

1. Vytvořte instanci třídy [Presentation](http://www.aspose.com/api/net/slides/cs/aspose.slides/) .
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape). 
4. Přidejte `Bevel` [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape) (při kliknutí na tento objekt se spuští animace).
5. Vytvořte sekvenci efektů na tvaru bevel.
6. Vytvořte vlastní `UserPath`.
7. Přidejte příkazy pro pohyb k `UserPath`.
8. Uložte prezentaci na disk jako soubor PPTX.

Tento C# kód ukazuje, jak aplikovat efekt `PathFootball` (cesta football) na tvar:

```c#
// Instancuje třídu Presentation, která představuje soubor prezentace.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Vytvoří efekt PathFootball pro existující tvar od začátku.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Přidá animační efekt PathFootball.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Vytvoří něco jako "tlačítko".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Vytvoří sekvenci efektů pro tlačítko.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Vytvoří vlastní uživatelskou cestu. Náš objekt se bude pohybovat až po kliknutí na tlačítko.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Přidá příkazy pro pohyb, protože vytvořená cesta je prázdná.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Zapíše soubor PPTX na disk
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Získání animačních efektů aplikovaných na tvar**

Následující příklady ukazují, jak použít metodu `GetEffectsByShape` z rozhraní [ISequence](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/) k získání všech animačních efektů aplikovaných na tvar.

**Příklad 1: Získání animačních efektů aplikovaných na tvar na normálním snímku**

V předchozím kapitole jste se naučili, jak přidávat animační efekty do tvarů v prezentacích PowerPoint. Následující ukázkový kód vám ukazuje, jak získat efekty aplikované na první tvar na první normálním snímku v prezentaci `AnimExample_out.pptx`.

```c#
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

**Příklad 2: Získání všech animačních efektů, včetně těch zděděných z placeholderů**

Pokud má tvar na normálním snímku placeholdery, které jsou na rozložení snímku a/nebo hlavním snímku, a na tyto placeholdery byly přidány animační efekty, pak budou během prezentace přehrány všechny efekty tvaru, včetně těch zděděných z placeholderů.

Mějme PowerPoint soubor `sample.pptx` s jedním snímkem, který obsahuje pouze tvar zápatí s textem „Made with Aspose.Slides“ a na tento tvar je aplikován efekt **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Předpokládejme také, že efekt **Split** je aplikován na placeholder zápatí na **layout** snímku.

![Layout shape animation effect](layout-shape-animation.png)

A nakonec je na placeholder zápatí na **master** snímku aplikován efekt **Fly In**.

![Master shape animation effect](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `GetBasePlaceholder` z rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) k přístupu k placeholderům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch zděděných z placeholderů umístěných na layout a master snímcích.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získá animační efekty tvaru na normálním snímku.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Získá animační efekty placeholderu na rozložení snímku.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Získá animační efekty placeholderu na hlavním snímku.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
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

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/properties/timing) properties:
- Rozbalovací seznam **Start** v PowerPoint Timing odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/properties/triggertype). 
- PowerPoint Timing **Duration** odpovídá vlastnosti [Effect.Timing.Duration](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/properties/duration). Délka animace (v sekundách) je celkový čas potřebný k dokončení jednoho cyklu animace. 
- PowerPoint Timing **Delay** odpovídá vlastnosti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- PowerPoint Timing **Repeat** rozbalovací seznam odpovídá těmto vlastnostem: 
  * vlastnost [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatcount), která popisuje *počet* opakování efektu;
  * příznak [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilendslide), který určuje, zda se efekt opakuje až do konce snímku;
  * příznak [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilnextclick), který určuje, zda se efekt opakuje až do dalšího kliknutí.
- Zaškrtávací políčko **Rewind when done playing** v PowerPoint Timing odpovídá vlastnosti [Effect.Timing.Rewind](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/rewind/). 

Toto je postup, jak změnit časové vlastnosti efektu:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte nové hodnoty pro vlastnosti [Effect.Timing](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/properties/timing), které potřebujete. 
3. Uložte upravený soubor PPTX.

Tento C# kód demonstruje operaci:

```c#
// Instancuje třídu prezentace, která představuje soubor prezentace.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Získá první efekt hlavní sekvence.
    IEffect effect = sequence[0];

    // Změní TriggerType efektu na spuštění po kliknutí
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Změní délku trvání efektu
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

    // Zapne funkci Rewind efektu
        effect.Timing.Rewind = true;
    
    // Uloží soubor PPTX na disk
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Zvuk animačního efektu**

Aspose.Slides poskytuje tyto vlastnosti, které vám umožňují pracovat se zvuky v animačních efektech: 
- [IEffect.Sound](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Přidání zvuku animačního efektu**

Tento C# kód ukazuje, jak přidat zvuk animačního efektu a zastavit jej, když začne další efekt:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Přidá audio do kolekce audia prezentace
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Získá hlavní sekvenci snímku.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Získá první efekt hlavní sekvence
	IEffect firstEffect = sequence[0];

	// Kontroluje, zda efekt nemá zvuk
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Přidá zvuk k prvnímu efektu
		firstEffect.Sound = effectSound;
	}

	// Získá první interaktivní sekvenci snímku.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Nastaví příznak "Stop previous sound" efektu
	interactiveSequence[0].StopPreviousSound = true;

	// Zapíše soubor PPTX na disk
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extrahování zvuku animačního efektu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) .
2. Získejte referenci na snímek podle jeho indexu. 
3. Získejte hlavní sekvenci efektů. 
4. Extrahujte [Sound](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effect/sound/) vložený do každého animačního efektu. 

Tento C# kód ukazuje, jak extrahovat zvuk vložený v animačním efektu:

```c#
// Instancuje třídu prezentace, která představuje soubor prezentace.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získá hlavní sekvenci snímku.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrahuje zvuk efektu do pole bajtů
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Po animaci**

Aspose.Slides pro .NET vám umožňuje změnit vlastnost After animation animačního efektu.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Rozbalovací seznam **After animation** v PowerPoint odpovídá těmto vlastnostem: 

- vlastnost [IEffect.AfterAnimationType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/afteranimationtype/) popisuje typ After animation :
  * PowerPoint **More Colors** odpovídá typu [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Don't Dim** odpovídá typu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/) (výchozí typ after animation);
  * PowerPoint **Hide After Animation** odpovídá typu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/) ;
- vlastnost [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/afteranimationcolor/) definuje formát barvy po animaci. Tato vlastnost funguje ve spojení s typem [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/). Pokud typ změníte na jiný, barva po animaci bude vymazána.

Tento C# kód ukazuje, jak změnit efekt po animaci:

```c#
// Instancuje třídu prezentace, která představuje soubor prezentace
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Změní typ po animaci na Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Nastaví barvu po animaci
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Zapíše soubor PPTX na disk
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animovat text**

Aspose.Slides poskytuje tyto vlastnosti, které vám umožňují pracovat s blokem *Animate text* animačního efektu:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/animatetexttype/) popisuje typ animace textu efektu. Text ve tvaru lze animovat:
  - Vše najednou ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/animatetexttype/) typ)
  - Po slovech ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/animatetexttype/) typ)
  - Po znacích ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/animatetexttype/) typ)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/delaybetweentextparts/) nastavuje prodlevu mezi částmi animovaného textu (slovy nebo znaky). Kladná hodnota udává procento trvání efektu. Záporná hodnota udává prodlevu v sekundách.

Toto je způsob, jak můžete změnit vlastnosti Effect Animate text:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte vlastnost [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itextanimation/buildtype/) na hodnotu [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/buildtype/) pro vypnutí režimu animace *By Paragraphs*.
3. Nastavte nové hodnoty pro vlastnosti [IEffect.AnimateTextType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/animatetexttype/) a [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Uložte upravený soubor PPTX.

Tento C# kód demonstruje operaci:

```c#
// Instancuje třídu prezentace, která představuje soubor prezentace.
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

    // Zapíše soubor PPTX na disk
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **Časté dotazy**

**Jak mohu zajistit, aby animace byly zachovány při publikování prezentace na web?**

[Export to HTML5](/slides/cs/net/export-to-html5/) a povolte [options](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/) zodpovědné za animace [shape](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animateshapes/) a [transition](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animatetransitions/). Běžné HTML nepřehrává animace snímků, zatímco HTML5 ano.

**Jak změna z‑order (pořadí vrstev) tvarů ovlivňuje animaci?**

Animace a pořadí kreslení jsou nezávislé: efekt řídí načasování a typ zobrazování/skrývání, zatímco [z-order](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/zorderposition/) určuje, co co překrývá. Viditelný výsledek je definován jejich kombinací. (Jedná se o obecné chování PowerPointu; model efektů a tvarů Aspose.Slides následuje stejnou logiku.)

**Existují omezení při konverzi animací na video pro některé efekty?**

Obecně jsou [animace podporovány](/slides/cs/net/convert-powerpoint-to-video/), ale v ojedinělých případech nebo pro konkrétní efekty může být výstup odlišný. Doporučujeme testovat s efekty, které používáte, a s verzí knihovny.