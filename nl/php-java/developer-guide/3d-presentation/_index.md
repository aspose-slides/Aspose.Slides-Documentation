---
title: 3D-effecten maken in presentaties met PHP
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentatie
- 3D-rotatie
- 3D-diepte
- 3D-extrusie
- 3D-verloop
- 3D-tekst
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in PHP met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for PHP via Java kan PowerPoint‑achtige 3D‑opmaak voor vormen en tekst maken, bewerken, behouden en renderen. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, afschuiningen, verlichting, materiaal, verloop‑ of afbeeldingvullingen en 3D‑tekst.

{{% alert color="info" title="Opmerking" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van afzonderlijke 3D‑modelfiles. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik de [Shape::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getThreeDFormat--) methode om 3D‑opmaak toe te passen op een vorm. De methode retourneert een [ThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#getThreeDFormat--) methode. Deze past 3D‑opmaak toe op het tekstframe in plaats van op het inhoudsdeel van de vorm.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het controleert | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getCamera--) | Kijkpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Het object in de 3D‑ruimte roteren of een PowerPoint‑3D‑rotatie‑preset matchen. |
| [getLightRig](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getLightRig--) | Lichtpreset, richting en lichtrotatie. | Wijzigen hoe hooglichten en schaduwen op het 3D‑oppervlak verschijnen. |
| [getMaterial](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getMaterial--) en [setMaterial](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Oppervlakte‑materiaal, zoals plat, mat, plastic of metaal. | Dezelfde geometrie er vlakker, zachter, glanzender of metaalachtig laten uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getExtrusionHeight--) en [setExtrusionHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Hoe ver de vorm naar achteren uitsteekt vanaf de voorzijde. | Een platte vorm omzetten in een zichtbaar dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Kleur van de uitgeschoven zijkanten. | Diepte zichtbaar maken of de kleur van de zijkant afstemmen op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getDepth--) en [setDepth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setDepth-double-) | Extra 3D‑diepte gebruikt door PowerPoint‑3D‑opmaak. | Diepte fijn afstellen voor vormen of tekst, vooral in combinatie met afschuiningen en materiaalinstellingen. |
| [getBevelTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getBevelBottom--) | Verhoogde of afgeronde randen op de voor‑ en achterkant. | Een verzachte of gevormde rand toevoegen in plaats van een scherpe platte zijde. |
| [getContourColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getContourColor--) en [getContourWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getContourWidth--) en [setContourWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Omtrek rond het 3D‑object. | De grens van het object benadrukken in de gerenderde uitvoer. |

## **Een 3D‑vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D oogt:

- Camera‑instellingen, want het standaard frontaalbeeld kan de extrusie verbergen.
- Licht‑instellingen, want verlichting maakt de vlakken en zijkanten leesbaar.
- Materiaal‑instellingen, want het oppervlak beïnvloedt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, want een platte vorm heeft dikte nodig.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De camerarotatie‑waarden staan in graden en de extrusie‑hoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De gerenderde dia‑afbeelding toont de rechthoek als een dik 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Een vorm draaien met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd vanuit het venster 3‑D‑rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u instelt via de camera‑API.

![PowerPoint‑venster 3‑D‑rotatie met gemarkeerde X, Y en Z rotatiewaarden](img_02_01.png)

In Aspose.Slides benadert u de camera via [ThreeDFormat::getCamera](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getCamera--). Dit voorbeeld maakt een rechthoek, kiest een orthografisch frontaalbeeld en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Gebruik de camera wanneer u de weergave van het object voor de kijker wilt wijzigen. Het verandert niet de 2D‑vorm‑geometrie op de dia. Het wijzigt het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie laat een vorm dikker lijken door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑regeling deze zichtbare dikte, en de kleurregeling bepaalt de kleur van de zijkanten.

![PowerPoint‑diepte‑regelingen gemapt op extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Gebruik [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) om de dikte in te stellen en [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getExtrusionColor--) om de zijkleur te benaderen. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en roteert de camera om de dikte te laten zien. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

De [ThreeDFormat::setDepth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setDepth-double-) methode stelt de diepte van een 3D‑vorm in. De [setExtrusionHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) methode regelt de hoogte van het extrusie‑effect, zoals in dit voorbeeld te zien.

## **Gradient‑ of afbeeldingvullingen gebruiken met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingvulling toepassen op de voorzijde en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen behouden.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorzijde en een donkeroranje kleur op de 150‑punt extrusie. De verloopstops op 0 en 100 markeren het begin en einde van het verloop. De camerarotatie‑waarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

De gerenderde uitvoer behoudt het verloop op de voorzijde en rendert de extrusie apart:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling. Dit voorbeeld veronderstelt een bestaand bestand “image.jpg” in de werkmap. Het rekent de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camerarotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

De afbeelding wordt gerenderd op de voorzijde, terwijl de extrusie wordt weergegeven als het 3D‑zijvlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstframe. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑witte raster‑patroon, past een opwaartse boog toe en configureert 3D‑instellingen via [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#getThreeDFormat--). De extrusie‑hoogte en diepte staan in punten, en de lichtrotatie in graden. De vormvulling en omtrek zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De tekst wordt gerenderd als gebogen, geëxtrudeerde 3D‑letters:

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Tekst plat houden op een 3D‑vorm**

Om tekst leesbaar te houden terwijl de 3D‑uitstraling van de vorm behouden blijft, roept u [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) aan via [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/#getTextFrameFormat--). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer de waarde `false` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert niet de 3D‑opmaak van de vorm: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [Shape::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getThreeDFormat--). Het verschilt ook van gewone rotatie. [Shape::setRotation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#setRotation-float-) roteert de vorm in het dia‑vlak, terwijl [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) de aangepaste rotatie van de tekst binnen de omhullende doos regelt. Het buiten de 3D‑scene houden van de tekst zet geen van beide hoeken terug.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstinstelling verschilt: `false` links en `true` rechts. De camerahoeken staan in graden en de extrusie‑hoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op het dubbele van de standaardafmetingen.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Links volgt de tekst de 3D‑oriëntatie. Rechts blijft de tekst plat en beter leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Zij‑aan‑zij 3D‑rechthoeken: tekst volgt de 3D‑oriëntatie links en blijft plat rechts](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan in PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de uitvoer getekend als een 2D‑resultaat. Dit geldt wanneer u dia’s rendert naar [PNG](/slides/nl/php-java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/php-java/convert-powerpoint-to-html/), of frames genereert voor [videoconversie](/slides/nl/php-java/convert-powerpoint-to-video/).

Houd rekening met de volgende punten:

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet meer door de gebruiker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, licht‑rig, materiaal, extrusie, vulling en diascale.
- Als u geërfde of themagerichte opmaak‑waarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/php-java/shape-effective-properties/).
- Sommige uitvoerformaten kunnen geen bewerkbare PowerPoint‑3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geëxporteerde afbeeldingen, PDF’s of HTML‑pagina’s niet tot interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint waar het formaat het ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een reguliere PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, afschuining, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbaar 3D‑object?**

Minimaal moet u een cameraro’tatie en ofwel extrusie of diepte instellen. In de praktijk stelt men ook een licht‑rig en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getThreeDFormat--) voor het vormlichaam en [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#getThreeDFormat--) voor tekst.

**Zullen 3D‑effecten verschijnen bij export naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑uitvoer, HTML‑uitvoer en frames die worden gebruikt voor videoconversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat erfelijkheid en thema‑instellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/php-java/shape-effective-properties/) om de definitieve camera-, licht‑rig-, afschuining‑ en gerelateerde 3D‑waarden te lezen.