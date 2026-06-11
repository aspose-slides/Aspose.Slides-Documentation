---
title: Konwertowanie slajdów prezentacji na obrazy w Androidzie
linktitle: Slajd na obraz
type: docs
weight: 35
url: /pl/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj slajdy z PPT, PPTX i ODP na obrazy przy użyciu Aspose.Slides dla Androida — szybkie renderowanie wysokiej jakości z przejrzystymi przykładami kodu Java."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java umożliwia łatwe konwertowanie slajdów prezentacji PowerPoint i OpenDocument do różnych formatów obrazu, w tym BMP, PNG, JPG (JPEG), GIF i innych.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Zdefiniuj pożądane ustawienia konwersji i wybierz slajdy, które chcesz wyeksportować, używając:
   - Interfejsu [ITiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiffoptions/), lub
   - Interfejsu [IRenderingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irenderingoptions/).
2. Wygeneruj obraz slajdu, wywołując metodę [getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage--).

W Aspose.Slides for Android via Java interfejs [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) umożliwia pracę z obrazami zdefiniowanymi przez dane pikseli. Możesz używać tego interfejsu do zapisywania obrazów w szerokim zakresie formatów (BMP, JPG, PNG itp.).

## **Konwertowanie slajdów na bitmapy i zapisywanie obrazów w formacie PNG**

Możesz przekonwertować slajd na obiekt bitmapy i używać go bezpośrednio w aplikacji. Alternatywnie możesz skonwertować slajd na bitmapę, a następnie zapisać obraz w formacie JPEG lub dowolnym innym preferowanym formacie.

Poniższy kod demonstruje, jak przekonwertować pierwszy slajd prezentacji na obiekt bitmapy, a następnie zapisać obraz w formacie PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konwertuj pierwszy slajd prezentacji na bitmapę.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // Zapisz obraz w formacie PNG.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konwertowanie slajdów na obrazy o niestandardowych rozmiarach**

Możesz potrzebować obrazu o określonym rozmiarze. Korzystając z przeciążenia metody [getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-), możesz przekonwertować slajd na obraz o konkretnych wymiarach (szerokość i wysokość).

Poniższy przykładowy kod pokazuje, jak to zrobić:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konwertuj pierwszy slajd prezentacji na bitmapę o określonym rozmiarze.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // Zapisz obraz w formacie JPEG.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konwertowanie slajdów z notatkami i komentarzami na obrazy**

Niektóre slajdy mogą zawierać notatki i komentarze.

Aspose.Slides udostępnia dwa interfejsy — [ITiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiffoptions/) i [IRenderingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irenderingoptions/) — które pozwalają kontrolować renderowanie slajdów prezentacji do obrazów. Oba interfejsy zawierają metodę `setSlidesLayoutOptions`, która umożliwia konfigurowanie renderowania notatek i komentarzy na slajdzie podczas konwertowania go na obraz.

Za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notescommentslayoutingoptions/) możesz określić preferowaną pozycję notatek i komentarzy w wynikowym obrazie.

Poniższy kod demonstruje, jak przekonwertować slajd z notatkami i komentarzami:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Wczytaj plik prezentacji.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // Ustaw pozycję notatek.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // Ustaw pozycję komentarzy.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // Ustaw szerokość obszaru komentarzy.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // Ustaw kolor obszaru komentarzy.

    // Utwórz opcje renderowania.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // Konwertuj pierwszy slajd prezentacji na obraz.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // Zapisz obraz w formacie GIF.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Uwaga" color="warning" %}} 
W każdym procesie konwersji slajdu na obraz metoda [setNotesPosition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) nie może zastosować `BottomFull` (określającego pozycję notatek), ponieważ tekst notatki może być zbyt duży, co uniemożliwia zmieszczenie go w określonym rozmiarze obrazu.
{{% /alert %}} 

## **Konwertowanie slajdów na obrazy przy użyciu opcji TIFF**

Interfejs [ITiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiffoptions/) zapewnia większą kontrolę nad powstałym obrazem TIFF, umożliwiając określenie parametrów takich jak rozmiar, rozdzielczość, paleta kolorów i inne.

Poniższy kod demonstruje proces konwersji, w którym opcje TIFF są używane do wygenerowania czarno-białego obrazu o rozdzielczości 300 DPI i rozmiarze 2160 × 2800:

```java 
// Wczytaj plik prezentacji.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Pobierz pierwszy slajd z prezentacji.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Skonfiguruj ustawienia wyjściowego obrazu TIFF.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // Ustaw rozmiar obrazu.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // Ustaw format pikseli (czarno-biały).
    tiffOptions.setDpiX(300);                                        // Ustaw rozdzielczość poziomą.
    tiffOptions.setDpiY(300);                                        // Ustaw rozdzielczość pionową.

    // Konwertuj slajd na obraz przy użyciu określonych opcji.
    IImage image = slide.getImage(tiffOptions);

    try {
        // Zapisz obraz w formacie TIFF.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konwertowanie wszystkich slajdów na obrazy**

Aspose.Slides pozwala na konwersję wszystkich slajdów w prezentacji na obrazy, efektywnie przekształcając całą prezentację w serię obrazów.

Poniższy przykładowy kod pokazuje, jak w języku Java przekonwertować wszystkie slajdy w prezentacji na obrazy:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Renderuj prezentację do obrazów slajd po slajdzie.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Kontroluj ukryte slajdy (nie renderuj ukrytych slajdów).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Przekonwertuj slajd na obraz.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // Zapisz obraz w formacie JPEG.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie, metoda `getImage` zapisuje tylko statyczny obraz slajdu, bez animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak, ukryte slajdy mogą być przetwarzane tak samo jak zwykłe. Upewnij się tylko, że są uwzględnione w pętli przetwarzania.

**Czy obrazy mogą być zapisywane z cieniami i efektami?**

Tak, Aspose.Slides obsługuje renderowanie cieni, przezroczystości i innych efektów graficznych przy zapisywaniu slajdów jako obrazy.