---
title: Formátování tvarů PowerPointu na Androidu
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/androidjava/shape-formatting/
keywords:
- formátovat tvar
- formátovat čáru
- skicový efekt
- skicovat čáru tvaru
- formátovat styl spojení
- gradientová výplň
- vzorná výplň
- vyplnění obrázkem
- texturovaná výplň
- vyplnění jednou barvou
- průhlednost tvaru
- černobílé vykreslování tvaru
- vykreslení tvaru v odstínech šedi
- otočit tvar
- 3D zkosený efekt
- 3D rotační efekt
- obnovit formátování
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu na Androidu pomocí Aspose.Slides — nastavení výplní, čar a stylů efektů pro soubory PPT, PPTX a ODP s precizností a úplnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Jelikož jsou tvary složeny z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysy. Navíc můžete tvary formátovat nastavením, které řídí, jak jsou jejich vnitřky vyplněny.

![formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides for Android via Java poskytuje rozhraní a metody, které vám umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar určit vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [styl čáry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [styl čerchování](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód ukazuje, jak formátovat obdélník `AutoShape`:

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

    // Odstraňte výplň z obdélníkového tvaru, aby byly viditelné pouze jeho čáry.
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

**Výsledek:**

![Formátované čáry v prezentaci](formatted-lines.png)

## **Použití skicových efektů na čáry tvarů**

Skicový efekt způsobí, že čára tvaru vypadá ručně kresleně. Použijte [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) pro přístup k nastavením čáry, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) pro přístup k nastavením skicy a [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Následující kód v jazyce Java ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) , jak přečíst explicitně přiřazenou hodnotu a jak odebrat efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Získejte formát čáry tvaru a jeho skicový formát.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Použijte skicový efekt.
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

Hodnota vrácená metodou [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení snímku, použijte [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/), přistupte k [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/), a přečtěte [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/). Efektivní hodnota odráží skutečné formátování po vyřešení zdědění:

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

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Kulatý
* Šikmý
* Sražený

Ve výchozím nastavení PowerPoint při spojení dvou čar pod úhlem (například v rohu tvaru) používá nastavení **Kulatý**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostňovat možnost **Šikmý**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

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

## **Gradientové výplně**

V PowerPointu je Gradient Fill formátovací možnost, která vám umožňuje aplikovat plynulé prolínání barev na tvar. Například můžete použít dvě nebo více barev tak, aby se jedna postupně přecházela v druhou.

Zde je návod, jak pomocí Aspose.Slides aplikovat gradientovou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `add` kolekce gradientových zastávek, kterou poskytuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/).
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

    // Aplikujte gradientové formátování na elipsu.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Nastavte směr gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Přidejte dva gradientové zastavení.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Uložte soubor PPTX na disk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Výsledek:**

![Elipsa s gradientovou výplní](gradient-fill.png)

Pokud se gradient v exportovaném obrázku liší od toho v PowerPointu, podívejte se na [Vyberte styl vykreslování gradientu](/slides/cs/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování, aniž byste měnili gradientovou výplň uloženou v prezentaci.

## **Vyplňování vzorem**

V PowerPointu je Pattern Fill formátovací možnost, která vám umožňuje použít dvoubarevný návrh – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na tvary a zvýšit tak vizuální atraktivitu prezentací. I po výběru předdefinovaného vzoru můžete přesně určit barvy, které má použít.

Zde je návod, jak pomocí Aspose.Slides aplikovat výplň vzorem na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) vzoru.
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

**Výsledek:**

![Obdélník s výplní vzorem](pattern-fill.png)

## **Vyplnění obrázkem**

V PowerPointu je Picture Fill formátovací možnost, která vám umožňuje vložit obrázek do tvaru – efektivně použít obrázek jako pozadí tvaru.

Zde je návod, jak pomocí Aspose.Slides aplikovat vyplnění obrázkem na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim vyplnění obrázkem na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) z obrázku, který chcete použít.
1. Předávejte obrázek metodě `ISlidesPicture.setImage`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Řekněme, že máme soubor „lotus.png“ s následujícím obrázkem:

![Obrázek lotusu](lotus.png)

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

    // Nastavte režim vyplnění obrázkem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Načtěte obrázek a přidejte jej k prostředkům prezentace.
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

**Výsledek:**

![Tvar s vyplněním obrázkem](picture-fill.png)

### **Dlaždicovat obrázek jako texturu**

Pokud chcete nastavit dlaždicovaný obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Nastavuje režim vyplnění obrázkem – buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Řídí, zda je dlaždice otočena horizontálně, vertikálně nebo oběma způsoby.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Nastavuje horizontální odsazení dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Nastavuje vertikální odsazení dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definuje horizontální měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definuje vertikální měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovou výplní obrázkem a nakonfigurovat možnosti dlaždic:

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Získejte první snímek.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Přidejte automatický tvar obdélníku.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Načtěte obrázek a přidejte jej k prostředkům prezentace.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Přiřaďte obrázek k tvaru.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Nakonfigurujte režim vyplnění obrázkem a vlastnosti dlaždic.
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

**Výsledek:**

![Možnosti dlaždic](tile-options.png)

## **Vyplnění jednou barvou**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní tvar jednou jednotnou barvou. Toto jednoduché pozadí se použije bez gradientů, textur či vzorů.

Chcete-li pomocí Aspose.Slides aplikovat výplň jednou barvou na tvar, postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
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

**Výsledek:**

![Tvar s výplní jednou barvou](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když aplikujete výplň jednou barvou, gradientovou, obrázkovou nebo texturální, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že je tvar průhlednější a pozadí nebo podkladové objekty jsou částečně viditelné.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa složky barvy použité pro výplň. Postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) na `Solid`.
1. Použijte `Color` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

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

    // Přidejte transparentní obdélníkový automatický tvar nad plný tvar.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Uložte soubor PPTX na disk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Výsledek:**

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umisťování vizuálních elementů s konkrétním zarovnáním nebo designovými požadavky.

Chcete‑li otočit tvar na snímku, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
1. Nastavte vlastnost otáčení tvaru na požadovaný úhel.
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

**Výsledek:**

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D zkosených efektů**

Aspose.Slides umožňuje aplikovat 3D zkosené efekty na tvary konfigurováním jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Chcete‑li přidat 3D zkosené efekty na tvar, postupujte takto:

1. Instanciujte třídu [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
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

**Výsledek:**

![3D zkosený efekt](3D-bevel-effect.png)

## **Přidání 3D rotačních efektů**

Aspose.Slides umožňuje aplikovat 3D rotační efekty na tvary konfigurováním jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Chcete‑li aplikovat 3D rotaci na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
1. Použijte [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) a [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) pro definování 3D rotace.
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

**Výsledek:**

![3D rotační efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslování pro tvary**

Metoda [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) určuje, jak se jednotlivý tvar vykresluje, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Tato metoda sama o sobě neaktivuje černobílý režim a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu ze třídy [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) pro výběr požadovaného chování. Například `Automatic` nechá renderovací aplikaci zvolit konverzi, `Gray` a `LightGray` používají šedé zabarvení, `BlackWhite` používá pouze černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová normální barvy, `Hidden` vynechá tvar v černobílém režimu a `NotDefined` znamená, že nebyl přiřazen žádný režim na úrovni tvaru.

Následující kód v jazyce Java vytvoří barevný tvar a způsobí, že se v černobílém zobrazovacím režimu zobrazí šedě:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Uchovejte oranžovou výplň v barevném režimu, ale vykreslete tvar se šedým zabarvením v černobílém režimu.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

V normálním barevném režimu si obdélník zachová oranžovou výplň. V pracovním postupu černobílého zobrazení používá šedé zbarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat plnobarevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné pracovní postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Následující kód v jazyce Java ukazuje, jak obnovit formátování snímku a vrátit pozici, velikost a formátování všech tvarů s placeholdery na [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) na jejich výchozí nastavení:

```java
import com.aspose.slides.*;

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

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze nepatrně. Vložené obrázky a média zabírají většinu prostoru souboru, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a téměř nepřidávají žádnou velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony snímků nebo souboru .POTX. Při tvorbě nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu použijte jejich formátování tam, kde je to potřeba.