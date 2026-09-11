---
title: Zastosowanie animacji kształtów w prezentacjach przy użyciu Python via Java
linktitle: Animacja kształtu
type: docs
weight: 60
url: /pl/python-java/shape-animation/
keywords:
- kształt
- animacja
- efekt
- animowany kształt
- animowany tekst
- dodaj animację
- pobierz animację
- wyodrębnij animację
- dodaj efekt
- pobierz efekt
- wyodrębnij efekt
- dźwięk efektu
- zastosuj animację
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać, przeglądać i dostosowywać animacje kształtów, czas trwania, dźwięki, zachowanie po animacji oraz animowany tekst przy użyciu Aspose.Slides for Python via Java."
---
## **Przegląd**

Aspose.Slides for Python via Java przedstawia animacje slajdów jako efekty na osi czasu slajdu. Efekt ma docelowy kształt, typ i podtyp animacji, wyzwalacz, ustawienia czasu oraz opcjonalne właściwości, takie jak dźwięk lub zachowanie po zakończeniu animacji.

Oś czasu zawiera dwa rodzaje sekwencji:

- **główna sekwencja** odtwarzana jest podczas przechodzenia do slajdu.
- **sekcja interaktywna** rozpoczyna się po kliknięciu kształtu wyzwalającego.

Ponieważ pola tekstowe, obrazy, wykresy, tabele i inne obiekty slajdu dziedziczą po [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/), do większości treści slajdu używasz tej samej metody [Sequence.addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect). Dostępne efekty są wymienione w klasie [EffectType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effecttype/).

## **Dodaj animacje kształtów**

Aby dodać animację, pobierz główną sekwencję slajdu i wywołaj [Sequence.addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect) z docelowym kształtem, typem efektu, podtypem i wyzwalaczem. Dla efektu, który rozpoczyna się po kliknięciu innego kształtu, utwórz sekcję interaktywną, której wyzwalaczem jest ten inny kształt.

