---
title: Zarządzanie pokazami slajdów w Pythonie przy użyciu Java
linktitle: Pokaz slajdów
type: docs
weight: 90
url: /pl/python-java/manage-slide-show/
keywords:
- typ pokazu
- prezentowane przez prelegenta
- przeglądane przez indywidualnego użytkownika
- przeglądane w kiosku
- opcje pokazu
- pętla ciągła
- pokaz bez narracji
- pokaz bez animacji
- kolor pióra
- pokazywanie slajdów
- niestandardowy pokaz
- przechodzenie slajdów
- ręcznie
- używając czasów
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać pokazami slajdów w Aspose.Slides dla Pythona via Java. Kontroluj przejścia slajdów, czasy i inne elementy w formatach PPT, PPTX i ODP z łatwością."
---
## **Wprowadzenie**

Opcje **Set Up Show** programu Microsoft PowerPoint umożliwiają wybór typu pokazu, włączenie pętli, wybór slajdów oraz kontrolowanie sposobu przechodzenia slajdów. Dzięki Aspose.Slides for Python via Java możesz konfigurować te opcje programowo i zapisywać je w pliku prezentacji.

Metoda [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlideShowSettings) zwraca obiekt [SlideShowSettings](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowsettings/), który kontroluje te opcje. Poniższe przykłady wymagają Aspose.Slides for Python via Java oraz kompatybilnego środowiska uruchomieniowego Java. Każdy przykład uruchamia JVM w razie potrzeby i zwalnia prezentację po zakończeniu.

## **Wybierz typ pokazu**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowsettings/#setSlideShowType) definiuje typ pokazu slajdów, którym może być instancja jednej z następujących klas: [PresentedBySpeaker](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/pl/python-java/aspose.slides/browsedbyindividual/), lub [BrowsedAtKiosk](https://reference.aspose.com/slides/pl/python-java/aspose.slides/browsedatkiosk/). Użycie tej metody pozwala dostosować prezentację do różnych scenariuszy użycia, takich jak automatyczne kioski czy prezentacje ręczne.

Poniższy przykład kodu tworzy nową prezentację i ustawia typ pokazu na „Browsed by an individual” bez wyświetlania paska przewijania.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Włącz opcje pokazu**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowsettings/#setLoop) określa, czy pokaz slajdów ma powtarzać się w pętli, aż zostanie ręcznie zatrzymany. Jest to przydatne w automatycznych prezentacjach, które muszą działać nieprzerwanie. Metoda [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowsettings/#setShowNarration) określa, czy narracje głosowe mają być odtwarzane podczas pokazu slajdów. Jest to przydatne w automatycznych prezentacjach zawierających wskazówki głosowe dla odbiorców. Metoda [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowsettings/#setShowAnimation) określa, czy animacje dodane do obiektów slajdu mają być odtwarzane. Jest to przydatne do zapewnienia pełnego efektu wizualnego prezentacji.

Poniższy przykład kodu tworzy nową prezentację i powtarza pokaz slajdów w pętli.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wybierz slajdy do wyświetlenia**

Metoda [SlideShowSettings.setSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowsettings/#setSlides) umożliwia wybór zakresu slajdów, które mają być wyświetlane podczas prezentacji. Jest to przydatne, gdy trzeba pokazać tylko część prezentacji, a nie wszystkie slajdy. Poniższy przykład kodu tworzy prezentację z dziewięcioma slajdami i wybiera slajdy od 2 do 9. Zakres używa numeracji slajdów zaczynającej się od 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Utwórz dziewięć slajdów, aby wybrany zakres istniał.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontroluj przechodzenie slajdów**

Metoda [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowsettings/#setUseTimings) pozwala włączyć lub wyłączyć użycie wstępnie ustalonych czasów wyświetlania dla każdego slajdu. Jest to przydatne do automatycznego wyświetlania slajdów z określonymi z góry czasami trwania. Poniższy przykład kodu tworzy nową prezentację i wyłącza użycie czasów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pokaż kontrolki multimediów**

Metoda [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) określa, czy kontrolki multimedialne (takie jak odtwarzanie, pauza i zatrzymanie) powinny być wyświetlane podczas pokazu slajdów, gdy odtwarzana jest zawartość multimedialna (np. wideo lub audio). Jest to przydatne, gdy chcesz dać prezenterowi kontrolę nad odtwarzaniem multimediów w trakcie prezentacji.

Poniższy przykład kodu tworzy nową prezentację i włącza wyświetlanie kontrolek multimedialnych.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę zapisać prezentację tak, aby otwierała się bezpośrednio w trybie pokazu slajdów?**

Tak. Zapisz plik jako PPSX lub PPSM; te formaty uruchamiają się bezpośrednio w trybie pokazu slajdów po otwarciu w PowerPoint. W Aspose.Slides wybierz odpowiedni format zapisu [during export](/slides/pl/python-java/save-presentation/).

**Czy mogę wykluczyć pojedyncze slajdy z pokazu bez usuwania ich z pliku?**

Tak. Oznacz slajd jako [hidden](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#setHidden). Ukryte slajdy pozostają w prezentacji, ale nie są wyświetlane podczas pokazu slajdów.

**Czy Aspose.Slides może odtwarzać pokaz slajdów lub kontrolować bieżącą prezentację na ekranie?**

Nie. Aspose.Slides edytuje, analizuje i konwertuje pliki prezentacji; rzeczywiste odtwarzanie jest obsługiwane przez aplikację wyświetlającą, taką jak PowerPoint.