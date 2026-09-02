---
title: PowerPoint prezentációk konvertálása Markdown formátumba PHP-ben
linktitle: PowerPoint Markdown-re
type: docs
weight: 140
url: /hu/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint MD-re
- prezentáció MD-re
- dia MD-re
- PPT MD-re
- PPTX MD-re
- PowerPoint mentése Markdown-ként
- prezentáció mentése Markdown-ként
- dia mentése Markdown-ként
- PPT mentése MD-ként
- PPTX mentése MD-ként
- PPT exportálása MD-be
- PPTX exportálása MD-be
- Markdown kép exportálás
- CDN kép hivatkozások
- PowerPoint
- prezentáció
- Markdown
- PHP
- Aspose.Slides
description: "Konvertálja a PPT és PPTX prezentációkat Markdown formátumba PHP-ben, és szabályozza, hogy az exportált bitmap, metafile és SVG képek hol legyenek mentve és hivatkozva."
---
## **Áttekintés**

Aspose.Slides for PHP via Java képes PPT és PPTX prezentációkat Markdown formátumba konvertálni dokumentáció, statikus weboldal, tartalom‑migráció és verziókezelési munkafolyamatok céljából. Kiválaszthatja a Markdown változatot, szabályozhatja, hogy a dia tartalma hogyan legyen megjelenítve, valamint megadhatja, hogy az exportált képek hol legyenek tárolva és hogy a generált Markdown hogyan hivatkozik rájuk.

Alapértelmezés szerint a Markdown export csak szöveges kimenetet használ. A vizuális tartalom exportálásához állítsa be az export típust a [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) metódussal a [MarkdownExportType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownexporttype/) felsorolt `Sequential` vagy `Visual` értékére. A `Sequential` külön‑külön és sorrendben rendereli a diaelemeket, míg a `Visual` csoportos elemeket együtt tartja, hogy megőrizze a vizuális kapcsolatot. A `TextOnly` érték nem bocsát ki kép erőforrásokat, ezért ebben a módban a képek mentésére szolgáló visszahívások nem lesznek meghívva.

## **Prezentáció konvertálása Markdown-be**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) felsorolt `Md` értékkel.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Markdown változat kiválasztása**

A [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) metódus szabályozza a kimenethez használt Markdown specifikációt. A [Flavor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/flavor/) felsorlat tartalmazza a CommonMark, a GitHub Flavored Markdown és más támogatott változatokat.

Az alábbi példa CommonMark formátumba exportál egy prezentációt:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Képek exportálása az alapértelmezett helyi mentési viselkedéssel**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) osztály két módszert biztosít a helyileg mentett képek konfigurálásához:

- [setBasePath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) meghatározza a Markdown dokumentum és erőforrásai számára a kiindulási könyvtárat.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) adja meg a képek alkönyvtárát. Alapértelmezett értéke `Images`.

Az alábbi példa vizuális tartalmat renderel, a képeket az `output/assets` könyvtárba írja, és relatív kép hivatkozásokat hoz létre a Markdown dokumentumban:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Ez a viselkedés szolgál visszaesésként is, amikor egy egyéni képmentő kezelő `false` értékkel tér vissza.

## **Kép mentés és Markdown hivatkozások testreszabása**

Használja a [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) metódust, hogy regisztráljon egy visszahívást a nem‑SVG bitmap és metafile erőforrásokhoz, amelyeket a Markdown export során bocsátanak ki. A `MarkdownImageSavingHandler` visszahívás megkapja az [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) objektumot, annak [ImageFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imageformat/) értékét, valamint a generált Markdown hivatkozást egyelemes Java string tömbként. Mentse vagy töltse fel a képet a megadott formátummal, és cserélje le a `$link[0]`‑t a Markdown kimenetben megjelenő referenciára.

Az SVG formátumban kibocsátott erőforrásokat külön kezelik. Regisztráljon egy visszahívást a [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) metódussal. A `MarkdownSvgImageSavingHandler` visszahívás megkap egy [ISvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/isvgimage/) objektumot és a egyelemes Java string tömb `$link`‑et. Az SVG‑nek nincs `ImageFormat` argumentuma; írja vagy töltse fel XML adatát a [ISvgImage::getSvgData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/isvgimage/) metódussal. Az export módjától és a vizuális csoportosítástól függően a forrás prezentációban lévő SVG rasterizálható vagy más tartalommal kombinálható; a keletkező nem‑SVG erőforrás ezután átadásra kerül a képmentő visszahívásnak. Regisztrálja mindkét visszahívást, ha minden exportált vizuális erőforrás egyedi feldolgozást igényel.

PHP via Java esetén valósítsa meg minden visszahívást egy PHP osztályban, és használja a `java_closure`‑t, hogy azt az objektumot a megfelelő Java interfészhez tegye hozzáférhetővé.

{{% alert color="info" title="Megjegyzés" %}}
Inicializálja a PHP/Java Bridge‑et a `JAVA_PREFER_VALUES` engedélyezésével, mielőtt betöltené a `Java.inc`‑t. A [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) metódus `void` értéket ad vissza, és a bridge alapértelmezett stream módja nem képes PHP visszahívást meghívni ebben a sorba állított hívásban. Az alábbi teljes példában megtalálható a szükséges inicializáció.
{{% /alert %}}

A kezelő visszatérési értéke határozza meg, ki dolgozza fel a képet:

