---
title: Zarządzaj przejściami slajdów w prezentacjach przy użyciu JavaScript
linktitle: Przejście slajdu
type: docs
weight: 80
url: /pl/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść za pomocą Aspose.Slides for Node.js via Java."
---
## **Przegląd**

Przejścia slajdów kontrolują, jak slajdy pojawiają się podczas pokazu slajdów. Korzystając z Aspose.Slides for Node.js via Java, możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie za pomocą kliknięcia myszy lub timera oraz dostosować opcje specyficzne dla danego efektu. Ten artykuł używa przykładów JavaScript, aby zastosować przejścia, ustawić dokładne czasy trwania przejścia, zarządzać czasowaniem slajdów i utworzyć przejście Morph pomiędzy dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) i uzyskaj dostęp do ustawień przejścia slajdu poprzez [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Użyj [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle w pierwszym slajdzie i przejście Comb w drugim. Użyj pliku `input.pptx` z co najmniej dwoma slajdami.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Przejście kołowe**

Metoda [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) klasy [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) kontroluje liczbę promieniowych sektorów, które odsłaniają docelowy slajd. Ustaw typ przejścia slajdu na Wheel z [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) przy użyciu [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) przed dostępem do [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) jako [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/).

Ten przykład tworzy dwie identyczne pary slajdów: czarny slajd, a następnie slajd z złotym prostokątem. Slajdy docelowe używają liczby szprych 1 i 8, przy tej samej prędkości ustawionej przez [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) oraz jawnego czasu trwania 8 000 ms ustawionego przez [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), aby różnicę było łatwo zauważyć.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otwórz wynikową prezentację w programie PowerPoint i uruchom pokaz slajdów. Przejdź ze slajdu 1 na slajd 2, a następnie ze slajdu 3 na slajd 4. W odtwarzaniu PowerPoint zweryfikowana liczba szprych 1 odsłania slajd jednym, zgodnym z ruchem wskazówek zegara, przejściem; zweryfikowana liczba 8 odsłania go ośmioma promieniowymi sektorami jednocześnie. Zawartość docelowa i czasowanie przejścia są identyczne, więc różnicą jest liczba sektorów odsłaniania.

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie i czy kliknięcie myszy przechodzi dalej w pokazie. Następujące metody kontrolują to zachowanie:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umożliwia widzowi przejście po kliknięciu myszy.  
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) włącza automatyczne przechodzenie.  
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz oba tryby – kliknięcie i czasowe – aby widz mógł przejść po kliknięciu lub poczekać na timer. Aby używać wyłącznie timera, przekaż `false` do [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Opóźnienie kontroluje moment, w którym pokaz przechodzi dalej; nie ustawia ono czasu trwania samego efektu wizualnego.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przechodzenie po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy również mogą przesuwać te slajdy. Użyj pliku `input.pptx` z co najmniej trzema slajdami.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Aby sprawdzić, czy automatyczne przechodzenie jest włączone, wywołaj [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Sama zapisana wartość opóźnienia nie wskazuje, że timer jest aktywny.

Następny przykład otwiera wcześniej zapisany plik, raportuje każdy włączony timer i wyłącza automatyczne przechodzenie dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Precyzyjna kontrola czasu przejścia**

Użyj [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), aby określić dokładną długość efektu przejścia w milisekundach. Metoda slajdu [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) udostępnia te ustawienia poprzez obiekt [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/):

| Metoda | Cel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Określa opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Przekaż `true` do [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter), aby aktywować timer. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Wybiera jedną z predefiniowanych kategorii prędkości z [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium lub Fast. Używane jest, gdy nie określono dokładnego czasu trwania. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) kontroluje jedynie efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przechodzenia konfiguruje się osobno. Gdy nie ustawiono explicite czasu trwania, Aspose.Slides wylicza go na podstawie typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Oddzielne słupki wskazują czas trwania przejścia 750 ms oraz ustawienie automatycznego przechodzenia po 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Wspólny przykład nadaje każdemu slajdowi przejście Fade trwające 750 ms i osobno włącza automatyczne przechodzenie po 5 000 ms. Czas trwania przejścia steruje efektem; przechodzenie decyduje, kiedy opuścić slajd. Te słupki są schematycznym przedstawieniem ustawień, a nie zmierzoną łączną oś czasu.*
<!-- visual-explanation:slide-transition:end -->

### **Zastosuj ten sam czas trwania do każdego slajdu**

Aby zachować jednolite tempo, zastosuj ten sam efekt i dokładny czas trwania do każdego slajdu. Ten przykład wczytuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) i nadaje każdemu przejściu czas trwania 750 ms. Osobno włącza automatyczne przechodzenie po 5 000 ms i wyłącza przechodzenie po kliknięciu myszy, a następnie zapisuje wynik jako PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Skonfiguruj automatyczne przechodzenie niezależnie od czasu trwania efektu.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ustaw różne czasy trwania dla poszczególnych slajdów**

Różne slajdy mogą mieć różne czasy trwania efektu. Na przykład można użyć krótkiego przejścia dla slajdu tytułowego i dłuższego dla wprowadzenia sekcji. Ten przykład ustawia 500 ms dla pierwszego slajdu i 1 200 ms dla drugiego. Użyj pliku `input.pptx` z co najmniej dwoma slajdami.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Koordynuj przejścia z wyjściem animowanym**

Podczas przygotowywania [animated GIF](/slides/pl/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pl/nodejs-java/export-to-html5/) lub [video](/slides/pl/nodejs-java/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj 600‑msowego zanikania między scenami i osobno dostosuj opóźnienie przejścia każdego slajdu, aby pozostawić czas na narrację lub treść.

Dla GIF‑ów i wideo skoordynuj liczbę klatek na sekundę z czasem trwania efektu: 600 ms odpowiada 18 klatkom przy 30 fps. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje czasowe obsługuje wybrany format eksportu, i zweryfikuj wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Wywołaj [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) przed modyfikacją przejścia, aby określić, czy przechowywana jest explicite wartość. Wartość `-1` oznacza brak ustalonego czasu; nieujemna wartość określa zapisany czas trwania w milisekundach. Nieustawiona wartość nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed), aby określić ten czas. Ustawienie typu przejścia może zainicjować czas, więc najpierw sprawdź pierwotne ustawienia.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Przejście Morph**

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby utworzyć prosty efekt Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu w klonie i zastosuj przejście Morph do drugiego slajdu. Dzięki temu przejście animuje odpowiadające sobie obiekty między stanem oryginalnym a zmodyfikowanym.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje go i zmienia pozycję oraz rozmiar prostokąta w klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Typy przejść Morph**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) określa, w jaki sposób Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) traktuje każdy kształt jako cały obiekt.  
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animuje tekst, dopasowując słowa tam, gdzie to możliwe.  
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animuje tekst, dopasowując znaki tam, gdzie to możliwe.

