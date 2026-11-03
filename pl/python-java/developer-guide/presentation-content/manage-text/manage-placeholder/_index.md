---
title: Zarządzanie polami zastępczymi prezentacji w Pythonie
linktitle: Zarządzaj polami zastępczymi
type: docs
weight: 10
url: /pl/python-java/manage-placeholder/
keywords:
- pole zastępcze
- pole zastępcze tekstu
- pole zastępcze obrazu
- pole zastępcze wykresu
- pole zastępcze zawartości
- tekst podpowiedzi
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować pola zastępcze tekstu, obrazu, wykresu i zawartości oraz zrozumieć dziedziczenie pól zastępczych przy użyciu Aspose.Slides dla Pythona poprzez Javę."
---
## **Przegląd**

Pola zastępcze to kształty, które rezerwują pozycję dla określonego rodzaju treści w szablonie prezentacji. Popularne przykłady to tytuł, treść, obraz, wykres oraz ogólne pola zastępcze zawartości. W przeciwieństwie do zwykłego kształtu, pole zastępcze może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu nadrzędnego.

Aspose.Slides udostępnia informacje o polach zastępczych za pośrednictwem metody [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder). Metoda zwraca obiekt [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) albo `None` dla zwykłego kształtu. Użyj [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) aby określić, co pole zastępcze ma zawierać.

Typ kształtu nadal ma znaczenie po określeniu typu pola zastępczego:

