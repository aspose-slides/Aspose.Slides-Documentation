---
title: Maak 3D-effecten in presentaties met Python
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D presentatie
- 3D rotatie
- 3D diepte
- 3D extrusie
- 3D verloop
- 3D tekst
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in Python met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for Python via .NET kan vormen en tekst maken, bewerken, behouden en weergeven met PowerPoint‑achtige 3D‑opmaak. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, verloop‑ of afbeeldingvullingen en 3D‑tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D‑opmaak effecte op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van losstaande 3D‑modelbestanden. Wanneer je een dia exporteert naar een afbeelding, PDF of HTML, renderen Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **Concepten voor 3D‑opmaak**

Gebruik de eigenschap [Shape.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/three_d_format/) om 3D‑opmaak toe te passen op een vorm. De eigenschap geeft toegang tot [ThreeDFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruik je de eigenschap [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/three_d_format/) . Hiermee wordt 3D‑opmaak toegepast op het tekstkader in plaats van op de vorm.

De belangrijkste eigenschappen zijn:

| Eigenschap | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [camera](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/camera/) | Bekijkpunt, vooraf ingestelde cameratypes, rotatie, zoom en perspectief. | Draai het object in 3D‑ruimte of stem overeen met een PowerPoint‑3D‑rotatie‑preset. |
| [light_rig](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/light_rig/) | Lichtpreset, richting en lichtrotatie. | Verander hoe reflecties en schaduwen verschijnen op het 3D‑oppervlak. |
| [material](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/material/) | Oppervlakte‑materiaal, zoals plat, mat, kunststof of metaal. | Laat dezelfde geometrie er platter, zachter, glanzender of metallischer uitzien. |
| [extrusion_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_height/) | Hoe ver de vorm zich naar achteren uitstrekt vanaf de voorzijde. | Maak van een platte vorm een duidelijk dik 3D‑object. |
| [extrusion_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_color/) | Kleur van de uitgeschoven zijden. | Maak diepte zichtbaar of stem de kleur van de zijkanten af op de voorvulling. |
| [depth](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/depth/) | Extra 3D‑diepte die wordt gebruikt door PowerPoint‑3D‑opmaak. | Fijn afstemmen van de diepte voor vormen of tekst, vooral in combinatie met schuine randen en materiaalinstellingen. |
| [bevel_top](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/bevel_top/) en [bevel_bottom](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/bevel_bottom/) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een zachtere of gevormde rand toe in plaats van een scherpe platte rand. |
| [contour_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/contour_color/) en [contour_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/contour_width/) | Omranding rond het 3D‑object. | Benadruk de grenzen van het object in de gerenderde output. |

## **Maak een 3D‑vorm**

Een vorm heeft meestal vier soorten instellingen nodig voordat het overtuigend 3D uitziet:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Licht‑instellingen, omdat verlichting de gezichten en zijkanten leesbaar maakt.
- Materiaal‑instellingen, omdat het oppervlak bepaalt hoe het licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De camera‑rotatiewaarden staan in graden en de extrusie‑hoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

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

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blokken:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Roteer een vorm met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het venster 3‑D Rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die je via de camera‑API instelt.

![PowerPoint‑venster 3‑D Rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides krijg je toegang tot de camera via [ThreeDFormat.camera](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/camera/). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch frontaanzicht en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Gebruik de camera wanneer je de weergave van het object voor de kijker wilt aanpassen. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑viewpoint dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Voeg extrusie en diepte toe**

Extrusie maakt een vorm dikker door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte en de kleur‑instelling bepaalt de kleur van de zijkanten.

![PowerPoint-diepte‑instellingen gekoppeld aan extrusie‑kleur en extrusie‑hoogte‑eigenschappen](img_02_02.png)

Stel [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_height/) in voor de dikte en [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_color/) voor de kleur van de zijkanten. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijden en draait de camera om de dikte te onthullen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

De eigenschap [ThreeDFormat.depth](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/depth/) stelt de diepte van een 3D‑vorm in. De eigenschap [extrusion_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/threedformat/extrusion_height/) regelt de hoogte van het extrusie‑effect, zoals in dit voorbeeld wordt getoond.

## **Gebruik verloop‑ of afbeeldingvullingen met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. Je kunt een effen kleur, verloop, patroon of afbeeldingvulling op de voorzijde toepassen en toch dezelfde camera-, licht-, materiaal- en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorzijde en een donkeroranje kleur op de 150‑punts extrusie. De verloopstops bij 0 en 100 geven respectievelijk het begin en einde van het verloop aan. De camera‑rotatiewaarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

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

De gerenderde output behoudt het verloop op de voorzijde en rendert de extrusie apart:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voeg je de afbeelding toe aan de presentatie en wijs je deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand genaamd "image.jpg" in de werkmap. Het strekt de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camera‑rotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

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

De afbeelding wordt gerenderd op de voorzijde, terwijl de extrusie wordt gerenderd als het 3D‑zijoppervlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstkader. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑wit rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/three_d_format/). De extrusie‑hoogte en diepte staan in punten en de lichtrotatie in graden. De vormvulling en rand worden verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

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

De tekst wordt gerenderd als gebogen, geëxtrudeerde 3D‑letters:

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Houd tekst vlak op een 3D‑vorm**

Om tekst leesbaar te houden terwijl je de 3D‑uitstraling van een vorm behoudt, stel je [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/keep_text_flat/) in via [TextFrame.text_frame_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/text_frame_format/). Wanneer de waarde `True` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `False` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [Shape.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/three_d_format/). Het verschilt ook van gewone rotatie. [Shape.rotation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/rotation/) roteert de vorm in het dia‑vlak, terwijl [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/rotation_angle/) de aangepaste rotatie van de tekst binnen het omhullende vak regelt. Tekst buiten de 3D‑scene houden, reset geen van die hoeken.

Het volgende, zelf‑containende voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstinstelling verschilt: `False` links en `True` rechts. De camera‑hoeken staan in graden en de extrusie‑hoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op het dubbele van de standaardafmetingen.

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

Links volgt de tekst de 3D‑oriëntatie. Rechts blijft de tekst vlak en beter leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Zij‑aan‑zij 3D‑rechthoeken: keep_text_flat is False links en True rechts](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer je dia's rendert naar [PNG](/slides/nl/python-net/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/python-net/convert-powerpoint-to-html/), of frames genereert voor [video‑conversie](/slides/nl/python-net/convert-powerpoint-to-video/).

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden gedraaid.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, licht‑rig, materiaal, extrusie, vulling en dia‑schaal.
- Als je geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/python-net/shape-effective-properties/).
- Sommige exportformaten kunnen de bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geëxporteerde afbeeldingen, PDF’s of HTML‑pagina’s geen interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dat ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een los 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, bevel, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet je een camera‑rotatie instellen en ofwel extrusie of diepte. In de praktijk stel je ook een licht‑rig en materiaal in zodat de gerenderde gezichten duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/three_d_format/) voor het vormlichaam en [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/three_d_format/) voor tekst.

**Zullen 3D‑effecten verschijnen bij export naar afbeeldingen, PDF, HTML of video‑frames?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat overerving en themainstellingen zijn toegepast?**

Ja. Gebruik de API’s voor effectieve opmaak beschreven in [Shape Effective Properties](/slides/nl/python-net/shape-effective-properties/) om de uiteindelijke camera‑, licht‑rig‑, bevel‑ en gerelateerde 3D‑waarden te lezen.