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
description: "Twórz i edytuj tabele w slajdach PowerPoint za pomocą Aspose.Slides dla .NET. Odkryj proste przykłady kodu C#, aby usprawnić swoje procesy pracy z tabelami."
---
## **Wprowadzenie**

Tabela w programie PowerPoint jest efektywnym sposobem wyświetlania i przedstawiania informacji. Informacje w siatce komórek (układanych w wiersze i kolumny) są proste i łatwe do zrozumienia.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/net/aspose.slides/table/) , interfejs [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) , klasę [Cell](https://reference.aspose.com/slides/pl/net/aspose.slides/cell/) , interfejs [ICell](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/) oraz inne typy, które pozwalają tworzyć, aktualizować i zarządzać tabelami we wszystkich rodzajach prezentacji. 

## **Utworzenie tabeli od podstaw**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj odniesienie do slajdu poprzez jego indeks. 
3. Zdefiniuj tablicę `columnWidth`.
4. Zdefiniuj tablicę `rowHeight`.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) do slajdu za pomocą metody [AddTable](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addtable/) .
6. Iteruj po każdym [ICell](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/) , aby zastosować formatowanie górnej, dolnej, prawej i lewej krawędzi.
7. Scal pierwsze dwie komórki pierwszego wiersza tabeli. 
8. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) komórki [ICell](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/) .
9. Dodaj trochę tekstu do [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) .
10. Zapisz zmodyfikowaną prezentację.

Ten kod C# pokazuje, jak utworzyć tabelę w prezentacji:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();

// Uzyskuje dostęp do pierwszego slajdu
ISlide sld = pres.Slides[0];

// Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Dodaje kształt tabeli do slajdu
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Ustawia formatowanie obramowania dla każdej komórki
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Łączy komórki 1 i 2 w pierwszym wierszu
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Dodaje tekst do połączonej komórki
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Zapisuje prezentację na dysku
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli numeracja komórek jest prosta i zaczyna się od zera. Pierwsza komórka w tabeli ma indeks 0,0 (kolumna 0, wiersz 0). 

Na przykład, komórki w tabeli o 4 kolumnach i 4 wierszach są numerowane w ten sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten kod C# pokazuje, jak określić numerację komórek w tabeli:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation pres = new Presentation())
{

    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.Slides[0];

    // Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Dodaje kształt tabeli do slajdu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ustawia formatowanie obramowania dla każdej komórki
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Zapisuje prezentację na dysku
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Dostęp do istniejącej tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj odniesienie do slajdu zawierającego tabelę poprzez jego indeks. 
3. Utwórz obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) i ustaw go na null.
4. Iteruj po wszystkich obiektach [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) , aż znajdziesz tabelę.

   Jeśli podejrzewasz, że slajd, z którym pracujesz, zawiera jedną tabelę, możesz po prostu sprawdzić wszystkie kształty, które zawiera. Gdy kształt zostanie zidentyfikowany jako tabela, możesz rzutować go na obiekt [Table](https://reference.aspose.com/slides/pl/net/aspose.slides/table/) . Jednak jeśli slajd zawiera kilka tabel, lepiej jest wyszukać potrzebną tabelę przy użyciu jej [AlternativeText](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/alternativetext/) .

5. Użyj obiektu [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) , aby pracować z tabelą. W poniższym przykładzie dodaliśmy nowy wiersz do tabeli.
6. Zapisz zmodyfikowaną prezentację.

Ten kod C# pokazuje, jak uzyskać dostęp i pracować z istniejącą tabelą:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.Slides[0];

    // Inicjalizuje zmienną tbl jako null
    ITable tbl = null;

    // Iteruje po kształtach i ustawia referencję do znalezionej tabeli
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Ustawia tekst dla pierwszej kolumny drugiego wiersza
    tbl[0, 1].TextFrame.Text = "New";

    // Zapisuje zmodyfikowaną prezentację na dysk
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Wyrównanie tekstu w tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj odniesienie do slajdu poprzez jego indeks. 
3. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) do slajdu. 
4. Uzyskaj dostęp do obiektu [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) z tabeli. 
5. Uzyskaj dostęp do [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) z [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) .
6. Wyrównaj tekst pionowo.
7. Zapisz zmodyfikowaną prezentację.

Ten kod C# pokazuje, jak wyrównać tekst w tabeli:

```c#
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu poprzez jego indeks. 
3. Uzyskaj dostęp do obiektu [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) ze slajdu.
4. Ustaw [FontHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/fontheight/) dla tekstu. 
5. Ustaw [Alignment](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/alignment/) i [MarginRight](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/marginright/) . 
6. Ustaw [TextVerticalType](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat/textverticaltype/) .
7. Zapisz zmodyfikowaną prezentację. 

Ten kod C# pokazuje, jak zastosować wybrane opcje formatowania do tekstu w tabeli:

```c#
// Tworzy instancję klasy Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą

// Ustawia wysokość czcionki komórek tabeli
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Ustawia wyrównanie tekstu komórek tabeli i prawy margines w jednej instrukcji
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Ustawia pionowy typ tekstu komórek tabeli
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Pobranie właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można było użyć tych danych w innej tabeli lub w innym miejscu. Ten kod C# pokazuje, jak uzyskać właściwości stylu z wstępnie zdefiniowanego stylu tabeli: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // zmień domyślny zestaw stylu
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Zablokowanie proporcji tabeli**

Proporcje geometrycznego kształtu to stosunek jego wymiarów w różnych wymiarach. Aspose.Slides udostępnia właściwość `AspectRatioLocked`, która umożliwia zablokowanie ustawienia proporcji dla tabel i innych kształtów. 

Ten kod C# pokazuje, jak zablokować proporcje tabeli:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // odwróć

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę włączyć kierunek czytania od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia właściwość [RightToLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/table/righttoleft/) , a akapity mają [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraphformat/righttoleft/) . Użycie obu zapewnia prawidłowy kolejność RTL i renderowanie wewnątrz komórek.

**Jak mogę uniemożliwić użytkownikom przenoszenie lub zmianę rozmiaru tabeli w finalnym pliku?**

Użyj [shape locks](/slides/pl/net/applying-protection-to-presentation/) , aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady obowiązują także dla tabel.

**Czy wstawianie obrazu jako tła wewnątrz komórki jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/) , aby wypełnić komórkę obrazem; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).