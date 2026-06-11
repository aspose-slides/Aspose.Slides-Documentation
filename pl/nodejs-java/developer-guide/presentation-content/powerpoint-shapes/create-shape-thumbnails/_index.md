---
title: Tworzenie miniatur kształtów prezentacji w JavaScript
linktitle: Miniatury kształtów
type: docs
weight: 70
url: /pl/nodejs-java/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides służy do tworzenia plików prezentacji, w których każda strona jest slajdem. Te slajdy można przeglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Jednak czasami programiści muszą wyświetlić obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides pomaga wygenerować miniatury obrazów kształtów slajdu. Jak używać tej funkcji opisano w tym artykule.

Ten artykuł wyjaśnia, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu slajdu o wymiarach zdefiniowanych przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatur kształtów ze slajdów**

Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for Node.js via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
2. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
3. Pobierz miniaturę obrazu kształtu [Get the shape thumbnail image](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getImage--) referowanego slajdu w domyślnej skali.
4. Zapisz obraz miniatury w wybranym przez siebie formacie obrazu.

Ten przykładowy kod pokazuje, jak wygenerować miniaturę kształtu ze slajdu:

```javascript
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Utwórz obraz w pełnej skali
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Zapisz obraz na dysku w formacie PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generowanie miniatur kształtów ze współczynnikiem skalowania określonym przez użytkownika**

Aby wygenerować miniaturę kształtu slajdu przy użyciu Aspose.Slides for Node.js via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
2. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
3. Pobierz miniaturę obrazu kształtu [Get the shape thumbnail image](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) referowanego slajdu z wymiarami określonymi przez użytkownika.
4. Zapisz obraz miniatury w wybranym przez siebie formacie obrazu.

Ten przykładowy kod pokazuje, jak wygenerować miniaturę kształtu na podstawie zdefiniowanego współczynnika skalowania:

```javascript
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Utwórz obraz w pełnej skali
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Zapisz obraz na dysku w formacie PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generowanie miniatury kształtu w granicach**

Ta metoda tworzenia miniatur kształtów pozwala programistom wygenerować miniaturę w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona granicami slajdu. Aby wygenerować miniaturę kształtu slajdu w granicach jego wyglądu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
2. Uzyskaj referencję do dowolnego slajdu, używając jego identyfikatora lub indeksu.
3. Pobierz obraz miniatury referowanego slajdu z granicami kształtu jako wygląd.
4. Zapisz obraz miniatury w wybranym przez siebie formacie obrazu.

Ten przykładowy kod oparty jest na powyższych krokach:

```javascript
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Utwórz obraz w pełnej skali
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Zapisz obraz na dysku w formacie PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imageformat/), i inne. Kształty mogą być także [eksportowane jako wektorowy SVG](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/writeassvg/) poprzez zapisanie zawartości kształtu jako SVG.

**Jaka jest różnica między granicami Shape a Appearance przy renderowaniu miniatury?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/nodejs-java/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/) i [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur dla kształtów tekstowych?**

Tak. Należy [udostępnić wymagane czcionki](/slides/pl/nodejs-java/custom-font/) (lub [skonfigurować podstawienia czcionek](/slides/pl/nodejs-java/font-substitution/)), aby uniknąć niepożądanych fallbacków i przemieszczeń tekstu.