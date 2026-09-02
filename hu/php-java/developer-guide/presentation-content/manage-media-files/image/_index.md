---
title: Optimize Image Management in Presentations Using PHP
linktitle: Manage Images
type: docs
weight: 10
url: /hu/php-java/image/
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
- csatolt SVG képek
- SVG betűtípusok
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- bemutató
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Optimalizálja a képek kezelését PowerPoint és OpenDocument formátumokban az Aspose.Slides for PHP via Java segítségével, javítva a teljesítményt és automatizálva a munkafolyamatot."
---
## **Bevezetés**

A képek élvezetesebbé és vizuálisan vonzóbbá teszik a bemutatókat. A Microsoft PowerPointban képeket szúrhat be a diákra fájlokból, az internetről vagy más forrásokból. Hasonlóan, az Aspose.Slides többféleképpen is lehetővé teszi, hogy képeket adjon hozzá a bemutató diáihoz.

{{% alert  title="Tip" color="primary" %}} 
Az Aspose ingyenes konvertálókat biztosít — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyekkel gyorsan készíthet bemutatókat képekből. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Ha képet szeretne képkockaként hozzáadni — különösen, ha átméretezni, effektusokat alkalmazni vagy más szabványos formázási lehetőségeket használni kíván — lásd a [Picture Frame](/slides/hu/php-java/picture-frame/) oldalt. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Képeket átalakíthat egyik formátumból a másikba. Lásd az alábbi oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hu/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hu/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hu/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hu/php-java/conversion/png-to-svg/) és [SVG to PNG](https://products.aspose.com/slides/hu/php-java/conversion/svg-to-png/). 
{{% /alert %}}

Az Aspose.Slides támogatja a képeket a népszerű formátumokban, például a JPEG, PNG, BMP, GIF és egyebek.

## **Képek hozzáadása helyileg tárolt diákhoz**

Egy vagy több, a számítógépén tárolt képet adhat hozzá egy bemutató diájához. Az alábbi PHP mintakód bemutatja, hogyan adhat hozzá egy képet egy diához:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Képek hozzáadása a webről diákhoz**

Ha a diára hozzáadni kívánt kép nincs tárolva a számítógépén, közvetlenül a webről is hozzáadhatja. 

Az alábbi PHP mintakód bemutatja, hogyan adhat hozzá egy képet a webről egy diához:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Képek hozzáadása diákmesterekhez**

A diákmester tárolja és irányítja az olyan információkat, mint a téma és az elrendezés a használó diák számára. Ha képet ad hozzá egy diákmesterhez, a kép megjelenik minden, azt a mestert használó dián. 

Az alábbi PHP mintakód bemutatja, hogyan adhat hozzá egy képet egy diákmesterhez:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Képek hozzáadása diák háttérként**

Képet használhat háttérként egy vagy több dián. A részletekért lásd a *[Setting Images as Backgrounds for Slides](/slides/hu/php-java/presentation-background/#setting-images-as-background-for-slides)* oldalát.

## **SVG hozzáadása bemutatókhoz**

Az SVG tartalmat a [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) osztály segítségével adhatja hozzá egy bemutatóhoz. A kapott SVG képobjektum ezután hozzáadható a bemutató képgyűjteményéhez és felhasználható képkocka létrehozásához.

Az alábbi PHP példa egy önálló SVG karakterláncot importál. Az SVG által használt összes kép, stílus és egyéb erőforrás közvetlenül az SVG tartalomban van beágyazva.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SVG tartalom importálása külső erőforrásokkal**

A tervezőeszközök, diagramkészítők, ikonrendszerek és webes folyamatokból exportált SVG‑fájlok hivatkozhatnak olyan erőforrásokra, amelyek az SVG‑dokumentumon kívül vannak tárolva. Például egy SVG tartalmazhat kép hivatkozást, mint a `images/photo.png`, egy CSS `url(...)` értéket vagy egy betűtípus URL‑t.

Az ilyen SVG tartalom importálásához hozzon létre egy [ExternalResourceResolver](https://reference.aspose.com/slides/hu/php-java/aspose.slides/externalresourceresolver/) megvalósítást, és adja át, a bázis‑URI‑val együtt, egy megfelelő [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) konstruktorának. A bázis‑URI az SVG‑dokumentum helyét jelöli, és a relatív hivatkozások feloldásához használatos.

Az SVG képobjektum hozzáférést biztosít az importált SVG információihoz:

- `getSvgContent()` visszaadja az SVG jelölést karakterláncként.
- `getSvgData()` visszaadja az SVG tartalmat bájt tömbként.
- `getBaseUri()` visszaadja a relatív hivatkozásokhoz használt bázis‑URI‑t.
- `getExternalResourceResolver()` visszaadja az SVG képre rendelt feloldót.

### **Külső erőforrás feloldó implementálása**

A feloldónak két metódusa van:

- ``resolveUri`` a bázis‑URI‑t és egy relatív erőforrás‑hivatkozást egyesíti, majd abszolút URI‑t ad vissza. Ha a hivatkozás nem oldható fel vagy nem engedélyezett, adjon vissza `null`‑t.
- ``getEntity`` visszaad egy olvasható streamet egy abszolút erőforrás‑URI‑hoz. Ha az erőforrás hiányzik, blokkolva van vagy nem elérhető, adjon vissza `null`‑t. Szükség esetén visszaadható egy tartalék stream is.

Az alábbi feloldó csak egy engedélyezett helyi könyvtárból tölti be a hivatkozott erőforrásokat. A hálózati erőforrások és az engedélyezett könyvtáron kívüli útvonalak blokkolva vannak. Egy opcionális tartalék kép kerül visszaadásra a feloldatlan kép hivatkozásoknál.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Ez a feloldó szándékosan csak helyi fájlok engedélyezését teszi lehetővé.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Csak képes erőforrások esetén használjunk tartalékot. Egy hiányzó betűtípus vagy
            // stíluslap esetén kép stream visszaadása nem lenne érvényes.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Hivatkozott erőforrások feloldása SVG importálás közben**

Tegyük fel, hogy a `assets/diagram.svg` relatív hivatkozást tartalmaz, például:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Az alábbi PHP példa a SVG‑fájl URI‑ját adja át bázis‑URI‑ként, és egy egyéni feloldót biztosít. A feloldó a relatív kép hivatkozást abszolút URI‑vá alakítja, és egy streamet ad vissza, amely a hivatkozott erőforrást tartalmazza, miközben az Aspose.Slides feldolgozza az SVG‑t.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Az alap URI az SVG dokumentum helyét jelöli.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// Az SVG képobjektum hozzáférést biztosít a forrás tartalomhoz, bináris adatokhoz, alap URI-hoz és a feloldóhoz.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az `SvgImage` osztály további túlterheléseket is kínál, amelyek SVG adatot fogadnak bájt tömbként vagy bemeneti streamként, valamint egy külső erőforrás feloldót és egy bázis‑URI‑t.

{{% alert title="Important" color="warning" %}}
Az erőforrás feloldó elérhetővé teszi a külső erőforrásokat, miközben az Aspose.Slides feldolgozza és rendereli az SVG‑t. Nem módosítja az eredeti SVG jelölést, és nem ágyazza be automatikusan a feloldott erőforrásokat.

Amikor egy SVG kép kerül a bemutató képgyűjteményébe, a PPTX fájl tartalmazhatja az eredeti SVG ábrázolást és egy raszteres tartalék képet is. A hivatkozott erőforrás megjelenhet a generált tartalék képen, míg a relatív hivatkozás, például `images/photo.png` változatlan marad a tárolt SVG‑ben. Egy olyan alkalmazás, amely a natív SVG ábrázolást rendereli, ezért kihagyhatja a hivatkozott tartalmat, ha az eredeti külső erőforrás nem érhető el.
{{% /alert %}}

### **Hordozható SVG kép létrehozása**

Az SVG kép létrehozásához, amely nem függ külső fájloktól, tegye az SVG‑t önállóvá a `SvgImage` létrehozása előtt. Például cserélje ki a hivatkozott kép URL‑eket `data:` URI‑kra, amelyek a kép adatot tartalmazzák:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Miután az összes szükséges erőforrást beágyazta az SVG tartalomba, hozza létre a `SvgImage`‑t, adja hozzá a bemutató képgyűjteményéhez, és szúrja be egy képkockába, ahogyan az előző példában látható.

### **Hiányzó vagy blokkolt erőforrások kezelése**

Adjon vissza `null`‑t a `resolveUri`‑ból, ha egy erőforrás URI érvénytelen, tiltott vagy nem oldható fel. Adjon vissza `null`‑t a `getEntity`‑ből, ha az erőforrás nem olvasható. Az Aspose.Slides a lehető legjobb esetben az erőforrás nélkül folytatja az SVG feldolgozását.

Hiányzó erőforrás esetén visszaadható egy tartalék stream, de annak tartalma kompatibilis kell legyen a kért erőforrás típusával. Például csak kép streamet adjon vissza hiányzó képhez, nem betűtípushoz vagy stíluslaphoz.

{{% alert title="Security" color="warning" %}}
Ne oldjon fel tetszőleges fájl útvonalakat vagy korlátozások nélküli hálózati URL‑eket nem megbízható SVG fájlokból. Korlátozza az engedélyezett sémákat, könyvtárakat és hostokat. Hálózati erőforrások esetén alkalmazzon kapcsolat időkorlátokat, válaszméret korlátokat és tartalomvalidációt.
{{% /alert %}}

## **SVG konvertálása alakzatkészletre**

Az Aspose.Slides képes egy SVG‑t alakzatkészletre konvertálni, hasonlóan a PowerPoint megfelelő funkciójához:

![PowerPoint Popup Menu](img_01_01.png)

Ez a funkcionalitás a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) osztály [addGroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addgroupshape/) metódusának egy túlterhelésével érhető el, amely első argumentumként egy [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) objektumot vár.

Az alábbi PHP mintakód bemutatja, hogyan használja ezt a metódust egy SVG fájl alakzatkészletté konvertálásához:

```php
// SVG forrásfájl neve.
$svgFileName = "sample.svg";

// Kimeneti bemutató fájl neve.
$outPptxPath = "presentation.pptx";

// Új bemutató létrehozása.
$presentation = new Presentation();
try {
    // SVG fájl tartalmának beolvasása.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // SvgImage objektum létrehozása.
    $svgImage = new SvgImage($svgContent);

    // Diák méretének lekérése.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Az SVG képet alakzatcsoporttá konvertálja, és a dia méretéhez igazítja.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Bemutató mentése PPTX formátumban.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Képek hozzáadása EMF‑ként diákhoz**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy EMF képeket generáljon Excel munkalapokból az Aspose.Cells segítségével, és ezeket a képeket hozzáadja a bemutató diákhoz.

Az alábbi PHP mintakód bemutatja, hogyan teheti ezt:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Munkafüzet mentése streambe.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // A fájlt változatlanul hozzáadja, hogy a kép vektoros EMF maradjon, a raszterizálás helyett.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Képek cseréje a képgyűjteményben**

Az Aspose.Slides lehetővé teszi, hogy cserélje a bemutató képgyűjteményében tárolt képeket, beleértve a diák alakzatai által használt képeket is. Ez a szakasz többféle módot ismertet a képek frissítésére a gyűjteményben. Képet cserélhet nyers bájt adat, egy [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) példány vagy egy már a gyűjteményben létező másik kép felhasználásával.

Kövesse az alábbi lépéseket:

1. Töltsön be egy, képeket tartalmazó bemutató fájlt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztállyal.
2. Töltsön be egy új képet egy fájlból bájt tömbbe.
3. Cserélje ki a célképet az új képre a bájt tömb használatával.
4. A második megközelítésben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) objektumba, és cserélje ki a célképet ezzel az objektummal.
5. A harmadik megközelítésben cserélje ki a célképet egy, a bemutató képgyűjteményében már létező képpel.
6. Írja ki a módosított bemutatót PPTX fájlként.

```php
// A Presentation osztály példányosítása, amely egy bemutató fájlt képvisel.
$presentation = new Presentation("sample.pptx");
try {
    // Az első mód.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // A második mód.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // A harmadik mód.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // A bemutató mentése fájlba.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Az Aspose ingyenes [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konvertálójával könnyedén animálhat szöveget, és GIF-eket hozhat létre szövegből. 
{{% /alert %}}

## **GYIK**

**Megmarad-e az eredeti képfelbontás a beszúrás után?**

Igen. A forrás pixeljei megmaradnak, de a végső megjelenés attól függ, hogyan van a [picture](/slides/hu/php-java/picture-frame/) méretezve a dián és a mentéskor alkalmazott tömörítéstől.

**Mi a legjobb módja egyazon logó cseréjének egyszerre több tucat dián?**

Helyezze el a logót a mesterdiára vagy egy elrendezésre, és cserélje ki a bemutató képgyűjteményében – a frissítések minden, azt az erőforrást használó elemre átkerülnek.

**Átalakítható-e egy beszúrt SVG szerkeszthető alakzatokká?**

Igen. Az SVG‑t átalakíthatja alakzatcsoporttá, amelynek egyes részei ezután a szokásos alakzat tulajdonságokkal szerkeszthetők.

**Hogyan állíthatok be egy képet háttérként több diára egyszerre?**

[<span>Rendelje a képet háttérként</span>](/slides/hu/php-java/presentation-background/) a mesterdiára vagy a megfelelő elrendezésre – minden, azt a mester/elrendezés használó dia örökli a hátteret.

**Hogyan akadályozhatom meg, hogy egy bemutató túl nagyra nőjen a sok kép miatt?**

Használja újra ugyanazt a kép erőforrást a duplikátumok helyett, válasszon ésszerű felbontásokat, alkalmazzon tömörítést mentéskor, és ahol megfelelő, a gyakran ismétlődő grafikákat a mesteren tartsa.