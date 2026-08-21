---
title: Formátování tvarů PowerPointu v PHP
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/php-java/shape-formatting/
keywords:
- formátovat tvar
- formátovat čáru
- skicový efekt
- skicovat čáru tvaru
- formátovat styl spojení
- gradientní výplň
- vzorová výplň
- obrázková výplň
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- černobílé vykreslování tvaru
- stupňová šedá vykreslování tvaru
- otáčet tvar
- 3d efekt zkosení
- 3d rotační efekt
- resetovat formátování
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v PHP pomocí Aspose.Slides — nastavte výplň, čáru a styly efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysy. Navíc můžete tvary formátovat zadáním nastavení, která řídí, jak jsou jejich vnitřky vyplněny.

![formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java poskytuje třídy a metody, které vám umožní formátovat tvary pomocí stejných možností, které jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar určit vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Nastavte [line style](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující PHP kód ukazuje, jak formátovat obdélník `AutoShape`:

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Nastavte barvu výplně pro tvar obdélníku.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Aplikujte formátování na čáry obdélníku.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Nastavte barvu pro čáru obdélníku.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Uložte soubor PPTX na disk.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

## **Použití skicových efektů na čáry tvaru**

Skicový efekt způsobí, že čára tvaru vypadá ručně kresleně. K přístupu k nastavením čáry použijte [Shape.getLineFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/), k nastavení skicu použijte [LineFormat.getSketchFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/lineformat/), a k výběru hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linesketchtype/) použijte [SketchFormat.setSketchType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sketchformat/).

Následující PHP kód ukazuje, jak aplikovat efekt [LineSketchType.Curved](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linesketchtype/) , přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Přístup k formátu čáry tvaru a jeho skicovému formátu.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Aplikujte skicový efekt.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Přečtěte skicový efekt přiřazený přímo tvaru.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Odeberte skicový efekt.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Hodnota vrácená metodou [SketchFormat.getSketchType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sketchformat/) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení, použijte [LineFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/lineformat/), získejte metodu `getSketchFormat` vráceného objektu a přečtěte jeho hodnotu `getSketchType`. Efektivní hodnota odráží formátování, které je skutečně použito po rozřešení dědičnosti:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Ve výchozím nastavení PowerPoint při spojení dvou čar pod úhlem (například na rohu tvaru) používá nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující PHP kód ukazuje, jak byly vytvořeny tři obdélníky (jak je vidět na obrázku výše) pomocí nastavení typů spojení Miter, Bevel a Round:

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte tři automatické tvary typu Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Nastavte barvu výplně pro každý obdélníkový tvar.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Nastavte šířku čáry.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Nastavte barvu pro čáru každého obdélníku.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Nastavte styl spojení.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Přidejte text do každého obdélníku.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Uložte soubor PPTX na disk.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gradientní výplň**

V PowerPointu je Gradient Fill formátovací volba, která vám umožní aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, že se jedna postupně přechází do druhé.

Zde je postup, jak aplikovat gradientní výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `add` ze sbírky gradientových zastávek, kterou poskytuje třída [GradientFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/gradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Aplikujte gradientní formátování na elipsu.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Nastavte směr gradientu.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Přidejte dva gradientové zastávky.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Uložte soubor PPTX na disk.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Elipsa s gradientní výplní](gradient-fill.png)

## **Vzorová výplň**

V PowerPointu je Pattern Fill formátovací volba, která vám umožní aplikovat dvoubarevný design — například tečky, pruhy, křížové šrafování nebo šachovnici — na tvar. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides nabízí více než 45 předdefinovaných vzorových stylů, které můžete aplikovat na tvary a zlepšit tak vizuální atraktivitu prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které má použít.

Zde je postup, jak aplikovat vzorovou výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/php-java/aspose.slides/patternformat/#getBackColor) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/php-java/aspose.slides/patternformat/#getForeColor) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Nastavte styl vzoru.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Nastavte barvy pozadí a popředí vzoru.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Uložte soubor PPTX na disk.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je Picture Fill formátovací volba, která vám umožní vložit obrázek do tvaru – účinně použít obrázek jako pozadí tvaru.

Zde je postup, jak pomocí Aspose.Slides aplikovat obrázkovou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) z obrázku, který chcete použít.
1. Předáte obrázek metodě `SlidesPicture.setImage`.
1. Uložte upravenou prezentaci jako soubor PPTX.

![Obrázek lotosu](lotus.png)

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Nastavte typ výplně na Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Nastavte režim obrázkové výplně.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Nastavte obrázek.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Uložte soubor PPTX na disk.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Dlaždicovat obrázek jako texturu**

