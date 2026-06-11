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
description: "Łatwo zarządzaj komórkami tabel w PowerPoint przy użyciu Aspose.Slides dla .NET. Opanuj szybki dostęp, modyfikację i stylizację komórek, aby zapewnić płynną automatyzację slajdów."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podzieleniu, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez właściwości komórek i zapisać zmodyfikowaną prezentację jako plik PPTX.

## **Zidentyfikuj scaloną komórkę tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Pobierz tabelę z pierwszego slajdu. 
3. Iteruj przez wiersze i kolumny tabeli, aby znaleźć scalone komórki.
4. Wypisz komunikat, gdy zostaną znalezione scalone komórki.

Ten kod C# pokazuje, jak zidentyfikować scalone komórki tabeli w prezentacji:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // zakładając że Slide#0.Shape#0 jest tabelą
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Usuń obramowania komórek tabeli**
1. Utwórz instancję klasy `Presentation`.
2. Pobierz odniesienie do slajdu za pomocą jego indeksu. 
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu przy użyciu metody `AddTable`.
6. Iteruj przez każdą komórkę, aby usunąć górne, dolne, prawe i lewe obramowania.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# pokazuje, jak usunąć obramowania z komórek tabeli:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation pres = new Presentation())
{
   // Uzyskuje dostęp do pierwszego slajdu
    Slide sld = (Slide)pres.Slides[0];

    // Definiuje kolumny z szerokościami i wiersze z wysokościami
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Dodaje kształt tabeli do slajdu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ustawia format obramowania dla każdej komórki
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Zapisuje plik PPTX na dysk
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Numeracja w scalonych komórkach**

Jeśli scalimy 2 pary komórek (1, 1) x (2, 1) oraz (1, 2) x (2, 2), wynikowa tabela będzie ponumerowana. Ten kod C# demonstruje ten proces:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation presentation = new Presentation())
{
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = presentation.Slides[0];

    // Definiuje kolumny z szerokościami i wiersze z wysokościami
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Dodaje kształt tabeli do slajdu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ustawia format obramowania dla każdej komórki
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

    // Scala komórki (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Scala komórki (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Następnie scalimy komórki dalej, scalając (1, 1) i (1, 2). Wynikiem jest tabela zawierająca dużą scaloną komórkę w centrum:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation presentation = new Presentation())
{
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide slide = presentation.Slides[0];

    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Dodaje kształt tabeli do slajdu
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ustawia format obramowania dla każdej komórki
    foreach (IRow row in table.Rows)
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

    // Scala komórki (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Scala komórki (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Scala komórki (1, 2) x (2, 2)
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Zapisuje plik PPTX na dysk
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Numeracja w podzielonej komórce**

W poprzednich przykładach, gdy komórki tabeli zostały scalone, numeracja lub system numeracji w pozostałych komórkach nie zmienił się. 

Tym razem bierzemy zwykłą tabelę (tabelę bez scalonych komórek), a następnie próbujemy podzielić komórkę (1,1), aby uzyskać specjalną tabelę. Warto zwrócić uwagę na numerację tej tabeli, która może wydawać się dziwna. Jednak tak Microsoft PowerPoint numeruje komórki tabeli i Aspose.Slides postępuje tak samo. 

Ten kod C# demonstruje opisany proces:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation presentation = new Presentation())
{
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide slide = presentation.Slides[0];

    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Dodaje kształt tabeli do slajdu
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Ustawia format obramowania dla każdej komórki
    foreach (IRow row in table.Rows)
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

    // Scala komórki (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Scala komórki (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Dzieli komórkę (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Zapisuje plik PPTX na dysk
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Zmień kolor tła komórki tabeli**

Ten kod C# pokazuje, jak zmienić kolor tła komórki tabeli:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // utwórz nową tabelę
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // ustaw kolor tła dla komórki
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Dodaj obraz wewnątrz komórki tabeli**

1. Utwórz instancję klasy `Presentation`.
2. Pobierz odniesienie do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu przy użyciu metody `AddTable`. 
6. Utwórz obiekt `Bitmap`, aby przechowywać plik obrazu.
7. Dodaj obraz bitmapowy do obiektu `IPPImage`.
8. Ustaw `FillFormat` dla komórki tabeli na `Picture`.
9. Dodaj obraz do pierwszej komórki tabeli.
10. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod C# pokazuje, jak umieścić obraz wewnątrz komórki tabeli podczas tworzenia tabeli:

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
using (Presentation presentation = new Presentation())
{
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide slide = presentation.Slides[0];

    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Dodaje kształt tabeli do slajdu
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Ładuje obraz z pliku i dodaje go do zasobów prezentacji
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Dodaje obraz do pierwszej komórki tabeli
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Zapisuje plik PPTX na dysk
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę ustawić różne grubości linii i style dla różnych stron jednej komórki?**

Tak. Obramowania [górne](https://reference.aspose.com/slides/pl/net/aspose.slides/cellformat/bordertop/)/[dolne](https://reference.aspose.com/slides/pl/net/aspose.slides/cellformat/borderbottom/)/[lewe](https://reference.aspose.com/slides/pl/net/aspose.slides/cellformat/borderleft/)/[prawe](https://reference.aspose.com/slides/pl/net/aspose.slides/cellformat/borderright/) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić. Wynika to logicznie z kontroli obramowania po stronie dla komórki opisanej w artykule.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tło komórki?**

Zachowanie zależy od [trybu wypełnienia](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillmode/) (rozciąganie/kafelkowanie). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane. W artykule wspomniano o trybach wyświetlania obrazu w komórce.

**Czy mogę przypisać hiperlink do całej zawartości komórki?**

[Hyperlinks](/slides/pl/net/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce link przypisuje się do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/pl/net/aspose.slides/portion/) (runy) z niezależnym formatowaniem — rodzinę czcionek, styl, rozmiar i kolor.