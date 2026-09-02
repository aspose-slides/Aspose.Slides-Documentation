---
title: Konwertowanie slajdów prezentacji na obrazy w PHP
linktitle: Slajd na obraz
type: docs
weight: 35
url: /pl/php-java/convert-slide/
keywords:
- konwertuj slajd
- eksportuj slajd
- slajd na obraz
- zapisz slajd jako obraz
- slajd do EMF
- slajd do PNG
- slajd do JPEG
- slajd do bitmapy
- slajd do TIFF
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Konwertuj slajdy z prezentacji PPT, PPTX i ODP na PNG, JPEG, GIF, TIFF, EMF i inne formaty obrazów w PHP przy użyciu Aspose.Slides."
---
## **Wprowadzenie**

Aspose.Slides for PHP via Java może renderować pojedyncze slajdy z prezentacji PowerPoint i OpenDocument jako PNG, JPEG, GIF, TIFF i inne formaty obrazów.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Wybierz slajd, który chcesz wyrenderować.
3. W razie potrzeby skonfiguruj renderowanie przy użyciu klasy [RenderingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/).
4. Wywołaj metodę [Slide::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage). Zwraca ona obiekt [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/).
5. Wywołaj metodę [IImage::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/#save) i określ format wyjściowy przy użyciu wartości [ImageFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imageformat/).

## **Konwertowanie slajdu na obraz PNG**

Najprostsza konwersja używa domyślnych ustawień renderowania. Uzyskany obiekt [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) może być przetwarzany w pamięci lub zapisany do pliku.

Poniższy przykład PHP renderuje pierwszy slajd i zapisuje go jako obraz PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konwertowanie slajdów na obrazy z niestandardowymi rozmiarami**

Użyj przeciążenia [Slide::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage), które przyjmuje wartość [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html), aby renderować slajd o dokładnych wymiarach w pikselach.

Poniższy przykład tworzy obraz JPEG o wymiarach 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Konwertowanie slajdów z notatkami i komentarzami na obrazy**

Domyślnie obrazy slajdów nie zawierają notatek ani komentarzy. Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/) do metody [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), aby kontrolować, gdzie notatki i komentarze mają się pojawiać.

Poniższy przykład umieszcza skrócone notatki pod slajdem oraz komentarze po jego prawej stronie:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Podczas konwersji slajdu na obraz nie przekazuj [BottomFull](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notespositions/) do metody [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Notatki mogą zawierać więcej tekstu niż stały rozmiar obrazu może pomieścić. Zamiast tego użyj [BottomTruncated](https://reference.aspose.com/slides/pl/php-java/aspose.slides/notespositions/).
{{% /alert %}}

## **Konwertowanie slajdów na obrazy przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/) umożliwia kontrolowanie rozmiaru, rozdzielczości i innych właściwości renderowanego obrazu TIFF.

Poniższy przykład renderuje pierwszy slajd jako obraz TIFF o wymiarach 2160 × 2880 przy 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Obsługa TIFF nie jest gwarantowana w wersjach Javy wcześniejszych niż JDK 9.
{{% /alert %}}

## **Konwertowanie wszystkich slajdów na obrazy**

Iteruj po kolekcji slajdów, aby przekonwertować całą prezentację na serię obrazów. Ukryte slajdy są uwzględniane, chyba że jawnie je pominiesz.

Poniższy przykład renderuje każdy slajd jako obraz JPEG z poziomym i pionowym współczynnikiem skalowania równym 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Tworzenie wyjścia w formacie Enhanced Metafile**

Enhanced Metafile (EMF) jest przydatny, gdy grafika wektorowa musi być wymieniana z Microsoft Office lub innymi aplikacjami Windows obsługującymi pliki metafile Windows. W przeciwieństwie do obrazu rastrowego, EMF może zachować operacje rysunkowe wektora, które skalują się bez utraty ostrości. Jednak EMF jest przede wszystkim formatem kompatybilności dla aplikacji obsługujących pliki metafile Windows, a nie uniwersalnym formatem wymiany. Dodatkowo złożona zawartość slajdu, taka jak obrazy bitmapowe i niektóre efekty, może być przechowywana jako elementy rasteryzowane wewnątrz kontenera wektorowego metafile.

### **Eksportowanie slajdu do EMF**

Metoda [Slide::writeAsEmf](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#writeAsEmf) zapisuje slajd do docelowego strumienia w formacie EMF. Poniższy przykład ładuje prezentację, wybiera pierwszy slajd i zapisuje go do strumienia pliku EMF:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Wywołujący jest właścicielem strumienia przekazanego do [Slide::writeAsEmf](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#writeAsEmf) i jest odpowiedzialny za jego zamknięcie, jak pokazano powyżej.

### **Konwertowanie obrazu SVG do EMF i dodanie go do prezentacji**

Użyj [SvgImage::writeAsEmf](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/#writeAsEmf), aby przekonwertować zawartość SVG na EMF. Uzyskane bajty można dodać do prezentacji za pomocą [ImageCollection::addImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/#addImage) i umieścić na slajdzie przy pomocy [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addPictureFrame).

Poniższy przykład tworzy [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/) z kodu SVG, konwertuje go do EMF w pamięci, wstawia metafile na pierwszym slajdzie i zapisuje prezentację:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/#writeAsEmf) nie przejmuje własności docelowego strumienia. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) przechowuje wszystkie wygenerowane dane w pamięci, więc przed wywołaniem `toByteArray` nie jest wymagane resetowanie pozycji. Zwrócona tablica bajtów pozostaje ważna po zamknięciu strumienia.

Generowanie EMF jest dostępne na systemach operacyjnych obsługiwanych przez wybraną konfigurację Aspose.Slides for PHP via Java oraz JDK, ale renderowanie może różnić się w zależności od platformy, gdy czcionki lub zależności graficzne nie są dostępne. Zainstaluj czcionki użyte w oryginalnej treści lub skonfiguruj odpowiednie substytuty, postępuj zgodnie z [wymaganiami platformy](/slides/pl/php-java/system-requirements/) dla Aspose.Slides for PHP via Java i zweryfikuj wynik w docelowej aplikacji odczytującej EMF. Aplikacje Linux i macOS często mają ograniczone lub niejednolite wsparcie dla wyświetlania i edytowania metafile Windows.

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="info" %}}
Aby prawidłowo renderować kolorowe emoji podczas konwersji slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest nieobecna, emoji mogą pojawiać się w monochromatycznej formie w obrazach wyjściowych.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie. Metoda [Slide::getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage) renderuje statyczny obraz slajdu i nie eksportuje animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak. Ukryte slajdy mogą być renderowane jak zwykłe slajdy. Uwzględnij je w pętli przetwarzania, tak jak pokazano w powyższym przykładzie.

**Czy cienie i inne efekty są zachowywane w obrazach slajdów?**

Tak. Aspose.Slides renderuje cienie, przezroczystość i inne obsługiwane efekty graficzne w obrazach slajdów.