- [setPictureFillMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Nastaví režim obrázkové výplně – buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileAlignment): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileFlip): Ovládá, zda je dlaždice přetočena vodorovně, svisle nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Nastaví vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Nastaví svislý posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definuje vodorovné měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definuje svislé měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovou obrázkovou výplní a nakonfigurovat možnosti dlaždic:

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Přiřaďte obrázek k tvaru.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Nakonfigurujte režim obrázkové výplně a vlastnosti dlaždic.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Uložte soubor PPTX na disk.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Možnosti dlaždic](tile-options.png)

## **Jednobarevná výplň**

V PowerPointu je Solid Color Fill formátovací volba, která vyplní tvar jednou, jednotnou barvou. Tato jednoduchá barva pozadí se použije bez jakýchkoli přechodů, textur či vzorů.

Chcete‑li použít jednobarevnou výplň na tvar pomocí Aspose.Slides, postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte tvaru preferovanou barvu výplně.
1. Uložte upravenou prezentaci jako soubor PPTX.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Nastavte barvu výplně.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Uložte soubor PPTX na disk.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Tvar s jednobarevnou výplní](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když použijete jednobarevnou, gradientní, obrázkovou nebo texturovou výplň na tvary, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více průhledný, což umožní částečně vidět pozadí nebo podkladové objekty.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou alfa‑komponenty barvy použité pro výplň. Zde je postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` k definici barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Rectangle s plnou výplní.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Přidejte transparentní automatický tvar obdélníku nad pevný tvar.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Uložte soubor PPTX na disk.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPointu. To může být užitečné při umisťování vizuálních prvků s konkrétními požadavky na zarovnání nebo design.

Chcete‑li otáčet tvar na snímku, postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
1. Uložte prezentaci.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Otočte tvar o 5 stupňů.
    $shape->setRotation(5);

    // Uložte soubor PPTX na disk.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D efektů zkosení**

Aspose.Slides vám umožňuje aplikovat 3D efekty zkosení na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/).

Chcete‑li přidat 3D efekty zkosení na tvar, postupujte následovně:

1. Instancujte třídu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
1. Uložte prezentaci.

```php
// Vytvořte instanci třídy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte tvar na snímek.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Nastavte vlastnosti ThreeDFormat tvaru.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Uložte prezentaci jako soubor PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidání 3D rotačních efektů**

Aspose.Slides vám umožňuje aplikovat 3D rotační efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/).

Chcete‑li aplikovat 3D rotaci na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte na snímek [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/).
1. Použijte [setCameraType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/camera/#setCameraType) a [setLightType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/lightrig/#setLightType) k definování 3D rotace.
1. Uložte prezentaci.

```php
// Create an instance of the Presentation class.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Save the presentation as a PPTX file.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![3D rotační efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslování pro tvary**

Metoda [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#setBlackWhiteMode) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazena nebo zpracována v černobílém režimu. Samotná metoda neaktivuje černobílý režim a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu z třídy [BlackWhiteMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/blackwhitemode/) pro výběr požadovaného chování. Například `Automatic` nechá aplikaci rozhodnout o konverzi, `Gray` a `LightGray` používají šedé zbarvení, `BlackWhite` používá pouze černou a bílou, `Black` a `White` vynutí jednu barvu, `Color` zachová normální zbarvení a `Hidden` vynechá tvar v černobílém režimu. `NotDefined` znamená, že není přiřazen žádný režim na úrovni tvaru.

Následující PHP kód vytvoří barevný tvar a způsobí, že se v černobílém zobrazení zobrazí šedě:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Uchovejte oranžovou výplň v barevném režimu, ale vykreslete tvar se šedým zbarvením v černobílém režimu.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

V normálním barevném režimu si obdélník zachovává oranžovou výplň. V černobílém zobrazení používá šedé zbarvení, protože je nastaven režim na `Gray`. To vám umožní zachovat plnobarevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled či jiné procesy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Následující Java kód ukazuje, jak obnovit formátování snímku a vrátit pozici, velikost a formátování všech tvarů s prostorovými značkami na [LayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/) na jejich výchozí nastavení:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Resetujte každý tvar na snímku, který má placeholder v rozložení.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Ovlivňuje formátování tvarů velikost finálního souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu prostoru souboru, zatímco parametry tvarů, jako jsou barvy, efekty a přechody, jsou uloženy jako metadata a prakticky nepřidávají žádnou další velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky seskupte tyto tvary, což usnadní pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablonového balíku snímků nebo souboru .POTX. Při tvorbě nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je to vyžadováno.