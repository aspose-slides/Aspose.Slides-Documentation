---
title: Zarządzanie przejściami slajdów w prezentacjach przy użyciu JavaScript
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
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść przy użyciu Aspose.Slides dla Node.js przez Java."
---
## **Przegląd**

Przejścia slajdów kontrolują, jak slajdy pojawiają się podczas pokazu slajdów. Za pomocą Aspose.Slides dla Node.js przez Java możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie przez kliknięcie myszy lub timer oraz dostosować opcje specyficzne dla danego efektu. Ten artykuł wykorzystuje przykłady JavaScript do zastosowania przejść, ustawienia dokładnych czasów trwania przejścia, zarządzania czasem slajdu oraz utworzenia przejścia Morph między dwoma slajdami. Przykłady pokazują również, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i uzyskaj dostęp do ustawień przejścia slajdu za pomocą [getSlideShowTransition](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Użyj [setType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/#setType) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle dla pierwszego slajdu i przejście Comb dla drugiego. Użyj pliku `input.pptx` zawierającego przynajmniej dwa slajdy.

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

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi do kolejnego slajdu. Następujące metody kontrolują to zachowanie:

- [setAdvanceOnClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) pozwala widzowi przejść dalej poprzez kliknięcie myszy.
- [setAdvanceAfter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) włącza automatyczne przechodzenie.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz zarówno kliknięcie, jak i przejście oparte na czasie, aby widz mógł przejść dalej kliknięciem lub poczekać na timer. Aby używać tylko timera, przekaż `false` do [setAdvanceOnClick]. Opóźnienie kontroluje, kiedy pokaz slajdów przechodzi dalej; nie ustawia ono czasu trwania wizualnego efektu przejścia.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przechodzenie po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego przynajmniej trzy slajdy.

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
        secondTransition.setAdvanceAfterTime(5

000);

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

Aby sprawdzić, czy przejście oparte na czasie jest włączone, wywołaj [getAdvanceAfter]. Same przechowywane opóźnienie nie wskazuje, że timer jest aktywny.

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

Użyj [setDuration], aby określić dokładną długość efektu przejścia w milisekundach. Metoda [getSlideShowTransition] slajdu udostępnia te ustawienia poprzez [SlideShowTransition]:

| Metoda | Cel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Przekaż `true` do [setAdvanceAfter], aby aktywować ten timer. |
| [setSpeed](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Wybiera predefiniowaną kategorię prędkości z [TransitionSpeed](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium lub Fast. Jest używana, gdy nie określono dokładnego czasu trwania. |

[setDuration] kontroluje tylko efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Skonfiguruj osobno opóźnienie automatycznego przejścia. Gdy nie ustawiono wyraźnego czasu trwania, Aspose.Slides określa czas trwania efektu na podstawie typu przejścia i wartości [getSpeed].

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Aby zachować spójną rytmikę, zastosuj ten sam efekt i dokładny czas trwania dla każdego slajdu. Ten przykład wczytuje `input.pptx`, wybiera Fade z [TransitionType] i nadaje każdemu przejściu czas trwania 750 milisekund. Oddzielnie włącza automatyczne przechodzenie po 5 000 milisekundach i wyłącza przechodzenie przez kliknięcie myszy, a następnie zapisuje wynik jako PPTX.

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

Różne slajdy mogą używać różnych czasów trwania efektów. Na przykład, zastosuj krótkie przejście dla slajdu tytułowego i dłuższe dla wprowadzenia sekcji. Ten przykład ustawia 500 milisekund dla pierwszego slajdu i 1 200 milisekund dla drugiego. Użyj pliku `input.pptx` zawierającego przynajmniej dwa slajdy.

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

### **Koordynuj przejścia z animowanym wyjściem**

Przy przygotowywaniu [animowanego GIF](/slides/pl/nodejs-java/convert-powerpoint-to-animated-gif/), [prezentacji HTML5](/slides/pl/nodejs-java/export-to-html5/) lub [wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj przejścia fade trwającego 600 milisekund między scenami i dostosuj osobno opóźnienie przejścia każdego slajdu, aby umożliwić czas na narrację lub treść.

Dla GIF i wideo, skoordynuj liczbę klatek wyjściowych z czasem trwania efektu: 600 milisekund odpowiada 18 klatkom przy 30 klatkach na sekundę. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, jakie efekty i opcje czasowe są wspierane przez wybrany format eksportu i podglądaj wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Wywołaj [getDuration] przed modyfikacją przejścia, aby określić, czy przechowywana jest wyraźna wartość. Wartość `-1` oznacza, że nie ustawiono żadnego czasu trwania; nieujemna wartość określa przechowywany czas trwania w milisekundach. Nieustawiona wartość nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i wartości [getSpeed] do określenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, więc najpierw sprawdź pierwotne ustawienia.

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

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby stworzyć prosty efekt Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu w klonie i zastosuj przejście Morph do drugiego slajdu. To umożliwia przejściu animowanie odpowiadających sobie obiektów pomiędzy ich oryginalnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje go i zmienia pozycję oraz rozmiar prostokąta w klonie. Następnie wybiera Morph z wyliczenia [TransitionType] dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji wspierającej Morph, aby zobaczyć efekt podczas pokazu slajdów.

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

## **Typy przejścia Morph**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/transitionmorphtype/) kontroluje, jak Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) traktuje każdy kształt jako cały obiekt.
- [ByWord](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) animuje tekst, dopasowując słowa, jeśli to możliwe.
- [ByChar](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) animuje tekst, dopasowując znaki, jeśli to możliwe.

Użyj [setType], aby wybrać Morph przed dostępem do [getValue]. Wartość zwraca obiekt [MorphTransition], którego metoda [setMorphType] wybiera tryb dopasowania.

Ten przykład otwiera prezentację utworzoną w poprzedniej sekcji i konfiguruje drugi slajd do użycia animacji Morph opartej na słowach.

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

## **Ustaw efekty przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt zaczyna się od czarnego ekranu. Dostępne opcje zależą od przejścia wybranego za pomocą [setType]. Najpierw ustaw typ, a następnie użyj odpowiedniego obiektu przejścia z [getValue].

Poniższy przykład stosuje przejście Cut do pierwszego slajdu pliku `input.pptx`. Wywołuje [setFromBlack] poprzez [OptionalBlackTransition], aby przejście zaczynało się od czarnego ekranu.

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

Tak. Preferuj [setDuration], gdy potrzebujesz dokładnego czasu trwania efektu w milisekundach. Użyj [setSpeed], gdy wystarcza predefiniowana kategoria [TransitionSpeed] — Slow, Medium lub Fast — i nie jest ustawiony wyraźny czas trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przechodzenia.

**Czy mogę dołączyć dźwięk do przejścia i spowodować jego pętlę?**

Tak. Przypisz osadzony dźwięk za pomocą [setSound], przekaż StartSound z wyliczenia [TransitionSoundMode] do [setSoundMode] oraz włącz [setSoundLoop] z wartością `true`. Dźwięk będzie się powtarzał aż do kolejnego zdarzenia dźwiękowego w pokazie slajdów.

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Iteruj przez kolekcję [getSlides] prezentacji i wywołaj [setType] z tą samą wartością dla przejścia każdego slajdu. Ustaw wszelkie opcje timingowe i efektowe w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Wywołaj [getType] na wyniku [getSlideShowTransition] slajdu. Zwraca on wartość z wyliczenia [TransitionType]; None oznacza, że żaden efekt przejścia nie jest zastosowany.