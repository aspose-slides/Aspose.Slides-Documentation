---
title: Formanimationen in Präsentationen in .NET anwenden
linktitle: Formanimation
type: docs
weight: 60
url: /de/net/shape-animation/
keywords:
- Form
- Animation
- Effekt
- animierte Form
- animierter Text
- Animation hinzufügen
- Animation abrufen
- Animation extrahieren
- Effekt hinzufügen
- Effekt abrufen
- Effekt extrahieren
- Effektton
- Animation anwenden
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formanimationen, Timing, Sounds, Nach-Animationsverhalten und animierten Text mit Aspose.Slides für .NET hinzufügen, prüfen und anpassen."
---
## **Übersicht**

Aspose.Slides für .NET stellt Folienanimationen als Effekte in einer Folientimeline dar. Ein Effekt besitzt eine Ziel‑Form, einen Animationstyp und Untertyp, einen Auslöser, Zeiteinstellungen und optionale Eigenschaften wie Sound oder das Verhalten nach der Animation.

Die Timeline enthält zwei Arten von Sequenzen:

- Die **Hauptsequenz** wird abgespielt, während die Folie fortschreitet.
- Eine **interaktive Sequenz** startet, wenn ihre Auslöser‑Form angeklickt wird.

Da Textfelder, Bilder, Diagramme, Tabellen und andere Folienobjekte das Interface [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/) implementieren, verwenden Sie für die meisten Folieninhalte dieselbe Methode [ISequence.AddEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/addeffect/). Die verfügbaren Effekte sind im Aufzählungstyp [EffectType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effecttype/) aufgelistet.

## **Form‑Animationen hinzufügen**

Um eine Animation hinzuzufügen, holen Sie die Hauptsequenz der Folie und rufen [ISequence.AddEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/addeffect/) mit der Ziel‑Form, dem Effekt­typ, Untertyp und Auslöser auf. Für einen Effekt, der startet, wenn eine andere Form angeklickt wird, erstellen Sie eine interaktive Sequenz, deren Auslöser diese andere Form ist.

Das folgende Beispiel erzeugt beide Animationsarten und speichert das Ergebnis in `shape-animations.pptx`.

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

Der Auslöser bestimmt, wann ein Effekt startet:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effecttriggertype/) wartet auf einen Klick in der Hauptsequenz bzw. auf einen Klick auf die Auslöser‑Form in einer interaktiven Sequenz.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effecttriggertype/) startet zusammen mit dem vorherigen Effekt.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/de/net/aspose.slides.animation/effecttriggertype/) startet, wenn der vorherige Effekt endet.

Um ein Bild, Diagramm oder einen anderen Formtyp zu animieren, übergeben Sie dieses Objekt an [ISequence.AddEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/addeffect/) anstelle von `targetShape`. Für diagrammspezifische Gruppierungsoptionen siehe [Animated Charts](/slides/de/net/animated-charts/).

## **Form‑Animationen auslesen**

Verwenden Sie [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/geteffectsbyshape/), wenn Sie die Ziel‑Form kennen. Um jeden Effekt zu untersuchen, enumerieren Sie die Hauptsequenz und jede interaktive Sequenz. Durch Enumeration vermeiden Sie die Annahme, dass eine Sequenz an Index `0` einen Effekt enthält.

Das folgende Beispiel erzeugt eine Form mit Haupt‑ und Interaktionseffekten, ruft die Effekte ab, die die Form ansprechen, und enumeriert anschließend jede Sequenz auf der Folie.

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

Falls Sie nur die Effekte für eine Form benötigen, identifizieren Sie die Form zunächst nach Name, Platzhaltertyp oder einer anderen stabilen Eigenschaft; rufen Sie dann [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/geteffectsbyshape/) auf. Gehen Sie nicht davon aus, dass [IShapeCollection.Item](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/item/) an Index `0` immer das beabsichtigte Objekt ist.

## **Mit geerbten Platzhalter‑Effekten arbeiten**

Ein Platzhalter auf einer normalen Folie kann das Animationsverhalten vom entsprechenden Platzhalter auf der Layout‑ und Master‑Folie erben. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/getbaseplaceholder/) gibt diesen übergeordneten Platzhalter zurück oder `null`, wenn kein übergeordneter Platzhalter existiert.

Im folgenden Beispiel‑Präsentation hat die Fußzeile **Random Bars** auf der normalen Folie, **Split** auf der Layout‑Folie und **Fly In** auf der Master‑Folie.

![Footer‑Animations‑Effekt auf der normalen Folie](slide-shape-animation.png)

![Footer‑Platzhalter‑Animations‑Effekt auf der Layout‑Folie](layout-shape-animation.png)

