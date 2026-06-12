---
title: Formátování tvarů PowerPoint v PHP
linktitle: Formátování tvaru
type: docs
weight: 20
url: /cs/php-java/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- formátování stylu spojení
- gradientové vyplnění
- vyplnění vzorem
- obrázkové vyplnění
- texturové vyplnění
- jednobarevné vyplnění
- průhlednost tvaru
- otočení tvaru
- 3D efekt zkosení
- 3D rotační efekt
- obnovení formátování
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v PHP pomocí Aspose.Slides—nastavte styly výplně, čáry a efektů pro soubory PPT, PPTX a ODP s přesností a úplnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou tvořeny čarami, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysy. Navíc můžete tvary formátovat nastavením, které řídí, jak jsou jejich vnitřky vyplněny.

![formátování-tvaru-powerpoint](format-shape-powerpoint.png)

Aspose.Slides pro PHP přes Java poskytuje třídy a metody, které umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Postup je popsán níže:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Nastavte [styl čáry](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linestyle/) tvaru.
5. Nastavte šířku čáry.
6. Nastavte [styl čárkování](https://reference.aspose.com/slides/cs/php-java/aspose.slides/linedashstyle/) čáry.
7. Nastavte barvu čáry pro tvar.
8. Uložte upravenou prezentaci jako soubor PPTX.

Následující PHP kód ukazuje, jak formátovat obdélníkový `AutoShape`:

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

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Ve výchozím nastavení, když PowerPoint spojuje dvě čáry pod úhlem (například na rohu tvaru), používá nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující PHP kód ukazuje, jak byly vytvořeny tři obdélníky (viz obrázek výše) pomocí nastavení typů spojení Miter, Bevel a Round:

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

## **Gradientové vyplnění**

V PowerPointu je Gradient Fill formátovací možnost, která umožňuje aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, že jedna postupně přechází v druhou.

Postup aplikace gradientového vyplnění na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Gradient`.
5. Přidejte dvě požadované barvy s definovanými pozicemi pomocí metod `add` ze sbírky gradientových zastávek, kterou poskytuje třída [GradientFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/gradientformat/).
6. Uložte upravenou prezentaci jako soubor PPTX.

Následující PHP kód ukazuje, jak aplikovat efekt gradientového vyplnění na elipsu:

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

![Elipsa s gradientovým vyplněním](gradient-fill.png)

## **Vyplnění vzorem**

V PowerPointu je Pattern Fill formátovací možnost, která umožňuje aplikovat dvoubarevný vzor – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na tvary a zvýšit tak vizuální atraktivitu vašich prezentací. I po výběru předdefinovaného vzoru můžete specifikovat přesné barvy, které má použít.

Postup aplikace vzorového vyplnění na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Pattern`.
5. Vyberte styl vzoru z předdefinovaných možností.
6. Nastavte [Barvu pozadí](https://reference.aspose.com/slides/cs/php-java/aspose.slides/patternformat/#getBackColor) vzoru.
7. Nastavte [Barvu popředí](https://reference.aspose.com/slides/cs/php-java/aspose.slides/patternformat/#getForeColor) vzoru.
8. Uložte upravenou prezentaci jako soubor PPTX.

Následující PHP kód ukazuje, jak aplikovat vzorové vyplnění na obdélník:

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

![Obdélník s vyplněním vzorem](pattern-fill.png)

## **Obrázkové vyplnění**

V PowerPointu je Picture Fill formátovací možnost, která umožňuje vložit obrázek dovnitř tvaru – prakticky použít obrázek jako pozadí tvaru.

Jak použít Aspose.Slides k aplikaci obrázkového vyplnění na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Picture`.
5. Nastavte režim obrázkového vyplnění na `Tile` (nebo jiný preferovaný režim).
6. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) z obrázku, který chcete použít.
7. Předávejte obrázek metodě `SlidesPicture.setImage`.
8. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor "lotus.png" s následujícím obrázkem:

![Obrázek lotosu](lotus.png)

Následující PHP kód ukazuje, jak vyplnit tvar obrázkem:

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

    // Nastavte režim obrázkového vyplnění.
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

![Tvar s obrázkovým vyplněním](picture-fill.png)

### **Obrázek dlaždice jako textura**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Nastaví režim obrázkového vyplnění — buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileAlignment): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileFlip): Řídí, zda je dlaždice otočena horizontálně, vertikálně nebo oběma způsoby.
- [setTileOffsetX](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Nastaví horizontální posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Nastaví vertikální posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definuje horizontální měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definuje vertikální měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovým obrázkovým vyplněním a nakonfigurovat možnosti dlaždic:

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

    // Nastavte režim obrázkového vyplnění a vlastnosti dlaždic.
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

## **Jednobarevné vyplnění**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní tvar jednou rovnoměrnou barvou. Tento jednoduchý podklad je aplikován bez gradientů, textur nebo vzorů.

Pro aplikaci jednobarevného vyplnění na tvar pomocí Aspose.Slides postupujte takto:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) tvaru na `Solid`.
5. Přiřaďte požadovanou barvu výplně tvaru.
6. Uložte upravenou prezentaci jako soubor PPTX.

Následující PHP kód ukazuje, jak aplikovat jednobarevné vyplnění na obdélník v PowerPoint snímku:

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

![Tvar s jednobarevným vyplněním](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když aplikujete jednobarevné, gradientové, obrázkové nebo texturové vyplnění na tvary, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že je tvar více průhledný, což umožní částečný náhled na pozadí nebo podkladové objekty.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) na `Solid`.
5. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
6. Uložte prezentaci.

Následující PHP kód ukazuje, jak aplikovat průhlednou barvu výplně na obdélník:

```php
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
$presentation = new Presentation();
try {
    // Získejte první snímek.
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte plný obdélníkový automatický tvar.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Přidejte průhledný obdélníkový automatický tvar nad plný tvar.
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

## **Rotace tvarů**

Aspose.Slides umožňuje otáčet tvary v PowerPoint prezentacích. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo návrhovými požadavky.

Pro otočení tvaru na snímku postupujte takto:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Nastavte vlastnost rotace tvaru na požadovaný úhel.
5. Uložte prezentaci.

Následující PHP kód ukazuje, jak otočit tvar o 5 stupňů:

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

![Rotace tvaru](shape-rotation.png)

## **Přidání 3D efektů zkosení**

Aspose.Slides umožňuje aplikovat 3D efekty zkosení na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/).

Pro přidání 3D efektů zkosení na tvar postupujte takto:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
5. Uložte prezentaci.

Následující PHP kód ukazuje, jak aplikovat 3D efekty zkosení na tvar:

```php
// Vytvořte instanci třídy Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte tvar do snímku.
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

Aspose.Slides umožňuje aplikovat 3D rotační efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/).

Pro aplikaci 3D rotace na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) do snímku.
4. Použijte [setCameraType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/camera/#setCameraType) a [setLightType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/lightrig/#setLightType) k definování 3D rotace.
5. Uložte prezentaci.

Následující PHP kód ukazuje, jak aplikovat 3D rotační efekty na tvar:

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

## **Obnovení formátování**

Následující Java kód ukazuje, jak resetovat formátování snímku a obnovit pozici, velikost a formátování všech tvarů se zástupci na [LayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/) do výchozího nastavení:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Resetujte každý tvar na snímku, který má zástupce v rozvržení.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu místa v souboru, zatímco parametry tvarů jako barvy, efekty a gradienty jsou uloženy jako metadata a přidávají prakticky žádnou extra velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu aplikujte jejich formátování podle potřeby.