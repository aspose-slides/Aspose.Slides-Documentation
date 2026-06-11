---
title: Utwórz przeglądarkę prezentacji w PHP
linktitle: Przeglądarka prezentacji
type: docs
weight: 50
url: /pl/php-java/presentation-viewer/
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
- PHP
- Aspose.Slides
description: "Utwórz własną przeglądarkę prezentacji przy użyciu Aspose.Slides dla PHP via Java. Łatwo wyświetlaj pliki PowerPoint i OpenDocument bez Microsoft PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides for PHP via Java służy do tworzenia plików prezentacji ze slajdami. Slajdy te można przeglądać, otwierając prezentacje w programie Microsoft PowerPoint, na przykład. Czasami jednak programiści potrzebują wyświetlać slajdy jako obrazy w preferowanym przeglądarce obrazów lub stworzyć własny podgląd prezentacji. W takich przypadkach Aspose.Slides umożliwia wyeksportowanie pojedynczego slajdu jako obrazu. Ten artykuł opisuje, jak to zrobić.

## **Generowanie obrazu SVG ze slajdu**

Aby wygenerować obraz SVG ze slajdu prezentacji za pomocą Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Otwórz strumień pliku.
1. Zapisz slajd jako obraz SVG do strumienia pliku.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Generowanie SVG z niestandardowym identyfikatorem kształtu**

Aspose.Slides może być użyte do wygenerowania [SVG](https://docs.fileformat.com/page-description-language/svg/) ze slajdu z niestandardowym identyfikatorem kształtu. Aby to zrobić, użyj metody `setId` z [SvgShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` może być użyty do ustawienia identyfikatora kształtu.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **Utworzenie miniatury slajdu**

Aspose.Slides pomaga generować obrazy miniatur slajdów. Aby wygenerować miniaturę slajdu za pomocą Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Pobierz obraz miniatury referowanego slajdu w określonej skali.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Utworzenie miniatury slajdu o wymiarach określonych przez użytkownika**

Aby utworzyć obraz miniatury slajdu o wymiarach określonych przez użytkownika, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Pobierz obraz miniatury referowanego slajdu o określonych wymiarach.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Utworzenie miniatury slajdu z notatkami prelegenta**

Aby wygenerować miniaturę slajdu z notatkami prelegenta przy użyciu Aspose.Slides, wykonaj poniższe kroki:

1. Utwórz instancję klasy [RenderingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/).
1. Użyj metody `RenderingOptions.setSlidesLayoutOptions`, aby ustawić pozycję notatek prelegenta.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu według jego indeksu.
1. Pobierz obraz miniatury referowanego slajdu z zastosowaniem opcji renderowania.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Przykład na żywo**

Możesz wypróbować darmową aplikację [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pl/viewer/), aby zobaczyć, co możesz zaimplementować przy użyciu API Aspose.Slides:

![Podgląd PowerPoint Online](online-PowerPoint-viewer.png)

## **FAQ**

**Czy mogę osadzić podgląd prezentacji w aplikacji internetowej?**

Tak. Możesz używać Aspose.Slides po stronie serwera do renderowania slajdów jako obrazy lub HTML i wyświetlać je w przeglądarce. Funkcje nawigacji i przybliżania można zaimplementować przy użyciu JavaScript, aby uzyskać interaktywne doświadczenie.

**Jaki jest najlepszy sposób wyświetlania slajdów w niestandardowym podglądzie?**

Zalecane podejście to renderowanie każdego slajdu jako obrazu (np. PNG lub SVG) lub konwersja do HTML przy użyciu Aspose.Slides, a następnie wyświetlenie wyniku w kontrolce obrazu (dla aplikacji desktopowych) lub w kontenerze HTML (dla aplikacji webowych).

**Jak radzić sobie z dużymi prezentacjami zawierającymi wiele slajdów?**

W przypadku dużych zestawów warto zastosować leniwe ładowanie lub renderowanie slajdów na żądanie. Oznacza to generowanie zawartości slajdu tylko wtedy, gdy użytkownik do niego przejdzie, co zmniejsza zużycie pamięci i skraca czas ładowania.