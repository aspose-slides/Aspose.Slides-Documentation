---
title: Zarządzanie wierszami i kolumnami w tabelach PowerPoint w .NET
linktitle: Wiersze i kolumny
type: docs
weight: 20
url: /pl/net/manage-rows-and-columns/
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
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy użyciu Aspose.Slides for .NET i przyspiesz edycję prezentacji oraz aktualizację danych."
---
## **Wprowadzenie**

Aspose.Slides for .NET umożliwia zarządzanie strukturą tabeli i formatowaniem w prezentacjach PowerPoint przy użyciu klasy [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) oraz interfejsu [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Możesz wyznaczyć wiersz nagłówka, klonować lub usuwać wiersze i kolumny oraz stosować formatowanie tekstu dla całego wiersza lub kolumny.

Ten artykuł wyjaśnia te operacje przy użyciu przykładów w C#. Pokazuje również, jak pobrać wstępnie ustawiony styl tabeli, aby można go było ponownie użyć. Indeksy wierszy i kolumn tabeli zaczynają się od zera.

## **Kontrolowanie wysokości wiersza**

Użyj [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) aby ustawić minimalną wysokość wiersza w punktach. Jest to dolna granica, a nie stała wysokość. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) zwraca rzeczywistą wysokość i jest tylko do odczytu. Uzyskaj dostęp do wiersza poprzez [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

Przykład ładuje [row-height-input.pptx](row-height-input.pptx), który zawiera tabelę jako pierwszy kształt na pierwszym slajdzie. Jego pierwszy wiersz zaczyna się od 70 punktów. Komórki używają tekstu Arial 18‑punktowego, z zawijaniem i marginesami górnym i dolnym po 6 punktów; dłuższy tekst w drugiej kolumnie zawija się na wiele wierszy. Przykład zwiększa minimalną wysokość do 100 punktów, następnie zmniejsza ją do 20 punktów, wypisuje rzeczywistą wysokość po każdej zmianie i zapisuje oba wyniki.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Przy dostarczonej prezentacji zwiększenie minimalnej wartości dodaje przestrzeń do wiersza. Zmniejszenie usuwa tę dodatkową przestrzeń, ale rzeczywista wysokość pozostaje większa niż 20 punktów, ponieważ tekst i marginesy komórek wymagają więcej miejsca. Same zmniejszenie minimalnej wartości nie może wymusić, aby wiersz był niższy niż przestrzeń wymagana przez jego treść.

Kilka czynników wpływa na rzeczywistą wysokość:

- **Tekst i rozmiar czcionki:** dłuższy tekst, wymuszone podziały wierszy lub większa czcionka mogą wymagać więcej miejsca w pionie.
- **Zawijanie i szerokość kolumny:** przy włączonym zawijaniu węższa [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) może generować więcej wierszy. Szersza kolumna może zredukować wymaganą pionowo przestrzeń.
- **Marginesy komórek:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) i [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) dodają przestrzeń w pionie. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) i [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) zmniejszają szerokość dostępną dla tekstu i mogą powodować dodatkowe zawijanie.

Dla tej tabeli bez scalonych komórek komórka wymagająca najwięcej pionowej przestrzeni określa limit dolny całego wiersza wyznaczany treścią. Aby skrócić wiersz, może być konieczne skrócenie tekstu, zmniejszenie rozmiaru czcionki lub marginesów, albo poszerzenie kolumny.

Poniższe obrazy przedstawiają tę samą tabelę w tej samej skali. W tym uruchomieniu rzeczywiste wysokości wyniosły 70, 100 i 55,2 punktu: ostatni wiersz pozostał wyższy niż jego minimalna wartość 20 punktów. Dokładne pomiary tekstu mogą się różnić w zależności od dostępnych czcionek w twoim środowisku. Pobierz zapisane wyniki: [increased minimum](row-height-increased.pptx) i [decreased minimum](row-height-decreased.pptx).

| Oryginalny: minimalny 70 pt, rzeczywisty 70 pt | Zwiększony: minimalny 100 pt, rzeczywisty 100 pt | Zmniejszony: minimalny 20 pt, rzeczywisty 55.2 pt |
| --- | --- | --- |
| ![Oryginalna tabela z pierwszym wierszem o wysokości 70 punktów.](row-height-before.png) | ![Tabela po zwiększeniu minimalnej wysokości pierwszego wiersza do 100 punktów.](row-height-increased.png) | ![Tabela po zmniejszeniu minimalnej wysokości pierwszego wiersza do 20 punktów; zawinięty tekst utrzymuje wiersz wyższym niż minimum.](row-height-decreased.png) |

