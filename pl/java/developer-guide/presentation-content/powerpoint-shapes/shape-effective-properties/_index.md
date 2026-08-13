---
title: Pobierz efektywne właściwości kształtu z prezentacji w Javie
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/java/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- system oświetlenia
- kształt fazowany
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides dla Javy, aby rozróżniać lokalne, dziedziczone i efektywne formatowanie kształtów w prezentacjach PowerPoint."
---
## **Zrozumienie właściwości lokalnych, dziedziczonych i efektywnych**

Formatowanie PowerPoint może pochodzić z kilku miejsc. Wartość przechowywana bezpośrednio na obiekcie jest jego **wartością lokalną**. Jeśli ta wartość nie jest ustawiona, PowerPoint przegląda źródła formatowania nadrzędnego, takie jak domyślne ustawienie akapitu, styl tekstu, układ lub slajd główny, motyw lub domyślne ustawienia prezentacji. Te wartości są **wartościami dziedziczonymi**. Wartość, która pozostaje po rozwiązaniu całej hierarchii, jest **wartością efektywną** — wartością używaną do renderowania obiektu.

Na przykład fragment tekstu może nie definiować własnej wysokości czcionki. Jego lokalna wartość [getFontHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) to wtedy `Float.NaN`, co oznacza „nie ustawiono tutaj”. Fragment może dziedziczyć wysokość z akapitu, domyślnego stylu tekstu prezentacji lub innego odpowiedniego źródła. Wywołanie [getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportionformat/#getEffective--) na formacie fragmentu zwraca ostateczną rozwiązana wysokość.

Używaj dwóch rodzajów danych formatowania w różnych celach:

- Odczyt lub zmiana lokalnego obiektu formatu, takiego jak [IPortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportionformat/), gdy potrzebujesz kontrolować, gdzie wartość jest zdefiniowana.
- Odczyt obiektu danych efektywnych, takiego jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportionformateffectivedata/), gdy potrzebujesz ostatecznego, renderowanego wyniku. Dane efektywne są tylko do odczytu.

## **Porównanie wartości lokalnych, dziedziczonych i efektywnych**

Poniższy kompletny przykład tworzy kształt i stosuje wysokości czcionki na poziomach prezentacji, akapitu i fragmentu. Każdy krok wypisuje wartości zdefiniowane na tych poziomach oraz wynikającą wartość efektywną dla tego samego fragmentu tekstu. Pokazuje także, dlaczego dane efektywne muszą być odczytane ponownie po zmianach formatowania.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Zdefiniuj dziedziczone wartości na dwóch różnych poziomach.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Lokalna wartość w fragmencie zastępuje obie dziedziczone wartości.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Zmiana dziedziczonej wartości nie zastępuje istniejącej lokalnej wartości.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Wyczyść lokalną wartość. Fragment ponownie dziedziczy z akapitu.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Wyczyść wartość akapitu. Domyślne ustawienie prezentacji teraz dostarcza wynik.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Odczytaj dane efektywne po poprzednich zmianach.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

