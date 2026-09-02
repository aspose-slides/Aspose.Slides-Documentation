---
title: Konwertowanie slajdów prezentacji na obrazy w .NET
linktitle: Slajd na obraz
type: docs
weight: 41
url: /pl/net/convert-slide/
keywords:
- konwertuj slajd
- eksportuj slajd
- slajd na obraz
- zapisz slajd jako obraz
- slajd na PNG
- slajd na JPEG
- slajd na bitmapę
- slajd na TIFF
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Konwertuj slajdy z formatów PPT, PPTX i ODP na obrazy w C# przy użyciu Aspose.Slides dla .NET — szybkie, wysokiej jakości renderowanie z przejrzystymi przykładami kodu."
---
## **Wprowadzenie**

Aspose.Slides for .NET umożliwia łatwe konwertowanie slajdów prezentacji PowerPoint i OpenDocument do różnych formatów obrazów, w tym BMP, PNG, JPG (JPEG), GIF i innych.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Zdefiniuj pożądane ustawienia konwersji i wybierz slajdy, które chcesz wyeksportować, używając:
    - interfejsu [ITiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/itiffoptions/), lub
    - interfejsu [IRenderingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/irenderingoptions/).
2. Wygeneruj obraz slajdu, wywołując metodę [GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/).

W .NET klasa [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) jest obiektem, który umożliwia pracę z obrazami definiowanymi przez dane pikseli. Możesz użyć instancji tej klasy do zapisywania obrazów w wielu formatach (BMP, JPG, PNG itp.).

## **Konwertowanie slajdów na bitmapy i zapisywanie obrazów w formacie PNG**

Możesz przekonwertować slajd na obiekt bitmapy i używać go bezpośrednio w swojej aplikacji. Alternatywnie możesz przekonwertować slajd na bitmapę, a następnie zapisać obraz w formacie JPEG lub innym wybranym formacie.

Ten kod C# demonstruje, jak przekonwertować pierwszy slajd prezentacji na obiekt bitmapy, a następnie zapisać obraz w formacie PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Konwertuj pierwszy slajd w prezentacji na bitmapę.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Zapisz obraz w formacie PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Konwertowanie slajdów na obrazy o niestandardowych rozmiarach**

Możesz potrzebować obrazu o określonym rozmiarze. Korzystając z przeciążenia metody [GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/), możesz przekonwertować slajd na obraz o konkretnych wymiarach (szerokość i wysokość).

Poniższy przykładowy kod demonstruje, jak to zrobić:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Konwertuj pierwszy slajd w prezentacji na bitmapę o określonym rozmiarze.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Zapisz obraz w formacie JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Konwertowanie slajdów z notatkami i komentarzami na obrazy**

Niektóre slajdy mogą zawierać notatki i komentarze.

Aspose.Slides udostępnia dwa interfejsy — [ITiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/itiffoptions/) i [IRenderingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/irenderingoptions/) — które pozwalają kontrolować renderowanie slajdów prezentacji na obrazy. Oba interfejsy zawierają właściwość `SlidesLayoutOptions`, która umożliwia skonfigurowanie renderowania notatek i komentarzy na slajdzie podczas konwersji na obraz.

Za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notescommentslayoutingoptions/) możesz określić preferowaną pozycję notatek i komentarzy w uzyskanym obrazie.

Ten kod C# demonstruje, jak przekonwertować slajd z notatkami i komentarzami:

```cs
float scaleX = 2;
float scaleY = scaleX;

// Załaduj plik prezentacji.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Utwórz opcje renderowania.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Ustaw pozycję notatek.
            CommentsPosition = CommentsPositions.Right,      // Ustaw pozycję komentarzy.
            CommentsAreaWidth = 500,                         // Ustaw szerokość obszaru komentarzy.
            CommentsAreaColor = Color.AntiqueWhite           // Ustaw kolor obszaru komentarzy.
        }
    };

    // Konwertuj pierwszy slajd prezentacji na obraz.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Zapisz obraz w formacie GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
W każdym procesie konwersji slajdów na obrazy właściwość [NotesPosition](https://reference.aspose.com/slides/pl/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) nie może być ustawiona na `BottomFull` (aby określić pozycję notatek), ponieważ tekst notatki może być zbyt duży, co uniemożliwia zmieszczenie go w określonym rozmiarze obrazu.
{{% /alert %}} 

## **Konwertowanie slajdów na obrazy przy użyciu opcji TIFF**

Interfejs [ITiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/itiffoptions/) zapewnia większą kontrolę nad powstałym obrazem TIFF, umożliwiając określenie parametrów, takich jak rozmiar, rozdzielczość, paleta kolorów i inne.

Ten kod C# demonstruje proces konwersji, w którym opcje TIFF są używane do wygenerowania czarno-białego obrazu o rozdzielczości 300 DPI i rozmiarze 2160 × 2800:

```cs
// Załaduj plik prezentacji.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Pobierz pierwszy slajd z prezentacji.
    ISlide slide = presentation.Slides[0];

    // Skonfiguruj ustawienia wyjściowego obrazu TIFF.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Ustaw rozmiar obrazu.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Ustaw format pikseli (czarno-biały).
        DpiX = 300,                                        // Ustaw rozdzielczość poziomą.
        DpiY = 300                                         // Ustaw rozdzielczość pionową.
    };

    // Przekonwertuj slajd na obraz przy użyciu określonych opcji.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Zapisz obraz w formacie TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Konwertowanie wszystkich slajdów na obrazy**

Aspose.Slides umożliwia konwersję wszystkich slajdów w prezentacji na obrazy, skutecznie przekształcając całą prezentację w serię obrazów.

Poniższy przykładowy kod demonstruje, jak w C# przekonwertować wszystkie slajdy w prezentacji na obrazy:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Renderuj prezentację do obrazów slajd po slajdzie.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Kontroluj ukryte slajdy (nie renderuj ukrytych slajdów).
        if (presentation.Slides[i].Hidden)
            continue;

        // Przekonwertuj slajd na obraz.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Zapisz obraz w formacie JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="warning" %}} 
Aby prawidłowo renderować kolorowe emoji podczas konwersji slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie przeprowadzającym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest nieobecna, emoji mogą być wyświetlane w odcieniach szarości w wygenerowanych obrazach.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie, metoda `GetImage` zapisuje tylko statyczny obraz slajdu, bez animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak, ukryte slajdy mogą być przetwarzane tak samo jak zwykłe. Należy tylko upewnić się, że są uwzględnione w pętli przetwarzania.

**Czy obrazy mogą być zapisywane z cieniami i efektami?**

Tak, Aspose.Slides obsługuje renderowanie cieni, przezroczystości i innych efektów graficznych przy zapisywaniu slajdów jako obrazy.