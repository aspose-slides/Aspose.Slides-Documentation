---
title: Použití animací tvarů v prezentacích v .NET
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
description: "Naučte se, jak přidávat, kontrolovat a přizpůsobovat animace tvarů, časování, zvuky, chování po animaci a animovaný text pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Pro práci s jednotlivými chováními uvnitř efektu nebo úpravu segmentů dráhy pohybu, viz [Custom Animation](/slides/cs/net/custom-animation/).

Aspose.Slides for .NET představuje animace snímků jako efekty v časové ose snímku. Efekt má cílový tvar, typ a podtyp animace, spouštěč, nastavení časování a volitelné vlastnosti, jako je zvuk nebo chování po animaci.

Časová osa obsahuje dva typy sekvencí:

- **Hlavní sekvence** se přehrává při postupu snímku.
- **Interaktivní sekvence** začíná, když je kliknuto na její spouštěcí tvar.

Protože textová pole, obrázky, grafy, tabulky a další objekty snímků implementují [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/), používáte stejnou metodu [ISequence.AddEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/addeffect/) pro většinu obsahu snímku. Dostupné efekty jsou uvedeny v výčtu [EffectType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttype/).

## **Přidání animací tvarů**

Chcete-li přidat animaci, získejte hlavní sekvenci snímku a zavolejte [ISequence.AddEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/addeffect/) s cílovým tvarem, typem efektu, podtypem a spouštěčem. Pro efekt, který začíná po kliknutí na jiný tvar, vytvořte interaktivní sekvenci, jejíž spouštěčem je tento jiný tvar.

