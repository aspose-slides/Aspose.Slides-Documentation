---
title: Zarządzanie kształtami prezentacji w Pythonie via Java
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/python-java/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtów
- Pobierz ID kształtu interop
- Alternatywny tekst kształtu
- Punkt regulacji kształtu
- Regulacja presetowego kształtu
- Geometria kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Odwróć kształt
- PowerPoint
- Prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, regulować, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odwracać kształty prezentacji przy użyciu Aspose.Slides dla Pythona via Java."
---
## **Przegląd**

Aspose.Slides for Python via Java reprezentuje kształty na slajdzie jako uporządkowaną [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/). Kolekcja jest zarówno miejscem, w którym można znajdować i modyfikować kształty, jak i źródłem ich kolejności warstw: indeks `0` to najbardziej tylni kształt, a ostatni indeks to najbardziej przedni kształt.

Ten artykuł podąża za tym modelem. Najpierw wyjaśnia, jak wiarygodnie zidentyfikować kształt i zmodyfikować presetowe punkty regulacji, a następnie pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport SVG, wyrównywanie i ustawienia odbicia. Każdy przykład jest niezależny, tak aby można było używać tylko operacji wymaganych w danym przepływie pracy.

## **Identyfikacja i znajdowanie kształtów**

Indeksy kolekcji są wygodne przy przetwarzaniu znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator zgodnie z tym, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getName) jest przydatny dla szablonów kontrolowanych przez dewelopera i łatwo go sprawdzić w panelu wyboru w PowerPoint. Nazwy można edytować i nie są gwarantowane jako unikalne, dlatego warto ustalić konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getAlternativeText) jest przydatny, gdy opis dostępności lub tag nadany przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisany dla dostępności i nie jest gwarantowany jako unikalny. Nie należy cicho wykorzystywać znaczącego tekstu dostępności jako klucza bazodanowego.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getOfficeInteropShapeId) jest identyfikatorem tylko do odczytu, unikalnym w ramach slajdu i odpowiada identyfikatorowi kształtu używanemu przez interop PowerPoint. Użyj go przy integracji z PowerPoint lub gdy potrzebujesz jednoznacznego odniesienia w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana metoda [getUniqueId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getUniqueId) zwraca identyfikator o zasięgu prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie powinna być traktowana jako trwały zewnętrzny klucz. Jeśli długoterminowa tożsamość jest istotna, przechowuj mapowanie w danych aplikacji i weryfikuj, czy oczekiwany kształt nadal istnieje.

