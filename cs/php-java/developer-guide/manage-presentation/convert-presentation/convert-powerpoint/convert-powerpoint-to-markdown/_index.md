---
title: Převod prezentací PowerPoint do Markdownu v PHP
linktitle: PowerPoint do Markdownu
type: docs
weight: 140
url: /cs/php-java/convert-powerpoint-to-markdown/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do MD
- prezentace do MD
- snímek do MD
- PPT do MD
- PPTX do MD
- uložit PowerPoint jako Markdown
- uložit prezentaci jako Markdown
- uložit snímek jako Markdown
- uložit PPT jako MD
- uložit PPTX jako MD
- exportovat PPT do MD
- exportovat PPTX do MD
- export obrázků do Markdownu
- odkazy na obrázky CDN
- PowerPoint
- prezentace
- Markdown
- PHP
- Aspose.Slides
description: "Převádějte PPT a PPTX prezentace do Markdownu v PHP a řiďte, kde jsou exportované bitmapové, metaznačkové a SVG obrázky uloženy a na které odkazy odkazují."
---
## **Přehled**

Aspose.Slides for PHP via Java dokáže převádět prezentace PPT a PPTX do Markdownu pro dokumentaci, statické stránky, migraci obsahu i workflow správy verzí. Můžete vybrat variantu Markdownu, řídit způsob vykreslování obsahu snímků a rozhodnout, kde budou uložené exportované obrázky a jak na ně bude odkazováno v generovaném Markdownu.

Ve výchozím nastavení export Markdownu používá výstup pouze s textem. Pro export vizuálního obsahu nastavte typ exportu pomocí metody [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) na hodnotu `Sequential` nebo `Visual` z výčtu [MarkdownExportType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownexporttype/). `Sequential` vykresluje položky snímku samostatně a v pořadí, zatímco `Visual` zachovává seskupené položky dohromady, aby se uchovala jejich vizuální vztah. Hodnota `TextOnly` neprodukuje obrázkové zdroje, takže se v tomto režimu nevolají zpětné volání pro ukládání obrázků.

## **Převod prezentace do Markdownu**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) a poté zavolejte metodu [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) s hodnotou `Md` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/).

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

## **Vyberte variantu Markdownu**

Metoda [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) řídí, která specifikace Markdownu bude použita pro výstup. Výčet [Flavor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/flavor/) zahrnuje CommonMark, GitHub Flavored Markdown a další podporované varianty.

Následující příklad exportuje prezentaci jako CommonMark:

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

## **Exportovat obrázky pomocí výchozího chování ukládání místně**

Třída [MarkdownSaveOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) poskytuje dvě metody pro konfiguraci místně ukládaných obrázků:

- [setBasePath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) určuje základní adresář pro dokument Markdown a jeho zdroje.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) určuje podadresář pro obrázky. Jeho výchozí hodnota je `Images`.

Následující příklad vykresluje vizuální obsah, zapisuje obrázky do `output/assets` a vytváří relativní odkazy na obrázky v dokumentu Markdown:

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

Toto chování slouží také jako záložní řešení, když vlastní obsluha ukládání obrázků vrátí `false`.

## **Přizpůsobení ukládání obrázků a odkazů v Markdownu**

Použijte metodu [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) k registraci zpětného volání pro bitmapové a metaznačkové zdroje, které nejsou SVG, a jsou emitovány během exportu Markdownu. Jeho zpětné volání `MarkdownImageSavingHandler` přijímá objekt [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/), jeho hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imageformat/) a vygenerovaný odkaz v Markdownu jako jednoprvkové pole Java řetězců. Uložte nebo nahrajte obrázek s uvedeným formátem a nahraďte `$link[0]` odkazem, který má být v Markdown výstupu.

Zdroje emitované ve formátu SVG jsou zpracovány odděleně. Registrujte zpětné volání pomocí metody [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/). Jeho zpětné volání `MarkdownSvgImageSavingHandler` přijímá objekt [ISvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/isvgimage/) a jednoprvkové pole Java řetězců `$link`. SVG nemá argument `ImageFormat`; místo toho zapíšete nebo nahrajete jeho XML data pomocí metody [ISvgImage::getSvgData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/isvgimage/). V závislosti na režimu exportu a vizuálním seskupení může být SVG v původní prezentaci rasterizováno nebo sloučeno s jiným obsahem; výsledný ne‑SVG zdroj je pak předán zpětnému volání pro ukládání obrázků. Registrujte obě zpětná volání, pokud každý exportovaný vizuální zdroj vyžaduje vlastní zpracování.

V PHP via Java implementujte každé zpětné volání v PHP třídě a použijte `java_closure` k vystavení tohoto objektu jako odpovídajícího Java rozhraní.

{{% alert color="info" title="Poznámka" %}}
Inicializujte PHP/Java Bridge s povoleným `JAVA_PREFER_VALUES` před načtením `Java.inc`. Metoda [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) vrací `void` a výchozí režim streamu mostu nedokáže během tohoto frontovaného volání zavolat PHP zpětné volání. Kompletní příklad níže obsahuje požadovanou inicializaci.
{{% /alert %}}