## **Ustaw pierwszy wiersz jako nagłówek**

Użyj właściwości [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) aby oznaczyć pierwszy wiersz jako nagłówek. Jego wygląd zależy od stylu tabeli zastosowanego do tabeli.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Uzyskaj dostęp do tabeli przechowywanej jako pierwszy kształt na slajdzie.
4. Włącz formatowanie nagłówka dla jej pierwszego wiersza.
5. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie. Włącza formatowanie nagłówka dla pierwszego wiersza i zapisuje `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Klonuj wiersz lub kolumnę tabeli**

Klonuj wiersze lub kolumny, aby ponownie wykorzystać ich zawartość i formatowanie. Możesz dodać kopię na koniec tabeli lub wstawić ją w określone miejsce.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę metodą [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Sklonuj wymagane wiersze.
6. Sklonuj wymagane kolumny.
7. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `Test.pptx` z co najmniej jednym slajdem. Tworzy tabelę z trzema kolumnami i pięcioma wierszami, z wymiarami podanymi w punktach. Dodaje kopie pierwszego wiersza i kolumny na końcu, a następnie wstawia kopie drugiego wiersza i kolumny pod indeksem 3 (czwarte miejsce). Wynikowa tabela ma siedem wierszy i pięć kolumn. Argument `false` wyłącza klonowanie do sąsiadujących scalonych wierszy lub kolumn; ta tabela nie posiada scalonych komórek.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Usuń wiersz lub kolumnę z tabeli**

Usuń wiersze lub kolumny, które nie są już potrzebne w tabeli. Usunięcie elementu przesuwa indeksy kolejnych wierszy lub kolumn.

1. Utwórz prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę metodą [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Usuń drugi wiersz i drugą kolumnę.
6. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 3x3 i usuwa wiersz oraz kolumnę o indeksie 1, pozostawiając tabelę 2x2 w pliku `TestTable_out.pptx`. Wymiary podane są w punktach. Argument `false` wyłącza usuwanie sąsiadujących scalonych wierszy lub kolumn; ta tabela nie posiada scalonych komórek.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

Zastosuj formatowanie tekstu do całego wiersza, aby zachować spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Ustaw [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) dla pierwszego wiersza.
4. Ustaw [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) i [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) dla pierwszego wiersza.
5. Ustaw [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) dla drugiego wiersza.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie i przynajmniej dwoma wierszami. Nakłada tekst 25‑punktowy, wyrównanie do prawej oraz prawy margines akapitu 20 punktów na pierwszym wierszu, a następnie ustawia pionowy tekst w drugim wierszu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

Zastosuj formatowanie tekstu do całej kolumny, aby zachować spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Ustaw [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) dla pierwszej kolumny.
4. Ustaw [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) i [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) dla pierwszej kolumny.
5. Ustaw [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) dla drugiej kolumny.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie i przynajmniej dwoma kolumnami. Nakłada tekst 25‑punktowy, wyrównanie do prawej oraz prawy margines akapitu 20 punktów na pierwszej kolumnie, a następnie ustawia pionowy tekst w drugiej kolumnie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Pobierz właściwości stylu tabeli**

Użyj właściwości [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) aby pobrać zastosowany wstępny styl tabeli i ponownie użyć go w innej tabeli. Dzięki temu identyfikujesz preset zamiast indywidualnych nadpisań formatowania komórek.

Przykład tworzy tabelę, stosuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), a następnie odczytuje preset. Wypisuje `DarkStyle1` i zapisuje tabelę w pliku `table.pptx`.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy mogę zastosować motywy/stylizacje PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/mistrza i nadal możesz nadpisać wypełnienia, obramowania i kolory tekstu ponad tym motywem.

**Czy mogę sortować wiersze tabeli jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj dane w pamięci najpierw, a potem ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (prążkowane) kolumny, zachowując jednocześnie niestandardowe kolory w określonych komórkach?**

Tak. Włącz paskowane kolumny, a potem nadpisz konkretne komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.