---
title: Konwertowanie slajdów prezentacji na obrazy w Javie
linktitle: Slajd na obraz
type: docs
weight: 35
url: /pl/java/convert-slide/
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
- Java
- Aspose.Slides
description: "Konwertuj slajdy z prezentacji PPT, PPTX i ODP na PNG, JPEG, GIF, TIFF, EMF oraz inne formaty obrazów w Javie przy użyciu Aspose.Slides."
---
## **Wprowadzenie**

Aspose.Slides for Java może renderować pojedyncze slajdy z prezentacji PowerPoint i OpenDocument jako PNG, JPEG, GIF, TIFF i inne formaty obrazów.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Załaduj prezentację za pomocą klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Wybierz slajd, który chcesz wyrenderować.
3. W razie potrzeby skonfiguruj renderowanie przy pomocy klasy [RenderingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/renderingoptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/).
4. Wywołaj metodę [ISlide.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#getImage--). Zwraca ona obiekt [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/).
5. Wywołaj metodę [IImage.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) i określ format wyjściowy za pomocą wartości [ImageFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/).

## **Konwertowanie slajdu na obraz PNG**

Najprostsza konwersja używa domyślnych ustawień renderowania. Uzyskany obiekt [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) może być przetwarzany w pamięci lub zapisany do pliku.

Poniższy przykład w języku Java renderuje pierwszy slajd i zapisuje go jako obraz PNG:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konwersja slajdów do obrazów o niestandardowych rozmiarach**

Użyj przeciążenia [ISlide.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-), które przyjmuje wartość [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html), aby renderować slajd o dokładnych wymiarach w pikselach.

Poniższy przykład tworzy obraz JPEG o wymiarach 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Konwersja slajdów z notatkami i komentarzami do obrazów**

Domyślnie obrazy slajdów nie zawierają notatek ani komentarzy. Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notescommentslayoutingoptions/) do metody [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-), aby kontrolować, gdzie mają się pojawiać notatki i komentarze.

Poniższy przykład umieszcza skrócone notatki pod slajdem oraz komentarze po jego prawej stronie:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Podczas konwersji slajdu na obraz nie przekazuj [BottomFull](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notespositions/) do metody [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Notatki mogą zawierać więcej tekstu niż pozwala na to stały rozmiar obrazu. Użyj zamiast tego [BottomTruncated](https://reference.aspose.com/slides/pl/java/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Konwersja slajdów do obrazów przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/) pozwala kontrolować rozmiar, rozdzielczość i inne właściwości renderowanego obrazu TIFF.

Poniższy przykład renderuje pierwszy slajd jako obraz TIFF o wymiarach 2160 × 2880 przy 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Obsługa formatu TIFF nie jest gwarantowana w wersjach Java wcześniejszych niż JDK 9.
{{% /alert %}}

## **Konwersja wszystkich slajdów do obrazów**

Iteruj przez kolekcję slajdów, aby przekonwertować całą prezentację na serię obrazów. Ukryte slajdy są uwzględniane, o ile nie zostaną wyraźnie pominięte.

Poniższy przykład renderuje każdy slajd jako obraz JPEG z poziomymi i pionowymi współczynnikami skalowania równymi 2:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Tworzenie wyjścia w formacie Enhanced Metafile**

Enhanced Metafile (EMF) jest przydatny, gdy grafika wektorowa musi być wymieniana z Microsoft Office lub innymi aplikacjami Windows obsługującymi pliki metafile Windows. W przeciwieństwie do obrazu rastrowego, EMF może zachować operacje rysunkowe wektorowe, które skalują się bez utraty ostrości. Jednak EMF jest przede wszystkim formatem kompatybilności dla aplikacji obsługujących metafile Windows, a nie uniwersalnym formatem wymiany. Dodatkowo, złożona zawartość slajdów, taka jak obrazy bitmapowe i niektóre efekty, może być przechowywana jako elementy rastrowe wewnątrz kontenera metafile wektorowego.

### **Eksport slajdu do EMF**

Metoda [ISlide.writeAsEmf](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) zapisuje [ISlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/) do docelowego strumienia w formacie EMF. Poniższy przykład ładuje prezentację, wybiera pierwszy slajd i zapisuje go do strumienia pliku EMF:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Wywołujący jest właścicielem strumienia przekazanego do [ISlide.writeAsEmf](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) i jest odpowiedzialny za jego zamknięcie, tak jak pokazano powyżej.

### **Konwersja obrazu SVG do EMF i dodanie go do prezentacji**

Użyj [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-), aby przekonwertować zawartość SVG na EMF. Uzyskane bajty mogą zostać dodane do prezentacji za pomocą [IImageCollection.addImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) i umieszczone na slajdzie przy pomocy [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Poniższy przykład tworzy [SvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/svgimage/) z kodu SVG, konwertuje go na EMF w pamięci, wstawia metafile na pierwszy slajd i zapisuje prezentację:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) nie przejmuje własności docelowego strumienia. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) przechowuje wszystkie wygenerowane dane w pamięci, więc przed wywołaniem `toByteArray` nie jest wymagane resetowanie pozycji. Zwrócona tablica bajtów pozostaje ważna po zamknięciu strumienia.

Generowanie EMF jest dostępne na systemach operacyjnych obsługiwanych przez wybraną konfigurację Aspose.Slides for Java i JDK, jednak renderowanie może się różnić w zależności od platformy, gdy czcionki lub zależności graficzne są niedostępne. Zainstaluj czcionki używane w źródłowej zawartości lub skonfiguruj odpowiednie zamienniki, postępuj zgodnie z [wymaganiami platformy](/slides/pl/java/system-requirements/) dla Aspose.Slides for Java i zweryfikuj wynik w docelowej aplikacji obsługującej EMF. Aplikacje na Linux i macOS często mają ograniczoną lub niespójną obsługę wyświetlania i edycji metafile Windows.

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="info" %}}
Aby prawidłowo renderować kolorowe emoji podczas konwertowania slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest nieobecna, emoji mogą pojawiać się w odcieniach szarości w obrazach wyjściowych.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie. Metoda [ISlide.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islide/#getImage--) renderuje statyczny obraz slajdu i nie eksportuje animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak. Ukryte slajdy mogą być renderowane jak zwykłe slajdy. Uwzględnij je w pętli przetwarzania, jak pokazano w powyższym przykładzie.

**Czy cienie i inne efekty są zachowywane w obrazach slajdów?**

Tak. Aspose.Slides renderuje cienie, przezroczystość i inne obsługiwane efekty graficzne w obrazach slajdów.