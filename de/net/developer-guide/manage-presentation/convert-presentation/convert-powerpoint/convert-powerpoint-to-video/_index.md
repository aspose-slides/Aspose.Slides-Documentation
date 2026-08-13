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
- PPT nach MP4 exportieren
- PPTX nach MP4 exportieren
- Videokonvertierung
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint-Präsentationen in .NET zu Video konvertieren. Entdecken Sie Beispiel‑C#‑Code und Automatisierungstechniken, um Ihren Workflow zu optimieren."
---
## **Einleitung**

Durch die Konvertierung Ihrer PowerPoint‑ oder OpenDocument‑Präsentation in ein Video erhalten Sie:

**Erhöhte Barrierefreiheit:** Alle Geräte, unabhängig von der Plattform, verfügen standardmäßig über Videoplayer, sodass es für Benutzer einfacher ist, Videos zu öffnen oder abzuspielen, verglichen mit herkömmlichen Präsentationsanwendungen.

**Größere Reichweite:** Videos ermöglichen es Ihnen, ein größeres Publikum zu erreichen und Informationen in einem ansprechenderen Format zu präsentieren. Umfragen und Statistiken zeigen, dass Menschen Video‑Inhalte gegenüber anderen Formen bevorzugen, wodurch Ihre Botschaft wirkungsvoller wird.

{{% alert color="info" %}} 
Schauen Sie sich unseren [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/de/video) an, da er eine Live‑ und effektive Umsetzung des hier beschriebenen Prozesses bietet.
{{% /alert %}} 

In Aspose.Slides for .NET haben wir die Unterstützung für die Konvertierung von Präsentationen in Video implementiert.

* Verwenden Sie Aspose.Slides for .NET, um aus den Präsentationsfolien bei einer angegebenen Bildrate (FPS) Frames zu erzeugen.
* Anschließend verwenden Sie ein Drittanbieter‑Werkzeug wie ffmpeg, um diese Frames zu einem Video zusammenzufügen.

## **PowerPoint‑Präsentation in Video konvertieren**

1. Verwenden Sie den Befehl `dotnet add package`, um Aspose.Slides und die FFMpegCore‑Bibliothek zu Ihrem Projekt hinzuzufügen:
   * Ausführen `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * Ausführen `dotnet add package FFMpegCore --version 4.8.0`
2. Laden Sie ffmpeg von [hier](https://ffmpeg.org/download.html) herunter.
3. FFMpegCore erfordert, dass Sie den Pfad zum heruntergeladenen ffmpeg angeben (z. B. extrahiert nach "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Führen Sie den PowerPoint‑zu‑Video‑Konvertierungscode aus.

Dieser C#‑Code demonstriert, wie eine Präsentation (die ein Shape und zwei Animationseffekte enthält) in ein Video umgewandelt wird:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // ver​wendet die FFmpeg‑Binärdateien, die wir zuvor nach C:\tools\ffmpeg extrahiert haben.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Füge ein Smiley‑Shape hinzu und animiere es anschließend.
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

    // Konfiguriere den Ordner mit den ffmpeg‑Binärdateien. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konvertiere die Frames in ein WebM‑Video.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Videoeffekte**

Beim Konvertieren einer PowerPoint‑Präsentation in ein Video mit Aspose.Slides for .NET können Sie verschiedene Videoeffekte anwenden, um die visuelle Qualität des Ergebnisses zu verbessern. Diese Effekte ermöglichen es Ihnen, das Erscheinungsbild der Folien im finalen Video zu steuern, indem Sie sanfte Übergänge, Animationen und weitere visuelle Elemente hinzufügen. Dieser Abschnitt erklärt die verfügbaren Videoeffekt‑Optionen und zeigt, wie sie angewendet werden.

{{% alert color="info" %}} 
Siehe:
- [Verbesserung von PowerPoint‑Präsentationen mit Animationen in C#](https://docs.aspose.com/slides/de/net/powerpoint-animation/)
- [Shape‑Animation](https://docs.aspose.com/slides/de/net/shape-animation/)
- [Shape‑Effekte in PowerPoint mit C# anwenden](https://docs.aspose.com/slides/de/net/shape-effect/)
{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender – und das Gleiche gilt für Videos. Lassen Sie uns dem vorherigen Beispiel eine weitere Folie und einen Übergang hinzufügen:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Füge ein Smiley-Shape hinzu und animiere es (siehe den obigen Code).

    // Füge eine neue Folie und einen animierten Übergang hinzu.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides unterstützt zudem Textanimationen. In diesem Beispiel animieren wir Absätze auf Objekten, sodass sie nacheinander erscheinen, jeweils mit einer Sekunde Verzögerung:

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

    // Konvertiere die Frames in ein WebM-Video.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Klassen zur Videokonvertierung**

Um PowerPoint‑zu‑Video‑Aufgaben zu ermöglichen, stellt Aspose.Slides for .NET die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/de/net/aspose.slides.export/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/de/net/aspose.slides.export/presentationplayer/) bereit.

`PresentationAnimationsGenerator` ermöglicht das Festlegen der Frame‑Größe für das später erstellte Video und des FPS‑Werts über dessen Konstruktor. Wenn Sie eine Präsentationsinstanz übergeben, wird deren `Presentation.SlideSize` verwendet und es werden Animationen generiert, die [PresentationPlayer](https://reference.aspose.com/slides/de/net/aspose.slides.export/presentationplayer/) nutzt.

Beim Generieren von Animationen wird für jede nachfolgende Animation ein `NewAnimation`‑Ereignis ausgelöst, das einen [IPresentationAnimationPlayer](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipresentationanimationplayer/)‑Parameter enthält. Diese Klasse repräsentiert einen Player für eine einzelne Animation.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipresentationanimationplayer/) zu arbeiten, benutzen Sie die [Duration](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipresentationanimationplayer/duration/)‑Eigenschaft (die die Gesamtdauer der Animation liefert) und die [SetTimePosition](https://reference.aspose.com/slides/de/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/)‑Methode. Jede Animationsposition wird im Bereich *0 bis Dauer* gesetzt, und die `GetFrame`‑Methode liefert dann ein Bitmap, das den Animationszustand zu diesem Zeitpunkt darstellt.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

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

            animationPlayer.SetTimePosition(0);        // Der Anfangszustand der Animation.
            IImage image = animationPlayer.GetFrame(); // Das Bild des Anfangszustands der Animation.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Der Endzustand der Animation.
            IImage lastImage = animationPlayer.GetFrame();             // Das letzte Bild der Animation.
            lastImage.Save("last.png");
        };
    }
}
```

