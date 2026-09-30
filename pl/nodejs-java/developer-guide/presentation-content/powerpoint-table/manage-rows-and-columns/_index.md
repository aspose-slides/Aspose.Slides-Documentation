---
title: Zarządzanie wierszami i kolumnami w tabelach PowerPoint przy użyciu JavaScript
linktitle: Wiersze i kolumny
type: docs
weight: 20
url: /pl/nodejs-java/manage-rows-and-columns/
keywords:
- wiersz tabeli
- kolumna tabeli
- pierwszy wiersz
- nagłówek tabeli
- klonuj wiersz
- klonuj kolumnę
- kopiuj wiersz
- kopiuj kolumnę
- usuń wiersz
- usuń kolumnę
- formatowanie tekstu wiersza
- formatowanie tekstu kolumny
- styl tabeli
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w programie PowerPoint przy użyciu JavaScript oraz Aspose.Slides dla Node.js przez Java, aby przyspieszyć edycję prezentacji i aktualizację danych."
---
## **Wprowadzenie**

Aspose.Slides for Node.js via Java umożliwia zarządzanie strukturą i formatowaniem tabel w prezentacjach PowerPoint przy użyciu klasy [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Możesz wyznaczyć wiersz nagłówka, klonować lub usuwać wiersze i kolumny oraz zastosować formatowanie tekstu do całego wiersza lub kolumny.

Ten artykuł wyjaśnia te operacje przy użyciu przykładów w JavaScript. Pokazuje również, jak pobrać preset stylu tabeli, aby można go ponownie wykorzystać. Indeksy wierszy i kolumn tabeli zaczynają się od zera.

## **Kontrola wysokości wiersza**

Użyj [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) , aby ustawić minimalną wysokość wiersza w punktach. Jest to dolna granica, a nie stała wysokość. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) zwraca rzeczywistą wysokość. Dostęp do wiersza uzyskujesz poprzez [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

Przykład ładuje plik [row-height-input.pptx](row-height-input.pptx), który zawiera tabelę jako pierwszy kształt na pierwszym slajdzie. Jej pierwszy wiersz zaczyna się od 70 punktów. Komórki używają tekstu Arial 18‑punktowego, z zawijaniem i marginesami górnym i dolnym po 6 punktów; dłuższy tekst w drugiej kolumnie zawija się na kilka linii. Przykład zwiększa minimalną wysokość do 100 punktów, a następnie zmniejsza ją do 20 punktów, wypisuje rzeczywistą wysokość po każdej zmianie i zapisuje oba wyniki.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W dostarczonej prezentacji zwiększenie wartości minimalnej dodaje przestrzeń do wiersza. Zmniejszenie jej usuwa tę dodatkową przestrzeń, ale rzeczywista wysokość pozostaje większa niż 20 punktów, ponieważ tekst i marginesy komórek potrzebują więcej miejsca. Samo zmniejszenie wartości minimalnej nie może wymusić, aby wiersz był niższy niż wymaganą przez jego treść przestrzeń.

Na rzeczywistą wysokość wpływa kilka czynników:

- **Tekst i rozmiar czcionki:** dłuższy tekst, wymuszone podziały wierszy lub większa czcionka mogą wymagać więcej miejsca w pionie.  
- **Zawijanie i szerokość kolumny:** przy włączonym zawijaniu, zmniejszenie szerokości kolumny przy użyciu [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) może spowodować powstanie większej liczby wierszy. Szersza kolumna może zmniejszyć wymaganą przestrzeń pionową.  
- **Marginesy komórek:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) i [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) dodają przestrzeń w pionie. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) i [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) zmniejszają dostępny dla tekstu szerokość i mogą powodować dodatkowe zawijanie.

W przypadku tej tabeli bez scalonych komórek, komórka wymagająca najwięcej pionowej przestrzeni określa ograniczenie dolne całego wiersza oparte na zawartości. Aby skrócić wiersz, może być konieczne skrócenie tekstu, zmniejszenie rozmiaru czcionki lub marginesów, albo poszerzenie kolumny.

Poniższe obrazy pokazują tę samą tabelę w tym samym skali. W przedstawionych wynikach rzeczywiste wysokości wynosiły 70, 100 i 55,2 punktu: ostatni wiersz pozostał wyższy niż jego minimalna wartość 20 punktów. Dokładne pomiary tekstu mogą się różnić w zależności od dostępnych w Twoim środowisku czcionek. Pobierz zapisane wyniki: [zwiększone minimum](row-height-increased.pptx) i [zmniejszone minimum](row-height-decreased.pptx).

| Oryginalne: minimum 70 pt, rzeczywisty 70 pt | Zwiększone: minimum 100 pt, rzeczywisty 100 pt | Zmniejszone: minimum 20 pt, rzeczywisty 55.2 pt |
| --- | --- | --- |
| ![Oryginalna tabela z pierwszym wierszem o wysokości 70 punktów.](row-height-before.png) | ![Tabela po zwiększeniu minimalnej wysokości pierwszego wiersza do 100 punktów.](row-height-increased.png) | ![Tabela po zmniejszeniu minimalnej wysokości pierwszego wiersza do 20 punktów; zawijany tekst utrzymuje wiersz wyższym niż minimum.](row-height-decreased.png) |

