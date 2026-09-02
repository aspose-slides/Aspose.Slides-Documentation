---
title: Alakzatanimációk alkalmazása prezentációkban .NET-ben
linktitle: Alakzatanimáció
type: docs
weight: 60
url: /hu/net/shape-animation/
keywords:
- alakzat
- animáció
- effektus
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- effektus hozzáadása
- effektus lekérése
- effektus kinyerése
- effektus hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, vizsgálhat meg és testre szabhat alakzatanimációkat, időzítést, hangokat, az animáció utáni viselkedést és animált szöveget az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Aspose.Slides for .NET a diaanimációkat effektusokként a dia idővonalában ábrázolja. Egy effektusnak van célalakja, animációtípusa és altípusa, egy aktiválója, időzítési beállításai, valamint opcionális tulajdonságai, például hang vagy az animáció utáni viselkedés.

Az idővonal kétféle szekvenciát tartalmaz:

- A **fő szekvencia** akkor játszódik le, amikor a dia előrehalad.
- Egy **interaktív szekvencia** akkor indul, amikor a hozzá tartozó aktiváló alakra kattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészt valósítják meg, a legtöbb diaelemhez ugyanazt a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) metódust használhatja. Az elérhető effektusok a [EffectType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttype/) felsorolásban vannak felsorolva.

## **Alakzatok animálásának hozzáadása**

Animáció hozzáadásához kérje le a dia fő szekvenciáját, és hívja meg a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) metódust a célalak, az effektustípus, altípus és az aktiváló megadásával. Egy olyan effektus esetén, amely egy másik alakra kattintáskor indul, hozzon létre egy interaktív szekvenciát, amelynek aktiválója az a másik alak.

A következő példa mindkét típusú animációt létrehozza, és az eredményt a `shape-animations.pptx` fájlba menti.

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

Az aktiváló határozza meg, mikor kezdődik egy effektus:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttriggertype/) a fő szekvenciában kattintásra, vagy egy interaktív szekvenciában a aktiváló alakra kattintásra vár.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttriggertype/) az előző effektussal együtt indul.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttriggertype/) az előző effektus befejeződésével kezdődik.

Kép, diagram vagy más alakzat animálásához adja át azt az objektumot a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) metódusnak a `targetShape` helyett. Diagramra vonatkozó csoportosítási beállításokért tekintse meg a [Animated Charts](/slides/hu/net/animated-charts/) részt.

## **Alakzatok animációinak beolvasása**

Használja a [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/geteffectsbyshape/) metódust, ha ismeri a célalakot. Minden effektus megtekintéséhez sorolja fel a fő szekvenciát és minden interaktív szekvenciát. A felsorolás elkerüli annak feltételezését, hogy egy szekvencia a `0` indexen tartalmaz effektust.

A következő példa egy alakzatot hoz létre fő szekvenciás és interaktív effektusokkal, lekéri a alakzatot célzó effektusokat, majd felsorolja a dia minden szekvenciáját.

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

Ha csak egy alakzatra vonatkozó effektusokra van szüksége, először azonosítsa az alakzatot név, helykitöltő típus vagy más stabil tulajdonság alapján; ezután hívja meg a [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/geteffectsbyshape/) metódust. Ne tételezze, hogy a [IShapeCollection.Item](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/item/) a `0` indexen mindig a kívánt objektum.

## **Örökölt helykitöltő effektusok kezelése**

Egy normál dián lévő helykitöltő örökölheti az animációs viselkedést a hozzá tartozó helykitöltőtől a layout dián és a mester dián. A [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getbaseplaceholder/) visszaadja azt a szülőhelykitöltőt, vagy `null`-t, ha nincs szülő.

A következő példa prezentációban a láblécnek **Random Bars** animációja van a normál dián, **Split** a layout dián, és **Fly In** a mester dián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc helykitöltő animációs effektus a layout dián](layout-shape-animation.png)

![Lábléc helykitöltő animációs effektus a mester dián](master-shape-animation.png)

A következő példa maga építi fel a helykitöltő hierarchiát. Effektusokat ad egy mester helykitöltőhöz, egy layout helykitöltőhöz, és a megfelelő helykitöltőhöz a normál dián. Minden [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getbaseplaceholder/) hívást ellenőriznek, mielőtt a visszaadott alakzatot felhasználnák.

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

## **Animáció időzítésének módosítása**

A PowerPoint **Timing** párbeszédablaka az [ITiming](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/) tulajdonságaira vonatkozik.

![PowerPoint időzítési párbeszédablak egy animációs effektushoz](shape-animation.png)

- **Start** az [ITiming.TriggerType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/triggertype/) -ra térképeződik.
- **Duration** az [ITiming.Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/duration/) -ra térképeződik, másodpercben.
- **Delay** az [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/triggerdelaytime/) -ra térképeződik, másodpercben.
- **Repeat** az [ITiming.RepeatCount](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilnextclick/) vagy [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilendslide/) -ra térképeződik.
- **Rewind when done playing** az [ITiming.Rewind](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/rewind/) -ra térképeződik.

Ez a különálló példa egy effektust ad hozzá, annak időzítését módosítja a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) által visszaadott objektumon keresztül, és elmenti az eredményt. A visszaadott [IEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/) hivatkozás megtartása elkerüli a felesleges gyűjteményindex használatát.

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

