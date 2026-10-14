---
title: Formatera PowerPoint‑former på Android
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/androidjava/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss‑effekt
- skisslinje för form
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgsfyllning
- formtransparens
- svart‑vit rendering av form
- gråskala rendering av form
- rotera form
- 3D-fasteffekt
- 3D-roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former på Android med Aspose.Slides—sätt fyllnings‑, linje‑ och effekstilar för PPT-, PPTX- och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller applicera effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![format-form-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för Android via Java tillhandahåller gränssnitt och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) för linjen.
1. Ange linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande kod visar hur man formaterar en rektangel `AutoShape`:

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

    // Ta bort fyllningen från rektangelformen så att endast dess linjer är synliga.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Applicera formatering på rektangelns linjer.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ange färgen för rektangelns linje.
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

## **Applicera skiss‑effekter på formens linjer**

En skisseffekt får en formlinje att se handritad ut. Använd [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) för att komma åt linjeinställningarna, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) för att komma åt skissinställningarna och [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) .

Följande Java‑kod visar hur man applicerar en [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/)‑effekt, läser det uttryckligen tilldelade värdet och tar bort effekten med [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Åtkomst till formens linjeformat och dess skissformat.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Applicera en skiss‑effekt.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Läs skiss‑effekten som tilldelats formen direkt.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Ta bort skiss‑effekten.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Det värde som returneras av [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) representerar inställningen som tilldelats formen direkt. Om linjeformatet kan ärvas från ett tema, en huvudbild eller en layoutbild, använd [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/), kom åt [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/), och läs [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/). Det effektiva värdet speglar det format som faktiskt tillämpas efter att arv har lösts :

```java
import com.aspose.slides.*;

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

## **Formatera anslutningsstilar**

Här är de tre alternativ för anslutningstyp:

* Round
* Miter
* Bevel

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en forms hörn), använder den **Round**‑inställningen. Men om du ritar en form med skarpa vinklar kan du föredra **Miter**‑alternativet.

![Fogstilen i presentationen](join-style-powerpoint.png)

Följande Java‑kod visar hur tre rektanglar (som visas på bilden ovan) skapades med Miter‑, Bevel‑ och Round‑inställningarna för anslutningstyp:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation‑klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till tre autoshapes av typen Rektangel.
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

    // Spara PPTX‑filen till disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig tillämpa en kontinuerlig färgblandning på en form. Till exempel kan du använda två eller fler färger så att den ena gradvis tonas ner i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två önskade färger med definierade positioner med hjälp av `add`‑metoderna i gradientstopp‑samlingen som exponeras av gränssnittet [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) .
1. Spara den ändrade presentationen som en PPTX‑fil.

```java
import com.aspose.slides.*;

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

Om en gradient ser annorlunda ut i en exporterad bild jämfört med hur den ser ut i PowerPoint, se [Välj en gradientrenderingsstil](/slides/sv/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en renderingsstil utan att ändra gradientfyllningen som lagras i presentationen.

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign—t.ex. prickar, ränder, korsvirkningar eller rutor—på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder mer än 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra det visuella intrycket i dina presentationer. Även efter att du har valt ett fördefinierat mönster kan du fortfarande specificera exakt vilka färger som ska användas.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ange [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) för mönstret.
1. Ange [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) för mönstret.
1. Spara den ändrade presentationen som en PPTX‑fil.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ange fyllningstypen till Pattern.
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

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form—så att bilden effektivt blir formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) till `Picture`.
1. Ange bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)‑objekt från bilden du vill använda.
1. Skicka bilden till metoden `ISlidesPicture.setImage`.
1. Spara den ändrade presentationen som en PPTX‑fil.

Anta att vi har en fil "lotus.png" med följande bild:

![Lotus‑bilden](lotus.png)

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
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

### **Tile‑bild som textur**

Om du vill använda en tiled bild som en textur och anpassa tile‑beteendet kan du använda följande metoder från gränssnittet [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) och klassen [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Anger bildfyllningsläget—antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Anger justeringen av tile‑erna inom formen.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Styr om tile‑en vänds horisontellt, vertikalt eller båda.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Anger den horisontella förskjutningen av tile‑en (i points) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Anger den vertikala förskjutningen av tile‑en (i points) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definierar den horisontella skalan av tile‑en i procent.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definierar den vertikala skalan av tile‑en i procent.

Följande kodexempel visar hur man lägger till en rektangel med tiled bildfyllning och konfigurerar tile‑alternativen:

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lägg till en rektangel‑autoshape.
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

    // Konfigurera bildfyllningsläget och tile‑egenskaperna.
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

Resultatet:

![Tile‑alternativen](tile-options.png)

## **Enfärgsfyllning**

I PowerPoint är Enfärgsfyllning ett formateringsalternativ som fyller en form med en enda, jämn färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en enfärgsfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) till `Solid`.
1. Tilldela den färg du föredrar som fyllning till formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
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

![Formen med enfärgsfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en enfärgs-, gradient‑, bild- eller texturfyllning på former kan du också ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ställa in transparensnivån genom att justera alfa‑värdet i färgen som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ange [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (alfa‑komponenten styr transparensen).
1. Spara presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en solid rektangel‑autoshape.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangel‑autoshape ovanpå den solida formen.
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

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifika justerings- eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Ställ in formens rotations‑egenskap till önskad vinkel.
1. Spara presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar en presentationsfil.
Presentation presentation = new Presentation();
try {
    // Hämta den första bilden.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoshape av typen Rektangel.
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

## **Lägg till 3D‑fasteffekter**

Aspose.Slides låter dig applicera 3D‑fasteffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/)‑egenskaper.

För att lägga till 3D‑fasteffekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) för att definiera fasinställningarna.
1. Spara presentationen.

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

![3D‑fasteffekten](3D-bevel-effect.png)

## **Lägg till 3D‑roteringseffekter**

Aspose.Slides låter dig applicera 3D‑roteringseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/)‑egenskaper.

För att applicera 3D‑rotering på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) på bilden.
1. Använd [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) och [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) för att definiera 3D‑roteringen.
1. Spara presentationen.

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

## **Styr svart‑vita rendering för former**

Metoden [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) anger hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vitt läge. Den aktiverar inte svart‑vit visning i sig själv och ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från klassen [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konverteringen, `Gray` och `LightGray` använder grå färg, `BlackWhite` använder endast svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning, och `Hidden` utesluter formen i svart‑vitt läge. `NotDefined` betyder att inget form‑nivå‑läge har tilldelats.

Följande Java‑kod skapar en färgad form och får den att visas grå i svart‑vitt visningsläge:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Behåll den orange fyllningen i färgläge, men rendera formen med grå färgning i svart-vitt läge.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett svart‑vitt display‑flöde använder den grå färg eftersom dess läge är satt till `Gray`. Detta låter dig behålla en fullfärgsbild medan du definierar ett tydligt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vita visningsinställningar.

## **Återställ formatering**

Följande Java‑kod visar hur man återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) till deras standardinställningar:

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

**Påverkar formatering av former den slutgiltiga presentationens filstorlek?**

Endast marginellt. Inbäddade bilder och media tar upp största delen av filstorleken, medan formparametrar som färger, effekter och gradienter lagras som metadata och nästan inte ökar filstorleken.

**Hur kan jag identifiera former på en bild som delar identisk formatering så att jag kan gruppera dem?**

Jämför varje forms viktiga formateringsegenskaper—fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑presentation eller en .POTX‑mallfil. När du skapar en ny presentation öppnar du mallen, klonar de stylade former du behöver och återapplicerar deras formatering där det behövs.