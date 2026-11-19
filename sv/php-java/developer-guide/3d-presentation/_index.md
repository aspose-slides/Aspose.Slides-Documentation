---
title: Skapa 3D‑effekter i presentationer med PHP
linktitle: 3D‑presentation
type: docs
weight: 232
url: /sv/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑presentation
- 3D‑rotation
- 3D‑djup
- 3D‑extrudering
- 3D‑gradient
- 3D‑text
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Applicera och rendera 3D‑effekter för PowerPoint‑former och text i PHP med Aspose.Slides. Konfigurera kamera, belysning, material, extrudering, fyllningar och 3D‑text."
---
## **Översikt**

Aspose.Slides för PHP via Java kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel täcker 3D‑effekter såsom rotation, extrudering, avfasningar, belysning, material, gradient‑ eller bildfyllningar och 3D‑text.

{{% alert color="info" title="Note" %}}
Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och text. Den handlar inte om att infoga eller redigera fristående 3D‑modellfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd metoden [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) för att applicera 3D‑formatering på en form. Metoden returnerar [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/), som styr 3D‑scenen för den formen.

För text, använd metoden [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Denna applicerar 3D‑formatering på textramen istället för formens kropp.

De viktigaste API‑medlemmarna är:

| API‑medlem | Vad den kontrollerar | När den ska användas |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Visningspunkt, förinställd kamertype, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rymden eller matcha en förinställd PowerPoint‑3D‑rotation. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Förinställt ljus, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) och [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Ytmaterial, t.ex. platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) och [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Hur långt formen sträcker sig bakåt från sin frontyta. | Gör en platt form till ett synligt tjockt 3D‑objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidfärgen med frontfyllningen. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) och [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | Ytterligare 3D‑djup som används av PowerPoints 3D‑formatering. | Finjustera djupet för former eller text, särskilt i kombination med avfasnings- och materialinställningar. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) och [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Upphöjda eller avrundade kanter på front- och baksidor. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) och [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) och [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Kontur runt 3D‑objektet. | Betona objektets gräns i den renderade utskriften. |

## **Skapa en 3D‑form**

- Kamerainställningar, eftersom standardframvyn kan dölja extruderingen.  
- Ljuseinställningar, eftersom belysning gör ytorna och sidorna tydliga.  
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.  
- Extruderings‑ eller djupinställningar, eftersom en platt form behöver tjocklek.  

Följande exempel skapar en rektangel, lägger till text på dess frontyta och tillämpar 3D‑formatering. Kamerarotationsvärdena är i grader och extruderingshöjden är 100 punkter. Exemplet renderar bilden till en PNG‑fil med dubbla standardmåtten och sparar presentationen som PPTX.

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

Den renderade bildens bild visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på frontytan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från panelen 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du ställer in via kamera‑API‑t.

![PowerPoint 3‑D‑rotationspanel med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides nås kameran via [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera). Detta exempel skapar en rektangel, väljer en ortografisk frontvy och sätter dess X‑, Y‑ och Z‑rotationer till 20, 30 respektive 40 grader. Det konfigurerar formen i minnet utan att spara någon fil:

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

Använd kameran när du behöver ändra hur betraktaren ser objektet. Den ändrar inte 2D‑geometrin för formen på bilden. Den ändrar 3D‑vypunkten som PowerPoint och Aspose.Slides använder vid rendering.

### **Kopiera kamerariktning från en mallform**

För att matcha orienteringen av en mallform, läs dess förinställda kamera med [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) och dess rotationsvinklar med [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). Exemplet öppnar `template.pptx` och kopierar kamerariktningen från den första formen på den första bilden till den andra formen. Båda formerna har redan 3D‑belysning, och den andra formen har ingen explicit kamerarotation.

Vinklarna är i grader. Index `0` är latitud, index `1` är longitud och index `2` är revolution. Skicka dem till [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) i den ordningen. Om källan returnerar `null` har den ingen explicit rotation, så lämna den andra formens vinklar odefinierade. En explicit rotation på `(0, 0, 0)` returnerar tre nollor och bör kopieras.

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

När du öppnar `camera-copy.pptx` igen i PowerPoint har pilen till höger samma kamerapreset och rotation som rektangeln till vänster. Båda formerna använder samma belysning och extruderingsdjup.

![En blå 3D‑rektangel och en högerpil med matchande kamerariktning, sedd uppifrån och från höger](camera-orientation.png)

## **Lägg till extrudering och djup**

Extrudering får en form att se tjock ut genom att förlängas bakom frontytan. I PowerPoint ställer djupreglaget in denna synliga tjocklek, och färgreglaget bestämmer färgen på sidoytorna.

![PowerPoint‑djupreglage kopplade till extruderingsfärg‑ och extruderingshöjdsegenskaper](img_02_02.png)

Använd [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) för att ställa in tjockleken och [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) för att åtkomma sidfärgen. Detta exempel ger en rektangel en 100‑punktsextrudering med lila sidor och roterar kameran för att visa dess tjocklek. Det konfigurerar formen i minnet utan att spara någon fil:

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

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth)‑metoden sätter djupet för en 3D‑form. [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight)‑metoden styr höjden på extruderings‑effekten, som visas i detta exempel.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en enhetlig färg, gradient, mönster eller bildfyllning på frontytan och ändå använda samma kamera-, ljus-, material- och extruderingsinställningar.

Detta exempel applicerar en blå‑till‑orange gradient på frontytan och en mörkorange färg på den 150‑punktsextruderade delen. Gradientens stopp vid 0 och 100 markerar början och slutet på gradienten. Kamerarotationsvärdena är i grader. Bilden renderas till en PNG‑fil med dubbla standardmåtten:

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

Den renderade utskriften behåller gradienten på frontytan och renderar extruderingen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrudering](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning. Detta exempel kräver en befintlig fil med namnet "image.jpg" i arbetskatalogen. Det sträcker bilden för att fylla rektangeln, applicerar en 150‑punktsextrudering och sätter kamerarotation i grader. Det konfigurerar formen i minnet utan att spara eller rendera någon fil:

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

Bilden renderas på frontytan, medan extruderingen renderas som 3D‑sidoytan:

![Renderad 3D‑rektangel med ett fotofyllning på frontytan och orange extrudering](img_02_04.png)

## **Applicera 3D‑formatering på text**

Formens 3D‑formatering påverkar formens kropp. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrudering, material, belysning och kamerainställningar.

Det följande exemplet skapar text med ett orange‑och‑vitt rutnätsmönster, applicerar en uppåtriktad båge och konfigurerar 3D‑inställningarna via [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat)... Extruderingshöjden och djupet är i punkter, och ljusrotationen är i grader. Formens fyllning och kontur är dolda så att endast texten är synlig. Exemplet renderar en PNG‑fil med dubbla standardmåtten för bilden och sparar presentationen som PPTX:

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

Texten renderas som krökt, extruderad 3D‑bokstäver:

![Renderad 3D‑text med en bågformad WordArt‑transformering, orange mönsterfyllning och mörk extrudering](img_02_05.png)

## **Behåll text platt på en 3D‑form**

För att hålla texten läsbar samtidigt som enformes 3D‑utseende bevaras, anropa [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) via [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat). När värdet är `true` förblir texten utanför 3D‑scenen. När det är `false` deltar texten i scenen och följer dess 3D‑orientering.

Denna inställning tar inte bort formens 3D‑formatering: dess kamera, belysning, material och extrudering förblir konfigurerade via [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat). Det är också annorlunda än vanlig rotation. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) roterar formen i bildplanen, medan [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) styr textens anpassade rotation inom dess begränsningsruta. Att hålla texten utanför 3D‑scenen återställer inte någon av dessa vinklar.

