---
title: "Zarządzanie komórkami tabel w prezentacjach na Androidzie"
linktitle: "Zarządzaj komórkami"
type: docs
weight: 30
url: /pl/androidjava/manage-cells/
keywords:
- "komórka tabeli"
- "scalanie komórek"
- "usuwanie obramowania"
- "dzielenie komórki"
- "obraz w komórce"
- "kolor tła"
- "PowerPoint"
- "prezentacja"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Zarządzaj komórkami tabel PowerPoint na Androidzie: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy za pomocą Aspose.Slides dla Androida w języku Java."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach programu PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować połączone komórki tabel, usuwać obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale komórek, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórki za pomocą właściwości komórki oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych przy dostępie do komórek tabeli w kolejności `(column, row)`.

## **Identyfikowanie połączonej komórki tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje po wszystkich wierszach i kolumnach i używa [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) aby zidentyfikować komórki w połączonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), oraz początkowe współrzędne obszaru, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) i [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **Usuwanie obramowań komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) i dodaj tabelę do jej pierwszego slajdu za pomocą [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Szerokości kolumn, wysokości wierszy oraz pozycja tabeli są określone w punktach. Przykład ustawia wszystkie cztery obramowania komórek na [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), czyniąc je niewidocznymi.

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

## **Dodawanie przekątnych obramowań komórek**

Użyj [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) aby narysować linię od lewego górnego rogu do prawego dolnego, oraz [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) aby narysować linię od lewego dolnego rogu do prawego górnego. Przekątna może oznaczać nagłówek narożny; obie przekątne mogą tworzyć X, aby oznaczyć, że komórka nie ma zastosowania.

Każda przekątna jest obiektem [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/). W jej [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) użyj [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) aby wybrać [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) i wybrać kolor przy pomocy [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--). Ustaw szerokość linii w punktach za pomocą [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-).

Przykład tworzy trzy komórki w jednym wierszu: czerwoną przekątną w dół, niebieską przekątną w górę oraz obie przekątne. Pozostawia niezmienione górne, dolne, lewe i prawe obramowania komórek.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przekątna jest właściwością formatowania, a nie podziałem komórki. Każda komórka zachowuje pojedynczą ramkę tekstową, dostępną poprzez [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--); regiony po obu stronach przekątnej nie mogą być edytowane niezależnie.

The saved table, rendered in Microsoft PowerPoint:

![Trzy komórki tabeli pokazujące czerwoną przekątną od lewego górnego do prawego dolnego, niebieską przekątną od lewego dolnego do prawego górnego oraz obie przekątne tworzące X.](diagonal-cell-borders.png)

*Od lewej do prawej: przekątna w dół (czerwona, 3 pt), przekątna w górę (niebieska, 5 pt) oraz obie przekątne.*

## **Scalanie komórek tabeli**

Użyj [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument kontroluje, czy scalenie może obejmować komórki poza określonym zakresem; `false` utrzymuje scalenie w obrębie tego zakresu.

Przykład tworzy tabelę 4 × 4 o kolumnach i wierszach o szerokości 70 punktów, a następnie scala cztery środkowe komórki od `(1, 1)` do `(2, 2)`. Powstała komórka zajmuje dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do treści lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table.get_Item(1, 1)` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem nie zmieniają się.

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

## **Dzielenie komórek tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Dzielenie komórki może wprowadzić nową kolumnę siatki i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides podąża za modelem siatki tabel PowerPoint.

Ten przykład tworzy tabelę 4 × 4 o kolumnach i wierszach o szerokości 70 punktów i wywołuje [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) na komórce `(1, 1)`. Połowa szerokości 70‑punktowej komórki jest przekazywana w celu utworzenia dwóch komórek o równej szerokości.

Po tym podziale dwie połowy są dostępne jako `table.get_Item(1, 1)` i `table.get_Item(2, 1)`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przechodzą odpowiednio do kolumn 3 i 4. Indeksy wierszy pozostają niezmienione. Użyj zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

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

<!-- visual-explanation:manage-cells:start -->
[![Niepołączona komórka o szerokości 70 punktów dzieli się na dwie komórki po 35 punktów, dodając piątą kolumnę siatki i przesuwając indeksy po jej prawej stronie.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Podział szerokości dotyczy komórki (1, 1), używając zerowych indeksów (column, row). Inne wiersze zachowują komórkę rozciągającą się na oba nowe pozycje kolumn.*
<!-- visual-explanation:manage-cells:end -->

### **Dzielenie połączonych komórek według zakresu wiersza lub kolumny**

Aby przygotować połączone komórki szablonu do wypełnienia danymi, użyj [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) aby podzielić wzdłuż istniejącej granicy wiersza lub [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) aby podzielić wzdłuż granicy kolumny.

Argument `index` liczy wiersze w części górnej lub kolumny w części lewej podziału; jest względny względem połączonego obszaru:
- Podział wiersza: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Podział kolumny: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Przykład zakłada, że prezentacja ma tabelę jako pierwszy kształt na pierwszym slajdzie, przy czym `(1, 2)` i `(1, 3)` są połączone pionowo. Rozpoczynając od niższej pozycji, używa [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) i [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) aby ustalić punkt początkowy i sprawdza oba zakresy. `splitByRowSpan(1)` oddziela następnie wiersze 2 i 3 dla nazw produktów. Dla poziomego połączenia dwóch kolumn użyj `splitByColSpan(1)`.

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

        // Pobierz wynikowe komórki z tabeli po podziale.
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

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz wynikowe komórki według ich współrzędnych; tutaj obie mają zakres 1 i [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) zwraca `false`. Większe obszary mogą pozostać częściowo połączone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw ewentualne formatowanie tekstu w sposób jawny.

Zapisana prezentacja zawiera oddzielne komórki „Product A” i „Product B” z zachowanym formatowaniem szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) po szczegóły.

### **Dzielenie komórki na określoną wysokość**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) przyjmuje wysokość górnej części w punktach. [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) przyjmuje liczbę istniejących wierszy siatki w części górnej. Aby wycentrować komórkę o wysokości 40 punktów w prawej kolumnie, odejmij 40 od rzeczywistej wysokości komórki i podziel pozostałą przestrzeń równo powyżej i poniżej niej.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pierwszy podział dodaje wiersz siatki i pozostawia dolne 90 punktów w komórce `(1, 1)`. Drugi podział dzieli tę komórkę na środkową o wysokości 40 punktów oraz dolną o wysokości 50 punktów. Prawa kolumna ma teraz trzy komórki o wysokościach 50, 40 i 50 punktów od góry do dołu. Lewa komórka rozciąga się na wszystkie trzy wiersze i zachowuje pierwotną wysokość 140 punktów.

![Lewa komórka rozciąga się na pełną wysokość tabeli obok trzech komórek z napisem Middle w środku.](split-by-height.png)

## **Zmiana koloru tła komórki tabeli**

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

## **Dodanie obrazu wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) i dodaje go do kolekcji obrazów prezentacji przy pomocy [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Następnie przypisuje obraz do wypełnienia obrazem komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnił komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy są podane w punktach. Załadowany obraz jest zwalniany w bloku `finally` po dodaniu go do prezentacji.

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

**Czy mogę ustawić różne grubości i style linii dla poszczególnych stron jednej komórki?**

Tak. Obrzeża [górne](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[dolne](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[lewe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[prawe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [trybu wypełnienia](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/). Przy rozciąganiu obraz dostosowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/androidjava/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (runy) z niezależnym formatowaniem — rodzinę czcionki, styl, rozmiar i kolor.