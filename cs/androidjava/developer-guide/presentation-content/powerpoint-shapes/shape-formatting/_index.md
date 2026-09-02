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
- vzorná výplň
- obrázková výplň
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- černobílé vykreslování tvaru
- šedotónové vykreslování tvaru
- otočení tvaru
- 3D obrušovací efekt
- 3D rotační efekt
- resetování formátování
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu na Androidu pomocí Aspose.Slides — nastavte výplně, čáry a styly efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysy. Navíc můžete tvary formátovat nastavením, které řídí, jak jsou jejich vnitřky vyplněny.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides pro Android prostřednictvím Javy poskytuje rozhraní a metody, které vám umožňují formátovat tvary pomocí stejných možností, jaké jsou dostupné v PowerPointu.

## **Formátovat čáry**

Pomocí Aspose.Slides můžete pro tvar určit vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) na snímek.
1. Nastavte [line style](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód ukazuje, jak naformátovat obdélníkový `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Odstraňte výplň z obdélníkového tvaru, aby byly viditelné jen jeho čáry.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Aplikujte formátování na čáry obdélníku.
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

![Formátované čáry v prezentaci](formatted-lines.png)

## **Použít skicové efekty na čáry tvaru**

Skicový efekt způsobí, že čára tvaru vypadá ručně kresleně. Použijte [IShape.getLineFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) k přístupu k nastavením čáry, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilineformat/) k přístupu k nastavením skici a [ISketchFormat.setSketchType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isketchformat/) k výběru hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linesketchtype/).

Následující Java kód ukazuje, jak aplikovat efekt [LineSketchType.Curved](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linesketchtype/) , přečíst explicitně přiřazenou hodnotu a odebrat efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Získejte formát čáry tvaru a jeho skicový formát.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Aplikujte skicový efekt.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Přečtěte skicový efekt přiřazený přímo tvaru.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Odstraňte skicový efekt.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Hodnota vrácená metodou [ISketchFormat.getSketchType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isketchformat/) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení snímku, použijte [ILineFormat.getEffective](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilineformat/), přistupujte k [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilineformateffectivedata/) a přečtěte [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isketchformateffectivedata/). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti:

```java
import com.aspose.slides.*;

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
* Bevel

Ve výchozím nastavení, když PowerPoint spojuje dvě čáry pod úhlem (například na rohu tvaru), používá nastavení **Kulatý**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující Java kód ukazuje, jak byly vytvořeny tři obdélníky (jak je vidět na obrázku výše) pomocí nastavení typu spojení Miter, Bevel a Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Nastavte styl spojení.
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

## **Gradientní výplň**

V PowerPointu je Gradientní výplň formátovací možnost, která umožňuje aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, že jedna postupně přechází v druhou.

Zde je postup, jak aplikovat gradientní výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte dvě preferované barvy s definovanými pozicemi pomocí metod `add` kolekce gradientových zastávek, kterou vystavuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/igradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
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

![Elipsa s gradientní výplní](gradient-fill.png)

## **Vzorová výplň**

V PowerPointu je Vzorová výplň formátovací možnost, která umožňuje aplikovat dvoubarevný design – například tečky, pruhy, šrafování nebo šachovnici – na tvar. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných vzorových stylů, které můžete aplikovat na tvary a zvýšit tak vizuální atraktivitu svých prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které se mají použít.

Zde je postup, jak aplikovat vzorovou výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte vzorový styl z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/patternformat/#getBackColor--) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/patternformat/#getForeColor--) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je Obrázková výplň formátovací možnost, která umožňuje vložit obrázek dovnitř tvaru – efektivně používá obrázek jako pozadí tvaru.

Zde je postup, jak pomocí Aspose.Slides aplikovat obrázkovou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) z obrázku, který chcete použít.
1. Předávejte obrázek metodě `ISlidesPicture.setImage`.
1. Uložte upravenou prezentaci jako soubor PPTX.

![Obrázek lotosu](lotus.png)

Následující Java kód ukazuje, jak vyplnit tvar obrázkem:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Nastavte typ výplně na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Nastavte režim obrázkové výplně.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Nahrajte obrázek a přidejte jej do zdrojů prezentace.
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

![Tvar s obrázkovou výplní](picture-fill.png)

### **Dlaždicovat obrázek jako texturu**

