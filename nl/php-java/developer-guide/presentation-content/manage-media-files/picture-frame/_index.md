---
title: Beheer afbeeldingsframes in presentaties met PHP
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/php-java/picture-frame/
keywords:
- afbeeldingsframe
- afbeeldingsframe toevoegen
- afbeeldingsframe maken
- ingebedde afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- opmaak van afbeeldingsframe
- relatieve schaal
- afbeeldingeffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Maak, formatteer, koppel, snijd bij, extraheer en comprimeer afbeeldingsframes in presentaties met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Een afbeeldingframe is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsresource en de vorm die deze weergeeft afzonderlijke objecten: een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) beheert ingebedde afbeeldingsresources via zijn [ImageCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/), terwijl een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingseffecten en andere instellingen op frame‑niveau regelt.

Deze scheiding is nuttig wanneer dezelfde afbeelding meer dan één keer wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/), en gebruik die afbeeldingsresource bij het maken van afbeeldingframes.

Afbeeldingframes kunnen rasterafbeeldingen bevatten, zoals PNG of JPEG, en vector‑SVG‑afbeeldingen. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is handig om vóór het toepassen van opmaak of optimalisatie te bepalen hoe de afbeelding moet worden opgeslagen.

## **Afbeelding toevoegen en opmaken**

Voor een ingebedde afbeelding voeg je de afbeeldingsdata toe aan de presentatie en maak je een afbeeldingframe met [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addpictureframe/). De afbeelding wordt onderdeel van het presentatiepakket, zodat de presentatie zelf‑bevat blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een JPEG‑afbeelding toe, creëert een frame op de oorspronkelijke afmetingen van de afbeelding en past lijnopmaak en rotatie toe:

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

Het afbeeldingframe bepaalt de weergegeven geometrie; het wijzigen van de framegrootte verandert de oorspronkelijke pixelafmetingen die zijn opgeslagen in de ingebedde afbeeldingsresource niet. Dit onderscheid wordt later belangrijk bij het bijsnijden of comprimeren van een afbeelding.

## **Relatieve schaal gebruiken**

[PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) biedt relatieve breedte‑ en hoogteschaal voor het frame via [setRelativeScaleWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/setrelativescalewidth/) en [setRelativeScaleHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldingsgrootte. Relatieve schaal is handig wanneer een workflow de relatie met de bronafbeeldingsgrootte moet behouden in plaats van de uiteindelijke afmetingen handmatig te berekenen.

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

Relatieve schaal wijzigt de schaalinstellingen van het frame; het herschaalt of comprimeert de ingebedde afbeelding niet.

## **Ingebedde en gekoppelde afbeeldingen**

Een ingebedde afbeelding slaat afbeeldingsdata op binnen de presentatie en is daardoor de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding slaat een externe locatie op via de [Picture::setLinkPathLong](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picture/setlinkpathlong/)‑methode in plaats van de afbeeldingsdata op dezelfde manier in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in de PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de applicatie die de presentatie opent of rendert. Als het pad verandert, het bestand wordt verplaatst of de resource niet beschikbaar is, wordt de gekoppelde afbeelding mogelijk niet zoals verwacht weergegeven. Voor presentaties die per e‑mail moeten worden verzonden, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingebedde afbeeldingen doorgaans betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een afbeeldingframe aan en wijst het naar een lokaal afbeeldingsbestand. Het behandelt alleen afbeeldingskoppelingen; video‑koppelingen zijn een aparte media‑workflow en worden opzettelijk niet in dit voorbeeld gemengd.

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

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet enkel als vervanging voor compressie: een kleine PPTX met kapotte afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere, zelf‑bevat presentatie.

## **Afbeeldingen extraheren uit afbeeldingframes**

Controleer vóór het extraheren van een afbeelding uit een bestaande presentatie of een vorm daadwerkelijk een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) is en of deze een ingebedde afbeelding bevat. Gekoppelde afbeeldingframes bevatten mogelijk geen afbeeldingsbytes die op dezelfde manier kunnen worden geëxtraheerd.

