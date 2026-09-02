---
title: Tworzenie miniatur kształtów prezentacji w Javie
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/java/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- granice wizualne
- granice kształtu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu Aspose.Slides for Java – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides for Java można używać do tworzenia plików prezentacji, w których każda strona odpowiada slajdowi. Slajdy można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Jednak deweloperzy czasami potrzebują wyświetlić obrazy kształtów osobno w przeglądarce obrazów. W takich sytuacjach Aspose.Slides for Java pomaga im generować miniatury obrazów kształtów slajdu.

Ten artykuł wyjaśnia, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu slajdu o wymiarach zdefiniowanych przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**
Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odwołanie do dowolnego slajdu używając jego identyfikatora lub indeksu.
1. [Pobierz miniaturę obrazu kształtu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getImage--) odwołanego slajdu w domyślnej skali.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

Poniższy przykład kodu pokazuje, jak wygenerować miniaturę kształtu ze slajdu:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Utwórz obraz w pełnej skali
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Zapisz obraz na dysku w formacie PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generowanie miniatury z czynnikiem skalowania określonym przez użytkownika**
Aby wygenerować miniaturę kształtu slajdu przy użyciu Aspose.Slides for Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odwołanie do dowolnego slajdu używając jego identyfikatora lub indeksu.
1. [Pobierz miniaturę obrazu kształtu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getImage-int-float-float-) odwołanego slajdu z wymiarami określonymi przez użytkownika.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

Poniższy przykład kodu pokazuje, jak wygenerować miniaturę kształtu na podstawie zdefiniowanego czynnika skalowania:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Utwórz obraz w pełnej skali
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Zapisz obraz na dysku w formacie PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Utworzenie miniatury wyglądu kształtu opartej na granicach**
Ta metoda tworzenia miniatur kształtów pozwala programistom wygenerować miniaturę w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona przez granice slajdu. Aby wygenerować miniaturę kształtu slajdu w granicach jego wyglądu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odwołanie do dowolnego slajdu używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury odwołanego slajdu, używając granic kształtu jako wyglądu.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

Poniższy przykład kodu opiera się na powyższych krokach:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Utwórz obraz w pełnej skali
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Zapisz obraz na dysku w formacie PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Uzyskanie rzeczywistych granic wizualnych kształtu**

Właściwości ramki interfejsu [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/) — metody `getX()`, `getY()`, `getWidth()` i `getHeight()` — opisują prostokąt przechowywany w modelu prezentacji. Rzeczywista renderowana zawartość może wykraczać poza tę ramkę lub zajmować inny prostokąt wyrównany do osi. Obrót, kontury, grotki strzałek, układ i przepełnienie tekstu, generowana geometria SmartArt oraz inne efekty renderowania mogą zmienić zajmowany obszar.

Użyj [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getVisualBounds--) aby obliczyć ten zajęty obszar bez tworzenia obrazu. Metoda zwraca obiekt [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) w układzie współrzędnych slajdu. Zwrócony prostokąt nie jest przycinany do slajdu, więc jego współrzędne mogą być ujemne, gdy zawartość wykracza poza początek slajdu.

[Shape.getVisualBounds](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getVisualBounds--) nie jest obecnie zadeklarowane w interfejsie [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/). Dlatego zachowaj kształt pobrany z kolekcji kształtów slajdu jako wartość interfejsu i dokonuj rzutowania tylko przy wywoływaniu tej metody.

Poniższy przykład pobiera i porównuje ramkę oraz granice wizualne:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Ten sam [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) może być użyty do wyrównywania pobliskich kształtów do jego lewej, prawej, górnej lub dolnej krawędzi; rezerwowania wystarczającej przestrzeni w generowanym układzie; lub wykrywania zawartości poza dozwolonym obszarem. Granice wizualne są szczególnie przydatne dla SmartArt, pól tekstowych, strzałek, obrazów, obróconych kształtów i grup kształtów, gdzie przechowywana ramka może nie odzwierciedlać pełnego wyniku renderowania.

Użyj [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getVisualBounds--) gdy potrzebujesz współrzędnych do układu lub walidacji i nie potrzebujesz bitmapy. Użyj [IShape.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/#getImage--) gdy musisz wyrenderować kształt. Z [ShapeThumbnailBounds](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` określa rozmiar obrazu na podstawie granic kształtu, łącznie z ustawieniami konturu, podczas gdy `ShapeThumbnailBounds.Appearance` określa rozmiar na podstawie wyglądu kształtu i ogranicza wynik do granic slajdu. Natomiast [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getVisualBounds--) zwraca tylko obliczony prostokąt i nie przycina go do slajdu.

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/), i inne. Kształty mogą być również [eksportowane jako wektorowy SVG](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) poprzez zapisanie ich zawartości jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` wykorzystuje geometrię kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/java/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy wciąż zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/) i [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy fonty zainstalowane w systemie wpływają na jakość miniatur tekstowych kształtów?**

Tak. Należy [dostarczyć wymagane czcionki](/slides/pl/java/custom-font/) (lub [skonfigurować podstawienia czcionek](/slides/pl/java/font-substitution/)), aby uniknąć niepożądanych zamienników i przeskładowania tekstu.