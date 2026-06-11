---
title: Utwórz przeglądarkę prezentacji w Javie
linktitle: Przeglądarka prezentacji
type: docs
weight: 50
url: /pl/java/presentation-viewer/
keywords:
- wyświetlanie prezentacji
- przeglądarka prezentacji
- tworzenie przeglądarki prezentacji
- wyświetlanie PPT
- wyświetlanie PPTX
- wyświetlanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Utwórz własną przeglądarkę prezentacji w Javie przy użyciu Aspose.Slides. Łatwo wyświetlaj pliki PowerPoint i OpenDocument bez Microsoft PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides dla Javy służy do tworzenia plików prezentacji ze slajdami. Te slajdy można oglądać otwierając prezentacje w programie Microsoft PowerPoint, na przykład. Jednak czasami programiści mogą potrzebować oglądać slajdy jako obrazy w preferowanej przeglądarce obrazów lub stworzyć własną przeglądarkę prezentacji. W takich przypadkach Aspose.Slides pozwala wyeksportować pojedynczy slajd jako obraz. Ten artykuł opisuje, jak to zrobić.

## **Generowanie obrazu SVG ze slajdu**

Aby wygenerować obraz SVG ze slajdu prezentacji przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Otwórz strumień pliku.
1. Zapisz slajd jako obraz SVG do strumienia pliku.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Generowanie SVG z niestandardowym identyfikatorem kształtu**

Aspose.Slides może być użyty do wygenerowania [SVG](https://docs.fileformat.com/page-description-language/svg/) ze slajdu z niestandardowym identyfikatorem kształtu. Aby to zrobić, użyj metody `setId` z [ISvgShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` może być użyty do ustawienia identyfikatora kształtu.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Utworzenie miniatury slajdu**

Aspose.Slides pomaga generować obrazy miniatur slajdów. Aby wygenerować miniaturę slajdu przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Uzyskaj obraz miniatury referowanego slajdu w określonej skali.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Utworzenie miniatury slajdu o wymiarach określonych przez użytkownika**

Aby utworzyć obraz miniatury slajdu o wymiarach określonych przez użytkownika, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Uzyskaj obraz miniatury referowanego slajdu z określonymi wymiarami.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Utworzenie miniatury slajdu z notatkami prelegenta**

Aby wygenerować miniaturę slajdu z notatkami prelegenta przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [RenderingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/renderingoptions/) class.
1. Użyj metody `RenderingOptions.setSlidesLayoutOptions` aby ustawić pozycję notatek prelegenta.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Pobierz odwołanie do slajdu według jego indeksu.
1. Uzyskaj obraz miniatury referowanego slajdu z opcjami renderowania.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Przykład na żywo**

Możesz wypróbować darmową aplikację [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pl/viewer/), aby zobaczyć, co możesz zaimplementować przy użyciu API Aspose.Slides:

![Przeglądarka PowerPoint online](online-PowerPoint-viewer.png)

## **FAQ**

**Czy mogę osadzić przeglądarkę prezentacji w aplikacji internetowej?**

Tak. Możesz używać Aspose.Slides po stronie serwera do renderowania slajdów jako obrazy lub HTML i wyświetlać je w przeglądarce. Funkcje nawigacji i przybliżania mogą być zaimplementowane przy pomocy JavaScript, aby uzyskać interaktywną obsługę.

**Jaki jest najlepszy sposób wyświetlania slajdów w niestandardowej przeglądarce?**

Zalecanym podejściem jest renderowanie każdego slajdu jako obrazu (np. PNG lub SVG) lub konwertowanie go na HTML przy użyciu Aspose.Slides, a następnie wyświetlanie wyniku w kontrolce obrazu (dla aplikacji desktopowych) lub w kontenerze HTML (dla aplikacji webowych).

**Jak obsłużyć duże prezentacje z wieloma slajdami?**

W przypadku dużych prezentacji warto rozważyć leniwe wczytywanie lub renderowanie slajdów na żądanie. Oznacza to generowanie treści slajdu tylko wtedy, gdy użytkownik przechodzi do niego, co zmniejsza zużycie pamięci i czas ładowania.