---
title: Maak 3D‑effecten in presentaties met Python
linktitle: 3D‑presentatie
type: docs
weight: 232
url: /nl/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑presentatie
- 3D‑rotatie
- 3D‑diepte
- 3D‑extrusie
- 3D‑kleurverloop
- 3D‑tekst
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Pas 3D‑effecten toe en render ze voor PowerPoint‑vormen en -tekst in Python met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D‑tekst."
---
## **Overzicht**

Aspose.Slides for Python via .NET kan vormen en tekst maken, bewerken, bewaren en weergeven met PowerPoint-achtige 3D-opmaak. Dit artikel behandelt 3D-effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, kleurverloop‑ of afbeeldingvullingen, en 3D-tekst.

{{% alert color="primary" %}}
Dit artikel gaat over 3D‑opmaakeffecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van zelfstandige 3D‑modelbestanden. Wanneer je een dia exporteert naar een afbeelding, PDF of HTML, renderen Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **Concepten voor 3D‑opmaak**

Gebruik de eigenschap [Shape.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/three_d_format/) om 3D‑opmaak op een vorm toe te passen. Deze eigenschap geeft toegang tot [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruik je de eigenschap [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/three_d_format/). Deze past 3D‑opmaak toe op het tekstkader in plaats van op het vormlichaam.

De belangrijkste eigenschappen zijn:

| Eigenschap | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [camera](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/camera/) | Perspectief, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in de 3D-ruimte of stem overeen met een PowerPoint‑3D‑rotatie‑preset. |
| [light_rig](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/light_rig/) | Lichtpreset, richting en lichtrotatie. | Verander hoe de highlights en schaduwen op het 3D‑oppervlak verschijnen. |
| [material](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/material/) | Oppervlakte‑materiaal, zoals vlak, mat, plastic of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metalen uitzien. |
| [extrusion_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_height/) | Hoe ver de vorm zich naar achteren uitstrekt vanaf het vooraanzicht. | Verander een platte vorm in een duidelijk dik 3D‑object. |
| [extrusion_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_color/) | Kleur van de uitgerekte zijkanten. | Maak diepte zichtbaar of stem de kleur van de zijkanten af op de voorvulling. |
| [depth](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/depth/) | Extra 3D‑diepte gebruikt door PowerPoint‑3D‑opmaak. | Stel de diepte nauwkeurig af voor vormen of tekst, vooral in combinatie met schuine randen en materiaalinstellingen. |
| [bevel_top](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/bevel_top/) en [bevel_bottom](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/bevel_bottom/) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte zijde. |
| [contour_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/contour_color/) en [contour_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/contour_width/) | Omranding rond het 3D‑object. | Benadruk de objectgrens in de gerenderde output. |

## **Een 3D‑vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D lijkt:

- Camerainstellingen, omdat de standaard voorkantweergave de extrusie kan verbergen.
- Lichtinstellingen, omdat verlichting de gezichten en zijkanten leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak bepaalt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde, past 3D‑opmaak toe, slaat de presentatie op als PPTX, en rendert de dia naar een PNG‑afbeelding.

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

De gerenderde dia‑afbeelding toont de rechthoek als een dik 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Een vorm draaien met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D‑rotatie. De X-, Y- en Z‑rotatiewaarden komen overeen met de rotatie die je via de camera‑API instelt.

![PowerPoint‑paneel 3‑D‑rotatie met gemarkeerde X-, Y- en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides stel je het cameratype en de rotatie in via [ThreeDFormat.camera](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Gebruik de camera wanneer je wilt wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het verandert het 3D‑viewpoint dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie laat een vorm dik lijken door deze achter de voorzijde uit te strekken. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijkanten.

![PowerPoint‑diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_height/) in voor de dikte en [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_color/) voor de kleur van de zijkanten:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Gebruik [ThreeDFormat.depth](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/depth/) wanneer je rechtstreeks met de diepte‑waarde van PowerPoint wilt werken of diepte wilt combineren met schuine randen, materiaal en texteffecten. In veel vormscenario’s is [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_height/) de duidelijkere instelling omdat het de zichtbare extrusie direct uitdrukt.

## **Verloop‑ of afbeeldingvullingen gebruiken met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. Je kunt een effen kleur, verloop, patroon of afbeeldingvulling toepassen op de voorzijde en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een verloopvulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

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

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Gebruik je liever een afbeeldingvulling, voeg dan de afbeelding toe aan de presentatie en wijs deze toe aan de vormvulling:

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

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstkader. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroonvulling, past een WordArt‑transformatie toe, en configureert 3D‑instellingen op [TextFrameFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/):

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

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan in PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer je dia’s rendert naar [PNG](/slides/nl/python-net/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/python-net/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/python-net/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Exporterde afbeeldingen en PDF‑bestanden zijn niet interactief. Het object kan na export niet door de kijker worden gedraaid.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtopstelling, materiaal, extrusie, vulling en schaal van de dia.
- Als je erfenis‑ of thema‑gebaseerde opmaakwaarden wilt inspecteren, lees dan de [effective shape properties](/slides/nl/python-net/shape-effective-properties/).
- Sommige uitvoerformaten kunnen bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen interactieve 3D‑scènes van geëxporteerde afbeeldingen, PDF‑bestanden of HTML‑pagina’s die door de kijker kunnen worden gedraaid. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint zolang het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een apart 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die op een reguliere PowerPoint‑vorm of -tekst wordt toegepast, zoals rotatie, extrusie, schuine randen, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet je een cameradraaien en ofwel extrusie of diepte instellen. In de praktijk stel je ook een lichtopstelling en materiaal in zodat de gerenderde gezichten duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/three_d_format/) voor het vormlichaam en [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/three_d_format/) voor tekst.

**Zullen 3D‑effecten verschijnen bij het exporteren naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat erf‑ en thema‑instellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/python-net/shape-effective-properties/) om de uiteindelijke camera‑, lichtopstelling‑, schuine‑rand‑ en gerelateerde 3D‑waarden te lezen.