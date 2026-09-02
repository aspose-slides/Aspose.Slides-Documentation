---
title: Optimaliseer het beheer van afbeeldingen in presentaties op Android
linktitle: Beheer afbeeldingen
type: docs
weight: 10
url: /nl/androidjava/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- afbeelding vervangen
- afbeeldingscollectie
- afbeeldingskader
- gekoppelde afbeelding
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- SVG naar vormen
- externe SVG-bronnen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u raster- en SVG-afbeeldingen kunt toevoegen, hergebruiken, linken, vervangen en beheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java."
---
## **Inleiding**

Aspose.Slides for Android via Java biedt verschillende manieren om met afbeeldingen te werken, en elke manier dient een ander doel. Je kunt een afbeelding opslaan in een presentatie, weergeven in een afbeeldingskader, gebruiken als dia‑achtergrond, linken naar een externe afbeelding, een gedeelde afbeeldingsbron vervangen, of SVG‑inhoud omzetten naar bewerkbare vormen.

Dit artikel richt zich op afbeeldingsbronnen en hoe ze gebruikt worden in een presentatie. Voor bijsnijden, transparantie, effecten, uitrekken en andere opmaak die op een individueel afbeeldingskader wordt toegepast, zie [Picture Frame](/slides/nl/androidjava/picture-frame/).

## **Begrijp het afbeeldingsmodel**

De volgende API‑concepten staan nauw verwant maar zijn niet uitwisselbaar:

- De [presentation image collection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimagecollection/) slaat afbeeldingsbronnen op die door de presentatie worden gebruikt. Gebruik [ImageCollection.addImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imagecollection/) om afbeeldingsdata toe te voegen en een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) bron te verkrijgen.
- Een [picture frame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipictureframe/) is een vorm die een afbeelding weergeeft op een dia, lay-out of master. Gebruik [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/) om een afbeeldingsbron op een dia te plaatsen.
- Een dia‑achtergrond gebruikt een afbeelding als onderdeel van de dia‑vulling in plaats van als vorm. Het gedraagt zich daarom niet als een afbeeldingskader.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) vervangt een afbeeldingsbron. Als verschillende presentatie‑elementen die bron gebruiken, gebruiken ze allemaal de vervanging.
- Het converteren van een SVG naar vormen maakt bewerkbare dia‑vormen. Na conversie wordt de inhoud niet langer beheerd als één afbeeldingsbron.

Een typisch werkproces is dus: afbeeldingsdata toevoegen aan de image collection, een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) ontvangen, en die bron vervolgens gebruiken in één of meer afbeeldingskaders of vullingen.

## **Een embedded afbeelding toevoegen**

Om een lokale afbeelding in te voegen, laad je het bestand, voeg je het toe aan de image collection en maak je een picture frame dat de geretourneerde `IPPImage` gebruikt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De op deze manier toegevoegde afbeelding wordt ingebed in de presentatie, zodat het uiteindelijke bestand niet afhankelijk is van de beschikbaarheid van het originele afbeeldingsbestand.

### **Een afbeelding van het web toevoegen**

Wanneer een afbeelding beschikbaar is via HTTP of HTTPS, download je de bytes, voeg je ze toe aan de presentation image collection, en gebruik je de geretourneerde afbeeldingsbron op dezelfde manier als een lokale afbeelding.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In langlopende toepassingen hergebruik je een HTTP‑client of een verbinding‑beheerstrategie die passend is voor de applicatie in plaats van telkens onnodig netwerk‑infrastructuur te creëren. Valideer ook externe URL’s, response‑groottes en content‑types wanneer de bron niet vertrouwd is.

## **Afbeeldingen hergebruiken over dia’s heen**

Als dezelfde afbeelding meer dan eens nodig is, voeg je deze één keer toe aan de presentatie en hergebruik je de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) bij het maken van extra picture frames. Dit voorkomt herhaaldelijk laden van dezelfde brondata en maakt de relatie tussen de gedeelde afbeeldingsbron en het gebruik expliciet.

Voor grafische elementen die automatisch op veel dia’s moeten verschijnen, zoals een bedrijfslogo, overweeg dan om het picture frame op een [slide master](/slides/nl/androidjava/slide-master/) of lay-out te plaatsen in plaats van een gelijkwaardige vorm aan elke dia toe te voegen.

## **Een afbeelding gebruiken als dia‑achtergrond**

