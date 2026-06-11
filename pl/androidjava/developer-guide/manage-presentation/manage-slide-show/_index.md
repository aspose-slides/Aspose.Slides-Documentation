---
title: Zarządzanie pokazem slajdów na Androidzie
linktitle: Pokaz slajdów
type: docs
weight: 90
url: /pl/androidjava/manage-slide-show/
keywords:
- typ pokazu
- prezentowany przez prelegenta
- przeglądany przez indywidualnego użytkownika
- przeglądany w kiosku
- opcje pokazu
- pętla ciągła
- pokaz bez narracji
- pokaz bez animacji
- kolor pióra
- pokaz slajdów
- niestandardowy pokaz
- przechodzenie slajdów
- ręcznie
- z użyciem timingów
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać pokazami slajdów w Aspose.Slides dla Androida przy użyciu Javy. Kontroluj przejścia slajdów, timingi i wiele innych w formatach PPT, PPTX i ODP z łatwością."
---
## **Wprowadzenie**

W programie Microsoft PowerPoint ustawienia **Pokazu slajdów** są kluczowym narzędziem do przygotowywania i prezentowania profesjonalnych prezentacji. Jedną z najważniejszych funkcji w tej sekcji jest **Ustawienia pokazu**, które pozwalają dostosować prezentację do określonych warunków i odbiorców, zapewniając elastyczność i wygodę. Dzięki tej funkcji możesz wybrać typ pokazu (np. prezentowany przez prelegenta, przeglądany przez jedną osobę lub przeglądany w kiosku), włączyć lub wyłączyć powtarzanie, wybrać konkretne slajdy do wyświetlenia oraz używać timingów. Ten krok w przygotowaniu jest kluczowy, aby Twoja prezentacja była bardziej efektywna i profesjonalna.

`getSlideShowSettings` jest metodą klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) , która zwraca obiekt typu [SlideShowSettings](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideshowsettings/), umożliwiający zarządzanie ustawieniami pokazu slajdów w prezentacji PowerPoint. W tym artykule przyjrzymy się, jak używać tej metody do konfigurowania i kontrolowania różnych aspektów ustawień pokazu slajdów. 

## **Wybierz typ pokazu**

`SlideShowSettings.setSlideShowType` określa typ pokazu slajdów, który może być instancją jednej z następujących klas: [PresentedBySpeaker](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/browsedbyindividual/), lub [BrowsedAtKiosk](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/browsedatkiosk/). Użycie tej metody pozwala dostosować prezentację do różnych scenariuszy użycia, takich jak kioski automatyczne lub prezentacje manualne.

Poniższy przykład kodu tworzy nową prezentację i ustawia typ pokazu na "Browsed by an individual" bez wyświetlania paska przewijania.

```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Włącz opcje pokazu**

`SlideShowSettings.setLoop` określa, czy pokaz slajdów ma powtarzać się w pętli aż do ręcznego zatrzymania. Jest to przydatne w automatycznych prezentacjach, które muszą działać ciągle. `SlideShowSettings.setShowNarration` określa, czy narracje głosowe mają być odtwarzane podczas pokazu slajdów. Jest to przydatne w automatycznych prezentacjach zawierających wskazówki głosowe dla odbiorców. `SlideShowSettings.setShowAnimation` określa, czy animacje dodane do obiektów slajdów mają być odtwarzane. Dzięki temu można uzyskać pełny efekt wizualny prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza pętlę pokazu slajdów.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Wybierz slajdy do wyświetlenia**

Metoda `SlideShowSettings.setSlides` umożliwia wybranie zakresu slajdów, które mają być wyświetlane podczas prezentacji. Jest to przydatne, gdy trzeba pokazać tylko część prezentacji, a nie wszystkie slajdy. Poniższy przykład kodu tworzy nową prezentację i ustawia zakres slajdów do wyświetlenia od slajdu `2` do `9`.

```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Użyj automatycznego przejścia slajdów**

Metoda `SlideShowSettings.setUseTimings` pozwala włączyć lub wyłączyć użycie wstępnie ustawionych timingów dla każdego slajdu. Jest to przydatne przy automatycznym wyświetlaniu slajdów o określonych czasach trwania. Poniższy przykład kodu tworzy nową prezentację i wyłącza użycie timingów.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Pokaż kontrolki multimediów**

Metoda `SlideShowSettings.setShowMediaControls` określa, czy kontrolki multimediów (takie jak odtwarzanie, pauza i zatrzymanie) mają być wyświetlane podczas pokazu slajdów, gdy odtwarzane są treści multimedialne (np. wideo lub audio). Jest to przydatne, gdy chcesz dać prezenterowi kontrolę nad odtwarzaniem multimediów podczas prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza wyświetlanie kontrolek multimediów.

```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **FAQ**

**Czy mogę zapisać prezentację tak, aby otwierała się bezpośrednio w trybie pokazu slajdów?**

Tak. Zapisz plik jako PPSX lub PPSM; te formaty uruchamiają się bezpośrednio w trybie pokazu slajdów po otwarciu w PowerPoint. W Aspose.Slides wybierz odpowiedni format zapisu [podczas eksportu](/slides/pl/androidjava/save-presentation/).

**Czy mogę wykluczyć pojedyncze slajdy z pokazu bez usuwania ich z pliku?**

Tak. Oznacz slajd jako [ukryty](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slide/#setHidden-boolean-). Ukryte slajdy pozostają w prezentacji, ale nie są wyświetlane podczas pokazu slajdów.

**Czy Aspose.Slides może odtwarzać pokaz slajdów lub kontrolować żywą prezentację na ekranie?**

Nie. Aspose.Slides edytuje, analizuje i konwertuje pliki prezentacji; rzeczywiste odtwarzanie jest obsługiwane przez aplikację do przeglądania, taką jak PowerPoint.