---
title: Zarządzanie przejściami slajdów w prezentacjach przy użyciu języka Java
linktitle: Przejście slajdu
type: docs
weight: 80
url: /pl/java/slide-transition/
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
- Java
- Aspose.Slides
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść za pomocą Aspose.Slides dla Javy."
---
## **Przegląd**

Przejścia slajdów kontrolują sposób wyświetlania slajdów podczas pokazu. W Aspose.Slides for Java możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie po kliknięciu myszy lub po upłynięciu określonego czasu oraz dostosować opcje specyficzne dla danego efektu. Ten artykuł używa przykładów w Javie, aby zastosować przejścia, ustawić dokładny czas trwania przejścia, zarządzać synchronizacją slajdów oraz utworzyć przejście Morph pomiędzy dwoma slajdami. Przykłady pokazują także, jak zapisać ustawienia do pliku PPTX.

## **Dodawanie przejścia slajdu**

Aby zastosować przejście, wczytaj prezentację przy pomocy klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) i uzyskaj dostęp do ustawień przejścia slajdu poprzez [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Użyj [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), a następnie zapisz prezentację.

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

## **Przejście kołowe (Wheel Transition)**

Metoda [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) interfejsu [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) kontroluje liczbę promieniowych sektorów odsłaniających docelowy slajd. Ustaw typ przejścia slajdu na Wheel przy pomocy [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) używając [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) przed uzyskaniem [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) jako [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/).

Ten przykład tworzy dwie identyczne pary slajdów: czarny slajd, po którym następuje slajd ze złotym prostokątem. Slajdy docelowe używają liczby promieni 1 i 8, przy tej samej prędkości ustawionej przez [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) oraz wyraźnym czasem trwania 8 000 ms ustawionym przez [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-), aby różnicę było łatwo zauważyć.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otwórz wyjściową prezentację w PowerPoint i uruchom pokaz slajdów. Przejdź ze slajdu 1 do slajdu 2, a następnie ze slajdu 3 do slajdu 4. W odtwarzaniu PowerPoint zweryfikowana liczba promieni 1 odsłania slajd jednym ruchem zgodnie z ruchem wskazówek zegara; liczba 8 odsłania go ośmioma promieniami jednocześnie. Zawartość docelowa i synchronizacja przejścia są identyczne, różni je jedynie liczba sektorów odsłaniania.

## **Dodawanie zaawansowanego przejścia slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie oraz czy kliknięcie myszy przechodzi do następnego slajdu. Następujące metody kontrolują to zachowanie:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) umożliwia widzowi przejście po kliknięciu myszy.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) włącza automatyczne przechodzenie.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz oba tryby – kliknięcie i odliczanie – aby widz mógł przejść po kliknięciu lub po upływie czasu. Aby używać wyłącznie odliczania, przekaż `false` do [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Opóźnienie steruje momentem przejścia pokazu, a nie czasem trwania samego efektu wizualnego.

Ten przykład przypisuje różne efekty do pierwszych trzech slajdów i włącza automatyczne przejście po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

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

Aby sprawdzić, czy automatyczne przejście jest włączone, wywołaj [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Sama przechowywana wartość opóźnienia nie oznacza, że licznik jest aktywny.

Kolejny przykład otwiera zapisany wcześniej plik, wypisuje każdy włączony licznik i wyłącza automatyczne przejście dla slajdów z opóźnieniem większym niż dwie sekundy. Dla tych slajdów włącza kliknięcia myszy i zapisuje zaktualizowane ustawienia.

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

Użyj [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) aby określić dokładną długość efektu przejścia w milisekundach. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) slajdu udostępnia te ustawienia poprzez interfejs [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Metoda | Cel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Przekaż `true` do [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) aby aktywować licznik. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Wybiera predefiniowaną kategorię prędkości z [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium lub Fast. Używane, gdy nie podano dokładnego czasu trwania. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) kontroluje wyłącznie efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Opóźnienie automatycznego przejścia należy ustawić osobno. Gdy nie ustawiono wyraźnego czasu, Aspose.Slides określa czas trwania na podstawie typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Wspólny przykład nadaje każdemu slajdowi przejście Fade trwające 750 ms oraz oddzielnie włącza automatyczne przejście po 5 000 ms. Czas trwania przejścia kontroluje efekt; przejście kontroluje moment opuszczenia slajdu. Te paski to schematyczne ustawienia, a nie zmierzona łączna oś czasu.*
<!-- visual-explanation:slide-transition:end -->

### **Zastosowanie tego samego czasu trwania dla wszystkich slajdów**

Aby uzyskać jednolite tempo, zastosuj ten sam efekt i dokładny czas trwania do każdego slajdu. Ten przykład wczytuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) i nadaje każdemu przejściu czas 750 ms. Oddzielnie włącza automatyczne przejście po 5 000 ms i wyłącza przejście po kliknięciu myszy, po czym zapisuje wynik jako PPTX.

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

### **Ustawianie różnych czasów trwania dla poszczególnych slajdów**

Różne slajdy mogą mieć różne czasy trwania efektów. Na przykład krótki przejście dla slajdu tytułowego i dłuższy dla wprowadzenia sekcji. Ten przykład ustawia 500 ms dla pierwszego slajdu i 1 200 ms dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

### **Koordynacja przejść z animowanym wyjściem**

Podczas przygotowywania [animated GIF](/slides/pl/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pl/java/export-to-html5/) lub [video](/slides/pl/java/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby dopasować je do zamierzonego tempa. Na przykład użyj przejścia Fade trwającego 600 ms między scenami i osobno dostosuj opóźnienie przejścia każdego slajdu, aby umożliwić narrację lub treść.

W przypadku GIF i wideo skoordynuj liczbę klatek wyjściowych z czasem trwania efektu: 600 ms odpowiada 18 klatkom przy 30 klatkach na sekundę. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje synchronizacji obsługuje wybrany format eksportu i przeglądaj wynik, aby potwierdzić synchronizację.

### **Odczyt istniejącego czasu trwania przejścia**

Wywołaj [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) przed modyfikacją przejścia, aby określić, czy przechowywana jest wyraźna wartość. Wartość `-1` oznacza brak ustalonego czasu; nieujemna wartość określa zapisany czas w milisekundach. Nieustawiona wartość nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) do określenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, dlatego najpierw sprawdź pierwotne ustawienia.

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

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby stworzyć proste przejście Morph, sklonuj slajd, przesuń lub zmień rozmiar obiektu w klonie i zastosuj przejście Morph do drugiego slajdu. Dzięki temu odpowiednie obiekty są animowane pomiędzy ich pierwotnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje slajd i zmienia położenie oraz rozmiar prostokąta w klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu.

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

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) określa, w jaki sposób Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) traktuje każdy kształt jako cały obiekt.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) animuje tekst, dopasowując słowa tam, gdzie to możliwe.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) animuje tekst, dopasowując znaki tam, gdzie to możliwe.

