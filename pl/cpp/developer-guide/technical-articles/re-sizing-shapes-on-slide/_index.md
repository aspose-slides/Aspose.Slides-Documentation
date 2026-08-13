---
title: Zmienianie rozmiaru kształtów na slajdach prezentacji
type: docs
weight: 100
url: /pl/cpp/re-sizing-shapes-on-slide/
keywords:
- zmień rozmiar kształtu
- zmiana rozmiaru kształtu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Łatwo zmieniaj rozmiar kształtów na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++ — automatyzuj dostosowywanie układu slajdów i zwiększ wydajność."
---
## **Omówienie**

Jednym z najczęściej zadawanych pytań przez klientów Aspose.Slides for C++ jest to, jak zmienić rozmiar kształtów, aby po zmianie rozmiaru slajdu dane nie były obcięte. Ten krótki artykuł techniczny pokazuje, jak to zrobić.

## **Zmiana rozmiaru kształtów**

Aby zapobiec nieprawidłowemu wyrównaniu kształtów po zmianie rozmiaru slajdu, zaktualizuj pozycję i wymiary każdego kształtu, aby odpowiadały nowemu układowi slajdu.

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

// Wczytaj plik prezentacji.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Pobierz oryginalny rozmiar slajdu.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Zmień rozmiar slajdu bez skalowania istniejących kształtów.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Pobierz nowy rozmiar slajdu.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Zmień rozmiar i pozycję kształtów na każdym slajdzie.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skaluj rozmiar kształtu.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skaluj położenie kształtu.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Jeśli slajd zawiera tabelę, powyższy kod nie będzie działał prawidłowo. W takim przypadku każda komórka w tabeli musi być zmieniona rozmiarem.
{{% /alert %}} 

Użyj poniższego kodu po swojej stronie, aby zmienić rozmiar slajdów zawierających tabele. Dla tabel, ustawianie szerokości lub wysokości jest przypadkiem szczególnym: musisz dostosować wysokości poszczególnych wierszy i szerokości kolumn, aby zmienić ogólny rozmiar tabeli.

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Pobierz oryginalny rozmiar slajdu.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Zmień rozmiar slajdu bez skalowania istniejących kształtów.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Pobierz nowy rozmiar slajdu.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Skaluj rozmiar kształtu.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skaluj położenie kształtu.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Skaluj rozmiar kształtu.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Skaluj położenie kształtu.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skaluj rozmiar kształtu.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skaluj położenie kształtu.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

### Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?

Podczas zmiany rozmiaru slajdu kształty zachowują swoją pierwotną pozycję i rozmiar, chyba że skala zostanie wyraźnie zmieniona. Może to spowodować przycięcie treści lub nieprawidłowe wyrównanie kształtów.

### Czy dostarczony kod działa dla wszystkich typów kształtów?

Podstawowy przykład działa dla większości typów kształtów (pola tekstowe, obrazy, wykresy itp.). Jednak w przypadku tabel trzeba obsłużyć wiersze i kolumny osobno, ponieważ wysokość i szerokość tabeli zależą od wymiarów poszczególnych komórek.

### Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?

Należy przejść przez wszystkie wiersze i kolumny tabeli oraz proporcjonalnie zmienić ich wysokość i szerokość, jak pokazano w drugim przykładzie kodu.

### Czy to skalowanie działa dla slajdów nadrzędnych i slajdów układu?

Tak, ale należy również przejść przez [Masters](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_masters/) i [Layout slides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_layoutslides/) oraz zastosować tę samą logikę skalowania do ich kształtów, aby zapewnić spójność w całej prezentacji.

### Czy mogę zmienić orientację slajdu (portret/pejzaż) wraz ze zmianą rozmiaru?

Tak. Możesz użyć [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidesize/set_orientation/) aby zmienić orientację. Upewnij się, że dostosujesz logikę skalowania, aby zachować układ.

### Czy istnieje limit rozmiaru slajdu, który mogę ustawić?

Aspose.Slides obsługuje rozmiary niestandardowe, ale bardzo duże rozmiary mogą wpływać na wydajność lub kompatybilność z niektórymi wersjami PowerPointa.

### Jak mogę zapobiec zniekształceniu kształtów o stałym współczynniku proporcji?

Możesz sprawdzić metodę `get_AspectRatioLocked` kształtu przed skalowaniem. Jeśli jest zablokowana, dostosuj szerokość lub wysokość proporcjonalnie, zamiast skalować je indywidualnie.