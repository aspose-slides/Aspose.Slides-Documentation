---
title: Konvertera presentationsbilder till bilder i Java
linktitle: Bild till bild
type: docs
weight: 35
url: /sv/java/convert-slide/
keywords:
- konvertera bild
- exportera bild
- bild till bild
- spara bild som bild
- bild till EMF
- bild till PNG
- bild till JPEG
- bild till bitmap
- bild till TIFF
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Konvertera bilder från PPT-, PPTX- och ODP-presentationer till PNG, JPEG, GIF, TIFF, EMF och andra bildformat i Java med Aspose.Slides."
---
## **Introduktion**

Aspose.Slides for Java kan rendera enskilda bilder från PowerPoint- och OpenDocument-presentationer som PNG, JPEG, GIF, TIFF och andra bildformat.

För att konvertera en bild till en bildfil, följ dessa steg:

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Välj den bild du vill rendera.
3. Om nödvändigt, konfigurera rendering med klassen [RenderingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/renderingoptions/) eller [TiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tiffoptions/).
4. Anropa metoden [ISlide.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage--). Den returnerar ett [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/)‑objekt.
5. Anropa metoden [IImage.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/#save-java.lang.String-int-) och ange utdataformatet med ett [ImageFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imageformat/)-värde.

## **Konvertera en bild till en PNG‑bild**

Den enklaste konverteringen använder standardinställningarna för rendering. Det resulterande [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/)‑objektet kan bearbetas i minnet eller sparas till en fil.

Följande Java‑exempel renderar den första bilden och sparar den som en PNG‑bild:

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

## **Konvertera bilder till bilder med anpassade storlekar**

Använd överlagringen [ISlide.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) som accepterar ett [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)‑värde för att rendera en bild med exakta pixelmått.

Följande exempel skapar en JPEG‑bild på 1820 × 1040 px:

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

## **Konvertera bilder med anteckningar och kommentarer till bilder**

Som standard innehåller bildfilerna inga anteckningar eller kommentarer. Skicka ett [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notescommentslayoutingoptions/)‑objekt till metoden [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) för att styra var anteckningar och kommentarer visas.

Följande exempel placerar avkortade anteckningar under bilden och kommentarer till höger om den:

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
För konvertering av bild till bild ska du inte skicka [BottomFull](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notespositions/) till metoden [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Anteckningar kan innehålla mer text än den fasta bildstorleken kan rymma. Använd istället [BottomTruncated](https://reference.aspose.com/slides/sv/java/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Konvertera bilder till bilder med TIFF‑alternativ**

Klassen [TiffOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/tiffoptions/) låter dig styra storlek, upplösning och andra egenskaper för den renderade TIFF‑bilden.

Följande exempel renderar den första bilden som en 2160 × 2880‑TIFF‑bild med 300 DPI:

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
TIFF‑stöd garanteras inte i Java‑versioner äldre än JDK 9.
{{% /alert %}}

## **Konvertera alla bilder till bilder**

Iterera genom bildsamlingen för att konvertera hela presentationen till en serie bilder. Dolda bilder inkluderas om du inte explicit hoppar över dem.

Följande exempel renderar varje bild som en JPEG‑bild med horisontella och vertikala skalningsfaktorer på 2:

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

## **Skapa Enhanced Metafile‑utdata**

Enhanced Metafile (EMF) är användbart när vektorgrafik måste utbytas med Microsoft Office eller andra Windows‑program som stöder Windows‑metafiler. Till skillnad från en pixelbaserad bild kan ett EMF bevara vektorritningsoperationer som skalas utan samma förlust av skärpa. EMF är dock främst ett kompatibilitetsformat för program med stöd för Windows‑metafiler, inte ett universellt utbytesformat. Dessutom kan komplext bildinnehåll, såsom bitmapbilder och vissa effekter, lagras som rasteriserade element i den vektor‑metafilbehållaren.

### **Exportera en bild till EMF**

Metoden [ISlide.writeAsEmf](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) skriver en [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/) till ett mål‑ström i EMF‑format. Följande exempel läser in en presentation, väljer den första bilden och skriver den till ett EMF‑filström:

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

Anroparen äger strömmen som skickas till [ISlide.writeAsEmf](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) och ansvarar för att stänga den, som visas ovan.

### **Konvertera en SVG‑bild till EMF och lägg till den i en presentation**

Använd [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) för att konvertera SVG‑innehåll till EMF. De resulterande byten kan läggas till presentationen via [IImageCollection.addImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) och placeras på en bild med [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Följande exempel skapar en [SvgImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/svgimage/) från SVG‑markup, konverterar den till ett EMF‑objekt i minnet, infogar metafilen på den första bilden och sparar presentationen:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) tar inte äganderätt till destinationsströmmen. En [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) lagrar all genererad data i minnet, så ingen positionsåterställning krävs innan `toByteArray` anropas. Den returnerade byte‑arrayen förblir giltig efter att strömmen har stängts.

EMF‑generering är tillgänglig på de operativsystem som stöds av den valda Aspose.Slides for Java‑ och JDK‑konfigurationen, men renderingen kan skilja sig mellan plattformar när teckensnitt eller grafikberoenden saknas. Installera de teckensnitt som används av källinnehållet eller konfigurera lämpliga ersättningar, följ [platform requirements](/slides/sv/java/system-requirements/) för Aspose.Slides for Java, och validera resultatet i den mål‑EMF‑konsumerande applikationen. Linux‑ och macOS‑program har ofta begränsat eller inkonsekvent stöd för att visa och redigera Windows‑metafiler.

## **Färg‑emoji‑rendering**

{{% alert title="Note" color="info" %}}
För att rendera färg‑emoji korrekt vid konvertering av presentationens bilder till bildfiler måste de emoji‑teckensnitt som används i presentationen vara installerade och tillgängliga på systemet som utför konverteringen. Till exempel, om presentationen använder **Segoe UI Emoji** och detta teckensnitt saknas, kan emoji visas i monokrom i utdatan.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides rendering av bilder med animationer?**

Nej. Metoden [ISlide.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getImage--) renderar en statisk bild av bilden och exporterar inte animationer.

**Kan dolda bilder exporteras som bilder?**

Ja. Dolda bilder kan renderas som vanliga bilder. Inkludera dem i bearbetningsloopen, som i exemplet ovan.

**Bevaras skuggor och andra effekter i bildfiler?**

Ja. Aspose.Slides renderar skuggor, transparens och andra stödda grafiska effekter i bildfiler.