---
title: Zarządzanie przejściami slajdów w prezentacjach przy użyciu PHP
linktitle: Przejście slajdu
type: docs
weight: 80
url: /pl/php-java/slide-transition/
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
- PHP
- Aspose.Slides
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść za pomocą Aspose.Slides dla PHP przez Java."
---
## **Przegląd**

Przejścia slajdów kontrolują sposób wyświetlania slajdów podczas pokazu slajdów. Za pomocą Aspose.Slides for PHP via Java można wybrać efekt przejścia dla każdego slajdu, skonfigurować przejście po kliknięciu myszy lub automatycznie po upływie czasu oraz dostosować opcje specyficzne dla efektu. W tym artykule użyto przykładów w PHP, aby zastosować przejścia, ustawić dokładne czasy trwania przejść, zarządzać czasem wyświetlania slajdów oraz utworzyć przejście Morph pomiędzy dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) . Następnie uzyskaj dostęp do ustawień przejścia slajdu za pomocą [getSlideShowTransition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getSlideShowTransition). Użyj [setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setType) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle do pierwszego slajdu oraz przejście Comb do drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi do kolejnego slajdu. Następujące metody kontrolują to zachowanie:

- [setAdvanceOnClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) umożliwia widzowi przejście po kliknięciu myszy.
- [setAdvanceAfter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) włącza automatyczne przejście.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz zarówno przejście po kliknięciu, jak i czasowe, aby widz mógł przejść kliknięciem lub poczekać na timer. Aby używać tylko timera, przekaż `false` do [setAdvanceOnClick](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Opóźnienie kontroluje, kiedy pokaz slajdów przechodzi dalej; nie ustawia czasu trwania wizualnego efektu przejścia.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przejście po odpowiednio 3, 5 i 7 sekundach. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Aby sprawdzić, czy czasowe przejście jest włączone, wywołaj [getAdvanceAfter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Sam zapisany czas opóźnienia nie oznacza, że timer jest aktywny.

Następny przykład otwiera wcześniej zapisany plik, raportuje każdy włączony timer i wyłącza automatyczne przejście dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Precyzyjna kontrola czasu przejścia**

Użyj [setDuration](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setDuration), aby określić dokładną długość efektu przejścia w milisekundach. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu udostępnia te ustawienia poprzez [SlideShowTransition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/):

| Metoda | Cel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setDuration) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Przekaż `true` do [setAdvanceAfter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter), aby aktywować ten timer. |
| [setSpeed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setSpeed) | Wybiera predefiniowaną kategorię prędkości z [TransitionSpeed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitionspeed/): Slow, Medium lub Fast. Jest używana, gdy nie określono dokładnego czasu trwania. |

[setDuration] kontroluje tylko efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przejścia należy skonfigurować oddzielnie. Gdy nie zostanie ustawiony wyraźny czas trwania, Aspose.Slides określa czas trwania efektu na podstawie typu przejścia i wartości [getSpeed].

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Aby zachować jednolite tempo, zastosuj ten sam efekt i dokładny czas trwania dla każdego slajdu. Ten przykład ładuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitiontype/), i ustawia czas trwania każdego przejścia na 750 milisekund. Oddzielnie włącza automatyczne przejście po 5 000 milisekundach i wyłącza przejście po kliknięciu myszy, po czym zapisuje wynik jako PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Skonfiguruj automatyczne przejście niezależnie od czasu trwania efektu.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ustaw różne czasy trwania dla poszczególnych slajdów**

Różne slajdy mogą mieć różne czasy trwania efektu. Na przykład, użyj krótkiego przejścia dla slajdu tytułowego i dłuższego dla wprowadzenia sekcji. Ten przykład ustawia 500 milisekund dla pierwszego slajdu i 1 200 milisekund dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Koordynuj przejścia z animowanym wyjściem**

