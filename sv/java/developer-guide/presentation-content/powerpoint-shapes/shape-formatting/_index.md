---
title: Formatera PowerPoint‑former i Java
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/java/shape-formatting/
keywords:
- formatera form
- formatera linje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgsfyllning
- formtransparent
- rotera form
- 3D‑avfasningseffekt
- 3D‑rotationseffekt
- återställ formatering
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i Java med Aspose.Slides—ange fyllnings-, linje- och effektstilar för PPT-, PPTX- och ODP-filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras innermaterial fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för Java tillhandahåller gränssnitt och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver förfarandet:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in [linjestil](https://reference.aspose.com/slides/sv/java/com.aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ställ in [streckstil](https://reference.aspose.com/slides/sv/java/com.aspose.slides/linedashstyle/) för linjen.
1. Ange linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande kod visar hur man formaterar en rektangel `AutoShape`:

```java
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Ställ in fyllningsfärgen för rektangelformen.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Applicera formatering på rektangelns linjer.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ställ in färgen för rektangelns linje.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Spara PPTX-filen till disken.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Formatera anslutningsstilar**

Här är de tre alternativ för anslutningstyp:

* Rund
* Fasett
* Avfasning

Som standard använder PowerPoint **Rund** när den förenar två linjer i en vinkel (t.ex. vid en formes hörn). Om du däremot ritar en form med skarpa vinklar kan du föredra **Fasett**.

![Anslutningsstilen i presentationen](join-style-powerpoint.png)

Följande Java‑kod demonstrerar hur tre rektanglar (som visas i bilden ovan) skapades med Fasett, Avfasning och Rund anslutningstyp:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till tre autoshapes av typen Rektangel.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ställ in fyllningsfärgen för varje rektangelform.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Ställ in linjebredden.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ställ in färgen för varje rektangels linje.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Ställ in anslutningsstilen.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Lägg till text i varje rektangel.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Spara PPTX-filen till disken.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig blandning av färger på en form. Till exempel kan du använda två eller flera färger så att den ena gradvis tonar in i den andra.

Här är hur du applicerar en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två önskade färger med definierade positioner med hjälp av `add`‑metoderna i gradientstopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/igradientformat/).
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Java‑kod demonstrerar hur du applicerar en gradientfyllning på en ellips:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Ellips.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applicera gradientformatering på ellipsen.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ställ in riktningen för gradienten.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Lägg till två gradientstopp.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Spara PPTX-filen till disken.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign—t.ex. prickar, ränder, korshatch eller rutmönster—på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra presentationens visuella intryck. Även efter att du valt ett fördefinierat mönster kan du fortfarande ange exakt vilka färger som ska användas.

Här är hur du applicerar en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ställ in [Background Color](https://reference.aspose.com/slides/sv/java/com.aspose.slides/patternformat/#getBackColor--) för mönstret.
1. Ställ in [Foreground Color](https://reference.aspose.com/slides/sv/java/com.aspose.slides/patternformat/#getForeColor--) för mönstret.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Java‑kod demonstrerar hur du applicerar en mönsterfyllning på en rektangel:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstypen till Mönster.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ställ in mönsterstilen.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ställ in mönstrets bakgrunds- och förgrundsfärger.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Spara PPTX-filen till disken.
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

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Picture`.
1. Ställ in bildfyllningsläget till `Tile` (eller ett annat önskat läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/)‑objekt från den bild du vill använda.
1. Skicka bilden till metoden `ISlidesPicture.setImage`.
1. Spara den ändrade presentationen som en PPTX‑fil.

Anta att vi har en fil "lotus.png" med följande bild:

![Lotusbilden](lotus.png)

Följande Java‑kod demonstrerar hur du fyller en form med bilden:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ställ in fyllningstypen till Bild.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ställ in bildfyllningsläget.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Läs in en bild och lägg till den i presentationens resurser.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ställ in bilden.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Spara PPTX-filen till disken.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Kakelbild som textur**

Om du vill ange en kaklad bild som textur och anpassa kaklingsbeteendet kan du använda följande metoder i gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ställer in bildfyllningsläget—antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Anger justeringen av kaklorna inom formen.
- [setTileFlip](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kontrollerar om kakeln vänds horisontellt, vertikalt eller båda.
- [setTileOffsetX](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ställer in den horisontella förskjutningen av kakeln (i punkter) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ställer in den vertikala förskjutningen av kakeln (i punkter) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definierar den horisontella skalan för kakeln som en procentsats.
- [setTileScaleY](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definierar den vertikala skalan för kakeln som en procentsats.

Följande kodexempel visar hur man lägger till en rektangel med kaklad bildfyllning och konfigurerar kakelalternativ:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lägg till en rektangel autoshape.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ställ in fyllningstypen för formen till Bild.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Läs in bilden och lägg till den i presentationens resurser.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tilldela bilden till formen.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurera bildfyllningsläget och kakleegenskaperna.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Spara PPTX-filen till disken.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Kakelalternativen](tile-options.png)

## **Enfärgsfyllning**

I PowerPoint är Enfärgsfyllning ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Solid`.
1. Tilldela den färg du föredrar som fyllningsfärg till formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Java‑kod demonstrerar hur du applicerar en enfärgsfyllning på en rektangel i en PowerPoint‑bild:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstypen till Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Ställ in fyllningsfärgen.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Spara PPTX-filen till disken.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Formen med enfärgsfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint kan du, när du applicerar en enfärgs-, gradient‑, bild‑ eller texturfyllning på former, också ange en transparensnivå för att kontrollera fyllningens ogenomskinlighet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (alpha‑komponenten styr transparensen).
1. Spara presentationen.

Följande Java‑kod demonstrerar hur du applicerar en transparent fyllningsfärg på en rektangel:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en solid rektangel autoshape.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en genomskinlig rektangel autoshape ovanpå den solida formen.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Spara PPTX-filen till disken.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den genomskinliga formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifika justerings‑ eller designkrav.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens rotationsegenskap till önskad vinkel.
1. Spara presentationen.

Följande Java‑kod demonstrerar hur du roterar en form med 5 grader:

```java
// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotera formen med 5 grader.
    shape.setRotation(5);

    // Spara PPTX-filen till disken.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Formens rotation](shape-rotation.png)

## **Lägg till 3D-Avfasningseffekter**

Aspose.Slides låter dig applicera 3D‑avfasningseffekter på former genom att konfigurera deras [ThreeDFormat]-egenskaper.

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat] för att definiera avfasningsinställningar.
1. Spara presentationen.

Följande Java‑kod visar hur du applicerar 3D‑avfasningseffekter på en form:

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

    // Ställ in formens ThreeDFormat-egenskaper.
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

![3D‑avfasningseffekten](3D-bevel-effect.png)

## **Lägg till 3D-rotationseffekter**

Aspose.Slides låter dig applicera 3D‑rotationseffekter på former genom att konfigurera deras [ThreeDFormat]-egenskaper.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Använd [setCameraType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icamera/#setCameraType-int-) och [setLightType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilightrig/#setLightType-int-) för att definiera 3D‑rotationen.
1. Spara presentationen.

Följande Java‑kod demonstrerar hur du applicerar 3D‑rotationseffekter på en form:

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

![3D‑rotationseffekten](3D-rotation-effect.png)

## **Återställ formatering**

Följande Java‑kod visar hur du återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/layoutslide/) till sina standardinställningar:

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

**Påverkar formatering av former den slutgiltiga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media tar upp största delen av filstorleken, medan formparametrar som färger, effekter och gradienter lagras som metadata och lägger i praktiken till ingen extra storlek.

**Hur kan jag identifiera former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckel‑formateringsegenskaper—fyllning, linje och effektinställningar. Om alla motsvarande värden matchar behandlas deras stilar som identiska och du kan logiskt gruppera dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑bildserie eller en .POTX‑mallfil. När du skapar en ny presentation öppnar du mallen, klonar de stilade former du behöver och återapplicer deras formatering där det krävs.