Priorytet w tym przykładzie jest następujący: formatowanie lokalne fragmentu, potem formatowanie akapitu, potem domyślne ustawienia prezentacji. Inne obiekty mogą mieć różne łańcuchy dziedziczenia, ale zasada jest ta sama: bardziej szczegółowa, jawna wartość wygrywa, a [getEffective](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportionformat/#getEffective--) zwraca ostateczny wynik.

## **Uzyskanie efektywnych właściwości tekstu**

Formatowanie tekstu jest podzielone na kilka obiektów:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#getEffective--) rozwiązuje właściwości ramki tekstowej, takie jak marginesy, zakotwienie, automatyczne dopasowanie i pionowy kierunek tekstu.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextstyle/#getEffective--) rozwiązuje formatowanie akapitu dla każdego poziomu stylu tekstu.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#getEffective--) rozwiązuje właściwości akapitu, takie jak wyrównanie, wcięcie i wypunktowanie.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportionformat/#getEffective--) rozwiązuje właściwości znaków, takie jak wysokość czcionki, krój, kolor, pogrubienie i kursywa.

W kolejnej przykładowej aplikacji plik `text-formatting.pptx` musi zawierać co najmniej jeden slajd i jedną [AutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/autoshape/) z niepustą ramką tekstową. AutoShape może znajdować się w dowolnej pozycji w kolekcji kształtów; kod wyszukuje odpowiedni obiekt i waliduje go przed użyciem.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Uzyskanie efektywnych właściwości 3D**

[IThreeDFormat.getEffective()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformat/#getEffective--) zwraca jeden obiekt [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformateffectivedata/), który grupuje wszystkie rozwiązane ustawienia 3D. Jego metody [getCamera](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), oraz [getBevelBottom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) udostępniają odpowiednie dane efektywne. Czytanie tych powiązanych ustawień razem ułatwia zrozumienie ostatecznego wyglądu 3D kształtu.

W tym przykładzie plik `shape-3d.pptx` musi zawierać co najmniej jeden kształt na pierwszym slajdzie. Zastosuj ustawienia kamery 3D, oświetlenia lub fazowania tego kształtu, jeśli chcesz, aby wynik zawierał wartości inne niż domyślne.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Uzyskanie efektywnego formatowania tabeli**

Formatowanie tabeli może pochodzić ze stylu tabeli oraz z formatów zastosowanych do całej tabeli, kolumny, wiersza lub pojedynczej komórki. W przypadku konfliktów między jawnie określonymi wypełnieniami priorytet jest następujący: komórka, wiersz, kolumna, a następnie cała tabela. Efektywny format komórki to ostateczny format używany do jej rysowania.

W tym przykładzie plik `table-formatting.pptx` musi zawierać co najmniej jedną tabelę na pierwszym slajdzie. Tabela musi mieć co najmniej jeden wiersz i jedną kolumnę. Kod wyszukuje obiekt [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itable/) zamiast zakładać, że `getShapes().get_Item(0)` jest tabelą.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Jeśli potrzebujesz koloru, a nie tylko typu wypełnienia, najpierw sprawdź efektywne [getFillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifillformateffectivedata/#getFillType--), a potem odczytaj metodę odpowiednią dla tego typu — na przykład [getSolidFillColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) dla wypełnienia stałym kolorem.

## **Ponowne odczytanie danych efektywnych po zmianach**

Dane efektywne opisują hierarchię formatowania w momencie ich rozwiązania. Wywołaj ponownie `getEffective` po zmianie czegokolwiek, co może uczestniczyć w tej hierarchii, w tym:

- lokalne formatowanie obiektu;
- domyślne ustawienia akapitu lub ramki tekstu;
- styl tabeli, format tabeli, kolumny, wiersza lub komórki;
- formatowanie układu lub slajdu głównego;
- dane motywu lub domyślne ustawienia prezentacji;
- układ lub slajd główny przypisany do slajdu.

Nie przechowuj obiektu danych efektywnych jako trwałego migawki. Aspose.Slides może buforować niektóre dane efektywne wewnętrznie, a późniejsze wywołanie `getEffective` może odświeżyć te dane. Jeśli musisz porównać wartości przed i po zmianie, skopiuj potrzebne wartości skalarne — takie jak wysokość czcionki, kolor, wyrównanie lub szerokość fazowania — do własnych zmiennych przed dokonaniem zmiany.

Aby zmienić wartość, zaktualizuj odpowiedni lokalny obiekt formatu, a następnie wywołaj `getEffective`, aby zweryfikować rezultat. Same obiekty danych efektywnych są tylko do odczytu.

## **FAQ**

**Jak mogę określić, który poziom dostarczył wartość efektywną?**

Dane efektywne zawierają ostateczną wartość, nie jej źródło. Przeglądaj odpowiednie obiekty lokalne od najdokładniejszego poziomu na zewnątrz. Dla tekstu może to obejmować fragment, akapit, ramkę tekstową, układ, slajd główny, motyw i domyślne ustawienia prezentacji. Niezdefiniowane wartości, takie jak `Float.NaN` lub `null`, wskazują, że wyszukiwanie kontynuuje się na kolejnym poziomie.

**Co się dzieje, gdy żaden poziom nie definiuje właściwości?**

Aspose.Slides rozwiązuje odpowiedni domyślny parametr PowerPoint lub biblioteki. Ta rozwiązana wartość pojawia się w danych efektywnych, mimo że żaden obiekt lokalny nie definiuje jej jawnie.

**Dlaczego wartość efektywna czasami jest równa wartości lokalnej?**

Wartość lokalna wygrała w obliczeniach dziedziczenia. Jest to oczekiwane, gdy właściwość jest jawnie ustawiona na obiekcie i żadne bardziej szczegółowe zasady jej nie nadpisują.

**Kiedy powinienem używać danych lokalnych zamiast danych efektywnych?**

Używaj danych lokalnych, aby sprawdzić lub edytować konkretny poziom formatowania. Używaj danych efektywnych, gdy potrzebujesz ostatecznego wyglądu po uwzględnieniu dziedziczenia, reguł motywu i zastosowanych stylów. [Pełny przykład porównania](#compare-local-inherited-and-effective-values) demonstruje oba podejścia w tym samym przepływie pracy.