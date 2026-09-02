---
title: Beheer afbeeldingframes in presentaties met PHP
linktitle: Afbeeldingframe
type: docs
weight: 10
url: /nl/php-java/picture-frame/
keywords:
- afbeeldingframe
- afbeeldingframe toevoegen
- afbeeldingframe maken
- ingebedde afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- afbeeldingframe opmaak
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Afbeeldingframes maken, opmaken, koppelen, bijsnijden, extraheren en comprimeren in presentaties met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Een afbeeldingframe is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsbron en de vorm die deze weergeeft afzonderlijke objecten: een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) bezit ingebedde afbeeldingsbronnen via zijn [ImageCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/), terwijl een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingseffecten en andere frame‑niveau instellingen van de afbeelding regelt.

Deze scheiding is nuttig wanneer dezelfde afbeelding meer dan één keer wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/), en gebruik die afbeeldingsbron bij het maken van afbeeldingframes.

Afbeeldingframes kunnen rasterafbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie‑ en exportgedrag, dus het is handig om te bepalen hoe de afbeelding moet worden opgeslagen voordat opmaak of optimalisatie wordt toegepast.

## **Een ingebedde afbeelding toevoegen en opmaken**

Voor een ingebedde afbeelding voeg je de afbeeldingsgegevens toe aan de presentatie en maak je een afbeeldingframe met [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addpictureframe/). De afbeelding wordt onderdeel van het presentatiepakket, zodat de presentatie zelf‑voorzienend blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een JPEG‑afbeelding toe, maakt een frame met de oorspronkelijke afmetingen van de afbeelding en past lijnopmaak en rotatie toe:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het afbeeldingframe bepaalt de weergegeven geometrie; het wijzigen van de framegrootte verandert niet de oorspronkelijke pixelafmetingen die in de ingebedde afbeeldingsbron zijn opgeslagen. Dit onderscheid wordt belangrijk bij later bijsnijden of comprimeren van een afbeelding.

## **Relatieve schaal gebruiken**

[PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) biedt relatieve breedte‑ en hoogte‑schaal voor het frame via [setRelativeScaleWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/setrelativescalewidth/) en [setRelativeScaleHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldingsgrootte. Relatieve schaal is handig wanneer een workflow een verhouding tot de bronafbeelding wil behouden in plaats van de uiteindelijke afmetingen handmatig te berekenen.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Relatieve schaal wijzigt de schaalinstellingen van het frame; het resamplet of comprimeert de ingebedde afbeelding niet.

## **Ingebedde en gekoppelde afbeeldingen**

Een ingebedde afbeelding slaat afbeeldingsgegevens binnen de presentatie op en is daardoor de veiligste keuze voor draagbaarheid en voorspelbare rendering. Een gekoppelde afbeelding slaat een externe locatie op via de [Picture::setLinkPathLong](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picture/setlinkpathlong/)‑methode in plaats van de afbeeldingsgegevens in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingdata in de PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de toepassing die de presentatie opent of rendert. Als het pad verandert, het bestand wordt verplaatst of de bron niet beschikbaar is, wordt de gekoppelde afbeelding mogelijk niet weergegeven zoals verwacht. Voor presentaties die moeten worden gemaild, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingebedde afbeeldingen over het algemeen betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een afbeeldingframe en wijst het naar een lokaal afbeeldingsbestand. Het behandelt alleen beeldkoppeling; video‑koppeling is een aparte media‑workflow en wordt bewust niet gemengd in dit voorbeeld.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet enkel als vervanging voor compressie: een kleine PPTX met gebroken afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere zelf‑voorzienende presentatie.

## **Afbeeldingen uit afbeeldingframes extraheren**

Controleer vóór het extraheren van een afbeelding uit een bestaande presentatie of een vorm daadwerkelijk een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) is en of deze een ingebedde afbeelding bevat. Gekoppelde afbeeldingframes bevatten mogelijk geen afbeeldingsbytes die op dezelfde manier kunnen worden geëxtraheerd.

