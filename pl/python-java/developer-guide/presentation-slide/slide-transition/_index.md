---
title: Zarządzanie przejściami slajdów w prezentacjach przy użyciu Pythona via Java
linktitle: Przejście slajdu
type: docs
weight: 80
url: /pl/python-java/slide-transition/
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
- Java
- Aspose.Slides
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj przejścia Morph i inne efekty przejścia przy użyciu Aspose.Slides dla Pythona via Java."
---
## **Przegląd**

Przejścia slajdów kontrolują sposób wyświetlania slajdów podczas pokazu slajdów. Za pomocą Aspose.Slides for Python via Java możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie za pomocą kliknięcia myszy lub timera oraz dostosować opcje specyficzne dla danego efektu. Ten artykuł wykorzystuje przykłady w Pythonie do zastosowania przejść, ustawienia dokładnych czasów trwania przejść, zarządzania czasem slajdu i tworzenia przejścia Morph pomiędzy dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i uzyskaj dostęp do ustawień przejścia slajdu poprzez [getSlideShowTransition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getSlideShowTransition). Użyj [setType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setType) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład zastosowuje przejście Circle do pierwszego slajdu i przejście Comb do drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie i czy kliknięcie myszy przechodzi do kolejnego slajdu. Następujące metody kontrolują to zachowanie:

- [setAdvanceOnClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) pozwala widzowi przejść klikając myszą.
- [setAdvanceAfter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) włącza automatyczne przechodzenie.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz zarówno przejście po kliknięciu, jak i z timerem, aby widz mógł przejść klikając lub poczekać na timer. Aby używać tylko timera, przekaż `False` do [setAdvanceOnClick](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Opóźnienie kontroluje moment, w którym pokaz slajdów przechodzi dalej; nie ustawia czasu trwania efektu wizualnego przejścia.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przechodzenie po 3, 5 i 7 sekundach, odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Aby sprawdzić, czy automatyczne przechodzenie z timerem jest włączone, wywołaj [getAdvanceAfter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Same przechowywane opóźnienie nie wskazuje, że timer jest aktywny.

Kolejny przykład otwiera wcześniej zapisany plik, raportuje każdy włączony timer i wyłącza automatyczne przechodzenie dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Precyzyjna kontrola czasu przejścia**

Użyj [setDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setDuration), aby określić dokładną długość efektu przejścia w milisekundach. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu udostępnia te ustawienia poprzez [SlideShowTransition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/):

| Metoda | Cel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setDuration) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Przekaż `True` do [setAdvanceAfter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter), aby aktywować ten timer. |
| [setSpeed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setSpeed) | Wybiera wstępnie zdefiniowaną kategorię prędkości z [TransitionSpeed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitionspeed/): Slow, Medium lub Fast. Jest używana, gdy nie określono dokładnego czasu trwania. |

[setDuration] kontroluje tylko efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przechodzenia należy konfigurować osobno. Gdy nie ustawiono wyraźnego czasu trwania, Aspose.Slides określa czas trwania efektu na podstawie typu przejścia i wartości [getSpeed].

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Aby uzyskać jednolite tempo, zastosuj ten sam efekt i dokładny czas trwania dla każdego slajdu. Ten przykład ładuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitiontype/), i ustawia każdemu przejściu czas trwania 750 milisekund. Oddzielnie włącza automatyczne przechodzenie po 5 000 milisekundach i wyłącza przechodzenie kliknięciem myszy, a następnie zapisuje wynik jako PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Skonfiguruj automatyczne przechodzenie niezależnie od czasu trwania efektu.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ustaw różne czasy trwania dla poszczególnych slajdów**

Różne slajdy mogą używać różnych czasów trwania efektu. Na przykład, użyj krótkiego przejścia dla slajdu tytułowego i dłuższego przejścia dla wprowadzenia sekcji. Ten przykład ustawia 500 milisekund dla pierwszego slajdu i 1 200 milisekund dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Koordynuj przejścia z animowanym wyjściem**

