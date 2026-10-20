---
title: Zmiana rozmiaru kształtów na slajdach prezentacji w Pythonie przez Java
type: docs
weight: 110
url: /pl/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /pl/python-java/re-sizing-shapes-on-slide/
keywords:
- przeskalowanie kształtu
- zmiana rozmiaru kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Łatwo zmień rozmiar kształtów na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona przez Javę — automatyzuj dostosowywanie układu slajdów i zwiększ wydajność."
---
## **Przegląd**

Kiedy zmieniasz rozmiar slajdu prezentacji, może być konieczne przeskalowanie i przemieszczenie jego kształtów, aby pasowały do nowych wymiarów. Ten artykuł pokazuje, jak ręcznie skalować kształty oraz jak obsługiwać tabele na slajdach, szablonach i układach.

## **Zmiana rozmiaru kształtów**

Aby zachować względną pozycję i rozmiar każdego kształtu, pomnóż jego współrzędne poziome oraz szerokość przez stosunek nowej szerokości slajdu do pierwotnej szerokości. Zastosuj odpowiedni stosunek wysokości do jego współrzędnych pionowych oraz wysokości.

Pierwszy przykład ładuje prezentację, której slajdy nie zawierają tabel, zmienia rozmiar slajdu na A4 i zapisuje wynik. Używa [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) z [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) tak, aby kolejna pętla kontrolowała skalowanie. Stosunki są bez wymiarów; pozycje i wymiary kształtów są mierzone w punktach. Różne współczynniki szerokości i wysokości mogą zniekształcać kształty, a zmiana wymiarów kształtu nie skaluje rozmiarów czcionek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Oblicz niezależne współczynniki skalowania w poziomie i w pionie.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Tablice wymagają osobnego przetwarzania: skaluj ich szerokości kolumn i wysokości wierszy zamiast przypisywania całkowitej szerokości i wysokości tabeli. Wysokości wierszy mogą pozostać większe niż żądane, jeśli zawartość komórek wymaga więcej miejsca.
{{% /alert %}}

Drugi przykład obsługuje tabele i przetwarza kształty na szablonach i układach, a także na pojedynczych slajdach, przed zapisaniem przeskalowanej prezentacji. Jego pomocnik obsługuje każdą [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) skalując szerokości kolumn za pomocą [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) oraz minimalne wysokości wierszy za pomocą [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Następnie skaluje pozycję tabeli bez osobnego skalowania jej ogólnych wymiarów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Wymiary tabeli są kontrolowane przez szerokości kolumn i wysokości wierszy.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Oblicz niezależne współczynniki skalowania w poziomie i w pionie.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Zmień rozmiar kształtów zdefiniowanych w szablonach i układach oraz na pojedynczych slajdach.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Jeśli zmienisz rozmiar slajdu bez skalowania kształtów, zachowają one pierwotne pozycje i wymiary i mogą wykraczać poza slajd. Skalowanie szerokości i wysokości różnymi współczynnikami może również zniekształcać kształty.

**Czy dostarczony kod działa dla wszystkich typów kształtów?**

Pierwszy przykład zmienia granice kształtu bezpośrednio i jest przeznaczony dla slajdów bez tabel. Drugi przykład obsługuje tabele osobno. Sprawdź wynikowy układ, szczególnie tekst i tabele, ponieważ te przykłady nie skalują rozmiarów czcionek, a zawartość tabel może ograniczać wysokość wierszy.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Skaluj szerokości kolumn zgodnie ze współczynnikiem szerokości i minimalne wysokości wierszy zgodnie ze współczynnikiem wysokości, a następnie skaluj pozycję tabeli, jak pokazano w drugim przykładzie.

**Czy to skalowanie zadziała dla slajdów master i układów?**

Tak. Drugi przykład iteruje przez [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) oraz [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) każdego szablonu i stosuje tę samą logikę skalowania do ich kształtów.

**Czy mogę zmienić orientację slajdu (pionową/poziomą) wraz ze zmianą rozmiaru?**

Tak. Wywołaj [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) po zmianie rozmiaru slajdu i przed odczytaniem docelowych wymiarów, aby współczynniki skalowania odzwierciedlały ostateczną orientację.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Możesz określić własne wymiary slajdu za pomocą [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Obsługiwane wymiary zależą również od formatu prezentacji oraz aplikacji używanej do otwarcia pliku.

**Jak mogę zapobiec zniekształceniu kształtów o stałym współczynniku proporcji?**

Użyj tego samego współczynnika skalowania dla szerokości i wysokości. Aby dopasować pierwotny układ do nowych wymiarów slajdu, zastosuj mniejszy z współczynników szerokości i wysokości zarówno dla wymiarów, jak i pozycji. Zachowuje to proporcje, ale może pozostawić niewykorzystaną przestrzeń wzdłuż jednej krawędzi.