### **Rasterafbeelding extraheren**

De moderne afbeelding‑API gebruikt rechtstreeks [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/). Het volgende voorbeeld vindt de eerste ingebedde rasterafbeelding op een dia en slaat deze op als PNG:

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

Opslaan via [IImage::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/#save) converteert de geëxtraheerde afbeelding naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes die in de presentatie zijn opgeslagen nodig hebt in plaats van een geconverteerd rasterbestand, gebruik dan in plaats daarvan de binaire gegevens van de afbeeldingsresource.

### **SVG‑afbeelding extraheren**

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

SVG‑inhoud behouden als SVG bewaart de vectorbron binnen de presentatie. Rasterexporten zoals PNG of JPEG renderen die vectorinhoud onvermijdelijk naar pixels. PDF‑ of SVG‑dia‑export is eveneens een render‑operatie, dus de geëxporteerde graphics moeten niet worden behandeld als een exacte byte‑voor‑byte kopie van de oorspronkelijke ingebedde SVG; gebruik de ingebedde [SvgImage::getSvgData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/getsvgdata/)‑data wanneer de oorspronkelijke vectorresource zelf vereist is.

## **Afbeelding bijsnijden**

Bijsnijden verandert welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/) zijn percentages van de bronafbeeldingsafmetingen. Bijsnijden verwijdert de verborgen pixels niet onmiddellijk uit de ingebedde afbeelding; het wijzigt alleen het zichtbare gebied.

Het volgende voorbeeld vindt veilig een afbeeldingframe en past bijsnijdwaarden toe:

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

Aangezien de verborgen afbeeldingsdata nog aanwezig is, kan de bijsnijding later worden aangepast zonder de oorspronkelijke pixels te verliezen. Als bestandsgrootte belangrijker is dan omkeerbaarheid, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden afbeeldingsdata verwijderen**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) verwijdert afbeeldingsdata buiten het huidige bijsnijdrechthoek en retourneert de resulterende afbeeldingsresource. Dit kan de bestandsgrootte verkleinen, maar het is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet langer beschikbaar voor een latere ontbijsnijd‑bewerking.

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

De methode kan een nieuwe afbeeldingsresource aan de presentatie toevoegen. Als de oorspronkelijke afbeelding ook door andere afbeeldingframes wordt gebruikt, hebben die frames hun bestaande resource nog steeds nodig, waardoor het verwijderen van bijgesneden gebieden niet per‑se het totale aantal afbeeldingen vermindert. Het bijsnijden van WMF‑ of EMF‑content met deze methode rastert het bijgesneden resultaat naar PNG.

## **Rasterafbeeldingen comprimeren**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) verlaagt de resolutie van rasterafbeeldingen ten opzichte van de grootte waarin de afbeelding wordt weergegeven. Het kan ook bijgesneden gebieden in dezelfde bewerking verwijderen. De methode retourneert `true` wanneer de afbeelding is herschaald of bijgesneden en `false` wanneer er geen wijziging nodig was.

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

Een aangepaste positieve DPI‑waarde kan worden meegegeven in plaats van een vooraf gedefinieerde waarde wanneer een specifiek doel vereist is.

Compressie is bedoeld voor rasterafbeeldingen. SVG‑ en meta‑file‑content wordt niet gereduceerd door deze rastercompressieworkflow. Vergeet ook niet dat lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie op basis van de grootste afmeting waarop de afbeelding daadwerkelijk wordt bekeken of geëxporteerd, in plaats van overal de laagste DPI toe te passen.

## **Afbeeldingseffecten inspecteren**

Afbeeldingseffecten worden opgeslagen op de afbeelding die door het frame wordt gebruikt. De afbeelding‑transformatieset kan effecten bevatten zoals vaste alfa‑modulatie voor transparantie en luminantie voor helderheid en contrast. Het onderstaande voorbeeld leest veilig beide soorten effecten uit het eerste afbeeldingframe op een dia:

