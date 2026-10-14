---
title: Formátování tvarů PowerPointu v .NET
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/net/shape-formatting/
keywords:
- formát tvaru
- formát čáry
- skicový efekt
- skicová čára tvaru
- formát stylu spojení
- gradientní výplň
- vzorková výplň
- obrázková výplň
- texturovaná výplň
- plná barva výplně
- průhlednost tvaru
- černobílé vykreslování tvaru
- šedotónové vykreslování tvaru
- otočení tvaru
- 3D výsuvový efekt
- 3D otáčovací efekt
- resetování formátování
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v C# pomocí Aspose.Slides — nastavte výplň, čáru a styly efektů pro soubory PPT a PPTX s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysech. Navíc můžete tvary formátovat nastavením, které řídí, jak jsou jejich výplně vyplněny.

![formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro .NET poskytuje rozhraní a vlastnosti, které vám umožní formátovat tvary pomocí stejných možností, jaké jsou dostupné v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Postup je následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Nastavte [line style](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v C# ukazuje, jak formátovat obdélník `AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Obdélník.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte barvu výplně pro obdélníkový tvar.
    shape.FillFormat.FillType = FillType.NoFill;

    // Použijte formátování na čáry obdélníku.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Nastavte barvu čáry obdélníku.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Uložte soubor PPTX na disk.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

## **Použití skicových efektů na čáry tvaru**

Skicový efekt způsobí, že čára tvaru vypadá ručně kresleně. Použijte [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) pro přístup k nastavením čáry, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) pro přístup k nastavením skicu a [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Následující kód v C# ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

Hodnota vrácená `ISketchFormat.SketchType` představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení, použijte [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), přistupujte k [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) a přečtěte [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Ve výchozím nastavení PowerPoint spojuje dvě čáry pod úhlem (například v rohu tvaru) pomocí nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující kód v C# ukazuje, jak byly vytvořeny tři obdélníky (jak je vidět na obrázku výše) s nastavením spojení Miter, Bevel a Round:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte tři automatické tvary typu Obdélník.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Nastavte barvu výplně pro každý obdélníkový tvar.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Nastavte šířku čáry.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Nastavte barvu čáry pro každý obdélník.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Nastavte styl spoje.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Přidejte text do každého obdélníku.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Uložte soubor PPTX na disk.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradientní výplň**

V PowerPointu je Gradient Fill formátovací možnost, která umožňuje aplikovat plynulé prolínání barev na tvar. Například můžete použít dvě nebo více barev tak, aby jedna postupně přecházela v druhou.

Postup, jak použít gradientní výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Nastavte vlastnost [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) tvaru na `Gradient`.
1. Přidejte dvě požadované barvy s definovanými pozicemi pomocí metod `Add` kolekce gradientových zastávek, kterou vystavuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v C# demonstruje, jak aplikovat gradientní výplň na elipsu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Elipsa.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Použijte gradientní formátování na elipsu.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Nastavte směr gradientu.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Přidejte dva gradientové zastávky.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Uložte soubor PPTX na disk.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Elipsa s gradientní výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, viz [Choose a Gradient Rendering Style](/slides/cs/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování, aniž byste měnili gradientní výplň uloženou v prezentaci.

## **Vzorová výplň**

V PowerPointu je Pattern Fill formátovací možnost, která vám umožní aplikovat dvoubarevný vzor – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Pro popředí i pozadí vzoru můžete zvolit vlastní barvy.

Aspose.Slides nabízí více než 45 předdefinovaných vzorových stylů, které můžete aplikovat na tvary a zvýšit vizuální atraktivitu prezentace. I po výběru předdefinovaného vzoru můžete určit přesné barvy, které má použít.

Postup, jak aplikovat vzorovou výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Nastavte vlastnost [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) tvaru na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v C# ukazuje, jak aplikovat vzorovou výplň na obdélník:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Obdélník.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Vzor.
    shape.FillFormat.FillType = FillType.Pattern;

    // Nastavte styl vzoru.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Nastavte barvy pozadí a popředí vzoru.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Uložte soubor PPTX na disk.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je Picture Fill formátovací možnost, která vám umožní vložit obrázek do tvaru – vlastně použít obrázek jako pozadí tvaru.

Postup, jak pomocí Aspose.Slides aplikovat obrázkovou výplň na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Nastavte vlastnost [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) tvaru na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný požadovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) z obrázku, který chcete použít.
1. Přiřaďte tento obrázek vlastnosti `Picture.Image` formátu `PictureFillFormat` tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor „lotus.png“ s následujícím obrázkem:

![Obrázek lotosu](lotus.png)

Následující kód v C# ukazuje, jak naplnit tvar obrázkem:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Obdélník.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Nastavte typ výplně na Obrázek.
    shape.FillFormat.FillType = FillType.Picture;

    // Nastavte režim výplně obrázkem.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Nastavte obrázek.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Uložte soubor PPTX na disk.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Obrázek dlaždicovat jako texturu**

Pokud chcete nastavit obrázek dlaždicovaný jako texturu a přizpůsobit chování dlaždicování, můžete použít následující vlastnosti rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Nastavuje režim obrázkové výplně – `Tile` nebo `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Řídí, zda je dlaždice převrácena vodorovně, svisle nebo obojí.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definuje vodorovné měřítko dlaždice v procentech.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definuje svislé měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovou obrázkovou výplní a nakonfigurovat možnosti dlaždic:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide firstSlide = presentation.Slides[0];

    // Přidejte automatický tvar typu Obdélník.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Obrázek.
    shape.FillFormat.FillType = FillType.Picture;

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Přiřaďte obrázek k tvaru.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Nastavte režim výplně obrázkem a vlastnosti dlaždicování.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Uložte soubor PPTX na disk.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Možnosti dlaždicování](tile-options.png)

## **Plná barva výplně**

V PowerPointu je Solid Color Fill formátovací možnost, která vyplní tvar jednou, jednotnou barvou. Tento jednoduchý podklad je aplikován bez gradientů, textur či vzorů.

Postup, jak aplikovat plnou barvu výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Nastavte vlastnost [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) tvaru na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v C# ukazuje, jak aplikovat plnou barvu výplně na obdélník v PowerPointovém snímku:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Obdélník.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Plnou.
    shape.FillFormat.FillType = FillType.Solid;

    // Nastavte barvu výplně.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Uložte soubor PPTX na disk.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Tvar s plnou barvou výplně](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu můžete při aplikaci plné barvy, gradientu, obrázku nebo textury nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více průsvitný a podklad nebo podkladové objekty budou částečně viditelné.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) na `Solid`.
1. Použijte `Color.FromArgb(alpha, baseColor)` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

Následující kód v C# demonstruje, jak aplikovat průhlednou barvu výplně na obdélník:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte plný obdélníkový automatický tvar.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Přidejte průhledný obdélníkový automatický tvar nad plným tvarem.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Uložte soubor PPTX na disk.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Aspose.Slides umožňuje otáčet tvary v PowerPointových prezentacích. To může být užitečné při umísťování vizuálních prvků s konkrétním zarovnáním nebo designem.

Postup, jak otočit tvar na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Nastavte vlastnost `Rotation` tvaru na požadovaný úhel.
1. Uložte prezentaci.

Následující kód v C# ukazuje, jak otočit tvar o 5 stupňů:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Obdélník.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Otočte tvar o 5 stupňů.
    shape.Rotation = 5;

    // Uložte soubor PPTX na disk.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D výsuvových efektů**

Aspose.Slides vám umožňuje aplikovat 3D výsuvové efekty na tvary nastavením jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Postup, jak přidat 3D výsuvový efekt na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) tvaru tak, aby definoval nastavení výsuvu.
1. Uložte prezentaci.

Následující kód v C# ukazuje, jak aplikovat 3D výsuvový efekt na tvar:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte tvar na snímek.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Nastavte vlastnosti ThreeDFormat tvaru.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Uložte prezentaci jako soubor PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![3D výsuvový efekt](3D-bevel-effect.png)

## **Přidání 3D otáčecích efektů**

Aspose.Slides vám umožňuje aplikovat 3D otáčecí efekty na tvary nastavením jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/).

Postup, jak aplikovat 3D otáčení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte na snímek [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
1. Nastavte [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) a [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) tvaru pro definování 3D otáčení.
1. Uložte prezentaci.

Následující kód v C# demonstruje, jak aplikovat 3D otáčecí efekty na tvar:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Uložte prezentaci jako soubor PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![3D otáčecí efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslení pro tvary**

Vlastnost [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Nevytváří samotný černobílý režim a nemění výplň, čáru nebo další formátování tvaru v normálním barevném režimu.

Použijte hodnotu z výčtu [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) pro výběr požadovaného chování. Například `Automatic` nechá aplikaci vybrat převod, `Gray` a `LightGray` použijí šedé tonální zobrazení, `BlackWhite` použije jen černou a bílou, `Black` a `White` vynutí jednobarevný výstup, `Color` zachová normální barvy a `Hidden` skryje tvar v černobílém režimu. `NotDefined` znamená, že není přiřazen žádný režim na úrovni tvaru.

Následující kód v C# vytvoří barevný tvar a zobrazí jej šedě v černobílém režimu:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Zachovejte oranžovou výplň v barevném režimu, ale vykreslete tvar se šedým zbarvením v černobílém režimu.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

V normálním barevném režimu si obdélník zachová oranžovou výplň. V pracovním postupu černobílého zobrazení použije šedé zobrazení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat plnobarevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné scénáře, které respektují nastavení černobílého režimu prezentace.

## **Obnovení formátování**

Následující kód v C# ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů s placeholdery na [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) na jejich výchozí nastavení:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Resetujte každý tvar na snímku, který má placeholder v rozložení.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Ovlivňuje formátování tvaru velikost výsledného souboru prezentace?**

Jen minimálně. Vložené obrázky a média zaujímají většinu místa, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a prakticky nepřidávají žádnou velikost.

**Jak mohu zjistit tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opakované použití v dalších prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, zkopírujte potřebné stylované tvary a aplikujte jejich formátování tam, kde je potřeba.