---
title: Zarządzanie kształtami prezentacji w Androidzie
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/androidjava/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdowanie kształtu
- Klonowanie kształtu
- Usuwanie kształtu
- Ukrywanie kształtu
- Zmiana kolejności kształtu
- Pobranie ID kształtu interop
- Alternatywny tekst kształtu
- Punkt dopasowania kształtu
- Wstępne dopasowanie kształtu
- Geometria kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównywanie kształtu
- Odwracanie kształtu
- PowerPoint
- Prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, dostosowywać, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odwracać kształty prezentacji przy użyciu Aspose.Slides dla Androida w języku Java."
---
## **Przegląd**

Aspose.Slides for Android via Java reprezentuje kształty na slajdzie jako uporządkowaną [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/). Kolekcja jest jednocześnie miejscem, w którym można znajdować i modyfikować kształty oraz źródłem ich kolejności warstw: indeks `0` to najdalej znajdujący się kształt, a ostatni indeks to najbardziej przedni kształt.

Ten artykuł podąża za tym modelem. Najpierw wyjaśnia, jak wiarygodnie zidentyfikować kształt i zmodyfikować wstępnie ustawione punkty dopasowania, a następnie pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport SVG, wyrównywanie i ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać tylko operacji potrzebnych w Twoim przepływie pracy.

## **Identyfikowanie i znajdowanie kształtów**

Indeksy kolekcji są wygodne przy przetwarzaniu znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator zgodnie z tym, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getName--) jest przydatny w szablonach kontrolowanych przez dewelopera i łatwy do sprawdzenia w panelu wyboru PowerPointa. Nazwy można edytować i nie są gwarantowane jako unikalne, więc wprowadź konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getAlternativeText--) jest przydatny, gdy opis dostępności lub tag dostarczony przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisywany pod kątem dostępności i nie jest gwarantowany jako unikalny. Nie wykorzystywuj po cichu znaczącego tekstu dostępności jako klucza w bazie danych.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) jest identyfikatorem tylko do odczytu, unikalnym w obrębie slajdu i odpowiadającemu identyfikatorowi kształtu używanemu przez interfejs PowerPoint. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odniesienia w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana metoda [getUniqueId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getUniqueId--) zwraca identyfikator o zakresie prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie należy traktować jej jako trwałego klucza zewnętrznego. Jeśli długoterminowa tożsamość jest istotna, przechowuj mapowanie w danych aplikacji i weryfikuj, czy oczekiwany kształt nadal istnieje.

Praktyczny przykład odczytu i aktualizacji zarówno tytułu, jak i opisu tekstu alternatywnego znajduje się w [Manage Alternative Text Titles and Descriptions](/slides/pl/androidjava/presentation-accessibility/). Używaj tekstu alternatywnego, aby wyjaśnić znaczenie wizualizacji czytelnikom i trzymaj go oddzielnie od nazw kształtów używanych w kodzie.

