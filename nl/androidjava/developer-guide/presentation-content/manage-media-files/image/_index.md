---
title: Afbeeldingsbeheer optimaliseren in presentaties op Android
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
- van internet
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- externe SVG‑resources
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
description: "Vereenvoudig het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor Android via Java, optimaliseer de prestaties en automatiseer uw workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en visueel aantrekkelijker. In Microsoft PowerPoint kunt u afbeeldingen op dia's invoegen vanuit bestanden, internet of andere bronnen. Op dezelfde manier stelt Aspose.Slides u in staat afbeeldingen aan presentatiedia's toe te voegen op verschillende manieren.

{{% alert  title="Tip" color="info" %}} 
Aspose biedt gratis converters—[JPEG to PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG to PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die u snel presentaties uit afbeeldingen kunt maken. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Als u een afbeelding wilt toevoegen als afbeeldingsframe—vooral als u van plan bent deze te schalen, effecten toe te passen of andere standaardopmaakeigenschappen te gebruiken—zie [Picture Frame](/slides/nl/androidjava/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
U kunt afbeeldingen van het ene formaat naar het andere converteren. Zie de volgende pagina's: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/androidjava/conversion/image-to-jpg/), [JPG naar afbeelding](https://products.aspose.com/slides/nl/androidjava/conversion/jpg-to-image/), [JPG naar PNG](https://products.aspose.com/slides/nl/androidjava/conversion/jpg-to-png/), [PNG naar JPG](https://products.aspose.com/slides/nl/androidjava/conversion/png-to-jpg/), [PNG naar SVG](https://products.aspose.com/slides/nl/androidjava/conversion/png-to-svg/), en [SVG naar PNG](https://products.aspose.com/slides/nl/androidjava/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides ondersteunt afbeeldingen in populaire formaten zoals JPEG, PNG, BMP, GIF en andere. 

## **Afbeeldingen die lokaal zijn opgeslagen toevoegen aan dia's**

U kunt één of meerdere afbeeldingen die op uw computer zijn opgeslagen toevoegen aan een presentatiedia. De volgende Java‑voorbeeldcode toont hoe u een afbeelding aan een dia kunt toevoegen:

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

## **Afbeeldingen van het internet toevoegen aan dia's**

Als de afbeelding die u aan een dia wilt toevoegen niet op uw computer is opgeslagen, kunt u deze rechtstreeks van het internet toevoegen. 

De volgende Java‑voorbeeldcode toont hoe u een afbeelding van het internet aan een dia kunt toevoegen:

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

Een dia‑master slaat informatie op en beheert zaken zoals het thema en de lay‑out voor de dia's die het gebruiken. Wanneer u een afbeelding aan een dia‑master toevoegt, verschijnt de afbeelding op elke dia die op die master is gebaseerd. 

De volgende Java‑voorbeeldcode toont hoe u een afbeelding aan een dia‑master kunt toevoegen:

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

## **Afbeeldingen toevoegen als dia‑achtergronden**

U kunt een afbeelding gebruiken als achtergrond voor één of meerdere dia's. Voor details, zie *[Afbeeldingen instellen als achtergrond voor dia's](/slides/nl/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG toevoegen aan presentaties**

SVG‑inhoud kan aan een presentatie worden toegevoegd met de klasse [SvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgimage/). Het resulterende [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/)‑object kan vervolgens worden toegevoegd aan de afbeeldingsverzameling van de presentatie en worden gebruikt om een afbeeldingsframe te maken.

De volgende Java‑voorbeeld importeert een zelf‑containende SVG‑string. Alle afbeeldingen, stijlen en andere resources die door deze SVG worden gebruikt, zijn direct in de SVG‑inhoud ingebed.

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

## **SVG‑inhoud importeren met externe resources**

SVG‑bestanden die geëxporteerd zijn vanuit ontwerptools, diagrameditors, icoonsystemen en web‑pijplijnen kunnen verwijzen naar resources die buiten het SVG‑document zijn opgeslagen. Bijvoorbeeld, een SVG kan een afbeelding‑link bevatten zoals `images/photo.png`, een CSS `url(...)`‑waarde, of een lettertype‑URL.

Om dergelijke SVG‑inhoud te importeren, maakt u een [IExternalResourceResolver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iexternalresourceresolver/)‑implementatie aan en geeft u deze, samen met een basis‑URI, door aan een geschikte [SvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/svgimage/)‑constructor. De basis‑URI identificeert de locatie van het SVG‑document en wordt gebruikt om relatieve koppelingen te resolven.

De [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isvgimage/)‑interface biedt toegang tot informatie over de geïmporteerde SVG:

- `getSvgContent()` retourneert de SVG‑markup als een string.
- `getSvgData()` retourneert de SVG‑inhoud als een byte‑array.
- `getBaseUri()` retourneert de basis‑URI die gebruikt wordt voor relatieve koppelingen.
- `getExternalResourceResolver()` retourneert de resolver die aan de SVG‑afbeelding is toegewezen.

### **Implementeer een externe resource‑resolver**

De resolver heeft twee methoden:

- `resolveUri` combineert de basis‑URI en een relatieve resource‑link en retourneert een absolute URI. Retourneer `null` wanneer de link niet kan worden opgelost of niet is toegestaan.
- `getEntity` retourneert een leesbare stream voor een absolute resource‑URI. Retourneer `null` wanneer de resource ontbreekt, geblokkeerd is of niet beschikbaar. Een fallback‑stream kan ook worden geretourneerd wanneer passend.

De volgende resolver laadt gekoppelde resources alleen vanuit een toegestane lokale map. Netwerk‑resources en paden buiten de toegestane map worden geblokkeerd. Een optionele fallback‑afbeelding wordt geretourneerd voor niet‑opgeloste afbeeldingslinks.

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

            // Gebruik alleen een fallback voor afbeeldingsresources. Het retourneren van een afbeeldingstream
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

### **Gekoppelde resources oplossen tijdens SVG‑import**

Stel dat `assets/diagram.svg` een relatieve referentie bevat zoals:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

De volgende Java‑voorbeeld geeft de SVG‑bestands‑URI door als basis‑URI en biedt een aangepaste resolver. De resolver converteert de relatieve afbeeldingslink naar een absolute URI en retourneert een stream die de gekoppelde resource bevat terwijl Aspose.Slides de SVG verwerkt.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// De basis‑URI vertegenwoordigt de locatie van het SVG‑document.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage geeft de broninhoud, binaire gegevens, basis‑URI en resolver weer.
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

De `SvgImage`‑klasse biedt ook overloads die SVG‑data accepteren als een byte‑array of een input‑stream, samen met een externe resource‑resolver en een basis‑URI.

{{% alert title="Belangrijk" color="warning" %}}
De resource‑resolver maakt externe resources beschikbaar terwijl Aspose.Slides de SVG verwerkt en rendert. Het wijzigt de originele SVG‑markup niet en embed niet automatisch de opgeloste resources daarin.

Wanneer een `ISvgImage` wordt toegevoegd aan de afbeeldingsverzameling van de presentatie, kan het PPTX‑bestand zowel de originele SVG‑representatie als een raster‑fallback‑afbeelding bevatten. Een gekoppelde resource kan verschijnen in de gegenereerde fallback‑afbeelding terwijl een relatieve link zoals `images/photo.png` onveranderd blijft in de opgeslagen SVG. Een applicatie die de native SVG‑representatie rendert, kan de gekoppelde inhoud daarom weglaten wanneer de oorspronkelijke externe resource niet beschikbaar is.
{{% /alert %}}

### **Maak een draagbare SVG‑afbeelding**

Om een SVG‑afbeelding te maken die niet afhankelijk is van externe bestanden, maakt u de SVG zelf‑containend voordat u de `SvgImage` maakt. Vervang bijvoorbeeld gekoppelde afbeeldings‑URL’s door `data:`‑URI’s die de afbeeldingsdata bevatten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nadat alle vereiste resources in de SVG‑inhoud zijn ingebed, maakt u de `SvgImage`, voegt u deze toe aan de afbeeldingsverzameling van de presentatie en plaatst u deze in een afbeeldingsframe zoals getoond in het vorige voorbeeld.

### **Ontbrekende of geblokkeerde resources afhandelen**

Retourneer `null` vanuit `resolveUri` wanneer een resource‑URI ongeldig, verboden of niet kan worden opgelost. Retourneer `null` vanuit `getEntity` wanneer de resource niet kan worden gelezen. Aspose.Slides blijft de SVG verwerken zonder die resource wanneer mogelijk.

Een fallback‑stream kan worden geretourneerd voor een ontbrekende resource, maar de inhoud moet compatibel zijn met het aangevraagde resource‑type. Retourneer bijvoorbeeld een afbeeldings‑stream alleen voor een ontbrekende afbeelding, niet voor een lettertype of stylesheet.

{{% alert title="Beveiliging" color="warning" %}}
Los geen willekeurige bestandspaden of onbeperkte netwerk‑URL’s op uit niet‑vertrouwde SVG‑bestanden. Beperk toegestane schema’s, directories en hosts. Voor netwerk‑resources, pas ook verbindings‑timeouts, limieten voor respons‑grootte en inhouds‑validatie toe.
{{% /alert %}}

## **SVG converteren naar een verzameling vormen**

Aspose.Slides kan een SVG converteren naar een verzameling vormen, vergelijkbaar met de overeenkomstige functionaliteit in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Deze functionaliteit wordt geleverd door een overload van de [addGroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-)‑methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection)‑interface die een [ISvgImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISvgImage)‑object als eerste argument neemt.

De volgende Java‑voorbeeldcode toont hoe u deze methode kunt gebruiken om een SVG‑bestand te converteren naar een verzameling vormen:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Bronnaam van SVG-bestand.
String svgFileName = "sample.svg";

// Naam van uitvoerpresentatiebestand.
String outPptxPath = "presentation.pptx";

// Nieuwe presentatie maken.
IPresentation presentation = new Presentation();
try {
    // De inhoud van het SVG-bestand lezen.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Een SvgImage-object maken.
    ISvgImage svgImage = new SvgImage(svgContent);

    // De dia-grootte ophalen.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // De SVG-afbeelding converteren naar een groep vormen en schalen naar de dia-grootte.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // De presentatie opslaan in PPTX-formaat.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Afbeeldingen als EMF toevoegen aan dia's**

Aspose.Slides for Android via Java stelt u in staat EMF‑afbeeldingen te genereren vanuit Excel‑werkbladen met Aspose.Cells en deze toe te voegen aan presentatiedia's.

De volgende Java‑voorbeeldcode toont hoe u dit doet:

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

// Sla het werkboek op naar een stream.
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

## **Afbeeldingen vervangen in de afbeeldingsverzameling**

Aspose.Slides laat u afbeeldingen vervangen die zijn opgeslagen in de afbeeldingsverzameling van een presentatie, inclusief afbeeldingen die door dia‑vormen worden gebruikt. Deze sectie beschrijft verschillende manieren om afbeeldingen in de verzameling bij te werken. U kunt een afbeelding vervangen met ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/)‑instantie, of een andere afbeelding die al in de verzameling aanwezig is.

Volg de onderstaande stappen:

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
3. Vervang de doel‑afbeelding door de nieuwe afbeelding met behulp van de byte‑array.
4. In de tweede benadering, laad de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/)‑object en vervang de doel‑afbeelding door dat object.
5. In de derde benadering, vervang de doel‑afbeelding door een afbeelding die al bestaat in de afbeeldingsverzameling van de presentatie.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Instantiseer de Presentation‑klasse die een presentatiebestand vertegenwoordigt.
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

    // Sla de presentatie op naar een bestand.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Met Aspose's gratis [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter kunt u eenvoudig tekst animeren en GIF‑bestanden uit tekst maken. 
{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke beeldresolutie behouden na het invoegen?**

Ja. De bronpixels worden behouden, maar het uiteindelijke uiterlijk hangt af van hoe het [picture](/slides/nl/androidjava/picture-frame/) op de dia wordt geschaald en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's tegelijk te vervangen?**

Plaats het logo op de masterdia of een lay‑out en vervang het in de afbeeldingsverzameling van de presentatie — updates worden doorgevoerd naar alle elementen die die resource gebruiken.

**Kan een ingevoegde SVG worden omgezet in bewerkbare vormen?**

Ja. U kunt een SVG converteren naar een groep vormen, waarna individuele delen bewerkbaar zijn met standaard vormeigenschappen.

**Hoe kan ik een afbeelding in één keer instellen als achtergrond voor meerdere dia's?**

Wijs de afbeelding toe als achtergrond op de masterdia of de betreffende lay‑out — alle dia's die die master/lay‑out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat een presentatie te groot wordt door vele afbeeldingen?**

Herbruik één afbeeldingbron in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en houd herhaalde grafieken waar mogelijk op de master.