---
title: Konwertowanie slajdów prezentacji na obrazy w C++
linktitle: Slajd na obraz
type: docs
weight: 41
url: /pl/cpp/convert-slide/
keywords:
- konwertuj slajd
- eksportuj slajd
- slajd na obraz
- zapisz slajd jako obraz
- slajd do PNG
- slajd do JPEG
- slajd do bitmapy
- slajd do TIFF
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Konwertuj slajdy z PPT, PPTX i ODP na obrazy w C++ przy użyciu Aspose.Slides — szybkie, wysokiej jakości renderowanie z przejrzystymi przykładami kodu."
---
## **Wprowadzenie**

Aspose.Slides for C++ umożliwia łatwe konwertowanie slajdów prezentacji PowerPoint i OpenDocument do różnych formatów graficznych, w tym BMP, PNG, JPG (JPEG), GIF i innych.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Zdefiniuj żądane ustawienia konwersji i wybierz slajdy, które chcesz wyeksportować, używając:
    - interfejsu [ITiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/itiffoptions/) lub
    - interfejsu [IRenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/irenderingoptions/).
2. Wygeneruj obraz slajdu, wywołując metodę [GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/).

Klasa [Bitmap](https://reference.aspose.com/slides/pl/cpp/system.drawing/bitmap/) jest obiektem, który umożliwia pracę z obrazami zdefiniowanymi przez dane pikseli. Możesz użyć jej instancji do zapisywania obrazów w szerokim zakresie formatów (BMP, JPG, PNG itd.).

## **Konwertowanie slajdów na bitmapy i zapisywanie obrazów w formacie PNG**

Możesz przekonwertować slajd na obiekt bitmapy i używać go bezpośrednio w swojej aplikacji. Alternatywnie możesz przekonwertować slajd na bitmapę, a następnie zapisać obraz w formacie JPEG lub innym wybranym formacie.

Ten kod C++ demonstruje, jak przekonwertować pierwszy slajd prezentacji na obiekt bitmapy, a następnie zapisać obraz w formacie PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konwertuj pierwszy slajd w prezentacji na bitmapę.
auto image = presentation->get_Slide(0)->GetImage();

// Zapisz obraz w formacie PNG.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Konwertowanie slajdów na obrazy o niestandardowych rozmiarach**

Możesz potrzebować obrazu o określonym rozmiarze. Korzystając z przeciążenia metody [GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/), możesz przekonwertować slajd na obraz o konkretnych wymiarach (szerokość i wysokość).

Ten przykładowy kod demonstruje, jak to zrobić:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Konwertuj pierwszy slajd w prezentacji na bitmapę o określonym rozmiarze.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Zapisz obraz w formacie JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Konwertowanie slajdów z notatkami i komentarzami na obrazy**

Niektóre slajdy mogą zawierać notatki i komentarze.

Aspose.Slides udostępnia dwa interfejsy — [ITiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/itiffoptions/) i [IRenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/irenderingoptions/) — które pozwalają kontrolować renderowanie slajdów prezentacji na obrazy. Oba interfejsy zawierają metodę `set_SlidesLayoutOptions`, która umożliwia skonfigurowanie renderowania notatek i komentarzy na slajdzie podczas konwersji na obraz.

Za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/) możesz określić preferowaną pozycję notatek i komentarzy w powstałym obrazie.

Ten kod C++ demonstruje, jak przekonwertować slajd z notatkami i komentarzami:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Załaduj plik prezentacji.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Ustaw pozycję notatek.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Ustaw pozycję komentarzy.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Ustaw szerokość obszaru komentarzy.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Ustaw kolor obszaru komentarzy.

// Utwórz opcje renderowania.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Konwertuj pierwszy slajd prezentacji na obraz.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Zapisz obraz w formacie GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
W każdym procesie konwersji slajdu na obraz metoda [set_NotesPosition](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) nie może zastosować `BottomFull` (do określenia pozycji notatek), ponieważ tekst notatki może być zbyt duży, aby zmieścić się w określonym rozmiarze obrazu.
{{% /alert %}} 

## **Konwertowanie slajdów na obrazy przy użyciu opcji TIFF**

Interfejs [ITiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/itiffoptions/) zapewnia większą kontrolę nad powstałym obrazem TIFF, pozwalając określić takie parametry jak rozmiar, rozdzielczość, paleta kolorów i inne.

Ten kod C++ demonstruje proces konwersji, w którym opcje TIFF są używane do wygenerowania czarno-białego obrazu o rozdzielczości 300 DPI i rozmiarze 2160 × 2800:

```cpp 
// Załaduj plik prezentacji.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Pobierz pierwszy slajd z prezentacji.
auto slide = presentation->get_Slide(0);

// Skonfiguruj ustawienia wyjściowego obrazu TIFF.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Ustaw rozmiar obrazu.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Ustaw format pikseli (czarno-biały).
tiffOptions->set_DpiX(300);                                         // Ustaw rozdzielczość poziomą.
tiffOptions->set_DpiY(300);                                         // Ustaw rozdzielczość pionową.

// Konwertuj slajd na obraz przy użyciu określonych opcji.
auto image = slide->GetImage(tiffOptions);

// Zapisz obraz w formacie TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Konwertowanie wszystkich slajdów na obrazy**

Aspose.Slides umożliwia konwersję wszystkich slajdów w prezentacji na obrazy, efektywnie przekształcając całą prezentację w serię obrazów.

Ten przykładowy kod demonstruje, jak w C++ przekonwertować wszystkie slajdy w prezentacji na obrazy:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Renderuj prezentację do obrazów slajd po slajdzie.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Kontroluj ukryte slajdy (nie renderuj ukrytych slajdów).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Konwertuj slajd na obraz.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Zapisz obraz w formacie JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="warning" %}} 
Aby poprawnie renderować kolorowe emoji podczas konwersji slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest nieobecna, emoji mogą być wyświetlane w czerni i bieli w wygenerowanych obrazach.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie, metoda `GetImage` zapisuje tylko statyczny obraz slajdu, bez animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak, ukryte slajdy mogą być przetwarzane tak samo jak zwykłe. Należy tylko upewnić się, że są uwzględnione w pętli przetwarzania.

**Czy obrazy mogą być zapisywane z cieniami i efektami?**

Tak, Aspose.Slides obsługuje renderowanie cieni, przezroczystości i innych efektów graficznych przy zapisywaniu slajdów jako obrazy.