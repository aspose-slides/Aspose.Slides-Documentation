---
title: Zarządzanie pokazem slajdów w Javie
linktitle: Pokaz slajdów
type: docs
weight: 90
url: /pl/java/manage-slide-show/
keywords:
- typ pokazu
- prowadzony przez prelegenta
- przeglądany przez pojedynczą osobę
- przeglądany w kiosku
- opcje pokazu
- powtarzanie w pętli
- pokaz bez narracji
- pokaz bez animacji
- kolor pióra
- wyświetl slajdy
- pokaz niestandardowy
- przechodź slajdy
- ręcznie
- używanie czasowań
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać pokazami slajdów w Aspose.Slides dla Javy. Kontroluj przejścia slajdów, czasowania i wiele innych w formatach PPT, PPTX i ODP z łatwością."
---
## **Wprowadzenie**

W programie Microsoft PowerPoint ustawienia **Pokaz slajdów** są kluczowym narzędziem do przygotowywania i prowadzenia profesjonalnych prezentacji. Jedną z najważniejszych funkcji w tej sekcji jest **Ustawienia pokazu**, które pozwalają dostosować prezentację do określonych warunków i odbiorców, zapewniając elastyczność i wygodę. Dzięki tej funkcji możesz wybrać typ pokazu (np. prowadzony przez prelegenta, przeglądany przez pojedynczą osobę lub przeglądany w kiosku), włączyć lub wyłączyć powtarzanie, wybrać konkretne slajdy do wyświetlenia oraz używać czasowań. Ten krok w przygotowaniu jest kluczowy dla uczynienia prezentacji bardziej efektywną i profesjonalną.

`getSlideShowSettings` jest metodą klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) zwracającą obiekt typu [SlideShowSettings](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideshowsettings/), który umożliwia zarządzanie ustawieniami pokazu slajdów w prezentacji PowerPoint. W tym artykule przyjrzymy się, jak używać tej metody do konfigurowania i kontrolowania różnych aspektów ustawień pokazu slajdów. 

## **Wybierz typ pokazu**

`SlideShowSettings.setSlideShowType` określa typ pokazu slajdów, który może być instancją jednej z następujących klas: [PresentedBySpeaker](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pl/java/com.aspose.slides/browsedbyindividual/), lub [BrowsedAtKiosk](https://reference.aspose.com/slides/pl/java/com.aspose.slides/browsedatkiosk/). Użycie tej metody pozwala dostosować prezentację do różnych scenariuszy użycia, takich jak automatyczne kioski lub ręczne prezentacje.

Poniższy przykład kodu tworzy nową prezentację i ustawia typ pokazu na „Przeglądany przez pojedynczą osobę” bez wyświetlania paska przewijania.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Włącz opcje pokazu**

`SlideShowSettings.setLoop` określa, czy pokaz slajdów ma powtarzać się w pętli aż do ręcznego zatrzymania. Jest to przydatne w automatycznych prezentacjach, które muszą działać nieprzerwanie. `SlideShowSettings.setShowNarration` określa, czy narracje głosowe mają być odtwarzane podczas pokazu slajdów. Jest to przydatne w automatycznych prezentacjach zawierających wskazówki głosowe dla odbiorców. `SlideShowSettings.setShowAnimation` określa, czy animacje dodane do obiektów slajdów mają być odtwarzane. Jest to przydatne do zapewnienia pełnego efektu wizualnego prezentacji.

Poniższy przykład kodu tworzy nową prezentację i powtarza pokaz slajdów.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Wybierz slajdy do wyświetlenia**

`SlideShowSettings.setSlides` umożliwia wybranie zakresu slajdów, które mają być wyświetlane podczas prezentacji. Jest to przydatne, gdy trzeba pokazać tylko część prezentacji, a nie wszystkie slajdy. Poniższy przykład kodu tworzy nową prezentację i ustawia zakres slajdów do wyświetlenia od slajdu `2` do `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Użyj automatycznego przechodzenia slajdów**

`SlideShowSettings.setUseTimings` umożliwia włączenie lub wyłączenie użycia wstępnie ustawionych czasowań dla każdego slajdu. Jest to przydatne do automatycznego wyświetlania slajdów o zdefiniowanych wcześniej czasach trwania. Poniższy przykład kodu tworzy nową prezentację i wyłącza użycie czasowań.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Pokaż kontrolki mediów**

`SlideShowSettings.setShowMediaControls` określa, czy kontrolki mediów (takie jak odtwarzanie, pauza i zatrzymanie) powinny być wyświetlane podczas pokazu slajdów, gdy odtwarzana jest zawartość multimedialna (np. wideo lub audio). Jest to przydatne, gdy chcesz dać prezenterowi kontrolę nad odtwarzaniem mediów podczas prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza wyświetlanie kontrolek mediów.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Czy mogę zapisać prezentację tak, aby otwierała się bezpośrednio w trybie pokazu slajdów?**

Tak. Zapisz plik jako PPSX lub PPSM; te formaty uruchamiają się od razu w trybie pokazu slajdów po otwarciu w programie PowerPoint. W Aspose.Slides wybierz odpowiedni format zapisu [podczas eksportu](/slides/pl/java/save-presentation/).

**Czy mogę wykluczyć pojedyncze slajdy z pokazu bez usuwania ich z pliku?**

Tak. Oznacz slajd jako [ukryty](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slide/#setHidden-boolean-). Ukryte slajdy pozostają w prezentacji, ale nie są wyświetlane podczas pokazu slajdów.

**Czy Aspose.Slides może odtwarzać pokaz slajdów lub kontrolować prezentację na żywo na ekranie?**

Nie. Aspose.Slides edytuje, analizuje i konwertuje pliki prezentacji; rzeczywiste odtwarzanie jest obsługiwane przez aplikację do przeglądania, taką jak PowerPoint.