---
title: Zarządzanie komórkami tabel w prezentacjach na Androidzie
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/androidjava/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Łatwo zarządzaj komórkami tabel w PowerPoint przy użyciu Aspose.Slides dla Androida w Javie. Opanuj szybki dostęp, modyfikację i stylizację komórek dla płynnej automatyzacji slajdów."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować połączone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale komórek, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez właściwości komórek oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

## **Identyfikacja połączonej komórki tabeli**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Pobierz tabelę z pierwszego slajdu.
3. Iteruj przez wiersze i kolumny tabeli, aby znaleźć połączone komórki.
4. Wyświetl komunikat, gdy zostaną znalezione połączone komórki.

Ten kod Java pokazuje, jak zidentyfikować połączone komórki tabel w prezentacji:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // zakładając, że Slide#0.Shape#0 jest tabelą
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie obramowań komórek tabeli**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Iteruj przez każdą komórkę, aby usunąć górne, dolne, prawe i lewe obramowanie.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak usunąć obramowania z komórek tabeli:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Definiuje kolumny z szerokościami i wiersze z wysokościami
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Dodaje kształt tabeli do slajdu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ustawia format obramowania dla każdej komórki
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Zapisuje plik PPTX na dysku
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeracja w połączonych komórkach**
Jeśli połączymy 2 pary komórek (1, 1) x (2, 1) oraz (1, 2) x (2, 2), wynikowa tabela będzie numerowana. Ten kod Java demonstruje proces:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Dodaje kształt tabeli do slajdu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ustawia format obramowania dla każdej komórki
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Łączy komórki (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Łączy komórki (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Następnie łączymy dalej komórki, scalając (1, 1) i (1, 2). Wynikiem jest tabela zawierająca dużą połączoną komórkę w jej centrum:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Dodaje kształt tabeli do slajdu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ustawia format obramowania dla każdej komórki
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Łączy komórki (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Łączy komórki (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Łączy komórki (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
	
//Zapisuje plik PPTX na dysku
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeracja w podzielonej komórce**
W poprzednich przykładach, gdy komórki tabeli były łączone, numeracja lub system numeracji w pozostałych komórkach nie zmieniały się.

Tym razem bierzemy zwykłą tabelę (tabelę bez połączonych komórek), a następnie próbujemy podzielić komórkę (1,1), aby uzyskać specjalną tabelę. Może warto zwrócić uwagę na numerację tej tabeli, która może wydawać się dziwna. Jednak tak właśnie Microsoft PowerPoint numeruje komórki tabel, a Aspose.Slides postępuje tak samo.

Ten kod Java demonstruje opisany proces:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Dodaje kształt tabeli do slajdu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ustawia format obramowania dla każdej komórki
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Łączy komórki (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Łączy komórki (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Dzieli komórkę (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

	// Zapisuje plik PPTX na dysku
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zmiana koloru tła komórki tabeli**

Ten kod Java pokazuje, jak zmienić kolor tła komórki tabeli:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // utwórz nową tabelę
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // ustaw kolor tła dla komórki
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Dodanie obrazu wewnątrz komórki tabeli**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu za pomocą metody [AddTable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Utwórz obiekt `Images`, aby przechować plik obrazu.
7. Dodaj obraz `IImage` do obiektu `IPPImage`.
8. Ustaw `FillFormat` dla komórki tabeli na `Picture`.
9. Dodaj obraz do pierwszej komórki tabeli.
10. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod Java pokazuje, jak umieścić obraz wewnątrz komórki tabeli przy tworzeniu tabeli:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide islide = pres.getSlides().get_Item(0);

    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Dodaje kształt tabeli do slajdu
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Tworzy obiekt IPPImage przy użyciu pliku obrazu
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Dodaje obraz do pierwszej komórki tabeli
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Zapisuje plik PPTX na dysku
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę ustawić różne grubości linii i style dla różnych krawędzi jednej komórki?**

Tak. Obrzeża [górne](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[dolne](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[lewe](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[prawe](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/cellformat/#getBorderRight--) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić. Wynika to logicznie z kontroli obramowań po stronie dla komórki, przedstawionej w artykule.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [trybu wypełnienia](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/picturefillmode/). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane. Artykuł wspomina o trybach wyświetlania obrazu w komórce.

**Czy mogę przypisać hiperłączę do całej zawartości komórki?**

[Hyperlinks](/slides/pl/androidjava/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/) (runy) z niezależnym formatowaniem — rodzinę czcionki, styl, rozmiar i kolor.