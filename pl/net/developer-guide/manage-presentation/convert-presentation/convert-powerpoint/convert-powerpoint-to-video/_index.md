---
title: Konwertuj prezentacje PowerPoint na wideo w .NET
linktitle: PowerPoint do wideo
type: docs
weight: 130
url: /pl/net/convert-powerpoint-to-video/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na wideo
- prezentacja na wideo
- PPT na wideo
- PPTX na wideo
- PowerPoint na MP4
- prezentacja na MP4
- PPT na MP4
- PPTX na MP4
- zapisz PPT jako MP4
- zapisz PPTX jako MP4
- eksportuj PPT do MP4
- eksportuj PPTX do MP4
- konwersja wideo
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak konwertować prezentacje PowerPoint na wideo w .NET. Odkryj przykładowy kod C# i techniki automatyzacji ułatwiające Twój przepływ pracy."
---
## **Wstęp**

Konwertując swoją prezentację PowerPoint lub OpenDocument na wideo, zyskujesz:

**Zwiększona dostępność:** Wszystkie urządzenia, niezależnie od platformy, są wyposażone w odtwarzacze wideo domyślnie, co ułatwia użytkownikom otwieranie lub odtwarzanie filmów w porównaniu z tradycyjnymi aplikacjami do prezentacji.

**Szersze zasięgi:** Filmy pozwalają dotrzeć do większej liczby odbiorców i przedstawić informacje w bardziej angażującym formacie. Badania i statystyki wskazują, że ludzie wolą oglądać i konsumować treści wideo niż inne formy, co sprawia, że Twoja wiadomość jest bardziej skuteczna.

{{% alert color="info" %}} 

Sprawdź nasz [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/pl/video), ponieważ oferuje działające i efektywne wdrożenie procesu opisanego tutaj.

{{% /alert %}} 

W Aspose.Slides for .NET wprowadziliśmy obsługę konwertowania prezentacji na wideo.

* Użyj Aspose.Slides for .NET do generowania klatek z slajdów prezentacji ze określoną liczbą klatek na sekundę (FPS).
* Następnie użyj narzędzia zewnętrznego, takiego jak ffmpeg, do skompilowania tych klatek w wideo.

## **Konwertuj prezentację PowerPoint na wideo**

