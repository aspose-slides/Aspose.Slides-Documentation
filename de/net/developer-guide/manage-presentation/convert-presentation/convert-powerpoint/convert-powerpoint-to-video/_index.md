---
title: PowerPoint in Video umwandeln
type: docs
weight: 130
url: /de/net/convert-powerpoint-to-video/
keywords: "PowerPoint umwandeln, PPT, PPTX, Präsentation, Video, MP4, PPT in Video, PPT in MP4, C#, Csharp, .NET, Aspose.Slides"
description: "PowerPoint in Video in C# oder .NET umwandeln"
---

Durch die Umwandlung Ihrer PowerPoint-Präsentation in ein Video erhalten Sie

* **Erhöhte Zugänglichkeit:** Alle Geräte (unabhängig von der Plattform) sind standardmäßig mit Videoplayern ausgestattet, im Gegensatz zu Anwendungen zum Öffnen von Präsentationen, sodass Benutzer es einfacher finden, Videos zu öffnen oder abzuspielen.
* **Mehr Reichweite:** Durch Videos können Sie ein großes Publikum erreichen und mit Informationen ansprechen, die ansonsten in einer Präsentation langweilig erscheinen könnten. Die meisten Umfragen und Statistiken legen nahe, dass Menschen Videos häufiger ansehen und konsumieren als andere Formen von Inhalten, und sie bevorzugen im Allgemeinen solche Inhalte.

{{% alert color="primary" %}} 

