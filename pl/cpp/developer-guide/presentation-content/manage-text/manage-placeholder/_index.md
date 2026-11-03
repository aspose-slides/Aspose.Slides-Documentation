---
title: Zarządzanie symbolami zastępczymi prezentacji w C++
linktitle: Zarządzaj symbolami zastępczymi
type: docs
weight: 10
url: /pl/cpp/manage-placeholder/
keywords:
- symbol zastępczy
- symbol zastępczy tekstu
- symbol zastępczy obrazu
- symbol zastępczy wykresu
- symbol zastępczy treści
- tekst podpowiedzi
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak przeglądać i edytować symbole zastępcze tekstu, obrazu, wykresu i treści oraz zrozumieć dziedziczenie symboli zastępczych przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Symbol zastępczy jest kształtem, który rezerwuje pozycję dla określonego rodzaju treści w szablonie prezentacji. Typowymi przykładami są symbole zastępcze tytułu, treści, obrazu, wykresu oraz ogólnego przeznaczenia. W przeciwieństwie do zwykłego kształtu, symbol zastępczy może dziedziczyć swoją pozycję, rozmiar, formatowanie i inne ustawienia z slajdu układu lub slajdu głównego.

Aspose.Slides udostępnia informacje o symbolu zastępczym poprzez metodę [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/). Metoda zwraca obiekt [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) lub `nullptr` dla zwykłego kształtu. Użyj [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) aby określić, co symbol zastępczy ma zawierać.

Interfejs kształtu nadal ma znaczenie po poznaniu typu symbolu zastępczego:

- Pusty symbol zastępczy tekstu, obrazu, wykresu lub treści jest zazwyczaj reprezentowany przez [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
- Wypełniony symbol zastępczy obrazu może być reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/).
- Wypełniony symbol zastępczy wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/).
- Symbol zastępczy treści może zawierać kilka rodzajów treści. Sprawdź zarówno [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) jak i interfejs kształtu w czasie wykonywania, zamiast zakładać, że każdy symbol zastępczy jest [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) opisuje rolę symbolu zastępczego; nie gwarantuje on typu kształtu w czasie wykonywania. Zawsze używaj sprawdzania typu przed dostępem do członków specyficznych dla tekstu, obrazu, wykresu, tabeli lub multimediów.
{{% /alert %}}

## **Zrozum dziedziczenie symboli zastępczych**

Symbole zastępcze tworzą hierarchię:

1. Slajd nadrzędny definiuje style wielokrotnego użytku i, w niektórych przypadkach, symbole zastępcze na poziomie nadrzędnym.
2. Slajd układu definiuje układ używany przez jeden lub więcej zwykłych slajdów i może dziedziczyć po slajdzie nadrzędnym.
3. Zwykły slajd zawiera symbole zastępcze dla tego slajdu i może dziedziczyć po jego układzie.

Wywołaj [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/), aby przesunąć się o jeden poziom wyżej w tej hierarchii. Symbol zastępczy slajdu zazwyczaj zwraca swój symbol zastępczy układu; symbol zastępczy układu może zwrócić swój symbol nadrzędny. Metoda zwraca `nullptr`, gdy kształt nie ma podstawowego symbolu zastępczego.

Poniższy przykład wymienia symbole zastępcze na pierwszym slajdzie i raportuje ich podstawowe symbole zastępcze:

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

Edycja symbolu zastępczego na zwykłym slajdzie tworzy lub zmienia lokalne nadpisanie dla tego slajdu. Edycja powiązanego układu lub slajdu nadrzędnego może wpływać na wszystkie slajdy, które nadal dziedziczą to ustawienie. Lokalny zwykły kształt nie ma podstawowego symbolu zastępczego i nie zaczyna dziedziczyć wyłącznie dlatego, że zajmuje te same współrzędne.

## **Usuń status symbolu zastępczego**

Podczas dostosowywania szablonu użyj [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) aby zachować istniejący obiekt jako zwykły kształt. Jego metoda [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) zwraca `nullptr`, ale kształt pozostaje w kolekcji slajdu. Natomiast [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) usuwa kształt z tej kolekcji.

