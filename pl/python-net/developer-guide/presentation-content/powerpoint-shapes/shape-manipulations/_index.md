---
title: Zarządzanie kształtami w prezentacjach przy użyciu Pythona
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/python-net/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtów
- Pobierz identyfikator Interop Shape
- Alternatywny tekst kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, edytować i optymalizować kształty w Aspose.Slides dla Pythona za pośrednictwem .NET oraz dostarczać wysokowydajnych prezentacji PowerPoint i OpenDocument."
---
## **Przegląd**

Ten przewodnik wprowadza manipulację kształtami w Aspose.Slides dla Pythona za pośrednictwem .NET. Poznaj praktyczne wzorce znajdowania kształtów (w tym według Alternatywnego Tekstu), duplikowania, usuwania lub ukrywania, zmiany kolejności, wyrównywania i odwracania, odczytywania identyfikatorów oraz formatowania opartego na układzie, oraz eksportowania pojedynczych kształtów do SVG przy użyciu interfejsów API [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/).

## **Znajdowanie kształtów na slajdach**

PowerPoint identyfikuje kształty tylko za pomocą wewnętrznych identyfikatorów. Przypisz unikalny Tekst alternatywny do docelowego kształtu w PowerPoint, a następnie otwórz prezentację przy użyciu Aspose.Slides for Python, iteruj po kształtach slajdu i wybierz ten, którego Tekst alternatywny się zgadza. Metoda `find_shape` implementuje to podejście i zwraca pasujący kształt.

```py
import aspose.slides as slides

# Znajduje kształt na slajdzie według jego alternatywnego tekstu.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Znajdź kształt z tekstem alternatywnym "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **Klonowanie kształtów**

Aby sklonować kształty z slajdu źródłowego do nowego slajdu w Aspose.Slides, wykonaj następujące kroki:

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) z pliku źródłowego.  
1. Uzyskaj slajd źródłowy według indeksu oraz jego kolekcję kształtów.  
1. Pobierz pusty układ z slajdu głównego.  
1. Dodaj pusty slajd używając tego układu i pobierz jego kształty.  
1. Sklonuj kształty do docelowego slajdu.  
1. Zapisz prezentację jako PPTX.  

Poniższy przykład kodu klonuje kształty z jednego slajdu do innego.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Zapisz prezentację na dysk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuwanie kształtów**

Aspose.Slides umożliwia usunięcie dowolnego kształtu ze slajdu. Na przykład, aby usunąć kształt z pierwszego slajdu za pomocą jego Alternatywnego Tekstu, wykonaj następujące kroki:

1. Utwórz instancję [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i załaduj plik.  
1. Uzyskaj dostęp do pierwszego slajdu z kolekcji slajdów.  
1. Znajdź kształt według wartości Alternatywnego Tekstu.  
1. Usuń kształt z kolekcji kształtów slajdu.  
1. Zapisz prezentację na dysku w formacie PPTX.  

```py
import aspose.slides as slides

# Znajduje kształt na slajdzie według jego alternatywnego tekstu.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Znajdź kształt z tekstem alternatywnym "User Defined".
    shape = find_shape(slide, "User Defined")
    # Usuń kształt.
    slide.shapes.remove(shape)
    # Zapisz prezentację na dysk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ukrywanie kształtów**

Aspose.Slides umożliwia ukrycie dowolnego kształtu na slajdzie. Na przykład, aby ukryć kształt na pierwszym slajdzie za pomocą jego Alternatywnego Tekstu, wykonaj następujące kroki:

