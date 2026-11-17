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
description: "Zastosuj przejścia slajdów, skonfiguruj automatyczne przechodzenie slajdów oraz dostosuj Morph i inne efekty przejść przy użyciu Aspose.Slides dla Androida w Java."
---
## **Przegląd**

Przejścia slajdów kontrolują, jak slajdy pojawiają się podczas pokazu slajdów. Za pomocą Aspose.Slides for Android via Java możesz wybrać efekt przejścia dla każdego slajdu, skonfigurować przechodzenie za pomocą kliknięcia myszy lub timera oraz dostosować opcje specyficzne dla efektu. W tym artykule użyto przykładów w języku Java do zastosowania przejść, ustawienia dokładnych czasów trwania przejść, zarządzania czasem slajdów oraz stworzenia przejścia Morph pomiędzy dwoma slajdami. Przykłady pokazują również, jak zapisać ustawienia do pliku PPTX.

## **Dodaj przejście slajdu**

Aby zastosować przejście, załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) i uzyskaj dostęp do ustawień przejścia slajdu poprzez [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Użyj [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) z wartością z wyliczenia [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/), a następnie zapisz prezentację.

Poniższy przykład stosuje przejście Circle na pierwszym slajdzie oraz przejście Comb na drugim. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

## **Przejście kołowe**

Metoda [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) interfejsu [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) kontroluje liczbę promieniowych sektorów, które odsłaniają docelowy slajd. Ustaw typ przejścia slajdu na Wheel z [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) przy użyciu [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-), zanim uzyskasz dostęp do [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) jako [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/).

Ten przykład tworzy dwie identyczne pary slajdów: czarny slajd, po którym następuje slajd ze złotym prostokątem. Docelowe slajdy używają liczby promieni 1 i 8, przy tej samej prędkości ustawionej przez [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) oraz explicite określonego czasu trwania 8000 milisekund ustawionego przez [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-), aby różnicę było łatwo zaobserwować.

```java
import android.graphics.Color;
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
    int gold = Color.rgb(255, 215, 0);
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

Otwórz wyjściową prezentację w programie PowerPoint i uruchom pokaz slajdów. Przejdź z slajdu 1 do slajdu 2, a następnie z slajdu 3 do slajdu 4. W odtwarzaniu w PowerPoint zweryfikowana liczba promieni 1 odsłania slajd jednym ruchem zgodnym z kierunkiem zegara; zweryfikowana liczba 8 odsłania go przez osiem promieni jednocześnie. Zawartość docelowa i czas przejścia są identyczne, więc różnica polega na liczbie sektorów odsłaniania.

## **Dodaj zaawansowane przejście slajdu**

Możesz skonfigurować, jak długo slajd pozostaje na ekranie i czy kliknięcie myszy przechodzi do kolejnego slajdu. Następujące metody kontrolują to zachowanie:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) pozwala widzowi przejść po kliknięciu myszy.
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) włącza automatyczne przechodzenie.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) określa opóźnienie przed automatycznym przejściem, w milisekundach.

Włącz zarówno kliknięcie, jak i przejście czasowe, aby widz mógł przejść po kliknięciu lub poczekać na timer. Aby używać tylko timera, przekaż `false` do [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Opóźnienie kontroluje, kiedy pokaz slajdów przechodzi dalej; nie ustawia czasu trwania wizualnego efektu przejścia.

Ten przykład nadaje pierwszym trzem slajdom różne efekty i włącza automatyczne przejście po 3, 5 i 7 sekundach odpowiednio. Kliknięcia myszy również mogą przechodzić te slajdy. Użyj pliku `input.pptx` zawierającego co najmniej trzy slajdy.

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

Aby sprawdzić, czy automatyczne przejście czasowe jest włączone, wywołaj [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Sam zapisany opóźnienie nie wskazuje, że timer jest aktywny.

Następny przykład otwiera plik zapisany wyżej, raportuje każdy włączony timer i wyłącza automatyczne przejście dla slajdów z opóźnieniem większym niż dwie sekundy. Włącza kliknięcia myszy dla tych slajdów i zapisuje zaktualizowane ustawienia.

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

Użyj [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) aby określić dokładną długość efektu przejścia w milisekundach. Metoda [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) slajdu udostępnia te ustawienia poprzez [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/):

| Metoda | Cel |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Ustawia czas trwania samego efektu przejścia, w milisekundach. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Ustawia opóźnienie przed automatycznym przejściem slajdu, w milisekundach. Przekaż `true` do [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) aby aktywować ten timer. |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Wybiera wstępnie zdefiniowaną kategorię prędkości z [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium lub Fast. Używana, gdy nie określono dokładnego czasu trwania. |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) kontroluje tylko efekt przejścia; nie określa, jak długo slajd pozostaje widoczny. Skonfiguruj osobno opóźnienie automatycznego przejścia. Gdy nie ustawiono explicite czasu trwania, Aspose.Slides określa go na podstawie typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Oddzielne paski wskazują czas trwania przejścia 750‑ms oraz ustawienie automatycznego przejścia 5,000‑ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Wspólny przykład nadaje każdemu slajdowi przejście Fade trwające 750‑ms i oddzielnie włącza automatyczne przejście po 5,000‑ms. Czas trwania przejścia kontroluje efekt; przejście kontroluje, kiedy opuścić slajd. Te paski są schematycznymi ustawieniami, a nie zmierzoną łączną osią czasu.*
<!-- visual-explanation:slide-transition:end -->

### **Zastosuj ten sam czas trwania dla każdego slajdu**

Dla spójnego tempa zastosuj ten sam efekt i dokładny czas trwania dla każdego slajdu. Ten przykład ładuje `input.pptx`, wybiera Fade z [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) i nadaje każdemu przejściu czas trwania 750 milisekund. Oddzielnie włącza automatyczne przejście po 5,000 milisekund i wyłącza przejście po kliknięciu myszy, po czym zapisuje wynik jako PPTX.

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

Różne slajdy mogą używać różnych czasów trwania efektu. Na przykład użyj krótkiego przejścia dla slajdu tytułowego i dłuższego przejścia dla wprowadzenia sekcji. Ten przykład ustawia 500 milisekund dla pierwszego slajdu i 1,200 milisekund dla drugiego. Użyj pliku `input.pptx` zawierającego co najmniej dwa slajdy.

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

Podczas przygotowywania [animated GIF](/slides/pl/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pl/androidjava/export-to-html5/) lub [video](/slides/pl/androidjava/convert-powerpoint-to-video/), ustaw dokładne czasy trwania przejść przed eksportem, aby pasowały do zamierzonego tempa. Na przykład użyj przejścia Fade trwającego 600 milisekund między scenami i osobno dostosuj opóźnienie przejścia każdego slajdu, aby umożliwić czas na narrację lub zawartość.

Dla GIF i wideo skoordynuj liczbę klatek wyjściowych z czasem trwania efektu: 600 milisekund odpowiada 18 klatkom przy 30 klatkach na sekundę. W HTML5 włącz animowane przejścia w ustawieniach eksportu. Sprawdź, które efekty i opcje czasowe są obsługiwane przez wybrany format eksportu oraz podglądnij wynik, aby potwierdzić synchronizację.

### **Odczytaj istniejący czas trwania przejścia**

Wywołaj [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) przed modyfikacją przejścia, aby określić, czy jest zapisany explicite. Wartość `-1` oznacza, że nie ustawiono explicite czasu trwania; nieujemna wartość określa zapisany czas w milisekundach. Nieustawiona wartość nie jest obliczonym czasem odtwarzania: Aspose.Slides używa typu przejścia i wartości [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) do wyznaczenia tego czasu. Ustawienie typu przejścia może zainicjować czas trwania, więc najpierw sprawdź oryginalne ustawienia.

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

Przejście Morph animuje zmiany między obiektami na kolejnych slajdach. Aby stworzyć prosty efekt Morph, sklonuj slajd, przenieś lub zmień rozmiar obiektu na klonie i zastosuj przejście Morph do drugiego slajdu. To pozwala przejściu animować odpowiadające obiekty między ich oryginalnym a zmodyfikowanym stanem.

Poniższy przykład tworzy slajd z prostokątem tekstowym, klonuje slajd i zmienia pozycję oraz rozmiar prostokąta na klonie. Następnie wybiera Morph z wyliczenia [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) dla drugiego slajdu. Otwórz zapisany plik w przeglądarce prezentacji obsługującej Morph, aby zobaczyć efekt podczas pokazu slajdów.

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

Wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) kontroluje, w jaki sposób Morph dopasowuje i animuje zawartość:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) traktuje każdy kształt jako cały obiekt.
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) animuje tekst, dopasowując słowa, gdy to możliwe.
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) animuje tekst, dopasowując znaki, gdy to możliwe.

Użyj [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) aby wybrać Morph przed dostępem do [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--). Uzyskana wartość zapewnia interfejs [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/), którego metoda [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) wybiera tryb dopasowania.

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

Niektóre przejścia udostępniają dodatkowe opcje, takie jak kierunek lub czy efekt zaczyna się od czarnego ekranu. Dostępne opcje zależą od przejścia wybranego przy użyciu [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Najpierw ustaw typ, a potem użyj odpowiedniego interfejsu z [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

Poniższy przykład stosuje przejście Cut do pierwszego slajdu `input.pptx`. Wywołuje [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) poprzez [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/), aby przejście rozpoczynało się od czarnego ekranu.

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

Tak. Preferuj [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-), gdy potrzebny jest dokładny czas trwania efektu w milisekundach. Użyj [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-), gdy wystarczy wstępnie zdefiniowana kategoria [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) — Slow, Medium lub Fast — i nie ustawiono explicite czasu trwania. Te ustawienia kontrolują efekt przejścia niezależnie od opóźnienia automatycznego przejścia.

**Czy mogę dołączyć dźwięk do przejścia i sprawić, że będzie się powtarzać?**

Tak. Przypisz wbudowany dźwięk za pomocą [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), przekaż StartSound z wyliczenia [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) do [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), i włącz [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) z wartością `true`. Dźwięk będzie się powtarzał aż do następnego zdarzenia dźwiękowego w pokazie slajdów.

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Iteruj po kolekcji [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) prezentacji i wywołaj [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) z tą samą wartością dla przejścia każdego slajdu. W tym samym pętli ustaw także wszelkie opcje czasowe i efektowe, aby zachować spójne zachowanie we wszystkich slajdach.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Wywołaj [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) na wyniku [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) slajdu. Zwróci wartość z wyliczenia [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/); None oznacza, że żadne przejście nie jest zastosowane.