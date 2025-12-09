---
title: PowerPoint-Präsentationen in .NET in Video konvertieren
linktitle: PowerPoint zu Video
type: docs
weight: 130
url: /de/net/convert-powerpoint-to-video/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu Video
- Präsentation zu Video
- PPT zu Video
- PPTX zu Video
- PowerPoint zu MP4
- Präsentation zu MP4
- PPT zu MP4
- PPTX zu MP4
- PPT als MP4 speichern
- PPTX als MP4 speichern
- PPT nach MP4 exportieren
- PPTX nach MP4 exportieren
- Video-Konvertierung
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Lernen Sie, wie Sie PowerPoint-Präsentationen in .NET in Video konvertieren. Entdecken Sie Beispiel-C#-Code und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---

## **Übersicht**

Durch die Konvertierung Ihrer PowerPoint- oder OpenDocument-Präsentation in ein Video erhalten Sie:

**Erhöhte Barrierefreiheit:** Alle Geräte, unabhängig vom Betriebssystem, verfügen standardmäßig über Videoplayer, was es Benutzern erleichtert, Videos zu öffnen oder abzuspielen, im Vergleich zu herkömmlichen Präsentationsanwendungen.

**Größere Reichweite:** Videos ermöglichen es Ihnen, ein größeres Publikum zu erreichen und Informationen ansprechender zu präsentieren. Umfragen und Statistiken zeigen, dass Menschen Video‑Inhalte lieber ansehen und konsumieren als andere Formen, wodurch Ihre Botschaft wirkungsvoller wird.

{{% alert color="primary" %}} 

