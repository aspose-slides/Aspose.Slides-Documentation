---
title: Zarządzanie wierszami i kolumnami w tabelach PowerPoint na Androidzie
linktitle: Wiersze i kolumny
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
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy użyciu Aspose.Slides for Android via Java oraz przyspiesz edycję prezentacji i aktualizację danych."
---
## **Wstęp**

Aspose.Slides for Android via Java umożliwia zarządzanie strukturą tabeli i jej formatowaniem w prezentacjach PowerPoint za pomocą klasy [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) i interfejsu [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/). Można wyznaczyć wiersz nagłówka, klonować lub usuwać wiersze i kolumny oraz zastosować formatowanie tekstu do całego wiersza lub kolumny.

Ten artykuł wyjaśnia te operacje na przykładach w języku Java. Pokazuje również, jak pobrać preset stylu tabeli, aby móc go ponownie użyć. Indeksy wierszy i kolumn tabeli są liczone od zera.

## **Kontrola wysokości wiersza**

Użyj [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) aby ustawić minimalną wysokość wiersza w punktach. Jest to dolna granica, a nie stała wysokość. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) zwraca faktyczną wysokość. Dostęp do wiersza uzyskuje się przez [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--).

Przykład ładuje plik [row-height-input.pptx](row-height-input.pptx), w którym tabela znajduje się jako pierwszy kształt na pierwszym slajdzie. Jej pierwszy wiersz zaczyna się od 70 punktów. Komórki używają tekstu Arial 18 pt, zawijania i marginesów górnego oraz dolnego po 6 pt; dłuższy tekst w drugiej kolumnie zawija się na kilka linii. Przykład zwiększa minimum do 100 punktów, a następnie zmniejsza je do 20 punktów, wypisuje faktyczną wysokość po każdej zmianie i zapisuje oba wyniki.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Przy użyciu dostarczonej prezentacji zwiększenie minimum dodaje przestrzeń do wiersza. Zmniejszenie go usuwa dodatkową przestrzeń, ale faktyczna wysokość pozostaje większa niż 20 punktów, ponieważ tekst i marginesy komórek wymagają więcej miejsca. Same obniżenie wartości minimalnej nie może wymusić wysokości poniżej wymaganego przez zawartość wiersza.

Na faktyczną wysokość wpływa kilka czynników:

- **Tekst i rozmiar czcionki:** dłuższy tekst, ręczne przełamania linii lub większa czcionka mogą wymagać więcej miejsca w pionie.
- **Zawijanie i szerokość kolumny:** przy włączonym zawijaniu zmniejszenie szerokości kolumny za pomocą [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) może spowodować powstanie większej liczby linii. Szersza kolumna może zmniejszyć potrzebną przestrzeń w pionie.
- **Marginesy komórek:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) i [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) dodają przestrzeń pionową. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) oraz [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) zmniejszają szerokość dostępną dla tekstu i mogą powodować dodatkowe zawijanie.

W tej tabeli, bez scalonych komórek, komórka wymagająca najwięcej pionowej przestrzeni wyznacza dolne ograniczenie wysokości całego wiersza. Aby skrócić wiersz, może być konieczne skrócenie tekstu, zmniejszenie rozmiaru czcionki lub marginesów, albo poszerzenie kolumny.

Poniższe obrazy przedstawiają tę samą tabelę w tej samej skali. W pokazanych wynikach faktyczne wysokości wynosiły 70, 100 i 55,2 punktu: ostatni wiersz pozostał wyższy niż jego minimalne 20 pt. Dokładne pomiary tekstu mogą się różnić w zależności od czcionek dostępnych w środowisku. Pobierz zapisane wyniki: [increased minimum](row-height-increased.pptx) i [decreased minimum](row-height-decreased.pptx).

| Oryginał: minimum 70 pt, rzeczywiste 70 pt | Zwiększone: minimum 100 pt, rzeczywiste 100 pt | Zmniejszone: minimum 20 pt, rzeczywiste 55,2 pt |
| --- | --- | --- |
| ![Oryginalna tabela z pierwszym wierszem o wysokości 70 punktów.](row-height-before.png) | ![Tabela po zwiększeniu minimum pierwszego wiersza do 100 punktów.](row-height-increased.png) | ![Tabela po zmniejszeniu minimum pierwszego wiersza do 20 punktów; zawinięty tekst utrzymuje wiersz wyższym niż minimum.](row-height-decreased.png) |

