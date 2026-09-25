---
title: Maak en pas WordArt-effecten toe in PHP
linktitle: WordArt
type: docs
weight: 110
url: /nl/php-java/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt-sjabloon
- WordArt-effect
- schaduweffect
- reflectie-effect
- gloed-effect
- WordArt-transformatie
- 3D-effect
- buitenste schaduweffect
- binnenste schaduweffect
- PHP
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides voor PHP via Java. Deze stapsgewijze handleiding helpt ontwikkelaars presentaties te verbeteren met professionele tekst in PHP."
---
## **Overzicht**

Met WordArt-effecten kunt u tekst opmaken met vullingen, contouren, schaduwen, reflecties, gloed, transformaties en 3D-opmaak. Dit artikel legt uit hoe u deze effecten kunt maken en aanpassen in PowerPoint‑presentaties met Aspose.Slides voor PHP via Java, zonder dat Microsoft Office geïnstalleerd is.

## **Een eenvoudige WordArt-sjabloon maken en toepassen op tekst**

De volgende voorbeelden bouwen een eenvoudige WordArt‑stijl door de tekst, het lettertype, de patroonvulling en de contour in te stellen.

Elk voorbeeld maakt een nieuwe presentatie en voegt een rechthoek toe aan de eerste dia; er is geen invoerbestand vereist. Het eerste voorbeeld stelt de tekst in op "Aspose.Slides". De positie en afmetingen van de vorm worden gemeten in punten:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

Stel het lettertype in op Arial Black met 36 punten om de opmaak beter zichtbaar te maken:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

