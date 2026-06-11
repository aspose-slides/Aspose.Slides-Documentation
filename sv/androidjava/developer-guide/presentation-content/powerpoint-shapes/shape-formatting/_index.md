---
title: Formatera PowerPoint-former på Android
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/androidjava/shape-formatting/
keywords:
- formatera form
- formatera linje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formtransparens
- rotera form
- 3D-fastringseffekt
- 3D-rotationseffekt
- återställ formatering
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint-former på Android med Aspose.Slides—ställ in fyllnings-, linje- och effektstilar för PPT-, PPTX- och ODP-filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för Android via Java tillhandahåller gränssnitt och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till en bild (slide) med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange [line style](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [dash style](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/linedashstyle/) för linjen.
1. Ange linjefärgen för formen.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande kod visar hur man formaterar en rektangel `AutoShape`:

```java
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Ange fyllningsfärgen för rektangelformen.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Applicera formatering på rektangelns linjer.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ange färgen för rektangelns linje.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Spara PPTX-filen till disk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Formatera anslutningsstilar**

Här är de tre alternativen för anslutningstyp:

* Rund
* Fas
* Avfasning

Standardmässigt, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formens hörn), använder den inställningen **Rund**. Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Fas**.

![Anslutningsstilen i presentationen](join-style-powerpoint.png)

Följande Java‑kod visar hur tre rektanglar (som visas på bilden ovan) skapades med inställningarna Fas, Avfasning och Rund för anslutningstyp:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till tre automatiska former av typen Rektangel.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ange fyllningsfärgen för varje rektangelform.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Ange linjebredden.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ange färgen för varje rektangels linje.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Ange anslutningsstilen.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Lägg till text i varje rektangel.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Spara PPTX-filen till disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Du kan exempelvis använda två eller flera färger så att den ena gradvis tonas ner i den andra.

Så här appliceras en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till en bild (slide) med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två föredragna färger med definierade positioner med hjälp av `add`‑metoderna i gradientstopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/igradientformat/).
1. Spara den modifierade presentationen som en PPTX‑fil.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Ellips.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applicera gradientformatering på ellipsen.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ange gradientens riktning.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Lägg till två gradientstopp.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Spara PPTX-filen till disk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera ett tvåfärgsdesign—t.ex. prickar, ränder, korsstreck eller rutmönster—på en form. Du kan välja anpassade färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder mer än 45 fördefinierade mönsterstilar som du kan använda på former för att förbättra den visuella attraktionskraften i dina presentationer. Även efter att du har valt ett fördefinierat mönster kan du fortfarande ange exakt vilka färger som ska användas.

Så här appliceras en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till en bild (slide) med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ange [Background Color](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/patternformat/#getBackColor--) för mönstret.
1. Ange [Foreground Color](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/patternformat/#getForeColor--) för mönstret.
1. Spara den modifierade presentationen som en PPTX‑fil.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ange fyllningstypen till Mönster.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ange mönsterstilen.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ange mönstrets bakgrunds- och förgrundsfärger.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Spara PPTX-filen till disk.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form—effektivt använda bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till en bild (slide) med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) till `Picture`.
1. Ange bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/)‑objekt från bilden du vill använda.
1. Skicka bilden till metoden `ISlidesPicture.setImage`.
1. Spara den modifierade presentationen som en PPTX‑fil.

Låt oss säga att vi har en fil "lotus.png" med följande bild:

![Lotus‑bilden](lotus.png)

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ange fyllningstypen till Bild.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ange bildfyllningsläget.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Läs in en bild och lägg till den i presentationens resurser.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ange bilden.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Spara PPTX-filen till disk.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Tila bild som textur**

Om du vill sätta en tilad bild som textur och anpassa plattningsbeteendet kan du använda följande metoder från gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ställer in bildfyllningsläget—antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Anger justeringen av plattorna inom formen.
- [setTileFlip](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kontrollerar om plattan vänds horisontellt, vertikalt eller båda.
- [setTileOffsetX](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ställer in den horisontella förskjutningen av plattan (i punkter) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ställer in den vertikala förskjutningen av plattan (i punkter) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definierar den horisontella skalan av plattan som en procentandel.
- [setTileScaleY](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definierar den vertikala skalan av plattan som en procentandel.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk rektangelform.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ange fyllningstypen för formen till Bild.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Läs in bilden och lägg till den i presentationens resurser.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tilldela bilden till formen.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurera bildfyllningsläget och plattningsegenskaperna.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Spara PPTX-filen till disk.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Plattalternativen](tile-options.png)

## **Solid färgfyllning**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

Så här applicerar du en solid färgfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till en bild (slide) med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) till `Solid`.
1. Tilldela din föredragna fyllningsfärg till formen.
1. Spara den modifierade presentationen som en PPTX‑fil.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ange fyllningstypen till Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Ange fyllningsfärgen.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Spara PPTX-filen till disk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Formen med solid färgfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en solid färg, gradient, bild eller texturfyllning på former, kan du också sätta en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig sätta transparensnivån genom att justera alfavärdet i färgen som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till en bild (slide) med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange [FillType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (alfakomponenten styr transparensen).
1. Spara presentationen.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en solid rektangulär automatisk form.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangulär automatisk form ovanpå den solida formen.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Spara PPTX-filen till disk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifika justeringar eller designbehov.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till en bild (slide) med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange formens rotations‑egenskap till önskad vinkel.
1. Spara presentationen.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotera formen med 5 grader.
    shape.setRotation(5);

    // Spara PPTX-filen till disk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Formroteringen](shape-rotation.png)

## **Lägg till 3D‑fastringseffekter**

Aspose.Slides låter dig applicera 3D‑fastringseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/threedformat/)‑egenskaper.

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till en bild (slide) med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/threedformat/) för att definiera fastringsinställningar.
1. Spara presentationen.

```java
// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en form på bilden.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Ange formens ThreeDFormat-egenskaper.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Spara presentationen som en PPTX-fil.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![3D‑fastringseffekten](3D-bevel-effect.png)

## **Lägg till 3D‑roteringseffekter**

Aspose.Slides låter dig applicera 3D‑roteringseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/threedformat/)‑egenskaper.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till en bild (slide) med dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Använd [setCameraType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icamera/#setCameraType-int-) och [setLightType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) för att definiera 3D‑rotationen.
1. Spara presentationen.

```java
// Skapa en instans av Presentation-klassen.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Spara presentationen som en PPTX-fil.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![3D‑roteringseffekten](3D-rotation-effect.png)

## **Återställ formatering**

Följande Java‑kod visar hur du återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/layoutslide/) till sina standardinställningar:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Återställ varje form på bilden som har en platshållare på layouten.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media utgör största delen av filstorleken, medan formparametrar såsom färger, effekter och gradienter lagras som metadata och nästan ingen extra storlek.

**Hur kan jag upptäcka former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings‑egenskaper—fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, betrakta deras stilar som identiska och gruppera logiskt de formerna, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med de önskade stilarna i en mall‑bildsats eller en .POTX‑mallfil. När du skapar en ny presentation öppnar du mallen, klonar de stylade former du behöver och återapplicerar deras formatering där det krävs.