Een achtergrondafbeelding wordt toegewezen aan de dia‑vulling; hij wordt niet toegevoegd als een picture‑frame vorm. Dit is handig wanneer de afbeelding de hele dia‑achtergrond moet bedekken en niet moet worden gemanipuleerd als een normaal dia‑object.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor extra achtergrondopties, inclusief master‑ en lay‑outachtergronden, zie [Presentation Background](/slides/nl/androidjava/presentation-background/).

## **Embedded afbeeldingen en gekoppelde afbeeldingen**

Embedded en linked afbeeldingen hebben verschillende draagbaarheids‑ en bestandsgrootte‑afwegingen:

- **Embedded afbeelding:** de afbeeldingsdata wordt opgeslagen binnen de presentatie. De presentatie is zelfstandig, maar de bestandsgrootte omvat de afbeeldingsdata.
- **Linked afbeelding:** de presentatie slaat een pad of URL op naar een externe afbeelding. Dit kan de presentatie‑grootte verkleinen, maar de externe bron moet beschikbaar blijven wanneer de presentatie wordt geopend of gerenderd.

Een gekoppelde afbeelding kan worden aangemaakt door het externe pad of de URL toe te wijzen via [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidespicture/) in plaats van de afbeeldingsdata te embedden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gebruik linked afbeeldingen alleen wanneer de implementatie‑omgeving de externe bron betrouwbaar kan benaderen. Voor presentaties die offline moeten werken of tussen systemen verplaatst worden, zijn embedded afbeeldingen doorgaans veiliger.

## **Werken met SVG‑afbeeldingen**

SVG is een vectorformaat, dus het kan nuttig zijn voor iconen, diagrammen en andere grafische elementen die zonder verlies in detail geschaald moeten kunnen worden. Aspose.Slides ondersteunt SVG zowel als afbeeldingsbron als als bron voor bewerkbare dia‑vormen.

### **Een SVG als afbeelding toevoegen**

Maak een [SvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgimage/), voeg deze toe aan de image collection, en plaats de resulterende afbeeldingsbron in een picture frame.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG‑bestanden met externe bronnen**

Een SVG kan verwijzen naar externe afbeeldingen, stylesheets of fonts. Voor deze gevallen biedt [SvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgimage/) constructors die een [IExternalResourceResolver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iexternalresourceresolver/) en een basis‑URI accepteren. De resolver kan een relatieve URI omzetten naar een toegestane absolute URI en een stream retourneren voor de gevraagde bron.

De resolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt, maar herschrijft de SVG niet naar een zelfstandige document. Als de SVG draagbaar moet blijven, embed dan de vereiste bronnen in de SVG zelf, bijvoorbeeld door `data:`‑URI’s te gebruiken voor gekoppelde afbeeldingen.

Wanneer SVG‑bestanden afkomstig zijn van onbetrouwbare bronnen, beperk dan de schema’s, bestandslocaties en hosts die de resolver mag benaderen. Netwerk‑resolvers moeten ook time‑outs, limieten voor respons‑grootte en inhoudsvalidatie toepassen.

### **SVG naar bewerkbare vormen converteren**

Aspose.Slides kan een SVG omzetten naar een groep bewerkbare dia‑vormen, vergelijkbaar met de overeenkomstige PowerPoint‑opdracht.

![PowerPoint Popup Menu](img_01_01.png)

Gebruik de overload van [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/) die een [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/) accepteert om de conversie uit te voeren.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gebruik SVG‑naar‑vormen conversie wanneer individuele vector‑elementen bewerkt moeten worden als PowerPoint‑vormen. Als de SVG alleen weergegeven moet worden, is het eenvoudiger om hem als afbeelding te bewaren en vermijd je het creëren van veel losse vormen.

## **Een bestaande afbeeldingsbron vervangen**

Gebruik [IPPImage.replaceImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) wanneer je een bestaande afbeeldingsbron wilt vervangen. Dit is vooral nuttig voor gedeelde grafische elementen zoals logo’s.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als meerdere picture frames, achtergronden, masters of lay-outs dezelfde afbeeldingsbron gebruiken, werkt het vervangen van die bron al deze gebruiken bij. Als slechts één picture frame moet veranderen, wijs dan een andere afbeelding toe aan dat frame in plaats van de gedeelde bron te vervangen.

`replaceImage` biedt ook overloads die een byte‑array of een andere [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/) accepteren.

## **Praktische richtlijnen voor afbeeldingsbeheer**

