---
title: Presentatiedia's converteren naar afbeeldingen op Android
linktitle: Dia naar afbeelding
type: docs
weight: 35
url: /nl/androidjava/convert-slide/
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
- Android
- Java
- Aspose.Slides
description: "Converteer dia's van PPT-, PPTX- en ODP‑presentaties naar PNG, JPEG, GIF, TIFF, EMF en andere afbeeldingsformaten op Android met Aspose.Slides."
---
## **Inleiding**

Aspose.Slides for Android via Java kan individuele dia's uit PowerPoint‑ en OpenDocument‑presentaties renderen als PNG, JPEG, GIF, TIFF en andere afbeeldingsformaten.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) class.
2. Selecteer de dia die u wilt renderen.
3. Indien nodig, configureer het renderen met de [RenderingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/renderingoptions/) of [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/) class.
4. Roep de [ISlide.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#getImage--) methode aan. Deze retourneert een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) object.
5. Roep de [IImage.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) methode aan en geef het uitvoerformaat op met een [ImageFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imageformat/) waarde.

## **Een dia converteren naar een PNG‑afbeelding**

De eenvoudigste conversie maakt gebruik van de standaard renderinstellingen. Het resulterende [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) object kan in het geheugen verwerkt of naar een bestand opgeslagen worden.

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

## **Dia's converteren naar afbeeldingen met aangepaste afmetingen**

Gebruik de [ISlide.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) overload die een [Size](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides.android/size/) waarde accepteert om een dia te renderen met exacte pixelafmetingen.

Het volgende voorbeeld maakt een JPEG‑afbeelding van 1820 × 1040:

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

## **Dia's met notities en opmerkingen converteren naar afbeeldingen**

Standaard bevatten dia‑afbeeldingen geen notities of opmerkingen. Geef een [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notescommentslayoutingoptions/) object door aan de [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) methode om te bepalen waar notities en opmerkingen verschijnen.

Het volgende voorbeeld plaatst afgekorte notities onder de dia en opmerkingen rechts ervan:

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
Voor dia‑naar‑afbeelding conversie, geef niet [BottomFull](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notespositions/) door aan de [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) methode. Notities kunnen meer tekst bevatten dan de vaste afbeeldingsgrootte kan huisvesten. Gebruik in plaats daarvan [BottomTruncated](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/notespositions/).
{{% /alert %}}

## **Dia's converteren naar afbeeldingen met TIFF‑opties**

De [TiffOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/tiffoptions/) class stelt u in staat de grootte, resolutie en andere eigenschappen van de gerenderde TIFF‑afbeelding te regelen.

Het volgende voorbeeld rendert de eerste dia als een 2160 × 2880 TIFF‑afbeelding met 300 DPI:

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

## **Alle dia's converteren naar afbeeldingen**

Itereer door de verzameling van dia's om de volledige presentatie om te zetten in een reeks afbeeldingen. Verborgen dia's worden mee genomen tenzij u ze expliciet overslaat.

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

Enhanced Metafile (EMF) is handig wanneer vector‑gebaseerde graphics moeten worden uitgewisseld met Microsoft Office of andere Windows‑applicaties die Windows‑metabestanden ondersteunen. In tegenstelling tot een pixel‑gebaseerde afbeelding kan een EMF vector‑tekenbewerkingen behouden die schalen zonder hetzelfde verlies van scherpte. EMF is echter vooral een compatibiliteitsformaat voor applicaties met Windows‑metabestandondersteuning, geen universeel uitwisselingsformaat. Bovendien kan complexe dia‑inhoud, zoals bitmap‑afbeeldingen en sommige effecten, worden opgeslagen als gerasterde elementen binnen de vector‑metabestandcontainer.

### **Een dia exporteren naar EMF**

De [ISlide.writeAsEmf](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) methode schrijft een [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) naar een doel‑stream in EMF‑formaat. Het volgende voorbeeld laadt een presentatie, selecteert de eerste dia en schrijft deze naar een EMF‑bestand‑stream:

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

De aanroeper bezit de stream die aan [ISlide.writeAsEmf](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) wordt doorgegeven en is verantwoordelijk voor het sluiten ervan, zoals hierboven getoond.

### **Een SVG‑afbeelding naar EMF converteren en toevoegen aan een presentatie**

Gebruik [ISvgImage.writeAsEmf](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) om SVG‑inhoud te converteren naar EMF. De resulterende bytes kunnen aan de presentatie toegevoegd worden via [IImageCollection.addImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) en op een dia geplaatst worden met [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-).

Het volgende voorbeeld maakt een [SvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgimage/) van SVG‑markup, converteert het naar een EMF in het geheugen, voegt het metabestand toe op de eerste dia en slaat de presentatie op:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) neemt geen eigendom van de doel‑stream. Een [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) slaat alle gegenereerde gegevens in het geheugen op, dus een reset van de positie is niet nodig vóór het aanroepen van `toByteArray`. Het teruggegeven byte‑array blijft geldig nadat de stream is gesloten.

EMF‑generatie is beschikbaar op ondersteunde Android‑versies en apparaat‑configuraties, maar de weergave kan variëren wanneer lettertypen of grafische afhankelijkheden niet beschikbaar zijn. Installeer de lettertypen die door de broninhoud worden gebruikt of configureer passende vervangingen, volg de [installatie‑gids](/slides/nl/androidjava/install-aspose-slides-for-android-via-java/) voor Aspose.Slides for Android via Java, en valideer het resultaat in de doel‑EMF‑consumerende applicatie. Applicaties op niet‑Windows‑platformen hebben vaak beperkte of inconsistente ondersteuning voor het weergeven en bewerken van Windows‑metabestanden.

## **Kleurrijke Emoji‑rendering**

{{% alert title="Note" color="info" %}}
Om kleur‑emoji’s correct weer te geven bij het converteren van presentatiedia’s naar afbeeldingen, moeten de emoji‑lettertypen die in de presentatie worden gebruikt, geïnstalleerd en beschikbaar zijn op het systeem dat de conversie uitvoert. Bijvoorbeeld, als de presentatie **Segoe UI Emoji** gebruikt en dit lettertype ontbreekt, kunnen emoji’s in monochroom verschijnen in de uitvoer‑afbeeldingen.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides het renderen van dia's met animaties?**

Nee. De [ISlide.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#getImage--) methode rendert een statische afbeelding van de dia en exporteert geen animaties.

**Kunnen verborgen dia's geëxporteerd worden als afbeeldingen?**

Ja. Verborgen dia's kunnen gerenderd worden zoals normale dia's. Neem ze op in de verwerkingslus, zoals getoond in het voorbeeld hierboven.

**Worden schaduwen en andere effecten bewaard in dia‑afbeeldingen?**

Ja. Aspose.Slides rendert schaduwen, transparantie en andere ondersteunde grafische effecten in dia‑afbeeldingen.