Möglicherweise möchten Sie unseren [**Online-Konverter für PowerPoint in Video**](https://products.aspose.app/slides/conversion/ppt-to-word) überprüfen, da dies eine live und effektive Implementierung des hier beschriebenen Prozesses ist.

{{% /alert %}} 

## **PowerPoint in Video Umwandlung in Aspose.Slides**

In [Aspose.Slides 22.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-22-11-release-notes/) haben wir die Unterstützung für die Umwandlung von Präsentationen in Videos implementiert.

* Verwenden Sie Aspose.Slides, um eine Reihe von Frames (von den Präsentationsfolien) zu generieren, die einer bestimmten FPS (Frames pro Sekunde) entsprechen.
* Verwenden Sie ein Drittanbieter-Tool wie FFMpegCore (ffmpeg), um ein Video basierend auf den Frames zu erstellen.

### **PowerPoint in Video umwandeln**

1. Verwenden Sie den Befehl `dotnet add package`, um Aspose.Slides und die FFMpegCore-Bibliothek zu Ihrem Projekt hinzuzufügen:
   * führen Sie `dotnet add package Aspose.Slides.NET --version 22.11.0` aus
   * führen Sie `dotnet add package FFMpegCore --version 4.8.0` aus
2. Laden Sie ffmpeg [hier](https://ffmpeg.org/download.html) herunter.
3. FFMpegCore erfordert, dass Sie den Pfad zum heruntergeladenen ffmpeg angeben (z.B. entpackt unter "C:\tools\ffmpeg"):  `GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin",} );`
4. Führen Sie den Code zur Umwandlung von PowerPoint in Video aus.

Dieser C#-Code zeigt Ihnen, wie Sie eine Präsentation (die eine Figur und zwei Animationseffekte enthält) in ein Video umwandeln:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // Verwendet die FFmpeg-Binärdateien, die wir vorher in "c:\tools\ffmpeg" entpackt haben
using Aspose.Slides.Animation;
using (Presentation presentation = new Presentation())

{
    // Fügt eine Smiley-Form hinzu und animiert sie
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
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

    // Konfigurieren Sie den Ordner für die ffmpeg-Binärdateien. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // Konvertiert Frames in ein Webm-Video
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Videoeffekte**

Sie können Animationen auf Objekte auf Folien anwenden und Übergänge zwischen Folien verwenden.

{{% alert color="primary" %}} 

Vielleicht möchten Sie sich diese Artikel ansehen: [PowerPoint-Animation](https://docs.aspose.com/slides/net/powerpoint-animation/), [Formanimation](https://docs.aspose.com/slides/net/shape-animation/), und [Formeffekt](https://docs.aspose.com/slides/net/shape-effect/).

{{% /alert %}} 

Animationen und Übergänge machen Diashows ansprechender und interessanter – und sie tun dasselbe für Videos. Lassen Sie uns eine weitere Folie und einen Übergang in den Code der vorherigen Präsentation hinzufügen:

```c#
// Fügt eine Smiley-Form hinzu und animiert sie

// ...

// Fügt eine neue Folie und einen animierten Übergang hinzu

ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

newSlide.Background.Type = BackgroundType.OwnBackground;

newSlide.Background.FillFormat.FillType = FillType.Solid;

newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;

newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides unterstützt auch Animationen für Texte. Wir animieren also Absätze auf Objekten, die nacheinander erscheinen (mit einer Verzögerung von einer Sekunde):

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    // Fügt Text und Animationen hinzu
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides für .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("PowerPoint-Präsentation mit Text in Video umwandeln"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("Absatz für Absatz"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    // Konvertiert Frames in Video
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
    // Konfigurieren Sie den Ordner für die ffmpeg-Binärdateien. Siehe diese Seite: https://github.com/rosenbjerg/FFMpegCore#installation

    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // Konvertiert Frames in ein Webm-Video
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Video-Konvertierungsklassen**

Um Ihnen die Durchführung von PowerPoint-zu-Video-Umwandlungsaufgaben zu ermöglichen, bietet Aspose.Slides die Klassen [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) und [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) an.

PresentationAnimationsGenerator ermöglicht es Ihnen, die Frame-Größe für das Video (das später erstellt wird) über seinen Konstruktor festzulegen. Wenn Sie eine Instanz der Präsentation übergeben, wird `Presentation.SlideSize` verwendet, und es wird Animationen generiert, die von [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) verwendet werden.

Wenn Animationen generiert werden, wird ein Ereignis `NewAnimation` für jede nachfolgende Animation ausgelöst, das den Parameter [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) hat. Letzteres ist eine Klasse, die einen Player für eine separate Animation darstellt.

Um mit [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/) zu arbeiten, werden die Eigenschaften [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (die Gesamtdauer der Animation) und die Methode [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) verwendet. Jede Animationsposition wird im Bereich *0 bis Dauer* festgelegt, und die Methode `GetFrame` gibt dann ein Bitmap zurück, das dem Animationszustand zu diesem Zeitpunkt entspricht.

```c#
using (Presentation presentation = new Presentation())
{
    // Fügt eine Smiley-Form hinzu und animiert sie
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Gesamte Animationsdauer: {animationPlayer.Duration}");
            
            animationPlayer.SetTimePosition(0); // Ursprünglicher Animationszustand
            Bitmap bitmap = animationPlayer.GetFrame(); // Bitmap des ursprünglichen Animationszustands

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Endzustand der Animation
            Bitmap lastBitmap = animationPlayer.GetFrame(); // Letzter Frame der Animation
            lastBitmap.Save("last.png");
        };
    }
}
```

Um alle Animationen in einer Präsentation gleichzeitig abzuspielen, wird die Klasse [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) verwendet. Diese Klasse nimmt eine Instanz von [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) und die FPS für Effekte in ihrem Konstruktor und ruft dann das Ereignis `FrameTick` für alle Animationen auf, um sie abzuspielen:

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

Dann können die generierten Frames kompiliert werden, um ein Video zu produzieren. Siehe den Abschnitt [PowerPoint in Video umwandeln](https://docs.aspose.com/slides/net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Unterstützte Animationen und Effekte**


**Eingänge**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Erscheinen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Ausblenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hineinfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hineinschweben** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Rad** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wachsen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schwenken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Springen** | ![unterstützt](v.png) | ![unterstützt](v.png) |


**Betonung**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Puls** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Farbpuls** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wippen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drehen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wachsen/Schrumpfen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Entsättigen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Dunkler machen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Aufhellen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Transparenz** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Objektfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Komplementärfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Linienfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Füllfarbe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Ausgänge**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Verschwinden** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Ausblenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hinausfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Hinausschweben** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schrumpfen & Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schwenken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Springen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Bewegungspfade:**

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linien** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Bögen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drehungen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Formen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schleifen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Benutzerdefinierter Pfad** | ![unterstützt](v.png) | ![unterstützt](v.png) |

## **Unterstützte Folienübergangseffekte**

**Subtil**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Ausblenden** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Drücken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Ziehen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Wischen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Teilen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Enthüllen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zufällige Balken** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Form** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Enthüllen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Abdeckung** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Blitzen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Streifen** | ![unterstützt](v.png) | ![unterstützt](v.png) |

**Aufregend**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Umfallen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Drapieren** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Vorhänge** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wind** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Prestige** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Fraktur** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zerdrücken** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Abziehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Seitenumblättern** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Flugzeug** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Origami** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Auflösen** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Schachbrett** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Jalousien** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Uhr** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Welle** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Honigwabe** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Glitzern** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Wirbel** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Schnipsel** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Umschalten** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Galerie** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Würfel** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Türen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Box** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Kamm** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Zoom** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Zufällig** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |

**Dynamischer Inhalt**:

| Animationstyp | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Riesenrad** | ![unterstützt](v.png) | ![unterstützt](v.png) |
| **Förderband** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Drehen** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Umlaufbahn** | ![nicht unterstützt](x.png) | ![unterstützt](v.png) |
| **Durchfliegen** | ![unterstützt](v.png) | ![unterstützt](v.png) |