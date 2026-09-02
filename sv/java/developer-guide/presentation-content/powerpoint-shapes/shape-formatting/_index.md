---
title: Formatera PowerPoint-former i Java
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/java/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss‑effekt
- skiss av formlinje
- formatera sammanfogningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formtransparens
- svart‑vit rendering av form
- gråskala rendering av form
- rotera form
- 3D fasadeffekt
- 3D roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i Java med Aspose.Slides—ange fyllnings‑, linje‑ och effektstilar för PPT-, PPTX‑ och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java tillhandahåller gränssnitt och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in [line style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ställ in [dash style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/linedashstyle/) för linjen.
1. Ange linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande kod visar hur du formaterar en rektangel‑`AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Ange fyllningsfärgen för rektangelformen.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Tillämpa formatering på rektangelns linjer.
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

## **Applicera skiss‑effekter på formens linjer**

En skiss‑effekt får en formlinje att se handritad ut. Använd [IShape.getLineFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) för att komma åt linjeinställningarna, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilineformat/) för att komma åt skiss‑inställningarna och [ISketchFormat.setSketchType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isketchformat/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/linesketchtype/).

Följande Java‑kod visar hur du applicerar en [LineSketchType.Curved](https://reference.aspose.com/slides/sv/java/com.aspose.slides/linesketchtype/)‑effekt, läser det uttryckligen tilldelade värdet och tar bort effekten med [LineSketchType.None](https://reference.aspose.com/slides/sv/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Åtkomst till formens linjeformat och dess skissformat.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Tillämpa en skiss‑effekt.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Läs den skiss‑effekt som tilldelats direkt till formen.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Ta bort skiss‑effekten.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Värdet som returneras av [ISketchFormat.getSketchType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isketchformat/) representerar inställningen som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, en master‑bild eller en layout‑bild, använd [ILineFormat.getEffective](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilineformat/), kom åt [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilineformateffectivedata/), och läs [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isketchformateffectivedata/). Det effektiva värdet speglar den formatering som faktiskt tillämpas efter arv har lösts:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formatera kopplingstyper**

Här är de tre alternativen för kopplingstyp:

* Round
* Miter
* Bevel

Som standard använder PowerPoint **Round**‑inställningen när två linjer möts i en vinkel (t.ex. i ett hörn på en form). Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Miter**.

![Kopplingstypen i presentationen](join-style-powerpoint.png)

Följande Java‑kod demonstrerar hur tre rektanglar (som visas i bilden ovan) skapades med Miter‑, Bevel‑ och Round‑kopplingstyper:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till tre automatiska former av typen Rectangle.
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

    // Ange sammanfogningsstilen.
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

I PowerPoint är Gradient Fill ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du applicera två eller fler färger på ett sätt så att den ena gradvis tonas in i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två föredragna färger med definierade positioner med hjälp av `add`‑metoderna i gradient‑stopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/igradientformat/).
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Java‑kod visar hur du applicerar en gradientfyllning på en ellips:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applicera gradientformattering på ellipsen.
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

I PowerPoint är Pattern Fill ett formateringsalternativ som låter dig applicera ett tvåfärgs‑mönster – t.ex. prickar, ränder, korsstreck eller schackrutor – på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra den visuella attraktiviteten i dina presentationer. Även efter att du har valt ett fördefinierat mönster kan du ange de exakta färgerna som ska användas.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ställ in [Background Color](https://reference.aspose.com/slides/sv/java/com.aspose.slides/patternformat/#getBackColor--) för mönstret.
1. Ställ in [Foreground Color](https://reference.aspose.com/slides/sv/java/com.aspose.slides/patternformat/#getForeColor--) för mönstret.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Java‑kod visar hur du applicerar en mönsterfyllning på en rektangel:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ange fyllningstypen till Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ange mönsterstil.
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

I PowerPoint är Picture Fill ett formateringsalternativ som låter dig infoga en bild i en form – i praktiken använder du bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Picture`.
1. Ställ in bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/)‑objekt från den bild du vill använda.
1. Skicka bilden till metoden `ISlidesPicture.setImage`.
1. Spara den ändrade presentationen som en PPTX‑fil.

Låt säga att vi har en fil **lotus.png** med följande bild:

![Lotus‑bilden](lotus.png)

Följande Java‑kod demonstrerar hur du fyller en form med bilden:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ange fyllningstypen till Picture.
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

### **Tile Picture As Texture**

