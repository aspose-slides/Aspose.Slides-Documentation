---
title: Zarządzaj wierszami i kolumnami w tabelach PowerPoint przy użyciu PHP
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
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy użyciu Aspose.Slides dla PHP via Java i przyspiesz edytowanie prezentacji oraz aktualizacje danych."
---
## **Wprowadzenie**

Aspose.Slides for PHP via Java umożliwia zarządzanie strukturą tabeli i formatowaniem w prezentacjach PowerPoint przy użyciu klasy [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Możesz wyznaczyć wiersz nagłówka, klonować lub usuwać wiersze i kolumny oraz zastosować formatowanie tekstu do całego wiersza lub kolumny.

Ten artykuł wyjaśnia te operacje przy użyciu przykładów w PHP. Pokazuje także, jak pobrać predefiniowany styl tabeli, aby można go było ponownie użyć. Indeksy wierszy i kolumn tabeli zaczynają się od zera.

## **Kontrola wysokości wiersza**

Użyj [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) aby ustawić minimalną wysokość wiersza w punktach. Jest to dolna granica, a nie stała wysokość. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) zwraca rzeczywistą wysokość. Dostęp do wiersza uzyskujesz przez [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

Przykład wczytuje [row-height-input.pptx](row-height-input.pptx), w którym tabela jest pierwszym kształtem na pierwszym slajdzie. Pierwszy wiersz zaczyna się od 70 punktów. Komórki używają tekstu Arial 18 pt, łamanie linii oraz marginesów górnego i dolnego po 6 pt; dłuższy tekst w drugiej kolumnie owija się na wiele linii. Przykład zwiększa minimum do 100 pt, potem zmniejsza je do 20 pt, wypisuje rzeczywistą wysokość po każdej zmianie i zapisuje oba wyniki.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Przy dostarczonej prezentacji zwiększenie minimum dodaje przestrzeń do wiersza. Zmniejszenie usuwa tę dodatkową przestrzeń, ale rzeczywista wysokość pozostaje większa niż 20 pt, ponieważ tekst i marginesy komórek wymagają więcej miejsca. Same obniżenie minimum nie może wymusić wysokości poniżej wymaganego przez zawartość wiersza.

Kilka czynników wpływa na rzeczywistą wysokość:

- **Tekst i rozmiar czcionki:** dłuższy tekst, wymuszone podziały wierszy lub większa czcionka mogą wymagać więcej miejsca w pionie.
- **Łamanie i szerokość kolumny:** przy włączonym łamaniu, zmniejszenie szerokości kolumny za pomocą [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) może spowodować powstanie większej liczby wierszy. Szersza kolumna może zmniejszyć potrzebną pionowo przestrzeń.
- **Marginesy komórek:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) i [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) dodają przestrzeń w pionie. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) i [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) zmniejszają szerokość dostępną dla tekstu i mogą powodować dodatkowe łamanie.

Dla tej tabeli bez scalonych komórek, komórka wymagająca najwięcej pionowej przestrzeni określa dolny limit zależny od zawartości dla całego wiersza. Aby skrócić wiersz, może być konieczne skrócenie tekstu, zmniejszenie rozmiaru czcionki lub marginesów, albo zwiększenie szerokości kolumny.

Poniższe obrazy pokazują tę samą tabelę w tej samej skali. W przedstawionych wynikach rzeczywiste wysokości wynosiły 70, 100 i 55,2 pt: ostatni wiersz pozostał wyższy niż jego minimalne 20 pt. Dokładne pomiary tekstu mogą się różnić w zależności od dostępnych czcionek w twoim środowisku. Pobierz zapisane wyniki: [zwiększone minimum](row-height-increased.pptx) i [zmniejszone minimum](row-height-decreased.pptx).

| Oryginalnie: minimum 70 pt, rzeczywiste 70 pt | Zwiększone: minimum 100 pt, rzeczywiste 100 pt | Zmniejszone: minimum 20 pt, rzeczywiste 55,2 pt |
| --- | --- | --- |
| ![Oryginalna tabela z pierwszym wierszem o wysokości 70 punktów.](row-height-before.png) | ![Tabela po zwiększeniu minimalnej wysokości pierwszego wiersza do 100 punktów.](row-height-increased.png) | ![Tabela po zmniejszeniu minimalnej wysokości pierwszego wiersza do 20 punktów; zawinięty tekst utrzymuje wiersz wyższym niż minimum.](row-height-decreased.png) |

