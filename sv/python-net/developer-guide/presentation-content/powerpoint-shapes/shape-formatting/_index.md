---
title: Formatera PowerPoint‑former i Python
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/python-net/shape-formatting/
keywords:
- formatera form
- formatera linje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgsfyllning
- formtransparens
- rotera form
- 3D fasadeffekt
- 3D roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i Python med Aspose.Slides—ställ in fyllning, linje‑ och effektstilar för PPT-, PPTX- och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bildspel. Eftersom former består av linjer kan du formatera dem genom att ändra eller lägga till effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras innerväggar fylls.

![formatera form i PowerPoint](format-shape-powerpoint.png)

Aspose.Slides för Python tillhandahåller klasser och egenskaper som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Ange [line style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [dash style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/linedashstyle/) för formen.
1. Ange linjefärgen för formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Python‑kod demonstrerar hur man formaterar en rektangel `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Rektangel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Ställ in fyllningsfärgen för rektangelformen.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Applicera formatering på rektangelns linjer.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Ställ in färgen för rektangelns linje.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Spara PPTX-filen till disk.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Formatera anslutningsstilar**

Här är de tre alternativen för anslutningstyp:

* Rund
* Miter
* Fas

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formens hörn), använder den inställningen **Round**. Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Miter**.

![Anslutningsstilen i presentationen](join-style-powerpoint.png)

Följande Python‑kod visar hur tre rektanglar (som visas i bilden ovan) skapades med Miter‑, Bevel‑ och Round‑inställningarna för anslutningstyp:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

	# Hämta den första bilden.
	slide = presentation.slides[0]

	# Lägg till tre autoformer av typen Rektangel.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Ställ in fyllningsfärgen för varje rektangelform.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Ställ in linjebredden.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Ställ in färgen för varje rektangels linje.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Ställ in anslutningsstilen.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Lägg till text i varje rektangel.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Spara PPTX-filen till disk.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Du kan t.ex. använda två eller flera färger så att den ena gradvis tonas ut i den andra.

Så här appliceras en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) till `GRADIENT`.
1. Lägg till dina två föredragna färger med definierade positioner med hjälp av `add`‑metoderna i `gradient_stops`‑samlingen som exponeras av klassen [GradientFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/gradientformat/).
1. Spara den ändrade presentationen som en PPTX‑fil.

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Ellips.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Applicera gradientformatering på ellipsen.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Ställ in riktningen för gradienten.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Lägg till två gradientstopp.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Spara PPTX-filen till disk.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign—t.ex. prickar, ränder, korsstreck eller rutmönster—på en form. Du kan välja anpassade färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra det visuella intrycket av dina presentationer. Även efter att ha valt ett fördefinierat mönster kan du ange exakt vilka färger som ska användas.

Så här appliceras en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) till `PATTERN`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ange [back_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/patternformat/back_color/) för mönstret.
1. Ange [fore_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/patternformat/fore_color/) för mönstret.
1. Spara den ändrade presentationen som en PPTX‑fil.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Rektangel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ställ in fyllningstyp till Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Ställ in mönsterstilen.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Ställ in mönstrets bakgrunds- och förgrundsfärger.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Spara PPTX-filen till disk.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form—effektivt använda bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) till `PICTURE`.
1. Ange bildfyllningsläget till `TILE` (eller ett annat föredraget läge).
1. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑objekt från bilden du vill använda.
1. Tilldela denna bild till egenskapen `picture.image` för formens `picture_fill_format`.
1. Spara den ändrade presentationen som en PPTX‑fil.

![Lotus‑bilden](lotus.png)

Följande Python‑kod demonstrerar hur man fyller en form med bilden:

```python
import aspose.slides as slides

    # Skapa en instans av Presentation-klassen som representerar en presentationsfil.
    with slides.Presentation() as presentation:

        # Hämta den första bilden.
        slide = presentation.slides[0]

        # Lägg till en autoform av typen Rektangel.
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

        # Ställ in fyllningstyp till Bild.
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # Ställ in bildfyllningsläget.
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

        # Läs in en bild och lägg till den i presentationens resurser.
        with slides.Images.from_file("lotus.png") as image:
            presentation_image = presentation.images.add_image(image)

        # Ställ in bilden.
        shape.fill_format.picture_fill_format.picture.image = presentation_image

        # Spara PPTX-filen till disk.
        presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Kakelbild som textur**

Om du vill använda en kaklad bild som textur och anpassa kaklingsbeteendet kan du använda följande egenskaper i klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Anger bildfyllningsläget—antingen `TILE` eller `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/tile_alignment/): Anger justeringen av kaklorna inom formen.
- [tile_flip](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/tile_flip/): Styr om kakeln vänds horisontellt, vertikalt eller båda.
- [tile_offset_x](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/tile_offset_x/): Anger den horisontella förskjutningen av kakeln (i punkter) från formens ursprung.
- [tile_offset_y](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/tile_offset_y/): Anger den vertikala förskjutningen av kakeln (i punkter) från formens ursprung.
- [tile_scale_x](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/tile_scale_x/): Definierar den horisontella skalan av kakeln som procent.
- [tile_scale_y](https://reference.aspose.com/slides/sv/python-net/aspose.slides/picturefillformat/tile_scale_y/): Definierar den vertikala skalan av kakeln som procent.

Följande kodexempel visar hur man lägger till en rektangel med kaklad bildfyllning och konfigurerar kakelalternativen:

```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    first_slide = presentation.slides[0]

    # Lägg till en rektangel autoform.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Ställ in fyllningstyp för formen till Bild.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Läs in bilden och lägg till den i presentationens resurser.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Tilldela bilden till formen.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Konfigurera bildfyllningsläget och kaklagenskaperna.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Spara PPTX-filen till disk.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Kakelalternativen](tile-options.png)

## **Solid färgfyllning**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Den enkla bakgrundsfärgen appliceras utan några gradienter, texturer eller mönster.

För att applicera en enfärgsfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) till `SOLID`.
1. Tilldela din föredragna fyllningsfärg till formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande Python‑kod demonstrerar hur man applicerar en enfärgsfyllning på en rektangel i ett PowerPoint‑blad:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Rektangel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Ställ in fyllningstyp till Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Ställ in fyllningsfärgen.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Spara PPTX-filen till disk.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Formen med enfärgsfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en enfärgs-, gradient-, bild- eller texturfyllning på former, kan du även ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ställa in transparensnivån genom att justera alfa‑värdet i färgen som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Ange fyllningstyp till `SOLID`.
1. Använd `Color.from_argb` för att definiera en färg med transparens (alfa‑komponenten styr transparensen).
1. Spara presentationen.

