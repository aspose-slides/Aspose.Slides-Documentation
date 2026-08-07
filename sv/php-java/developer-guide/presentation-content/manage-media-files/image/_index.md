---
title: Optimera bildhantering i presentationer med PHP
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/php-java/image/
keywords:
- lägg till bild
- lägg till bild
- lägg till bitmap
- byt bild
- byt bild
- från webben
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- externa SVG-resurser
- SVG-resolver
- länkade SVG-bilder
- SVG-teckensnitt
- lägg till EMF
- lägg till WMF
- lägg till TIFF
- PowerPoint
- OpenDocument
- presentation
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Förenkla bildhantering i PowerPoint och OpenDocument med Aspose.Slides för PHP via Java, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och visuellt tilltalande. I Microsoft PowerPoint kan du infoga bilder på bilderna från filer, internet eller andra källor. På samma sätt låter Aspose.Slides dig lägga till bilder i presentationsbilder på flera sätt.

{{% alert  title="Tips" color="primary" %}} 

Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter dig snabbt skapa presentationer från bilder. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Om du vill lägga till en bild som en bildram—särskilt om du planerar att ändra storlek, applicera effekter eller använda andra standardformateringsalternativ—se [Bildram](/slides/sv/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Obs" color="warning" %}}

Du kan konvertera bilder från ett format till ett annat. Se följande sidor: konvertera [bild till JPG](https://products.aspose.com/slides/sv/php-java/conversion/image-to-jpg/), [JPG till bild](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-image/), [JPG till PNG](https://products.aspose.com/slides/sv/php-java/conversion/jpg-to-png/), [PNG till JPG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-jpg/), [PNG till SVG](https://products.aspose.com/slides/sv/php-java/conversion/png-to-svg/), och [SVG till PNG](https://products.aspose.com/slides/sv/php-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides stödjer bilder i vanliga format som JPEG, PNG, BMP, GIF och andra. 

## **Lägg till lokalt lagrade bilder på bilder**

Du kan lägga till en eller flera bilder som lagras på din dator på en presentationsbild. Följande PHP‑exempelkod visar hur du lägger till en bild på en bild:

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

## **Lägg till bilder från webben på bilder**

Om bilden du vill lägga till på en bild inte är lagrad på din dator kan du lägga till den direkt från webben. 

Följande PHP‑exempelkod visar hur du lägger till en bild från webben på en bild:

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

## **Lägg till bilder på bildmastrar**

En bildmastare lagrar och styr information såsom tema och layout för de bilder som använder den. När du lägger till en bild på en bildmastare visas bilden på varje bild baserad på den mastaren. 

Följande PHP‑exempelkod visar hur du lägger till en bild på en bildmastare:

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

## **Lägg till bilder som bakgrund för bilder**

Du kan använda en bild som bakgrund för en eller flera bilder. För detaljer, se *[Ställa in bilder som bakgrund för bilder](/slides/sv/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägg till SVG i presentationer**

SVG‑innehåll kan läggas till i en presentation med klassen [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/). Det resulterande SVG‑bildobjektet kan sedan läggas till i presentationens bildsamling och användas för att skapa en bildram.

Följande PHP‑exempel importerar en självständig SVG‑sträng. Alla bilder, stilar och andra resurser som används av denna SVG är inbäddade direkt i SVG‑innehållet.

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

## **Importera SVG‑innehåll med externa resurser**

SVG‑filer som exporteras från designverktyg, diagramredigerare, ikonsystem och webb‑pipelines kan referera till resurser som lagras utanför SVG‑dokumentet. Till exempel kan en SVG innehålla en bildlänk som `images/photo.png`, ett CSS‑`url(...)`‑värde eller en teckensnittslänk.

För att importera sådant SVG‑innehåll, skapa en implementation av [ExternalResourceResolver](https://reference.aspose.com/slides/sv/php-java/aspose.slides/externalresourceresolver/) och skicka den, tillsammans med en bas‑URI, till en lämplig [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/)-konstruktör. Bas‑URI identifierar placeringen av SVG‑dokumentet och används för att lösa relativa länkar.

SVG‑bildobjektet ger åtkomst till information om den importerade SVG:n:

- `getSvgContent()` returnerar SVG‑markup som en sträng.
- `getSvgData()` returnerar SVG‑innehållet som en byte‑array.
- `getBaseUri()` returnerar bas‑URI som används för relativa länkar.
- `getExternalResourceResolver()` returnerar den resolver som tilldelats SVG‑bilden.

### **Implementera en extern resursresolver**

Resolvern har två metoder:

- `resolveUri` kombinerar bas‑URI och en relativ resursslänk och returnerar en absolut URI. Returnera `null` när länken inte kan lösas eller inte är tillåten.
- `getEntity` returnerar ett läsbart flöde för en absolut resursslänk. Returnera `null` när resursen saknas, är blockerad eller otillgänglig. Ett reservflöde kan också returneras när det är lämpligt.

Följande resolver laddar länkade resurser endast från en tillåten lokal katalog. Nätverksresurser och sökvägar utanför den tillåtna katalogen blockeras. En valfri reservbild returneras för olösta bildlänkar.

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

            // Den här resolvern tillåter avsiktligt bara lokala filer.
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

            // Använd en reserv endast för bildresurser. Att returnera ett bildflöde
            // för ett saknat typsnitt eller en stilmall skulle inte vara giltigt.
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

### **Lös länkade resurser under SVG‑import**

Anta att `assets/diagram.svg` innehåller en relativ referens såsom:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Följande PHP‑exempel skickar SVG‑filens URI som bas‑URI och tillhandahåller en anpassad resolver. Resolvern omvandlar den relativa bildlänken till en absolut URI och returnerar ett flöde som innehåller den länkade resursen medan Aspose.Slides behandlar SVG:n.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Bas-URI:n representerar platsen för SVG-dokumentet.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// SVG-bildobjektet visar källinnehållet, binära data, bas-URI och resolvern.
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

Klassen `SvgImage` erbjuder också överlagringar som accepterar SVG‑data som en byte‑array eller ett inmatningsflöde, tillsammans med en extern resursresolver och en bas‑URI.

{{% alert title="Viktigt" color="warning" %}}

Resursresolvern gör externa resurser tillgängliga medan Aspose.Slides behandlar och renderar SVG:n. Den ändrar inte den ursprungliga SVG‑markupen eller bäddar automatiskt in de lösta resurserna i den.

När en SVG‑bild läggs till i presentationens bildsamling kan PPTX‑filen innehålla både den ursprungliga SVG‑representationen och en raster‑reservbild. En länkad resurs kan visas i den genererade reservbilden medan en relativ länk som `images/photo.png` förblir oförändrad i den lagrade SVG:n. En applikation som renderar den inhemska SVG‑representationen kan därför utelämna den länkade innehållet när den ursprungliga externa resursen är otillgänglig.

{{% /alert %}}

### **Skapa en portabel SVG‑bild**

För att skapa en SVG‑bild som inte är beroende av externa filer, gör SVG:n självständig innan du skapar `SvgImage`. Till exempel, ersätt länkade bild‑URL:er med `data:`‑URI:er som innehåller bilddata:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

När alla nödvändiga resurser har bäddats in i SVG‑innehållet, skapa `SvgImage`, lägg till den i presentationens bildsamling och infoga den i en bildram som i föregående exempel.

### **Hantera saknade eller blockerade resurser**

Returnera `null` från `resolveUri` när en resurs‑URI är ogiltig, förbjuden eller inte kan lösas. Returnera `null` från `getEntity` när resursen inte kan läsas. Aspose.Slides fortsätter att bearbeta SVG:n utan den resursen när det är möjligt.

Ett reservflöde kan returneras för en saknad resurs, men dess innehåll måste vara kompatibelt med den begärda resurs­typen. Till exempel, returnera ett bildflöde endast för en saknad bild, inte för ett teckensnitt eller en stilmall.

{{% alert title="Säkerhet" color="warning" %}}

Lös inte godtyckliga filsökvägar eller obegränsade nätverks‑URL:er från opålitliga SVG‑filer. Begränsa tillåtna scheman, kataloger och värdar. För nätverksresurser, tillämpa även anslutnings‑timeout, svarsstorleks‑gränser och innehållsvalidering.

{{% /alert %}}

## **Konvertera SVG till en uppsättning former**

Aspose.Slides kan konvertera en SVG till en uppsättning former, likt motsvarande funktionalitet i PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Denna funktionalitet tillhandahålls av en överlagring av metoden [addGroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addgroupshape/) i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/) som tar ett [SvgImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/svgimage/)‑objekt som sitt första argument.

Följande PHP‑exempelkod visar hur du använder denna metod för att konvertera en SVG‑fil till en uppsättning former:

```php
// Källfilnamn för SVG.
$svgFileName = "sample.svg";

// Utdatafilnamn för presentation.
$outPptxPath = "presentation.pptx";

// Skapa en ny presentation.
$presentation = new Presentation();
try {
    // Läs SVG-filens innehåll.
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

    // Skapa ett SvgImage‑objekt.
    $svgImage = new SvgImage($svgContent);

    // Hämta bildens storlek.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Konvertera SVG‑bilden till en grupp av former och skala den till bildens storlek.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Spara presentationen i PPTX-format.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Lägg till bilder som EMF på bilder**

Aspose.Slides för PHP via Java låter dig generera EMF‑bilder från Excel‑arbetsblad med Aspose.Cells och lägga till dem på presentationsbilder.

Följande PHP‑exempelkod visar hur du gör detta:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Spara arbetsboken till en ström.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Lägg till filen som den är så att bilden förblir en vektor‑EMF istället för att rasteriseras.
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

## **Byt ut bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling, inklusive bilder som används av bildformer. Detta avsnitt beskriver flera sätt att uppdatera bilder i samlingen. Du kan ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/)-instans, eller en annan bild som redan finns i samlingen.

Följ stegen nedan:

1. Läs in presentationsfilen som innehåller bilder med klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Läs in en ny bild från en fil till en byte‑array.
1. Ersätt mål‑bilden med den nya bilden med byte‑arrayen.
1. I det andra tillvägagångssättet, läs in bilden till ett [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/)-objekt och ersätt mål‑bilden med det objektet.
1. I det tredje tillvägagångssättet, ersätt mål‑bilden med en bild som redan finns i presentationens bildsamling.
1. Skriv den modifierade presentationen som en PPTX‑fil.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation("sample.pptx");
try {
    // Det första sättet.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Det andra sättet.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // Det tredje sättet.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Spara presentationen till en fil.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Med Asposes gratis [Text till GIF](https://products.aspose.app/slides/sv/text-to-gif)‑konverterare kan du enkelt animera text och skapa GIF‑ar från text. 

{{% /alert %}}

## **FAQ**

**Behåller den ursprungliga bildens upplösning sin kvalitet efter infogning?**

Ja. Källpixelna bevaras, men det slutliga utseendet beror på hur [bilden](/slides/sv/php-java/picture-frame/) skalas på bilden och eventuell kompression vid sparning.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder på en gång?**

Placera logotypen på mastern eller en layout och ersätt den i presentationens bildsamling—uppdateringar sprids till alla element som använder den resursen.

**Kan en insatt SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varefter enskilda delar blir redigerbara med vanliga formegenskaper.

**Hur kan jag ange en bild som bakgrund för flera bilder samtidigt?**

[Tilldela bilden som bakgrund](/slides/sv/php-java/presentation-background/) på mastern eller den relevanta layouten—alla bilder som använder den mastern/layouten kommer att ärva bakgrunden.

**Hur förhindrar jag att en presentation blir för stor på grund av många bilder?**

Återanvänd en enda bildresurs istället för dubbletter, välj rimliga upplösningar, applicera kompression vid sparning och håll återkommande grafik på mastern där det är lämpligt.