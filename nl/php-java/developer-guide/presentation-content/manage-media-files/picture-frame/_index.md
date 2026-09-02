---
title: Beheer beeldframes in presentaties met PHP
linktitle: Beeldframe
type: docs
weight: 10
url: /nl/php-java/picture-frame/
keywords:
- beeldframe
- beeldframe toevoegen
- beeldframe maken
- ingesloten afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- beeldframe-opmaak
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Maak, formatteer, link, snijd bij, extraheer en comprimeer beeldframes in presentaties met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Een beeldframe is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsbron en de vorm die deze weergeeft aparte objecten: een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) bezit ingesloten afbeeldingsbronnen via zijn [ImageCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imagecollection/), terwijl een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingseffecten en andere instellingen op frame‑niveau regelt.

Deze scheiding is nuttig wanneer dezelfde afbeelding meer dan één keer wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/), en gebruik die afbeeldingsbron bij het maken van beeldframes.

Beeldframes kunnen rasterafbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is nuttig om vóór het toepassen van opmaak of optimalisatie te bepalen hoe de afbeelding moet worden opgeslagen.

## **Een ingesloten afbeelding toevoegen en opmaken**

Voor een ingesloten afbeelding voeg je de afbeeldingsdata toe aan de presentatie en maak je een beeldframe met [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addpictureframe/). De afbeelding wordt onderdeel van het presentatiepakket, zodat de presentatie zelf‑voorzien blijft wanneer deze naar een andere computer wordt verplaatst.

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

Het beeldframe bepaalt de weergegeven geometrie; het wijzigen van de frame‑grootte verandert de originele pixelafmetingen die in de ingesloten afbeeldingsbron zijn opgeslagen. Dit onderscheid wordt belangrijk bij later bijsnijden of comprimeren van een afbeelding.

## **Relatieve schaal gebruiken**

[PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) biedt relatieve breedte‑ en hoogte‑schaal voor het frame via [setRelativeScaleWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/setrelativescalewidth/) en [setRelativeScaleHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Een waarde van `1.0` komt overeen met 100 % van de originele afbeeldingsgrootte. Relatieve schaal is nuttig wanneer een werkstroom een relatie tot de bronafbeeldingsgrootte moet behouden in plaats van de uiteindelijke afmetingen handmatig te berekenen.

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

Relatieve schaal wijzigt de schaalinstellingen van het frame; het herschaalt of comprimeert de ingesloten afbeelding niet.

## **Ingesloten en gekoppelde afbeeldingen**

Een ingesloten afbeelding slaat afbeeldingsdata op binnen de presentatie en is daarom de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding bewaart een externe locatie via de [Picture::setLinkPathLong](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picture/setlinkpathlong/)‑methode in plaats van de afbeeldingsdata op dezelfde manier in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in de PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet beschikbaar blijven voor de applicatie die de presentatie opent of rendert. Als het pad wijzigt, het bestand wordt verplaatst of de bron niet meer beschikbaar is, wordt het gekoppelde beeld mogelijk niet zoals verwacht weergegeven. Voor presentaties die moeten worden gemaild, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingesloten afbeeldingen doorgaans betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een beeldframe aan en wijst het naar een lokaal afbeeldingsbestand. Het behandelt alleen afbeeldingkoppelingen; video‑koppelingen vormen een aparte media‑werkstroom en worden bewust niet gemengd in dit voorbeeld.

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

Gebruik koppelingen wanneer extern bestandbeheer opzettelijk is. Gebruik ze niet alleen als vervanging voor compressie: een kleine PPTX met kapotte afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere zelf‑voorzienende presentatie.

## **Afbeeldingen extraheren uit beeldframes**

Controleer vóór het extraheren van een afbeelding uit een bestaande presentatie of een vorm daadwerkelijk een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) is en of deze een ingesloten afbeelding bevat. Gekoppelde beeldframes kunnen mogelijk geen afbeeldingsbytes bevatten die op dezelfde manier kunnen worden geëxtraheerd.

### **Een raster‑afbeelding extraheren**

De moderne afbeeldings‑API gebruikt [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) direct. Het volgende voorbeeld vindt de eerste ingesloten raster‑afbeelding op een dia en slaat deze op als PNG:

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

Opslaan via [IImage::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/#save) converteert de geëxtraheerde afbeelding naar het gewenste uitvoerformaat. Als je de gecodeerde bytes wilt die in de presentatie zijn opgeslagen in plaats van een geconverteerd raster‑bestand, gebruik dan de binaire data van de afbeeldingsbron.

### **Een SVG‑afbeelding extraheren**

Voor een SVG‑beeld levert de [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) een [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/)‑object. Hiermee kun je de SVG‑data direct ophalen in plaats van de afbeelding eerst te rasteren.

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

Het behouden van SVG‑inhoud als SVG behoudt de vector‑bron binnen de presentatie. Raster‑exporten zoals PNG of JPEG renderen die vectorinhoud noodzakelijkerwijs om naar pixels. PDF‑ of SVG‑dia‑export is eveneens een render‑handeling, dus de geëxporteerde grafieken moeten niet worden beschouwd als een byte‑voor‑byte kopie van de originele ingesloten SVG; gebruik de ingesloten [SvgImage::getSvgData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/getsvgdata/)‑data wanneer de oorspronkelijke vector‑bron zelf vereist is.

## **Een afbeelding bijsnijden**

Bijsnijden verandert welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/) zijn percentages van de bronafbeeldingsafmetingen. Bijsnijden verwijdert de verborgen pixels niet onmiddellijk uit de ingesloten afbeelding; het verandert alleen het zichtbare gebied.

Het volgende voorbeeld zoekt veilig een beeldframe en past bijsnijdwaarden toe:

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

