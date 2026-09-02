---
title: Konwertowanie slajdów prezentacji na obrazy w Androidzie
linktitle: Slajd do obrazu
type: docs
weight: 35
url: /pl/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj slajdy z formatów PPT, PPTX i ODP na obrazy przy użyciu Aspose.Slides dla Androida — szybkie, wysokiej jakości renderowanie z przejrzystymi przykładami kodu w Javie."
---
## **Wstęp**

Aspose.Slides dla Androida za pośrednictwem Java umożliwia łatwe konwertowanie slajdów prezentacji PowerPoint i OpenDocument do różnych formatów obrazów, w tym BMP, PNG, JPG (JPEG), GIF i innych.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Zdefiniuj żądane ustawienia konwersji i wybierz slajdy, które chcesz wyeksportować, używając:
    - Interfejsu [ITiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiffoptions/) lub
    - Interfejsu [IRenderingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irenderingoptions/).
2. Wygeneruj obraz slajdu, wywołując metodę [getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage--).

W Aspose.Slides dla Androida za pośrednictwem Java, [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) jest interfejsem umożliwiającym pracę z obrazami zdefiniowanymi przez dane pikseli. Możesz użyć tego interfejsu do zapisywania obrazów w szerokim zakresie formatów (BMP, JPG, PNG itp.).

## **Konwertowanie slajdów na bitmapy i zapisywanie obrazów w formacie PNG**

Możesz przekonwertować slajd na obiekt bitmapy i używać go bezpośrednio w aplikacji. Alternatywnie możesz przekonwertować slajd na bitmapę, a następnie zapisać obraz w formacie JPEG lub innym wybranym formacie.

Ten kod demonstruje, jak przekonwertować pierwszy slajd prezentacji na obiekt bitmapy, a następnie zapisać obraz w formacie PNG:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konwertuj pierwszy slajd w prezentacji na bitmapę.
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

Możesz potrzebować obrazu o określonym rozmiarze. Korzystając z przeciążenia metody [getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-), możesz przekonwertować slajd na obraz o określonych wymiarach (szerokość i wysokość). 

Poniższy przykładowy kod pokazuje, jak to zrobić:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Konwertuj pierwszy slajd w prezentacji na bitmapę o określonym rozmiarze.
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

Aspose.Slides udostępnia dwa interfejsy — [ITiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiffoptions/) i [IRenderingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/irenderingoptions/) — które pozwalają kontrolować renderowanie slajdów prezentacji na obrazy. Oba interfejsy zawierają metodę `setSlidesLayoutOptions`, umożliwiającą skonfigurowanie renderowania notatek i komentarzy na slajdzie podczas konwersji na obraz.

Za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notescommentslayoutingoptions/) możesz określić preferowaną pozycję notatek i komentarzy w wygenerowanym obrazie.

Ten kod demonstruje, jak przekonwertować slajd z notatkami i komentarzami:

```java 
float scaleX = 2;
float scaleY = scaleX;

// Załaduj plik prezentacji.
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

{{% alert title="Note" color="warning" %}} 

W każdym procesie konwersji slajdu na obraz metoda [setNotesPosition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) nie może zastosować wartości `BottomFull` (określającej pozycję notatek), ponieważ tekst notatki może być zbyt duży, co uniemożliwia dopasowanie go do określonego rozmiaru obrazu.

{{% /alert %}} 

## **Konwertowanie slajdów na obrazy przy użyciu opcji TIFF**

Interfejs [ITiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiffoptions/) zapewnia większą kontrolę nad powstającym obrazem TIFF, umożliwiając określenie parametrów takich jak rozmiar, rozdzielczość, paleta kolorów i inne.

Ten kod demonstruje proces konwersji, w którym opcje TIFF są używane do wygenerowania czarno‑białego obrazu o rozdzielczości 300 DPI i rozmiarze 2160 × 2800:

```java 
// Załaduj plik prezentacji.
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

    // Konwertuj slajd na obraz z określonymi opcjami.
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

Aspose.Slides umożliwia konwersję wszystkich slajdów w prezentacji na obrazy, efektywnie przekształcając całą prezentację w serię obrazów.

Poniższy przykładowy kod pokazuje, jak w języku Java przekonwertować wszystkie slajdy w prezentacji na obrazy:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // Renderuj prezentację na obrazy slajd po slajdzie.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // Kontroluj ukryte slajdy (nie renderuj ukrytych slajdów).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // Konwertuj slajd na obraz.
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

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="warning" %}} 
Aby poprawnie renderować kolorowe emoji podczas konwersji slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne na systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji**, a ta czcionka jest nieobecna, emoji mogą być wyświetlane w monochromatycznym odcieniu na obrazach wyjściowych.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie, metoda `getImage` zapisuje tylko statyczny obraz slajdu, bez animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak, ukryte slajdy mogą być przetwarzane tak samo jak zwykłe. Należy jedynie upewnić się, że są uwzględnione w pętli przetwarzania.

**Czy obrazy mogą być zapisywane z cieniami i efektami?**

Tak, Aspose.Slides obsługuje renderowanie cieni, przezroczystości i innych efektów graficznych przy zapisywaniu slajdów jako obrazy.