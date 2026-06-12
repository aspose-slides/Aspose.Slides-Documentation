---
title: Formátování tvarů PowerPointu v .NET
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/net/shape-formatting/
keywords:
- formátovat tvar
- formátovat čáru
- formátovat styl spojení
- gradientní výplň
- výplň vzorem
- výplň obrázkem
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- otočit tvar
- 3D efekt zkosení
- 3D otáčecí efekt
- obnovit formátování
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v C# pomocí Aspose.Slides — nastavte výplně, čáry a styly efektů pro soubory PPT a PPTX s přesností a plnou kontrolou."
---
## **Úvod**

V aplikaci PowerPoint můžete do snímků přidávat tvary. Protože tvary jsou složeny z čar, můžete je formátovat úpravou nebo aplikací efektů na jejich obrysy. Navíc můžete tvary formátovat zadáním nastavení, která řídí, jak jsou jejich výplně vyplněny.

![formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro .NET poskytuje rozhraní a vlastnosti, které vám umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Pomocí Aspose.Slides můžete pro tvar zadat vlastní styl čáry. Následující kroky popisují postup:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte [styl čáry](https://reference.aspose.com/slides/cs/net/aspose.slides/linestyle/) tvaru.
1. Nastavte šířku čáry.
1. Nastavte [styl čárkování](https://reference.aspose.com/slides/cs/net/aspose.slides/linedashstyle/) čáry.
1. Nastavte barvu čáry pro tvar.
1. Uložte upravenou prezentaci jako soubor PPTX.

Následující kód v C# ukazuje, jak naformátovat obdélníkový `AutoShape`:

```c#
// Vytvořte instance třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Rectangle.
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

## **Formátování typů spojení**

Zde jsou tři možnosti typu spojení:

* Zaoblený
* Hrotový
* Zkosený

Ve výchozím nastavení PowerPoint při spojování dvou čar pod úhlem (například v rohu tvaru) použije nastavení **Zaoblený**. Pokud však kreslíte tvar s ostrými úhly, můžete upřednostnit možnost **Hrotový**.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Následující kód v C# ukazuje, jak byly tři obdélníky (jak je vidět na obrázku výše) vytvořeny pomocí nastavení typů spojení Hrotový, Zkosený a Zaoblený:

```c#
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

## **Gradientní výplň**

V PowerPointu je Gradientní výplň formátovací možností, která vám umožňuje použít plynulé přechody barev na tvar. Například můžete použít dvě nebo více barev tak, že se jedna postupně mísí s druhou.

Zde je postup, jak aplikovat gradientní výplň na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Gradient`.
1. Přidejte své dvě preferované barvy s definovanými pozicemi pomocí metod `Add` ze sbírky gradientových zastávek, kterou poskytuje rozhraní [IGradientFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/igradientformat/).

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplikujte gradientní formátování na elipsu.
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

## **Výplň vzorem**

V PowerPointu je Výplň vzorem formátovací možností, která vám umožňuje aplikovat dvoubarevný design – například tečky, pruhy, křížové šrafování nebo šachovnici – na tvar. Můžete zvolit vlastní barvy pro popředí a pozadí vzoru.

Aspose.Slides nabízí více než 45 předdefinovaných stylů vzorů, které můžete použít na tvary pro zvýšení vizuální atraktivity vašich prezentací. I po výběru předdefinovaného vzoru můžete stále určit přesné barvy, které má použít.

Zde je postup, jak aplikovat výplň vzorem na tvar pomocí Aspose.Slides:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Pattern`.
1. Vyberte styl vzoru z předdefinovaných možností.
1. Nastavte [Background Color](https://reference.aspose.com/slides/cs/net/aspose.slides/ipatternformat/backcolor/) vzoru.
1. Nastavte [Foreground Color](https://reference.aspose.com/slides/cs/net/aspose.slides/ipatternformat/forecolor/) vzoru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```c#
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

Výsledek:

![Obdélník s výplní vzorem](pattern-fill.png)

## **Výplň obrázkem**

V PowerPointu je Výplň obrázkem formátovací možností, která vám umožňuje vložit obrázek do tvaru – efektivně používá obrázek jako pozadí tvaru.

Zde je návod, jak použít Aspose.Slides k aplikaci výplně obrázkem na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Picture`.
1. Nastavte režim výplně obrázkem na `Tile` (nebo jiný preferovaný režim).
1. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) ze souboru obrázku, který chcete použít.
1. Přiřaďte tento obrázek k vlastnosti `Picture.Image` formátu `PictureFillFormat` tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Předpokládejme, že máme soubor "lotus.png" s následujícím obrázkem:

![Obrázek lotusu](lotus.png)

Následující kód v C# ukazuje, jak vyplnit tvar obrázkem:

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický tvar typu Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Nastavte typ výplně na Picture.
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

![Tvar s výplní obrázkem](picture-fill.png)

### **Dlaždicový obrázek jako textura**

Pokud chcete nastavit obrázek jako dlaždice a použít jej jako texturu a přizpůsobit chování dlaždic, můžete použít následující vlastnosti rozhraní [IPictureFillFormat] a třídy [PictureFillFormat]:

- [PictureFillMode](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/picturefillmode/): Nastavuje režim výplně obrázkem – buď `Tile`, nebo `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tilealignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [TileFlip](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tileflip/): Ovládá, zda je dlaždice překlopena vodorovně, svisle nebo obojí.
- [TileOffsetX](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tileoffsetx/): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [TileOffsetY](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tileoffsety/): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [TileScaleX](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tilescalex/): Definuje vodorovné měřítko dlaždice v procentech.
- [TileScaleY](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/tilescaley/): Definuje svislé měřítko dlaždice v procentech.

Následující ukázka kódu ukazuje, jak přidat obdélníkový tvar s výplní obrázkem jako dlaždice a nastavit možnosti dlaždic:

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide firstSlide = presentation.Slides[0];

    // Přidejte automatický obdélníkový tvar.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Nastavte typ výplně tvaru na Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Načtěte obrázek a přidejte jej do zdrojů prezentace.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Přiřaďte obrázek k tvaru.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Nakonfigurujte režim výplně obrázkem a vlastnosti dlaždicování.
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

![Možnosti dlaždic](tile-options.png)

## **Jednobarevná výplň**

V PowerPointu je Jednobarevná výplň formátovací možností, která vyplní tvar jednou, jednotnou barvou. Tato jednobarevná barva pozadí se použije bez gradientů, textur ani vzorů.

Pro aplikaci jednobarevné výplně na tvar pomocí Aspose.Slides postupujte následovně:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte tvaru [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Solid`.
1. Přiřaďte požadovanou barvu výplně tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```c#
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

Výsledek:

![Tvar s jednobarevnou výplní](solid-color-fill.png)

## **Nastavení průhlednosti**

V PowerPointu, když použijete jednobarevnou, gradientní, obrázkovou nebo texturovou výplň na tvary, můžete také nastavit úroveň průhlednosti, která řídí neprůhlednost výplně. Vyšší hodnota průhlednosti způsobí, že tvar bude více průhledný, což umožní částečnou viditelnost pozadí nebo podkladových objektů.

Aspose.Slides vám umožňuje nastavit úroveň průhlednosti úpravou alfa komponenty barvy použité pro výplň. Zde je postup:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Solid`.
1. Použijte `Color.FromArgb(alpha, baseColor)` k definování barvy s průhledností (komponenta `alpha` řídí průhlednost).
1. Uložte prezentaci.

```c#
const int alpha = 128;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte automatický obdélníkový tvar s plnou výplní.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Přidejte transparentní obdélníkový automatický tvar nad plný tvar.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Uložte soubor PPTX na disk.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otočení tvarů**

Aspose.Slides vám umožňuje otáčet tvary v prezentacích PowerPoint. To může být užitečné při umísťování vizuálních prvků s konkrétními potřebami zarovnání nebo designu.

Pro otočení tvaru na snímku postupujte následovně:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte vlastnost `Rotation` tvaru na požadovaný úhel.
1. Uložte prezentaci.

```c#
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

Výsledek:

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D zkosených efektů**

Aspose.Slides vám umožňuje aplikovat 3D zkosené efekty na tvary konfigurací jejich vlastností [ThreeDFormat].

Pro přidání 3D zkosených efektů na tvar postupujte následovně:

1. Instancujte třídu [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte [ThreeDFormat] tvaru pro definování nastavení zkosení.
1. Uložte prezentaci.

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

![3D zkosený efekt](3D-bevel-effect.png)

## **Přidání 3D otáčecích efektů**

Aspose.Slides vám umožňuje aplikovat 3D otáčecí efekty na tvary konfigurací jejich vlastností [ThreeDFormat].

Pro aplikaci 3D otočení na tvar:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte do snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
1. Nastavte [CameraType] a [LightType] tvaru pro definování 3D otáčení.
1. Uložte prezentaci.

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

![3D otáčecí efekt](3D-rotation-effect.png)

## **Obnovení formátování**

Následující kód v C# ukazuje, jak obnovit formátování snímku a vrátit pozici, velikost a formátování všech tvarů s zástupci na [LayoutSlide] na jejich výchozí nastavení:

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

Pouze nepatrně. Vložené obrázky a média zabírají většinu prostoru souboru, zatímco parametry tvarů, jako jsou barvy, efekty a gradienty, jsou uloženy jako metadata a téměř nepřidávají žádnou další velikost.

**Jak mohu na snímku detekovat tvary, které mají stejný formát, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – nastavení výplně, čáry a efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky seskupte tyto tvary, což usnadní pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte vzorové tvary s požadovanými styly do šablony sady snímků nebo do souboru šablony .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu použijte jejich formátování kdekoliv je to potřeba.