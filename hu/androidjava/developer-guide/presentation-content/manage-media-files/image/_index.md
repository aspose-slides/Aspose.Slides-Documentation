---
title: "Képkezelés optimalizálása a prezentációkban Androidon"
linktitle: "Képek kezelése"
type: docs
weight: 10
url: /hu/androidjava/image/
keywords:
- "kép hozzáadása"
- "kép beillesztése"
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
- "linkelt SVG képek"
- "SVG betűtípusok"
- "EMF hozzáadása"
- "WMF hozzáadása"
- "TIFF hozzáadása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Egyszerűsítse a képek kezelését PowerPoint és OpenDocument dokumentumokban az Aspose.Slides for Android Java használatával, optimalizálva a teljesítményt és automatizálva a munkafolyamatát."
---
## **Bevezetés**

A képek a prezentációkat vonzóbbá és vizuálisan csábítóbbá teszik. A Microsoft PowerPointban képeket illeszthetsz a diákra fájlokból, az internetről vagy más forrásokból. Hasonlóan, az Aspose.Slides többféleképpen is lehetővé teszi képek hozzáadását a prezentáció diáira.

{{% alert  title="Tip" color="primary" %}} 
Az Aspose ingyenes konvertereket biztosít — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyekkel gyorsan készíthetsz prezentációkat képekből. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Ha egy képet képkockaként szeretnél hozzáadni — különösen, ha átméretezni, hatásokat alkalmazni vagy más szabványos formázási lehetőségeket használni tervezed — lásd a [Picture Frame](/slides/hu/androidjava/picture-frame/) oldalt. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Képeket átalakíthatsz egyik formátumból a másikba. Lásd az alábbi oldalakat: convert [image to JPG](https://products.aspose.com/slides/hu/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hu/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hu/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hu/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hu/androidjava/conversion/png-to-svg/), és [SVG to PNG](https://products.aspose.com/slides/hu/androidjava/conversion/svg-to-png/).
{{% /alert %}}

Az Aspose.Slides támogatja a népszerű képpformátumokat, mint a JPEG, PNG, BMP, GIF és mások. 

## **Helyileg tárolt képek hozzáadása diákhoz**

A számítógépedre mentett egy vagy több képet adhatod egy prezentációs diára. Az alábbi Java példakód bemutatja, hogyan adhatunk képet egy diához:

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

## **Képek hozzáadása a webről diákhoz**

Ha a diára felvenni kívánt kép nincs a számítógépedén, közvetlenül a webről adhatod hozzá.

Az alábbi Java példakód megmutatja, hogyan adhatunk képet a webről egy diához:

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

## **Képek hozzáadása diamesterekhez**

A diamester tárolja és vezérli az információkat, mint a téma és elrendezés a használó diák számára. Ha képet adsz hozzá egy diamesterhez, a kép minden azon a masteren alapuló dián megjelenik.

Az alábbi Java példakód mutatja, hogyan adjunk képet egy diamesterhez:

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

## **Képek hozzáadása diák háttérképként**

Képet használhatsz egy vagy több dia háttérként. Részletekért lásd a *[Setting Images as Backgrounds for Slides](/slides/hu/androidjava/presentation-background/#setting-images-as-background-for-slides)* oldalt.

## **SVG hozzáadása prezentációkhoz**

Az SVG tartalmat egy prezentációhoz a [SvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgimage/) osztály segítségével adhatod hozzá. A kapott [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) objektum ezután hozzáadható a prezentáció képgyűjteményéhez, és képkocka létrehozására használható.

Az alábbi Java példa egy önálló SVG karakterláncot importál. Az összes képet, stílust és egyéb erőforrást, amelyet ez az SVG használ, közvetlenül az SVG tartalomba ágyazza.

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

A tervezőeszközök, diagram szerkesztők, ikon rendszerek és webes folyamatokból exportált SVG fájlok hivatkozhatnak olyan erőforrásokra, amelyek az SVG dokumentumon kívül vannak tárolva. Például egy SVG tartalmazhat képhivatkozást, mint `images/photo.png`, egy CSS `url(...)` értéket vagy egy betűkészlet URL-t.

Az ilyen SVG tartalom importálásához hozz létre egy [IExternalResourceResolver](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iexternalresourceresolver/) implementációt, és add át, a bázis URI-val együtt, egy megfelelő [SvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgimage/) konstruktorának. A bázis URI az SVG dokumentum helyét azonosítja, és a relatív hivatkozások feloldásához használják.

Az [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgimage/) interfész hozzáférést biztosít az importált SVG információihoz:
- `getSvgContent()` visszaadja az SVG jelölőnyelvet karakterláncként.
- `getSvgData()` visszaadja az SVG tartalmat bájt tömbként.
- `getBaseUri()` visszaadja a relatív hivatkozásokhoz használt bázis URI-t.
- `getExternalResourceResolver()` visszaadja az SVG képhez rendelt feloldót.

### **Külső erőforrás feloldó implementálása**

A feloldónak két metódusa van:
- `resolveUri` a bázis URI-t és egy relatív erőforrás hivatkozást kombinálja, és abszolút URI-t ad vissza. Ha a hivatkozás nem oldható fel vagy nem engedélyezett, `null`-t adjon vissza.
- `getEntity` egy olvasható stream-et ad egy abszolút erőforrás URI-hoz. Ha az erőforrás hiányzik, blokkolt vagy nem elérhető, `null`-t adjon vissza. Egy tartalék stream is visszaadható, ha megfelelő.

Az alábbi feloldó csak a megengedett helyi könyvtárból tölti be a linkelt erőforrásokat. A hálózati erőforrások és a megengedett könyvtáron kívüli útvonalak blokkolva vannak. Egy opcionális tartalék kép visszaadódik a feloldhatatlan képhivatkozások esetén.

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

            // Csak képekre használjon tartalékot. Képadat stream visszaadása
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

### **Linkelt erőforrások feloldása SVG importálás során**

Tegyük fel, hogy a `assets/diagram.svg` egy relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi Java példa a SVG fájl URI-ját bázis URI-ként adja át, és egy egyedi feloldót biztosít. A feloldó a relatív képhivatkozást abszolút URI-vá alakítja, és egy stream-et ad vissza, amely a linkelt erőforrást tartalmazza, miközben az Aspose.Slides feldolgozza az SVG-t.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// A base URI a SVG dokumentum helyét jelöli.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// Az ISvgImage a forrás tartalmat, bináris adatokat, a base URI-t és a feloldót teszi elérhetővé.
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

A `SvgImage` osztály további túlterheléseket is biztosít, amelyek SVG adatot fogadnak bájt tömbként vagy bemeneti streamként, egy külső erőforrás feloldóval és egy bázis URI-val együtt.

{{% alert title="Important" color="warning" %}}
Az erőforrás feloldó elérhetővé teszi a külső erőforrásokat, amíg az Aspose.Slides feldolgozza és rendereli az SVG-t. Nem módosítja az eredeti SVG jelölőnyelvet, és nem ágyazza be automatikusan a feloldott erőforrásokat.

Amikor egy `ISvgImage` a prezentáció képgyűjteményéhez kerül, a PPTX fájl tartalmazhatja az eredeti SVG ábrázolást és egy raszteres tartalék képet is. Egy linkelt erőforrás megjelenhet a generált tartalék képen, míg egy relatív hivatkozás, például `images/photo.png`, változatlan marad a tárolt SVG-ben. Így egy natív SVG ábrázolást megjelenítő alkalmazás kihagyhatja a linkelt tartalmat, ha az eredeti külső erőforrás nem érhető el.
{{% /alert %}}

### **Hordozható SVG kép létrehozása**

Ahhoz, hogy olyan SVG képet hozzunk létre, amely nem függ külső fájloktól, tedd az SVG-t önállóvá a `SvgImage` létrehozása előtt. Például cseréld le a linkelt kép URL-eket `data:` URI‑kra, amelyek a képadatot tartalmazzák:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután az összes szükséges erőforrás be van ágyazva az SVG tartalomba, hozd létre a `SvgImage`-t, add hozzá a prezentáció képgyűjteményéhez, és szúrd be egy képkockába, ahogyan az előző példában is látható.

### **Hiányzó vagy blokkolt erőforrások kezelése**

Adj `null`-t a `resolveUri`-ból, ha egy erőforrás URI érvénytelen, tiltott vagy nem oldható fel. Adj `null`-t a `getEntity`-ből, ha az erőforrás nem olvasható. Az Aspose.Slides lehetőség szerint a hiányzó erőforrás nélkül folytatja az SVG feldolgozását.

Egy tartalék stream visszaadható hiányzó erőforrás esetén, de tartalma kompatibilis kell legyen a kért erőforrás típusával. Például csak képadat stream-et adj vissza hiányzó kép esetén, nem betűtípus vagy stíluslap esetén.

{{% alert title="Security" color="warning" %}}
Ne oldj fel tetszőleges fájl útvonalakat vagy korlátlan hálózati URL-eket megbízhatatlan SVG fájlokból. Korlatokba szorítsd a megengedett sémákat, könyvtárakat és hostokat. Hálózati erőforrások esetén alkalmazz kapcsolat időkorlátot, válaszméret korlátot és tartalomvalidációt.
{{% /alert %}}

## **SVG átalakítása alakzatsorozattá**

Az Aspose.Slides képes egy SVG-t alakzatsorozattá konvertálni, hasonlóan a PowerPoint megfelelő funkciójához:

![PowerPoint Popup Menu](img_01_01.png)

Ez a funkcionalitás a [addGroupShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) metódus túlterhelésével érhető el az [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) interfészen, amely egy [ISvgImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISvgImage) objektumot vesz első argumentumként.

Az alábbi Java példakód mutatja, hogyan használjuk ezt a metódust egy SVG fájl alakzatsorozattá konvertálásához:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// A forrás SVG fájl neve.
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

    // Az SVG képet alakzatsorozattá konvertálja és a dia méretére méretezi.
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

## **Képek hozzáadása EMF-ként diákhoz**

Az Aspose.Slides for Android Java-n keresztül lehetővé teszi, hogy EMF képeket generálj Excel munkalapokból az Aspose.Cells segítségével, és hozzáadd őket a prezentáció diáihoz.

Az alábbi Java példakód megmutatja, hogyan teheted ezt:

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

        // A fájlt változatlanul hozzáadja, hogy a kép vektoros EMF maradjon a rasterizálás helyett.
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

Az Aspose.Slides lehetővé teszi a prezentáció képgyűjteményében tárolt képek cseréjét, beleértve a diák alakzatai által használt képeket is. Ez a szakasz több módszert ír le a képek frissítésére a gyűjteményben. Képet cserélhetsz nyers bájt adatokkal, egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) példánnyal vagy egy már létező képpel a gyűjteményben.

Kövesd az alábbi lépéseket:
1. Töltsd be a képeket tartalmazó prezentációfájlt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztállyal.
1. Tölts be egy új képet egy fájlból bájt tömbbe.
1. Cseréld le a célképet az új képre a bájt tömb használatával.
1. A második módszerben töltsd be a képet egy [IImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iimage/) objektumba, és cseréld le a célképet ezzel az objektummal.
1. A harmadik módszerben cseréld le a célképet egy olyan képpel, amely már létezik a prezentáció képgyűjteményében.
1. Írd ki a módosított prezentációt PPTX fájlként.

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
Az Aspose ingyenes [Text to GIF] konverterével könnyedén animálhatsz szöveget és készíthetsz GIF-eket szövegből. 
{{% /alert %}}

## **GYIK**

**Megmarad az eredeti kép felbontása a beillesztés után?**

Igen. A forráspixelek megmaradnak, de a végső megjelenés attól függ, hogyan van a [picture](/slides/hu/androidjava/picture-frame/) átméretezve a dián és az esetleges mentéskor alkalmazott tömörítéstől.

**Mi a legjobb módja annak, hogy egyetlen logót egyszerre több tucat dián cseréljünk?**

Helyezd a logót a master diára vagy egy elrendezésre, és cseréld ki a prezentáció képgyűjteményében — a frissítések minden olyan elemre kiterjednek, amely ezt az erőforrást használja.

**Átalakítható-e a beillesztett SVG szerkeszthető alakzatokká?**

Igen. Az SVG-t alakzatsorozattá konvertálhatod, majd az egyes részek szerkeszthetővé válnak a szabványos alakzat tulajdonságokkal.

**Hogyan állíthatok be egy képet több dia háttérként egyszerre?**

[A kép háttérként történő hozzárendelés](/slides/hu/androidjava/presentation-background/) a master dián vagy a megfelelő elrendezésen — minden, az adott masterre/elrendezésre épülő dia örökli a hátteret.

**Hogyan előzhetem meg, hogy a prezentáció túl nagy legyen a sok kép miatt?**

Használd újra ugyanazt a képernyőforrást a másolatok helyett, válassz megfelelő felbontást, alkalmazz tömörítést mentéskor, és a gyakran ismétlődő grafikákat helyezd a masterre, ahol megfelelő.