![Footer‑Platzhalter‑Animations‑Effekt auf der Master‑Folie](master-shape-animation.png)

Das nächste Beispiel baut die Platzhalter‑Hierarchie selbst auf. Es fügt Effekte zu einem Master‑Platzhalter, einem Layout‑Platzhalter und dem entsprechenden Platzhalter auf einer normalen Folie hinzu. Jeder Aufruf von [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/getbaseplaceholder/) wird geprüft, bevor die zurückgegebene Form verwendet wird.

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

## **Animations‑Zeitsteuerung ändern**

Der PowerPoint‑**Timing**‑Dialog entspricht den Eigenschaften von [ITiming](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/).

![PowerPoint‑Timing‑Dialog für einen Animations‑Effekt](shape-animation.png)

- **Start** entspricht [ITiming.TriggerType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** entspricht [ITiming.Duration](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/duration/), in Sekunden.
- **Delay** entspricht [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/triggerdelaytime/), in Sekunden.
- **Repeat** entspricht [ITiming.RepeatCount](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatuntilnextclick/) oder [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** entspricht [ITiming.Rewind](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/rewind/).

Dieses eigenständige Beispiel fügt einen Effekt hinzu, ändert dessen Zeitsteuerung über das von [ISequence.AddEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/addeffect/) zurückgegebene Objekt und speichert das Ergebnis. Das Beibehalten der zurückgegebenen [IEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/)‑Referenz verhindert einen unnötigen Listen‑Index‑Zugriff.

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

Verwenden Sie bewusst einen Wiederholungs‑Modus. Die Kombination eines Wiederholungszählers mit einem „until“‑Flag kann in verschiedenen Betrachtern zu verwirrenden Ergebnissen führen. Beim Ändern von Wiederholungs‑Modi setzen Sie zuerst [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatuntilnextclick/) und [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatuntilendslide/), bevor Sie [ITiming.RepeatCount](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itiming/repeatcount/) festlegen, da das Setzen eines Flags den aktiven Wiederholungs‑Modus ändert.

## **Animations‑Sounds hinzufügen und extrahieren**

Ein Animations‑Effekt kann über [IEffect.Sound](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/sound/) eingebetteten Audio‑Content referenzieren. [IEffect.StopPreviousSound](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/stopprevioussound/) weist einen Effekt an, den von einem früheren Effekt gestarteten Sound zu stoppen.

### **Einen Sound zu einem Effekt hinzufügen**

Das folgende Beispiel erwartet eine lokale Audiodatei namens `animation-sound.wav`. Es erzeugt zwei Effekte, bettet diese Datei als Sound für den ersten Effekt ein und konfiguriert den zweiten Effekt so, dass er den Sound stoppt. Es verwendet die von [ISequence.AddEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/addeffect/) zurückgegebenen Objekte, sodass kein Sequenz‑Index erforderlich ist.

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

### **Eingebettete Effekt‑Sounds extrahieren**

Das folgende Beispiel erwartet eine lokale Präsentation namens `presentation-with-animation-sounds.pptx`. Es durchsucht sowohl Haupt‑ als auch Interaktions‑Sequenzen und schreibt jeden eingebetteten Effekt‑Sound in das Verzeichnis `extracted-animation-sounds`. Die Dateierweiterung wird aus dem Audio‑MIME‑Typ ermittelt, den [IAudio.ContentType](https://reference.aspose.com/slides/de/net/aspose.slides/iaudio/contenttype/) liefert.

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

Für große Audio‑Objekte verwenden Sie [IAudio.GetStream](https://reference.aspose.com/slides/de/net/aspose.slides/iaudio/getstream/) und kopieren den Stream in eine Datei, anstatt das gesamte Objekt in ein Byte‑Array zu laden.

## **After‑Animation‑Verhalten festlegen**

Die Option **After animation** bestimmt, was mit einer Form geschieht, nachdem ihr Effekt beendet ist.

![PowerPoint‑Effekt‑Optionen‑Dialog mit After‑Animation‑Einstellungen](shape-after-animation.png)

Der Aufzählungstyp [AfterAnimationType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/afteranimationtype/) unterstützt das Belassen der Form unverändert, das Ändern ihrer Farbe, das Ausblenden nach der Animation oder das Ausblenden beim nächsten Klick. Ist der Typ [AfterAnimationType.Color](https://reference.aspose.com/slides/de/net/aspose.slides.animation/afteranimationtype/), setzen Sie zusätzlich [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Dieses eigenständige Beispiel erstellt einen Effekt, legt dessen After‑Animation‑Verhalten über das zurückgegebene Effekt‑Objekt fest und speichert das Ergebnis.

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

Wenn Sie den Typ von [AfterAnimationType.Color](https://reference.aspose.com/slides/de/net/aspose.slides.animation/afteranimationtype/) ändern, wird die Einstellung für die After‑Animation‑Farbe zurückgesetzt.

## **Text animieren**

Die Textanimation besitzt zwei zusammenhängende Steuerungen:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/itextanimation/buildtype/) bestimmt, ob Absätze gemeinsam oder zeilenweise erscheinen.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/animatetexttype/) bestimmt, ob Text auf einmal, wortweise oder buchstabenweise erscheint. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/de/net/aspose.slides.animation/ieffect/delaybetweentextparts/) legt die Verzögerung zwischen Worten oder Buchstaben fest. Ein positiver Wert ist ein Prozentsatz der Effekt‑Dauer; ein negativer Wert ist eine Verzögerung in Sekunden.

Das folgende unabhängige Beispiel animiert die Wörter in einem Textfeld. [BuildType.AsOneObject](https://reference.aspose.com/slides/de/net/aspose.slides.animation/buildtype/) deaktiviert das Aufbauen Absatz‑für‑Absatz, sodass die Wort‑Einstellung für das gesamte Textfeld gilt.

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

Um ein Textfeld Absatz für Absatz aufzubauen, setzen Sie [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/de/net/aspose.slides.animation/buildtype/) (oder einen anderen Absatz‑Level). Um einen einzelnen Absatz mit eigenem Effekt zu versehen, verwenden Sie die [ISequence.AddEffect](https://reference.aspose.com/slides/de/net/aspose.slides.animation/isequence/addeffect/)‑Überladung, die ein [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/) akzeptiert. Siehe [Animated Text](/slides/de/net/animated-text/) für Beispiele auf Absatz‑Ebene.

## **Export‑ und Kompatibilitäts‑Hinweise**

- Das Speichern im PPT‑ oder PPTX‑Format bewahrt das Animations‑Modell, aber die endgültige Wiedergabe wird vom Präsentations‑Viewer gesteuert.
- PDF und statische Bilder spielen keine Animationen ab. Verwenden Sie [HTML5‑Export](/slides/de/net/export-to-html5/), animierte GIFs oder die [Video‑Konvertierung](/slides/de/net/convert-powerpoint-to-video/), wenn die Ausgabe Bewegung zeigen muss.
- Für HTML5 aktivieren Sie [Html5Options.AnimateShapes](https://reference.aspose.com/slides/de/net/aspose.slides.export/html5options/animateshapes/) und bei Bedarf [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/de/net/aspose.slides.export/html5options/animatetransitions/).
- Die Video‑Renderung unterstützt viele gängige Eingangs‑, Betonungs‑, Ausgangs‑ und Bewegungs‑Pfad‑Effekte, jedoch nicht jeden PowerPoint‑Effekt. Prüfen Sie die aktuelle [unterstützte Animationen und Effekte](/slides/de/net/convert-powerpoint-to-video/#supported-animations-and-effects) und testen Sie kritische Präsentationen mit Ihrer Ziel‑Version von Aspose.Slides.
- Erweiterte benutzerdefinierte Effekte und aus anderen Präsentationsformaten importierte Effekte können in der Datei erhalten bleiben, werden jedoch in PowerPoint, HTML5 oder Video unterschiedlich gerendert. Validieren Sie das exportierte Ergebnis, anstatt sich ausschließlich auf den Effekt‑Namen zu verlassen.

## **FAQ**

**Warum wird eine Animation in PowerPoint angezeigt, aber nicht in einer PDF?**

PDF ist ein statisches Format, daher werden Animationen und Folienübergänge nicht abgespielt. Exportieren Sie zu HTML5, animiertem GIF oder Video, wenn Bewegung erhalten bleiben muss.

**Warum wird ein Effekt in einem Video anders abgespielt?**

Der Video‑Export rendert Animationen, anstatt das ursprüngliche PowerPoint‑Verhalten zu speichern. Einige erweiterte Effekte werden nicht unterstützt oder nur approximativ wiedergegeben. Prüfen Sie die Tabelle der unterstützten Effekte und testen Sie die eigentliche Präsentation vor dem produktiven Einsatz.

**Ändert das Vor‑ oder Zurückziehen einer Form ihre Animationsreihenfolge?**

Nein. Die Z‑Reihenfolge einer Form steuert die Überlappung, während die Sequenz‑Reihenfolge und die Auslöser die Animations‑Wiedergabe bestimmen. Ändern Sie die Timeline, wenn Sie eine andere Wiedergabereihenfolge benötigen.