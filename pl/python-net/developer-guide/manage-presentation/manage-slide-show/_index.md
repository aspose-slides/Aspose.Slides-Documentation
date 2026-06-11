---
title: Zarządzanie pokazem slajdów w Pythonie
linktitle: Pokaz slajdów
type: docs
weight: 90
url: /pl/python-net/manage-slide-show/
keywords:
- typ pokazu
- prezentowane przez prelegenta
- przeglądane przez indywidualnego użytkownika
- przeglądane w kiosku
- opcje pokazu
- zapętlanie ciągłe
- pokaz bez narracji
- pokaz bez animacji
- kolor pióra
- pokaz slajdów
- niestandardowy pokaz
- przewijanie slajdów
- ręcznie
- z użyciem timingów
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak zarządzać pokazami slajdów w Aspose.Slides dla Pythona przy użyciu .NET. Kontroluj przejścia slajdów, timingi i więcej w formatach PPT, PPTX i ODP z łatwością."
---
## **Wprowadzenie**

W programie Microsoft PowerPoint, ustawienia **Slide Show** są kluczowym narzędziem do przygotowywania i prezentowania profesjonalnych prezentacji. Jedną z najważniejszych funkcji w tej sekcji jest **Set Up Show**, która umożliwia dostosowanie prezentacji do konkretnych warunków i odbiorców, zapewniając elastyczność i wygodę. Dzięki tej funkcji można wybrać typ pokazu (np. prowadzony przez prelegenta, przeglądany przez pojedynczego użytkownika lub przeglądany w kiosku), włączyć lub wyłączyć pętlę, określić konkretne slajdy do wyświetlenia oraz używać timingów. Ten krok przygotowawczy jest kluczowy, aby uczynić prezentację bardziej skuteczną i profesjonalną.

`slide_show_settings` jest własnością klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) typu [SlideShowSettings](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slideshowsettings/), która pozwala zarządzać ustawieniami pokazu slajdów w prezentacji PowerPoint. W tym artykule przyjrzymy się, jak używać tej własności do konfigurowania i sterowania różnymi aspektami ustawień pokazu.

## **Wybór typu pokazu**

`SlideShowSettings.slide_show_type` definiuje typ pokazu slajdów, którym może być instancja jednej z następujących klas: [PresentedBySpeaker](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pl/python-net/aspose.slides/browsedbyindividual/) lub [BrowsedAtKiosk](https://reference.aspose.com/slides/pl/python-net/aspose.slides/browsedatkiosk/). Użycie tej własności pozwala dostosować prezentację do różnych scenariuszy użycia, takich jak automatyczne kioski lub ręczne prezentacje.

Przykładowy kod poniżej tworzy nową prezentację i ustawia typ pokazu na „Browsed by an individual” bez wyświetlania paska przewijania.

```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Włączanie opcji pokazu**

`SlideShowSettings.loop` określa, czy pokaz slajdów ma powtarzać się w pętli aż do ręcznego zatrzymania. Jest to przydatne w automatycznych prezentacjach, które muszą działać ciągle. `SlideShowSettings.show_narration` określa, czy podczas pokazu mają być odtwarzane narracje głosowe. Jest to przydatne w automatycznych prezentacjach zawierających wskazówki głosowe dla publiczności. `SlideShowSettings.show_animation` określa, czy animacje dodane do obiektów slajdu mają być odtwarzane. To umożliwia pełne wykorzystanie efektów wizualnych prezentacji.

Poniższy przykład kodu tworzy nową prezentację i ustawia pętlę pokazu.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Wybór slajdów do wyświetlenia**

Własność `SlideShowSettings.slides` pozwala wybrać zakres slajdów, które mają być wyświetlane podczas prezentacji. Jest to przydatne, gdy trzeba pokazać tylko część prezentacji, a nie wszystkie slajdy. Poniższy przykład kodu tworzy nową prezentację i ustawia zakres slajdów od `2` do `9`.

```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Użycie timingów slajdów**

Własność `SlideShowSettings.use_timings` pozwala włączyć lub wyłączyć użycie presetowanych timingów dla każdego slajdu. Jest to przydatne do automatycznego wyświetlania slajdów z określonym czasem trwania. Przykładowy kod poniżej tworzy nową prezentację i wyłącza użycie timingów.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Wyświetlanie kontrolek mediów**

Własność `SlideShowSettings.show_media_controls` określa, czy podczas pokazu mają być wyświetlane kontrolki multimedialne (takie jak odtwarzanie, pauza i zatrzymanie), gdy odtwarzane są treści multimedialne (np. wideo lub audio). Jest to przydatne, gdy chcesz dać prezenterowi kontrolę nad odtwarzaniem mediów podczas prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza wyświetlanie kontrolek mediów.

```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę zapisać prezentację tak, aby otwierała się bezpośrednio w trybie pokazu?**

Tak. Zapisz plik jako PPSX lub PPSM; formaty te uruchamiają się bezpośrednio w trybie pokazu po otwarciu w PowerPoint. W Aspose.Slides wybierz odpowiedni format zapisu [podczas eksportu](/slides/pl/python-net/save-presentation/).

**Czy mogę wykluczyć poszczególne slajdy z pokazu bez ich usuwania z pliku?**

Tak. Oznacz slajd jako [hidden](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/hidden/). Ukryte slajdy pozostają w prezentacji, ale nie są wyświetlane podczas pokazu.

**Czy Aspose.Slides może odtworzyć pokaz slajdów lub sterować prezentacją na żywo na ekranie?**

Nie. Aspose.Slides edytuje, analizuje i konwertuje pliki prezentacji; rzeczywiste odtwarzanie jest obsługiwane przez aplikację przeglądarki, taką jak PowerPoint.