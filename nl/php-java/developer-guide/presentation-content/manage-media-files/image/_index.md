---
title: Optimaliseer Beeldbeheer in Presentaties met PHP
linktitle: Afbeeldingen Beheren
type: docs
weight: 10
url: /nl/php-java/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- afbeelding vervangen
- afbeeldingscollectie
- afbeeldingsframe
- gekoppelde afbeelding
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- SVG naar vormen
- externe SVG-bronnen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u raster- en SVG-afbeeldingen kunt toevoegen, hergebruiken, koppelen, vervangen en beheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java."
---
## **Introductie**

Aspose.Slides voor PHP via Java biedt verschillende manieren om met afbeeldingen te werken, en elke manier heeft een eigen doel. Je kunt een afbeelding opslaan in een presentatie, weergeven in een afbeeldingsframe, gebruiken als slide‑achtergrond, koppelen aan een externe afbeelding, een gedeelde afbeeldingbron vervangen, of SVG‑inhoud omzetten naar bewerkbare vormen.

Dit artikel richt zich op afbeeldingsbronnen en hoe ze in een presentatie worden gebruikt. Voor bijsnijden, transparantie, effecten, uitrekken en andere opmaak die op een individueel afbeeldingsframe wordt toegepast, zie [Picture Frame](/slides/nl/php-java/picture-frame/).

## **Begrijp het afbeeldingsmodel**

De volgende API‑concepten hangen nauw samen maar zijn niet uitwisselbaar:

- De [presentatie‑afbeeldingscollectie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/) slaat afbeeldingsbronnen op die door de presentatie worden gebruikt. Gebruik [ImageCollection::addImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/) om afbeeldingsdata toe te voegen en een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) resource te verkrijgen.
- Een [picture frame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) is een vorm die een afbeelding weergeeft op een slide, lay-out of master. Gebruik [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addpictureframe/) om een afbeeldingsresource op een slide te plaatsen.
- Een slide‑achtergrond gebruikt een afbeelding als onderdeel van de slide‑vulling in plaats van als een vorm. Het gedraagt zich daarom niet als een picture frame.
- [PPImage::replaceImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) vervangt een afbeeldingsresource. Als verschillende presentatie‑elementen die resource gebruiken, maken ze allemaal gebruik van de vervanging.
- Het converteren van een SVG naar vormen creëert bewerkbare slide‑vormen. Na de conversie wordt de inhoud niet meer beheerd als één afbeeldingsresource.

Een typische workflow is dus: afbeeldingsdata toevoegen aan de afbeeldingscollectie, een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) ontvangen en vervolgens die resource gebruiken in één of meer picture frames of vullingen.

## **Voeg een ingebedde afbeelding toe**

Om een lokale afbeelding in te voegen, laad je het bestand, voeg je het toe aan de afbeeldingscollectie en maak je een picture frame aan dat de geretourneerde `PPImage` gebruikt.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De op deze manier toegevoegde afbeelding wordt ingebed in de presentatie, zodat het resulterende bestand niet afhankelijk is van de beschikbaarheid van het oorspronkelijke afbeeldingsbestand.

### **Voeg een afbeelding van het web toe**

Wanneer een afbeelding beschikbaar is via HTTP of HTTPS, download je de bytes, voeg je ze toe aan de presentatie‑afbeeldingscollectie en gebruik je de geretourneerde afbeeldingsresource op dezelfde manier als een lokale afbeelding.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

In langdurige toepassingen moet je een HTTP‑client of een verbinding‑beheersstrategie hergebruiken die geschikt is voor de applicatie, in plaats van herhaaldelijk onnodige netwerkinfrastructuur te creëren. Valideer ook externe URL’s, responsgroottes en content‑types wanneer de bron niet vertrouwd is.

## **Afbeeldingen hergebruiken over slides**

Als dezelfde afbeelding meer dan één keer nodig is, voeg je deze eenmaal toe aan de presentatie en hergebruik je de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) bij het maken van extra picture frames. Dit voorkomt herhaaldelijk laden van dezelfde brondata en maakt de relatie tussen de gedeelde afbeeldingsresource en het gebruik ervan expliciet.

Voor grafische elementen die automatisch op veel slides moeten verschijnen, zoals een bedrijfslogo, kun je overwegen het picture frame op een [slide master](/slides/nl/php-java/slide-master/) of lay-out te plaatsen in plaats van een gelijkwaardige vorm aan elke slide toe te voegen.

## **Een afbeelding gebruiken als slide‑achtergrond**

