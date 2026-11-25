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
description: "Transformujte své soubory PPT a PPTX pomocí pokročilých efektů tvarů s Aspose.Slides pro PHP via Java — vytvořte během několika sekund působivé, profesionální snímky."
---
## **Úvod**

Zatímco efekty v PowerPointu lze použít k zvýraznění tvaru, liší se od [vyplnění](/slides/cs/php-java/shape-formatting/#gradient-fill) nebo obrysů. Pomocí efektů v PowerPointu můžete vytvořit přesvědčivé odrazy na tvaru, rozšířit jeho záři atd.

![Efekt tvaru](shape-effect.png)

PowerPoint nabízí šest efektů, které lze použít na tvary. Na tvar můžete použít jeden nebo více efektů.

Některé kombinace efektů vypadají lépe než jiné. Z tohoto důvodu PowerPoint poskytuje možnosti pod **Preset**. Možnosti Preset jsou kombinace dvou nebo více efektů, o kterých se ví, že vypadají dobře. Tímto způsobem, výběrem předvolby, nebudete muset ztrácet čas testováním nebo kombinováním různých efektů, abyste našli vhodnou kombinaci.

Aspose.Slides poskytuje vlastnosti a metody ve třídě [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/), které vám umožňují použít stejné efekty na tvary v prezentacích PowerPoint.

## **Použití stínového efektu**

Aspose.Slides pro PHP via Java podporuje vnější i vnitřní stíny pro tvary. Můžete přizpůsobit jejich barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly designu vaší prezentace.

### **Použití vnějšího stínu**

Použijte vnější stín, aby karta nebo panel vynikl proti pozadí snímku. Stín přesahuje okraje tvaru a vytváří dojem, že je tvar zvednutý nad snímkem. Nastavte jeho barvu, směr, vzdálenost a poloměr rozostření tak, aby odpovídaly osvětlení a stylu vaší šablony.

Tento PHP kód ukazuje, jak použít [vnější efekt stínu](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) na obdélník:

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

### **Použití vnitřního stínu**

Při reprodukci vizuálního stylu šablony použijte vnitřní stín, který kartě nebo panelu dodá vtisknutý vzhled. Vnější stín se rozprostírá mimo tvar a způsobuje, že vypadá zvednutě, zatímco vnitřní stín zahlučuje vnitřní část jeho okrajů.

Zavolejte [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) a poté nakonfigurujte stín vrácený metodou [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Větší hodnoty poloměru rozostření produkují měkčí okraje.

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

Chcete‑li odebrat vnitřní stín, zavolejte [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) na formát efektu tvaru.

### **Použití, změna a odebrání předdefinovaného stínu**

Zavolejte [enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) pro povolení předdefinovaného stínu. Použijte [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) pro výběr [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) nebo pro přepnutí na jiný styl na stejném tvaru. Zavolejte [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect), abyste odstranili stín a zároveň zachovali výplň a obrys.

Tento PHP příklad klonuje obdélník po každé ze tří prvních fází, abyste mohli porovnat všechny čtyři fáze vedle sebe na jednom snímku. Oba stíny jsou posunuty o 10 bodů. Směr 225° umístí první stín nad a vlevo od obdélníku a 45° umístí druhý pod a vpravo.

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

| Původní | První předvolba | Druhá předvolba | Po odebrání |
| :---: | :---: | :---: | :---: |
| ![Žádný stín](preset_shadow_original.png) | ![Stín vlevo nahoře](preset_shadow_top_left.png) | ![Stín vpravo dole](preset_shadow_bottom_right.png) | ![Žádný stín po odebrání](preset_shadow_removed.png) |

## **Použití odrazového efektu**

Pro použití odrazového efektu v Aspose.Slides pro PHP via Java můžete přidat zrcadlový odraz na tvary a upravit parametry, jako je vzdálenost, průhlednost a velikost. Tento efekt zvyšuje estetiku vašich prezentací tím, že tvary získají uhlazenější a sofistikovanější vzhled. Je snadno implementovatelný pomocí jednoduchého kódu, což umožňuje rychlé použití napříč více prvky pro konzistentní design.

Tento PHP kód ukazuje, jak aplikovat [odrazový efekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) na tvar:

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

Pro použití zářivého efektu na tvar v Aspose.Slides pro PHP via Java můžete přidat měkkou, zářivou auru kolem tvarů a upravit vlastnosti jako barvu a velikost. Tento efekt pomáhá tvary zvýraznit a přidává atraktivní, poutavý vizuální prvek do vaší prezentace. Je snadno implementovatelný s minimálním kódem a zlepšuje celkový vzhled vašich snímků.

Tento PHP kód ukazuje, jak aplikovat [zářivý efekt](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) na tvar:

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

## **Použití efektu měkkých okrajů**

Pro použití efektu měkkých okrajů v Aspose.Slides pro PHP via Java můžete vytvořit plynulý, rozostřený přechod kolem okrajů tvaru. Tento efekt přidává jemnější a rafinovanější vzhled, ideální pro návrhy, které vyžadují jemný, měkčí vzhled. Parametry jako poloměr lze snadno upravit, aby se dosáhlo požadovaného efektu na různých tvarech ve vaší prezentaci.

Tento PHP kód ukazuje, jak aplikovat [efekt měkkých okrajů](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) na tvar:

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

## **Použití rozostření**

Použijte rozostření tvaru k změkčení výplně a obrysu tvaru při zachování možnosti úprav. Zavolejte [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) na formát efektu tvaru. Poloměr se měří v bodech (1/72 palce): použijte nezápornou hodnotu, přičemž větší hodnoty vytvářejí silnější rozostření. Poloměr nula ponechá vzhled beze změny.

Nastavení [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) řídí viditelné hranice efektu. S hodnotou `false` je rozostření oříznuto na původní natřené hranice, včetně obrysu. S hodnotou `true` může rozostření přesahovat tyto hranice. Žádné z těchto nastavení nemění pozici ani rozměry tvaru.

Níže uvedené srovnání používá po celou dobu stejnou výplň, obrys a rozměry tvaru. Horní řada používá `grow = false`; dolní řada používá `grow = true`.

![Původní obdélník porovnaný s poloměry rozostření 5 a 15 bodů, s vypnutým a zapnutým růstem](shape_blur_comparison.png)

Tento PHP příklad vytvoří oranžový obdélník s tmavě modrým obrysem, použije 5‑bodové rozostření a poté jej aktualizuje na 15‑bodové rozostření opětovným zavoláním [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Uloží oba rozostřené stavy, poté zavolá [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) a uloží tvar bez rozostření.

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

Rozostření tvaru ovlivňuje výplň i obrys současně. Efekt měkkých okrajů zeslabuje okraje tvaru, zatímco rozostření stínu změkčuje pouze stín. Efekty transformace obrazu pracují s obsahem obrázku; tento příklad aplikuje rozostření přímo na formát efektu tvaru, aniž by tvar převáděl na obrázek.

## **Často kladené otázky**

**Mohu na stejný tvar použít více efektů?**

Ano, můžete kombinovat různé efekty, jako jsou stín, odraz a záře, na jednom tvaru a vytvořit tak dynamičtější vzhled.

**Na jaké tvary mohu aplikovat efekty?**

Efekty můžete použít na různé tvary, včetně automatických tvarů, grafů, tabulek, obrázků, objektů SmartArt, OLE objektů a dalších.

**Mohu aplikovat efekty na seskupené tvary?**

Ano, můžete aplikovat efekty na seskupené tvary. Efekt se použije na celou skupinu.