```php
use aspose\slides\Presentation;

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
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Deze effecten veranderen hoe de afbeelding in het frame wordt gerenderd; ze herschrijven niet de oorspronkelijke ingebedde afbeeldingsbytes.

## **Geometrie van afbeeldingframe vergrendelen**

De [PictureFrameLock](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframelock/)‑instellingen bepalen welke bewerkingshandelingen voor een afbeeldingframe zijn uitgeschakeld. Bijvoorbeeld, [setAspectRatioLocked](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) behoudt de verhoudingen van de vorm tijdens het schalen.

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

De vergrendeling geldt voor de afbeeldingframe‑vorm. Het dwingt de bronafbeelding niet om opnieuw geschaald of permanent gewijzigd te worden naar dezelfde beeldverhouding.

## **StretchOffset‑waarden aanpassen**

Wanneer de opvulmodus van de afbeelding "stretch" is, definiëren de stretch‑offset‑waarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/) het opvulrechthoek ten opzichte van de omhullende box van het afbeeldingframe. Positieve percentages maken een insnijding vanaf een rand, terwijl negatieve percentages een uitstulping creëren.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets veranderen het rechthoek waarin de zichtbare afbeeldingspopulatie wordt gestrekt.

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

Gebruik stretch‑offsets voor het plaatsen van de opvulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om randen van de bronafbeelding te verbergen.

## **Opslag, bestandsgrootte en exportoverwegingen**

De belangrijkste afwegingen zijn gemakkelijker te beheren wanneer afbeeldingopslag en afbeeldingframe‑opmaak apart worden behandeld:

- **Ingebedde afbeeldingen** maken de presentatie zelf‑bevat en zijn het meest betrouwbaar voor delen en server‑side rendering, maar grote rasterafbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die op de opgeslagen paden of locaties beschikbaar blijven.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingebed totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote rasterafbeeldingen, maar het gaat ten koste van de bronresolutie. Het moet worden toegepast nadat de beoogde weergavegrootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten als SVG blijven wanneer behoud van vectoren belangrijk is. Extraheer de ingebedde SVG direct wanneer je de vectorresource zelf nodig hebt. Raster‑dia‑exports converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten een bestaande [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑resource hergebruiken wanneer mogelijk in plaats van steeds opnieuw hetzelfde bestand in de presentatieworkflow te laden.

Voor grote presentaties is afbeeldingoptimalisatie doorgaans het meest effectief wanneer deze selectief wordt uitgevoerd: houd logo's en diagrammen als vectorinhoud, comprimeer foto's volgens hun werkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet nodig is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een afbeeldingframe en een afbeeldingsresource?**

Een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) stelt een afbeeldingsresource voor die aan de presentatie is gekoppeld. Een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau geometrie en opmaak opslaat, zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen embedden of koppelen?**

Embed afbeeldingen wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet worden zonder toegang tot externe resources. Koppel afbeeldingen alleen wanneer het opzettelijk is om afbeeldingsbestanden buiten de PPTX te houden en de externe locaties betrouwbaar kunnen worden beheerd.

**Vermindert bijsnijden de PPTX‑bestandsgrootte?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) of afbeeldingcompressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden verwijderd.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verlagen, en het verwijderen van bijgesneden gebieden gooit afbeeldingsdata weg. Bewaar de originele bronafbeelding buiten de presentatie als later bewerking met hoge resolutie nodig kan zijn.

**Hoe moeten SVG‑afbeeldingen worden behandeld?**

Behoud SVG‑content als SVG wanneer vectorprecisie belangrijk is. De ingebedde [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/) kan direct worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia's?**

Controleer het vormtype voordat je picture‑frame‑specifieke leden gebruikt. Een `java_instanceof`‑controle op [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) voorkomt ongeldige casts en laat de code dia's afhandelen die geen afbeeldingframes bevatten.