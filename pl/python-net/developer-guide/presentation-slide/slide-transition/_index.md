---
title: Zarządzanie przejściami slajdów w prezentacjach przy użyciu Pythona
linktitle: Przejście slajdu
type: docs
weight: 90
url: /pl/python-net/slide-transition/
keywords:
- przejście slajdu
- dodaj przejście slajdu
- zastosuj przejście slajdu
- zaawansowane przejście slajdu
- przejście morph
- typ przejścia
- efekt przejścia
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść przy użyciu Aspose.Slides for Python via .NET."
---
## **Przegląd**

Przejścia slajdów kontrolują, jak slajdy pojawiają się podczas pokazu slajdów. Dzięki Aspose.Slides for Python via .NET możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przejście za pomocą kliknięcia myszy lub timera oraz dostosować opcje specyficzne dla efektu. Ten artykuł używa przykładów w Pythonie do zastosowania przejść, ustawienia dokładnych czasów trwania przejść, zarządzania czasem slajdu i stworzenia przejścia Morph między dwoma slajdami. Przykłady również pokazują, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i uzyskaj dostęp do właściwości [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) slajdu. Ustaw jej [typ](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) na wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) i następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle do pierwszego slajdu i przejście Comb do drugiego. Użyj pliku `input.pptx` zawierającego przynajmniej dwa slajdy.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Przejście kołowe (Wheel Transition)**

Właściwość [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) klasy [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) określa liczbę promieniowych sektorów odsłaniających slajd docelowy. Ustaw [typ](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) przejścia slajdu na **WHEEL** z [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) przed dostępem do [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) jako [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Ten przykład tworzy dwie identyczne pary slajdów: czarny slajd, po którym następuje slajd z złotym prostokątem. Slajdy docelowe używają liczby szprych 1 i 8, przy tej samej [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) i explicite określonym [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) = 8 000 ms, aby różnicę było łatwo zauważyć.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Otwórz wynikową prezentację w PowerPoint i uruchom pokaz slajdów. Przejdź z slajdu 1 do slajdu 2, a następnie z slajdu 3 do slajdu 4. W odtwarzaniu PowerPoint zweryfikowana liczba szprych 1 odsłania slajd jednym ruchem w prawo; zweryfikowana liczba 8 odsłania go przez osiem promieniowych sektorów jednocześnie. Zawartość docelowa i czas przejścia są identyczne, więc różnica polega wyłącznie na liczbie sektorów odsłaniających.

## **Fade Through Black przy przejściu Reveal**

Ustaw [typ](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) przejścia slajdu docelowego na **Reveal**, a następnie ustaw [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) w obiekcie [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/). Przykład tworzy niebieskozielony slajd źródłowy i koralowy slajd docelowy, a następnie klonuje parę. Obie pary używają dwusekundowego przejścia Reveal. Tylko druga para przechodzi przez czarny ekran.

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Otwórz `reveal-transitions.pptx` w PowerPoint i rozpocznij pokaz slajdów. Przejdź z slajdu 1 do slajdu 2, aby zobaczyć płynne przejście niebieskozielonego w koralowy. Następnie przejdź z slajdu 3 do slajdu 4. Ekran chwilowo przyciemnia się prawie do czerni, po czym pojawia się slajd koralowy. Oba slajdy zachowują pierwotne kolory tła.

Poniższe wiersze pokazują klatki z PowerPoint w odstępach pół sekundy. Porównaj środkową klatkę w każdym wierszu, aby zobaczyć efekt ustawienia.

![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](reveal-through-black.png)

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie i czy kliknięcie myszy przechodzi do kolejnego slajdu. Następujące właściwości kontrolują to zachowanie:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) umożliwia widzowi przejście po kliknięciu myszą.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) włącza automatyczne przejście.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz zarówno przejście po kliknięciu, jak i po czasie, aby widz mógł przejść kliknięciem lub poczekać na timer. Aby używać tylko timera, ustaw [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) na `False`. Opóźnienie określa, kiedy pokaz slajdów przechodzi dalej; nie ustawia ono czasu trwania efektu wizualnego.

