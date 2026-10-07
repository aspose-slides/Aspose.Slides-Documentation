---
title: Zarządzaj komórkami tabeli w prezentacjach przy użyciu JavaScript
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/nodejs-java/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj komórkami tabeli PowerPoint w JavaScript: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy przy użyciu Aspose.Slides dla Node.js za pomocą Java."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak identyfikować scalone komórki tabel, usuwać obramowania komórek, pracować z numeracją komórek po scaleniu lub podzieleniu, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak tworzyć lub otwierać prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez właściwości komórek oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych do dostępu do komórek tabel w kolejności `(column, row)`.

## **Zidentyfikuj scaloną komórkę tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje przez wszystkie wiersze i kolumny i używa [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) do identyfikacji komórek w scalonych regionach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/) oraz początkowe współrzędne regionu, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) i [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Usuń obramowania komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) i dodaj tabelę do jej pierwszego slajdu za pomocą [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Szerokości kolumn, wysokości wierszy i pozycja tabeli są określone w punktach. Przykład ustawia wszystkie cztery obramowania komórek na [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), czyniąc je niewidocznymi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Scal komórki tabeli**

Użyj [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/), aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument kontroluje, czy scalanie może obejmować komórki poza określonym zakresem; `false` utrzymuje scalenie w obrębie tego zakresu.

Przykład tworzy tabelę 4x4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery środkowe komórki od `(1, 1)` do `(2, 2)`. Powstała komórka zajmuje dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table.get_Item(1, 1)` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem się nie zmieniają.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Podziel komórki tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę w siatce i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides stosuje model siatki tabeli PowerPointa.

Ten przykład tworzy tabelę 4x4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) na komórce `(1, 1)`. Połowa szerokości 70 punktów tej komórki jest używana do utworzenia dwóch komórek o równej szerokości.

Po tym podziale dwie połówki są dostępne jako `table.get_Item(1, 1)` i `table.get_Item(2, 1)`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przechodzą do kolumn 3 i 4, odpowiednio. Indeksy wierszy pozostają niezmienione. Używaj tych zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Podziel scalone komórki według zakresu wierszy lub kolumn**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) do podziału wzdłuż istniejącej granicy wiersza lub [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) do podziału wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest on względny względem scalonego regionu:
- Podział wiersza: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Podział kolumny: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Przykład zakłada, że prezentacja ma tabelę jako pierwszy kształt na pierwszym slajdzie, przy czym `(1, 2)` i `(1, 3)` są scalone pionowo. Zaczynając od niższej pozycji, używa [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) i [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) aby zlokalizować początek i sprawdza oba zakresy. `splitByRowSpan(1)` następnie oddziela wiersze 2 i 3 dla nazw produktów. Dla poziomego scalenia dwóch kolumn, użyj `splitByColSpan(1)` zamiast tego.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Pobierz powstałe komórki z tabeli po podziale.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz powstałe komórki według ich współrzędnych; tutaj obie mają zakres 1 i [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) zwraca `false`. Większe regiony mogą pozostać częściowo scalone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw wszelkie wymagane formatowanie tekstu explicite.

Zapisana prezentacja zawiera oddzielne komórki "Product A" i "Product B" z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) po więcej szczegółów.

## **Zmień kolor tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Używa [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) aby wybrać wypełnienie jednolite i ustawia kolor zwrócony przez [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodaj obraz wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile), a następnie dodaje go do kolekcji obrazów prezentacji przy użyciu [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Następnie przypisuje obraz do wypełnienia obrazu w komórce `(0, 0)`, czyli pierwszej komórce w tabeli.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnić komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy są podane w punktach. Załadowany obraz jest zwalniany w bloku `finally` po jego dodaniu do prezentacji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę ustawić różne grubości linii i style dla różnych stron jednej komórki?**

Tak. Obramowania [górna](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[dolna](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[lewa](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[prawa](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) są oddzielnymi właściwościami, więc grubość i styl każdej strony mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [tryb wypełnienia](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dostosowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hiperłącza](/slides/pl/nodejs-java/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (runs) z niezależnym formatowaniem — rodzina czcionki, styl, rozmiar i kolor.