---
title: Skapa 3D-effekter i presentationer med Python
linktitle: 3D-presentation
type: docs
weight: 232
url: /sv/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentation
- 3D-rotation
- 3D-djup
- 3D-extrudering
- 3D-gradient
- 3D-text
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Tillämpa och rendera 3D-effekter för PowerPoint-former och -text i Python med Aspose.Slides. Konfigurera kamera, belysning, material, extrudering, fyllningar och 3D-text."
---
## **Översikt**

Aspose.Slides for Python via .NET kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel täcker 3D‑effekter såsom rotation, extrusion, avfasning, belysning, material, gradient‑ eller bildfyllning samt 3D‑text.

{{% alert color="info" title="Note" %}}
Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och text. Den handlar inte om att infoga eller redigera fristående 3D‑modelfiler. När du exporterar en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formatkoncept**

Använd egenskapen [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) för att tillämpa 3D‑formatering på en form. Egenskapen exponerar [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/), som styr 3D‑scenen för den formen.

För text, använd egenskapen [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Detta tillämpar 3D‑formatering på textramen istället för på formkroppen.

De viktigaste egenskaperna är:

| Egenskap | Vad den styr | När den ska användas |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Visningspunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rymden eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Ljusetapet, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Ytmaterial, t.ex. platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Hur långt formen sträcker sig bakåt från dess främre yta. | Omvandla en platt form till ett tydligt tjockt 3D‑objekt. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidornas färg med frontfyllningen. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djupet för former eller text, särskilt i kombination med avfasning‑ och materialinställningar. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) och [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Upphöjda eller avrundade kanter på fram- och baksidorna. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) och [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Kontur runt 3D‑objektet. | Betona objektets gräns i den renderade utskriften. |

## **Skapa en 3D‑form**

- Kamerainställningar, eftersom standardframsidan kan dölja extrusionen.  
- Ljusinställningar, eftersom belysning gör ansiktena och sidorna läsbara.  
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.  
- Extrusion‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på framsidan och tillämpar 3D‑formatering. Kamera‑rotationsvärdena är i grader och extrusion‑höjden är 100 punkter. Exemplet renderar bilden till en PNG‑fil med dubbla standardmått och sparar presentationen som PPTX.

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

![Renderad blå 3D‑rektangel med vit 3D‑text på framsidan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation i panelen 3‑D‑Rotation. Rotationsvärdena för X, Y och Z motsvarar rotationen du ställer in via kamera‑API‑et.

![PowerPoint‑panel för 3‑D‑Rotation med X, Y och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides får du åtkomst till kameran via [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/). Detta exempel skapar en rektangel, väljer en ortografisk frontvy och sätter X‑, Y‑ och Z‑rotationerna till 20, 30 respektive 40 grader. Det konfigurerar formen i minnet utan att spara en fil:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Använd kameran när du behöver ändra hur betraktaren ser objektet. Det ändrar inte 2D‑geometrin på bilden. Det ändrar 3D‑vy­punkten som PowerPoint och Aspose.Slides använder vid rendering.

### **Kopiera kameraorientering från en mallform**

För att matcha en mallforms orientering, kopiera dess [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/)‑förinställning och läs rotationen med [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). Exemplet öppnar `template.pptx` och kopierar kameraorienteringen från den första formen på den första bilden till den andra formen. Båda formerna har redan 3D‑ljus, och den andra formen har ingen explicit kamerarotation.

Vinklarna är i grader. Indexen `0`, `1` och `2` innehåller respektive latitud, longitud och varv. Skicka dem till [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) i den ordningen. Om källan saknar explicit rotation returnerar `get_rotation` `None`, så lämna destinationsvinklarna odefinierade. Om källan explicit sätter alla tre vinklar till noll, kopiera dessa nollor.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

När du öppnar om `camera-copy.pptx` i PowerPoint har båda formerna samma kamera‑förinställning och rotation. Pil‑ikonen till höger använder orienteringen kopierad från rektangeln till vänster. Båda formerna använder samma ljus och extrusion‑djup.

![En blå 3D‑rektangel och en högerpil med matchande kameraorientering, sedd ovanifrån och från höger](camera-orientation.png)

## **Lägg till extrusion och djup**

Extrusion får en form att se tjock ut genom att den sträcker sig bakom framsidan. I PowerPoint bestämmer djup‑kontrollen den synliga tjockleken och färg‑kontrollen färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till extrusion‑färg och extrusion‑höjd‑egenskaper](img_02_02.png)

Ange [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) för tjockleken och [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) för sidofärgen. Detta exempel ger en rektangel en 100‑punkts extrusion med lila sidor och roterar kameran för att visa tjockleken. Det konfigurerar formen i minnet utan att spara en fil:

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

[ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)‑egenskapen anger djupet för en 3D‑form. [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/)‑egenskapen styr höjden på extrusion‑effekten, vilket visas i detta exempel.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en solid färg, gradient, mönster eller bildfyllning på framsidan och fortfarande använda samma kamera, ljus, material och extrusion‑inställningar.

Detta exempel applicerar en blå‑till‑orange gradient på framsidan och en mörkorange färg på den 150‑punkts extrusionen. Gradient‑stopp vid 0 och 100 markerar början och slutet på gradienten. Kamera‑rotationsvärdena är i grader. Bilden renderas till en PNG‑fil med dubbla standardmått:

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

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrusion](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning. Detta exempel kräver en befintlig fil med namn “image.jpg” i arbetskatalogen. Bilden sträcks för att fylla rektangeln, applicerar en 150‑punkts extrusion och sätter kamera‑rotationen i grader. Det konfigurerar formen i minnet utan att spara eller rendera en fil:

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

![Renderad 3D‑rektangel med ett foto på framsidan och orange extrusion](img_02_04.png)

## **Applicera 3D‑formatering på text**

Formens 3D‑formatering påverkar formkroppen. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrusion, material, belysning och kamera‑inställningar.

Följande exempel skapar text med ett orange‑och‑vitt rutnätsmönster, applicerar en uppåtböjd båge och konfigurerar 3D‑inställningarna via [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Extrusion‑höjd och djup är i punkter och ljus‑rotation i grader. Formens fyllning och kontur är dolda så att endast texten syns. Exemplet renderar en PNG‑bild med dubbla standardmått och sparar presentationen som PPTX:

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

![Renderad 3D‑text med en uppåtböjd WordArt‑transformering, orange mönsterfyllning och mörk extrusion](img_02_05.png)

## **Behåll texten platt på en 3D‑form**

För att hålla text läsbar samtidigt som du bevarar en forms 3D‑utseende, ange [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) via [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). När värdet är `True` hålls texten utanför 3D‑scenen. När det är `False` deltar texten i scenen och följer dess 3D‑orientering.

Denna inställning tar inte bort formens 3D‑formatering: dess kamera, belysning, material och extrusion förblir konfigurerade via [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/). Den skiljer sig också från vanlig rotation. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) roterar formen i bildplanet, medan [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) styr textens anpassade rotation inom sin begränsningsruta. Att hålla texten utanför 3D‑scenen återställer inte någon av dessa vinklar.

Följande fristående exempel skapar en blå rektangel med text och klonar den bredvid originalet. Båda formerna har samma 3D‑formatering; bara textinställningen skiljer sig: `False` på vänster och `True` på höger. Kamera‑vinklarna är i grader och extrusion‑höjden är 40 punkter. Exemplet sparar presentationen som PPTX och renderar jämförelsesliden till PNG med dubbla standardmått.

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

På vänster sida följer texten 3D‑orienteringen. På höger sida förblir den platt och lättare att läsa. Båda rektanglarna behåller samma synliga extrusion och 3D‑orientering.

![Sida‑vid‑sida 3D‑rektanglar: keep_text_flat är False på vänster och True på höger](keep_text_flat.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när du sparar till PowerPoint‑format som PPTX. Vid rendering eller export till fast‑layout‑format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/python-net/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/python-net/convert-powerpoint-to-html/), eller genererar ramar för [video conversion](/slides/sv/python-net/convert-powerpoint-to-video/).

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.  
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrusion, fyllning och bildskalning.  
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs de [effective shape properties](/slides/sv/python-net/shape-effective-properties/).  
- Vissa exportformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet snarare än att bevaras som redigerbara 3D‑inställningar.

## **Vanliga frågor**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX‑formatet förblir 3D‑formateringen redigerbar i PowerPoint där formatet stöder det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrusion, avfasning, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Minst måste du sätta en kamerarotation och antingen extrusion eller djup. I praktiken bör du också ange en ljusrigg och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag applicera 3D‑effekter på både former och text?**

Ja. Använd [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) för formkroppen och [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) för text.

**Kommer 3D‑effekter att visas när man exporterar till bilder, PDF, HTML eller videoram?**

Ja. Aspose.Slides renderar 3D‑effekter när du skapar bildfiler, PDF‑utdata, HTML‑utdata och ramar som används för videokonvertering. Den exporterade utdata innehåller den renderade utsikten, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API:erna som beskrivs i [Shape Effective Properties](/slides/sv/python-net/shape-effective-properties/) för att läsa de slutgiltiga kamera‑, ljusrigg‑, avfasnings‑ och relaterade 3D‑värden.