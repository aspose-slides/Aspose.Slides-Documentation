---
title: Maak 3D‑effecten in presentaties met PHP
linktitle: 3D‑presentatie
type: docs
weight: 232
url: /nl/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑presentatie
- 3D‑rotatie
- 3D‑diepte
- 3D‑extrusie
- 3D‑verloop
- 3D‑tekst
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Pas 3D‑effecten toe en render ze voor PowerPoint‑vormen en -tekst in PHP met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D‑tekst."
---
## **Overzicht**

Aspose.Slides voor PHP via Java kan PowerPoint‑achtige 3D‑opmaak voor vormen en tekst maken, bewerken, behouden en renderen. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, verlopen‑ of picture‑vullingen en 3D‑tekst.

{{% alert color="info" title="Opmerking" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van zelfstandige 3D‑modelbestanden. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑uitvoer.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik de [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat)‑methode om 3D‑opmaak op een vorm toe te passen. De methode retourneert een [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat)‑methode. Deze past 3D‑opmaak toe op het tekstkader in plaats van op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Kijkpunt, voorgedefinieerd cameratype, rotatie, zoom en perspectief. | Het object in 3D‑ruimte roteren of een PowerPoint‑3D‑rotatie‑preset nabootsen. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Lichtpreset, richting en lichtrotatie. | Wijzigen hoe highlights en schaduwen op het 3D‑oppervlak verschijnen. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) en [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Oppervlaktmateriaal, zoals vlak, mat, plastic of metaal. | Dezelfde geometrie er vlakker, zachter, glanzender of dichterbij uit laten zien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) en [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Hoe ver de vorm naar achteren uitstrekt vanaf de voorzijde. | Een platte vorm omzetten in een duidelijk dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Kleur van de geëxtrudeerde zijden. | Diepte zichtbaar maken of de kleur van de zijkant afstemmen op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) en [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | Extra 3D‑diepte die door PowerPoint‑3D‑opmaak wordt gebruikt. | Diepte fijn afstemmen voor vormen of tekst, vooral in combinatie met bevel‑ en materiaalinstellingen. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) en [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Opstaande of afgeronde randen aan de voor‑ en achterkant. | Een verzachte of gemolde rand toevoegen in plaats van een scherpe platte flank. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) en [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) en [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Omtrek rond het 3D‑object. | De objectgrens benadrukken in de gerenderde uitvoer. |

## **Een 3D‑vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat deze overtuigend 3D‑achtig oogt:

- Camera‑instellingen, omdat het standaard front‑view de extrusie kan verbergen.  
- Licht‑instellingen, omdat verlichting de vlakken en zijden leesbaar maakt.  
- Materiaal‑instellingen, omdat het oppervlak bepaalt hoe licht wordt weergegeven.  
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De camerahoekwaarden staan in graden en de extrusie‑hoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

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

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het 3‑D‑Rotatie‑venster. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u instelt via de camera‑API.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

In Aspose.Slides bereikt u de camera via [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch front‑view en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

Gebruik de camera wanneer u wilt wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑geometrie van de vorm op de dia. Het verandert het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

### **Camera‑oriëntatie kopiëren van een sjabloon‑vorm**

Om de oriëntatie van een sjabloon‑vorm te evenaren, leest u het camerapreset met [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) en de rotatiehoeken met [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). Het voorbeeld opent `template.pptx` en kopieert de camera‑oriëntatie van de eerste vorm op de eerste dia naar de tweede vorm. Beide vormen hebben al 3D‑verlichting, en de tweede vorm heeft geen expliciete camera‑rotatie.

De hoeken staan in graden. Index `0` is latitude, index `1` is longitude en index `2` is revolution. Geef ze in die volgorde door aan [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation). Als de bron `null` retourneert, heeft deze geen expliciete rotatie, dus laat u de hoeken van de tweede vorm ongewijzigd. Een expliciete rotatie van `(0, 0, 0)` geeft drie nullen terug en moet worden gekopieerd.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wanneer u `camera-copy.pptx` opnieuw opent in PowerPoint, heeft de pijl rechts dezelfde camera‑preset en rotatie als de rechthoek links. Beide vormen gebruiken dezelfde verlichting en extrusie‑diepte.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Extrusie en diepte toevoegen**

Extrusie maakt een vorm dikker door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte en de kleur‑instelling bepaalt de kleur van de zijkanten.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Gebruik [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) om de dikte in te stellen en [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) om de zijkleur te benaderen. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijden en draait de camera om de dikte te onthullen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

De methode [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) stelt de diepte van een 3D‑vorm in. De methode [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) regelt de hoogte van het extrusie‑effect, zoals getoond in dit voorbeeld.

## **Verlopen‑ of picture‑vullingen gebruiken met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of picture‑vulling op de voorzijde toepassen en toch dezelfde camera, licht, materiaal en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorzijde en een donker‑oranje kleur op de 150‑punt‑extrusie. De verloopstops op 0 en 100 markeren respectievelijk het begin en einde van het verloop. De camerahoekwaarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

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

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Om een picture‑vulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand met de naam “image.jpg” in de werkmap. Het strekt de foto uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de cameraro rotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

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

De foto wordt gerenderd op de voorzijde, terwijl de extrusie wordt weergegeven als het 3D‑zijvlak:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstkader. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑witte rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). De extrusie‑hoogte en diepte staan in punten, en de lichtrotatie in graden. De vormvulling en omtrek zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

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

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Tekst plat houden op een 3D‑vorm**

Om tekst leesbaar te houden terwijl de 3D‑uitstraling van de vorm behouden blijft, roept u [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) aan via [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `false` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert niet de 3D‑opmaak van de vorm: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat). Het verschilt ook van gewone rotatie. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) roteert de vorm in het dia‑vlak, terwijl [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) de aangepaste rotatie van de tekst binnen zijn omhulling regelt. Tekst buiten de 3D‑scene houden reset geen van beide hoeken.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstd instelling verschilt: `false` links en `true` rechts. De camera‑hoeken staan in graden en de extrusie‑hoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op het dubbele van de standaardafmetingen.

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

Links volgt de tekst de 3D‑oriëntatie. Rechts blijft hij plat en makkelijker leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **Export‑ en renderingsgedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layout‑formaten wordt de 3D‑scene gerasterd of getekend in de uitvoer als een 2D‑resultaat. Dit geldt wanneer u dia’s rendert naar [PNG](/slides/nl/php-java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/php-java/convert-powerpoint-to-html/), of frames genereert voor [video‑conversie](/slides/nl/php-java/convert-powerpoint-to-video/).

Houd rekening met het volgende:

- Geëxporteerde afbeeldingen en PDF‑bestanden zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.  
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtinstallatie, materiaal, extrusie, vulling en dia‑schaling.  
- Als u geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vorm‑eigenschappen](/slides/nl/php-java/shape-effective-properties/).  
- Sommige uitvoerformaten kunnen geen bewerkbare PowerPoint‑3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF‑bestanden of HTML‑pagina's tot interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint waar het formaat dat ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die op een gewone PowerPoint‑vorm of tekst wordt toegepast, zoals rotatie, extrusie, bevel, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minstens een camera‑rotatie en ofwel extrusie of diepte. In de praktijk stelt men ook een lichtinstallatie en materiaal in zodat de gerenderde vlakken duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) voor het vormlichaam en [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) voor tekst.

**Zien 3D‑effecten er uit wanneer ik exporteer naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het genereren van dia‑afbeeldingen, PDF‑uitvoer, HTML‑uitvoer en frames die worden gebruikt voor videoconversie. De geëxporteerde uitvoer bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat erfelijkheid en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/php-java/shape-effective-properties/) om de uiteindelijke camera‑, licht‑, bevel‑ en gerelateerde 3D‑waarden te lezen.