Przy przygotowywaniu [animowanego GIF-a](/slides/pl/php-java/convert-powerpoint-to-animated-gif/), [prezentacji HTML5](/slides/pl/php-java/export-to-html5/) lub [wideo](/slides/pl/php-java/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj 600‑milisekundowego zanikania (fade) między scenami i oddzielnie dostosuj opóźnienie przejścia każdego slajdu, aby zapewnić czas na narrację lub zawartość.

Dla GIF‑ów i wideo, skoordynuj liczbę klatek wyjściowych z czasem trwania efektu: 600 milisekund odpowiada 18 klatkom przy 30 klatkach na sekundę. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje timingowe są wspierane w wybranym formacie eksportu i podglądnij wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Wywołaj [getDuration](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#getDuration) przed modyfikacją przejścia, aby ustalić, czy przechowywana jest wyraźna wartość. Wartość `-1` oznacza, że nie ustawiono konkretnego czasu trwania; wartość nieujemna określa przechowywany czas w milisekundach. Nieustawiona wartość nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#getSpeed) do określenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, dlatego najpierw sprawdź oryginalne ustawienia.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Przejście Morph**

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby stworzyć prosty efekt Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu w klonie i zastosuj przejście Morph do drugiego slajdu. Dzięki temu przejście animuje odpowiadające obiekty pomiędzy ich pierwotnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje slajd i zmienia pozycję oraz rozmiar prostokąta w klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu slajdów.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Typy przejścia Morph**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitionmorphtype/) kontroluje sposób dopasowywania i animacji zawartości przez Morph:

- [ByObject](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitionmorphtype/#ByObject) traktuje każdy kształt jako cały obiekt.
- [ByWord](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitionmorphtype/#ByWord) animuje tekst, dopasowując słowa tam, gdzie to możliwe.
- [ByChar](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitionmorphtype/#ByChar) animuje tekst, dopasowując znaki tam, gdzie to możliwe.

Użyj [setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setType), aby wybrać Morph przed dostępem do [getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#getValue). Uzyskana wartość zwraca obiekt [MorphTransition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/morphtransition/), którego metoda [setMorphType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/morphtransition/#setMorphType) wybiera tryb dopasowywania.

Ten przykład otwiera prezentację utworzoną w poprzedniej sekcji i konfiguruje drugi slajd do użycia animacji Morph opartej na słowach.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Ustaw efekty przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt zaczyna się od czarnego ekranu. Dostępne opcje zależą od przejścia wybranego przy użyciu [setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setType). Najpierw ustaw typ, a następnie użyj odpowiedniego obiektu przejścia z [getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#getValue).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu pliku `input.pptx`. Wywołuje [setFromBlack](https://reference.aspose.com/slides/pl/php-java/aspose.slides/optionalblacktransition/#setFromBlack) poprzez [OptionalBlackTransition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/optionalblacktransition/), aby przejście rozpoczynało się od czarnego ekranu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Użyj [setDuration](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setDuration), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [setSpeed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setSpeed), gdy wystarczy predefiniowana kategoria [TransitionSpeed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitionspeed/) — Slow, Medium lub Fast — i nie jest ustawiony wyraźny czas trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przejścia.

**Czy mogę dołączyć dźwięk do przejścia i sprawić, że będzie się powtarzał?**

Tak. Przypisz osadzony dźwięk za pomocą [setSound](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setSound), przekaż StartSound z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setSoundMode) i włącz [setSoundLoop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setSoundLoop) ustawiając `true`. Dźwięk będzie powtarzał się, aż do kolejnego zdarzenia dźwiękowego w pokazie slajdów.

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Iteruj po kolekcji [getSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getSlides) prezentacji i wywołuj [setType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#setType) z tą samą wartością dla przejścia każdego slajdu. Ustaw wszelkie opcje czasu i efektu w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Wywołaj [getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/#getType) na wyniku [getSlideShowTransition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu. Zwraca on wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitiontype/); None oznacza, że żaden efekt przejścia nie jest zastosowany.