---
title: Stwórz przeglądarkę prezentacji w .NET
linktitle: Przeglądarka prezentacji
type: docs
weight: 50
url: /pl/net/presentation-viewer/
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
- .NET
- C#
- Aspose.Slides
description: "Stwórz własną przeglądarkę prezentacji w .NET przy użyciu Aspose.Slides. Łatwo wyświetlaj pliki PowerPoint i OpenDocument bez Microsoft PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides dla .NET służy do tworzenia plików prezentacji ze slajdami. Te slajdy można przeglądać, otwierając prezentacje w programie Microsoft PowerPoint, na przykład. Jednak programiści czasami muszą wyświetlić slajdy jako obrazy w preferowanym przeglądarce obrazów lub używać ich w niestandardowej przeglądarce prezentacji. W takich przypadkach Aspose.Slides umożliwia eksportowanie poszczególnych slajdów jako obrazy. Ten artykuł wyjaśnia, jak to zrobić.

## **Generowanie obrazu SVG ze slajdu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Pobierz referencję do slajdu po jego indeksie.
1. Otwórz strumień pliku.
1. Zapisz slajd jako obraz SVG do strumienia pliku.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Generowanie SVG z niestandardowym identyfikatorem kształtu**

Aspose.Slides może być użyty do wygenerowania [SVG](https://docs.fileformat.com/page-description-language/svg/) ze slajdu z niestandardowym identyfikatorem kształtu `ID`. Aby to osiągnąć, użyj właściwości Id z interfejsu [ISvgShape](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isvgshape). Klasa `CustomSvgShapeFormattingController` może zostać użyta do ustawienia identyfikatora kształtu.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Utworzenie obrazu miniatury slajdu**

Aspose.Slides pomaga generować obrazy miniatur slajdów. Aby wygenerować miniaturę slajdu przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Pobierz referencję do slajdu po jego indeksie.
1. Utwórz obraz miniatury referowanego slajdu w żądanej skali.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Utworzenie miniatury slajdu z wymiarami określonymi przez użytkownika**

Aby utworzyć obraz miniatury slajdu z wymiarami określonymi przez użytkownika, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Pobierz referencję do slajdu po jego indeksie.
1. Wygeneruj obraz miniatury referowanego slajdu o określonych wymiarach.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Utworzenie miniatury slajdu z notatkami prelegenta**

Aby wygenerować miniaturę slajdu z notatkami prelegenta przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [RenderingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/renderingoptions/).
1. Użyj właściwości `RenderingOptions.SlidesLayoutOptions`, aby ustawić położenie notatek prelegenta.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Pobierz referencję do slajdu po jego indeksie.
1. Wygeneruj obraz miniatury referowanego slajdu przy użyciu opcji renderowania.
1. Zapisz obraz miniatury w preferowanym formacie obrazu.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Przykład na żywo**

Wypróbuj bezpłatną aplikację [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pl/viewer/), aby zobaczyć, co możesz zaimplementować przy użyciu API Aspose.Slides:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/pl/viewer/)

## **FAQ**

**Czy mogę osadzić przeglądarkę prezentacji w aplikacji webowej ASP.NET?**

Tak. Możesz używać Aspose.Slides po stronie serwera do renderowania slajdów jako obrazy lub HTML i wyświetlania ich w przeglądarce. Funkcje nawigacji i powiększania można zaimplementować przy użyciu JavaScript, aby uzyskać interaktywne doświadczenie.

**Jaki jest najlepszy sposób wyświetlania slajdów w niestandardowej przeglądarce .NET?**

Zalecane podejście polega na renderowaniu każdego slajdu jako obrazu (np. PNG lub SVG) lub konwersji go do HTML przy użyciu Aspose.Slides, a następnie wyświetlaniu wyniku w kontrolce picture box (dla aplikacji desktopowych) lub w kontenerze HTML (dla aplikacji webowych).

**Jak obsłużyć duże prezentacje z wieloma slajdami?**

W przypadku dużych prezentacji warto rozważyć leniwe ładowanie lub renderowanie slajdów na żądanie. Oznacza to generowanie zawartości slajdu tylko w momencie, gdy użytkownik przechodzi do niego, co zmniejsza zużycie pamięci i czas ładowania.