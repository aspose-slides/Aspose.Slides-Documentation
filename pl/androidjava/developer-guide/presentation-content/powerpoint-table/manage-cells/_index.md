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
description: "Zarządzaj komórkami tabel PowerPoint na Androidzie: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Aspose.Slides pozwala na dostęp i modyfikowanie komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podzieleniu, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórki poprzez właściwości komórki i zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych do dostępu do komórek tabel w kolejności `(column, row)`.

## **Zidentyfikuj scaloną komórkę tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje po wszystkich wierszach i kolumnach i używa [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) do identyfikacji komórek w scalonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), oraz początkowe współrzędne regionu, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) i [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Usuń obramowania komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) i dodaj tabelę do jej pierwszego slajdu za pomocą [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Szerokości kolumn, wysokości wierszy i pozycja tabeli są podawane w punktach. Przykład ustawia wszystkie cztery obramowania komórek na [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), czyniąc je niewidocznymi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Scal komórki tabeli**

Użyj [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument kontroluje, czy scalanie może obejmować komórki poza określonym zakresem; `false` utrzymuje scalanie w ramach tego zakresu.

Przykład tworzy tabelę 4‑na‑4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery centralne komórki od `(1, 1)` do `(2, 2)`. Powstała komórka zajmuje dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table.get_Item(1, 1)` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem nie ulegają zmianie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Podziel komórki tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę siatki i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides stosuje się do modelu siatki tabel PowerPointa.

Ten przykład tworzy tabelę 4‑na‑4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) na komórce `(1, 1)`. Połowa szerokości komórki 70 punktów jest przekazywana w celu utworzenia dwóch komórek o równej szerokości.

Po podziale obie połowy są dostępne jako `table.get_Item(1, 1)` i `table.get_Item(2, 1)`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przechodzą odpowiednio do kolumn 3 i 4. Indeksy wierszy pozostają niezmienione. Używaj tych zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Podziel scalone komórki według zakresu wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) do podzielenia wzdłuż istniejącej granicy wiersza lub [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) do podzielenia wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest względem scalonego regionu:

- Podział wiersza: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Podział kolumny: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Przykład zakłada, że prezentacja ma tabelę jako pierwszy kształt na pierwszym slajdzie, przy czym `(1, 2)` i `(1, 3)` są scalone pionowo. Rozpoczynając od dolnej pozycji, używa [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) i [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) aby zlokalizować początek i sprawdza oba zakresy. `splitByRowSpan(1)` następnie oddziela wiersze 2 i 3 dla nazw produktów. Dla poziomego scalenia dwóch kolumn, użyj `splitByColSpan(1)`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Pobierz powstałe komórki z tabeli po podziale.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz powstałe komórki po ich współrzędnych; tutaj obie mają zakres 1 i [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) wypisuje `false`. Większe regiony mogą pozostać częściowo scalone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw wymagane formatowanie tekstu explicite.

Zapisana prezentacja zawiera osobne komórki „Product A” i „Product B” z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) dla szczegółów.

## **Zmień kolor tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Używa [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) aby wybrać jednolite wypełnienie i ustawia kolor zwrócony przez [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj obraz wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) i dodaje go do kolekcji obrazów prezentacji przy pomocy [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Następnie przypisuje obraz do wypełnienia obrazem komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnić komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy podawane są w punktach. Załadowany obraz jest zwalniany w bloku `finally` po dodaniu go do prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę ustawić różne grubości linii i style dla różnych krawędzi jednej komórki?**

Tak. Obramowania [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) mają oddzielne właściwości, więc grubość i styl każdej krawędzi mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/androidjava/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (segmenty) z niezależnym formatowaniem — rodzinę czcionek, styl, rozmiar i kolor.