Podczas przygotowywania [animated GIF](/slides/pl/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pl/python-java/export-to-html5/) lub [video](/slides/pl/python-java/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj 600‑milisekundowego zanikania między scenami i osobno dostosuj opóźnienie przechodzenia każdego slajdu, aby zapewnić czas na narrację lub treść.  

Dla GIF i wideo, skoordynuj liczbę klatek wyjściowych z czasem trwania efektu: 600 milisekund odpowiada 18 klatkom przy 30 klatkach na sekundę. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, jakie efekty i opcje czasowe są obsługiwane przez wybrany format eksportu i podglądaj wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Wywołaj [getDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#getDuration) przed modyfikacją przejścia, aby określić, czy przechowywana jest explicite wartość. Wartość `-1` oznacza, że nie ustawiono wyraźnego czasu trwania; nieujemna wartość określa przechowywany czas trwania w milisekundach. Nieustawiona wartość nie jest wyliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#getSpeed) do określenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, więc najpierw sprawdź oryginalne ustawienia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Przejście Morph**

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby stworzyć prosty efekt Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu na kopii i zastosuj przejście Morph do drugiego slajdu. Dzięki temu przejście animuje odpowiednie obiekty między ich pierwotnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje slajd i zmienia pozycję oraz rozmiar prostokąta na kopii. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu slajdów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Typy przejścia Morph**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitionmorphtype/) określa, jak Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitionmorphtype/#ByObject) traktuje każdy kształt jako pojedynczy obiekt.
- [ByWord](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitionmorphtype/#ByWord) animuje tekst, dopasowując słowa, gdzie to możliwe.
- [ByChar](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitionmorphtype/#ByChar) animuje tekst, dopasowując znaki, gdzie to możliwe.

Użyj [setType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setType), aby wybrać Morph przed dostępem do [getValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#getValue). Wartość jest wtedy instancją klasy [MorphTransition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/morphtransition/), której metoda [setMorphType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/morphtransition/#setMorphType) wybiera tryb dopasowania.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Ustaw efekty przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt rozpoczyna się od czarnego ekranu. Dostępne opcje zależą od przejścia wybranego za pomocą [setType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setType). Najpierw ustaw typ, a następnie użyj odpowiedniej klasy z [getValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#getValue).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu `input.pptx`. Wywołuje [setFromBlack](https://reference.aspose.com/slides/pl/python-java/aspose.slides/optionalblacktransition/#setFromBlack) za pośrednictwem [OptionalBlackTransition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/optionalblacktransition/), aby przejście rozpoczynało się od czarnego ekranu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę kontrolować szybkość odtwarzania przejścia slajdu?**

Tak. Preferuj [setDuration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setDuration), gdy potrzebujesz dokładnego czasu trwania efektu w milisekundach. Użyj [setSpeed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setSpeed), gdy wystarcza wstępnie zdefiniowana kategoria [TransitionSpeed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitionspeed/) — Slow, Medium lub Fast — i nie jest ustawiony wyraźny czas trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przechodzenia.

**Czy mogę dołączyć dźwięk do przejścia i sprawić, że będzie się powtarzał?**

Tak. Przypisz wbudowany dźwięk za pomocą [setSound](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setSound), przekaż StartSound z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setSoundMode) i włącz [setSoundLoop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setSoundLoop) ustawiając `True`. Dźwięk będzie powtarzany aż do kolejnego zdarzenia dźwiękowego w pokazie slajdów.

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Przejdź w pętli po kolekcji [getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides) prezentacji i wywołaj [setType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#setType) z tą samą wartością dla przejścia każdego slajdu. Ustaw wszelkie opcje czasu i efektu w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest obecnie ustawione na slajdzie?**

Wywołaj [getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowtransition/#getType) na wyniku [getSlideShowTransition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu. Zwraca on wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/transitiontype/); None_ oznacza, że żaden efekt przejścia nie jest zastosowany.