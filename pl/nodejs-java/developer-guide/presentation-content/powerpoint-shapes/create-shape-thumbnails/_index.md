---
title: Tworzenie miniatur kształtów prezentacji w JavaScript
linktitle: Miniatury Kształtów
type: docs
weight: 70
url: /pl/nodejs-java/create-shape-thumbnails/
keywords:
- miniatura kształtu
- obraz kształtu
- renderowanie kształtu
- renderowanie kształtu
- granice wizualne
- granice kształtu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Generuj wysokiej jakości miniatury kształtów z slajdów PowerPoint przy użyciu JavaScript i Aspose.Slides for Node.js – łatwo twórz i eksportuj miniatury prezentacji."
---
## **Wprowadzenie**

Aspose.Slides jest używany do tworzenia plików prezentacji, w których każda strona jest slajdem. Te slajdy można oglądać, otwierając pliki prezentacji w programie Microsoft PowerPoint. Czasami jednak deweloperzy mogą potrzebować wyświetlić obrazy kształtów osobno w przeglądarce obrazów. W takich przypadkach Aspose.Slides pomaga wygenerować miniatury obrazów kształtów slajdu. Sposób użycia tej funkcji opisano w tym artykule.
Ten artykuł wyjaśnia, jak generować miniatury slajdów na różne sposoby:

- Generowanie miniatury kształtu wewnątrz slajdu.
- Generowanie miniatury kształtu slajdu z wymiarami zdefiniowanymi przez użytkownika.
- Generowanie miniatury kształtu w granicach wyglądu kształtu.

## **Generowanie miniatur kształtów ze slajdów**
Aby wygenerować miniaturę kształtu z dowolnego slajdu przy użyciu Aspose.Slides for Node.js via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Uzyskaj odniesienie do dowolnego slajdu, używając jego ID lub indeksu.
1. [Pobierz obraz miniatury kształtu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getImage--) z odwołanego slajdu w domyślnej skali.
1. Zapisz obraz miniatury w wybranym formacie obrazu.

Poniższy przykładowy kod pokazuje, jak wygenerować miniaturę kształtu ze slajdu:

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

## **Generowanie miniatur kształtów z określonym współczynnikiem skalowania**
Aby wygenerować miniaturę kształtu slajdu przy użyciu Aspose.Slides for Node.js via Java, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Uzyskaj odniesienie do dowolnego slajdu, używając jego ID lub indeksu.
1. [Pobierz obraz miniatury kształtu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) z odwołanego slajdu z wymiarami określonymi przez użytkownika.
1. Zapisz obraz miniatury w wybranym formacie obrazu.

Poniższy przykładowy kod pokazuje, jak wygenerować miniaturę kształtu na podstawie określonego współczynnika skalowania:

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
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
Ta metoda tworzenia miniatur kształtów umożliwia deweloperom generowanie miniatury w granicach wyglądu kształtu. Uwzględnia wszystkie efekty kształtu. Wygenerowana miniatura kształtu jest ograniczona granicami slajdu. Aby wygenerować miniaturę kształtu slajdu w granicach jego wyglądu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Uzyskaj odniesienie do dowolnego slajdu, używając jego ID lub indeksu.
1. Pobierz obraz miniatury odwołanego slajdu z granicami kształtu jako wygląd.
1. Zapisz obraz miniatury w wybranym formacie obrazu.

Poniższy przykładowy kod opiera się na powyższych krokach:

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
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

## **Uzyskaj rzeczywiste granice wizualne kształtu**

Parametry ramki [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) — metody `getX()`, `getY()`, `getWidth()` i `getHeight()` — opisują prostokąt przechowywany w modelu prezentacji. Zawartość faktycznie renderowana może wykraczać poza tę ramkę lub zajmować inny prostokąt wyrównany do osi. Obrót, obrysy, groty strzałek, układ i przepełnienie tekstu, generowana geometria SmartArt oraz inne efekty renderowania mogą zmienić zajmowany obszar.

Użyj [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getVisualBounds--) aby obliczyć ten zajęty obszar bez tworzenia obrazu. Metoda zwraca obiekt [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) w współrzędnych slajdu. Zwrócony prostokąt nie jest przycięty do slajdu, więc jego współrzędne mogą być ujemne, gdy zawartość wykracza poza początek slajdu.

Poniższy przykład pobiera i porównuje ramkę oraz granice wizualne:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Następny prostokąt może być użyty do wyrównania pobliskich kształtów do jego lewej, prawej, górnej lub dolnej krawędzi; rezerwowania wystarczającej przestrzeni w generowanym układzie; lub wykrywania treści poza dozwolonym regionem. Granice wizualne są szczególnie przydatne dla SmartArt, pól tekstowych, strzałek, obrazów, obróconych kształtów i grup kształtów, gdzie przechowywana ramka może nie odzwierciedlać pełnego efektu renderowania.

Używaj [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getVisualBounds--) gdy potrzebujesz współrzędnych do układu lub walidacji i nie potrzebujesz bitmapy. Używaj [Shape.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage--) gdy musisz renderować kształt. Z [ShapeThumbnailBounds](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` określa rozmiar obrazu na podstawie granic kształtu, w tym ustawień obrysu, podczas gdy `ShapeThumbnailBounds.Appearance` określa rozmiar na podstawie wyglądu kształtu i ogranicza wynik do granic slajdu. Natomiast [Shape.getVisualBounds](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getVisualBounds--) zwraca tylko obliczony prostokąt i nie przycina go do slajdu.

## **FAQ**

**Jakie formaty obrazu można używać przy zapisywaniu miniatur kształtów?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imageformat/), i inne. Kształty można także [wyeksportować jako wektorowy SVG](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/writeassvg/) zapisując ich zawartość jako SVG.

**Jaka jest różnica między granicami Shape a Appearance podczas renderowania miniatury?**

`Shape` używa geometrii kształtu; `Appearance` uwzględnia [efekty wizualne](/slides/pl/nodejs-java/shape-effect/) (cienie, poświaty itp.).

**Co się stanie, jeśli kształt jest oznaczony jako ukryty? Czy nadal zostanie wyrenderowany jako miniatura?**

Ukryty kształt pozostaje częścią modelu i może być renderowany; flaga ukrycia wpływa na wyświetlanie pokazu slajdów, ale nie uniemożliwia generowania obrazu kształtu.

**Czy grupowe kształty, wykresy, SmartArt i inne złożone obiekty są obsługiwane?**

Tak. Każdy obiekt reprezentowany jako [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) (w tym [GroupShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/), i [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartart/)) może być zapisany jako miniatura lub jako SVG.

**Czy czcionki zainstalowane w systemie wpływają na jakość miniatur kształtów tekstowych?**

Tak. Należy [dostarczyć wymagane czcionki](/slides/pl/nodejs-java/custom-font/) (lub [skonfigurować podstawienia czcionek](/slides/pl/nodejs-java/font-substitution/)), aby uniknąć niepożądanych zamienników i przeskładania tekstu.