## **Ustaw pierwszy wiersz jako nagłówek**

Użyj metody [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) aby oznaczyć pierwszy wiersz jako nagłówek. Jego wygląd zależy od stylu tabeli zastosowanego do tabeli.

1. Wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Uzyskaj dostęp do tabeli zapisanej jako pierwszy kształt na slajdzie.
4. Włącz formatowanie nagłówka dla jej pierwszego wiersza.
5. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie. Włącza formatowanie nagłówka dla pierwszego wiersza i zapisuje plik `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Klonowanie wiersza lub kolumny tabeli**

Klonuj wiersze lub kolumny, aby ponownie użyć ich zawartości i formatowania. Możesz dodać kopię na koniec tabeli lub wstawić ją w określone miejsce.

1. Wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę metodą [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Sklonuj wymagane wiersze.
6. Sklonuj wymagane kolumny.
7. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `Test.pptx` z co najmniej jednym slajdem. Tworzy tabelę z trzema kolumnami i pięcioma wierszami, z wymiarami podanymi w punktach. Dodaje kopie pierwszego wiersza i pierwszej kolumny, a następnie wstawia kopie drugiego wiersza i drugiej kolumny pod indeksem 3 (czwarte miejsce). Wynikowa tabela ma siedem wierszy i pięć kolumn. Argument `false` wyłącza klonowanie do sąsiadujących scalonych wierszy lub kolumn; ta tabela nie ma scalonych komórek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Usuwanie wiersza lub kolumny z tabeli**

Usuwaj wiersze lub kolumny, które nie są już potrzebne w tabeli. Usunięcie elementu przesuwa indeksy kolejnych wierszy lub kolumn.

1. Utwórz prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę metodą [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Usuń drugi wiersz i drugą kolumnę.
6. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 3 × 3 i usuwa wiersz oraz kolumnę o indeksie 1, pozostawiając tabelę 2 × 2 w pliku `TestTable_out.pptx`. Wymiary podane są w punktach. Argument `false` wyłącza usuwanie sąsiadujących scalonych wierszy lub kolumn; ta tabela nie ma scalonych komórek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

Zastosuj formatowanie tekstu do całego wiersza, aby jego komórki były spójne. Możesz ustawić właściwości czcionki, formatowanie akapitu oraz kierunek tekstu bez formatowania każdej komórki osobno.

1. Wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Użyj [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) dla pierwszego wiersza.
4. Użyj [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) i [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) dla pierwszego wiersza.
5. Użyj [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) dla drugiego wiersza.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie i co najmniej dwoma wierszami. Zastosowano tekst 25 pt, wyrównanie do prawej oraz margines akapitu po prawej stronie 20 pt w pierwszym wierszu, a następnie ustawiono pionowy tekst w drugim wierszu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

Zastosuj formatowanie tekstu do całej kolumny, aby jej komórki były spójne. Możesz ustawić właściwości czcionki, formatowanie akapitu oraz kierunek tekstu bez formatowania każdej komórki osobno.

1. Wczytaj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Użyj [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) dla pierwszej kolumny.
4. Użyj [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) i [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) dla pierwszej kolumny.
5. Użyj [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) dla drugiej kolumny.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie i co najmniej dwiema kolumnami. Zastosowano tekst 25 pt, wyrównanie do prawej oraz margines akapitu po prawej stronie 20 pt w pierwszej kolumnie, a następnie ustawiono pionowy tekst w drugiej kolumnie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Pobieranie właściwości stylu tabeli**

Użyj metody [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) aby pobrać predefiniowany styl zastosowany do tabeli i ponownie użyć go w innej tabeli. To identyfikuje preset zamiast indywidualnych nadpisań formatowania komórek.

Przykład tworzy tabelę, stosuje [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) i odczytuje preset. Wypisuje wartość całkowitą odpowiadającą `DarkStyle1` i zapisuje tabelę w pliku `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy mogę zastosować motywy/stylu PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/mistrza, a nadal możesz nadpisać wypełnienia, krawędzie i kolory tekstu ponad tym motywem.

**Czy mogę sortować wiersze tabeli tak jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj dane w pamięci najpierw, a potem ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (pasiowe) kolumny, zachowując jednocześnie niestandardowe kolory w wybranych komórkach?**

Tak. Włącz paskowane kolumny, a następnie nadpisz konkretne komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.