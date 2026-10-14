---
title: Formatera PowerPoint‑former i Java
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/java/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss‑effekt
- skisslinje för form
- formatera fogstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgsfyllning
- formtransparens
- svart‑vitt formrendering
- gråskalaformrendering
- rotera form
- 3D‑avfasningseffekt
- 3D‑roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i Java med Aspose.Slides—sätt fyllnings‑, linje‑ och effektstilar för PPT-, PPTX- och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller applicera effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java tillhandahåller gränssnitt och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in [linjestil](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) för formen.
1. Ställ in linjebredden.
1. Ställ in [streckstil](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) för linjen.
1. Ställ in linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande kod visar hur du formaterar en rektangel `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Ställ in fyllningsfärgen för rektangel‑formen.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Applicera formatering på rektangelns linjer.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ställ in färgen för rektangelns linje.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Spara PPTX‑filen till disk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Applicera skiss‑effekter på form‑linjer**

En skiss‑effekt får en form‑linje att se handritad ut. Använd [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) för att komma åt linjeinställningarna, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) för att komma åt skissinställningarna och [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Följande Java‑kod visar hur du applicerar en [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/)‑effekt, läser det explicit tilldelade värdet och tar bort effekten med [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Åtkomst till formens linjeformat och dess skissformat.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Applicera en skisseffekt.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Läs den skisseffekt som tilldelats direkt till formen.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Ta bort skisseffekten.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Det värde som returneras av [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) representerar den inställning som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, en master‑bild eller en layout‑bild, använd [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), nå [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/), och läs [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). Det effektiva värdet återspeglar den formatering som faktiskt tillämpas efter att arv har lösts:

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

## **Formatera fogstilar**

Här är de tre alternativen för fogtyp:

* Rund
* Miter
* Bevel

Som standard använder PowerPoint **Round**‑inställningen när två linjer förenas i en vinkel (t.ex. vid en formens hörn). Men om du ritar en form med skarpa vinklar kan du föredra **Miter**‑alternativet.

![Fogstilen i presentationen](join-style-powerpoint.png)

Följande Java‑kod demonstrerar hur tre rektanglar (som visas på bilden ovan) skapades med Miter‑, Bevel‑ och Round‑inställningarna för fogtyp:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till tre autosformer av typen Rektangel.
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

    // Ställ in fogstilen.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Lägg till text i varje rektangel.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Spara PPTX‑filen till disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du använda två eller flera färger så att den ena gradvis tonar in i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två önskade färger med definierade positioner med hjälp av `add`‑metoderna i gradientstopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/).
1. Spara den ändrade presentationen som en PPTX‑fil.

```java
import com.aspose.slides.*;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autosform av typen Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Applicera gradientformatering på ellipsen.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ställ in gradientens riktning.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Lägg till två gradientstopp.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Spara PPTX‑filen till disk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Ellipsen med gradientfyllning](gradient-fill.png)

Om en gradient ser annorlunda ut i en exporterad bild jämfört med hur den ser ut i PowerPoint, se [Välj en gradientrenderingsstil](/slides/sv/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en renderingsstil utan att ändra gradientfyllningen som lagras i presentationen.

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera ett tvåfärgsdesign—t.ex. prickar, ränder, korsningar eller rutmönster—på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder mer än 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra presentationernas visuella intryck. Även efter att ha valt ett fördefinierat mönster kan du fortfarande ange exakt vilka färger det ska använda.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ställ in [Bakgrundsfärg](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) för mönstret.
1. Ställ in [Förgrundsfärg](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) för mönstret.
1. Spara den ändrade presentationen som en PPTX‑fil.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autosform av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstypen till Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ställ in mönsterstilen.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ställ in mönstrets bakgrunds- och förgrundsfärger.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Spara PPTX‑filen till disk.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form—effektivt använda bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) till `Picture`.
1. Ställ in bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)‑objekt från den bild du vill använda.
1. Skicka bilden till metoden `ISlidesPicture.setImage`.
1. Spara den ändrade presentationen som en PPTX‑fil.

Anta att vi har en fil "lotus.png" med följande bild:

![Lotus‑bilden](lotus.png)