- A kezelő `true` értékkel tér vissza, miután elmentette, feltöltötte, átalakította vagy egyéb módon feldolgozta a képet, és érvényes értéket rendelt a `$link[0]`‑hez. Az Aspose.Slides ezt az értéket beírja a Markdown dokumentumba, és nem hajtja végre az alapértelmezett helyi mentést.
- A kezelő `false` értékkel tér vissza, hogy az Aspose.Slides helyileg mentse a képet, és a linket a [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) és a [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) beállításoknak megfelelően generálja.

{{% alert color="warning" title="Fontos" %}}
A `true` értékkel visszatérő kezelő vállalja a kép felelősségét. Ha `true` értékkel tér vissza anélkül, hogy érvényes, nem üres hivatkozást rendelne, az export `InvalidOperationException` hibával sikertelen.
{{% /alert %}}

### **Képek mentése CDN eredeti könyvtárba és külső URL-ek használata**

Az alábbi példában a `cdn-origin/presentations/quarterly-report` könyvtárat egy csatolt vagy szinkronizált CDN eredeti könyvtárként kezeli. Minden kezelő kinyeri a generált fájlnevet, elmenti a képet ebbe az egyedi könyvtárba, és a generált helyi hivatkozást egy nyilvános CDN URL‑re cseréli. A minta maga nem végez hálózati feltöltést: az URL csak akkor válik érvényessé, amikor a könyvtár CDN eredetként van csatolva vagy fájljait a CDN‑re publikálják. Objektumtároló esetén a fájlrendszer írását cserélje le a tároló SDK feltöltési műveletére, és csak a feltöltés sikeres befejezése után adja értékül a `$link[0]`‑t.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

A bitmap kezelő szándékosan `false` értékkel tér vissza a 128 × 128 pixelnél kisebb képeknél, így az Aspose.Slides ezeket a képeket a `output/fallback-images` könyvtárba menti az alapértelmezett viselkedés szerint. Nagyobb bitmap és metafile erőforrások, valamint SVG erőforrások a saját kód által kerülnek kezelve. Például egy generált helyi hivatkozás, mint `fallback-images/image1.png`, `https://cdn.example.com/presentations/quarterly-report/image1.png` lesz. A kezelők csak fájlrendszer‑útvonalakat használnak fájlok írásakor; a Markdown‑be írt hivatkozások perjelűek és URL‑kódolt fájlneveket tartalmaznak. Ugyanezt a szabályt alkalmazza relatív hivatkozások építésekor: használjon `/`‑t, ne a platform‑specifikus könyvtár‑elválasztót.

## **GYIK**

**Kezelhet egyetlen kezelő egyszerre raszteres és SVG képeket?**  
Nem. Használja a [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) metódust a bitmap és metafile erőforrásokhoz, valamint a [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) metódust az SVG‑ként kibocsátott erőforrásokhoz. Az első egy [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) objektumot és egy [ImageFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imageformat/) értéket ad, a második egy [ISvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/isvgimage/) objektumot, amelynek SVG adatait a [ISvgImage::getSvgData](https://reference.aspose.com/slides/hu/php-java/aspose.slides/isvgimage/) metódussal olvashatja. A forrás SVG, amely exportálás közben rasterizálódik, az image‑saving visszahívás által kerül feldolgozásra.

**Mi történik, ha egy image‑saving kezelő `false`‑t ad vissza?**  
Az Aspose.Slides az alapértelmezett helyi mentési viselkedést használja. A kép helyét és a generált hivatkozást a [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) és a [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) beállítások határozzák meg.

**Képes egy kezelő URL‑t adni anélkül, hogy a képet helyben mentené?**  
Igen. A kezelő feltöltheti a képet objektumtárolóba vagy egy másik szolgáltatásba, a kapott URL‑t a `$link[0]`‑hez rendeli, és `true`‑val tér vissza. A kezelőnek saját maga kell befejeznie a feldolgozást; a `true` visszatérés megakadályozza az alapértelmezett helyi mentést.

**Miért dob `InvalidOperationException`‑t a Markdown export egy kezelőtől?**  
Ez a kivétel akkor fordul elő, amikor a kezelő `true`‑val tér vissza, de nem ad meg érvényes hivatkozást. A visszatérés előtt adja meg a relatív útvonalat vagy külső URL‑t, amelyet a Markdown‑be kell írni.

**Milyen útvonalelválasztót kell használni a kép hivatkozásoknál?**  
Használjon perjeleket (`/`) a Markdown hivatkozásokban és URL‑ekben. A `DIRECTORY_SEPARATOR`‑t csak fájlrendszer‑útvonalaknál alkalmazza, majd a Markdown referencia építésekor normalizálja azt perjelekkel.

**Megmaradnak a hiperhivatkozások a Markdown export során?**  
Igen. A szöveg [hiperhivatkozásai](/slides/hu/php-java/manage-hyperlinks/) megmaradnak szabványos Markdown linkként. A dia [átmenetei](/slides/hu/php-java/slide-transition/) és [animációi](/slides/hu/php-java/powerpoint-animation/) nem kerülnek átalakításra.

**Konvertálhatók a prezentációk párhuzamosan Markdown‑be?**  
Különböző prezentációs fájlok párhuzamosan feldolgozhatók, de ne ossza meg ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt a szálak között. Kövesse a [többszálú útmutatót](/slides/hu/php-java/multithreading/) és minden fájlhoz használjon külön példányt.