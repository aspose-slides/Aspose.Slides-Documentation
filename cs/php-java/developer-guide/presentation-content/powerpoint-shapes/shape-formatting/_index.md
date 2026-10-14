---
title: Formátování tvarů PowerPointu v PHP
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/php-java/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- skicový efekt
- skicová čára tvaru
- formátování stylu spojení
- gradientová výplň
- výplň vzorem
- obrázková výplň
- texturovaná výplň
- jednobarevná výplň
- průhlednost tvaru
- černobílé vykreslení tvaru
- vykreslení tvaru ve stupních šedi
- otočení tvaru
- 3D efekt zkosení
- 3D otáčecí efekt
- resetování formátování
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, jak formátovat tvary PowerPointu v PHP pomocí Aspose.Slides — nastavte styly výplně, čáry a efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysy. Navíc můžete tvary formátovat nastavením, které řídí, jak jsou vyplněny jejich vnitřní části.

![formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro PHP přes Java poskytuje třídy a metody, které vám umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátovat čáry**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Nastavte [styl čáry](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [styl přerušení](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód PHP ukazuje, jak formátovat obdélníkový `AutoShape`:

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Nastavte barvu výplně pro obdélníkový tvar.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Aplikujte formátování na čáry obdélníku.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Nastavte barvu čáry obdélníku.
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

## **Aplikovat skicové efekty na čáry tvaru**

Skicový efekt způsobí, že čára tvaru vypadá jako ručně kreslená. K přístupu k nastavení čáry použijte [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), k přístupu k nastavení skicu použijte [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), a pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) použijte [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/).

Následující kód PHP ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) , přečíst explicitně přiřazenou hodnotu a odebrat efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Přístup k formátu čáry tvaru a jeho skicovému formátu.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Aplikovat skicový efekt.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Přečíst skicový efekt přiřazený přímo tvaru.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Odstranit skicový efekt.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Hodnota vrácená metodou [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení snímku, použijte [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), získejte objekt a jeho metodu `getSketchFormat`, a přečtěte jeho hodnotu `getSketchType`. Efektivní hodnota odráží formátování, které je skutečně aplikováno po vyřešení dědičnosti:

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

## **Formátovat styly spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Ve výchozím nastavení PowerPoint při spojení dvou čar pod úhlem (například v rohu tvaru) používá nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující kód PHP ukazuje, jak byly tři obdélníky (jak je vidět na výše uvedeném obrázku) vytvořeny pomocí nastavení typu spojení Miter, Bevel a Round:

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte tři automatické tvary typu Obdélník.
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

    // Nastavte barvu čáry pro každý obdélník.
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

## **Gradientová výplň**

V PowerPointu je Gradient Fill formátovací možnost, která vám umožňuje aplikovat plynulé prolínání barev na tvar. Například můžete použít dvě nebo více barev tak, že jedna postupně přechází v druhou.

Zde je návod, jak pomocí Aspose.Slides aplikovat gradientovou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte dvě požadované barvy s definovanými pozicemi pomocí metod `add` kolekce gradientových zastávek, kterou poskytuje třída [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Aplikujte gradientové formátování na elipsu.
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

![Elipsa s gradientovou výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, podívejte se na [Choose a Gradient Rendering Style](/slides/cs/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl renderování bez změny gradientové výplně uložené v prezentaci.

## **Výplň vzorem**

V PowerPointu je Pattern Fill formátovací možnost, která vám umožňuje aplikovat dvoubarevný návrh – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete vybrat vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzoru, které můžete aplikovat na tvary a zvýšit tak vizuální atraktivitu vašich prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které má použít.

Zde je návod, jak pomocí Aspose.Slides aplikovat výplň vzorem na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
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

![Obdélník s výplní vzorem](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je Picture Fill formátovací možnost, která vám umožňuje vložit obrázek dovnitř tvaru – efektivně použít obrázek jako pozadí tvaru.

Zde je návod, jak pomocí Aspose.Slides aplikovat obrázkovou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) z obrázku, který chcete použít.
1. Předejte obrázek metodě `SlidesPicture.setImage`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor „lotus.png“ s následujícím obrázkem:

![Obrázek lotosu](lotus.png)

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Nastavte typ výplně na Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Nastavte režim obrázkové výplně.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Načtěte obrázek a přidejte jej do prostředků prezentace.
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

![Tvar s obrázkovou výplní](picture-fill.png)

### **Obrázek dlaždic jako textura**

Pokud chcete nastavit obrázek dlaždic jako texturu a přizpůsobit chování dláždění, můžete použít následující metody třídy [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Nastaví režim obrázkové výplně – buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Ovládá, zda je dlaždice přetočena horizontálně, vertikálně nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Nastaví vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Nastaví svislý posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definuje vodorovné měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definuje svislé měřítko dlaždice v procentech.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Načtěte obrázek a přidejte jej do prostředků prezentace.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Přiřaďte obrázek k tvaru.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Nakonfigurujte režim obrázkové výplně a vlastnosti dláždění.
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

![Možnosti dlaždic](tile-options.png)

## **Jednobarevná výplň**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplňuje tvar jednou, jednotnou barvou. Tento jednoduchý podkladový odstín se aplikuje bez jakýchkoli gradientů, textur či vzorů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte tvaru preferovanou barvu výplně.
1. Uložte upravenou prezentaci jako soubor PPTX.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
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

![Tvar s jednobarevnou výplní](solid-color-fill.png)

## **Nastavit průhlednost**

V PowerPointu, když použijete jednobarevnou, gradientovou, obrázkovou nebo texturovou výplň na tvary, můžete také nastavit úroveň průhlednosti, která určuje neprůhlednost výplně. Vyšší hodnota průhlednosti činí tvar více průhledným a umožňuje částečně vidět pozadí nebo podkladové objekty.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte pevný obdélníkový automatický tvar.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Přidejte transparentní obdélníkový automatický tvar nad pevný tvar.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Uložte soubor PPTX na disk.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Průhledný tvar](shape-transparency.png)

## **Otočit tvary**

Aspose.Slides vám umožňuje otáčet tvary v PowerPoint prezentacích. To může být užitečné při umisťování vizuálních prvků se specifickým zarovnáním nebo designovými požadavky.

Postup pro otočení tvaru na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
1. Uložte prezentaci.

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Otočte tvar o 5 stupňů.
    $shape->setRotation(5);

    // Uložte soubor PPTX na disk.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Otáčení tvaru](shape-rotation.png)

## **Přidat 3D zkosení**

Aspose.Slides umožňuje aplikovat 3D zkosení na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Postup pro přidání 3D zkosení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
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

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidat 3D otáčecí efekty**

Aspose.Slides umožňuje aplikovat 3D otáčecí efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Postup pro aplikaci 3D otáčení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
1. Pomocí [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) a [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) definujte 3D otáčení.
1. Uložte prezentaci.

```php
// Vytvořte instanci třídy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Uložte prezentaci jako soubor PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![3D otáčecí efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslování pro tvary**

Metoda [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazena nebo zpracována v černobílém režimu. Neaktualizuje samotný černobílý režim ani nemění výplň, čáru nebo jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu z třídy [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) pro výběr požadovaného chování. Například `Automatic` umožní aplikaci renderování zvolit konverzi, `Gray` a `LightGray` použijí šedé zabarvení, `BlackWhite` použije jen černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová normální barvu a `Hidden` skryje tvar v černobílém režimu. `NotDefined` znamená, že nebyl přiřazen žádný režim na úrovni tvaru.

Následující PHP kód vytvoří barevný tvar a v černobílém zobrazení jej zobrazí šedě:

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

V normálním barevném režimu si obdélník zachovává oranžovou výplň. V černobílém pracovním postupu se používá šedé zbarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat snímek v plné barvě a přitom definovat odlišný vzhled pro tisk, náhled nebo jiné procesy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovit formátování**

Následující Java kód ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů s placeholdery na [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) do jejich výchozích nastavení:

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

## **Často kladené otázky**

**Ovlivňuje formátování tvaru konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu místa v souboru, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a prakticky nezvětšují velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je to vyžadováno.