Omdat de verborgen afbeeldingsdata nog steeds aanwezig is, kan de bijsnijding later worden gewijzigd zonder de originele pixels te verliezen. Als bestandsgrootte belangrijker is dan terugdraaibaarheid, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden afbeeldingsdata verwijderen**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) verwijdert afbeeldingsdata buiten het huidige bijsnijdrechthoek en levert de resulterende afbeeldingsbron terug. Dit kan de bestandsgrootte verkleinen, maar het is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet meer beschikbaar voor een latere on‑crop‑operatie.

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

De methode kan een nieuwe afbeeldingsbron aan de presentatie toevoegen. Als de originele afbeelding ook door andere beeldframes wordt gebruikt, hebben die frames nog steeds hun bestaande bron nodig, waardoor het verwijderen van bijgesneden gebieden niet noodzakelijkerwijs het totale aantal afbeeldingen verlaagt. Het bijsnijden van WMF‑ of EMF‑inhoud met deze methode rastert het bijgesneden resultaat naar PNG.

## **Raster‑afbeeldingen comprimeren**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) vermindert de resolutie van raster‑afbeeldingen ten opzichte van de grootte waarin de afbeelding wordt weergegeven. Het kan tevens bijgesneden gebieden verwijderen in dezelfde bewerking. De methode retourneert `true` wanneer de afbeelding is verkleind of bijgesneden en `false` wanneer geen wijziging nodig was.

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

Een aangepaste positieve DPI‑waarde kan in plaats van een vooraf gedefinieerde waarde worden opgegeven wanneer een specifiek doel vereist is.

Compressie is bedoeld voor raster‑afbeeldingen. SVG‑ en metafile‑inhoud wordt niet verkleind door deze raster‑compressieworkflow. Denk er ook aan dat een lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie op basis van de grootste weergave‑ of exportgrootte van de afbeelding in plaats van globaal de laagste DPI toe te passen.

## **Beeld‑transformatie‑effecten beheren**

Voor een volledige werkstroom die helderheid, contrast, kleurovergangen, vervaging, alfa‑effecten, geordende ketens, inspectie, verwijdering en round‑trip‑verificatie omvat, zie [Image Transform Effects](/php-java/image-transform-effects/).

## **Beeldframe‑geometrie vergrendelen**

De [PictureFrameLock](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframelock/)‑instellingen bepalen welke bewerkingsacties zijn uitgeschakeld voor een beeldframe. Bijvoorbeeld, [setAspectRatioLocked](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) behoudt de verhoudingen van de vorm terwijl deze wordt geschaald.

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

De vergrendeling geldt voor de beeldframe‑vorm. Het dwingt de bronafbeelding niet tot herschalen of permanent wijzigen naar dezelfde beeldverhouding.

## **De StretchOffset‑waarden aanpassen**

Wanneer de opvulmodus van de afbeelding “stretch” is, bepalen de stretch‑offset‑waarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/) het opvullende rechthoek ten opzichte van de omhullende doos van het beeldframe. Positieve percentages creëren een inspringing vanaf een rand, terwijl negatieve percentages een uitstulping veroorzaken.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare afbeelding wordt uitgerekt.

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

Gebruik stretch‑offsets voor het positioneren van de opvulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om randen van de bronafbeelding te verbergen.

## **Opslag, bestandsgrootte en export‑overwegingen**

De belangrijkste afwegingen zijn gemakkelijker te beheren wanneer afbeeldingopslag en beeldframe‑opmaak afzonderlijk worden behandeld:

- **Ingesloten afbeeldingen** maken de presentatie zelf‑voorzien en zijn het betrouwbaarst voor delen en server‑side rendering, maar grote raster‑afbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die beschikbaar blijven op de opgeslagen paden of locaties.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingesloten totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie worden weggelaten.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote raster‑afbeeldingen, maar schaft resolutie van de bron in. Het moet worden toegepast nadat de beoogde grootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten als SVG blijven wanneer vectorbehoud belangrijk is. Extraheer de ingesloten SVG direct wanneer je de vector‑bron zelf nodig hebt. Raster‑dia‑exporten converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten bij voorkeur een bestaande [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/)‑bron hergebruiken in plaats van telkens dezelfde bestand opnieuw te laden in de werkstroom.

Voor grote presentaties is afbeeldingoptimalisatie meestal het meest effectief wanneer deze selectief wordt uitgevoerd: bewaar logo’s en diagrammen als vectorinhoud, comprimeer foto’s volgens hun werkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet nodig is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een beeldframe en een afbeeldingsbron?**

Een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) vertegenwoordigt een afbeeldingsbron die aan de presentatie is gekoppeld. Een [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau geometrie en opmaak opslaat zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen insluiten of koppelen?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet kunnen worden zonder toegang tot externe bronnen. Koppel afbeeldingen alleen wanneer het bewust is om afbeeldingsbestanden buiten de PPTX te houden en de externe locaties betrouwbaar kunnen worden onderhouden.

**Vermindert bijsnijden de bestandsgrootte van de PPTX?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) of afbeeldingscompressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden weggelaten.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verlagen, en het verwijderen van bijgesneden gebieden wis de afbeeldingsdata. Bewaar de originele bronafbeelding buiten de presentatie als later bewerken in hoge resolutie vereist kan zijn.

**Hoe moet ik SVG‑afbeeldingen behandelen?**

Behoud SVG‑inhoud als SVG wanneer vector‑fideliteit van belang is. De ingesloten [SvgImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/svgimage/) kan direct worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype voordat je beeldframe‑specifieke leden gebruikt. Een `java_instanceof`‑controle tegen [PictureFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pictureframe/) voorkomt ongeldige casts en laat de code dia’s die geen beeldframes bevatten adequaat afhandelen.