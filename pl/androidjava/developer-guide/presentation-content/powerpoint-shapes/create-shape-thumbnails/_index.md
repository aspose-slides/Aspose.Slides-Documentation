---
title: Tworzenie miniatur kształtów prezentacji na Androidzie
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/androidjava/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu Aspose.Slides for Android via Java – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java można używać do tworzenia plików prezentacji, w których każda strona odpowiada slajdowi. Slajdy można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Jednak programiści czasami potrzebują wyświetlić obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides for Android via Java pomaga generować miniatury obrazów kształtów slajdu.

W tym temacie pokażemy, jak generować miniatury slajdów w różnych sytuacjach:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu dla kształtu slajdu o wymiarach określonych przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatury kształtu ze slajdu**
Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for Android via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. [Pobierz miniaturę obrazu kształtu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#getImage--) referowanego slajdu w domyślnej skali.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

Ten przykładowy kod pokazuje, jak wygenerować miniaturę kształtu ze slajdu:

```java
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
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

## **Generowanie miniatury z własnym współczynnikiem skalowania**
Aby wygenerować miniaturę kształtu slajdu przy użyciu Aspose.Slides for Android via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. [Pobierz miniaturę obrazu kształtu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) referowanego slajdu z wymiarami określonymi przez użytkownika.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

Ten przykładowy kod pokazuje, jak wygenerować miniaturę kształtu na podstawie zdefiniowanego współczynnika skalowania:

```java
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
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

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
1. Pobierz obraz miniatury referowanego slajdu z granicami kształtu jako wygląd.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

Ten przykładowy kod opiera się na powyższych krokach:

```java
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
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

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imageformat/), i inne. Kształty mogą być także [wyeksportowane jako wektorowy SVG](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) poprzez zapisanie ich treści jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/androidjava/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/chart/) i [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur kształtów tekstowych?**

Tak. Powinieneś [udostępnić wymagane czcionki](/slides/pl/androidjava/custom-font/) (lub [skonfigurować zamienniki czcionek](/slides/pl/androidjava/font-substitution/)), aby uniknąć niepożądanych awaryjnych zamian i przemieszczeń tekstu.