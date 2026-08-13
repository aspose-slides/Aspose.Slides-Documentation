---
title: Zarządzanie przejściami slajdów w prezentacjach przy użyciu Java
linktitle: Przejście slajdu
type: docs
weight: 80
url: /pl/java/slide-transition/
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
- Java
- Aspose.Slides
description: "Odkryj, jak dostosować przejścia slajdów w Aspose.Slides dla Java, krok po kroku, dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać przejściami slajdów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak zastosować typy przejść do slajdów, skonfigurować zachowanie przejścia, takie jak przechodzenie po kliknięciu lub po określonym czasie, sprawdzić i wyłączyć automatyczne przechodzenie, używać przejścia Morph i jego typów oraz ustawiać opcje efektów przejścia. Przykłady demonstrują, jak wczytać lub utworzyć prezentację, zmodyfikować ustawienia przejść dla wybranych slajdów i zapisać wynik jako plik PPTX. Artykuł odpowiada także na częste pytania dotyczące szybkości przejścia, dźwięków przejść, stosowania tego samego przejścia do wielu slajdów oraz sprawdzania, które przejście jest aktualnie ustawione na slajdzie.

## **Dodaj przejście slajdu**
Aby stworzyć prosty efekt przejścia slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z efektów przejścia oferowanych przez Aspose.Slides for Java przy użyciu wyliczenia TransitionType.
3. Zapisz zmodyfikowany plik prezentacji.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, aby wczytać źródłowy plik prezentacji
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Zastosuj przejście typu circle na slajdzie 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Zastosuj przejście typu comb na slajdzie 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Zapisz prezentację na dysku
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj zaawansowane przejście slajdu**
W powyższej sekcji zastosowaliśmy prosty efekt przejścia na slajdzie. Aby uczynić ten efekt lepszym i bardziej kontrolowanym, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z efektów przejścia oferowanych przez Aspose.Slides for Java.
3. Możesz także ustawić przejście na automatyczne przechodzenie po kliknięciu, po określonym czasie lub oba te warunki.
4. Jeśli przejście slajdu jest włączone z opcją Advance On Click, przejście będzie kontynuowane tylko po kliknięciu myszy. Ponadto, jeśli ustawiono właściwość Advance After Time, przejście rozpocznie się automatycznie po upłynięciu określonego czasu.
5. Zapisz zmodyfikowaną prezentację jako plik prezentacji.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Zastosuj przejście typu circle na slajdzie 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Ustaw czas przejścia na 3 sekundy
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Zastosuj przejście typu comb na slajdzie 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Ustaw czas przejścia na 5 sekund
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Zastosuj przejście typu zoom na slajdzie 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Ustaw czas przejścia na 7 sekund
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Zapisz prezentację na dysku
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Przejście Morph**
{{% alert color="info" %}} 

Aspose.Slides for Java obsługuje teraz [Morph Transition](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IMorphTransition). Są to nowe przejścia Morph wprowadzone w programie PowerPoint 2019.

{{% /alert %}} 

Przejście Morph umożliwia animację płynnego przejścia z jednego slajdu do następnego. Ten artykuł opisuje koncepcję i sposób użycia przejścia Morph. Aby efektywnie korzystać z przejścia Morph, potrzebujesz dwóch slajdów z co najmniej jednym wspólnym obiektem. Najłatwiejszy sposób to zduplikowanie slajdu, a następnie przeniesienie obiektu na drugim slajdzie w inne miejsce.

Poniższy fragment kodu pokazuje, jak dodać klon slajdu z tekstem do prezentacji i ustawić przejście typu [morph type](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TransitionType) na drugim slajdzie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Typy przejść Morph**
Nowe wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TransitionMorphType) zostało dodane. Reprezentuje różne typy przejść Morph slajdu.

Wyliczenie TransitionMorphType posiada trzy człony:

- ByObject: Przejście Morph będzie wykonywane z uwzględnieniem kształtów jako niepodzielnych obiektów.
- ByWord: Przejście Morph będzie wykonywane poprzez przenoszenie tekstu słowo po słowie, jeśli to możliwe.
- ByChar: Przejście Morph będzie wykonywane poprzez przenoszenie tekstu znak po znaku, jeśli to możliwe.

Poniższy fragment kodu pokazuje, jak ustawić przejście Morph na slajdzie i zmienić typ Morph:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw efekty przejścia**
Aspose.Slides for Java obsługuje ustawianie efektów przejścia, takich jak „z czerni”, „z lewej”, „z prawej” itp. Aby ustawić efekt przejścia, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
- Pobierz referencję do slajdu.
- Ustaw efekt przejścia.
- Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).

W poniższym przykładzie ustawiliśmy efekty przejścia.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Ustaw efekt
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Zapisz prezentację na dysku
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?

Tak. Ustaw prędkość przejścia za pomocą ustawienia [TransitionSpeed](https://reference.aspose.com/slides/pl/java/com.aspose.slides/transitionspeed/) (np. wolna/średnia/szybka).

### Czy mogę dołączyć dźwięk do przejścia i ustawić go w pętli?

Tak. Możesz osadzić dźwięk w przejściu i kontrolować zachowanie przy pomocy ustawień takich jak tryb dźwięku i pętla (np. [setSound](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadane takie jak [setSoundIsBuiltIn](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) i [setSoundName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?

Skonfiguruj żądany typ przejścia w ustawieniach przejścia każdego slajdu; przejścia są przechowywane per slajd, więc zastosowanie tego samego typu we wszystkich slajdach daje spójny wynik.

### Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?

Sprawdź ustawienia przejścia slajdu ([transition settings](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslide/#getSlideShowTransition--)) i odczytaj jego [transition type](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setType-int-); ta wartość dokładnie określa, jaki efekt jest zastosowany.