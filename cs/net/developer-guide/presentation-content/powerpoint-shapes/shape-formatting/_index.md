---
title: Formátování tvarů PowerPointu v .NET
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/net/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- náčrtový efekt
- náčrtová čára tvaru
- formátování stylu spojení
- gradientové vyplnění
- vzorkované vyplnění
- obrázkové vyplnění
- texturované vyplnění
- jednobarevné vyplnění
- průhlednost tvaru
- černobílé vykreslení tvaru
- vykreslení tvaru ve stupních šedi
- otočit tvar
- 3D zkosený efekt
- 3D rotační efekt
- resetovat formátování
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v C# pomocí Aspose.Slides—nastavte styly vyplnění, čáry a efektů pro soubory PPT a PPTX s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo použitím efektů na jejich obrysy. Navíc můžete tvary formátovat zadáním nastavení, která řídí, jak jsou jejich vnitřky vyplněny.

![Formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro .NET poskytuje rozhraní a vlastnosti, které vám umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Nastavte [line style](https://reference.aspose.com/slides/cs/net/aspose.slides/linestyle/) tvaru.
5. Nastavte šířku čáry.
6. Nastavte [dash style](https://reference.aspose.com/slides/cs/net/aspose.slides/linedashstyle/) čáry.
7. Nastavte barvu čáry pro tvar.
8. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód C# ukazuje, jak naformátovat obdélníkový `AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Rectangle.
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

![Formátované čáry v prezentaci](formatted-lines.png)

## **Použití náčrtových efektů na čáry tvaru**

Cílem náčrtového efektu je, aby čára tvaru vypadala ručně kresleně. Použijte [IShape.LineFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/lineformat/) pro přístup k nastavením čáry, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ilineformat/sketchformat/) pro přístup k nastavením náčrtu a [ISketchFormat.SketchType](https://reference.aspose.com/slides/cs/net/aspose.slides/isketchformat/sketchtype/) pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/net/aspose.slides/linesketchtype/).

Následující kód C# ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/cs/net/aspose.slides/linesketchtype/) , přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/cs/net/aspose.slides/linesketchtype/):

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

Hodnota vrácená `ISketchFormat.SketchType` představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení snímku, použijte [ILineFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/ilineformat/geteffective/), přistupujte k [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ilineformateffectivedata/sketchformat/), a přečtěte [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/cs/net/aspose.slides/isketchformateffectivedata/sketchtype/). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti:

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

* Kulatý
* Miter
* Šikmý

Ve výchozím nastavení PowerPoint spojuje dvě čáry pod úhlem (například na rohu tvaru) pomocí nastavení **Kulatý**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující kód C# ukazuje, jak byly vytvořeny tři obdélníky (jak je vidět na obrázku výše) pomocí nastavení typu spojení Miter, Bevel a Round:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte tři automatické tvary typu Rectangle.
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

    // Nastavte styl spojení.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Přidejte text ke každému obdélníku.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Uložte soubor PPTX na disk.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradientové vyplnění**

V PowerPointu je Gradientové vyplnění formátovací možnost, která vám umožňuje použít plynulý přechod barev na tvar. Například můžete použít dvě nebo více barev tak, že se jedna postupně přechází do druhé.

Zde je postup, jak aplikovat gradientové vyplnění na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) tvaru na `Gradient`.
5. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `Add` kolekce gradientových zastávek, kterou poskytuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/igradientformat/).
6. Uložte upravenou prezentaci jako soubor PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Použijte gradientové formátování na elipsu.
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

![Elipsa s gradientovým vyplněním](gradient-fill.png)

## **Vzorkované vyplnění**

V PowerPointu je Vzorkované vyplnění formátovací možnost, která vám umožňuje aplikovat dvoubarevný návrh – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete zvolit vlastní barvy popředí a pozadí vzoru.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete aplikovat na tvary a zvýšit tak vizuální atraktivitu vašich prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které má použít.

Toto je postup, jak aplikovat vzorkované vyplnění na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) tvaru na `Pattern`.
5. Vyberte styl vzoru z předdefinovaných možností.
6. Nastavte [Background Color](https://reference.aspose.com/slides/cs/net/aspose.slides/ipatternformat/backcolor/) vzoru.
7. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/net/aspose.slides/ipatternformat/forecolor/) vzoru.
8. Uložte upravenou prezentaci jako soubor PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Pattern.
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

![Obdélník s vzorkovaným vyplněním](pattern-fill.png)

## **Obrázkové vyplnění**

V PowerPointu je Obrázkové vyplnění formátovací možnost, která vám umožňuje vložit obrázek dovnitř tvaru – efektivně použít obrázek jako pozadí tvaru.

Toto je postup, jak pomocí Aspose.Slides aplikovat obrázkové vyplnění na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) tvaru na `Picture`.
5. Nastavte režim obrázkového vyplnění na `Tile` (nebo jiný preferovaný režim).
6. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) z obrázku, který chcete použít.
7. Přiřaďte tento obrázek vlastnosti `Picture.Image` formátu `PictureFillFormat` tvaru.
8. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor „lotus.png“ s následujícím obrázkem:

