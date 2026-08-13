---
title: Pobierz efektywne właściwości kształtu z prezentacji w C++
linktitle: Efektywne właściwości
type: docs
weight: 50
url: /pl/cpp/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- układ oświetlenia
- kształt fazowania
- ramka tekstu
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides dla C++, aby rozróżniać lokalne, dziedziczone i efektywne formatowanie kształtów w prezentacjach PowerPoint."
---
## **Zrozumienie lokalnych, dziedziczonych i efektywnych właściwości**

Formatowanie w PowerPoint może pochodzić z kilku miejsc. Wartość przechowywana bezpośrednio na obiekcie jest jego **wartością lokalną**. Jeśli ta wartość nie jest ustawiona, PowerPoint sprawdza źródła formatowania nadrzędnego, takie jak domyślne ustawienia akapitu, styl tekstu, układ lub slajd nadrzędny, motyw lub domyślne ustawienia na poziomie prezentacji. Te wartości są **wartościami dziedziczonymi**. Wartość, która pozostaje po rozwiązaniu całej hierarchii, jest **wartością efektywną** — wartością używaną do renderowania obiektu.

Na przykład fragment tekstu może nie definiować własnej wysokości czcionki. Jego lokalna [wysokość czcionki](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseportionformat/) jest wtedy `std::numeric_limits<float>::quiet_NaN()`, co oznacza „nie ustawiono tutaj”. Fragment może dziedziczyć wysokość z akapitu, domyślnego stylu tekstu prezentacji lub innego odpowiedniego źródła. Wywołanie [GetEffective](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/) na formacie fragmentu zwraca ostateczną rozdzieloną wysokość.

Użyj dwóch rodzajów danych formatowania do różnych celów:

- Odczytać lub zmienić lokalny obiekt formatu, taki jak [IPortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/), gdy potrzebujesz kontrolować, gdzie wartość jest zdefiniowana.
- Odczytać obiekt danych efektywnych, taki jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformateffectivedata/), gdy potrzebujesz ostatecznego, renderowanego wyniku. Dane efektywne są tylko do odczytu.

## **Porównaj lokalne, dziedziczone i efektywne wartości**

Poniższy kompletny przykład tworzy kształt i nakłada wysokości czcionki na poziomie prezentacji, akapitu i fragmentu. Każdy krok wypisuje wartości zdefiniowane na tych poziomach oraz wynikającą wartość efektywną dla tego samego fragmentu tekstu. Pokazuje także, dlaczego dane efektywne należy odczytać ponownie po zmianach formatowania.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Zdefiniuj dziedziczone wartości na dwóch różnych poziomach.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Odczytaj dane efektywne po poprzednich zmianach.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Lokalna wartość w fragmencie nadpisuje obie dziedziczone wartości.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Zmiana dziedziczonej wartości nie nadpisuje istniejącej wartości lokalnej.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Wyczyść wartość lokalną. Fragment teraz ponownie dziedziczy z akapitu.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Wyczyść wartość akapitu. Domyślna wartość prezentacji teraz dostarcza wynik.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Priorytet w tym przykładzie to najpierw formatowanie lokalne fragmentu, potem formatowanie akapitu, a na końcu domyślne ustawienia prezentacji. Inne obiekty mogą mieć różne łańcuchy dziedziczenia, ale zasada jest taka sama: bardziej szczegółowa wartość jawna wygrywa, a [GetEffective](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/) zwraca ostateczny rezultat.

## **Uzyskaj efektywne właściwości tekstu**

Formatowanie tekstu jest podzielone na kilka obiektów:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformat/) rozwiązuje właściwości ramki tekstowej, takie jak marginesy, zakotwienie, dopasowanie automatyczne i pionowy kierunek tekstu.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextstyle/) rozwiązuje formatowanie akapitu dla każdego poziomu stylu tekstu.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iparagraphformat/) rozwiązuje właściwości akapitu, takie jak wyrównanie, wcięcie i wypunktowanie.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformat/) rozwiązuje właściwości znaków, takie jak wysokość czcionki, krój, kolor, pogrubienie i kursywa.

Dla kolejnego przykładu plik `text-formatting.pptx` musi zawierać przynajmniej jeden slajd i jedną [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) z niepustą ramką tekstową. IAutoShape może znajdować się w dowolnej pozycji w kolekcji kształtów; kod wyszukuje odpowiedni obiekt i weryfikuje go przed użyciem.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Uzyskaj efektywne właściwości 3D**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformat/) zwraca jeden obiekt [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformateffectivedata/), który grupuje wszystkie rozwiązane ustawienia 3D. Jego [camera](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapebeveleffectivedata/) i [bottom bevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapebeveleffectivedata/) ujawniają odpowiednie ustawienia efektywne. Czytanie tych powiązanych ustawień razem ułatwia zrozumienie ostatecznego wyglądu 3D kształtu.

