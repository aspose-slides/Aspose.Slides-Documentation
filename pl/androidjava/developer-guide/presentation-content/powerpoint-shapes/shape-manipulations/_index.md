---
title: Zarządzanie kształtami prezentacji na Androidzie
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/androidjava/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtu
- Pobierz ID kształtu interop
- Alternatywny tekst kształtu
- Punkt regulacji kształtu
- Regulacja predefiniowanego kształtu
- Geometria kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Odbij kształt
- PowerPoint
- Prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, regulować, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odbijać kształty prezentacji przy użyciu Aspose.Slides dla Androida za pomocą Javy."
---
## **Przegląd**

Aspose.Slides for Android via Java reprezentuje kształty na slajdzie jako uporządkowaną [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/). Kolekcja jest jednocześnie miejscem, w którym znajdujesz i modyfikujesz kształty oraz źródłem ich kolejności układania: indeks `0` to najgłębiej położony kształt, a ostatni indeks to kształt najbliżej przodu.

Ten artykuł opiera się na tym modelu. Najpierw wyjaśnia, jak niezawodnie zidentyfikować kształt i zmodyfikować wstępnie ustawione punkty regulacji, a następnie pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje omawiają formatowanie na poziomie układu, eksport SVG, wyrównywanie i ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać tylko operacji potrzebnych w Twoim przepływie pracy.

## **Identyfikacja i znajdowanie kształtów**

Indeksy kolekcji są wygodne przy przetwarzaniu znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator w zależności od tego, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getName--) jest przydatny w szablonach kontrolowanych przez programistów i łatwy do sprawdzenia w panelu wyboru PowerPointa. Nazwy można edytować i nie są gwarantowane jako unikalne, więc wprowadź konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getAlternativeText--) jest przydatny, gdy opis dostępności lub tag podany przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisany w celu poprawy dostępności i nie jest gwarantowany jako unikalny. Nie wykorzystuj cichej, znaczącej treści dostępności jako klucza bazy danych.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) jest identyfikatorem tylko do odczytu, unikalnym w obrębie slajdu i odpowiadającym identyfikatorowi kształtu używanemu przez interfejs PowerPoint. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odwołania w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana metoda [getUniqueId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getUniqueId--) zwraca identyfikator o zakresie prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przydzielona. Nie należy jej traktować jako trwałego zewnętrznego klucza. Jeśli długoterminowa tożsamość jest istotna, zachowaj mapowanie w danych aplikacji i sprawdź, czy oczekiwany kształt nadal istnieje.

Poniższy przykład wyszukuje po nazwie przy użyciu dokładnego porównania i zgłasza identyfikator interopowy w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

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

Gdy operacja jest specyficzna dla typu kształtu, sprawdź interfejs przed użyciem członków specyficznych dla typu. Ten przykład aktualizuje tekst i tekst alternatywny tylko wtedy, gdy nazwany obiekt jest [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/).

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

## **Identyfikacja i modyfikacja wstępnych regulacji kształtu**

Kształty o geometrycznej predefinicji mogą udostępniać punkty regulacji kontrolujące takie elementy jak rozmiar narożnika, proporcje strzałki czy kąty łuku. Dostęp do nich uzyskuje się przez kolekcję tylko do odczytu [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) . Sama kolekcja jest dostarczana przez kształt, ale każdy [IAdjustValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/) zawiera wartość, którą można zmienić.