Ten przykład przypisuje różne efekty do trzech pierwszych slajdów i włącza automatyczne przejście po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego przynajmniej trzy slajdy.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Aby sprawdzić, czy automatyczne przejście jest włączone, odczytaj [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Sam zapisany czas nie oznacza, że timer jest aktywny.

Następny przykład otwiera wcześniej zapisaną prezentację, raportuje każdy włączony timer i wyłącza automatyczne przejście dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Precyzyjna kontrola czasu przejścia**

Użyj [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) aby określić dokładną długość efektu przejścia w milisekundach. Właściwość [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) slajdu udostępnia te ustawienia poprzez [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Property | Purpose |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Określa opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Włącz [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/), aby aktywować timer. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Wybiera jedną z predefiniowanych kategorii prędkości z [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM lub FAST. Używana, gdy nie podano dokładnego czasu trwania. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) kontroluje wyłącznie efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przejścia konfiguruje się oddzielnie. Gdy nie ustawiono explicite czasu trwania, Aspose.Slides określa go na podstawie typu przejścia i wartości [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Wspólny przykład nadaje każdemu slajdowi przejście Fade o czasie 750 ms i osobno włącza automatyczne przejście po 5 000 ms. Czas trwania przejścia kontroluje efekt; przejście kontroluje moment opuszczenia slajdu. Te paski to schematyczne ustawienia, a nie zmierzona łączna oś czasu.*
<!-- visual-explanation:slide-transition:end -->

### **Zastosuj ten sam czas trwania do każdego slajdu**

Aby uzyskać jednolite tempo, zastosuj ten sam efekt i dokładny czas trwania do każdego slajdu. Ten przykład ładuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) i nadaje każdemu przejściu czas 750 ms. Osobno włącza automatyczne przejście po 5 000 ms i wyłącza przejście po kliknięciu, a następnie zapisuje wynik jako PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Skonfiguruj automatyczne przechodzenie niezależnie od czasu trwania efektu.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Ustaw różne czasy trwania dla poszczególnych slajdów**

Różne slajdy mogą mieć różne czasy trwania efektu. Na przykład krótki przejście dla slajdu tytułowego i dłuższy dla wprowadzenia sekcji. Ten przykład ustawia 500 ms dla pierwszego slajdu i 1 200 ms dla drugiego. Użyj pliku `input.pptx` z przynajmniej dwoma slajdami.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Koordynuj przejścia z wyjściem animowanym**

Przy przygotowywaniu [animowanego GIF](/slides/pl/python-net/convert-powerpoint-to-animated-gif/), [prezentacji HTML5](/slides/pl/python-net/export-to-html5/) lub [wideo](/slides/pl/python-net/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj przejścia Fade o czasie 600 ms między scenami i osobno dopasuj opóźnienie przejścia każdego slajdu, aby zapewnić czas na narrację lub treść.

Dla GIF i wideo skoordynuj liczbę klatek na sekundę z czasem trwania efektu: 600 ms to 18 klatek przy 30 fps. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje czasowe obsługuje wybrany format eksportu i podglądnij wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Odczytaj [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) przed modyfikacją przejścia, aby określić, czy przechowywana jest wartość explicite. Wartość `-1` oznacza brak explicite określonego czasu; wartość nieujemna podaje przechowywany czas w milisekundach. Nieustawiona wartość nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/), aby określić ten czas. Ustawienie typu przejścia może zainicjować czas, więc najpierw sprawdź oryginalne ustawienia.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Przejście Morph**

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby stworzyć prosty efekt Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu na klonie i zastosuj przejście Morph do drugiego slajdu. Dzięki temu obiekty przejścia mają animować się między stanem oryginalnym a zmodyfikowanym.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje go i zmienia pozycję oraz rozmiar prostokąta na klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt w pokazie slajdów.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Typy przejścia Morph**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) określa, w jaki sposób Morph dopasowuje i animuje zawartość:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) traktuje każdy kształt jako całość.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując słowa tam, gdzie to możliwe.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) animuje tekst, dopasowując znaki tam, gdzie to możliwe.

Ustaw [typ](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) przejścia na **Morph** przed dostępem do jego [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Wartość zwraca obiekt [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), którego właściwość [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) wybiera tryb dopasowania.

Ten przykład otwiera prezentację utworzoną w poprzedniej sekcji i konfiguruje drugi slajd, aby używał animacji Morph opartej na słowach.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Ustaw efekty przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt rozpoczyna się od czarnego ekranu. Dostępne opcje zależą od wybranego [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/). Najpierw ustaw typ, a potem użyj odpowiedniego obiektu przejścia z jego [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu pliku `input.pptx`. Ustawia [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) poprzez [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/), aby przejście rozpoczynało się od czarnego ekranu.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Preferuj [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/), gdy wystarczy kategoria [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW, MEDIUM lub FAST — i nie ustawiono explicite czasu trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przejścia.

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Przypisz osadzony dźwięk do [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), ustaw [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) na **START_SOUND** z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) i włącz [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Dźwięk będzie powtarzany aż do następnego zdarzenia dźwiękowego w pokazie slajdów.

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do każdego slajdu?**

Iteruj po kolekcji [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) prezentacji i ustaw właściwość [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) przejścia każdego slajdu na tę samą wartość. W tym samym pętli ustaw wszelkie opcje czasowe i efektowe, aby zachować spójne zachowanie na wszystkich slajdach.

**Jak sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Odczytaj właściwość [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) z [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) slajdu. Zwróci ona wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); **NONE** oznacza, że żadne przejście nie jest zastosowane.