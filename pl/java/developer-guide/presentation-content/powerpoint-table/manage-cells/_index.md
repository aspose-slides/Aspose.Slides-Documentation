---
title: Zarządzanie komórkami tabeli w prezentacjach przy użyciu Javy
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/java/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Bezproblemowo zarządzaj komórkami tabeli w programie PowerPoint przy użyciu Aspose.Slides dla Javy. Opanuj szybki dostęp, modyfikację i stylizację komórek, aby uzyskać płynną automatyzację slajdów."
---
## **Przegląd**

Aspose.Slides pozwala na dostęp i modyfikację komórek tabeli w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabeli, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podzieleniu, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek przy użyciu właściwości komórek oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

## **Identyfikacja scalonej komórki tabeli**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Pobierz tabelę z pierwszego slajdu.
3. Iteruj przez wiersze i kolumny tabeli, aby znaleźć scalone komórki.
4. Wydrukuj komunikat, gdy zostaną znalezione scalone komórki.

Ten kod Java pokazuje, jak zidentyfikować scalone komórki tabeli w prezentacji:

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
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu przy użyciu metody [addTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Iteruj przez każdą komórkę, aby wyczyścić górne, dolne, prawe i lewe obramowania.
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

    // Zapisuje plik PPTX na dysk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeracja w scalonych komórkach**
Jeśli scalimy 2 pary komórek (1, 1) x (2, 1) i (1, 2) x (2, 2), powstała tabela będzie numerowana. Ten kod Java demonstruje proces:

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

    // Scala komórki (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Scala komórki (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Następnie scalamy dalej komórki, łącząc (1, 1) i (1, 2). Wynikiem jest tabela zawierająca dużą scaloną komórkę w jej centrum:

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

    // Scala komórki (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Scala komórki (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Scala komórki (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Zapisuje plik PPTX na dysk
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeracja w podzielonej komórce**
W poprzednich przykładach, gdy komórki tabeli były scalane, numeracja lub system numeracji w innych komórkach nie zmienił się. 

Tym razem bierzemy zwykłą tabelę (tabelę bez scalonych komórek) i próbujemy podzielić komórkę (1,1), aby uzyskać specjalną tabelę. Możesz zwrócić uwagę na numerację tej tabeli, która może wydawać się dziwna. Jednak tak Microsoft PowerPoint numeruje komórki tabeli i Aspose.Slides robi to samo.

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

    // Scala komórki (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Scala komórki (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Dzieli komórkę (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    //Zapisuje plik PPTX na dysk
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

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu przy użyciu metody [AddTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Utwórz obiekt `Images`, aby przechowywać plik obrazu.
7. Dodaj obraz `IImage` do obiektu `IPPImage`.
8. Ustaw `FillFormat` dla komórki tabeli na `Picture`.
9. Dodaj obraz do pierwszej komórki tabeli.
10. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod Java pokazuje, jak umieścić obraz wewnątrz komórki tabeli podczas tworzenia tabeli:

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

    // Zapisuje plik PPTX na dysk
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę ustawić różne grubości linii i style dla różnych stron jednej komórki?**

Tak. Obramowania [górne](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellformat/#getBorderTop--)/[dolne](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellformat/#getBorderBottom--)/[lewe](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellformat/#getBorderLeft--)/[prawe](https://reference.aspose.com/slides/pl/java/com.aspose.slides/cellformat/#getBorderRight--) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić. Wynika to logicznie z kontrolowania obramowań po stronie dla komórki, jak pokazano w artykule.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [trybu wypełniania](https://reference.aspose.com/slides/pl/java/com.aspose.slides/picturefillmode/) (rozciąganie/kafelkowanie). przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane. W artykule wymieniono tryby wyświetlania obrazu w komórce.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/java/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/pl/java/com.aspose.slides/portion/) (runs) z niezależnym formatowaniem — rodzina czcionki, styl, rozmiar i kolor.