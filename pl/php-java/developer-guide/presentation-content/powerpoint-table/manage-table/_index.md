---
title: Zarządzanie tabelami prezentacji w PHP
linktitle: Zarządzaj tabelą
type: docs
weight: 10
url: /pl/php-java/manage-table/
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
- PHP
- Aspose.Slides
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Java. Odkryj proste przykłady kodu, które usprawnią Twoje procesy pracy z tabelami."
---
## **Wprowadzenie**

Tabele w programie PowerPoint organizują informacje w wierszach i kolumnach, ułatwiając ich odczyt i porównywanie wartości.

Aspose.Slides udostępnia klasy [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) i [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) oraz inne typy, które umożliwiają tworzenie, aktualizację i zarządzanie tabelami w prezentacjach.

## **Utworzenie tabeli od podstaw**

Utwórz tabelę, określając jej pozycję, szerokości kolumn i wysokości wierszy. Po dodaniu jej do slajdu możesz formatować krawędzie komórek, scalać komórki i wstawiać tekst.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu przy użyciu jego indeksu.
3. Zdefiniuj tablicę szerokości kolumn w punktach.
4. Zdefiniuj tablicę wysokości wierszy w punktach.
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
6. Iteruj po każdej [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/), aby zastosować formatowanie górnej, dolnej, prawej i lewej krawędzi.
7. Scal pierwsze dwie komórki pierwszego wiersza tabeli.
8. Uzyskaj dostęp do scalonej komórki poprzez jej metodę [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/).
9. Ustaw tekst w scalonej komórce.
10. Zapisz zmodyfikowaną prezentację.

Poniższy przykład tworzy tabelę z trzema kolumnami i pięcioma wierszami w położeniu (100, 50) punktów. Nakłada czerwone obramowania o szerokości 5 punktów, scala pierwsze dwie komórki w pierwszym wierszu i zapisuje wynik jako `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
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

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dostęp do istniejącej tabeli**

Tabele są przechowywane w kolekcji kształtów slajdu. Przejrzyj kształty, aby znaleźć tabelę, a następnie użyj klasy [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) do odczytu lub aktualizacji jej komórek.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu zawierającego tabelę przy użyciu jego indeksu.
3. Iteruj po obiektach [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) i zatrzymaj się, gdy zostanie znaleziona tabela. Jeśli slajd zawiera kilka tabel, użyj [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) aby zidentyfikować potrzebną.
4. Zaktualizuj tekst w docelowej komórce.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `UpdateExistingTable.pptx` i znajduje pierwszą tabelę na pierwszym slajdzie. Ustawia komórkę w kolumnie 0, wierszu 1 na `New` i zapisuje wynik jako `table1_out.pptx`. Wejście musi zawierać co najmniej jeden slajd, a pierwsza tabela na tym slajdzie musi mieć co najmniej jedną kolumnę i dwa wiersze.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Aby zmienić wysokość wiersza w istniejącej tabeli i zrozumieć, dlaczego jej rzeczywista wysokość może przekraczać wymaganą minimalną, zobacz [Kontrola wysokości wiersza](/slides/pl/php-java/manage-rows-and-columns/#control-row-height).

## **Znajdź komórkę, której własnością jest TextFrame**

Kiedy ogólny kod przetwarzający tekst otrzymuje [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) z tabeli, użyj metody [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) aby odzyskać należącą [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/). Dla ramki tekstowej w komórce tabeli, [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) zwraca właściciela, a [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) zwraca `null`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne poprzez tylko do odczytu metody [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) i [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/). [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) zapewnia również nawigację tylko do odczytu: zwraca właściciela, ale nie zmienia własności. Zawsze sprawdzaj zwróconą komórkę przy użyciu `java_is_null` przed jej użyciem.

Pełny przykład identyfikujący właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, znajdziesz w [Wyszukiwanie i zamiana tekstu](/slides/pl/php-java/search-and-replace-text/).

## **Wyrównanie tekstu w tabeli**

Możesz kontrolować pionowe zakotwiczenie i kierunek tekstu pojedynczych komórek tabeli. Przykład w tej sekcji centruje tekst w pierwszej komórce i obraca go o 270 stopni.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu przy użyciu jego indeksu.
3. Dodaj obiekt [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) do slajdu.
4. Uzyskaj dostęp do obiektu [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) z tabeli.
5. Uzyskaj dostęp do pierwszego [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) i ustaw jego tekst oraz kolor.
6. Ustaw pionowe zakotwiczenie komórki i kierunek tekstu przy użyciu [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) i [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/).
7. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 4 × 4 z szerokościami kolumn 120 punktów i wysokościami wierszy 100 punktów. Formatuje tekst w komórce (0, 0), dodaje wartości do pozostałych komórek w pierwszym wierszu i zapisuje wynik jako `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

Użyj [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) aby zastosować formatowanie tekstu we wszystkich komórkach tabeli. Przeciążenia przyjmują formatowanie fragmentu, akapitu i ramki tekstowej, więc możesz ustawić te właściwości bez iteracji po poszczególnych komórkach.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu przy użyciu jego indeksu.
3. Uzyskaj dostęp do obiektu [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) ze slajdu.
4. Ustaw rozmiar czcionki używając [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) dla tekstu.
5. Ustaw wyrównanie akapitu i prawy margines przy użyciu [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) i [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Ustaw kierunek tekstu przy użyciu [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `table.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Ustawia rozmiar czcionki na 25 punktów, wyrównuje akapity do prawej z prawym marginesem 20 punktów i ustawia tekst pionowo. Sformatowana prezentacja jest zapisywana jako `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Pobierz właściwości stylu tabeli**

Użyj [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) aby odczytać presetowy styl tabeli i [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) aby go przypisać. Ten przykład stosuje [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) do jednej tabeli, wypisuje wartość presetową i przypisuje ten sam preset do drugiej tabeli. Obie tabele są zapisywane w pliku `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zablokuj proporcje tabeli**

Proporcje tabeli to stosunek jej szerokości do wysokości. Użyj [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) aby zablokować ten stosunek dla tabeli.

Poniższy przykład otwiera `pres.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Wypisuje aktualny stan blokady, włącza blokadę proporcji, wypisuje zaktualizowany stan (`true`) i zapisuje wynik jako `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy mogę włączyć kierunek czytania od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/), a akapity mają [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Użycie obu zapewnia prawidłowy kolejność RTL i renderowanie wewnątrz komórek.

**Jak mogę zapobiec użytkownikom przemieszczaniu lub zmianie rozmiaru tabeli w pliku końcowym?**

Użyj [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/), aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady działają również na tabele.

**Czy wstawianie obrazu wewnątrz komórki jako tła jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).