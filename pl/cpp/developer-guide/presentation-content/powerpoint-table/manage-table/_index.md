---
title: "Zarządzanie tabelami w prezentacji w C++"
linktitle: "Zarządzaj tabelą"
type: docs
weight: 10
url: /pl/cpp/manage-table/
keywords:
- "dodaj tabelę"
- "utwórz tabelę"
- "dostęp do tabeli"
- "proporcje"
- "wyrównaj tekst"
- "formatowanie tekstu"
- "styl tabeli"
- "PowerPoint"
- "prezentacja"
- "C++"
- "Aspose.Slides"
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu Aspose.Slides dla C++. Odkryj proste przykłady kodu, które usprawnią Twoje przepływy pracy z tabelami."
---
## **Wprowadzenie**

Tabele w programie PowerPoint organizują informacje w wiersze i kolumny, ułatwiając ich odczyt i porównywanie wartości.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) , interfejs [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) , klasę [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) , interfejs [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) oraz inne typy, które umożliwiają tworzenie, aktualizowanie i zarządzanie tabelami w prezentacjach.

## **Utworzenie tabeli od podstaw**

Utwórz tabelę, podając jej pozycję, szerokości kolumn i wysokości wierszy. Po dodaniu jej do slajdu możesz formatować krawędzie komórek, scalać komórki i wstawiać tekst.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę szerokości kolumn w punktach.
4. Zdefiniuj tablicę wysokości wierszy w punktach.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) do slajdu przy użyciu metody [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) .
6. Iteruj po każdym [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) , aby zastosować formatowanie do górnych, dolnych, prawych i lewych krawędzi.
7. Scal pierwsze dwa komórki pierwszego wiersza tabeli.
8. Uzyskaj dostęp do scalonej komórki za pomocą jej metody [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) .
9. Ustaw tekst w scalonej komórce.
10. Zapisz zmodyfikowaną prezentację.

Poniższy przykład tworzy tabelę z trzema kolumnami i pięcioma wierszami w punkcie (100, 50). Nakłada czerwone krawędzie o szerokości 5 punktów, scala pierwsze dwa komórki w pierwszym wierszu i zapisuje wynik jako `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Numerowanie w standardowej tabeli**

W standardowej tabeli indeksy komórek zaczynają się od zera i używają kolejności (kolumna, wiersz). Pierwsza komórka ma indeks (0, 0).

Na przykład komórki w tabeli z 4 kolumnami i 4 wierszami są numerowane w następujący sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten przykład tworzy przedstawioną powyżej tabelę 4 × 4, z szerokościami kolumn i wysokościami wierszy równymi 70 punktów oraz czerwonymi krawędziami o szerokości 5 punktów. Współrzędne ilustrują indeksy komórek; przykład pozostawia komórki puste i zapisuje tabelę jako `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Dostęp do istniejącej tabeli**

Tabele są przechowywane w kolekcji kształtów slajdu. Iteruj przez kształty, aby zlokalizować tabelę, a następnie użyj interfejsu [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) do odczytu lub aktualizacji jej komórek.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu zawierającego tabelę za pomocą jego indeksu.
3. Iteruj przez obiekty [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) i zatrzymaj się, gdy zostanie znaleziona tabela. Jeśli slajd zawiera kilka tabel, użyj [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) aby zidentyfikować potrzebną.
4. Zaktualizuj tekst w docelowej komórce.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `UpdateExistingTable.pptx` i znajduje pierwszą tabelę na pierwszym slajdzie. Ustawia komórkę w kolumnie 0, wierszu 1 na `New` i zapisuje wynik jako `table1_out.pptx`. Wejście musi zawierać co najmniej jeden slajd, a pierwsza tabela na tym slajdzie musi mieć co najmniej jedną kolumnę i dwa wiersze.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Aby zmienić wysokość wiersza w istniejącej tabeli i zrozumieć, dlaczego jej rzeczywista wysokość może przekraczać żądaną minimalną, zobacz [Kontrolowanie wysokości wiersza](/slides/pl/cpp/manage-rows-and-columns/#control-row-height).

## **Znajdowanie komórki, do której należy ramka tekstowa**

Gdy ogólny kod przetwarzający tekst otrzymuje obiekt [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) z tabeli, użyj [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) aby pobrać należący [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/). Dla ramki tekstowej komórki tabeli, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) zwraca właściciela, a [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) zwraca `nullptr`, mimo że tabela sama jest kształtem.

Współrzędne komórki są dostępne przez metodę tylko do odczytu [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) oraz [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) . [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) zapewnia również nawigację tylko do odczytu: zwraca właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `nullptr` przed jej użyciem.

Pełny przykład identyfikujący właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, zobacz [Search and Replace Text](/slides/pl/cpp/search-and-replace-text/).

## **Wyrównywanie tekstu w tabeli**

Możesz kontrolować pionowe zakotwiczenie i kierunek tekstu poszczególnych komórek tabeli. Przykład w tej sekcji wyśrodkowuje tekst w pierwszej komórce i obraca go o 270 stopni.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj obiekt [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) do slajdu.
4. Uzyskaj dostęp do obiektu [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) z tabeli.
5. Uzyskaj dostęp do pierwszego [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) i ustaw jego tekst oraz kolor.
6. Ustaw pionowe zakotwiczenie komórki i kierunek tekstu za pomocą [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) oraz [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) .
7. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 4 × 4 o szerokościach kolumn 120 punktów i wysokościach wierszy 100 punktów. Formatuje tekst w komórce (0, 0), dodaje wartości do pozostałych komórek w pierwszym wierszu i zapisuje wynik jako `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Ustawianie formatowania tekstu na poziomie tabeli**

Użyj [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) aby zastosować formatowanie tekstu do wszystkich komórek w tabeli. Jego przeciążenia akceptują formatowanie części, akapitu i ramki tekstowej, więc możesz ustawić te właściwości bez iteracji przez poszczególne komórki.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do obiektu [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ze slajdu.
4. Ustaw rozmiar czcionki za pomocą [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) dla tekstu.
5. Ustaw wyrównanie akapitu i prawy margines za pomocą [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) oraz [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) .
6. Ustaw kierunek tekstu za pomocą [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) .
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `table.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Ustawia rozmiar czcionki na 25 punktów, wyrównuje akapity do prawej z prawym marginesem 20 punktów oraz ustawia tekst pionowo. Sformatowana prezentacja jest zapisywana jako `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Pobieranie właściwości stylu tabeli**

Użyj [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) aby odczytać presetowy styl tabeli oraz [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) aby go przypisać. Ten przykład nakłada [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) na jedną tabelę, wypisuje nazwę presetu i przypisuje ten sam preset drugiej tabeli. Obie tabele są zapisywane w `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Zablokowanie proporcji tabeli**

Proporcje tabeli to stosunek jej szerokości do wysokości. Użyj [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) aby zablokować ten stosunek dla tabeli.

Poniższy przykład otwiera `pres.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Wypisuje aktualny stan blokady, włącza blokadę proporcji, wypisuje zaktualizowany stan (`True`) i zapisuje wynik jako `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę włączyć kierunek odczytu od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/), a akapity posiadają [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). Użycie obu zapewnia prawidłowy porządek RTL i renderowanie wewnątrz komórek.

**Jak mogę zapobiec przenoszeniu lub zmianie rozmiaru tabeli w ostatecznym pliku?**

Użyj [shape locks](/slides/pl/cpp/applying-protection-to-presentation/) aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady działają również na tabele.

**Czy wstawianie obrazu wewnątrz komórki jako tła jest obsługiwane?**

Tak. możesz ustawić [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).