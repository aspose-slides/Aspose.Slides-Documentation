---
title: Skapa 3D‑effekter i presentationer med Python
linktitle: 3D‑presentation
type: docs
weight: 232
url: /sv/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentation
- 3D-rotation
- 3D-djup
- 3D-extrusion
- 3D-gradient
- 3D-text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Tillämpar och renderar 3D‑effekter för PowerPoint‑former och text i Python med Aspose.Slides. Konfigurera kamera, belysning, material, extrusion, fyllningar och 3D‑text."
---
## **Översikt**

Aspose.Slides för Python via .NET kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Den här artikeln täcker 3D‑effekter såsom rotation, extrusion, fasader, belysning, material, gradient‑ eller bildfyllningar och 3D‑text.

{{% alert color="info" title="Note" %}}
Den här artikeln handlar om 3D‑formateringseffekter på PowerPoint‑former och text. Den handlar inte om att infoga eller redigera fristående 3D‑modellfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd egenskapen [Shape.three_d_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/three_d_format/) för att tillämpa 3D‑formatering på en form. Egenskapen exponerar [ThreeDFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/), som styr 3D‑scenen för den formen.

För text, använd egenskapen [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/three_d_format/). Detta tillämpar 3D‑formatering på textramen istället för formens kropp.

De viktigaste egenskaperna är:

| Egenskap | Vad den styr | När den ska användas |
|---|---|---|
| [camera](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/camera/) | Vypunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rummet eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [light_rig](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/light_rig/) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [material](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/material/) | Ytmaterial, såsom platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [extrusion_height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/extrusion_height/) | Hur långt formen sträcker sig bakåt från dess främre yta. | Omvandla en platt form till ett tydligt tjockt 3D‑objekt. |
| [extrusion_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/extrusion_color/) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidfärgen med frontfyllningen. |
| [depth](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/depth/) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djupet för former eller text, särskilt tillsammans med fasad‑ och materialinställningar. |
| [bevel_top](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/bevel_top/) och [bevel_bottom](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/bevel_bottom/) | Upphöjda eller avrundade kanter på främre och bakre ytor. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [contour_color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/contour_color/) och [contour_width](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/contour_width/) | Kontur runt 3D‑objektet. | Betona objektets gräns i den renderade utdata. |

## **Skapa en 3D‑form**

- Kamerainställningar, eftersom standardframsidan kan dölja extrusionen.
- Belysningsinställningar, eftersom ljus gör att ytorna och sidorna blir tydliga.
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.
- Extruderings‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess främre yta och tillämpar 3D‑formatering. Kamerarotationsvärdena är i grader och extruderingshöjden är 100 punkter. Exemplet renderar bilden till en PNG‑fil med dubbla standardmått och sparar presentationen som PPTX.

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

Den renderade bildbilden visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på den främre ytan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från rutan 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du anger via kamera‑API:et.

