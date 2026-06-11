---
title: Zarządzanie wierszami i kolumnami w tabelach PowerPoint na Androidzie
linktitle: Wiersze i Kolumny
type: docs
weight: 20
url: /pl/androidjava/manage-rows-and-columns/
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
- Android
- Java
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy użyciu Aspose.Slides dla Androida w Javie i przyspiesz edycję prezentacji oraz aktualizację danych."
---
## **Wstęp**

Aby umożliwić zarządzanie wierszami i kolumnami tabeli w prezentacji PowerPoint, Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/table/) , interfejs [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) oraz wiele innych typów.

## **Ustaw pierwszy wiersz jako nagłówek**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i załaduj prezentację.
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Utwórz obiekt [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) i ustaw go na null.
4. Iteruj po wszystkich obiektach [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) , aby znaleźć odpowiednią tabelę.
5. Ustaw pierwszy wiersz tabeli jako jej nagłówek.

Poniższy kod Java pokazuje, jak ustawić pierwszy wiersz tabeli jako nagłówek:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicjalizuje zmienną null TableEx
    ITable tbl = null;

    // Iteruje po kształtach i ustawia odwołanie do tabeli
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            // Ustawia pierwszy wiersz tabeli jako nagłówek
            tbl.setFirstRow(true);
        }
    }
    
    // Zapisuje prezentację na dysk
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Klonowanie wiersza lub kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i załaduj prezentację,
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę `columnWidth`.
4. Zdefiniuj tablicę `rowHeight`.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Sklonuj wiersz tabeli.
7. Sklonuj kolumnę tabeli.
8. Zapisz zmodyfikowaną prezentację.

Poniższy kod Java pokazuje, jak sklonować wiersz lub kolumnę tabeli PowerPoint:

```java
 // Tworzy instancję klasy Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Dodaje kształt tabeli do slajdu
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Dodaje tekst do komórki wiersza 1, kolumny 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Dodaje tekst do komórki wiersza 1, kolumny 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Klonuje wiersz 1 na końcu tabeli
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Dodaje tekst do komórki wiersza 2, kolumny 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Dodaje tekst do komórki wiersza 2, kolumny 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Klonuje wiersz 2 jako czwarty wiersz tabeli
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Klonuje pierwszą kolumnę na końcu
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klonuje drugą kolumnę pod indeksem 4
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Zapisuje prezentację na dysk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie wiersza lub kolumny z tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i załaduj prezentację,
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę `columnWidth`.
4. Zdefiniuj tablicę `rowHeight`.
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) .
6. Usuń wiersz tabeli.
7. Usuń kolumnę tabeli.
8. Zapisz zmodyfikowaną prezentację.

Poniższy kod Java pokazuje, jak usunąć wiersz lub kolumnę z tabeli:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i załaduj prezentację,
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do odpowiedniego obiektu [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) ze slajdu.
4. Ustaw w komórkach pierwszego wiersza metodę [setFontHeight(float value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Ustaw w komórkach pierwszego wiersza [setAlignment(int value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) oraz [setMarginRight(float value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Ustaw w komórkach drugiego wiersza [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Zapisz zmodyfikowaną prezentację.

Poniższy kod Java demonstruje tę operację.

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Ustawia wysokość czcionki komórek pierwszego wiersza
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Ustawia wyrównanie tekstu komórek pierwszego wiersza i prawy margines
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Ustawia pionowy typ tekstu komórek drugiego wiersza
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Zapisuje prezentację na dysk
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i załaduj prezentację,
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do odpowiedniego obiektu [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) ze slajdu.
4. Ustaw w komórkach pierwszej kolumny metodę [setFontHeight(float value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).
5. Ustaw w komórkach pierwszej kolumny [setAlignment(int value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) oraz [setMarginRight(float value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Ustaw w komórkach drugiej kolumny [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Zapisz zmodyfikowaną prezentację.

Poniższy kod Java demonstruje tę operację:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Ustawia wysokość czcionki komórek pierwszej kolumny
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Ustawia wyrównanie tekstu i prawy margines komórek pierwszej kolumny w jednej operacji
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Ustawia pionowy typ tekstu komórek drugiej kolumny
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Pobieranie właściwości stylu tabeli**

Aspose.Slides pozwala pobrać właściwości stylu tabeli, aby można było użyć tych informacji w innej tabeli lub w innym miejscu. Poniższy kod Java pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // zmień domyślny predefiniowany styl motywu
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę zastosować motywy/stylu PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/dużego szablonu i nadal można nadpisać wypełnienia, obramowania i kolory tekstu w ramach tego motywu.

**Czy mogę sortować wiersze tabeli tak jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj najpierw dane w pamięci, a następnie ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (prążkowane) kolumny, zachowując jednocześnie niestandardowe kolory w wybranych komórkach?**

Tak. Włącz paskowane kolumny, a następnie nadpisz konkretne komórki formatowaniem lokalnym; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.