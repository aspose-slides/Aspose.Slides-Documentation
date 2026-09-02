---
title: "Képek kezelésének optimalizálása a prezentációkban Java használatával"
linktitle: "Képek kezelése"
type: docs
weight: 10
url: /hu/java/image/
keywords:
- "kép hozzáadása"
- "kép hozzáadása"
- "bitmap hozzáadása"
- "kép cseréje"
- "kép cseréje"
- "webről"
- "háttér"
- "PNG hozzáadása"
- "JPG hozzáadása"
- "SVG hozzáadása"
- "külső SVG erőforrások"
- "SVG feloldó"
- "kapcsolt SVG képek"
- "SVG betűtípusok"
- "EMF hozzáadása"
- "WMF hozzáadása"
- "TIFF hozzáadása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Az Aspose.Slides for Java segítségével egyszerűsítse a képek kezelését PowerPoint és OpenDocument esetén, optimalizálja a teljesítményt és automatizálja a munkafolyamatot."
---
## **Bevezetés**

A képek a prezentációkat érdekesebbé és vizuálisan vonzóbbá teszik. A Microsoft PowerPointban képeket szúrhat be a diákra fájlokból, az internetről vagy más forrásokból. Hasonlóan, az Aspose.Slides lehetővé teszi, hogy képeket adjon hozzá a prezentáció diáihoz többféleképpen.