Poniższy przykład wyszukuje po nazwie przy użyciu dokładnego porównania i raportuje interopowy identyfikator w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Gdy operacja jest specyficzna dla typu kształtu, sprawdź interfejs przed użyciem członków typowych. Ten przykład aktualizuje tekst i tekst alternatywny tylko wtedy, gdy nazwany obiekt jest [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identyfikowanie i modyfikowanie wstępnych dopasowań kształtu**

Kształty o wstępnie zdefiniowanej geometrii mogą udostępniać punkty dopasowania kontrolujące cechy takie jak rozmiar narożników, proporcje strzałek czy kąty łuków. Uzyskaj do nich dostęp przez tylko‑do‑odczytu kolekcję [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . Sama kolekcja jest dostarczana przez kształt, ale każdy [IAdjustValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/) zawiera wartość, którą można zmienić.

Nie polegaj wyłącznie na stałym indeksie kolekcji. Iteruj po dopasowaniach i sprawdzaj tylko‑do‑odczytu metodę [getType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/#getType--) , której wartość [ShapeAdjustmentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapeadjustmenttype/) opisuje, co dopasowanie kontroluje. Metoda tylko‑do‑odczytu [getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/#getName--) dostarcza dodatkowych informacji identyfikacyjnych i jest szczególnie użyteczna, gdy wstępny zestaw zawiera więcej niż jedno dopasowanie o tym samym semantycznym typie.

Użyj metody wartości odpowiadającej znaczeniu dopasowania:

| Typ dopasowania | Cel | Wartość do zmiany |
|---|---|---|
| `CornerSize` | Rozmiar zaokrąglonych narożników | [setRawValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Grubość ogona strzałki | `setRawValue` |
| `ArrowheadLength` | Długość grotu strzałki | `setRawValue` |
| `ArrowheadWidth` | Szerokość grotu strzałki | `setRawValue` |
| `StartAngle` | Kąt początkowy wycinka lub łuku | [setAngleValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Kąt końcowy wycinka lub łuku | `setAngleValue` |

`getType` i `getName` zwracają informacje tylko‑do‑odczytu. `getRawValue` i `setRawValue` pracują z liczbą całkowitą w natywnych jednostkach geometrii wstępnego kształtu, natomiast `getAngleValue` i `setAngleValue` pracują z kątem w stopniach. Liczba, kolejność, znaczenie i prawidłowy zakres dopasowań zależą od wstępnego [ShapeType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igeometryshape/#getShapeType--). Wartość ważna dla jednego wstępnego kształtu może być nieprawidłowa lub mieć inny efekt dla innego.

Gdy `getType` zwraca `ShapeAdjustmentType.Custom`, API nie rozpoznaje standardowego znaczenia semantycznego. Sprawdź `getName`, typ wstępny oraz istniejącą wartość i pozostaw dopasowanie niezmienione, chyba że znane są oczekiwane znaczenie i zakres. Nawet dla rozpoznanych typów, sprawdź, czy ten sam typ występuje więcej niż raz przed wybraniem wartości. Artykuł [Connector](/slides/pl/androidjava/connector/) pokazuje tę sytuację w przypadku dopasowań zgięcia łącznika.

Poniższy kompletny przykład tworzy domyślne i zmodyfikowane wersje trzech wstępnych kształtów. Iteruje po każdym dopasowaniu, raportuje jego nazwę i typ, zmienia wartości związane z rozmiarem poprzez `setRawValue`, zmienia kąty poprzez `setAngleValue` i zapisuje wynik. Lewa kolumna zachowuje domyślną geometrię; prawa kolumna pokazuje dostosowany zaokrąglony prostokąt, czterokierunkową strzałkę i wycinek koła.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaje nagłówki dla kolumn kształtów domyślnych i dostosowanych.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sprawdzanie typu semantycznego przed zmianą wartości sprawia, że kod jest jednoznaczny w swoim zamierzeniu i unika założeń, że konkretny indeks kolekcji ma to samo znaczenie w różnych wstępnych kształtach.

## **Modyfikowanie kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach zebranych przed tą operacją.

### **Klonowanie kształtu**

[addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) tworzy niezależną kopię i dołącza ją do docelowej kolekcji. [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) także tworzy kopię, ale umieszcza ją w określonym indeksie kolejności Z. Przeciążenia przyjmujące współrzędne przenoszą klon bez zmiany jego rozmiaru; przeciążenia z szerokością i wysokością mogą go również przeskalować.

Przykład tworzy slajd docelowy, klonuje oznaczony prostokąt na przedniej warstwie i wstawia drugi klon z tyłu. Zmiany w którymkolwiek klonie nie modyfikują kształtu źródłowego.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę i tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty obsługuje prezentacja, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) usuwa określony obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w trakcie iteracji po indeksach, przechodź od końca, aby każdy pozostały indeks pozostał ważny.

Ten przykład usuwa każdy kształt o określonej nazwie. Odczytuje kształt pod bieżącym indeksem, nie stały element kolekcji, i nie rzutuje niepotrzebnie typu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Po usunięciu zmienia się liczba kształtów oraz indeksy kolejnych kształtów. Odwołania do nieusuniętych kształtów pozostają bardziej niezawodne niż zapisane indeksy. Weź także pod uwagę łączniki, animacje i inne elementy prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż tylko wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Hidden](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) na `true` pozostawia kształt w kolekcji, ale zapobiega jego wyświetlaniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne dla kodu, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą być przywrócone później.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ukrywanie nie jest usunięciem ani zabezpieczeniem. Obiekt nadal może być odnaleziony i odsłonięty przez użytkownika lub kod i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z‑Order**

Kształty nakładają się w kolejności kolekcji. [reorder](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) przenosi istniejący kształt do docelowego indeksu bez jego klonowania. Indeks `0` to tył; `size() - 1` to przód.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Prostokąt jest tworzony najpierw i początkowo znajduje się za elipsą. Przeniesienie go do ostatniego indeksu umieszcza go na wierzchu. Finalizuj kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dodają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną kolejkę warstw.

## **Inspekcja kształtów na slajdach układu**

Zwykłe slajdy, slajdy układu i slajdy wzorcowe mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie pozycjonowany kształt na zwykłym slajdzie. Sprawdzaj kształty układu, gdy musisz zrozumieć lub zmienić formatowanie dostarczane przez układ.

Poniższy przykład odczytuje [FillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getFillFormat--) i [LineFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getLineFormat--) każdego kształtu układu, nie zakładając, że każdy kształt jest `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Edycja układu może wpływać na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy zwykły slajd dziedziczy obiekt czy zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksportowanie kształtu do SVG**

[writeAsSvg](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) zapisuje renderowaną zawartość jednego kształtu do strumienia. Wynik zawiera sam kształt, a nie całe tło slajdu ani sąsiednie kształty.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Utrzymuj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz od zasobów takich jak czcionki i obrazy. Jeśli potrzebny jest cały układ, wyeksportuj slajd, a nie pojedynczy kształt. Wywołujący jest właścicielem strumienia i musi go zamknąć.

## **Wyrównywanie kształtów**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ma przeciążenia wyrównujące wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb rozmieszczenia. Ustaw `alignToSlide` na `true`, aby używać krawędzi slajdu; ustaw na `false`, aby wyrównać zaznaczone kształty względem siebie.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrócone referencje do kształtów są konwertowane na ich bieżące indeksy tuż przed wyrównaniem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wyrównywanie zmienia pozycje, nie kolejność Z. Wyrównanie względne zwykle wymaga przynajmniej dwóch kształtów, podczas gdy rozmieszczenie poziome lub pionowe potrzebuje wystarczającej liczby kształtów, aby określić odstępy. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Obracanie (flip) kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz rotację. Jej wartości `getFlipH` i `getFlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/nullablebool/): `True` włącza odbicie, `False` wyłącza, a `NotDefined` zachowuje stan nieokreślony/domyslny.

Prezentacja wejściowa poniżej zawiera jeden nieodwrócony kształt.

![The shape before flipping](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zastępuje tylko dwa ustawienia odbicia. To ważne, ponieważ przypisanie nowego [Frame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) zastępuje całą ramkę.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zapisany kształt jest odbity poziomo i pionowo, zachowując jednocześnie pozycję, rozmiar i rotację.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Zalecane są zweryfikowane konwencje `Name` lub `AlternativeText` dla szablonów tworzonych, lub `OfficeInteropShapeId` dla prac interopowych w obrębie slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być odnaleziony, przemieszczony, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`addClone` dołącza klon na końcu kolekcji, co odpowiada przedniej warstwie Z‑order. Użyj `insertClone`, aby wybrać początkowy indeks, lub `reorder` po dodaniu wszystkich kształtów.

**Czy mogę używać stałego indeksu do identyfikacji wstępnego dopasowania kształtu?**

Tylko po zweryfikowaniu dokładnego wstępnego kształtu i układu kolekcji. Lepiej iterować przez `IGeometryShape.getAdjustments` i sprawdzać `IAdjustValue.getType`; użyj `IAdjustValue.getName` jako dodatkowej informacji, gdy ten sam typ semantyczny występuje więcej niż raz.