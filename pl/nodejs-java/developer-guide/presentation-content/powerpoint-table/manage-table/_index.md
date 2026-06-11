---
title: Zarządzaj tabelami prezentacji w JavaScript
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
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js. Odkryj proste przykłady kodu, aby usprawnić swoje procesy pracy z tabelami."
---
## **Wprowadzenie**

Tabela w programie PowerPoint to wydajny sposób wyświetlania i prezentowania informacji. Informacje w siatce komórek (ustawionych w wierszach i kolumnach) są przejrzyste i łatwe do zrozumienia.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table), klasę [Cell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cell/) oraz inne typy, które pozwalają tworzyć, aktualizować i zarządzać tabelami we wszystkich rodzajach prezentacji.

## **Utwórz tabelę od podstaw**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Pobierz odwołanie do slajdu przez jego indeks. 
3. Zdefiniuj tablicę `columnWidth`.
4. Zdefiniuj tablicę `rowHeight`.
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Przejdź przez każdą [Cell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cell/) i zastosuj formatowanie górnej, dolnej, prawej i lewej krawędzi.
7. Połącz pierwsze dwie komórki pierwszego wiersza tabeli. 
8. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) komórki [Cell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cell/).
9. Dodaj tekst do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/).
10. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript pokazuje, jak utworzyć tabelę w prezentacji:

```javascript
// Tworzy instancję klasy Presentation reprezentującej plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Definiuje kolumny z szerokościami i wiersze z wysokościami
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Dodaje kształt tabeli do slajdu
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ustawia format krawędzi dla każdej komórki
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Łączy komórki 1 i 2 wiersza 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Dodaje tekst do połączonej komórki
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Zapisuje prezentację na dysk
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli numeracja komórek jest prosta i rozpoczyna się od zera. Pierwsza komórka w tabeli ma indeks 0,0 (kolumna 0, wiersz 0). 

Na przykład, komórki w tabeli o 4 kolumnach i 4 wierszach są numerowane w ten sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten kod JavaScript pokazuje, jak określić numerację komórek w tabeli:

```javascript
// Tworzy instancję klasy Presentation reprezentującej plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Dodaje kształt tabeli do slajdu
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Ustawia format krawędzi dla każdej komórki
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
    // Zapisuje prezentację na dysk
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dostęp do istniejącej tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).

2. Pobierz odwołanie do slajdu zawierającego tabelę przez jego indeks. 

3. Utwórz obiekt [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) i ustaw go na null.

4. Przejdź przez wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) aż znajdziesz tabelę.

   Jeśli podejrzewasz, że slajd, z którym pracujesz, zawiera jedną tabelę, możesz po prostu sprawdzić wszystkie znajdujące się na nim kształty. Gdy kształt zostanie zidentyfikowany jako tabela, możesz rzutować go na obiekt [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table). Jeśli jednak slajd zawiera kilka tabel, lepiej wyszukać potrzebną tabelę po jej [setAlternativeText(String value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Użyj obiektu [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) do pracy z tabelą. W poniższym przykładzie dodaliśmy nowy wiersz do tabeli.

6. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript pokazuje, jak uzyskać dostęp i pracować z istniejącą tabelą:

```javascript
// Tworzy instancję klasy Presentation reprezentującej plik PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Inicjalizuje zmienną TableEx jako null
    var tbl = null;
    // Przegląda kształty i ustawia odwołanie do znalezionej tabeli
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Ustawia tekst dla pierwszej kolumny drugiego wiersza
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Zapisuje zmodyfikowaną prezentację na dysk
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Wyrównaj tekst w tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Pobierz odwołanie do slajdu przez jego indeks. 
3. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) do slajdu.
4. Uzyskaj dostęp do obiektu [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) z tabeli.
5. Uzyskaj dostęp do [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) w [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/).
6. Wyrównaj tekst pionowo.
7. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript pokazuje, jak wyrównać tekst w tabeli:

```javascript
// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje pierwszy slajd
    var slide = pres.getSlides().get_Item(0);
    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Dodaje kształt tabeli do slajdu
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Uzyskuje dostęp do ramki tekstowej
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Tworzy obiekt Paragraph dla ramki tekstowej
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Tworzy obiekt Portion dla akapitu
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Wyrównuje tekst pionowo
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Zapisuje prezentację na dysk
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Pobierz odwołanie do slajdu przez jego indeks. 
3. Uzyskaj dostęp do obiektu [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) ze slajdu.
4. Ustaw [setFontHeight(float value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) dla tekstu.
5. Ustaw [setAlignment(int value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) oraz [setMarginRight(float value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Ustaw [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Zapisz zmodyfikowaną prezentację. 

Ten kod JavaScript pokazuje, jak zastosować wybrane opcje formatowania do tekstu w tabeli:

```javascript
// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Ustawia wysokość czcionki komórek tabeli
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Ustawia wyrównanie tekstu komórek tabeli i prawy margines w jednym wywołaniu
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Ustawia pionowy typ tekstu komórek tabeli
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Pobierz właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można było użyć ich przy innej tabeli lub w innym miejscu. Ten kod JavaScript pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// zmień domyślny preset stylu
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zablokuj proporcje tabeli**

Proporcje geometrycznego kształtu to stosunek jego wymiarów w różnych płaszczyznach. Aspose.Slides udostępnia właściwość [**setAspectRatioLocked**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-), aby umożliwić zablokowanie ustawienia proporcji dla tabel i innych kształtów.

Ten kod JavaScript pokazuje, jak zablokować proporcje tabeli:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę włączyć tryb od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [setRightToLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/table/setrighttoleft/), a akapity mają [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Użycie obu zapewnia prawidłowy porządek RTL i renderowanie wewnątrz komórek.

**Jak mogę zapobiec przenoszeniu lub zmienianiu rozmiaru tabeli przez użytkowników w finalnym pliku?**

Użyj blokad kształtu, aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Blokady te dotyczą także tabel.

**Czy wstawianie obrazu jako tła w komórce jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).