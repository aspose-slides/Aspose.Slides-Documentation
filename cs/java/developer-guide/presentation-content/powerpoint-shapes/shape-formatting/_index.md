---
title: Formátování tvarů PowerPoint v Javě
linktitle: Formátování tvaru
type: docs
weight: 20
url: /cs/java/shape-formatting/
keywords:
- formát tvaru
- formát čáry
- kreslený efekt
- kreslená čára tvaru
- formát stylu spojení
- gradientní výplň
- vzorová výplň
- obrázková výplň
- texturovaná výplň
- jednobarevná výplň
- průhlednost tvaru
- černobílé vykreslování tvaru
- šedotónové vykreslování tvaru
- otočení tvaru
- 3D zkosený efekt
- 3D otáčecí efekt
- obnovení formátování
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v Javě pomocí Aspose.Slides—nastavit styly výplně, čáry a efektů pro soubory PPT, PPTX a ODP s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysy. Navíc můžete tvary formátovat zadáním nastavení, která řídí, jak jsou jejich vnitřky vyplněny.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides pro Java poskytuje rozhraní a metody, které vám umožňují formátovat tvary pomocí stejných možností dostupných v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar určit vlastní styl čáry. Níže je postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
1. Nastavte [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód ukazuje, jak formátovat obdélníkový `AutoShape`:

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

    // Nastavte barvu výplně pro obdélníkový tvar.
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

## **Použití kreslených efektů na čáry tvarů**

Kreslený efekt způsobí, že čára tvaru vypadá ručně kresleně. Použijte [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) k přístupu k nastavením čáry, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) k přístupu k nastavením kreslení a [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) k výběru hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Následující Java kód ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Přístup k formátu čáry tvaru a jeho formátu skicu.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Použijte kreslený efekt.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Přečtěte kreslený efekt přiřazený přímo tvaru.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Odstraňte kreslený efekt.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Hodnota vrácená metodou [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, nadřazeného snímku nebo rozvržení snímku, použijte [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), přistupte k [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/) a přečtěte [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti:

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

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Zaoblený
* Řez
* Sklon

Ve výchozím nastavení PowerPoint při spojování dvou čar pod úhlem (například v rohu tvaru) použije nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující Java kód ukazuje, jak byly vytvořeny tři obdélníky (jak je vidět na obrázku výše) pomocí nastavení spojení Miter, Bevel a Round:

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

    // Nastavte barvu čáry každého obdélníku.
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

    // Přidejte text ke každému obdélníku.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Uložte soubor PPTX na disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přechodová výplň**

V PowerPointu je Gradient Fill formátovací možnost, která vám umožňuje aplikovat plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, aby se jedna postupně vytrácela do druhé.

Zde je návod, jak aplikovat gradientní výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `add` ze sbírky gradientových zastávek, kterou poskytuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Java kód ukazuje, jak aplikovat gradientní výplň na elipsu:

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

Pokud se gradient v exportovaném obrázku liší od toho v PowerPointu, podívejte se na [Zvolit styl vykreslování gradientu](/slides/cs/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování bez změny gradientní výplně uložené v prezentaci.

## **Vzorová výplň**

Pattern Fill je formátovací možnost, která vám umožňuje aplikovat dvoubarevný design – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete použít na tvary a zlepšit tak vizuální atraktivitu prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které má použít.

Zde je návod, jak aplikovat vzorovou výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Java kód ukazuje, jak aplikovat vzorovou výplň na obdélník:

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

Picture Fill je formátovací možnost, která vám umožňuje vložit obrázek do tvaru – efektivně použít obrázek jako pozadí tvaru.

Zde je návod, jak použít Aspose.Slides k aplikaci obrázkové výplně na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) z obrázku, který chcete použít.
1. Předávejte obrázek metodě `ISlidesPicture.setImage`.
1. Uložte prezentaci.

Řekněme, že máme soubor "lotus.png" s následujícím obrázkem:

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

    // Načtěte obrázek a přidejte jej do prostředků prezentace.
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

### **Obrázek dlaždic jako textura**

Pokud chcete nastavit obrázek rozložený jako textura a přizpůsobit chování dlaždic, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Nastavuje režim obrázkové výplně – buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Řídí, zda je dlaždice překlopena vodorovně, svisle nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definuje vodorovné měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definuje svislé měřítko dlaždice v procentech.

Následující ukázkový kód ukazuje, jak přidat obdélníkový tvar s rozloženou obrázkovou výplní a nastavit možnosti dlaždic:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Přidejte automatický obdélníkový tvar.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Načtěte obrázek a přidejte jej do prostředků prezentace.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Přiřaďte obrázek k tvaru.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Nakonfigurujte režim obrázkové výplně a vlastnosti dlaždic.
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

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní tvar jednou, jednotnou barvou. Tato jednoduchá barva pozadí se aplikuje bez jakýchkoli gradientů, textur nebo vzorů.

Postup pro aplikaci jednobarevné výplně pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující Java kód ukazuje, jak aplikovat jednobarevnou výplň na obdélník v PowerPoint snímku:

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

## **Nastavení průhlednosti**

V PowerPointu, když použijete jednobarevnou, gradientní, obrázkovou nebo texturovanou výplň na tvary, můžete také nastavit úroveň průhlednosti pro řízení neprůhlednosti výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více průhledný, což umožní částečně vidět pozadí nebo objekty pod ním.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Zde je postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

Následující Java kód ukazuje, jak aplikovat průhlednou barvu výplně na obdélník:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte automatický obdélníkový tvar s plnou výplní.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Přidejte průhledný obdélníkový automatický tvar nad solidním tvarem.
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

## **Otáčení tvarů**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovými požadavky.

Postup pro otáčení tvaru na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
1. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
1. Uložte prezentaci.

Následující Java kód ukazuje, jak otáčet tvar o 5 stupňů:

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

## **Přidání 3D zkosených efektů**

Aspose.Slides vám umožňuje aplikovat 3D zkosené efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Postup pro přidání 3D zkosených efektů na tvar:

1. Instancujte třídu [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
1. Konfigurujte [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
1. Uložte prezentaci.

Následující Java kód ukazuje, jak aplikovat 3D zkosené efekty na tvar:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![3D zkosený efekt](3D-bevel-effect.png)

## **Přidání 3D otáčecích efektů**

Aspose.Slides vám umožňuje aplikovat 3D otáčecí efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Postup pro aplikaci 3D otáčení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
1. Použijte [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) a [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) k definování 3D rotace.
1. Uložte prezentaci.

Následující Java kód ukazuje, jak aplikovat 3D otáčecí efekty na tvar:

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

![3D otáčecí efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslování pro tvary**

Metoda [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazena nebo zpracována v černobílém režimu. Sama o sobě neaktivuje černobílé zobrazení a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu ze třídy [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `Automatic` umožňuje aplikaci pro vykreslování zvolit konverzi, `Gray` a `LightGray` používají šedé barvy, `BlackWhite` používá pouze černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová běžné zbarvení a `Hidden` vynechává tvar v černobílém režimu. `NotDefined` znamená, že není přiřazeno žádné režim na úrovni tvaru.

Následující Java kód vytvoří barevný tvar a v černobílém režimu jej zobrazí šedě:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Uchovejte oranžovou výplň v barevném režimu, ale vykreslete tvar se šedým zbarvením v černobílém režimu.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obnovení formátování**

Následující Java kód ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů se zástupci na [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) na výchozí nastavení:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Resetujte každý tvar na snímku, který má zástupný prvek v rozvržení.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze mírně. Vložené obrázky a média zabírají většinu místa v souboru, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a prakticky nepřidávají žádnou další velikost.

**Jak mohu na snímku zjistit tvary se stejným formátováním, abych je mohl seskupit?**

Porovnejte klíčové formátovací vlastnosti každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony snímků nebo souboru šablony .POTX. Při vytváření nové prezentace otevřete šablonu, zkopírujte potřebné stylované tvary a znovu použijte jejich formátování podle potřeby.