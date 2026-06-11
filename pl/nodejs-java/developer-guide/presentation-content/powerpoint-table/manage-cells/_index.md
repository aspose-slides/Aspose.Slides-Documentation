---
title: Zarządzanie komórkami tabeli w prezentacjach przy użyciu JavaScript
linktitle: Zarządzanie komórkami
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
description: "Zarządzaj komórkami tabeli w PowerPoint przy użyciu Aspose.Slides dla Node.js. Opanuj szybki dostęp, modyfikację i stylizację komórek, aby zapewnić płynną automatyzację slajdów."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabeli w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować połączone komórki tabeli, usunąć obramowanie komórek, pracować z numeracją komórek po scaleniu lub podziale, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek za pomocą właściwości komórki oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

## **Identyfikacja połączonych komórek tabeli**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Pobierz tabelę z pierwszego slajdu. 
3. Iteruj po wierszach i kolumnach tabeli, aby znaleźć połączone komórki.
4. Wypisz komunikat, gdy zostaną znalezione połączone komórki.

Ten kod JavaScript pokazuje, jak zidentyfikować połączone komórki tabeli w prezentacji:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// zakładając, że Slide#0.Shape#0 jest tabelą
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usuwanie obramowań komórek tabeli**
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu przez jego indeks. 
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu przy użyciu metody [addTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Iteruj po każdej komórce, aby usunąć górne, dolne, prawe i lewe obramowania.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak usunąć obramowania z komórek tabeli:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Definiuje kolumny o podanych szerokościach i wiersze o podanych wysokościach
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Dodaje kształt tabeli do slajdu
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ustawia format obramowania dla każdej komórki
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Zapisuje plik PPTX na dysku
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numeracja w połączonych komórkach**
Jeśli połączymy 2 pary komórek (1, 1) x (2, 1) oraz (1, 2) x (2, 2), powstała tabela będzie numerowana. Ten kod JavaScript demonstruje proces:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Definiuje kolumny o podanych szerokościach i wiersze o podanych wysokościach
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Dodaje kształt tabeli do slajdu
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ustawia format obramowania dla każdej komórki
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Łączy komórki (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Łączy komórki (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Następnie dalej łączymy komórki, scalając (1, 1) i (1, 2). Wynikiem jest tabela zawierająca dużą połączoną komórkę w jej centrum:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Definiuje kolumny o podanych szerokościach i wiersze o podanych wysokościach
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Dodaje kształt tabeli do slajdu
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ustawia format obramowania dla każdej komórki
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Łączy komórki (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Łączy komórki (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Łączy komórki (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // Zapisuje plik PPTX na dysku
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numeracja w podzielonej komórce**
W poprzednich przykładach, gdy komórki tabeli były łączone, numeracja lub system numeracji w pozostałych komórkach nie ulegał zmianie. 

Tym razem bierzemy zwykłą tabelę (tabelę bez połączonych komórek), a następnie próbujemy podzielić komórkę (1,1), aby uzyskać specjalną tabelę. Warto zwrócić uwagę na numerację tej tabeli, która może wydawać się dziwna. Jednak tak właśnie Microsoft PowerPoint numeruje komórki tabeli i Aspose.Slides postępuje tak samo. 

Ten kod JavaScript demonstruje opisany przez nas proces:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Definiuje kolumny o podanych szerokościach i wiersze o podanych wysokościach
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Dodaje kształt tabeli do slajdu
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ustawia format obramowania dla każdej komórki
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Łączy komórki (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Łączy komórki (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Dzieli komórkę (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Zapisuje plik PPTX na dysku
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zmiana koloru tła komórki tabeli**

Ten kod JavaScript pokazuje, jak zmienić kolor tła komórki tabeli:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // utwórz nową tabelę
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // ustaw kolor tła dla komórki
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Dodanie obrazu wewnątrz komórki tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Uzyskaj referencję do slajdu przez jego indeks.
3. Zdefiniuj tablicę kolumn z szerokością.
4. Zdefiniuj tablicę wierszy z wysokością.
5. Dodaj tabelę do slajdu przy użyciu metody [addTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Utwórz obiekt `Images`, aby przechować plik obrazu.
7. Dodaj obraz `IImage` do obiektu `PPImage`.
8. Ustaw `FillFormat` dla komórki tabeli na `Picture`.
9. Dodaj obraz do pierwszej komórki tabeli.
10. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript pokazuje, jak umieścić obraz wewnątrz komórki tabeli przy tworzeniu tabeli:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var islide = pres.getSlides().get_Item(0);
    // Definiuje kolumny o podanych szerokościach i wiersze o podanych wysokościach
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Dodaje kształt tabeli do slajdu
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Tworzy obiekt PPImage przy użyciu pliku obrazu
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Dodaje obraz do pierwszej komórki tabeli
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Zapisuje plik PPTX na dysku
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę ustawić różne grubości linii i style dla różnych boków jednej komórki?**

Tak. Granice [górna](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cellformat/getbordertop/)/[dolna](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[lewa](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cellformat/getborderleft/)/[prawa](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cellformat/getborderright/) mają oddzielne właściwości, więc grubość i styl każdej z nich mogą się różnić. Wynika to logicznie z kontroli granic po stronie każdej komórki wykazanej w artykule.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tło komórki?**

Zachowanie zależy od [trybu wypełnienia](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillmode/) (rozciąganie/kafelkowanie). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są ponownie obliczane. Artykuł wspomina o trybach wyświetlania obrazu w komórce.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinki](/slides/pl/nodejs-java/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) (runy) z niezależnym formatowaniem — rodzinę czcionki, styl, rozmiar i kolor.