---
title: Formátování tvarů PowerPointu v .NET
linktitle: Formátování tvaru
type: docs
weight: 20
url: /cs/net/shape-formatting/
keywords:
- formát tvaru
- formát čáry
- náčrtový efekt
- náčrtová čára tvaru
- formát stylu spojení
- gradientová výplň
- výplň vzorem
- obrázková výplň
- texturovaná výplň
- jednobarevná výplň
- průhlednost tvaru
- otočení tvaru
- 3D efekt zkosení
- 3D efekt otáčení
- obnovení formátování
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v C# pomocí Aspose.Slides—nastavit styly výplně, čáry a efektů pro soubory PPT a PPTX s přesností a plnou kontrolou."
---
## **Úvod**

V PowerPointu můžete do snímků přidávat tvary. Protože jsou tvary tvořeny čarami, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysy. Navíc můžete tvary formátovat nastavením, která určují, jak bude vyplněn jejich vnitřek.

![formátování tvaru v powerpointu](format-shape-powerpoint.png)

Aspose.Slides pro .NET poskytuje rozhraní a vlastnosti, které vám umožní formátovat tvary pomocí stejných možností, jaké jsou dostupné v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte [line style](https://reference.aspose.com/slides/cs/net/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [dash style](https://reference.aspose.com/slides/cs/net/aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v C# ukazuje, jak formátovat obdélníkový `AutoShape`:

```c#
 // Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
 using (Presentation presentation = new Presentation())
 {
     // Získejte první snímek.
     ISlide slide = presentation.Slides[0];

     // Přidejte automatický tvar typu Obdélník.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

     // Nastavte barvu výplně pro obdélníkový tvar.
     shape.FillFormat.FillType = FillType.NoFill;

     // Aplikujte formátování na čáry obdélníku.
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

## **Použití náčrtových efektů na čáry tvarů**

Náčrtový efekt způsobí, že čára tvaru vypadá, jako by byla ručně kreslená. Použijte [IShape.LineFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/lineformat/) pro přístup k nastavením čáry, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ilineformat/sketchformat/) pro přístup k nastavením náčrtu a [ISketchFormat.SketchType](https://reference.aspose.com/slides/cs/net/aspose.slides/isketchformat/sketchtype/) pro výběr hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/cs/net/aspose.slides/linesketchtype/).

Následující kód v C# ukazuje, jak aplikovat efekt [LineSketchType.Curved](https://reference.aspose.com/slides/cs/net/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/cs/net/aspose.slides/linesketchtype/):

```csharp
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

Hodnota vrácená `ISketchFormat.SketchType` představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozvržení, použijte [ILineFormat.GetEffective](https://reference.aspose.com/slides/cs/net/aspose.slides/ilineformat/geteffective/), přistupte k [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ilineformateffectivedata/sketchformat/) a přečtěte [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/cs/net/aspose.slides/isketchformateffectivedata/sketchtype/). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení zděděných nastavení:

```csharp
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

* Round – zakulacené
* Miter – šikmé
* Bevel – zkosené

Ve výchozím nastavení PowerPoint používá při spojení dvou čar pod úhlem (například v rohu tvaru) nastavení **Round**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Miter**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující kód v C# ukazuje, jak byly vytvořeny tři obdélníky (viz obrázek výše) pomocí nastavení spojení Miter, Bevel a Round:

```c#
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

    // Nastavte barvu čáry každého obdélníku.
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

    // Přidejte text do každého obdélníku.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Uložte soubor PPTX na disk.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradientové výplně**

V PowerPointu je gradientová výplň formátovací možnost, která vám umožní aplikovat plynulý přechod barev do tvaru. Například můžete použít dvě nebo více barev tak, aby jedna postupně přecházela v druhou.

Postup aplikace gradientové výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Gradient`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `Add` kolekce zastávek gradientu, kterou vystavuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/igradientformat/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v C# ukazuje, jak aplikovat efekt gradientové výplně na elipsu:

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Elipsa.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplikujte gradientové formátování na elipsu.
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

![Elipsa s gradientovou výplní](gradient-fill.png)

## **Výplň vzorem**

V PowerPointu je výplň vzorem formátovací možnost, která vám umožní aplikovat dvoubarevný vzor – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Pro popředí i pozadí vzoru můžete zvolit vlastní barvy.

Aspose.Slides poskytuje více než 45 předdefinovaných stylů vzorů, které můžete použít na tvary a zvýšit tak vizuální atraktivitu prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které se mají použít.

Postup aplikace výplně vzorem na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/net/aspose.slides/ipatternformat/backcolor/) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/net/aspose.slides/ipatternformat/forecolor/) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v C# ukazuje, jak aplikovat výplň vzorem na obdélník:

```c#
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

![Obdélník s výplní vzorem](pattern-fill.png)

## **Obrázková výplň**

V PowerPointu je obrázková výplň formátovací možnost, která vám umožní vložit obrázek dovnitř tvaru – prakticky použít obrázek jako pozadí tvaru.

Postup použití Aspose.Slides pro aplikaci obrázkové výplně na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Picture`.
1. Nastavte režim obrázkové výplně na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) z obrázku, který chcete použít.
1. Přiřaďte tento obrázek vlastnosti `Picture.Image` výplňového formátu `PictureFillFormat` tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Řekněme, že máme soubor **lotus.png** s následujícím obrázkem:

![Obrázek lotusu](lotus.png)

Následující kód v C# ukazuje, jak vyplnit tvar obrázkem:

```c#
 // Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
 using (Presentation presentation = new Presentation())
 {
     // Získejte první snímek.
     ISlide slide = presentation.Slides[0];
 
     // Přidejte automatický tvar typu Obdélník.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
 
     // Nastavte typ výplně na Obrázek.
     shape.FillFormat.FillType = FillType.Picture;
 
     // Nastavte režim obrázkové výplně.
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

### **Dlaždicovat obrázek jako texturu**

Pokud chcete nastavit obrázek jako dlaždicovou texturu a přizpůsobit chování dlaždicování, můžete použít následující vlastnosti rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/picturefillmode/): Nastavuje režim obrázkové výplně – `Tile` nebo `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tilealignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [TileFlip](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tileflip/): Ovládá, zda je dlaždice převrácena horizontálně, vertikálně nebo oběma směry.
- [TileOffsetX](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tileoffsetx/): Nastavuje horizontální posun dlaždice (v bodech) od počátku tvaru.
- [TileOffsetY](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tileoffsety/): Nastavuje vertikální posun dlaždice (v bodech) od počátku tvaru.
- [TileScaleX](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tilescalex/): Definuje horizontální měřítko dlaždice v procentech.
- [TileScaleY](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tilescaley/): Definuje vertikální měřítko dlaždice v procentech.

Následující ukázkový kód ukazuje, jak přidat obdélníkový tvar s dlaždicovou obrázkovou výplní a nakonfigurovat možnosti dlaždic:

```c#
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

    // Nakonfigurujte režim obrázkové výplně a vlastnosti dlaždicování.
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

## **Jednobarevná výplň**

V PowerPointu je jednobarevná výplň formátovací možnost, která vyplní tvar jednou, jednotnou barvou. Tento jednoduchý podklad se aplikuje bez gradientů, textur nebo vzorů.

Postup aplikace jednobarevné výplně na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v C# ukazuje, jak aplikovat jednobarevnou výplň na obdélník v PowerPoint snímku:

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Obdélník.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Nastavte typ výplně na Jednobarevný.
    shape.FillFormat.FillType = FillType.Solid;

    // Nastavte barvu výplně.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Uložte soubor PPTX na disk.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Tvar s jednobarevnou výplní](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když použijete jednobarevnou, gradientovou, obrázkovou nebo texturovou výplň na tvary, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že bude tvar více průhledný, což umožní viditelnost pozadí nebo podkladových objektů.

Aspose.Slides umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty ve barvě použitých pro výplň. Postup:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Solid`.
1. Použijte `Color.FromArgb(alpha, baseColor)` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

Následující kód v C# ukazuje, jak aplikovat průhlednou barvu výplně na obdélník:

```c#
const int alpha = 128;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte plný obdélníkový automatický tvar.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Přidejte průhledný obdélníkový automatický tvar nad plný tvar.
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

Aspose.Slides umožňuje otáčet tvary v PowerPoint prezentacích. To může být užitečné při umisťování vizuálních prvků s konkrétním zarovnáním nebo designovými požadavky.

Postup otáčení tvaru na snímku:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte vlastnost `Rotation` tvaru na požadovaný úhel.
1. Uložte prezentaci.

Následující kód v C# ukazuje, jak otočit tvar o 5 stupňů:

```c#
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

## **Přidání 3D efektů zkosení**

Aspose.Slides umožňuje aplikovat 3D efekty zkosení na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/).

Postup přidání 3D efektů zkosení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nakonfigurujte [ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/) tvaru pro definování nastavení zkosení.
1. Uložte prezentaci.

Následující kód v C# ukazuje, jak aplikovat 3D efekty zkosení na tvar:

```c#
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

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidání 3D efektů otáčení**

Aspose.Slides umožňuje aplikovat 3D efekty otáčení na tvary konfigurací jejich vlastností [ThreeDFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/threedformat/).

Postup aplikace 3D otáčení na tvar:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte [CameraType](https://reference.aspose.com/slides/cs/net/aspose.slides/icamera/cameratype/) a [LightType](https://reference.aspose.com/slides/cs/net/aspose.slides/ilightrig/lighttype/) tvaru pro definování 3D otáčení.
1. Uložte prezentaci.

Následující kód v C# ukazuje, jak aplikovat 3D efekty otáčení na tvar:

```c#
// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Uložte prezentaci jako soubor PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![3D efekt otáčení](3D-rotation-effect.png)

## **Obnovení formátování**

Následující kód v C# ukazuje, jak obnovit formátování snímku a vrátit pozici, velikost a formátování všech tvarů se zástupci na [LayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutslide/) do jejich výchozích nastavení:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Resetujte každý tvar na snímku, který má zástupce v rozvržení.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Pouze minimálně. Vložené obrázky a média zabírají většinu místa v souboru, zatímco parametry tvarů jako barvy, efekty a gradienty jsou uloženy jako metadata a prakticky nepřidávají žádnou extra velikost.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony snímků nebo souboru .POTX. Při tvorbě nové prezentace otevřete šablonu, zkopírujte potřebné stylované tvary a znovu aplikujte jejich formátování kdekoliv je to potřeba.