### **Een raster‑afbeelding extraheren**

De moderne afbeelding‑API gebruikt [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) rechtstreeks. Het volgende voorbeeld zoekt de eerste ingebedde raster‑afbeelding op een dia en slaat deze op als PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Opslaan via [IImage::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/#save) converteert de geëxtraheerde afbeelding naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes wilt die in de presentatie zijn opgeslagen in plaats van een geconverteerd raster‑bestand, gebruik dan de binaire gegevens van de afbeeldingsbron.

### **Een SVG‑afbeelding extraheren**

Voor een SVG‑afbeelding biedt de [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) een [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/)‑object. Hiermee kun je de SVG‑data direct ophalen in plaats van de afbeelding eerst te rasteren.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Het behouden van SVG‑inhoud als SVG bewaart de vectorbron binnen de presentatie. Raster‑exports zoals PNG of JPEG renderen die vectorinhoud noodzakelijkerwijs naar pixels. PDF‑ of SVG‑dia‑export is ook een render‑operatie, dus de geëxporteerde grafieken moeten niet worden beschouwd als een bit‑voor‑bit‑kopie van de oorspronkelijke ingebedde SVG; gebruik de ingebedde [SvgImage::getSvgData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/getsvgdata/)‑data wanneer de originele vectorbron zelf vereist is.

## **Een afbeelding bijsnijden**

Bijsnijden wijzigt welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/) zijn percentages van de afmetingen van de bronafbeelding. Bijsnijden verwijdert de verborgen pixels niet meteen uit de ingebedde afbeelding; het wijzigt alleen het zichtbare gebied.

Het volgende voorbeeld zoekt veilig een afbeeldingframe en past bijsnijdwaarden toe:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Omdat de verborgen afbeeldingsdata nog aanwezig is, kan de bijsnijding later worden aangepast zonder de originele pixels te verliezen. Als bestandsgrootte belangrijker is dan herhaalbaarheid, kunnen de bijgesneden regio’s fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden afbeeldingsdata verwijderen**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) verwijdert afbeeldingsdata buiten het huidige bijsnijd‑rechthoek en retourneert de resulterende afbeeldingsbron. Dit kan de bestandsgrootte verkleinen, maar het is een destructieve optimalisatie: na het opslaan van de presentatie zijn de verwijderde pixels niet meer beschikbaar voor een latere on‑crop‑bewerking.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

De methode kan een nieuwe afbeeldingsbron aan de presentatie toevoegen. Als de oorspronkelijke afbeelding ook door andere afbeeldingframes wordt gebruikt, hebben die frames hun bestaande bron nog steeds nodig, dus het verwijderen van bijgesneden gebieden vermindert niet noodzakelijkerwijs het totale aantal afbeeldingen. Het bijsnijden van WMF‑ of EMF‑content met deze methode rastert het bijgesneden resultaat naar PNG.

## **Raster‑afbeeldingen comprimeren**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) verlaagt de raster‑afbeeldingsresolutie relatief tot de grootte waarop de afbeelding wordt weergegeven. Het kan ook bijgesneden regio’s in dezelfde bewerking verwijderen. De methode retourneert `true` wanneer de afbeelding is geschaald of bijgesneden en `false` wanneer er geen wijziging nodig was.

Gebruik een vooraf gedefinieerde [PicturesCompression](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturescompression/)‑waarde wanneer een standaard doelresolutie voldoende is:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Een aangepaste positieve DPI‑waarde kan worden doorgegeven in plaats van een vooraf gedefinieerde waarde wanneer een specifiek doel vereist is.

Compressie is bedoeld voor raster‑afbeeldingen. SVG‑ en metafile‑content wordt niet gereduceerd door deze raster‑compressieworkflow. Vergeet ook niet dat een lagere resolutie en verwijderde bijgesneden regio’s niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie op basis van de grootste weergave‑ of exportgrootte van de afbeelding in plaats van overal de laagste DPI toe te passen.

