---
title: Skapa 3D‑effekter i presentationer med Python
linktitle: 3D‑presentation
type: docs
weight: 232
url: /sv/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑presentation
- 3D‑rotation
- 3D‑djup
- 3D‑extrusion
- 3D‑gradient
- 3D‑text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Tillämpa och rendera 3D‑effekter för PowerPoint‑former och -text i Python med Aspose.Slides. Konfigurera kamera, belysning, material, extrusion, fyllningar och 3D‑text."
---
## **Översikt**

Aspose.Slides för Python via .NET kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Den här artikeln behandlar 3D‑effekter såsom rotation, extrusion, avfasningar, ljussättning, material, gradient‑ eller bildfyllningar samt 3D‑text.

{{% alert color="primary" %}}
Den här artikeln handlar om 3D‑formateringseffekter på PowerPoint‑former och -text. Den handlar inte om att infoga eller redigera fristående 3D‑modelfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter till den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd egenskapen [Shape.three_d_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/three_d_format/) för att tillämpa 3D‑formatering på en form. Egenskapen exponerar [ThreeDFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/), som styr 3D‑scenen för den formen.

För text, använd egenskapen [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/three_d_format/). Detta tillämpar 3D‑formatering på textramen istället för på formens kropp.

De viktigaste egenskaperna är:

| Egenskap | Vad den styr | När den ska användas |
|---|---|---|
| [camera](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/camera/) | Vypunkt, förinställd kamtyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rummet eller matcha en förinställd PowerPoint‑3D‑rotation. |
| [light_rig](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/light_rig/) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [material](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/material/) | Ytmaterial, t.ex. platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [extrusion_height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/extrusion_height/) | Hur långt formen sträcker sig bakåt från sin främre yta. | Omvandla en platt form till ett tydligt tjockt 3D‑objekt. |
| [extrusion_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/extrusion_color/) | Färg på extruderade sidor. | Gör djupet synligt eller koordinera sidfärgen med frontfyllningen. |
| [depth](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/depth/) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djup för former eller text, särskilt i kombination med avfasning och materialinställningar. |
| [bevel_top](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/bevel_bottom/) | Upphöjda eller rundade kanter på fram- och bakytorna. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [contour_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/contour_width/) | Kontur runt 3D‑objektet. | Markera objektets gräns i den renderade utdata. |

## **Skapa en 3D‑form**

- Kamerainställningar, eftersom standardframsidan kan dölja extrusionen.  
- Ljusinställningar, eftersom belysning gör ytorna och sidorna läsbara.  
- Materialinställningar, eftersom ytan påverkar hur ljus renderas.  
- Extrusion‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess främre yta, tillämpar 3D‑formatering, sparar presentationen som PPTX och renderar bilden till en PNG‑fil.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

Den renderade bildfilen visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på den främre ytan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation i rutan 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du ställer in via kamera‑API:et.

![PowerPoint 3‑D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

I Aspose.Slides ställer du in kameratyp och rotation via [ThreeDFormat.camera](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Använd kameran när du behöver ändra hur betraktaren ser objektet. Den ändrar inte 2D‑formgeometrin på bilden. Den ändrar 3D‑vyvinkeln som används av PowerPoint och av Aspose.Slides vid renderingen.

## **Lägg till extrusion och djup**

Extrusion får en form att se tjock ut genom att sträcka den bakom den främre ytan. I PowerPoint styr djupkontrollen den synliga tjockleken, och färgkontrollen anger färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till egenskaperna extrusion‑färg och extrusion‑höjd](img_02_02.png)

Ställ in [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/extrusion_height/) för tjockleken och [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/extrusion_color/) för sidfärgen:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Använd [ThreeDFormat.depth](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/depth/) när du behöver arbeta direkt med PowerPoints djupvärde eller kombinera djup med avfasning, material och texteffekter. I många former är [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/extrusion_height/) den tydligare inställningen eftersom den uttrycker den synliga extrusionen direkt.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan tillämpa en solid färg, gradient, mönster eller bildfyllning på den främre ytan och fortfarande använda samma kamera‑, ljus‑, material‑ och extrusion‑inställningar.

Detta exempel applicerar en gradientfyllning på formen och en mörkare extrusion‑färg på sidorna:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

Den renderade utdata behåller gradienten på den främre ytan och renderar extrusionen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrusion](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Bilden renderas på den främre ytan, medan extrusionen renderas som den 3D‑sidoytan:

![Renderad 3D‑rektangel med ett foto som fyllning på den främre ytan och orange extrusion](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

Formens 3D‑formatering påverkar formens kropp. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där själva bokstäverna behöver extrusion, material, belysning och kamerainställningar.

Följande exempel skapar text med ett mönsterfyllning, applicerar en WordArt‑transformering och konfigurerar 3D‑inställningar på [TextFrameFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/):

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

Texten renderas som böjda, extruderade 3D‑bokstäver:

![Renderad 3D‑text med en bågformad WordArt‑transformering, orange mönsterfyllning och mörk extrusion](img_02_05.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när du sparar till PowerPoint‑format som PPTX. Vid renderning eller export till fasta layout‑format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/python-net/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/python-net/convert-powerpoint-to-html/), eller genererar bildrutor för [video conversion](/slides/sv/python-net/convert-powerpoint-to-video/).

Kom ihåg följande punkter:

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrusion, fyllning och bildskala.
- Om du behöver granska ärvda eller temabaserade formateringsvärden, läs [effective shape properties](/slides/sv/python-net/shape-effective-properties/).
- Vissa exportformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stödjer det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrusion, avfasning, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum måste du ange en kamerarotation och antingen extrusion eller djup. I praktiken bör du även ange en ljusrigg och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag applicera 3D‑effekter på både former och text?**

Ja. Använd [Shape.three_d_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/three_d_format/) för formens kropp och [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/three_d_format/) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videobildrutor?**

Ja. Aspose.Slides renderar 3D‑effekter när du skapar bildrutor, PDF‑utdata, HTML‑utdata och bildrutor för videokonvertering. Den exporterade utdata innehåller den renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API‑erna som beskrivs i [Shape Effective Properties](/slides/sv/python-net/shape-effective-properties/) för att läsa slutgiltiga kamera-, ljusrigg-, avfasnings- och relaterade 3D‑värden.