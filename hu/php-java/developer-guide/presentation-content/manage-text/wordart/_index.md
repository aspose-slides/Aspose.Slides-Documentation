---
title: WordArt effektusok létrehozása és alkalmazása PHP-ben
linktitle: WordArt
type: docs
weight: 110
url: /hu/php-java/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt effektus
- árnyék effektus
- tükröződés effektus
- ragyogás effektus
- WordArt átalakítás
- 3D effektus
- külső árnyék effektus
- belső árnyék effektus
- PHP
- Aspose.Slides
description: "Hozzon létre és testreszabjon WordArt effektusokat az Aspose.Slides for PHP via Java-ban. Ez a lépésről lépésre útmutató segít a fejlesztőknek professzionális szöveggel gazdagítani a prezentációkat PHP-ben."
---
## **Áttekintés**

A WordArt effektusok lehetővé teszik a szöveg stílusozását kitöltésekkel, körvonalakkal, árnyékokkal, tükröződésekkel, ragyogással, átalakításokkal és 3D formázással. Ez a cikk bemutatja, hogyan hozhatja létre és testre szabhatja ezeket az effektusokat PowerPoint‑prezentációkban az Aspose.Slides for PHP via Java segítségével, Microsoft Office telepítése nélkül.

## **Egyszerű WordArt sablon létrehozása és szövegre alkalmazása**

A következő példák egy egyszerű WordArt stílust építenek fel a szöveg, a betűtípus, a mintás kitöltés és a körvonal beállításával.

Minden példa egy új prezentációt hoz létre, és egy téglalapot ad az első diahoz; bemeneti fájlra nincs szükség. Az első példa a szöveget "Aspose.Slides"-re állítja. Az alakzat pozíciója és méretei pontban vannak megadva:

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

Állítsa a betűtípust Arial Black-re, 36 pont méretben, hogy a formázás jobban kiemelkedjen:

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

Alkalmazzon egy SmallGrid mintát sötét narancssárga előtérrel és fehér háttérrel, majd adjon hozzá egy 1 pont széles fekete szöveg körvonalat:

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

Az eredményül kapott szöveg:

![The simple WordArt template](WordArt_template.png)

## **Más WordArt effektusok alkalmazása**

A következő példák bemutatják, hogyan alkalmazhat árnyékokat, tükröződéseket, ragyogást, átalakításokat és 3D effektusokat a szövegre.

### **Külső árnyék effektusok alkalmazása**

A külső árnyék mélységet ad, ha a szöveg mögé helyezi az árnyékot. Testreszabhatja a színét, irányát, távolságát, elmosódási sugarát, méretarányát és ferdeségét.

Ez a példa meghívja az enableOuterShadowEffect metódust, és egy fekete árnyékot állít be 4 pont elmosódási sugárral, 230 fokos iránnyal és 30 pont távolsággal. A 100-as méretarány megőrzi az árnyék méretét, míg a vízszintes ferdeség 20 fokkal dönti el. Az alfa transzformáció 32 %-os átlátszatlanságot állít be:

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

Az eredményül kapott szöveg:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Ha a külső és előre beállított árnyékok együttesen vannak használva, csak a külső árnyék kerül alkalmazásra.
- Ha a külső és belső árnyékok egyszerre vannak használva, az eredményül kapott effektus a PowerPoint verziójától függ. Például a PowerPoint 2013-ban az effektus duplázódik, míg a PowerPoint 2007-ben csak a külső árnyék kerül alkalmazásra.
{{% /alert %}}

### **Tükröződés effektusok alkalmazása**

A tükröződés egy tükrözött másolatot hoz létre a szövegről. Állítsa be a pozícióját, méretarányát, elmosódását és átlátszatlanságát a megjelenés szabályozásához.

Ez a példa meghívja az enableReflectionEffect metódust, és függőlegesen tükrözi a tükröződést -100 % méretarányban. 0,5 pont elmosódási sugarat és 4,72 pont távolságot használ. Az átlátszatlanság 60 %-ról 0,9 %-ra csökken a tükröződés 0 % és 60 % közötti pozíciói között:

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

Az eredményül kapott szöveg:

![The Reflection effect](reflection_effect.png)

### **Ragyogás effektusok alkalmazása**

A ragyogás egy lágy színes körvonallal veszi körül a szöveget. Állítsa a színét, átlátszatlanságát és sugarát az effektus szabályozásához.

