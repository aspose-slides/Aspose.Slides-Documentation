---
title: Konwertuj slajdy PowerPoint na PNG w Pythonie
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/python-java/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- Python
- Java
- Aspose.Slides
description: Konwertuj slajdy PowerPoint na obrazy PNG w Pythonie za pośrednictwem Javy. Eksportuj prezentacje PPT, PPTX i ODP z niestandardowymi skalami lub dokładnymi wymiarami obrazu.
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na obrazy PNG przy użyciu Aspose.Slides for Python via Java. Można ładować pliki PPT, PPTX i ODP, renderować każdy slajd i zapisywać go jako oddzielny obraz PNG.

Przykłady pokazują także, jak kontrolować wymiary wyjściowe przy użyciu czynników skalowania lub dokładnej szerokości i wysokości. Każdy przykład uruchamia maszynę wirtualną Javy, jeśli jest to potrzebne, i zwalnia zasoby prezentacji oraz obrazu po użyciu.

## **Konwertuj PowerPoint na PNG**

1. Załaduj plik wejściowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Pobierz slajdy przy użyciu [Presentation.getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides).
3. Renderuj każdy slajd przy użyciu [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage).
4. Zapisz każdy wyrenderowany obraz przy użyciu [ImageFormat.Png](https://reference.aspose.com/slides/pl/python-java/aspose.slides/imageformat/#Png), a następnie zwolnij jego zasoby.

Poniższy przykład w Pythonie eksportuje wszystkie slajdy w ich domyślnym rozmiarze:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Konwertuj PowerPoint na PNG z niestandardową skalą**

Przekaż poziome i pionowe czynniki skalowania do [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage), aby zwiększyć lub zmniejszyć wymiary wyjściowe. Na przykład slajd o wymiarach 720 × 540 punktów renderowany ze współczynnikiem skalowania 2 na obu osiach daje obraz 1440 × 1080 pikseli.

Użyj równych czynników skalowania, aby zachować proporcje slajdu. Różne czynniki rozciągają slajd w poziomie lub w pionie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Konwertuj PowerPoint na PNG z niestandardowym rozmiarem**

Aby określić dokładne wymiary w pikselach, przekaż obiekt Java `Dimension` z żądaną szerokością i wysokością do [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage). Wybierz wymiary o tym samym współczynniku proporcji co źródłowy slajd, aby uniknąć zniekształceń.

Poniższy przykład zapisuje każdy slajd jako obraz PNG o wymiarach 960 × 720 pikseli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę wyeksportować pojedynczy kształt, np. wykres lub obraz, zamiast całego slajdu?**

Tak. Aspose.Slides obsługuje [generowanie miniatur dla poszczególnych kształtów](/slides/pl/python-java/create-shape-thumbnails/), które można zapisać jako obrazy PNG.

**Czy mogę konwertować prezentacje równolegle na serwerze?**

Użyj oddzielnej instancji prezentacji dla każdego wątku lub procesu oraz unikalnych ścieżek wyjściowych, aby zapobiec nadpisaniu plików. Nie współdziel instancji prezentacji między wątkami. Zobacz [Multithreading](/slides/pl/python-java/multithreading/).

**Jakie są ograniczenia wersji próbnej przy eksporcie do PNG?**

Tryb ewaluacji dodaje znak wodny do obrazów wyjściowych i nakłada [inne ograniczenia](/slides/pl/python-java/licensing/). Zastosuj licencję, aby usunąć te ograniczenia.