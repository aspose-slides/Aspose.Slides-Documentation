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
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść za pomocą Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Przejścia slajdów kontrolują, jak slajdy pojawiają się podczas pokazu slajdów. Dzięki Aspose.Slides for Python via Java możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przejście po kliknięciu myszy lub po upływie określonego czasu oraz dostosować opcje specyficzne dla danego efektu. W tym artykule użyto przykładów w Pythonie, aby zastosować przejścia, ustawić dokładne czasy trwania przejść, zarządzać czasem wyświetlania slajdu oraz utworzyć przejście Morph pomiędzy dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Dodawanie przejścia slajdu**

Aby zastosować przejście, wczytaj prezentację za pomocą klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) i uzyskaj dostęp do ustawień przejścia slajdu przez [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Użyj [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle dla pierwszego slajdu i przejście Comb dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

## **Przejście Wheel**

Użyj [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), aby wybrać Wheel z [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Następnie wywołaj [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue), aby uzyskać dostęp do ustawień [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Metoda [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) kontroluje, ile promieniowych sektorów odsłania docelowy slajd.

Przykład tworzy dwie identyczne pary slajdów. Każda para zaczyna się od czarnego slajdu i kończy prostokątem złotym obejmującym cały slajd. Oba docelowe slajdy używają tej samej wolnej prędkości ustawionej przy pomocy [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) oraz tego samego wyraźnego czasu trwania 8 000 ms ustawionego przy pomocy [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Zmienia się jedynie liczba szprych.

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

Otwórz `wheel-transitions.pptx` w programie PowerPoint i uruchom pokaz slajdów. Przejdź ze slajdu 1 do slajdu 2, aby zobaczyć jedną, zgodną z ruchem wskazówek zegara, trójkę odsłaniającą złoty prostokąt. Następnie przejdź ze slajdu 3 do slajdu 4, aby zobaczyć osiem promieniowych sektorów odsłaniających ten sam prostokąt jednocześnie.

## **Fade Through Black z przejściem Reveal**

Ustaw typ przejścia docelowego slajdu na Reveal, a następnie wywołaj [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) na jego ustawieniach [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/). Przykład tworzy niebieskozielony slajd źródłowy i różowy slajd docelowy, a następnie klonuje oba. Każda para używa dwusekundowego przejścia Reveal. Tylko druga para zanika przez czarny ekran.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Otwórz `reveal-transitions.pptx` w programie PowerPoint i uruchom pokaz slajdów. Przejdź ze slajdu 1 do slajdu 2, aby zobaczyć płynne przejście z niebieskozielonego na różowy. Następnie przejdź ze slajdu 3 do slajdu 4. Ekran krótko przyciemnia się do prawie czerni, zanim pojawi się różowy slajd. Oba slajdy zachowują swoje pierwotne kolory tła.

Poniższe wiersze pokazują klatki z PowerPoint co pół sekundy. Porównaj środkową klatkę w każdym wierszu, aby zobaczyć efekt.

![Odtwarzanie PowerPoint z wyłączonym (góra) i włączonym (dół) zanikiem przez czarny ekran. Tylko dolny wiersz przechodzi przez prawie czarny kolor.](reveal-through-black.png)

## **Dodawanie zaawansowanego przejścia slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie i czy kliknięcie myszy powoduje przejście do kolejnego slajdu. Poniższe metody sterują tym zachowaniem:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) pozwala widzowi przejść dalej po kliknięciu myszy.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) włącza automatyczne przejście.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz jednocześnie przejście po kliknięciu i po upływie czasu, aby widz mógł przejść dalej kliknięciem lub poczekać na licznik. Aby używać wyłącznie timera, przekaż `False` do [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Opóźnienie kontroluje, kiedy pokaz slajdów przechodzi dalej; nie ustawia ono czasu trwania wizualnego efektu przejścia.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przejście po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

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

Aby sprawdzić, czy automatyczne przejście jest włączone, wywołaj [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Zapisane opóźnienie samo w sobie nie oznacza, że timer jest aktywny.

Kolejny przykład otwiera wcześniej zapisany plik, wypisuje każdy włączony timer i wyłącza automatyczne przejście dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

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

Użyj [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), aby określić dokładną długość efektu przejścia w milisekundach. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu udostępnia te ustawienia za pośrednictwem klasy [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Metoda | Cel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Przekaż `True` do [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter), aby aktywować timer. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Wybiera jedną z predefiniowanych kategorii prędkości z [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium lub Fast. Używana jest, gdy nie określono dokładnego czasu trwania. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) kontroluje wyłącznie efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przejścia należy konfigurować osobno. Gdy nie zostanie podany wyraźny czas trwania, Aspose.Slides wylicza go na podstawie typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Oddzielne słupki wskazują 750‑ms czas trwania przejścia i 5 000‑ms ustawienie automatycznego przejścia.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Przykład daje każdemu slajdowi 750‑ms przejście Fade i oddzielnie włącza automatyczne przejście po 5 000 ms. Czas trwania przejścia steruje efektem; przejście steruje momentem opuszczenia slajdu. Te słupki są schematycznymi ustawieniami, a nie zmierzoną łączną oś czasu.*
<!-- visual-explanation:slide-transition:end -->

### **Zastosowanie tego samego czasu trwania dla wszystkich slajdów**

Aby uzyskać jednolite tempo, zastosuj ten sam efekt i dokładny czas trwania do każdego slajdu. Ten przykład wczytuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) i nadaje każdemu przejściu czas 750 ms. Oddzielnie włącza automatyczne przejście po 5 000 ms i wyłącza przejście po kliknięciu myszy, po czym zapisuje wynik jako PPTX.

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

### **Ustawianie różnych czasów trwania dla poszczególnych slajdów**

Różne slajdy mogą mieć różne czasy trwania efektów. Na przykład użyj krótkiego przejścia dla slajdu tytułowego i dłuższego dla wprowadzenia sekcji. Ten przykład ustawia 500 ms dla pierwszego slajdu i 1 200 ms dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

### **Koordynacja przejść z animowanym wyjściem**

Podczas przygotowywania [animowanego GIF](/slides/pl/python-java/convert-powerpoint-to-animated-gif/), [prezentacji HTML5](/slides/pl/python-java/export-to-html5/) lub [wideo](/slides/pl/python-java/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj 600‑ms zaniku między scenami i dostosuj osobno opóźnienie przejścia każdego slajdu, aby umożliwić czas na narrację lub treść.

Dla GIF‑ów i wideo koordynuj liczbę klatek na sekundę z czasem trwania efektu: 600 ms odpowiada 18 klatkom przy 30 fps. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje czasu są obsługiwane przez wybrany format eksportu i podejrzyj wynik, aby potwierdzić synchronizację.

### **Odczyt istniejącego czasu trwania przejścia**

Wywołaj [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) przed modyfikacją przejścia, aby określić, czy zapisano wyraźną wartość. Wartość `-1` oznacza, że nie ustawiono konkretnego czasu trwania; wartość nieujemna określa zapisany czas w milisekundach. Brak ustawionej wartości nie jest równy wyliczonemu czasowi odtwarzania: Aspose.Slides wykorzystuje typ przejścia i wartość [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed), aby określić ten czas. Ustawienie typu przejścia może zainicjować czas, więc najpierw sprawdź oryginalne ustawienia.

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

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby stworzyć proste przejście Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu na klonie i zastosuj przejście Morph do drugiego slajdu. Dzięki temu odpowiadające obiekty zostaną animowane pomiędzy ich stanem pierwotnym a zmodyfikowanym.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje slajd i zmienia pozycję oraz rozmiar prostokąta na klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu slajdów.

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

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) kontroluje, w jaki sposób Morph dopasowuje i animuje treść:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) traktuje każdy kształt jako cały obiekt.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) animuje tekst, dopasowując słowa, gdzie to możliwe.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) animuje tekst, dopasowując znaki, gdzie to możliwe.

Użyj [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType), aby wybrać Morph przed dostępem do [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Wartość będzie wtedy instancją klasy [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), której metoda [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) wybiera tryb dopasowania.

Ten przykład otwiera prezentację utworzoną w poprzedniej sekcji i konfiguruje drugi slajd tak, aby używał animacji Morph opartej na słowach.

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

## **Ustawianie efektów przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt zaczyna się od czarnego ekranu. Dostępne opcje zależą od przejścia wybranego za pomocą [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Najpierw ustaw typ, a potem użyj odpowiedniej klasy zwróconej przez [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

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

Tak. Użyj [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed), gdy wystarczająca jest predefiniowana kategoria [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium lub Fast, i nie ustawiono wyraźnego czasu trwania. Te ustawienia sterują efektem przejścia niezależnie od opóźnienia automatycznego przejścia.

**Czy mogę dołączyć dźwięk do przejścia i sprawić, że będzie się powtarzał?**

Tak. Przypisz osadzony dźwięk za pomocą [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), przekaż `StartSound` z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) i włącz [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) ustawiając `True`. Dźwięk będzie powtarzany, dopóki nie nastąpi kolejny sygnał dźwiękowy w pokazie slajdów.

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do każdego slajdu?**

Iteruj po kolekcji [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) prezentacji i wywołaj [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) z tą samą wartością dla przejścia każdego slajdu. W tej samej pętli ustaw wszelkie opcje czasu i efektu, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Wywołaj [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) na wyniku [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu. Zwróci ona wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); `None_` oznacza, że żaden efekt przejścia nie jest zastosowany.