---
title: "Zarządzanie przejściami slajdów w prezentacjach przy użyciu Java"
linktitle: "Przejście slajdu"
type: docs
weight: 80
url: /pl/java/slide-transition/
keywords:
  - "przejście slajdu"
  - "dodaj przejście slajdu"
  - "zastosuj przejście slajdu"
  - "zaawansowane przejście slajdu"
  - "przejście morph"
  - "typ przejścia"
  - "efekt przejścia"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentacja"
  - "Java"
  - "Aspose.Slides"
description: "Odkryj, jak dostosować przejścia slajdów w Aspose.Slides dla Java, z krok po kroku instrukcjami dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać przejściami slajdów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak zastosować typy przejść do slajdów, konfigurować zachowanie przejścia, takie jak przechodzenie po kliknięciu lub po określonym czasie, sprawdzać i wyłączać automatyczne przechodzenie, używać przejścia Morph i jego typów oraz ustawiać opcje efektów przejścia. Przykłady demonstrują, jak wczytać lub utworzyć prezentację, zmodyfikować ustawienia przejść dla wybranych slajdów i zapisać wynik jako plik PPTX. Artykuł odpowiada także na typowe pytania dotyczące prędkości przejścia, dźwięków przejścia, zastosowania tego samego przejścia do wielu slajdów oraz sprawdzania, które przejście jest obecnie ustawione na slajdzie.

## **Dodaj przejście slajdu**
Aby utworzyć prosty efekt przejścia slajdu, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z efektów przejścia oferowanych przez Aspose.Slides for Java za pośrednictwem wyliczenia TransitionType.
3. Zapisz zmodyfikowany plik prezentacji.

```java
// Utwórz instancję klasy Presentation, aby wczytać plik prezentacji źródłowej
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Zastosuj przejście typu circle na slajdzie 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Zastosuj przejście typu comb na slajdzie 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Zapisz prezentację na dysk
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj zaawansowane przejście slajdu**
W powyższej sekcji zastosowaliśmy tylko prosty efekt przejścia na slajdzie. Teraz, aby uczynić ten prosty efekt przejścia jeszcze lepszym i kontrolowanym, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z efektów przejścia oferowanych przez Aspose.Slides for Java.
3. Możesz również ustawić przejście na „Advance On Click”, po określonym czasie lub oba te warunki.
4. Jeśli przejście slajdu jest włączone na „Advance On Click”, przejście nastąpi tylko po kliknięciu myszy. Ponadto, jeśli ustawiona jest właściwość „Advance After Time”, przejście nastąpi automatycznie po upływie określonego czasu.
5. Zapisz zmodyfikowaną prezentację jako plik prezentacji.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Zastosuj przejście typu circle na slajdzie 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Ustaw czas trwania przejścia na 3 sekundy
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Zastosuj przejście typu comb na slajdzie 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Ustaw czas trwania przejścia na 5 sekund
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Zastosuj przejście typu zoom na slajdzie 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Ustaw czas trwania przejścia na 7 sekund
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Zapisz prezentację na dysku
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Przejście Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Java obsługuje teraz [Morph Transition](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IMorphTransition). Reprezentują nowy przejście morph wprowadzone w PowerPoint 2019.

{{% /alert %}} 

Przejście Morph umożliwia animowanie płynnego przemieszczenia z jednego slajdu do następnego. Ten artykuł opisuje koncepcję i sposób użycia przejścia Morph. Aby skutecznie używać przejścia Morph, potrzebujesz dwóch slajdów z co najmniej jednym wspólnym obiektem. Najprostszym sposobem jest zduplikowanie slajdu, a następnie przeniesienie obiektu na drugim slajdzie w inne miejsce.

Poniższy fragment kodu pokazuje, jak dodać klon slajdu z pewnym tekstem do prezentacji i ustawić przejście typu [morph type](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TransitionType) na drugim slajdzie.

```java
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

## **Typy przejścia Morph**
Dodano nową wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TransitionMorphType). Reprezentuje ono różne typy przejścia Morph slajdu.

Wyliczenie TransitionMorphType ma trzy elementy:

- ByObject: przejście Morph będzie wykonywane z uwzględnieniem kształtów jako niepodzielnych obiektów.
- ByWord: przejście Morph będzie wykonywane poprzez przenoszenie tekstu słowo po słowie, gdy to możliwe.
- ByChar: przejście Morph będzie wykonywane poprzez przenoszenie tekstu znak po znaku, gdy to możliwe.

Poniższy fragment kodu pokazuje, jak ustawić przejście morph na slajdzie i zmienić typ morph:

```java
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
Aspose.Slides for Java obsługuje ustawianie efektów przejścia, takich jak z czerni, z lewej, z prawej itd. Aby ustawić efekt przejścia, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
- Pobierz odniesienie do slajdu.
- Ustaw efekt przejścia.
- Zapisz prezentację jako plik [PPTX ](https://docs.fileformat.com/presentation/pptx/).

W poniższym przykładzie ustawiliśmy efekty przejścia.

```java
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

**Czy mogę sterować prędkością odtwarzania przejścia slajdu?**

Tak. Ustaw prędkość przejścia za pomocą [speed](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) przy użyciu ustawienia [TransitionSpeed](https://reference.aspose.com/slides/pl/java/com.aspose.slides/transitionspeed/) (np. wolna/średnia/szybka).

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Możesz osadzić dźwięk do przejścia i sterować zachowaniem przy pomocy ustawień, takich jak tryb dźwięku i pętla (np. [setSound](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), a także metadane takie jak [setSoundIsBuiltIn](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) i [setSoundName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Skonfiguruj pożądany typ przejścia w ustawieniach przejścia każdego slajdu; przejścia są przechowywane osobno dla każdego slajdu, więc zastosowanie tego samego typu we wszystkich slajdach zapewnia spójny efekt.

**Jak mogę sprawdzić, które przejście jest obecnie ustawione na slajdzie?**

Sprawdź [ustawienia przejścia](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseslide/#getSlideShowTransition--) slajdu i odczytaj jego [typ przejścia](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowtransition/#setType-int-); ta wartość dokładnie wskazuje, jaki efekt jest zastosowany.