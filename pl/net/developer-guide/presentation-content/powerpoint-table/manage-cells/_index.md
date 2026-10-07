---
title: Zarządzanie komórkami tabel w prezentacjach w .NET
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/net/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- podział komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj komórkami tabel PowerPoint w C#: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki i ustawiaj kolory tła oraz obrazy przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować połączone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podzieleniu komórek, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek za pomocą właściwości komórki i zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych do dostępu do komórek tabel w kolejności `(column, row)`.

## **Zidentyfikowanie połączonej komórki tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje po wszystkich wierszach i kolumnach i używa [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) do identyfikacji komórek w połączonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/) oraz początkowe współrzędne regionu, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) i [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Usuwanie obramowań komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i dodaj tabelę do pierwszego slajdu przy użyciu [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Szerokości kolumn, wysokości wierszy i pozycja tabeli są określone w punktach. Przykład ustawia wszystkie cztery obramowania komórki na [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), co sprawia, że są niewidoczne.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Scalanie komórek tabeli**

Użyj [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) , aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument określa, czy scalanie może obejmować komórki poza określonym zakresem; `false` utrzymuje scalanie w obrębie tego zakresu.

Przykład tworzy tabelę 4x4 o kolumnach i wierszach o szerokości 70 punktów, a następnie scala cztery środkowe komórki od `(1, 1)` do `(2, 2)`. Powstała komórka zajmuje dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table[1, 1]` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem nie zmieniają się.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Rozdzielanie komórek tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Rozdzielenie komórki może wprowadzić nową kolumnę w siatce i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides stosuje model siatki tabeli PowerPoint.

Ten przykład tworzy tabelę 4x4 o kolumnach i wierszach o szerokości 70 punktów i wywołuje [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) na komórce `(1, 1)`. Połowa szerokości 70‑punktowej komórki jest przekazywana w celu utworzenia dwóch komórek o równej szerokości.

Po tym podziale obie połówki są dostępne jako `table[1, 1]` i `table[2, 1]`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przenoszą się odpowiednio do kolumn 3 i 4. Indeksy wierszy pozostają niezmienione. Używaj zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Rozdzielenie scalonych komórek według zakresu wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/), aby podzielić wzdłuż istniejącej granicy wiersza, lub [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/), aby podzielić wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest względem scalonego regionu:

- Podział wiersza: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Podział kolumny: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Przykład zakłada, że prezentacja ma tabelę jako pierwszy kształt na pierwszym slajdzie, przy czym `(1, 2)` i `(1, 3)` są scalone pionowo. Rozpoczynając od dolnej pozycji, używa [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) i [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) do zlokalizowania początku i sprawdza oba zakresy. `SplitByRowSpan(1)` następnie oddziela wiersze 2 i 3 dla nazw produktów. W przypadku poziomego scalania dwóch kolumn użyj `SplitByColSpan(1)` zamiast tego.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Pobierz powstałe komórki z tabeli po podziale.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz powstałe komórki według ich współrzędnych; tutaj obie mają zakres 1 i [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) zwraca `False`. Większe regiony mogą pozostać częściowo scalone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw wyraźnie wymagane formatowanie tekstu.

Zapisana prezentacja zawiera oddzielne komórki „Product A” i „Product B” z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) po szczegóły.

## **Zmiana koloru tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Ustawia [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na solid i [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Dodanie obrazu wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) i dodaje go do kolekcji obrazów prezentacji przy użyciu [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Następnie przypisuje obraz do wypełnienia obrazem komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnić komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy są podawane w punktach. Załadowany obraz jest automatycznie usuwany dzięki deklaracji using.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy mogę ustawić różne grubości linii i style dla różnych stron jednej komórki?**

Tak. Obramowania [górne](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[dolne](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[lewe](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[prawe](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu zdjęcia jako tło komórki?**

Zachowanie zależy od [trybu wypełnienia](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dostosowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/net/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz odnośnik do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (fragmenty) z niezależnym formatowaniem — rodzinę czcionki, styl, rozmiar i kolor.