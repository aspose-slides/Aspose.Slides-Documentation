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
description: "Odkryj, jak dostosować przejścia slajdów w Aspose.Slides dla Androida przy użyciu Javy, krok po kroku dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać przejściami slajdów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak zastosować typy przejść do slajdów, skonfigurować zachowanie przejścia, takie jak przechodzenie po kliknięciu lub po określonym czasie, używać przejścia Morph oraz jego typów oraz ustawiać opcje efektów przejścia. Przykłady demonstrują, jak wczytać lub utworzyć prezentację, zmodyfikować ustawienia przejścia dla wybranych slajdów i zapisać wynik jako plik PPTX. Artykuł odpowiada również na często zadawane pytania dotyczące szybkości przejścia, dźwięków przejścia, stosowania tego samego przejścia w wielu slajdach oraz sprawdzania, które przejście jest aktualnie ustawione na slajdzie.

## **Dodaj przejście slajdu**
Aby utworzyć prosty efekt przejścia slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) .
1. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z efektów przejścia oferowanych przez Aspose.Slides for Android via Java za pośrednictwem wyliczenia TransitionType.
1. Zapisz zmodyfikowany plik prezentacji.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, aby załadować źródłowy plik prezentacji
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
W powyższej sekcji zastosowaliśmy prosty efekt przejścia na slajdzie. Teraz, aby ulepszyć ten prosty efekt i uzyskać większą kontrolę, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) .
1. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z efektów przejścia oferowanych przez Aspose.Slides for Android via Java.
1. Możesz również ustawić przejście na Przejdź po kliknięciu, po określonym czasie lub oba jednocześnie.
1. Jeśli przejście slajdu jest ustawione na Przejdź po kliknięciu, przejście nastąpi tylko po kliknięciu myszą. Ponadto, jeśli ustawiono właściwość Advance After Time, przejście zostanie wykonane automatycznie po upływie określonego czasu.
1. Zapisz zmodyfikowaną prezentację jako plik prezentacji.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Zastosuj przejście typu circle na slajdzie 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Przejdź po kliknięciu lub automatycznie po 3 sekundach
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Zastosuj przejście typu comb na slajdzie 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Przejdź po kliknięciu lub automatycznie po 5 sekundach
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Zastosuj przejście typu zoom na slajdzie 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Przejdź po kliknięciu lub automatycznie po 7 sekundach
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

Aspose.Slides for Android via Java obsługuje teraz [Morph Transition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IMorphTransition). Reprezentują one nowy przejście Morph wprowadzone w PowerPoint 2019.

{{% /alert %}} 

Przejście Morph umożliwia animowanie płynnego przejścia z jednego slajdu do kolejnego. Ten artykuł opisuje koncepcję i sposób użycia przejścia Morph. Aby efektywnie korzystać z przejścia Morph, potrzebujesz dwóch slajdów posiadających co najmniej jeden wspólny obiekt. Najprostszym sposobem jest skopiowanie slajdu, a następnie przeniesienie obiektu na drugim slajdzie w inne miejsce.

Poniższy fragment kodu pokazuje, jak dodać klon slajdu z nieco tekstem do prezentacji i ustawić przejście typu [morph type](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/TransitionType) na drugim slajdzie.

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

## **Typy przejścia Morph**
Dodano nowy wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/TransitionMorphType). Reprezentuje ono różne typy przejścia slajdu Morph.

Wyliczenie TransitionMorphType ma trzy elementy:

- ByObject: Przejście Morph będzie wykonywane, traktując kształty jako niepodzielne obiekty.
- ByWord: Przejście Morph będzie wykonywane z przenoszeniem tekstu słowo po słowie, tam gdzie to możliwe.
- ByChar: Przejście Morph będzie wykonywane z przenoszeniem tekstu znak po znaku, tam gdzie to możliwe.

Poniższy fragment kodu pokazuje, jak ustawić przejście morph na slajdzie i zmienić typ morph:

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
Aspose.Slides for Android via Java obsługuje ustawianie efektów przejścia, takich jak z czerni, z lewej, z prawej itp. Aby ustawić efekt przejścia, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) .
- Uzyskaj referencję do slajdu.
- Ustawienie efektu przejścia.
- Zapisz prezentację jako plik [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

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

Tak. Ustaw [speed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) przejścia, używając ustawienia [TransitionSpeed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/transitionspeed/) (np. wolny/średni/szybki).

### Czy mogę dołączyć dźwięk do przejścia i ustawić go w pętli?

Tak. Możesz osadzić dźwięk dla przejścia i kontrolować zachowanie poprzez ustawienia takie jak [setSound](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), plus metadane takie jak [setSoundIsBuiltIn](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) i [setSoundName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-).

### Jaki jest najszybszy sposób zastosowania tego samego przejścia do każdego slajdu?

Skonfiguruj żądany typ przejścia w ustawieniach przejścia każdego slajdu; przejścia są przechowywane per slajd, więc zastosowanie tego samego typu we wszystkich slajdach daje spójny wynik.

### Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?

Sprawdź [transition settings](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) slajdu i odczytaj jego [transition type](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); ta wartość wskaże dokładnie, który efekt jest zastosowany.