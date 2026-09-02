---
title: "Tworzenie miniatur kształtów prezentacji na Androidzie"
linktitle: "Miniatury kształtów"
type: docs
weight: 70
url: /pl/androidjava/create-shape-thumbnails/
keywords:
- "miniatura kształtu"
- "obraz kształtu"
- "renderowanie kształtu"
- "renderowanie kształtu"
- "granice wizualne"
- "granice kształtu"
- "PowerPoint"
- "prezentacja"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Twórz wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu Aspose.Slides for Android via Java – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java można używać do tworzenia plików prezentacji, w których każda strona odpowiada slajdowi. Slajdy można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Jednak programiści czasami muszą wyświetlać obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides for Android via Java pomaga im generować miniaturki obrazów kształtów slajdu.

W tym temacie pokażemy, jak generować miniaturki slajdów w różnych sytuacjach:

- Generowanie miniaturki kształtu wewnątrz slajdu.
- Generowanie miniaturki kształtu dla kształtu slajdu z wymiarami określonymi przez użytkownika.
- Generowanie miniaturki kształtu w granicach wyglądu kształtu.

## **Generowanie miniaturki kształtu ze slajdu**
Aby wygenerować miniaturkę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for Android via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj odwołanie do dowolnego slajdu, używając jego ID lub indeksu.
1. [Pobierz miniaturkę obrazu kształtu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#getImage--) referowanego slajdu w domyślnej skali.
1. Zapisz miniaturkę w wybranym przez siebie formacie obrazu.

Ten przykład kodu pokazuje, jak generować miniaturkę kształtu ze slajdu:

```java
// Utwórz obiekt klasy Presentation reprezentujący plik prezentacji
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

## **Generowanie miniaturki ze skalowaniem określonym przez użytkownika**
Aby wygenerować miniaturkę kształtu slajdu przy użyciu Aspose.Slides for Android via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj odwołanie do dowolnego slajdu, używając jego ID lub indeksu.
1. [Pobierz miniaturkę obrazu kształtu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) referowanego slajdu z wymiarami określonymi przez użytkownika.
1. Zapisz miniaturkę w wybranym przez siebie formacie obrazu.

Ten przykład kodu pokazuje, jak generować miniaturkę kształtu na podstawie zdefiniowanego czynnika skalowania:

```java
// Utwórz obiekt klasy Presentation reprezentujący plik prezentacji
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

## **Tworzenie miniaturki wyglądu kształtu opartej na granicach**
Ta metoda tworzenia miniatur kształtów pozwala programistom generować miniaturkę w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniaturka kształtu jest ograniczona granicami slajdu. Aby wygenerować miniaturkę kształtu slajdu w granicach jego wyglądu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj odwołanie do dowolnego slajdu, używając jego ID lub indeksu.
1. Pobierz obraz miniaturki referowanego slajdu, używając granic kształtu jako wyglądu.
1. Zapisz miniaturkę w wybranym przez siebie formacie obrazu.

Ten przykład kodu opiera się na powyższych krokach:

```java
// Utwórz obiekt klasy Presentation reprezentujący plik prezentacji
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
Właściwości ramki [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) — metody `getX()`, `getY()`, `getWidth()` i `getHeight()` — opisują prostokąt przechowywany w modelu prezentacji. Treść rzeczywiście renderowana może wykraczać poza tę ramkę lub zajmować inny prostokąt ustawiony wzdłuż osi. Rotacja, kontury, końcówki strzałek, układ i przepełnienie tekstu, generowana geometria SmartArt oraz inne efekty renderowania mogą zmienić zajmowany obszar.

Użyj [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getVisualBounds--) aby obliczyć ten zajęty obszar bez tworzenia obrazu. Metoda zwraca [RectF](https://developer.android.com/reference/android/graphics/RectF) w współrzędnych slajdu. Zwrócony prostokąt nie jest przycinany do slajdu, więc jego współrzędne mogą być ujemne, gdy treść wykracza poza początek slajdu.

[Shape.getVisualBounds](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getVisualBounds--) nie jest obecnie zadeklarowana w interfejsie [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/). Dlatego zachowaj kształt pobrany z kolekcji kształtów slajdu jako wartość interfejsu i rzutuj go tylko przy wywołaniu tej metody.

Poniższy przykład pobiera i porównuje granice ramki oraz granice wizualne:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Tego samego [RectF](https://developer.android.com/reference/android/graphics/RectF) można używać do wyrównywania pobliskich kształtów do jego lewej, prawej, górnej lub dolnej krawędzi; rezerwowania wystarczającej przestrzeni w generowanym układzie; lub wykrywania treści poza dozwolonym obszarem. Granice wizualne są szczególnie przydatne dla SmartArt, pól tekstowych, strzałek, obrazów, obróconych kształtów i grup kształtów, gdzie przechowywana ramka może nie odzwierciedlać pełnego wyniku renderowania.

Użyj [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getVisualBounds--) gdy potrzebujesz współrzędnych do układu lub walidacji i nie potrzebujesz bitmapy. Użyj [IShape.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getImage--) gdy musisz renderować kształt. Z [ShapeThumbnailBounds](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.Shape` określa rozmiar obrazu na podstawie granic kształtu, włącznie z ustawieniami konturu, natomiast `ShapeThumbnailBounds.Appearance` określa rozmiar na podstawie wyglądu kształtu i ogranicza wynik do granic slajdu. Natomiast [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getVisualBounds--) zwraca jedynie obliczony prostokąt i nie przycina go do slajdu.

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imageformat/), i inne. Kształty można również [wyeksportować jako wektorowy SVG](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) zapisując zawartość kształtu jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniaturki?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/androidjava/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniaturka?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chart/), i [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/smartart/)) może być zapisany jako miniaturka lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniaturk tekstowych kształtów?**

Tak. Należy [udostępnić wymagane czcionki](/slides/pl/androidjava/custom-font/) (lub [skonfigurować substytucje czcionek](/slides/pl/androidjava/font-substitution/)), aby uniknąć niepożądanych zastąpień i przeskładania tekstu.