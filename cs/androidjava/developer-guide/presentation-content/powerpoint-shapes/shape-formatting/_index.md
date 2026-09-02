---
title: Formátování tvarů PowerPointu na Androidu
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/androidjava/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- skicový efekt
- skicová čára tvaru
- formátování stylu spojení
- gradientní výplň
- vzorkovaná výplň
- obrázková výplň
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- otáčení tvaru
- 3D zkosený efekt
- 3D otočný efekt
- obnovení formátování
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu na Androidu pomocí Aspose.Slides - nastavte styly výplně, čáry a efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V aplikaci PowerPoint můžete do snímků přidávat tvary. Protože jsou tvary složeny z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysech. Navíc můžete tvary formátovat nastavením, které určuje, jak bude vyplněn jejich vnitřek.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java poskytuje rozhraní a metody, které vám umožní formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátovat čáry**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Postup je následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [styl čáry](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [styl přerušení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód ukazuje, jak formátovat obdélníkový `AutoShape`:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získá první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Obdélník.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Nastavte barvu výplně obdélníkového tvaru.
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

## **Použít skicové efekty na čáry tvaru**

Skicový efekt způsobí, že čára tvaru vypadá jako ručně kreslená. Použijte [IShape.getLineFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) pro přístup k nastavením čáry, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilineformat/) pro přístup k nastavením skici a [ISketchFormat.setSketchType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isketchformat/) pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linesketchtype/).

Následující Java kód ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Přístup k formátu čáry tvaru a jeho formátu skici.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Aplikovat skicový efekt.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Načíst skicový efekt přiřazený přímo tvaru.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Odebrat skicový efekt.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Hodnota vrácená metodou [ISketchFormat.getSketchType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isketchformat/) představuje nastavení přiřazené přímo tvaru. Pokud může formátování čáry dědit téma, hlavní snímek nebo rozvržení, použijte [ILineFormat.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilineformat/), přistupte k [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilineformateffectivedata/) a přečtěte [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isketchformateffectivedata/). Efektivní hodnota odráží skutečné formátování po vyřešení dědičnosti:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formátovat styly spojení**

Zde jsou tři možnosti typu spojení:

* Kulatý
* Miter
* Šikmý

Ve výchozím nastavení PowerPoint při spojení dvou čar pod úhlem (například v rohu tvaru) používá nastavení **Kulatý**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Následující Java kód ukazuje, jak byly vytvořeny tři obdélníky (viz obrázek výše) pomocí nastavení spojení Miter, Šikmý a Kulatý:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získá první snímek.
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

    // Nastavte styl spojení.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Přidejte text k jednotlivým obdélníkům.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Uložte soubor PPTX na disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradientní výplň**

V PowerPointu je Gradientní výplň volba formátování, která umožňuje aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, aby se jedna postupně prolínala do druhé.

Postup pro aplikaci gradientní výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte dvě preferované barvy s definovanými pozicemi pomocí metod `add` ze sbírky gradientových zastávek, kterou poskytuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/igradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Java kód demonstruje, jak aplikovat gradientní výplň na elipsu:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získá první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplikujte gradientní formátování na elipsu.
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

## **Vzorkovaná výplň**

V PowerPointu je Vzorkovaná výplň volba formátování, která umožňuje aplikovat dvoubarevný motiv — například body, proužky, křížové šrafování nebo šachovnici — na tvar. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete použít k ozvláštnění vzhledu vašich prezentací. I po výběru předdefinovaného vzoru můžete nastavit přesné barvy, které má použít.

Postup pro aplikaci vzorkované výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/patternformat/#getBackColor--) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/patternformat/#getForeColor--) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Java kód ukazuje, jak aplikovat vzorkovanou výplň na obdélník:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získá první snímek.
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

V PowerPointu je Obrázková výplň volba formátování, která umožňuje vložit obrázek dovnitř tvaru — efektivně použít obrázek jako pozadí tvaru.

Postup pro použití Aspose.Slides k aplikaci obrázkové výplně na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) ze souboru obrázku, který chcete použít.
1. Předávejte obrázek metodě `ISlidesPicture.setImage`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Řekněme, že máme soubor „lotus.png“ s následujícím obrázkem:

![The lotus picture](lotus.png)

Následující Java kód ukazuje, jak vyplnit tvar obrázkem:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získá první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Nastavte typ výplně na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Nastavte režim obrázkové výplně.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
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

### **Základna obrázku jako textura**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Nastaví režim obrázkové výplně — `Tile` nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Řídí, zda je dlaždice převrácena vodorovně, svisle nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definuje vodorovné měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definuje svislé měřítko dlaždice v procentech.

Následující ukázkový kód ukazuje, jak přidat obdélníkový tvar s dlaždicovou obrázkovou výplní a nakonfigurovat možnosti dlaždic:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získá první snímek.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Přiřaďte obrázek k tvaru.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Nakonfigurujte režim obrázkové výplně a vlastnosti dlaždicování.
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

V PowerPointu je Jednobarevná výplň volba formátování, která vyplní tvar jednou jednotnou barvou. Tento jednoduchý podklad se aplikuje bez gradientů, textur nebo vzorů.

Postup pro aplikaci jednobarevné výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Java kód ukazuje, jak aplikovat jednobarevnou výplň na obdélník v PowerPoint snímku:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získá první snímek.
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

## **Nastavit průhlednost**

V PowerPointu můžete při aplikaci jednobarevné, gradientní, obrázkové nebo texturové výplně na tvary také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti činí tvar více průhledným, čímž umožňuje částečné zobrazení pozadí nebo podkladových objektů.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

Následující Java kód ukazuje, jak aplikovat transparentní barvu výplně na obdélník:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získá první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte plný obdélníkový automatický tvar.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Přidejte průhledný obdélníkový automatický tvar nad plný tvar.
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

## **Otáčet tvary**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovým požadavkem.

Postup pro otočení tvaru na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
1. Uložte prezentaci.

Následující Java kód ukazuje, jak otočit tvar o 5 stupňů:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získá první snímek.
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

## **Přidat 3D zkosené efekty**

Aspose.Slides umožňuje aplikovat 3D zkosené efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/threedformat/).

Postup pro přidání 3D zkosených efektů na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
1. Uložte prezentaci.

Následující Java kód ukazuje, jak aplikovat 3D zkosené efekty na tvar:

```java
// Vytvořte instanci třídy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte tvar na snímek.
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

## **Přidat 3D otočné efekty**

Aspose.Slides umožňuje aplikovat 3D otočné efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/threedformat/).

Postup pro aplikaci 3D otáčení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
1. Použijte [setCameraType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icamera/#setCameraType-int-) a [setLightType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) pro definování 3D otáčení.
1. Uložte prezentaci.

Následující Java kód ukazuje, jak aplikovat 3D otočné efekty na tvar:

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

## **Obnovit formátování**

Následující Java kód ukazuje, jak obnovit formátování snímku a vrátit pozici, velikost a formátování všech tvarů s místodržícími prvky na [LayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/layoutslide/) na výchozí nastavení:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Resetujte každý tvar na snímku, který má místodržící prvek v rozvržení.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Ovlivňuje formátování tvaru konečnou velikost souboru prezentace?**

Pouze minimálně. Vkládané obrázky a média zabírají většinu prostoru souboru, zatímco parametry tvarů jako barvy, efekty a gradienty jsou uloženy jako metadata a prakticky nepřidávají žádnou velikost.

**Jak mohu zjistit tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru — nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což později usnadní správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylizované tvary a znovu aplikujte jejich formátování tam, kde je to potřeba.