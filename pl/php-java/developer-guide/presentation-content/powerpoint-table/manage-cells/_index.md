---
title: Zarządzanie komórkami tabeli w prezentacjach przy użyciu PHP
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/php-java/manage-cells/
keywords:
- komórka tabeli
- łączenie komórek
- usuwanie obramowania
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Bezproblemowo zarządzaj komórkami tabeli w PowerPoint przy użyciu Aspose.Slides dla PHP. Opanuj szybki dostęp, modyfikację i stylizację komórek dla płynnej automatyzacji slajdów."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabeli w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować połączone komórki tabeli, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez właściwości komórek i zapisać zmodyfikowaną prezentację jako plik PPTX.

## **Zidentyfikowanie połączonej komórki tabeli**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Pobierz tabelę z pierwszego slajdu.
3. Iteruj przez wiersze i kolumny tabeli, aby znaleźć połączone komórki.
4. Wyświetl komunikat, gdy zostaną znalezione połączone komórki.

Ten kod PHP pokazuje, jak zidentyfikować połączone komórki tabeli w prezentacji:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// zakładając, że Slide#0.Shape#0 jest tabelą

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usuwanie obramowań komórek tabeli**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj odwołanie do slajdu przez jego indeks.
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu przy użyciu metody [addTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addTable).
6. Iteruj przez każdą komórkę, aby usunąć górne, dolne, prawe i lewe obramowania.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP pokazuje, jak usunąć obramowania z komórek tabeli:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Dodaje kształt tabeli do slajdu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ustawia format obramowania dla każdej komórki
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Zapisuje plik PPTX na dysku
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numeracja w połączonych komórkach**
Jeśli połączymy 2 pary komórek (1, 1) x (2, 1) oraz (1, 2) x (2, 2), powstała tabela będzie ponumerowana. Ten kod PHP demonstruje ten proces:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Dodaje kształt tabeli do slajdu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ustawia format obramowania dla każdej komórki
    foreach($tbl->getRows() as $row) {
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
    # Łączy komórki (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Łączy komórki (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Następnie łączymy dalej komórki, scalając (1, 1) i (1, 2). Wynikiem jest tabela zawierająca dużą połączoną komórkę w centrum:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Dodaje kształt tabeli do slajdu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ustawia format obramowania dla każdej komórki
    foreach($tbl->getRows() as $row) {
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
    # Łączy komórki (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Łączy komórki (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Łączy komórki (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Zapisuje plik PPTX na dysku
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numeracja w podzielonej komórce**
W poprzednich przykładach, gdy komórki tabeli zostały połączone, numeracja w pozostałych komórkach nie uległa zmianie.

Tym razem bierzemy zwykłą tabelę (tabelę bez połączonych komórek) i próbujemy podzielić komórkę (1,1), aby uzyskać specjalną tabelę. Warto zwrócić uwagę na numerację tej tabeli, która może wydawać się nietypowa. Jednak tak właśnie Microsoft PowerPoint numeruje komórki tabeli i Aspose.Slides robi to samo.

Ten kod PHP demonstruje opisany proces:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Dodaje kształt tabeli do slajdu
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Ustawia format obramowania dla każdej komórki
    foreach($tbl->getRows() as $row) {
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
    # Łączy komórki (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Łączy komórki (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Dzieli komórkę (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Zapisuje plik PPTX na dysku
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zmienianie koloru tła komórki tabeli**

Ten kod PHP pokazuje, jak zmienić kolor tła komórki tabeli:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # utwórz nową tabelę
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # ustaw kolor tła dla komórki
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Dodanie obrazu wewnątrz komórki tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
2. Uzyskaj odwołanie do slajdu przez jego indeks.
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu przy użyciu metody [AddTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addTable).
6. Utwórz obiekt `Images`, aby przechowywać plik obrazu.
7. Dodaj obraz `IImage` do obiektu `IPPImage`.
8. Ustaw `FillFormat` komórki tabeli na `Picture`.
9. Dodaj obraz do pierwszej komórki tabeli.
10. Zapisz zmodyfikowaną prezentację jako plik PPTX

Ten kod PHP pokazuje, jak umieścić obraz wewnątrz komórki tabeli podczas tworzenia tabeli:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $islide = $pres->getSlides()->get_Item(0);
    # Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Dodaje kształt tabeli do slajdu
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Tworzy obiekt IPPImage przy użyciu pliku obrazu
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Dodaje obraz do pierwszej komórki tabeli
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Zapisuje plik PPTX na dysk
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę ustawić różne grubości linii i style dla różnych stron jednej komórki?**

Tak. Obramowania [górne](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellformat/getbordertop/)/[dolne](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellformat/getborderbottom/)/[lewe](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellformat/getborderleft/)/[prawe](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cellformat/getborderright/) mają osobne właściwości, więc grubość i styl każdej strony mogą się różnić. Wynika to logicznie z kontroli obramowania po stronie dla komórki, przedstawionej w artykule.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tło komórki?**

Zachowanie zależy od [trybu wypełnienia](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillmode/). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane. W artykule wspomniano o trybach wyświetlania obrazu w komórce.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/php-java/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) (runs) z niezależnym formatowaniem — rodzina czcionki, styl, rozmiar i kolor.