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
- efekt měkkých okrajů
- formát efektu
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů v Aspose.Slides pro PHP via Java—vytvořte úchvatné, profesionální snímky během několika sekund."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [výplní](/slides/cs/php-java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit záři tvaru atd.

![Efekt tvaru](shape-effect.png)

PowerPoint poskytuje šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint nabízí možnosti pod **Předvolba**. Možnosti Předvolby jsou kombinace dvou nebo více efektů, o nichž se ví, že vypadají dobře. Tímto způsobem, výběrem předvolby, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli hezkou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/), které vám umožní použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použití stínového efektu**

Aspose.Slides for PHP via Java podporuje vnější a vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použít vnější stín**

Použijte vnější stín, aby karta nebo panel vynikly proti pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že je tvar nad snímkem. Přizpůsobte jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento PHP kód ukazuje, jak použít [vnější stínový efekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) na obdélník:

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

![Stínový efekt](shadow_effect.png)

### **Použít vnitřní stín**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, aby karta nebo panel měly zapouzdřený vzhled. Vnější stín přesahuje mimo tvar a způsobuje, že vypadá vyvýšený, zatímco vnitřní stín zatmaví vnitřní část jeho okrajů.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), poté nakonfigurujte stín vrácený metodou [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Větší hodnoty poloměru rozostření vytvářejí měkčí hrany.

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

Pro odstranění vnitřního stínu zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formátu efektu tvaru.

## **Použití odrazového efektu**

Pro použití odrazového efektu v Aspose.Slides for PHP via Java můžete přidat zrcadlový odraz k tvarům a upravit parametry, jako je vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že poskytuje tvarům uhlazenější a sofistikovanější vzhled. Je snadné jej implementovat pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro konzistentní design.

Tento PHP kód ukazuje, jak použít [odrazový efekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) na tvar:

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

![Odrazový efekt](reflection_effect.png)

## **Použití zářivého efektu**

Pro použití zářivého efektu na tvar v Aspose.Slides for PHP via Java můžete přidat měkkou, jasně vyzařující aurou kolem tvarů a upravit vlastnosti, jako je barva a velikost. Tento efekt pomáhá zvýraznit tvary a přidává atraktivní, upoutávající vizuální prvek do vaší prezentace. Je snadné jej implementovat s minimálním kódem, čímž zlepšuje celkový vzhled vašich snímků.

Tento PHP kód ukazuje, jak použít [zářivý efekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) na tvar:

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

![Zářivý efekt](glow_effect.png)

## **Použití měkkých okrajů**

Pro použití efektu měkkých okrajů v Aspose.Slides for PHP via Java můžete vytvořit hladký, rozmazaný přechod kolem okrajů tvaru. Tento efekt přidává jemnější a vylepšený vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Můžete snadno upravit parametry, jako je poloměr, abyste dosáhli požadovaného efektu u různých tvarů ve vaší prezentaci.

Tento PHP kód ukazuje, jak použít [efekt měkkých okrajů](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) na tvar:

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

![Efekt měkkých okrajů](soft_edges_effect.png)

## **FAQ**

**Mohu použít více efektů na stejný tvar?**

Ano, můžete kombinovat různé efekty, jako stín, odraz a záři, na jeden tvar, abyste vytvořili dynamickější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Můžete aplikovat efekty na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt bude aplikován na celou skupinu.