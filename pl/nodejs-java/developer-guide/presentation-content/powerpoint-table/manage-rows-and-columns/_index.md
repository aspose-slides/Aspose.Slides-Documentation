---
title: "Zarządzanie wierszami i kolumnami w tabelach PowerPoint przy użyciu JavaScript"
linktitle: "Wiersze i kolumny"
type: docs
weight: 20
url: /pl/nodejs-java/manage-rows-and-columns/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js poprzez Java oraz przyspiesz edycję prezentacji i aktualizacje danych."
---
## **Wprowadzenie**

Aby umożliwić zarządzanie wierszami i kolumnami tabeli w prezentacji PowerPoint, Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/table/) oraz inne typy.

## **Ustaw pierwszy wiersz jako nagłówek**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wczytaj prezentację.  
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.  
3. Utwórz obiekt [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) i ustaw go na null.  
4. Iteruj po wszystkich obiektach [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) w celu znalezienia odpowiedniej tabeli.  
5. Ustaw pierwszy wiersz tabeli jako jej nagłówek.  

Ten kod JavaScript pokazuje, jak ustawić pierwszy wiersz tabeli jako jej nagłówek:

```javascript
// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Inicjalizuje pustą TableEx
    var tbl = null;
    // Iteruje po kształtach i ustawia odwołanie do tabeli
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Ustawia pierwszy wiersz tabeli jako nagłówek
            tbl.setFirstRow(true);
        }
    }
    // Zapisuje prezentację na dysk
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Klonowanie wiersza lub kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wczytaj prezentację,  
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.  
3. Zdefiniuj tablicę `columnWidth`.  
4. Zdefiniuj tablicę `rowHeight`.  
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Sklonuj wiersz tabeli.  
7. Sklonuj kolumnę tabeli.  
8. Zapisz zmodyfikowaną prezentację.  

Ten kod JavaScript pokazuje, jak sklonować wiersz lub kolumnę tabeli PowerPoint:

```javascript
// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Definiuje kolumny z szerokościami i wiersze z wysokościami
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Dodaje kształt tabeli do slajdu
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Dodaje tekst do komórki wiersza 1, komórki 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Dodaje tekst do komórki wiersza 1, komórki 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Klonuje wiersz 1 na koniec tabeli
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Dodaje tekst do komórki wiersza 2, komórki 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Dodaje tekst do komórki wiersza 2, komórki 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Klonuje wiersz 2 jako czwarty wiersz tabeli
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Klonuje pierwszą kolumnę na końcu
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Klonuje drugą kolumnę na indeksie czwartej kolumny
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Zapisuje prezentację na dysk
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usuwanie wiersza lub kolumny z tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wczytaj prezentację,  
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.  
3. Zdefiniuj tablicę `columnWidth`.  
4. Zdefiniuj tablicę `rowHeight`.  
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Usuń wiersz tabeli.  
7. Usuń kolumnę tabeli.  
8. Zapisz zmodyfikowaną prezentację.  

Ten kod JavaScript pokazuje, jak usunąć wiersz lub kolumnę z tabeli:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wczytaj prezentację,  
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.  
3. Uzyskaj dostęp do odpowiedniego obiektu [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) ze slajdu.  
4. Ustaw wysokość czcionki komórek pierwszego wiersza za pomocą [setFontHeight(float value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ustaw wyrównanie komórek pierwszego wiersza przy pomocy [setAlignment(int value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) oraz [setMarginRight(float value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Ustaw typ pionowego tekstu komórek drugiego wiersza przy użyciu [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Zapisz zmodyfikowaną prezentację.  

Ten kod JavaScript demonstruje działanie.

```javascript
// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Załóżmy, że pierwszym kształtem na pierwszym slajdzie jest tabela
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Ustawia wysokość czcionki komórek pierwszego wiersza
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Ustawia wyrównanie tekstu komórek pierwszego wiersza oraz prawy margines
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Ustawia pionowy typ tekstu komórek drugiego wiersza
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Zapisuje prezentację na dysk
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i wczytaj prezentację,  
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.  
3. Uzyskaj dostęp do odpowiedniego obiektu [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Table) ze slajdu.  
4. Ustaw wysokość czcionki komórek pierwszej kolumny za pomocą [setFontHeight(float value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ustaw wyrównanie komórek pierwszej kolumny przy pomocy [setAlignment(int value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) oraz [setMarginRight(float value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Ustaw typ pionowego tekstu komórek drugiej kolumny przy użyciu [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Zapisz zmodyfikowaną prezentację.  

Ten kod JavaScript demonstruje działanie:

```javascript
// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Załóżmy, że pierwszym kształtem na pierwszym slajdzie jest tabela
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Ustawia wysokość czcionki komórek pierwszej kolumny
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Ustawia wyrównanie tekstu komórek pierwszej kolumny oraz prawy margines w jednym wywołaniu
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Ustawia pionowy typ tekstu komórek drugiej kolumny
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Pobierz właściwości stylu tabeli**

Aspose.Slides pozwala pobrać właściwości stylu tabeli, aby można było użyć tych szczegółów w innej tabeli lub w innym miejscu. Ten kod JavaScript pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// zmień domyślny preset stylu motywu
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę zastosować motywy/stylizacje PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/master, a jednocześnie możesz nadpisać wypełnienia, obramowania i kolory tekstu na tym motywie.

**Czy mogę sortować wiersze tabeli tak jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj najpierw dane w pamięci, a następnie ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (prążkowane) kolumny, zachowując niestandardowe kolory w konkretnych komórkach?**

Tak. Włącz paskowane kolumny, a następnie nadpisz konkretne komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.