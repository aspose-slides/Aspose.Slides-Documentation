---
title: Tworzenie miniaturek kształtów prezentacji w Javie
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/java/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu Aspose.Slides for Java – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides for Java może być używany do tworzenia plików prezentacji, w których każda strona odpowiada slajdowi. Slajdy mogą być wyświetlane po otwarciu plików prezentacji za pomocą Microsoft PowerPoint. Jednak programiści czasami potrzebują zobaczyć obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides for Java pomaga wygenerować miniatury obrazów kształtów slajdu.

Ten artykuł wyjaśnia, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu slajdu o wymiarach określonych przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**

Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. [Pobierz obraz miniatury kształtu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#getImage--) referowanego slajdu na domyślnej skali.
1. Zapisz obraz miniatury w wybranym przez siebie formacie obrazu.

Poniższy przykładowy kod pokazuje, jak wygenerować miniaturę kształtu ze slajdu:

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

## **Generowanie miniatury ze współczynnikiem skalowania określonym przez użytkownika**

Aby wygenerować miniaturę kształtu slajdu przy użyciu Aspose.Slides for Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. [Pobierz obraz miniatury kształtu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#getImage-int-float-float-) referowanego slajdu z wymiarami określonymi przez użytkownika.
1. Zapisz obraz miniatury w wybranym przez siebie formacie obrazu.

Poniższy przykładowy kod pokazuje, jak wygenerować miniaturę kształtu na podstawie określonego współczynnika skalowania:

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

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury referowanego slajdu z granicami kształtu jako wyglądem.
1. Zapisz obraz miniatury w wybranym przez siebie formacie obrazu.

Poniższy przykładowy kod opiera się na powyższych krokach:

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

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/), oraz inne. Kształty mogą być także [eksportowane jako wektorowy SVG](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) poprzez zapisanie zawartości kształtu jako SVG.

**Jaka jest różnica między granicami Shape a Appearance podczas renderowania miniatury?**

`Shape` wykorzystuje geometrię kształtu; `Appearance` bierze pod uwagę [efekty wizualne](/slides/pl/java/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/) i [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniaturek kształtów tekstowych?**

Tak. Należy [zapewnić wymagane czcionki](/slides/pl/java/custom-font/) (lub [skonfigurować zamienniki czcionek](/slides/pl/java/font-substitution/)), aby uniknąć niechcianych zastąpień i przelotów tekstu.