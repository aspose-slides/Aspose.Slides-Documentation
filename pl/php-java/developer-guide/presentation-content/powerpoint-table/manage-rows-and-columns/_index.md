---
title: Zarządzanie wierszami i kolumnami w tabelach PowerPoint przy użyciu PHP
linktitle: Wiersze i kolumny
type: docs
weight: 20
url: /pl/php-java/manage-rows-and-columns/
keywords:
- wiersz tabeli
- kolumna tabeli
- pierwszy wiersz
- nagłówek tabeli
- klonowanie wiersza
- klonowanie kolumny
- kopiowanie wiersza
- kopiowanie kolumny
- usuwanie wiersza
- usuwanie kolumny
- formatowanie tekstu wiersza
- formatowanie tekstu kolumny
- styl tabeli
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy pomocy Aspose.Slides dla PHP poprzez Java oraz przyspiesz edycję prezentacji i aktualizację danych."
---
## **Wprowadzenie**

Aby umożliwić zarządzanie wierszami i kolumnami tabeli w prezentacji PowerPoint, Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/table/) oraz wiele innych typów.

## **Ustaw pierwszy wiersz jako nagłówek**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i załaduj prezentację.  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Utwórz obiekt [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table) i ustaw go na null.  
4. Iteruj po wszystkich obiektach [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/) , aby znaleźć odpowiednią tabelę.  
5. Ustaw pierwszy wiersz tabeli jako jej nagłówek.  

Ten kod PHP pokazuje, jak ustawić pierwszy wiersz tabeli jako nagłówek:

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Inicjalizuje zmienną TableEx jako null
    $tbl = null;
    # Iteruje przez kształty i ustawia referencję do tabeli
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Ustawia pierwszy wiersz tabeli jako nagłówek
        $tbl->setFirstRow(true);
      }
    }
    # Zapisuje prezentację na dysk
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Klonuj wiersz lub kolumnę tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i załaduj prezentację,  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Zdefiniuj tablicę `columnWidth`.  
4. Zdefiniuj tablicę `rowHeight`.  
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addtable/).  
6. Sklonuj wiersz tabeli.  
7. Sklonuj kolumnę tabeli.  
8. Zapisz zmodyfikowaną prezentację.  

Ten kod PHP pokazuje, jak klonować wiersz lub kolumnę tabeli PowerPoint:

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Uzyskuje dostęp do pierwszego slajdu
    $sld = $pres->getSlides()->get_Item(0);
    # Definiuje kolumny z szerokościami i wiersze z wysokościami
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Dodaje kształt tabeli do slajdu
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Dodaje tekst do komórki 1 wiersza 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Dodaje tekst do komórki 2 wiersza 1
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Klonuje wiersz 1 na końcu tabeli
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Dodaje tekst do komórki 1 wiersza 2
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Dodaje tekst do komórki 2 wiersza 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Klonuje wiersz 2 jako czwarty wiersz tabeli
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Klonuje pierwszą kolumnę na końcu
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Klonuje drugą kolumnę na indeksie czwartej kolumny
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Zapisuje prezentację na dysk
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usuń wiersz lub kolumnę z tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i załaduj prezentację,  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Zdefiniuj tablicę `columnWidth`.  
4. Zdefiniuj tablicę `rowHeight`.  
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addtable/).  
6. Usuń wiersz tabeli.  
7. Usuń kolumnę tabeli.  
8. Zapisz zmodyfikowaną prezentację.  

Ten kod PHP pokazuje, jak usunąć wiersz lub kolumnę z tabeli:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i załaduj prezentację,  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Uzyskaj dostęp do odpowiedniego obiektu [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table) ze slajdu.  
4. Ustaw w komórkach pierwszego wiersza [setFontHeight(float value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Ustaw w komórkach pierwszego wiersza [setAlignment(int value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setalignment/) oraz [setMarginRight(float value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Ustaw w komórkach drugiego wiersza [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Zapisz zmodyfikowaną prezentację.  

Ten kod PHP demonstruje operację.

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation();
  try {
    # Załóżmy, że pierwszym kształtem na pierwszym slajdzie jest tabela
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ustawia wysokość czcionki komórek pierwszego wiersza
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Ustawia wyrównanie tekstu komórek pierwszego wiersza oraz prawy margines
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Ustawia pionowy rodzaj tekstu komórek drugiego wiersza
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Zapisuje prezentację na dysk
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i załaduj prezentację,  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Uzyskaj dostęp do odpowiedniego obiektu [Table](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Table) ze slajdu.  
4. Ustaw w komórkach pierwszej kolumny [setFontHeight(float value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Ustaw w komórkach pierwszej kolumny [setAlignment(int value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setalignment/) oraz [setMarginRight(float value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Ustaw w komórkach drugiej kolumny [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Zapisz zmodyfikowaną prezentację.  

Ten kod PHP demonstruje operację:

```php
  # Tworzy instancję klasy Presentation
  $pres = new Presentation();
  try {
    # Załóżmy, że pierwszym kształtem na pierwszym slajdzie jest tabela
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ustawia wysokość czcionki komórek pierwszej kolumny
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Ustawia wyrównanie tekstu i prawy margines komórek pierwszej kolumny w jednym wywołaniu
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Ustawia pionowy rodzaj tekstu komórek drugiej kolumny
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Pobierz właściwości stylu tabeli**

Aspose.Slides pozwala pobrać właściwości stylu tabeli, aby móc użyć ich w innej tabeli lub w innym miejscu. Ten kod PHP pokazuje, jak uzyskać właściwości stylu z gotowego stylu tabeli:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// zmień domyślny preset stylu

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę zastosować motywy/style PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/mastera i nadal możesz nadpisać wypełnienia, obramowania oraz kolory tekstu w ramach tego motywu.

**Czy mogę sortować wiersze tabeli jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj najpierw dane w pamięci, a następnie ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (stripowane) kolumny, zachowując niestandardowe kolory w określonych komórkach?**

Tak. Włącz paskowane kolumny, a następnie nadpisz konkretne komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.