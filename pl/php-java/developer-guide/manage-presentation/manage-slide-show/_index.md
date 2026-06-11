---
title: Zarządzaj pokazem slajdów w PHP
linktitle: Pokaz slajdów
type: docs
weight: 90
url: /pl/php-java/manage-slide-show/
keywords:
- typ pokazu
- prowadzony przez prelegenta
- przeglądany przez jednostkę
- przeglądany w kiosku
- opcje pokazu
- ciągłe powtarzanie
- pokaz bez narracji
- pokaz bez animacji
- kolor pióra
- pokaz slajdów
- niestandardowy pokaz
- przechodzenie slajdów
- ręcznie
- używanie timingów
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak zarządzać pokazami slajdów w Aspose.Slides dla PHP przy użyciu Java. Kontroluj przejścia slajdów, timingi i więcej w formatach PPT, PPTX i ODP z łatwością."
---
## **Wprowadzenie**

W programie Microsoft PowerPoint ustawienia **Slide Show** są kluczowym narzędziem do przygotowywania i prezentowania profesjonalnych prezentacji. Jedną z najważniejszych funkcji w tej sekcji jest **Set Up Show**, która pozwala dostosować prezentację do konkretnych warunków i odbiorców, zapewniając elastyczność i wygodę. Dzięki tej funkcji możesz wybrać typ pokazu (np. prowadzony przez prelegenta, przeglądany przez pojedynczego użytkownika lub przeglądany w kiosku), włączyć lub wyłączyć powtarzanie, wybrać konkretne slajdy do wyświetlenia oraz używać timingów. Ten krok w przygotowaniu jest kluczowy dla zwiększenia efektywności i profesjonalizmu prezentacji.

`getSlideShowSettings` jest metodą klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) zwracającą obiekt typu [SlideShowSettings](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideshowsettings/), który pozwala zarządzać ustawieniami pokazu slajdów w prezentacji PowerPoint. W tym artykule przyjrzymy się, jak używać tej metody do konfigurowania i kontrolowania różnych aspektów ustawień pokazu slajdów. 

## **Wybierz typ pokazu**

`SlideShowSettings->setSlideShowType` definiuje typ pokazu slajdów, który może być instancją jednej z następujących klas: [PresentedBySpeaker](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pl/php-java/aspose.slides/browsedbyindividual/), lub [BrowsedAtKiosk](https://reference.aspose.com/slides/pl/php-java/aspose.slides/browsedatkiosk/). Użycie tej metody pozwala dostosować prezentację do różnych scenariuszy użycia, takich jak automatyczne kioski lub ręczne prezentacje.

```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Włącz opcje pokazu**

`SlideShowSettings->setLoop` określa, czy pokaz slajdów ma powtarzać się w pętli aż do ręcznego zatrzymania. Jest to przydatne w automatycznych prezentacjach, które muszą działać nieprzerwanie. `SlideShowSettings->setShowNarration` określa, czy narracje głosowe mają być odtwarzane podczas pokazu slajdów. Jest to użyteczne w automatycznych prezentacjach zawierających wskazówki głosowe dla odbiorców. `SlideShowSettings->setShowAnimation` określa, czy animacje dodane do obiektów slajdu mają być odtwarzane. To zapewnia pełny efekt wizualny prezentacji.

Poniższy przykład kodu tworzy nową prezentację i powtarza pokaz slajdów.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Wybierz slajdy do wyświetlenia**

`SlideShowSettings->setSlides` umożliwia wybranie zakresu slajdów, które mają być wyświetlane podczas prezentacji. Jest to przydatne, gdy trzeba pokazać tylko część prezentacji, a nie wszystkie slajdy. Poniższy przykład kodu tworzy nową prezentację i ustawia zakres slajdów do wyświetlenia od slajdu `2` do `9`.

```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Użyj automatycznego przejścia slajdów**

`SlideShowSettings->setUseTimings` umożliwia włączenie lub wyłączenie użycia ustawionych timingów dla każdego slajdu. Jest to przydatne do automatycznego wyświetlania slajdów z z góry określonymi czasami trwania. Poniższy przykład kodu tworzy nową prezentację i wyłącza użycie timingów.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Pokaż kontrolki mediów**

`SlideShowSettings->setShowMediaControls` określa, czy kontrolki multimedialne (takie jak odtwarzanie, pauza i zatrzymanie) mają być wyświetlane podczas pokazu slajdów, gdy odtwarzana jest zawartość multimedialna (np. wideo lub dźwięk). Jest to przydatne, gdy chcesz dać prezenterowi kontrolę nad odtwarzaniem multimediów podczas prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza wyświetlanie kontrolek mediów.

```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **FAQ**

**Czy mogę zapisać prezentację tak, aby otwierała się od razu w trybie pokazu slajdów?**

Tak. Zapisz plik jako PPSX lub PPSM; te formaty uruchamiają się bezpośrednio w trybie pokazu po otwarciu w PowerPoint. W Aspose.Slides wybierz odpowiedni format zapisu [podczas eksportu](/slides/pl/php-java/save-presentation/).

**Czy mogę wykluczyć pojedyncze slajdy z pokazu bez usuwania ich z pliku?**

Tak. Oznacz slajd jako [hidden](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/sethidden/). Ukryte slajdy pozostają w prezentacji, ale nie są wyświetlane podczas pokazu slajdów.

**Czy Aspose.Slides może odtwarzać pokaz slajdów lub kontrolować prezentację na żywo na ekranie?**

Nie. Aspose.Slides edytuje, analizuje i konwertuje pliki prezentacji; faktyczne odtwarzanie jest obsługiwane przez aplikację przeglądarki, taką jak PowerPoint.