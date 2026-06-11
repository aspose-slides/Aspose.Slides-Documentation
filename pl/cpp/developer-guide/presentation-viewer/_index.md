---
title: Utwórz przeglądarkę prezentacji w C++
linktitle: Przeglądarka prezentacji
type: docs
weight: 50
url: /pl/cpp/presentation-viewer/
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
- C++
- Aspose.Slides
description: "Utwórz niestandardową przeglądarkę prezentacji w C++ przy użyciu Aspose.Slides. Łatwo wyświetlaj pliki PowerPoint i OpenDocument bez Microsoft PowerPoint."
---
## **Wprowadzenie**

Aspose.Slides dla C++ służy do tworzenia plików prezentacji z slajdami. Slajdy te można wyświetlać, otwierając prezentacje w programie Microsoft PowerPoint, na przykład. Czasami programiści mogą potrzebować wyświetlić slajdy jako obrazy w preferowanym przeglądarce obrazów lub stworzyć własny podgląd prezentacji. W takich przypadkach Aspose.Slides umożliwia wyeksportowanie pojedynczego slajdu jako obrazu. Ten artykuł opisuje, jak to zrobić.

## **Generowanie obrazu SVG ze slajdu**

Aby wygenerować obraz SVG ze slajdu prezentacji przy użyciu Aspose.Slides, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Pobierz referencję do slajdu według jego indeksu.
1. Otwórz strumień pliku.
1. Zapisz slajd jako obraz SVG do strumienia pliku.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **Generowanie SVG z niestandardowym identyfikatorem kształtu**

Aspose.Slides może być używany do generowania [SVG](https://docs.fileformat.com/page-description-language/svg/) ze slajdu z niestandardowym identyfikatorem kształtu. Aby to zrobić, użyj metody `set_Id` z [ISvgShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/isvgshape/) . `CustomSvgShapeFormattingController` można wykorzystać do ustawienia identyfikatora kształtu.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Tworzenie miniatury slajdu**

Aspose.Slides pomaga generować miniatury slajdów. Aby wygenerować miniaturę slajdu przy użyciu Aspose.Slides, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Pobierz referencję do slajdu według jego indeksu.
1. Pobierz obraz miniatury referowanego slajdu w określonej skali.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Tworzenie miniatury slajdu o wymiarach określonych przez użytkownika**

Aby utworzyć obraz miniatury slajdu o wymiarach określonych przez użytkownika, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Pobierz referencję do slajdu według jego indeksu.
1. Pobierz obraz miniatury referowanego slajdu z określonymi wymiarami.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Tworzenie miniatury slajdu z notatkami prelegenta**

Aby wygenerować miniaturę slajdu z notatkami prelegenta przy użyciu Aspose.Slides, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [RenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/renderingoptions/) .
1. Użyj metody `RenderingOptions.set_SlidesLayoutOptions`, aby ustawić pozycję notatek prelegenta.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Pobierz referencję do slajdu według jego indeksu.
1. Pobierz obraz miniatury referowanego slajdu z opcjami renderowania.
1. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Przykład na żywo**

Możesz wypróbować darmową aplikację [**Aspose.Slides Viewer**](https://products.aspose.app/slides/pl/viewer/) i zobaczyć, co możesz zaimplementować przy użyciu API Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**Czy mogę osadzić przeglądarkę prezentacji w aplikacji internetowej?**

Tak. Możesz używać Aspose.Slides po stronie serwera, aby renderować slajdy jako obrazy lub HTML i wyświetlać je w przeglądarce. Funkcje nawigacji i powiększania można zaimplementować w JavaScript, aby uzyskać interaktywne wrażenia.

**Jaki jest najlepszy sposób wyświetlania slajdów w niestandardowej przeglądarce?**

Zalecane podejście to renderowanie każdego slajdu jako obrazu (np. PNG lub SVG) lub konwersja do HTML przy użyciu Aspose.Slides, a następnie wyświetlenie wyniku w kontrolce obrazu (w aplikacji desktop) lub w kontenerze HTML (w aplikacji webowej).

**Jak radzić sobie z dużymi prezentacjami zawierającymi wiele slajdów?**

W przypadku dużych zestawów rozważ ładowanie leniwe lub renderowanie slajdów na żądanie. Oznacza to generowanie zawartości slajdu tylko wtedy, gdy użytkownik przechodzi do niego, co zmniejsza zużycie pamięci i czas ładowania.