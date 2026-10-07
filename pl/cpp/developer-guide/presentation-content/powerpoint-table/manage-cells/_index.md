---
title: Zarządzaj komórkami tabel w prezentacjach przy użyciu C++
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/cpp/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj komórkami tabel PowerPoint w C++: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustaw kolory tła i obrazy przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Aspose.Slides pozwala na dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podzieleniu komórek, zmienić tło komórki i dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez właściwości komórek i zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych do dostępu do komórek tabel w kolejności `(column, row)`.

## **Zidentyfikuj scaloną komórkę tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje przez wszystkie wiersze i kolumny i używa [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) do identyfikacji komórek w scalonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), oraz początkowe współrzędne regionu, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) i [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

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

## **Usuń obramowania komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) i dodaj tabelę do jej pierwszego slajdu przy użyciu [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). Szerokości kolumn, wysokości wierszy oraz pozycja tabeli są określone w punktach. Przykład ustawia wszystkie cztery obramowania komórek na [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), czyniąc je niewidocznymi.

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

## **Scal komórki tabeli**

Użyj [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) , aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument kontroluje, czy scalanie może obejmować komórki poza określonym zakresem; `false` utrzymuje scalanie w ramach tego zakresu.

Przykład tworzy tabelę 4x4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery centralne komórki od `(1, 1)` do `(2, 2)`. Powstała komórka zajmuje dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table->idx_get(1, 1)` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem nie zmieniają się.

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

## **Podziel komórki tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę siatki i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides stosuje się do modelu siatki tabeli PowerPoint.

Ten przykład tworzy tabelę 4x4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) na komórce `(1, 1)`. Połowa szerokości komórki 70 punktów jest przekazywana, aby utworzyć dwie komórki o równej szerokości.

Po tym podziale dwie połówki są dostępne jako `table->idx_get(1, 1)` i `table->idx_get(2, 1)`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przestawiają się do kolumn 3 i 4, odpowiednio. Indeksy wierszy pozostają niezmienione. Używaj tych zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

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

### **Podziel scalone komórki według zakresu wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) , aby podzielić wzdłuż istniejącej granicy wiersza, lub [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) , aby podzielić wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest względny względem scalonego regionu:

- Row split: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Column split: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Przykład zakłada, że prezentacja ma tabelę jako pierwszy kształt na pierwszym slajdzie, z komórkami `(1, 2)` i `(1, 3)` scalonymi pionowo. Rozpoczynając od niższej pozycji, używa [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) i [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/), aby zlokalizować początek i sprawdza oba zakresy. `SplitByRowSpan(1)` następnie oddziela wiersze 2 i 3 dla nazw produktów. Dla poziomego scalania dwóch kolumn użyj `SplitByColSpan(1)` zamiast tego.

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

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz powstałe komórki po ich współrzędnych; tutaj obie mają zakresy równe 1 i [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) wypisuje `False`. Większe regiony mogą pozostać częściowo scalone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw wszelkie wymagane formatowanie tekstu explicite.

Zapisana prezentacja zawiera osobne komórki "Product A" i "Product B" z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) po szczegóły.

## **Zmień kolor tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Używa [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) , aby wybrać jednolite wypełnienie oraz [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) , aby uzyskać kolor wypełnienia i ustawić go na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

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

## **Dodaj obraz wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz przy użyciu [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) , i dodaje go do kolekcji obrazów prezentacji za pomocą [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). Następnie przypisuje obraz do wypełnienia obrazu komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnić komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy są podane w punktach. Załadowany obraz jest zwalniany po dodaniu go do prezentacji.

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

**Can I set different line thicknesses and styles for different sides of a single cell?**

Tak. Obramowania [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić.

**What happens to the image if I change the column/row size after setting a picture as the cell’s background?**

Zachowanie zależy od [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dostosowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Can I assign a hyperlink to all the content of a cell?**

[Hyperlinks](/slides/pl/cpp/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Can I set different fonts within a single cell?**

Tak. Ramka tekstowa komórki obsługuje [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) , czyli fragmenty (runy) z niezależnym formatowaniem — rodzina czcionki, styl, rozmiar i kolor.