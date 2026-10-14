---
title: Formatera PowerPoint-former i Python via Java
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/python-java/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss‑effekt
- skisslinje för form
- formatera föreningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formtransparens
- svart‑vit rendering av form
- gråskala rendering av form
- rotera form
- 3D‑avfasningseffekt
- 3D‑roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i Python via Java med Aspose.Slides—sätt fyllnings‑, linje‑ och effektstilar för PPT, PPTX och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java tillhandahåller klasser och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) på bilden.
1. Ställ in [linjestilen](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) för formen.
1. Ställ in linjebredden.
1. Ställ in [streckstilen](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) för linjen.
1. Ställ in linjefärgen för formen.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande kod visar hur man formaterar en rektangel [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instansiera Presentation-klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoform av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Ställ in fyllningsfärgen för rektangelformen.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Tillämpa formatering på rektangelns linjer.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Ställ in färgen för rektangelns linje.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Spara PPTX-filen till disk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Tillämpa skiss‑effekter på formlinjer**

En skisseffekt får en formlinje att se handritad ut. Använd [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) för att komma åt linjeinställningarna, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) för att komma åt skissinställningarna och [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Följande Python‑kod visar hur man tillämpar en [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved)-effekt, läser det explicit tilldelade värdet och tar bort effekten med [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None):

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

    # Tillämpa en skiss‑effekt.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Läs av skiss‑effekten som tilldelats direkt till formen.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Ta bort skiss‑effekten.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Värdet som returneras av [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType) representerar den inställning som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, en master‑bild eller en layout‑bild, använd [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective), åtkomst `LineFormatEffectiveData.getSketchFormat` och läs `SketchFormatEffectiveData.getSketchType`. Det effektiva värdet speglar den formatering som faktiskt tillämpas efter arv har lösts:

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

## **Formatera föreningsstilar**

Här är de tre alternativen för föreningstyp:

* Rund
* Miter
* Avfasad

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en forms hörn), använder den inställningen **Rund**. Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Miter**.

![Föreningsstilen i presentationen](join-style-powerpoint.png)

Följande Python‑kod demonstrerar hur tre rektanglar (visa på bilden ovan) skapades med Miter‑, Avfasad‑ och Rund‑inställningarna:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instansiera Presentation‑klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till tre autoformer av typen Rectangle.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Ställ in fyllningsfärgen för varje rektangelform.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Ställ in linjebredden.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Ställ in färgen för varje rektangels linje.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Ställ in föreningsstilen.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Lägg till text i varje rektangel.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Spara PPTX‑filen till disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du applicera två eller flera färger på ett sätt där den ena gradvis tonas ut i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två föredragna färger med definierade positioner med metoden [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) i gradientstopp‑samlingen som exponeras av klassen [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/).
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande Python‑kod demonstrerar hur du applicerar en gradientfyllning på en ellips:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instansiera Presentation‑klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoform av typen Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Tillämpa gradientformatering på ellipsen.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Ställ in gradientens riktning.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Lägg till två gradientstopp.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Spara PPTX‑filen till disk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

Om en gradient ser annorlunda ut i en exporterad bild än i PowerPoint, se [Välj en gradientrenderingsstil](/slides/sv/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en renderingsstil utan att ändra gradientfyllningen som lagras i presentationen.

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera ett tvåfärgs‑mönster—såsom prickar, ränder, korshatch eller rutnät—på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra dina presentationers visuella uttryck. Även efter att du har valt ett fördefinierat mönster kan du fortfarande ange exakt vilka färger det ska använda.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ställ in [Bakgrundsfärg](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) för mönstret.
1. Ställ in [Förgrundsfärg](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) för mönstret.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande Python‑kod demonstrerar hur du applicerar en mönsterfyllning på en rektangel:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instansiera Presentation‑klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoform av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ställ in fyllningstypen till Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Ställ in mönsterstilen.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Ställ in mönstrets bakgrunds‑ och förgrundsfärger.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Spara PPTX‑filen till disk.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form—i praktiken använder du bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) till `Picture`.
1. Ställ in bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/)-objekt från den bild du vill använda.
1. Skicka bilden till metoden `SlidesPicture.setImage`.
1. Spara den modifierade presentationen som en PPTX‑fil.

Anta att vi har filen "lotus.png" med följande bild:

![Lotusbilden](lotus.png)

Följande Python‑kod demonstrerar hur du fyller en form med bilden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Instansiera Presentation‑klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoform av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Ställ in fyllningstypen till Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Ställ in bildfyllningsläget.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Läs in en bild och lägg till den i presentationens resurser.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Ställ in bilden.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Spara PPTX‑filen till disk.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Tile Bild som Textur**