![PowerPoint‑rutan 3‑D‑Rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides nås kameran via [ThreeDFormat.camera](https://reference.aspose.com/slides/sv/python-net/aspose.slides/threedformat/camera/). Detta exempel skapar en rektangel, väljer en ortografisk frontvy och sätter dess X‑, Y‑ och Z‑rotationer till 20, 30 respektive 40 grader. Det konfigurerar formen i minnet utan att spara en fil:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Använd kameran när du behöver ändra hur betraktaren ser objektet. Den ändrar inte 2D‑formens geometri på sliden. Den ändrar 3D‑vyn som används av PowerPoint och av Aspose.Slides vid rendering.

## **Lägg till extrusion och djup**

Extrusion får en form att se tjock ut genom att den sträcker sig bakom den främre ytan. I PowerPoint ställer djupkontrollen in denna synliga tjocklek, och färgkontrollen anger färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till extruderingsfärg‑ och extruderingshöjd‑egenskaper](img_02_02.png)

Ange [ThreeDFormat.extrusion_height] för tjockleken och [ThreeDFormat.extrusion_color] för sidfärgen. Detta exempel ger en rektangel en 100‑punkts extrusion med lila sidor och roterar kameran för att avslöja dess tjocklek. Det konfigurerar formen i minnet utan att spara en fil:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

[ThreeDFormat.depth]-egenskapen anger djupet för en 3D‑form. [extrusion_height]-egenskapen styr höjden på extrusionseffekten, som visas i detta exempel.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan tillämpa en enhetlig färg, gradient, mönster eller bildfyllning på den främre ytan och fortfarande använda samma kamera-, ljus-, material- och extrusion‑inställningar.

Detta exempel applicerar en blå‑till‑orange gradient på den främre ytan och en mörk orange färg på 150‑punkts extruderingen. Gradientstopp vid 0 och 100 markerar start och slut på gradienten. Kamerarotationsvärdena är i grader. Sliden renderas till en PNG‑fil med dubbla standardmått:

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

Renderad 3D‑rektangel med blå‑till‑orange gradientfyllning och orange extrusion:

![Renderad 3D‑rektangel med blå‑till‑orange gradientfyllning och orange extrusion](img_02_03.png)

För att använda en bildfyllning istället lägg till bilden i presentationen och tilldela den till formens fyllning. Detta exempel kräver en befintlig fil med namn "image.jpg" i arbetskatalogen. Den sträcker bilden för att fylla rektangeln, tillämpar en 150‑punkts extrusion och anger kamerarotation i grader. Den konfigurerar formen i minnet utan att spara eller rendera en fil:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Renderad 3D‑rektangel med fotofyllning på den främre ytan och orange extrusion:

![Renderad 3D‑rektangel med fotofyllning på den främre ytan och orange extrusion](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

Formens 3D‑formatering påverkar formkroppen. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där själva bokstäverna behöver extrusion, material, belysning och kamerainställningar.

Följande exempel skapar text med ett orange‑och‑vitt rutmönster, tillämpar en uppåtböjd båge och konfigurerar 3D‑inställningarna via [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/three_d_format/). Extruderingshöjden och djupet är i punkter och ljusrotationen i grader. Formens fyllning och kontur döljes så att endast texten är synlig. Exemplet renderar en PNG‑fil med dubbla standardmått för sliden och sparar presentationen som PPTX:

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

Renderad 3D‑text med en bågformad WordArt‑transform, orange mönsterfyllning och mörk extrusion:

![Renderad 3D‑text med en bågformad WordArt‑transform, orange mönsterfyllning och mörk extrusion](img_02_05.png)

## **Behåll text platt på en 3D‑form**

För att hålla texten läsbar samtidigt som du bevarar en forms 3D‑utseende, ställ in [TextFrameFormat.keep_text_flat] via [TextFrame.text_frame_format]. När värdet är `True` hålls texten utanför 3D‑scenen. När det är `False` deltar texten i scenen och följer dess 3D‑orientering.

Denna inställning tar inte bort formens 3D‑formatering: dess kamera, belysning, material och extrusion förblir konfigurerade via [Shape.three_d_format]. Det skiljer sig också från vanlig rotation. [Shape.rotation] roterar formen i slidsplanet, medan [TextFrameFormat.rotation_angle] styr textens anpassade rotation inom dess omgivningsruta. Att hålla texten utanför 3D‑scenen återställer inte någon av dessa vinklar.

Följande fristående exempel skapar en blå rektangel med text och klonar den bredvid originalet. Båda formerna har samma 3D‑formatering; endast textinställningen skiljer sig: `False` till vänster och `True` till höger. Kamera‑vinklarna är i grader och extruderingshöjden är 40 punkter. Exemplet sparar presentationen som PPTX och renderar jämförelsesliden till PNG med dubbla standardmått:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

Sida‑vid‑sida 3D‑rektanglar: keep_text_flat är False till vänster och True till höger:

![Side-by-side 3D rectangles: keep_text_flat is False on the left and True on the right](keep_text_flat.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering vid sparande till PowerPoint‑format som PPTX. Vid rendering eller export till fasta layout‑format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar slidor till [PNG](/slides/sv/python-net/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/python-net/convert-powerpoint-to-html/), eller genererar ramar för [video conversion](/slides/sv/python-net/convert-powerpoint-to-video/).

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutliga utseendet beror på kombinationen av kamera, ljusrigg, material, extrusion, fyllning och bildskalning.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs [effective shape properties](/slides/sv/python-net/shape-effective-properties/).
- Vissa utdataformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint när formatet stödjer det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrusion, fasad, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Minst krävs en kamerarotation samt antingen extrusion eller djup. I praktiken bör även en ljusrigg och material ställas in så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag tillämpa 3D‑effekter på både former och text?**

Ja. Använd [Shape.three_d_format] för formkroppen och [TextFrameFormat.three_d_format] för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videoramar?**

Ja. Aspose.Slides renderar 3D‑effekter när slide‑bilder, PDF‑utdata, HTML‑utdata och ramar för video‑konvertering produceras. Den exporterade utdata innehåller den renderade bilden, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutliga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API:erna som beskrivs i [Shape Effective Properties] för att läsa de slutgiltiga kamera‑, ljusrigg‑, fasad‑ och relaterade 3D‑värdena.