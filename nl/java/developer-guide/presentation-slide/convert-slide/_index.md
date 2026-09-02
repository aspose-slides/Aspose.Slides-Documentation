---
title: Dia's van een presentatie omzetten naar afbeeldingen in Java
linktitle: Dia naar afbeelding
type: docs
weight: 35
url: /nl/java/convert-slide/
keywords:
- dia converteren
- dia exporteren
- dia naar afbeelding
- dia opslaan als afbeelding
- dia naar EMF
- dia naar PNG
- dia naar JPEG
- dia naar bitmap
- dia naar TIFF
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Converteer dia's van PPT-, PPTX- en ODP-presentaties naar PNG, JPEG, GIF, TIFF, EMF en andere beeldformaten in Java met Aspose.Slides."
---
## **Inleiding**

Aspose.Slides for Java kan individuele dia's uit PowerPoint- en OpenDocument‑presentaties renderen als PNG, JPEG, GIF, TIFF en andere beeldformaten.

Om een dia naar een afbeelding om te zetten, volg deze stappen:

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Selecteer de dia die u wilt renderen.
3. Indien nodig, configureer de weergave met de [RenderingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/renderingoptions/)‑ of [TiffOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tiffoptions/)‑klasse.
4. Roep de methode [ISlide.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#getImage--) aan. Deze retourneert een [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/)‑object.
5. Roep de methode [IImage.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) aan en specificeer het uitvoerformaat met een [ImageFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imageformat/)‑waarde.

## **Een dia omzetten naar een PNG‑afbeelding**

De eenvoudigste conversie gebruikt de standaard renderinstellingen. Het resulterende [IImage]‑object kan in het geheugen worden verwerkt of naar een bestand worden opgeslagen.

Het volgende Java‑voorbeeld rendert de eerste dia en slaat deze op als een PNG‑afbeelding:

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

## **Dia's omzetten naar afbeeldingen met aangepaste afmetingen**

Gebruik de overload van [ISlide.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) die een [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html)‑waarde accepteert om een dia te renderen met exacte pixelafmetingen.

Het volgende voorbeeld maakt een JPEG‑afbeelding van 1820 × 1040:

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

## **Dia's met notities en opmerkingen omzetten naar afbeeldingen**

Standaard bevatten dia‑afbeeldingen geen notities of opmerkingen. Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notescommentslayoutingoptions/)‑object door aan de methode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) om te bepalen waar notities en opmerkingen worden weergegeven.

Het volgende voorbeeld plaatst ingekorte notities onder de dia en opmerkingen rechts ervan:

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

