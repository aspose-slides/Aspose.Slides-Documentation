---
title: Optimize Image Management in Presentations Using PHP
linktitle: Manage Images
type: docs
weight: 10
url: /cs/php-java/image/
keywords:
- add image
- add picture
- add bitmap
- replace image
- replace picture
- from web
- background
- add PNG
- add JPG
- add SVG
- external SVG resources
- SVG resolver
- linked SVG images
- SVG fonts
- add EMF
- add WMF
- add TIFF
- PowerPoint
- OpenDocument
- presentation
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Streamline image management in PowerPoint and OpenDocument with Aspose.Slides for PHP via Java, optimizing performance and automating your workflow."
---
## **Úvod**

Obrázky činí prezentace poutavějšími a vizuálně atraktivnějšími. V Microsoft PowerPoint můžete vkládat obrázky na snímky ze souborů, z internetu nebo z jiných zdrojů. Podobně Aspose.Slides umožňuje přidávat obrázky do snímků prezentace několika způsoby.

{{% alert  title="Tip" color="primary" %}} 

Aspose poskytuje bezplatné konvertory — [JPEG to PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG to PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt) — které vám umožní rychle vytvořit prezentace z obrázků. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Pokud chcete přidat obrázek jako rámeček — zejména pokud ho plánujete měnit velikost, použít efekty nebo jiné standardní možnosti formátování — viz [Picture Frame](/slides/cs/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Můžete převádět obrázky z jednoho formátu do druhého. Viz následující stránky: převod [image to JPG](https://products.aspose.com/slides/cs/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-svg/), a [SVG to PNG](https://products.aspose.com/slides/cs/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides podporuje obrázky v populárních formátech, jako jsou JPEG, PNG, BMP, GIF a další. 

## **Přidání obrázků uložených místně do snímků**

Můžete přidat jeden nebo více obrázků uložených ve vašem počítači do snímku prezentace. Následující ukázkový kód v PHP ukazuje, jak přidat obrázek do snímku:

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

## **Přidání obrázků z webu do snímků**

Pokud obrázek, který chcete přidat do snímku, není uložen ve vašem počítači, můžete jej přidat přímo z webu. 

Následující ukázkový kód v PHP ukazuje, jak přidat obrázek z webu do snímku:

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

## **Přidání obrázků do Slide Masteru**

Slide master ukládá a řídí informace, jako jsou motiv a rozvržení snímků, které jej používají. Když přidáte obrázek do slide masteru, obrázek se zobrazí na každém snímku založeném na tomto masteru. 

Následující ukázkový kód v PHP ukazuje, jak přidat obrázek do slide masteru:

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

## **Přidání obrázků jako pozadí snímků**

Můžete použít obrázek jako pozadí pro jeden nebo více snímků. Podrobnosti najdete v *[Setting Images as Backgrounds for Slides](/slides/cs/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Přidání SVG do prezentací**

Obsah SVG lze do prezentace přidat pomocí třídy [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/). Výsledný objekt SVG obrázku lze poté přidat do kolekce obrázků prezentace a použít k vytvoření rámečku. 

Následující příklad v PHP importuje samostatný řetězec SVG. Všechny obrázky, styly a další zdroje použité v tomto SVG jsou vloženy přímo do obsahu SVG.

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

## **Import SVG obsahu s externími zdroji**

SVG soubory exportované z nástrojů pro design, diagramových editorů, ikonových systémů a webových pipeline mohou odkazovat na zdroje, které jsou uloženy mimo dokument SVG. Například SVG může obsahovat odkaz na obrázek jako `images/photo.png`, hodnotu CSS `url(...)` nebo URL písma. 

Pro import takového SVG obsahu vytvořte implementaci [ExternalResourceResolver](https://reference.aspose.com/slides/cs/php-java/aspose.slides/externalresourceresolver/) a předávejte ji spolu se základní URI do příslušného konstruktoru [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/). Základní URI identifikuje umístění SVG dokumentu a používá se k řešení relativních odkazů. 

Objekt SVG obrázku poskytuje přístup k informacím o importovaném SVG:

- `getSvgContent()` vrací SVG značkování jako řetězec.  
- `getSvgData()` vrací obsah SVG jako pole bajtů.  
- `getBaseUri()` vrací základní URI používané pro relativní odkazy.  
- `getExternalResourceResolver()` vrací resolver přiřazený obrázku SVG.  

### **Implementace externího resolveru zdrojů**

Resolver má dvě metody:

- `resolveUri` spojí základní URI a relativní odkaz na zdroj a vrátí absolutní URI. Vrátí `null`, pokud odkaz nelze vyřešit nebo není povolen.  
- `getEntity` vrací čitelný stream pro absolutní URI zdroje. Vrátí `null`, pokud je zdroj chybějící, zablokovaný nebo nedostupný. Vhodně lze také vrátit náhradní stream.  

Následující resolver načítá propojené zdroje pouze z povoleného místního adresáře. Síťové zdroje a cesty mimo povolený adresář jsou blokovány. Pro nevyřešené odkazy na obrázky se vrací volitelný náhradní obrázek.

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

            // Tento resolver úmyslně povoluje pouze místní soubory.
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

            // Použít náhradní jen pro obrazové zdroje. Vrácení proudu obrázku
            // pro chybějící písmo nebo stylopis by nebylo platné.
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

### **Řešení propojených zdrojů během importu SVG**

Předpokládejme, že `assets/diagram.svg` obsahuje relativní odkaz, například:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Následující příklad v PHP předává URI souboru SVG jako základní URI a poskytuje vlastní resolver. Resolver převádí relativní odkaz na obrázek na absolutní URI a vrací stream obsahující propojený zdroj během zpracování SVG v Aspose.Slides.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Základní URI představuje umístění SVG dokumentu.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// Objekt SVG obrázku vystavuje zdrojový obsah, binární data, základní URI a resolver.
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

`SvgImage` třída také poskytuje přetížené metody, které přijímají SVG data jako pole bajtů nebo vstupní stream, spolu s externím resolverem zdrojů a základním URI. 

{{% alert title="Important" color="warning" %}}

Resolver zdrojů zpřístupňuje externí zdroje během zpracování a renderování SVG v Aspose.Slides. Nemění původní SVG značkování ani automaticky nevestavuje vyřešené zdroje do něj.  

Když je SVG obrázek přidán do kolekce obrázků prezentace, soubor PPTX může obsahovat jak původní SVG reprezentaci, tak rastrový náhradní obrázek. Propojený zdroj se může objevit v vygenerovaném náhradním obrázku, zatímco relativní odkaz jako `images/photo.png` zůstane nezměněn v uloženém SVG. Aplikace, která vykresluje nativní SVG reprezentaci, může proto vynechat propojený obsah, pokud není původní externí zdroj dostupný. 

{{% /alert %}}

### **Vytvoření přenosného SVG obrázku**

Pro vytvoření SVG obrázku, který nezávisí na externích souborech, udělejte SVG samostatným před vytvořením `SvgImage`. Například nahraďte odkazy na obrázky typu `data:` URI, které obsahují data obrázku: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po vložení všech potřebných zdrojů do obsahu SVG vytvořte `SvgImage`, přidejte jej do kolekce obrázků prezentace a vložte jej do rámečku, jak je ukázáno v předchozím příkladu. 

### **Zpracování chybějících nebo blokovaných zdrojů**

Vrátí `null` z `resolveUri`, když je URI zdroje neplatné, zakázané nebo jej nelze vyřešit. Vrátí `null` z `getEntity`, když zdroj nelze přečíst. Aspose.Slides pokračuje ve zpracování SVG bez tohoto zdroje, pokud je to možné.  

Pro chybějící zdroj lze vrátit náhradní stream, ale jeho obsah musí být kompatibilní s požadovaným typem zdroje. Například vrátit stream s obrázkem pouze pro chybějící obrázek, ne pro písmo nebo stylesheet. 

{{% alert title="Security" color="warning" %}}

Nemějte řešit libovolné cesty k souborům nebo neomezené síťové URL z nedůvěryhodných SVG souborů. Omezte povolené schémata, adresáře a hosty. Pro síťové zdroje také aplikujte časové limity připojení, limity velikosti odpovědi a validaci obsahu. 

{{% /alert %}}

## **Převod SVG na sadu tvarů**

Aspose.Slides může převést SVG na sadu tvarů, podobně jako odpovídající funkce v PowerPointu: 

![PowerPoint Popup Menu](img_01_01.png)

Tato funkce je poskytována přetíženou metodou [addGroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addgroupshape/) třídy [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/), která přijímá objekt [SvgImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgimage/) jako svůj první argument. 

Následující ukázkový kód v PHP ukazuje, jak použít tuto metodu k převodu SVG souboru na sadu tvarů: 

```php
// Název zdrojového SVG souboru.
$svgFileName = "sample.svg";

// Název výstupního souboru prezentace.
$outPptxPath = "presentation.pptx";

// Vytvořit novou prezentaci.
$presentation = new Presentation();
try {
    // Načíst obsah SVG souboru.
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

    // Vytvořit objekt SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Získat velikost snímku.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Převést SVG obrázek na skupinu tvarů a přizpůsobit jej velikosti snímku.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Uložit prezentaci ve formátu PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Přidání obrázků jako EMF do snímků**

Aspose.Slides for PHP via Java vám umožňuje generovat EMF obrázky z listů Excel pomocí Aspose.Cells a přidávat je do snímků prezentace. 

Následující ukázkový kód v PHP ukazuje, jak to udělat: 

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Uložit sešit do proudu.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Přidat soubor tak, jak je, aby obrázek zůstal vektorovým EMF místo rasterizace.
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

## **Nahrazení obrázků v kolekci obrázků**

Aspose.Slides umožňuje nahradit obrázky uložené v kolekci obrázků prezentace, včetně obrázků používaných tvary snímků. Tato sekce popisuje několik způsobů, jak aktualizovat obrázky v kolekci. Obrázek můžete nahradit pomocí surových bajtových dat, instance [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) nebo jiného obrázku, který již v kolekci existuje. 

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace, který obsahuje obrázky, pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).  
2. Načtěte nový obrázek ze souboru do pole bajtů.  
3. Nahraďte cílový obrázek novým obrázkem pomocí pole bajtů.  
4. Ve druhém přístupu načtěte obrázek do objektu [IImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/iimage/) a nahraďte cílový obrázek tímto objektem.  
5. Ve třetím přístupu nahraďte cílový obrázek obrázkem, který již v kolekci obrázků prezentace existuje.  
6. Zapište upravenou prezentaci jako soubor PPTX.  

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation("sample.pptx");
try {
    // První způsob.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Druhý způsob.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // Třetí způsob.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Uložit prezentaci do souboru.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

S bezplatným konvertorem Aspose [Text to GIF](https://products.aspose.app/slides/cs/text-to-gif) můžete snadno animovat text a vytvářet GIFy z textu. 

{{% /alert %}}

## **Často kladené otázky**

**Zůstane původní rozlišení obrázku po vložení zachováno?**

Ano. Zdrojové pixely jsou zachovány, ale konečný vzhled závisí na tom, jak je [picture](/slides/cs/php-java/picture-frame/) na snímku škálováno a na případné kompresi při ukládání.  

**Jaký je nejlepší způsob, jak najednou nahradit stejné logo na desítkách snímků?**

Umístěte logo na master snímek nebo rozvržení a nahraďte jej v kolekci obrázků prezentace — aktualizace se projeví ve všech prvcích, které tento zdroj používají.  

**Lze vložené SVG převést na editovatelné tvary?**

Ano. SVG lze převést na skupinu tvarů, po čemž se jednotlivé části stávají editovatelnými pomocí standardních vlastností tvarů.  

**Jak mohu najednou nastavit obrázek jako pozadí pro více snímků?**

[Přiřaďte obrázek jako pozadí](/slides/cs/php-java/presentation-background/) na master snímku nebo odpovídajícím rozvržení — všechny snímky používající tento master/rozvržení zdědí pozadí.  

**Jak zabránit tomu, aby prezentace byla příliš velká kvůli mnoha obrázkům?**

Znovu použijte jeden zdroj obrázku místo duplicit, vyberte rozumné rozlišení, aplikujte kompresi při ukládání a opakovanou grafiku umístěte na master, kde je to vhodné.