Használjon egy ismétlési módot szándékosan. A ismétlési szám és egy „until” (addig) jelző kombinálása különböző lejátszókban zavaró eredményeket eredményezhet. Ismétlési módok módosításakor állítsa be előbb a [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilnextclick/) és a [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilendslide/) értékeket, majd a [ITiming.RepeatCount](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatcount/) -t, mivel bármely jelző beállítása módosítja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus beágyazott hangra hivatkozhat a [IEffect.Sound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/sound/) segítségével. A [IEffect.StopPreviousSound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/stopprevioussound/) azt mondja az effektusnak, hogy állítsa le a korábbi effektus által indított hangot.

### **Hang hozzáadása egy effektushoz**

A következő példa egy helyi `animation-sound.wav` nevű hangfájlt vár. Két effektust hoz létre, az első effektus hangjaként beágyazza ezt a fájlt, és a második effektust beállítja a hang leállítására. A [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) által visszaadott objektumokat használja, ezért nem szükséges szekvenciaindex.

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

### **Beágyazott effektus hangok kinyerése**

A következő példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. Átvizsgálja a fő és az interaktív szekvenciákat, és minden beágyazott effektushangot a `extracted-animation-sounds` könyvtárba ír. A kiterjesztést a [IAudio.ContentType](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudio/contenttype/) által biztosított hang MIME-típusból választja.

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

Nagy hangobjektumok esetén használja a [IAudio.GetStream](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudio/getstream/) metódust, és másolja a streamet fájlba ahelyett, hogy az egész objektumot egy byte tömbbe töltené be.

## **Az animáció utáni viselkedés beállítása**

Az **After animation** (Animáció után) beállítás szabályozza, mi történik egy alakzattal az effektus befejezése után.

![PowerPoint Effektus beállítások párbeszédablaka, amely az After animation beállításokat mutatja](shape-after-animation.png)

A [AfterAnimationType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/) felsorolás lehetővé teszi az alakzat változatlanul hagyását, színének módosítását, az animáció után elrejtését, vagy a következő kattintáskor történő elrejtését. Ha a típus a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/) érték, akkor a [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/afteranimationcolor/) is beállítható.

Ez a különálló példa egy effektust hoz létre, annak animáció utáni viselkedését a visszaadott effektusobjektumon keresztül állítja be, és elmenti az eredményt.

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

A [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/) típus megváltoztatása törli az animáció utáni színbeállítást.

## **Szöveg animálása**

A szöveganimációnak két kapcsolódó beállítása van:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itextanimation/buildtype/) szabályozza, hogy a bekezdések együtt vagy bekezdésenként jelenjenek meg.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/animatetexttype/) szabályozza, hogy a szöveg egyszerre, szó szerint vagy betű szerint jelenjen meg. A [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/delaybetweentextparts/) állítja be a szó vagy betű közötti késleltetést. A pozitív érték az effektus időtartamának százaléka; a negatív érték másodpercben megadott késleltetés.

A következő különálló példa a szövegdoboz szavait animálja. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/buildtype/) letiltja a bekezdésenkénti felépítést, így a szó beállítás az egész szövegkeretre vonatkozik.

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

Szövegdoboz bekezdésenkénti felépítéséhez állítsa be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/buildtype/) értéket (vagy más bekezdés szintet). Egy egyedi effektussal célozza meg egyetlen bekezdést a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) olyan túlterhelésével, amely elfogad egy [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumot. Tekintse meg az [Animated Text](/slides/hu/net/animated-text/) oldalt bekezdés szintű példákért.

## **Exportálási és kompatibilitási megjegyzések**

- A PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a végső lejátszást a prezentációs lejátszó szabályozza.
- A PDF és a statikus képek nem játszanak le animációkat. Használja a [HTML5 export](/slides/hu/net/export-to-html5/), animált GIF-et vagy a [video conversion](/slides/hu/net/convert-powerpoint-to-video/) lehetőséget, ha a kimenetnek mozgást kell mutatnia.
- HTML5-hez engedélyezze a [Html5Options.AnimateShapes](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animateshapes/) lehetőséget, és szükség esetén a [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animatetransitions/) beállítást.
- A videó renderelés sok gyakori belépő, hangsúlyozó, kilépő és mozgásút effektust támogat, de nem minden PowerPoint effektus érhető el. Ellenőrizze a jelenlegi [supported animations and effects](/slides/hu/net/convert-powerpoint-to-video/#supported-animations-and-effects) oldalt, és tesztelje a kritikus prezentációkat a cél Aspose.Slides verzióval.
- Az egyedi fejlett effektusok és más prezentációs formátumokból importált effektusok megmaradhatnak a fájlban, de másként jelenhetnek meg PowerPointban, HTML5-ben vagy videóban. Ellenőrizze az exportált eredményt, ne csak az effektus nevét vegye alapul.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF-ben?**

A PDF egy statikus formátum, ezért az animációk és diaváltások nem játszódnak le. Exportáljon HTML5-re, animált GIF-re vagy videóra, ha a mozgásnak meg kell maradnia.

**Miért játszódik le egy effektus másként egy videóban?**

A videó exportálás animációkat renderel, ahelyett, hogy az eredeti PowerPoint viselkedést tárolná. Néhány fejlett effektus nem támogatott vagy csak közelítően jelenik meg. Tekintse át a támogatott effektusok táblázatát, és tesztelje a tényleges prezentációt a gyártás előtt.

**Módosítja-e egy alakzat előre vagy hátra helyezése az animáció sorrendjét?**

Nem. Az alakzat Z-rendje csak a rétegezést szabályozza, míint a szekvencia sorrend és az aktiválók működtetik az animáció lejátszását. A lejátszási sorrend módosításához változtassa meg az idővonalat.