Det följande fristående exemplet skapar en blå rektangel med text och klonar den bredvid originalet. Båda formerna har samma 3D‑formatering; endast textinställningen skiljer sig: `false` till vänster och `true` till höger. Kameravinklarna är i grader och extruderingshöjden är 40 punkter. Exemplet sparar presentationen som PPTX och renderar jämförelsesliden till PNG med dubbla standardmåtten.

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

Till vänster följer texten 3D‑orienteringen. Till höger förblir den platt och lättare att läsa. Båda rektanglarna behåller samma synliga extrudering och 3D‑orientering.

![Sida‑vid‑sida 3D‑rektanglar: text följer 3D‑orienteringen till vänster och förblir platt till höger](keep_text_flat.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering vid sparande till PowerPoint‑format som PPTX. Vid rendering eller export till fasta layoutformat rasteriseras 3D‑scenen eller ritas in i utskriften som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/php-java/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/php-java/convert-powerpoint-to-html/), eller genererar ramar för [videokonvertering](/slides/sv/php-java/convert-powerpoint-to-video/).

Kom ihåg följande punkter:
- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrudering, fyllning och bildskalning.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs [effektiva formegenskaper](/slides/sv/php-java/shape-effective-properties/).
- Vissa utdataformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stödjer det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller -text, såsom rotation, extrudering, avfasning, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum måste du ställa in en kamerarotation och antingen extrudering eller djup. I praktiken bör du också sätta en ljusrigg och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag applicera 3D‑effekter på både former och text?**

Ja. Använd [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) för formens kropp och [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videoram?**

Ja. Aspose.Slides renderar 3D‑effekter när bildspel renderas till bildfiler, PDF‑utdata, HTML‑utdata och ramar som används för videokonvertering. Den exporterade utskriften innehåller det renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API‑erna som beskrivs i [Shape Effective Properties](/slides/sv/php-java/shape-effective-properties/) för att läsa den slutgiltiga kameran, ljusrigen, avfasningen och relaterade 3D‑värden.