Schauen Sie sich unseren [**PowerPoint‑zu‑Video‑Online‑Konverter**](https://products.aspose.app/slides/video) an, da er eine Live‑ und effektive Umsetzung des hier beschriebenen Prozesses bietet.

{{% /alert %}} 

In Aspose.Slides für .NET haben wir die Unterstützung für die Konvertierung von Präsentationen in Video implementiert.

* Verwenden Sie Aspose.Slides für .NET, um Frames aus den Präsentationsfolien mit einer angegebenen Bildrate (FPS) zu erzeugen.
* Verwenden Sie anschließend ein Drittanbieter‑Tool wie ffmpeg, um diese Frames zu einem Video zusammenzufügen.

## **PowerPoint‑Präsentation in Video konvertieren**

1. Verwenden Sie den Befehl `dotnet add package`, um Aspose.Slides und die FFMpegCore‑Bibliothek zu Ihrem Projekt hinzuzufügen:
   * führen Sie `dotnet add package Aspose.Slides.NET --version 22.11.0` aus
   * führen Sie `dotnet add package FFMpegCore --version 4.8.0` aus
2. Laden Sie ffmpeg von [hier](https://ffmpeg.org/download.html) herunter.
3. FFMpegCore erfordert, dass Sie den Pfad zu dem heruntergeladenen ffmpeg angeben (z. B. extrahiert nach "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. Führen Sie den PowerPoint‑zu‑Video‑Konvertierungscode aus.

Dieser C#‑Code demonstriert, wie man eine Präsentation (mit einer Form und zwei Animationseffekten) in ein Video umwandelt:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // verwendet die FFmpeg-Binärdateien, die wir zuvor nach C:\tools\ffmpeg extrahiert haben.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Fügt ein Smiley-Shape hinzu und animiert es anschließend.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Konfiguriere den ffmpeg-Binärordner. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konvertiere die Frames zu einem WebM-Video.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **Video‑Effekte**

Wenn Sie eine PowerPoint‑Präsentation mit Aspose.Slides für .NET in ein Video konvertieren, können Sie verschiedene Video‑Effekte anwenden, um die visuelle Qualität des Ausgabevideos zu verbessern. Diese Effekte ermöglichen es Ihnen, das Aussehen der Folien im endgültigen Video zu steuern, indem Sie sanfte Übergänge, Animationen und weitere visuelle Elemente hinzufügen. In diesem Abschnitt werden die verfügbaren Video‑Effekt‑Optionen erläutert und deren Anwendung gezeigt.

{{% alert color="primary" %}} 

Siehe:
- [PowerPoint‑Präsentationen mit Animationen in C# verbessern](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [Form‑Animation](https://docs.aspose.com/slides/net/shape-animation/)
- [Form‑Effekte in PowerPoint mit C# anwenden](https://docs.aspose.com/slides/net/shape-effect/)

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und das Gleiche gilt für Videos. Fügen wir dem Code für die vorherige Präsentation eine weitere Folie und einen Übergang hinzu:
```c#
// Füge ein Smiley-Shape hinzu und animiere es.
// ...

// Füge eine neue Folie und einen animierten Übergang hinzu.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides unterstützt auch Textanimationen. In diesem Beispiel animieren wir Absätze auf Objekten, sodass sie nacheinander mit einer Sekunde Verzögerung erscheinen:
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Füge Text und Animationen hinzu.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Konfiguriere den ffmpeg-Binärordner. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konvertiere die Frames zu einem WebM-Video.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **Klassen für Video‑Konvertierung**

Um PowerPoint‑zu‑Video‑Konvertierungen zu ermöglichen, stellt Aspose.Slides für .NET die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) bereit.

`PresentationAnimationsGenerator` ermöglicht das Festlegen der Frame‑Größe für das später zu erstellende Video sowie des FPS‑Werts (Frames pro Sekunde) über den Konstruktor. Wenn Sie eine Instanz einer Präsentation übergeben, wird deren `Presentation.SlideSize` verwendet und es werden Animationen erzeugt, die [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) nutzt.

Wenn Animationen erzeugt werden, wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis ausgelöst, das einen Parameter vom Typ [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) enthält. Diese Klasse stellt einen Player für eine einzelne Animation dar.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) zu arbeiten, verwenden Sie die Eigenschaft [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (die die Gesamtdauer der Animation liefert) und die Methode [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Jede Animationsposition wird innerhalb des Bereichs *0 bis Duration* festgelegt, und die Methode `GetFrame` liefert dann ein Bitmap, das den Animationszustand zu diesem Zeitpunkt darstellt.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Füge ein Smiley-Shape hinzu und animiere es.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // Der anfängliche Animationszustand.
            Bitmap bitmap = animationPlayer.GetFrame();  // Das Bitmap des anfänglichen Animationszustands.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Der Endzustand der Animation.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Das letzte Bild der Animation.
            lastBitmap.Save("last.png");
        };
    }
}
```


Um alle Animationen einer Präsentation gleichzeitig abzuspielen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) verwendet. Diese Klasse nimmt eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) und einen FPS‑Wert für die Effekte im Konstruktor entgegen und ruft dann das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:
```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```


Anschließend können die erzeugten Frames zu einem Video zusammengefügt werden. Siehe den Abschnitt [PowerPoint‑Präsentation in Video konvertieren](/slides/de/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Unterstützte Animationen und Effekte**

Bei der Konvertierung einer PowerPoint‑Präsentation in ein Video mit Aspose.Slides für .NET ist es wichtig zu wissen, welche Animationen und Effekte im Ausgabevideo unterstützt werden. Aspose.Slides unterstützt eine breite Palette gängiger Eingangs‑, Ausgangs‑ und Betonungseffekte wie Einblenden, Hereinfliegen, Zoom und Drehen. Einige fortgeschrittene oder benutzerdefinierte Animationen werden jedoch möglicherweise nicht vollständig erhalten oder können im endgültigen Video anders erscheinen. Dieser Abschnitt gibt einen Überblick über die unterstützten Animationen und Effekte.

**Eingang**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fade** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Fly In** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Float In** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Split** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wipe** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shape** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wheel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Random Bars** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Grow & Turn** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Swivel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bounce** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Betonung**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Color Pulse** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Teeter** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Spin** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Grow/Shrink** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Desaturate** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Darken** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Lighten** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Transparency** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Object Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Complementary Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Line Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fill Color** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Ausgang**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fade** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Fly Out** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Float Out** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Split** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wipe** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shape** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Random Bars** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shrink & Turn** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Swivel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bounce** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Bewegungspfade**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Arcs** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Turns** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shapes** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Loops** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Custom Path** | ![unterstützt](v.png) | ![unterstützt](v.png) |

## **Unterstützte Folien‑Übergangseffekte**

Folien‑Übergangseffekte spielen eine wichtige Rolle, um glatte und optisch ansprechende Wechsel zwischen Folien in einem Video zu erzeugen. Aspose.Slides für .NET unterstützt eine Vielzahl gängiger Übergangseffekte, um den Fluss und Stil Ihrer Originalpräsentation zu erhalten. Dieser Abschnitt hebt hervor, welche Übergangseffekte während des Konvertierungsprozesses unterstützt werden.

**Dezent**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fade** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Push** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Pull** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wipe** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Split** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Reveal** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Random Bars** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Shape** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Uncover** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Cover** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Flash** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Strips** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Spannend**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Drape** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Curtains** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wind** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Prestige** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fracture** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Crush** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Peel Off** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Page Curl** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Airplane** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Origami** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Dissolve** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Checkerboard** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Blinds** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Clock** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Ripple** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Honeycomb** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Glitter** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Vortex** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Shred** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Switch** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Flip** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Gallery** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Cube** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Doors** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Box** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Comb** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Random** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Dynamischer Inhalt**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Ferris Wheel** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Conveyor** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Rotate** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Orbit** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fly Through** | ![unterstützt](v.png) | ![unterstützt](v.png) |

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**

Ja, Aspose.Slides für .NET unterstützt das Arbeiten mit passwortgeschützten Präsentationen. Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides für .NET die Nutzung in Cloud‑Lösungen?**

Ja, Aspose.Slides für .NET kann in Cloud‑Anwendungen und -Diensten integriert werden. Die Bibliothek ist für den Einsatz in Server‑Umgebungen konzipiert und bietet hohe Leistung und Skalierbarkeit für die Stapelverarbeitung von Dateien.

**Gibt es Größeneinschränkungen für Präsentationen während der Konvertierung?**

Aspose.Slides für .NET kann Präsentationen praktisch jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird häufig empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.