---
title: Konwertuj prezentacje PowerPoint na wideo w Javie
linktitle: PowerPoint do wideo
type: docs
weight: 130
url: /pl/java/convert-powerpoint-to-video/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do wideo
- prezentacja do wideo
- PPT do wideo
- PPTX do wideo
- PowerPoint do MP4
- prezentacja do MP4
- PPT do MP4
- PPTX do MP4
- zapisz PPT jako MP4
- zapisz PPTX jako MP4
- eksportuj PPT do MP4
- eksportuj PPTX do MP4
- konwersja wideo
- PowerPoint
- Java
- Aspose.Slides
description: "Dowiedz się, jak konwertować prezentacje PowerPoint na wideo w Javie. Odkryj przykładowy kod i techniki automatyzacji, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

Konwertując swoją prezentację PowerPoint lub OpenDocument na wideo, zyskujesz:

**Zwiększona dostępność:** Wszystkie urządzenia, niezależnie od platformy, mają domyślnie odtwarzacze wideo, co ułatwia użytkownikom otwieranie lub odtwarzanie filmów w porównaniu z tradycyjnymi aplikacjami do prezentacji.

**Szerszy zasięg:** Filmy pozwalają dotrzeć do większej liczby odbiorców i przedstawić informacje w bardziej angażującym formacie. Badania i statystyki wskazują, że ludzie wolą oglądać i konsumować treści wideo niż inne formy, co sprawia, że Twoja wiadomość jest bardziej skuteczna.

{{% alert color="primary" %}} 

Możesz sprawdzić nasz [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/pl/conversion/ppt-to-word) ponieważ jest to działająca i skuteczna implementacja opisanego tutaj procesu.

{{% /alert %}} 

## **Konwersja PowerPoint do wideo w Aspose.Slides**

W [Aspose.Slides 22.11](https://docs.aspose.com/slides/pl/java/aspose-slides-for-java-22-11-release-notes/) wprowadziliśmy obsługę konwersji prezentacji na wideo. 

* Użyj **Aspose.Slides**, aby wygenerować zestaw klatek (z slajdów prezentacji) odpowiadających określonej liczbie FPS (klatek na sekundę)
* Użyj narzędzia zewnętrznego, takiego jak **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)), aby stworzyć wideo na podstawie klatek. 

### **Konwertuj PowerPoint na wideo**

1. Dodaj to do swojego pliku POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Pobierz ffmpeg [here](https://ffmpeg.org/download.html).

4. Uruchom kod Java konwertujący PowerPoint na wideo.

Ten kod Java pokazuje, jak przekonwertować prezentację (zawierającą figurę i dwa efekty animacji) na wideo:

```java
Presentation presentation = new Presentation();
try {
    // Dodaje kształt uśmiechu i następnie animuje go
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Skonfiguruj folder binarny ffmpeg. Zobacz tę stronę: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Efekty wideo**

Możesz zastosować animacje do obiektów na slajdach oraz używać przejść między slajdami. 

{{% alert color="primary" %}} 

Możesz chcieć zobaczyć te artykuły: [PowerPoint Animation](https://docs.aspose.com/slides/pl/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/pl/java/shape-animation/), and [Shape Effect](https://docs.aspose.com/slides/pl/java/shape-effect/).

{{% /alert %}} 

Animacje i przejścia sprawiają, że pokazy slajdów są bardziej angażujące i ciekawe — i robią to samo w przypadku wideo. Dodajmy kolejny slajd i przejście do kodu poprzedniej prezentacji:

```java
// Dodaje kształt uśmiechu i animuje go

// ...

// Dodaje nowy slajd i animowane przejście

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides obsługuje również animację tekstów. Animujemy więc akapity na obiektach, które pojawią się kolejno (z opóźnieniem ustawionym na jedną sekundę):

```java
Presentation presentation = new Presentation();
try {
    // Dodaje tekst i animacje
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Skonfiguruj folder binarny ffmpeg. Zobacz tę stronę: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Klasy konwersji wideo**

Aby umożliwić wykonywanie zadań konwersji PowerPoint na wideo, Aspose.Slides udostępnia klasy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationanimationsgenerator/) i [PresentationPlayer](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationanimationsgenerator/) pozwala ustawić rozmiar klatki wideo (które zostanie utworzone później) poprzez konstruktor. Jeśli przekażesz instancję prezentacji, użyty zostanie `Presentation.SlideSize` i zostaną wygenerowane animacje, które wykorzystuje [PresentationPlayer](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationplayer/).

Gdy animacje są generowane, dla każdej kolejnej animacji generowane jest zdarzenie `NewAnimation`, które posiada parametr [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationanimationplayer/). Ostatnia jest klasą reprezentującą odtwarzacz oddzielnej animacji.

Aby pracować z [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationanimationplayer/), używane są właściwość [Duration](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (pełny czas trwania animacji) oraz metoda [SetTimePosition](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Każda pozycja animacji jest ustawiana w przedziale *0 to duration*, a następnie metoda `GetFrame` zwróci obiekt BufferedImage odpowiadający stanowi animacji w danym momencie:

```java
Presentation presentation = new Presentation();
try {
    // Dodaje kształt uśmiechu i animuje go
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // początkowy stan animacji
            try {
                // bitmapa początkowego stanu animacji
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // końcowy stan animacji
            try {
                // ostatnia klatka animacji
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aby wszystkie animacje w prezentacji odtwarzały się jednocześnie, używana jest klasa [PresentationPlayer](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationplayer/). Klasa ta przyjmuje w konstruktorze instancję [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationanimationsgenerator/) oraz FPS dla efektów, a następnie wywołuje zdarzenie `FrameTick` dla wszystkich animacji, aby je odtworzyć:

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Następnie wygenerowane klatki mogą być skompilowane, aby utworzyć wideo. Zobacz sekcję [Convert PowerPoint to Video](https://docs.aspose.com/slides/pl/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Obsługiwane animacje i efekty**

**Entrance**:

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

**Emphasis**:

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

**Exit**:

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

**Motion Paths**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Czy możliwe jest konwertowanie prezentacji zabezpieczonych hasłem?**

Tak, Aspose.Slides umożliwia pracę z [prezentacjami zabezpieczonymi hasłem](/slides/pl/java/password-protected-presentation/). Przy przetwarzaniu takich plików należy podać prawidłowe hasło, aby biblioteka mogła uzyskać dostęp do zawartości prezentacji.

**Czy Aspose.Slides obsługuje użycie w rozwiązaniach chmurowych?**

Tak, Aspose.Slides może być integrowane z aplikacjami i usługami chmurowymi. Biblioteka jest zaprojektowana do pracy w środowiskach serwerowych, zapewniając wysoką wydajność i skalowalność przy przetwarzaniu plików w trybie wsadowym.

**Czy istnieją ograniczenia rozmiaru prezentacji podczas konwersji?**

Aspose.Slides radzi sobie z prezentacjami praktycznie każdego rozmiaru. Jednak przy bardzo dużych plikach mogą być potrzebne dodatkowe zasoby systemowe i czasami zaleca się optymalizację prezentacji w celu poprawy wydajności.