Poniższy przykład wyszukuje po nazwie przy użyciu dokładnego porównania i zgłasza interopowy identyfikator w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z nieprawidłowym obiektem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Gdy operacja jest specyficzna dla typu kształtu, sprawdź typ przed użyciem członków specyficznych dla typu. Ten przykład aktualizuje tekst i alternatywny tekst tylko jeśli nazwany obiekt jest [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Identyfikacja i modyfikacja wstępnie zdefiniowanych regulacji kształtu**

Kształty o presetowej geometrii mogą udostępniać punkty regulacji kontrolujące takie cechy jak rozmiar narożników, proporcje strzałek czy kąty łuków. Dostęp do nich uzyskuje się przez kolekcję tylko do odczytu [GeometryShape.getAdjustments](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/#getAdjustments). Sama kolekcja jest dostarczana przez kształt, ale każdy [AdjustValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/) zawiera wartość, którą można zmienić.

Nie polegaj wyłącznie na stałym indeksie kolekcji. Iteruj po regulacjach i sprawdzaj metodę tylko do odczytu [getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getType), której wartość [ShapeAdjustmentType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/) opisuje, co dana regulacja kontroluje. Metoda tylko do odczytu [getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getName) dostarcza dodatkowe informacje identyfikacyjne i jest szczególnie przydatna, gdy preset zawiera więcej niż jedną regulację o tym samym typie semantycznym.

Użyj metody wartości pasującej do znaczenia regulacji:

| Typ regulacji | Cel | Wartość do zmiany |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Rozmiar zaokrąglonych narożników | [setRawValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Grubość ogona strzałki | [setRawValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Długość grotka strzały | [setRawValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Szerokość grotka strzały | [setRawValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Kąt początkowy wycinka lub łuku | [setAngleValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Kąt końcowy wycinka lub łuku | [setAngleValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getType) i [getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getName) zwracają informacje tylko do odczytu. [getRawValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getRawValue) i [setRawValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setRawValue) działają na liczbie całkowitej w natywnych jednostkach geometrii presetu, natomiast [getAngleValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getAngleValue) i [setAngleValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setAngleValue) pracują z kątem w stopniach. Liczba, kolejność, znaczenie i dopuszczalny zakres regulacji zależą od presetu [ShapeType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/#getShapeType). Wartość ważna dla jednego presetu może być niewłaściwa lub mieć inny efekt dla innego.

Gdy [getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getType) zwraca [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeadjustmenttype/#Custom), API nie rozpoznaje standardowego znaczenia semantycznego. Sprawdź [getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getName), typ presetu i istniejącą wartość, i pozostaw regulację niezmienioną, chyba że znane jest jej znaczenie i zakres. Nawet dla rozpoznanych typów, sprawdź, czy ten sam typ występuje więcej niż raz przed wybraniem wartości. Artykuł [Connector](/slides/pl/python-java/connector/) pokazuje tę sytuację w kontekście regulacji zgięcia łącznika.

Poniższy kompletny przykład tworzy domyślne i zmodyfikowane wersje trzech presetowych kształtów. Iteruje po każdej regulacji, zgłasza jej nazwę i typ, zmienia wartości związane z rozmiarem za pomocą [setRawValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setRawValue), zmienia kąty za pomocą [setAngleValue](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#setAngleValue) i zapisuje rezultat. Lewa kolumna zachowuje domyślną geometrię; prawa kolumna pokazuje dostosowany zaokrąglony prostokąt, czterokierunkową strzałkę oraz wycinek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaje nagłówki dla kolumn domyślnego i zmodyfikowanego kształtu.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sprawdzanie typu semantycznego przed zmianą wartości sprawia, że kod jest jednoznaczny w zamiarze i unika założenia, że konkretny indeks kolekcji ma to samo znaczenie w różnych presetowych kształtach.

## **Modyfikacja kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają bezpośrednio na kolekcji. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie kontynuuj polegania na indeksach przechwyconych przed tą operacją.

### **Klonowanie kształtu**

[addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addClone) tworzy niezależną kopię i dołącza ją do docelowej kolekcji. [insertClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#insertClone) również tworzy kopię, ale umieszcza ją pod określonym indeksem kolejności Z. Przeciążenia przyjmujące współrzędne przenoszą klon bez zmiany rozmiaru; przeciążenia z szerokością i wysokością mogą również zmienić rozmiar.

Przykład tworzy docelowy slajd, klonuje opisany prostokąt na wierzch i wstawia drugi klon z tyłu. Zmiany w którymkolwiek klonie nie modyfikują kształtu źródłowego.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę i tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są obsługiwane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#remove) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielokrotnych dopasowań w trakcie iteracji po indeksach, przechodź od końca, aby każdy pozostały indeks pozostał prawidłowy.

Ten przykład usuwa każdy kształt o określonej nazwie. Odczytuje kształt pod bieżącym indeksem, a nie stały element kolekcji, i nie rzutuje niepotrzebnie kształtu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Po usunięciu liczba kształtów i indeksy kolejnych kształtów ulegają zmianie. Odwołania do niezmienionych kształtów pozostają bardziej wiarygodne niż zapisane indeksy. Warto również uwzględnić łączniki, animacje i inne elementy prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż tylko wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Hidden](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setHidden) na `True` pozostawia kształt w kolekcji, ale zapobiega jego wyświetleniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne w kodzie, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą być przywrócone później.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ukrywanie nie jest usunięciem ani zabezpieczeniem. Obiekt nadal może być odkryty i odsłonięty przez użytkownika lub kod i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z**

Nakładające się kształty są malowane w kolejności kolekcji. [reorder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#reorder) przenosi istniejący kształt do docelowego indeksu bez jego klonowania. Indeks `0` to tył; [size](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#size) kolekcji minus jeden to przód.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prostokąt jest tworzony jako pierwszy i początkowo znajduje się za elipsą. Przeniesienie go na ostatni indeks umieszcza go z przodu. Finalizuj kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dołączają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną kolejkę warstw.

## **Inspekcja kształtów na slajdach układu**

Zwykłe slajdy, slajdy układu i slajdy główne mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie pozycjonowany kształt na zwykłym slajdzie. Sprawdzaj kształty układu, gdy musisz zrozumieć lub zmienić formatowanie dostarczane przez układ.

Poniższy przykład odczytuje [FillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getFillFormat) i [LineFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getLineFormat) każdego kształtu układu, nie zakładając, że każdy kształt jest [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Edycja układu może wpływać na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy zwykły slajd dziedziczy obiekt lub zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksport kształtu do SVG**

Metoda `writeAsSvg` klasy [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/) zapisuje wyrenderowaną zawartość jednego kształtu do strumienia. Wynik zawiera sam kształt, a nie całe tło slajdu ani sąsiadujące kształty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Utrzymuj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd zamiast pojedynczego kształtu. Wywołujący jest właścicielem strumienia i musi go zamknąć.

## **Wyrównywanie kształtów**

Przeciążenia [SlideUtil.alignShapes](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideutil/#alignShapes) wyrównują albo wszystkie kształty, albo wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb dystrybucji. Ustaw `align_to_slide` na `True`, aby używać krawędzi slajdu; ustaw na `False`, aby wyrównać wybrane kształty względem siebie.

Przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Odniesienia do kształtów są konwertowane na ich aktualne indeksy bezpośrednio przed wyrównaniem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wyrównanie zmienia pozycje, nie kolejność Z. Wyrównanie względne zwykle wymaga co najmniej dwóch kształtów, podczas gdy dystrybucja pozioma lub pionowa potrzebuje wystarczającej liczby kształtów do określenia odstępów. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odwracanie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz rotację. Jej wartości [getFlipH](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeframe/#getFlipH) i [getFlipV](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeframe/#getFlipV) używają [NullableBool](https://reference.aspose.com/slides/pl/python-java/aspose.slides/nullablebool/): `True` włącza odbicie, `False` wyłącza, a `NotDefined` zachowuje nieokreślony/domyślny stan.

Poniższa prezentacja wejściowa zawiera jeden nieodwrócony kształt.

![Kształt przed odwróceniem](shape_to_be_flipped.png)

Przykład zachowuje wszystkie pozostałe wartości ramki i zmienia wyłącznie dwa ustawienia odbicia. Jest to ważne, ponieważ ustawienie nowego [Frame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setFrame) zastępuje całą ramkę.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zapisany kształt jest odbity poziomo i pionowo, zachowując jednocześnie swoją pozycję, rozmiar i rotację.

![Kształt po odwróceniu](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję [Name](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getName) lub [AlternativeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getAlternativeText) dla szablonów tworzonych ręcznie, lub [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getOfficeInteropShapeId) dla prac interopowych w zakresie slajdu.

**Czy ukrywanie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Można go znaleźć, zmienić kolejność, edytować lub ponownie uczynić widocznym.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

[addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addClone) dołącza klon na koniec kolekcji, co jest frontem kolejności Z. Użyj [insertClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#insertClone), aby wybrać początkowy indeks, lub [reorder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#reorder) po dodaniu wszystkich kształtów.

**Czy mogę używać stałego indeksu do identyfikacji wstępnie ustawionej regulacji kształtu?**

Tylko po zweryfikowaniu dokładnego presetu i układu kolekcji. Preferuj iterację przez [GeometryShape.getAdjustments](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/#getAdjustments) i sprawdzanie [AdjustValue.getType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getType); używaj [AdjustValue.getName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/adjustvalue/#getName) jako dodatkowej informacji, gdy ten sam typ semantyczny pojawia się więcej niż raz.