---
title: Alakzatanimációk alkalmazása prezentációkban .NET-ben
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/net/shape-animation/
keywords:
- alakzat
- animáció
- hatás
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- hatás hozzáadása
- hatás lekérése
- hatás kinyerése
- hatás hang
- animáció alkalmazása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet hozzáadni, ellenőrizni és testreszabni az alakzatanimációkat, az időzítést, a hangokat, az animáció utáni viselkedést és az animált szöveget az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az effektuson belüli egyedi viselkedések kezeléséhez vagy a mozgásút szegmensek szerkesztéséhez lásd a [Egyéni animáció](/slides/hu/net/custom-animation/) oldalt.

Az Aspose.Slides for .NET a diaanimációkat effektusokként ábrázolja a dia idővonalán. Egy effektusnak van célobjektuma, animációtípusa és al-típusa, triggerje, időzítési beállításai, valamint opcionális tulajdonságai, például hang vagy az animáció utáni viselkedés.

Az idővonal kétféle szekvenciát tartalmaz:

- A **fő sorozat** lejátszódik a dia előrehaladtával.
- Egy **interaktív sorozat** akkor indul, amikor a trigger objektumra kattintanak.

Mivel a szövegdobozok, képek, diagramok, táblázatok és egyéb diaobjektumok a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészt valósítják meg, a legtöbb diaelemmel ugyanazt a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) metódust használja. Az elérhető effektusok a [EffectType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttype/) felsorolásban találhatók.

## **Alakzatanimációk hozzáadása**

Animáció hozzáadásához szerezze meg a dia fő sorozatát, és hívja meg a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) metódust a célobjektummal, az effektustípussal, al-típussal és triggerrel. Olyan effektus esetén, amely egy másik objektumra kattintás után indul, hozza létre az interaktív sorozatot, amelynek triggerje ez a másik objektum.

Az alábbi példa létrehozza mindkét animációtípust, és elmenti az eredményt a `shape-animations.pptx` fájlba.

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

A trigger határozza meg, mikor indul egy effektus:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttriggertype/) a fő sorozatban kattintásra, vagy az interaktív sorozatban a trigger objektumra vár.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttriggertype/) az előző effektussal együtt indul.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/effecttriggertype/) az előző effektus befejezése után kezdődik.

Kép, diagram vagy más objektum animálásához adja át azt az objektumot a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) hívásnak a `targetShape` helyett. Diagram-specifikus csoportosítási lehetőségekért lásd az [Animált diagramok](/slides/hu/net/animated-charts/) oldalt.

## **Alakzatanimációk beolvasása**

Használja a [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/geteffectsbyshape/) metódust, ha ismeri a célobjektumot. Minden effektus megtekintéséhez iterálja végig a fő sorozatot és az összes interaktív sorozatot. Az iteráció elkerüli, hogy azt feltételezze, egy sorozat index `0`‑án mindig van effektus.

Az alábbi példa egy olyan alakzatot hoz létre, amelynek fő‑ és interaktív effektusai vannak, lekéri a alakzatot célozó effektusokat, majd végigiterál minden sorozaton a dián.

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

Ha csak egy alakzathoz szükségesek az effektusok, előbb azonosítsa az alakzatot név, placeholder‑típus vagy más stabil tulajdonság alapján; ezután hívja meg a [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/geteffectsbyshape/) metódust. Ne tételezze azt, hogy a [IShapeCollection.Item](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/item/) index `0`‑án mindig a kívánt objektum található.

## **Örökölt placeholder‑effektusok kezelése**

Egy normál dián lévő placeholder örökölheti az animációs viselkedést a megfelelő layout‑dián és master‑dián lévő placeholder‑től. A [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getbaseplaceholder/) visszaadja ezt a szülő‑placeholdert, vagy `null`‑t, ha nincs szülő.

Az alábbi példaprezentációban a láblécnek **Random Bars** effektusa van a normál dián, **Split** a layout‑dián és **Fly In** a master‑dián.

![Lábléc animációs effektus a normál dián](slide-shape-animation.png)

