---
title: Zarządzanie placeholderami prezentacji w C++
linktitle: Zarządzaj placeholderami
type: docs
weight: 10
url: /pl/cpp/manage-placeholder/
keywords:
- symbol zastępczy
- placeholder tekstowy
- placeholder obrazu
- placeholder wykresu
- placeholder zawartości
- tekst podpowiedzi
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować placeholdery tekstowe, obrazkowe, wykresów i zawartości oraz zrozumieć dziedziczenie placeholderów za pomocą Aspose.Slides dla C++."
---
## **Przegląd**

Placeholder to kształt, który rezerwuje pozycję dla określonego rodzaju zawartości w szablonie prezentacji. Typowe przykłady to tytuł, treść, obraz, wykres oraz ogólne placeholdery zawartości. W przeciwieństwie do zwykłego kształtu, placeholder może dziedziczyć pozycję, rozmiar, formatowanie i inne ustawienia ze slajdu układu lub slajdu master.

Aspose.Slides udostępnia informacje o placeholderze poprzez metodę [IShape::get_Placeholder](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_placeholder/). Metoda zwraca obiekt [IPlaceholder](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iplaceholder/) lub `nullptr` dla zwykłego kształtu. Użyj [IPlaceholder::get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iplaceholder/get_type/), aby określić, co placeholder ma zawierać.

Interfejs kształtu nadal ma znaczenie po poznaniu typu placeholdera:

