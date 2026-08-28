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
- slajd na EMF
- slajd na PNG
- slajd na JPEG
- slajd na bitmapę
- slajd na TIFF
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj slajdy z prezentacji PPT, PPTX i ODP na PNG, JPEG, GIF, TIFF, EMF i inne formaty obrazów w JavaScript przy użyciu Aspose.Slides."
---
## **Wstęp**

Aspose.Slides for Node.js via Java może renderować pojedyncze slajdy z prezentacji PowerPoint i OpenDocument jako PNG, JPEG, GIF, TIFF i inne formaty obrazu.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Wybierz slajd, który chcesz wyrenderować.
3. W razie potrzeby skonfiguruj renderowanie za pomocą klasy [RenderingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/).
4. Wywołaj metodę [Slide.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage). Zwraca ona obiekt [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/).
5. Wywołaj metodę [IImage.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/#save) i określ format wyjściowy przy pomocy wartości [ImageFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imageformat/).

## **Konwersja slajdu do obrazu PNG**

Najprostsza konwersja używa domyślnych ustawień renderowania. Uzyskany obiekt [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) może być przetwarzany w pamięci lub zapisany do pliku.

Poniższy przykład JavaScript renderuje pierwszy slajd i zapisuje go jako obraz PNG:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konwersja slajdów do obrazów o niestandardowych rozmiarach**

Użyj przeciążenia [Slide.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage), które przyjmuje wartość `java.awt.Dimension`, aby wyrenderować slajd o dokładnych wymiarach w pikselach.

Poniższy przykład tworzy obraz JPEG o wymiarach 1820 × 1040:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konwersja slajdów z notatkami i komentarzami do obrazów**

Domyślnie obrazy slajdów nie zawierają notatek ani komentarzy. Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notescommentslayoutingoptions/) do metody [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), aby kontrolować, gdzie mają się pojawiać notatki i komentarze.

Poniższy przykład umieszcza przycięte notatki pod slajdem oraz komentarze po jego prawej stronie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Do konwersji slajdu na obraz nie przekazuj [BottomFull](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notespositions/) do metody [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Notatki mogą zawierać więcej tekstu niż stały rozmiar obrazu może pomieścić. Zamiast tego użyj [BottomTruncated](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/notespositions/).
{{% /alert %}}

## **Konwersja slajdów do obrazów przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/) pozwala kontrolować rozmiar, rozdzielczość i inne właściwości wyrenderowanego obrazu TIFF.

Poniższy przykład renderuje pierwszy slajd jako obraz TIFF o wymiarach 2160 × 2880 przy 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Obsługa TIFF nie jest gwarantowana w wersjach Java starszych niż JDK 9.
{{% /alert %}}

## **Konwersja wszystkich slajdów do obrazów**

Iteruj po kolekcji slajdów, aby przekonwertować całą prezentację na serię obrazów. Ukryte slajdy są uwzględniane, chyba że wyraźnie je pominiesz.

Poniższy przykład renderuje każdy slajd jako obraz JPEG z poziomymi i pionowymi współczynnikami skali równymi 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tworzenie wyjścia w formacie Enhanced Metafile**

Enhanced Metafile (EMF) jest przydatny, gdy grafika wektorowa musi być wymieniana z Microsoft Office lub innymi aplikacjami Windows obsługującymi pliki metafile Windows. W przeciwieństwie do obrazu rastrowego, EMF może zachować operacje rysunkowe wektorowe, które skalują się bez utraty ostrości. Jednak EMF jest przede wszystkim formatem zgodności dla aplikacji obsługujących metafile Windows, a nie uniwersalnym formatem wymiany. Dodatkowo, złożona zawartość slajdu, taka jak obrazy bitmapowe i niektóre efekty, może być przechowywana jako elementy rastrowe wewnątrz kontenera metafile wektorowego.

### **Eksport slajdu do EMF**

Metoda [Slide.writeAsEmf](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#writeAsEmf) zapisuje slajd do docelowego strumienia w formacie EMF. Poniższy przykład ładuje prezentację, wybiera pierwszy slajd i zapisuje go do strumienia pliku EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Wywołujący jest właścicielem strumienia przekazanego do [Slide.writeAsEmf](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#writeAsEmf) i jest odpowiedzialny za jego zamknięcie, jak pokazano powyżej.

### **Konwersja obrazu SVG do EMF i dodanie go do prezentacji**

Użyj [SvgImage.writeAsEmf](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgimage/#writeAsEmf), aby przekonwertować zawartość SVG na EMF. Wynikowe bajty można dodać do prezentacji za pomocą [ImageCollection.addImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagecollection/#addImage) i umieścić na slajdzie przy pomocy [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

Poniższy przykład tworzy [SvgImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgimage/) z kodu SVG, konwertuje go na EMF w pamięci, wstawia metafile na pierwszym slajdzie i zapisuje prezentację:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgimage/#writeAsEmf) nie przejmuje własności docelowego strumienia. `java.io.ByteArrayOutputStream` przechowuje wszystkie wygenerowane dane w pamięci, więc przed wywołaniem `toByteArray` nie jest wymagana resetacja pozycji. Zwrócona tablica bajtów pozostaje ważna po zamknięciu strumienia.

Generowanie EMF jest dostępne na systemach operacyjnych obsługiwanych przez wybraną konfigurację Aspose.Slides for Node.js via Java i JDK, jednak renderowanie może się różnić między platformami, gdy czcionki lub zależności graficzne są niedostępne. Zainstaluj czcionki używane w źródłowej zawartości lub skonfiguruj odpowiednie zamienniki, postępuj zgodnie z [wymaganiami platformy](/slides/pl/nodejs-java/system-requirements/) dla Aspose.Slides for Node.js via Java i zweryfikuj wynik w docelowej aplikacji konsumującej EMF. Aplikacje Linux i macOS często mają ograniczone lub niejednolite wsparcie dla wyświetlania i edycji metafile Windows.

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="info" %}}
Aby poprawnie renderować kolorowe emoji przy konwersji slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji**, a ta czcionka jest nieobecna, emoji mogą być wyświetlane w monochromatycznej formie w obrazach wyjściowych.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie. Metoda [Slide.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage) renderuje statyczny obraz slajdu i nie eksportuje animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak. Ukryte slajdy mogą być renderowane tak jak zwykłe slajdy. Uwzględnij je w pętli przetwarzania, jak pokazano w powyższym przykładzie.

**Czy cienie i inne efekty są zachowywane w obrazach slajdów?**

Tak. Aspose.Slides renderuje cienie, przezroczystość i inne obsługiwane efekty graficzne w obrazach slajdów.