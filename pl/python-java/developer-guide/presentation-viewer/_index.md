---
title: Utwórz przeglądarkę prezentacji w Pythonie za pośrednictwem Javy
linktitle: Przeglądarka prezentacji
type: docs
weight: 50
url: /pl/python-java/presentation-viewer/
keywords:
- przeglądaj prezentację
- przeglądarka prezentacji
- utwórz przeglądarkę prezentacji
- wyświetl PPT
- wyświetl PPTX
- wyświetl ODP
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Utwórz niestandardową przeglądarkę prezentacji w Pythonie za pośrednictwem Javy przy użyciu Aspose.Slides. Łatwo wyświetlaj pliki PowerPoint i OpenDocument bez Microsoft PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java służy do tworzenia plików prezentacji ze slajdami. Te slajdy mogą być oglądane poprzez otwieranie prezentacji w programie Microsoft PowerPoint, na przykład. Jednak czasami programiści mogą potrzebować wyświetlać slajdy jako obrazy w swoim ulubionym przeglądarce obrazów lub stworzyć własną przeglądarkę prezentacji. W takich przypadkach Aspose.Slides umożliwia eksportowanie pojedynczego slajdu jako obrazu. Ten artykuł opisuje, jak to zrobić.

## **Generowanie obrazu SVG ze slajdu**

Aby wygenerować obraz SVG ze slajdu prezentacji przy użyciu Aspose.Slides, proszę postępować zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Pobierz referencję do slajdu przy użyciu jego indeksu.
1. Otwórz strumień bajtów.
1. Zapisz slajd jako obraz SVG do strumienia i zapisz go do pliku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Generowanie SVG z niestandardowym identyfikatorem kształtu**

Aspose.Slides może być użyte do wygenerowania [SVG](https://docs.fileformat.com/page-description-language/svg/) ze slajdu z niestandardowym identyfikatorem kształtu. Aby to zrobić, użyj metody [SvgShape.setId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgshape/#setId) z klasy [SvgShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` może być użyty do ustawienia identyfikatora kształtu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Utworzenie miniatury slajdu**

Aspose.Slides pomaga generować obrazy miniaturek slajdów. Aby wygenerować miniaturę slajdu przy użyciu Aspose.Slides, proszę postępować zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Pobierz referencję do slajdu przy użyciu jego indeksu.
1. Uzyskaj obraz miniatury referencjonowanego slajdu w określonej skali.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Utworzenie miniatury slajdu o wymiarach definiowanych przez użytkownika**

Aby stworzyć obraz miniatury slajdu o wymiarach definiowanych przez użytkownika, proszę postępować zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Pobierz referencję do slajdu przy użyciu jego indeksu.
1. Uzyskaj obraz miniatury referencjonowanego slajdu z określonymi wymiarami.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Utworzenie miniatury slajdu z notatkami prelegenta**

Aby wygenerować miniaturę slajdu z notatkami prelegenta przy użyciu Aspose.Slides, proszę postępować zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [RenderingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/).
1. Użyj metody [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), aby ustawić pozycję notatek prelegenta.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Pobierz referencję do slajdu przy użyciu jego indeksu.
1. Uzyskaj obraz miniatury referencjonowanego slajdu przy użyciu opcji renderowania.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Przykład na żywo**

Możesz wypróbować darmową aplikację [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pl/viewer/), aby zobaczyć, co możesz zrealizować przy użyciu API Aspose.Slides:

![Internetowy przeglądacz PowerPoint](online-PowerPoint-viewer.png)

## **FAQ**

**Czy mogę osadzić przeglądarkę prezentacji w aplikacji internetowej?**

Tak. Możesz używać Aspose.Slides po stronie serwera do renderowania slajdów jako obrazy lub HTML i wyświetlać je w przeglądarce. Funkcje nawigacji i powiększania mogą być zaimplementowane w JavaScript, aby zapewnić interaktywne doświadczenie.

**Jaki jest najlepszy sposób wyświetlania slajdów w niestandardowej przeglądarce?**

Zalecane podejście to renderowanie każdego slajdu jako obrazu (np. PNG lub SVG) lub konwersja do HTML przy użyciu Aspose.Slides, a następnie wyświetlenie wyniku w kontrolce obrazu (dla aplikacji desktopowych) lub w kontenerze HTML (dla aplikacji webowych).

**Jak obsługiwać duże prezentacje z wieloma slajdami?**

W przypadku dużych prezentacji warto zastosować leniwe wczytywanie lub renderowanie slajdów na żądanie. Oznacza to generowanie treści slajdu tylko wtedy, gdy użytkownik przechodzi do niego, co zmniejsza zużycie pamięci i czas ładowania.