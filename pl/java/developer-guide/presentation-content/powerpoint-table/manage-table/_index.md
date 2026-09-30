---
title: Zarządzanie tabelami prezentacji w Java
linktitle: Zarządzaj tabelą
type: docs
weight: 10
url: /pl/java/manage-table/
keywords:
- dodaj tabelę
- utwórz tabelę
- dostęp do tabeli
- proporcje
- wyrównanie tekstu
- formatowanie tekstu
- styl tabeli
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu Aspose.Slides dla Java. Odkryj proste przykłady kodu, aby usprawnić pracę z tabelami."
---
## **Wprowadzenie**

Tabele w PowerPoint organizują informacje w wierszach i kolumnach, co ułatwia ich odczyt i porównywanie wartości.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/), interfejs [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/), klasę [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/), interfejs [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) oraz inne typy, które umożliwiają tworzenie, aktualizację i zarządzanie tabelami w prezentacjach.

## **Utworzenie tabeli od podstaw**

Utwórz tabelę, określając jej pozycję, szerokość kolumn i wysokość wierszy. Po dodaniu jej do slajdu możesz sformatować obramowania komórek, scalić komórki i wstawić tekst.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu według jego indeksu.
3. Zdefiniuj tablicę szerokości kolumn w punktach.
4. Zdefiniuj tablicę wysokości wierszy w punktach.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Przejdź przez każdą [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) i zastosuj formatowanie górnego, dolnego, prawego i lewego obramowania.
7. Scal dwa pierwsze komórki pierwszego wiersza tabeli.
8. Uzyskaj dostęp do scalonej komórki za pomocą jej metody [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--).
9. Ustaw tekst w scalonej komórce.
10. Zapisz zmodyfikowaną prezentację.

Poniższy przykład tworzy tabelę o trzech kolumnach i pięciu wierszach w punkcie (100, 50). Zastosowano czerwone obramowania o szerokości 5 punktów, scalono dwie pierwsze komórki w pierwszym wierszu i zapisano wynik jako `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

W standardowej tabeli indeksy komórek rozpoczynają się od zera i używają kolejności (kolumna, wiersz). Pierwsza komórka ma indeks (0, 0).

Na przykład komórki w tabeli o 4 kolumnach i 4 wierszach są numerowane w ten sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten przykład tworzy tabelę 4 × 4 przedstawioną powyżej, z szerokością kolumn i wysokością wierszy po 70 punktów oraz czerwonymi obramowaniami o szerokości 5 punktów. Współrzędne ilustrują indeksy komórek; przykład pozostawia komórki puste i zapisuje tabelę jako `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Tabele są przechowywane w kolekcji kształtów slajdu. Przejdź przez kształty, aby zlokalizować tabelę, a następnie użyj interfejsu [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) do odczytu lub aktualizacji jej komórek.

1. Wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu zawierającego tabelę według jego indeksu.
3. Przejdź przez obiekty [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) i zatrzymaj się, gdy znajdziesz tabelę. Jeśli slajd zawiera kilka tabel, użyj [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) aby zidentyfikować potrzebną.
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

Aby zmienić rozmiar wiersza w istniejącej tabeli i zrozumieć, dlaczego jej rzeczywista wysokość może przekraczać żądaną minimalną, zobacz [Control Row Height](/slides/pl/java/manage-rows-and-columns/#control-row-height).

## **Znajdowanie komórki będącej właścicielem ramki tekstowej**

Gdy ogólny kod przetwarzający tekst otrzymuje obiekt [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) z tabeli, użyj metody [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) aby pobrać należącą [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/). Dla ramki tekstowej komórki tabeli metoda [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) zwraca właściciela, a [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) zwraca `null`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne poprzez właściwości tylko do odczytu [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) i [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--). Metoda [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) zapewnia także nawigację tylko do odczytu: zwraca właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `null` przed jej użyciem.

Pełny przykład identyfikujący właścicieli komórek tabeli i kształtów, w tym kształtów powiązanych z węzłami SmartArt, znajduje się w [Search and Replace Text](/slides/pl/java/search-and-replace-text/).

## **Wyrównanie tekstu w tabeli**

Możesz sterować pionowym zakotwiczeniem i kierunkiem tekstu poszczególnych komórek tabeli. Przykład w tej sekcji centruje tekst w pierwszej komórce i obraca go o 270 stopni.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu według jego indeksu.
3. Dodaj obiekt [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) do slajdu.
4. Uzyskaj dostęp do obiektu [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) z tabeli.
5. Uzyskaj dostęp do pierwszego [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) i ustaw jego tekst oraz kolor.
6. Ustaw pionowe zakotwiczenie komórki i kierunek tekstu przy użyciu [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) oraz [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 4 × 4 o szerokościach kolumn 120 punktów i wysokościach wierszy 100 punktów. Formatuje tekst w komórce (0, 0), dodaje wartości do pozostałych komórek pierwszego wiersza i zapisuje wynik jako `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Ustawienie formatowania tekstu na poziomie tabeli**

Użyj [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) aby zastosować formatowanie tekstu do wszystkich komórek w tabeli. Jego przeciążenia przyjmują formatowanie fragmentu, akapitu i ramki tekstowej, więc możesz ustawić te właściwości bez iteracji po poszczególnych komórkach.

1. Wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Pobierz odniesienie do slajdu według jego indeksu.
3. Uzyskaj dostęp do obiektu [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) ze slajdu.
4. Ustaw rozmiar czcionki przy użyciu [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) dla tekstu.
5. Ustaw wyrównanie akapitu i prawy margines przy użyciu [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) oraz [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Ustaw kierunek tekstu przy użyciu [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `table.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Ustawia rozmiar czcionki na 25 punktów, wyrównuje akapity do prawej z prawym marginesem 20 punktów i ustawia tekst jako pionowy. Sformatowana prezentacja jest zapisywana jako `result.pptx`.

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

## **Pobieranie właściwości stylu tabeli**

Użyj [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) aby odczytać wstępnie zdefiniowany styl tabeli oraz [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) aby go przypisać. Ten przykład stosuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) do jednej tabeli, wypisuje wartość preset i przypisuje ten sam preset do drugiej tabeli. Obie tabele są zapisywane w `table-style.pptx`.

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

## **Zablokowanie proporcji tabeli**

Proporcje tabeli to stosunek jej szerokości do wysokości. Użyj [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) aby zablokować ten stosunek dla tabeli.

Przykład otwiera `pres.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Wypisuje bieżący stan blokady, włącza blokadę proporcji, wypisuje zaktualizowany stan (`true`) i zapisuje wynik jako `pres-out.pptx`.

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

**Czy mogę włączyć kierunek odczytu od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-), a akapity mają [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Użycie obu zapewnia poprawny porządek RTL i renderowanie w komórkach.

**Jak zapobiec użytkownikom przemieszczenia lub zmiany rozmiaru tabeli w finalnym pliku?**

Użyj [shape locks](/slides/pl/java/applying-protection-to-presentation/), aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady działają również na tabele.

**Czy wstawienie obrazu jako tła w komórce jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).