Následující příklad vytvoří oba typy animací a uloží výsledek do `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

Spouštěč určuje, kdy efekt začne:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttriggertype/) čeká na kliknutí v hlavní sekvenci nebo na kliknutí na spouštěcí tvar v interaktivní sekvenci.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttriggertype/) začíná současně s předchozím efektem.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/effecttriggertype/) začíná po dokončení předchozího efektu.

Chcete-li animovat obrázek, graf nebo jiný typ tvaru, předávejte tento objekt metodě [ISequence.AddEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/addeffect/) místo `targetShape`. Pro specifické možnosti seskupování grafu viz [Animated Charts](/slides/cs/net/animated-charts/).

## **Čtení animací tvarů**

Použijte [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/geteffectsbyshape/) pokud znáte cílový tvar. Pro prohlédnutí každého efektu enumerujte hlavní sekvenci a každou interaktivní sekvenci. Enumerace zabraňuje předpokladu, že sekvence obsahuje efekt na indexu `0`.

Následující příklad vytvoří tvar s hlavními a interaktivními efekty, získá efekty, které cílí na tento tvar, a poté enumeruje každou sekvenci na snímku.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Pokud potřebujete efekty jen pro jeden tvar, nejprve identifikujte tvar podle názvu, typu placeholderu nebo jiné stabilní vlastnosti; poté zavolejte [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/geteffectsbyshape/). Nepředpokládejte, že [IShapeCollection.Item](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/item/) na indexu `0` je vždy požadovaný objekt.

## **Práce s děděnými efekty placeholderů**

Placeholder na běžném snímku může dědit chování animace z odpovídajícího placeholderu na snímku rozvržení a hlavním snímku. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/getbaseplaceholder/) vrací tento nadřazený placeholder nebo `null`, pokud neexistuje žádný nadřazený.

V následujícím příkladovém prezentaci má zápatí **Random Bars** na běžném snímku, **Split** na snímku rozvržení a **Fly In** na hlavním snímku.

![Animace patičky na běžném snímku](slide-shape-animation.png)

![Animace placeholderu patičky na snímku rozvržení](layout-shape-animation.png)

![Animace placeholderu patičky na hlavním snímku](master-shape-animation.png)

Následující příklad samotně vytvoří hierarchii placeholderů. Přidá efekty k hlavnímu placeholderu, placeholderu rozvržení a odpovídajícímu placeholderu na běžném snímku. Každé volání [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/getbaseplaceholder/) je zkontrolováno, než je vrácený tvar použit.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Změna časování animace**

Dialog PowerPoint **Timing** (Časování) mapuje na vlastnosti [ITiming](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/).

![Dialog PowerPoint Časování pro animační efekt](shape-animation.png)

- **Start** mapuje na [ITiming.TriggerType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** (Délka) mapuje na [ITiming.Duration](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/duration/), v sekundách.
- **Delay** (Zpoždění) mapuje na [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/triggerdelaytime/), v sekundách.
- **Repeat** (Opakování) mapuje na [ITiming.RepeatCount](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilnextclick/), nebo [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** (Přetočit po přehrání) mapuje na [ITiming.Rewind](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/rewind/).

Tento samostatný příklad přidá efekt, změní jeho časování prostřednictvím objektu vráceného metodou [ISequence.AddEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/addeffect/), a uloží výsledek. Udržení vrácené reference na [IEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/) zabraňuje zbytečnému indexu kolekce.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Používejte záměrně jeden režim opakování. Kombinace počtu opakování s příznakem "until" může vést k matoucím výsledkům v různých prohlížečích. Při změně režimů opakování nastavte [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilnextclick/) a [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatuntilendslide/) před [ITiming.RepeatCount](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itiming/repeatcount/), protože nastavení kterékoli z těchto příznaků také mění aktivní režim opakování.

## **Přidání a extrahování zvuků animací**

Animační efekt může odkazovat na vložený zvuk pomocí [IEffect.Sound](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/stopprevioussound/) říká efektu, aby zastavil zvuk zahájený předchozím efektem.

### **Přidání zvuku k efektu**

Následující příklad očekává místní audio soubor pojmenovaný `animation-sound.wav`. Vytvoří dva efekty, vloží tento soubor jako zvuk pro první efekt a nastaví druhý efekt tak, aby zvuk zastavil. Používá objekty vrácené metodou [ISequence.AddEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/addeffect/), takže není vyžadován index sekvence.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Extrahování vložených zvuků efektů**

Následující příklad očekává místní prezentaci pojmenovanou `presentation-with-animation-sounds.pptx`. Prohledá hlavní i interaktivní sekvence a zapíše každý vložený zvuk efektu do adresáře `extracted-animation-sounds`. Přípona je vybrána z audio MIME typu poskytovaného [IAudio.ContentType](https://reference.aspose.com/slides/cs/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Pro velké audio objekty použijte [IAudio.GetStream](https://reference.aspose.com/slides/cs/net/aspose.slides/iaudio/getstream/) a zkopírujte stream do souboru místo načtení celého objektu do bajtového pole.

## **Nastavení chování po animaci**

Volba **After animation** (Po animaci) určuje, co se stane s tvarem po dokončení jeho efektu.

![Dialog PowerPoint Možnosti efektu zobrazující nastavení Po animaci](shape-after-animation.png)

Výčet [AfterAnimationType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/) podporuje ponechání tvaru nezměněného, změnu jeho barvy, skrytí po animaci nebo skrytí při dalším kliknutí. Když je typ [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/), nastavte také [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Tento samostatný příklad vytvoří efekt, nastaví jeho chování po animaci prostřednictvím vráceného objektu efektu a uloží výsledek.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Změna typu od [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/afteranimationtype/) vymaže nastavení barvy po animaci.

## **Animovat text**

Animace textu má dva související ovladače:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/itextanimation/buildtype/) určuje, zda se odstavce zobrazí společně nebo po úrovních odstavců.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/animatetexttype/) určuje, zda se text zobrazí najednou, po slovech nebo po znacích. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/ieffect/delaybetweentextparts/) nastavuje prodlevu mezi slovy nebo znaky. Kladná hodnota je procento trvání efektu; záporná hodnota představuje prodlevu v sekundách.

Následující samostatný příklad animuje slova v textovém poli. [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/buildtype/) zakáže postupné budování odstavců, takže nastavení slov se použije na celý textový rámec.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Pro stavbu textového pole po odstavcích nastavte [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/buildtype/) (nebo jinou úroveň odstavce). Pro cílení na jediný odstavec s vlastním efektem použijte přetížení [ISequence.AddEffect](https://reference.aspose.com/slides/cs/net/aspose.slides.animation/isequence/addeffect/), které přijímá [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/). Podívejte se na [Animated Text](/slides/cs/net/animated-text/) pro příklady na úrovni odstavců.

## **Export a poznámky o kompatibilitě**

- Uložení do PPT nebo PPTX zachovává model animace, ale finální přehrávání je řízeno prohlížečem prezentace.
- PDF a statické obrázky neukazují animace. Použijte [HTML5 export](/slides/cs/net/export-to-html5/), animovaný GIF nebo [video conversion](/slides/cs/net/convert-powerpoint-to-video/), když výstup musí zobrazovat pohyb.
- Pro HTML5 povolte [Html5Options.AnimateShapes](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animateshapes/) a v případě potřeby [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/cs/net/aspose.slides.export/html5options/animatetransitions/).
- Rendering videa podporuje mnoho běžných vstupních, zdůrazňujících, ukončovacích a pohybových efektů, ale ne každý PowerPoint efekt je podporován. Zkontrolujte aktuální [supported animations and effects](/slides/cs/net/convert-powerpoint-to-video/#supported-animations-and-effects) a otestujte kritické prezentace s vaší cílovou verzí Aspose.Slides.
- Pokročilé vlastní efekty a efekty importované z jiných formátů prezentací mohou být v souboru zachovány, ale vykreslí se odlišně v PowerPointu, HTML5 nebo videu. Ověřte exportovaný výsledek místo spoléhání se jen na název efektu.

## **Často kladené otázky**

**Proč se animace zobrazí v PowerPointu, ale ne v PDF?**

PDF je statický formát, takže animace a přechody snímků se nepřehrávají. Exportujte do HTML5, animovaného GIFu nebo videa, pokud je nutný pohyb.

**Proč se efekt přehrává jinak ve videu?**

Export videa vykresluje animace místo ukládání původního chování PowerPointu. Některé pokročilé efekty nejsou podporovány nebo jsou zjednodušeny. Prohlédněte si tabulku podporovaných efektů a otestujte skutečnou prezentaci před použitím ve výrobě.

**Mění posun tvaru dopředu nebo dozadu jeho pořadí animace?**

Ne. Z‑order tvaru řídí překrývání, zatímco pořadí sekvencí a spouštěče řídí přehrávání animace. Změňte časovou osu, pokud potřebujete jiné pořadí přehrávání.