Użyj [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) aby wybrać Morph przed uzyskaniem [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--). Uzyskana wartość zwraca interfejs [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/), którego metoda [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) wybiera tryb dopasowania.

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

## **Ustawianie efektów przejścia**

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub rozpoczęcie efektu od czarnego ekranu. Dostępne opcje zależą od przejścia wybranego przy pomocy [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-). Najpierw ustaw typ, a potem użyj odpowiedniego interfejsu zwróconego przez [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu pliku `input.pptx`. Wywołuje [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) poprzez [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/), aby przejście rozpoczynało się od czarnego ekranu.

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

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Używaj [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Używaj [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-), gdy wystarczy kategoria [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) – Slow, Medium lub Fast – i nie jest ustawiony wyraźny czas trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przejścia.

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Przypisz osadzony dźwięk przy pomocy [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), przekaż `StartSound` z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), i włącz [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) z wartością `true`. Dźwięk będzie powtarzany, aż do kolejnego zdarzenia dźwiękowego w pokazie.

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do wszystkich slajdów?**

Iteruj po kolekcji [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) prezentacji i wywołaj [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) z tą samą wartością dla przejścia każdego slajdu. W tej samej pętli ustaw wszelkie opcje czasu i efektu, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Wywołaj [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) na wyniku [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) slajdu. Zwróci wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); `None` oznacza brak zastosowanego efektu przejścia.