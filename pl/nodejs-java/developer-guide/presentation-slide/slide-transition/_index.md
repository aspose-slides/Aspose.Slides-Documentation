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
description: "Dostosuj przejścia slajdów w JavaScript przy użyciu Aspose.Slides for Node.js via Java, z instrukcją krok po kroku dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać przejściami slajdów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak zastosować typy przejść do slajdów, skonfigurować zachowanie przejścia, takie jak przechodzenie po kliknięciu lub po określonym czasie, sprawdzić i wyłączyć automatyczne przechodzenie, używać przejścia Morph i jego typów oraz ustawiać opcje efektu przejścia. Przykłady demonstrują, jak wczytać lub utworzyć prezentację, zmodyfikować ustawienia przejść dla wybranych slajdów oraz zapisać wynik jako plik PPTX. Artykuł odpowiada także na często zadawane pytania dotyczące szybkości przejścia, dźwięków przejścia, stosowania tego samego przejścia w wielu slajdach oraz sprawdzania, które przejście jest aktualnie ustawione na slajdzie.

## **Dodaj przejście slajdu**
Aby utworzyć prosty efekt przejścia slajdu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Zastosuj typ przejścia slajdu na slajdzie, wybierając jeden z efektów przejścia oferowanych przez Aspose.Slides for Node.js via Java przy użyciu wyliczenia TransitionType.
1. Zapisz zmodyfikowany plik prezentacji.

```javascript
// Utwórz instancję klasy Presentation, aby załadować plik prezentacji źródłowej
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Zastosuj przejście typu Circle na slajdzie 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Zastosuj przejście typu Comb na slajdzie 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Zapisz prezentację na dysk
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj zaawansowane przejście slajdu**
W poprzedniej sekcji zastosowaliśmy prosty efekt przejścia na slajdzie. Teraz, aby ten prosty efekt był lepszy i bardziej kontrolowany, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Zastosuj typ przejścia slajdu na slajdzie, wybierając jeden z efektów przejścia oferowanych przez Aspose.Slides for Node.js via Java.
1. Możesz także ustawić przejście na „Advance On Click”, po określonym czasie lub oba te tryby.
1. Jeśli przejście slajdu jest włączone jako „Advance On Click”, przejście nastąpi tylko po kliknięciu myszy. Ponadto, jeśli ustawiona jest właściwość „Advance After Time”, przejście zostanie wykonane automatycznie po upływie określonego czasu.
1. Zapisz zmodyfikowaną prezentację jako plik prezentacji.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Zastosuj przejście typu Circle na slajdzie 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Ustaw czas przejścia na 3 sekundy
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Zastosuj przejście typu Comb na slajdzie 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Ustaw czas przejścia na 5 sekund
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Zastosuj przejście typu Zoom na slajdzie 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Ustaw czas przejścia na 7 sekund
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Zapisz prezentację na dysk
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Przejście Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java obsługuje teraz [Morph Transition](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/MorphTransition). Przedstawia nowy przejście morph wprowadzone w PowerPoint 2019.

{{% /alert %}} 

Przejście Morph umożliwia płynne animowanie przejścia z jednego slajdu do drugiego. Ten artykuł opisuje koncepcję i sposób użycia przejścia Morph. Aby skutecznie korzystać z przejścia Morph, potrzebujesz dwóch slajdów z co najmniej jednym wspólnym obiektem. Najprostszy sposób to zduplikowanie slajdu i przeniesienie obiektu na drugim slajdzie w inne miejsce.

Poniższy fragment kodu pokazuje, jak dodać klon slajdu z tekstem do prezentacji i ustawić przejście typu [morph type](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TransitionType) dla drugiego slajdu.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Typy przejścia Morph**
Dołączono nową wyliczoną [TransitionMorphType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TransitionMorphType). Reprezentuje ona różne typy przejścia Morph slajdu.

Wyliczenie TransitionMorphType ma trzy członki:

- ByObject: przejście Morph będzie wykonywane z uwzględnieniem kształtów jako niepodzielnych obiektów.
- ByWord: przejście Morph będzie wykonywane poprzez przenoszenie tekstu słowo po słowie, gdy to możliwe.
- ByChar: przejście Morph będzie wykonywane poprzez przenoszenie tekstu znak po znaku, gdy to możliwe.

Poniższy fragment kodu pokazuje, jak ustawić przejście morph na slajdzie i zmienić typ morph:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw efekty przejścia**
Aspose.Slides for Node.js via Java obsługuje ustawianie efektów przejścia, takich jak przejście z czerni, z lewej, z prawej itp. Aby ustawić efekt przejścia, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
- Pobierz odniesienie do slajdu.
- Ustaw efekt przejścia.
- Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/) .

W poniższym przykładzie ustawiono efekty przejścia.

```javascript
// Utwórz instancję klasy Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Ustaw efekt
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Zapisz prezentację na dysk
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Ustaw prędkość [transition’s speed](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/setspeed/) przy użyciu ustawienia [TransitionSpeed](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/transitionspeed/) (np. wolna/średnia/szybka).

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Możesz osadzić dźwięk dla przejścia i kontrolować zachowanie za pomocą ustawień, takich jak tryb dźwięku i pętla (np. [setSound](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/)), a także metadane takie jak [setSoundIsBuiltIn](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) i [setSoundName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/setsoundname/).

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do każdego slajdu?**

Skonfiguruj żądany typ przejścia w ustawieniach przejścia każdego slajdu; przejścia są przechowywane osobno dla każdego slajdu, więc zastosowanie tego samego typu we wszystkich slajdach zapewnia spójny rezultat.

**Jak mogę sprawdzić, które przejście jest obecnie ustawione na slajdzie?**

Sprawdź [transition settings](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu i odczytaj jego [transition type](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowtransition/gettype/); ta wartość dokładnie informuje, który efekt jest zastosowany.