---
title: Vytvoření a použití WordArt efektů v PHP
linktitle: WordArt
type: docs
weight: 110
url: /cs/php-java/wordart/
keywords:
- WordArt
- vytvořit WordArt
- šablona WordArt
- efekt WordArt
- efekt stínu
- efekt odrazu
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- PHP
- Aspose.Slides
description: "Vytvořte a přizpůsobte WordArt efekty v Aspose.Slides for PHP via Java. Tento podrobný průvodce pomáhá vývojářům vylepšit prezentace profesionálním textem v PHP."
---
## **Přehled**

Efekty WordArt vám umožňují stylizovat text pomocí výplní, ohraničení, stínů, odrazů, záře, transformací a 3D formátování. Tento článek vysvětluje, jak vytvářet a přizpůsobovat tyto efekty v prezentacích PowerPoint pomocí Aspose.Slides for PHP via Java, bez nainstalovaného Microsoft Office.

## **Vytvořte jednoduchou šablonu WordArt a použijte ji na text**

Následující příklady vytvoří jednoduchý styl WordArt nastavením textu, fontu, výplně vzorem a ohraničení.

Každý příklad vytvoří novou prezentaci a přidá obdélník na její první snímek; není vyžadován žádný vstupní soubor. První příklad nastaví text na „Aspose.Slides“. Pozice a rozměry tvaru jsou měřeny v bodech:

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

Nastavte font na Arial Black s velikostí 36 bodů, aby bylo formátování viditelnější:

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

Použijte vzor [SmallGrid](https://reference.aspose.com/slides/cs/php-java/aspose.slides/patternstyle/#SmallGrid) s tmavě oranžovým popředím a bílým pozadím, poté přidejte černé ohraničení textu o šířce 1 bod:

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

Výsledný text:

![Jednoduchá šablona WordArt](WordArt_template.png)

## **Použijte další efekty WordArt**

Následující příklady ukazují, jak na text použít stíny, odrazy, záři, transformace a 3D efekty.

### **Použijte vnější stínové efekty**

Vnější stín přidává hloubku umístěním stínu za text. Můžete přizpůsobit jeho barvu, směr, vzdálenost, poloměr rozostření, měřítko a zkosení.

Tento příklad volá [enableOuterShadowEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) a nastaví černý stín s poloměrem rozostření 4 body, směrem 230° a vzdáleností 30 bodů. Hodnota měřítka 100 zachovává velikost stínu, zatímco horizontální zkosení ji nakloní o 20 stupňů. Alfa transformace nastaví neprůhlednost na 32 %:

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

Výsledný text:

![Efekt vnějšího stínu](outer_shadow_effect.png)

{{% alert color="info" title="Poznámka" %}}
- Když jsou použity současně vnější a předdefinované stíny, použije se pouze vnější stín.
- Pokud jsou současně použity vnější a vnitřní stíny, výsledek závisí na verzi PowerPointu. Například ve verzi PowerPoint 2013 je efekt zdvojený, zatímco ve verzi PowerPoint 2007 se použije pouze vnější stín.
{{% /alert %}}

### **Použijte odrazové efekty**

Odraz vytvoří zrcadlovou kopii textu. Nastavte jeho pozici, měřítko, rozostření a neprůhlednost, abyste ovládali jeho vzhled.

Tento příklad volá [enableReflectionEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effectformat/#enableReflectionEffect--) a otočí odraz vertikálně se měřítkem -100 %. Používá poloměr rozostření 0,5 bodu a vzdálenost 4,72 bodu. Neprůhlednost klesá z 60 % na 0,9 % mezi pozicemi 0 % a 60 % podél odrazu:

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

Výsledný text:

![Efekt odrazu](reflection_effect.png)

### **Použijte efekty záře**

Záře přidává kolem textu měkké barevné ohraničení. Nastavte její barvu, neprůhlednost a poloměr, abyste ovlivnili efekt.

Tento příklad volá [enableGlowEffect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/effectformat/#enableGlowEffect--) a použije červenou záři s neprůhledností 54 % a poloměrem 7 bodů:

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

Výsledný text:

![Efekt záře](glow_effect.png)

### **Použijte transformace WordArt**

Transformace WordArt ohýbají, natahují nebo deformují blok textu.

Nastavte [setTransform](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setTransform-int-) na [ArchUpPour](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textshapetype/#ArchUpPour), aby se celý textový rámec zakřivil směrem nahoru:

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

Výsledný text:

![Transformace WordArt](transform_effect.png)

{{% alert color="info" title="Poznámka" %}}
Aspose.Slides for PHP via Java poskytuje sadu předdefinovaných [typů transformací](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Použijte 3D efekty na tvary a text**

Můžete použít 3D efekty na tvar nebo na jeho text. Šikmosti, extruze, osvětlení a nastavení kamery řídí výsledný vzhled.

Následující příklad používá [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/) k přidání kulatých šikmostí, oranžové extruze a tmavě červeného konturu k obdélníku. Rozměry šikmosti, výška extruze, šířka konturu a hloubka jsou měřeny v bodech. Plastový materiál, vyvážené osvětlení otočené o 40 stupňů kolem osy Z a perspektivní kamera definují jeho vzhled:

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

Výsledný tvar:

![3D efekt tvaru](shape_3D_effect.png)

Tento příklad použije podobné 3D formátování na text pomocí [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Menší šikmosti tvarují hrany písmen, zatímco extruze a osvětlení dodávají textu hloubku:

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

Výsledný text:

![3D efekt textu](text_3D_effect.png)

{{% alert color="info" title="Poznámka" %}}
Používání 3D efektů na text nebo jejich tvary — a interakce mezi těmito efekty — je řízeno specifickými pravidly. Zvažte scénu zahrnující jak text, tak tvar, který jej obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, ve které je umístěn.

- Pokud je scéna nastavena pro jak tvar, tak text, má prioritu scéna tvaru a scéna textu je ignorována.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Pokud tvar nemá žádný 3D efekt, je považován za plochý a 3D efekt se aplikuje pouze na text.

Tyto chování se vztahují k metodám [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getLightRig--) a [ThreeDFormat::getCamera](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Pro více příkladů 3D formátování viz [Vytvoření 3D efektů v prezentacích pomocí PHP](/slides/cs/php-java/3d-presentation/).

## **Často kladené otázky**

**Mohu používat WordArt efekty s různými fonty nebo skripty (např. arabština, čínština)?**

Ano, Aspose.Slides for PHP via Java podporuje Unicode a funguje se všemi hlavními fonty a skripty. Efekty WordArt, jako stín, výplň a ohraničení, lze použít bez ohledu na jazyk, i když dostupnost fontů a jejich vykreslování může záviset na systémových fontech.

**Mohu použít WordArt efekty na prvky master snímků?**

Ano, můžete použít WordArt efekty na tvary na master snímcích, včetně zástupců titulků, patiček nebo textu na pozadí. Změny provedené v rozložení masteru se projeví ve všech přidružených snímcích.

**Ovlivňují WordArt efekty velikost souboru prezentace?**

Mírně. Efekty WordArt, jako stíny, záře a gradientové výplně, mohou mírně zvětšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu si prohlédnout výsledek WordArt efektů bez uložení prezentace?**

Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí [Slide::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage--), nebo vykreslit jednotlivé tvary pomocí [Shape::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage--). To vám umožní prohlédnout výsledek v paměti nebo na obrazovce před uložením či exportem celé prezentace.