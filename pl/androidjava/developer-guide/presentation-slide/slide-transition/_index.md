---
title: Zarządzanie przejściami slajdów w prezentacjach na Androidzie
linktitle: Przejście slajdu
type: docs
weight: 80
url: /pl/androidjava/slide-transition/
keywords:
- przejście slajdu
- dodaj przejście slajdu
- zastosuj przejście slajdu
- zaawansowane przejście slajdu
- przejście Morph
- typ przejścia
- efekt przejścia
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj przejścia Morph i inne efekty przejść przy użyciu Aspose.Slides for Android via Java."
---
## **Przegląd**

Przejścia slajdów kontrolują, jak slajdy pojawiają się podczas pokazu slajdów. Za pomocą Aspose.Slides for Android via Java możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie po kliknięciu myszy lub timerem oraz dostosować opcje specyficzne dla efektu. Ten artykuł wykorzystuje przykłady w języku Java do zastosowania przejść, ustawienia dokładnych czasów trwania przejścia, zarządzania czasem slajdu oraz stworzenia przejścia Morph między dwoma slajdami. Przykłady pokazują również, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i uzyskaj dostęp do ustawień przejścia slajdu poprzez [getSlideShowTransition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Użyj [setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle do pierwszego slajdu i przejście Comb do drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi dalej w pokazie. Następujące metody kontrolują to zachowanie:

- [setAdvanceOnClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) pozwala widzowi przejść po kliknięciu myszy.
- [setAdvanceAfter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) włącza automatyczne przechodzenie.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz jednocześnie przejście po kliknięciu i po upływie czasu, aby widz mógł kontynuować kliknięciem lub poczekać na timer. Aby używać tylko timera, przekaż `false` do [setAdvanceOnClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Opóźnienie kontroluje, kiedy pokaz slajdów przechodzi dalej; nie ustawia ono czasu trwania wizualnego efektu przejścia.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przechodzenie po odpowiednio 3, 5 i 7 sekundach. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Aby sprawdzić, czy przejście czasowe jest włączone, wywołaj [getAdvanceAfter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Sam zapisany odstęp nie oznacza, że timer jest aktywny.

Następny przykład otwiera wcześniej zapisany plik, raportuje każdy włączony timer i wyłącza automatyczne przechodzenie dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Precyzyjna kontrola czasu przejścia**

Użyj [setDuration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) aby określić dokładną długość efektu przejścia w milisekundach. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) udostępnia te ustawienia poprzez interfejs [ISlideShowTransition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/):

| Metoda | Cel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Przekaż `true` do [setAdvanceAfter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) aby aktywować ten timer. |
| [setSpeed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Wybiera predefiniowaną kategorię prędkości z [TransitionSpeed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium lub Fast. Jest używana, gdy nie określono dokładnego czasu trwania. |

[setDuration] kontroluje tylko efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przechodzenia należy skonfigurować osobno. Gdy nie zostanie ustawiony explicite czas trwania, Aspose.Slides określa go na podstawie typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Aby uzyskać jednolite tempo, zastosuj ten sam efekt i dokładny czas trwania do każdego slajdu. Ten przykład ładuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitiontype/) i nadaje każdemu przejściu czas trwania 750 milisekund. Oddzielnie włącza automatyczne przechodzenie po 5 000 milisekund i wyłącza przechodzenie po kliknięciu myszy, a następnie zapisuje wynik jako PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Skonfiguruj automatyczne przechodzenie niezależnie od czasu trwania efektu.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ustaw różne czasy trwania dla poszczególnych slajdów**

Różne slajdy mogą mieć różne czasy trwania efektu. Na przykład można użyć krótkiego przejścia dla slajdu tytułowego i dłuższego dla wprowadzenia sekcji. Ten przykład ustawia 500 ms dla pierwszego slajdu i 1 200 ms dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Koordynuj przejścia z animowanym wyjściem**

Podczas przygotowywania [animated GIF](/slides/pl/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pl/androidjava/export-to-html5/) lub [video](/slides/pl/androidjava/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować tempo. Na przykład użyj 600‑milisekundowego zaniku między scenami i osobno dostosuj opóźnienie przechodzenia slajdu, aby umożliwić narrację lub treść.

Dla GIF‑a i wideo, skoordynuj liczbę klatek wyjściowych z czasem trwania efektu: 600 ms odpowiada 18 klatkom przy 30 fps. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje czasowe są obsługiwane przez wybrany format eksportu i podglądaj wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Wywołaj [getDuration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) przed modyfikacją przejścia, aby sprawdzić, czy zapisano explicite wartość. Wartość `-1` oznacza, że nie ustawiono wyraźnego czasu trwania; wartość nieujemna określa przechowywany czas w milisekundach. Brak ustawionej wartości nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) do określenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, dlatego najpierw sprawdź oryginalne ustawienia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Przejście Morph**

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby stworzyć proste przejście Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu na klonie i zastosuj przejście Morph do drugiego slajdu. Daje to obiektom przejścia możliwość animacji pomiędzy ich oryginalnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje go i zmienia położenie oraz rozmiar prostokąta na klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt w trakcie pokazu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Typy przejścia Morph**

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitionmorphtype/) określa, jak Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) traktuje każdy kształt jako cały obiekt.
- [ByWord](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) animuje tekst, dopasowując słowa, gdy to możliwe.
- [ByChar](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) animuje tekst, dopasowując znaki, gdy to możliwe.

Użyj [setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) aby wybrać Morph przed dostępem do [getValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#getValue--). Uzyskana wartość udostępnia interfejs [IMorphTransition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imorphtransition/), którego metoda [setMorphType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) wybiera tryb dopasowania.

Ten przykład otwiera prezentację utworzoną w poprzedniej sekcji i konfiguruje drugi slajd do animacji Morph opartej na słowach.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Ustaw efekty przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt zaczyna się od czarnego ekranu. Dostępne opcje zależą od przejścia wybranego za pomocą [setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Najpierw ustaw typ, a potem użyj odpowiedniego interfejsu z [getValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu `input.pptx`. Wywołuje [setFromBlack](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) poprzez [IOptionalBlackTransition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ioptionalblacktransition/), aby przejście zaczynało się od czarnego ekranu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę kontrolować szybkość odtwarzania przejścia slajdu?**

Tak. Preferuj [setDuration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [setSpeed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-), gdy wystarczy predefiniowana kategoria [TransitionSpeed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitionspeed/) – Slow, Medium lub Fast – i nie jest ustawiony explicite czas trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przechodzenia.

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Przypisz wbudowany dźwięk za pomocą [setSound](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), przekaż `StartSound` z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), i włącz [setSoundLoop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) z wartością `true`. Dźwięk będzie powtarzany, aż nastąpi kolejne zdarzenie dźwiękowe w pokazie.

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Przejdź pętlą po kolekcji [getSlides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getSlides--) prezentacji i wywołaj [setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) z tą samą wartością dla przejścia każdego slajdu. Ustaw wszelkie opcje czasowe i efektowe w tej samej pętli, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Wywołaj [getType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islideshowtransition/#getType--) na wyniku [getSlideShowTransition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) slajdu. Zwróci wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitiontype/); None oznacza, że żaden efekt przejścia nie jest zastosowany.