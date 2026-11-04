---
title: Použití efektů tvarů v prezentacích pomocí PHP
linktitle: Efekt tvaru
type: docs
weight: 30
url: /cs/php-java/shape-effect/
keywords:
- efekt tvaru
- efekt stínu
- efekt odrazu
- efekt záře
- efekt měkkých hran
- formát efektu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Přeměňte své soubory PPT a PPTX pomocí pokročilých efektů tvarů v Aspose.Slides for PHP via Java — vytvořte během několika sekund výrazné, profesionální snímky."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [výplní](/slides/cs/php-java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint poskytuje možnosti pod **Preset**. Možnosti Preset jsou kombinace dvou nebo více efektů, o nichž se ví, že vypadají dobře. Tímto způsobem, výběrem presetu, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/), které vám umožní aplikovat stejné efekty na tvary v prezentacích PowerPointu.

## **Použití efektu stínu**

Aspose.Slides for PHP via Java podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použití vnějšího stínu**

Vnější stín použijte k zvýraznění karty nebo panelu vůči pozadí snímku. Stín se rozšiřuje za okraje tvaru, čímž vytváří dojem, že je tvar nad snímkem. Upravte jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento PHP kód ukazuje, jak aplikovat [efekt vnějšího stínu](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) na obdélník:
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

![Efekt stínu](shadow_effect.png)

### **Použití vnitřního stínu**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel měly zapuštěný vzhled. Vnější stín se rozšiřuje mimo tvar a způsobuje, že vypadá vyvýšeně, zatímco vnitřní stín zahlučuje vnitřek jeho okrajů.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), poté nakonfigurujte stín vrácený metodou [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Větší hodnoty poloměru rozostření produkují měkčí hrany.

Tento PHP příklad vytvoří světle modrou kartu s tmavě šedým vnitřním stínem a uloží ji jako soubor PPTX. Směr stínu je 225 stupňů, jeho vzdálenost je 7 bodů a poloměr rozostření je 6 bodů:
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

![Světle modrý obdélník s vnitřním stínem](inner_shadow_effect.png)

Chcete-li odstranit vnitřní stín, zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formátu efektu tvaru.

## **Použití efektu odrazu**

Pro použití efektu odrazu v Aspose.Slides for PHP via Java můžete přidat zrcadlový odraz k tvarům a upravit parametry jako vzdálenost, průhlednost a velikost. Tento efekt vylepšuje estetiku vašich prezentací tím, že poskytuje tvarům uhlazenější a sofistikovanější vzhled. Je snadné jej implementovat pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro jednotný design.

Tento PHP kód ukazuje, jak aplikovat [efekt odrazu](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) na tvar:
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

![Efekt odrazu](reflection_effect.png)

## **Použití efektu záře**

Pro aplikaci efektu záře na tvar v Aspose.Slides for PHP via Java můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá zvýraznit tvary a přidává atraktivní, poutavý vizuální prvek do vaší prezentace. Je snadné jej implementovat s minimálním kódem, což zlepšuje celkový vzhled vašich snímků.

Tento PHP kód ukazuje, jak aplikovat [efekt záře](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) na tvar:
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

![Efekt záře](glow_effect.png)

## **Použití efektu měkkých hran**

Pro aplikaci efektu měkkých hran v Aspose.Slides for PHP via Java můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Parametry jako poloměr můžete snadno upravit, abyste dosáhli požadovaného efektu na různých tvarech ve vaší prezentaci.

Tento PHP kód ukazuje, jak aplikovat [efekt měkkých hran](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) na tvar:
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

![Efekt měkkých hran](soft_edges_effect.png)

## **Použití efektu rozostření**

Použijte rozostření tvaru k změkčení výplně a obrysu tvaru při zachování editovatelnosti tvaru. Zavolejte [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) na formát efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty produkují silnější rozostření. Poloměr nula ponechává vzhled beze změny.

Nastavení [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) řídí viditelné hranice efektu. S hodnotou `false` je rozostření oříznuto na původní namalované hranice, včetně obrysu. S hodnotou `true` může rozostření přesáhnout tyto hranice. Žádné z nastavení nemění pozici ani rozměry tvaru.

Srovnání níže používá po celou dobu stejnou výplň, obrys a rozměry tvaru. Horní řada používá `grow = false`; spodní řada používá `grow = true`.

![Původní obdélník porovnán s poloměry rozostření 5 a 15 bodů, s vypnutým a zapnutým růstem](shape_blur_comparison.png)

Tento PHP příklad vytvoří oranžový obdélník s tmavě modrým obrysem, použije rozostření o 5 bodů a poté ho aktualizuje na rozostření o 15 bodů opětovným zavoláním [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Uloží oba rozostřené stavy, poté zavolá [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) a uloží tvar bez rozostření.
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

Rozostření tvaru ovlivňuje výplň i obrys najednou. Efekt měkkých hran rozplývá hrany tvaru, zatímco rozostření stínu změkčuje pouze stín. Efekty transformace obrazu pracují s obsahem obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru, aniž by tvar převáděl na obrázek.

## **Často kladené otázky**

**Mohu na stejný tvar použít více efektů?**

Ano, můžete kombinovat různé efekty, jako je stín, odraz a záře, na jediném tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.