---
title: Formatera PowerPoint-former i .NET
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/net/shape-formatting/
keywords:
- formatera form
- formatera linje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgs fyllning
- formtransparens
- rotera form
- 3d-fas effekt
- 3d-rotations effekt
- återställ formatering
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint-former i C# med Aspose.Slides—ange fyllnings-, linje- och effektsstil för PPT- och PPTX-filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras innermaterial fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för .NET tillhandahåller gränssnitt och egenskaper som gör att du kan formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in [line style](https://reference.aspose.com/slides/sv/net/aspose.slides/linestyle/) för formen.
1. Ställ in linjebredden.
1. Ställ in [dash style](https://reference.aspose.com/slides/sv/net/aspose.slides/linedashstyle/) för linjen.
1. Ställ in linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX-fil.

Följande C#-kod demonstrerar hur du formaterar en rektangel-`AutoShape`:

```c#
 // Skapa en instans av Presentation-klassen som representerar en presentationsfil.
 using (Presentation presentation = new Presentation())
 {
     // Hämta den första bilden.
     ISlide slide = presentation.Slides[0];

     // Lägg till en autoform av typen Rectangle.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Formatera anslutningsstilar**

Här är de tre alternativ för anslutningstyper:

* Round
* Miter
* Bevel

Som standard använder PowerPoint **Round**-inställningen när två linjer förenas i en vinkel (t.ex. i en forms hörn). Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Följande C#-kod demonstrerar hur tre rektanglar (som visas på bilden ovan) skapades med Miter-, Bevel- och Round-anslutningsinställningarna:

```c#
 // Skapa en instans av Presentation-klassen som representerar en presentationsfil.
 using (Presentation presentation = new Presentation())
 {
     // Hämta den första bilden.
     ISlide slide = presentation.Slides[0];

     // Lägg till tre autosformer av typen Rectangle.
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

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du applicera två eller flera färger på ett sätt där den ena gradvis tonas ut i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två föredragna färger med definierade positioner med hjälp av `Add`-metoderna i gradientstopp-samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/igradientformat/).
1. Spara den ändrade presentationen som en PPTX-fil.

Följande C#-kod demonstrerar hur du applicerar en gradientfyllning på en ellips:

```c#
 // Skapa en instans av Presentation-klassen som representerar en presentationsfil.
 using (Presentation presentation = new Presentation())
 {
     // Hämta den första bilden.
     ISlide slide = presentation.Slides[0];

     // Lägg till en autoform av typen Ellipse.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

     // Tillämpa gradientformatering på ellipsen.
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

![The ellipse with gradient fill](gradient-fill.png)

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera ett tvåfärgsdesign-mönster—såsom prickar, ränder, korsstreck eller rutnät—på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra det visuella intrycket av dina presentationer. Även efter att ha valt ett fördefinierat mönster kan du fortfarande ange exakt vilka färger som ska användas.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ställ in [Background Color](https://reference.aspose.com/slides/sv/net/aspose.slides/ipatternformat/backcolor/) för mönstret.
1. Ställ in [Foreground Color](https://reference.aspose.com/slides/sv/net/aspose.slides/ipatternformat/forecolor/) för mönstret.
1. Spara den ändrade presentationen som en PPTX-fil.

Följande C#-kod demonstrerar hur du applicerar en mönsterfyllning på en rektangel:

```c#
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoform av typen Rectangle.
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

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form—effektivt använder bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Picture`.
1. Ställ in bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/)-objekt från den bild du vill använda.
1. Tilldela denna bild till egenskapen `Picture.Image` i formens `PictureFillFormat`.
1. Spara den ändrade presentationen som en PPTX-fil.

Låt oss säga att vi har en fil named "lotus.png" med följande bild:

![The lotus picture](lotus.png)

Följande C#-kod demonstrerar hur du fyller en form med bilden:

```c#
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoform av typen Rectangle.
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

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Om du vill ange en brickad bild som textur och anpassa brickningsbeteendet kan du använda följande egenskaper i gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/picturefillmode/): Anger bildfyllningsläget—antingen `Tile` eller `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tilealignment/): Specificerar brickornas justering inom formen.
- [TileFlip](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tileflip/): Styr om brickan vänds horisontellt, vertikalt eller båda.
- [TileOffsetX](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tileoffsetx/): Anger den horisontella offseten för brickan (i punkter) från formens ursprung.
- [TileOffsetY](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tileoffsety/): Anger den vertikala offseten för brickan (i punkter) från formens ursprung.
- [TileScaleX](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tilescalex/): Definierar den horisontella skalan för brickan i procent.
- [TileScaleY](https://reference.aspose.com/slides/sv/net/aspose.slides/ipicturefillformat/tilescaley/): Definierar den vertikala skalan för brickan i procent.

Följande kodexempel visar hur du lägger till en rektangulär form med en brickad bildfyllning och konfigurerar brickalternativen:

```c#
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide firstSlide = presentation.Slides[0];

    // Lägg till en rektangel autoform.
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

    // Konfigurera bildfyllningsläget och brickningsegenskaperna.
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

