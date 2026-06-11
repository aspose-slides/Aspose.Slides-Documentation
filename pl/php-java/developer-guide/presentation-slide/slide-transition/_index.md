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
description: "Odkryj, jak dostosować przejścia slajdów w Aspose.Slides for PHP via Java, z instrukcjami krok po kroku dla prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zarządzać przejściami slajdów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak zastosować typy przejść do slajdów, skonfigurować zachowanie przejścia, takie jak przechodzenie po kliknięciu lub po określonym czasie, sprawdzić i wyłączyć automatyczne przechodzenie, używać przejścia Morph i jego typów oraz ustawiać opcje efektów przejścia. Przykłady demonstrują, jak wczytać lub utworzyć prezentację, modyfikować ustawienia przejść dla wybranych slajdów oraz zapisać wynik jako plik PPTX. Artykuł odpowiada również na często zadawane pytania dotyczące szybkości przejścia, dźwięków przejść, stosowania tego samego przejścia do wielu slajdów oraz sprawdzania, które przejście jest aktualnie ustawione na slajdzie.

## **Dodaj przejście slajdu**

Aby utworzyć prosty efekt przejścia slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z dostępnych efektów przejścia oferowanych przez Aspose.Slides for PHP via Java przy użyciu wyliczenia TransitionType.
3. Zapisz zmodyfikowany plik prezentacji.

```php
  # Utwórz instancję klasy Presentation, aby załadować plik prezentacji źródłowej
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Zastosuj przejście typu Circle na slajdzie 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Zastosuj przejście typu Comb na slajdzie 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Zapisz prezentację na dysk
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Dodaj zaawansowane przejście slajdu**

W powyższej sekcji zastosowaliśmy prosty efekt przejścia na slajdzie. Teraz, aby uczynić ten prosty efekt lepszym i bardziej kontrolowanym, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
2. Zastosuj typ przejścia slajdu na slajdzie, wybierając jedną z dostępnych efektów przejścia oferowanych przez Aspose.Slides for PHP via Java.
3. Możesz także ustawić przejście na przechodzenie po kliknięciu, po określonym czasie lub oba te warunki.
4. Jeśli przejście slajdu jest włączone jako przechodzenie po kliknięciu, przejście nastąpi tylko po kliknięciu myszy. Ponadto, jeśli ustawiono właściwość Advance After Time, przejście zostanie wykonane automatycznie po upływie określonego czasu.
5. Zapisz zmodyfikowaną prezentację jako plik prezentacji.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Zastosuj przejście typu Circle na slajdzie 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Ustaw czas przejścia na 3 sekundy
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Zastosuj przejście typu Comb na slajdzie 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Ustaw czas przejścia na 5 sekund
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Zastosuj przejście typu Zoom na slajdzie 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Ustaw czas przejścia na 7 sekund
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Zapisz prezentację na dysk
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Przejście Morph**

{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java obsługuje teraz [Morph Transition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/morphtransition/). Reprezentują nowe przejście morph wprowadzone w PowerPoint 2019.
{{% /alert %}} 

Przejście Morph pozwala na animowanie płynnego przejścia z jednego slajdu do drugiego. Ten artykuł opisuje koncepcję i sposób użycia przejścia Morph. Aby efektywnie korzystać z przejścia Morph, potrzebujesz dwóch slajdów z co najmniej jednym wspólnym obiektem. Najłatwiejszym sposobem jest skopiowanie slajdu, a następnie przemieszczenie obiektu na drugim slajdzie w inne miejsce.

Poniższy fragment kodu pokazuje, jak dodać klon slajdu z pewnym tekstem do prezentacji oraz ustawić przejście typu [morph type](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TransitionType) na drugim slajdzie.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Typy przejścia Morph**

Dodano nowe wyliczenie [TransitionMorphType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/TransitionMorphType). Reprezentuje ono różne typy przejść Morph slajdu.

Wyliczenie TransitionMorphType ma trzy elementy:

- ByObject: Przejście Morph będzie wykonywane z uwzględnieniem kształtów jako niepodzielnych obiektów.
- ByWord: Przejście Morph będzie wykonywane poprzez przenoszenie tekstu słowo po słowie, jeśli to możliwe.
- ByChar: Przejście Morph będzie wykonywane poprzez przenoszenie tekstu znak po znaku, jeśli to możliwe.

Poniższy fragment kodu pokazuje, jak ustawić przejście morph na slajdzie i zmienić typ morph:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ustaw efekty przejścia**

Aspose.Slides for PHP via Java obsługuje ustawianie efektów przejścia, takich jak „z czerni”, „z lewej”, „z prawej” itp. Aby ustawić efekt przejścia, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Pobierz odniesienie do slajdu.
- Ustaw efekt przejścia.
- Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).

W poniższym przykładzie ustawiliśmy efekty przejścia.

```php
  # Utwórz instancję klasy Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Ustaw efekt
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Zapisz prezentację na dysk
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**Czy mogę kontrolować prędkość odtwarzania przejścia slajdu?**

Tak. Ustaw prędkość przejścia za pomocą [speed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/setspeed/) przy użyciu ustawienia [TransitionSpeed](https://reference.aspose.com/slides/pl/php-java/aspose.slides/transitionspeed/) (np. slow/medium/fast).

**Czy mogę dołączyć dźwięk do przejścia i ustawić jego pętlę?**

Tak. Możesz osadzić dźwięk dla przejścia i kontrolować jego zachowanie za pomocą ustawień, takich jak tryb dźwięku i pętla (np. [setSound](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/setsoundloop/), a także metadane, takie jak [setSoundIsBuiltIn](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) i [setSoundName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Jaki jest najszybszy sposób, aby zastosować to samo przejście do każdego slajdu?**

Skonfiguruj żądany typ przejścia w ustawieniach przejścia każdego slajdu; przejścia są przechowywane osobno dla każdego slajdu, więc zastosowanie tego samego typu we wszystkich slajdach zapewnia spójny wynik.

**Jak mogę sprawdzić, które przejście jest aktualnie ustawione na slajdzie?**

Sprawdź [ustawienia przejścia](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseslide/#getSlideShowTransition) slajdu i odczytaj jego [typ przejścia](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowtransition/settype/); ta wartość dokładnie wskazuje, jaki efekt jest zastosowany.