Um alle Animationen einer Präsentation gleichzeitig abspielen zu lassen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/de/net/aspose.slides.export/presentationplayer/) verwendet. Diese Klasse nimmt im Konstruktor eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/de/net/aspose.slides.export/presentationanimationsgenerator/) und einen FPS‑Wert für Effekte entgegen und ruft dann das `FrameTick`‑Ereignis für alle Animationen auf, um sie abzuspielen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Beim Konvertieren einer PowerPoint‑Präsentation in ein Video mit Aspose.Slides for .NET ist es wichtig zu wissen, welche Animationen und Effekte im Ergebnis unterstützt werden. Aspose.Slides unterstützt eine Vielzahl gängiger Eingangs‑, Ausgangs‑ und Betonungseffekte wie Einblenden, Hereinfliegen, Zoomen und Drehen. Einige erweiterte oder benutzerdefinierte Animationen werden jedoch möglicherweise nicht vollständig erhalten oder können im finalen Video anders erscheinen. Dieser Abschnitt gibt einen Überblick über die unterstützten Animationen und Effekte.

**Eingang**:

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Unterstützte Folienübergangseffekte**

Folienübergangseffekte spielen eine wichtige Rolle, um reibungslose und optisch ansprechende Wechsel zwischen Folien in einem Video zu erzeugen. Aspose.Slides for .NET unterstützt eine Vielzahl gängiger Übergangseffekte, um den Fluss und Stil Ihrer Originalpräsentation zu bewahren. Dieser Abschnitt hebt hervor, welche Übergangseffekte während des Konvertierungsprozesses unterstützt werden.

**Dezent**:

| Animation Type | Aspose.Slides | PowerPoint |
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

**Spannend**:

| Animation Type | Aspose.Slides | PowerPoint |
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

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### Ist es möglich, passwortgeschützte Präsentationen zu konvertieren?

Ja, Aspose.Slides for .NET ermöglicht die Arbeit mit passwortgeschützten Präsentationen. Beim Verarbeiten solcher Dateien müssen Sie das korrekte Passwort angeben, damit die Bibliothek Zugriff auf den Inhalt der Präsentation erhält.

### Unterstützt Aspose.Slides for .NET die Verwendung in Cloud‑Lösungen?

Ja, Aspose.Slides for .NET kann in Cloud‑Anwendungen und -Diensten integriert werden. Die Bibliothek ist für den Einsatz in Serverumgebungen konzipiert und gewährleistet hohe Leistung sowie Skalierbarkeit für die stapelweise Verarbeitung von Dateien.

### Gibt es Größenbeschränkungen für Präsentationen während der Konvertierung?

Aspose.Slides for .NET kann praktisch Präsentationen jeder Größe verarbeiten. Bei sehr großen Dateien können jedoch zusätzliche Systemressourcen erforderlich sein, und es wird manchmal empfohlen, die Präsentation zu optimieren, um die Leistung zu verbessern.