## **Afbeelding‑transformatieteffecten beheren**

Voor een volledige workflow met helderheid, contrast, kleuropties, vervaging, alfa‑effecten, geordende ketens, inspectie, verwijdering en round‑trip‑verificatie, zie [Image Transform Effects](/slides/nl/php-java/image-transform-effects/).

## **Geometrie van afbeeldingframe vergrendelen**

De [PictureFrameLock](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframelock/)‑instellingen bepalen welke bewerkingsacties uitgeschakeld zijn voor een afbeeldingframe. Bijvoorbeeld, [setAspectRatioLocked](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) behoudt de verhoudingen van de vorm tijdens het schalen.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De vergrendeling geldt voor de vorm van het afbeeldingframe. Het dwingt de bronafbeelding niet om te worden geresampled of permanent te worden gewijzigd naar dezelfde beeldverhouding.

## **De StretchOffset‑waarden aanpassen**

Wanneer de opvulmodus van de afbeelding “stretch” is, definiëren de stretch‑offset‑waarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/) het opvul‑rechthoek ten opzichte van de begrenzende doos van het afbeeldingframe. Positieve percentages creëren een inset vanaf een rand, terwijl negatieve percentages een outset creëren.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare afbeelding‑opvulling wordt uitgerekt.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gebruik stretch‑offsets voor plaatsing van opvulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om randen van de bronafbeelding te verbergen.

## **Opslag, bestandsgrootte en exportoverwegingen**

De belangrijkste afwegingen zijn makkelijker te beheren wanneer afbeelding‑opslag en afbeeldingframe‑opmaak apart worden behandeld:

- **Ingebedde afbeeldingen** maken de presentatie zelf‑voorzienend en zijn het meest betrouwbaar voor delen en server‑side rendering, maar grote raster‑afbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die beschikbaar blijven op de opgeslagen paden of locaties.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingebed totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie worden weggehaald.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote raster‑afbeeldingen, maar het schaft in op resolutie van de bron. Het moet worden toegepast nadat de beoogde weergavegrootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten behouden blijven als SVG wanneer vectorbehoud belangrijk is. Extraheer de ingebedde SVG direct wanneer je de vectorbron zelf nodig hebt. Raster‑dia‑exports converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten een bestaande [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑bron hergebruiken wanneer mogelijk in plaats van steeds opnieuw hetzelfde bestand in de presentatieworkflow te laden.

Voor grote presentaties is afbeelding‑optimalisatie meestal het meest effectief wanneer selectief wordt toegepast: houd logo’s en diagrammen als vector‑content, comprimeer foto’s volgens hun werkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet vereist is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een afbeeldingframe en een afbeeldingsbron?**

Een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) vertegenwoordigt een afbeeldingsbron die aan de presentatie is gekoppeld. Een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau geometrie en opmaak opslaat, zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen insluiten of koppelen?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet kunnen worden zonder toegang tot externe bronnen. Koppel afbeeldingen alleen wanneer het buiten de PPTX houden van afbeeldingsbestanden opzettelijk is en de externe locaties betrouwbaar kunnen worden beheerd.

**Vermindert bijsnijden de PPTX‑bestandsgrootte?**

Niet op zich alleen. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) of afbeeldingcompressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden weggehaald.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen raster‑resolutie verlagen, en het verwijderen van bijgesneden regio’s wist afbeeldingsdata. Bewaar de originele bronafbeelding buiten de presentatie als latere bewerkingen in hoge resolutie nodig kunnen zijn.

**Hoe moet ik met SVG‑afbeeldingen omgaan?**

Houd SVG‑content als SVG wanneer vector‑fidelity van belang is. De ingebedde [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/) kan direct worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype vóór het gebruiken van leden die specifiek zijn voor afbeeldingframes. Een `java_instanceof`‑controle tegen [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) voorkomt ongeldige casts en stelt de code in staat om dia’s die geen afbeeldingframes bevatten adequaat af te handelen.