Poniższy przykład wymaga `template.pptx` z co najmniej jednym slajdem i niepustym symbolem zastępczym tekstu na pierwszym slajdzie. Użyj symbolu zastępczego z formatowaniem dziedziczonym z jego układu lub slajdu nadrzędnego, aby zobaczyć efekt usunięcia tej relacji. Przykład sprawdza, że ten sam kształt pozostaje, wywołuje metodę ponownie na teraz zwykłym kształcie i zapisuje wynik.

{{% alert color="warning" title="Warning" %}}
Usunięcie statusu symbolu zastępczego nie zachowuje automatycznie dziedziczonych ustawień wyglądu. Poniższy przykład celowo pozostawia te ustawienia niezmienione, więc wynik może wyglądać inaczej. Kształt, którego pozycja i rozmiar są całkowicie dziedziczone, może po wywołaniu mieć zerowe współrzędne i wymiary i stać się niewidzialny, mimo że pozostaje w kolekcji.
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // Wywołanie metody na zwykłym kształcie nie ma efektu.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

Dla pasującego symbolu zastępczego wszystkie trzy sprawdzenia wypisują `True`. Tekst pozostaje, ale dziedziczona pozycja, rozmiar, obrót, czcionka, wyrównanie akapitu, marginesy ramki tekstu, pionowe zakotwiczenie, wypełnienie i ustawienia linii mogą się zmienić po usunięciu relacji symbolu zastępczego. Na przykład dziedziczone formatowanie tytułu może powrócić do zwykłego formatowania tekstu. Zobacz [Slide Layout](/slides/pl/cpp/slide-layout/) po więcej informacji o układach.

Aby zachować zamierzony wygląd, przed wywołaniem przechwyć wyliczoną pozycję, rozmiar i obrót i skopiuj wymagane wartości efektywnego formatowania do osobnych zmiennych. Pobierz te wartości poprzez [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), oraz [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/). Nie polegaj wyłącznie na obiektach efektywnego formatowania, ponieważ ich wartości formatowania tekstu mogą się zmienić po usunięciu relacji. Zastosuj wyraźnie przechwycone wartości do zwykłego kształtu po zakończeniu, włączając rodzinę czcionki, rozmiar, styl, kolor, ustawienia akapitu, ustawienia ramki tekstu, wypełnienie i linię używaną w szablonie.

Dziedziczoną geometrię kształtu może być również konieczne przypisanie explicite poprzez [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/). Dla prostokątnego symbolu zastępczego tekstu oznacza to przypisanie [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); przywrócenie tylko wypełnienia i linii może nie przywrócić widocznego prostokąta. Szablony z dodatkowymi efektami lub bardziej złożonym formatowaniem wymagają również obsługi tych ustawień.

## **Zmień tekst w symbolu zastępczym**

Symbole zastępcze tytułu, tytułu wyśrodkowanego, podtytułu, treści i tekstu zazwyczaj obsługują tekst. Sprawdź, czy istnieje [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) zanim użyjesz jego metody [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/).

Ten przykład aktualizuje pierwszy symbol zastępczy tytułu na pierwszym slajdzie i zapisuje wynik:

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