![The tile options](tile-options.png)

## **Enfärgs fyllning**

I PowerPoint är Enfärgs fyllning ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en enfärgs fyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Solid`.
1. Tilldela din föredragna fyllningsfärg till formen.
1. Spara den ändrade presentationen som en PPTX-fil.

Följande C#-kod demonstrerar hur du applicerar en enfärgs fyllning på en rektangel i en PowerPoint-bild:

```c#
 // Skapa en instans av Presentation-klassen som representerar en presentationsfil.
 using (Presentation presentation = new Presentation())
 {
     // Hämta den första bilden.
     ISlide slide = presentation.Slides[0];

     // Lägg till en autoform av typen Rectangle.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

     // Ställ in fyllningstypen till Solid.
     shape.FillFormat.FillType = FillType.Solid;

     // Ställ in fyllningsfärgen.
     shape.FillFormat.SolidFillColor.Color = Color.Yellow;

     // Spara PPTX-filen till disk.
     presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
 }
```

Resultatet:

![The shape with solid color fill](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en enfärgs-, gradient-, bild- eller texturfyllning på former, kan du också ange en transparensnivå för att kontrollera fyllningens ogenomskinlighet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ange transparensnivån genom att justera alfavärdet i den färg som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in [FillType](https://reference.aspose.com/slides/sv/net/aspose.slides/filltype/) till `Solid`.
1. Använd `Color.FromArgb(alpha, baseColor)` för att definiera en färg med transparens (alfakomponenten styr transparensen).
1. Spara presentationen.

Följande C#-kod demonstrerar hur du applicerar en transparent fyllningsfärg på en rektangel:

```c#
const int alpha = 128;

// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en solid rektangel autoform.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangel autoform ovanpå den solida formen.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Spara PPTX-filen till disk.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The transparent shape](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint-presentationer. Detta kan vara användbart när du placerar visuella element med specifik justering eller designkrav.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens `Rotation`-egenskap till önskad vinkel.
1. Spara presentationen.

Följande C#-kod demonstrerar hur du roterar en form med 5 grader:

```c#
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
using (Presentation presentation = new Presentation())
{
    // Hämta den första bilden.
    ISlide slide = presentation.Slides[0];

    // Lägg till en autoform av typen Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotera formen med 5 grader.
    shape.Rotation = 5;

    // Spara PPTX-filen till disk.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Resultatet:

![The shape rotation](shape-rotation.png)

## **Lägg till 3D-fasadeffekter**

Aspose.Slides låter dig applicera 3D-fasadeffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/)-egenskaper.

För att lägga till 3D-fasadeffekter på en form, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/) för att definiera fasainställningarna.
1. Spara presentationen.

Följande C#-kod visar hur du applicerar 3D-fasadeffekter på en form:

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

![The 3D bevel effect](3D-bevel-effect.png)

## **Lägg till 3D-roteringseffekter**

Aspose.Slides låter dig applicera 3D-roteringseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/threedformat/)-egenskaper.

För att applicera 3D-rotering på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [CameraType](https://reference.aspose.com/slides/sv/net/aspose.slides/icamera/cameratype/) och [LightType](https://reference.aspose.com/slides/sv/net/aspose.slides/ilightrig/lighttype/) för att definiera 3D-rotationen.
1. Spara presentationen.

Följande C#-kod demonstrerar hur du applicerar 3D-roteringseffekter på en form:

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

![The 3D rotation effect](3D-rotation-effect.png)

## **Återställ formatering**

Följande C#-kod visar hur du återställer formateringen av en bild och återställer position, storlek och formatering av alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutslide/) till deras standardinställningar:

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

## **FAQ**

**Påverkar formatering av former den slutgiltiga presentationsfilens storlek?**

Endast minimalt. Inbäddade bilder och media upptar största delen av filutrymmet, medan formparametrar såsom färger, effekter och gradienter lagras som metadata och lägger i princip ingen extra storlek.

**Hur kan jag identifiera former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings-egenskaper—fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, betrakta deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall-bildsamling eller en .POTX-mallfil. När du skapar en ny presentation, öppna mallen, klona de stilade formerna du behöver, och tillämpa deras formatering där det behövs.