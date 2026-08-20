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
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Obróć kształt
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i obracać kształty prezentacji przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Aspose.Slides for Android via Java przedstawia kształty na slajdzie jako uporządkowaną [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/). Kolekcja jest jednocześnie miejscem, w którym znajdujesz i modyfikujesz kształty oraz źródłem ich kolejności układania: indeks `0` to najdalej z tyłu, a ostatni indeks to najbardziej przedni kształt.

W tym artykule przyjęto ten model. Najpierw wyjaśniamy, jak niezawodnie zidentyfikować kształt, a potem pokazujemy, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport SVG, wyrównywanie i ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać tylko operacji wymaganych w Twoim przepływie pracy.

## **Identyfikowanie i znajdowanie kształtów**

Indeksy kolekcji są wygodne przy przetwarzaniu znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator zgodnie z tym, jak prezentacja jest tworzona i utrzymywana:

- [Name](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getName--) jest przydatny w szablonach kontrolowanych przez programistów i łatwy do sprawdzenia w panelu wyboru PowerPointa. Nazwy mogą być edytowane i nie są gwarantowane jako unikalne, więc wprowadź konwencję nazewnictwa, jeśli kod od nich zależy.
- [AlternativeText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getAlternativeText--) jest przydatny, gdy opis dostępności lub tag dostarczony przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisany pod kątem dostępności i nie jest gwarantowany jako unikalny. Nie używaj cicho znaczącego tekstu dostępności jako klucza bazy danych.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) to identyfikator tylko do odczytu, unikalny w obrębie slajdu i odpowiadający identyfikatorowi kształtu używanemu przez interfejs PowerPoint. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odniesienia w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana metoda [getUniqueId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getUniqueId--) zwraca identyfikator o zasięgu prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie należy traktować jej jako trwałego zewnętrznego klucza. Jeśli długoterminowa tożsamość jest istotna, zachowaj mapowanie w danych aplikacji i sprawdzaj, czy oczekiwany kształt nadal istnieje.

Poniższy przykład wyszukuje po nazwie przy użyciu dokładnego porównania i raportuje interopowy identyfikator o zasięgu slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z nieprawidłowym obiektem.

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

## **Modyfikowanie kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach zebranych przed tą operacją.

### **Klonowanie kształtu**

[addClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) tworzy niezależną kopię i dołącza ją do docelowej kolekcji. [insertClone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) także tworzy kopię, ale umieszcza ją pod określonym indeksem kolejności Z. Przeciążenia przyjmujące współrzędne przenoszą klon bez zmiany jego rozmiaru; przeciążenia z szerokością i wysokością mogą również zmienić rozmiar.

Przykład tworzy slajd docelowy, klonuje opisany prostokąt na przednią warstwę i wstawia drugi klon na tył. Zmiany w którymkolwiek klonie nie modyfikują źródłowego kształtu.

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

[remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w trakcie iteracji indeksowanej, przechodź od końca, aby każdy pozostały indeks pozostał prawidłowy.

Ten przykład usuwa każdy kształt o wyznaczonej nazwie. Odczytuje kształt pod bieżącym indeksem, nie stałą pozycją w kolekcji, i nie rzutuje go niepotrzebnie.

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

Po usunięciu liczba kształtów i indeksy kolejnych kształtów ulegają zmianie. Odwołania do niezmienionych kształtów pozostają bardziej niezawodne niż zapisane indeksy. Weź też pod uwagę łączniki, animacje i inne cechy prezentacji, które mogą odnosić się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż tylko wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Hidden](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) na `true` pozostawia kształt w kolekcji, ale uniemożliwia jego wyświetlenie w normalnym pokazu slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne dla kodu, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą być przywrócone później.

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

Ukrywanie nie jest usunięciem ani zabezpieczeniem. Obiekt nadal może zostać odnaleziony i odsłonięty przez użytkownika lub kod i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z**

Nachodzące na siebie kształty są rysowane w kolejności kolekcji. [reorder](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) przenosi istniejący kształt do docelowego indeksu bez klonowania. Indeks `0` to tył; `size() - 1` to przód.

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

Prostokąt jest tworzony najpierw i początkowo znajduje się za elipsą. Przeniesienie go na ostatni indeks umieszcza go z przodu. Sfinalizuj kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dołączają lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną kolejkę.

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

Edycja układu może wpłynąć na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy zwykły slajd dziedziczy obiekt, czy zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksportowanie kształtu do SVG**

[writeAsSvg](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) zapisuje wyrenderowaną zawartość jednego kształtu do strumienia. Wynik zawiera sam kształt, a nie całe tło slajdu ani sąsiadujące kształty.

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

Utrzymuj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz od zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd zamiast pojedynczego kształtu. Wywołujący jest właścicielem strumienia i musi go zamknąć.

## **Wyrównywanie kształtów**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) ma przeciążenia wyrównujące wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb rozmieszczenia. Ustaw `alignToSlide` na `true`, aby używać krawędzi slajdu; ustaw na `false`, aby wyrównać wybrane kształty względem siebie.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Zwrócone referencje kształtów są przekształcane na ich bieżące indeksy tuż przed wyrównaniem.

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

Wyrównanie zmienia pozycje, nie kolejność Z. Wyrównanie względne zazwyczaj wymaga co najmniej dwóch kształtów, podczas gdy rozmieszczenie poziome lub pionowe wymaga wystarczającej liczby kształtów do określenia odstępów. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Obracanie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz obrót. Jej wartości `getFlipH` i `getFlipV` używają [NullableBool](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/nullablebool/): `True` włącza odbicie, `False` wyłącza, a `NotDefined` zachowuje stan nieokreślony/domyslny.

Prezentacja wejściowa poniżej zawiera jeden nieodbity kształt.

![The shape before flipping](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zastępuje tylko dwa ustawienia odbicia. Jest to ważne, ponieważ przypisanie nowego [Frame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) zastępuje całą ramkę.

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

Zapisany kształt jest odbity poziomo i pionowo, przy zachowaniu pozycji, rozmiaru i obrotu.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `Name` lub `AlternativeText` dla szablonów tworzonych ręcznie, albo `OfficeInteropShapeId` dla pracy z interopem w obrębie slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być odnaleziony, przestawiony, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`addClone` dołącza klon na końcu kolekcji, co oznacza przednią warstwę Z. Użyj `insertClone`, aby wybrać początkowy indeks, lub `reorder` po dodaniu wszystkich kształtów.