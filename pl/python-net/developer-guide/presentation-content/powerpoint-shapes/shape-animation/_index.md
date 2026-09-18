---
title: Zastosowanie animacji kształtów w prezentacjach przy użyciu Pythona
linktitle: Animacja kształtu
type: docs
weight: 60
url: /pl/python-net/shape-animation/
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
- Aspose.Slides
description: "Dowiedz się, jak dodawać, przeglądać i dostosowywać animacje kształtów, ich czas, dźwięki, zachowanie po animacji oraz animowany tekst za pomocą Aspose.Slides dla Pythona poprzez .NET."
---
## **Przegląd**

Aby pracować z poszczególnymi zachowaniami wewnątrz efektu lub edytować segmenty trasy ruchu, zobacz [Custom Animation](/slides/pl/python-net/custom-animation/).

Aspose.Slides for Python via .NET reprezentuje animacje slajdów jako efekty na osi czasu slajdu. Efekt posiada docelowy kształt, typ i podtyp animacji, wyzwalacz, ustawienia czasu oraz opcjonalne właściwości, takie jak dźwięk lub zachowanie po animacji.

Linia czasowa zawiera dwa rodzaje sekwencji:

- **Główna sekwencja** odtwarzana jest podczas przechodzenia slajdu.
- **Sekwencja interaktywna** rozpoczyna się, gdy jej kształt wyzwalający zostanie kliknięty.

Ponieważ pola tekstowe, obrazy, wykresy, tabele i inne obiekty slajdu implementują [IShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishape/), używasz tej samej metody [Sequence.add_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/add_effect/) dla większości treści slajdu. Dostępne efekty są wymienione w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttype/).

## **Dodawanie animacji kształtów**

Aby dodać animację, pobierz główną sekwencję slajdu i wywołaj [Sequence.add_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/add_effect/) z docelowym kształtem, typem efektu, podtypem i wyzwalaczem. Dla efektu, który zaczyna się po kliknięciu innego kształtu, utwórz sekwencję interaktywną, której wyzwalaczem jest ten inny kształt.

