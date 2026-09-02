---
title: Optimera bildhantering i presentationer på Android
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/androidjava/image/
keywords:
- lägga till bild
- lägga till foto
- lägga till bitmap
- ersätta bild
- ersätta foto
- från webben
- bakgrund
- lägga till PNG
- lägga till JPG
- lägga till SVG
- externa SVG-resurser
- SVG-upplösare
- länkade SVG-bilder
- SVG-teckensnitt
- lägga till EMF
- lägga till WMF
- lägga till TIFF
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Strömlinjeforma bildhantering i PowerPoint och OpenDocument med Aspose.Slides för Android via Java, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och visuellt tilltalande. I Microsoft PowerPoint kan du infoga bilder på bilder från filer, internet eller andra källor. På samma sätt låter Aspose.Slides dig lägga till bilder på presentationsbilder på flera sätt.

{{% alert  title="Tips" color="primary" %}} 

Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter dig snabbt skapa presentationer från bilder. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Om du vill lägga till en bild som en bildram—särskilt om du planerar att ändra storlek, applicera effekter eller använda andra standardformateringsalternativ—se [Bildram](/slides/sv/androidjava/picture-frame/). 

{{% /alert %}} 

{{% alert title="Obs" color="warning" %}}

Du kan konvertera bilder från ett format till ett annat. Se följande sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/androidjava/conversion/image-to-jpg/), [JPG till bild](https://products.aspose.com/slides/sv/androidjava/conversion/jpg-to-image/), [JPG till PNG](https://products.aspose.com/slides/sv/androidjava/conversion/jpg-to-png/), [PNG till JPG](https://products.aspose.com/slides/sv/androidjava/conversion/png-to-jpg/), [PNG till SVG](https://products.aspose.com/slides/sv/androidjava/conversion/png-to-svg/), och [SVG till PNG](https://products.aspose.com/slides/sv/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides stöder bilder i populära format såsom JPEG, PNG, BMP, GIF och andra. 

## **Lägg till lokalt lagrade bilder på bilder**

Du kan lägga till en eller flera bilder som lagras på din dator till en presentationsbild. Följande Java-exempel visar hur du lägger till en bild på en bild:

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

## **Lägg till bilder från webben på bilder**

Om bilden du vill lägga till på en bild inte är lagrad på din dator kan du lägga till den direkt från webben.

Följande Java-exempel visar hur du lägger till en bild från webben på en bild:

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

## **Lägg till bilder till bildmaster**

En bildmaster lagrar och styr information såsom tema och layout för de bilder som använder den. När du lägger till en bild på en bildmaster visas bilden på varje bild som baseras på den mastern.

Följande Java-exempel visar hur du lägger till en bild på en bildmaster:

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

## **Lägg till bilder som bildbakgrund**

Du kan använda en bild som bakgrund för en eller flera bilder. För detaljer, se *[Ställa in bilder som bakgrund för bilder](/slides/sv/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägg till SVG i presentationer**

SVG-innehåll kan läggas till i en presentation med klassen [SvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgimage/). Det resulterande [ISvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgimage/)-objektet kan sedan läggas till i presentationens bildsamling och användas för att skapa en bildram.

Följande Java-exempel importerar en självständig SVG-sträng. Alla bilder, stilar och andra resurser som används av denna SVG är inbäddade direkt i SVG-innehållet.

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

## **Importera SVG-innehåll med externa resurser**

SVG-filer som exporteras från designverktyg, diagramredigerare, ikonsystem och webbpipeline kan referera till resurser som lagras utanför SVG-dokumentet. Till exempel kan en SVG innehålla en bildlänk som `images/photo.png`, ett CSS `url(...)`-värde eller en teckensnitt-URL.

För att importera sådant SVG-innehåll skapar du en [IExternalResourceResolver](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iexternalresourceresolver/)-implementation och skickar den, tillsammans med en bas‑URI, till en lämplig [SvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgimage/)-konstruktor. Bas‑URI identifierar platsen för SVG-dokumentet och används för att lösa relativa länkar.

[ISvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isvgimage/)-gränssnittet ger åtkomst till information om den importerade SVG:n:

- `getSvgContent()` returnerar SVG‑markup som en sträng.
- `getSvgData()` returnerar SVG‑innehållet som en byte‑array.
- `getBaseUri()` returnerar bas‑URI:n som används för relativa länkar.
- `getExternalResourceResolver()` returnerar upplösaren som tilldelats SVG‑bilden.

### **Implementera en extern resurshanterare**

Upplösaren har två metoder:

- `resolveUri` kombinerar bas‑URI:n och en relativ resurslänk och returnerar en absolut URI. Returnera `null` när länken inte kan lösas eller inte är tillåten.
- `getEntity` returnerar en läsbar ström för en absolut resurs‑URI. Returnera `null` när resursen saknas, blockeras eller är otillgänglig. En reservström kan också returneras när det är lämpligt.

Följande upplösare läser endast länkade resurser från en tillåten lokal katalog. Nätverksresurser och sökvägar utanför den tillåtna katalogen blockeras. En valfri reservbild returneras för olösta bildlänkar.

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

            // Denna upplösare tillåter medvetet endast lokala filer.
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

            // Använd en reserv endast för bildresurser. Returnera en bildström
            // för ett saknat teckensnitt eller stilark skulle inte vara giltigt.
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

### **Lös länkade resurser under SVG-import**

Anta att `assets/diagram.svg` innehåller en relativ referens som:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Följande Java-exempel skickar SVG‑filens URI som bas‑URI och tillhandahåller en anpassad upplösare. Upplösaren konverterar den relativa bildlänken till en absolut URI och returnerar en ström som innehåller den länkade resursen medan Aspose.Slides bearbetar SVG:n.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Bas-URI:n representerar platsen för SVG-dokumentet.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exponerar källinnehållet, binära data, bas-URI:n och upplösaren.
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

`SvgImage`‑klassen erbjuder också överlagringar som accepterar SVG‑data som en byte‑array eller en indataström, tillsammans med en extern resurshanterare och en bas‑URI.

{{% alert title="Viktigt" color="warning" %}}

Resurshanteraren gör externa resurser tillgängliga medan Aspose.Slides bearbetar och renderar SVG:n. Den ändrar inte den ursprungliga SVG‑markupen eller bäddar automatiskt in de lösta resurserna i den.

När ett `ISvgImage` läggs till i presentationens bildsamling kan PPTX‑filen innehålla både den ursprungliga SVG‑representationen och en raster‑reservbild. En länkad resurs kan visas i den genererade reservbilden medan en relativ länk såsom `images/photo.png` förblir oförändrad i den lagrade SVG:n. En applikation som renderar den inbyggda SVG‑representationen kan därför utelämna det länkade innehållet när den ursprungliga externa resursen är otillgänglig.

{{% /alert %}}

### **Skapa en portabel SVG-bild**

För att skapa en SVG‑bild som inte är beroende av externa filer, gör SVG:n självständig innan du skapar `SvgImage`. Till exempel, ersätt länkade bild‑URL:er med `data:`‑URI:er som innehåller bilddata:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

När alla nödvändiga resurser är inbäddade i SVG‑innehållet, skapa `SvgImage`, lägg till den i presentationens bildsamling och infoga den i en bildram som i föregående exempel.

### **Hantera saknade eller blockerade resurser**

Returnera `null` från `resolveUri` när en resurs‑URI är ogiltig, förbjuden eller inte kan lösas. Returnera `null` från `getEntity` när resursen inte kan läsas. Aspose.Slides fortsätter bearbeta SVG:n utan den resursen när det är möjligt.

En reservström kan returneras för en saknad resurs, men innehållet måste vara kompatibelt med den begärda resurstypen. Till exempel, returnera en bildström endast för en saknad bild, inte för ett teckensnitt eller en stilmall.

{{% alert title="Säkerhet" color="warning" %}}

Lös inte godtyckliga filsökvägar eller obegränsade nätverks‑URL:er från opålitliga SVG‑filer. Begränsa tillåtna scheman, kataloger och värdar. För nätverksresurser, tillämpa också tidsgränser, svarsstorleksbegränsningar och innehållsvalidering.

{{% /alert %}}

## **Konvertera SVG till en uppsättning former**

Denna funktionalitet tillhandahålls av en överlagring av metoden [addGroupShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) i gränssnittet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection) som tar ett [ISvgImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISvgImage)-objekt som första argument.

Följande Java-exempel visar hur du använder denna metod för att konvertera en SVG‑fil till en uppsättning former:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Käll‑SVG‑filnamn.
String svgFileName = "sample.svg";

// Utdata presentationsfilnamn.
String outPptxPath = "presentation.pptx";

// Skapa en ny presentation.
IPresentation presentation = new Presentation();
try {
    // Läs SVG‑filens innehåll.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Skapa ett SvgImage‑objekt.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Hämta bildens storlek.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Konvertera SVG‑bilden till en grupp former och skala den till bildens storlek.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Spara presentationen i PPTX‑format.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Lägg till bilder som EMF på bilder**

Aspose.Slides för Android via Java låter dig generera EMF‑bilder från Excel‑arbetsblad med Aspose.Cells och lägga till dem i presentationsbilder.

Följande Java-exempel visar hur du gör detta:

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

// Spara arbetsboken till en ström.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Lägg till filen som den är så att bilden förblir en vektor‑EMF istället för att rasteriseras.
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

## **Byt ut bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling, inklusive bilder som används av bildformer. Detta avsnitt beskriver flera sätt att uppdatera bilder i samlingen. Du kan ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/)-instans eller en annan bild som redan finns i samlingen.

Följ stegen nedan:

1. Ladda presentationsfilen som innehåller bilder med klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Ladda en ny bild från en fil till en byte‑array.
1. Ersätt målbilden med den nya bilden med hjälp av byte‑arrayen.
1. I det andra tillvägagångssättet, ladda bilden i ett [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/)-objekt och ersätt målbilden med det objektet.
1. I det tredje tillvägagångssättet, ersätt målbilden med en bild som redan finns i presentationens bildsamling.
1. Skriv den modifierade presentationen som en PPTX‑fil.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Det första sättet.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Det andra sättet.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Det tredje sättet.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Spara presentationen till en fil.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Med Asposes gratis [Text till GIF](https://products.aspose.app/slides/sv/text-to-gif)-konverterare kan du enkelt animera text och skapa GIF‑filer från text. 

{{% /alert %}}

## **FAQ**

**Behåller den ursprungliga bildens upplösning sin integritet efter infogning?**

Ja. Källpixlarna bevaras, men det slutliga utseendet beror på hur [bilden](/slides/sv/androidjava/picture-frame/) skalas på bilden och eventuell komprimering vid sparande.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder på en gång?**

Placera logotypen på master‑bilden eller en layout och ersätt den i presentationens bildsamling—uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varpå enskilda delar blir redigerbara med vanliga formersegenskaper.

**Hur kan jag ange en bild som bakgrund för flera bilder på en gång?**

[Tilldela bilden som bakgrund](/slides/sv/androidjava/presentation-background/) på master‑bilden eller den relevanta layouten—alla bilder som använder den master/layouten ärver bakgrunden.

**Hur förhindrar jag att en presentation blir för stor på grund av många bilder?**

Återanvänd en enda bildresurs istället för dupliceringar, välj rimliga upplösningar, tillämpa komprimering vid sparande och håll återkommande grafik på master‑nivå där det är lämpligt.