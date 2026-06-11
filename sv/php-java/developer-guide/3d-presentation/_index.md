---
title: Skapa 3D-effekter i presentationer med PHP
linktitle: 3D-presentation
type: docs
weight: 232
url: /sv/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentation
- 3D-rotation
- 3D-djup
- 3D-extrudering
- 3D-gradient
- 3D-text
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Applicera och rendera 3D-effekter för PowerPoint-former och -text i PHP med Aspose.Slides. Konfigurera kamera, belysning, material, extrudering, fyllningar och 3D-text."
---
## **Översikt**

Aspose.Slides för PHP via Java kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel täcker 3D‑effekter såsom rotation, extrudering, fasetter, belysning, material, gradient‑ eller bildfyllningar samt 3D‑text.

{{% alert color="primary" %}}
Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och -text. Den handlar inte om att infoga eller redigera fristående 3D‑modellfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd klassen [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) och dess metod [Shape::getThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getThreeDFormat--) för att tillämpa 3D‑formatering på en form. Metoden returnerar [ThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/), som styr 3D‑scenen för den formen.

För text, använd klassen [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/) och dess metod [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Detta tillämpar 3D‑formatering på textramen istället för på formens kropp.

De viktigaste inställningarna är:

| Metod eller inställning | Vad den styr | När du ska använda den |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getCamera--) | Perspektiv, förinställd kameraslag, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rum eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [getLightRig](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getLightRig--) | Ljuset förinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [setMaterial](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Ytmaterial, t.ex. platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, blankare eller metallisk ut. |
| [setExtrusionHeight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Hur långt formen sträcker sig bakåt från dess framsida. | Omvandla en platt form till ett synligt tjockt 3D‑objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidofärgen med frambeläggningen. |
| [setDepth](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#setDepth-double-) | Extra 3D‑djup som används av PowerPoints 3D‑formatering. | Finjustera djupet för former eller text, särskilt i kombination med fasett‑ och materialinställningar. |
| [getBevelTop](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getBevelTop--) och [getBevelBottom](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getBevelBottom--) | Upphöjda eller rundade kanter på fram- och baksidorna. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [getContourColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getContourColor--) och [setContourWidth](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Kontur runt 3D‑objektet. | Betona objektets gräns i den renderade utdata. |

## **Skapa en 3D‑form**

En form behöver vanligtvis fyra typer av inställningar innan den ser övertygande 3D ut:

- Kamerainställningar, eftersom standardframsidan kan dölja extruderingen.
- Ljuseinställningar, eftersom belysning gör ytorna och sidorna läsbara.
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.
- Extruderings‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess framsida, tillämpar 3D‑formatering, sparar presentationen som PPTX och renderar bilden till en PNG‑fil.

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

Den renderade bildskivan visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på framsidan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från panelen 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du anger via kamera‑‑API‑et.

![PowerPoint‑panelen 3‑D‑Rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides ställer du in kameratyp och rotation via [ThreeDFormat::getCamera](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Använd kameran när du behöver ändra hur betraktaren ser objektet. Den ändrar inte 2D‑formgeometrin på bilden. Den ändrar 3D‑vypunkten som PowerPoint och Aspose.Slides använder vid rendering.

## **Lägg till extrudering och djup**

Extrudering får en form att se tjock ut genom att den sträcker sig bakom framsidan. I PowerPoint styr djupkontrollen denna synliga tjocklek och färgkontrollen anger färgen på sidoytorna.

![PowerPoint‑djupkontroller kopplade till extruderingsfärg och extruderingshöjd‑egenskaper](img_02_02.png)

Ställ in [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) för tjockleken och [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getExtrusionColor--) för sidofärgen:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Använd [ThreeDFormat::setDepth](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#setDepth-double-) när du behöver arbeta med PowerPoints djupvärde direkt eller kombinera djup med fasett, material och texteffekter. I många formasammanhang är `setExtrusionHeight` den tydligare inställningen eftersom den direkt uttrycker den synliga extruderingen.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en solid färg, gradient, mönster eller bildfyllning på framsidan och ändå använda samma kamera-, ljus-, material- och extruderingsinställningar.

Detta exempel tillämpar en gradientfyllning på formen och en mörkare extruderingsfärg på sidorna:

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

Den renderade utskriften behåller gradienten på framsidan och renderar extruderingen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrudering](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning:

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

Bilden renderas på framsidan, medan extruderingen renderas som 3D‑sidoytan:

![Renderad 3D‑rektangel med en fotofyllning på framsidan och orange extrudering](img_02_04.png)

## **Applicera 3D‑formatering på text**

Formens 3D‑formatering påverkar formkroppen. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrudering, material, belysning och kamerainställningar.

Följande exempel skapar text med en mönsterfyllning, tillämpar en WordArt‑transform och konfigurerar 3D‑inställningar på [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/):

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

Texten renderas som böjd, extruderad 3D‑bokstavsgrafik:

![Renderad 3D‑text med en bågformad WordArt‑transform, orange mönsterfyllning och mörk extrudering](img_02_05.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när du sparar till PowerPoint‑format som PPTX. Vid rendering eller export till fast‑layout‑format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/php-java/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/php-java/convert-powerpoint-to-html/), eller genererar bildrutor för [videokonvertering](/slides/sv/php-java/convert-powerpoint-to-video/).

Kom ihåg följande punkter:

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrudering, fyllning och bildskale.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs [effektiva formegenskaper](/slides/sv/php-java/shape-effective-properties/).
- Vissa utskriftsformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stöder det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrudering, fasett, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum, ställ in en kamerarotation och antingen extrudering eller djup. I praktiken bör du också ange en ljusrigg och material så att de renderade ytorna har tydliga högdagrar och skuggor.

**Kan jag applicera 3D‑effekter på både former och text?**

Ja. Använd [Shape::getThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getThreeDFormat--) för formkroppen och [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/#getThreeDFormat--) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videobildrutor?**

Ja. Aspose.Slides renderar 3D‑effekter när slide‑bilder, PDF‑utdata, HTML‑utdata och bildrutor för videokonvertering skapas. Den exporterade utdata innehåller det renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API:erna som beskrivs i [Shape Effective Properties](/slides/sv/php-java/shape-effective-properties/) för att läsa slutgiltiga kamera‑, ljusrigg‑, fasett‑ och relaterade 3D‑värden.