Návratová hodnota obsluhy určuje, kdo obraz zpracuje:

- Vraťte `true`, pokud obsluha uložila, nahrála, transformovala nebo jinak zpracovala obrázek a přiřadila platnou hodnotu do `$link[0]`. Aspose.Slides zapíše tuto hodnotu do dokumentu Markdown a neprovede výchozí místní uložení.
- Vraťte `false`, aby Aspose.Slides uložil obrázek místně a vygeneroval odkaz podle hodnot nastavených pomocí [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) a [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Důležité" %}}
Obsluha, která vrátí `true`, přebírá odpovědnost za obrázek. Pokud vrátí `true` bez přiřazení platného, neprázdného odkazu, export selže s `InvalidOperationException`.
{{% /alert %}}

### **Ukládat obrázky do adresáře CDN originu a používat externí URL**

Následující příklad považuje `cdn-origin/presentations/quarterly-report` za připojený nebo synchronizovaný adresář CDN originu. Každá obsluha získá vygenerovaný název souboru, uloží obrázek do tohoto vlastního adresáře a nahradí lokální odkaz veřejnou URL CDN. Vzorek sám o sobě neprovádí žádné síťové nahrávání: URL je platná až po připojení adresáře jako CDN originu nebo po publikaci souborů na CDN. Pro objektové úložiště nahraďte zápis do souborového systému nahrávací operací SDK úložiště a přiřaďte `$link[0]` až po úspěšném nahrání.

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

Bitmapová obsluha záměrně vrací `false` pro obrázky menší než 128 × 128 pixelů, takže Aspose.Slides uloží tyto obrázky do `output/fallback-images` pomocí výchozího chování. Větší bitmapové a metaznačkové zdroje, stejně jako SVG zdroje, jsou zpracovány vlastním kódem. Například vygenerovaný lokální odkaz `fallback-images/image1.png` se změní na `https://cdn.example.com/presentations/quarterly-report/image1.png`. Obsluhy používají cesty operačního systému pouze při zápisu souborů; odkazy zapisované do Markdownu používají dopředná lomítka a URL‑enkodované názvy souborů. Používejte stejný princip i při vytváření relativních odkazů: použijte `/`, ne platformově specifický oddělovač adresářů.

## **Často kladené otázky**

**Může jedna obsluha zpracovávat jak rastrové obrázky, tak SVG obrázky?**

Ne. Použijte [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) pro bitmapové a metaznačkové zdroje a [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) pro zdroje emitované jako SVG. První poskytuje objekt [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) a hodnotu [ImageFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imageformat/); druhý poskytuje objekt [ISvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/isvgimage/), jehož SVG data lze číst pomocí [ISvgImage::getSvgData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/isvgimage/). SVG ze zdroje, který je během exportu rasterizován, je zpracován zpětným voláním pro ukládání obrázků.

**Co se stane, když obsluha ukládání obrázků vrátí `false`?**

Aspose.Slides použije výchozí chování místního ukládání. Umístění obrázku a vygenerovaný odkaz jsou řízeny hodnotami nastavenými pomocí [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/) a [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markdownsaveoptions/).

**Může obsluha poskytnout URL bez lokálního uložení obrázku?**

Ano. Obsluha může obrázek nahrát do objektového úložiště nebo jej předat jiné službě, přiřadit výslednou URL do `$link[0]` a vrátit `true`. Obsluha musí zpracování dokončit sama; vrácení `true` zabrání výchozímu místnímu uložení.

**Proč export Markdownu vyhodí `InvalidOperationException` z obsluhy?**

Tato výjimka nastane, když obsluha vrátí `true`, ale neposkytne platný odkaz. Před vrácením `true` přiřaďte relativní cestu nebo externí URL, která má být zapsána do Markdownu.

**Jaký oddělovač cesty by měly odkazy na obrázky používat?**

V odkazech Markdown a URL používejte dopředná lomítka. `DIRECTORY_SEPARATOR` používejte jen pro cesty v souborovém systému a poté samostatně vytvořte či normalizujte odkaz v Markdownu.

**Zůstávají hypertextové odkazy zachovány během exportu Markdownu?**

Ano. Textové [hyperlinky](/slides/cs/php-java/manage-hyperlinks/) jsou zachovány jako standardní odkazy Markdown. [Přechody](/slides/cs/php-java/slide-transition/) a [animace](/slides/cs/php-java/powerpoint-animation/) snímků nejsou konvertovány.

**Lze prezentace převádět do Markdownu paralelně?**

Můžete zpracovávat různé soubory prezentací paralelně, ale nesdílejte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) mezi vlákny. Dodržujte [pravidla pro vícevláknové zpracování](/slides/cs/php-java/multithreading/) a pro každý soubor použijte samostatnou instanci.