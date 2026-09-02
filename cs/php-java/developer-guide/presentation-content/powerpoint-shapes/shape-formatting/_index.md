---
title: Formátování tvarů PowerPointu v PHP
linktitle: Formátování tvaru
type: docs
weight: 20
url: /cs/php-java/shape-formatting/
keywords:
- formátovat tvar
- formátovat čáru
- skicový efekt
- skicová čára tvaru
- formátovat styl spojení
- gradientová výplň
- vzorová výplň
- výplň obrázkem
- texturová výplň
- výplň jednou barvou
- průhlednost tvaru
- otáčet tvar
- 3D zkosený efekt
- 3D rotační efekt
- resetovat formátování
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak v PHP pomocí Aspose.Slides formátovat tvary v PowerPointu — nastavte výplň, čáru a styly efektů pro soubory PPT, PPTX a ODP s přesností a úplnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysech. Navíc můžete formátovat tvary nastavením, která řídí, jak jsou jejich vnitřky vyplněny.

![formátování tvaru ve PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro PHP přes Java poskytuje třídy a metody, které umožňují formátovat tvary pomocí stejných možností, které jsou dostupné v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [styl čáry](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [styl čáry s čárkováním](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linedashstyle/).
1. Nastavte barvu čáry tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód PHP ukazuje, jak na obdélníkovém `AutoShape` nastavit formátování čáry:

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
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

## **Použití skicových efektů na čáry tvarů**

Skicový efekt způsobí, že čára tvaru vypadá ručně kresleně. Použijte [Shape.getLineFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) k přístupu k nastavení čáry, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/lineformat/) k přístupu k nastavení skicu a [SketchFormat.setSketchType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sketchformat/) k výběru hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linesketchtype/).

Následující kód PHP ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odebrat efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linesketchtype/):

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

    // Odebrat skicový efekt.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Hodnota vrácená metodou [SketchFormat.getSketchType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sketchformat/) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení, použijte [LineFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/lineformat/), získejte metodu `getSketchFormat` vráceného objektu a přečtěte jeho hodnotu `getSketchType`. Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti:

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

Ve výchozím nastavení PowerPoint používá při spojení dvou čar pod úhlem (například v rohu tvaru) nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete preferovat možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující kód PHP ukazuje, jak byly vytvořeny tři obdélníky (jak je vidět na obrázku výše) s nastavením spojení Miter, Bevel a Round:

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

    // Nastavte barvu čáry každého obdélníku.
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

    // Přidejte text ke každému obdélníku.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Uložte soubor PPTX na disk.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gradient Fill**

V PowerPointu je Gradient Fill formátovací možnost, která umožňuje aplikovat plynulé prolínání barev na tvar. Například můžete použít dvě nebo více barev tak, aby jedna postupně přecházela v druhou.

Postup aplikace gradientního výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte dvě preferované barvy s definovanými pozicemi pomocí metod `add` kolekce gradientových zastávek, kterou poskytuje třída [GradientFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/gradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód PHP ukazuje, jak aplikovat efekt gradientní výplně na elipsu:

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

Výsledek:

![Elipsa s gradientní výplní](gradient-fill.png)

## **Pattern Fill**

V PowerPointu je Pattern Fill formátovací možnost, která vám umožní aplikovat dvoubarevný vzor – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete si zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na tvary a tím zvýšit vizuální atraktivitu prezentací. I po výběru předdefinovaného vzoru můžete nadále určit přesné barvy, které se mají použít.

Postup aplikace vzorové výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/php-java/aspose.slides/patternformat/#getBackColor) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/php-java/aspose.slides/patternformat/#getForeColor) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód PHP ukazuje, jak aplikovat vzorovou výplň na obdélník:

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

## **Picture Fill**

V PowerPointu je Picture Fill formátovací možnost, která umožňuje vložit obrázek do tvaru – prakticky použít obrázek jako pozadí tvaru.

Postup použití Aspose.Slides k aplikaci výplně obrázkem na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim výplně obrázkem na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) z obrázku, který chcete použít.
1. Předávejte obrázek metodě `SlidesPicture.setImage`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor "lotus.png" s následujícím obrázkem:

![Obrázek lotosu](lotus.png)

Následující kód PHP ukazuje, jak vyplnit tvar obrázkem:

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

    // Nastavte režim výplně obrázkem.
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

![Tvar s výplní obrázkem](picture-fill.png)

### **Tile Picture As Texture**

Pokud chcete nastavit obrázek jako dlaždicovou texturu a přizpůsobit chování dlaždic, můžete použít následující metody třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Nastaví režim výplně obrázkem – buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileAlignment): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileFlip): Ovládá, zda je dlaždice převrácena vodorovně, svisle nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Nastaví horizontální posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Nastaví vertikální posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definuje horizontální měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definuje vertikální měřítko dlaždice v procentech.

Následující ukázkový kód ukazuje, jak přidat obdélníkový tvar s dlaždicovou výplní obrázkem a nakonfigurovat možnosti dlaždic:

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

    // Nastavte režim výplně obrázkem a vlastnosti dlaždicování.
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

## **Solid Color Fill**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní tvar jednou, jednotnou barvou. Tento jednoduchý podkladový odstín se použije bez gradientů, textur či vzorů.

Postup aplikace jednotné barevné výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód PHP ukazuje, jak aplikovat jednotnou barvu výplně na obdélník v PowerPoint snímku:

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

![Tvar s jednotnou barvou výplně](solid-color-fill.png)

## **Set Transparency**

V PowerPointu můžete při použití jednotné barvy, gradientu, obrázku nebo textury nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více prosvětlený a podklad nebo podložní objekty budou částečně viditelné.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

Následující kód PHP ukazuje, jak aplikovat průhlednou barvu výplně na obdélník:

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte plný obdélníkový automatický tvar.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Přidejte průhledný obdélníkový automatický tvar přes plný tvar.
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

## **Rotate Shapes**

Aspose.Slides umožňuje otáčet tvary v PowerPoint prezentacích. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovými požadavky.

Postup otáčení tvaru na snímku:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
1. Uložte prezentaci.

Následující kód PHP ukazuje, jak otočit tvar o 5 stupňů:

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

## **Add 3D Bevel Effects**

Aspose.Slides umožňuje aplikovat 3D zkosené efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/).

Postup přidání 3D zkosených efektů na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/) tvaru a definujte nastavení zkosení.
1. Uložte prezentaci.

Následující kód PHP ukazuje, jak aplikovat 3D zkosené efekty na tvar:

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

![3D zkosený efekt](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides umožňuje aplikovat 3D rotační efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/).

Postup aplikace 3D rotace na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) na snímek.
1. Použijte [setCameraType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/camera/#setCameraType) a [setLightType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/lightrig/#setLightType) k definování 3D rotace.
1. Uložte prezentaci.

Následující kód PHP ukazuje, jak aplikovat 3D rotační efekty na tvar:

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

Výsledek:

![3D rotační efekt](3D-rotation-effect.png)

## **Reset Formatting**

Následující kód Java ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů s placeholdery na [LayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/) do jejich výchozích nastavení:

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

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu prostoru souboru, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a prakticky nepřidávají žádnou další velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což později usnadní správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony snímků nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, zkopírujte potřebné stylované tvary a aplikujte jejich formátování tam, kde je potřeba.