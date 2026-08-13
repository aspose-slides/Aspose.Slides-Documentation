---
title: Konwertuj prezentacje PowerPoint na wideo w systemie Android
linktitle: PowerPoint do wideo
type: docs
weight: 130
url: /pl/androidjava/convert-powerpoint-to-video/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak konwertować prezentacje PowerPoint na wideo w Javie. Poznaj przykładowy kod i techniki automatyzacji, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

Konwertując swoją prezentację PowerPoint na wideo, zyskujesz 

* **Zwiększona dostępność:** Wszystkie urządzenia (bez względu na platformę) mają domyślnie odtwarzacze wideo, w przeciwieństwie do aplikacji otwierających prezentacje, więc użytkownikom łatwiej jest otwierać lub odtwarzać filmy.
* **Większy zasięg:** Za pomocą wideo możesz dotrzeć do szerokiej publiczności i skierować do niej informacje, które w prezentacji mogłyby wydawać się żmudne. Większość ankiet i statystyk wskazuje, że ludzie oglądają i konsumują wideo częściej niż inne formy treści i zazwyczaj wolą właśnie takie materiały.

## **Konwersja PowerPoint do wideo w Aspose.Slides**

Aspose.Slides obsługuje konwersję prezentacji na wideo.

* Użyj **Aspose.Slides** do wygenerowania zestawu klatek (z slajdów prezentacji), które odpowiadają określonej liczbie FPS (klatek na sekundę)
* Użyj narzędzia zewnętrznego, takiego jak **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)), aby utworzyć wideo na podstawie klatek. 

### **Konwertuj PowerPoint na wideo**

