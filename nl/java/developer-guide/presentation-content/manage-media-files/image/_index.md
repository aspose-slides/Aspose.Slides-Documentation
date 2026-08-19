---
title: Optimaliseer het beheer van afbeeldingen in presentaties met Java
linktitle: Afbeeldingen beheren
type: docs
weight: 10
url: /nl/java/image/
keywords:
- afbeelding toevoegen
- afbeelding invoegen
- afbeelding vervangen
- afbeeldingcollectie
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
- Java
- Aspose.Slides
description: "Leer hoe u raster- en SVG-afbeeldingen kunt toevoegen, hergebruiken, koppelen, vervangen en beheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Java."
---
## **Introductie**

Aspose.Slides for Java biedt verschillende manieren om met afbeeldingen te werken, en elke manier heeft een ander doel. U kunt een afbeelding opslaan in een presentatie, weergeven in een afbeeldingskader, gebruiken als een dia‑achtergrond, koppelen aan een externe afbeelding, een gedeelde afbeeldingsbron vervangen, of SVG‑inhoud omzetten naar bewerkbare vormen.

Dit artikel richt zich op afbeeldingsbronnen en hoe ze worden gebruikt in een presentatie. Voor bijsnijden, transparantie, effecten, uitrekken en andere opmaak die op een enkel afbeeldingskader wordt toegepast, zie [Picture Frame](/slides/nl/java/picture-frame/).

## **Begrijp het afbeeldingsmodel**

De volgende API‑concepten zijn nauw verwant maar niet uitwisselbaar:

- De [presentatie‑afbeeldingscollectie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimagecollection/) slaat afbeeldingsbronnen op die door de presentatie worden gebruikt. Gebruik [ImageCollection.addImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imagecollection/) om afbeeldingsgegevens toe te voegen en een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/)‑bron te verkrijgen.
- Een [picture frame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipictureframe/) is een vorm die een afbeelding weergeeft op een dia, lay-out of master. Gebruik [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/) om een afbeeldingsbron op een dia te plaatsen.
- Een dia‑achtergrond gebruikt een afbeelding als onderdeel van de dia‑vulling in plaats van als een vorm. Het gedraagt zich dus niet als een picture frame.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) vervangt een afbeeldingsbron. Als verschillende presentatie‑elementen die bron gebruiken, gebruiken ze allemaal de vervanging.
- Het omzetten van een SVG naar vormen maakt bewerkbare dia‑vormen. Na de conversie wordt de inhoud niet langer beheerd als één afbeeldingsbron.

Een typisch werkproces is daarom: voeg afbeeldingsgegevens toe aan de afbeeldingscollectie, ontvang een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/), en gebruik die bron vervolgens in één of meer picture frames of vullingen.

## **Een ingebedde afbeelding toevoegen**

Om een lokale afbeelding in te voegen, laad het bestand, voeg het toe aan de afbeeldingscollectie en maak een picture frame aan dat de geretourneerde `IPPImage` gebruikt.

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

De op deze manier toegevoegde afbeelding is ingebed in de presentatie, zodat het resulterende bestand niet afhankelijk is van de beschikbaarheid van het oorspronkelijke afbeeldingsbestand.

### **Een afbeelding van het web toevoegen**

Wanneer een afbeelding beschikbaar is via HTTP of HTTPS, download de bytes, voeg ze toe aan de presentatie‑afbeeldingscollectie en gebruik de geretourneerde afbeeldingsbron op dezelfde manier als een lokale afbeelding.

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

In langdurige toepassingen moet u een HTTP‑client of verbindings‑beheerstrategie hergebruiken die geschikt is voor de applicatie in plaats van herhaaldelijk onnodige netwerkinfrastructuur te creëren. Valideer ook externe URL‑s, responsgroottes en inhoudstypen wanneer de bron niet vertrouwd is.

## **Afbeeldingen hergebruiken over dia's**

Als dezelfde afbeelding meer dan eens nodig is, voeg deze dan één keer toe aan de presentatie en hergebruik de geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) bij het maken van extra picture frames. Dit voorkomt het herhaaldelijk laden van dezelfde brongegevens en maakt de relatie tussen de gedeelde afbeeldingsbron en het gebruik ervan expliciet.

Voor grafische elementen die automatisch op veel dia's moeten verschijnen, zoals een bedrijfslogo, overweeg om het picture frame op een [slide master](/slides/nl/java/slide-master/) of lay-out te plaatsen in plaats van een gelijkwaardige vorm aan elke dia toe te voegen.

## **Een afbeelding als dia‑achtergrond gebruiken**

