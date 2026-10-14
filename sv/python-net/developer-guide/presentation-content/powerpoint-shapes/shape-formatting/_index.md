---
title: Formatera PowerPoint‑former i Python
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/python-net/shape-formatting/
keywords:
- formatera form
- formatera linje
- skisseffekt
- skisslinje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formtransparens
- svart‑vit rendering av form
- gråskala rendering av form
- rotera form
- 3D bevel‑effekt
- 3D rotations‑effekt
- återställ formatering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i Python med Aspose.Slides—ange fyllnings‑, linje‑ och effektstilar för PPT-, PPTX‑ och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för Python tillhandahåller klasser och egenskaper som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver förfarandet:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) på bilden.
1. Ange [linjestil](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [streckstil](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) för formen.
1. Ange linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Python‑kod visar hur du formaterar en rektangel `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiera Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Rektangel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Ta bort fyllningen från rektangelformen så att endast dess linjer är synliga.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Applicera formatering på rektangelns linjer.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Ange färgen för rektangelns linje.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Spara PPTX‑filen till disken.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Applicera skiss‑effekter på formlinjer**

En skiss‑effekt får en formlinje att se handritad ut. Använd [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) för att komma åt linjeinställningarna, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) för att komma åt skissinställningarna och [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Följande Python‑kod visar hur du applicerar en [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/)‑effekt, läser det explicit tilldelade värdet och tar bort effekten med [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Åtkomst till formens linjeformat och dess skissformat.
    sketch_format = shape.line_format.sketch_format

    # Applicera en skiss‑effekt.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Läs den skiss‑effekt som tilldelats direkt till formen.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Ta bort skiss‑effekten.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Det värde som returneras av `SketchFormat.sketch_type` representerar inställningen som tilldelats direkt till formen. Om linjeformateringen kan ärvas från ett tema, en mästar‑slide eller en layout‑slide, använd [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), nå den returnerade objektets `sketch_format`‑egenskap och läs dess `sketch_type`‑egenskap. Det effektiva värdet speglar den formatering som faktiskt appliceras efter att arv har lösts:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Formatera anslutningsstilar**

Här är de tre alternativen för anslutningstyp:

* Rund
* Miter
* Bevel

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formhörn), använder den inställningen **Rund**. Men om du ritar en form med skarpa vinklar kan du föredra alternativet **Miter**.

![Anslutningsstilen i presentationen](join-style-powerpoint.png)

Följande Python‑kod visar hur tre rektanglar (som visas på bilden ovan) skapades med Miter‑, Bevel‑ och Rund‑inställningarna för anslutningstyp:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiera Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

	# Hämta den första bilden.
	slide = presentation.slides[0]

	# Lägg till tre autoformer av typen Rektangel.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Sätt fyllningsfärgen för varje rektangelform.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Sätt linjebredden.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Sätt färgen för varje rektangels linje.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Sätt anslutningsstilen.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Lägg till text i varje rektangel.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Spara PPTX‑filen till disken.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du applicera två eller fler färger så att den ena gradvis tonas ner i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) till `GRADIENT`.
1. Lägg till dina två önskade färger med definierade positioner genom att använda `add`‑metoderna i samlingen `gradient_stops` som exponeras av klassen [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/).
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Python‑kod visar hur du applicerar en gradientfyllning på en ellips:

```python
import aspose.slides as slides

# Instansiera Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Ellips.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Applicera gradientformatering på ellipsen.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Ange gradientens riktning.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Lägg till två gradientstopp.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Spara PPTX‑filen till disken.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

Om en gradient ser annorlunda ut i en exporterad bild än i PowerPoint, se [Choose a Gradient Rendering Style](/slides/sv/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en renderingsstil utan att ändra gradientfyllningen som lagras i presentationen.

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera ett tvåfärgs‑mönster — såsom prickar, ränder, korshatch eller rutnät — på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides tillhandahåller över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra det visuella intrycket i dina presentationer. Även efter att du har valt ett fördefinierat mönster kan du ange exakt vilka färger som ska användas.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) till `PATTERN`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ange [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) för mönstret.
1. Ange [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) för mönstret.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Python‑kod visar hur du applicerar en mönsterfyllning på en rektangel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiera Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Rektangel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ange fyllningstypen till Mönster.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Ange mönsterstilen.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Ange mönstrets bakgrunds- och förgrundsfärger.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Spara PPTX‑filen till disken.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form — på så sätt använder du bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) till `PICTURE`.
1. Ange bildfyllningsläget till `TILE` (eller ett annat föredraget läge).
1. Skapa ett [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑objekt från den bild du vill använda.
1. Tilldela denna bild till egenskapen `picture.image` i formens `picture_fill_format`.
1. Spara den ändrade presentationen som en PPTX‑fil.

Låt oss säga att vi har en fil **lotus.png** med följande bild:

![Lotus‑bilden](lotus.png)

Följande Python‑kod visar hur du fyller en form med bilden:

```python
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Rektangel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Ange fyllningstypen till Bild.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Ange bildfyllningsläget.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Läs in en bild och lägg till den i presentationens resurser.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Ange bilden.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Spara PPTX-filen till disken.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Tile Picture As Texture**

Om du vill ange en kaklad bild som textur och anpassa kaklingsbeteendet kan du använda följande egenskaper i klassen [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Anger bildfyllningsläget — antingen `TILE` eller `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Anger justeringen av kaklorna inom formen.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Styr om kakeln flippar horisontellt, vertikalt eller båda.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Anger horisontell offset för kakeln (i punkter) från formens origin.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Anger vertikal offset för kakeln (i punkter) från formens origin.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definierar horisontell skala för kakeln i procent.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definierar vertikal skala för kakeln i procent.

Följande kodexempel visar hur du lägger till en rektangulär form med en kaklad bildfyllning och konfigurerar kaklingsalternativen:

```py
import aspose.slides as slides

# Instansiera Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    first_slide = presentation.slides[0]

    # Lägg till en rektangel‑autofom.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Ange fyllningstypen för formen till Bild.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Läs in bilden och lägg till den i presentationens resurser.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Tilldela bilden till formen.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Konfigurera bildfyllningsläget och kaklings‑egenskaperna.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Spara PPTX‑filen till disken.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Kaklingsalternativen](tile-options.png)

## **Solid Color Fill**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en solid färgfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) till `SOLID`.
1. Tilldela din föredragna fyllningsfärg till formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Python‑kod visar hur du applicerar en solid färgfyllning på en rektangel i en PowerPoint‑slide:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiera Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Rektangel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ange fyllningstypen till Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Ange fyllningsfärgen.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Spara PPTX‑filen till disken.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Formen med solid färgfyllning](solid-color-fill.png)

## **Set Transparency**

I PowerPoint, när du applicerar en solid färg, gradient, bild eller texturfyllning på former, kan du också ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ställa in transparensnivån genom att justera alfa‑värdet i den färg som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) på bilden.
1. Ange fyllningstypen till `SOLID`.
1. Använd `Color.from_argb` för att definiera en färg med transparens (alfa‑komponenten styr transparensen).
1. Spara presentationen.

Följande Python‑kod visar hur du applicerar en transparent fyllningsfärg på en rektangel:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instansiera Presentation‑klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]
    
    # Lägg till en solid rektangel‑autoform.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Lägg till en transparent rektangel‑autoform ovanpå den solida formen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den transparenta formen](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifik justering eller designbehov.

För att rotera en form på en slide, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) på bilden.
1. Sätt formens `rotation`‑egenskap till önskad vinkel.
1. Spara presentationen.

Följande Python‑kod visar hur du roterar en form med 5 grader:

```python
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Rektangel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Rotera formen med 5 grader.
    shape.rotation = 5

    # Spara PPTX-filen till disken.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Formrotationen](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides låter dig applicera 3D‑bevel‑effekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)‑egenskaper.

För att lägga till 3D‑bevel‑effekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) för att definiera bevel‑inställningarna.
1. Spara presentationen.

