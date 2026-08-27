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
description: "Twórz i edytuj tabele w slajdach PowerPoint za pomocą Aspose.Slides dla .NET. Odkryj proste przykłady kodu C#, aby usprawnić przepływy pracy z tabelami."
---
## **Wprowadzenie**

Tabela w programie PowerPoint to wydajny sposób wyświetlania i prezentacji informacji. Informacje w siatce komórek (układanych w wiersze i kolumny) są proste i łatwe do zrozumienia.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/net/aspose.slides/table/), interfejs [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/), klasę [Cell](https://reference.aspose.com/slides/pl/net/aspose.slides/cell/), interfejs [ICell](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/) oraz inne typy, które pozwalają tworzyć, aktualizować i zarządzać tabelami w prezentacjach.

## **Utworzenie tabeli od podstaw**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Pobierz odniesienie do slajdu za pośrednictwem jego indeksu. 
3. Zdefiniuj tablicę `columnWidth`.
4. Zdefiniuj tablicę `rowHeight`.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) do slajdu przy użyciu metody [AddTable](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/addtable/) .
6. Przejdź przez każdy [ICell](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/) i zastosuj formatowanie krawędzi: górnej, dolnej, prawej i lewej.
7. Połącz pierwsze dwie komórki pierwszego wiersza tabeli. 
8. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) komórki [ICell](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/) . 
9. Dodaj tekst do [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) .
10. Zapisz zmodyfikowaną prezentację.

Ten kod C# pokazuje, jak utworzyć tabelę w prezentacji:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();

// Uzyskuje dostęp do pierwszego slajdu
ISlide sld = pres.Slides[0];

// Definiuje kolumny o określonych szerokościach oraz wiersze o określonych wysokościach
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Dodaje kształt tabeli do slajdu
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Ustawia formatowanie krawędzi dla każdej komórki
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
// Łączy komórki 1 i 2 pierwszego wiersza
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Dodaje tekst do połączonej komórki
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Zapisuje prezentację na dysku
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli numeracja komórek jest prosta i rozpoczyna się od zera. Pierwsza komórka tabeli ma indeks 0,0 (kolumna 0, wiersz 0). 

