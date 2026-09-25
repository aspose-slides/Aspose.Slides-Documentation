---
title: Skapa och tillämpa WordArt‑effekter i PHP
linktitle: WordArt
type: docs
weight: 110
url: /sv/php-java/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt‑mall
- WordArt‑effekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- WordArt‑transformation
- 3D‑effekt
- yttre skuggeffekt
- inre skuggeffekt
- PHP
- Aspose.Slides
description: "Skapa och anpassa WordArt‑effekter i Aspose.Slides för PHP via Java. Denna steg‑för‑steg‑guide hjälper utvecklare att förbättra presentationer med professionell text i PHP."
---
## **Översikt**

WordArt-effekter låter dig formatera text med fyllningar, konturer, skuggor, reflektioner, glöd, transformationer och 3D‑formatering. Denna artikel förklarar hur du skapar och anpassar dessa effekter i PowerPoint-presentationer med Aspose.Slides för PHP via Java, utan att Microsoft Office är installerat.

## **Skapa en enkel WordArt‑mall och tillämpa den på text**

Följande exempel bygger en enkel WordArt‑stil genom att ange text, teckensnitt, mönsterfyllning och kontur.

Varje exempel skapar en ny presentation och lägger till en rektangel på dess första bild; ingen indatafil behövs. Det första exemplet sätter texten till "Aspose.Slides". Formens position och mått mäts i punkter:

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

Ställ in teckensnittet till Arial Black med 36 punkter för att göra formateringen mer märkbar:

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

Applicera ett [SmallGrid](https://reference.aspose.com/slides/sv/php-java/aspose.slides/patternstyle/#SmallGrid)-mönster med en mörkorange förgrund och en vit bakgrund, lägg sedan till en svart textkontur med en bredd på 1 punkt:

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

Den resulterande texten:

![The simple WordArt template](WordArt_template.png)

## **Tillämpa andra WordArt‑effekter**

Följande exempel demonstrerar hur man tillämpar skuggor, reflektioner, glöd, transformationer och 3D‑effekter på text.

### **Tillämpa yttre skuggeffekter**

En yttre skugga ger djup genom att placera en skugga bakom texten. Du kan anpassa dess färg, riktning, avstånd, oskärpa, skala och skevhet.

Detta exempel anropar [enableOuterShadowEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) och sätter en svart skugga med en oskärpa på 4 punkter, en riktning på 230 grader och ett avstånd på 30 punkter. Skala på 100 bevarar skuggans storlek, medan horisontell skevhet lutar den 20 grader. Alfa‑transformen sätter dess opacitet till 32%:

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

Den resulterande texten:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- När yttre och förinställda skuggor används tillsammans, tillämpas endast den yttre skuggan.
- Om yttre och inre skuggor används samtidigt beror den resulterande effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 fördubblas effekten, medan i PowerPoint 2007 tillämpas endast den yttre skuggan.
{{% /alert %}}

### **Tillämpa reflektionseffekter**

En reflektion skapar en spegelvänd kopia av texten. Justera dess position, skala, oskärpa och opacitet för att styra dess utseende.

Detta exempel anropar [enableReflectionEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effectformat/#enableReflectionEffect--) och vänder reflektionen vertikalt med en skala på -100%. Det använder en oskärpa på 0,5 punkt och ett avstånd på 4,72 punkt. Opaciteten minskar från 60% till 0,9% mellan positionerna 0% och 60% längs reflektionen:

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

Den resulterande texten:

![The Reflection effect](reflection_effect.png)

### **Tillämpa glödeffekter**

Ett glöd lägger till en mjuk färgad kontur runt texten. Justera dess färg, opacitet och radie för att kontrollera effekten.

Detta exempel anropar [enableGlowEffect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/effectformat/#enableGlowEffect--) och applicerar ett rött glöd med 54% opacitet och en radie på 7 punkter:

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

Den resulterande texten:

![The Glow effect](glow_effect.png)

### **Tillämpa WordArt‑transformationer**

WordArt‑transformationer böjer, sträcker eller deformerar ett textblock.

Använd [setTransform](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/#setTransform-int-) till [ArchUpPour](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textshapetype/#ArchUpPour) för att böja hela textramen uppåt:

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

Den resulterande texten:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides för PHP via Java tillhandahåller ett antal fördefinierade [transformationstyper](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Tillämpa 3D‑effekter på former och text**

Du kan tillämpa 3D‑effekter på en form eller på dess text. Fasader, extrusion, belysning och kameraparametrar styr det resulterande utseendet.

Följande exempel använder [ThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/) för att lägga till cirkulära fasader, orange extrusion och en mörkröd kontur på rektangeln. Fasaddimensioner, extrusionens höjd, konturens bredd och djup mäts i punkter. Ett plastmaterial, balanserad belysning roterad 40 grader kring Z‑axeln, och en perspektivkamera definierar dess utseende:

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

Den resulterande formen:

![The shape 3D effect](shape_3D_effect.png)

Detta exempel tillämpar liknande 3D‑formatering på texten via [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Mindre fasader formar bokstavskanten, medan extrusion och belysning ger texten djup:

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

Den resulterande texten:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Tillämpningen av 3D‑effekter på text eller deras former – och interaktionen mellan dessa effekter – styrs av specifika regler. Tänk på en scen som involverar både text och den form som innehåller den. En 3D‑effekt inkluderar objektets 3D‑representation och scenen i vilken den placeras.

- Om en scen är angiven för både formen och texten, har formens scen prioritet och textens scen ignoreras.
- Om formen saknar egen scen men har en 3D‑representation, används textens scen.
- Om formen inte har någon 3D‑effekt alls behandlas den som platt, och 3D‑effekten tillämpas endast på texten.

Beteendena relaterar till metoderna [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getLightRig--) och [ThreeDFormat::getCamera](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

För fler exempel på 3D‑formatering, se [Create 3D Effects in Presentations Using PHP](/slides/sv/php-java/3d-presentation/).

## **FAQ**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. Arabiska, kinesiska)?**

Ja, Aspose.Slides för PHP via Java stödjer Unicode och fungerar med alla större teckensnitt och skript. WordArt‑effekter såsom skugga, fyllning och kontur kan tillämpas oavsett språk, även om teckensnittens tillgänglighet och återgivning kan bero på systemets teckensnitt.

**Kan jag tillämpa WordArt‑effekter på master‑bilder?**

Ja, du kan tillämpa WordArt‑effekter på former i master‑bilder, inklusive titelplatshållare, sidfötter eller bakgrundstext. Ändringar i master‑layouten kommer att återspeglas i alla associerade bilder.

**Påverkar WordArt‑effekter filstorleken på presentationen?**

Lite grann. WordArt‑effekter såsom skuggor, glöd och gradientfyllningar kan öka filstorleken något på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bildformat (t.ex. PNG, JPEG) med [Slide::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/#getImage--), eller rendera enskilda former med [Shape::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage--). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.