```java
import com.aspose.slides.*;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autosform av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ställ in fyllningstypen till Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ställ in bildfyllningsläget.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Läs in en bild och lägg till den i presentationens resurser.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ställ in bilden.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Spara PPTX‑filen till disk.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formen med bildfyllning](picture-fill.png)

### **Tile Bild Som Textur**

Om du vill ställa in en plattad bild som en textur och anpassa plattningsbeteendet kan du använda följande metoder i gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ställer in bildfyllningsläget—antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Anger justeringen av plattorna inom formen.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Styr huruvida plattan vänds horisontellt, vertikalt eller båda.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ställer in den horisontella förskjutningen av plattan (i punkter) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ställer in den vertikala förskjutningen av plattan (i punkter) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definierar den horisontella skalan av plattan som en procentandel.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definierar den vertikala skalan av plattan som en procentandel.

```java
import com.aspose.slides.*;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lägg till en rektangel‑autosform.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ställ in fyllningstypen för formen till Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Läs in bilden och lägg till den i presentationens resurser.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tilldela bilden till formen.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurera bildfyllningsläget och plattningsinställningarna.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Spara PPTX‑filen till disk.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Plattalternativen](tile-options.png)

## **Enfärgsfyllning**

I PowerPoint är Enfärgsfyllning ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

Så här applicerar du en enfärgsfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) till `Solid`.
1. Tilldela den önskade fyllningsfärgen till formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autosform av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstypen till Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Ställ in fyllningsfärgen.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Spara PPTX‑filen till disk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formen med enfärgsfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint kan du när du applicerar en enfärgs‑, gradient‑, bild‑ eller texturfyllning på former även ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ange transparensnivån genom att justera alfa‑värdet i färgen som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (alfa‑komponenten styr transparensen).
1. Spara presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en solid rektangel‑autosform.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangel‑autosform ovanpå den solida formen.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Spara PPTX‑filen till disk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifik justering eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens rotations‑property till önskad vinkel.
1. Spara presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autosform av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotera formen med 5 grader.
    shape.setRotation(5);

    // Spara PPTX‑filen till disk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formens rotation](shape-rotation.png)

## **Lägg till 3D-avfasningseffekter**

Aspose.Slides tillåter dig att applicera 3D‑avfasningseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/)‑egenskaper.

För att lägga till 3D‑avfasningseffekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) för att definiera avfasningsinställningarna.
1. Spara presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Skapa en instans av Presentation‑klassen.
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

![3D-avfasningseffekten](3D-bevel-effect.png)

## **Lägg till 3D-roteringseffekter**

Aspose.Slides tillåter dig att applicera 3D‑roteringseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/)‑egenskaper.

För att applicera 3D‑rotering på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) på bilden.
1. Använd [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) och [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) för att definiera 3D‑roteringen.
1. Spara presentationen.

```java
import com.aspose.slides.*;

// Skapa en instans av Presentation‑klassen.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Spara presentationen som en PPTX‑fil.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![3D-roteringseffekten](3D-rotation-effect.png)

## **Styr svart‑vitt‑rendering för former**

Metoden [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) specificerar hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vitt‑läge. Den aktiverar inte svart‑vitt‑visning i sig och ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från klassen [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konverteringen, `Gray` och `LightGray` använder grå färgning, `BlackWhite` använder endast svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning, och `Hidden` utesluter formen i svart‑vitt‑läge. `NotDefined` betyder att inget form‑nivå‑läge har tilldelats.

Följande Java‑kod skapar en färgad form och får den att visas grå i svart‑vitt‑visningsläge:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Behåll den orange fyllningen i färgläge, men rendera formen med grå färgning i svart-vitt läge.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett arbetsflöde med svart‑vitt‑visning använder den grå färgning eftersom dess läge är satt till `Gray`. Detta låter dig bevara en färgrik bild medan du definierar ett tydligt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vitt‑visningsinställningar.

## **Återställ formatering**

Följande Java‑kod visar hur du återställer formateringen av en bild och återställer position, storlek och formatering av alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) till deras standardinställningar:

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

**Påverkar formatering av former den slutgiltiga filstorleken för presentationen?**

Endast marginellt. Inbäddade bilder och media upptar största delen av filutrymmet, medan formparametrar såsom färger, effekter och gradienter lagras som metadata och bidrar praktiskt taget inte till någon extra storlek.

**Hur kan jag identifiera former på en bild som delar identisk formatering så att jag kan gruppera dem?**

Jämför varje formes nyckelformaterings‑egenskaper—fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑bildspel eller en .POTX‑mallfil. När du skapar en ny presentation öppnar du mallen, klonar de stilade formerna du behöver och återapplicerar deras formatering där det krävs.