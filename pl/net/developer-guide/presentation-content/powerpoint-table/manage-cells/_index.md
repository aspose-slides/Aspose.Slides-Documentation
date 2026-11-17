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
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj komórkami tabel PowerPoint w C#: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabeli, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek za pomocą właściwości komórek oraz zapisać zmodyfikowaną prezentację jako plik PPTX.  
Aspose.Slides używa indeksów zerowych do dostępu do komórek tabeli w kolejności `(column, row)`.

## **Zidentyfikuj scaloną komórkę tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje przez wszystkie wiersze i kolumny i używa [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) do identyfikacji komórek w scalonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), oraz początkowe współrzędne regionu, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) i [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

## **Usuń obramowania komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) i dodaj tabelę do jej pierwszego slajdu za pomocą [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Szerokości kolumn, wysokości wierszy i pozycja tabeli są podawane w punktach. Przykład ustawia wszystkie cztery obramowania komórek na [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), czyniąc je niewidocznymi.

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

## **Dodaj przekątne obramowania komórek**

Użyj [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) aby narysować linię od lewego górnego rogu do prawego dolnego, oraz [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) aby narysować linię od lewego dolnego rogu do prawego górnego. Przekątna może oznaczać nagłówek narożny; obie przekątne mogą tworzyć X, oznaczając komórkę jako nieodpowiednią.  
Każda przekątna jest obiektem typu [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). W jej [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/), ustaw [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) i wybierz [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Ustaw [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) linii w punktach.  
Przykład tworzy trzy komórki w jednym wierszu: czerwoną przekątną w dół, niebieską przekątną w górę oraz obie przekątne. Pozostawia niezmienione górne, dolne, lewe i prawe obramowania komórek.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Przekątna jest właściwością formatowania, a nie podziałem komórki. Każda komórka zachowuje pojedynczy [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); obszary po obu stronach przekątnej nie mogą być edytowane niezależnie.  

Zapisana tabela, wyświetlona w programie Microsoft PowerPoint:

![Trzy komórki tabeli pokazujące czerwoną przekątną od lewego górnego rogu do prawego dolnego, niebieską przekątną od lewego dolnego rogu do prawego górnego oraz obie przekątne tworzące X.](diagonal-cell-borders.png)

*Od lewej do prawej: przekątna w dół (czerwona, 3 pt), przekątna w górę (niebieska, 5 pt) i obie przekątne.*

## **Scal komórki tabeli**

Użyj [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument określa, czy scalanie może obejmować komórki poza podanym zakresem; `false` utrzymuje scalanie w tym zakresie.  
Przykład tworzy tabelę 4x4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery centralne komórki od `(1, 1)` do `(2, 2)`. Powstała komórka rozciąga się na dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table[1, 1]` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem nie ulegają zmianie.

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

## **Podziel komórki tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę w siatce i zmienić indeksy kolumn komórek po jej prawej. Aspose.Slides podąża za modelem siatki tabeli w programie PowerPoint.  
Ten przykład tworzy tabelę 4x4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) na komórce `(1, 1)`. Połowa szerokości 70 punktów komórki jest przekazywana, aby utworzyć dwie komórki o równej szerokości.  
Po tym podziale obie połowy są dostępne jako `table[1, 1]` i `table[2, 1]`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przesuwają się do kolumn 3 i 4, odpowiednio. Indeksy wierszy pozostają niezmienione. Używaj tych zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

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

### **Podziel scalone komórki według zakresu wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) aby podzielić wzdłuż istniejącej granicy wiersza, lub [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) aby podzielić wzdłuż granicy kolumny.  
Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest względny względem scentralizowanego regionu:  
- Podział wiersza: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).  
- Podział kolumny: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).  
Przykład zakłada, że prezentacja ma tabelę jako pierwszy kształt na pierwszym slajdzie, z komórkami `(1, 2)` i `(1, 3)` scalonymi pionowo. Rozpoczynając od niższej pozycji, używa [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) i [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) aby zlokalizować początek i sprawdza oba zakresy. `SplitByRowSpan(1)` następnie oddziela wiersze 2 i 3 dla nazw produktów. Dla poziomego scalenia dwóch kolumn użyj `SplitByColSpan(1)`.

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

    // Pobierz wynikowe komórki z tabeli po podziale.
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

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz wynikowe komórki po ich współrzędnych; tutaj obie mają zakres 1 i [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) wypisuje `False`. Większe obszary mogą pozostać częściowo scalone po jednym podziale.  
Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw wszelkie wymagane formatowanie tekstu explicite.  
Zapisana prezentacja zawiera oddzielne komórki „Product A” i „Product B” z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) po szczegóły.

<!-- visual-explanation:manage-cells:start -->
[![Scalona komórka w kolumnie 1, wiersze 2 i 3 dzieli się na Product A i Product B z tymi samymi indeksami siatki.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*Podział wiersza wykorzystuje istniejącą granicę. Product A i Product B zajmują odpowiednio (1, 2) i (1, 3).*
<!-- visual-explanation:manage-cells:end -->

### **Podziel komórkę o określonej wysokości**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) przyjmuje wysokość górnej części w punktach. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) przyjmuje liczbę istniejących wierszy siatki w górnej części. Aby wyśrodkować 40-punktową komórkę w prawej kolumnie, odejmij 40 od rzeczywistej wysokości komórki i podziel pozostałą przestrzeń równo powyżej i poniżej niej.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

Pierwszy podział dodaje wiersz siatki, pozostawiając dolne 90 punktów w `[1, 1]`. Drugi podział celuje w tę komórkę i dodaje kolejny wiersz pod nią. Prawa kolumna zawiera teraz `[1, 0]` o wysokości 50 punktów (`margin`), `[1, 1]` o wysokości 40 punktów oraz `[1, 2]` o wysokości 50 punktów (`margin`). Lewa komórka rozciąga się na wszystkie trzy wiersze przy pierwotnej wysokości 140 punktów.

![Lewa komórka rozciąga się na pełną wysokość tabeli obok trzech komórek z napisem Middle w środku.](split-by-height.png)

## **Zmień kolor tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Ustawia [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na solid oraz [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

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

## **Dodaj obraz wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) i dodaje go do kolekcji obrazów prezentacji za pomocą [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Następnie przypisuje obraz do wypełnienia obrazem komórki `(0, 0)`, pierwszej komórki w tabeli.  
[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnił komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy podawane są w punktach. Załadowany obraz jest automatycznie zwalniany przez deklarację using.

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

Tak. Obramowania [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/). Przy rozciąganiu obraz dostosowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/net/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (fragmenty) z niezależnym formatowaniem — rodzina czcionki, styl, rozmiar i kolor.