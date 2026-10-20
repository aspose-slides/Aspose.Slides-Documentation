---
title: Zmiana rozmiaru kształtów na slajdach prezentacji w C++
type: docs
weight: 130
url: /pl/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /pl/cpp/re-sizing-shapes-on-slide/
keywords:
- zmiana rozmiaru kształtu
- zmiana rozmiaru kształtu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Łatwo zmień rozmiar kształtów na slajdach PowerPoint i OpenDocument za pomocą Aspose.Slides dla C++ — automatyzuj dostosowywanie układu slajdów i zwiększaj wydajność."
---
## **Przegląd**

Kiedy zmieniasz rozmiar slajdu w prezentacji, może być konieczne również zmienienie rozmiaru i przemieszczenie jego kształtów, aby pasowały do nowych wymiarów. Ten artykuł pokazuje, jak ręcznie skalować kształty oraz jak obsługiwać tabele na slajdach, szablonach i układach.

## **Zmienianie rozmiaru kształtów**

Aby zachować względną pozycję i rozmiar każdego kształtu, pomnóż jego współrzędne poziome i szerokość przez stosunek nowej szerokości slajdu do pierwotnej szerokości. Zastosuj odpowiedni stosunek wysokości do jego współrzędnych pionowych i wysokości.

Pierwszy przykład ładuje prezentację, w której slajdy nie zawierają tabel, zmienia rozmiar slajdu na A4 i zapisuje wynik. Używa [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) z [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/), aby pętla kontrolowała skalowanie. Stosunki są bezjednostkowe; pozycje i wymiary kształtów są mierzone w punktach. Różne współczynniki szerokości i wysokości mogą zniekształcać kształty, a zmiana wymiarów kształtu nie skaluje rozmiarów czcionek.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
{{% alert color="info" title="Uwaga" %}}
Tabele wymagają osobnego podejścia: skaluj ich szerokości kolumn i wysokości wierszy zamiast przypisywać ogólną szerokość i wysokość tabeli. Wysokości wierszy mogą pozostać większe niż żądane, jeśli zawartość komórek wymaga więcej miejsca.
{{% /alert %}}

Drugi przykład obsługuje tabele i przetwarza kształty na szablonach i układach, a także na poszczególnych slajdach, przed zapisaniem przeskalowanej prezentacji. Jego pomocnik obsługuje każdy [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) poprzez skalowanie [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) i [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). Następnie skaluje pozycję tabeli bez osobnego skalowania jej całkowitych wymiarów.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Oblicz niezależne współczynniki skalowania w poziomie i pionie.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // Wymiary tabeli są kontrolowane przez szerokości kolumn i wysokości wierszy.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// Zmień rozmiar kształtów zdefiniowanych w szablonach głównych i układach oraz na pojedynczych slajdach.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Jeśli zmienisz rozmiar slajdu bez skalowania kształtów, zachowają one pierwotne pozycje i wymiary i mogą wyjść poza obszar slajdu. Skalowanie szerokości i wysokości przy różnych współczynnikach może również zniekształcić kształty.

**Czy dostarczony kod działa dla wszystkich typów kształtów?**

Pierwszy przykład zmienia granice kształtu bezpośrednio i jest przeznaczony dla slajdów bez tabel. Drugi przykład obsługuje tabele osobno. Sprawdź otrzymany układ, szczególnie tekst i tabele, ponieważ te przykłady nie skalują rozmiarów czcionek, a zawartość tabeli może ograniczać wysokość wierszy.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Skaluj szerokości kolumn według współczynnika szerokości i minimalne wysokości wierszy według współczynnika wysokości, a następnie skaluj pozycję tabeli, jak pokazano w drugim przykładzie.

**Czy to skalowanie działa dla slajdów szablonów i układów?**

Tak. Drugi przykład iteruje przez [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) i każdy szablon [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) i stosuje tę samą logikę zmiany rozmiaru do ich kształtów.

**Czy mogę zmienić orientację slajdu (pionowa/pozioma) razem z zmianą rozmiaru?**

Tak. Ustaw [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) po zmianie rozmiaru slajdu i przed odczytaniem docelowych wymiarów, aby czynniki skalowania odzwierciedlały ostateczną orientację.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Możesz określić własne wymiary slajdu przy użyciu [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). Obsługiwane wymiary zależą również od formatu prezentacji i aplikacji używanej do otwarcia pliku.

**Jak mogę zapobiec zniekształceniu kształtów o stałym współczynniku proporcji?**

Użyj tego samego współczynnika skalowania dla szerokości i wysokości. Aby dopasować oryginalny układ do nowych wymiarów slajdu, użyj mniejszego ze współczynników szerokości i wysokości zarówno dla wymiarów, jak i pozycji. To zachowuje proporcje, ale może pozostawić niewykorzystaną przestrzeń wzdłuż jednej krawędzi.