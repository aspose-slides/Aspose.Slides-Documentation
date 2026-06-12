---
title: 3D-effecten creëren in presentaties met PHP
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
- 3D-kleurverloop
- 3D-tekst
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in PHP met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for PHP via Java kan PowerPoint-achtige 3D-opmaak voor vormen en tekst maken, bewerken, behouden en renderen. Dit artikel behandelt 3D-effecten zoals rotatie, extrusie, afschuining, verlichting, materiaal, kleurverloop‑ of afbeeldingsvullingen en 3D‑tekst.

{{% alert color="primary" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van losse 3D‑modellen. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik de [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/)‑klasse en de methode [Shape::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getThreeDFormat--) om 3D‑opmaak op een vorm toe te passen. De methode geeft een [ThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/) terug, die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/)‑klasse en de methode [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Hiermee wordt 3D‑opmaak op het tekstframe toegepast in plaats van op het lichaam van de vorm.

De belangrijkste instellingen zijn:

| Methode of instelling | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getCamera--) | Viewpoint, vooraf ingestelde camertype, rotatie, zoom en perspectief. | Het object roteren in de 3D‑ruimte of een PowerPoint‑rotatie‑preset nabootsen. |
| [getLightRig](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getLightRig--) | Licht‑preset, richting en lichtrotatie. | Wijzigen hoe hooglichten en schaduwen op het 3D‑oppervlak verschijnen. |
| [setMaterial](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Oppervlaktmateriaal, bijv. vlak, mat, plastic of metaal. | Dezelfde geometrie er vlakker, zachter, glanzender of metallischer laten uitzien. |
| [setExtrusionHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Hoe ver de vorm naar achteren uitstrekt vanaf het voorvlak. | Een vlakke vorm omzetten in een duidelijk dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Kleur van de geëxtrudeerde zijden. | Diepte zichtbaar maken of de zijkleur afstemmen op de voorvulling. |
| [setDepth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setDepth-double-) | Extra 3D‑diepte die PowerPoint‑3D‑opmaak gebruikt. | Diepte fijn afstellen voor vormen of tekst, vooral in combinatie met afschuining en materiaal. |
| [getBevelTop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getBevelBottom--) | Verhoogde of afgeronde randen op de voor‑ en achterkant. | Een verzachte of gevormde rand toevoegen in plaats van een scherpe platte kant. |
| [getContourColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getContourColor--) en [setContourWidth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Omtrek rond het 3D‑object. | De grens van het object in de gerenderde output accentueren. |

## **Een 3D‑vorm maken**

Een vorm heeft doorgaans vier soorten instellingen nodig voordat hij overtuigend 3D lijkt:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Licht‑instellingen, omdat verlichting de vlakken en zijkanten leesbaar maakt.
- Materiaal‑instellingen, omdat het oppervlak invloed heeft op hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een vlakke vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan het voorvlak, past 3D‑opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG‑afbeelding.

```php
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

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op het voorvlak](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D‑Rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint‑paneel 3‑D‑Rotatie met gemarkeerde X, Y en Z rotatiewaarden](img_02_01.png)

In Aspose.Slides stelt u het camertype en de rotatie in via [ThreeDFormat::getCamera](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Gebruik de camera wanneer u wilt wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑geometrie van de vorm op de dia, maar wel het 3D‑viewpoint dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie maakt een vorm dik door deze achter het voorvlak uit te breiden. In PowerPoint bepaalt de diepte‑regeling deze zichtbare dikte, en de kleur‑regeling bepaalt de kleur van de zijvlakken.

![PowerPoint‑diepte‑regelingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) in voor de dikte en [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getExtrusionColor--) voor de zijkleur:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Gebruik [ThreeDFormat::setDepth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#setDepth-double-) wanneer u direct met de diepte‑waarde van PowerPoint wilt werken of diepte wilt combineren met afschuining, materiaal en teksteffecten. In veel scenario’s is `setExtrusionHeight` duidelijker omdat het de zichtbare extrusie rechtstreeks aangeeft.

## **Kleurverloop‑ of afbeeldingsvullingen met 3D‑effecten gebruiken**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, kleurverloop, patroon of afbeelding als vulling op het voorvlak toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een kleurverloop‑vulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

De gerenderde output behoudt het kleurverloop op het voorvlak en rendert de extrusie apart:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje kleurverloop‑vulling en oranje extrusie](img_02_03.png)

Om een afbeelding‑vulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

De afbeelding wordt gerenderd op het voorvlak, terwijl de extrusie wordt weergegeven als het 3D‑zijkantoppervlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op het voorvlak en oranje extrusie](img_02_04.png)

## **3D‑opmaak op tekst toepassen**

3D‑opmaak van een vorm heeft invloed op het lichaam van de vorm. 3D‑opmaak van tekst heeft invloed op het tekstframe. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroonvulling, past een WordArt‑transformatie toe en configureert 3D‑instellingen op [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/):

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer u dia’s rendert naar [PNG](/slides/nl/php-java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/php-java/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/php-java/convert-powerpoint-to-video/).

Houd rekening met de volgende punten:

- Geëxporteerde afbeeldingen en PDF‑bestanden zijn niet interactief. Het object kan na export niet worden geroteerd door de kijker.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtset, materiaal, extrusie, vulling en schaal van de dia.
- Als u geërfde of thema‑gebaseerde opmaakwaarden wilt inspecteren, lees dan de [effective shape properties](/slides/nl/php-java/shape-effective-properties/).
- Sommige uitvoerformaten kunnen geen bewerkbare PowerPoint‑3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd i.p.v. bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF‑bestanden of HTML‑pagina’s tot interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint waar het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een los 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die op een gewone PowerPoint‑vorm of -tekst wordt toegepast, zoals rotatie, extrusie, afschuining, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet u een camera‑rotatie en ofwel extrusie of diepte instellen. In de praktijk stelt u ook een lichtset en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getThreeDFormat--) voor het vormlichaam en [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#getThreeDFormat--) voor tekst.

**Verschijnen 3D‑effecten bij export naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de definitieve 3D‑waarden lezen nadat erfelijkheid en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/php-java/shape-effective-properties/) om de uiteindelijke camera‑, lichtset‑, afschuining‑ en gerelateerde 3D‑waarden te lezen.