1. Utwórz instancję [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i załaduj plik.  
1. Uzyskaj dostęp do pierwszego slajdu z kolekcji slajdów.  
1. Znajdź kształt według wartości Alternatywnego Tekstu.  
1. Ukryj kształt.  
1. Zapisz prezentację na dysku w formacie PPTX.  

```py
# Znajduje kształt na slajdzie według jego alternatywnego tekstu.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Znajdź kształt z tekstem alternatywnym "User Defined".
    shape = find_shape(slide, "User Defined")
    # Ukryj kształt.
    shape.hidden = True
    # Zapisz prezentację na dysk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmiana kolejności kształtów**

Aspose.Slides pozwala programistom na zmianę kolejności kształtów (zmianę ich kolejności Z). Zmiana kolejności określa, który kształt znajduje się przed innym, a który za nim. Na przykład, aby zmienić kolejność dwóch kształtów na pierwszym slajdzie, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).  
1. Uzyskaj dostęp do pierwszego slajdu.  
1. Dodaj pierwszy kształt (na przykład prostokąt).  
1. Dodaj drugi kształt (na przykład trójkąt).  
1. Zmień kolejność kształtów, przenosząc drugi kształt na pierwszą pozycję w kolekcji.  
1. Zapisz prezentację na dysk.  

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Dodaj dwa kształty do slajdu.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Przenieś drugi kształt na pierwszą pozycję.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobranie identyfikatora Interop Shape**

Aspose.Slides umożliwia uzyskanie unikalnego identyfikatora kształtu w zakresie slajdu, w przeciwieństwie do właściwości `unique_id`, która jest unikalna dla całej prezentacji. Właściwość `office_interop_shape_id` jest dostępna w klasie [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/). Jej wartość odpowiada `Id` obiektu `Microsoft.Office.Interop.PowerPoint.Shape`. Przykładowy fragment kodu przedstawiono poniżej.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Uzyskaj unikalny identyfikator kształtu w obrębie slajdu.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **Ustawienie alternatywnego tekstu dla kształtów**

Aspose.Slides pozwala programistom ustawiać alternatywny tekst dla dowolnego kształtu. Alternatywny tekst można używać do identyfikacji i lokalizacji kształtów w prezentacji. Właśćność alternatywnego tekstu może być odczytywana i zapisywana zarówno przez Aspose.Slides, jak i Microsoft PowerPoint. Oznaczając kształty tą właściwością, można później usuwać, ukrywać lub zmieniać ich kolejność na slajdzie.

Aby ustawić alternatywny tekst kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).  
1. Uzyskaj dostęp do pierwszego slajdu.  
1. Dodaj kształt do slajdu.  
1. Ustaw alternatywny tekst.  
1. Zapisz prezentację na dysku.  

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Dodaj kształt.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Ustaw alternatywny tekst dla kształtu.
    shape.alternative_text = "User Defined"
    # Zapisz prezentację na dysk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do formatów układu dla kształtów**

Aspose.Slides udostępnia prosty interfejs API do uzyskiwania formatów układu dla kształtów. Ta sekcja pokazuje, jak uzyskać dostęp do formatów układu.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **Renderowanie kształtów jako SVG**

Aspose.Slides obsługuje renderowanie kształtów jako SVG. Metoda `write_as_svg` (oraz jej przeciążenia) w klasie [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) umożliwia zapisanie zawartości kształtu jako obrazu SVG. Poniższy fragment kodu pokazuje, jak wyeksportować kształt do pliku SVG.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Pobierz pierwszy kształt na pierwszym slajdzie.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **Wyrównywanie kształtu**

Używając metody `align_shape` w klasie [SlidesUtil](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/), możesz:
* Wyrównać kształty względem marginesów slajdu (zobacz Przykład 1).  
* Wyrównać kształty względem siebie (zobacz Przykład 2).  

Wyliczenie [ShapesAlignmentType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapesalignmenttype/) definiuje dostępne opcje wyrównywania.

**Przykład 1**

Ten kod w Pythonie pokazuje, jak wyrównać kształty o indeksach 1, 2 i 4 do górnej krawędzi slajdu:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**Przykład 2**

Ten przykład w Pythonie pokazuje, jak wyrównać wszystkie kształty w kolekcji względem najniższego kształtu w tej kolekcji:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **Właściwości odbicia**

W Aspose.Slides klasa [ShapeFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapeframe/) zapewnia kontrolę nad poziomym i pionowym odbiciem kształtów za pomocą właściwości `flip_h` i `flip_v`. Obie właściwości są typu [NullableBool](https://reference.aspose.com/slides/pl/python-net/aspose.slides/nullablebool/), umożliwiając wartości `TRUE` wskazujące na odbicie, `FALSE` oznaczające brak odbicia lub `NOT_DEFINED` do użycia domyślnego zachowania. Wartości te są dostępne z [Frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/frame/) kształtu.

Aby zmodyfikować ustawienia odbicia, tworzona jest nowa instancja [ShapeFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapeframe/) z aktualną pozycją i rozmiarem kształtu, żądanymi wartościami `flip_h` i `flip_v` oraz kątem obrotu. Przypisanie tej instancji do [Frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/frame/) kształtu i zapisanie prezentacji stosuje transformacje odbicia i zapisuje je w pliku wyjściowym.

Załóżmy, że mamy plik sample.pptx, w którym pierwszy slajd zawiera pojedynczy kształt z domyślnymi ustawieniami odbicia, jak pokazano poniżej.

![Kształt do odbicia](shape_to_be_flipped.png)

Poniższy przykład kodu pobiera bieżące właściwości odbicia kształtu i odbija go zarówno poziomo, jak i pionowo.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Pobierz właściwość odbicia poziomego kształtu.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Pobierz właściwość odbicia pionowego kształtu.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Odbij w poziomie i w pionie.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Odbity kształt](flipped_shape.png)

## **FAQ**

**Czy mogę łączyć kształty (union/intersect/subtract) na slajdzie jak w edytorze desktopowym?**

Nie ma wbudowanego interfejsu API operacji Boolowskich. Możesz przybliżyć to, tworząc własny kontur — np. obliczyć wynikową geometrię (przy użyciu [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/)) i utworzyć nowy kształt z tym obrysem, opcjonalnie usuwając oryginały.

**Jak mogę kontrolować kolejność nakładania (z-order), aby kształt zawsze pozostawał „na wierzchu”?**

Zmień kolejność wstawiania/przenoszenia w kolekcji [shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/shapes/) slajdu. Aby uzyskać przewidywalne wyniki, sfinalizuj kolejność Z po wszystkich pozostałych modyfikacjach slajdu.

**Czy mogę „zablokować” kształt, aby uniemożliwić użytkownikom jego edycję w PowerPoint?**

Tak. Ustaw [flagi ochrony na poziomie kształtu](/slides/pl/python-net/applying-protection-to-presentation/) (np. blokada zaznaczania, przemieszczania, zmiany rozmiaru, edycji tekstu). W razie potrzeby zastosuj te same ograniczenia w masterze lub układzie. Należy zauważyć, że jest to ochrona na poziomie interfejsu użytkownika, a nie funkcja bezpieczeństwa; dla silniejszej ochrony, połącz to z ograniczeniami na poziomie pliku, takimi jak [zalecenia tylko do odczytu lub hasła](/slides/pl/python-net/password-protected-presentation/).