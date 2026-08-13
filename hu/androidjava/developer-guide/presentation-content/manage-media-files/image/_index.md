---
title: Képek kezelésének optimalizálása prezentációkban Androidon
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/androidjava/image/
keywords:
- kép hozzáadása
- kép hozzáadása
- bitmap hozzáadása
- kép cseréje
- kép cseréje
- webről
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- külső SVG erőforrások
- SVG feloldó
- linkelt SVG képek
- SVG betűtípusok
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Android Java segítségével egyszerűsíti a képek kezelését a PowerPoint és az OpenDocument formátumokban, optimalizálja a teljesítményt és automatizálja a munkafolyamatát."
---
## **Bevezetés**

A képek a bemutatókat vonzóbbá és vizuálisan szebbé teszik. A Microsoft PowerPointban a képeket fájlokból, az internetről vagy egyéb forrásokból szúrhatja be a diákra. Hasonlóan az Aspose.Slides lehetővé teszi, hogy különböző módokon adjunk képeket a prezentáció diákhoz.

{{% alert  title="Tip" color="info" %}} 
Az Aspose ingyenes konvertereket biztosít—[JPEG PowerPointba](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG PowerPointba](https://products.aspose.app/slides/hu/import/png-to-ppt)—amelyek lehetővé teszik, hogy gyorsan prezentációkat hozzon létre képekből. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Ha egy képet képként szeretne hozzáadni—különösen, ha átméretezést, effektusok alkalmazását vagy egyéb szabványos formázási beállításokat tervez—tekintse meg a [Képkeret](/slides/hu/androidjava/picture-frame/) oldalt. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Képeket átalakíthat egyik formátumból a másikba. Tekintse meg a következő oldalakat: [image to JPG](https://products.aspose.com/slides/hu/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hu/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hu/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hu/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hu/androidjava/conversion/png-to-svg/), és [SVG to PNG](https://products.aspose.com/slides/hu/androidjava/conversion/svg-to-png/). 
{{% /alert %}}

Az Aspose.Slides népszerű formátumokban, például JPEG, PNG, BMP, GIF és egyéb képeket támogat.

## **Helyben tárolt képek hozzáadása a diákhoz**

Egy vagy több, a számítógépén tárolt képet hozzáadhat egy prezentáció diájához. Az alábbi Java mintakód mutatja, hogyan adjon képet egy diához:

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

Ha a diára hozzáadni kívánt kép nincs a számítógépén tárolva, közvetlenül a webről adhatja hozzá.

Az alábbi Java mintakód mutatja, hogyan adjon képet a webről egy diához:

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

## **Képek hozzáadása a diamesterekhez**

A diamester tárolja és szabályozza az olyan információkat, mint a téma és az elrendezés azokhoz a diákhoz, amelyek ezt használják. Ha képet ad hozzá egy diamesterhez, a kép megjelenik minden, arra a mesterre épülő dián.

Az alábbi Java mintakód mutatja, hogyan adjon képet egy diamesterhez:

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

Használhat képet egy vagy több dia háttérként. A részletekért lásd a *[Képek beállítása diák háttérként](/slides/hu/androidjava/presentation-background/#setting-images-as-background-for-slides)* oldalt.

## **SVG hozzáadása a prezentációkhoz**

Az SVG tartalmat a [SvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgimage/) osztály segítségével adhatja hozzá a prezentációhoz. A keletkező [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) objektum ezután hozzáadható a prezentáció képgyűjteményéhez, és képkeret létrehozására használható.

Az alábbi Java példa egy önálló SVG karakterláncot importál. Az SVG által használt összes kép, stílus és egyéb erőforrás közvetlenül az SVG tartalomban van beágyazva.

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

A tervezőeszközök, diagram szerkesztők, ikon rendszerek és webes folyamatok által exportált SVG fájlok hivatkozhatnak az SVG dokumentumon kívül tárolt erőforrásokra. Például egy SVG tartalmazhat kép hivatkozást, mint `images/photo.png`, egy CSS `url(...)` értéket, vagy egy betűtípus URL-t.

Az ilyen SVG tartalom importálásához hozzon létre egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iexternalresourceresolver/) megvalósítást, és adja át, a bázis URI-val együtt, egy megfelelő [SvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgimage/) konstruktorának. A bázis URI az SVG dokumentum helyét jelöli, és a relatív hivatkozások feloldásához használják.

Az [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) interfész hozzáférést biztosít az importált SVG információihoz:

- `getSvgContent()` visszaadja az SVG jelölést karakterláncként.
- `getSvgData()` visszaadja az SVG tartalmat bájt tömbként.
- `getBaseUri()` visszaadja a relatív hivatkozásokhoz használt bázis URI-t.
- `getExternalResourceResolver()` visszaadja a SVG képhez rendelt feloldót.

### **Külső erőforrás feloldó megvalósítása**

A feloldónak két metódusa van:

- `resolveUri` kombinálja a bázis URI-t és egy relatív erőforrás hivatkozást, és abszolút URI-t ad vissza. `null` értéket ad vissza, ha a hivatkozás nem oldható fel vagy nem engedélyezett.
- `getEntity` egy olvasható streamet ad egy abszolút erőforrás URI-hez. `null` értéket ad vissza, ha az erőforrás hiányzik, blokkolva van vagy nem elérhető. Szükség esetén visszaadható egy tartalék (fallback) stream is.

Az alábbi feloldó csak egy engedélyezett helyi könyvtárból tölti be a hivatkozott erőforrásokat. Hálózati erőforrások és az engedélyezett könyvtáron kívüli útvonalak blokkolva vannak. Egy opcionális tartalék kép visszaadható feloldatlan kép hivatkozásokhoz.

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

            // Csak képfájlokhoz használjon tartalékot. Kép stream visszaadása
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

### **Linkelt erőforrások feloldása SVG importálás közben**

Tegyük fel, hogy `assets/diagram.svg` relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi Java példa a SVG fájl URI-ját adja át bázis URI‑ként, és saját feloldót biztosít. A feloldó a relatív képhivatkozást abszolút URI‑vá alakítja, és egy streamet ad vissza, amely a hivatkozott erőforrást tartalmazza, miközben az Aspose.Slides feldolgozza az SVG‑t.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Az alap URI a SVG dokumentum helyét jelenti.
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

A `SvgImage` osztály további túlterheléseket (overloads) is biztosít, amelyek SVG adatot bájt tömbként vagy bemeneti streamként fogadnak, egy külső erőforrás feloldóval és egy bázis URI‑val együtt.

{{% alert title="Important" color="warning" %}}
Az erőforrás feloldó a külső erőforrásokat a SVG feldolgozása és renderelése közben elérhetővé teszi az Aspose.Slides számára. Nem módosítja az eredeti SVG jelölést, és nem ágyazza be automatikusan a feloldott erőforrásokat.

Amikor egy `ISvgImage` hozzáadásra kerül a prezentáció képgyűjteményéhez, a PPTX fájl tartalmazhatja az eredeti SVG ábrázolást és egy raszteres tartalék képet is. Egy hivatkozott erőforrás megjelenhet a generált tartalék képen, míg egy relatív hivatkozás, például `images/photo.png`, változatlan marad a tárolt SVG‑ben. Egy natív SVG ábrázolást renderelő alkalmazás ezért kihagyhatja a hivatkozott tartalmat, ha az eredeti külső erőforrás nem érhető el.
{{% /alert %}}

### **Hordozható SVG kép létrehozása**

Az SVG‑t hordozhatóvá tehetjük úgy, hogy a `SvgImage` létrehozása előtt önállóvá tesszük. Például cserélje le a hivatkozott kép URL‑eket `data:` URI‑kra, amelyek tartalmazzák a kép adatát:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután az összes szükséges erőforrás be van ágyazva az SVG tartalomba, hozza létre a `SvgImage`‑t, adja hozzá a prezentáció képgyűjteményéhez, és illessze be egy képkeretbe, ahogyan az előző példában látható.

### **Hiányzó vagy blokkolt erőforrások kezelése**

`null` értékkel térjen vissza a `resolveUri`‑ból, ha egy erőforrás URI érvénytelen, tiltott vagy nem oldható fel. `null` értékkel térjen vissza a `getEntity`‑ből, ha az erőforrás nem olvasható. Az Aspose.Slides lehetőleg az erőforrás nélkül folytatja az SVG feldolgozását.

Egy tartalék stream visszaadható hiányzó erőforrás esetén, de annak tartalma kompatibilis kell legyen a kért erőforrás típusával. Például csak egy kép streamet adjon vissza hiányzó képhez, nem betűtípushoz vagy stíluslaphoz.

{{% alert title="Security" color="warning" %}}
Ne oldjon fel tetszőleges fájl útvonalakat vagy korlátlan hálózati URL‑ket megbízhatatlan SVG fájlokból. Korlátozza az engedélyezett sémákat, könyvtárakat és hostokat. Hálózati erőforrások esetén alkalmazzon kapcsolat-időkorlátot, válaszméret‑korlátot és tartalom‑validációt.
{{% /alert %}}

## **SVG konvertálása alakzatkészletté**

Az Aspose.Slides képes egy SVG‑t alakzatkészleté konvertálni, hasonlóan a PowerPoint megfelelő funkciójához:

![PowerPoint felugró menü](img_01_01.png)

Ez a funkció egy [addGroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metódus egy túlterhelésén keresztül érhető el az [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) interfészben, amely első argumentumként egy [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISvgImage) objektumot fogad.

Az alábbi Java mintakód mutatja, hogyan használja ezt a metódust egy SVG fájl alakzatkészletté konvertálásához:

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
    // Az SVG fájl tartalmának beolvasása.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // SvgImage objektum létrehozása.
    ISvgImage svgImage = new SvgImage(svgContent);

    // A dia méretének lekérése.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Az SVG képet alakzatcsoporttá konvertálja és a dia méretéhez méretez.
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

Az Androidra készült Aspose.Slides Java segítségével lehetővé teszi, hogy az Aspose.Cells használatával Excel munkalapokból EMF képeket generáljon, és ezeket a prezentáció diáihoz adja.

Az alábbi Java mintakód mutatja, hogyan teheti ezt:

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

        // A fájlt úgy adjuk hozzá, ahogy van, hogy a kép vektoros EMF marad, ahelyett, hogy raszterizálódna.
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

Az Aspose.Slides lehetővé teszi, hogy a prezentáció képgyűjteményében tárolt képeket, beleértve a dia alakzatok által használt képeket, cserélje. Ez a szakasz több módot ismertet a képek frissítésére a gyűjteményben. Képet cserélhet nyers bájtadatokkal, egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) példánnyal vagy egy már a gyűjteményben létező másik képpel.

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó prezentációs fájlt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztállyal.
2. Töltsön be egy új képet egy fájlból egy bájt tömbbe.
3. Cserélje le a célképet az új képre a bájt tömb használatával.
4. A második megközelítésben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektumba, és cserélje le a célképet ezzel az objektummal.
5. A harmadik megközelítésben cserélje le a célképet egy már a prezentáció képgyűjteményében létező képre.
6. Írja ki a módosított prezentációt PPTX fájlként.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Az első mód.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // A második mód.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // A harmadik mód.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // A prezentáció mentése egy fájlba.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Az Aspose ingyenes [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterével könnyedén animálhat szöveget és hozhat létre GIF-eket szövegből. 
{{% /alert %}}

## **GYIK**

**Megmarad-e az eredeti kép felbontása a beszúrás után?**

Igen. A forrásbitek megmaradnak, de a végső megjelenés attól függ, hogyan méretezi a [picture](/slides/hu/androidjava/picture-frame/) a dián, és milyen tömörítést alkalmaz a mentéskor.

**Mi a legjobb módja annak, hogy egyszerre több tucat dián ugyanazt a logót cseréljük?**

Helyezze a logót a mester diára vagy egy elrendezésre, és cserélje ki a prezentáció képgyűjteményében – a frissítések minden, azt az erőforrást használó elemre kiterjednek.

**Átalakítható‑e a beillesztett SVG szerkeszthető alakzatokká?**

Igen. Átalakíthat egy SVG‑t alakzatcsoporttá, ezután az egyes részek szerkeszthetőek a szokásos alakzattulajdonságokkal.

**Hogyan állíthatok be egy képet egyszerre több dia háttérként?**

[Állítsa be a képet háttérként](/slides/hu/androidjava/presentation-background/) a mester dián vagy a megfelelő elrendezésen – minden, azt a mester/elrendezés használó dia örökölni fogja a hátteret.

**Hogyan előzhetem meg, hogy egy prezentáció túl nagyra nő a sok kép miatt?**

Használja újra ugyanazt a kép erőforrást a duplikációk helyett, válasszon ésszerű felbontást, alkalmazzon tömörítést mentéskor, és ahol megfelelő, a gyakran használt grafikákat helyezze a mesterre.