Följande Python‑kod visar hur du applicerar 3D‑bevel‑effekter på en form:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Lägg till en form på bilden.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Ange formens ThreeDFormat-egenskaper.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Spara presentationen som en PPTX-fil.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![3D‑bevel‑effekten](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides låter dig applicera 3D‑rotations‑effekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)‑egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) på bilden.
1. Ange formens [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) och [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) för att definiera 3D‑rotationen.
1. Spara presentationen.

Följande Python‑kod visar hur du applicerar 3D‑rotations‑effekter på en form:

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Spara presentationen som en PPTX-fil.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![3D‑rotations‑effekten](3D-rotation-effect.png)

## **Control Black-and-White Rendering for Shapes**

Egenskapen [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) specificerar hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vitt‑läge. Den aktiverar inte svart‑vitt‑visning i sig och ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från uppräkningen [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `AUTOMATIC` renderingsprogrammet välja konverteringen, `GRAY` och `LIGHT_GRAY` använder grå nyanser, `BLACK_WHITE` använder endast svart och vitt, `BLACK` och `WHITE` tvingar en enda färg, `COLOR` bevarar normal färgning, och `HIDDEN` utesluter formen i svart‑vitt‑läge. `NOT_DEFINED` betyder att inget form‑nivåläge är tilldelat.

Följande Python‑kod skapar en färgad form och får den att visas grå i svart‑vitt‑visningsläge:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Behåll den orange fyllningen i färgläge, men rendera formen med grå färgning i svart-vitt läge.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett arbetsflöde med svart‑vitt‑visning använder den grå färg eftersom dess läge är satt till `GRAY`. Detta låter dig bevara en färgrik slide samtidigt som du definierar ett separat utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vitt‑visningsinställningar.

## **Reset Formatting**

Följande Python‑kod visar hur du återställer formateringen av en slide och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) till deras standardinställningar:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Återställ varje form på bilden som har en platshållare på layouten.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media utgör huvuddelen av filstorleken, medan formparametrar såsom färger, effekter och gradienter lagras som metadata och tillför praktiskt taget ingen extra storlek.

**Hur kan jag identifiera former på en slide som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms nyckelformaterings‑egenskaper — fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i ett mall‑slide‑paket eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de stylade former du behöver och återapplicera deras formatering där det krävs.