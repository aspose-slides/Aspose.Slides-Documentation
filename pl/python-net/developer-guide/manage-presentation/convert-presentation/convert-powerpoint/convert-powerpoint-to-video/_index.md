---
title: Konwertowanie prezentacji PowerPoint na wideo w Pythonie
linktitle: PowerPoint do wideo
type: docs
weight: 130
url: /pl/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint do wideo
- konwertować PowerPoint do wideo
- prezentacja do wideo
- konwertować prezentację do wideo
- PPT do wideo
- konwertować PPT do wideo
- PPTX do wideo
- konwertować PPTX do wideo
- ODP do wideo
- konwertować ODP do wideo
- PowerPoint do MP4
- konwertować PowerPoint do MP4
- prezentacja do MP4
- konwertować prezentację do MP4
- PPT do MP4
- konwertować PPT do MP4
- PPTX do MP4
- konwertować PPTX do MP4
- konwersja PowerPoint do wideo
- konwersja prezentacji do wideo
- konwersja PPT do wideo
- konwersja PPTX do wideo
- konwersja ODP do wideo
- konwersja wideo w Pythonie
- PowerPoint
- Python
- Aspose.Slides
description: "Dowiedz się, jak konwertować prezentacje PowerPoint i OpenDocument na wideo przy użyciu Pythona. Odkryj przykładowy kod i techniki automatyzacji, aby usprawnić swój przepływ pracy."
---
## **Wprowadzenie**

Konwertując swoją prezentację PowerPoint lub OpenDocument na wideo, zyskujesz:

**Zwiększona dostępność:** Wszystkie urządzenia, niezależnie od platformy, są domyślnie wyposażone w odtwarzacze wideo, co ułatwia użytkownikom otwieranie lub odtwarzanie filmów w porównaniu z tradycyjnymi aplikacjami do prezentacji.

**Szerszy zasięg:** Filmy pozwalają dotrzeć do większej liczby odbiorców i prezentować informacje w bardziej angażującym formacie. Badania i statystyki wskazują, że ludzie wolą oglądać i konsumować treści wideo niż inne formy, co zwiększa wpływ Twojego przekazu.

{{% alert color="primary" %}} 
Sprawdź nasz [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/pl/video), ponieważ oferuje on działające i skuteczne wdrożenie procesu opisanego tutaj.
{{% /alert %}} 

W [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/pl/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/), wprowadziliśmy obsługę konwersji prezentacji na wideo.

* Użyj Aspose.Slides for Python, aby generować klatki z slajdów prezentacji ze wskazaną liczbą klatek na sekundę (FPS).
* Następnie użyj zewnętrznego narzędzia, takiego jak ffmpeg, aby złożyć te klatki w wideo.

## **Konwertuj prezentację PowerPoint na wideo**

