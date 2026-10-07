---
title: Zarządzaj komórkami tabeli w prezentacjach przy użyciu PHP
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/php-java/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj komórkami tabeli PowerPoint w PHP: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy za pomocą Aspose.Slides dla PHP przez Java."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabeli w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabeli, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, uzyskać tabelę ze slajdu, zaktualizować formatowanie komórek za pomocą właściwości komórek i zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych do dostępu do komórek tabeli w kolejności `(column, row)`.

## **Zidentyfikuj scaloną komórkę tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje przez wszystkie wiersze i kolumny oraz używa [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) do identyfikacji komórek w scalonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), oraz początkowe współrzędne obszaru, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) i [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Usuń obramowania komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) i dodaj tabelę do pierwszego slajdu przy użyciu [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Szerokości kolumn, wysokości wierszy oraz pozycja tabeli są określane w punktach. Przykład ustawia wszystkie cztery obramowania komórek na [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), czyniąc je niewidocznymi.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Scal komórki tabeli**

Użyj [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument kontroluje, czy scalanie może obejmować komórki poza określonym zakresem; `false` utrzymuje scalanie w tym zakresie.

Przykład tworzy tabelę 4x4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery centralne komórki od `(1, 1)` do `(2, 2)`. Powstała komórka zajmuje dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `$table->get_Item(1, 1)` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem nie zmieniają się.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Podziel komórki tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę siatki i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides stosuje się do modelu siatki tabeli w PowerPoint.

Ten przykład tworzy tabelę 4x4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) na komórce `(1, 1)`. Połowa szerokości 70 punktów komórki jest przekazywana do utworzenia dwóch komórek o równej szerokości.

Po tym podziale obie połówki są dostępne jako `$table->get_Item(1, 1)` i `$table->get_Item(2, 1)`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przesuń do kolumn 3 i 4 odpowiednio. Indeksy wierszy pozostają niezmienione. Używaj tych zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Podziel scalone komórki według zakresu wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) do podzielenia wzdłuż istniejącej granicy wiersza lub [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) do podzielenia wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest względny względem scalonego obszaru:

- Podział wiersza: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Podział kolumny: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Przykład zakłada, że prezentacja ma tabelę jako pierwszy kształt na pierwszym slajdzie, przy czym `(1, 2)` i `(1, 3)` są scalone pionowo. Rozpoczynając od niższej pozycji, używa [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) i [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) do zlokalizowania początku i sprawdza oba zakresy. `splitByRowSpan(1)` następnie oddziela wiersze 2 i 3 dla nazw produktów. W przypadku poziomego scalania dwóch kolumn, użyj `splitByColSpan(1)`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Pobierz powstałe komórki z tabeli po podziale.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz wynikowe komórki według ich współrzędnych; tutaj obie mają zakres 1 i [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) wypisuje `false`. Większe obszary mogą pozostać częściowo scalone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw wszelkie wymagane formatowanie tekstu explicite.

Zapisana prezentacja zawiera osobne komórki "Product A" i "Product B" z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) po szczegóły.

## **Zmień kolor tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Używa [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) aby wybrać jednolite wypełnienie i ustawia kolor zwrócony przez [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dodaj obraz wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) i dodaje go do kolekcji obrazów prezentacji przy użyciu [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Następnie przypisuje obraz do wypełnienia obrazu komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnić komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy podane są w punktach. Załadowany obraz jest zwalniany w bloku `finally` po dodaniu go do prezentacji.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy mogę ustawić różne grubości linii i style dla różnych boków jednej komórki?**

Tak. Obrzeża [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [tryb wypełnienia](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperlink do całej zawartości komórki?**

[Hyperlinks](/slides/pl/php-java/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (uruchomienia) z niezależnym formatowaniem — rodzina czcionki, styl, rozmiar i kolor.