---
title: "Képek kezelése a prezentációkban Java-val"
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
- "hivatkozott SVG képek"
- "SVG betűtípusok"
- "EMF hozzáadása"
- "WMF hozzáadása"
- "TIFF hozzáadása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Egyszerűsítse a képek kezelését PowerPoint és OpenDocument esetén az Aspose.Slides for Java segítségével, optimalizálja a teljesítményt és automatizálja a munkafolyamatát."
---
## **Bevezetés**

A képek a bemutatókat vonzóbbá és vizuálisan szebbé teszik. A Microsoft PowerPointban képeket szúrhat be a diákra fájlokból, az internetről vagy egyéb forrásokból. Hasonlóan, az Aspose.Slides lehetővé teszi, hogy különböző módokon képeket adjon hozzá a prezentációs diákhoz.

{{% alert  title="Tipp" color="info" %}} 

Az Aspose ingyenes konvertereket kínál—[JPEG a PowerPoint-be](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG a PowerPoint-be](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy gyorsan készítsen bemutatókat a képekből. 

{{% /alert %}} 

{{% alert title="Információ" color="info" %}}

Ha képet szeretne képként keretbe helyezni—különösen ha átméretezni, hatásokat alkalmazni vagy egyéb szabványos formázási lehetőségeket használni kíván—tekintse meg a [Képkeret](/slides/hu/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Megjegyzés" color="warning" %}}

Képeket konvertálhat az egyik formátumból a másikba. Lásd a következő oldalakat: konvertálás [kép JPG-re](https://products.aspose.com/slides/hu/java/conversion/image-to-jpg/), [JPG képre](https://products.aspose.com/slides/hu/java/conversion/jpg-to-image/), [JPG PNG-re](https://products.aspose.com/slides/hu/java/conversion/jpg-to-png/), [PNG JPG-re](https://products.aspose.com/slides/hu/java/conversion/png-to-jpg/), [PNG SVG-re](https://products.aspose.com/slides/hu/java/conversion/png-to-svg/), valamint [SVG PNG-re](https://products.aspose.com/slides/hu/java/conversion/svg-to-png/).

{{% /alert %}}

Az Aspose.Slides támogatja a népszerű képtformátumokat, mint például a JPEG, PNG, BMP, GIF és mások. 

## **Helyileg tárolt képek hozzáadása a diákhoz**

Képet vagy több képet adhat hozzá a számítógépén tárolt képekből egy prezentációs diára. Az alábbi Java példakód bemutatja, hogyan adjon képet egy diához:

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

## **Képek hozzáadása a webből a diákhoz**

Ha a diára felvenni kívánt kép nincs a számítógépén, közvetlenül a webről is hozzáadhatja.

Az alábbi Java példakód bemutatja, hogyan adjon képet a webről egy diához:

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

## **Képek hozzáadása diák‑mesterhez**

A diák‑mester tárolja és szabályozza a témát és elrendezést a rá épülő diák számára. Ha képet ad hozzá egy diák‑mesterhez, a kép minden, az adott mesterre épülő dián megjelenik.

Az alábbi Java példakód bemutatja, hogyan adjon képet egy diák‑mesterhez:

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

## **Képek hozzáadása diák háttérként**

Egy vagy több dia háttérként használhat képet. Részletekért tekintse meg a *[Képek beállítása háttérként a diákhoz](/slides/hu/java/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG hozzáadása a prezentációkhoz**

Az SVG tartalmat hozzáadhatja egy prezentációhoz a [SvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgimage/) osztály használatával. A kapott [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) objektum ezután hozzáadható a prezentáció képgyűjteményéhez, és képkeret létrehozására használható.

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

A tervezőeszközök, diagramkészítők, ikonrendszerek és webes folyamatok által exportált SVG‑fájlok hivatkozhatnak a dokumentumon kívül tárolt erőforrásokra. Például egy SVG tartalmazhat egy képhivatkozást, mint `images/photo.png`, egy CSS `url(...)` értéket vagy egy betűkészlet‑URL‑t.

Az ilyen SVG‑tartalom importálásához hozza létre egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iexternalresourceresolver/) megvalósítást, és adja át egy alap‑URI‑val együtt a megfelelő [SvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgimage/) konstruktorának. Az alap‑URI határozza meg az SVG‑dokumentum helyét, és a relatív hivatkozások feloldásához használatos.

Az [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgimage/) interfész hozzáférést biztosít az importált SVG információihoz:

- `getSvgContent()` visszaadja az SVG markup‑ot karakterláncként.
- `getSvgData()` visszaadja az SVG tartalmat bájt‑tömbként.
- `getBaseUri()` visszaadja a relatív hivatkozásokhoz használt alap‑URI‑t.
- `getExternalResourceResolver()` visszaadja az SVG képhez rendelt resolver‑t.

### **Külső erőforrás-Resolver megvalósítása**

A resolver két metódussal rendelkezik:

- `resolveUri` egyesíti az alap‑URI‑t és egy relatív erőforrás‑hivatkozást, majd visszaad egy abszolút URI‑t. `null`‑t adjon vissza, ha a hivatkozás nem oldható fel vagy nem engedélyezett.
- `getEntity` visszaad egy olvasható streamet egy abszolút erőforrás‑URI‑hoz. `null`‑t adjon vissza, ha az erőforrás hiányzik, blokkolt vagy nem elérhető. Szükség esetén egy tartalék stream is visszaadható.

Az alábbi resolver csak egy engedélyezett helyi könyvtárból tölti be a hivatkozott erőforrásokat. Hálózati erőforrások és az engedélyezett könyvtáron kívüli útvonalak blokkolva vannak. Egy opcionális tartalék kép visszaadásra kerül a feloldhatatlan kép‑hivatkozásoknál.

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

            // Ez a feloldó szándékosan csak helyi fájlok használatát engedélyezi.
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

            // Csak kép erőforrásokhoz használjon tartalékot. Képfolyam visszaadása
            // Hiányzó betűkészlet vagy stíluslap esetén ez nem lenne érvényes.
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

### **Kötött erőforrások feloldása SVG importálás közben**

Tegyük fel, hogy a `assets/diagram.svg` egy relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi Java példa a SVG‑fájl URI‑t alap‑URI‑ként adja át, és egy egyéni resolver‑t biztosít. A resolver a relatív kép‑hivatkozást abszolút URI‑vá alakítja, és egy olyan streamet ad vissza, amely a hivatkozott erőforrást tartalmazza, miközben az Aspose.Slides a SVG‑t feldolgozza.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// A base URI az SVG dokumentum helyét jelöli.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// Az ISvgImage a forrás tartalmat, bináris adatot, base URI-t és a feloldót teszi elérhetővé.
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

A `SvgImage` osztály további túlterheléseket is biztosít, amelyek SVG adatot fogadnak bájt‑tömbként vagy bemeneti stream‑ként, valamint egy külső erőforrás‑resolver‑t és egy alap‑URI‑t.

{{% alert title="Fontos" color="warning" %}}

Az erőforrás‑resolver külső erőforrásokat tesz elérhetővé, amíg az Aspose.Slides a SVG‑t feldolgozza és rendereli. Nem módosítja az eredeti SVG markup‑ot, és nem ágyazza be automatikusan a feloldott erőforrásokat.

Amikor egy `ISvgImage` hozzáadásra kerül a prezentáció képgyűjteményéhez, a PPTX‑fájl tartalmazhatja az eredeti SVG ábrázolást és egy raszteres tartalék képet is. Egy hivatkozott erőforrás megjelenhet a generált tartalék képen, míg egy relatív hivatkozás, például `images/photo.png` változatlan marad a tárolt SVG‑ben. A natív SVG‑ábrázolást renderelő alkalmazás ezért kihagyhatja a hivatkozott tartalmat, ha az eredeti külső erőforrás nem érhető el.

{{% /alert %}}

### **Hordozható SVG kép létrehozása**

Hordozható SVG képet csak úgy hozhat létre, ha az SVG-t önállóvá teszi, mielőtt a `SvgImage`‑t létrehozná. Például cserélje le a hivatkozott kép‑URL‑ket `data:` URI‑kra, amelyek a kép adatát tartalmazzák:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután minden szükséges erőforrás be van ágyazva az SVG tartalomba, hozza létre a `SvgImage`‑t, adja hozzá a prezentáció képgyűjteményéhez, és szúrja be képkeretként, ahogyan az előző példában látható.

### **Hiányzó vagy blokkolt erőforrások kezelése**

`resolveUri`‑ból térjen vissza `null`‑val, ha az erőforrás‑URI érvénytelen, tiltott vagy nem oldható fel. `getEntity`‑ből térjen vissza `null`‑val, ha az erőforrás nem olvasható. Az Aspose.Slides a lehető legjobban folytatja az SVG feldolgozását az adott erőforrás nélkül.

Tartalék stream visszaadható egy hiányzó erőforrás esetén, de annak tartalma kompatibilis kell legyen a kért erőforrás típusával. Például csak kép‑streamet adjon vissza hiányzó képhez, nem betűkészlethez vagy stíluslaphoz.

{{% alert title="Biztonság" color="warning" %}}

Ne oldjon fel önkényes fájlútvonalakat vagy korlátlan hálózati URL‑ket nem megbízható SVG‑fájlokból. Korlátozza az engedélyezett sémákat, könyvtárakat és hostokat. Hálózati erőforrások esetén alkalmazzon kapcsolat‑időkorlátokat, válasz‑méret‑korlátokat és tartalom‑validációt.

{{% /alert %}}

## **SVG konvertálása alakzatkészletté**

![PowerPoint Popup Menu](img_01_01.png)

Ez a funkció a [addGroupShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metódus egy túlterhelésén keresztül érhető el az [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) interfészen, amely első paramétereként egy [ISvgImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISvgImage) objektumot vár.

Az alábbi Java példakód bemutatja, hogyan használja ezt a metódust egy SVG‑fájl alakzatkészletté konvertálásához:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Az SVG forrásfájl neve.
String svgFileName = "sample.svg";

// A kimeneti prezentáció fájlneve.
String outPptxPath = "presentation.pptx";

// Új prezentáció létrehozása.
IPresentation presentation = new Presentation();
try {
    // Olvassa be az SVG fájl tartalmát.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // SvgImage objektum létrehozása.
    ISvgImage svgImage = new SvgImage(svgContent);

    // A dia méretének lekérése.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Az SVG képet alakzatcsoporttá konvertálja, és a dia méretére méretezi.
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

## **Képek hozzáadása EMF‑ként a diákhoz**

Az Aspose.Slides for Java lehetővé teszi, hogy EMF képeket generáljon Excel munkalapokból az Aspose.Cells segítségével, és azokat prezentációs diákhoz adja.

Az alábbi Java példakód bemutatja, hogyan teheti ezt:

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

// A munkafüzet mentése egy adatfolyamba.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // A fájlt változatlanul hozzáadja, így a kép vektoros EMF marad, nem kerül raszterizálásra.
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

Az Aspose.Slides lehetővé teszi a prezentáció képgyűjteményében tárolt képek cseréjét, beleértve a diák alakzatai által használt képeket is. Ez a szakasz több módot mutat be a képek frissítésére a gyűjteményben. Képet cserélhet nyers bájt‑adatokkal, egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) példánnyal, vagy egy már a gyűjteményben létező képpel.

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó prezentációs fájlt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztály segítségével.
2. Töltsön be egy új képet fájlból egy bájt‑tömbbe.
3. Cserélje le a célképet az új képre a bájt‑tömb használatával.
4. A második módszernél töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/) objektumba, és cserélje le a célképet ezzel az objektummal.
5. A harmadik módszernél cserélje le a célképet egy olyan képre, amely már létezik a prezentáció képgyűjteményében.
6. Írja ki a módosított prezentációt PPTX fájlként.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
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

    // A prezentáció mentése fájlba.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Az Aspose ingyenes [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterével könnyedén animálhat szöveget és készíthet GIF‑eket szövegből. 

{{% /alert %}}

## **GYIK**

**Megmarad a képek eredeti felbontása a beszúrás után?**

Igen. A forrás‑pixelek megmaradnak, de a végleges megjelenés attól függ, hogyan van a [kép](/slides/hu/java/picture-frame/) méretezve a dián és milyen tömörítést alkalmaz a mentéskor.

**Mi a legjobb módja annak, hogy egyszerre cseréljünk ki ugyanazt a logót több tucat dián?**

Helyezze a logót a mester‑diára vagy egy elrendezésre, és cserélje le a prezentáció képgyűjteményében—az frissítések minden, az erőforrást használó elemre kihatnak.

**Átalakítható‑e egy beszúrt SVG szerkeszthető alakzatokká?**

Igen. Egy SVG‑t konvertálhat egy alakzatcsoporttá, amelynek egyes részei ezután szerkeszthetők a szokásos alakzattulajdonságokkal.

**Hogyan állíthatok be egy képet háttérként egyszerre több diára?**

[Állítsa be a képet háttérként](/slides/hu/java/presentation-background/) a mester‑dián vagy a megfelelő elrendezésen—bármely dia, amely azt a mestert/elrendezést használja, örökli a hátteret.

**Hogyan akadályozhatom meg, hogy a prezentáció túl nagyra nő a sok kép miatt?**

Használjon egyetlen képforrást a többszörös példányok helyett, válasszon ésszerű felbontást, alkalmazzon tömörítést mentéskor, és ahol megfelelő, a gyakran ismétlődő grafikákat a mesterben tartsa.