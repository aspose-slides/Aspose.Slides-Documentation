---
title: PowerPoint-Präsentationen in .NET zu Video konvertieren
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
- PPT zu MP4 exportieren
- PPTX zu MP4 exportieren
- Videokonvertierung
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen in .NET zu Video konvertieren. Entdecken Sie Beispiel‑C#‑Code und Automatisierungstechniken, um Ihren Arbeitsablauf zu optimieren."
---

## **Übersicht**

**Erhöhte Barrierefreiheit:** Alle Geräte, unabhängig vom Betriebssystem, verfügen standardmäßig über Videoplayer, sodass es für Benutzer einfacher ist, Videos zu öffnen oder abzuspielen im Vergleich zu herkömmlichen Präsentationsanwendungen.

**Größere Reichweite:** Videos ermöglichen es Ihnen, ein größeres Publikum zu erreichen und Informationen in einem ansprechenderen Format zu präsentieren. Umfragen und Statistiken zeigen, dass Menschen Video‑Inhalte lieber ansehen und konsumieren als andere Formate, wodurch Ihre Botschaft wirkungsvoller wird.

{{% alert color="primary" %}} 
Sehen Sie sich unseren [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/video) an, da er eine Live‑ und effektive Umsetzung des hier beschriebenen Prozesses bietet.
{{% /alert %}} 

In Aspose.Slides für .NET haben wir die Unterstützung für die Konvertierung von Präsentationen in Video implementiert.

* Verwenden Sie Aspose.Slides für .NET, um Frames aus den Präsentationsfolien mit einer angegebenen Bildrate (FPS) zu erzeugen.  
* Verwenden Sie anschließend ein Drittanbieter‑Tool wie ffmpeg, um diese Frames zu einem Video zu bündeln.

## **PowerPoint‑Präsentation in Video konvertieren**

1. Verwenden Sie den `dotnet add package`‑Befehl, um Aspose.Slides und die FFMpegCore‑Bibliothek zu Ihrem Projekt hinzuzufügen:
   * führen Sie `dotnet add package Aspose.Slides.NET --version 22.11.0` aus
   * führen Sie `dotnet add package FFMpegCore --version 4.8.0` aus