Pokud chcete nastavit obrázek jako dlaždicovou texturu a přizpůsobit chování dlaždicování, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Nastavuje režim obrázkové výplně – buď `Tile` nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Ovládá, zda je dlaždice převrácena horizontálně, vertikálně nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Nastavuje horizontální posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Nastavuje vertikální posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definuje horizontální měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definuje vertikální měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovou obrázkovou výplní a nakonfigurovat možnosti dlaždic:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
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

![Možnosti dlaždic](tile-options.png)

## **Jednobarevná výplň**

V PowerPointu je Jednobarevná výplň formátovací možnost, která vyplní tvar jednou rovnoměrnou barvou. Toto ploché pozadí se použije bez jakýchkoli gradientů, textur či vzorů.

Postup pro aplikaci jednobarevné výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte preferovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Tvar s jednobarevnou výplní](solid-color-fill.png)

## **Nastavit průhlednost**

V PowerPointu, když aplikujete jednobarevnou, gradientní, obrázkovou nebo texturovou výplň na tvary, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více průhledný a podklad nebo podkladové objekty budou částečně viditelné.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) na snímek.
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` pro definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte plný obdélníkový automatický tvar.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Přidejte průhledný obdélníkový automatický tvar nad pevný tvar.
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

![Průhledný tvar](shape-transparency.png)

## **Otočit tvary**

Aspose.Slides umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovým požadavkem.

Postup pro otočení tvaru na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) na snímek.
1. Nastavte vlastnost rotace tvaru na požadovaný úhel.
1. Uložte prezentaci.

```java
import com.aspose.slides.*;

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

![Otáčení tvaru](shape-rotation.png)

## **Přidat 3D obrušovací efekty**

Aspose.Slides vám umožňuje aplikovat 3D obrušovací efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/threedformat/).

Postup pro přidání 3D obrušovacích efektů na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) na snímek.
1. Konfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/threedformat/) tvaru pro definování nastavení obroušení.
1. Uložte prezentaci.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![3D obrušovací efekt](3D-bevel-effect.png)

## **Přidat 3D rotační efekty**

Aspose.Slides vám umožňuje aplikovat 3D rotační efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/threedformat/).

Postup pro aplikaci 3D rotace na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) na snímek.
1. Použijte [setCameraType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icamera/#setCameraType-int-) a [setLightType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) pro definování 3D rotace.
1. Uložte prezentaci.

```java
import com.aspose.slides.*;

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

![3D rotační efekt](3D-rotation-effect.png)

## **Ovládání černobílého vykreslování tvarů**

Metoda [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) určuje, jak se jednotlivý tvar vykreslí, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Neaktivuje černobílý režim sama o sobě a nemění výplň, čáru nebo jiné formátování tvaru v normálním barevném režimu.

Pro výběr požadovaného chování použijte hodnotu ze třídy [BlackWhiteMode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/blackwhitemode/). Například `Automatic` nechá aplikaci zvolit převod, `Gray` a `LightGray` používají šedé zabarvení, `BlackWhite` používá jen černou a bílou, `Black` a `White` vynutí jednu barvu, `Color` zachová normální barvy a `Hidden` vynechá tvar v černobílém režimu. `NotDefined` znamená, že není přiřazen žádný režim na úrovni tvaru.

Následující Java kód vytvoří barevný tvar a způsobí, že se v černobílém zobrazovacím režimu zobrazí šedě:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Zachovat oranžovou výplň v barevném režimu, ale vykreslit tvar se šedým zbarvením v černobílém režimu.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

V normálním barevném režimu si obdélník zachovává oranžovou výplň. V pracovním postupu s černobílým zobrazením používá šedé zabarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat plnobarevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled či jiné postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovit formátování**

Následující Java kód ukazuje, jak obnovit formátování snímku a vrátit pozici, velikost a formátování všech tvarů s zástupci na [LayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/layoutslide/) na jejich výchozí nastavení:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Resetujte každý tvar na snímku, který má zástupce v rozložení.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze minimálně. Vložení obrázků a médií zabírá většinu místa v souboru, zatímco parametry tvarů jako barvy, efekty a gradienty jsou uloženy jako metadata a prakticky nezvyšují velikost souboru.

**Jak mohu na snímku detekovat tvary, které mají identické formátování, aby bylo možné je seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablonového balíku snímků nebo souboru šablony .POTX. Při vytváření nové prezentace otevřete šablonu, naklonujte stylované tvary, které potřebujete, a znovu aplikujte jejich formátování kdekoliv je to nutné.