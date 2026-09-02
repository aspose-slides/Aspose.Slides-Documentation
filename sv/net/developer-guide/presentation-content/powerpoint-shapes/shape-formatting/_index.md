---
title: Formatera PowerPoint‑former i .NET
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/net/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss‑effekt
- skissa formlinje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solidfärgsfyllning
- formtransparens
- svart‑vit formrendering
- gråskala formrendering
- rotera form
- 3d‑förskärningseffekt
- 3d‑rotationseffekt
- återställ formatering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i C# med Aspose.Slides—sätt fyllnings‑, linje‑ och effektstilar för PPT‑ och PPTX‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras innerväggar fylls.

![formatering-av-form-i-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET tillhandahåller gränssnitt och egenskaper som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in [linjestilen](https://reference.aspose.com/slides/sv/net/aspose.slides/linestyle/) för formen.
1. Ställ in linjebredden.
1. Ställ in [streckstilen](https://reference.aspose.com/slides/sv/net/aspose.slides/linedashstyle/) för linjen.
1. Ställ in linjefärgen för formen.
1. Spara den modifierade presentationen som en PPTX-fil.

Följande C#-kod demonstrerar hur man formaterar en rektangel‑`AutoShape`:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ange fyllningsfärgen för rektangelformen.
    shape.FillFormat.FillType = FillType.NoFill;

    // Applicera formatering på rektangelns linjer.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Ange färgen för rektangelns linje.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Spara PPTX‑filen till disken.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Tillämpa skiss‑effekter på formlinjer**

En skiss‑effekt får en formlinje att se handritad ut. Använd [IShape.LineFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/lineformat/) för att komma åt linjeinställningarna, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ilineformat/sketchformat/) för att komma åt skiss‑inställningarna och [ISketchFormat.SketchType](https://reference.aspose.com/slides/sv/net/aspose.slides/isketchformat/sketchtype/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/sv/net/aspose.slides/linesketchtype/).

Följande C#‑kod visar hur man tillämpar en [LineSketchType.Curved](https://reference.aspose.com/slides/sv/net/aspose.slides/linesketchtype/)‑effekt, läser det uttryckligen tilldelade värdet och tar bort effekten med [LineSketchType.None](https://reference.aspose.com/slides/sv/net/aspose.slides/linesketchtype/):

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

Värdet som returneras av `ISketchFormat.SketchType` representerar inställningen som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, en masternavigering eller en layout‑bild, använd [ILineFormat.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/ilineformat/geteffective/), kom åt [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ilineformateffectivedata/sketchformat/) och läs [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/sv/net/aspose.slides/isketchformateffectivedata/sketchtype/). Det effektiva värdet speglar den formatering som faktiskt tillämpas efter att arv har lösts:

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

Här är de tre alternativ för anslutningstyp:

* Round
* Miter
* Bevel

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formas hörn), använder den **Round**‑inställningen. Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Miter**.

![Anslutningsstilen i presentationen](join-style-powerpoint.png)

Följande C#‑kod demonstrerar hur tre rektanglar (som visas i bilden ovan) skapades med Miter‑, Bevel‑ och Round‑anslutningsinställningarna:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till tre autoshapes av typen Rektangel.
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

    // Spara PPTX‑filen till disken.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du applicera två eller fler färger så att den ena gradvis tonas in i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två föredragna färger med definierade positioner med hjälp av `Add`‑metoderna i gradientstopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/igradientformat/).
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande C#‑kod demonstrerar hur man applicerar en gradientfyllningseffekt på en ellips:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoshape av typen Ellips.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Tillämpa gradientformatering på ellipsen.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Ställ in gradientens riktning.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Lägg till två gradientstopp.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Spara PPTX-filen till disken.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera ett tvåfärgs‑mönster—t.ex. prickar, ränder, korshatching eller schackrutor—på en form. Du kan välja anpassade färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra presentationens visuella intryck. Även efter att du har valt ett fördefinierat mönster kan du specificera exakt vilka färger som ska användas.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ställ in [Background Color](https://reference.aspose.com/slides/sv/net/aspose.slides/ipatternformat/backcolor/) för mönstret.
1. Ställ in [Foreground Color](https://reference.aspose.com/slides/sv/net/aspose.slides/ipatternformat/forecolor/) för mönstret.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande C#‑kod demonstrerar hur man applicerar en mönsterfyllning på en rektangel:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstyp till Mönster.
    shape.FillFormat.FillType = FillType.Pattern;

    // Ställ in mönsterstil.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Ställ in mönstrets bakgrunds- och förgrundsfärger.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Spara PPTX-filen till disken.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form—effektivt använda bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Picture`.
1. Ställ in bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)‑objekt från den bild du vill använda.
1. Tilldela denna bild till egenskapen `Picture.Image` i formens `PictureFillFormat`.
1. Spara den modifierade presentationen som en PPTX‑fil.

Låt oss anta att vi har en fil “lotus.png” med följande bild:

![Lotusbilden](lotus.png)

Följande C#‑kod demonstrerar hur man fyller en form med bilden:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Ställ in fyllningstyp till Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Ställ in bildfyllningsläge.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Läs in en bild och lägg till den i presentationens resurser.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ställ in bilden.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Spara PPTX-filen till disken.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Tile-bild som textur**

Om du vill ange en plattad bild som textur och anpassa plattningsbeteendet kan du använda följande egenskaper i gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/picturefillmode/): Ställer in bildens fyllningsläge—antingen `Tile` eller `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tilealignment/): Anger justeringen av plattorna inom formen.
- [TileFlip](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tileflip/): Styr om plattan vänds horisontellt, vertikalt eller både och.
- [TileOffsetX](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tileoffsetx/): Ställer in den horisontella förskjutningen av plattan (i punkter) från formens ursprung.
- [TileOffsetY](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tileoffsety/): Ställer in den vertikala förskjutningen av plattan (i punkter) från formens ursprung.
- [TileScaleX](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tilescalex/): Definierar den horisontella skalan av plattan i procent.
- [TileScaleY](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tilescaley/): Definierar den vertikala skalan av plattan i procent.

Följande kodexempel visar hur man lägger till en rektangulär form med plattad bildfyllning och konfigurerar tile‑alternativen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide firstSlide = presentation.Slides[0];

    // Lägg till en rektangel‑autoshape.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ställ in fyllningstyp för formen till Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Läs in bilden och lägg till den i presentationens resurser.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Tilldela bilden till formen.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurera bildfyllningsläget och plattningsegenskaperna.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Spara PPTX-filen till disken.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Tile-alternativen](tile-options.png)

## **Solidfärgsfyllning**

I PowerPoint är Solidfärgsfyllning ett formateringsalternativ som fyller en form med en enda, jämn färg. Denna enkla bakgrundsfärg appliceras utan gradienter, texturer eller mönster.

För att applicera en solidfärgsfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Solid`.
1. Tilldela din föredragna fyllningsfärg till formen.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande C#‑kod demonstrerar hur man applicerar en solidfärgsfyllning på en rektangel i en PowerPoint‑bild:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstyp till Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Ställ in fyllningsfärgen.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Spara PPTX-filen till disken.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Formen med solid färgfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en solid färg, gradient, bild eller texturfyllning på former, kan du också ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ställa in transparensnivån genom att justera alfa‑värdet i den färg som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Solid`.
1. Använd `Color.FromArgb(alpha, baseColor)` för att definiera en färg med transparens (komponenten `alpha` styr transparensen).
1. Spara presentationen.

Följande C#‑kod demonstrerar hur man applicerar en transparent fyllningsfärg på en rektangel:

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

    // Lägg till en solid rektangel‑autoshape.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangel‑autoshape ovanpå den solida formen.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Spara PPTX-filen till disken.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifik justering eller designkrav.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens `Rotation`‑egenskap till önskad vinkel.
1. Spara presentationen.

Följande C#‑kod demonstrerar hur man roterar en form med 5 grader:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotera formen med 5 grader.
    shape.Rotation = 5;

    // Spara PPTX-filen till disken.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Formrotationen](shape-rotation.png)

## **Lägg till 3D-förskärningseffekter**

Aspose.Slides gör det möjligt att applicera 3D‑förskärningseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/)-egenskaper.

