---
title: Zarządzanie tabelami prezentacji w Androidzie
linktitle: Zarządzaj tabelą
type: docs
weight: 10
url: /pl/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu Aspose.Slides dla Androida. Odkryj proste przykłady kodu w języku Java, które usprawnią Twoje procesy pracy z tabelami."
---
## **Wprowadzenie**

Tabela w programie PowerPoint jest efektywnym sposobem wyświetlania i prezentowania informacji. Informacje w siatce komórek (ustawionych w wierszach i kolumnach) są proste i łatwe do zrozumienia.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Table) , interfejs [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) , klasę [Cell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/cell/) , interfejs [ICell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icell/) oraz inne typy, które umożliwiają tworzenie, aktualizowanie i zarządzanie tabelami we wszystkich rodzajach prezentacji.

## **Utworzenie tabeli od podstaw**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) .
2. Uzyskaj odwołanie do slajdu przy użyciu jego indeksu. 
3. Zdefiniuj tablicę `columnWidth` .
4. Zdefiniuj tablicę `rowHeight` .
5. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) do slajdu przy użyciu metody [addTable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Iteruj przez każdy [ICell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icell/) , aby zastosować formatowanie do górnej, dolnej, prawej i lewej krawędzi.
7. Połącz pierwsze dwie komórki pierwszego wiersza tabeli. 
8. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframe/) komórki [ICell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icell/) .
9. Dodaj tekst do [TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframe/) .
10. Zapisz zmodyfikowaną prezentację.

```java
// Tworzy obiekt klasy Presentation, który reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiuje kolumny o podanych szerokościach i wiersze o podanych wysokościach
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Dodaje kształt tabeli do slajdu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ustawia formatowanie obramowania dla każdej komórki
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Łączy komórki 1 i 2 wiersza 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Dodaje tekst do połączonej komórki
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Zapisuje prezentację na dysku
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli numeracja komórek jest prosta i zaczyna się od zera. Pierwsza komórka w tabeli ma indeks 0,0 (kolumna 0, wiersz 0). 

Na przykład, komórki w tabeli o 4 kolumnach i 4 wierszach są numerowane w następujący sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten kod Java pokazuje, jak określić numerację komórek w tabeli:

```java
// Tworzy obiekt klasy Presentation, który reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Dodaje kształt tabeli do slajdu
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ustawia formatowanie obramowania dla każdej komórki
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Zapisuje prezentację na dysku
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dostęp do istniejącej tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) .
2. Uzyskaj odwołanie do slajdu zawierającego tabelę przy użyciu jego indeksu. 
3. Utwórz obiekt [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) i ustaw go na null.
4. Iteruj przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) , aż tabela zostanie znaleziona.

   Jeśli podejrzewasz, że slajd, z którym pracujesz, zawiera jedną tabelę, możesz po prostu sprawdzić wszystkie kształty, które zawiera. Gdy kształt zostanie zidentyfikowany jako tabela, możesz rzutować go na obiekt [Table](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Table) . Jednak jeśli slajd zawiera kilka tabel, lepiej jest wyszukać potrzebną tabelę przy użyciu jej metody [setAlternativeText(String value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Użyj obiektu [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) , aby pracować z tabelą. W poniższym przykładzie dodaliśmy nowy wiersz do tabeli.
6. Zapisz zmodyfikowaną prezentację.

```java
// Tworzy obiekt klasy Presentation, który reprezentuje plik PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Dostęp do pierwszego slajdu
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicjalizuje zmienną TableEx jako null
    ITable tbl = null;

    // Iteruje po kształtach i ustawia odwołanie do znalezionej tabeli
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Ustawia tekst dla pierwszej kolumny drugiego wiersza
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Zapisuje zmodyfikowaną prezentację na dysku
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Wyrównanie tekstu w tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) .
2. Uzyskaj odwołanie do slajdu przy użyciu jego indeksu. 
3. Dodaj obiekt [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) do slajdu.
4. Uzyskaj dostęp do obiektu [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) z tabeli.
5. Uzyskaj dostęp do [IParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/) z [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) .
6. Wyrównaj tekst pionowo.
7. Zapisz zmodyfikowaną prezentację.

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Definiuje kolumny o szerokościach i wiersze o wysokościach
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Dodaje kształt tabeli do slajdu
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Uzyskuje dostęp do ramki tekstowej
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Tworzy obiekt Paragraph dla ramki tekstowej
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Tworzy obiekt Portion dla akapitu
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Wyrównuje tekst pionowo
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Zapisuje prezentację na dysku
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) .
2. Uzyskaj odwołanie do slajdu przy użyciu jego indeksu. 
3. Uzyskaj dostęp do obiektu [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable) ze slajdu.
4. Ustaw [setFontHeight(float value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) dla tekstu.
5. Ustaw [setAlignment(int value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) i [setMarginRight(float value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Ustaw [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Zapisz zmodyfikowaną prezentację. 

```java
// Tworzy instancję klasy Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Ustawia wysokość czcionki komórek tabeli
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Ustawia wyrównanie tekstu komórek tabeli i prawy margines w jednym wywołaniu
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Ustawia pionowy typ tekstu komórek tabeli
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Pobieranie właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można je było wykorzystać w innej tabeli lub gdzie indziej. Ten kod Java pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // zmień domyślny styl presetowy motywu
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zablokowanie proporcji tabeli**

Proporcje geometrycznego kształtu to stosunek jego wymiarów w różnych kierunkach. Aspose.Slides udostępnia właściwość [**setAspectRatioLocked**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) , która pozwala zablokować ustawienie proporcji dla tabel i innych kształtów.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // odwróć

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę włączyć kierunek czytania od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [setRightToLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) , a akapity mają [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) . Użycie obu zapewnia prawidłową kolejność RTL i renderowanie wewnątrz komórek.

**Jak mogę zapobiec przenoszeniu lub zmianie rozmiaru tabeli przez użytkowników w finalnym pliku?**

Użyj blokad kształtu, aby wyłączyć przenoszenie, zmianę rozmiaru, wybór itp. Te blokady dotyczą również tabel.

**Czy wstawianie obrazu jako tła wewnątrz komórki jest obsługiwane?**

Tak. Można ustawić [picture fill](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).