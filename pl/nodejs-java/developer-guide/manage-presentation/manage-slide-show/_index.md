---
title: Zarządzaj pokazem slajdów w JavaScript
linktitle: Pokaz slajdów
type: docs
weight: 90
url: /pl/nodejs-java/manage-slide-show/
keywords:
- typ pokazu
- prowadzony przez prelegenta
- przeglądany przez pojedynczą osobę
- przeglądany w kiosku
- opcje pokazu
- ciągłe powtarzanie
- bez narracji
- bez animacji
- kolor pióra
- wyświetlanie slajdów
- pokaz niestandardowy
- przechodzenie slajdów
- ręcznie
- używanie timingów
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj pokazami slajdów w JavaScript przy użyciu Aspose.Slides dla Node.js. Kontroluj przejścia slajdów, timingi i inne funkcje w formatach PPT, PPTX i ODP z łatwością."
---
## **Wprowadzenie**

W Microsoft PowerPoint ustawienia **Pokaz slajdów** są kluczowym narzędziem do przygotowywania i prowadzenia profesjonalnych prezentacji. Jedną z najważniejszych funkcji w tej sekcji jest **Ustawienia pokazu**, które pozwalają dostosować prezentację do określonych warunków i odbiorców, zapewniając elastyczność i wygodę. Dzięki tej funkcji możesz wybrać typ pokazu (np. prowadzony przez prelegenta, przeglądany przez pojedynczą osobę lub przeglądany w kiosku), włączyć lub wyłączyć powtarzanie, wybrać konkretne slajdy do wyświetlenia oraz używać timingów. Ten krok w przygotowaniu ma kluczowe znaczenie dla zwiększenia efektywności i profesjonalizmu Twojej prezentacji.

`getSlideShowSettings` jest metodą klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), która zwraca obiekt typu [SlideShowSettings](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideshowsettings/), umożliwiający zarządzanie ustawieniami pokazu slajdów w prezentacji PowerPoint. W tym artykule przyjrzymy się, jak używać tej metody do konfigurowania i kontrolowania różnych aspektów ustawień pokazu slajdów. 

## **Wybierz typ pokazu**

`SlideShowSettings.setSlideShowType` definiuje typ pokazu slajdów, który może być instancją jednej z następujących klas: [PresentedBySpeaker](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/browsedbyindividual/), lub [BrowsedAtKiosk](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/browsedatkiosk/). Użycie tej metody pozwala dostosować prezentację do różnych scenariuszy użycia, takich jak automatyczne kioski czy ręczne prezentacje.

Poniższy przykład kodu tworzy nową prezentację i ustawia typ pokazu na „Przeglądany przez pojedynczą osobę” bez wyświetlania paska przewijania.

```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Włącz opcje pokazu**

`SlideShowSettings.setLoop` określa, czy pokaz slajdów ma powtarzać się w pętli aż do ręcznego zatrzymania. Jest to przydatne w automatycznych prezentacjach, które muszą działać nieprzerwanie. `SlideShowSettings.setShowNarration` określa, czy narracje dźwiękowe mają być odtwarzane podczas pokazu slajdów. Jest to przydatne w automatycznych prezentacjach zawierających wskazówki głosowe dla odbiorców. `SlideShowSettings.setShowAnimation` określa, czy animacje dodane do obiektów slajdów mają być odtwarzane. To zapewnia pełny efekt wizualny prezentacji.

Poniższy przykład kodu tworzy nową prezentację i powtarza pokaz slajdów w pętli.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Wybierz slajdy do wyświetlenia**

Metoda `SlideShowSettings.setSlides` pozwala wybrać zakres slajdów, które mają być wyświetlane podczas prezentacji. Jest to przydatne, gdy chcesz pokazać tylko część prezentacji, a nie wszystkie slajdy. Poniższy przykład kodu tworzy nową prezentację i ustawia zakres slajdów do wyświetlenia od slajdu `2` do `9`.

```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Użyj automatycznego przechodzenia slajdów**

Metoda `SlideShowSettings.setUseTimings` umożliwia włączenie lub wyłączenie użycia ustalonych z góry timingów dla każdego slajdu. Jest to przydatne do automatycznego wyświetlania slajdów z określonymi wcześniej czasami trwania. Poniższy przykład kodu tworzy nową prezentację i wyłącza użycie timingów.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Pokaż kontrolki multimedialne**

Metoda `SlideShowSettings.setShowMediaControls` określa, czy kontrolki multimedialne (takie jak odtwarzanie, pauza i zatrzymanie) mają być wyświetlane podczas pokazu slajdów, gdy odtwarzane są treści multimedialne (np. wideo lub audio). Jest to przydatne, gdy chcesz dać prezenterowi kontrolę nad odtwarzaniem multimediów podczas prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza wyświetlanie kontrolek multimedialnych.

```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Czy mogę zapisać prezentację tak, aby otwierała się bezpośrednio w trybie pokazu slajdów?**

Tak. Zapisz plik jako PPSX lub PPSM; te formaty uruchamiają się bezpośrednio w trybie pokazu slajdów po otwarciu w programie PowerPoint. W Aspose.Slides wybierz odpowiedni format zapisu [podczas eksportu](/slides/pl/nodejs-java/save-presentation/).

**Czy mogę wykluczyć pojedyncze slajdy z pokazu bez usuwania ich z pliku?**

Tak. Oznacz slajd jako [ukryty](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/sethidden/). Ukryte slajdy pozostają w prezentacji, ale nie są wyświetlane podczas pokazu slajdów.

**Czy Aspose.Slides może odtwarzać pokaz slajdów lub sterować prezentacją na żywo na ekranie?**

Nie. Aspose.Slides edytuje, analizuje i konwertuje pliki prezentacji; rzeczywiste odtwarzanie jest obsługiwane przez aplikację wyświetlającą, taką jak PowerPoint.