Nie polegaj wyłącznie na stałym indeksie kolekcji. Iteruj po regulacjach i sprawdzaj metodę tylko do odczytu [getType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/#getType--) , której wartość [ShapeAdjustmentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapeadjustmenttype/) opisuje, co dana regulacja kontroluje. Metoda tylko do odczytu [getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/#getName--) dostarcza dodatkowych informacji identyfikacyjnych i jest szczególnie przydatna, gdy predefinicja zawiera więcej niż jedną regulację tego samego typu semantycznego.

Użyj metody wartości odpowiadającej znaczeniu regulacji:

| Typ regulacji | Cel | Wartość do zmiany |
|---|---|---|
| `CornerSize` | Rozmiar zaokrąglonych narożników | [setRawValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Grubość ogona strzałki | `setRawValue` |
| `ArrowheadLength` | Długość grotu strzałki | `setRawValue` |
| `ArrowheadWidth` | Szerokość grotu strzałki | `setRawValue` |
| `StartAngle` | Kąt początkowy wycinka lub łuku | [setAngleValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Kąt końcowy wycinka lub łuku | `setAngleValue` |

`getType` i `getName` zwracają informacje tylko do odczytu. `getRawValue` i `setRawValue` pracują z liczbą całkowitą w natywnych jednostkach geometrycznych predefinicji, natomiast `getAngleValue` i `setAngleValue` pracują z kątem w stopniach. Liczba, kolejność, znaczenie i dopuszczalny zakres regulacji zależą od predefiniowanego [ShapeType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igeometryshape/#getShapeType--). Wartość ważna dla jednej predefinicji może być nieważna lub mieć inny efekt dla innej.

Gdy `getType` zwraca `ShapeAdjustmentType.Custom`, API nie rozpoznaje standardowego znaczenia semantycznego. Przeanalizuj `getName`, typ predefinicji oraz istniejącą wartość i pozostaw regulację niezmienioną, chyba że znane są oczekiwane znaczenie i zakres. Nawet dla rozpoznanych typów sprawdź, czy ten sam typ występuje więcej niż raz przed wybraniem wartości. Artykuł [Connector](/slides/pl/androidjava/connector/) pokazuje tę sytuację w kontekście regulacji zgięcia łącznika.

Poniższy kompletny przykład tworzy domyślne i zmodyfikowane wersje trzech predefiniowanych kształtów. Iteruje po każdej regulacji, zgłasza jej nazwę i typ, zmienia wartości związane z rozmiarem za pomocą `setRawValue`, zmienia kąty przy pomocy `setAngleValue` i zapisuje wynik. Lewa kolumna zachowuje domyślną geometrię; prawa kolumna pokazuje dostosowany prostokąt z zaokrąglonymi rogami, czterodrogą strzałkę i wycinek koła.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaje nagłówki dla kolumn domyślnego i zmodyfikowanego kształtu.
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

Sprawdzanie typu semantycznego przed zmianą wartości sprawia, że kod jest jawny co do intencji i unika zakładania, że dany indeks kolekcji ma to samo znaczenie w różnych predefinicjach kształtów.

## **Modyfikacja kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach zebranych przed tą operacją.

### **Klonowanie kształtu**

[addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) tworzy niezależną kopię i dodaje ją do docelowej kolekcji. [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) także tworzy kopię, ale umieszcza ją pod zadanym indeksem z‑order. Przeciążenia przyjmujące współrzędne przenoszą klon bez zmiany jego rozmiaru; przeciążenia z szerokością i wysokością mogą również zmienić rozmiar.

Przykład tworzy slajd docelowy, klonuje opisany prostokąt na wierzch i wstawia drugi klon z tyłu. Zmiany w którymkolwiek klonie nie modyfikują kształtu źródłowego.

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

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę i tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są obsługiwane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w trakcie iteracji po indeksach, przechodź od końca, aby każdy pozostały indeks pozostał ważny.

Ten przykład usuwa każdy kształt o określonej nazwie. Odczytuje kształt pod bieżącym indeksem, a nie stały element kolekcji, i nie wykonuje niepotrzebnego rzutowania.

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

Po usunięciu liczba kształtów i indeksy późniejszych kształtów się zmieniają. Odniesienia do niezmienionych kształtów pozostają bardziej niezawodne niż zapisane indeksy. Pamiętaj także o łącznikach, animacjach i innych elementach prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż tylko wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Hidden](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) na `true` pozostawia kształt w kolekcji, ale zapobiega jego wyświetlaniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne dla kodu, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą zostać przywrócone później.

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

Ukrycie nie jest usunięciem ani zabezpieczeniem. Obiekt nadal może być wykryty i odkryty przez użytkownika lub kod, i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z‑order**

Kształty zachodzące na siebie są rysowane w kolejności kolekcji. [reorder](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) przenosi istniejący kształt do docelowego indeksu bez jego klonowania. Indeks `0` to tył; `size() - 1` to przód.

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

Prostokąt jest tworzony jako pierwszy i początkowo znajduje się za elipsą. Przeniesienie go do ostatniego indeksu umieszcza go na wierzchu. Ustal kolejność Z‑order po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dodają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną kolejność.

## **Inspekcja kształtów na slajdach układu**

Zwykłe slajdy, slajdy układu i slajdy główne mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie pozycjonowany kształt na zwykłym slajdzie. Sprawdzaj kształty układu, gdy musisz zrozumieć lub zmienić formatowanie dostarczane przez układ.

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

Edycja układu może wpływać na wiele slajdów, które go używają. Przed zmianą kształtu układu ustal, czy zwykły slajd dziedziczy obiekt czy zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksport kształtu do SVG**

[writeAsSvg](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) zapisuje wyrenderowaną zawartość jednego kształtu do strumienia. Wynik zawiera tylko kształt, a nie całe tło slajdu ani sąsiadujące kształty.

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

Utrzymuj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj cały slajd, a nie pojedynczy kształt. Wywołujący jest właścicielem strumienia i musi go zamknąć.

## **Wyrównywanie kształtów**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ma przeciążenia wyrównujące wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapesalignmenttype/) określa krawędź, linię środka lub tryb dystrybucji. Ustaw `alignToSlide` na `true`, aby używać krawędzi slajdu; ustaw na `false`, aby wyrównywać wybrane kształty względem siebie.

Przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrócone referencje do kształtów są przeliczane na ich bieżące indeksy bezpośrednio przed wyrównaniem.

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

Wyrównanie zmienia pozycje, nie kolejność Z‑order. Wyrównanie względne zazwyczaj wymaga co najmniej dwóch kształtów, podczas gdy dystrybucja pozioma lub pionowa wymaga wystarczającej liczby kształtów do określenia odstępów. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odbicie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia w poziomie i w pionie oraz rotację. Jej wartości `getFlipH` i `getFlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/nullablebool/): `True` włącza odbicie, `False` wyłącza, a `NotDefined` zachowuje nieokreślony/domyślny stan.

Poniższa prezentacja wejściowa zawiera jeden nieodbijany kształt.

![The shape before flipping](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zmienia tylko dwa ustawienia odbicia. Jest to ważne, ponieważ przypisanie nowej [Frame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) zastępuje całą ramkę.

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

Zapisany kształt jest odbity poziomo i pionowo, zachowując pozycję, rozmiar i rotację.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `Name` lub `AlternativeText` dla szablonów tworzonych, lub `OfficeInteropShapeId` dla prac w zakresie interop slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z‑order?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być znajdowany, przemieszczany, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`addClone` dodaje klon na koniec kolekcji, co jest przodem kolejności Z‑order. Użyj `insertClone`, aby wybrać początkowy indeks, lub `reorder` po dodaniu wszystkich kształtów.

**Czy mogę używać stałego indeksu do identyfikacji regulacji predefiniowanego kształtu?**

Tylko po zweryfikowaniu dokładnej predefinicji i układu kolekcji. Preferuj iterację przez `IGeometryShape.getAdjustments` i sprawdzanie `IAdjustValue.getType`; używaj `IAdjustValue.getName` jako dodatkowej informacji, gdy ten sam typ semantyczny pojawia się wielokrotnie.