1. Użyj polecenia pip install, aby dodać Aspose.Slides for Python do projektu: `pip install aspose-slides==24.4.0`
2. Pobierz ffmpeg z [tutaj](https://ffmpeg.org/download.html) lub zainstaluj go za pomocą menedżera pakietów.
3. Upewnij się, że ffmpeg znajduje się w zmiennej `PATH`. W przeciwnym razie uruchom ffmpeg, podając pełną ścieżkę do pliku wykonywalnego (np. `C:\ffmpeg\ffmpeg.exe` w systemie Windows lub `/opt/ffmpeg/ffmpeg` w systemie Linux).
4. Uruchom kod konwertujący PowerPoint na wideo.

Ten kod w Pythonie demonstruje, jak przekonwertować prezentację (zawierającą kształt i dwa efekty animacji) na wideo:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **Efekty wideo**

Podczas konwertowania prezentacji PowerPoint na wideo przy użyciu Aspose.Slides for Python możesz zastosować różne efekty wideo, aby poprawić jakość wizualną rezultatu. Efekty te pozwalają kontrolować wygląd slajdów w finalnym wideo, dodając płynne przejścia, animacje i inne elementy wizualne. W tej sekcji wyjaśniono dostępne opcje efektów wideo oraz przedstawiono ich zastosowanie.

{{% alert color="primary" %}} 
Zobacz [PowerPoint Animation](https://docs.aspose.com/slides/pl/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/pl/python-net/shape-animation/), oraz [Shape Effect](https://docs.aspose.com/slides/pl/python-net/shape-effect/).
{{% /alert %}} 

Animacje i przejścia sprawiają, że pokazy slajdów są bardziej angażujące i interesujące — to samo dotyczy wideo. Dodajmy kolejny slajd i przejście do kodu poprzedniej prezentacji:

```python
import aspose.pydrawing as drawing

# Dodaj kształt uśmiechu i animuj go.
# ...

# Dodaj nowy slajd i animowane przejście.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python obsługuje także animacje tekstu. W tym przykładzie animujemy akapity na obiektach tak, aby pojawiały się kolejno, z jednosekundowym opóźnieniem między nimi:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj tekst i animacje.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # Konwertuj klatki na wideo.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **Klasy konwersji wideo**

Aby umożliwić zadania konwersji PowerPoint na wideo, Aspose.Slides for Python udostępnia [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` pozwala ustawić rozmiar klatki wideo (która zostanie utworzona później) oraz wartość FPS (klatek na sekundę) poprzez konstruktor. Jeśli przekażesz instancję prezentacji, użyty zostanie jej `Presentation.SlideSize`.

Aby wszystkie animacje w prezentacji odtworzyły się jednocześnie, użyj metody `PresentationEnumerableFramesGenerator.enumerate_frames`. Metoda ta przyjmuje kolekcję slajdów i kolejno zwraca [EnumerableFrameArgs](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/enumerableframeargs/). Następnie użyj `EnumerableFrameArgs.get_frame()` aby uzyskać każdą klatkę wideo.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

Następnie wygenerowane klatki mogą być złożone w wideo. Po więcej szczegółów zobacz sekcję [Convert PowerPoint to Video](https://docs.aspose.com/slides/pl/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Obsługiwane animacje i efekty**

Podczas konwertowania prezentacji PowerPoint na wideo przy użyciu Aspose.Slides for Python ważne jest zrozumienie, które animacje i efekty są obsługiwane w rezultacie. Aspose.Slides obsługuje szeroką gamę typowych efektów wejścia, wyjścia i podkreślenia, takich jak zanikanie, przelot, przybliżenie i obrót. Niektóre zaawansowane lub niestandardowe animacje mogą nie być w pełni zachowane lub mogą wyglądać inaczej w finalnym wideo. Poniżej przedstawiono obsługiwane animacje i efekty.

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

**Zakończenie**:

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

## **Ścieżki ruchu:**

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Obsługiwane efekty przejść slajdów**

Efekty przejść slajdów odgrywają ważną rolę w tworzeniu płynnych i atrakcyjnych wizualnie zmian pomiędzy slajdami w wideo. Aspose.Slides for Python obsługuje różnorodne, powszechnie używane efekty przejść, aby pomóc zachować przepływ i styl oryginalnej prezentacji. Poniżej zestawiono, które efekty przejść są wspierane podczas konwersji.

**Delikatne**:

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

**Czy możliwe jest konwertowanie prezentacji chronionych hasłem?**

Tak, Aspose.Slides for Python pozwala pracować z prezentacjami zabezpieczonymi hasłem. Podczas przetwarzania takich plików należy podać prawidłowe hasło, aby biblioteka mogła uzyskać dostęp do zawartości prezentacji.

**Czy Aspose.Slides for Python wspiera użycie w rozwiązaniach chmurowych?**

Tak, Aspose.Slides for Python może być zintegrowany z aplikacjami i usługami chmurowymi. Biblioteka jest zaprojektowana z myślą o środowiskach serwerowych, zapewniając wysoką wydajność i skalowalność przy przetwarzaniu plików wsadowo.

**Czy istnieją ograniczenia rozmiaru prezentacji podczas konwersji?**

Aspose.Slides for Python jest w stanie obsłużyć prezentacje praktycznie dowolnego rozmiaru. Jednak przy pracy z bardzo dużymi plikami może być konieczne większe użycie zasobów systemowych i czasami zaleca się optymalizację prezentacji w celu poprawy wydajności.