För att lägga till 3D‑förskärningseffekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/) för att definiera förskärningsinställningarna.
1. Spara presentationen.

Följande C#‑kod visar hur man applicerar 3D‑förskärningseffekter på en form:

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

    // Ställ in formens ThreeDFormat-egenskaper.
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

Resultatet:

![3D‑förskärningseffekten](3D-bevel-effect.png)

## **Lägg till 3D-rotations‑effekter**

Aspose.Slides gör det möjligt att applicera 3D‑rotationseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/)-egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till ett [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [CameraType](https://reference.aspose.com/slides/sv/net/aspose.slides/icamera/cameratype/) och [LightType](https://reference.aspose.com/slides/sv/net/aspose.slides/ilightrig/lighttype/) för att definiera 3D‑rotationen.
1. Spara presentationen.

Följande C#‑kod demonstrerar hur man applicerar 3D‑rotationseffekter på en form:

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

Resultatet:

![3D‑rotationseffekten](3D-rotation-effect.png)

## **Styr svart‑vit rendering för former**

[Egenskapen IShape.BlackWhiteMode](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/blackwhitemode/) specificerar hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vit läge. Den möjliggör inte svart‑vit visning i sig och ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från uppräkningen [BlackWhiteMode](https://reference.aspose.com/slides/sv/net/aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konverteringen, `Gray` och `LightGray` använder grå färgning, `BlackWhite` använder endast svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning, och `Hidden` utesluter formen i svart‑vit läge. `NotDefined` betyder att inget form‑specifikt läge är tilldelat.

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

// Behåll den orange fyllnaden i färgläge, men rendera formen med grå färgning i svart-vitt läge.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett arbetsflöde med svart‑vit visning använder den grå färgning eftersom dess läge är satt till `Gray`. Detta låter dig bevara en färgrik bild medan du definierar ett särskilt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vita visningsinställningar.

## **Återställ formatering**

Följande C#‑kod visar hur man återställer formateringen av en bild och återställer position, storlek och formatering av alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutslide/) till deras standardinställningar:

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

**Påverkar formatering av former den slutliga presentationens filstorlek?**

Endast marginellt. Inbäddade bilder och media upptar det mesta av filutrymmet, medan formparametrar som färger, effekter och gradienter lagras som metadata och lägger i praktiken till ingen extra storlek.

**Hur kan jag identifiera former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings‑egenskaper—fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i ett mall‑presentationspaket eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de stylade former du behöver och återapplicera deras formatering där det krävs.