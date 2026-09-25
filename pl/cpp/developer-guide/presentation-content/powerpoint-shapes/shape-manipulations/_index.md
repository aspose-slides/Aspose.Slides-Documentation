---
title: Zarządzanie kształtami prezentacji w C++
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/cpp/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtu
- Pobierz interopowy ID kształtu
- Alternatywny tekst kształtu
- Punkt dopasowania kształtu
- Dopasowanie kształtu presetu
- Geometria kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Odwróć kształt
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, dostosowywać, klonować, usuwać, ukrywać, przestawiać, eksportować, wyrównywać i odwracać kształty prezentacji przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Aspose.Slides for C++ reprezentuje kształty na slajdzie jako uporządkowaną [IShapeCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/). Kolekcja jest zarówno miejscem, w którym znajdujesz i modyfikujesz kształty, jak i źródłem ich kolejności układania: indeks `0` to najbardziej tylny kształt, a ostatni indeks to najbardziej przedni kształt.

Ten artykuł podąża za tym modelem. Najpierw wyjaśnia, jak wiarygodnie zidentyfikować kształt i zmodyfikować wstępne punkty dopasowania, a następnie pokazuje, jak klonować, usuwać, ukrywać i przestawiać kształty. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport SVG, wyrównywanie i ustawienia odwrócenia. Każdy przykład jest niezależny, więc możesz używać tylko operacji, które są potrzebne w twoim przepływie pracy.

## **Identyfikowanie i znajdowanie kształtów**

Indeksy kolekcji są wygodne przy przetwarzaniu znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub przestawienie kształtu może zmienić jego indeks. Wybierz identyfikator zgodnie z tym, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_name/) jest przydatny dla szablonów kontrolowanych przez dewelopera i łatwy do sprawdzenia w panelu wyboru programu PowerPoint. Nazwy można edytować i nie są gwarantowane jako unikalne, więc ustanów konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_alternativetext/) jest przydatny, gdy opis dostępności lub etykieta dostarczona przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisany pod kątem dostępności i nie jest gwarantowany jako unikalny. Nie przekształcaj cichej istotnej treści dostępności w klucz bazy danych.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_officeinteropshapeid/) jest identyfikatorem tylko do odczytu, unikalnym w obrębie slajdu i odpowiadającemu identyfikatorowi kształtu używanemu przez interop PowerPoint. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz niejednoznacznego odwołania podczas życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana właściwość [UniqueId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_uniqueid/) ma zakres prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie należy jej traktować jako stałego zewnętrznego klucza. Jeśli długoterminowa tożsamość jest istotna, zachowaj mapowanie w danych aplikacji i zweryfikuj, czy oczekiwany kształt nadal istnieje.

Dla praktycznego przykładu odczytu i aktualizacji zarówno tytułu, jak i opisu tekstu alternatywnego, zobacz [Manage Alternative Text Titles and Descriptions](/slides/pl/cpp/presentation-accessibility/). Używaj tekstu alternatywnego, aby wyjaśnić znaczenie wizualizacji czytelnikom i trzymaj go oddzielnie od nazw kształtów używanych przez kod do ich znajdowania.

