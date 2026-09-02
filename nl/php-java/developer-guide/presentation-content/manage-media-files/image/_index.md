---
title: "Optimaliseer Beeldbeheer in Presentaties met PHP"
linktitle: "Beheer Afbeeldingen"
type: docs
weight: 10
url: /nl/php-java/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van internet
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- externe SVG-bronnen
- SVG-resolver
- gekoppelde SVG-afbeeldingen
- SVG-lettertypen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Stroomlijn het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor PHP via Java, optimaliseer de prestaties en automatiseer je workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en visueel aantrekkelijker. In Microsoft PowerPoint kun je afbeeldingen op dia's invoegen vanuit bestanden, internet of andere bronnen. Op dezelfde manier stelt Aspose.Slides je in staat om afbeeldingen toe te voegen aan presentatiedia's op verschillende manieren.

{{% alert title="Tip" color="primary" %}} 
Aspose biedt gratis converters—[JPEG to PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG to PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die je in staat stellen snel presentaties uit afbeeldingen te maken. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Als je een afbeelding wilt toevoegen als afbeeldingsframe—vooral als je van plan bent de grootte aan te passen, effecten toe te passen of andere standaardopmaakopties te gebruiken—zie [Picture Frame](/slides/nl/php-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Opmerking" color="warning" %}}
Je kunt afbeeldingen van het ene formaat naar het andere converteren. Zie de volgende pagina's: converteren [image to JPG](https://products.aspose.com/slides/nl/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/nl/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/nl/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/nl/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/nl/php-java/conversion/png-to-svg/), en [SVG to PNG](https://products.aspose.com/slides/nl/php-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides ondersteunt afbeeldingen in populaire formaten zoals JPEG, PNG, BMP, GIF en andere. 

## **Afbeeldingen van lokaal toevoegen aan dia's**

Je kunt een of meerdere afbeeldingen die op je computer zijn opgeslagen toevoegen aan een presentatiedia. De volgende PHP‑voorbeeldcode laat zien hoe je een afbeelding aan een dia toevoegt:

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

## **Afbeeldingen van het web toevoegen aan dia's**

Als de afbeelding die je wilt toevoegen aan een dia niet op je computer staat, kun je deze direct van het web toevoegen. 

De volgende PHP‑voorbeeldcode laat zien hoe je een afbeelding van het web aan een dia toevoegt:

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

## **Afbeeldingen toevoegen aan dia‑masters**

Een dia‑master slaat informatie op en regelt zaken zoals het thema en de lay‑out van de dia's die ervan gebruikmaken. Wanneer je een afbeelding toevoegt aan een dia‑master, verschijnt de afbeelding op elke dia die op die master is gebaseerd. 

De volgende PHP‑voorbeeldcode laat zien hoe je een afbeelding aan een dia‑master toevoegt:

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

## **Afbeeldingen toevoegen als dia‑achtergronden**

Je kunt een afbeelding als achtergrond voor één of meerdere dia's gebruiken. Voor details zie *[Setting Images as Backgrounds for Slides](/slides/nl/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG toevoegen aan presentaties**

SVG‑inhoud kan aan een presentatie worden toegevoegd met de klasse [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/). Het resulterende SVG‑afbeeldingsobject kan vervolgens aan de afbeeldingencollectie van de presentatie worden toegevoegd en worden gebruikt om een afbeeldingsframe te maken.

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

## **SVG-inhoud importeren met externe bronnen**

SVG‑bestanden die vanuit ontwerptools, diagrameditoren, icoonsystemen en web‑pijplijnen worden geëxporteerd, kunnen verwijzen naar bronnen die buiten het SVG‑document zijn opgeslagen. Een SVG kan bijvoorbeeld een afbeeldingslink bevatten zoals `images/photo.png`, een CSS `url(...)`‑waarde of een lettertype‑URL.

Om dergelijke SVG‑inhoud te importeren, maak je een [ExternalResourceResolver](https://reference.aspose.com/slides/nl/php-java/aspose.slides/externalresourceresolver/)-implementatie en geef je deze, samen met een basis‑URI, door aan een geschikte [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/)-constructor. De basis‑URI identificeert de locatie van het SVG‑document en wordt gebruikt om relatieve links te resolveren.

Het SVG‑afbeeldingsobject biedt toegang tot informatie over de geïmporteerde SVG:

- `getSvgContent()` retourneert de SVG‑markup als een string.
- `getSvgData()` retourneert de SVG‑inhoud als een byte‑array.
- `getBaseUri()` retourneert de basis‑URI die wordt gebruikt voor relatieve links.
- `getExternalResourceResolver()` retourneert de resolver die aan de SVG‑afbeelding is toegewezen.

### **Implementeer een externe resource‑resolver**

De resolver heeft twee methoden:

- `resolveUri` combineert de basis‑URI en een relatieve resource‑link en retourneert een absolute URI. Retourneer `null` wanneer de link niet kan worden opgelost of niet is toegestaan.
- `getEntity` retourneert een leesbare stream voor een absolute resource‑URI. Retourneer `null` wanneer de resource ontbreekt, geblokkeerd is of niet beschikbaar is. Een fallback‑stream kan ook worden geretourneerd wanneer dat passend is.

De volgende resolver laadt gekoppelde bronnen uitsluitend vanuit een toegestane lokale map. Netwerkbronnen en paden buiten de toegestane map worden geblokkeerd. Een optionele fallback‑afbeelding wordt geretourneerd voor niet‑opgeloste afbeeldingslinks.

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

            // Deze resolver staat opzettelijk alleen lokale bestanden toe.
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

            // Gebruik alleen een fallback voor afbeeldingsbronnen. Een afbeeldingsstream retourneren
            // voor een ontbrekend lettertype of stylesheet zou niet geldig zijn.
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

### **Gekoppelde bronnen tijdens SVG-import oplossen**

Neem aan dat `assets/diagram.svg` een relatieve verwijzing bevat zoals:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

De volgende PHP‑voorbeeldcode geeft de SVG‑bestands‑URI door als basis‑URI en levert een aangepaste resolver. De resolver zet de relatieve afbeeldingslink om in een absolute URI en retourneert een stream met de gekoppelde resource terwijl Aspose.Slides de SVG verwerkt.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// De basis-URI geeft de locatie van het SVG-document weer.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// Het SVG-afbeeldingsobject geeft de broninhoud, binaire gegevens, basis-URI en resolver weer.
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

De `SvgImage`‑klasse biedt bovendien overloads die SVG‑gegevens als een byte‑array of een input‑stream accepteren, samen met een externe resource‑resolver en een basis‑URI.

{{% alert title="Belangrijk" color="warning" %}}
De resource‑resolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt en rendert. Hij wijzigt de originele SVG‑markup niet en embedt de opgeloste bronnen niet automatisch erin.

Wanneer een SVG‑afbeelding wordt toegevoegd aan de afbeeldingencollectie van de presentatie, kan het PPTX‑bestand zowel de originele SVG‑representatie als een raster‑fallback‑afbeelding bevatten. Een gekoppelde resource kan verschijnen in de gegenereerde fallback‑afbeelding terwijl een relatieve link zoals `images/photo.png` ongewijzigd blijft in de opgeslagen SVG. Een toepassing die de native SVG‑representatie rendert, kan de gekoppelde inhoud daarom weglaten wanneer de oorspronkelijke externe resource niet beschikbaar is.
{{% /alert %}}

### **Maak een draagbare SVG‑afbeelding**

Om een SVG‑afbeelding te maken die niet afhankelijk is van externe bestanden, maak je de SVG zelf‑containend voordat je de `SvgImage` aanmaakt. Vervang bijvoorbeeld gekoppelde afbeeldings‑URL's door `data:`‑URI's die de afbeeldingsgegevens bevatten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nadat alle benodigde bronnen in de SVG‑inhoud zijn ingebed, maak je de `SvgImage`, voeg je deze toe aan de afbeeldingencollectie van de presentatie, en voeg je hem in een afbeeldingsframe in zoals getoond in het vorige voorbeeld.

### **Ontbrekende of geblokkeerde bronnen verwerken**

Retourneer `null` vanuit `resolveUri` wanneer een resource‑URI ongeldig, verboden of niet op te lossen is. Retourneer `null` vanuit `getEntity` wanneer de resource niet kan worden gelezen. Aspose.Slides blijft de SVG verwerken zonder die resource wanneer dat mogelijk is.

Een fallback‑stream kan worden geretourneerd voor een ontbrekende resource, maar de inhoud moet compatibel zijn met het gevraagde resource‑type. Retourneer bijvoorbeeld alleen een afbeeldingsstream voor een ontbrekende afbeelding, niet voor een lettertype of stylesheet.

{{% alert title="Beveiliging" color="warning" %}}
Los geen willekeurige bestands‑paden of onbeperkte netwerk‑URL's op uit onbetrouwbare SVG‑bestanden. Beperk toegestane schema's, mappen en hosts. Voor netwerkbronnen moeten ook time‑outs, maximale respons‑groottes en inhoudsvalidatie worden toegepast.
{{% /alert %}}

## **SVG converteren naar een set vormen**

Aspose.Slides kan een SVG converteren naar een set vormen, vergelijkbaar met de overeenkomstige functionaliteit in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Deze functionaliteit wordt geleverd via een overload van de [addGroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addgroupshape/)-methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)-klasse die een [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/)-object als eerste argument accepteert.

De volgende PHP‑voorbeeldcode laat zien hoe je deze methode gebruikt om een SVG‑bestand naar een set vormen te converteren:

```php
// Bron SVG-bestandsnaam.
$svgFileName = "sample.svg";

// Uitvoernaam van de presentatie.
$outPptxPath = "presentation.pptx";

// Maak een nieuwe presentatie.
$presentation = new Presentation();
try {
    // Lees de inhoud van het SVG-bestand.
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

    // Maak een SvgImage-object aan.
    $svgImage = new SvgImage($svgContent);

    // Haal de dia-grootte op.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Converteer de SVG-afbeelding naar een groep vormen en schaal deze naar de dia-grootte.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Sla de presentatie op in PPTX-formaat.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Afbeeldingen als EMF toevoegen aan dia's**

Aspose.Slides for PHP via Java stelt je in staat om EMF‑afbeeldingen te genereren vanuit Excel‑werkbladen met Aspose.Cells en deze toe te voegen aan presentatiedia's.

De volgende PHP‑voorbeeldcode laat zien hoe je dit doet:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Sla de werkmap op in een stream.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Voeg het bestand toe zoals het is zodat de afbeelding een vector‑EMF blijft in plaats van gerasterd te worden.
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

## **Afbeeldingen vervangen in de afbeeldingencollectie**

Aspose.Slides laat je afbeeldingen die in de afbeeldingencollectie van een presentatie zijn opgeslagen vervangen, inclusief afbeeldingen die door dia‑vormen worden gebruikt. Deze sectie beschrijft verschillende manieren om afbeeldingen in de collectie bij te werken. Je kunt een afbeelding vervangen met ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/)-instantie, of een andere afbeelding die al in de collectie bestaat.

Volg de onderstaande stappen:

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)-klasse.
1. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
1. Vervang de doel‑afbeelding door de nieuwe afbeelding met behulp van de byte‑array.
1. In de tweede aanpak, laad de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/)-object en vervang de doel‑afbeelding met dat object.
1. In de derde aanpak, vervang de doel‑afbeelding door een afbeelding die al bestaat in de afbeeldingencollectie van de presentatie.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```php
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
$presentation = new Presentation("sample.pptx");
try {
    // De eerste manier.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // De tweede manier.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // De derde manier.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Sla de presentatie op naar een bestand.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Met Aspose's gratis [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter kun je eenvoudig tekst animeren en GIF‑bestanden uit tekst maken. 
{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na het invoegen?**

Ja. De bronpixels worden bewaard, maar het uiteindelijke resultaat hangt af van hoe de [picture](/slides/nl/php-java/picture-frame/) op de dia wordt geschaald en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's tegelijk te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingencollectie van de presentatie—updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden geconverteerd naar bewerkbare vormen?**

Ja. Je kunt een SVG omzetten naar een groep vormen; daarna kunnen individuele delen bewerkt worden met de standaard vorm‑eigenschappen.

**Hoe kan ik één afbeelding als achtergrond voor meerdere dia's tegelijk instellen?**

[Stel de afbeelding in als achtergrond](/slides/nl/php-java/presentation-background/) op de master‑dia of de betreffende lay‑out—alle dia's die die master/lay‑out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat een presentatie te groot wordt door veel afbeeldingen?**

Hergebruik een enkele afbeeldingsbron in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en houd herhaalde grafieken op de master waar dat gepast is.