## **Ustaw pierwszy wiersz jako nagłówek**

Użyj metody [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) aby oznaczyć pierwszy wiersz jako nagłówek. Jego wygląd zależy od stylu tabeli zastosowanego do tabeli.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Uzyskaj dostęp do tabeli przechowywanej jako pierwszy kształt na slajdzie.
4. Włącz formatowanie nagłówka dla jej pierwszego wiersza.
5. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie. Włącza formatowanie nagłówka dla pierwszego wiersza i zapisuje plik `First_row_header.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Klonowanie wiersza lub kolumny tabeli**

Klonuj wiersze lub kolumny, aby ponownie użyć ich zawartości i formatowania. Można dodać kopię na koniec tabeli lub wstawić ją w określonej pozycji.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę przy użyciu metody [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Sklonuj wymagane wiersze.
6. Sklonuj wymagane kolumny.
7. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `Test.pptx` zawierającego co najmniej jeden slajd. Tworzy tabelę z trzema kolumnami i pięcioma wierszami, z wymiarami podanymi w punktach. Dodaje kopie pierwszego wiersza i kolumny, a następnie wstawia kopie drugiego wiersza i kolumny pod indeksem 3 (czwarte miejsce). Wynikowa tabela ma siedem wierszy i pięć kolumn. Argument `false` wyłącza klonowanie do sąsiadujących scalonych wierszy lub kolumn; w tej tabeli nie ma scalonych komórek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usuwanie wiersza lub kolumny z tabeli**

Usuwaj wiersze lub kolumny, które nie są już potrzebne w tabeli. Usunięcie elementu powoduje przesunięcie indeksów kolejnych wierszy lub kolumn.

1. Utwórz prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę przy użyciu metody [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
5. Usuń drugi wiersz i drugą kolumnę.
6. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 3 × 3 i usuwa wiersz oraz kolumnę o indeksie 1, pozostawiając tabelę 2 × 2 w pliku `TestTable_out.pptx`. Wymiary podane są w punktach. Argument `false` wyłącza usuwanie sąsiadujących scalonych wierszy lub kolumn; w tej tabeli nie ma scalonych komórek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

Zastosuj formatowanie tekstu do całego wiersza, aby utrzymać spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu oraz kierunek tekstu bez konieczności formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Użyj [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) dla pierwszego wiersza.
4. Użyj [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) i [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) dla pierwszego wiersza.
5. Użyj [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) dla drugiego wiersza.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie oraz co najmniej dwoma wierszami. Nakłada tekst 25‑pt, wyrównanie do prawej oraz prawy margines akapitu 20 pt na pierwszy wiersz, a następnie ustawia pionowy tekst w drugim wierszu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

Zastosuj formatowanie tekstu do całej kolumny, aby utrzymać spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu oraz kierunek tekstu bez konieczności formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Użyj [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) dla pierwszej kolumny.
4. Użyj [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) i [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) dla pierwszej kolumny.
5. Użyj [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) dla drugiej kolumny.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie oraz co najmniej dwiema kolumnami. Nakłada tekst 25‑pt, wyrównanie do prawej oraz prawy margines akapitu 20 pt na pierwszą kolumnę, a następnie ustawia pionowy tekst w drugiej kolumnie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pobieranie właściwości stylu tabeli**

Użyj metody [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) aby pobrać preset zastosowany do tabeli i ponownie użyć go w innej tabeli. Dzięki temu identyfikujesz preset zamiast indywidualnych nadpisań formatowania komórek.

Przykład tworzy tabelę, stosuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) i odczytuje preset. Wypisuje wartość całkowitą odpowiadającą `DarkStyle1` i zapisuje tabelę w pliku `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę zastosować motywy/stylizacje PowerPointa do już istniejącej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/matki, a jednocześnie możesz nadpisać wypełnienia, obramowania i kolory tekstu ponad tym motywem.

**Czy mogę sortować wiersze tabeli tak jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Najpierw posortuj dane w pamięci, a potem ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (prążkowane) kolumny, jednocześnie zachowując niestandardowe kolory w określonych komórkach?**

Tak. Włącz paskowane kolumny, a następnie nadpisz wybrane komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.