Följande Python‑kod demonstrerar hur man applicerar en transparent fyllningsfärg på en rektangel:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]
    
    # Lägg till en solid rektangel autoform.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Lägg till en transparent rektangel autoform ovanpå den solida formen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när man placerar visuella element med specifika justeringar eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Ställ in formens `rotation`‑egenskap på önskad vinkel.
1. Spara presentationen.

Följande Python‑kod visar hur man roterar en form med 5 grader:

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar en presentationsfil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en autoform av typen Rektangel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Rotera formen med 5 grader.
    shape.rotation = 5

    # Spara PPTX-filen till disk.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Formroteringen](shape-rotation.png)

## **Lägg till 3D‑fasadeffekter**

Aspose.Slides låter dig applicera 3D‑fasadeffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/)-egenskaper.

För att lägga till 3D‑fasadeffekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/) för att definiera fasinställningar.
1. Spara presentationen.

Följande Python‑kod visar hur man applicerar 3D‑fasadeffekter på en form:

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

    # Ställ in formens ThreeDFormat-egenskaper.
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

![3D‑fasadeffekten](3D-bevel-effect.png)

## **Lägg till 3D‑roteringseffekter**

Aspose.Slides låter dig applicera 3D‑roteringseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/)-egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [camera_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/camera/camera_type/) och [light_type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/lightrig/light_type/) för att definiera 3D‑rotationen.
1. Spara presentationen.

Följande Python‑kod demonstrerar hur man applicerar 3D‑roteringseffekter på en form:

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

![3D‑roteringseffekten](3D-rotation-effect.png)

## **Återställ formatering**

Följande Python‑kod visar hur man återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/layoutslide/) till deras standardinställningar:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Återställ varje form på bilden som har en platshållare i layouten.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Endast marginellt. Bäddade bilder och media tar upp största delen av filstorleken, medan formparametrar såsom färger, effekter och gradienter lagras som metadata och tillför praktiskt taget ingen extra storlek.

**Hur kan jag identifiera former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms viktigaste formateringsegenskaper—fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, betraktas deras stilar som identiska och du kan logiskt gruppera dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑bildspelsuppsättning eller en .POTX‑mallfil. När du skapar en ny presentation öppnar du mallen, klonar de stylade former du behöver och återapplicerar deras formatering där det krävs.