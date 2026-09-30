---
title: Zarządzaj wierszami i kolumnami w tabelach PowerPoint przy użyciu C++
linktitle: Wiersze i kolumny
type: docs
weight: 20
url: /pl/cpp/manage-rows-and-columns/
keywords:
- wiersz tabeli
- kolumna tabeli
- pierwszy wiersz
- nagłówek tabeli
- klonowanie wiersza
- klonowanie kolumny
- kopiowanie wiersza
- kopiowanie kolumny
- usuwanie wiersza
- usuwanie kolumny
- formatowanie tekstu wiersza
- formatowanie tekstu kolumny
- styl tabeli
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy użyciu Aspose.Slides dla C++ i przyspiesz edycję prezentacji oraz aktualizację danych."
---
## **Wprowadzenie**

Aspose.Slides for C++ umożliwia zarządzanie strukturą tabeli i formatowaniem w prezentacjach PowerPoint za pośrednictwem klasy [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) i interfejsu [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/). Możesz wyznaczyć wiersz nagłówka, klonować lub usuwać wiersze i kolumny oraz zastosować formatowanie tekstu do całego wiersza lub kolumny.

Ten artykuł wyjaśnia te operacje na przykładach w C++. Pokazuje także, jak pobrać preset stylu tabeli, aby móc go ponownie użyć. Indeksy wierszy i kolumn tabeli są zerowe.

## **Kontrola wysokości wiersza**

Użyj [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) aby ustawić minimalną wysokość wiersza w punktach. Jest to dolna granica, a nie stała wysokość. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) zwraca rzeczywistą wysokość; tej wartości nie można ustawić bezpośrednio. Uzyskaj dostęp do wiersza przez [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/).

Przykład ładuje [row-height-input.pptx](row-height-input.pptx), który zawiera tabelę jako pierwszy obiekt na pierwszym slajdzie. Pierwszy wiersz zaczyna się od 70 punktów. Komórki używają tekstu Arial 18‑punktowego, z zawijaniem i marginesami górnym oraz dolnym po 6 punktów; dłuższy tekst w drugiej kolumnie zawija się na wiele linii. Przykład zwiększa minimum do 100 punktów, potem zmniejsza je do 20 punktów, wypisuje rzeczywistą wysokość po każdej zmianie i zapisuje oba wyniki.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Przy dostarczonej prezentacji zwiększenie minimum dodaje przestrzeń do wiersza. Zmniejszenie usuwa tę dodatkową przestrzeń, ale rzeczywista wysokość pozostaje większa niż 20 punktów, ponieważ tekst i marginesy komórek potrzebują więcej miejsca. Samo obniżenie minimum nie może zmusić wiersza do wysokości mniejszej niż wymagana przez zawartość.

Kilka czynników wpływa na rzeczywistą wysokość:

- **Tekst i rozmiar czcionki:** dłuższy tekst, wymuszone podziały wierszy lub większa czcionka mogą wymagać więcej pionowej przestrzeni.
- **Zawijanie i szerokość kolumny:** przy włączonym zawijaniu zmniejszenie szerokości kolumny za pomocą [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) może spowodować powstanie większej liczby linii. Szersza kolumna może zmniejszyć wymaganą pionowo przestrzeń.
- **Marginesy komórek:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) i [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) kontrolują marginesy dodające pionową przestrzeń. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) i [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) kontrolują marginesy zmniejszające dostępną szerokość tekstu i mogą powodować dodatkowe zawijanie.

W tej tabeli bez scalonych komórek komórka wymagająca najwięcej pionowej przestrzeni określa dolną granicę wymuszoną treścią dla całego wiersza. Aby skrócić wiersz, może być konieczne skrócenie tekstu, zmniejszenie rozmiaru czcionki lub marginesów albo zwiększenie szerokości kolumny.

Poniższe obrazy przedstawiają tę samą tabelę w tej samej skali. W referencyjnym uruchomieniu .NET, które tutaj jest pokazane, rzeczywiste wysokości wynosiły 70, 100 i 55,2 punktu: ostatni wiersz pozostał wyższy niż jego minimum 20 punktów. Dokładne pomiary tekstu mogą się różnić w zależności od dostępnych w Twoim środowisku czcionek. Pobierz zapisane wyniki: [zwiększony minimum](row-height-increased.pptx) i [zmniejszony minimum](row-height-decreased.pptx).

| Oryginalny: minimum 70 pt, rzeczywiste 70 pt | Zwiększony: minimum 100 pt, rzeczywiste 100 pt | Zmniejszony: minimum 20 pt, rzeczywiste 55.2 pt |
| --- | --- | --- |
| ![Oryginalna tabela z pierwszym wierszem o wysokości 70 punktów.](row-height-before.png) | ![Tabela po zwiększeniu minimalnej wysokości pierwszego wiersza do 100 punktów.](row-height-increased.png) | ![Tabela po zmniejszeniu minimalnej wysokości pierwszego wiersza do 20 punktów; zawinięty tekst utrzymuje wiersz wyższym niż minimum.](row-height-decreased.png) |