Użyj [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType), aby wybrać Morph przed dostępem do [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue). Uzyskana wartość zwraca obiekt [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/), którego metoda [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) wybiera tryb dopasowania.

Ten przykład otwiera prezentację utworzoną w poprzedniej sekcji i konfiguruje drugi slajd tak, aby używał animacji Morph opartej na słowach.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Ustaw efekty przejść**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt zaczyna się od czarnego ekranu. Dostępne opcje zależą od przejścia wybranego przy pomocy [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType). Najpierw ustaw typ, a następnie użyj odpowiedniego obiektu przejścia zwróconego przez [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu pliku `input.pptx`. Wywołuje [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) poprzez [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/), aby przejście zaczynało się od czarnego ekranu.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Preferuj [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), gdy potrzebny jest dokładny czas efektu w milisekundach. Użyj [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed), gdy wystarczy predefiniowana kategoria [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium lub Fast, i nie ustawiono explicite czasu trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przechodzenia.

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Przypisz osadzony dźwięk za pomocą [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound), przekaż `StartSound` z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) i włącz [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) ustawiając `true`. Dźwięk będzie powtarzany do kolejnego zdarzenia dźwiękowego w pokazie.

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do wszystkich slajdów?**

Iteruj kolekcję [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) prezentacji i wywołaj [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) z tą samą wartością dla przejścia każdego slajdu. Ustaw wszelkie opcje czasowe i efektu w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Wywołaj [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) na wyniku [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu. Zwróci wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/); None oznacza, że żadne przejście nie jest zastosowane.