Een achtergrondafbeelding wordt toegewezen aan de dia‑vulling; hij wordt niet toegevoegd als een picture‑frame vorm. Dit is handig wanneer de afbeelding de dia‑achtergrond moet bedekken en niet als een normaal dia‑object bewerkt mag worden.

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

Voor extra achtergrondopties, inclusief master‑ en lay‑outachtergronden, zie [Presentation Background](/slides/nl/java/presentation-background/).

## **Ingebedde afbeeldingen en gekoppelde afbeeldingen**

Ingebedde en gekoppelde afbeeldingen hebben verschillende draagbaarheid‑ en bestandsgrootte‑afwegingen:

- **Ingebedde afbeelding:** de afbeeldingsgegevens worden opgeslagen binnen de presentatie. De presentatie is zelfstandig, maar de bestandsgrootte omvat de afbeeldingsgegevens.
- **Gekoppelde afbeelding:** de presentatie slaat een pad of URL op naar een externe afbeelding. Dit kan de presentatiegrootte verkleinen, maar de externe bron moet toegankelijk blijven wanneer de presentatie wordt geopend of gerenderd.

Een gekoppelde afbeelding kan worden gemaakt door het externe pad of de URL toe te wijzen via [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidespicture/) in plaats van de afbeeldingsgegevens in te bedden.

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

Gebruik gekoppelde afbeeldingen alleen wanneer de implementatie‑omgeving betrouwbaar toegang heeft tot de externe bron. Voor presentaties die offline moeten werken of tussen systemen moeten worden verplaatst, zijn ingebedde afbeeldingen doorgaans veiliger.

## **Werken met SVG‑afbeeldingen**

SVG is een vectorformaat, waardoor het nuttig kan zijn voor pictogrammen, diagrammen en andere grafische elementen die zonder hetzelfde detailverlies als rasterafbeeldingen moeten schalen. Aspose.Slides ondersteunt SVG zowel als een afbeeldingsbron als een bron voor bewerkbare dia‑vormen.

### **Een SVG als afbeelding toevoegen**

Maak een [SvgImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgimage/), voeg deze toe aan de afbeeldingscollectie en plaats de resulterende afbeeldingsbron in een picture frame.

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

Een SVG kan verwijzen naar externe afbeeldingen, stijlsheets of lettertypen. Voor deze gevallen biedt [SvgImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/svgimage/) constructors die een [IExternalResourceResolver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iexternalresourceresolver/) en een basis‑URI accepteren. De resolver kan een relatieve URI omzetten naar een toegestane absolute URI en een stroom teruggeven voor de gevraagde bron.

De resolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt, maar herschrijft de SVG niet naar een zelfstandig document. Als de SVG draagbaar moet blijven, embed dan de benodigde bronnen in de SVG zelf, bijvoorbeeld door `data:`‑URI's te gebruiken voor gekoppelde afbeeldingen.

Wanneer SVG‑bestanden afkomstig zijn van niet‑vertrouwde bronnen, beperk dan de schema's, bestandslocaties en hosts waartoe de resolver toegang heeft. Netwerk‑resolvers moeten ook time‑outs, limieten voor responsgrootte en inhoudsvalidatie toepassen.

### **SVG omzetten naar bewerkbare vormen**

Aspose.Slides kan een SVG omzetten in een groep bewerkbare dia‑vormen, vergelijkbaar met de overeenkomstige PowerPoint‑opdracht.

![PowerPoint Popup Menu](img_01_01.png)

Gebruik de [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/) overload die een [ISvgImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isvgimage/) accepteert om de conversie uit te voeren.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gebruik SVG‑naar‑vormen conversie wanneer individuele vector‑elementen bewerkt moeten worden als PowerPoint‑vormen. Als de SVG alleen moet worden weergegeven, is het behouden als afbeelding eenvoudiger en vermijdt het het aanmaken van veel afzonderlijke vormen.

## **Een bestaande afbeeldingsbron vervangen**

Gebruik [IPPImage.replaceImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) wanneer u een bestaande afbeeldingsbron wilt vervangen. Dit is vooral handig voor gedeelde grafische elementen zoals logo’s.

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

Als meerdere picture frames, achtergronden, masters of lay‑outs dezelfde afbeeldingsbron gebruiken, werkt het vervangen van die bron al deze toepassingen bij. Als slechts één picture frame moet worden gewijzigd, ken dan een andere afbeelding toe aan dat frame in plaats van de gedeelde bron te vervangen.

`replaceImage` biedt ook overloads die een byte‑array of een andere [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/) accepteren.

## **Praktische richtlijnen voor afbeeldingsbeheer**

### **Presentatiegrootte beheren**

