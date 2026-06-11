---
title: Zarządzanie pokazem slajdów w .NET
linktitle: Pokaz slajdów
type: docs
weight: 90
url: /pl/net/manage-slide-show/
keywords:
- typ pokazu
- prezentowany przez prelegenta
- przeglądany przez pojedynczego użytkownika
- przeglądany w kiosku
- opcje pokazu
- ciągła pętla
- pokaz bez narracji
- pokaz bez animacji
- kolor pióra
- pokaz slajdów
- własny pokaz
- przechodzenie slajdów
- ręcznie
- z użyciem timingów
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak zarządzać pokazami slajdów w Aspose.Slides dla .NET. Kontroluj przejścia slajdów, synchronizację czasową i wiele więcej w formatach PPT, PPTX i ODP z łatwością."
---
## **Wprowadzenie**

W programie Microsoft PowerPoint ustawienia **Slide Show** są kluczowym narzędziem do przygotowywania i wygłaszania profesjonalnych prezentacji. Jedną z najważniejszych funkcji w tej sekcji jest **Set Up Show**, która pozwala dostosować prezentację do określonych warunków i odbiorców, zapewniając elastyczność i wygodę. Dzięki tej funkcji możesz wybrać typ pokazu (np. prezentowany przez prelegenta, przeglądany przez pojedynczą osobę lub przeglądany w kiosku), włączyć lub wyłączyć pętlę, wybrać konkretne slajdy do wyświetlenia oraz używać synchronizacji czasowej. Ten krok w przygotowaniu jest kluczowy dla zwiększenia skuteczności i profesjonalizmu prezentacji.

`SlideShowSettings` jest własnością klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) typu [SlideShowSettings](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/slideshowsettings/), która umożliwia zarządzanie ustawieniami pokazu slajdów w prezentacji PowerPoint. W tym artykule przyjrzymy się, jak używać tej własności do konfigurowania i kontrolowania różnych aspektów ustawień pokazu.

## **Wybierz typ pokazu**

`SlideShowSettings.SlideShowType` definiuje typ pokazu slajdów, którym może być instancja jednej z następujących klas: [PresentedBySpeaker](https://reference.aspose.com/slides/pl/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pl/net/aspose.slides/browsedbyindividual/) lub [BrowsedAtKiosk](https://reference.aspose.com/slides/pl/net/aspose.slides/browsedatkiosk/). Użycie tej własności umożliwia dostosowanie prezentacji do różnych scenariuszy użycia, takich jak automatyczne kioski lub prezentacje ręczne.

Poniższy przykład kodu tworzy nową prezentację i ustawia typ pokazu na „Browsed by an individual” bez wyświetlania paska przewijania.

```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Włącz opcje pokazu**

`SlideShowSettings.Loop` określa, czy pokaz slajdów powinien powtarzać się w pętli aż do ręcznego zatrzymania. Jest to przydatne w automatycznych prezentacjach, które muszą działać ciągle. `SlideShowSettings.ShowNarration` określa, czy narracje głosowe mają być odtwarzane podczas pokazu slajdów. Jest to użyteczne w automatycznych prezentacjach zawierających wskazówki głosowe dla odbiorców. `SlideShowSettings.ShowAnimation` określa, czy animacje dodane do obiektów slajdu mają być odtwarzane. Dzięki temu można zapewnić pełny efekt wizualny prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza pętlę pokazu slajdów.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Wybierz slajdy do wyświetlenia**

Własność `SlideShowSettings.Slides` pozwala wybrać zakres slajdów, które mają być wyświetlane podczas prezentacji. Jest to przydatne, gdy chcemy pokazać tylko część prezentacji, a nie wszystkie slajdy. Poniższy przykład kodu tworzy nową prezentację i ustawia zakres slajdów do wyświetlenia od slajdu `2` do `9`.

```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Użyj automatycznego przechodzenia slajdów**

Własność `SlideShowSettings.UseTimings` pozwala włączyć lub wyłączyć użycie wstępnie ustawionych czasów wyświetlania dla każdego slajdu. Jest to przydatne do automatycznego wyświetlania slajdów z określonymi wcześniej czasami trwania. Poniższy przykład kodu tworzy nową prezentację i wyłącza użycie timingów.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Pokaż kontrolki multimediów**

Własność `SlideShowSettings.ShowMediaControls` określa, czy kontrolki multimedialne (takie jak odtwarzanie, pauza i zatrzymanie) mają być wyświetlane podczas pokazu, gdy odtwarzana jest zawartość multimedialna (np. wideo lub audio). Jest to przydatne, gdy chcesz dać prezenterowi kontrolę nad odtwarzaniem multimediów w trakcie prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza wyświetlanie kontrolek multimedialnych.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy mogę zapisać prezentację tak, aby otwierała się bezpośrednio w trybie pokazu slajdów?**

Tak. Zapisz plik jako PPSX lub PPSM; te formaty uruchamiają się bezpośrednio w trybie pokazu po otwarciu w PowerPoint. W Aspose.Slides wybierz odpowiedni format zapisu [during export](/slides/pl/net/save-presentation/).

**Czy mogę wykluczyć poszczególne slajdy z pokazu bez usuwania ich z pliku?**

Tak. Oznacz slajd jako [Hidden](https://reference.aspose.com/slides/pl/net/aspose.slides/slide/hidden/). Ukryte slajdy pozostają w prezentacji, ale nie są wyświetlane podczas pokazu.

**Czy Aspose.Slides może odtworzyć pokaz slajdów lub sterować prezentacją na żywo na ekranie?**

Nie. Aspose.Slides edytuje, analizuje i konwertuje pliki prezentacji; rzeczywiste odtwarzanie jest obsługiwane przez aplikację przeglądarki, taką jak PowerPoint.