![Lábléc placeholder animációs effektus a layout-dián](layout-shape-animation.png)

![Lábléc placeholder animációs effektus a master-dián](master-shape-animation.png)

A következő példa felépíti magát a placeholder‑hierarchiát. Effektusokat ad egy master placeholderhez, egy layout placeholderhez és a megfelelő placeholderhez egy normál dián. Minden [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/getbaseplaceholder/) hívás előtt ellenőrzés történik, mielőtt a visszakapott objektumot felhasználná.

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

A PowerPoint **Timing** párbeszédablaka a [ITiming](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/) tulajdonságaira képezhető le.

![PowerPoint időzítési párbeszédablak egy animációs effektushoz](shape-animation.png)

- **Start** a [ITiming.TriggerType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/triggertype/) értékére vonatkozik.
- **Duration** a [ITiming.Duration](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/duration/) másodpercekben megadott értéke.
- **Delay** a [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/triggerdelaytime/) másodpercekben megadott értéke.
- **Repeat** a [ITiming.RepeatCount](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatcount/), a [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilnextclick/) vagy a [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilendslide/) értékére vonatkozik.
- **Rewind when done playing** a [ITiming.Rewind](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/rewind/) beállítását jelenti.

Ez a független példa hozzáad egy effektust, módosítja az időzítését a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) által visszaadott objektumon keresztül, és elmenti az eredményt. A visszakapott [IEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/) referencia megőrzése elkerüli a felesleges gyűjtemény‑index használatát.

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

Használjon egy ismétlési módot tudatosan. Az ismétlésszám és egy „until” (eddig) jelző kombinálása zavaró eredményeket okozhat különböző lejátszókban. Amikor ismétlési módot vált, előbb állítsa be a [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilnextclick/) és a [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatuntilendslide/) értékét, majd a [ITiming.RepeatCount](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itiming/repeatcount/)-t, mivel bármely jelző beállítása megváltoztatja az aktív ismétlési módot.

## **Animációs hangok hozzáadása és kinyerése**

Egy animációs effektus hivatkozhat beágyazott audióra az [IEffect.Sound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/sound/) segítségével. Az [IEffect.StopPreviousSound](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/stopprevioussound/) megmondja az effektusnak, hogy állítsa le a korábban egy másik effektus által elindított hangot.

### **Hang hozzáadása egy effektushoz**

Az alábbi példa egy helyi `animation-sound.wav` nevű audiofájlt igényel. Két effektust hoz létre, az elsőhöz beágyazza a fájlt hangként, a másodikat pedig úgy konfigurálja, hogy leállítsa a hangot. A [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) által visszaadott objektumokat használja, így nincs szükség sorozat‑indexre.

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

### **Beágyazott effektus‑hangok kinyerése**

Az alábbi példa egy helyi `presentation-with-animation-sounds.pptx` nevű prezentációt vár. Bejárja a fő‑ és interaktív sorozatokat, és minden beágyazott effektus‑hangot a `extracted-animation-sounds` könyvtárba ír ki. A kiterjesztés a [IAudio.ContentType](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudio/contenttype/) által visszaadott audio MIME‑típusból kerül kiválasztásra.

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

Nagy audioobjektumok esetén használja az [IAudio.GetStream](https://reference.aspose.com/slides/hu/net/aspose.slides/iaudio/getstream/) metódust, és másolja a streamet fájlba a teljes objektum byte‑tömbbe töltése helyett.

## **Az animáció utáni viselkedés beállítása**

A **After animation** opció határozza meg, mi történik egy alakzattal, miután az effektusa befejeződik.

![PowerPoint effektus beállítások párbeszédablak, After animation beállításaival](shape-after-animation.png)

Az [AfterAnimationType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/) felsorolás lehetővé teszi az alakzat változatlanul hagyását, a szín megváltoztatását, a rejtett állapotba helyezését az animáció után, vagy a következő kattintáskor való elrejtést. Ha a típus [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/), akkor állítsa be az [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/afteranimationcolor/) értékét is.

Ez a független példa egy effektust hoz létre, beállítja az animáció utáni viselkedését a visszaadott effektusobjektumon keresztül, és elmenti az eredményt.

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

Ha a típust a [AfterAnimationType.Color](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/afteranimationtype/)‑tól eltérőre változtatja, az animáció utáni színbeállítás törlődik.

## **Szöveg animálása**

A szöveganimációnak két kapcsolódó beállítása van:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/itextanimation/buildtype/) határozza meg, hogy a bekezdések egyszerre vagy bekezdésenként jelenjenek meg.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/animatetexttype/) szabályozza, hogy a szöveg egyszerre, szóként vagy betűként jelenjen meg. Az [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/ieffect/delaybetweentextparts/) a szavak vagy betűk közötti késleltetést állítja be. A pozitív érték a hatás időtartamának százalékában, a negatív érték másodpercben megadott késleltetés.