Poniższy przykład tworzy oba typy animacji i zapisuje wynik jako `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wyzwalacz określa, kiedy efekt się rozpoczyna:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effecttriggertype/#OnClick) czeka na kliknięcie w głównej sekwencji lub na kliknięcie kształtu wyzwalającego w sekcji interaktywnej.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effecttriggertype/#WithPrevious) rozpoczyna się wraz z poprzednim efektem.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effecttriggertype/#AfterPrevious) rozpoczyna się po zakończeniu poprzedniego efektu.

Aby animować obraz, wykres lub inny rodzaj kształtu, przekaż ten obiekt do [Sequence.addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect) zamiast `target_shape`. Opcje grupowania specyficzne dla wykresów znajdziesz w sekcji [Animated Charts](/slides/pl/python-java/animated-charts/).

## **Odczyt animacji kształtów**

Użyj [Sequence.getEffectsByShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#getEffectsByShape), gdy znasz docelowy kształt. Aby przejrzeć wszystkie efekty, wyliczaj główną sekwencję oraz każdą sekcję interaktywną. Wyliczanie eliminuje założenie, że w sekwencji znajduje się efekt pod indeksem `0`.

Poniższy przykład tworzy kształt z efektami w głównej i interaktywnej sekwencji, pobiera efekty skierowane do tego kształtu, a następnie wylicza każdą sekwencję na slajdzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Jeśli potrzebujesz efektów tylko dla jednego kształtu, najpierw zidentyfikuj kształt po nazwie, typie placeholdera lub innej stabilnej właściwości; następnie wywołaj [Sequence.getEffectsByShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#getEffectsByShape). Nie zakładaj, że [ShapeCollection.get_Item](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#get_Item) pod indeksem `0` zawsze jest pożądanym obiektem.

## **Praca z odziedziczonymi efektami placeholderów**

Placeholder na normalnym slajdzie może odziedziczyć zachowanie animacji z odpowiedniego placeholdera na slajdzie układu oraz slajdzie głównym. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getBasePlaceholder) zwraca ten nadrzędny placeholder lub `None`, jeśli nie istnieje.

W przykładowej prezentacji stopka ma **Random Bars** na normalnym slajdzie, **Split** na slajdzie układu i **Fly In** na slajdzie głównym.

![Efekt animacji stopki na normalnym slajdzie](slide-shape-animation.png)

![Efekt animacji placeholdera stopki na slajdzie układu](layout-shape-animation.png)

![Efekt animacji placeholdera stopki na slajdzie głównym](master-shape-animation.png)

Następny przykład używa hierarchii placeholderów w nowej prezentacji. Dodaje efekty do placeholdera w masterze, placeholdera w układzie i odpowiadającego mu placeholdera na normalnym slajdzie. Każde wywołanie [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getBasePlaceholder) jest sprawdzane przed użyciem zwróconego kształtu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zmiana czasu animacji**

Okno dialogowe PowerPoint **Timing** mapuje się na właściwości klasy [Timing](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/).

![Okno dialogowe PowerPoint Timing dla efektu animacji](shape-animation.png)

- **Start** mapuje się na [Timing.getTriggerType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** mapuje się na [Timing.getDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getDuration) w sekundach.
- **Delay** mapuje się na [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getTriggerDelayTime) w sekundach.
- **Repeat** mapuje się na [Timing.getRepeatCount](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getRepeatUntilNextClick) lub [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** mapuje się na [Timing.getRewind](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#getRewind).

Ten niezależny przykład dodaje efekt, zmienia jego czas za pomocą obiektu zwróconego przez [Sequence.addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect) i zapisuje wynik. Przechowywanie referencji zwróconego [Effect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/) zapobiega niepotrzebnemu użyciu indeksu kolekcji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Używaj jednego trybu powtarzania zamierzenie. Łączenie liczby powtórzeń z flagą „until” może powodować mylące wyniki w różnych odtwarzaczach. Przy zmianie trybów powtarzania ustaw najpierw [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#setRepeatUntilNextClick) i [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#setRepeatUntilEndSlide), a dopiero potem [Timing.setRepeatCount](https://reference.aspose.com/slides/pl/python-java/aspose.slides/timing/#setRepeatCount), ponieważ ustawienie którejkolwiek flagi zmienia także aktywny tryb powtarzania.

## **Dodawanie i wyodrębnianie dźwięków animacji**

Efekt animacji może odwoływać się do osadzonego dźwięku przy użyciu [Effect.getSound](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/#setStopPreviousSound) nakazuje efektowi zatrzymać dźwięk rozpoczęty przez wcześniejszy efekt.

### **Dodaj dźwięk do efektu**

Poniższy przykład wymaga lokalnego pliku audio o nazwie `animation-sound.wav`. Tworzy dwa efekty, osadza ten plik jako dźwięk pierwszego efektu i konfiguruje drugi efekt, aby zatrzymał dźwięk. Używa obiektów zwróconych przez [Sequence.addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect), więc nie jest wymagany indeks sekwencji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Wyodrębnij osadzone dźwięki efektów**

Poniższy przykład wymaga lokalnej prezentacji o nazwie `presentation-with-animation-sounds.pptx`. Przeszukuje zarówno główną, jak i interaktywną sekwencję i zapisuje każdy osadzony dźwięk efektu do katalogu `extracted-animation-sounds`. Rozszerzenie jest wybierane na podstawie typu MIME audio zwracanego przez [Audio.getContentType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

W przypadku dużych obiektów audio użyj [Audio.getStream](https://reference.aspose.com/slides/pl/python-java/aspose.slides/audio/#getStream) i skopiuj strumień do pliku zamiast ładować cały obiekt do tablicy bajtów.

## **Ustaw zachowanie po animacji**

Opcja **After animation** określa, co sta się z kształtem po zakończeniu jego efektu.

![Okno dialogowe PowerPoint Effect Options z ustawieniami After animation](shape-after-animation.png)

Klasa [AfterAnimationType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/afteranimationtype/) umożliwia pozostawienie kształtu niezmienionego, zmianę jego koloru, ukrycie po animacji lub ukrycie przy następnym kliknięciu. Gdy typ jest [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/python-java/aspose.slides/afteranimationtype/#Color), należy także ustawić [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/#getAfterAnimationColor).

Ten niezależny przykład tworzy efekt, ustawia jego zachowanie po animacji za pomocą zwróconego obiektu efektu i zapisuje wynik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zmiana typu z [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/python-java/aspose.slides/afteranimationtype/#Color) usuwa ustawienie koloru po animacji.

## **Animowanie tekstu**

Animacja tekstu ma dwa powiązane sterowania:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textanimation/#getBuildType) określa, czy akapity pojawiają się razem, czy poziomowo.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/#getAnimateTextType) określa, czy tekst pojawia się jednorazowo, słowo po słowie lub litera po literze. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/effect/#getDelayBetweenTextParts) ustawia opóźnienie między słowami lub literami. Wartość dodatnia jest procentem czasu trwania efektu; wartość ujemna oznacza opóźnienie w sekundach.

Poniższy niezależny przykład animuje słowa w polu tekstowym. [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/python-java/aspose.slides/buildtype/#AsOneObject) wyłącza budowanie akapitu po akapicie, tak aby ustawienie słów obowiązywało dla całej ramki tekstowej.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby budować pole tekstowe akapit po akapicie, ustaw [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/pl/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (lub inny poziom akapitu). Aby skierować pojedynczy akapit własnym efektem, użyj przeciążenia [Sequence.addEffect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sequence/#addEffect), które przyjmuje [Paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/). Zobacz [Animated Text](/slides/pl/python-java/animated-text/) po przykłady na poziomie akapitu.

## **Eksport i uwagi dotyczące kompatybilności**

- Zapis do PPT lub PPTX zachowuje model animacji, ale ostateczne odtwarzanie kontroluje przeglądarka prezentacji.
- PDF i obrazy statyczne nie odtwarzają animacji. Użyj [eksportu HTML5](/slides/pl/python-java/export-to-html5/), animowanego GIF‑a lub [konwersji wideo](/slides/pl/python-java/convert-powerpoint-to-video/), gdy wyjście musi pokazywać ruch.
- Dla HTML5 włącz [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/#setAnimateShapes) i, w razie potrzeby, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/html5options/#setAnimateTransitions).
- Renderowanie wideo obsługuje wiele popularnych efektów wejścia, podkreślenia, wyjścia i ścieżek ruchu, ale nie wszystkie efekty PowerPoint są wspierane. Sprawdź aktualną listę [wspieranych animacji i efektów](/slides/pl/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) i przetestuj krytyczne prezentacje z docelową wersją Aspose.Slides.
- Zaawansowane efekty niestandardowe oraz efekty zaimportowane z innych formatów mogą być zachowane w pliku, ale renderują się inaczej w PowerPoint, HTML5 lub wideo. Zweryfikuj wyeksportowany wynik zamiast polegać wyłącznie na nazwie efektu.

## **FAQ**

**Dlaczego animacja pojawia się w PowerPoint, a nie w PDF?**

PDF jest formatem statycznym, więc animacje i przejścia slajdów nie są odtwarzane. Eksportuj do HTML5, animowanego GIF‑a lub wideo, gdy ruch musi być zachowany.

**Dlaczego efekt odtwarza się inaczej w wideo?**

Eksport wideo renderuje animacje zamiast przechowywać oryginalne zachowanie PowerPoint. Niektóre zaawansowane efekty nie są obsługiwane lub są przybliżane. Przejrzyj tabelę wspieranych efektów i przetestuj rzeczywistą prezentację przed użyciem w produkcji.

**Czy przeniesienie kształtu do przodu lub do tyłu zmienia kolejność jego animacji?**

Nie. Z‑order kształtu kontroluje nakładanie się, natomiast kolejność sekwencji i wyzwalacze kontrolują odtwarzanie animacji. Zmodyfikuj oś czasu, jeśli potrzebujesz innej kolejności odtwarzania.