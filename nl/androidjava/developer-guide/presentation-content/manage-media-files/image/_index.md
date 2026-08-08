---
title: Optimaliseer het beheer van afbeeldingen in presentaties op Android
linktitle: Afbeeldingen beheren
type: docs
weight: 10
url: /nl/androidjava/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van het web
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- externe SVG‑bronnen
- SVG‑resolver
- gelinkte SVG‑afbeeldingen
- SVG‑lettertypen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Stroomlijn het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor Android via Java, optimaliseer de prestaties en automatiseer uw workflow."
---
## **Introductie**

Afbeeldingen maken presentaties boeiender en visueel aantrekkelijker. In Microsoft PowerPoint kun je afbeeldingen in dia's invoegen vanuit bestanden, internet of andere bronnen. Op dezelfde manier stelt Aspose.Slides je in staat om afbeeldingen aan presentatiedia's toe te voegen op verschillende manieren.

{{% alert  title="Tip" color="primary" %}} 
Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die je in staat stellen om snel presentaties van afbeeldingen te maken. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Als je een afbeelding wilt toevoegen als afbeeldingsframe—vooral wanneer je deze wilt schalen, effecten wilt toepassen of andere standaardopmaakopties wilt gebruiken—zie [Afbeeldingsframe](/slides/nl/androidjava/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Je kunt afbeeldingen van het ene formaat naar het andere converteren. Zie de volgende pagina's: converteren [afbeelding naar JPG](https://products.aspose.com/slides/nl/androidjava/conversion/image-to-jpg/), [JPG naar afbeelding](https://products.aspose.com/slides/nl/androidjava/conversion/jpg-to-image/), [JPG naar PNG](https://products.aspose.com/slides/nl/androidjava/conversion/jpg-to-png/), [PNG naar JPG](https://products.aspose.com/slides/nl/androidjava/conversion/png-to-jpg/), [PNG naar SVG](https://products.aspose.com/slides/nl/androidjava/conversion/png-to-svg/), en [SVG naar PNG](https://products.aspose.com/slides/nl/androidjava/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides ondersteunt afbeeldingen in populaire formaten zoals JPEG, PNG, BMP, GIF en andere. 

## **Afbeeldingen die lokaal zijn opgeslagen toevoegen aan dia's**

Je kunt één of meer afbeeldingen die op je computer zijn opgeslagen toevoegen aan een presentatiedia. De volgende Java-voorbeeldcode laat zien hoe je een afbeelding aan een dia toevoegt:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Afbeeldingen van het web toevoegen aan dia's**

Als de afbeelding die je aan een dia wilt toevoegen niet op je computer is opgeslagen, kun je deze direct van het web toevoegen. 

De volgende Java-voorbeeldcode laat zien hoe je een afbeelding van het web aan een dia toevoegt:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Afbeeldingen toevoegen aan dia‑masters**

Een dia‑master slaat informatie op en regelt deze, zoals het thema en de lay-out voor de dia's die ervan gebruikmaken. Wanneer je een afbeelding toevoegt aan een dia‑master, verschijnt de afbeelding op elke dia die op die master is gebaseerd. 

De volgende Java-voorbeeldcode laat zien hoe je een afbeelding aan een dia‑master toevoegt:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Afbeeldingen als dia‑achtergronden toevoegen**

Je kunt een afbeelding gebruiken als achtergrond voor één of meer dia's. Voor details, zie *[Instellen van afbeeldingen als achtergrond voor dia's](/slides/nl/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG aan presentaties toevoegen**

SVG‑inhoud kan aan een presentatie worden toegevoegd met de [SvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgimage/)‑klasse. Het resulterende [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/)‑object kan vervolgens aan de afbeeldingsverzameling van de presentatie worden toegevoegd en worden gebruikt om een afbeeldingsframe te maken.

Het volgende Java‑voorbeeld importeert een zelfstandige SVG‑string. Alle afbeeldingen, stijlen en andere bronnen die door deze SVG worden gebruikt, zijn direct in de SVG‑inhoud ingebed.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SVG‑inhoud importeren met externe bronnen**

SVG‑bestanden die geëxporteerd zijn vanuit ontwerpgereedschappen, diagrameditors, icoonsystemen en web‑pijplijnen kunnen verwijzen naar bronnen die buiten het SVG‑document zijn opgeslagen. Een SVG kan bijvoorbeeld een afbeeldingslink bevatten zoals `images/photo.png`, een CSS `url(...)`-waarde, of een lettertype‑URL.

Om dergelijke SVG‑inhoud te importeren, maak je een [IExternalResourceResolver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iexternalresourceresolver/)-implementatie en geef je deze, samen met een basis‑URI, door aan een geschikte [SvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgimage/)-constructor. De basis‑URI identificeert de locatie van het SVG‑document en wordt gebruikt om relatieve links op te lossen.

De [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/) interface biedt toegang tot informatie over de geïmporteerde SVG:

- `getSvgContent()` retourneert de SVG‑markup als een string.  
- `getSvgData()` retourneert de SVG‑inhoud als een byte‑array.  
- `getBaseUri()` retourneert de basis‑URI die wordt gebruikt voor relatieve links.  
- `getExternalResourceResolver()` retourneert de resolver die aan de SVG‑afbeelding is toegewezen.  

### **Implementeer een externe resource‑resolver**

De resolver heeft twee methoden:

- `resolveUri` combineert de basis‑URI en een relatieve resource‑link en retourneert een absolute URI. Retourneer `null` wanneer de link niet kan worden opgelost of niet is toegestaan.  
- `getEntity` retourneert een leesbare stream voor een absolute resource‑URI. Retourneer `null` wanneer de resource ontbreekt, geblokkeerd is of niet beschikbaar is. Een fallback‑stream kan ook worden geretourneerd wanneer passend.  

De volgende resolver laadt gekoppelde resources alleen vanuit een toegestane lokale map. Netwerkresources en paden buiten de toegestane map worden geblokkeerd. Een optionele fallback‑afbeelding wordt geretourneerd voor niet‑opgeloste afbeeldingslinks.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Deze resolver staat opzettelijk alleen lokale bestanden toe.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Gebruik alleen een fallback voor afbeeldingsbronnen. Retourneren van een afbeeldingsstroom
            // voor een ontbrekend lettertype of stylesheet zou niet geldig zijn.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Gelinkte resources oplossen tijdens SVG‑import**

Stel dat `assets/diagram.svg` een relatieve referentie bevat zoals:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Het volgende Java‑voorbeeld geeft de SVG‑bestands‑URI door als basis‑URI en levert een aangepaste resolver. De resolver zet de relatieve afbeeldingslink om in een absolute URI en retourneert een stream met de gekoppelde resource terwijl Aspose.Slides de SVG verwerkt.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// De basis-URI vertegenwoordigt de locatie van het SVG-document.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage biedt de broninhoud, binaire gegevens, basis-URI en resolver.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De `SvgImage`‑klasse biedt ook overloads die SVG‑data accepteren als een byte‑array of een invoerstroom, samen met een externe resource‑resolver en een basis‑URI.

{{% alert title="Belangrijk" color="warning" %}}
De resource‑resolver maakt externe resources beschikbaar terwijl Aspose.Slides de SVG verwerkt en rendert. Het wijzigt de oorspronkelijke SVG‑markup niet en embedde de opgeloste resources niet automatisch.

Wanneer een `ISvgImage` wordt toegevoegd aan de afbeeldingsverzameling van de presentatie, kan het PPTX‑bestand zowel de oorspronkelijke SVG‑representatie als een raster‑fallback‑afbeelding bevatten. Een gekoppelde resource kan verschijnen in de gegenereerde fallback‑afbeelding, terwijl een relatieve link zoals `images/photo.png` onveranderd blijft in de opgeslagen SVG. Een toepassing die de native SVG‑representatie rendert, kan daarom de gekoppelde inhoud weglaten wanneer de oorspronkelijke externe resource niet beschikbaar is.
{{% /alert %}}

### **Maak een draagbare SVG‑afbeelding**

Om een SVG‑afbeelding te maken die niet afhankelijk is van externe bestanden, maak je de SVG zelf‑containend voordat je de `SvgImage` creëert. Vervang bijvoorbeeld gekoppelde afbeeldings‑URL's door `data:`‑URI's die de afbeeldingsdata bevatten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nadat alle benodigde resources in de SVG‑inhoud zijn ingebed, maak je de `SvgImage`, voeg je deze toe aan de afbeeldingsverzameling van de presentatie, en voeg je deze in een afbeeldingsframe in zoals in het vorige voorbeeld.

### **Ontbrekende of geblokkeerde resources afhandelen**

Retourneer `null` van `resolveUri` wanneer een resource‑URI ongeldig, verboden of niet kan worden opgelost. Retourneer `null` van `getEntity` wanneer de resource niet kan worden gelezen. Aspose.Slides blijft de SVG verwerken zonder die resource wanneer mogelijk.

Een fallback‑stream kan worden geretourneerd voor een ontbrekende resource, maar de inhoud moet compatibel zijn met het aangevraagde resource‑type. Retourneer bijvoorbeeld alleen een afbeeldings‑stream voor een ontbrekende afbeelding, niet voor een lettertype of stylesheet.

{{% alert title="Beveiliging" color="warning" %}}
Los geen willekeurige bestands‑paden of onbeperkte netwerk‑URL's op uit onbetrouwbare SVG‑bestanden. Beperk toegestane schema’s, mappen en hosts. Voor netwerk‑resources, pas ook verbindings‑timeouts, limieten op de respons‑grootte en inhouds‑validatie toe.
{{% /alert %}}

## **SVG omzetten naar een set vormen**

Aspose.Slides kan een SVG omzetten in een set vormen, vergelijkbaar met de overeenkomstige functionaliteit in PowerPoint:

![PowerPoint pop‑upmenu](img_01_01.png)

Deze functionaliteit wordt geleverd door een overload van de [addGroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-)‑methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection) interface die een [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISvgImage) object als eerste argument neemt.