Om du vill använda en tegel‑bild som textur och anpassa tegel‑beteendet kan du använda följande metoder i gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Anger bildfyllningsläget – antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Specificerar justeringen av tegel inom formen.
- [setTileFlip](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Styr om teglet flippar horisontellt, vertikalt eller båda.
- [setTileOffsetX](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Anger den horisontella förskjutningen av teglet (i punkter) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Anger den vertikala förskjutningen av teglet (i punkter) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definierar den horisontella skalan av teglet i procent.
- [setTileScaleY](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definierar den vertikala skalan av teglet i procent.

Följande kodexempel visar hur du lägger till en rektangulär form med en tegel‑bildfyllning och konfigurerar tegel‑alternativen:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lägg till en rektangel‑autoform.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ange fyllningstypen för formen till Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Läs in bilden och lägg till den i presentationens resurser.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tilldela bilden till formen.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurera bildfyllningsläget och tegel‑egenskaperna.
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

![Tegel‑alternativen](tile-options.png)

## **Solid Color Fill**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en solid färgfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Solid`.
1. Tilldela din föredragna fyllningsfärg till formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Java‑kod demonstrerar hur du applicerar en solid färgfyllning på en rektangel i en PowerPoint‑bild:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Rectangle.
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

I PowerPoint kan du, när du använder en solid färg, gradient, bild eller texturfyllning på former, också ange en transparensnivå för att styra fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ställa in transparensnivån genom att justera alfa‑värdet i den färg som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in [FillType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (alfa‑komponenten styr transparensen).
1. Spara presentationen.

Följande Java‑kod visar hur du applicerar en transparent fyllningsfärg på en rektangel:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en solid rektangel‑autoform.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangel‑autoform ovanpå den solida formen.
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

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifik justering eller design.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens rotations‑egenskap till önskad vinkel.
1. Spara presentationen.

Följande Java‑kod demonstrerar hur du roterar en form med 5 grader:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en automatisk form av typen Rectangle.
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

![Formens rotation](shape-rotation.png)

## **Lägg till 3D‑fasadeffekter**

Aspose.Slides låter dig applicera 3D‑fasadeffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/threedformat/)-egenskaper.

För att lägga till 3D‑fasadeffekter på en form, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/threedformat/) för att definiera fasadeinställningarna.
1. Spara presentationen.

Följande Java‑kod visar hur du applicerar 3D‑fasadeffekter på en form:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Ställ in formens ThreeDFormat‑egenskaper.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Spara presentationen som en PPTX‑fil.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![3D‑fasadeffekten](3D-bevel-effect.png)

## **Lägg till 3D‑roteringseffekter**

Aspose.Slides låter dig applicera 3D‑roteringseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/threedformat/)-egenskaper.

För att applicera 3D‑rotering på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) på bilden.
1. Använd [setCameraType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icamera/#setCameraType-int-) och [setLightType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilightrig/#setLightType-int-) för att definiera 3D‑roteringen.
1. Spara presentationen.

Följande Java‑kod demonstrerar hur du applicerar 3D‑roteringseffekter på en form:

```java
import com.aspose.slides.*;

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

## **Styr svart‑vit rendering av former**

Metoden [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) anger hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vit läge. Den aktiverar inte svart‑vit visning i sig och ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från klassen [BlackWhiteMode](https://reference.aspose.com/slides/sv/java/com.aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konvertering, `Gray` och `LightGray` använder gråtoner, `BlackWhite` använder endast svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färg, och `Hidden` utesluter formen i svart‑vit läge. `NotDefined` betyder att inget form‑specifikt läge är tilldelat.

Följande Java‑kod skapar en färgad form och får den att visas grå i svart‑vit display‑läge:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Behåll den orange fyllningen i färgläge, men rendera formen med grå färg i svart‑vitt läge.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett arbetsflöde med svart‑vit display använder den grå färg eftersom dess läge är satt till `Gray`. Detta låter dig bevara en full‑färgs‑bild medan du definierar ett särskilt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vita visningsinställningar.

## **Återställ formatering**

Följande Java‑kod visar hur du återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/layoutslide/) till deras standardinställningar:

```java
import com.aspose.slides.*;

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

**Påverkar formatering av former den slutliga filstorleken för presentationen?**

Endast marginellt. Inbäddade bilder och media tar upp största delen av filstorleken, medan formparametrar som färger, effekter och gradienter lagras som metadata och tillför praktiskt taget ingen extra storlek.

**Hur kan jag upptäcka former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings‑egenskaper – fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i ett mall‑bildspel eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de stiliserade former du behöver och applicera deras formatering där de krävs.