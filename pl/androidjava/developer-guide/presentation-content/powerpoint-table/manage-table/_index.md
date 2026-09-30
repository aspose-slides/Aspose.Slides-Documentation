---
title: Zarządzanie tabelami w prezentacjach na Androidzie
linktitle: Zarządzaj tabelą
type: docs
weight: 10
url: /pl/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu Aspose.Slides dla Androida. Odkryj proste przykłady kodu Java, aby usprawnić przepływy pracy z tabelami."
---
## **Wprowadzenie**

Tabele w programie PowerPoint organizują informacje w wierszach i kolumnach, ułatwiając ich odczyt i porównywanie wartości.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) , interfejs [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) , klasę [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) , interfejs [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) oraz inne typy, które umożliwiają tworzenie, aktualizowanie i zarządzanie tabelami w prezentacjach.

## **Utworzenie tabeli od podstaw**

Utwórz tabelę, określając jej pozycję, szerokość kolumn i wysokość wierszy. Po dodaniu jej do slajdu możesz formatować obramowania komórek, scalać komórki i wstawiać tekst.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Zdefiniuj tablicę szerokości kolumn w punktach.
4. Zdefiniuj tablicę wysokości wierszy w punktach.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) do slajdu metodą [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Iteruj po każdej [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) , aby zastosować formatowanie do górnych, dolnych, prawych i lewych obramowań.
7. Połącz pierwsze dwie komórki pierwszego wiersza tabeli.
8. Uzyskaj dostęp do połączonej komórki za pomocą jej metody [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) .
9. Ustaw tekst w połączonej komórce.
10. Zapisz zmodyfikowaną prezentację.

Poniższy przykład tworzy tabelę z trzema kolumnami i pięcioma wierszami w punkcie (100, 50). Stosuje czerwone obramowania o szerokości 5 punktów, scala pierwsze dwie komórki w pierwszym wierszu i zapisuje wynik jako `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli indeksy komórek zaczynają się od zera i używają kolejności (kolumna, wiersz). Pierwsza komórka ma indeks (0, 0).

Na przykład, komórki w tabeli o 4 kolumnach i 4 wierszach są numerowane w ten sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten przykład tworzy powyższą tabelę 4 × 4, z szerokością kolumn i wysokością wierszy równą 70 punktów oraz czerwonymi obramowaniami komórek o szerokości 5 punktów. Współrzędne ilustrują indeksy komórek; przykład pozostawia komórki puste i zapisuje tabelę jako `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostęp do istniejącej tabeli**

Tabele są przechowywane w kolekcji kształtów slajdu. Przeglądaj kształty, aby znaleźć tabelę, a następnie użyj interfejsu [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) do odczytu lub aktualizacji jej komórek.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu zawierającego tabelę według jego indeksu.
3. Iteruj po obiektach [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) , zatrzymując się, gdy zostanie znaleziona tabela. Jeśli slajd zawiera kilka tabel, użyj [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) , aby zidentyfikować potrzebną.
4. Zaktualizuj tekst w docelowej komórce.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `UpdateExistingTable.pptx` i znajduje pierwszą tabelę na pierwszym slajdzie. Ustawia komórkę w kolumnie 0, wierszu 1 na `New` i zapisuje wynik jako `table1_out.pptx`. Wejście musi zawierać co najmniej jeden slajd, a pierwsza tabela na tym slajdzie musi mieć co najmniej jedną kolumnę i dwa wiersze.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Aby zmienić wysokość wiersza w istniejącej tabeli i zrozumieć, dlaczego jej rzeczywista wysokość może przekraczać żądaną minimalną, zobacz [Kontrola wysokości wiersza](/slides/pl/androidjava/manage-rows-and-columns/#control-row-height).

## **Znajdź komórkę, która posiada ramkę tekstową**

Gdy ogólny kod przetwarzający tekst otrzymuje [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) z tabeli, użyj metody [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) aby uzyskać właściciela – [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) . Dla ramki tekstowej komórki tabeli, [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) zwraca właściciela, a [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) zwraca `null`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne poprzez metodę tylko do odczytu [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) oraz [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) . Metoda [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) również zapewnia nawigację tylko do odczytu: zwraca właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `null` przed jej użyciem.

Dla pełnego przykładu, który identyfikuje właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, zobacz [Wyszukiwanie i zamiana tekstu](/slides/pl/androidjava/search-and-replace-text/) .

## **Wyrównanie tekstu w tabeli**

Możesz kontrolować pionowe zakotwiczenie i kierunek tekstu poszczególnych komórek tabeli. Przykład w tej sekcji centruje tekst w pierwszej komórce i obraca go o 270 stopni.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Dodaj obiekt [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) do slajdu.
4. Uzyskaj dostęp do obiektu [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) z tabeli.
5. Uzyskaj dostęp do pierwszego [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) i ustaw jego tekst oraz kolor.
6. Ustaw pionowe zakotwiczenie komórki i kierunek tekstu przy użyciu [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) oraz [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 4 × 4 o szerokości kolumn 120 punktów i wysokości wierszy 100 punktów. Formatuje tekst w komórce (0, 0), dodaje wartości do pozostałych komórek w pierwszym wierszu i zapisuje wynik jako `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

Użyj [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) , aby zastosować formatowanie tekstu we wszystkich komórkach tabeli. Jej przeciążenia przyjmują formatowanie fragmentu, akapitu i ramki tekstowej, dzięki czemu możesz ustawić te właściwości bez iteracji po poszczególnych komórkach.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu według jego indeksu.
3. Uzyskaj dostęp do obiektu [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ze slajdu.
4. Ustaw rozmiar czcionki przy użyciu [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) dla tekstu.
5. Ustaw wyrównanie akapitu oraz prawy margines przy użyciu [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) i [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. Ustaw kierunek tekstu przy użyciu [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `table.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Ustawia rozmiar czcionki na 25 punktów, wyrównuje akapity do prawej z prawym marginesem 20 punktów oraz ustawia tekst pionowo. Sformatowana prezentacja jest zapisana jako `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pobierz właściwości stylu tabeli**

Użyj [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) , aby odczytać presetowy styl tabeli i [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) , aby go przypisać. Ten przykład stosuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) do jednej tabeli, wypisuje wartość prese​tu i przypisuje ten sam preset do drugiej tabeli. Obie tabele są zapisane w `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zablokuj proporcje tabeli**

Proporcje tabeli to stosunek jej szerokości do wysokości. Użyj [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) , aby zablokować ten stosunek dla tabeli.

Poniższy przykład otwiera `pres.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Wypisuje aktualny stan blokady, włącza blokadę proporcji, wypisuje zaktualizowany stan (`true`) i zapisuje wynik jako `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę włączyć kierunek czytania od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) , a akapity mają [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) . Użycie obu zapewnia prawidłową kolejność RTL i renderowanie wewnątrz komórek.

**Jak mogę uniemożliwić użytkownikom przenoszenie lub zmianę rozmiaru tabeli w finalnym pliku?**

Użyj [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) , aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady dotyczą również tabel.

**Czy wstawianie obrazu wewnątrz komórki jako tła jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).