- Pusty placeholder tekstowy, obrazkowy, wykresu lub zawartości jest zwykle reprezentowany przez [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/).
- Wypełniony placeholder obrazu może być reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/).
- Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/).
- Placeholder zawartości może zawierać kilka rodzajów treści. Sprawdzaj zarówno [IPlaceholder::get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iplaceholder/get_type/), jak i interfejs kształtu w czasie wykonywania, zamiast zakładać, że każdy placeholder jest [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Ostrzeżenie" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iplaceholder/get_type/) opisuje rolę placeholdera; nie gwarantuje on typu kształtu w czasie wykonywania. Zawsze wykonuj sprawdzenie typu przed dostępem do członków specyficznych dla tekstu, obrazu, wykresu, tabeli lub multimediów.
{{% /alert %}}

## **Zrozumienie dziedziczenia placeholderów**

Placeholdery tworzą hierarchię:

1. Slajd master definiuje style wielokrotnego użytku i, w niektórych przypadkach, placeholdery na poziomie mastera.
2. Slajd układu określa rozmieszczenie używane przez jeden lub więcej zwykłych slajdów i może dziedziczyć po masterze.
3. Zwykły slajd zawiera placeholdery dla tego slajdu i może dziedziczyć po swoim układzie.

Wywołaj [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/getbaseplaceholder/), aby przejść o jeden poziom wyżej w tej hierarchii. Placeholder slajdu zazwyczaj zwraca swój placeholder układu; placeholder układu może zwrócić swój placeholder mastera. Metoda zwraca `nullptr`, gdy kształt nie ma bazowego placeholdera.

Poniższy przykład wymienia placeholdery na pierwszym slajdzie i raportuje ich bazowe placeholdery:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

Edycja placeholdera na zwykłym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edycja powiązanego układu lub mastera może wpłynąć na wszystkie slajdy, które nadal dziedziczą to ustawienie. Zwykły lokalny kształt nie ma bazowego placeholdera i nie zaczyna dziedziczyć jedynie dlatego, że zajmuje te same współrzędne.

## **Zmienianie tekstu w placeholderze**

Placeholdery tytułu, tytułu wyśrodkowanego, podtytułu, treści i tekstowe zazwyczaj obsługują tekst. Sprawdź, czy kształt jest [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) przed użyciem jego metody [get_TextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/get_textframe/).

Poniższy przykład aktualizuje pierwszy placeholder tytułu na pierwszym slajdzie i zapisuje wynik:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

Ten wzorzec unika rzutowania placeholderów obrazu, wykresu, tabeli lub multimediów na [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/). Identyfikuje również placeholder ze względu na przeznaczenie, zamiast polegać na kruchym indeksie kształtu.

## **Ustawianie tekstu podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w pustym placeholderze w czasie projektowania, np. *Kliknij, aby dodać tytuł*. Ustaw niestandardowy tekst podpowiedzi w placeholderze układu, zamiast próbować uzyskać go przez kolekcję kształtów zwykłego slajdu. Dostęp do układu uzyskaj poprzez [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/get_layoutslide/) i iteruj po [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/get_shapes/).

Poniższy przykład zmienia podpowiedzi tytułu i podtytułu w układzie używanym przez pierwszy slajd:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Tekst podpowiedzi nie jest normalną zawartością slajdu. Jest przeznaczony dla pustych placeholderów w aplikacjach edytorskich, takich jak PowerPoint. Gdy użytkownik lub program dostarczy prawdziwą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje istniejącego tekstu na slajdach korzystających z tego układu.

## **Aktualizacja placeholdera obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli placeholder obrazu jest już wypełniony i reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/), zamień obraz za pomocą [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipicturefillformat/get_picture/) oraz [ISlidesPicture::set_Image](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidespicture/set_image/).
- Jeśli jest to nadal pusty placeholder, dodaj ramkę obrazu w współrzędnych placeholdera przy użyciu [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addpictureframe/) i usuń pusty placeholder.

Kolejny przykład obsługuje oba przypadki i zapisuje prezentację:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

Zastąpienie utworzone dla pustego placeholdera jest lokalną ramką obrazu, a nie nowym placeholderem, ponieważ [IShape::get_Placeholder](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_placeholder/) jest tylko do odczytu. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla placeholdera. Jeśli zachowanie relacji placeholdera jest kluczowe, przygotuj i wypełnij placeholder w PowerPoint najpierw, a potem zaktualizuj powstały [IPictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipictureframe/) przy pomocy Aspose.Slides.

Informacje o przezroczystości obrazu, przycinaniu i innych efektach specyficznych dla obrazu znajdziesz w artykule [Manage Picture Frames](/slides/pl/cpp/picture-frame/). Operacje te dotyczą ramki obrazu lub wypełnienia obrazu, a nie metadanych placeholdera.

## **Praca z placeholderami wykresów i zawartości**

Wypełniony placeholder wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/). Ten przykład znajduje taki wykres zarówno po typie placeholdera, jak i po interfejsie w czasie wykonywania, zmienia jego tytuł i zapisuje plik:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Ogólny placeholder zawartości zwykle ma typ [PlaceholderType::Object](https://reference.aspose.com/slides/pl/cpp/aspose.slides/placeholdertype/). W PowerPoint działa jako uruchamiacz dla kilku typów zawartości, w tym wykresów, tabel, diagramów, obrazów i multimediów. Po jego wypełnieniu należy zbadać rzeczywisty interfejs kształtu, aby dowiedzieć się, co zawiera. Specjalne układy mogą również udostępniać [PlaceholderType::Chart](https://reference.aspose.com/slides/pl/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/pl/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/pl/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/pl/cpp/aspose.slides/placeholdertype/), lub [PlaceholderType::Diagram](https://reference.aspose.com/slides/pl/cpp/aspose.slides/placeholdertype/).

Aspose.Slides nie konwertuje pustego placeholdera [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) w [IChart](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/ichart/) jedynie przez zmianę [IPlaceholder::get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iplaceholder/get_type/); typ jest tylko do odczytu. Aby programowo wypełnić pusty obszar wykresu lub zawartości, dodaj wymagany obiekt w współrzędnych placeholdera, a następnie usuń pusty placeholder. Poniższy przykład robi to dla wykresu:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar placeholdera, ale nie dziedziczy z placeholdera układu. Skorzystaj z dedykowanych artykułów o zarządzaniu wykresami [chart management articles](/slides/pl/cpp/powerpoint-charts/), gdy potrzebujesz zamienić kategorie, serie lub dane z arkusza.

## **Pełny przykład: aktualizacja tekstu lub obrazu**

Poniższy przykład od początku do końca otwiera szablon, przeszukuje pierwszy slajd pod kątem placeholdera tytułu lub obrazu, sprawdza typy placeholdera i kształtu, aktualizuje odpowiednią zawartość i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub rzutowania każdego placeholdera na ten sam interfejs.

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czym jest bazowy placeholder?**

Bazowy placeholder to odpowiadający mu kształt na układzie lub masterze, z którego dziedziczy inny placeholder. Użyj [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/getbaseplaceholder/), aby go pobrać. Zwykły lokalny kształt zwraca `nullptr`, ponieważ nie jest częścią hierarchii placeholderów.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując placeholder układu?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułu jest przechowywana na normalnych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, iteruj po slajdach i zaktualizuj każdy placeholder tytułu.

**Jak zarządzać placeholderami daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakresie: slajd, układ, master, notatki lub wersja drukowana. Zobacz [Manage Presentation Header and Footer](/slides/pl/cpp/presentation-header-and-footer/) po pełne przykłady.