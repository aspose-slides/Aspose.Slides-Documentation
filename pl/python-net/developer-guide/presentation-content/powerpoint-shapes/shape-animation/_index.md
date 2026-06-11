---
title: Zastosuj animacje kształtów w prezentacjach przy użyciu Pythona
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
description: "Odkryj, jak tworzyć i dostosowywać animacje kształtów w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET. Wyróżnij się!"
---
## **Wprowadzenie**

Animacje to efekty wizualne, które można zastosować do tekstów, obrazów, kształtów lub [wykresów](/slides/pl/python-net/animated-charts/). Dodają życia prezentacjom lub ich elementom. 

## **Dlaczego używać animacji w prezentacjach?**

* kontrolować przepływ informacji
* podkreślać ważne punkty
* zwiększać zainteresowanie lub zaangażowanie publiczności
* ułatwiać czytanie, przyswajanie lub przetwarzanie treści
* przyciągać uwagę czytelników lub widzów do ważnych części w prezentacji

PowerPoint oferuje wiele opcji i narzędzi do animacji oraz efektów animacji w kategoriach **wejścia**, **wyjścia**, **akcentu** i **ścieżek ruchu**. 

## **Animacje w Aspose.Slides**

* Aspose.Slides udostępnia klasy i typy potrzebne do pracy z animacjami w przestrzeni nazw [Aspose.Slides.Animation](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/).
* Aspose.Slides udostępnia ponad **150 efektów animacji** w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttype/). Te efekty są zasadniczo takie same (lub równoważne) jak używane w PowerPoint.

## **Zastosuj animację do TextBox**

Aspose.Slides for Python via .NET umożliwia zastosowanie animacji do tekstu w kształcie. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu przez jego indeks.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iautoshape/). 
4. Dodaj tekst do `IAutoShape.TextFrame`.
5. Pobierz główną sekwencję efektów.
6. Dodaj efekt animacji do [IAutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iautoshape/). 
7. Ustaw właściwość `TextAnimation.BuildType` na wartość z wyliczenia `BuildType`.
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod w Pythonie pokazuje, jak zastosować efekt `Fade` do AutoShape i ustawić animację tekstu na wartość *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Dodaje nową AutoShape z tekstem
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Pobiera główną sekwencję slajdu.
    sequence = sld.timeline.main_sequence

    # Dodaje efekt animacji Fade do kształtu
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animuje tekst kształtu według akapitów pierwszego poziomu
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Zapisuje plik PPTX na dysku
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Poza stosowaniem animacji do tekstu, możesz również zastosować animacje do pojedynczego [Paragraph](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iparagraph/). Zobacz [**Animated Text**](/slides/pl/python-net/animated-text/).

{{% /alert %}} 

## **Zastosuj animację do PictureFrame**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu przez jego indeks.
3. Dodaj lub pobierz [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/) na slajdzie. 
4. Pobierz główną sekwencję efektów.
5. Dodaj efekt animacji do [PictureFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pictureframe/).
6. Zapisz prezentację na dysku jako plik PPTX.

Ten kod w Pythonie pokazuje, jak zastosować efekt `Fly` do ramki obrazu:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
with slides.Presentation() as pres:
    # Ładuje obraz, który ma zostać dodany do kolekcji obrazów w prezentacji
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Dodaje ramkę obrazu do slajdu
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Pobiera główną sekwencję slajdu.
    sequence = pres.slides[0].timeline.main_sequence

    # Dodaje efekt animacji Fly od lewej do ramki obrazu
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Zapisuje plik PPTX na dysku
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zastosuj animację do Shape**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu przez jego indeks.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iautoshape/). 
4. Dodaj `Bevel` [IAutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iautoshape/) (gdy ten obiekt zostanie kliknięty, animacja zostanie odtworzona).
5. Utwórz sekwencję efektów na kształcie bevel.
6. Utwórz niestandardowy `UserPath`.
7. Dodaj polecenia przemieszczania do `UserPath`.
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod w Pythonie pokazuje, jak zastosować efekt `PathFootball` (ścieżka piłkowa) do kształtu:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Tworzy efekt PathFootball dla istniejącego kształtu od podstaw.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Dodaje efekt animacji PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Tworzy pewnego rodzaju "przycisk".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Tworzy sekwencję efektów dla przycisku.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Tworzy niestandardową ścieżkę użytkownika. Nasz obiekt będzie przemieszczał się dopiero po kliknięciu przycisku.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Dodaje polecenia ruchu, ponieważ utworzona ścieżka jest pusta.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Zapisuje plik PPTX na dysku
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj efekty animacji zastosowane do Shape**

Poniższe przykłady pokazują, jak używać metody `get_effects_by_shape` z klasy [Sequence](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/sequence/) aby uzyskać wszystkie efekty animacji zastosowane do kształtu.

