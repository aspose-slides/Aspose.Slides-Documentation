---
title: Konwertowanie slajdów prezentacji na obrazy w PHP
linktitle: Slajd na obraz
type: docs
weight: 35
url: /pl/php-java/convert-slide/
keywords:
- konwertowanie slajdu
- eksportowanie slajdu
- slajd na obraz
- zapisz slajd jako obraz
- slajd na PNG
- slajd na JPEG
- slajd na bitmapę
- slajd na TIFF
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Konwertuj slajdy z formatów PPT, PPTX i ODP na obrazy przy użyciu Aspose.Slides for PHP via Java — szybkie, wysokiej jakości renderowanie z przejrzystymi przykładami kodu."
---
## **Wprowadzenie**

Aspose.Slides for PHP via Java umożliwia łatwe konwertowanie slajdów prezentacji PowerPoint i OpenDocument na różne formaty obrazu, w tym BMP, PNG, JPG (JPEG), GIF i inne.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Zdefiniuj żądane ustawienia konwersji i wybierz slajdy, które chcesz wyeksportować, używając:
    - klasy [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/) lub
    - klasy [RenderingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/).
2. Wygeneruj obraz slajdu, wywołując metodę [getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage).

W Aspose.Slides for PHP via Java interfejs [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) jest klasą, która umożliwia pracę z obrazami zdefiniowanymi danymi pikseli. Możesz użyć tej klasy do zapisywania obrazów w szerokim zakresie formatów (BMP, JPG, PNG itp.).

## **Konwertowanie slajdów na bitmapy i zapisywanie obrazów w formacie PNG**

Możesz przekonwertować slajd na obiekt bitmapy i używać go bezpośrednio w aplikacji. Alternatywnie możesz przekonwertować slajd na bitmapę, a następnie zapisać obraz w formacie JPEG lub innym wybranym formacie.

Poniższy kod demonstruje, jak przekonwertować pierwszy slajd prezentacji na obiekt bitmapy, a następnie zapisać obraz w formacie PNG:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    // Konwertuj pierwszy slajd w prezentacji na bitmapę.
    $image = $presentation->getSlides()->get_Item(0)->getImage();
    try {
        // Zapisz obraz w formacie PNG.
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konwertowanie slajdów na obrazy o niestandardowych rozmiarach**

Możesz potrzebować obrazu o określonym rozmiarze. Korzystając z przeciążenia metody [getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage), możesz przekonwertować slajd na obraz o konkretnych wymiarach (szerokość i wysokość). 

Poniższy przykład kodu pokazuje, jak to zrobić:

```php
$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    // Konwertuj pierwszy slajd w prezentacji na bitmapę o określonym rozmiarze.
    $image = $presentation->getSlides()->get_Item(0)->getImage($imageSize);
    try {
        // Zapisz obraz w formacie JPEG.
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konwertowanie slajdów z notatkami i komentarzami na obrazy**

Niektóre slajdy mogą zawierać notatki i komentarze.

Aspose.Slides udostępnia dwie klasy[TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/) i [RenderingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/)—które pozwalają kontrolować renderowanie slajdów prezentacji na obrazy. Obie klasy zawierają metodę `setSlidesLayoutOptions`, która umożliwia skonfigurowanie renderowania notatek i komentarzy na slajdzie podczas konwersji do obrazu.

Za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/) możesz określić preferowaną pozycję notatek i komentarzy w uzyskanym obrazie.

Poniższy kod demonstruje, jak przekonwertować slajd z notatkami i komentarzami:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $notesCommentsOptions = new NotesCommentsLayoutingOptions();
    $notesCommentsOptions->setNotesPosition(NotesPositions::BottomTruncated);         // Ustaw pozycję notatek.
    $notesCommentsOptions->setCommentsPosition(CommentsPositions::Right);             // Ustaw pozycję komentarzy.
    $notesCommentsOptions->setCommentsAreaWidth(500);                                 // Ustaw szerokość obszaru komentarzy.
    $notesCommentsOptions->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);  // Ustaw kolor obszaru komentarzy.

    // Utwórz opcje renderowania.
    $options = new RenderingOptions();
    $options->setSlidesLayoutOptions($notesCommentsOptions);

    // Konwertuj pierwszy slajd prezentacji na obraz.
    $image = $presentation->getSlides()->get_Item(0)->getImage($options, $scaleX, $scaleY);
    try {
        // Zapisz obraz w formacie GIF.
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

W każdym procesie konwersji slajdu na obraz metoda [setNotesPosition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) nie może zastosować wartości `BottomFull` (aby określić pozycję notatek), ponieważ tekst notatki może być zbyt duży, co uniemożliwia zmieszczenie go w określonym rozmiarze obrazu.

{{% /alert %}} 

## **Konwertowanie slajdów na obrazy przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/) zapewnia większą kontrolę nad wynikowym obrazem TIFF, umożliwiając określenie parametrów takich jak rozmiar, rozdzielczość, paleta kolorów i inne.

Poniższy kod demonstruje proces konwersji, w którym opcje TIFF są używane do wygenerowania czarno-białego obrazu z rozdzielczością 300 DPI i rozmiarem 2160 × 2800:

```php
// Wczytaj plik prezentacji.
$presentation = new Presentation("sample.pptx");
try {
    // Pobierz pierwszy slajd z prezentacji.
    $slide = $presentation->getSlides()->get_Item(0);

    // Skonfiguruj ustawienia wyjściowego obrazu TIFF.
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));  // Ustaw rozmiar obrazu.
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);       // Ustaw format pikseli (czarno-biały).
    $options->setDpiX(300);                                              // Ustaw rozdzielczość poziomą.
    $options->setDpiY(300);                                              // Ustaw rozdzielczość pionową.
    
    // Konwertuj slajd na obraz z podanymi opcjami.
    $image = $slide->getImage($options);
    try {
        // Zapisz obraz w formacie TIFF.
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Obsługa formatu TIFF nie jest gwarantowana w wersjach starszych niż JDK 9.

{{% /alert %}} 

## **Konwertowanie wszystkich slajdów na obrazy**

Aspose.Slides umożliwia konwersję wszystkich slajdów w prezentacji na obrazy, efektywnie zamieniając całą prezentację w serię obrazów.

Poniższy przykład kodu pokazuje, jak w PHP przekonwertować wszystkie slajdy w prezentacji na obrazy:

```php
$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    // Renderuj prezentację do obrazów slajd po slajdzie.
    for($i = 0; $i < java_values($presentation->getSlides()->size()) ; $i++) {
        // Kontroluj ukryte slajdy (nie renderuj ukrytych slajdów).
        if (java_values($presentation->getSlides()->get_Item($i)->getHidden())) {
            continue;
        }

        // Konwertuj slajd na obraz.
        $image = $presentation->getSlides()->get_Item($i)->getImage($scaleX, $scaleY);
        try {
            // Zapisz obraz w formacie JPEG.
            $image->save("Slide_" . $i . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie, metoda `getImage` zapisuje jedynie statyczny obraz slajdu, bez animacji.

**Czy ukryte slajdy można eksportować jako obrazy?**

Tak, ukryte slajdy mogą być przetwarzane tak samo jak zwykłe. Należy tylko upewnić się, że są uwzględnione w pętli przetwarzania.

**Czy obrazy można zapisać z cieniami i efektami?**

Tak, Aspose.Slides obsługuje renderowanie cieni, przezroczystości i innych efektów graficznych podczas zapisywania slajdów jako obrazy.