- Puste miejsce na tekst, obraz, wykres lub zawartość jest zazwyczaj reprezentowane przez [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Wypełnione pole zastępcze obrazu może być reprezentowane przez [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Wypełnione pole zastępcze wykresu może być reprezentowane przez [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Pole zawartości może zawierać kilka rodzajów treści. Sprawdź zarówno [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) jak i typ kształtu w czasie wykonywania zamiast zakładać, że każde pole zastępcze jest [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) opisuje rolę pola zastępczego; nie gwarantuje typu kształtu w czasie wykonywania. Zawsze używaj sprawdzania typu przed dostępem do tekstu, obrazu, wykresu, tabeli lub elementów multimedialnych.
{{% /alert %}}

## **Zrozumienie dziedziczenia pól zastępczych**

Placeholders tworzą hierarchię:

1. Slajd nadrzędny definiuje style wielokrotnego użytku i, w niektórych przypadkach, pola zastępcze na poziomie nadrzędnym.
2. Slajd układu definiuje układ używany przez jeden lub więcej zwykłych slajdów i może dziedziczyć z nadrzędnego.
3. Zwykły slajd zawiera pola zastępcze dla tego slajdu i może dziedziczyć z jego układu.

Wywołaj [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) aby przejść o jeden poziom wyżej w tej hierarchii. Pole zastępcze slajdu zazwyczaj zwraca swoje pole zastępcze układu; pole zastępcze układu może zwrócić swoje pole nadrzędne. Metoda zwraca `None`, gdy kształt nie ma bazowego pola zastępczego.

Poniższy przykład wymienia pola zastępcze na pierwszym slajdzie i zgłasza ich bazowe pola:

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

Edycja pola zastępczego na zwykłym slajdzie tworzy lub zmienia lokalne nadpisanie tego slajdu. Edycja powiązanego układu lub slajdu nadrzędnego może wpłynąć na wszystkie slajdy, które nadal dziedziczą to ustawienie. Zwykły lokalny kształt nie ma bazowego pola zastępczego i nie zaczyna dziedziczyć tylko dlatego, że zajmuje te same współrzędne.

## **Usunięcie statusu pola zastępczego**

Podczas dostosowywania szablonu, użyj [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) aby zachować istniejący obiekt jako zwykły kształt. Jego metoda [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) zwraca `None`, ale kształt pozostaje w kolekcji slajdu. W przeciwieństwie do tego, [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) usuwa kształt z tej kolekcji.

Poniższy przykład wymaga pliku `template.pptx` z co najmniej jednym slajdem i niepustym polem tekstowym na pierwszym slajdzie. Użyj pola zastępczego z formatowaniem dziedziczonym z jego układu lub slajdu nadrzędnego, aby zobaczyć efekt usunięcia tej relacji. Przykład sprawdza, że ten sam kształt pozostaje, wywołuje metodę ponownie na teraz zwykłym kształcie i zapisuje wynik.

{{% alert color="warning" title="Warning" %}}
Usunięcie statusu pola zastępczego nie zachowuje automatycznie dziedziczonych ustawień wyglądu. Poniższy przykład celowo pozostawia te ustawienia niezmienione, więc wynik może wyglądać inaczej. Kształt, którego pozycja i rozmiar są całkowicie dziedziczone, może po wywołaniu mieć zerowe współrzędne i wymiary i stać się niewidoczny, mimo że pozostaje w kolekcji.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Wywołanie metody na zwykłym kształcie nie ma efektu.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Dla pasującego pola zastępczego wszystkie trzy sprawdzenia zwracają `True`. Tekst pozostaje, ale dziedziczone pozycja, rozmiar, obrót, czcionka, wyrównanie akapitu, marginesy ramki tekstu, pionowe kotwiczenie, wypełnienie i ustawienia linii mogą się zmienić po usunięciu relacji pola zastępczego. Na przykład, dziedziczone formatowanie tytułu może powrócić do zwykłego formatowania tekstu. Zobacz [Układ slajdu](/slides/pl/python-java/slide-layout/) po więcej o układach.

Aby zachować zamierzony wygląd, przechwyć wyliczoną pozycję, rozmiar i obrót przed wywołaniem i skopiuj wymagane efektywne wartości formatowania do oddzielnych zmiennych. Pobierz te wartości za pomocą [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective), i [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). Nie polegaj wyłącznie na obiektach efektownego formatu, ponieważ ich wartości formatowania tekstu mogą się zmienić po usunięciu relacji. Zastosuj wyraźnie przechwycone wartości do zwykłego kształtu później, w tym rodzinę czcionki, rozmiar, styl, kolor, ustawienia akapitu, ustawienia ramki tekstu, wypełnienie i linię używaną w szablonie.

Może być konieczne także explicite przypisanie dziedziczonej geometrii kształtu poprzez [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). Dla prostokątnego pola tekstowego oznacza to przypisanie [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); przywrócenie jedynie wypełnienia i linii może nie przywrócić widocznego prostokąta. Szablony z dodatkowymi efektami lub bardziej złożonym formatowaniem również wymagają obsługi tych ustawień.

## **Zmienianie tekstu w polu zastępczym**

Tytułowe, wyśrodkowane tytuły, podtytuły, treść i pola tekstowe zazwyczaj obsługują tekst. Sprawdź, czy jest to [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/), zanim użyjesz jego metody [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame).

Poniższy przykład aktualizuje pierwsze pole tytułowe na pierwszym slajdzie i zapisuje wynik:

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

Ten wzorzec unika traktowania pól zastępczych obrazu, wykresu, tabeli lub multimediów jako [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Identyfikuje ono pole zastępcze według przeznaczenia zamiast polegać na kruchej indeksacji kształtu.

## **Ustawianie tekstu podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w czasie projektowania w pustym polu zastępczym, np. *Kliknij, aby dodać tytuł*. Ustaw niestandardowy tekst podpowiedzi w polu zastępczym układu, zamiast próbować dotrzeć do niego przez kolekcję kształtów zwykłego slajdu. Uzyskaj dostęp do układu poprzez [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide), i iteruj po kolekcji zwróconej przez [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

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

Tekst podpowiedzi nie jest normalną treścią slajdu. Jest przeznaczony dla pustych pól zastępczych w aplikacjach edycyjnych, takich jak PowerPoint. Gdy użytkownik lub program dostarczy rzeczywistą treść, podpowiedź nie jest już wyświetlana. Zmiana podpowiedzi nie zastępuje również istniejącego tekstu na slajdach wykorzystujących dany układ.

## **Aktualizacja pola zastępczego obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli pole zastępcze obrazu jest już wypełnione i reprezentowane przez [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), zamień obraz za pomocą [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) i [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- Jeśli jest nadal pustym polem zastępczym, dodaj ramkę obrazu w współrzędnych pola za pomocą [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) i usuń puste pole zastępcze.

Następny przykład obsługuje oba przypadki i zapisuje prezentację:

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

Zastąpienie utworzone dla pustego pola jest lokalną ramką obrazu, a nie nowym polem zastępczym, ponieważ [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) nie udostępnia settera. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla pola zastępczego. Jeśli zachowanie relacji pola jest kluczowe, najpierw przygotuj i wypełnij pole w PowerPoint, a następnie zaktualizuj powstały [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) przy użyciu Aspose.Slides.

W celu uzyskania przezroczystości obrazu, przycinania i innych efektów specyficznych dla obrazu, zobacz [Zarządzanie ramkami obrazów](/slides/pl/python-java/picture-frame/). Te operacje dotyczą ramki obrazu lub wypełnienia obrazu, a nie metadanych pola zastępczego.

## **Praca z polami zastępczymi wykresów i zawartości**

Wypełnione pole zastępcze wykresu może być reprezentowane przez [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). Ten przykład znajduje taki wykres zarówno po typie pola, jak i typie kształtu w czasie wykonywania, zmienia jego tytuł i zapisuje plik:

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

Ogólne pole zawartości zazwyczaj ma [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). W PowerPoint działa jako uruchamiacz dla kilku typów zawartości, w tym wykresów, tabel, diagramów, obrazów i mediów. Po jego wypełnieniu, sprawdź rzeczywisty typ kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą również eksponować [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) lub [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides nie konwertuje pustego [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) w [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) jedynie zmieniając [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType); typu nie można zmienić za pośrednictwem API. Aby wypełnić pusty obszar wykresu lub zawartości programowo, dodaj wymagany obiekt w współrzędnych pola zastępczego, a następnie usuń puste pole. Poniższy przykład robi to dla wykresu:

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

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar pola zastępczego, ale nie dziedziczy z pola układu. Skorzystaj z dedykowanych [artykuły o zarządzaniu wykresami](/slides/pl/python-java/powerpoint-charts/) gdy musisz zastąpić jego kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja treści tekstowej lub obrazowej**

Poniższy kompleksowy przykład otwiera szablon, przeszukuje pierwszy slajd pod kątem pola tytułowego lub obrazu, sprawdza typy pola i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub traktowania każdego pola zastępczego jako tego samego typu.

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

**Czym jest bazowe pole zastępcze?**

Bazowe pole zastępcze to odpowiedni kształt w układzie lub slajdzie nadrzędnym, z którego inne pole dziedziczy. Użyj [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) aby je pobrać. Zwykły lokalny kształt zwraca `None`, ponieważ nie jest częścią hierarchii pól zastępczych.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując pole zastępcze układu?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułu jest przechowywana na zwykłych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, iteruj po slajdach i zaktualizuj każde pole tytułowe.

**Jak zarządzać polami zastępczymi daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki na odpowiednim slajdzie, układzie, slajdzie nadrzędnym, notatkach lub wyciągu. Zobacz [Zarządzanie nagłówkiem i stopką prezentacji](/slides/pl/python-java/presentation-header-and-footer/) po pełne przykłady.