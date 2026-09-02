---
title: Konwertowanie slajdów prezentacji na obrazy w JavaScript
linktitle: Slajd na obraz
type: docs
weight: 35
url: /pl/nodejs-java/convert-slide/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj slajdy z PPT, PPTX i ODP na obrazy w JavaScript przy użyciu Aspose.Slides dla Node.js via Java — szybkie, wysokiej jakości renderowanie z przejrzystymi przykładami kodu."
---
## **Wprowadzenie**

Aspose.Slides for Node.js via Java umożliwia łatwe konwertowanie slajdów prezentacji PowerPoint i OpenDocument do różnych formatów obrazu, w tym BMP, PNG, JPG (JPEG), GIF i innych.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Określ żądane ustawienia konwersji i wybierz slajdy, które chcesz wyeksportować, używając:
    - Klasy [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/) lub
    - Klasy [RenderingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/) .
2. Wygeneruj obraz slajdu, wywołując metodę [getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage).

W Aspose.Slides for Node.js via Java, [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) jest klasą pozwalającą pracować z obrazami zdefiniowanymi przez dane pikseli. Możesz używać tej klasy do zapisywania obrazów w szerokim zakresie formatów (BMP, JPG, PNG itp.).

## **Konwertowanie slajdów na bitmapę i zapisywanie obrazów w formacie PNG**

Możesz skonwertować slajd do obiektu bitmapy i używać go bezpośrednio w swojej aplikacji. Alternatywnie możesz skonwertować slajd do bitmapy, a następnie zapisać obraz w formacie JPEG lub innym wybranym formacie.

Ten kod JavaScript pokazuje, jak skonwertować pierwszy slajd prezentacji do obiektu bitmapy, a następnie zapisać obraz w formacie PNG:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konwertuj pierwszy slajd w prezentacji na bitmapę.
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // Zapisz obraz w formacie PNG.
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konwertowanie slajdów na obrazy o niestandardowych rozmiarach**

Możesz potrzebować obrazu o określonym rozmiarze. Korzystając z przeciążenia metody [getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage), możesz przekonwertować slajd na obraz o konkretnych wymiarach (szerokość i wysokość).

Poniższy przykładowy kod pokazuje, jak to zrobić:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Konwertuj pierwszy slajd w prezentacji na bitmapę o określonym rozmiarze.
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // Zapisz obraz w formacie JPEG.
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konwertowanie slajdów z notatkami i komentarzami na obrazy**

Niektóre slajdy mogą zawierać notatki i komentarze.

Aspose.Slides udostępnia dwie klasy — [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/) i [RenderingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/) — które pozwalają kontrolować renderowanie slajdów prezentacji na obrazy. Obie klasy zawierają metodę `setSlidesLayoutOptions`, umożliwiającą skonfigurowanie renderowania notatek i komentarzy na slajdzie podczas konwersji na obraz.

Za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) możesz określić preferowaną pozycję notatek i komentarzy w uzyskanym obrazie.

Ten kod JavaScript demonstruje, jak przekonwertować slajd z notatkami i komentarzami:

```js
const scaleX = 2;
const scaleY = scaleX;

// Wczytaj plik prezentacji.
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // Ustaw pozycję notatek.
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // Ustaw pozycję komentarzy.
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // Ustaw szerokość obszaru komentarzy.
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // Ustaw kolor obszaru komentarzy.

    // Utwórz opcje renderowania.
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // Konwertuj pierwszy slajd prezentacji na obraz.
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // Zapisz obraz w formacie GIF.
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

W każdym procesie konwersji slajd‑do‑obrazu metoda [setNotesPosition](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) nie może zastosować `BottomFull` (aby określić pozycję notatek), ponieważ tekst notatki może być zbyt obszerny, aby zmieścić się w określonym rozmiarze obrazu. 

{{% /alert %}} 

## **Konwertowanie slajdów na obrazy przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/) zapewnia większą kontrolę nad wynikowym plikiem TIFF, umożliwiając określenie parametrów takich jak rozmiar, rozdzielczość, paleta kolorów i inne.

Ten kod JavaScript pokazuje proces konwersji, w którym opcje TIFF są używane do wygenerowania obrazu czarno‑białego o rozdzielczości 300 DPI i rozmiarze 2160 × 2800:

```js
// Wczytaj plik prezentacji.
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Pobierz pierwszy slajd z prezentacji.
    let slide = presentation.getSlides().get_Item(0);

    // Skonfiguruj ustawienia wyjściowego obrazu TIFF.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // Ustaw rozmiar obrazu.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // Ustaw format pikseli (czarno-biały).
    tiffOptions.setDpiX(300);                                                          // Ustaw rozdzielczość poziomą.
    tiffOptions.setDpiY(300);                                                          // Ustaw rozdzielczość pionową.

    // Konwertuj slajd na obraz z określonymi opcjami.
    let image = slide.getImage(tiffOptions);
    try {
        // Zapisz obraz w formacie TIFF.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Obsługa TIFF nie jest gwarantowana w wersjach wcześniejszych niż JDK 9. 

{{% /alert %}} 

## **Konwertowanie wszystkich slajdów na obrazy**

Aspose.Slides pozwala konwertować wszystkie slajdy w prezentacji na obrazy, skutecznie przekształcając całą prezentację w serię obrazów.

Poniższy przykładowy kod demonstruje, jak przekonwertować wszystkie slajdy w prezentacji na obrazy w JavaScript:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Renderuj prezentację do obrazów slajd po slajdzie.
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // Kontroluj ukryte slajdy (nie renderuj ukrytych slajdów).
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // Konwertuj slajd na obraz.
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // Zapisz obraz w formacie JPEG.
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
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
Aby poprawnie renderować kolorowe emoji podczas konwertowania slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest nieobecna, emoji mogą pojawiać się w odcieniach szarości w wygenerowanych obrazach. 
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie, metoda `getImage` zapisuje jedynie statyczny obraz slajdu, bez animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak, ukryte slajdy mogą być przetwarzane tak samo jak zwykłe. Należy jedynie upewnić się, że są uwzględnione w pętli przetwarzania.

**Czy obrazy mogą być zapisywane z cieniami i efektami?**

Tak, Aspose.Slides obsługuje renderowanie cieni, przezroczystości i innych efektów graficznych przy zapisywaniu slajdów jako obrazy.