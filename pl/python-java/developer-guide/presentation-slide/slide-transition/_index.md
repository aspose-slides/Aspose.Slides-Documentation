---
title: Zarządzaj przejściami slajdów w prezentacjach przy użyciu Pythona poprzez Java
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
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejścia przy użyciu Aspose.Slides dla Pythona poprzez Javę."
---
## **Przegląd**

Przejścia slajdów kontrolują sposób wyświetlania slajdów podczas pokazu. Dzięki Aspose.Slides dla Pythona poprzez Java możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie po kliknięciu myszy lub timerze oraz dostosować opcje specyficzne dla danego efektu. Ten artykuł używa przykładów w Pythonie, aby zastosować przejścia, ustawić dokładne czasy trwania przejścia, zarządzać timingiem slajdów i utworzyć przejście Morph między dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) i uzyskaj dostęp do ustawień przejścia slajdu poprzez [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Użyj [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle do pierwszego slajdu i przejście Comb do drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

## **Przejście kołowe**

Użyj [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), aby wybrać Wheel z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Następnie wywołaj [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue), aby uzyskać dostęp do ustawień [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Metoda [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) kontroluje liczbę promieniowych sektorów odsłaniających docelowy slajd.

Przykład tworzy dwie identyczne pary slajdów. Każda para zaczyna się czarnym slajdem i kończy pełnoekranowym złotym prostokątem. Oba docelowe slajdy używają tej samej wolnej prędkości ustawionej przy pomocy [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) oraz tego samego wyraźnego czasu trwania 8 000 milisekund ustawionego przy pomocy [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Zmienia się tylko liczba szprych.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Otwórz `wheel-transitions.pptx` w PowerPoint i uruchom pokaz. Przejdź ze slajdu 1 do slajdu 2, aby zobaczyć jedną obracającą się w prawo sekcję odsłaniającą złoty prostokąt. Następnie przejdź ze slajdu 3 do slajdu 4, aby zobaczyć osiem promieniowych sektorów odsłaniających ten sam prostokąt jednocześnie.

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi do kolejnego slajdu. Następujące metody kontrolują to zachowanie:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umożliwia widzowi przejście po kliknięciu myszy.  
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) włącza automatyczne przechodzenie.  
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz oba tryby — kliknięcie i automatyczne przejście — aby widz mógł przejść po kliknięciu lub poczekać na timer. Aby używać wyłącznie timera, przekaż `False` do [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Opóźnienie decyduje o tym, kiedy pokaz przechodzi dalej; nie ustawia ono czasu trwania wizualnego efektu przejścia.

Przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przejście po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

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

Aby sprawdzić, czy automatyczne przejście jest włączone, wywołaj [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Przechowywane jedynie opóźnienie nie oznacza, że timer jest aktywny.

Kolejny przykład otwiera wcześniej zapisany plik, raportuje każdy włączony timer i wyłącza automatyczne przejście dla slajdów z opóźnieniem większym niż dwie sekundy. Dla tych slajdów włącza kliknięcia myszy i zapisuje zaktualizowane ustawienia.

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

## **Precyzyjne kontrolowanie czasu przejścia**

Użyj [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), aby określić dokładną długość efektu przejścia w milisekundach. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu udostępnia te ustawienia poprzez [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Metoda | Cel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Przekaż `True` do [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter), aby aktywować ten timer. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Wybiera jedną z predefiniowanych kategorii prędkości z [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium lub Fast. Używana jest, gdy nie określono dokładnego czasu trwania. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) kontroluje wyłącznie efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przejścia konfiguruje się osobno. Gdy nie ustawiono explicite czasu trwania, Aspose.Slides określa go na podstawie typu przejścia i wartości zwracanej przez [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Oddzielne słupki identyfikują 750‑ms czas trwania przejścia i 5 000‑ms ustawienie automatycznego przejścia.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Przykład współdzielony nadaje każdemu slajdowi przejście Fade trwające 750 ms i oddzielnie włącza automatyczne przejście po 5 000 ms. Czas trwania przejścia kontroluje efekt; przejście kontroluje moment opuszczenia slajdu. Te słupki przedstawiają schematyczne ustawienia, a nie zmierzoną łączną oś czasu.*  
<!-- visual-explanation:slide-transition:end -->

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Aby zapewnić jednolite tempo, zastosuj ten sam efekt i dokładny czas trwania do każdego slajdu. Ten przykład ładuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), i nadaje każdemu przejściu czas trwania 750 milisekund. Oddzielnie włącza automatyczne przejście po 5 000 milisekundach i wyłącza przejście po kliknięciu myszy, po czym zapisuje wynik jako PPTX.

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

Różne slajdy mogą używać różnych czasów trwania efektu. Na przykład można zastosować krótkie przejście dla slajdu tytułowego i dłuższe dla wprowadzenia sekcji. Ten przykład ustawia 500 ms dla pierwszego slajdu i 1 200 ms dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

Podczas przygotowywania [animowanego GIF](/slides/pl/python-java/convert-powerpoint-to-animated-gif/), [prezentacji HTML5](/slides/pl/python-java/export-to-html5/) lub [wideo](/slides/pl/python-java/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj 600‑milisekundowego zanikania między scenami i osobno ustaw opóźnienie automatycznego przejścia, aby umożliwić narrację lub treść.

Dla GIF‑ów i wideo skoordynuj liczbę klatek na sekundę z czasem trwania efektu: 600 ms to 18 klatek przy 30 fps. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje timingowe są obsługiwane przez wybrany format eksportu oraz podglądaj wynik, aby potwierdzić synchronizację.

### **Odczyt istniejącego czasu trwania przejścia**

Wywołaj [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) przed modyfikacją przejścia, aby ustalić, czy przechowywana jest explicite wartość. Wartość `-1` oznacza brak explicite ustawionego czasu; nieujemna wartość określa przechowywany czas trwania w milisekundach. Nieustawiona wartość nie jest wyliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i wartości zwracanej przez [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed), aby określić ten czas. Ustawienie typu przejścia może zainicjować czas, dlatego najpierw sprawdź oryginalne ustawienia.

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

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby stworzyć proste przejście Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu na klonie i zastosuj przejście Morph do drugiego slajdu. Dzięki temu odpowiadające sobie obiekty są animowane pomiędzy ich pierwotnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje go, a następnie zmienia pozycję i rozmiar prostokąta w klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu.

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

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) określa, w jaki sposób Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) traktuje każdy kształt jako całość.  
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) animuje tekst, dopasowując słowa tam, gdzie to możliwe.  
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) animuje tekst, dopasowując znaki tam, gdzie to możliwe.

Użyj [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), aby wybrać Morph przed dostępem do [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Wartość jest wtedy instancją klasy [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), której metoda [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) wybiera tryb dopasowania.

Ten przykład otwiera prezentację stworzoną w poprzedniej sekcji i konfiguruje drugi slajd tak, aby używał animacji Morph opartej na słowach.

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

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt rozpoczyna się od czarnego ekranu. Dostępne opcje zależą od wybranego przejścia przy użyciu [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Najpierw ustaw typ, a następnie użyj odpowiedniej klasy zwróconej przez [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu pliku `input.pptx`. Wywołuje [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) poprzez [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/), aby przejście zaczynało się od czarnego ekranu.

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

Tak. Preferuj [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed), gdy wystarczy predefiniowana kategoria [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium lub Fast, a nie ustawiono explicite czasu trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przejścia.

**Czy mogę dodać dźwięk do przejścia i sprawić, by był odtwarzany w pętli?**

Tak. Przypisz osadzony dźwięk przy pomocy [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), przekaż `StartSound` z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) i włącz [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) z wartością `True`. Dźwięk będzie powtarzany, aż do następnego zdarzenia dźwiękowego w pokazie.

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do każdego slajdu?**

Przejdź pętlą przez kolekcję [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) prezentacji i wywołaj [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) z tą samą wartością dla każdego slajdu. Ustaw wszelkie opcje timingowe i efektowe w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Wywołaj [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) na wyniku [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu. Zwraca on wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); `None_` oznacza, że żadne przejście nie jest zastosowane.