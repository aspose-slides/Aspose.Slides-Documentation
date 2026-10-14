---
title: Formatera PowerPoint-former i .NET
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/net/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss effekt
- skiss formlinje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formtransparens
- svart-vit formrendering
- gråskala formrendering
- rotera form
- 3D-fasadeffekt
- 3D-roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint-former i C# med Aspose.Slides—ange fyllnings-, linje- och effekstilar för PPT- och PPTX-filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för .NET tillhandahåller gränssnitt och egenskaper som gör att du kan formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) på bilden.
1. Ange [linjestil](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [streckstil](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) för linjen.
1. Ange linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX-fil.

Följande C#-kod visar hur du formaterar en rektangel `AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ange fyllningsfärgen för rektangelformen.
    shape.FillFormat.FillType = FillType.NoFill;

    // Tillämpa formatering på rektangelns linjer.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Ange färgen för rektangelns linje.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Spara PPTX-filen till disk.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Applicera skiss‑effekter på formens linjer**

En skisseffekt får en formlinje att se handritad ut. Använd [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) för att komma åt linjeinställningarna, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) för att komma åt skisseinställningarna och [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Följande C#-kod visar hur du tillämpar en [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/)‑effekt, läser det uttryckligen tilldelade värdet och tar bort effekten med [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

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

Värdet som returneras av `ISketchFormat.SketchType` representerar den inställning som tilldelats direkt till formen. Om linjeformatering kan ärvas från ett tema, en huvudsida eller en layout‑bild, använd [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), få åtkomst till [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) och läs [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Det effektiva värdet speglar den formatering som faktiskt tillämpas efter att arv har lösts:

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

## **Formatera anslutningsstilar**

Här är de tre alternativen för join‑typ:

* Rund
* Snedkant
* Avfasning

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formens hörn), använder den inställningen **Rund**. Men om du ritar en form med skarpa vinklar kan du föredra alternativet **Snedkant**.

![Anslutningsstilen i presentationen](join-style-powerpoint.png)

Följande C#-kod visar hur tre rektanglar (som visas på bilden ovan) skapades med inställningarna Snedkant, Avfasning och Rund för join‑typ:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till tre automatiska former av typen Rektangel.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ange fyllningsfärgen för varje rektangelform.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Ange linjebredden.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Ange färgen för varje rektangels linje.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Ange anslutningsstilen.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Lägg till text i varje rektangel.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Spara PPTX-filen till disk.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig blandning av färger på en form. Till exempel kan du använda två eller fler färger så att den ena gradvis tonar in i den andra.

Så här appliceras en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två önskade färger med definierade positioner med hjälp av `Add`‑metoderna i gradientstopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/).

Spara den ändrade presentationen som en PPTX-fil.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en automatisk form av typen Ellips.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applicera gradientformatering på ellipsen.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Ange gradientens riktning.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Lägg till två gradientstopp.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Spara PPTX-filen till disk.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

Om en gradient ser annorlunda ut i en exporterad bild än i PowerPoint, se [Välj en gradientrenderingsstil](/slides/sv/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en renderingsstil utan att ändra gradientfyllningen som lagras i presentationen.

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign – t.ex. prickar, ränder, korshatch eller rutnät – på en form. Du kan välja anpassade färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra det visuella intrycket i dina presentationer. Även efter att ha valt ett fördefinierat mönster kan du fortfarande ange exakt vilka färger som ska användas.

Så här appliceras en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ange [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) för mönstret.
1. Ange [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) för mönstret.
1. Spara den ändrade presentationen som en PPTX-fil.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ange fyllningstypen till Mönster.
    shape.FillFormat.FillType = FillType.Pattern;

    // Ange mönsterstilen.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Ange mönstrets bakgrunds- och förgrundsfärger.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Spara PPTX-filen till disk.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form – effektivt används bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) till `Picture`.
1. Ange bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)‑objekt från den bild du vill använda.
1. Tilldela denna bild till egenskapen `Picture.Image` i formens `PictureFillFormat`.
1. Spara den ändrade presentationen som en PPTX-fil.

Låt oss säga att vi har en fil "lotus.png" med följande bild:

