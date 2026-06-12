---
title: Formátování tvarů PowerPoint v Javě
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/java/shape-formatting/
keywords:
- formátovat tvar
- formátovat čáru
- formátovat styl spoje
- gradientová výplň
- vzorová výplň
- obrázková výplň
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- otáčení tvaru
- 3D efekt zkosení
- 3D efekt rotace
- resetování formátování
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak v Javě pomocí Aspose.Slides formátovat tvary PowerPointu — nastavit výplň, čáru a styly efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V programu PowerPoint můžete do snímků přidávat tvary. Protože tvary se skládají z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysy. Navíc můžete tvary formátovat nastavením, které řídí, jak jsou vyplněny jejich vnitřní části.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java poskytuje rozhraní a metody, které vám umožňují formátovat tvary pomocí stejných možností, které jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
1. Nastavte [line style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód ukazuje, jak naformátovat obdélníkový `AutoShape`:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Nastavte barvu výplně pro tvar obdélníku.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Použijte formátování na čáry obdélníku.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Nastavte barvu čáry obdélníku.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Uložte soubor PPTX na disk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The formatted lines in the presentation](formatted-lines.png)

## **Formátování stylů spojení**

Zde jsou tři možnosti typů spojení:

* Round
* Miter
* Bevel

Ve výchozím nastavení, když PowerPoint spojuje dvě čáry pod úhlem (například na rohu tvaru), používá nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte tři automatické tvary typu Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Nastavte barvu výplně pro každý obdélníkový tvar.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Nastavte šířku čáry.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Nastavte barvu čáry pro každý obdélník.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Nastavte styl spoje.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Přidejte text do každého obdélníku.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Uložte soubor PPTX na disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradientová výplň**

V PowerPointu je Gradient Fill (gradientová výplň) volbou formátování, která umožňuje aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, aby se jedna postupně promíchávala s druhou.

Pomocí Aspose.Slides můžete aplikovat gradientovou výplň na tvar následujícím způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) na `Gradient`.
1. Pomocí metod `add` ze sbírky gradientových zastávek, kterou vystavuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/igradientformat/), přidejte své dvě upřednostňované barvy s definovanými pozicemi.
1. Uložte upravenou prezentaci jako soubor PPTX.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplikujte gradientové formátování na elipsu.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Nastavte směr gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Přidejte dva gradientové zastávky.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Uložte soubor PPTX na disk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The ellipse with gradient fill](gradient-fill.png)

## **Vzorová výplň**

V PowerPointu je Pattern Fill (vzorová výplň) volbou formátování, která umožňuje aplikovat dvoubarevný design – například tečky, pruhy, šrafování nebo šachovnici – na tvar. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na tvary a zvýšit tak vizuální přitažlivost svých prezentací. I po výběru předdefinovaného vzoru můžete ještě určit konkrétní barvy, které má použít.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/java/com.aspose.slides/patternformat/#getBackColor--) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/java/com.aspose.slides/patternformat/#getForeColor--) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Nastavte styl vzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Nastavte barvy pozadí a popředí vzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Uložte soubor PPTX na disk.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The rectangle with pattern fill](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je Picture Fill (obrázková výplň) volbou formátování, která vám umožňuje vložit obrázek do tvaru – efektivně použít obrázek jako pozadí tvaru.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) z obrázku, který chcete použít.
1. Předávejte obrázek metodě `ISlidesPicture.setImage`.
1. Uložte upravenou prezentaci jako soubor PPTX.

![The lotus picture](lotus.png)

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Nastavte typ výplně na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Nastavte režim výplně obrázkem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Načtěte obrázek a přidejte ho do zdrojů prezentace.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Nastavte obrázek.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Uložte soubor PPTX na disk.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The shape with picture fill](picture-fill.png)

### **Dlaždice obrázku jako textury**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Nastavuje režim vyplnění obrázkem – buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Určuje zarovnání dlaždic v rámci tvaru.
- [setTileFlip](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Řídí, zda je dlaždice převrácena vodorovně, svisle nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Nastavuje horizontální posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Nastavuje vertikální posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definuje horizontální měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definuje vertikální měřítko dlaždice v procentech.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Načtěte obrázek a přidejte ho do zdrojů prezentace.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Přiřaďte obrázek k tvaru.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Nakonfigurujte režim výplně obrázkem a vlastnosti dláždění.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Uložte soubor PPTX na disk.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The tile options](tile-options.png)

## **Jednobarevná výplň**

V PowerPointu je Solid Color Fill (jednobarevná výplň) volbou formátování, která vyplní tvar jednou, jednotnou barvou. Tato jednoduchá barva pozadí se použije bez jakýchkoli gradientů, textur nebo vzorů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) na `Solid`.
1. Přiřaďte tvaru preferovanou barvu výplně.
1. Uložte upravenou prezentaci jako soubor PPTX.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Nastavte barvu výplně.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Uložte soubor PPTX na disk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The shape with solid color fill](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když použijete jednobarevnou, gradientovou, obrázkovou nebo texturovou výplň na tvary, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více průhledný a podklad nebo podřazené objekty budou částečně viditelné.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar Rectangle s plnou výplní.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Přidejte transparentní obdélníkový automatický tvar nad pevný tvar.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Uložte soubor PPTX na disk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The transparent shape](shape-transparency.png)

## **Rotace tvarů**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umisťování vizuálních prvků s konkrétními požadavky na zarovnání nebo design.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
1. Nastavte vlastnost rotace tvaru na požadovaný úhel.
1. Uložte prezentaci.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Otočte tvar o 5 stupňů.
    shape.setRotation(5);

    // Uložte soubor PPTX na disk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The shape rotation](shape-rotation.png)

## **Přidání 3D efektů zkosení**

Aspose.Slides umožňuje aplikovat 3D efekty zkosení na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/threedformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
1. Uložte prezentaci.

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte tvar do snímku.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Nastavte vlastnosti ThreeDFormat tvaru.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Uložte prezentaci jako soubor PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The 3D bevel effect](3D-bevel-effect.png)

## **Přidání 3D efektů rotace**

Aspose.Slides umožňuje aplikovat 3D rotaci na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/threedformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
1. Pomocí metod [setCameraType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icamera/#setCameraType-int-) a [setLightType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilightrig/#setLightType-int-) definujte 3D rotaci.
1. Uložte prezentaci.

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Uložte prezentaci jako soubor PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![The 3D rotation effect](3D-rotation-effect.png)

## **Obnovení formátování**

Následující Java kód ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů s placeholdery na [LayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/layoutslide/) na jejich výchozí nastavení:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Resetujte každý tvar na snímku, který má placeholder v rozložení.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů velikost konečného souboru prezentace?**

Pouze nepatrně. Vložené obrázky a média zabírají většinu místa v souboru, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a přidávají prakticky žádnou další velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony prezentace nebo souboru šablony .POTX. Při vytváření nové prezentace otevřete šablonu, zkopírujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je to potřeba.