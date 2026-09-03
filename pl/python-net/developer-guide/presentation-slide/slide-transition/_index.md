---
title: Zarządzaj przejściami slajdów w prezentacjach przy użyciu Pythona
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
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejścia przy użyciu Aspose.Slides for Python via .NET."
---
## **Przegląd**

Przejścia slajdów kontrolują sposób wyświetlania slajdów podczas pokazu slajdów. Za pomocą Aspose.Slides for Python via .NET możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie po kliknięciu myszy lub timerem oraz dostosować opcje specyficzne dla efektu. Ten artykuł wykorzystuje przykłady w Pythonie do zastosowania przejść, ustawiania dokładnych czasów trwania przejść, zarządzania czasem wyświetlania slajdu i tworzenia przejścia Morph między dwoma slajdami. Przykłady pokazują również, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i uzyskaj dostęp do właściwości [slide_show_transition](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/slide_show_transition/) slajdu. Ustaw jej [type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/type/) na wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/transitiontype/), a następnie zapisz prezentację.

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

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi dalej w pokazie slajdów. Następujące właściwości kontrolują to zachowanie:

- [advance_on_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) umożliwia widzowi przejście po kliknięciu myszy.
- [advance_after](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) umożliwia automatyczne przechodzenie.
- [advance_after_time](https://reference.aspose.com/slides/pl/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) określa opóźnienie przed automatycznym przechodzeniem, w milisekundach.

Włącz zarówno przechodzenie po kliknięciu, jak i po upływie czasu, aby widz mógł przejść dalej kliknięciem lub poczekać na timer. Aby używać tylko timera, ustaw [advance_on_click] na `False`. Opóźnienie kontroluje, kiedy pokaz slajdów przechodzi dalej; nie określa czasu trwania efektu wizualnego przejścia.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przechodzenie po 3, 5 i 7 sekundach, odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego przynajmniej trzy slajdy.

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

Aby sprawdzić, czy włączono przechodzenie czasowe, odczytaj [advance_after]. Sam zapisany czas opóźnienia nie oznacza, że timer jest aktywny.

Następny przykład otwiera zapisany powyżej plik, raportuje każdy włączony timer i wyłącza automatyczne przechodzenie dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

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

Użyj [duration] aby określić dokładną długość efektu przejścia w milisekundach. Właściwość [slide_show_transition] slajdu udostępnia te ustawienia poprzez [SlideShowTransition]:

| Właściwość | Cel |
| --- | --- |
| [duration] | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [advance_after_time] | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Włącz [advance_after], aby aktywować ten timer. |
| [speed] | Wybiera predefiniowaną kategorię prędkości z [TransitionSpeed]: SLOW, MEDIUM lub FAST. Jest używana, gdy nie określono dokładnego czasu trwania. |

[duration] kontroluje tylko efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przejścia należy konfigurować osobno. Gdy nie ustawiono explicite czasu trwania, Aspose.Slides określa czas trwania efektu na podstawie typu przejścia i wartości [speed].

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Dla spójnego tempa zastosuj ten sam efekt i dokładny czas trwania dla każdego slajdu. Ten przykład ładuje `input.pptx`, wybiera Fade z [TransitionType] i nadaje każdemu przejściu czas trwania 750 milisekund. Osobno włącza automatyczne przejście po 5,000 milisekundach i wyłącza przechodzenie po kliknięciu myszy, a następnie zapisuje wynik jako PPTX.

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

Różne slajdy mogą mieć różne czasy trwania efektów. Na przykład użyj krótkiego przejścia dla slajdu tytułowego i dłuższego przejścia dla wprowadzenia sekcji. Ten przykład ustawia 500 milisekund dla pierwszego slajdu i 1200 milisekund dla drugiego. Użyj pliku `input.pptx` zawierającego przynajmniej dwa slajdy.

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

### **Skoordynuj przejścia z animowanym wyjściem**

Przy przygotowywaniu [animated GIF](/slides/pl/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pl/python-net/export-to-html5/) lub [video](/slides/pl/python-net/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj 600-milisekundowego zanikania (fade) między scenami i dostosuj osobno opóźnienie przejścia każdego slajdu, aby umożliwić czas na narrację lub zawartość.

Dla GIF i wideo skoordynuj częstotliwość klatek wyjściowych z czasem trwania efektu: 600 milisekund odpowiada 18 klatkom przy 30 klatkach na sekundę. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, jakie efekty i opcje czasowe obsługuje wybrany format eksportu oraz podglądaj wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Odczytaj [duration] przed modyfikacją przejścia, aby określić, czy zapisano explicite wartość. Wartość `-1` oznacza, że nie ustawiono wyraźnego czasu trwania; wartość nieujemna określa zapisany czas trwania w milisekundach. Nieustawiona wartość nie jest wyliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i [speed] do określenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, więc najpierw sprawdź oryginalne ustawienia.

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

Przejście Morph animuje zmiany pomiędzy obiektami na kolejnych slajdach. Aby stworzyć prosty efekt Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu na klonie i zastosuj przejście Morph do drugiego slajdu. To zapewnia przejściowi odpowiednie obiekty do animacji między ich pierwotnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje slajd i zmienia pozycję oraz rozmiar prostokąta na klonie. Następnie wybiera Morph z wyliczenia [TransitionType] dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu slajdów.

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

Wyliczenie [TransitionMorphType] kontroluje, w jaki sposób Morph dopasowuje i animuje zawartość:

- [BY_OBJECT] traktuje każdy kształt jako cały obiekt.
- [BY_WORD] animuje tekst, dopasowując słowa, gdzie to możliwe.
- [BY_CHAR] animuje tekst, dopasowując znaki, gdzie to możliwe.

Ustaw przejście [type] na Morph przed dostępem do jego [value]. Wartość następnie zwraca obiekt [MorphTransition], którego właściwość [morph_type] wybiera tryb dopasowania.

Ten przykład otwiera prezentację stworzoną w poprzedniej sekcji i konfiguruje drugi slajd do używania animacji Morph opartej na słowach.

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

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek czy to, czy efekt zaczyna się od czarnego ekranu. Dostępne opcje zależą od wybranego [type] przejścia. Najpierw ustaw typ, a następnie użyj odpowiedniego obiektu przejścia z jego [value].

Poniższy przykład stosuje przejście Cut do pierwszego slajdu `input.pptx`. Ustawia [from_black] za pośrednictwem [OptionalBlackTransition], aby przejście rozpoczynało się od czarnego ekranu.

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

Tak. Preferuj [duration], gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [speed], gdy wystarczy predefiniowana kategoria [TransitionSpeed] — SLOW, MEDIUM lub FAST — i nie ustawiono explicite czasu trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przejścia.

**Czy mogę dołączyć dźwięk do przejścia i sprawić, że będzie się powtarzać?**

Tak. Przypisz wbudowany dźwięk do [sound], ustaw [sound_mode] na START_SOUND z wyliczenia [TransitionSoundMode] i włącz [sound_loop]. Dźwięk będzie się powtarzał aż do następnego zdarzenia dźwiękowego w pokazie slajdów.

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Przejdź pętlą po kolekcji [slides] prezentacji i ustaw [type] przejścia każdego slajdu na tę samą wartość. Ustaw wszystkie opcje czasu i efektów w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Odczytaj właściwość [type] z [slide_show_transition] slajdu. Zwraca ona wartość z wyliczenia [TransitionType]; NONE oznacza, że żaden efekt przejścia nie jest zastosowany.