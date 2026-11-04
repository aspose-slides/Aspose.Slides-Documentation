---
title: Alakzat hatások alkalmazása prezentációkban PHP-vel
linktitle: Alakzat hatás
type: docs
weight: 30
url: /hu/php-java/shape-effect/
keywords:
- alakzat hatás
- árnyék hatás
- reflexió hatás
- fénylő hatás
- lágy szélek hatás
- hatásformátum
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alakítsa át PPT és PPTX fájljait fejlett alakzathatásokkal az Aspose.Slides for PHP via Java használatával – hozzon létre lenyűgöző, professzionális diákat percek alatt."
---
## **Bevezetés**

Miközben a PowerPoint hatásait arra lehet használni, hogy egy alakzat kiemelkedjen, különböznek a [kitöltésektől](/slides/hu/php-java/shape-formatting/#gradient-fill) vagy a körvonalaktól. A PowerPoint hatások segítségével meggyőző tükrözéseket hozhat létre egy alakzaton, terjesztheti az alakzat fénylődését stb.

![Alakzat hatás](shape-effect.png)

A PowerPoint hat effektust kínál, amelyeket alakzatokra lehet alkalmazni. Egy vagy több hatást is alkalmazhat egy alakzatra.

Néhány hatáskombináció jobban néz ki, mint mások. Emiatt a PowerPoint a **Preset** alatt lehetőségeket kínál. Az Előre beállított (Preset) lehetőségek két vagy több, általában jól kinéző hatás kombinációi. Így egy előre beállított lehetőség kiválasztásával nem kell időt vesztegetnie különféle hatások tesztelésével vagy kombinálásával a megfelelő kombináció megtalálásához.

Az Aspose.Slides a [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) osztály alatt olyan tulajdonságokat és metódusokat biztosít, amelyekkel ugyanazokat a hatásokat alkalmazhatja PowerPoint‑prezentációk alakzataira.

## **Árnyékhatás alkalmazása**

Az Aspose.Slides for PHP via Java támogatja a külső és belső árnyékokat alakzatoknál. Testreszabhatja a színüket, irányukat, távolságukat és elmosási sugarukat, hogy illeszkedjenek a prezentációja dizájnjához.

### **Külső árnyék alkalmazása**

Használjon külső árnyékot, hogy egy kártya vagy panel kiemelkedjen a dia hátteréből. Az árnyék túlnyúlik az alakzat szélén, így az alakzat a dia fölé emelkedettnek tűnik. Állítsa be a színét, irányát, távolságát és elmosási sugarát, hogy megfeleljen a sablon megvilágításának és stílusának.

Ez a PHP kód bemutatja, hogyan alkalmazza a [külső árnyék hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) egy téglalapra:

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

Sablon vizuális stílusának reprodukálásakor használjon belső árnyékot, hogy egy kártya vagy panel recesszív megjelenést kapjon. A külső árnyék az alakzat külső részén terjed, és emelkedett hatást kelt, míg a belső árnyék az élek belsejét árnyalja.

Hívja meg a [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), majd konfigurálja a [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) által visszaadott árnyékot. A nagyobb elmosási sugárértékek lágyabb éleket eredményeznek.

Ez a PHP példa egy világoskék kártyát hoz létre sötét szürke belső árnyékkal, és PPTX fájlként menti. Az árnyék iránya 225 fok, távolsága 7 pont, elmosási sugara 6 pont:

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

A belső árnyék eltávolításához hívja meg a [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) metódust az alakzat effectformátumán.

## **Reflexió hatás alkalmazása**

A reflexió hatás alkalmazásához az Aspose.Slides for PHP via Java‑ban hozzáadhat tükörszerű tükrözést az alakzatokhoz, beállítva a távolságot, átlátszóságot és méretet. Ez a hatás fokozza az előadás esztétikáját, polírozottabbá és kifinomultabbá téve az alakzatokat. Könnyen megvalósítható egyszerű kóddal, gyorsan alkalmazható több elemre a konzisztens tervezés érdekében.

Ez a PHP kód bemutatja, hogyan alkalmazza a [reflexió hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) egy alakzatra:

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

![Reflexió hatás](reflection_effect.png)

## **Fénylő hatás alkalmazása**

A fénylő hatás alkalmazásához az Aspose.Slides for PHP via Java‑ban lágy, ragyogó aurát adhat az alakzatok köré, beállítva például a színt és a méretet. Ez a hatás segít kiemelni az alakzatokat, és vonzó, szemfelébb vonzó vizuális elemet ad a prezentációnak. Könnyen megvalósítható minimális kóddal, javítva a diák általános megjelenését.

Ez a PHP kód bemutatja, hogyan alkalmazza a [fénylő hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) egy alakzatra:

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

A lágy szélek hatás alkalmazásához az Aspose.Slides for PHP via Java‑ban sima, elmosott átmenetet hozhat létre az alakzat szélei körül. Ez a hatás finomabb és kifinomultabb megjelenést biztosít, ideális olyan tervekhez, amelyeknek gyengéd, lágyabb megjelenésre van szükségük. Könnyen állíthatja a sugár paramétert, hogy a kívánt hatást elérje a prezentáció különböző alakzatai között.

Ez a PHP kód bemutatja, hogyan alkalmazza a [lágy szélek hatást](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) egy alakzatra:

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

## **Elmosás hatás alkalmazása**

Használjon alakzat‑elmosást a kitöltés és a körvonal puhításához, miközben az alakzat szerkeszthető marad. Hívja meg a [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) metódust az alakzat effectformátumán. A sugár pontban mérhető (1/72 hüvelyk): használjon nem negatív értéket, a nagyobb értékek erősebb elmosást eredményeznek. A nulla sugár változatlan megjelenést hagy.

A [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) beállítás szabályozza a hatás látható határait. `false` esetén az elmosás az eredeti festett határokra, a körvonalra korlátozódik. `true` esetén az elmosás túlnyúlhat ezeken a határokon. Egyik beállítás sem változtatja meg az alakzat helyzetét vagy méreteit.

Az alábbi összehasonlítás ugyanazt a kitöltést, körvonalat és alakzateméretet használja minden esetben. A felső sorban `grow = false`; az alsó sorban `grow = true`.

![Eredeti téglalap összehasonlítva 5 és 15 pont elmosási sugarakkal, a növekedés letiltott és engedélyezett állapotával](shape_blur_comparison.png)

Ez a PHP példa egy narancssárga téglalapot hoz létre sötétkék körvonallal, 5 pont elmosást alkalmaz, majd újra meghívja a [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) metódust 15 pont elmosásra. Mindkét elmosott állapotot menti, majd meghívja a [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) metódust, és a shape‑ot elmosás nélkül menti.

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

Az alakzat‑elmosás a kitöltést és a körvonalat együtt érinti. A lágy szélek hatás az alakzat széleit fokozza, míg az árnyék‑elmosás csak az árnyékot lágyítja. A képek átalakítási hatásai a kép tartalmára vonatkoznak; ez a példa közvetlenül az alakzat effectformátumára alkalmaz elmosást, anélkül, hogy az alakzatot képpé konvertálná.

## **GYIK**

**Alkalmazhatok több hatást ugyanarra az alakzatra?**

Igen, több különböző hatást, például árnyékot, reflexiót és fénylő hatást kombinálhat egyetlen alakzaton, hogy dinamikusabb megjelenést érjen el.

**Milyen alakzatokra alkalmazhatok hatásokat?**

Különféle alakzatokra alkalmazhat hatásokat, beleértve az autoshape‑eket, diagramokat, táblázatokat, képeket, SmartArt objektumokat, OLE objektumokat és egyebeket.

**Alkalmazhatok hatásokat csoportosított alakzatokra?**

Igen, hatásokat alkalmazhat csoportosított alakzatokra is. A hatás az egész csoportra lesz alkalmazva.