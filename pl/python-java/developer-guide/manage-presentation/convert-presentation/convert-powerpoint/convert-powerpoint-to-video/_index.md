---
title: Konwertuj prezentacje PowerPoint na wideo w Pythonie
linktitle: PowerPoint na wideo
type: docs
weight: 130
url: /pl/python-java/convert-powerpoint-to-video/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na wideo
- prezentacja na wideo
- PPT na wideo
- PPTX na wideo
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
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint na wideo MP4 w Pythonie przy użyciu Javy. Generuj klatki przy użyciu Aspose.Slides i koduj je za pomocą FFmpeg, w tym animacje i przejścia."
---
## **Przegląd**

Konwertowanie prezentacji PowerPoint lub OpenDocument na wideo pozwala widzom oglądać jej zawartość w odtwarzaczu wideo bez otwierania aplikacji do prezentacji. Aspose.Slides for Python via Java renderuje animacje i przejścia prezentacji do klatek obrazu. Oddzielny enkoder, taki jak FFmpeg, łączy te klatki w plik wideo.

{{% alert color="info" title="Uwaga" %}}
Wypróbuj internetowy konwerter PowerPoint do wideo, aby zobaczyć konwersję prezentacji na wideo w działaniu.
{{% /alert %}}

## **Konwertuj PowerPoint na wideo**

Konwersja składa się z dwóch etapów: generowanie klatek PNG w wybranej liczbie klatek na sekundę, a następnie kodowanie sekwencji obrazów do formatu MP4. Użyj tej samej liczby klatek na sekundę w obu etapach, aby zachować synchronizację animacji.

Przed uruchomieniem przykładu:

1. Zainstaluj [Aspose.Slides for Python via Java](/slides/pl/python-java/installation/).
2. Pobierz [FFmpeg](https://ffmpeg.org/download.html) i udostępnij jego plik wykonywalny w zmiennej `PATH`. Przykład używa wersji z enkoderem `libx264`.
3. Uruchom poniższy kod Pythona w zapisywalnym katalogu.

Przykład tworzy uśmiechający się kształt z animacjami wejścia i wyjścia, renderuje klatki w 30 FPS i wywołuje FFmpeg, aby stworzyć `output.mp4`. Nowy katalog klatek zapobiega uwzględnieniu klatek z wcześniejszych uruchomień w wideo.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

Aby przekonwertować istniejący plik, zainicjalizuj [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) z jego ścieżką i pomiń instrukcje tworzenia kształtu oraz animacji.

Polecenie FFmpeg odczytuje numerowaną [sekwencję obrazów](https://ffmpeg.org/ffmpeg-formats.html#image2), wyrównuje nieparzyste wymiary do wartości parzystych i zapisuje wideo H.264 w formacie pikseli `yuv420p`. Opcja `-n` zapobiega nadpisaniu istniejącego pliku wyjściowego. Wygenerowane pliki PNG pozostają w katalogu klatek; usuń je, gdy nie będą już potrzebne.

{{% alert color="info" title="Uwaga" %}}
Ten przykład koduje tylko klatki obrazu. Nie dodaje narracji ani wbudowanego dźwięku prezentacji do wideo wyjściowego.
{{% /alert %}}

## **Efekty wideo**

Animacje kontrolują, jak obiekty slajdu pojawiają się, poruszają lub znikają. Przejścia kontrolują zmianę pomiędzy slajdami. Dodaj te efekty przed generowaniem klatek wideo.

Zobacz [PowerPoint Animation](/slides/pl/python-java/powerpoint-animation/), [Shape Animation](/slides/pl/python-java/shape-animation/), [Shape Effects](/slides/pl/python-java/shape-effect/), oraz [Slide Transitions](/slides/pl/python-java/slide-transition/).

### **Dodaj przejście slajdu**

Poniższy samodzielny przykład tworzy prezentację z dwoma slajdami. Drugi slajd ma magentowe tło i przejście typu push. Zapisz prezentację, a następnie użyj jej jako wejścia do powyższego przykładu generowania klatek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Animuj akapity**

Tekst może pojawiać się akapit po akapicie. Ten przykład tworzy trzy akapity z kolejnymi efektami stopniowego pojawiania się, każdy opóźniony o jedną sekundę po poprzednim efekcie. Użyj zapisanego pliku `paragraphs.pptx` jako wejścia do przykładu konwersji wideo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klasy konwersji wideo**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationanimationsgenerator/) generuje zdarzenia animacji dla slajdów. Tworzenie go na podstawie prezentacji używa rozmiaru slajdu prezentacji dla klatek. Użyj [setDefaultDelay](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay), aby skonfigurować domyślne opóźnienie w milisekundach.

[PresentationPlayer](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationplayer/) pobiera próbki wygenerowanych animacji przy zadanej liczbie klatek na sekundę podanej w konstruktorze. Zarejestruj wywołanie zwrotne Pythona poprzez JPype za pomocą [setFrameTick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationplayer/#setFrameTick), a następnie wywołaj [run](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationanimationsgenerator/#run), aby wygenerować klatki. Pierwszy przykład używa własnego licznika zerowego, aby nazwy plików odpowiadały sekwencji wejściowej FFmpeg.

Do obsługi poszczególnych stanów animacji zarejestruj wywołanie zwrotne za pomocą [setNewAnimation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). Wywołanie zwrotne otrzymuje odtwarzacz animacji, który można ustawić na wybrany moment czasu. Poniższy przykład zapisuje pierwszą i ostatnią klatkę każdej wygenerowanej animacji pod unikalnymi nazwami plików:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **Obsługiwane animacje i efekty**

Poniższe tabele podsumowują wsparcie renderowania opisane w artykule konwersji Java. Podglądaj wygenerowane klatki, gdy prezentacja używa efektów, które nie są obsługiwane.

**Wejście**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pojawienie się** | No | Yes |
| **Zanik** | Yes | Yes |
| **Lot w wewnątrz** | Yes | Yes |
| **Unoszenie** | Yes | Yes |
| **Podział** | Yes | Yes |
| **Wymazywanie** | Yes | Yes |
| **Kształt** | Yes | Yes |
| **Koło** | Yes | Yes |
| **Losowe paski** | Yes | Yes |
| **Rozszerzanie i obrót** | No | Yes |
| **Powiększenie** | Yes | Yes |
| **Obrót** | Yes | Yes |
| **Odbicie** | Yes | Yes |

**Podkreślenie**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Puls** | No | Yes |
| **Puls koloru** | No | Yes |
| **Trzęsienie się** | Yes | Yes |
| **Obrót** | Yes | Yes |
| **Powiększanie/Zmniejszanie** | No | Yes |
| **Desaturacja** | No | Yes |
| **Przyciemnienie** | No | Yes |
| **Rozjaśnienie** | No | Yes |
| **Przezroczystość** | No | Yes |
| **Kolor obiektu** | No | Yes |
| **Kolor dopełniający** | No | Yes |
| **Kolor linii** | No | Yes |
| **Kolor wypełnienia** | No | Yes |

**Wyjście**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Znikanie** | No | Yes |
| **Zanik** | Yes | Yes |
| **Lot na zewnątrz** | Yes | Yes |
| **Unoszenie na zewnątrz** | Yes | Yes |
| **Podział** | Yes | Yes |
| **Wymazywanie** | Yes | Yes |
| **Kształt** | Yes | Yes |
| **Losowe paski** | Yes | Yes |
| **Kurczenie i obrót** | No | Yes |
| **Powiększenie** | Yes | Yes |
| **Obrót** | Yes | Yes |
| **Odbicie** | Yes | Yes |

**Ścieżki ruchu**:

| Typ animacji | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linie** | Yes | Yes |
| **Łuki** | Yes | Yes |
| **Obroty** | Yes | Yes |
| **Kształty** | Yes | Yes |
| **Pętle** | Yes | Yes |
| **Ścieżka niestandardowa** | Yes | Yes |

## **FAQ**

**Czy Aspose.Slides tworzy plik MP4 bezpośrednio?**

Nie. Aspose.Slides generuje klatki prezentacji. Użyj enkodera wideo, takiego jak FFmpeg, aby połączyć je w plik MP4.

**Dlaczego wideo odtwarza się szybciej lub wolniej niż oczekiwano?**

Użyj tej samej liczby klatek na sekundę zarówno przy generowaniu klatek, jak i przy podawaniu klatek do enkodera. Niezgodność zmienia czas odtwarzania sekwencji obrazów.

**Czy mogę przekonwertować zabezpieczoną hasłem prezentację?**

Tak. Podaj prawidłowe hasło podczas [ładowania zabezpieczonej prezentacji](/slides/pl/python-java/password-protected-presentation/), a następnie wygeneruj klatki z wczytanej zawartości.

**Czy ten proces zachowuje dźwięk prezentacji?**

Przykłady eksportują tylko klatki obrazu, więc powstałe wideo jest bez dźwięku. Aby dodać dźwięk, należy osobno dostarczyć ścieżkę audio podczas kodowania wideo.

**Jak mogę zmniejszyć tymczasowe zużycie dysku?**

Użyj mniejszego rozmiaru klatek lub niższej liczby FPS i usuń tymczasowe pliki PNG po pomyślnym kodowaniu. Sprawdź jakość powstałego wideo przy zmniejszaniu któregokolwiek z tych parametrów.