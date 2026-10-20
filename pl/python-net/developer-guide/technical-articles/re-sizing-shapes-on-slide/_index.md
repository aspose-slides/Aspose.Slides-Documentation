---
title: Zmiana rozmiaru kształtów na slajdach prezentacji w Pythonie
type: docs
weight: 130
url: /pl/python-net/resizing-shapes-on-slide/
aliases:
  - /pl/python-net/re-sizing-shapes-on-slide/
  /python-net/re-sizing-shapes-on-slide/
keywords:
- zmień kształt
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Łatwo zmień rozmiar kształtów na slajdach PowerPoint i OpenDocument za pomocą Aspose.Slides dla Pythona poprzez .NET — automatyzuj dostosowywanie układu slajdów i zwiększ produktywność."
---
## **Przegląd**

Kiedy zmieniasz rozmiar slajdu prezentacji, możesz również potrzebować zmienić rozmiar i pozycję jej kształtów, aby dopasować je do nowych wymiarów. Ten artykuł pokazuje, jak ręcznie skalować kształty i jak obsługiwać tabele na slajdach, szablonach i układach.

## **Zmienianie rozmiaru kształtów**

Aby zachować względną pozycję i rozmiar każdego kształtu, pomnóż jego współrzędne poziome i szerokość przez stosunek nowej szerokości slajdu do pierwotnej szerokości. Zastosuj odpowiedni stosunek wysokości do jego współrzędnych pionowych i wysokości.

Pierwszy przykład ładuje prezentację, której slajdy nie zawierają tabel, zmienia rozmiar slajdu na A4 i zapisuje wynik. Używa [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) z [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) tak, aby kolejna pętla kontrolowała skalowanie. Stosunki są bezjednostkowe; pozycje i wymiary kształtów są mierzone w punktach. Różne stosunki szerokości i wysokości mogą zniekształcać kształty, a zmiana wymiarów kształtu nie skaluje rozmiarów czcionki.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Oblicz niezależne czynniki skali poziomej i pionowej.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Tabele wymagają osobnej obsługi: skaluj ich szerokości kolumn i wysokości wierszy zamiast przypisywać całkowitą szerokość i wysokość tabeli. Wysokości wierszy mogą pozostać większe niż żądane, jeśli zawartość komórki wymaga więcej miejsca.
{{% /alert %}}

Drugi przykład obsługuje tabele i przetwarza kształty na szablonach i układach, a także na poszczególnych slajdach, przed zapisaniem zmienionej prezentacji. Jego pomocnik obsługuje każdą [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) skalując [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) i [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Następnie skaluje pozycję tabeli bez osobnego skalowania jej całkowitych wymiarów.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Wymiary tabeli są kontrolowane przez szerokości kolumn i wysokości wierszy.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Oblicz niezależne czynniki skali poziomej i pionowej.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Zmień rozmiar kształtów zdefiniowanych na szablonach i układach, a także na poszczególnych slajdach.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Jeśli zmienisz rozmiar slajdu bez skalowania kształtów, zachowują one pierwotne pozycje i wymiary i mogą wystawać poza slajd. Skalowanie szerokości i wysokości przy różnych współczynnikach może również zniekształcać kształty.

**Czy dostarczony kod działa dla wszystkich typów kształtów?**

Pierwszy przykład zmienia granice kształtu bezpośrednio i jest przeznaczony dla slajdów bez tabel. Drugi przykład obsługuje tabele osobno. Sprawdź wynikowy układ, szczególnie tekst i tabele, ponieważ te przykłady nie skalują rozmiarów czcionek, a zawartość tabel może ograniczać wysokość wierszy.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Skaluj szerokości kolumn przy użyciu współczynnika szerokości i minimalne wysokości wierszy przy użyciu współczynnika wysokości, a następnie skaluj pozycję tabeli, jak pokazano w drugim przykładzie.

**Czy to skalowanie działa również dla slajdów szablonów i układów?**

Tak. Drugi przykład iteruje przez [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) i [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) każdego szablonu i stosuje tę samą logikę zmiany rozmiaru do ich kształtów.

**Czy mogę zmienić orientację slajdu (pionową/poziomą) wraz ze zmianą rozmiaru?**

Tak. Ustaw [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) po zmianie rozmiaru slajdu i przed odczytaniem docelowych wymiarów, aby współczynniki skalowania odzwierciedlały ostateczną orientację.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Możesz określić niestandardowe wymiary slajdu przy użyciu [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Obsługiwane wymiary zależą również od formatu prezentacji i aplikacji używanej do otwarcia pliku.

**Jak zapobiec zniekształceniu kształtów o stałym stosunku boków?**

Użyj tego samego współczynnika skalowania dla szerokości i wysokości. Aby dopasować pierwotny układ do nowych wymiarów slajdu, użyj mniejszego ze współczynników szerokości i wysokości dla obu wymiarów i pozycji. To zachowuje proporcje, ale może pozostawić niewykorzystaną przestrzeń wzdłuż jednej krawędzi.