Poniższy przykład tworzy oba typy animacji i zapisuje wynik do `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

Wyzwalacz kontroluje, kiedy efekt się rozpoczyna:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttriggertype/) oczekuje na kliknięcie w głównej sekwencji lub na kliknięcie kształtu wyzwalającego w sekwencji interaktywnej.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttriggertype/) rozpoczyna się razem z poprzedzającym efektem.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttriggertype/) rozpoczyna się po zakończeniu poprzedzającego efektu.

Aby animować obraz, wykres lub inny rodzaj kształtu, przekaż ten obiekt do [Sequence.add_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/add_effect/) zamiast `target_shape`. Opcje grupowania specyficzne dla wykresów znajdziesz w sekcji [Animated Charts](/slides/pl/python-net/animated-charts/).

## **Odczytywanie animacji kształtów**

Użyj [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/get_effects_by_shape/), gdy znasz docelowy kształt. Aby przejrzeć każdy efekt, iteruj po głównej sekwencji i po każdej sekwencji interaktywnej. Iteracja zapobiega przyjmowaniu, że sekwencja zawiera efekt pod indeksem `0`.

Poniższy przykład tworzy kształt z efektami w głównej i interaktywnej sekwencji, pobiera efekty skierowane do tego kształtu i następnie iteruje po każdej sekwencji na slajdzie.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Jeśli potrzebujesz efektów tylko dla jednego kształtu, najpierw zidentyfikuj kształt po nazwie, typie symbolu zastępczego lub innej stabilnej właściwości; potem wywołaj [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Nie zakładaj, że kształt pod indeksem `0` jest zawsze pożądanym obiektem.

## **Praca z dziedziczonymi efektami symboli zastępczych**

Symbol zastępczy na normalnym slajdzie może dziedziczyć zachowanie animacji z odpowiadającego mu symbolu zastępczego na slajdzie układu i slajdzie nadrzędnym. [Shape.get_base_placeholder](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_base_placeholder/) zwraca ten nadrzędny symbol, lub `None`, gdy nie istnieje rodzic.

W poniższej przykładowej prezentacji stopka ma **Random Bars** na normalnym slajdzie, **Split** na slajdzie układu i **Fly In** na slajdzie nadrzędnym.

![Efekt animacji stopki na normalnym slajdzie](slide-shape-animation.png)

![Efekt animacji stopki na slajdzie układu](layout-shape-animation.png)

![Efekt animacji stopki na slajdzie nadrzędnym](master-shape-animation.png)

Kolejny przykład buduje samą hierarchię symboli zastępczych. Dodaje efekty do symbolu głównego, symbolu układu i odpowiadającego mu symbolu na normalnym slajdzie. Każde wywołanie [Shape.get_base_placeholder](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_base_placeholder/) jest sprawdzane przed użyciem zwróconego kształtu.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmiana czasu animacji**

Okno dialogowe PowerPoint **Timing** odpowiada właściwościom [Timing](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/).

![Okno dialogowe PowerPoint Timing dla efektu animacji](shape-animation.png)

- **Start** odpowiada [Timing.trigger_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duration** odpowiada [Timing.duration](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/duration/), w sekundach.
- **Delay** odpowiada [Timing.trigger_delay_time](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/trigger_delay_time/), w sekundach.
- **Repeat** odpowiada [Timing.repeat_count](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_until_next_click/), lub [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Rewind when done playing** odpowiada [Timing.rewind](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/rewind/).

Ten niezależny przykład dodaje efekt, zmienia jego czas za pośrednictwem obiektu zwróconego przez [Sequence.add_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/add_effect/), i zapisuje wynik. Przechowywanie zwróconego odnośnika do [Effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/) zapobiega niepotrzebnemu odwołaniu do indeksu kolekcji.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Używaj jednego trybu powtarzania zamierzenie. Łączenie liczby powtórzeń z flagą „until” może powodować mylące wyniki w różnych odtwarzaczach. Przy zmianie trybów powtarzania najpierw ustaw [Timing.repeat_until_next_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_until_next_click/) i [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), a dopiero potem [Timing.repeat_count](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/timing/repeat_count/), ponieważ ustawienie którejkolwiek flagi zmienia także aktywny tryb powtarzania.

## **Dodawanie i wyodrębnianie dźwięków animacji**

Efekt animacji może odwoływać się do osadzonego dźwięku za pośrednictwem [Effect.sound](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/stop_previous_sound/) instruuje efekt, aby zatrzymał dźwięk rozpoczęty przez wcześniejszy efekt.

### **Dodaj dźwięk do efektu**

Poniższy przykład oczekuje lokalnego pliku audio o nazwie `animation-sound.wav`. Tworzy dwa efekty, osadza ten plik jako dźwięk dla pierwszego efektu i konfiguruje drugi efekt, aby zatrzymał dźwięk. Używa obiektów zwróconych przez [Sequence.add_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/add_effect/), więc nie jest wymagany indeks sekwencji.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Wyodrębnij osadzone dźwięki efektów**

Poniższy przykład oczekuje lokalnej prezentacji o nazwie `presentation-with-animation-sounds.pptx`. Przeszukuje zarówno główne, jak i interaktywne sekwencje i zapisuje każdy osadzony dźwięk efektu do katalogu `extracted-animation-sounds`. Rozszerzenie jest wybierane na podstawie typu MIME audio udostępnianego przez [Audio.content_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Dla dużych obiektów audio użyj [Audio.get_stream](https://reference.aspose.com/slides/pl/python-net/aspose.slides/audio/get_stream/) i skopiuj strumień do pliku zamiast ładować cały obiekt do tablicy bajtów.

## **Ustaw zachowanie po animacji**

Opcja **After animation** kontroluje, co się dzieje z kształtem po zakończeniu jego efektu.

![Okno dialogowe PowerPoint Effect Options pokazujące ustawienia After animation](shape-after-animation.png)

Wyliczenie [AfterAnimationType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/afteranimationtype/) obsługuje pozostawienie kształtu niezmienionego, zmianę jego koloru, ukrycie go po animacji lub ukrycie przy następnym kliknięciu. Gdy typ to [AfterAnimationType.COLOR](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/afteranimationtype/), ustaw także [Effect.after_animation_color](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/after_animation_color/).

Ten niezależny przykład tworzy efekt, ustawia jego zachowanie po animacji poprzez zwrócony obiekt efektu i zapisuje wynik.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

Zmienienie typu z [AfterAnimationType.COLOR](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/afteranimationtype/) usuwa ustawienie koloru po animacji.

## **Animowanie tekstu**

Animacja tekstu ma dwa powiązane kontrolki:

- [TextAnimation.build_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/textanimation/build_type/) kontroluje, czy akapity pojawiają się razem, czy poziomowo.
- [Effect.animate_text_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/animate_text_type/) kontroluje, czy tekst pojawia się jednocześnie, słowo po słowie lub litera po literze. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effect/delay_between_text_parts/) ustawia opóźnienie między słowami lub literami. Wartość dodatnia to procent czasu trwania efektu; wartość ujemna to opóźnienie w sekundach.

Poniższy niezależny przykład animuje słowa w polu tekstowym. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/buildtype/) wyłącza budowanie akapit po akapicie, tak aby ustawienie słowa obowiązywało dla całej ramki tekstowej.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Aby budować pole tekstowe akapit po akapicie, ustaw [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/buildtype/) (lub inny poziom akapitu). Aby skierować pojedynczy akapit z własnym efektem, użyj przeciążenia [Sequence.add_effect](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/add_effect/), które przyjmuje [IParagraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iparagraph/). Zobacz [Animated Text](/slides/pl/python-net/animated-text/) po przykłady na poziomie akapitu.

## **Uwagi dotyczące eksportu i kompatybilności**

- Zapis do PPT lub PPTX zachowuje model animacji, ale ostateczne odtwarzanie kontrolowane jest przez przeglądarkę prezentacji.
- PDF i obrazy statyczne nie odtwarzają animacji. Użyj [HTML5 export](/slides/pl/python-net/export-to-html5/), animowanego GIFa lub [video conversion](/slides/pl/python-net/convert-powerpoint-to-video/), gdy wyjście musi pokazywać ruch.
- Dla HTML5 włącz [Html5Options.animate_shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/animate_shapes/) i, w razie potrzeby, [Html5Options.animate_transitions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/animate_transitions/).
- Renderowanie wideo obsługuje wiele popularnych efektów wejścia, podkreślenia, wyjścia i ścieżek ruchu, ale nie każdy efekt PowerPoint jest obsługiwany. Sprawdź aktualną listę [supported animations and effects](/slides/pl/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) i przetestuj krytyczne prezentacje z wersją Aspose.Slides, której używasz.
- Zaawansowane efekty niestandardowe oraz efekty importowane z innych formatów prezentacji mogą być zachowane w pliku, ale renderowane inaczej w PowerPoint, HTML5 lub wideo. Zweryfikuj wyeksportowany wynik, zamiast polegać wyłącznie na nazwie efektu.

## **FAQ**

**Dlaczego animacja pojawia się w PowerPoint, a nie w PDF?**

PDF jest formatem statycznym, więc animacje i przejścia slajdów nie są odtwarzane. Eksportuj do HTML5, animowanego GIFa lub wideo, gdy ruch musi być zachowany.

**Dlaczego efekt odtwarzany jest inaczej w wideo?**

Eksport wideo renderuje animacje zamiast przechowywać oryginalne zachowanie PowerPoint. Niektóre zaawansowane efekty nie są obsługiwane lub są przybliżane. Przejrzyj tabelę obsługiwanych efektów i przetestuj rzeczywistą prezentację przed użyciem produkcyjnym.

**Czy przeniesienie kształtu do przodu lub do tyłu zmienia kolejność jego animacji?**

Nie. Z‑order kształtu kontroluje nakładanie się, natomiast kolejność w sekwencji i wyzwalacze kontrolują odtwarzanie animacji. Zmień oś czasu, jeśli potrzebna jest inna kolejność odtwarzania.