De volgende Java‑voorbeeldcode laat zien hoe je deze methode gebruikt om een SVG‑bestand om te zetten in een set vormen:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Bron SVG-bestandsnaam.
String svgFileName = "sample.svg";

// Bestandsnaam van de uitvoer-presentatie.
String outPptxPath = "presentation.pptx";

// Maak een nieuwe presentatie.
IPresentation presentation = new Presentation();
try {
    // Lees de inhoud van het SVG-bestand.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Maak een SvgImage-object.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Haal de dia-grootte op.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Converteer de SVG-afbeelding naar een groep vormen en schaal deze naar de dia-grootte.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Sla de presentatie op in PPTX-formaat.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Afbeeldingen als EMF aan dia's toevoegen**

Aspose.Slides for Android via Java stelt je in staat om EMF‑afbeeldingen te genereren uit Excel‑werkbladen met Aspose.Cells en deze toe te voegen aan presentatiedia's.

De volgende Java‑voorbeeldcode laat zien hoe je dit doet:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Sla het werkboek op in een stream.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Voeg het bestand toe zoals het is zodat de afbeelding een vector‑EMF blijft in plaats van gerasterd te worden.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Afbeeldingen in de afbeeldingsverzameling vervangen**

Aspose.Slides laat je afbeeldingen die zijn opgeslagen in de afbeeldingsverzameling van een presentatie vervangen, inclusief afbeeldingen die door dia‑vormen worden gebruikt. Deze sectie beschrijft verschillende manieren om afbeeldingen in de verzameling bij te werken. Je kunt een afbeelding vervangen met ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/)‑instance, of een andere afbeelding die al in de verzameling bestaat.

