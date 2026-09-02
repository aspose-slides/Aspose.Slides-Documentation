---
title: Formatera PowerPoint-former i .NET
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/net/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss-effekt
- skiss formlinje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formtransparens
- rotera form
- 3D fasadeffekt
- 3D-rotationseffekt
- återställ formatering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint-former i C# med Aspose.Slides—ställ in fyllning, linje och effektstilar för PPT- och PPTX-filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att modifiera eller applicera effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![formatera-form-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET tillhandahåller gränssnitt och egenskaper som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ange [linjestil](https://reference.aspose.com/slides/sv/net/aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [strecksstil](https://reference.aspose.com/slides/sv/net/aspose.slides/linedashstyle/) för linjen.
1. Ange linjefärgen för formen.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande C#‑kod demonstrerar hur man formaterar en rektangel `AutoShape`:

```c#
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoskiss av typen Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllnadsfärgen för rektangelformen.
    shape.FillFormat.FillType = FillType.NoFill;

    // Applicera formatering på rektangelns linjer.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Ställ in färgen för rektangelns linje.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Spara PPTX-filen till disk.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Applicera skiss‑effekter på formlinjer**

En skisseffekt får en formlinje att se handritad ut. Använd [IShape.LineFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/lineformat/) för att komma åt linjeinställningarna, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ilineformat/sketchformat/) för att komma åt skissinställningarna och [ISketchFormat.SketchType](https://reference.aspose.com/slides/sv/net/aspose.slides/isketchformat/sketchtype/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/sv/net/aspose.slides/linesketchtype/).

Följande C#‑kod visar hur man applicerar en [LineSketchType.Curved](https://reference.aspose.com/slides/sv/net/aspose.slides/linesketchtype/)‑effekt, läser det explicit tilldelade värdet och tar bort effekten med [LineSketchType.None](https://reference.aspose.com/slides/sv/net/aspose.slides/linesketchtype/):

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

Värdet som returneras av `ISketchFormat.SketchType` representerar den inställning som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, en master‑bild eller en layout‑bild, använd [ILineFormat.GetEffective](https://reference.aspose.com/slides/sv/net/aspose.slides/ilineformat/geteffective/), kom åt [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ilineformateffectivedata/sketchformat/) och läs [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/sv/net/aspose.slides/isketchformateffectivedata/sketchtype/). Det effektiva värdet speglar den formatering som faktiskt tillämpas efter ärvning har lösts:

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

## **Formatera anslutningsstilar**

Här är de tre alternativen för anslutningstyp:

* Rund
* Sned
* Avfasning

Som standard använder PowerPoint **Rund** när två linjer förenas i en vinkel (t.ex. i en forms hörn). Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Sned**.

![Anslutningsstilen i presentationen](join-style-powerpoint.png)

Följande C#‑kod demonstrerar hur tre rektanglar (som visas på bilden ovan) skapades med respektive Sned-, Avfasning‑ och Rund‑inställning för anslutningstyp:

```c#
// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till tre autoskissar av typen Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ställ in fyllnadsfärgen för varje rektangelform.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Ställ in linjebredden.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Ställ in färgen för varje rektangels linje.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Ställ in anslutningsstilen.
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

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du applicera två eller flera färger på ett sätt där den ena gradvis tonas ut i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två föredragna färger med definierade positioner med hjälp av `Add`‑metoderna i gradientstopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/igradientformat/).
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande C#‑kod demonstrerar hur du applicerar en gradientfyllning på en ellips:

```c#
// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoskiss av typen Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applicera gradientformatering på ellipsen.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Ställ in gradientens riktning.
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

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera ett tvåfärgs‑mönster – såsom prickar, ränder, korshatch eller schackrutor – på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides tillhandahåller över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra ditt presentations visuella uttryck. Även efter att du valt ett fördefinierat mönster kan du fortfarande specificera exakt vilka färger som ska användas.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ställ in [Background Color](https://reference.aspose.com/slides/sv/net/aspose.slides/ipatternformat/backcolor/) för mönstret.
1. Ställ in [Foreground Color](https://reference.aspose.com/slides/sv/net/aspose.slides/ipatternformat/forecolor/) för mönstret.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande C#‑kod demonstrerar hur du applicerar en mönsterfyllning på en rektangel:

```c#
// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoskiss av typen Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstypen till Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Ställ in mönsterstilen.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Ställ in mönstrets bakgrunds- och förgrundsfärger.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Spara PPTX-filen till disk.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form – effektivt som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Picture`.
1. Ställ in bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)-objekt från den bild du vill använda.
1. Tilldela denna bild till egenskapen `Picture.Image` i formens `PictureFillFormat`.
1. Spara den modifierade presentationen som en PPTX‑fil.

Låt oss säga att vi har filen **lotus.png** med följande bild:

