---
title: Zarządzanie komórkami tabeli w prezentacjach przy użyciu PHP
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/php-java/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie krawędzi
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj komórkami tabel PowerPoint w PHP: identyfikuj połączone komórki, usuwaj krawędzie, dziel komórki oraz ustawiaj kolory tła i obrazy przy pomocy Aspose.Slides dla PHP via Java."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować połączone komórki tabel, usuwać krawędzie komórek, pracować z numeracją komórek po scaleniu lub podziale, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek za pomocą właściwości komórki oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zaczynających się od zera do dostępu do komórek tabel w kolejności `(kolumna, wiersz)`.

## **Zidentyfikuj połączoną komórkę tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje po wszystkich wierszach i kolumnach i używa [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) do identyfikacji komórek w połączonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `wiersz;kolumna`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), oraz początkowe współrzędne obszaru, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) i [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Usuń krawędzie komórek tabeli**

Utwórz obiekt [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) i dodaj tabelę do jej pierwszego slajdu przy pomocy [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Szerokości kolumn, wysokości wierszy oraz pozycja tabeli są podane w punktach. Przykład ustawia wszystkie cztery krawędzie komórki na [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), czyniąc je niewidocznymi.

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

## **Dodaj przekątne krawędzie komórek**

Użyj [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/), aby narysować linię od lewego górnego rogu do prawego dolnego, oraz [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/), aby narysować linię od lewego dolnego rogu do prawego górnego. Przekątna może oznaczać nagłówek narożny; obie przekątne mogą tworzyć X, aby oznaczyć komórkę jako nieodpowiednią.

Każda przekątna ma własny [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/). W jej [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) użyj [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/), aby wybrać [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) i określić kolor przez [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). Ustaw szerokość linii w punktach za pomocą [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/).

Przykład tworzy trzy komórki w jednym wierszu: czerwoną przekątną w dół, niebieską przekątną w górę oraz obie przekątne. Pozostawia niezmienione krawędzie górne, dolne, lewe i prawe.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Przekątna zmienia tylko formatowanie komórki. Każda komórka zachowuje pojedynczą ramkę tekstową, dostęp do której uzyskuje się przez [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). Regiony po obu stronach przekątnej nie mogą być edytowane niezależnie.

Zapisana tabela, wyświetlona w Microsoft PowerPoint:

![Trzy komórki tabeli pokazujące czerwoną przekątną od lewego górnego rogu do prawego dolnego, niebieską przekątną od lewego dolnego rogu do prawego górnego oraz obie przekątne tworzące X.](diagonal-cell-borders.png)

*Od lewej do prawej: przekątna w dół (czerwona, 3 pt), przekątna w górę (niebieska, 5 pt) oraz obie przekątne.*

## **Scal komórki tabeli**

Użyj [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/), aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument kontroluje, czy scalanie może obejmować komórki poza określonym zakresem; `false` utrzymuje scalanie w ramach tego zakresu.

Przykład tworzy tabelę 4 × 4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery centralne komórki od `(1, 1)` do `(2, 2)`. Powstała komórka rozciąga się na dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania połączonej komórki, użyj jej lewej górnej pozycji: `$table->get_Item(1, 1)` w tym przykładzie. Pozostałe pozycje w połączonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem się nie zmieniają.

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

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę siatki i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides podąża za modelem siatki tabel PowerPointa.

Ten przykład tworzy tabelę 4 × 4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) na komórce `(1, 1)`. Połowa szerokości 70‑punktowej komórki jest przekazywana, aby utworzyć dwie komórki o równej szerokości.

Po podziale dwie połowy są dostępne jako `$table->get_Item(1, 1)` i `$table->get_Item(2, 1)`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przechodzą odpowiednio do kolumn 3 i 4. Indeksy wierszy pozostają niezmienione. Używaj tych zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

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

<!-- visual-explanation:manage-cells:start -->
[![Niepołączona komórka o szerokości 70 punktów dzieli się na dwie komórki po 35 punktów, dodając piątą kolumnę siatki i przesuwając indeksy po jej prawej stronie.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Podział szerokości dotyczy komórki (1, 1), używając indeksów zero‑based (kolumna, wiersz). Inne wiersze zachowują komórkę rozciągającą się na oba nowe pozycje kolumn.*
<!-- visual-explanation:manage-cells:end -->

### **Podziel połączone komórki według zakresu wiersza lub kolumny**

Aby przygotować połączone komórki szablonu do wypełnienia danymi, użyj [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) do podziału wzdłuż istniejącej granicy wiersza lub [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) do podziału wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest względny względem połączonego obszaru:

- Podział wiersza: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Podział kolumny: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Przykład zakłada, że prezentacja zawiera tabelę jako pierwszy kształt na pierwszym slajdzie, przy czym `(1, 2)` i `(1, 3)` są połączone pionowo. Rozpoczynając od dolnej pozycji, używa [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) i [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) do zlokalizowania początku i sprawdza oba zakresy. `splitByRowSpan(1)` następnie oddziela wiersze 2 i 3 dla nazw produktów. Dla poziomego połączenia dwóch kolumn użyj `splitByColSpan(1)`.

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

        // Pobierz wynikowe komórki z tabeli po podziale.
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

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz wynikowe komórki według ich współrzędnych; tutaj obie mają zakresy równe 1 i [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) zwraca `false`. Większe obszary mogą pozostać częściowo połączone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, krawędzie i marginesy. Wypełnij komórki po podziale i ustaw wszelkie wymagane formatowanie tekstu explicite.

Zapisana prezentacja zawiera osobne komórki „Product A” i „Product B” z zachowanym formatowaniem komórki szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) po szczegóły.

### **Podziel komórkę o określonej wysokości**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) przyjmuje wysokość górnej części w punktach. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) przyjmuje liczbę istniejących wierszy siatki w górnej części. Aby wyśrodkować komórkę o wysokości 40 punktów w prawej kolumnie, odejmij 40 od rzeczywistej wysokości komórki i podziel pozostałą przestrzeń równo powyżej i poniżej niej.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pierwszy podział dodaje wiersz siatki i pozostawia dolne 90 punktów w komórce `(1, 1)`. Drugi podział dzieli tę komórkę na środkową komórkę o wysokości 40 punktów oraz dolną komórkę o wysokości 50 punktów. Prawa kolumna ma teraz trzy komórki o wysokościach 50, 40 i 50 punktów od góry do dołu. Lewa komórka rozciąga się na wszystkie trzy wiersze i zachowuje pierwotną wysokość 140 punktów.

![Lewy komórka rozciąga się na pełną wysokość tabeli obok trzech komórek, z środkową w centrum.](split-by-height.png)

## **Zmień kolor tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Używa [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/), aby wybrać wypełnienie jednostajne i ustawia kolor zwrócony przez [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) na czerwony dla komórki `(2, 3)`, czyli trzeciej kolumny i czwartego wiersza.

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

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz przy pomocy [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) i dodaje go do kolekcji obrazów prezentacji przy użyciu [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Następnie przypisuje obraz do wypełnienia obrazu komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnić komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy podane są w punktach. Załadowany obraz jest zwalniany w bloku `finally` po jego dodaniu do prezentacji.

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

**Czy mogę ustawić różne grubości i style linii dla różnych krawędzi jednej komórki?**

Tak. Krawędzie [górna](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/), [dolna](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/), [lewa](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/), [prawa](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) mają oddzielne właściwości, więc grubość i styl każdej z nich mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/php-java/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (segmenty) z niezależnym formatowaniem — rodziną czcionki, stylem, rozmiarem i kolorem.