Pas een [SmallGrid](https://reference.aspose.com/slides/nl/php-java/aspose.slides/patternstyle/#SmallGrid)-patroon toe met een donkeroranje voorgrond en een witte achtergrond, en voeg vervolgens een zwarte tekstcontour toe met een breedte van 1 punt:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

De resulterende tekst:

![De eenvoudige WordArt-sjabloon](WordArt_template.png)

## **Andere WordArt-effecten**

De volgende voorbeelden laten zien hoe u schaduwen, reflecties, gloed, transformaties en 3D-effecten op tekst kunt toepassen.

### **Buitenste schaduweffecten toepassen**

Een buitenste schaduw voegt diepte toe door een schaduw achter de tekst te plaatsen. U kunt de kleur, richting, afstand, vervagingsstraal, schaal en scheefstand aanpassen.

Dit voorbeeld roept [enableOuterShadowEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) aan en stelt een zwarte schaduw in met een vervagingsstraal van 4 punten, een richting van 230 graden en een afstand van 30 punten. Schaalwaarden van 100 behouden de schaduwgrootte, terwijl een horizontale scheefstand deze 20 graden kantelt. De alfabewerking zet de dekking op 32%:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

De resulterende tekst:

![Het buitenste schaduweffect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wanneer buitenste en vooraf ingestelde schaduwen samen worden gebruikt, wordt alleen de buitenste schaduw toegepast.
- Als buitenste en binnenste schaduwen gelijktijdig worden gebruikt, hangt het resulterende effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld, terwijl in PowerPoint 2007 alleen de buitenste schaduw wordt toegepast.
{{% /alert %}}

### **Reflectie-effecten toepassen**

Een reflectie maakt een gespiegeld exemplaar van de tekst. Pas de positie, schaal, vervaging en dekking aan om het uiterlijk te regelen.

Dit voorbeeld roept [enableReflectionEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effectformat/#enableReflectionEffect--) aan en draait de reflectie verticaal met een schaal van -100%. Het gebruikt een vervagingsstraal van 0.5 punt en een afstand van 4.72 punt. De dekking neemt af van 60% tot 0.9% tussen posities 0% en 60% langs de reflectie:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

De resulterende tekst:

![Het reflectie-effect](reflection_effect.png)

### **Gloed-effecten toepassen**

Een gloed voegt een zachte gekleurde omtrek rond de tekst toe. Pas de kleur, dekking en straal aan om het effect te regelen.

Dit voorbeeld roept [enableGlowEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/effectformat/#enableGlowEffect--) aan en past een rode gloed toe met 54% dekking en een straal van 7 punten:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

De resulterende tekst:

![Het gloed-effect](glow_effect.png)

### **WordArt-transformaties toepassen**

WordArt-transformaties buigen, strekken of vervormen een tekstblok.

Stel [setTransform](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setTransform-int-) in op [ArchUpPour](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textshapetype/#ArchUpPour) om het volledige tekstkader omhoog te buigen:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

De resulterende tekst:

![De WordArt-transformatie](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides voor PHP via Java biedt een reeks vooraf gedefinieerde [transformatietypen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **3D-effecten toepassen op vormen en tekst**

U kunt 3D-effecten toepassen op een vorm of op de tekst ervan. Afschuiningen, extrusie, verlichting en camera‑instellingen bepalen het uiteindelijke uiterlijk.

Het volgende voorbeeld gebruikt [ThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/) om cirkelvormige afschuiningen, oranje extrusie en een donkerrode omtrek aan de rechthoek toe te voegen. De afmetingen van de afschuining, extrusiehoogte, omtrekbreedte en diepte worden gemeten in punten. Een plastic materiaal, gebalanceerde verlichting die 40 graden rond de Z‑as draait, en een perspectiefcamera bepalen het uiterlijk:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

De resulterende vorm:

![Het 3D-effect van de vorm](shape_3D_effect.png)

Dit voorbeeld past vergelijkbare 3D-opmaak toe op de tekst via [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Kleinere afschuiningen vormen de rand van de letters, terwijl extrusie en verlichting de tekst diepte geven:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

De resulterende tekst:

![Het 3D-effect van de tekst](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Het toepassen van 3D-effecten op tekst of hun vormen — en de interactie tussen deze effecten — wordt geregeld door specifieke regels. Beschouw een scène waarin zowel tekst als de vorm die de tekst bevat aanwezig zijn. Een 3D-effect omvat de 3D‑representatie van het object en de scène waarin het geplaatst is.

- Als voor zowel de vorm als de tekst een scène is ingesteld, krijgt de scène van de vorm voorrang en wordt de scène van de tekst genegeerd.
- Als de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de scène van de tekst gebruikt.
- Als de vorm helemaal geen 3D‑effect heeft, wordt deze als plat beschouwd en wordt het 3D‑effect alleen op de tekst toegepast.

Deze gedragingen hebben betrekking op de methoden [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getLightRig--) en [ThreeDFormat::getCamera](https://reference.aspose.com/slides/nl/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Voor meer voorbeelden van 3D-opmaak, zie [Create 3D Effects in Presentations Using PHP](/slides/nl/php-java/3d-presentation/).

## **FAQ**

**Kan ik WordArt-effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides voor PHP via Java ondersteunt Unicode en werkt met alle gangbare lettertypen en scripts. WordArt-effecten zoals schaduw, vulling en contour kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid van lettertypen en weergave kunnen afhangen van de systeemlettertypen.

**Kan ik WordArt-effecten toepassen op elementen van de masterdia?**

Ja, u kunt WordArt-effecten toepassen op vormen op masterdia's, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen in de master‑lay-out worden doorgevoerd naar alle bijbehorende dia’s.

**Beïnvloeden WordArt-effecten de bestandsgrootte van de presentatie?**

Enigszins. WordArt-effecten zoals schaduwen, gloed en graduele vullingen kunnen de bestandsgrootte iets vergroten door toegevoegde opmaakmetadata, maar het verschil is meestal verwaarloosbaar.

**Kan ik het resultaat van WordArt-effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia's met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met behulp van [Slide::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/#getImage--), of individuele vormen renderen met [Shape::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage--). Hiermee kunt u het resultaat in het geheugen of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.