---
title: Alkalmazzon alakzati hatásokat prezentációkban PHP használatával
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/php-java/shape-effect/
keywords:
- alakzati hatás
- árnyék hatás
- tükrözés hatás
- fénylő hatás
- lágy szélek hatás
- hatásformátum
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzati hatásokkal az Aspose.Slides for PHP via Java segítségével — hozzon létre lenyűgöző, professzionális diákat másodpercek alatt."
---
## **Bevezetés**

Bár a PowerPoint hatásait arra lehet használni, hogy egy alakzat kitűnjön, eltérnek a [kitöltésektől](/slides/hu/php-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatásokkal meggyőző tükröződéseket hozhatunk létre egy alakzaton, eloszthatjuk az alakzat fénylő hatását stb.

![Shape effect](shape-effect.png)

A PowerPoint hat hatást biztosít, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Egyes hatáskombinációk jobban néznek ki, mint mások. Emiatt a PowerPoint a **Preset** alatt ad lehetőségeket. Az előre beállított lehetőségek két vagy több hatás kombinációi, amelyek jó megjelenést biztosítanak. Így egy előre beállítást kiválasztva nem kell időt pazarolni a hatások tesztelésével vagy kombinálásával, hogy jó kombinációt találjon.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) osztályban olyan tulajdonságokat és metódusokat biztosít, amelyek lehetővé teszik, hogy ugyanazokat a hatásokat alkalmazza a PowerPoint előadásokban lévő alakzatokra.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for PHP via Java külső és belső árnyékokat támogat alakzatokhoz. Testreszabhatja azok színét, irányát, távolságát és homály sugarát, hogy illeszkedjenek az előadás tervezéséhez.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kitűnjön a dia háttérrel szemben. Az árnyék a alakzat szélein túlra nyúlik, így úgy tűnik, mintha az alakzat felemelkedett volna a dián. Állítsa be a színét, irányát, távolságát és homály sugarát, hogy megfeleljen a sablon megvilágításának és stílusának.

