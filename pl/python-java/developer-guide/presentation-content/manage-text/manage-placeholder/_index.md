---
title: Zarządzanie placeholderami prezentacji w Pythonie
linktitle: Zarządzanie placeholderami
type: docs
weight: 10
url: /pl/python-java/manage-placeholder/
keywords:
- symbol zastępczy
- placeholder tekstowy
- placeholder obrazu
- placeholder wykresu
- placeholder treści
- tekst podpowiedzi
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstu, obrazu, wykresu i treści oraz zrozumieć dziedziczenie placeholderów przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Placeholder to kształt, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowymi przykładami są tytuł, ciało, obraz, wykres i ogólne placeholdery treści. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu master.

Aspose.Slides udostępnia informacje o placeholderach poprzez metodę [Shape.getPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getPlaceholder). Metoda zwraca obiekt [Placeholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholder/) lub `None` dla zwykłego kształtu. Użyj [Placeholder.getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholder/#getType), aby określić, co placeholder ma zawierać.

Typ kształtu nadal ma znaczenie po poznaniu typu placeholdera:

- Pusty placeholder tekstu, obrazu, wykresu lub treści jest zwykle reprezentowany przez [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/).
- Placeholder treści może zawierać różne rodzaje treści. Sprawdzaj zarówno [Placeholder.getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholder/#getType), jak i typ kształtu w czasie wykonywania, zamiast zakładać, że każdy placeholder jest [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Ostrzeżenie" %}}
[Placeholder.getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholder/#getType) opisuje rolę placeholdera; nie gwarantuje on typu kształtu w czasie wykonywania. Zawsze sprawdzaj typ przed dostępem do elementów specyficznych dla tekstu, obrazu, wykresu, tabeli lub multimediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd master definiuje style wielokrotnego użytku i, w niektórych przypadkach, placeholdery na poziomie master.
2. Slajd układu definiuje rozmieszczenie używane przez jeden lub więcej zwykłych slajdów i może dziedziczyć po masterze.
3. Zwykły slajd zawiera placeholdery dla tego slajdu i może dziedziczyć po swoim układzie.

Wywołaj [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getBasePlaceholder), aby przejść jeden poziom wyżej w tej hierarchii. Placeholder slajdu zazwyczaj zwraca placeholder układu; placeholder układu może zwrócić placeholder master. Metoda zwraca `None`, gdy kształt nie ma podstawowego placeholdera.

Poniższy przykład wyświetla placeholdery na pierwszym slajdzie i raportuje ich podstawowe placeholdery:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Edycja placeholdera na zwykłym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edycja powiązanego układu lub mastera może wpływać na wszystkie slajdy, które nadal dziedziczą to ustawienie. Zwykły lokalny kształt nie ma podstawowego placeholdera i nie zaczyna dziedziczyć tylko dlatego, że zajmuje te same współrzędne.

## **Zmiana tekstu w placeholderze**

Placeholdery typu tytuł, tytuł‑środkowy, podtytuł, ciało i tekst zazwyczaj obsługują tekst. Sprawdź, czy kształt jest [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/), zanim użyjesz jego metody [getTextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#getTextFrame).

Ten przykład aktualizuje pierwszy placeholder tytułu na pierwszym slajdzie i zapisuje wynik:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ten wzorzec unika traktowania placeholderów obrazu, wykresu, tabeli lub multimediów jako [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/). Identifikuje także placeholder po przeznaczeniu, zamiast polegać na kruchym indeksie kształtu.

## **Ustawienie tekstu podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w pustym placeholderze w czasie projektowania, np. *Kliknij, aby dodać tytuł*. Ustaw niestandardowy tekst podpowiedzi w placeholderze układu, zamiast próbować dotrzeć do niego przez kolekcję kształtów zwykłego slajdu. Uzyskaj dostęp do układu przez [Slide.getLayoutSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getLayoutSlide) i iteruj po kolekcji zwróconej przez [BaseSlide.getShapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslide/#getShapes).

Poniższy przykład zmienia podpowiedzi tytułu i podtytułu w układzie używanym przez pierwszy slajd:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tekst podpowiedzi nie jest normalną treścią slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edycyjnych, takich jak PowerPoint. Po tym, jak użytkownik lub program dostarczy rzeczywistą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje istniejącego tekstu na slajdach, które używają tego układu.

## **Aktualizacja placeholdera obrazu**

Obsługiwane są dwa przypadki:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/), zamień obraz przy użyciu [PictureFillFormat.getPicture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/#getPicture) i [Picture.setImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picture/#setImage).
- Jeśli jest nadal pustym placeholderem, dodaj ramkę obrazu w współrzędnych placeholdera przy użyciu [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addPictureFrame) i usuń pusty placeholder.

Kolejny przykład obsługuje oba przypadki i zapisuje prezentację:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zamiennik utworzony dla pustego placeholdera jest lokalną ramką obrazu, a nie nowym placeholderem, ponieważ [Shape.getPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getPlaceholder) nie udostępnia setter‑a. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli utrzymanie relacji placeholdera jest istotne, przygotuj i wypełnij placeholder w PowerPoint, a następnie zaktualizuj powstały [PictureFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pictureframe/) przy użyciu Aspose.Slides.

W celu uzyskania przezroczystości obrazu, przycinania i innych efektów specyficznych dla obrazu, zobacz [Manage Picture Frames](/slides/pl/python-java/picture-frame/). Operacje te dotyczą ramki obrazu lub wypełnienia obrazu, a nie metadanych placeholdera.

## **Praca z placeholderami wykresów i treści**

Wypełniony placeholder wykresu może być reprezentowany przez [Chart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i typie runtime, zmienia jego tytuł i zapisuje plik:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ogólny placeholder treści zazwyczaj ma typ [PlaceholderType.Object](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholdertype/#Object). W PowerPoint działa jako uruchamiacz dla wielu typów treści, w tym wykresów, tabel, diagramów, obrazów i multimediów. Po wypełnieniu, sprawdź rzeczywisty typ kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą także eksponować [PlaceholderType.Chart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholdertype/#Media) lub [PlaceholderType.Diagram](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides nie konwertuje pustego placeholdera [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) na [Chart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/) jedynie poprzez zmianę [Placeholder.getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholder/#getType); typ nie może być zmieniony przez API. Aby wypełnić pusty obszar wykresu lub treści programowo, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy z placeholdera układu. Skorzystaj z dedykowanych artykułów o zarządzaniu wykresami [chart management articles](/slides/pl/python-java/powerpoint-charts/), gdy potrzebujesz zastąpić kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja tekstu lub obrazu**

Poniższy przykład end‑to‑end otwiera szablon, przeszukuje pierwszy slajd w poszukiwaniu placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład świadomie unika zakładania indeksu kształtu lub traktowania każdego placeholdera jako tego samego typu.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Czym jest podstawowy placeholder?**

Podstawowy placeholder to odpowiadający mu kształt w układzie lub masterze, z którego inny placeholder dziedziczy. Użyj [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getBasePlaceholder), aby go pobrać. Zwykły lokalny kształt zwraca `None`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując placeholder w układzie?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułu jest przechowywana na normalnych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, iteruj po slajdach i aktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki na odpowiednim poziomie: slajd, układ, master, notatki lub rozdanie. Zobacz [Manage Presentation Header and Footer](/slides/pl/python-java/presentation-header-and-footer/) po pełne przykłady.