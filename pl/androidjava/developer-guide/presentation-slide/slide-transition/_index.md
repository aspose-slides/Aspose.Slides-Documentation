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
- przejście morph
- typ przejścia
- efekt przejścia
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak dostosować przejścia slajdów w Aspose.Slides dla Androida przy użyciu Javy, z instrukcją krok po kroku dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać przejściami slajdów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak zastosować typy przejść do slajdów, skonfigurować zachowanie przejścia, takie jak przechodzenie po kliknięciu lub po określonym czasie, sprawdzić i wyłączyć automatyczne przechodzenie, używać przejścia Morph i jego typów oraz ustawiać opcje efektów przejścia. Przykłady demonstrują, jak wczytać lub utworzyć prezentację, zmodyfikować ustawienia przejścia dla wybranych slajdów i zapisać wynik jako plik PPTX. Artykuł również odpowiada na często zadawane pytania dotyczące szybkości przejścia, dźwięków przejścia, stosowania tego samego przejścia do wielu slajdów oraz sprawdzania, które przejście jest aktualnie ustawione na slajdzie.

## **Dodaj przejście slajdu**

Aby utworzyć prosty efekt przejścia slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jeden z efektów przejść oferowanych przez Aspose.Slides for Android via Java przy użyciu wyliczenia TransitionType.
3. Zapisz zmodyfikowany plik prezentacji.

```java
// Utwórz instancję klasy Presentation, aby wczytać plik źródłowej prezentacji
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

W powyższej sekcji zastosowaliśmy jedynie prosty efekt przejścia na slajdzie. Teraz, aby uczynić ten prosty efekt przejścia jeszcze lepszym i lepiej kontrolowanym, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jeden z efektów przejść oferowanych przez Aspose.Slides for Android via Java.
3. Możesz również ustawić przejście na przechodzenie po kliknięciu, po określonym czasie lub oba te warunki.
4. Jeśli przejście slajdu jest włączone do przechodzenia po kliknięciu, przejście będzie postępować tylko po kliknięciu myszy. Ponadto, jeśli ustawiona jest właściwość Advance After Time, przejście będzie postępować automatycznie po upłynięciu określonego czasu.
5. Zapisz zmodyfikowaną prezentację jako plik prezentacji.

```java
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

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java obsługuje teraz [Morph Transition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IMorphTransition). Reprezentują nowy przejście morph wprowadzone w programie PowerPoint 2019.

{{% /alert %}} 

Przejście Morph pozwala animować płynny ruch z jednego slajdu do kolejnego. Ten artykuł opisuje koncepcję i sposób użycia przejścia Morph. Aby skutecznie korzystać z przejścia Morph, potrzebujesz dwóch slajdów posiadających przynajmniej jeden wspólny obiekt. Najłatwiejszym sposobem jest powielenie slajdu, a następnie przeniesienie obiektu na drugim slajdzie w inne miejsce.

Poniższy fragment kodu pokazuje, jak dodać klon slajdu z pewnym tekstem do prezentacji oraz ustawić przejście typu [morph type](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/TransitionType) na drugim slajdzie.

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

Dodano nowe wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/TransitionMorphType). Reprezentuje ono różne typy przejścia Morph slajdu.

Wyliczenie TransitionMorphType ma trzy elementy:

- ByObject: Przejście Morph będzie wykonywane z uwzględnieniem kształtów jako niepodzielnych obiektów.
- ByWord: Przejście Morph będzie wykonywane poprzez przenoszenie tekstu słowo po słowie, tam gdzie jest to możliwe.
- ByChar: Przejście Morph będzie wykonywane poprzez przenoszenie tekstu znak po znaku, tam gdzie jest to możliwe.

Poniższy fragment kodu pokazuje, jak ustawić przejście morph na slajdzie i zmienić jego typ:

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

Aspose.Slides for Android via Java obsługuje ustawianie efektów przejścia, takich jak: z czerni, z lewej, z prawej itd. Aby ustawić efekt przejścia, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Pobierz referencję do slajdu.
- Ustaw efekt przejścia.
- Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).

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

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Ustaw prędkość przejścia za pomocą [speed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) przy użyciu ustawienia [TransitionSpeed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitionspeed/) (np. slow/medium/fast).

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Możesz osadzić dźwięk dla przejścia i kontrolować jego zachowanie przy pomocy ustawień, takich jak tryb dźwięku i pętla (np. [setSound](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), a także metadane takie jak [setSoundIsBuiltIn](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) i [setSoundName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?**

Skonfiguruj pożądany typ przejścia w ustawieniach przejścia każdego slajdu; przejścia są przechowywane indywidualnie dla każdego slajdu, więc zastosowanie tego samego typu we wszystkich slajdach zapewnia jednolity efekt.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Sprawdź [ustawienia przejścia](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) slajdu i odczytaj jego [typ przejścia](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); ta wartość dokładnie określa, jaki efekt jest zastosowany.