Ez a PHP kód bemutatja, hogyan kell alkalmazni a [külső árnyék hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

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

![Árnyékhatás](shadow_effect.png)

#### **Az árnyék irányának vezérlése alakzat forgatásakor**

Alapértelmezés szerint a külső árnyék együtt forog az alakzattal. Ahhoz, hogy a különböző forgatásokkal rendelkező alakzatok ugyanabból az irányból legyenek megvilágítva, hívja a [setRotateShadowWithShape](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setRotateShadowWithShape) függvényt `false` értékkel, és használja a [setDirection](https://reference.aspose.com/slides/php-java/aspose.slides/outershadow/#setDirection) függvényt, hogy az árnyékok ugyanazt az irányt kapják.

A példa két kék nyilat hoz létre, szürke árnyékokkal, amelyek 42 ponttal jobbra eltolódnak (0°). Ezután megkettőzi a diát, és mindkét nyilat 90°-kal óramutató járása szerint elforgatja.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $before = $presentation->getSlides()->get_Item(0);
    
    $left = $before->getShapes()->addAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
    $left->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $left->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $left->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $left->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $left->getEffectFormat()->getOuterShadowEffect();
    $shadow->getShadowColor()->setColor(java("java.awt.Color")->GRAY);
    $shadow->setDirection(0);
    $shadow->setDistance(42);
    $shadow->setBlurRadius(0);
    $shadow->setRotateShadowWithShape(true);

    $right = $before->getShapes()->addClone($left);
    $right->setX(395);
    $right->getEffectFormat()->getOuterShadowEffect()->setRotateShadowWithShape(false);

    $after = $presentation->getSlides()->addClone($before);
    foreach ($after->getShapes()->toArray() as $arrow) {
        $arrow->setRotation(90);
    }

    $presentation->save("arrow_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A második dián a bal nyíl lefelé vet árnyékot, míg a jobb nyíl továbbra is jobbra vet árnyékot. A beállított irány mindkét árnyéknál 0° marad.

![PowerPoint megjelenítés 90°-os forgatás előtt és után. Mindkét árnyék a jobb oldalon kezdődik. Forgatás után az árnyék a bal nyíl alá kerül, és a jobb nyíl jobb oldalán marad.](arrow-shadow-rotation.png)

### **Belső árnyék alkalmazása**

Köztes sablon vizuális stílusának újraalkotásakor használjon belső árnyékot, hogy a kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat külső részén nyúlik és felemelt hatást kelt, míg a belső árnyék az élek belsejét árnyékolja.

Hívja a [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) függvényt, majd állítsa be a [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb homály sugár értékek lágyabb éleket eredményeznek.

Ez a PHP példa egy világoskék kártyát hoz létre sötétszürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, a homály sugara 6 pont:

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

A belső árnyék eltávolításához hívja a [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) függvényt az alakzat effektformátumán.

### **Előre beállított árnyék alkalmazása, módosítása és eltávolítása**

Hívja a [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) függvényt egy előre beállított árnyék engedélyezéséhez. Használja a [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) függvényt egy [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) kiválasztásához vagy egy másik stílusra váltáshoz ugyanazon alakzaton. Hívja a [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) függvényt az árnyék eltávolításához, miközben a kitöltést és a körvonalat megőrzi.

Ez a PHP példa a téglalapot az első három szakasz után klónozza, hogy összehasonlíthassa a négy szakaszt egymás mellé egy dián. Mindkét árnyék 10 ponttal el van tolva. 225° irányban az első árnyék a téglalap fölött és balra kerül, 45° irányban a második alul és jobbra.

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

| Eredeti | Első előre beállítás | Második előre beállítás | Eltávolítás után |
| :---: | :---: | :---: | :---: |
| ![Nincs árnyék](preset_shadow_original.png) | ![Bal felső árnyék](preset_shadow_top_left.png) | ![Jobb alsó árnyék](preset_shadow_bottom_right.png) | ![Árnyék eltávolítás után](preset_shadow_removed.png) |

## **Tükrözés hatás alkalmazása**

Az Aspose.Slides for PHP via Java segítségével tükrözés hatást alkalmazhat, amely tükörszerű visszaverődést ad az alakzatoknak, beállítva a távolságot, átlátszóságot és méretet. Ez a hatás javítja az előadások esztétikáját, elegánsabb megjelenést kölcsönöz az alakzatoknak. Egyszerű kóddal könnyen megvalósítható, gyors alkalmazást tesz lehetővé több elemre a konzisztens tervezés érdekében.

Ez a PHP kód bemutatja, hogyan kell alkalmazni a [reflection effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) hatást egy alakzatra:

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

![Tükrözés hatás](reflection_effect.png)

## **Fénylő hatás alkalmazása**

Az Aspose.Slides for PHP via Java segítségével fénylő hatást adhat egy alakzathoz, amely lágy, fényes aurát hoz létre körülötte, testreszabva például a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, vonzó, szemfelé figyelemfelkeltő vizuális elemet adva az előadáshoz. Egyszerű kóddal könnyen megvalósítható, javítva a diák megjelenését.

Ez a PHP kód mutatja, hogyan kell alkalmazni a [glow effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) hatást egy alakzatra:

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

![Fénylő hatás](glow_effect.png)

## **Lágy szélek hatás alkalmazása**

Az Aspose.Slides for PHP via Java segítségével lágy szélek hatást hozhat létre, amely egy sima, elmosódott átmenetet ad az alakzat szélei körül. Ez a hatás finomabb és kifinomultabb megjelenést kölcsönöz, tökéletes a designok számára, amelyek enyhe, lágyabb megjelenést igényelnek. Könnyen állíthatja a paramétereket, például a sugarat, a kívánt hatás eléréséhez különböző alakzatokon az előadásban.

Ez a PHP kód bemutatja, hogyan kell alkalmazni a [soft edges effect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) hatást egy alakzatra:

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

![Lágy szélek hatás](soft_edges_effect.png)

## **Homály hatás alkalmazása**

Használja a forma homályt, hogy lágyítsa a forma kitöltését és körvonalát, miközben a forma szerkeszthető marad. Hívja a [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) függvényt a forma effektformatumán. A sugár pontban van mérve (1/72 hüvelyk): használjon nem negatív értéket, a nagyobb értékek erősebb homályt eredményeznek. A nulla sugár változatlanul hagyja a megjelenést.

A [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) beállítás szabályozza a hatás látható határait. `false` esetén a homály a eredeti festett határokra van vágva, beleértve a körvonalat. `true` esetén a homály túlnyúlhat ezen határokon. Egyik beállítás sem változtatja a forma helyzetét vagy méreteit.

Az alábbi összehasonlítás mindenhol ugyanazt a kitöltést, körvonalat és alakzatméretet használja. A felső sor `grow = false`; az alsó sor `grow = true`.

![Az eredeti téglalap összehasonlítva 5 és 15 pont homály sugárral, a grow letiltva és engedélyezve](shape_blur_comparison.png)

Ez a PHP példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pont homályt alkalmaz, majd a [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) újbóli meghívásával 15 pont homályra frissíti. Mindkét homályos állapotot menti, majd a [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) függvényt hívja, és a formát homály nélkül menti.

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

A forma homály egyszerre befolyásolja a kitöltést és a körvonalat. A lágy szélek hatás a forma széleit halványítja, míg az árnyék homály csak az árnyékot lágyítja. A képátalakítási hatások a kép tartalmán működnek; ez a példa közvetlenül a forma effektformátumára alkalmaz homályt, anélkül, hogy a formát képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, különböző hatásokat, például árnyékot, tükrözést és fénylést kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Hatásokat többféle alakzatra alkalmazhat, beleértve az automatikus alakzatokat, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportos alakzatokra?**

Igen, a csoportos alakzatokra is alkalmazhat hatásokat. A hatás a teljes csoportra vonatkozik.