![Lotusbilden](lotus.png)

Följande C#‑kod demonstrerar hur du fyller en form med bilden:

```c#
// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoskiss av typen Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Ställ in fyllningstypen till Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Ställ in bildfyllningsläget.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Läs in en bild och lägg till den i presentationens resurser.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ställ in bilden.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Spara PPTX-filen till disk.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Tile Bild som Textur**

Om du vill ange en kaklad bild som textur och anpassa kaklingsbeteendet kan du använda följande egenskaper i gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/picturefillmode/): Anger bildfyllningsläget – antingen `Tile` eller `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tilealignment/): Anger hur kaklorna positioneras inom formen.
- [TileFlip](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tileflip/): Styr om kaklan vänds horisontellt, vertikalt eller båda.
- [TileOffsetX](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tileoffsetx/): Anger horisontell förskjutning av kaklan (i punkter) från formens ursprung.
- [TileOffsetY](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tileoffsety/): Anger vertikal förskjutning av kaklan (i punkter) från formens ursprung.
- [TileScaleX](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tilescalex/): Definierar horisontell skala för kaklan i procent.
- [TileScaleY](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tilescaley/): Definierar vertikal skala för kaklan i procent.

Följande kodexempel visar hur du lägger till en rektangel med kaklad bildfyllning och konfigurerar kaklingsalternativen:

```c#
// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide firstSlide = presentation.Slides[0];

    // Lägg till en rektangel‑autoskiss.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ställ in fyllningstypen för formen till Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Läs in bilden och lägg till den i presentationens resurser.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Tilldela bilden till formen.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurera bildfyllningsläget och kaklingsegenskaperna.
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

Resultatet:

![Kakelalternativen](tile-options.png)

## **Solid färgfyllning**

I PowerPoint är Solid färgfyllning ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan gradienter, texturer eller mönster.

För att applicera en solid färgfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Solid`.
1. Tilldela din föredragna fyllnadsfärg till formen.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande C#‑kod demonstrerar hur du applicerar en solid färgfyllning på en rektangel i en PowerPoint‑bild:

```c#
// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoskiss av typen Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstypen till Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Ställ in fyllnadsfärgen.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Spara PPTX-filen till disk.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Formen med solid färgfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint kan du, när du applicerar en solid färg, gradient, bild eller textur på former, även ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör att formen blir mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ange transparensnivån genom att justera alfavärdet i den färg som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ange [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Solid`.
1. Använd `Color.FromArgb(alpha, baseColor)` för att definiera en färg med transparens (alfakomponenten styr transparensen).
1. Spara presentationen.

Följande C#‑kod demonstrerar hur du applicerar en transparent fyllningsfärg på en rektangel:

```c#
const int alpha = 128;

// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en solid rektangel autoskiss.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangel autoskiss ovanpå den solida formen.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Spara PPTX-filen till disk.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifik justering eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ange formens `Rotation`‑egenskap till önskad vinkel.
1. Spara presentationen.

Följande C#‑kod demonstrerar hur du roterar en form med 5 grader:

```c#
// Instansiera Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoskiss av typen Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotera formen med 5 grader.
    shape.Rotation = 5;

    // Spara PPTX-filen till disk.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![Formrotationen](shape-rotation.png)

## **Lägg till 3D-fasadeffekter**

Aspose.Slides låter dig applicera 3D‑fasadeffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/)-egenskaper.

För att lägga till 3D‑fasadeffekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/) för att definiera fasadeinställningarna.
1. Spara presentationen.

Följande C#‑kod visar hur du applicerar 3D‑fasadeffekter på en form:

```c#
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

![3D-fasadeffekten](3D-bevel-effect.png)

## **Lägg till 3D-rotationseffekter**

Aspose.Slides låter dig applicera 3D‑rotationseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/)-egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [CameraType](https://reference.aspose.com/slides/sv/net/aspose.slides/icamera/cameratype/) och [LightType](https://reference.aspose.com/slides/sv/net/aspose.slides/ilightrig/lighttype/) för att definiera 3D‑rotationen.
1. Spara presentationen.

Följande C#‑kod demonstrerar hur du applicerar 3D‑rotationseffekter på en form:

```c#
// Skapa en instans av Presentation-klassen.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Spara presentationen som en PPTX-fil.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![3D-rotationseffekten](3D-rotation-effect.png)

## **Återställ formatering**

Följande C#‑kod visar hur du återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutslide/) till deras standardinställningar:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Återställ varje form på bilden som har en platshållare i layouten.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media upptar största delen av filstorleken, medan formparametrar som färger, effekter och gradienter sparas som metadata och bidrar praktiskt taget ingen extra storlek.

**Hur kan jag hitta former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckel‑formateringsegenskaper – fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i ett mall‑bildspel eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de stilar du behöver och återapplicera deras formatering där det behövs.