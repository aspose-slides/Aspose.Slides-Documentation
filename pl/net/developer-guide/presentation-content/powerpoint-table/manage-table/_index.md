---
title: Zarządzanie tabelami prezentacji w .NET
linktitle: Zarządzaj tabelą
type: docs
weight: 10
url: /pl/net/manage-table/
keywords:
- dodaj tabelę
- utwórz tabelę
- dostęp do tabeli
- proporcje
- wyrównaj tekst
- formatowanie tekstu
- styl tabeli
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Utwórz i edytuj tabele w slajdach PowerPoint przy użyciu Aspose.Slides dla .NET. Odkryj proste przykłady kodu C#, aby usprawnić pracę z tabelami."
---
## **Wprowadzenie**

Tabele w programie PowerPoint organizują informacje w wierszach i kolumnach, co ułatwia ich odczytywanie i porównywanie wartości.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) interfejs [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) klasę [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) interfejs [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) oraz inne typy, które umożliwiają tworzenie, aktualizację i zarządzanie tabelami w prezentacjach.

## **Utwórz tabelę od podstaw**

Utwórz tabelę, określając jej położenie, szerokości kolumn i wysokości wierszy. Po dodaniu jej do slajdu możesz formatować krawędzie komórek, scalać komórki i wstawiać tekst.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
3. Zdefiniuj tablicę szerokości kolumn w punktach.
4. Zdefiniuj tablicę wysokości wierszy w punktach.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) do slajdu za pomocą metody [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Iteruj po każdym [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/), aby zastosować formatowanie krawędzi górnej, dolnej, prawej i lewej.
7. Scal pierwsze dwa komórki pierwszego wiersza tabeli.
8. Uzyskaj dostęp do scalonej komórki przez jej właściwość [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/).
9. Ustaw tekst w scalonej komórce.
10. Zapisz zmodyfikowaną prezentację.

Przykład poniżej tworzy tabelę z trzema kolumnami i pięcioma wierszami w punkcie (100, 50). Stosuje czerwone krawędzie o szerokości 5 punktów, scala pierwsze dwa komórki w pierwszym wierszu i zapisuje wynik jako `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli indeksy komórek zaczynają się od zera i używają kolejności (kolumna, wiersz). Pierwsza komórka ma indeks (0, 0).

Na przykład komórki w tabeli z 4 kolumnami i 4 wierszami są numerowane w ten sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten przykład tworzy powyższą tabelę 4 × 4, z szerokościami kolumn i wysokościami wierszy po 70 punktów oraz czerwonymi krawędziami komórek o szerokości 5 punktów. Współrzędne ilustrują indeksy komórek; przykład pozostawia komórki puste i zapisuje tabelę jako `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Dostęp do istniejącej tabeli**

Tabele są przechowywane w kolekcji kształtów slajdu. Iteruj po kształtach, aby zlokalizować tabelę, a następnie użyj interfejsu [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) do odczytu lub aktualizacji jej komórek.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu zawierającego tabelę na podstawie jego indeksu.
3. Iteruj po obiektach [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) i zatrzymaj się, gdy znajdziesz tabelę. Jeśli slajd zawiera kilka tabel, użyj [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/), aby zidentyfikować potrzebną.
4. Zaktualizuj tekst w docelowej komórce.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `UpdateExistingTable.pptx` i znajduje pierwszą tabelę na pierwszym slajdzie. Ustawia komórkę w kolumnie 0, wierszu 1 na `New` i zapisuje wynik jako `table1_out.pptx`. Wejście musi zawierać co najmniej jeden slajd, a pierwsza tabela na tym slajdzie musi mieć co najmniej jedną kolumnę i dwa wiersze.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Aby zmienić rozmiar wiersza w istniejącej tabeli i zrozumieć, dlaczego jej rzeczywista wysokość może przekraczać żądaną minimalną, zobacz [Kontrola wysokości wiersza](/slides/pl/net/manage-rows-and-columns/#control-row-height).

## **Znajdź komórkę posiadającą ramkę tekstową**

Gdy ogólny kod przetwarzający tekst otrzymuje obiekt [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) z tabeli, użyj właściwości [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/), aby pobrać będącą właścicielem [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). Dla ramki tekstowej komórki tabeli [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) jest ustawiona, a [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) ma wartość `null`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne poprzez właściwości tylko do odczytu [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) i [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) jest również tylko do odczytu: zapewnia nawigację do właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `null` przed jej użyciem.

Pełny przykład, który identyfikuje właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, znajdziesz w [Wyszukiwanie i zamiana tekstu](/slides/pl/net/search-and-replace-text/).

## **Wyrównaj tekst w tabeli**

Możesz kontrolować pionowe zakotwiczenie i kierunek tekstu pojedynczych komórek tabeli. Przykład w tej sekcji centruje tekst w pierwszej komórce i obraca go o 270 stopni.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
3. Dodaj obiekt [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) do slajdu.
4. Uzyskaj dostęp do obiektu [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) z tabeli.
5. Uzyskaj dostęp do pierwszego [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) i ustaw jego tekst oraz kolor.
6. Ustaw w komórce właściwości [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) i [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/).
7. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 4 × 4 z szerokościami kolumn po 120 punktów i wysokościami wierszy po 100 punktów. Formatuje tekst w komórce (0, 0), dodaje wartości do pozostałych komórek w pierwszym wierszu i zapisuje wynik jako `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

Użyj [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) aby zastosować formatowanie tekstu we wszystkich komórkach tabeli. Przeciążenia akceptują formatowanie fragmentu, akapitu i ramki tekstowej, więc możesz ustawić te właściwości bez iteracji po poszczególnych komórkach.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
3. Uzyskaj dostęp do obiektu [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) ze slajdu.
4. Ustaw [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) dla tekstu.
5. Ustaw [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) oraz [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Ustaw [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `table.pptx`, który musi zawierać przynajmniej jeden slajd z tabelą jako pierwszym kształtem. Ustawia rozmiar czcionki na 25 punktów, wyrównuje akapity do prawej z prawym marginesem 20 punktów i ustawia tekst w pionie. Sformatowaną prezentację zapisuje jako `result.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Pobierz właściwości stylu tabeli**

Użyj [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/), aby odczytać lub przypisać wstępnie zdefiniowany styl tabeli. Ten przykład stosuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) do jednej tabeli, wypisuje nazwę stylu i przypisuje ten sam styl drugiej tabeli. Obie tabele są zapisane w `table-style.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Zablokuj proporcje tabeli**

Proporcje tabeli to stosunek jej szerokości do wysokości. Użyj [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/), aby zablokować ten stosunek dla tabeli.

Poniższy przykład otwiera `pres.pptx`, który musi zawierać przynajmniej jeden slajd z tabelą jako pierwszym kształtem. Wypisuje bieżący stan blokady, włącza blokadę proporcji, wypisuje zaktualizowany stan (`True`) i zapisuje wynik jako `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy mogę włączyć kierunek odczytu od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia właściwość [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/), a akapity mają [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Użycie obu zapewnia prawidłowy porządek RTL i renderowanie wewnątrz komórek.

**Jak mogę zapobiec przenoszeniu lub zmianie rozmiaru tabeli przez użytkowników w pliku końcowym?**

Użyj [blokady kształtów](/slides/pl/net/applying-protection-to-presentation/), aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady mają zastosowanie również do tabel.

**Czy wstawianie obrazu wewnątrz komórki jako tła jest obsługiwane?**

Tak. Możesz ustawić [wypełnienie obrazem](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).