![Lotusbilden](lotus.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Ange fyllningstypen till Bild.
    shape.FillFormat.FillType = FillType.Picture;

    // Ange bildfyllningsläget.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Läs in en bild och lägg till den i presentationens resurser.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ange bilden.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Spara PPTX-filen till disk.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

![Formen med bildfyllning](picture-fill.png)

### **Tila bild som textur**

Om du vill ange en tiled bild som en textur och anpassa tilningsbeteendet kan du använda följande egenskaper i gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Anger bildfyllningsläget – antingen `Tile` eller `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Anger justeringen av rutorna inom formen.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Styr om rutorna vänds horisontellt, vertikalt eller båda.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Anger den horisontella förskjutningen av rutan (i punkter) från formens ursprung.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Anger den vertikala förskjutningen av rutan (i punkter) från formens ursprung.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definierar den horisontella skalan för rutan som en procentsats.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definierar den vertikala skalan för rutan som en procentsats.

Följande kodexempel visar hur du lägger till en rektangelform med en tiled bildfyllning och konfigurerar tile‑alternativen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide firstSlide = presentation.Slides[0];

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ange fyllningstypen för formen till Bild.
    shape.FillFormat.FillType = FillType.Picture;

    // Läs in bilden och lägg till den i presentationens resurser.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Tilldela bilden till formen.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurera bildfyllningsläget och tilningsegenskaperna.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Spara PPTX-filen till disk.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

![Tile‑alternativen](tile-options.png)

## **Solid färgfyllning**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en solid färgfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) till `Solid`.
1. Tilldela den önskade fyllningsfärgen till formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ange fyllningstypen till Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Ange fyllningsfärgen.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Spara PPTX-filen till disk.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

![Formen med solid färgfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en solid färg, gradient, bild eller texturfyllning på former, kan du även ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ange transparensnivån genom att justera alfavärdet i färgen som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) på bilden.
1. Ange [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) till `Solid`.
1. Använd `Color.FromArgb(alpha, baseColor)` för att definiera en färg med transparens (komponenten `alpha` styr transparensen).
1. Spara presentationen.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en solid rektangel automatisk form.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangel automatisk form ovanpå den solida formen.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Spara PPTX-filen till disk.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifik justering eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens `Rotation`‑egenskap till önskad vinkel.
1. Spara presentationen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotera formen med 5 grader.
    shape.Rotation = 5;

    // Spara PPTX-filen till disk.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

![Formroteringen](shape-rotation.png)

## **Lägg till 3D‑fasadeffekter**

Aspose.Slides låter dig applicera 3D‑fasadeffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/)‑egenskaper.

För att lägga till 3D‑fasadeffekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) för att definiera fasadegenskaper.
1. Spara presentationen.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Skapa en instans av Presentation-klassen.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Lägg till en form på bilden.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Ange formens ThreeDFormat-egenskaper.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Spara presentationen som en PPTX-fil.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

![3D‑fasadeffekten](3D-bevel-effect.png)

## **Lägg till 3D‑rotationseffekter**

Aspose.Slides låter dig applicera 3D‑rotationseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/)‑egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) och [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) för att definiera 3D‑rotationen.
1. Spara presentationen.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Skapa en instans av Presentation-klassen.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Spara presentationen som en PPTX-fil.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

![3D‑rotations effekten](3D-rotation-effect.png)

## **Styr svart‑vit rendering för former**

Egenskapen [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) anger hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vit läge. Den aktiverar inte svart‑vit visning i sig, och den ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från uppräkningen [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konverteringen, `Gray` och `LightGray` använder grå färgning, `BlackWhite` använder endast svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning, och `Hidden` utesluter formen i svart‑vit läge. `NotDefined` betyder att inget form‑nivå läge är tilldelat.

Följande C#‑kod skapar en färgad form och får den att visas grå i svart‑vit visningsläge:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett svart‑vit arbetsflöde använder den grå färgning eftersom dess läge är satt till `Gray`. Detta låter dig bevara en färgrik bildruta samtidigt som du definierar ett distinkt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vita visningsinställningar.

## **Återställ formatering**

Följande C#‑kod visar hur du återställer en bilds formatering och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) till deras standardinställningar:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Återställ varje form på bilden som har en platshållare på layouten.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Påverkar formatering av former den slutgiltiga filstorleken på presentationen?**

Endast marginellt. Inbäddade bilder och media upptar största delen av filstorleken, medan formparametrar såsom färger, effekter och gradienter lagras som metadata och tillför praktiskt taget ingen extra storlek.

**Hur kan jag identifiera former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformateringsegenskaper – fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mallpresentation eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de formaterade former du behöver och återapplicera deras formatering där det behövs.