Grote rasterafbeeldingen kunnen een presentatie onnodig groot maken. Gebruik bronafbeeldingen met afmetingen die passen bij de beoogde weergavegrootte, hergebruik gedeelde afbeeldingsbronnen waar mogelijk, en vermijd het inbedden van meerdere exemplaren van dezelfde volledige resolutie‑grafiek.

Voor rasterafbeeldingen die al in picture frames zijn geplaatst, kan [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipicturefillformat/) de afbeeldingsgegevens verminderen volgens de gekozen resolutie en bijsnijdinstellingen. Dit is picture‑frame verwerking in plaats van beheer van de afbeeldingscollectie, dus zie [Picture Frame](/slides/nl/java/picture-frame/) voor gerelateerde opmaakbewerkingen.

### **Kies tussen ingebedde en gekoppelde content**

Inbedden maakt de presentatie draagbaar omdat alle vereiste afbeeldingsgegevens met het bestand meereizen. Koppelen kan de bestandsgrootte verkleinen, maar introduceert een externe afhankelijkheid. Gebruik links alleen wanneer die afhankelijkheid acceptabel en stabiel is.

### **Gedeelde branding hergebruiken**

Voor herhaalde logo’s, watermerken of decoratieve grafische elementen, gebruik één afbeeldingsbron en hergebruik deze. Als de grafiek tot het presentatiedesign behoort in plaats van tot de dia‑inhoud, plaats deze dan op een master of lay‑out zodat deze wordt geërfd door de betreffende dia’s.

### **SVG‑bronnen draagbaar houden**

Een zelfstandige SVG is makkelijker te verplaatsen en consistent te renderen dan een SVG die afhankelijk is van externe bestanden of netwerkbronnen. Wanneer mogelijk, embed de benodigde bronnen vóór het importeren van de SVG. Converteer SVG naar vormen alleen wanneer de individuele vector‑elementen bewerkt moeten worden.

### **Gebruik de moderne cross‑platform afbeeldings‑API**

Voor nieuwe Java‑code, gebruik de Aspose.Slides [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) en [Images](https://reference.aspose.com/slides/nl/java/com.aspose.slides/images/) API’s in plaats van de verouderde publieke API gebaseerd op `java.awt.image.BufferedImage`. Zie [Modern API](/slides/nl/java/modern-api/) voor migratie‑richtlijnen.

WMF en EMF vereisen speciale aandacht. Wanneer deze formaten via een [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/) worden verwerkt, converteert [ImageCollection.addImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imagecollection/) de metafile naar een raster‑PNG‑representatie vóór invoeging. Als het behouden van de metafile‑gegevens belangrijk is, gebruik dan een stream‑gebaseerde [ImageCollection.addImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imagecollection/) overload. Het genereren van EMF‑inhoud vanuit spreadsheets of andere producten is een afzonderlijke integratie‑workflow en valt buiten de reikwijdte van dit artikel.

## **FAQ**

**Wat is het verschil tussen de afbeeldingscollectie en een picture frame?**  
De afbeeldingscollectie slaat herbruikbare afbeeldingsbronnen op. Een picture frame is een dia‑vorm die een van die bronnen weergeeft en picture‑specifieke opmaak biedt, zoals bijsnijden en effecten.

**Wat is de beste manier om hetzelfde logo overal te vervangen?**  
Als het logo al gedeeld is als één afbeeldingsbron, vervang die bron met [IPPImage.replaceImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/). Voor merkidentiteit over de hele presentatie, kan het plaatsen van het logo op een master of lay‑out ook de duplicatie van dia‑inhoud verminderen.

**Waarom verdwijnt een gekoppelde afbeelding op een andere computer?**  
Een gekoppelde afbeelding hangt af van zijn externe bestand of URL. Als die bron niet bereikbaar is vanaf de andere computer, kan de gekoppelde afbeelding onbeschikbaar zijn. Embed de afbeelding wanneer de presentatie zelfstandig moet zijn.

**Kan een ingevoegde SVG worden bewerkt als PowerPoint‑vormen?**  
Ja. Converteer de SVG met [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/); de resulterende groep bevat bewerkbare dia‑vormen in plaats van één SVG‑afbeelding.

**Hoe kan ik presentaties met veel afbeeldingen kleiner houden?**  
Herbruik gedeelde afbeeldingsbronnen, vermijd onnodig grote rasterbronnen, comprimeer geschikte rasterafbeeldingen wanneer passend, houd herhaalde branding op masters of lay‑outs, en gebruik gekoppelde afbeeldingen alleen wanneer een externe afhankelijkheid acceptabel is.