Dla tego przykładu plik `shape-3d.pptx` musi zawierać przynajmniej jeden kształt na pierwszym slajdzie. Zastosuj ustawienia kamery 3D, oświetlenia lub fazowania do tego kształtu, jeśli chcesz, aby wynik zawierał wartości inne niż domyślne.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Uzyskaj efektywne formatowanie tabeli**

Formatowanie tabeli może pochodzić ze stylu tabeli oraz z formatów zastosowanych do całej tabeli, kolumny, wiersza lub pojedynczej komórki. W przypadku konfliktów pomiędzy jawnie określonymi wypełnieniami priorytetem jest kolejno: komórka, wiersz, kolumna i na końcu cała tabela. Efektywny format komórki to ostateczny format używany do jej rysowania.

Dla tego przykładu plik `table-formatting.pptx` musi zawierać przynajmniej jedną tabelę na pierwszym slajdzie. Tabela musi mieć przynajmniej jeden wiersz i jedną kolumnę. Kod wyszukuje obiekt [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/) zamiast zakładać, że pierwszym kształtem jest tabela.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Jeśli potrzebujesz koloru, a nie tylko typu wypełnienia, najpierw sprawdź efektywny [FillType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifillformateffectivedata/), a potem odczytaj właściwość właściwą dla tego typu — na przykład [SolidFillColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifillformateffectivedata/) dla wypełnienia jednolitego.

## **Ponowne odczytanie danych efektywnych po zmianach**

Dane efektywne opisują hierarchię formatowania w momencie ich rozwiązania. Wywołaj ponownie `GetEffective` po zmianie czegokolwiek, co może uczestniczyć w tej hierarchii, w tym:

- lokalne formatowanie obiektu;
- domyślne ustawienia akapitu lub ramki tekstowej;
- styl tabeli, tabela, kolumna, wiersz lub format komórki;
- formatowanie układu lub slajdu nadrzędnego;
- dane tematu lub domyślne ustawienia na poziomie prezentacji;
- układ lub slajd nadrzędny przypisany do slajdu.

Nie przechowuj obiektu danych efektywnych jako trwałego migawki. Aspose.Slides może wewnętrznie buforować niektóre dane efektywne, a późniejsze wywołanie `GetEffective` może odświeżyć te dane. Jeśli potrzebujesz porównać wartości przed i po zmianie, skopiuj potrzebne wartości skalarne — takie jak wysokość czcionki, kolor, wyrównanie czy szerokość fazowania — do własnych zmiennych przed wprowadzeniem zmiany.

Aby zmienić wartość, zaktualizuj odpowiedni lokalny obiekt formatu, a następnie wywołaj `GetEffective`, aby zweryfikować wynik. Obiekty danych efektywnych są same w sobie tylko do odczytu.

## **FAQ**

**Jak mogę stwierdzić, który poziom dostarczył wartość efektywną?**

Dane efektywne zawierają ostateczną wartość, a nie jej źródło. Należy sprawdzić odpowiednie lokalne obiekty, zaczynając od najbardziej szczegółowego poziomu i idąc na zewnątrz. Dla tekstu może to obejmować fragment, akapit, ramkę tekstową, układ, slajd nadrzędny, temat oraz domyślne ustawienia prezentacji. Niezdefiniowane wartości, takie jak `std::numeric_limits<float>::quiet_NaN()` lub `nullptr`, wskazują, że wyszukiwanie kontynuuje się na kolejnym poziomie.

**Co się stanie, gdy żaden poziom nie zdefiniuje właściwości?**

Aspose.Slides rozwiązuje odpowiedni domyślny parametr PowerPoint lub biblioteki. Ta rozwiązana wartość pojawia się w danych efektywnych, chociaż żaden lokalny obiekt nie definiuje jej jawnie.

**Dlaczego wartość efektywna czasami jest równa wartości lokalnej?**

Wartość lokalna wygrała w obliczeniach dziedziczenia. Dzieje się tak, gdy właściwość jest jawnie ustawiona na obiekcie i żadne bardziej szczegółowe zasady jej nie nadpisują.

**Kiedy powinienem używać danych lokalnych zamiast danych efektywnych?**

Używaj danych lokalnych, aby zbadać lub edytować konkretny poziom formatowania. Używaj danych efektywnych, gdy potrzebny jest ostateczny wygląd po zastosowaniu dziedziczenia, reguł tematu i odpowiednich stylów. [pełny przykład porównania](#compare-local-inherited-and-effective-values) demonstruje oba podejścia w tym samym przepływie pracy.