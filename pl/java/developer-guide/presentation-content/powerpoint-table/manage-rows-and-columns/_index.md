---
title: Zarządzanie wierszami i kolumnami w tabelach PowerPoint przy użyciu Javy
linktitle: Wiersze i kolumny
type: docs
weight: 20
url: /pl/java/manage-rows-and-columns/
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
- Java
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint za pomocą Aspose.Slides dla Javy i przyspiesz edycję prezentacji oraz aktualizację danych."
---
## **Wprowadzenie**

Aby umożliwić zarządzanie wierszami i kolumnami tabeli w prezentacji PowerPoint, Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/java/com.aspose.slides/table/) , interfejs [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITable) oraz wiele innych typów. 

## **Ustaw pierwszy wiersz jako nagłówek**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i załaduj prezentację. 
2. Uzyskaj odniesienie do slajdu przez jego indeks. 
3. Utwórz obiekt [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITable) i ustaw go na null. 
4. Przejdź przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) w celu odnalezienia odpowiedniej tabeli. 
5. Ustaw pierwszy wiersz tabeli jako jej nagłówek. 

Ten kod Java pokazuje, jak ustawić pierwszy wiersz tabeli jako nagłówek:

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicjalizuje nullowy TableEx
    ITable tbl = null;

    // Iteruje przez kształty i ustawia odniesienie do tabeli
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Ustawia pierwszy wiersz tabeli jako nagłówek
            tbl.setFirstRow(true);
        }
    }
    
    // Zapisuje prezentację na dysku
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Klonowanie wiersza lub kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i załaduj prezentację, 
2. Uzyskaj odniesienie do slajdu przez jego indeks. 
3. Zdefiniuj tablicę `columnWidth`. 
4. Zdefiniuj tablicę `rowHeight`. 
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITable) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Sklonuj wiersz tabeli. 
7. Sklonuj kolumnę tabeli. 
8. Zapisz zmodyfikowaną prezentację. 

Ten kod Java pokazuje, jak sklonować wiersz lub kolumnę tabeli PowerPoint:

```java
 // Tworzy instancję klasy Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Dodaje kształt tabeli na slajdzie
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Dodaje tekst do wiersza 1, komórki 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Dodaje tekst do wiersza 1, komórki 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Klonuje wiersz 1 na końcu tabeli
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Dodaje tekst do wiersza 2, komórki 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Dodaje tekst do wiersza 2, komórki 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Klonuje wiersz 2 jako czwarty wiersz tabeli
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Klonuje pierwszą kolumnę na końcu
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klonuje drugą kolumnę pod indeksem 4
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Zapisuje prezentację na dysku
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie wiersza lub kolumny z tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i załaduj prezentację, 
2. Uzyskaj odniesienie do slajdu przez jego indeks. 
3. Zdefiniuj tablicę `columnWidth`. 
4. Zdefiniuj tablicę `rowHeight`. 
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITable) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Usuń wiersz tabeli. 
7. Usuń kolumnę tabeli. 
8. Zapisz zmodyfikowaną prezentację. 

Ten kod Java pokazuje, jak usunąć wiersz lub kolumnę z tabeli:

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

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i załaduj prezentację, 
2. Uzyskaj odniesienie do slajdu przez jego indeks. 
3. Uzyskaj dostęp do odpowiedniego obiektu [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITable) ze slajdu. 
4. Ustaw wysokość czcionki komórek pierwszego wiersza metodą [setFontHeight(float value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Ustaw wyrównanie komórek pierwszego wiersza metodą [setAlignment(int value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) oraz prawy margines metodą [setMarginRight(float value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Ustaw orientację tekstu w komórkach drugiego wiersza metodą [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Zapisz zmodyfikowaną prezentację. 

Ten kod Java demonstruje tę operację.

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
    
    // Ustawia wyrównanie tekstu i prawy margines komórek pierwszego wiersza
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Ustawia typ pionowego tekstu komórek drugiego wiersza
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Zapisuje prezentację na dysku
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i załaduj prezentację, 
2. Uzyskaj odniesienie do slajdu przez jego indeks. 
3. Uzyskaj dostęp do odpowiedniego obiektu [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITable) ze slajdu. 
4. Ustaw wysokość czcionki komórek pierwszej kolumny metodą [setFontHeight(float value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseportionformat/#setFontHeight-float-). 
5. Ustaw wyrównanie komórek pierwszej kolumny metodą [setAlignment(int value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) oraz prawy margines metodą [setMarginRight(float value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Ustaw orientację tekstu w komórkach drugiej kolumny metodą [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-). 
7. Zapisz zmodyfikowaną prezentację. 

Ten kod Java demonstruje tę operację:

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

    // Ustawia wyrównanie tekstu i prawy margines komórek pierwszej kolumny w jednym wywołaniu
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Ustawia typ pionowego tekstu komórek drugiej kolumny
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Pobieranie właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można je było zastosować do innej tabeli lub w innym miejscu. Ten kod Java pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // zmień domyślny preset stylu
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę zastosować motywy/stylizacje PowerPoint do już istniejącej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/masters, a jednocześnie możesz nadpisać wypełnienia, obramowania i kolory tekstu.

**Czy mogę sortować wiersze tabeli tak jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj dane w pamięci, a następnie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (przebarwione) kolumny, zachowując jednocześnie niestandardowe kolory w konkretnych komórkach?**

Tak. Włącz paskowanie kolumn, a następnie nadpisz wybrane komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.