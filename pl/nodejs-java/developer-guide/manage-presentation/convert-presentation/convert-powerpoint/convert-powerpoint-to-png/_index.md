---
title: Konwertuj slajdy PowerPoint na PNG w JavaScript
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /pl/nodejs-java/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na PNG
- prezentacja na PNG
- slajd na PNG
- PPT na PNG
- PPTX na PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "Szybko konwertuj prezentacje PowerPoint na obrazy PNG wysokiej jakości w JavaScript przy użyciu Aspose.Slides dla Node.js, zapewniając precyzyjne, automatyczne wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na obrazy PNG przy użyciu Aspose.Slides. Pokazuje, jak ładować pliki prezentacji w formatach takich jak PPT, PPTX i ODP, renderować slajdy jako obrazy oraz zapisywać wyniki w formacie PNG.

Artykuł również demonstruje, jak dostosować wygenerowane obrazy PNG, ustawiając wartości skalowania lub określając żądaną szerokość i wysokość.

## **Konwertuj PowerPoint na PNG**

Wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Uzyskaj obiekt slajdu z kolekcji zwróconej przez metodę [Presentation.getSlides()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) klasy [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide).
3. Użyj metody [Slide.getImage()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Slide), aby uzyskać miniaturę każdego slajdu.
4. Użyj metody [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/#save), aby zapisać miniaturę slajdu w formacie PNG.

Ten kod JavaScript pokazuje, jak skonwertować prezentację PowerPoint na PNG:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage();
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konwertuj PowerPoint na PNG z niestandardowymi wymiarami**

Jeśli chcesz uzyskać pliki PNG o określonej skali, możesz ustawić wartości `desiredX` i `desiredY`, które określają wymiary powstałej miniatury.

Ten kod w JavaScript demonstruje opisane działanie:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var scaleX = 2.0;
    var scaleY = 2.0;
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(scaleX, scaleY);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konwertuj PowerPoint na PNG z niestandardowym rozmiarem**

Jeśli chcesz uzyskać pliki PNG o określonym rozmiarze, możesz przekazać preferowane argumenty `width` i `height` dla `ImageSize`.

Ten kod pokazuje, jak skonwertować prezentację PowerPoint na PNG, określając rozmiar obrazów:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var size = java.newInstanceSync("java.awt.Dimension", 960, 720);
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var slideImage = slide.getImage(size);
        try {
            slideImage.save(("image_java_" + index) + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jak mogę wyeksportować tylko określony kształt (np. wykres lub obraz) zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniaturek dla pojedynczych kształtów](/slides/pl/nodejs-java/create-shape-thumbnails/); możesz renderować kształt do obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**

Tak, ale [nie udostępniaj](/slides/pl/nodejs-java/multithreading/) jednej instancji prezentacji pomiędzy wątkami. Użyj osobnej instancji dla każdego wątku lub procesu.

**Jakie są ograniczenia wersji próbnej przy eksporcie do PNG?**

Tryb ewaluacji dodaje znak wodny do obrazów wyjściowych i wymusza [inne ograniczenia](/slides/pl/nodejs-java/licensing/), dopóki nie zostanie zastosowana licencja.