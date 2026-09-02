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
- slajd do EMF
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
description: "Konwertuj slajdy z prezentacji PPT, PPTX i ODP na PNG, JPEG, GIF, TIFF, EMF i inne formaty obrazu w systemie Android przy użyciu Aspose.Slides."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java może renderować pojedyncze slajdy z prezentacji PowerPoint i OpenDocument jako obrazy w formatach PNG, JPEG, GIF, TIFF i innych.

Aby przekonwertować slajd na obraz, wykonaj następujące kroki:

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Wybierz slajd, który chcesz wyrenderować.
3. W razie potrzeby skonfiguruj renderowanie przy użyciu klasy [RenderingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/renderingoptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/).
4. Wywołaj metodę [ISlide.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage--). Zwraca ona obiekt [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/).
5. Wywołaj metodę [IImage.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) i określ format wyjściowy przy pomocy wartości [ImageFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imageformat/).

## **Konwersja slajdu na obraz PNG**

Najprostsza konwersja używa domyślnych ustawień renderowania. Uzyskany obiekt [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) może być przetwarzany w pamięci lub zapisywany do pliku.

Poniższy przykład w Javie renderuje pierwszy slajd i zapisuje go jako obraz PNG:

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

## **Konwersja slajdów na obrazy o niestandardowych rozmiarach**

Użyj przeciążenia [ISlide.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-), które przyjmuje wartość [Size](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides.android/size/), aby wyrenderować slajd o dokładnych wymiarach w pikselach.

Poniższy przykład tworzy obraz JPEG o wymiarach 1820 × 1040:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

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

## **Konwersja slajdów z notatkami i komentarzami na obrazy**

Domyślnie obrazy slajdów nie zawierają notatek ani komentarzy. Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notescommentslayoutingoptions/) do metody [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-), aby kontrolować, gdzie notatki i komentarze mają się pojawiać.

Poniższy przykład umieszcza przycięte notatki pod slajdem, a komentarze po jego prawej stronie:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

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
Podczas konwersji slajdu na obraz nie przekazuj [BottomFull](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notespositions/) do metody [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Notatki mogą zawierać więcej tekstu niż może pomieścić stały rozmiar obrazu. Użyj zamiast tego [BottomTruncated](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Konwersja slajdów na obrazy przy użyciu opcji TIFF**

Klasa [TiffOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/) umożliwia kontrolowanie rozmiaru, rozdzielczości i innych właściwości renderowanego obrazu TIFF.

Poniższy przykład renderuje pierwszy slajd jako obraz TIFF o wymiarach 2160 × 2880 przy 300 DPI:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

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

## **Konwersja wszystkich slajdów na obrazy**

Iteruj przez kolekcję slajdów, aby przekonwertować całą prezentację na serię obrazów. Ukryte slajdy są uwzględniane, chyba że jawnie je pomijasz.

Poniższy przykład renderuje każdy slajd jako obraz JPEG z poziomym i pionowym współczynnikiem skalowania równym 2:

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

Enhanced Metafile (EMF) jest przydatny, gdy grafika wektorowa musi być wymieniana z Microsoft Office lub innymi aplikacjami Windows obsługującymi metafile Windows. W przeciwieństwie do obrazu rastrowego, EMF może zachować operacje rysunkowe wektorowe, które skalują się bez utraty ostrości. Jednak EMF jest przede wszystkim formatem kompatybilności dla aplikacji obsługujących metafile Windows, a nie uniwersalnym formatem wymiany. Dodatkowo, złożona zawartość slajdu, taka jak obrazy bitmapowe i niektóre efekty, może być przechowywana jako elementy rastrowe wewnątrz wektorowego kontenera metafile.

### **Eksport slajdu do EMF**

Metoda [ISlide.writeAsEmf](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) zapisuje obiekt [ISlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/) do docelowego strumienia w formacie EMF. Poniższy przykład ładuje prezentację, wybiera pierwszy slajd i zapisuje go do strumienia pliku EMF:

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

Wywołujący jest właścicielem strumienia przekazanego do [ISlide.writeAsEmf](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) i jest odpowiedzialny za jego zamknięcie, jak pokazano powyżej.

### **Konwersja obrazu SVG do EMF i dodanie go do prezentacji**

Użyj [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-), aby przekonwertować zawartość SVG na EMF. Otrzymane bajty można dodać do prezentacji za pomocą [IImageCollection.addImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) i umieścić na slajdzie przy pomocy [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Poniższy przykład tworzy [SvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgimage/) z kodu SVG, konwertuje go na EMF w pamięci, wstawia metafile na pierwszy slajd i zapisuje prezentację:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) nie przejmuje własności docelowego strumienia. [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) przechowuje wszystkie wygenerowane dane w pamięci, więc przed wywołaniem `toByteArray` nie jest wymagane resetowanie pozycji. Zwrócona tablica bajtów pozostaje ważna po zamknięciu strumienia.

Generowanie EMF jest dostępne na obsługiwanych wersjach Androida i konfiguracjach urządzeń, ale renderowanie może się różnić, gdy brak jest czcionek lub zależności graficznych. Zainstaluj czcionki używane w źródłowej zawartości lub skonfiguruj odpowiednie zamienniki, postępuj zgodnie z [przewodnikiem instalacji](/slides/pl/androidjava/install-aspose-slides-for-android-via-java/) dla Aspose.Slides for Android via Java i zweryfikuj wynik w docelowej aplikacji odczytującej EMF. Aplikacje na platformach nie‑Windows często mają ograniczone lub niejednolite wsparcie dla wyświetlania i edycji metafile Windows.

## **Renderowanie kolorowych emoji**

{{% alert title="Note" color="info" %}}
Aby poprawnie renderować kolorowe emoji podczas konwersji slajdów prezentacji na obrazy, czcionki emoji użyte w prezentacji muszą być zainstalowane i dostępne w systemie wykonującym konwersję. Na przykład, jeśli prezentacja używa **Segoe UI Emoji** i ta czcionka jest nieobecna, emoji mogą pojawiać się w monochromatycznej wersji w obrazach wyjściowych.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje renderowanie slajdów z animacjami?**

Nie. Metoda [ISlide.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage--) renderuje statyczny obraz slajdu i nie eksportuje animacji.

**Czy ukryte slajdy mogą być eksportowane jako obrazy?**

Tak. Ukryte slajdy mogą być renderowane tak jak zwykłe slajdy. Uwzględnij je w pętli przetwarzania, jak pokazano w powyższym przykładzie.

**Czy cienie i inne efekty są zachowywane na obrazach slajdów?**

Tak. Aspose.Slides renderuje cienie, przezroczystość i inne obsługiwane efekty graficzne na obrazach slajdów.