Ten wzorzec unika rzutowania symboli zastępczych obrazu, wykresu, tabeli lub multimediów do [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Identyfikuje również symbol zastępczy według przeznaczenia, zamiast polegać na kruchym indeksie kształtu.

## **Ustaw tekst podpowiedzi w układzie**

Tekst podpowiedzi to instrukcja wyświetlana w czasie projektowania w pustym symbolu zastępczym, np. *Kliknij, aby dodać tytuł*. Ustaw niestandardowy tekst podpowiedzi w symbolu zastępczym układu zamiast próbować uzyskać go przez kolekcję kształtów zwykłego slajdu. Dostęp do układu uzyskaj poprzez [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) i iteruj po [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/).

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

Tekst podpowiedzi nie jest normalną treścią slajdu. Jest przeznaczony dla pustych symboli zastępczych w aplikacjach edytujących, takich jak PowerPoint. Gdy użytkownik lub program dostarczy prawdziwą treść, podpowiedź przestaje być wyświetlana. Zmiana podpowiedzi nie zastępuje również istniejącego tekstu na slajdach korzystających z tego układu.

## **Zaktualizuj symbol zastępczy obrazu**

Istnieją dwa przypadki do obsłużenia:

- Jeśli symbol zastępczy obrazu jest już wypełniony i reprezentowany przez [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), zamień obraz poprzez [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) i [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/).
- Jeśli jest nadal pustym symbolem zastępczym, dodaj ramkę obrazu na współrzędnych symbolu zastępczego za pomocą [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) i usuń pusty symbol.

Następny przykład obsługuje oba przypadki i zapisuje prezentację:

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

Zastąpienie utworzone dla pustego symbolu zastępczego jest lokalną ramką obrazu, a nie nowym symbolem zastępczym, ponieważ [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) jest tylko do odczytu. Zachowuje zarezerwowaną pozycję, ale nie dziedziczy już zachowań specyficznych dla symbolu zastępczego. Jeśli utrzymanie relacji symbolu zastępczego jest istotne, najpierw przygotuj i wypełnij symbol w PowerPoint, a potem zaktualizuj powstały [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) za pomocą Aspose.Slides.

Aby uzyskać przezroczystość obrazu, kadrowanie i inne efekty specyficzne dla obrazu, zobacz [Manage Picture Frames](/slides/pl/cpp/picture-frame/). Te operacje należą do ramki obrazu lub wypełnienia obrazu, nie do metadanych symbolu zastępczego.

## **Praca z symbolami zastępczymi wykresów i treści**

Wypełniony symbol zastępczy wykresu może być reprezentowany przez [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/). Ten przykład znajduje taki wykres zarówno po typie symbolu zastępczego, jak i interfejsie w czasie wykonywania, zmienia jego tytuł i zapisuje plik:

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

Ogólny symbol zastępczy treści zwykle ma [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). W PowerPoint działa jako uruchamiacz dla kilku typów treści, w tym wykresów, tabel, diagramów, obrazów i multimediów. Po wypełnieniu, sprawdź rzeczywisty interfejs kształtu, aby dowiedzieć się, co zawiera. Specjalistyczne układy mogą również udostępniać [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), lub [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/).

Aspose.Slides nie konwertuje pustego [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) na [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) jedynie poprzez zmianę [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/); typ jest tylko do odczytu. Aby wypełnić pusty obszar wykresu lub treści programowo, dodaj wymagany obiekt na współrzędnych symbolu zastępczego, a następnie usuń pusty symbol. Następujący przykład robi to dla wykresu:

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

Dodany wykres jest zwykłym lokalnym wykresem. Zajmuje obszar symbolu zastępczego, ale nie dziedziczy po symbolu zastępczym układu. Użyj dedykowanych [chart management articles](/slides/pl/cpp/powerpoint-charts/) gdy potrzebujesz zamienić jego kategorie, serie lub dane skoroszytu.

## **Pełny przykład: aktualizacja treści tekstowej lub obrazowej**

Poniższy przykład od początku do końca otwiera szablon, przeszukuje pierwszy slajd pod kątem symbolu zastępczego tytułu lub obrazu, sprawdza typy symbolu i kształtu, aktualizuje odpowiednią treść i zapisuje wynik. Przykład celowo unika zakładania indeksu kształtu lub rzutowania każdego symbolu zastępczego na ten sam interfejs.

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

**Co to jest podstawowy symbol zastępczy?**

Podstawowy symbol zastępczy to odpowiadający kształt na układzie lub slajdzie nadrzędnym, z którego inny symbol dziedziczy. Użyj [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) aby go pobrać. Zwykły lokalny kształt zwraca `nullptr`, ponieważ nie jest częścią hierarchii symboli zastępczych.

**Czy mogę zmienić wszystkie tytuły slajdów, edytując symbol zastępczy układu?**

Możesz zmienić dziedziczone formatowanie lub tekst podpowiedzi poprzez układ, ale istniejąca treść tytułu jest przechowywana na zwykłych slajdach. Aby zastąpić rzeczywisty tekst tytułu w całej prezentacji, przeiteruj slajdy i zaktualizuj każdy symbol zastępczy tytułu.

**Jak zarządzać symbolami zastępczymi daty, numeru slajdu, nagłówka i stopki?**

Użyj menedżerów nagłówka i stopki w odpowiednim zakresie slajdu, układu, slajdu nadrzędnego, notatek lub materiałów rozdawniczych. Zobacz [Manage Presentation Header and Footer](/slides/pl/cpp/presentation-header-and-footer/) po pełne przykłady.