## **Ustaw pierwszy wiersz jako nagłówek**

Użyj metody [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) , aby oznaczyć pierwszy wiersz do formatowania jako nagłówek. Jego wygląd zależy od zastosowanego stylu tabeli.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Uzyskaj dostęp do pierwszego slajdu.  
3. Uzyskaj dostęp do tabeli przechowywanej jako pierwszy kształt na slajdzie.  
4. Włącz formatowanie nagłówka dla jej pierwszego wiersza.  
5. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie. Włącza formatowanie nagłówka dla pierwszego wiersza i zapisuje plik `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Klonowanie wiersza lub kolumny tabeli**

Klonuj wiersze lub kolumny, aby ponownie wykorzystać ich zawartość i formatowanie. Możesz dodać kopię na koniec tabeli lub wstawić ją w określone miejsce.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Uzyskaj dostęp do pierwszego slajdu.  
3. Zdefiniuj szerokości kolumn i wysokości wierszy.  
4. Dodaj tabelę przy użyciu metody [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
5. Sklonuj wymagane wiersze.  
6. Sklonuj wymagane kolumny.  
7. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `Test.pptx` z co najmniej jednym slajdem. Tworzy tabelę z trzema kolumnami i pięcioma wierszami, o wymiarach podanych w punktach. Dodaje kopie pierwszego wiersza i kolumny, a następnie wstawia kopie drugiego wiersza i kolumny pod indeksem 3 (czwarte pozycje). Powstała tabela ma siedem wierszy i pięć kolumn. Argument `false` wyłącza klonowanie do sąsiednich scalonych wierszy lub kolumn; ta tabela nie zawiera scalonych komórek.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usuwanie wiersza lub kolumny z tabeli**

Usuń wiersze lub kolumny, które nie są już potrzebne w tabeli. Usunięcie elementu przesuwa indeksy wierszy lub kolumn, które po nim następują.

1. Utwórz prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Uzyskaj dostęp do pierwszego slajdu.  
3. Zdefiniuj szerokości kolumn i wysokości wierszy.  
4. Dodaj tabelę przy użyciu metody [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
5. Usuń drugi wiersz i drugą kolumnę.  
6. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę trzy na trzy i usuwa wiersz oraz kolumnę o indeksie 1, pozostawiając tabelę dwa na dwa w pliku `TestTable_out.pptx`. Wymiary podane są w punktach. Argument `false` wyłącza usuwanie sąsiednich scalonych wierszy lub kolumn; ta tabela nie zawiera scalonych komórek.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

Zastosuj formatowanie tekstu do całego wiersza, aby zachować spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.  
3. Użyj [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) dla pierwszego wiersza.  
4. Użyj [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) i [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) dla pierwszego wiersza.  
5. Użyj [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) dla drugiego wiersza.  
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie i co najmniej dwoma wierszami. Zastosowuje tekst o rozmiarze 25 punktów, wyrównanie do prawej oraz 20‑punktowy prawy margines akapitu w pierwszym wierszu, a następnie ustawia tekst pionowy w drugim wierszu.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

Zastosuj formatowanie tekstu do całej kolumny, aby zachować spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.  
3. Użyj [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) dla pierwszej kolumny.  
4. Użyj [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) i [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) dla pierwszej kolumny.  
5. Użyj [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) dla drugiej kolumny.  
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie i co najmniej dwiema kolumnami. Zastosowuje tekst o rozmiarze 25 punktów, wyrównanie do prawej oraz 20‑punktowy prawy margines akapitu w pierwszej kolumnie, a następnie ustawia tekst pionowy w drugiej kolumnie.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pobieranie właściwości stylu tabeli**

Użyj metody [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) , aby pobrać preset zastosowany do tabeli i ponownie użyć go w innej tabeli. Określa to preset zamiast indywidualnych nadpisań formatowania komórek.

Przykład tworzy tabelę, stosuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) i odczytuje ten preset. Wypisuje wartość całkowitą odpowiadającą `DarkStyle1` i zapisuje tabelę w pliku `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę zastosować tematy/style PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy temat slajdu/układu/mistrza i nadal możesz nadpisać wypełnienia, obramowania oraz kolory tekstu ponad tym tematem.

**Czy mogę sortować wiersze tabeli tak jak w Excelu?**

Nie, tabele Aspose.Slides nie posiadają wbudowanego sortowania ani filtrów. Najpierw posortuj dane w pamięci, a następnie ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (prążkowane) kolumny, zachowując jednocześnie niestandardowe kolory w określonych komórkach?**

Tak. Włącz paskowane kolumny, a następnie nadpisz konkretne komórki formatowaniem lokalnym; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.