1. Laad het presentatie‑bestand dat afbeeldingen bevat met behulp van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.  
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.  
3. Vervang de doel‑afbeelding door de nieuwe afbeelding met behulp van de byte‑array.  
4. In de tweede aanpak laad je de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/)‑object en vervang je de doel‑afbeelding door dat object.  
5. In de derde aanpak vervang je de doel‑afbeelding door een afbeelding die al in de afbeeldingsverzameling van de presentatie bestaat.  
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Instantieer de Presentation‑klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation("sample.pptx");
try {
    // De eerste manier.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // De tweede manier.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // De derde manier.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Sla de presentatie op in een bestand.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Met de gratis [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter van Aspose kun je eenvoudig tekst animeren en GIF’s van tekst maken. 
{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na het invoegen?**

Ja. De bronpixels blijven behouden, maar het uiteindelijke uiterlijk hangt af van hoe de [afbeelding](/slides/nl/androidjava/picture-frame/) op de dia wordt geschaald en van eventuele compressie die bij het opslaan wordt toegepast.

**Wat is de beste manier om hetzelfde logo in tientallen dia's in één keer te vervangen?**

Plaats het logo op de master‑dia of een lay-out en vervang het in de afbeeldingsverzameling van de presentatie — wijzigingen worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden omgezet in bewerkbare vormen?**

Ja. Je kunt een SVG omzetten in een groep vormen, waarna individuele delen bewerkbaar worden met de standaard vorm‑eigenschappen.

**Hoe kan ik een afbeelding in één keer als achtergrond voor meerdere dia's instellen?**

[Wijs de afbeelding toe als achtergrond](/slides/nl/androidjava/presentation-background/) op de master‑dia of de relevante lay-out — alle dia's die die master/lay-out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat een presentatie te groot wordt door veel afbeeldingen?**

Herbruik één afbeeldingsbron in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en behoud herhaalde afbeeldingen op de master waar dit passend is.