### **Presentatie‑grootte beheersen**

Grote rasterafbeeldingen kunnen een presentatie onnodig groot maken. Gebruik bronafbeeldingen met afmetingen die passen bij de beoogde weergavegrootte, hergebruik gedeelde afbeeldingsbronnen waar mogelijk, en vermijd het embedden van meerdere kopieën van dezelfde afbeelding met volledige resolutie.

Voor rasterafbeeldingen die al in picture frames staan, kan [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipicturefillformat/) de afbeeldingsdata verkleinen volgens de gekozen resolutie en bijsnijdinstellingen. Dit is picture‑frame verwerking, niet image‑collection beheer, dus zie [Picture Frame](/slides/nl/androidjava/picture-frame/) voor gerelateerde opmaakhandelingen.

### **Kiezen tussen embedded en linked content**

Embedding maakt de presentatie draagbaar omdat alle benodigde afbeeldingsdata met het bestand meereist. Linking kan de bestandsgrootte verkleinen, maar introduceert een externe afhankelijkheid. Gebruik links alleen wanneer die afhankelijkheid acceptabel en stabiel is.

### **Gedeelde branding hergebruiken**

Voor terugkerende logo’s, watermerken of decoratieve grafieken, gebruik één afbeeldingsbron en hergebruik die. Als de grafiek deel uitmaakt van het presentatie‑ontwerp in plaats van de dia‑inhoud, plaats deze dan op een master of lay-out zodat ze door de juiste dia’s wordt geërfd.

### **SVG‑bronnen draagbaar houden**

Een zelfstandige SVG is makkelijker te verplaatsen en consistent te renderen dan een SVG die afhankelijk is van externe bestanden of netwerkbronnen. Waar mogelijk, embed de benodigde bronnen vóór het importeren van de SVG. Converteer SVG naar vormen alleen wanneer de afzonderlijke vector‑elementen bewerkt moeten worden.

### **Gebruik de moderne cross‑platform Image‑API**

Voor nieuwe Android‑via‑Java code, gebruik de Aspose.Slides [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) en [Images](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/images/) API’s in plaats van de verouderde publieke API gebaseerd op `android.graphics.Bitmap`. Zie [Modern API](/slides/nl/androidjava/modern-api/) voor migratie‑advies.

WMF en EMF vereisen speciale aandacht. Wanneer deze formaten via een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/) worden doorgegeven, converteert [ImageCollection.addImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imagecollection/) het metafile naar een raster‑PNG‑representatie vóór invoeging. Als het behouden van de metafile‑data belangrijk is, gebruik dan een stream‑gebaseerde overload van [ImageCollection.addImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imagecollection/). Het genereren van EMF‑content vanuit spreadsheets of andere producten is een aparte integratieworkflow en valt buiten de scope van dit artikel.

## **FAQ**

**Wat is het verschil tussen de image collection en een picture frame?**

De image collection slaat herbruikbare afbeeldingsbronnen op. Een picture frame is een dia‑vorm die een van die bronnen weergeeft en picture‑specifieke opmaak biedt zoals bijsnijden en effecten.

**Wat is de beste manier om hetzelfde logo overal te vervangen?**

Als het logo al gedeeld wordt als één afbeeldingsbron, vervang die bron met [IPPImage.replaceImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/). Voor presentatie‑brede branding kan het plaatsen van het logo op een master of lay-out ook de gedupliceerde dia‑inhoud verminderen.

**Waarom verdwijnt een linked afbeelding op een andere computer?**

Een gekoppelde afbeelding hangt af van het externe bestand of de URL. Als die bron niet bereikbaar is vanaf de andere computer, is de linked afbeelding niet beschikbaar. Embed de afbeelding wanneer de presentatie volledig zelfstandig moet zijn.

**Kan een ingevoegde SVG bewerkt worden als PowerPoint‑vormen?**

Ja. Converteer de SVG met [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/); de resulterende groep bevat bewerkbare dia‑vormen in plaats van één SVG‑afbeelding.

**Hoe houd ik presentaties met veel afbeeldingen kleiner?**

Hergebruik gedeelde afbeeldingsbronnen, vermijd onnodig grote rasterbronnen, comprimeer geschikte rasterafbeeldingen wanneer gepast, plaats terugkerende branding op masters of lay-outs, en gebruik linked afbeeldingen alleen wanneer een externe afhankelijkheid acceptabel is.