Om du vill ange en tilad bild som en textur och anpassa tilningsbeteendet kan du använda följande metoder i klassen [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): Ställer in bildfyllningsläget—antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): Anger justeringen av plattorna inom formen.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): Styr om plattan vänds horisontellt, vertikalt eller båda.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): Ställer in den horisontella offseten för plattan (i punkter) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): Ställer in den vertikala offseten för plattan (i punkter) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): Definierar den horisontella skalan för plattan som en procentandel.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): Definierar den vertikala skalan för plattan som en procentandel.

Följande kodexempel visar hur du lägger till en rektangelform med en tilad bildfyllning och konfigurerar til‑alternativen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Instansiera Presentation‑klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    first_slide = presentation.getSlides().get_Item(0)

    # Lägg till en rektangel‑autoform.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Ställ in fyllningstypen för formen till Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Läs in bilden och lägg till den i presentationens resurser.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Tilldela bilden till formen.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Konfigurera bildfyllningsläget och tilnings‑egenskaperna.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Spara PPTX‑filen till disk.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Tile‑alternativen](tile-options.png)

## **Solid färgfyllning**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, jämn färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en solid färgfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) till `Solid`.
1. Tilldela din föredragna fyllningsfärg till formen.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande Python‑kod demonstrerar hur du applicerar en solid färgfyllning på en rektangel i en PowerPoint‑bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instansiera Presentation‑klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoform av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Ställ in fyllningstypen till Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Ställ in fyllningsfärgen.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Spara PPTX‑filen till disk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Formen med solid färgfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en solid färg, gradient, bild eller texturfyllning på former, kan du också ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ange transparensnivån genom att justera alfa‑värdet i färgen som används för fyllningen. Så gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) på bilden.
1. Ställ in [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) till `Solid`.
1. Använd [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) för att definiera en färg med transparens (alfa‑komponenten styr transparensen).
1. Spara presentationen.

Följande Python‑kod demonstrerar hur du applicerar en transparent fyllningsfärg på en rektangel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instansiera Presentation‑klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en solid rektangel‑autoform.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Lägg till en transparent rektangel‑autoform ovanpå den solida formen.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Spara PPTX‑filen till disk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifik justering eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens rotations‑egenskap till önskad vinkel.
1. Spara presentationen.

Följande Python‑kod demonstrerar hur du roterar en form med 5 grader:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instansiera Presentation‑klassen som representerar en presentationsfil.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en autoform av typen Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Rotera formen med 5 grader.
    shape.setRotation(5)

    # Spara PPTX‑filen till disk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![Formrotationen](shape-rotation.png)

## **Lägg till 3D‑avfasningseffekter**

Aspose.Slides gör det möjligt att tillämpa 3D‑avfasningseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)-egenskaper.

För att lägga till 3D‑avfasningseffekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) för att definiera avfasningsinställningarna.
1. Spara presentationen.

Följande Python‑kod visar hur du applicerar 3D‑avfasningseffekter på en form:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation‑klassen.
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

    # Ställ in formens ThreeDFormat‑egenskaper.
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

![3D‑avfasningseffekten](3D-bevel-effect.png)

## **Lägg till 3D‑rotations‑effekter**

Aspose.Slides låter dig tillämpa 3D‑rotationseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/)-egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) på bilden.
1. Använd metoderna [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) och [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) för att definiera 3D‑rotationen.
1. Spara presentationen.

Följande Python‑kod demonstrerar hur du applicerar 3D‑rotationseffekter på en form:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Skapa en instans av Presentation‑klassen.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Spara presentationen som en PPTX‑fil.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Resultatet:

![3D‑rotations‑effekten](3D-rotation-effect.png)

## **Kontrollera svart‑vit rendering för former**

Metoden [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) specificerar hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vit läge. Den aktiverar inte svart‑vit visning i sig och ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från klassen [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konverteringen, `Gray` och `LightGray` använder grå färgning, `BlackWhite` använder endast svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning, och `Hidden` utesluter formen i svart‑vit läge. `NotDefined` betyder att inget form‑specifikt läge är tilldelat.

Följande Python‑kod skapar en färgad form och får den att visas grå i svart‑vit visningsläge:

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

I normalt färgläge behåller rektangeln sin orange fyllning. I ett arbetsflöde med svart‑vit visning använder den grå färgning eftersom dess läge är satt till `Gray`. Detta låter dig bevara en färgrik bild samtidigt som du definierar ett särskilt utseende för utskrift, förhandsgranskning eller andra arbetsflöden som hedrar presentationens svart‑vita visningsinställningar.

## **Återställ formatering**

Följande Python‑kod visar hur du återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) till deras standardinställningar:

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

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media tar upp största delen av filutrymmet, medan formparametrar såsom färger, effekter och gradienter lagras som metadata och tillför praktiskt taget ingen extra storlek.

**Hur kan jag identifiera former på en bild som delar identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings‑egenskaper—fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar till en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempel­former med önskade stilar i en mall‑presentationsfil eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de stylade former du behöver och återapplicera deras formatering där den behövs.