---
title: Zarządzanie pokazem slajdów w C++
linktitle: Pokaz slajdów
type: docs
weight: 90
url: /pl/cpp/manage-slide-show/
keywords:
- typ pokazu
- prezentowane przez mówcę
- przeglądane przez osobę indywidualną
- przeglądane w kiosku
- opcje pokazu
- pętla ciągła
- pokaz bez narracji
- pokaz bez animacji
- kolor pióra
- pokaz slajdów
- pokaz niestandardowy
- przejście slajdów do przodu
- ręcznie
- z użyciem timingów
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak zarządzać pokazami slajdów w Aspose.Slides dla C++. Kontroluj przejścia slajdów, timingi i wiele innych w formatach PPT, PPTX i ODP z łatwością."
---
## **Wprowadzenie**

W programie Microsoft PowerPoint ustawienia **Slide Show** są kluczowym narzędziem do przygotowywania i prowadzenia profesjonalnych prezentacji. Jedną z najważniejszych funkcji w tej sekcji jest **Set Up Show**, która pozwala dostosować prezentację do konkretnych warunków i odbiorców, zapewniając elastyczność i wygodę. Dzięki tej funkcji można wybrać typ pokazu (np. prezentowany przez prowadzącego, przeglądany przez osobę indywidualną lub w kiosku), włączyć lub wyłączyć powtarzanie, wybrać konkretne slajdy do wyświetlenia oraz używać timingów. Ten krok w przygotowaniu jest kluczowy dla zwiększenia skuteczności i profesjonalizmu prezentacji.

`get_SlideShowSettings` jest metodą klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/), która zwraca obiekt typu [SlideShowSettings](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slideshowsettings/), umożliwiający zarządzanie ustawieniami pokazu w prezentacji PowerPoint. W tym artykule przyjrzymy się, jak używać tej metody do konfigurowania i kontrolowania różnych aspektów ustawień pokazu.

## **Wybierz typ pokazu**

`SlideShowSettings.set_SlideShowType` określa typ pokazu, którym może być instancja jednej z następujących klas: [PresentedBySpeaker](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pl/cpp/aspose.slides/browsedbyindividual/), lub [BrowsedAtKiosk](https://reference.aspose.com/slides/pl/cpp/aspose.slides/browsedatkiosk/). Użycie tej metody pozwala dostosować prezentację do różnych scenariuszy użycia, takich jak kioski automatyczne czy prezentacje ręczne.

Poniższy przykład kodu tworzy nową prezentację i ustawia typ pokazu na „Browsed by an individual” bez wyświetlania paska przewijania.

```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Włącz opcje pokazu**

`SlideShowSettings.set_Loop` określa, czy pokaz ma się powtarzać w pętli aż do ręcznego zatrzymania. Jest to przydatne w automatycznych prezentacjach, które muszą działać ciągle. `SlideShowSettings.set_ShowNarration` określa, czy podczas pokazu mają być odtwarzane narracje głosowe. Jest to przydatne w automatycznych prezentacjach zawierających wskazówki głosowe dla odbiorców. `SlideShowSettings.set_ShowAnimation` określa, czy animacje dodane do obiektów slajdów mają być odtwarzane. Jest to przydatne do pełnego efektu wizualnego prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza powtarzanie pokazu.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Wybierz slajdy do wyświetlenia**

`SlideShowSettings.set_Slides` umożliwia wybranie zakresu slajdów, które mają być wyświetlane podczas prezentacji. Jest to przydatne, gdy trzeba pokazać tylko część prezentacji, a nie wszystkie slajdy. Poniższy przykład kodu tworzy nową prezentację i ustawia zakres slajdów do wyświetlenia od slajdu `2` do `9`.

```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Użyj automatycznego przechodzenia slajdów**

`SlideShowSettings.set_UseTimings` umożliwia włączenie lub wyłączenie użycia ustawionych wcześniej timingów dla każdego slajdu. Jest to przydatne do automatycznego wyświetlania slajdów z z góry określonym czasem trwania. Poniższy przykład kodu tworzy nową prezentację i wyłącza użycie timingów.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Pokaż kontrolki multimedialne**

`SlideShowSettings.set_ShowMediaControls` określa, czy kontrolki multimedialne (takie jak odtwarzanie, pauza i zatrzymanie) powinny być wyświetlane podczas pokazu, gdy odtwarzana jest treść multimedialna (np. wideo lub audio). Jest to przydatne, gdy chcesz dać prezentującemu kontrolę nad odtwarzaniem mediów podczas prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza wyświetlanie kontrolek multimedialnych.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Czy mogę zapisać prezentację tak, aby otwierała się bezpośrednio w trybie pokazu?**

Tak. Zapisz plik jako PPSX lub PPSM; formaty te uruchamiają się bezpośrednio w trybie pokazu po otwarciu w PowerPoint. W Aspose.Slides wybierz odpowiedni format zapisu [podczas eksportu](/slides/pl/cpp/save-presentation/).

**Czy mogę wykluczyć pojedyncze slajdy z pokazu bez ich usuwania z pliku?**

Tak. Oznacz slajd jako [ukryty](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/set_hidden/). Ukryte slajdy pozostają w prezentacji, ale nie są wyświetlane podczas pokazu.

**Czy Aspose.Slides może odtwarzać pokaz slajdów lub sterować bieżącą prezentacją na ekranie?**

Nie. Aspose.Slides edytuje, analizuje i konwertuje pliki prezentacji; rzeczywiste odtwarzanie jest obsługiwane przez aplikację wyświetlającą, taką jak PowerPoint.