Az alábbi független példa a szövegdoboz szavait animálja. A [BuildType.AsOneObject](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/buildtype/) letiltja a bekezdésenkénti építést, így a szavakra vonatkozó beállítás az egész szövegkeretre érvényesül.

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

A szövegdoboz bekezdésenkénti építéséhez állítsa be a [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/buildtype/) (vagy másik bekezdés‑szint) értéket. Egyetlen bekezdés saját effektussal történő célzásához használja a [ISequence.AddEffect](https://reference.aspose.com/slides/hu/net/aspose.slides.animation/isequence/addeffect/) olyan overload‑ját, amely egy [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) objektumot fogad. Lásd az [Animált szöveg](/slides/hu/net/animated-text/) oldalt a bekezdés‑szintű példákért.

## **Exportálás és kompatibilitási megjegyzések**

- PPT vagy PPTX formátumba mentés megőrzi az animációs modellt, de a lejátszást a prezentáció‑megtekintő szabályozza.
- A PDF és a statikus képek nem játszanak le animációkat. Használjon [HTML5 export](/slides/hu/net/export-to-html5/), animált GIF‑et vagy [videókonverziót](/slides/hu/net/convert-powerpoint-to-video/) akkor, ha a kimenetnek mozgást kell mutatnia.
- HTML5‑höz engedélyezze a [Html5Options.AnimateShapes](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animateshapes/) beállítást, és szükség esetén a [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/hu/net/aspose.slides.export/html5options/animatetransitions/) opciót.
- A videó renderelés támogatja a legtöbb gyakori belépő, hangsúlyozó, kilépő és mozgásút‑effektust, de nem minden PowerPoint‑effektus van támogatva. Ellenőrizze az aktuális [támogatott animációkat és effektusokat](/slides/hu/net/convert-powerpoint-to-video/#supported-animations-and-effects), és tesztelje a kritikus prezentációkat a használt Aspose.Slides verzióval.
- Az előre elkészített egyéni effektusok és más formátumokból importált effektusok megmaradhatnak a fájlban, de a PowerPointban, HTML5‑ben vagy videóban másként jelenhetnek meg. Ellenőrizze az exportált eredményt, ne csak az effektus nevét vegye alapul.

## **GYIK**

**Miért jelenik meg egy animáció a PowerPointban, de nem a PDF‑ben?**

A PDF statikus formátum, ezért az animációk és diaátmenetek nem játszhatók le. Exportáljon HTML5‑be, animált GIF‑be vagy videóba, ha a mozgást meg kell őrizni.

**Miért játszódik le egy effektus másként a videóban?**

A videóexportálás az animációkat rendereli, ahelyett, hogy az eredeti PowerPoint‑viselkedést tárolná. Egyes fejlett effektusok nem támogatottak vagy csak közelítőleg jelennek meg. Tekintse meg a támogatott‑effektus táblázatot, és tesztelje a prezentációt a tényleges felhasználás előtt.

**Megváltoztatja-e egy alakzat előre‑ vagy hátratevése az animáció sorrendjét?**

Nem. Az alakzat z‑rendje csak a rétegezést szabályozza, míg a sorozatsorrend és a triggerek határozzák meg az animáció lejátszási sorrendjét. Ha más lejátszási sorrendre van szükség, módosítsa az idővonalat.