## **Ustaw pierwszy wiersz jako nagłówek**

Użyj metody [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) aby oznaczyć pierwszy wiersz jako nagłówek. Jego wygląd zależy od stylu tabeli zastosowanego do tabeli.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Uzyskaj dostęp do tabeli zapisanej jako pierwszy obiekt na slajdzie.
4. Włącz formatowanie nagłówka dla jej pierwszego wiersza.
5. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym obiektem na pierwszym slajdzie. Włącza formatowanie nagłówka dla pierwszego wiersza i zapisuje `First_row_header.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Klonowanie wiersza lub kolumny tabeli**

Klonuj wiersze lub kolumny, aby ponownie użyć ich zawartości i formatowania. Możesz dodać kopię na koniec tabeli lub wstawić ją w określone miejsce.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę przy użyciu metody [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Sklonuj wymagane wiersze.
6. Sklonuj wymagane kolumny.
7. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `Test.pptx` z co najmniej jednym slajdem. Tworzy tabelę z trzema kolumnami i pięcioma wierszami, o wymiarach podanych w punktach. Dodaje kopie pierwszego wiersza i pierwszej kolumny na koniec, a następnie wstawia kopie drugiego wiersza i drugiej kolumny pod indeksem 3 (czwarte miejsce). Wynikowa tabela ma siedem wierszy i pięć kolumn. Argument `false` wyłącza klonowanie do sąsiadujących scalonych wierszy lub kolumn; w tej tabeli nie ma scalonych komórek.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Usuwanie wiersza lub kolumny z tabeli**

Usuń wiersze lub kolumny, które nie są już potrzebne w tabeli. Usunięcie elementu przesuwa indeksy kolejnych wierszy lub kolumn.

1. Utwórz prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę przy użyciu metody [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
5. Usuń drugi wiersz i drugą kolumnę.
6. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę trzy‑na‑trzy i usuwa wiersz oraz kolumnę o indeksie 1, pozostawiając tabelę dwa‑na‑dwa w pliku `TestTable_out.pptx`. Wymiary podane są w punktach. Argument `false` wyłącza usuwanie sąsiadujących scalonych wierszy lub kolumn; w tej tabeli nie ma scalonych komórek.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

Zastosuj formatowanie tekstu do całego wiersza, aby komórki były spójne. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Ustaw wysokość czcionki przy użyciu [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) dla pierwszego wiersza.
4. Ustaw wyrównanie i prawy margines akapitu przy użyciu [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) oraz [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) dla pierwszego wiersza.
5. Ustaw kierunek tekstu przy użyciu [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) dla drugiego wiersza.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym obiektem na pierwszym slajdzie i co najmniej dwoma wierszami. Nakłada tekst 25‑punktowy, wyrównanie do prawej i prawy margines akapitu 20 punktów na pierwszy wiersz, a następnie ustawia pionowy tekst w drugim wierszu.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

Zastosuj formatowanie tekstu do całej kolumny, aby komórki były spójne. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Ustaw wysokość czcionki przy użyciu [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) dla pierwszej kolumny.
4. Ustaw wyrównanie i prawy margines akapitu przy użyciu [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) oraz [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) dla pierwszej kolumny.
5. Ustaw kierunek tekstu przy użyciu [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) dla drugiej kolumny.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym obiektem na pierwszym slajdzie i co najmniej dwiema kolumnami. Nakłada tekst 25‑punktowy, wyrównanie do prawej i prawy margines akapitu 20 punktów na pierwszą kolumnę, a następnie ustawia pionowy tekst w drugiej kolumnie.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Pobierz właściwości stylu tabeli**

Użyj metody [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) aby pobrać preset zastosowany do tabeli i ponownie użyć go w innej tabeli. To identyfikuje preset zamiast indywidualnych nadpisań formatowania komórek.

Przykład tworzy tabelę, stosuje [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) i odczytuje preset. Wypisuje `DarkStyle1` i zapisuje tabelę w pliku `table.pptx`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę zastosować motywy/stylu PowerPoint do już istniejącej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/macierzy, a Ty nadal możesz nadpisać wypełnienia, obramowania i kolory tekstu ponad tym motywem.

**Czy mogę sortować wiersze tabeli jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj dane w pamięci najpierw, a potem ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć kolumny w paski przy zachowaniu niestandardowych kolorów w określonych komórkach?**

Tak. Włącz paski w kolumnach, a potem nadpisz konkretne komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.