Poniższy przykład wyszukuje po `Name` i raportuje interopowy identyfikator w kontekście slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Gdy operacja jest specyficzna dla typu kształtu, sprawdź interfejs przed użyciem członków specyficznych dla typu. Ten przykład aktualizuje tekst i tekst alternatywny tylko wtedy, gdy nazwany obiekt jest [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Identyfikowanie i modyfikowanie wstępnych dopasowań kształtu**

Kształty o predefiniowanej geometrii mogą udostępniać punkty dopasowania, które sterują takimi cechami jak rozmiar narożników, proporcje strzałki czy kąty łuku. Dostęp do nich uzyskuje się przez kolekcję tylko do odczytu [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igeometryshape/get_adjustments/). Sama kolekcja jest dostarczana przez kształt, ale każdy [IAdjustValue](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iadjustvalue/) zawiera wartość, którą można zmienić.

Nie opieraj się wyłącznie na stałym indeksie kolekcji. Iteruj przez dopasowania i sprawdzaj tylko do odczytu właściwość [IAdjustValue::get_Type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iadjustvalue/get_type/), której wartość [ShapeAdjustmentType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapeadjustmenttype/) opisuje, co dopasowanie kontroluje. Właściwość tylko do odczytu [IAdjustValue::get_Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iadjustvalue/get_name/) dostarcza dodatkowych informacji identyfikacyjnych i jest szczególnie przydatna, gdy preset zawiera więcej niż jedno dopasowanie tego samego semantycznego typu.

Użyj właściwości wartości, która odpowiada znaczeniu dopasowania:

| Typ dopasowania | Cel | Wartość do zmiany |
|---|---|---|
| `CornerSize` | Rozmiar zaokrąglonych rogów | [RawValue](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Grubość ogona strzały | `RawValue` |
| `ArrowheadLength` | Długość zakończenia strzały | `RawValue` |
| `ArrowheadWidth` | Szerokość zakończenia strzały | `RawValue` |
| `StartAngle` | Kąt początkowy wycinka lub łuku | [AngleValue](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Kąt końcowy wycinka lub łuku | `AngleValue` |

`Type` i `Name` nie mogą być przypisane. `RawValue` jest liczbą całkowitą do odczytu/zapisu w jednostkach natywnej geometrii presetu, natomiast `AngleValue` jest liczbą do odczytu/zapisu wyrażoną w stopniach. Liczba, kolejność, znaczenie i dopuszczalny zakres dopasowań zależą od presetu [ShapeType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/igeometryshape/get_shapetype/). Wartość ważna dla jednego presetu może być nieprawidłowa lub mieć inny efekt dla innego.

Gdy `Type` ma wartość `ShapeAdjustmentType::Custom`, API nie rozpoznaje standardowego znaczenia semantycznego. Sprawdź `Name`, typ presetu i istniejącą wartość oraz pozostaw dopasowanie niezmienione, chyba że znane jest oczekiwane znaczenie i zakres. Nawet dla rozpoznanych typów sprawdzaj, czy ten sam typ występuje więcej niż raz przed wybraniem wartości. Artykuł [Connector](/slides/pl/cpp/connector/) pokazuje tę sytuację przy dopasowaniach zgięcia łącznika.

Poniższy kompletny przykład tworzy domyślne i zmodyfikowane wersje trzech presetów kształtów. Iteruje przez każde dopasowanie, raportuje jego `Name` i `Type`, zmienia wartości związane z rozmiarem przez `RawValue`, zmienia kąty przez `AngleValue` i zapisuje wynik. Lewa kolumna zachowuje domyślną geometrię; prawa kolumna pokazuje dostosowany zaokrąglony prostokąt, czterokierunkową strzałkę i wycinek.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Dodaje nagłówki dla kolumny domyślnej i zmodyfikowanej geometrii kształtu.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sprawdzanie typu semantycznego przed zmianą wartości sprawia, że kod jest jednoznaczny co do zamiaru i unika założeń, że konkretny indeks kolekcji ma to samo znaczenie w różnych presetach kształtów.

## **Modyfikowanie kolekcji kształtów**

Metody dodawania, klonowania, usuwania i przestawiania działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach zebranych przed tą operacją.

### **Klonowanie kształtu**

[AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addclone/) tworzy niezależną kopię i dołącza ją do docelowej kolekcji. [InsertClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/insertclone/) również tworzy kopię, ale umieszcza ją pod wskazanym indeksem kolejności Z. Przeciążenia przyjmujące współrzędne przesuwają klon bez zmiany jego rozmiaru; przeciążenia z szerokością i wysokością mogą go również przeskalować.

Przykład tworzy docelowy slajd, klonuje prostokąt z etykietą na wierzch oraz wstawia drugi klon z tyłu. Zmiany w dowolnym klonie nie modyfikują kształtu źródłowego.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę i tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty obsługuje prezentacja, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[Remove](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/remove/) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w trakcie iteracji po indeksach, przechodź od końca, aby każdy pozostały indeks pozostał prawidłowy.

Ten przykład usuwa każdy kształt o określonej nazwie. Odczytuje aktualny indeksowany kształt, a nie stały element kolekcji, i nie rzutuje niepotrzebnie kształtu.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Po usunięciu liczba kształtów i indeksy późniejszych kształtów ulegają zmianie. Odniesienia do niezmienionych kształtów pozostają bardziej niezawodne niż zapisane indeksy. Należy także uwzględnić łączniki, animacje i inne elementy prezentacji, które mogą odnosić się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Hidden](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/set_hidden/) na `true` pozostawia kształt w kolekcji, ale zapobiega jego wyświetleniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne dla kodu, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą zostać przywrócone później.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ukrywanie nie jest usunięciem ani zabezpieczeniem. Obiekt nadal może być odkryty i ponownie odsłonięty przez użytkownika lub kod i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z**

Kształty nakładają się w kolejności kolekcji. [Reorder](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/reorder/) przenosi istniejący kształt do docelowego indeksu bez klonowania. Indeks `0` to tył; `Count - 1` to przód.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Prostokąt jest tworzony jako pierwszy i początkowo znajduje się za elipsą. Przeniesienie go na ostatni indeks umieszcza go z przodu. Finalizuj kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dołączają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną kolejkę.

## **Inspekcja kształtów na slajdach układu**

Normalne slajdy, slajdy układu i slajdy nadrzędne mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem, co podobnie pozycjonowany kształt na normalnym slajdzie. Badanie kształtów układu jest konieczne, gdy chcesz zrozumieć lub zmienić formatowanie dostarczane przez układ.

Poniższy przykład odczytuje każdy [FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_fillformat/) i [LineFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_lineformat/) kształtu układu, nie zakładając, że każdy kształt jest `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Edycja układu może wpłynąć na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy normalny slajd dziedziczy obiekt lub zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksportowanie kształtu do SVG**

[WriteAsSvg](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/writeassvg/) zapisuje renderowaną zawartość jednego kształtu do strumienia. Wynik zawiera tylko kształt, nie cały tło slajdu ani sąsiadujące kształty.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Utrzymuj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd, a nie pojedynczy kształt. Wywołujący właściciel strumienia musi go zamknąć lub zwolnić.

## **Wyrównywanie kształtów**

Przeciążenia [SlideUtil::AlignShapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/slideutil/alignshapes/) wyrównują wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb dystrybucji. Ustaw `alignToSlide` na `true`, aby używać krawędzi slajdu; ustaw na `false`, aby wyrównać wybrane kształty względem siebie.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrócone referencje do kształtów są konwertowane na ich aktualne indeksy natychmiast przed wyrównaniem.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wyrównywanie zmienia pozycje, nie kolejność Z. Wyrównywanie względne zwykle wymaga przynajmniej dwóch kształtów, podczas gdy dystrybucja pozioma lub pionowa wymaga wystarczającej liczby kształtów, aby określić odstępy. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odwrócenie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odwrócenia poziomego i pionowego oraz obrót. Jej wartości `FlipH` i `FlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/cpp/aspose.slides/nullablebool/): `True` włącza odwrócenie, `False` wyłącza, a `NotDefined` zachowuje nieokreślony/ustawiony domyślnie stan.

Prezentacja wejściowa poniżej zawiera jeden nieodwrócony kształt.

![Kształt przed odwróceniem](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zastępuje tylko dwa ustawienia odwrócenia. To ważne, ponieważ przypisanie nowego [Frame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/set_frame/) zastępuje całą ramkę.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Zapisany kształt jest odbity poziomo i pionowo, zachowując pozycję, rozmiar i obrót.

![Kształt po odwróceniu](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, kiedy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `Name` lub `AlternativeText` dla tworzonych szablonów albo `OfficeInteropShapeId` dla pracy z interopem slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być odnaleziony, przestawiony, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`AddClone` dołącza klon na koniec kolekcji, co jest przodem kolejności Z. Użyj `InsertClone`, aby wybrać początkowy indeks, lub `Reorder` po dodaniu wszystkich kształtów.

**Czy mogę używać stałego indeksu do identyfikacji wstępnego dopasowania kształtu?**

Tylko po zweryfikowaniu dokładnego presetu i układu kolekcji. Preferuj iterację przez `IGeometryShape::get_Adjustments` i sprawdzanie `IAdjustValue::get_Type`; używaj `IAdjustValue::get_Name` jako dodatkowej informacji, gdy ten sam typ semantyczny pojawia się wielokrotnie.