Ez a példa meghívja az enableGlowEffect metódust, és egy vörös ragyogást alkalmaz 54 % átlátszatlansággal és 7 pont sugarral:

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

Az eredményül kapott szöveg:

![The Glow effect](glow_effect.png)

### **WordArt átalakítások alkalmazása**

A WordArt átalakítások hajlítják, nyújtják vagy torzítják a szövegréteget.

Állítsa a setTransform‑t ArchUpPour‑ra, hogy a teljes szövegdobozt felfelé ívvel hajtja:

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

Az eredményül kapott szöveg:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for PHP via Java előre definiált átalakítási típusok egy készletét biztosítja.
{{% /alert %}}

### **3D effektusok alkalmazása alakzatokra és szövegre**

Alkalmazhat 3D effektusokat egy alakzatra vagy annak szövegére. A csonkítások, extrudálás, világítás és kamera beállítások szabályozzák a megjelenést.

A következő példa a ThreeDFormat‑ot használja kör alakú csonkítások, narancssárga extrudálás és sötétvörös kontúr hozzáadásához a téglalaphoz. A csonkítás méretei, az extrudálás magassága, a kontúr szélessége és mélysége pontban van megadva. Egy műanyag anyag, 40 fokkal Z‑tengely körül elfordított kiegyensúlyozott világítás és egy perspektíva kamera határozza meg a megjelenést:

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

Az eredményül kapott alakzat:

![The shape 3D effect](shape_3D_effect.png)

Ez a példa hasonló 3D formázást alkalmaz a szövegre a TextFrameFormat::getThreeDFormat segítségével. A kisebb csonkítások alakítják a betűk szélét, míg az extrudálás és a világítás mélységet ad a szövegnek:

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

Az eredményül kapott szöveg:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
A 3D effektusok szövegre vagy azok alakzataira való alkalmazását – valamint az ezek közötti kölcsönhatást – meghatározott szabályok szabályozzák. Tekintsen meg egy jelenetet, amely mind a szöveget, mind a tartalmazó alakzatot magában foglalja. Egy 3D effektus magában foglalja az objektum 3D ábrázolását és a benne elhelyezkedő jelenetet.

- Ha a jelenet mind az alakzatra, mind a szövegre be van állítva, az alakzat jelenete lesz elsődleges, a szöveg jelenete figyelmen kívül marad.
- Ha az alakzatnak nincs saját jelenete, de van 3D ábrázolása, akkor a szöveg jelenete kerül felhasználásra.
- Ha az alakzatnak egyáltalán nincs 3D effektusa, laposként kezelik, és a 3D effektus csak a szövegre lesz alkalmazva.

Ezek a viselkedések a ThreeDFormat::getLightRig és a ThreeDFormat::getCamera metódusokra vonatkoznak.
{{% /alert %}}

További 3D formázási példákért lásd a PHP használatával készült prezentációk 3D effektusainak létrehozását.

## **GYIK**

**Használhatok WordArt effektusokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides for PHP via Java támogatja az Unicode‑ot, és működik minden főbb betűtípussal és írásrendszerrel. A WordArt effektusok, például az árnyék, a kitöltés és a körvonal, a nyelvtől függetlenül alkalmazhatók, bár a betűtípusok elérhetősége és megjelenítése a rendszer betűtípusaitól függhet.

**Alkalmazhatok WordArt effektusokat a diamester elemeire?**

Igen, alkalmazhat WordArt effektusokat a master diák alakzataira, beleértve a címhelyőrzőket, lábléceket vagy háttérszöveget. A master elrendezésben végzett módosítások minden kapcsolódó diára kihatnak.

**A WordArt effektusok befolyásolják a prezentáció fájlméretét?**

Enyhén. A WordArt effektusok, mint például az árnyékok, ragyogások és a színátmenetes kitöltések, kismértékben megnövelhetik a fájlméretet a hozzáadott formázási metaadatok miatt, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt effektusok eredményét a prezentáció mentése nélkül?**

Igen, a WordArt‑ot tartalmazó diák képekké (pl. PNG, JPEG) renderelhetők a Slide::getImage segítségével, vagy az egyes alakzatok a Shape::getImage‑vel. Ez lehetővé teszi az eredmény előnézetét a memóriában vagy a képernyőn a teljes prezentáció mentése vagy exportálása előtt.