**Przykład 1: Pobierz efekty animacji zastosowane do kształtu na zwykłym slajdzie**

Poprzednio nauczyłeś się, jak dodawać efekty animacji do kształtów w prezentacjach PowerPoint. Poniższy kod przykładowy pokazuje, jak pobrać efekty zastosowane do pierwszego kształtu na pierwszym zwykłym slajdzie w prezentacji `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Pobiera główną sekwencję animacji slajdu.
    sequence = first_slide.timeline.main_sequence

    # Pobiera pierwszy kształt na pierwszym slajdzie.
    shape = first_slide.shapes[0]

    # Pobiera efekty animacji zastosowane do kształtu.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Przykład 2: Pobierz wszystkie efekty animacji, w tym dziedziczone z placeholderów**

Jeśli kształt na zwykłym slajdzie ma placeholdery znajdujące się na slajdzie układu i/lub slajdzie głównym, a efekty animacji zostały dodane do tych placeholderów, wszystkie efekty kształtu będą odtwarzane podczas pokazu slajdów, w tym te dziedziczone z placeholderów.

Załóżmy, że mamy plik prezentacji PowerPoint `sample.pptx` z jednym slajdem zawierającym jedynie kształt stopki z tekstem "Made with Aspose.Slides" oraz zastosowanym efektem **Random Bars**.

![Efekt animacji kształtu slajdu](slide-shape-animation.png)

Załóżmy również, że efekt **Split** jest zastosowany do placeholdera stopki na slajdzie **layout**.

![Efekt animacji kształtu układu](layout-shape-animation.png)

Na koniec, efekt **Fly In** jest zastosowany do placeholdera stopki na slajdzie **master**.

![Efekt animacji kształtu master](master-shape-animation.png)

Poniższy kod przykładowy pokazuje, jak używać metody `get_base_placeholder` z klasy [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) aby uzyskać dostęp do placeholderów kształtu i pobrać efekty animacji zastosowane do kształtu stopki, w tym dziedziczone z placeholderów znajdujących się na slajdach layout i master.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Pobierz efekty animacji kształtu na zwykłym slajdzie.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Pobierz efekty animacji placeholdera na slajdzie układu.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Pobierz efekty animacji placeholdera na slajdzie master.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Zmień właściwości czasowe efektu animacji**

Aspose.Slides for Python via .NET umożliwia zmianę właściwości Timing efektu animacji.

To jest panel Timing animacji w Microsoft PowerPoint:

![Panel Timing animacji](shape-animation.png)

To są odpowiedniki pomiędzy Timingiem w PowerPoint a właściwościami `Effect.Timing`:

- Lista rozwijana PowerPoint Timing **Start** odpowiada właściwości [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/effecttriggertype/).
- PowerPoint Timing **Duration** odpowiada właściwości `Effect.Timing.Duration`. Czas trwania animacji (w sekundach) to całkowity czas potrzebny do zakończenia jednego cyklu.
- PowerPoint Timing **Delay** odpowiada właściwości `Effect.Timing.TriggerDelayTime`.

Oto jak zmienić właściwości Timing efektu:

1. [Zastosuj](#apply-animation-to-shape) lub pobierz efekt animacji.
2. Ustaw nowe wartości właściwości `Effect.Timing`, które są potrzebne. 
3. Zapisz zmodyfikowany plik PPTX.

```python
import aspose.slides as slides

# Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Pobiera główną sekwencję slajdu.
    sequence = pres.slides[0].timeline.main_sequence

    # Pobiera pierwszy efekt głównej sekwencji.
    effect = sequence[0]

    # Zmienia TriggerType efektu, aby rozpoczął się po kliknięciu
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Zmienia czas trwania efektu
    effect.timing.duration = 3

    # Zmienia TriggerDelayTime efektu
    effect.timing.trigger_delay_time = 0.5

    # Zapisuje plik PPTX na dysku
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Dźwięk efektu animacji**

Aspose.Slides udostępnia następujące właściwości, które umożliwiają pracę z dźwiękami w efektach animacji:

- `sound`
- `stop_previous_sound`

### **Dodaj dźwięk efektu animacji**

Ten kod w Pythonie pokazuje, jak dodać dźwięk do efektu animacji i zatrzymać go, gdy rozpocznie się kolejny efekt:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Dodaje dźwięk do kolekcji audio prezentacji
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Pobiera główną sekwencję slajdu.
    sequence = first_slide.timeline.main_sequence

    # Pobiera pierwszy efekt głównej sekwencji
    first_effect = sequence[0]

    # Sprawdza, czy efekt nie ma dźwięku
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Dodaje dźwięk do pierwszego efektu
        first_effect.sound = effect_sound

    # Pobiera pierwszą interaktywną sekwencję slajdu.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Ustawia flagę „Stop previous sound” efektu
    interactive_sequence[0].stop_previous_sound = True

    # Zapisuje plik PPTX na dysku
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Wyodrębnij dźwięk efektu animacji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu przez jego indeks. 
3. Pobierz główną sekwencję efektów. 
4. Wyodrębnij osadzony `sound` z każdego efektu animacji. 