1. Użyj polecenia `dotnet add package`, aby dodać Aspose.Slides i bibliotekę FFMpegCore do swojego projektu:
   * uruchom `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * uruchom `dotnet add package FFMpegCore --version 4.8.0`
2. Pobierz ffmpeg z [tutaj](https://ffmpeg.org/download.html).
3. FFMpegCore wymaga określenia ścieżki do pobranego ffmpeg (np. rozpakowanego do "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Uruchom kod konwertujący PowerPoint na wideo.

Poniższy kod C# demonstruje, jak przekonwertować prezentację (zawierającą kształt i dwa efekty animacji) na wideo:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // użyje binarek FFmpeg, które wcześniej wyodrębniliśmy do C:\tools\ffmpeg.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj kształt uśmiechu, a następnie go animuj.
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

    // Skonfiguruj folder z binarkami ffmpeg. Zobacz tę stronę: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konwertuj klatki na wideo webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Efekty wideo**

Podczas konwertowania prezentacji PowerPoint na wideo przy użyciu Aspose.Slides for .NET, możesz zastosować różne efekty wideo, aby poprawić jakość wizualną wyjścia. Efekty te pozwalają kontrolować wygląd slajdów w finalnym wideo, dodając płynne przejścia, animacje i inne elementy wizualne. Ta sekcja wyjaśnia dostępne opcje efektów wideo i pokazuje, jak je zastosować.

{{% alert color="info" %}} 

Zobacz:
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/pl/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/pl/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/pl/net/shape-effect/)

{{% /alert %}} 

Animacje i przejścia sprawiają, że pokazy slajdów są bardziej angażujące i interesujące — i mają taki sam efekt wideo. Dodajmy kolejny slajd i przejście do kodu dla poprzedniej prezentacji:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Dodaj kształt uśmiechu i animuj go (zobacz kod powyżej).

    // Dodaj nowy slajd i animowane przejście.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides obsługuje także animacje tekstu. W tym przykładzie animujemy akapity na obiektach tak, aby pojawiały się kolejno, z jednosekundowym opóźnieniem między nimi:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj tekst i animacje.
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

    // Skonfiguruj folder z binarkami ffmpeg. Zobacz tę stronę: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Konwertuj klatki na wideo webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Klasy konwersji wideo**

Aby umożliwić zadania konwersji PowerPoint do wideo, Aspose.Slides for .NET udostępnia klasy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/net/aspose.slides.export/presentationanimationsgenerator/) i [PresentationPlayer](https://reference.aspose.com/slides/pl/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` pozwala ustawić rozmiar klatki dla wideo (które zostanie później utworzone) oraz wartość FPS (klatek na sekundę) poprzez konstruktor. Jeśli przekażesz instancję prezentacji, zostanie użyty jej `Presentation.SlideSize`, a klasa generuje animacje, które używa [PresentationPlayer](https://reference.aspose.com/slides/pl/net/aspose.slides.export/presentationplayer/).

Podczas generowania animacji wywoływane jest zdarzenie `NewAnimation` dla każdej kolejnej animacji, które zawiera parametr [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipresentationanimationplayer/). Ta klasa reprezentuje odtwarzacz pojedynczej animacji.

Aby pracować z [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipresentationanimationplayer/), używasz właściwości [Duration](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipresentationanimationplayer/duration/) (która podaje pełny czas trwania animacji) oraz metody [SetTimePosition](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Każda pozycja animacji jest ustawiana w zakresie *0 do duration*, a metoda `GetFrame` zwraca Bitmapę przedstawiającą stan animacji w danym momencie.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Dodaj kształt uśmiechu i animuj go.
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

            animationPlayer.SetTimePosition(0);        // Początkowy stan animacji.
            IImage image = animationPlayer.GetFrame(); // Obraz początkowego stanu animacji.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Końcowy stan animacji.
            IImage lastImage = animationPlayer.GetFrame();             // Ostatnia klatka animacji.
            lastImage.Save("last.png");
        };
    }
}
```

Aby wszystkie animacje w prezentacji odtwarzały się jednocześnie, używa się klasy [PresentationPlayer](https://reference.aspose.com/slides/pl/net/aspose.slides.export/presentationplayer/). Klasa ta przyjmuje instancję [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/net/aspose.slides.export/presentationanimationsgenerator/) oraz wartość FPS dla efektów w konstruktorze, a następnie wywołuje zdarzenie `FrameTick` dla wszystkich animacji, aby je odtworzyć:

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

Następnie wygenerowane klatki mogą być skompilowane w celu utworzenia wideo. Zobacz sekcję [Convert a PowerPoint Presentation to Video](/slides/pl/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Obsługiwane animacje i efekty**

Podczas konwertowania prezentacji PowerPoint na wideo przy użyciu Aspose.Slides for .NET ważne jest zrozumienie, które animacje i efekty są obsługiwane w wyniku. Aspose.Slides obsługuje szeroką gamę typowych efektów wejściowych, wyjściowych i podkreślających, takich jak zanikanie, wlot, przybliżanie i obracanie. Niektóre zaawansowane lub niestandardowe animacje mogą nie zostać w pełni zachowane lub mogą wyglądać inaczej w finalnym wideo. Poniżej przedstawiono obsługiwane animacje i efekty.

**Wejście**:

| Typ animacji | Aspose.Slides | PowerPoint |
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

**Podkreślenie**:

| Typ animacji | Aspose.Slides | PowerPoint |
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

**Wyjście**:

| Typ animacji | Aspose.Slides | PowerPoint |
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

**Ścieżki ruchu**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Obsługiwane efekty przejścia slajdów**

Efekty przejścia slajdów odgrywają ważną rolę w tworzeniu płynnych i wizualnie atrakcyjnych zmian między slajdami w wideo. Aspose.Slides for .NET obsługuje różnorodne popularne efekty przejścia, pomagając zachować przepływ i styl oryginalnej prezentacji. Poniżej przedstawiono, które efekty przejścia są obsługiwane podczas procesu konwersji.

**Subtelne**:

| Typ animacji | Aspose.Slides | PowerPoint |
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

**Ekscytujące**:

| Typ animacji | Aspose.Slides | PowerPoint |
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

**Dynamiczna zawartość**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### Czy można konwertować prezentacje zabezpieczone hasłem?

Tak, Aspose.Slides for .NET umożliwia pracę z prezentacjami zabezpieczonymi hasłem. Podczas przetwarzania takich plików należy podać właściwe hasło, aby biblioteka mogła uzyskać dostęp do zawartości prezentacji.

### Czy Aspose.Slides for .NET obsługuje użycie w rozwiązaniach chmurowych?

Tak, Aspose.Slides for .NET może być zintegrowany z aplikacjami i usługami w chmurze. Biblioteka jest zaprojektowana do pracy w środowiskach serwerowych, zapewniając wysoką wydajność i skalowalność przy przetwarzaniu wsadowym plików.

### Czy istnieją ograniczenia rozmiaru prezentacji podczas konwersji?

Aspose.Slides for .NET jest w stanie obsłużyć prezentacje praktycznie dowolnego rozmiaru. Jednak przy pracy z bardzo dużymi plikami mogą być wymagane dodatkowe zasoby systemowe i często zaleca się optymalizację prezentacji w celu poprawy wydajności.