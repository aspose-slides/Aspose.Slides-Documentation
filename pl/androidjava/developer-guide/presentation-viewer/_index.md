---
title: Utwórz przeglądarkę prezentacji na Androidzie
linktitle: Przeglądarka prezentacji
type: docs
weight: 50
url: /pl/androidjava/presentation-viewer/
keywords: 
- przeglądanie prezentacji
- przeglądarka prezentacji
- tworzenie przeglądarki prezentacji
- przeglądanie PPT
- przeglądanie PPTX
- przeglądanie ODP
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Utwórz własną przeglądarkę prezentacji w Javie przy użyciu Aspose.Slides for Android. Łatwo wyświetlaj pliki PowerPoint i OpenDocument bez Microsoft PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java służy do tworzenia plików prezentacji ze slajdami. Te slajdy można oglądać, otwierając prezentacje w programie Microsoft PowerPoint, na przykład. Jednakże czasami programiści mogą potrzebować wyświetlić slajdy jako obrazy w preferowanej przeglądarce obrazów lub stworzyć własną przeglądarkę prezentacji. W takich przypadkach Aspose.Slides umożliwia wyeksportowanie pojedynczego slajdu jako obrazu. Ten artykuł opisuje, jak to zrobić.

## **Generowanie obrazu SVG ze slajdu**

Aby wygenerować obraz SVG ze slajdu prezentacji przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu według jego indeksu.
3. Otwórz strumień pliku.
4. Zapisz slajd jako obraz SVG do strumienia pliku.

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

Aspose.Slides może być używany do generowania [SVG](https://docs.fileformat.com/page-description-language/svg/) ze slajdu z niestandardowym identyfikatorem kształtu. Aby to zrobić, użyj metody `setId` z [ISvgShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` może być używany do ustawiania identyfikatora kształtu.

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Utworzenie miniatury slajdu**

Aspose.Slides pomaga generować obrazy miniatur slajdów. Aby wygenerować miniaturę slajdu przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu według jego indeksu.
3. Uzyskaj obraz miniatury referowanego slajdu w określonej skali.
4. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

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

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) .
2. Uzyskaj odniesienie do slajdu według jego indeksu.
3. Uzyskaj obraz miniatury referowanego slajdu o określonych wymiarach.
4. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Utworzenie miniatury slajdu z notatkami prelegenta**

Aby wygenerować miniaturę slajdu z notatkami prelegenta przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [RenderingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/renderingoptions/) .
2. Użyj metody `RenderingOptions.setSlidesLayoutOptions`, aby ustawić pozycję notatek prelegenta.
3. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) .
4. Uzyskaj odniesienie do slajdu według jego indeksu.
5. Uzyskaj obraz miniatury referowanego slajdu z wykorzystaniem opcji renderowania.
6. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

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

Tak. Możesz używać Aspose.Slides po stronie serwera do renderowania slajdów jako obrazy lub HTML i wyświetlania ich w przeglądarce. Funkcje nawigacji i przybliżania można zaimplementować przy użyciu JavaScript, aby uzyskać interaktywne doświadczenie.

**Jaki jest najlepszy sposób wyświetlania slajdów w własnej przeglądarce?**

Zalecane podejście polega na renderowaniu każdego slajdu jako obrazu (np. PNG lub SVG) lub konwertowaniu go do HTML przy użyciu Aspose.Slides, a następnie wyświetlaniu wyniku w kontrolce obrazu (dla aplikacji desktopowych) lub w kontenerze HTML (dla aplikacji internetowych).

**Jak obsługiwać duże prezentacje z wieloma slajdami?**

W przypadku dużych zestawów slajdów rozważ leniwe ładowanie lub renderowanie na żądanie. Oznacza to generowanie treści slajdu tylko wtedy, gdy użytkownik przechodzi do niego, co zmniejsza zużycie pamięci i czas ładowania.