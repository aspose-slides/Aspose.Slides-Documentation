---
title: Konwertowanie prezentacji PowerPoint na wideo w JavaScript
linktitle: PowerPoint na wideo
type: docs
weight: 130
url: /pl/nodejs-java/convert-powerpoint-to-video/
keywords:
- konwersja PowerPoint
- konwersja prezentacji
- konwersja PPT
- konwersja PPTX
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak konwertować prezentacje PowerPoint na wideo w JavaScript. Odkryj przykładowy kod i techniki automatyzacji, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

Konwertując swoją prezentację PowerPoint na wideo, zyskujesz 

* **Zwiększona dostępność:** Wszystkie urządzenia (bez względu na platformę) są domyślnie wyposażone w odtwarzacze wideo w porównaniu do aplikacji otwierających prezentacje, więc użytkownikom łatwiej jest otworzyć lub odtworzyć wideo.
* **Większy zasięg:** Dzięki wideo możesz dotrzeć do szerokiej publiczności i skierować do niej informacje, które w prezentacji mogłyby wydać się nużące. Większość badań i statystyk wskazuje, że ludzie oglądają i konsumują wideo bardziej niż inne formy treści i zazwyczaj wolą właśnie taki format.

{{% alert color="primary" %}} 

Możesz sprawdzić nasz [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/pl/conversion/ppt-to-word), ponieważ jest to działająca i skuteczna implementacja opisanego tutaj procesu.

{{% /alert %}} 

## **Konwersja PowerPoint do wideo w Aspose.Slides**

Aspose.Slides obsługuje konwersję prezentacji na wideo.

* Użyj **Aspose.Slides**, aby wygenerować zestaw klatek (z slajdów prezentacji), które odpowiadają określonej liczbie FPS (klatek na sekundę)
* Skorzystaj z zewnętrznego narzędzia, takiego jak **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)), aby utworzyć wideo na podstawie klatek. 

### **Konwertuj PowerPoint do wideo**

1. Pobierz ffmpeg [tutaj](https://ffmpeg.org/download.html).

2. Uruchom kod JavaScript konwertujący PowerPoint na wideo.

Ten kod JavaScript pokazuje, jak przekonwertować prezentację (zawierającą figurę i dwa efekty animacji) na wideo:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Dodaje kształt uśmiechu, a następnie animuje go
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Skonfiguruj folder binarny ffmpeg. Zobacz tę stronę: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Efekty wideo**

Możesz stosować animacje na obiektach na slajdach oraz używać przejść między slajdami. 

{{% alert color="primary" %}} 

Możesz zobaczyć te artykuły: [PowerPoint Animation](https://docs.aspose.com/slides/pl/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/pl/nodejs-java/shape-animation/), oraz [Shape Effect](https://docs.aspose.com/slides/pl/nodejs-java/shape-effect/).

{{% /alert %}} 

Animacje i przejścia sprawiają, że pokazy slajdów są bardziej atrakcyjne i interesujące — i mają taki sam efekt w przypadku wideo. Dodajmy kolejny slajd i przejście do kodu poprzedniej prezentacji:

```javascript
// Dodaje kształt uśmiechu i animuje go
// ...
// Dodaje nowy slajd i animowane przejście
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides obsługuje także animację tekstu. Animujemy więc akapity na obiektach, które będą pojawiały się kolejno (z opóźnieniem ustawionym na jedną sekundę):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Dodaje tekst i animacje
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Skonfiguruj folder binarny ffmpeg. Zobacz tę stronę: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Klasy konwersji wideo**

Aby umożliwić wykonywanie zadań konwersji PowerPoint na wideo, Aspose.Slides udostępnia klasy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationanimationsgenerator/) oraz [PresentationPlayer](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationanimationsgenerator/) pozwala ustawić rozmiar klatek wideo (które zostanie utworzone później) poprzez konstruktor. Jeśli przekażesz instancję prezentacji, zostanie użyte `Presentation.getSlideSize` i generuje animacje, które wykorzystuje [PresentationPlayer](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationplayer/).

Podczas generowania animacji wywoływane jest zdarzenie `NewAnimation` dla każdej kolejnej animacji, które posiada parametr odtwarzacza animacji prezentacji. Ten ostatni jest klasą reprezentującą odtwarzacz dla oddzielnej animacji.

Aby pracować z odtwarzaczem animacji prezentacji, używa się metod `getDuration` (pełny czas trwania animacji) oraz `setTimePosition`. Pozycja każdej animacji jest ustawiana w zakresie *0 do duration*, a następnie metoda `getFrame` zwróci obiekt BufferedImage odpowiadający stanowi animacji w danym momencie:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Dodaje kształt uśmiechu i animuje go
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// początkowy stan animacji
            try {
                // bitmapa początkowego stanu animacji
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// ostateczny stan animacji
            try {
                // ostatnia klatka animacji
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Aby wszystkie animacje w prezentacji odtwarzały się jednocześnie, używana jest klasa [PresentationPlayer](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationplayer/). Klasa ta przyjmuje w konstruktorze instancję [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationanimationsgenerator/) oraz FPS efektów, a następnie wywołuje zdarzenie `FrameTick` dla wszystkich animacji, aby je uruchomić:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Następnie wygenerowane klatki mogą być scalone w celu stworzenia wideo. Zobacz sekcję [Convert PowerPoint to Video](https://docs.aspose.com/slides/pl/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Obsługiwane animacje i efekty**

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

**Ścieżki ruchu:** 

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Najczęściej zadawane pytania**

**Czy możliwe jest konwertowanie prezentacji zabezpieczonych hasłem?**

Tak, Aspose.Slides umożliwia pracę z prezentacjami zabezpieczonymi hasłem. Podczas przetwarzania takich plików należy podać poprawne hasło, aby biblioteka mogła uzyskać dostęp do zawartości prezentacji.

**Czy Aspose.Slides obsługuje wykorzystanie w rozwiązaniach chmurowych?**

Tak, Aspose.Slides może być integrowany z aplikacjami i usługami w chmurze. Biblioteka jest zaprojektowana do pracy w środowiskach serwerowych, zapewniając wysoką wydajność i skalowalność przy przetwarzaniu plików wsadowo.

**Czy istnieją ograniczenia rozmiaru prezentacji podczas konwersji?**

Aspose.Slides jest w stanie obsłużyć prezentacje praktycznie każdego rozmiaru. Jednak przy pracy z bardzo dużymi plikami mogą być potrzebne dodatkowe zasoby systemowe i czasami zaleca się optymalizację prezentacji w celu poprawy wydajności.