Een achtergrondafbeelding wordt toegewezen aan de slide‑vulling; ze wordt niet toegevoegd als een picture‑frame vorm. Dit is handig wanneer de afbeelding de slide‑achtergrond moet bedekken en niet moet worden gemanipuleerd als een normaal slide‑object.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Voor extra achtergrondopties, inclusief master‑ en lay‑outachtergronden, zie [Presentation Background](/slides/nl/php-java/presentation-background/).

## **Ingebedde afbeeldingen en gekoppelde afbeeldingen**

Ingebedde en gekoppelde afbeeldingen hebben verschillende portabiliteit‑ en bestandsgrootte‑afwegingen:

- **Ingebedde afbeelding:** de afbeeldingsdata wordt opgeslagen binnen de presentatie. De presentatie is zelf‑containend, maar de bestandsgrootte bevat de afbeeldingsdata.
- **Gekoppelde afbeelding:** de presentatie slaat een pad of URL op naar een externe afbeelding. Dit kan de presentatiegrootte verkleinen, maar de externe bron moet beschikbaar blijven wanneer de presentatie wordt geopend of gerenderd.

Een gekoppelde afbeelding kan worden gemaakt door het externe pad of de URL toe te wijzen via [Picture::setLinkPathLong](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picture/) in plaats van de afbeeldingsdata in te sluiten.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gebruik gekoppelde afbeeldingen alleen wanneer de deployment‑omgeving betrouwbaar toegang heeft tot de externe bron. Voor presentaties die offline moeten werken of tussen systemen verplaatst moeten worden, zijn ingebedde afbeeldingen doorgaans veiliger.

## **Werken met SVG‑afbeeldingen**

SVG is een vectorformaat, waardoor het nuttig kan zijn voor iconen, diagrammen en andere grafische elementen die kunnen schalen zonder hetzelfde verlies aan details als rasterafbeeldingen. Aspose.Slides ondersteunt SVG zowel als afbeeldingsresource als bron voor bewerkbare slide‑vormen.

### **Voeg een SVG toe als afbeelding**

Maak een [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/), voeg deze toe aan de afbeeldingscollectie en plaats de resulterende afbeeldingsresource in een picture frame.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **SVG‑bestanden met externe bronnen**