{{% alert title="Waarschuwing" color="warning" %}}
Voor dia‑naar‑afbeeldingconversie mag u niet [BottomFull](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notespositions/) doorgeven aan de methode [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-). Notities kunnen meer tekst bevatten dan de vaste afbeeldingsgrootte kan bevatten. Gebruik in plaats daarvan [BottomTruncated](https://reference.aspose.com/slides/nl/java/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Dia's omzetten naar afbeeldingen met TIFF‑opties**

De klasse [TiffOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/tiffoptions/) stelt u in staat de grootte, resolutie en andere eigenschappen van de gerenderde TIFF‑afbeelding te regelen.

Het volgende voorbeeld rendert de eerste dia als een TIFF‑afbeelding van 2160 × 2880 bij 300 DPI:

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

{{% alert title="Waarschuwing" color="warning" %}}
TIFF‑ondersteuning is niet gegarandeerd in Java‑versies ouder dan JDK 9.
{{% /alert %}}

## **Alle dia's omzetten naar afbeeldingen**

Itereer door de dia‑collectie om de volledige presentatie om te zetten in een reeks afbeeldingen. Verborgen dia's worden opgenomen, tenzij u ze expliciet overslaat.

Het volgende voorbeeld rendert elke dia als een JPEG‑afbeelding met horizontale en verticale schaalfactoren van 2:

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

## **Enhanced Metafile‑output maken**

Enhanced Metafile (EMF) is handig wanneer vector‑gebaseerde grafische elementen uitgewisseld moeten worden met Microsoft Office of andere Windows‑toepassingen die Windows‑metabestanden ondersteunen. In tegenstelling tot een pixel‑gebaseerde afbeelding kan een EMF vectorteken‑operaties behouden die schalen zonder dezelfde scherpteverlies. EMF is echter voornamelijk een compatibiliteitsformaat voor toepassingen met Windows‑metabestand‑ondersteuning, geen universeel uitwisselingsformaat. Bovendien kan complexe dia‑inhoud, zoals bitmap‑afbeeldingen en sommige effecten, opgeslagen worden als gerasterde elementen binnen de vector‑metabestand‑container.

### **Een dia exporteren naar EMF**

De methode [ISlide.writeAsEmf](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) schrijft een [ISlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/) naar een doel‑stream in EMF‑formaat. Het volgende voorbeeld laadt een presentatie, selecteert de eerste dia en schrijft deze naar een EMF‑bestand‑stream:

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

De aanroeper bezit de stream die aan [ISlide.writeAsEmf](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) wordt doorgegeven en is verantwoordelijk voor het sluiten ervan, zoals hierboven getoond.

### **Een SVG‑afbeelding omzetten naar EMF en toevoegen aan een presentatie**

Gebruik [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) om SVG‑inhoud om te zetten naar EMF. De resulterende bytes kunnen aan de presentatie worden toegevoegd via [IImageCollection.addImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) en op een dia geplaatst worden met [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Het volgende voorbeeld maakt een [SvgImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgimage/) van SVG‑markup, zet deze om naar een EMF in het geheugen, plaatst het metafile op de eerste dia en slaat de presentatie op:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) neemt geen eigendom van de doeldestination‑stream. Een [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) slaat alle gegenereerde gegevens in het geheugen op, dus een reset van de positie is niet nodig vóór het aanroepen van `toByteArray`. De geretourneerde byte‑array blijft geldig nadat de stream is gesloten.

EMF‑generatie is beschikbaar op de besturingssystemen die worden ondersteund door de geselecteerde Aspose.Slides for Java‑ en JDK‑configuratie, maar rendering kan verschillen tussen platformen wanneer lettertypen of grafische afhankelijkheden ontbreken. Installeer de lettertypen die door de broninhoud worden gebruikt of configureer geschikte vervangingen, volg de [platformvereisten](/slides/nl/java/system-requirements/) voor Aspose.Slides for Java, en valideer het resultaat in de doel‑EMF‑bruikende toepassing. Linux‑ en macOS‑toepassingen hebben vaak beperkte of inconsistente ondersteuning voor het weergeven en bewerken van Windows‑metabestanden.

## **Kleur‑emoji‑rendering**

{{% alert title="Opmerking" color="info" %}}
Om kleur‑emoji’s correct weer te geven bij het converteren van presentatiedia’s naar afbeeldingen, moeten de emoji‑lettertypen die in de presentatie worden gebruikt geïnstalleerd en beschikbaar zijn op het systeem dat de conversie uitvoert. Bijvoorbeeld, als de presentatie **Segoe UI Emoji** gebruikt en dit lettertype ontbreekt, kunnen emoji’s in monochroom verschijnen in de output‑afbeeldingen.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides het renderen van dia’s met animaties?**

Nee. De methode [ISlide.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#getImage--) rendert een statische afbeelding van de dia en exporteert geen animaties.

**Kunnen verborgen dia’s worden geëxporteerd als afbeeldingen?**

Ja. Verborgen dia’s kunnen worden gerenderd net als reguliere dia’s. Neem ze op in de verwerkingslus, zoals in het bovenstaande voorbeeld.

**Worden schaduwen en andere effecten behouden in dia‑afbeeldingen?**

Ja. Aspose.Slides rendert schaduwen, transparantie en andere ondersteunde grafische effecten in dia‑afbeeldingen.