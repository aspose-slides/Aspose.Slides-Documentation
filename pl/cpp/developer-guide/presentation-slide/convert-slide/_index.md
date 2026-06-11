---
title: Konwertowanie slajdów prezentacji na obrazy w C++
linktitle: Slajd do obrazu
type: docs
weight: 41
url: /pl/cpp/convert-slide/
keywords:
- konwertowanie slajdu
- eksport slajdu
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
description: "Konwertuj slajdy z formatów PPT, PPTX i ODP na obrazy w C++ przy użyciu Aspose.Slides — szybkie, wysokiej jakości renderowanie z przejrzystymi przykładami kodu."
---
## **Wprowadzenie**

Aspose.Slides dla C++ umożliwia łatwe konwertowanie slajdów prezentacji PowerPoint i OpenDocument na różne formaty obrazu, w tym BMP, PNG, JPG (JPEG), GIF i inne.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Zdefiniuj żądane ustawienia konwersji i wybierz slajdy, które chcesz wyeksportować, używając:
    - The [ITiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/itiffoptions/) interface, or
    - The [IRenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/irenderingoptions/) interface.
2. Wygeneruj obraz slajdu, wywołując metodę [GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/).

Obiekt [Bitmap](https://reference.aspose.com/slides/pl/cpp/system.drawing/bitmap/) pozwala pracować z obrazami zdefiniowanymi danymi pikseli. Możesz użyć instancji tej klasy do zapisywania obrazów w szerokim zakresie formatów (BMP, JPG, PNG itp.).

## **Konwertuj slajdy na bitmapy i zapisz obrazy w formacie PNG**

Możesz przekonwertować slajd na obiekt bitmapy i używać go bezpośrednio w aplikacji. Alternatywnie możesz przekonwertować slajd na bitmapę, a następnie zapisać obraz w formacie JPEG lub innym wybranym formacie.

Poniższy kod C++ pokazuje, jak przekonwertować pierwszy slajd prezentacji na obiekt bitmapy, a następnie zapisać obraz w formacie PNG:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Konwertuj slajdy na obrazy o niestandardowych rozmiarach**

Możesz potrzebować obrazu o określonym rozmiarze. Korzystając z przeciążenia metody [GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/), możesz przekonwertować slajd na obraz o konkretnych wymiarach (szerokość i wysokość). 

Poniższy przykładowy kod pokazuje, jak to zrobić:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Przekształć pierwszy slajd w prezentacji na bitmapę o określonym rozmiarze.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Zapisz obraz w formacie JPEG.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Konwertuj slajdy z notatkami i komentarzami na obrazy**

Niektóre slajdy mogą zawierać notatki i komentarze.

Aspose.Slides udostępnia dwa interfejsy—[ITiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/itiffoptions/) i [IRenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/irenderingoptions/)—pozwalające kontrolować renderowanie slajdów prezentacji na obrazy. Oba interfejsy zawierają metodę `set_SlidesLayoutOptions`, która umożliwia konfigurowanie renderowania notatek i komentarzy na slajdzie podczas konwersji na obraz.

Korzystając z klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/), możesz określić preferowaną pozycję notatek i komentarzy w wygenerowanym obrazie.

Poniższy kod C++ pokazuje, jak przekonwertować slajd z notatkami i komentarzami:

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

// Przekształć pierwszy slajd prezentacji na obraz.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Zapisz obraz w formacie GIF.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Uwaga" color="warning" %}} 
W każdym procesie konwersji slajdu na obraz metoda [set_NotesPosition](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) nie może zastosować `BottomFull` (określającego pozycję notatek), ponieważ tekst notatki może być zbyt obszerny, co uniemożliwia zmieszczenie go w określonym rozmiarze obrazu.
{{% /alert %}} 

## **Konwertuj slajdy na obrazy przy użyciu opcji TIFF**

Interfejs [ITiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/itiffoptions/) zapewnia większą kontrolę nad wynikowym obrazem TIFF, umożliwiając określenie parametrów takich jak rozmiar, rozdzielczość, paleta kolorów i inne.

Poniższy kod C++ demonstruje proces konwersji, w którym opcje TIFF są używane do wygenerowania czarno-białego obrazu o rozdzielczości 300 DPI i rozmiarze 2160 × 2800:

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

// Przekształć slajd na obraz przy użyciu określonych opcji.
auto image = slide->GetImage(tiffOptions);

// Zapisz obraz w formacie TIFF.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Konwertuj wszystkie slajdy na obrazy**

Aspose.Slides umożliwia konwersję wszystkich slajdów w prezentacji na obrazy, efektywnie przekształcając całą prezentację w serię obrazów.

Poniższy przykładowy kod pokazuje, jak przekonwertować wszystkie slajdy w prezentacji na obrazy w C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Renderuj prezentację na obrazy slajd po slajdzie.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Kontroluj ukryte slajdy (nie renderuj ukrytych slajdów).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Przekształć slajd na obraz.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Zapisz obraz w formacie JPEG.
    image->Save(String::Format(u"Slide_{0}.jpg", i), ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie, metoda `GetImage` zapisuje tylko statyczny obraz slajdu, bez animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak, ukryte slajdy mogą być przetwarzane tak samo jak zwykłe. Należy tylko upewnić się, że są uwzględnione w pętli przetwarzania.

**Czy obrazy mogą być zapisywane z cieniami i efektami?**

Tak, Aspose.Slides obsługuje renderowanie cieni, przezroczystości i innych efektów graficznych przy zapisywaniu slajdów jako obrazy.