{{% alert  title="Tip" color="primary" %}} 
Az Aspose ingyenes konvertereket kínál — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyek gyorsan lehetővé teszik, hogy képekből prezentációkat hozzon létre. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Ha képet szeretne képkockaként hozzáadni – különösen ha átméretezni, effektusokat alkalmazni vagy más szabványos formázási beállításokat használni tervez – lásd a [Picture Frame](/slides/hu/java/picture-frame/) oldalt. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Konvertálhat képeket egyik formátumból a másikba. Lásd a következő oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hu/java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hu/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hu/java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hu/java/conversion/png-to-svg/), és [SVG to PNG](https://products.aspose.com/slides/hu/java/conversion/svg-to-png/).
{{% /alert %}}

Az Aspose.Slides a népszerű formátumokban, például JPEG, PNG, BMP, GIF és egyéb képeket támogat.

## **Képek helyi tárolásból való hozzáadása a diákhoz**

Képet vagy több képet adhat hozzá a számítógépén tárolt képeket egy prezentációs diához. Az alábbi Java mintakód bemutatja, hogyan lehet képet hozzáadni egy diához:

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

## **Képek hozzáadása a webről a diákhoz**

Ha a diára felvenni kívánt kép nincs a számítógépén, közvetlenül a webről is hozzáadhatja.

Az alábbi Java mintakód bemutatja, hogyan lehet képet a webről hozzáadni egy diához:

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

## **Képek hozzáadása a dia-mesterekhez**

A dia-mester tárolja és szabályozza az információkat, például a témát és az elrendezést azoknak a diáknak, amelyek ezt használják. Ha képet ad hozzá egy dia-mesterhez, a kép megjelenik minden, az adott mester alapján készült dián.

Az alábbi Java mintakód bemutatja, hogyan lehet képet hozzáadni egy dia-mesterhez:

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

## **Képek hozzáadása dia háttérként**

Képet használhat egy vagy több dia háttérként. Részletekért lásd a *[Setting Images as Backgrounds for Slides](/slides/hu/java/presentation-background/#setting-images-as-background-for-slides)* oldalt.

## **SVG hozzáadása a prezentációkhoz**

Az SVG tartalmat a [SvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgimage/) osztály használatával adhatja hozzá a prezentációhoz. A keletkezett [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) objektum ezután hozzáadható a prezentáció képgyűjteményéhez, és használható képkocka létrehozásához.

Az alábbi Java példa egy önálló SVG karakterláncot importál. Az SVG által használt összes kép, stílus és egyéb erőforrás közvetlenül az SVG tartalomba van ágyazva.

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

## **SVG tartalom importálása külső erőforrásokkal**

A tervezőeszközök, diagram szerkesztők, ikon rendszerek és webes csővezetékek által exportált SVG fájlok hivatkozhatnak az SVG dokumentumon kívül tárolt erőforrásokra. Például egy SVG tartalmazhat kép hivatkozást, mint `images/photo.png`, egy CSS `url(...)` értéket vagy egy betűtípus URL-t.

Az ilyen SVG tartalom importálásához hozzon létre egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iexternalresourceresolver/) megvalósítást, és adja át, a bázis URI-val együtt, egy megfelelő [SvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgimage/) konstruktorának. A bázis URI az SVG dokumentum helyét azonosítja, és a relatív hivatkozások feloldására szolgál.

A [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) interfész hozzáférést biztosít az importált SVG-re vonatkozó információkhoz:

- `getSvgContent()` visszaadja az SVG markupot karakterláncként.
- `getSvgData()` visszaadja az SVG tartalmat bájt tömbként.
- `getBaseUri()` visszaadja a relatív hivatkozásokhoz használt bázis URI-t.
- `getExternalResourceResolver()` visszaadja az SVG képhez rendelt erőforrás-feloldót.

### **Külső erőforrás-feloldó implementálása**

A feloldónak két metódusa van:

- `resolveUri` kombinálja a bázis URI-t és egy relatív erőforrás hivatkozást, és visszaad egy abszolút URI-t. `null`-t ad vissza, ha a hivatkozás nem oldható fel vagy nem megengedett.
- `getEntity` visszaad egy olvasható stream-et egy abszolút erőforrás URI-hez. `null`-t ad vissza, ha az erőforrás hiányzik, blokkolva van vagy nem elérhető. Szükség esetén egy tartalék stream is visszaadható.

Az alábbi feloldó csak egy engedélyezett helyi könyvtárból tölti be a kapcsolt erőforrásokat. A hálózati erőforrások és az engedélyezett könyvtáron kívüli útvonalak blokkolva vannak. Egy opcionális tartalék kép van visszaadva a feloldatlan kép hivatkozásokhoz.

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

            // Ez a feloldó szándékosan csak helyi fájlokat engedélyez.
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

            // Csak kép erőforrások esetén használjon tartalékot. Kép stream visszaadása
            // hiányzó betűtípus vagy stíluslap esetén nem lenne érvényes.
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

### **Kapcsolt erőforrások feloldása SVG importálása során**

Tegyük fel, hogy a `assets/diagram.svg` relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi Java példa a SVG fájl URI-t bázis URI-ként adja át, és egy egyedi feloldót biztosít. A feloldó a relatív kép hivatkozást átalakítja abszolút URI-vé, és visszaad egy stream-et, amely a kapcsolt erőforrást tartalmazza, miközben az Aspose.Slides feldolgozza az SVG-t.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// A bázis URI a SVG dokumentum helyét jelöli.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
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

A `SvgImage` osztály további túlterheléseket is biztosít, amelyek SVG adatot bájt tömbként vagy bemeneti streamként fogadnak, egy külső erőforrás-feloldóval és egy bázis URI-val együtt.

{{% alert title="Important" color="warning" %}}
Az erőforrás-feloldó a külső erőforrásokat elérhetővé teszi, amíg az Aspose.Slides feldolgozza és rendereli az SVG-t. Nem módosítja az eredeti SVG markupot, és nem ágyazza be automatikusan a feloldott erőforrásokat.

Amikor egy `ISvgImage` kerül hozzáadásra a prezentáció képgyűjteményéhez, a PPTX fájl tartalmazhatja az eredeti SVG ábrázolást és egy raszteres tartalék képet is. Egy kapcsolt erőforrás megjelenhet a generált tartalék képen, míg egy relatív hivatkozás, például `images/photo.png` változatlan marad a tárolt SVG-ben. Egy olyan alkalmazás, amely a natív SVG ábrázolást rendereli, ezért kihagyhatja a kapcsolt tartalmat, ha az eredeti külső erőforrás nem érhető el.
{{% /alert %}}

### **Hordozható SVG kép létrehozása**

Hogy olyan SVG képet hozzon létre, amely nem függ külső fájloktól, tegye az SVG-t önállóvá a `SvgImage` létrehozása előtt. Például cserélje le a kapcsolt kép URL-eket `data:` URI-kká, amelyek a kép adatát tartalmazzák:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután az összes szükséges erőforrás be van ágyazva az SVG tartalomba, hozza létre a `SvgImage`-t, adja hozzá a prezentáció képgyűjteményéhez, és helyezze be egy képkockába, ahogyan az előző példában is.

### **Hiányzó vagy blokkolt erőforrások kezelése**

Adjon vissza `null`-t a `resolveUri`-ból, ha egy erőforrás URI érvénytelen, tiltott vagy nem oldható fel. Adjon vissza `null`-t a `getEntity`-ből, ha az erőforrást nem lehet beolvasni. Az Aspose.Slides lehetőség szerint az erőforrás nélkül folytatja az SVG feldolgozását.

Egy tartalék stream visszaadható hiányzó erőforrás esetén, de tartalmának kompatibilisnek kell lennie a kért erőforrás típusával. Például csak képet streamként adjon vissza hiányzó kép esetén, nem betűtípust vagy stíluslapot.

{{% alert title="Security" color="warning" %}}
Ne oldjon fel tetszőleges fájlelérési útvonalakat vagy korlátlan hálózati URL-eket megbízhatatlan SVG fájlokból. Szűkítse a megengedett sémákat, könyvtárakat és hostokat. Hálózati erőforrások esetén alkalmazzon kapcsolat-időkorlátot, válaszméret limitet és tartalomvalidációt.
{{% /alert %}}

## **SVG konvertálása alakzatkészletre**

Az Aspose.Slides képes egy SVG-t alakzatkészletre konvertálni, hasonlóan a PowerPoint megfelelő funkciójához:

![PowerPoint Popup Menu](img_01_01.png)

Ez a funkció a [addGroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metódus túlterhelésével érhető el az [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) interfészben, amely első argumentumként egy [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISvgImage) objektumot vár.

Az alábbi Java mintakód bemutatja, hogyan kell használni ezt a metódust egy SVG fájl alakzatkészletté konvertálásához:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// A forrás SVG fájl neve.
String svgFileName = "sample.svg";

// A kimeneti prezentáció fájl neve.
String outPptxPath = "presentation.pptx";

// Új prezentáció létrehozása.
IPresentation presentation = new Presentation();
try {
    // A SVG fájl tartalmának beolvasása.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // SvgImage objektum létrehozása.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Diák méretének lekérése.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Az SVG képet alakzatcsoporttá konvertálja és a dia méretéhez méretezi.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // A prezentáció mentése PPTX formátumban.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Képek hozzáadása EMF formátumban a diákhoz**

Az Aspose.Slides for Java lehetővé teszi, hogy EMF képeket generáljon Excel munkalapokból az Aspose.Cells segítségével, és hozzáadja őket a prezentáció diáihoz.

Az alábbi Java mintakód bemutatja, hogyan kell ezt megtenni:

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

// A munkafüzet mentése egy adatfolyamra.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // A fájl hozzáadása változtatás nélkül, hogy a kép vektor EMF formában maradjon, a raszterizálás helyett.
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

## **Képek cseréje a képgyűjteményben**

Az Aspose.Slides lehetővé teszi a prezentáció képgyűjteményében tárolt képek cseréjét, beleértve a diák alakzatai által használt képeket is. Ez a rész több módot ismertet a képek frissítésére a gyűjteményben. Képet cserélhet nyers bájt adat, egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) példány, vagy a gyűjteményben már meglévő másik kép használatával.

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó prezentációfájlt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály használatával.  
2. Töltsön be egy új képet egy fájlból bájt tömbbe.  
3. Cserélje ki a célképet az új képre a bájt tömb használatával.  
4. A második megközelítésben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektumba, és cserélje ki a célképet ezzel az objektummal.  
5. A harmadik megközelítésben cserélje ki a célképet egy olyan képpel, amely már létezik a prezentáció képgyűjteményében.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Az első módszer.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // A második módszer.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // A harmadik módszer.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Mentse a prezentációt fájlba.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Az Aspose ingyenes [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterével könnyedén animálhat szöveget és GIF-eket hozhat létre szövegből. 
{{% /alert %}}

## **GYIK**

**Megmarad az eredeti kép felbontása a beillesztés után?**

Igen. A forráspixel megtartásra kerül, de a végső megjelenés attól függ, hogyan van a [picture](/slides/hu/java/picture-frame/) méretezve a dián és milyen tömörítés kerül alkalmazásra a mentéskor.

**Mi a legjobb módja annak, hogy egyszerre cseréljünk ki egy logót több tucat dián?**

Helyezze a logót a master diára vagy egy elrendezésre, és cserélje ki a prezentáció képgyűjteményében – a frissítések minden olyan elemre kiterjednek, amely ezt az erőforrást használja.

**Konvertálható egy beillesztett SVG szerkeszthető alakzatokká?**

Igen. Az SVG-t alakzatcsoporttá konvertálhatja, ezután az egyes részek szerkeszthetőek lesznek a szokásos alakzattulajdonságokkal.

**Hogyan állíthatok be egy képet több dia háttérként egyszerre?**

A [Assign the image as the background](/slides/hu/java/presentation-background/) a master dián vagy a megfelelő elrendezésen; minden, azt a mastert/elrendezést használó dia örökli a hátteret.

**Hogyan akadályozhatom, hogy a prezentáció túl nagyra nőjen a sok kép miatt?**

Használjon egyetlen kép erőforrást a másolatok helyett, válasszon ésszerű felbontásokat, alkalmazzon tömörítést mentéskor, és ismétlődő grafikákat helyezzen a masterre, ahol megfelelő.