1. Dodaj to do swojego pliku POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Pobierz ffmpeg [tutaj](https://ffmpeg.org/download.html).

3. Uruchom kod Java konwertujący PowerPoint na wideo.

Ten kod Java pokazuje, jak przekonwertować prezentację (zawierającą rysunek i dwa efekty animacji) na wideo:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Dodaje kształt uśmiechu, a następnie animuje go
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

    // Skonfiguruj folder z plikami binarnymi ffmpeg. Zobacz tę stronę: https://github.com/bramp/ffmpeg-cli-wrapper
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

{{% alert color="info" %}} 
Możesz chcieć zobaczyć te artykuły: [Animacja PowerPoint](https://docs.aspose.com/slides/pl/androidjava/powerpoint-animation/), [Animacja kształtu](https://docs.aspose.com/slides/pl/androidjava/shape-animation/), i [Efekt kształtu](https://docs.aspose.com/slides/pl/androidjava/shape-effect/).
{{% /alert %}} 

Animacje i przejścia sprawiają, że pokazy slajdów są bardziej angażujące i interesujące — i mają taki sam efekt wideo. Dodajmy kolejny slajd i przejście do kodu poprzedniej prezentacji:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Prezentacja z animowanym kształtem uśmiechu utworzonym powyżej.
Presentation presentation = new Presentation();
try {
    // Dodaje nowy slajd i animowane przejście

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides obsługuje również animację tekstów. Animujemy więc akapity na obiektach, które pojawiają się kolejno (z opóźnieniem ustawionym na sekundę):

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

    // Skonfiguruj folder z plikami binarnymi ffmpeg. Zobacz tę stronę: https://github.com/bramp/ffmpeg-cli-wrapper
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

Aby umożliwić wykonywanie zadań konwersji PowerPoint na wideo, Aspose.Slides udostępnia klasy **PresentationAnimationsGenerator** i **PresentationPlayer**.

**PresentationAnimationsGenerator** pozwala ustawić rozmiar klatki wideo (które zostanie utworzone później) poprzez konstruktor. Jeśli przekażesz instancję prezentacji, zostanie użyty `Presentation.SlideSize` i generuje animacje, które wykorzystuje **PresentationPlayer**.

Podczas generowania animacji, dla każdej kolejnej animacji generowane jest zdarzenie `NewAnimation`, które posiada parametr **IPresentationAnimationPlayer**. Ten parametr jest klasą reprezentującą odtwarzacz osobnej animacji.

Aby pracować z **IPresentationAnimationPlayer**, używa się właściwości **Duration** (pełny czas trwania animacji) oraz metody **SetTimePosition**. Pozycja każdej animacji jest ustawiana w zakresie *0 do duration*, a metoda `getFrame` zwróci **IImage** odpowiadający stanowi animacji w danym momencie:

```java
import com.aspose.slides.*;

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
            // bitmapa początkowego stanu animacji
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // ostateczny stan animacji
            // ostatnia klatka animacji
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Generuje animacje. Powyższe wywołanie zwrotne uruchamiane jest dla każdej z nich.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aby wszystkie animacje w prezentacji odtwarzały się jednocześnie, używa się klasy **PresentationPlayer**. Klasa ta przyjmuje w konstruktorze instancję **PresentationAnimationsGenerator** oraz FPS dla efektów, a następnie wywołuje zdarzenie `FrameTick` dla wszystkich animacji, aby je odtworzyć:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

Następnie wygenerowane klatki mogą być złożone w wideo. Zobacz sekcję **Convert PowerPoint to Video**.

## **Obsługiwane animacje i efekty**

**Wejście**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pojawienie się** | ![not supported](x.png) | ![supported](v.png) |
| **Znikanie** | ![supported](v.png) | ![supported](v.png) |
| **Latanie do środka** | ![supported](v.png) | ![supported](v.png) |
| **Unoszenie się** | ![supported](v.png) | ![supported](v.png) |
| **Rozdzielenie** | ![supported](v.png) | ![supported](v.png) |
| **Przetarcie** | ![supported](v.png) | ![supported](v.png) |
| **Kształt** | ![supported](v.png) | ![supported](v.png) |
| **Koło** | ![supported](v.png) | ![supported](v.png) |
| **Losowe paski** | ![supported](v.png) | ![supported](v.png) |
| **Rozrost i obrót** | ![not supported](x.png) | ![supported](v.png) |
| **Powiększenie** | ![supported](v.png) | ![supported](v.png) |
| **Obrót** | ![supported](v.png) | ![supported](v.png) |
| **Odbicie** | ![supported](v.png) | ![supported](v.png) |

**Podkreślenie**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulsowanie** | ![not supported](x.png) | ![supported](v.png) |
| **Pulsowanie koloru** | ![not supported](x.png) | ![supported](v.png) |
| **Chwianie** | ![supported](v.png) | ![supported](v.png) |
| **Obrót** | ![supported](v.png) | ![supported](v.png) |
| **Rozrost/kurczenie** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturacja** | ![not supported](x.png) | ![supported](v.png) |
| **Przyciemnienie** | ![not supported](x.png) | ![supported](v.png) |
| **Rozjaśnienie** | ![not supported](x.png) | ![supported](v.png) |
| **Przezroczystość** | ![not supported](x.png) | ![supported](v.png) |
| **Kolor obiektu** | ![not supported](x.png) | ![supported](v.png) |
| **Kolor dopełniający** | ![not supported](x.png) | ![supported](v.png) |
| **Kolor linii** | ![not supported](x.png) | ![supported](v.png) |
| **Kolor wypełnienia** | ![not supported](x.png) | ![supported](v.png) |

**Wyjście**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Znikanie** | ![not supported](x.png) | ![supported](v.png) |
| **Znikanie** | ![supported](v.png) | ![supported](v.png) |
| **Wylot** | ![supported](v.png) | ![supported](v.png) |
| **Unoszenie na zewnątrz** | ![supported](v.png) | ![supported](v.png) |
| **Rozdzielenie** | ![supported](v.png) | ![supported](v.png) |
| **Przetarcie** | ![supported](v.png) | ![supported](v.png) |
| **Kształt** | ![supported](v.png) | ![supported](v.png) |
| **Losowe paski** | ![supported](v.png) | ![supported](v.png) |
| **Kurczenie i obrót** | ![not supported](x.png) | ![supported](v.png) |
| **Powiększenie** | ![supported](v.png) | ![supported](v.png) |
| **Obrót** | ![supported](v.png) | ![supported](v.png) |
| **Odbicie** | ![supported](v.png) | ![supported](v.png) |

**Ścieżki ruchu**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linie** | ![supported](v.png) | ![supported](v.png) |
| **Łuki** | ![supported](v.png) | ![supported](v.png) |
| **Skręty** | ![supported](v.png) | ![supported](v.png) |
| **Kształty** | ![supported](v.png) | ![supported](v.png) |
| **Pętle** | ![supported](v.png) | ![supported](v.png) |
| **Ścieżka niestandardowa** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### Czy istnieje możliwość konwersji prezentacji zabezpieczonych hasłem?

Tak, Aspose.Slides umożliwia pracę z [prezentacjami zabezpieczonymi hasłem](/slides/pl/androidjava/password-protected-presentation/). Podczas przetwarzania takich plików należy podać prawidłowe hasło, aby biblioteka mogła uzyskać dostęp do zawartości prezentacji.

### Czy Aspose.Slides obsługuje użycie w rozwiązaniach chmurowych?

Tak, Aspose.Slides może być integrowany z aplikacjami i usługami w chmurze. Biblioteka została zaprojektowana do pracy w środowiskach serwerowych, zapewniając wysoką wydajność i skalowalność przy przetwarzaniu plików wsadowo.

### Czy istnieją ograniczenia rozmiaru prezentacji podczas konwersji?

Aspose.Slides jest w stanie obsłużyć prezentacje praktycznie dowolnego rozmiaru. Jednak przy pracy z bardzo dużymi plikami mogą być potrzebne dodatkowe zasoby systemowe i czasami zaleca się optymalizację prezentacji w celu poprawy wydajności.