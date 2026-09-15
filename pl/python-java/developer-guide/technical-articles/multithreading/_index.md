---
title: Wielowątkowość w Aspose.Slides dla Pythona przez Java
linktitle: Wielowątkowość
type: docs
weight: 310
url: /pl/python-java/multithreading/
keywords:
- wielowątkowość
- wiele wątków
- równoległa praca
- konwersja slajdów
- slajdy na obrazy
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Wielowątkowość w Aspose.Slides dla Pythona przez Java przyspiesza przetwarzanie PowerPoint i OpenDocument. Odkryj najlepsze praktyki dla wydajnych przepływów pracy z prezentacjami."
---
## **Wprowadzenie**

Chociaż praca równoległa z prezentacjami jest możliwa (z wyjątkiem parsowania, ładowania i klonowania) i zazwyczaj działa dobrze, istnieje małe ryzyko niepoprawnych wyników przy używaniu biblioteki w wielu wątkach.

Zdecydowanie zalecamy, aby **nie** używać pojedynczej [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) instancji w środowisku wielowątkowym, ponieważ może to prowadzić do nieprzewidywalnych błędów lub awarii, które trudno wykryć.

Nie jest **bezpieczne** ładować, zapisywać i/lub klonować instancję [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) w wielu wątkach. Takie operacje są **nieobsługiwane**. Jeśli musisz wykonać takie zadania, musisz równolegle wykonywać operacje przy użyciu kilku jednowątkowych procesów — każdy z tych procesów powinien używać własnej instancji prezentacji.

## **Konwertowanie slajdów prezentacji na obrazy równolegle**

Załóżmy, że chcemy przekonwertować wszystkie slajdy z prezentacji PowerPoint na obrazy PNG równolegle. Ponieważ użycie jednej [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) instancji w wielu wątkach jest niebezpieczne, dzielimy slajdy prezentacji na osobne prezentacje i konwertujemy slajdy na obrazy równolegle, używając każdej prezentacji w osobnym wątku. Poniższy przykład kodu pokazuje, jak to zrobić.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Wyodrębnij slajd do osobnej prezentacji.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Konwertuj slajd na obraz w osobnym zadaniu.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Poczekaj na zakończenie wszystkich zadań.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **FAQ**

**Czy muszę wywoływać konfigurację licencji w każdym wątku?**

Nie. Wystarczy wykonać to raz na proces przed uruchomieniem wątków. Jeśli [license setup](/slides/pl/python-java/licensing/) może być wywoływane jednocześnie (na przykład podczas leniwej inicjalizacji), zsynchronizuj to wywołanie, ponieważ metoda konfiguracji licencji nie jest bezpieczna wątkowo.

**Czy mogę przekazywać obiekty [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) lub [Slide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/) między wątkami?**

Przekazywanie „aktywnych” obiektów prezentacji między wątkami nie jest zalecane: używaj niezależnych instancji na wątek lub utwórz osobne prezentacje lub kontenery slajdów dla każdego wątku z wyprzedzeniem. Takie podejście jest zgodne z ogólną rekomendacją, aby nie udostępniać jednej instancji prezentacji między wątkami.

**Czy bezpieczne jest równoległe eksportowanie do różnych formatów (PDF, HTML, obrazy), pod warunkiem że każdy wątek ma własną instancję [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/)?**

Tak. Przy użyciu niezależnych instancji i oddzielnych ścieżek wyjściowych takie zadania zazwyczaj równolegle działają prawidłowo; unikaj współdzielenia obiektów prezentacji oraz wspólnych strumieni I/O.

**Co powinienem zrobić z globalnymi ustawieniami czcionek (foldery, podstawienia) w środowisku wielowątkowym?**

Zainicjuj wszystkie globalne [font settings](/slides/pl/python-java/powerpoint-fonts/) przed uruchomieniem wątków i nie zmieniaj ich podczas pracy równoległej. Eliminuje to wyścigi przy dostępie do współdzielonych zasobów czcionek.