![Obrázek lotusu](lotus.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Nastavte typ výplně na Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Nastavte režim vyplnění obrázkem.
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

![Tvar s obrázkovým vyplněním](picture-fill.png)

### **Dlaždicový obrázek jako textura**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dláždění, můžete použít následující vlastnosti rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/picturefillmode/): Nastaví režim obrázkového vyplnění – buď `Tile`, nebo `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tilealignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [TileFlip](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tileflip/): Řídí, zda je dlaždice otočena horizontálně, vertikálně nebo obojí.
- [TileOffsetX](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tileoffsetx/): Nastaví horizontální posun dlaždice (v bodech) od počátku tvaru.
- [TileOffsetY](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tileoffsety/): Nastaví vertikální posun dlaždice (v bodech) od počátku tvaru.
- [TileScaleX](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tilescalex/): Definuje horizontální měřítko dlaždice v procentech.
- [TileScaleY](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tilescaley/): Definuje vertikální měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s dlaždicovým obrázkovým vyplněním a nakonfigurovat možnosti dlaždic:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide firstSlide = presentation.Slides[0];

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Přiřaďte obrázek ke tvaru.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Nakonfigurujte režim vyplnění obrázkem a vlastnosti dláždění.
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

![Možnosti dláždění](tile-options.png)

## **Jednobarevné vyplnění**

V PowerPointu je Jednobarevné vyplnění formátovací možnost, která vyplní tvar jednou jednotnou barvou. Tato jednoduchá barva pozadí se použije bez jakýchkoli gradientů, textur nebo vzorů.

Pro aplikaci jednobarevného vyplnění na tvar pomocí Aspose.Slides postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) tvaru na `Solid`.
5. Přiřaďte požadovanou barvu vyplnění tvaru.
6. Uložte upravenou prezentaci jako soubor PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Nastavte barvu výplně.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Uložte soubor PPTX na disk.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

![Tvar s jednobarevným vyplněním](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když použijete jednobarevné, gradientové, obrázkové nebo texturové vyplnění na tvary, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost vyplnění. Vyšší hodnota průhlednosti způsobí, že tvar bude průhlednější a umožní částečnou viditelnost pozadí nebo podkladových objektů.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro vyplnění. Zde je postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) tvaru na `Solid`.
5. Použijte `Color.FromArgb(alpha, baseColor)` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
6. Uložte prezentaci.

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

    // Přidejte automatický tvar obdélníku s plnou výplní.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Přidejte transparentní automatický tvar obdélníku nad plný tvar.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Uložte soubor PPTX na disk.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umisťování vizuálních prvků s konkrétními požadavky na zarovnání nebo design.

Pro otáčení tvaru na snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Nastavte vlastnost `Rotation` tvaru na požadovaný úhel.
5. Uložte prezentaci.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Otočte tvar o 5 stupňů.
    shape.Rotation = 5;

    // Uložte soubor PPTX na disk.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D zkosených efektů**

Aspose.Slides vám umožňuje aplikovat 3D zkosené efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/).

Pro přidání 3D zkosených efektů na tvar postupujte takto:

1. Instancujte třídu [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
5. Uložte prezentaci.

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

![3D zkosený efekt](3D-bevel-effect.png)

## **Přidání 3D rotačních efektů**

Aspose.Slides vám umožňuje aplikovat 3D rotační efekty na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/).

Pro aplikaci 3D rotace na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Nastavte [CameraType](https://reference.aspose.com/slides/cs/net/aspose.slides/icamera/cameratype/) a [LightType](https://reference.aspose.com/slides/cs/net/aspose.slides/ilightrig/lighttype/) tvaru pro definování 3D rotace.
5. Uložte prezentaci.

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

![3D rotační efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslení pro tvary**

Vlastnost [IShape.BlackWhiteMode](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/blackwhitemode/) určuje, jak se jednotlivý tvar vykreslí, když je prezentace zobrazena nebo zpracována v černobílém režimu. Sama o sobě neaktivuje černobílé zobrazení a nemění vyplnění, čáru ani jiné formátování tvaru v normálním barevném režimu.

Při výběru požadovaného chování použijte hodnotu z výčtu [BlackWhiteMode](https://reference.aspose.com/slides/cs/net/aspose.slides/blackwhitemode/). Například `Automatic` ponechá výběr konverze na aplikaci, `Gray` a `LightGray` použijí šedé zbarvení, `BlackWhite` používá jen černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová normální barvu a `Hidden` vynechá tvar v černobílém režimu. `NotDefined` znamená, že není přiřazen žádný režim na úrovni tvaru.

Následující kód C# vytvoří barevný tvar a zobrazí jej šedě v černobílém režimu zobrazení:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Udržte oranžovou výplň v barevném režimu, ale vykreslete tvar se šedým zbarvením v černobílém režimu.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

V normálním barevném režimu si obdélník zachová oranžové vyplnění. V černobílém pracovním procesu se použije šedé zbarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat snímek v plné barvě a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné procesy, které respektují nastavení černobílého zobrazení prezentace.

## **Resetování formátování**

Následující kód C# ukazuje, jak resetovat formátování snímku a vrátit pozici, velikost a formátování všech tvarů s místodržiteli na [LayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutslide/) na výchozí nastavení:

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

**Ovlivňuje formátování tvaru konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu místa v souboru, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a téměř nepřidávají žádnou velikost.

**Jak mohu na snímku zjistit tvary, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení vyplnění, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony snímků nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, naklonujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je potřeba.