2. Laden Sie ffmpeg von [hier](https://ffmpeg.org/download.html) herunter.
3. FFMpegCore erfordert, dass Sie den Pfad zum heruntergeladenen ffmpeg angeben (z. B. extrahiert nach "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. Führen Sie den PowerPoint‑zu‑Video‑Konvertierungscode aus.

Dieser C#‑Code demonstriert, wie man eine Präsentation (die eine Form und zwei Animationseffekte enthält) in ein Video konvertiert:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // verwendet die FFmpeg-Binärdateien, die wir zuvor nach C:\tools\ffmpeg extrahiert haben.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Füge eine Smiley-Form hinzu und animiere sie anschließend.
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

Beim Konvertieren einer PowerPoint‑Präsentation in ein Video mit Aspose.Slides für .NET können Sie verschiedene Video‑Effekte anwenden, um die visuelle Qualität des Ausgabematerials zu verbessern. Diese Effekte ermöglichen die Steuerung des Erscheinungsbildes der Folien im finalen Video durch sanfte Übergänge, Animationen und weitere visuelle Elemente. In diesem Abschnitt werden die verfügbaren Video‑Effekt‑Optionen erklärt und deren Anwendung gezeigt.

{{% alert color="primary" %}} 
Siehe:
- [PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/net/shape-effect/)
{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – das Gleiche gilt für Videos. Fügen wir der vorherigen Präsentation einen weiteren Folien‑ und Übergangseffekt im Code hinzu:
```c#
// Füge eine Smiley-Form hinzu und animiere sie.
// ...

// Füge eine neue Folie und einen animierten Übergang hinzu.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides unterstützt zudem Textanimationen. In diesem Beispiel animieren wir Absätze auf Objekten, sodass sie nacheinander mit einer Sekunde Verzögerung erscheinen:
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Text und Animationen hinzufügen.
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


## **Video‑Konvertierungs‑Klassen**

Um PowerPoint‑zu‑Video‑Aufgaben zu ermöglichen, stellt Aspose.Slides für .NET die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) bereit.

`PresentationAnimationsGenerator` ermöglicht das Festlegen der Frame‑Größe für das später zu erstellende Video sowie des FPS‑Werts über den Konstruktor. Wird eine Präsentationsinstanz übergeben, wird deren `Presentation.SlideSize` verwendet und es werden Animationen erzeugt, die [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) nutzt.

Beim Erzeugen von Animationen wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis ausgelöst, das einen [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)‑Parameter enthält. Diese Klasse repräsentiert einen Player für eine einzelne Animation.

Zur Arbeit mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) verwenden Sie die Eigenschaft [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (die die Gesamtdauer der Animation angibt) und die Methode [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Jede Positionsangabe liegt im Bereich *0 bis Duration*, und die Methode `GetFrame` liefert ein Bitmap, das den Animationszustand zu diesem Zeitpunkt darstellt.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Füge eine Smiley-Form hinzu und animiere sie.
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

            animationPlayer.SetTimePosition(0);          // Der Anfangszustand der Animation.
            Bitmap bitmap = animationPlayer.GetFrame();  // Bitmap des Anfangszustands der Animation.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Der Endzustand der Animation.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Der letzte Frame der Animation.
            lastBitmap.Save("last.png");
        };
    }
}
```


Um alle Animationen einer Präsentation gleichzeitig abzuspielen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) verwendet. Sie übernimmt eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) und einen FPS‑Wert für die Effekte im Konstruktor und ruft dann das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:
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


Anschließend können die erzeugten Frames zu einem Video zusammengefügt werden. Siehe den Abschnitt [Convert a PowerPoint Presentation to Video](/slides/de/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Unterstützte Animationen und Effekte**

Beim Konvertieren einer PowerPoint‑Präsentation in ein Video mit Aspose.Slides für .NET ist es wichtig zu wissen, welche Animationen und Effekte im Ergebnis unterstützt werden. Aspose.Slides unterstützt ein breites Spektrum gängiger Eingangs‑, Ausgangs‑ und Betonungseffekte wie Einblenden, Hereinfliegen, Zoomen und Drehen. Einige fortgeschrittene oder benutzerdefinierte Animationen werden jedoch eventuell nicht vollständig erhalten oder erscheinen im finalen Video anders. Dieser Abschnitt gibt einen Überblick über die unterstützten Animationen und Effekte.

**Eingang**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Betonung**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Ausgang**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Bewegungspfade**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Unterstützte Folienübergangseffekte**

Folienübergangseffekte tragen wesentlich zu reibungslosen und visuell ansprechenden Wechseln zwischen Folien in einem Video bei. Aspose.Slides für .NET unterstützt eine Vielzahl gängiger Übergangseffekte, um den Fluss und Stil Ihrer ursprünglichen Präsentation zu erhalten. Dieser Abschnitt zeigt, welche Übergangseffekte während der Konvertierung unterstützt werden.

**Dezent**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Aufregend**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Dynamischer Inhalt**:

| Animationsart | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?**

Ja, Aspose.Slides für .NET unterstützt die Arbeit mit passwortgeschützten Präsentationen. Beim Verarbeiten solcher Dateien muss das korrekte Passwort angegeben werden, damit die Bibliothek auf den Inhalt der Präsentation zugreifen kann.

**Unterstützt Aspose.Slides für .NET die Verwendung in Cloud‑Lösungen?**

Ja, Aspose.Slides für .NET kann in Cloud‑Anwendungen und -Diensten integriert werden. Die Bibliothek ist für den Einsatz in Server‑Umgebungen ausgelegt und bietet hohe Leistung sowie Skalierbarkeit für die Stapelverarbeitung von Dateien.

**Gibt es Größenbeschränkungen für Präsentationen während der Konvertierung?**

Aspose.Slides für .NET kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird gelegentlich empfohlen, die Präsentation zu optimieren, um die Performance zu verbessern.