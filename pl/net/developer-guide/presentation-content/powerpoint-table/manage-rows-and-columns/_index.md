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
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy użyciu Aspose.Slides dla .NET i przyspiesz edycję prezentacji oraz aktualizację danych."
---
## **Wstęp**

Aby umożliwić zarządzanie wierszami i kolumnami tabeli w prezentacji PowerPoint, Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/net/aspose.slides/table/) , interfejs [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) oraz wiele innych typów. 

## **Ustaw pierwszy wiersz jako nagłówek**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i załaduj prezentację. 
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) i ustaw go na null.
4. Iteruj po wszystkich obiektach [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) , aby znaleźć odpowiednią tabelę. 
5. Ustaw pierwszy wiersz tabeli jako jej nagłówek. 

Ten kod C# pokazuje, jak ustawić pierwszy wiersz tabeli jako jej nagłówek:

```c#
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("table.pptx");

// Uzyskuje dostęp do pierwszego slajdu
ISlide sld = pres.Slides[0];

// Inicjalizuje zmienną TableEx jako null
ITable tbl = null;

// Iteruje po kształtach i ustawia referencję do tabeli
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Ustawia pierwszy wiersz tabeli jako nagłówek
tbl.FirstRow = true;

// Zapisuje prezentację na dysk
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Klonowanie wiersza lub kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i załaduj prezentację, 
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Zdefiniuj tablicę `columnWidth`.
4. Zdefiniuj tablicę `rowHeight`.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) do slajdu przy użyciu metody [AddTable](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addtable/) .
6. Sklonuj wiersz tabeli.
7. Sklonuj kolumnę tabeli.
8. Zapisz zmodyfikowaną prezentację.

Ten kod C# pokazuje, jak sklonować wiersz lub kolumnę tabeli PowerPoint:

```c#
 // Tworzy instancję klasy Presentation
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = presentation.Slides[0];

    // Definiuje kolumny z szerokościami i wiersze z wysokościami
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Dodaje kształt tabeli do slajdu
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Dodaje tekst do wiersza 1 komórka 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Dodaje tekst do wiersza 1 komórka 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Klonuje wiersz 1 na końcu tabeli
    table.Rows.AddClone(table.Rows[0], false);

    // Dodaje tekst do wiersza 2 komórka 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Dodaje tekst do wiersza 2 komórka 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Klonuje wiersz 2 jako czwarty wiersz tabeli
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Klonuje pierwszą kolumnę na końcu
    table.Columns.AddClone(table.Columns[0], false);

    // Klonuje drugą kolumnę na indeksie 4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Zapisuje prezentację na dysk
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Usuwanie wiersza lub kolumny z tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i załaduj prezentację, 
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Zdefiniuj tablicę `columnWidth`.
4. Zdefiniuj tablicę `rowHeight`.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) do slajdu przy użyciu metody [AddTable](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addtable/) .
6. Usuń wiersz tabeli.
7. Usuń kolumnę tabeli.
8. Zapisz zmodyfikowaną prezentację. 

Ten kod C# pokazuje, jak usunąć wiersz lub kolumnę z tabeli:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i załaduj prezentację, 
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Uzyskaj dostęp do odpowiedniego obiektu [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) ze slajdu. 
4. Ustaw [FontHeight] komórek pierwszego wiersza. 
5. Ustaw [Alignment] i [MarginRight] komórek pierwszego wiersza. 
6. Ustaw [TextVerticalType] komórek drugiego wiersza.
7. Zapisz zmodyfikowaną prezentację.

Ten kod C# demonstruje tę operację.

```c#
// Tworzy instancję klasy Presentation
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą

// Ustawia wysokość czcionki komórek pierwszego wiersza
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Ustawia wyrównanie tekstu i prawy margines komórek pierwszego wiersza
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Ustawia pionowy typ tekstu komórek drugiego wiersza
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Zapisuje prezentację na dysk
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i załaduj prezentację, 
2. Uzyskaj referencję do slajdu za pomocą jego indeksu. 
3. Uzyskaj dostęp do odpowiedniego obiektu [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) ze slajdu. 
4. Ustaw [FontHeight] komórek pierwszej kolumny. 
5. Ustaw [Alignment] i [MarginRight] komórek pierwszej kolumny. 
6. Ustaw [TextVerticalType] komórek drugiej kolumny.
7. Zapisz zmodyfikowaną prezentację. 

Ten kod C# demonstruje tę operację: 

```c#
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą

// Ustawia wysokość czcionki komórek pierwszej kolumny
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Ustawia wyrównanie tekstu i prawy margines komórek pierwszej kolumny w jednym wywołaniu
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Ustawia pionowy typ tekstu komórek drugiej kolumny
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Zapisuje prezentację na dysk
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Pobieranie właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można było użyć tych danych w innej tabeli lub w innym miejscu. Ten kod C# pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // zmień domyślny preset stylu
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę zastosować motywy/styl PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/mastera i nadal możesz nadpisać wypełnienia, obramowania oraz kolory tekstu ponad tym motywem.

**Czy mogę sortować wiersze tabeli jak w Excelu?**

Nie, tabele Aspose.Slides nie posiadają wbudowanego sortowania ani filtrów. Posortuj dane w pamięci najpierw, a następnie ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (z paskami) kolumny, zachowując jednocześnie niestandardowe kolory w określonych komórkach?**

Tak. Włącz paskowane kolumny, a następnie nadpisz konkretne komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.