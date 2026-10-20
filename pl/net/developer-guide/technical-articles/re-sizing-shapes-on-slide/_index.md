---
title: Zmiana rozmiaru kształtów na slajdach prezentacji w .NET
type: docs
weight: 130
url: /pl/net/resizing-shapes-on-slide/
aliases:
  - /net/re-sizing-shapes-on-slide/
  - /pl/net/re-sizing-shapes-on-slide/
keywords:
- zmień rozmiar kształtu
- zmiana rozmiaru kształtu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Łatwo zmień rozmiar kształtów na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET — automatyzuj dostosowywanie układu slajdów i zwiększaj wydajność."
---
## **Przegląd**

Kiedy zmieniasz rozmiar slajdu prezentacji, możesz także potrzebować zmienić rozmiar i pozycję jej kształtów, aby dopasować je do nowych wymiarów. Ten artykuł pokazuje, jak ręcznie skalować kształty oraz jak obsługiwać tabele na slajdach, wzorcach i układach.

## **Zmienianie rozmiaru kształtów**

Aby zachować względną pozycję i rozmiar każdego kształtu, pomnóż jego współrzędne poziome oraz szerokość przez stosunek nowej szerokości slajdu do oryginalnej szerokości. Zastosuj odpowiadający stosunek wysokości do jego współrzędnych pionowych oraz wysokości.

Pierwszy przykład wczytuje prezentację, w której slajdy nie zawierają tabel, zmienia rozmiar slajdu na A4 i zapisuje wynik. Używa [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) z [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) tak, aby kolejna pętla kontrolowała skalowanie. Stosunki są bezjednostkowe; pozycje i wymiary kształtów są mierzone w punktach. Różne współczynniki szerokości i wysokości mogą zniekształcać kształty, a zmiana wymiarów kształtu nie skaluje rozmiarów czcionek.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Oblicz niezależne współczynniki skali poziomej i pionowej.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Tabele wymagają oddzielnej obsługi: skaluj ich szerokości kolumn i wysokości wierszy zamiast przypisywać całkowitą szerokość i wysokość tabeli. Wysokości wierszy mogą pozostać większe niż żądane, jeśli zawartość komórek wymaga więcej miejsca.
{{% /alert %}}

Drugi przykład obsługuje tabele i przetwarza kształty na wzorcach i układach, a także na poszczególnych slajdach przed zapisaniem przeskalowanej prezentacji. Jego pomocnik obsługuje każdy [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) skalując [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) i [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Następnie skaluje pozycję tabeli bez oddzielnego skalowania jej całkowitych wymiarów.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Oblicz niezależne współczynniki skali poziomej i pionowej.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Zmień rozmiar kształtów zdefiniowanych w masterach i układach, a także na poszczególnych slajdach.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Wymiary tabeli są kontrolowane przez szerokości kolumn i wysokości wierszy.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub przycięte po zmianie rozmiaru slajdu?**

Jeśli zmienisz rozmiar slajdu bez skalowania kształtów, zachowają one pierwotne pozycje i wymiary i mogą wykraczać poza obszar slajdu. Skalowanie szerokości i wysokości różnymi stosunkami również może zniekształcać kształty.

**Czy podany kod działa dla wszystkich typów kształtów?**

Pierwszy przykład zmienia granice kształtów bezpośrednio i jest przeznaczony dla slajdów bez tabel. Drugi przykład obsługuje tabele osobno. Sprawdź uzyskany układ, szczególnie tekst i tabele, ponieważ przykłady nie skalują rozmiarów czcionek, a zawartość tabel może ograniczać wysokość wierszy.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Skaluj szerokości kolumn według współczynnika szerokości oraz minimalne wysokości wierszy według współczynnika wysokości, a następnie skaluj pozycję tabeli, tak jak pokazano w drugim przykładzie.

**Czy to skalowanie działa dla slajdów wzorcowych i slajdów układu?**

Tak. Drugi przykład iteruje przez [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) oraz [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) każdego wzorca i stosuje tę samą logikę zmiany rozmiaru do ich kształtów.

**Czy mogę zmienić orientację slajdu (pionowa/pozioma) wraz ze zmianą rozmiaru?**

Tak. Ustaw [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) po zmianie rozmiaru slajdu i przed odczytaniem docelowych wymiarów, aby współczynniki skali odzwierciedlały końcową orientację.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Możesz określić własne wymiary slajdu za pomocą [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Obsługiwane wymiary zależą również od formatu prezentacji i aplikacji używanej do otwarcia pliku.

**Jak zapobiec zniekształceniu kształtów o stałym współczynniku proporcji?**

Użyj tego samego współczynnika skali dla szerokości i wysokości. Aby dopasować oryginalny układ do nowych wymiarów slajdu, użyj mniejszego ze współczynników szerokości i wysokości zarówno dla wymiarów, jak i pozycji. Zachowuje to proporcje, ale może pozostawić nieużywaną przestrzeń wzdłuż jednej krawędzi.