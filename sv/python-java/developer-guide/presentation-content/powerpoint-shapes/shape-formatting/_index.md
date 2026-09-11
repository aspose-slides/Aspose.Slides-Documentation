---
title: Formatera PowerPoint-former i Python via Java
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/python-java/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss-effekt
- skisslinje för form
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgsfyllning
- formtransparens
- svart-vit rendering av form
- gråskala rendering av form
- rotera form
- 3D-avfasningseffekt
- 3D-rotationseffekt
- återställ formatering
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint-former i Python via Java med Aspose.Slides -- ange fyllnings-, linje- och effektstilar för PPT-, PPTX- och ODP-filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller applicera effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras innerväggar fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för Python via Java tillhandahåller klasser och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
1. Ange [line style](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [dash style](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linedashstyle/) för linjen.
1. Ange linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX-fil.

Följande kod visar hur man formaterar en rektangel [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoshape av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Ange fyllningsfärgen för rektangelformen.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Applicera formatering på rektangelns linjer.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Ange färgen för rektangelns linje.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Spara PPTX-filen till disk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


Resultatet:

![The formatted lines in the presentation](formatted-lines.png)

## **Applicera skiss‑effekter på formlinjer**

En skisseffekt får en formlinje att se handritad ut. Använd [Shape.getLineFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getLineFormat) för att komma åt linjeinställningarna, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/lineformat/#getSketchFormat) för att komma åt skissinställningarna och [SketchFormat.setSketchType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sketchformat/#setSketchType) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linesketchtype/).

Följande Python‑kod visar hur man applicerar en [LineSketchType.Curved](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linesketchtype/#Curved)‑effekt, läser det explicit tilldelade värdet och tar bort effekten med [LineSketchType.None_](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linesketchtype/#None):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Åtkomst till formens linjeformat och dess skissformat.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Applicera en skisseffekt.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Läs den skisseffekt som tilldelats direkt till formen.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Ta bort skisseffekten.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Värdet som returneras av [SketchFormat.getSketchType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sketchformat/#getSketchType) representerar inställningen som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, en huvudsida eller en layout‑slide, använd [LineFormat.getEffective](https://reference.aspose.com/slides/sv/python-java/aspose.slides/lineformat/#getEffective), få åtkomst till `LineFormatEffectiveData.getSketchFormat` och läs `SketchFormatEffectiveData.getSketchType`. Det effektiva värdet speglar den formatering som faktiskt tillämpas efter att arv har lösts:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Formatera anslutningsstilar**

Här är de tre alternativen för anslutningstyp:

* Rund
* Sned
* Avfasad

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formens hörn), använder den **Round**‑inställningen. Om du däremot ritar en form med skarpa vinklar kan du föredra **Miter**‑alternativet.

![The join style in the presentation](join-style-powerpoint.png)

Följande Python‑kod demonstrerar hur tre rektanglar (som visas på bilden ovan) skapades med Miter‑, Bevel‑ och Round‑inställningarna för anslutningstyp:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till tre autoshapes av typen Rectangle.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Ange fyllningsfärgen för varje rektangelform.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Ange linjebredden.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Ange färgen för varje rektangels linje.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Ange anslutningsstilen.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Lägg till text till varje rektangel.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Spara PPTX-filen till disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Du kan till exempel applicera två eller fler färger så att en gradvis tonar in i en annan.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två önskade färger med definierade positioner med hjälp av metoden [addPresetColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/gradientstopcollection/#addPresetColor) i gradientstoppkollektionen som exponeras av klassen [GradientFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/gradientformat/).
1. Spara den ändrade presentationen som en PPTX-fil.

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

    # Skapa en instans av Presentation-klassen som representerar en presentationsfil.
    presentation = Presentation()
    try:
        # Hämta den första bilden.
        slide = presentation.getSlides().get_Item(0)

        # Lägg till en autoshape av typen Ellipse.
        shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

        # Applicera gradientformatering på ellipsen.
        shape.getFillFormat().setFillType(FillType.Gradient)
        shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

        # Ange gradientens riktning.
        shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

        # Lägg till två gradientstopp.
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
        shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

        # Spara PPTX-filen till disk.
        presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Resultatet:

![The ellipse with gradient fill](gradient-fill.png)

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign – såsom prickar, ränder, korsade linjer eller schackrutor – på en form. Du kan välja anpassade färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder mer än 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra det visuella intrycket i dina presentationer. Även efter att ha valt ett fördefinierat mönster kan du fortfarande specificera exakt vilka färger det ska använda.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ange [Background Color](https://reference.aspose.com/slides/sv/python-java/aspose.slides/patternformat/#getBackColor) för mönstret.
1. Ange [Foreground Color](https://reference.aspose.com/slides/sv/python-java/aspose.slides/patternformat/#getForeColor) för mönstret.
1. Spara den ändrade presentationen som en PPTX-fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoshape av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ange fyllningstypen till Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Ange mönsterstilen.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Ange mönstrets bakgrunds- och förgrundsfärger.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Spara PPTX-filen till disk.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form – som effektivt använder bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) till `Picture`.
1. Ange bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)‑objekt från den bild du vill använda.
1. Skicka bilden till metoden `SlidesPicture.setImage`.
1. Spara den ändrade presentationen som en PPTX-fil.

Låt oss säga att vi har en fil "lotus.png" med följande bild:

![The lotus picture](lotus.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoshape av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Ange fyllningstypen till Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Ange bildfyllningsläget.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Ladda en bild och lägg till den i presentationens resurser.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Ange bilden.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Spara PPTX-filen till disk.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![The shape with picture fill](picture-fill.png)

### **Tila bild som textur**

Om du vill sätta en tilad bild som textur och anpassa tilningsbeteendet kan du använda följande metoder i klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Ställer in bildfyllningsläget – antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#setTileAlignment): Anger hur plattorna är justerade inom formen.
- [setTileFlip](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#setTileFlip): Styr om plattan vänds horisontellt, vertikalt eller både och.
- [setTileOffsetX](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Anger den horisontella förskjutningen av plattan (i punkter) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Anger den vertikala förskjutningen av plattan (i punkter) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definierar den horisontella skalan för plattan i procent.
- [setTileScaleY](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definierar den vertikala skalan för plattan i procent.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    first_slide = presentation.getSlides().get_Item(0)

    # Lägg till en rektangel‑autoshape.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Ange fyllningstypen för formen till Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Ladda bilden och lägg till den i presentationens resurser.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Tilldela bilden till formen.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Konfigurera bildfyllningsläget och tilningsegenskaperna.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Spara PPTX-filen till disk.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![The tile options](tile-options.png)

## **Solid färgfyllning**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en enfärgsfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) till `Solid`.
1. Tilldela den önskade fyllningsfärgen till formen.
1. Spara den ändrade presentationen som en PPTX-fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoshape av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ange fyllningstypen till Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Ange fyllningsfärgen.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Spara PPTX-filen till disk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![The shape with solid color fill](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en solid färg, gradient, bild eller texturfyllning på former, kan du också ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt blir delvis synliga.

Aspose.Slides låter dig ange transparensnivån genom att justera alfa‑värdet i färgen som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
1. Ange [FillType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) till `Solid`.
1. Använd [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) för att definiera en färg med transparens (komponenten `alpha` styr transparensen).
1. Spara presentationen.

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en solid rektangel-autoshape.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Lägg till en transparent rektangel-autoshape ovanpå den solida formen.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Spara PPTX-filen till disk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![The transparent shape](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifika justerings‑ eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
1. Ange formens roterings‑egenskap till önskad vinkel.
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoshape av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Rotera formen med 5 grader.
    shape.setRotation(5)

    # Spara PPTX-filen till disk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![The shape rotation](shape-rotation.png)

## **Lägg till 3D‑avfasningseffekter**

Aspose.Slides gör det möjligt att applicera 3D‑avfasningseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/)‑egenskaper.

För att lägga till 3D‑avfasningseffekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/) för att definiera avfasningsinställningarna.
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en form på bilden.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Ange formens ThreeDFormat‑egenskaper.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Spara presentationen som en PPTX‑fil.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![The 3D bevel effect](3D-bevel-effect.png)

## **Lägg till 3D‑roteringeﬀekter**

Aspose.Slides gör det möjligt att applicera 3D‑roteringeﬀekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/threedformat/)‑egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) på bilden.
1. Använd metoderna [setCameraType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/camera/#setCameraType) och [setLightType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/lightrig/#setLightType) för att definiera 3D‑rotationen.
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Spara presentationen som en PPTX-fil.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![The 3D rotation effect](3D-rotation-effect.png)

## **Styr svart‑vit rendering för former**

Metoden [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setBlackWhiteMode) anger hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vitt läge. Den aktiverar inte svart‑vit visning i sig själv, och den ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från klassen [BlackWhiteMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` rendering‑applikationen välja konvertering, `Gray` och `LightGray` använder grå färgning, `BlackWhite` använder endast svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning, och `Hidden` utelämnar formen i svart‑vitt läge. `NotDefined` betyder att inget läge har tilldelats på formnivå.

Följande Python‑kod skapar en färgad form och får den att visas grå i svart‑vitt visningsläge:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Behåll den orange fyllningen i färgläge, men rendera formen med grå färgning i svart-vitt läge.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett arbetsflöde med svart‑vit visning använder den grå färg eftersom dess läge är satt till `Gray`. Detta låter dig behålla en fullfärgs‑slide samtidigt som du definierar ett distinkt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vita visningsinställningar.

## **Återställ formatering**

Följande Python‑kod visar hur du återställer formateringen av en slide och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/) till deras standardinställningar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Återställ varje form på bilden som har en platshållare på layouten.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Påverkar formateringen av former den slutliga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media tar upp största delen av filens storlek, medan formparametrar såsom färger, effekter och gradienter lagras som metadata och lägger i praktiskt taget ingen extra storlek.

**Hur kan jag upptäcka former på en slide som delar identisk formatering så att jag kan gruppera dem?**

Jämför varje formas nyckelformaterings‑egenskaper – fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt de formerna, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑slide‑uppsättning eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de stylade formerna du behöver och återapplicera deras formatering där det krävs.