Een SVG kan externe afbeeldingen, stylesheets of lettertypen refereren. Voor deze gevallen biedt [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/) constructors die een [ExternalResourceResolver](https://reference.aspose.com/slides/nl/php-java/aspose.slides/externalresourceresolver/) en een basis‑URI accepteren. De resolver kan een relatieve URI naar een toegestane absolute URI mappen en een stream teruggeven voor de gevraagde bron.

De resolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt, maar herschrijft de SVG niet naar een zelf‑containend document. Als de SVG portabel moet blijven, embed dan de benodigde resources direct in de SVG, bijvoorbeeld door `data:`‑URI’s te gebruiken voor gekoppelde afbeeldingen.

Wanneer SVG‑bestanden afkomstig zijn van onbetrouwbare bronnen, beperk dan de schema’s, bestandslocaties en hosts waartoe de resolver toegang heeft. Netwerk‑resolvers moeten ook time‑outs, limieten voor respons‑grootte en content‑validatie toepassen.

### **SVG omzetten naar bewerkbare vormen**

Aspose.Slides kan een SVG omzetten in een groep bewerkbare slide‑vormen, vergelijkbaar met de overeenkomstige PowerPoint‑opdracht.

![PowerPoint Popup Menu](img_01_01.png)

Gebruik de [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addgroupshape/) overload die een [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/) accepteert om de conversie uit te voeren.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gebruik de SVG‑naar‑vormen conversie wanneer individuele vector‑elementen als PowerPoint‑vormen bewerkt moeten worden. Als de SVG alleen weergegeven hoeft te worden, is het behouden als afbeelding eenvoudiger en vermijdt het het maken van veel afzonderlijke vormen.

## **Vervangen van een bestaande afbeeldingsresource**

Gebruik [PPImage::replaceImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) wanneer je een bestaande afbeeldingsresource wilt vervangen. Dit is vooral handig voor gedeelde grafische elementen zoals logo’s.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Als meerdere picture frames, achtergronden, masters of lay-outs dezelfde afbeeldingsresource gebruiken, zorgt het vervangen van die resource voor een update van al die toepassingen. Als slechts één picture frame moet veranderen, wijs dan een andere afbeelding toe aan dat frame in plaats van de gedeelde resource te vervangen.

`PPImage::replaceImage` biedt ook overloads die een byte‑array of een andere [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) accepteren.

## **Praktische richtlijnen voor afbeeldingsbeheer**

### **Presentatiegrootte beheersen**

Grote rasterafbeeldingen kunnen een presentatie onnodig groot maken. Gebruik bron‑afbeeldingen met afmetingen die passen bij de beoogde weergavegrootte, hergebruik gedeelde afbeeldingsbronnen waar mogelijk, en vermijd het inbedden van meerdere kopieën van dezelfde afbeelding met volledige resolutie.

Voor rasterafbeeldingen die al in picture frames zijn geplaatst, kan [PictureFillFormat::compressImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/) de afbeeldingsdata verkleinen op basis van de gekozen resolutie en bijsnijdinstellingen. Dit is picture‑frame verwerking in plaats van beheer van de afbeeldingscollectie, dus zie [Picture Frame](/slides/nl/php-java/picture-frame/) voor gerelateerde opmaakbewerkingen.

### **Kiezen tussen ingebedde en gekoppelde inhoud**

Inbedden maakt de presentatie draagbaar omdat alle benodigde afbeeldingsdata met het bestand meereist. Koppelen kan de bestandsgrootte verkleinen, maar introduceert een externe afhankelijkheid. Gebruik links alleen wanneer die afhankelijkheid acceptabel en stabiel is.

### **Gedeelde branding hergebruiken**

Voor herhaalde logo’s, watermerken of decoratieve grafische elementen, gebruik één afbeeldingsresource en hergebruik deze. Als het grafische element deel uitmaakt van het presentatiedesign in plaats van van de slide‑inhoud, plaats het dan op een master of lay-out zodat het wordt overgeërfd door de betreffende slides.

### **SVG‑bronnen draagbaar houden**

Een zelf‑containende SVG is makkelijker te verplaatsen en consistent te renderen dan een SVG die afhankelijk is van externe bestanden of netwerkbronnen. Voeg indien mogelijk de benodigde bronnen in voordat je de SVG importeert. Converteer SVG naar vormen alleen wanneer de individuele vector‑elementen bewerkt moeten worden.

### **Gebruik de moderne cross‑platform afbeelding‑API**

Voor nieuwe PHP‑via‑Java‑code, gebruik de Aspose.Slides [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) en [Images](https://reference.aspose.com/slides/nl/php-java/aspose.slides/images/) API’s in plaats van de oude publieke API gebaseerd op `java.awt.image.BufferedImage`. Zie [Modern API](/slides/nl/php-java/modern-api/) voor migratierichtlijnen.

WMF‑ en EMF‑bestanden vereisen speciale aandacht. Wanneer deze formaten via een [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) worden verwerkt, converteert [ImageCollection::addImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/) de metafile naar een raster‑PNG‑representatie vóór invoeging. Als het behouden van de metafile‑data belangrijk is, gebruik dan een stream‑gebaseerde [ImageCollection::addImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/) overload. Het genereren van EMF‑content vanuit spreadsheets of andere producten is een apart integratieworkflow en valt buiten de reikwijdte van dit artikel.

## **FAQ**

**Wat is het verschil tussen de afbeeldingscollectie en een picture frame?**

De afbeeldingscollectie slaat herbruikbare afbeeldingsbronnen op. Een picture frame is een slide‑vorm die een van die bronnen weergeeft en picture‑specifieke opmaak biedt, zoals bijsnijden en effecten.

**Wat is de beste manier om hetzelfde logo overal te vervangen?**

Als het logo al gedeeld wordt als één afbeeldingsresource, vervang die resource met [PPImage::replaceImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/). Voor merk‑identiteit over de hele presentatie kan het plaatsen van het logo op een master of lay-out eveneens de duplicatie van slide‑inhoud verminderen.

**Waarom verdwijnt een gekoppelde afbeelding op een andere computer?**

Een gekoppelde afbeelding is afhankelijk van het externe bestand of de URL. Als die bron niet bereikbaar is vanaf de andere computer, kan de gekoppelde afbeelding ontbreken. Embed de afbeelding wanneer de presentatie zelf‑containend moet zijn.

**Kan een ingevoegde SVG bewerkt worden als PowerPoint‑vormen?**

Ja. Converteer de SVG met [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addgroupshape/); de resulterende groep bevat bewerkbare slide‑vormen in plaats van één SVG‑afbeelding.

**Hoe kan ik presentaties met veel afbeeldingen kleiner houden?**

Hergebruik gedeelde afbeeldingsbronnen, vermijd onnodig grote rasterbronnen, comprimeer geschikte rasterafbeeldingen wanneer passend, houd herhaalde branding op masters of lay‑outs, en gebruik gekoppelde afbeeldingen alleen wanneer een externe afhankelijkheid acceptabel is.