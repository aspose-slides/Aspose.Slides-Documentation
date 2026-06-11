---
title: Utwórz przeglądarkę prezentacji w JavaScript
linktitle: Przeglądarka prezentacji
type: docs
weight: 50
url: /pl/nodejs-java/presentation-viewer/
keywords:
- wyświetl prezentację
- przeglądarka prezentacji
- utwórz przeglądarkę prezentacji
- wyświetl PPT
- wyświetl PPTX
- wyświetl ODP
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Utwórz własną przeglądarkę prezentacji w JavaScript przy użyciu Aspose.Slides dla Node.js. Łatwo wyświetlaj pliki PowerPoint i OpenDocument bez Microsoft PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides for Node.js via Java służy do tworzenia plików prezentacji ze slajdami. Te slajdy mogą być wyświetlane poprzez otwieranie prezentacji w programie Microsoft PowerPoint, na przykład. Jednak czasami programiści mogą potrzebować wyświetlić slajdy jako obrazy w preferowanym przeglądarce obrazów lub stworzyć własną przeglądarkę prezentacji. W takich przypadkach Aspose.Slides umożliwia eksport pojedynczego slajdu jako obrazu. Ten artykuł opisuje, jak to zrobić.

## **Generowanie obrazu SVG ze slajdu**

Aby wygenerować obraz SVG ze slajdu prezentacji przy użyciu Aspose.Slides, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu przy użyciu jego indeksu.
1. Otwórz strumień pliku.
1. Zapisz slajd jako obraz SVG do strumienia pliku.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Generowanie SVG z niestandardowym identyfikatorem kształtu**

Aspose.Slides może być użyty do wygenerowania [SVG](https://docs.fileformat.com/page-description-language/svg/) ze slajdu z niestandardowym identyfikatorem kształtu. Aby to zrobić, użyj metody `setId` z [SvgShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` może zostać użyty do ustawienia identyfikatora kształtu.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **Utworzenie miniatury slajdu**

Aspose.Slides pomaga generować obrazy miniatur slajdów. Aby wygenerować miniaturę slajdu przy użyciu Aspose.Slides, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu przy użyciu jego indeksu.
1. Uzyskaj obraz miniatury referencjonowanego slajdu w określonej skali.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Utworzenie miniatury slajdu o wymiarach definiowanych przez użytkownika**

Aby utworzyć obraz miniatury slajdu o wymiarach określonych przez użytkownika, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu przy użyciu jego indeksu.
1. Uzyskaj obraz miniatury referencjonowanego slajdu o określonych wymiarach.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Utworzenie miniatury slajdu z notatkami prelegenta**

Aby wygenerować miniaturę slajdu z notatkami prelegenta przy użyciu Aspose.Slides, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [RenderingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/).
1. Użyj metody `RenderingOptions.setSlidesLayoutOptions`, aby ustawić pozycję notatek prelegenta.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu przy użyciu jego indeksu.
1. Uzyskaj obraz miniatury referencjonowanego slajdu z opcjami renderowania.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Przykład na żywo**

Możesz wypróbować darmową aplikację [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pl/viewer/), aby zobaczyć, co możesz zaimplementować przy użyciu API Aspose.Slides:

![Przeglądarka PowerPoint online](online-PowerPoint-viewer.png)

## **FAQ**

**Czy mogę osadzić przeglądarkę prezentacji w aplikacji internetowej Node.js?**

Tak. Możesz używać Aspose.Slides po stronie serwera do renderowania slajdów jako obrazy lub HTML i wyświetlania ich w przeglądarce. Funkcje nawigacji i przybliżania można zaimplementować w JavaScript, aby uzyskać interaktywne doświadczenie.

**Jaki jest najlepszy sposób wyświetlania slajdów w niestandardowym podglądzie?**

Zalecane podejście polega na renderowaniu każdego slajdu jako obrazu (np. PNG lub SVG) lub konwertowaniu go na HTML przy użyciu Aspose.Slides, a następnie wyświetlaniu wyniku w kontrolce obrazka (dla aplikacji desktop) lub w kontenerze HTML (dla sieci).

**Jak obsłużyć duże prezentacje z wieloma slajdami?**

W przypadku dużych zestawów slajdów rozważ ładowanie leniwe (lazy-loading) lub renderowanie na żądanie. Oznacza to generowanie zawartości slajdu tylko wtedy, gdy użytkownik do niego przejdzie, co zmniejsza zużycie pamięci i czas ładowania.