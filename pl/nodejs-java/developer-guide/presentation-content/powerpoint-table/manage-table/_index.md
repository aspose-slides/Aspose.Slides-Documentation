---
title: Zarządzanie tabelami prezentacji w JavaScript
linktitle: Zarządzaj tabelą
type: docs
weight: 10
url: /pl/nodejs-java/manage-table/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js. Odkryj proste przykłady kodu, które usprawnią Twoje procesy pracy z tabelami."
---
## **Wprowadzenie**

Tabele w programie PowerPoint organizują informacje w wierszach i kolumnach, ułatwiając odczyt i porównywanie wartości.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , klasę [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) oraz inne typy, które umożliwiają tworzenie, aktualizowanie i zarządzanie tabelami w prezentacjach.

## **Utworzenie tabeli od podstaw**

Utwórz tabelę, określając jej pozycję, szerokości kolumn i wysokości wierszy. Po dodaniu jej do slajdu możesz formatować krawędzie komórek, scalać komórki i wstawiać tekst.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę szerokości kolumn w punktach.
4. Zdefiniuj tablicę wysokości wierszy w punktach.
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) .
6. Iteruj przez każdą [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) , aby zastosować formatowanie krawędzi górnej, dolnej, prawej i lewej.
7. Scal pierwsze dwie komórki pierwszego wiersza tabeli.
8. Uzyskaj dostęp do scalonej komórki za pomocą jej metody [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) .
9. Ustaw tekst w scalonej komórce.
10. Zapisz zmodyfikowaną prezentację.

Poniższy przykład tworzy tabelę z trzema kolumnami i pięcioma wierszami w punkcie (100, 50). Nakłada czerwone obramowania o szerokości 5 punktów, scala pierwsze dwie komórki w pierwszym wierszu i zapisuje wynik jako `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli indeksy komórek są zerowe i używają kolejności (kolumna, wiersz). Pierwsza komórka ma indeks (0, 0).

Na przykład komórki w tabeli z 4 kolumnami i 4 wierszami są numerowane w ten sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten przykład tworzy tabelę 4 × 4 przedstawioną powyżej, z szerokościami kolumn i wysokościami wierszy po 70 punktów oraz czerwonymi obramowaniami komórek o szerokości 5 punktów. Współrzędne ilustrują indeksy komórek; przykład pozostawia komórki puste i zapisuje tabelę jako `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dostęp do istniejącej tabeli**

Tabele są przechowywane w kolekcji kształtów slajdu. Iteruj przez kształty, aby znaleźć tabelę, a następnie użyj klasy [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , aby odczytać lub zaktualizować jej komórki.

1. Wczytaj prezentację za pomocą klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu zawierającego tabelę za pomocą jego indeksu.
3. Iteruj przez obiekty [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) , zatrzymując się, gdy znajdziesz tabelę. Jeśli slajd zawiera kilka tabel, użyj [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) , aby zidentyfikować potrzebną.
4. Zaktualizuj tekst w docelowej komórce.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `UpdateExistingTable.pptx` i znajduje pierwszą tabelę na pierwszym slajdzie. Ustawia komórkę w kolumnie 0, wierszu 1 na `New` i zapisuje wynik jako `table1_out.pptx`. Wejście musi zawierać co najmniej jeden slajd, a pierwsza tabela na tym slajdzie musi mieć co najmniej jedną kolumnę i dwa wiersze.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Aby zmienić rozmiar wiersza w istniejącej tabeli i zrozumieć, dlaczego jego rzeczywista wysokość może przekraczać żądane minimum, zobacz [Kontrola wysokości wiersza](/slides/pl/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Znajdź komórkę, której własnością jest ramka tekstowa**

Gdy ogólny kod przetwarzający tekst otrzymuje [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) z tabeli, użyj metody [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) , aby uzyskać własną [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) . Dla ramki tekstowej w komórce tabeli, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) zwraca właściciela, a [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) zwraca `null`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne za pośrednictwem metod tylko do odczytu [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) i [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) . [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) zapewnia również nawigację tylko do odczytu: zwraca właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `null` przed jej użyciem.

Aby zobaczyć pełny przykład identyfikujący właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, zobacz [Wyszukiwanie i zamiana tekstu](/slides/pl/nodejs-java/search-and-replace-text/).

## **Wyrównanie tekstu w tabeli**

Możesz kontrolować pionowe zakotwiczenie i kierunek tekstu poszczególnych komórek tabeli. Przykład w tej sekcji centruje tekst w pierwszej komórce i obraca go o 270 stopni.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Dodaj obiekt [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) do slajdu.
4. Uzyskaj dostęp do obiektu [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) z tabeli.
5. Uzyskaj dostęp do pierwszego [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) , ustaw jego tekst i kolor.
6. Ustaw pionowe zakotwiczenie komórki i kierunek tekstu przy użyciu [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) i [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) .
7. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 4 × 4 o szerokościach kolumn 120 punktów i wysokościach wierszy 100 punktów. Formatuje tekst w komórce (0, 0), dodaje wartości do pozostałych komórek w pierwszym wierszu i zapisuje wynik jako `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

Użyj [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) , aby zastosować formatowanie tekstu we wszystkich komórkach tabeli. Jej przeciążenia akceptują formatowanie fragmentu, akapitu i ramki tekstowej, więc możesz ustawiać te właściwości bez iteracji przez poszczególne komórki.

1. Wczytaj prezentację za pomocą klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do obiektu [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) ze slajdu.
4. Ustaw rozmiar czcionki przy użyciu [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) dla tekstu.
5. Ustaw wyrównanie akapitu i prawy margines przy użyciu [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) i [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) .
6. Ustaw kierunek tekstu przy użyciu [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `table.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Ustawia rozmiar czcionki na 25 punktów, prawe wyrównanie akapitów z prawym marginesem 20 punktów oraz ustawia tekst pionowo. Sformatowana prezentacja jest zapisana jako `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pobierz właściwości stylu tabeli**

Użyj [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) , aby odczytać domyślny styl tabeli i [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) , aby go przypisać. Ten przykład stosuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) do jednej tabeli, wypisuje wartość preset i przypisuje ten sam preset do drugiej tabeli. Obie tabele są zapisywane w `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zablokuj proporcje tabeli**

Proporcje tabeli to stosunek jej szerokości do wysokości. Użyj [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) , aby zablokować te proporcje dla tabeli.

Poniższy przykład otwiera `pres.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Wypisuje bieżący stan blokady, włącza blokadę proporcji, wypisuje zaktualizowany stan (`true`) i zapisuje wynik jako `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę włączyć kierunek czytania od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) , a akapity mają [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-) . Użycie obu zapewnia prawidłowy porządek RTL i renderowanie wewnątrz komórek.

**Jak mogę uniemożliwić użytkownikom przenoszenie lub zmianę rozmiaru tabeli w finalnym pliku?**

Użyj [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) , aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady mają zastosowanie również do tabel.

**Czy wstawianie obrazu jako tła wewnątrz komórki jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) , aby wypełnić komórkę obrazem; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub powielanie).