Na przykład, komórki w tabeli o 4 kolumnach i 4 wierszach są numerowane w ten sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten kod C# tworzy powyższą standardową tabelę 4 × 4 i ustawia formatowanie krawędzi dla każdej jej komórki:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

    // Ustawia formatowanie krawędzi dla każdej komórki
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
2. Pobierz odniesienie do slajdu zawierającego tabelę za pośrednictwem jego indeksu. 
3. Utwórz obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) i ustaw go na null.
4. Przejdź przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) aż zostanie znaleziona tabela.

   Jeśli podejrzewasz, że rozpatrywany slajd zawiera jedną tabelę, możesz po prostu sprawdzić wszystkie znajdujące się na nim kształty. Gdy kształt zostanie rozpoznany jako tabela, możesz rzutować go na obiekt [Table](https://reference.aspose.com/slides/pl/net/aspose.slides/table/) . Jeśli natomiast slajd zawiera kilka tabel, lepiej szukać potrzebnej tabeli po jej [AlternativeText](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/alternativetext/) .

5. Użyj obiektu [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) do pracy z tabelą. W poniższym przykładzie dodaliśmy nowy wiersz do tabeli.
6. Zapisz zmodyfikowaną prezentację.

Ten kod C# pokazuje, jak uzyskać dostęp i pracować z istniejącą tabelą:

```c#
using Aspose.Slides;

// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.Slides[0];

    // Inicjalizuje zmienną TableEx jako null
    ITable tbl = null;

    // Iteruje po kształtach i ustawia referencję do odnalezionej tabeli
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Ustawia tekst dla pierwszej kolumny drugiego wiersza
    tbl[0, 1].TextFrame.Text = "New";

    // Zapisuje zmodyfikowaną prezentację na dysk
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Znajdź komórkę, której własnością jest ramka tekstowa**

Gdy ogólny kod przetwarzania tekstu otrzyma obiekt [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) z tabeli, użyj właściwości [ITextFrame.ParentCell](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentcell/) aby pobrać należącą do niej [ICell](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/) . Dla ramki tekstowej w komórce tabeli, [ITextFrame.ParentCell](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentcell/) jest ustawiona, a [ITextFrame.ParentShape](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentshape/) ma wartość `null`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne za pośrednictwem właściwości tylko do odczytu [ICell.FirstColumnIndex](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/firstcolumnindex/) i [ICell.FirstRowIndex](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/firstrowindex/) . [ITextFrame.ParentCell](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentcell/) jest również tylko do odczytu: umożliwia nawigację do właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `null` przed jej użyciem.

Pełny przykład identyfikujący właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, znajduje się w artykule [Search and Replace Text](/slides/pl/net/search-and-replace-text/) .

## **Wyrównanie tekstu w tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Pobierz odniesienie do slajdu za pośrednictwem jego indeksu. 
3. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) do slajdu. 
4. Uzyskaj dostęp do obiektu [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) z tabeli. 
5. Uzyskaj dostęp do [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) w ramach [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) .
6. Wyrównaj tekst w pionie.
7. Zapisz zmodyfikowaną prezentację.

Ten kod C# pokazuje, jak wyrównać tekst w tabeli:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Tworzy instancję klasy Presentation
Presentation presentation = new Presentation();

// Pobiera pierwszy slajd 
ISlide slide = presentation.Slides[0];

// Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Dodaje kształt tabeli do slajdu
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Uzyskuje dostęp do ramki tekstowej
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Tworzy obiekt Paragraph dla ramki tekstowej
IParagraph paragraph = txtFrame.Paragraphs[0];

// Tworzy obiekt Portion dla akapitu
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Wyrównuje tekst pionowo
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Zapisuje prezentację na dysk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
2. Pobierz odniesienie do slajdu za pośrednictwem jego indeksu. 
3. Uzyskaj dostęp do obiektu [ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) ze slajdu.
4. Ustaw [FontHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/fontheight/) dla tekstu. 
5. Ustaw [Alignment](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/alignment/) i [MarginRight](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/marginright/) .
6. Ustaw [TextVerticalType](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat/textverticaltype/) .
7. Zapisz zmodyfikowaną prezentację. 

Ten kod C# pokazuje, jak zastosować wybrane opcje formatowania do tekstu w tabeli:

```c#
using Aspose.Slides;

// Tworzy instancję klasy Presentation
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą

// Ustawia wysokość czcionki komórek tabeli
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Ustawia wyrównanie tekstu komórek tabeli i prawy margines w jednym wywołaniu
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Ustawia typ pionowego rozmieszczenia tekstu w komórkach tabeli
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Pobierz właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można je było użyć w innej tabeli lub w innym miejscu. Ten kod C# pokazuje, jak uzyskać właściwości stylu z gotowego stylu tabeli: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // zmień domyślny preset stylu

    // Pobierz preset stylu tabeli.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Zastosuj pobrany preset stylu do innej tabeli.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Zablokuj proporcje tabeli**

Proporcje geometrycznego kształtu to stosunek jego wymiarów w różnych osiach. Aspose.Slides udostępnia właściwość `AspectRatioLocked`, aby pozwolić zablokować ustawienie proporcji dla tabel i innych kształtów. 

Ten kod C# pokazuje, jak zablokować proporcje tabeli:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Tak. Tabela udostępnia właściwość [RightToLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/table/righttoleft/), a akapity mają [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraphformat/righttoleft/). Użycie obu zapewnia prawidłowy porządek RTL oraz renderowanie w komórkach.

**Jak zapobiec przemieszczeniu lub zmianie rozmiaru tabeli przez użytkowników w ostatecznym pliku?**

Użyj [shape locks](/slides/pl/net/applying-protection-to-presentation/), aby wyłączyć przemieszczanie, zmianę rozmiaru, zaznaczanie itp. Te blokady dotyczą także tabel.

**Czy wstawianie obrazu jako tła w komórce jest obsługiwane?**

Tak. Można ustawić [picture fill](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).