---
title: Formátování tvarů PowerPointu v JavaScriptu
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/nodejs-java/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- formátování stylu spojení
- gradientní výplň
- vzorová výplň
- obrázková výplň
- texturovaná výplň
- plná barva výplně
- průhlednost tvaru
- otočení tvaru
- 3D efekt zkosení
- 3D rotační efekt
- resetování formátování
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Formátujte tvary PowerPointu v JavaScriptu pomocí Aspose.Slides—nastavte výplň, čáru a styly efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou tvořeny čarami, můžete je formátovat úpravou nebo použitím efektů na jejich obrysech. Navíc můžete formátovat tvary nastavením, které řídí vyplnění jejich vnitřku.

![formátování tvarů v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java poskytuje třídy a metody, které vám umožní formátovat tvary pomocí stejných možností, jaké jsou dostupné v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [styl čáry](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [styl čárkování](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód ukazuje, jak formátovat obdélníkový `AutoShape`:

```js
    // Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
    let presentation = new aspose.slides.Presentation();
    try {
        // Získejte první snímek.
        let slide = presentation.getSlides().get_Item(0);
    
        // Přidejte automatický tvar typu Obdélník.
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);
    
        // Nastavte barvu výplně pro obdélníkový tvar.
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    
        // Aplikujte formátování na čáry obdélníku.
        shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
        shape.getLineFormat().setWidth(7);
        shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    
        // Nastavte barvu čáry obdélníku.
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
        // Uložte soubor PPTX na disk.
        presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

## **Formátování stylů spojení**

Jsou k dispozici tři možnosti typu spojení:

* Zaoblený
* Šikmý
* Sražený

Ve výchozím nastavení PowerPoint, když spojuje dvě čáry pod úhlem (například na rohu tvaru), používá nastavení **Zaoblený**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Šikmý**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující JavaScriptový kód ukazuje, jak byly vytvořeny tři obdélníky (viz obrázek výše) pomocí nastavení typu spojení Šikmý, Sražený a Zaoblený:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Získejte první snímek.
    let slide = presentation.getSlides().get_Item(0);

    // Přidejte tři automatické tvary typu Obdélník.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Nastavte barvu výplně pro každý obdélníkový tvar.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Nastavte šířku čáry.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Nastavte barvu čáry pro každý obdélník.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Nastavte styl spojení.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Přidejte text do každého obdélníku.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Uložte soubor PPTX na disk.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradientní výplň**

V PowerPointu je Gradientní výplň formátovací možnost, která umožňuje aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, že jedna postupně přechází v druhou.

Postup, jak použít gradientní výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte dvě preferované barvy s definovanými pozicemi pomocí metod `add` kolekce gradientových zastávek, kterou poskytuje třída [GradientFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/gradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující JavaScriptový kód demonstruje, jak aplikovat gradientní výplň na elipsu:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Získejte první snímek.
    let slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Elipsa.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplikujte gradientní formátování na elipsu.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Nastavte směr gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Přidejte dva gradientové úseky.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Uložte soubor PPTX na disk.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Elipsa s gradientní výplní](gradient-fill.png)

## **Vzorová výplň**

V PowerPointu je Vzorová výplň formátovací možnost, která vám umožní aplikovat dvoubarevný motiv – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete si zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides nabízí více než 45 předdefinovaných stylů vzorů, které můžete použít na tvary a vylepšit tak vizuální přitažlivost vašich prezentací. I po výběru předdefinovaného vzoru můžete dále specifikovat přesné barvy, které se mají použít.

Postup, jak aplikovat vzorovou výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/patternformat/#getBackColor--) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/patternformat/#getForeColor--) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující JavaScriptový kód ukazuje, jak aplikovat vzorovou výplň na obdélník:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Získejte první snímek.
    let slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Vzor.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Nastavte styl vzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Nastavte barvy pozadí a popředí vzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Uložte soubor PPTX na disk.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je Obrázková výplň formátovací možnost, která vám umožní vložit obrázek dovnitř tvaru – prakticky použít obrázek jako pozadí tvaru.

Postup, jak použít Aspose.Slides k aplikaci obrázkové výplně na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) z obrázku, který chcete použít.
1. Předávejte obrázek metodě `ISlidesPicture.setImage`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor "lotus.png" s následujícím obrázkem:

![Obrázek lotosu](lotus.png)

Následující JavaScriptový kód demonstruje, jak vyplnit tvar obrázkem:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Získejte první snímek.
    let slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Nastavte typ výplně na Obrázek.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Nastavte režim obrázkové výplně.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Nastavte obrázek.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Uložte soubor PPTX na disk.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Obrázek dlaždic jako textura**

Pokud chcete nastavit obrázek dlaždic jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Nastaví režim obrázkové výplně – `Tile` nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Řídí, zda je dlaždice převrácena horizontálně, vertikálně nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Nastavuje horizontální posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Nastavuje vertikální posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definuje horizontální škálování dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definuje vertikální škálování dlaždice v procentech.

Následující ukázkový kód ukazuje, jak přidat obdélníkový tvar s dlaždicovou obrázkovou výplní a nastavit možnosti dlaždic:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Získejte první snímek.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Obrázek.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Přiřaďte obrázek k tvaru.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Nastavte režim obrázkové výplně a vlastnosti dlaždicování.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Uložte soubor PPTX na disk.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Možnosti dlaždic](tile-options.png)

## **Plná barva výplně**

V PowerPointu je Plná barva výplně formátovací možnost, která vyplní tvar jednou, jednotnou barvou. Tato jednoduchá barva pozadí se použije bez gradientů, textur nebo vzorů.

Postup, jak aplikovat plnou barvu výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující JavaScriptový kód ukazuje, jak aplikovat plnou barvu výplně na obdélník v PowerPoint snímku:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Získejte první snímek.
    let slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Plná.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Nastavte barvu výplně.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Uložte soubor PPTX na disk.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Tvar s plnou barvou výplně](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když použijete plnou barvu, gradient, obrázek nebo texturu jako výplň tvarů, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více průsvitný, což umožní částečnou viditelnost pozadí nebo podkladových objektů.

Aspose.Slides vám umožní nastavit úroveň průhlednosti úpravou alfa komponenty ve barvě použité pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

Následující JavaScriptový kód demonstruje, jak aplikovat průhlednou barvu výplně na obdélník:

```js
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
let presentation = new aspose.slides.Presentation();
try {
    // Získejte první snímek.
    let slide = presentation.getSlides().get_Item(0);

    // Přidejte plný obdélníkový automatický tvar.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Přidejte průhledný obdélníkový automatický tvar nad plný tvar.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Uložte soubor PPTX na disk.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Aspose.Slides vám umožňuje otáčet tvary v PowerPoint prezentacích. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovými požadavky.

Pro otočení tvaru na snímku postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
1. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
1. Uložte prezentaci.

Následující JavaScriptový kód ukazuje, jak otočit tvar o 5 stupňů:

```js
    // Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
    let presentation = new aspose.slides.Presentation();
    try {
        // Získejte první snímek.
        let slide = presentation.getSlides().get_Item(0);

        // Přidejte automatický tvar typu Obdélník.
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

        // Otočte tvar o 5 stupňů.
        shape.setRotation(5);

        // Uložte soubor PPTX na disk.
        presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
```

Výsledek:

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D efektu zkosení**

Aspose.Slides vám umožňuje aplikovat 3D efekty zkosení na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/).

Pro přidání 3D efektu zkosení na tvar postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/) tvaru tak, aby definoval nastavení zkosení.
1. Uložte prezentaci.

Následující JavaScriptový kód ukazuje, jak aplikovat 3D efekt zkosení na tvar:

```js
// Vytvořte instanci třídy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Přidejte tvar na snímek.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Nastavte vlastnosti ThreeDFormat tvaru.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Uložte prezentaci jako soubor PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidání 3D rotace**

Aspose.Slides vám umožňuje aplikovat 3D rotační efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/).

Pro aplikaci 3D rotace na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) na snímek.
1. Použijte [setCameraType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/camera/#setCameraType) a [setLightType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/lightrig/#setLightType) k definování 3D rotace.
1. Uložte prezentaci.

Následující JavaScriptový kód demonstruje, jak aplikovat 3D rotační efekty na tvar:

```js
// Vytvořte instanci třídy Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Uložte prezentaci jako soubor PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![3D rotační efekt](3D-rotation-effect.png)

## **Resetování formátování**

Následující Java kód ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů s místodržiteli na [LayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/) do jejich výchozího nastavení:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Resetujte každý tvar na snímku, který má v rozvržení zástupný prvek.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a multimédia zaujímají většinu místa v souboru, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a prakticky nezvětšují velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což zjednoduší následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a použijte jejich formátování tam, kde je potřeba.