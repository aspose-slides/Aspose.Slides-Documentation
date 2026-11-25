---
title: Alakzat hatások alkalmazása bemutatókban PHP használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/php-java/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- tükröződés hatás
- ragyogás hatás
- lágy szél hatás
- hatás formátum
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzat hatásokkal az Aspose.Slides for PHP via Java segítségével — hozzon létre lenyűgöző, professzionális diákat percek alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait használhatja egy alakzat kiemelésére, ezek különböznek a [kitöltésektől](/slides/hu/php-java/shape-formatting/#gradient-fill) vagy a körvonaltól. PowerPoint hatásait felhasználva meggyőző tükröződéseket hozhat létre egy alakzaton, szétterítheti az alakzat ragyogását stb.

![Alakzat hatása](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobb, mint mások. Emiatt a PowerPoint a **Előbeállítás** alatt kínál lehetőségeket. Az előbeállítási lehetőségek két vagy több hatás kombinációi, amelyekről ismert, hogy jól néznek ki. Így, ha egy előbeállítást választ, nem kell időt pazarolnia a különböző hatások tesztelésére vagy kombinálására egy szép kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) osztályban biztosít tulajdonságokat és metódusokat, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint bemutatók alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for PHP via Java támogatja a külső és belső árnyékokat az alakzatoknál. Testreszabhatja azok színét, irányát, távolságát és elmosódási sugarát, hogy illeszkedjen a bemutató tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia háttérrel szemben. Az árnyék a forma szélein túlra nyúlik, így a forma a dia fölé emelkedettnek tűnik. Állítsa be a színét, irányát, távolságát és elmosódási sugarát, hogy megfeleljen a sablon megvilágításának és stílusának.

Ez a PHP kód mutatja, hogyan kell alkalmazni a [külső árnyékhatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Árnyék hatás](shadow_effect.png)

### **Belső árnyék alkalmazása**

Amikor egy sablon vizuális stílusát reprodukálja, használjon belső árnyékot, hogy egy kártya vagy panel recesszív megjelenést kapjon. A külső árnyék a forma kívülére nyúlik, és azt a benyomást kelti, hogy a forma emelkedett, míg a belső árnyék a szélek belsejét árnyékolja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) metódust, majd állítsa be a [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosódási sugarak lágyabb szélűek.

Ez a PHP példa egy világoskék kártyát hoz létre egy sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, elmosódási sugara 6 pont:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Világoskék téglalap belső árnyékkal](inner_shadow_effect.png)

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat hatásformátumán.

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja meg a [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) metódust egy előre beállított árnyék engedélyezéséhez. Használja a [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) metódust egy [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) kiválasztásához vagy egy másik stílusra való váltáshoz ugyanazon az alakzaton. Hívja meg a [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) metódust az árnyék eltávolításához a kitöltés és a körvonal megőrzése mellett.

Ez a PHP példa a téglalapot másolja az első három lépés után, hogy négy lépést hasonlíthasson össze egy dián. Mindkét árnyék 10 ponttal van eltolva. A 225° irány az első árnyékot a téglalap bal felső részébe helyezi, a 45° irány a másodikat jobb alsó részébe.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Eredeti | Első előbeállítás | Második előbeállítás | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső vetett árnyék](preset_shadow_top_left.png) | ![Jobb alsó vetett árnyék](preset_shadow_bottom_right.png) | ![Nincs árnyék eltávolítás után](preset_shadow_removed.png) |

## **Tükröződés hatás alkalmazása**

A PHP kód megmutatja, hogyan kell alkalmazni a [tükröződés hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Tükröződés hatás](reflection_effect.png)

## **Ragyogás hatás alkalmazása**

A PHP kód megmutatja, hogyan kell alkalmazni a [ragyogás hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Ragyogás hatás](glow_effect.png)

## **Lágy szél hatás alkalmazása**

A PHP kód megmutatja, hogyan kell alkalmazni a [lágy szél hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Lágy szél hatás](soft_edges_effect.png)

## **Elmosódás hatás alkalmazása**

Használja a forma elmosódását a kitöltés és a körvonal lágyításához, miközben a forma szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) metódust az alakzat hatásformátumán. A sugár pontban van mérve (1/72 hüvelyk): használjon nem negatív értéket, a nagyobb értékek erősebb elmosódást eredményeznek. A nulla sugár változatlan megjelenést hagy.

A [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) beállítás szabályozza a hatás látható határait. `false` esetén az elmosódás az eredeti festett határokra, beleértve a körvonalat, van korlátozva. `true` esetén az elmosódás túlnyúlhat ezeken a határokon. Egyik beállítás sem módosítja az alakzat helyzetét vagy méretét.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és alakzati méreteket használja. A felső sorban `grow = false`; az alsó sorban `grow = true`.

![Eredeti téglalap összehasonlítva 5 és 15 pont elmosódási sugarakkal, a grow letiltott és engedélyezett állapotban](shape_blur_comparison.png)

Ez a PHP példa egy narancssárga téglalapot hoz létre egy sötétkék körvonallal, 5 pontos elmosódást alkalmaz, majd a [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) újbóli meghívásával 15 pontra növeli. Mindkét elmosódott állapotot menti, majd a [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) meghívásával elmenti az árnyék nélküli alakzatot.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A forma elmosódása egyszerre érinti a kitöltést és a körvonalt. A lágy szél hatás a forma széleit halványítja, míg az árnyék elmosódása csak az árnyékot lágyítja. A képtranszformációs hatások a kép tartalmán működnek; ez a példa közvetlenül a forma hatásformátumára alkalmaz elmosódást anélkül, hogy a formát képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, tükröződést és ragyogást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, köztük automatikus alakzatokra, diagramokra, táblázatokra, képekre, SmartArt objektumokra, OLE objektumokra és egyéb elemekre.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, hatásokat alkalmazhat csoportosított alakzatokra. A hatás az egész csoportra vonatkozik.