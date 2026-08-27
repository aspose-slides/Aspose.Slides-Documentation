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
description: "Twórz i edytuj tabele w slajdach PowerPoint za pomocą Aspose.Slides dla PHP poprzez Java. Odkryj proste przykłady kodu, aby usprawnić przepływy pracy z tabelami."
---
## **Wprowadzenie**

Tabela w PowerPoint jest efektywnym sposobem wyświetlania i prezentowania informacji. Informacje w siatce komórek (ustawionych w wierszach i kolumnach) są przejrzyste i łatwe do zrozumienia.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table), klasę [Cell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cell/) oraz inne typy, które umożliwiają tworzenie, aktualizowanie i zarządzanie tabelami we wszystkich rodzajach prezentacji.

## **Utworzenie tabeli od podstaw**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu poprzez jego indeks. 
3. Zdefiniuj tablicę `columnWidth`.
4. Zdefiniuj tablicę `rowHeight`.
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/table/) do slajdu metodą [addTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addtable/).
6. Przejdź przez każdą [Cell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cell/) i zastosuj formatowanie górnych, dolnych, prawych i lewych krawędzi.
7. Połącz pierwsze dwie komórki pierwszego wiersza tabeli. 
8. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) komórki [Cell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cell/).
9. Dodaj tekst do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/).
10. Zapisz zmodyfikowaną prezentację.

Ten kod PHP pokazuje, jak utworzyć tabelę w prezentacji:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiuje kolumny z szerokościami i wiersze z wysokościami
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Dodaje kształt tabeli do slajdu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ustawia format obramowania dla każdej komórki
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Łączy komórki 1 i 2 w wierszu 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Dodaje tekst do połączonej komórki
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Zapisuje prezentację na dysku
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli numeracja komórek jest prosta i rozpoczyna się od zera. Pierwsza komórka tabeli ma indeks 0,0 (kolumna 0, wiersz 0). 

Na przykład komórki w tabeli o 4 kolumnach i 4 wierszach są numerowane w następujący sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten kod PHP pokazuje, jak określić numerację komórek w tabeli:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiuje kolumny z szerokościami i wiersze z wysokościami
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Dodaje kształt tabeli do slajdu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ustawia format obramowania dla każdej komórki
    $rows = $tbl->getRows();
    foreach($rows as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Zapisuje prezentację na dysku
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dostęp do istniejącej tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).

2. Uzyskaj odwołanie do slajdu zawierającego tabelę poprzez jego indeks. 

3. Utwórz obiekt [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table) i ustaw go na null.

4. Przeglądaj wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/), aż znajdziesz tabelę.

   Jeśli podejrzewasz, że slajd zawiera jedną tabelę, możesz po prostu sprawdzić wszystkie znajdujące się na nim kształty. Gdy kształt zostanie zidentyfikowany jako tabela, możesz rzutować go na obiekt [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table). Jeśli jednak slajd zawiera kilka tabel, lepiej wyszukać potrzebną tabelę za pomocą jej [setAlternativeText(String value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/setalternativetext/).

5. Użyj obiektu [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table) do pracy z tabelą. W poniższym przykładzie dodaliśmy nowy wiersz do tabeli.

6. Zapisz zmodyfikowaną prezentację.

Ten kod PHP pokazuje, jak uzyskać dostęp i pracować z istniejącą tabelą:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Inicjalizuje pusty TableEx
    $tbl = null;
    # Iteruje po kształtach i ustawia odniesienie do znalezionej tabeli
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Ustawia tekst dla pierwszej kolumny drugiego wiersza
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Zapisuje zmodyfikowaną prezentację na dysku
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Znajdowanie komórki, której właścicielem jest ramka tekstowa**

Gdy ogólny kod przetwarzający tekst otrzymuje [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) z tabeli, użyj metody [TextFrame::getParentCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentCell), aby pobrać właściciela – [Cell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cell/). Dla ramki tekstowej komórki tabeli, [TextFrame::getParentCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentCell) zwraca właściciela, a [TextFrame::getParentShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentShape) zwraca `null`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne poprzez metoda tylko do odczytu [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cell/#getFirstColumnIndex) oraz [Cell::getFirstRowIndex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame::getParentCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParentCell) zapewnia również nawigację tylko do odczytu: zwraca właściciela, ale nie zmienia własności. Zawsze sprawdzaj zwróconą komórkę przy pomocy `java_is_null` przed jej użyciem.

Kompletny przykład identyfikujący właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, znajduje się w artykule [Search and Replace Text](/slides/pl/php-java/search-and-replace-text/).

## **Wyrównanie tekstu w tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj odwołanie do slajdu poprzez jego indeks. 
3. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table) do slajdu.
4. Uzyskaj dostęp do obiektu [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) z tabeli.
5. Uzyskaj dostęp do [Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/).
6. Wyrównaj tekst w pionie.
7. Zapisz zmodyfikowaną prezentację.

Ten kod PHP pokazuje, jak wyrównać tekst w tabeli:

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $slide = $pres->getSlides()->get_Item(0);
    # Definiuje kolumny z szerokościami i wiersze z wysokościami
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Dodaje kształt tabeli do slajdu
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Uzyskuje dostęp do ramki tekstowej
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Tworzy obiekt Paragraph dla ramki tekstowej
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Tworzy obiekt Portion dla akapitu
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Wyrównuje tekst w pionie
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Zapisuje prezentację na dysku
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustawienie formatowania tekstu na poziomie tabeli**

1. Utwórz instancję [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj odwołanie do slajdu poprzez jego indeks. 
3. Uzyskaj dostęp do obiektu [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table) ze slajdu.
4. Ustaw [setFontHeight(float value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setFontHeight) dla tekstu.
5. Ustaw [setAlignment(int value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setalignment/) oraz [setMarginRight(float value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Ustaw [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Zapisz zmodyfikowaną prezentację. 

Ten kod PHP pokazuje, jak zastosować wybrane opcje formatowania do tekstu w tabeli:

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ustawia wysokość czcionki komórek tabeli
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Ustawia wyrównanie tekstu i prawy margines komórek tabeli w jednym wywołaniu
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Ustawia pionowy typ tekstu w komórkach tabeli
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Pobieranie właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można było użyć tych danych w innej tabeli lub w innym miejscu. Ten kod PHP pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// zmień domyślny styl presetu tematu
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zablokowanie proporcji tabeli**

Proporcje geometrycznego kształtu określają stosunek jego wymiarów w różnych osiach. Aspose.Slides udostępnia metodę [setAspectRatioLocked](https://reference.aspose.com/slides/pl/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/), umożliwiającą zablokowanie ustawienia proporcji dla tabel i innych kształtów.

Ten kod PHP pokazuje, jak zablokować proporcje tabeli:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// odwróć

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę włączyć tryb czytania od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [setRightToLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/table/setrighttoleft/), a akapity mają [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setrighttoleft/). Użycie obu zapewnia poprawny kolejność i renderowanie RTL wewnątrz komórek.

**Jak mogę zapobiec przemieszczaniu lub zmienianiu rozmiaru tabeli w finalnym pliku?**

Użyj blokad kształtu, aby wyłączyć przemieszczanie, zmianę rozmiaru, zaznaczanie itp. Blokady te obowiązują także dla tabel.

**Czy wstawianie obrazu jako tła w komórce jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).