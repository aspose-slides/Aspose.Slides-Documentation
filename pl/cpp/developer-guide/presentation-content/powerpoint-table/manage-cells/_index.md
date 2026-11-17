---
title: Zarządzanie komórkami tabeli w prezentacjach przy użyciu C++
linktitle: Zarządzanie komórkami
type: docs
weight: 30
url: /pl/cpp/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- podział komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj komórkami tabel PowerPoint w C++: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabeli, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale komórek, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, uzyskać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez właściwości komórek i zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych do dostępu do komórek tabeli w kolejności `(column, row)`.

## **Zidentyfikowanie scalonej komórki tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje po wszystkich wierszach i kolumnach i używa [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) do identyfikacji komórek w scalonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), oraz początkowe współrzędne regionu, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) i [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Usunięcie obramowań komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) i dodaj tabelę do pierwszego slajdu za pomocą [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Szerokości kolumn, wysokości wierszy i pozycja tabeli są określone w punktach. Przykład ustawia wszystkie cztery obramowania komórki na [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), czyniąc je niewidocznymi.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Dodanie przekątnych obramowań komórek**

Użyj [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/), aby narysować linię od górnego lewego rogu do dolnego prawego, oraz [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/), aby narysować linię od dolnego lewego rogu do górnego prawego. Przekątna może oznaczać nagłówek w rogu; obie przekątne mogą tworzyć X, aby oznaczyć komórkę jako nie mającą zastosowania.

Każda przekątna jest obiektem [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/). Użyj [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/), aby uzyskać dostęp do wypełnienia, wywołaj [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) z [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) i wybierz kolor za pomocą [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/). Ustaw szerokość linii za pomocą [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) w punktach.

Przykład tworzy trzy komórki w jednym wierszu: czerwoną przekątną skierowaną w dół, niebieską przekątną skierowaną w górę oraz obie przekątne. Pozostawia niezmienione górne, dolne, lewe i prawe obramowania komórek.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

Przekątna jest właściwością formatowania, a nie podziałem komórki. Każda komórka zachowuje pojedynczą ramkę tekstową dostępną przez [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/); obszary po obu stronach przekątnej nie mogą być edytowane niezależnie.

Zapisana tabela, wyświetlona w Microsoft PowerPoint:

![Trzy komórki tabeli pokazujące czerwoną przekątną od górnego lewego do dolnego prawego, niebieską przekątną od dolnego lewego do górnego prawego oraz obie przekątne tworzące X.](diagonal-cell-borders.png)

*Od lewej do prawej: przekątna skierowana w dół (czerwona, 3 pt), przekątna skierowana w górę (niebieska, 5 pt) oraz obie przekątne.*

## **Scalanie komórek tabeli**

Użyj [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/), aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument kontroluje, czy scalanie może obejmować komórki poza określonym zakresem; `false` utrzymuje scalanie w obrębie tego zakresu.

Przykład tworzy tabelę 4x4 o kolumnach i wierszach o szerokości 70 punktów, a następnie scala cztery centralne komórki od `(1, 1)` do `(2, 2)`. Powstała komórka obejmuje dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table->idx_get(1, 1)` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem się nie zmieniają.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Podział komórek tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę siatki i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides stosuje model siatki tabeli PowerPoint.

Ten przykład tworzy tabelę 4x4 o kolumnach i wierszach o szerokości 70 punktów i wywołuje [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) na komórce `(1, 1)`. Połowa szerokości 70 punktów komórki jest przekazywana, aby utworzyć dwie komórki o równej szerokości.

Po tym podziale, dwie połowy są dostępne jako `table->idx_get(1, 1)` i `table->idx_get(2, 1)`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przenoszone są odpowiednio do kolumn 3 i 4. Indeksy wierszy pozostają niezmienione. Używaj tych zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

<!-- visual-explanation:manage-cells:start -->
[![Niescalona komórka o szerokości 70 punktów dzieli się na dwie komórki po 35 punktów, dodając piątą kolumnę siatki i przesuwając indeksy po jej prawej stronie.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Podział szerokości dotyczy komórki (1, 1), używając zerowych (kolumna, wiersz) indeksów. Inne wiersze zachowują komórkę obejmującą oba nowe pozycje kolumn.*
<!-- visual-explanation:manage-cells:end -->

### **Podział scalonych komórek według zakresu wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełnienia danymi, użyj [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) , aby podzielić wzdłuż istniejącej granicy wiersza, lub [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) , aby podzielić wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest względny względem scalonego regionu:

- Podział wiersza: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Podział kolumny: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Przykład zakłada, że prezentacja zawiera tabelę jako pierwszy kształt na pierwszym slajdzie, przy czym `(1, 2)` i `(1, 3)` są scalone pionowo. Rozpoczynając od dolnej pozycji, używa [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) i [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) do zlokalizowania początkowego punktu i sprawdza oba zakresy. `SplitByRowSpan(1)` oddziela wtedy wiersze 2 i 3 dla nazw produktów. Dla poziomego scalania dwóch kolumn, użyj `SplitByColSpan(1)` zamiast tego.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Pobierz powstałe komórki z tabeli po podziale.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz wynikowe komórki według ich współrzędnych; tutaj obie mają zakresy równe 1, a [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) wypisuje `False`. Większe regiony mogą pozostać częściowo scalone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw wymagane formatowanie tekstu explicite.

Zapisana prezentacja zawiera oddzielne komórki „Product A” i „Product B” z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) po szczegóły.

### **Podział komórki o określonej wysokości**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) przyjmuje wysokość górnej części w punktach. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) przyjmuje liczbę istniejących wierszy siatki w górnej części. Aby wyśrodkować komórkę o wysokości 40 punktów w prawej kolumnie, odejmij 40 od rzeczywistej wysokości komórki i podziel pozostałą przestrzeń równo powyżej i poniżej niej.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

Pierwszy podział dodaje wiersz siatki, pozostawiając dolne 90 punktów w `(1, 1)`. Drugi podział dotyczy tej komórki i dodaje kolejny wiersz pod nią. Prawa kolumna zawiera teraz `(1, 0)` o wysokości 50 punktów (`margin`), `(1, 1)` o wysokości 40 punktów oraz `(1, 2)` o wysokości 50 punktów (`margin`). Lewa komórka obejmuje wszystkie trzy wiersze przy pierwotnej wysokości 140 punktów.

![Lewa komórka rozciąga się na pełną wysokość tabeli obok trzech komórek z napisem Middle w centrum.](split-by-height.png)

## **Zmiana koloru tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Używa [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) , aby wybrać wypełnienie jednolite oraz [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) , aby uzyskać dostęp do koloru wypełnienia i ustawia go na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Dodanie obrazu wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) i dodaje go do kolekcji obrazów prezentacji przy użyciu [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Następnie przypisuje obraz do wypełnienia obrazem komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnić komórkę, co może zmienić jej proporcje. Szerokość kolumn i wysokość wierszy są wyrażone w punktach. Załadowany obraz jest zwalniany po dodaniu go do prezentacji.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę ustawić różne grubości i style linii dla różnych stron jednej komórki?**

Tak. Obrzeża [górne](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[dolne](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[lewe](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[prawe](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić.

**Co się dzieje z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [trybu wypełniania](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dostosowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperlink do całej treści komórki?**

[Hyperlinks](/slides/pl/cpp/manage-hyperlinks/) są ustawiane na poziomie tekstu (części) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do części lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (fragmenty) z niezależnym formatowaniem — rodzinę czcionki, styl, rozmiar i kolor.