Ten kod w Pythonie pokazuje, jak wyodrębnić dźwięk osadzony w efekcie animacji:

```python
import aspose.slides as slides

# Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Pobiera główną sekwencję slajdu.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Wyodrębnia dźwięk efektu jako tablicę bajtów
        audio = effect.sound.binary_data
```

## **Po animacji**

Aspose.Slides for .NET umożliwia zmianę właściwości After animation efektu animacji.

To jest panel Efekt animacji i rozszerzone menu w Microsoft PowerPoint:

![Panel Efekt animacji](shape-after-animation.png)

Lista rozwijana PowerPoint Effect **After animation** odpowiada następującym właściwościom: 

- właściwość `after_animation_type`, która opisuje typ After animation:
  * PowerPoint **More Colors** odpowiada typowi [COLOR](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** odpowiada typowi [DO_NOT_DIM](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/afteranimationtype/) (domyślny typ after animation);
  * PowerPoint **Hide After Animation** odpowiada typowi [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** odpowiada typowi [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/afteranimationtype/);
- właściwość `after_animation_color`, która definiuje format koloru after animation. Działa ona w połączeniu z typem [COLOR](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/afteranimationtype/). Jeśli zmienisz typ na inny, kolor after animation zostanie wyczyszczony.

Ten kod w Pythonie pokazuje, jak zmienić efekt after animation:

```python
import aspose.slides as slides

# Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Pobiera pierwszy efekt głównej sekwencji
    first_effect = first_slide.timeline.main_sequence[0]

    # Zmienia typ after animation na Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Ustawia kolor przyciemnienia after animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Zapisuje plik PPTX na dysku
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animuj tekst**

Aspose.Slides udostępnia następujące właściwości, które pozwalają na pracę z blokiem *Animate text* efektu animacji:

- `animate_text_type`, która opisuje typ animacji tekstu w efekcie. Tekst kształtu może być animowany:
  - Wszystko naraz ([ALL_AT_ONCE](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/animatetexttype/) typ)
  - Słowo po słowie ([BY_WORD](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/animatetexttype/) typ)
  - Litera po literze ([BY_LETTER](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/animatetexttype/) typ)
- `delay_between_text_parts` ustawia opóźnienie pomiędzy animowanymi częściami tekstu (słowami lub literami). Dodatnia wartość określa procent czasu trwania efektu. Ujemna wartość określa opóźnienie w sekundach.

Oto jak można zmienić właściwości Effect Animate text:

1. [Zastosuj](#apply-animation-to-shape) lub pobierz efekt animacji.
2. Ustaw właściwość `build_type` na wartość [AS_ONE_OBJECT](https://reference.aspose.com/slides/pl/python-net/aspose.slides.animation/buildtype/), aby wyłączyć tryb animacji *By Paragraphs*.
3. Ustaw nowe wartości właściwości `animate_text_type` i `delay_between_text_parts`.
4. Zapisz zmodyfikowany plik PPTX.

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Pobiera pierwszy efekt głównej sekwencji
    first_effect = first_slide.timeline.main_sequence[0]

    # Zmienia typ animacji tekstu efektu na "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Zmienia typ animacji tekstu na "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Ustawia opóźnienie między słowami na 20% czasu trwania efektu
    first_effect.delay_between_text_parts = 20

    # Zapisuje plik PPTX na dysku
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Jak mogę zapewnić, że animacje zostaną zachowane przy publikowaniu prezentacji w sieci?**

[Eksportuj do HTML5](/slides/pl/python-net/export-to-html5/) i włącz [opcje](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/) odpowiedzialne za animacje [kształtów](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/animate_shapes/) i [przejść](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/animate_transitions/). Zwykły HTML nie odtwarza animacji slajdów, natomiast HTML5 tak.

**Jak zmiana kolejności z-order (kolejności warstw) kształtów wpływa na animację?**

Animacja i kolejność rysowania są niezależne: efekt kontroluje timing i rodzaj pojawiania/zanikania, natomiast [z-order](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/z_order_position/) określa, co co zasłania. Widoczny rezultat jest określany przez ich kombinację. (Takie jest ogólne zachowanie PowerPoint; model efektów i kształtów Aspose.Slides podąża za tą samą logiką.)

**Czy istnieją ograniczenia przy konwertowaniu animacji na wideo dla niektórych efektów?**

Ogólnie [animacje są wspierane](/slides/pl/python-net/convert-powerpoint-to-video/), ale rzadkie przypadki lub specyficzne efekty mogą być renderowane inaczej. Zaleca się przetestowanie używanych efektów oraz wersji biblioteki.