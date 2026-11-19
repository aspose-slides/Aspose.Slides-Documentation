---
title: Maak 3D‑effecten in presentaties met Python
linktitle: 3D presentatie
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
description: "Pas 3D‑effecten toe en render ze voor PowerPoint‑vormen en -tekst in Python met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D‑tekst."
---
## **Overzicht**

Aspose.Slides for Python via .NET kan vormen en tekst maken, bewerken, behouden en weergeven met PowerPoint‑achtige 3D‑opmaak. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, balken, verlichting, materiaal, verlopen of afbeeldingsvullingen, en 3D‑tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D‑opmaak­effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van afzonderlijke 3D‑modelbestanden. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik de [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/)‑eigenschap om 3D‑opmaak toe te passen op een vorm. De eigenschap exposeert [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/)‑eigenschap. Hiermee wordt 3D‑opmaak toegepast op het tekstframe in plaats van op het lichaam van de vorm.

De belangrijkste eigenschappen zijn:

| Eigenschap | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Uitzichtspunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Roteer het object in de 3D‑ruimte of pas een PowerPoint 3D‑rotatiepreset toe. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Lichtpreset, richting en lichtrotatie. | Verander hoe hooglichten en schaduwen verschijnen op het 3D‑oppervlak. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Oppervlakelijk materiaal, zoals plat, mat, plastic of metaal. | Laat dezelfde geometrie vlakker, zachter, glanzender of metaalachtig lijken. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Hoe ver de vorm zich uitstrekt naar achteren vanaf de voorzijde. | Zet een vlakke vorm om tot een zichtbaar dikke 3D‑object. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Kleur van de uitgeschoven zijkanten. | Maak diepte zichtbaar of stem de zijkleur af op de voorvulling. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | Extra 3D‑diepte gebruikt door PowerPoint 3D‑opmaak. | Fijnafstel van diepte voor vormen of tekst, vooral in combinatie met balk‑ en materiaalinstellingen. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) en [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte flank. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) en [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Omtrek rond het 3D‑object. | Benadruk de objectgrens in de gerenderde output. |

## **Een 3D‑vorm maken**

- Camerainstellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.  
- Verlichtingsinstellingen, omdat verlichting de vlakken en zijkanten leesbaar maakt.  
- Materiaalinstellingen, omdat het oppervlak beïnvloedt hoe licht wordt weergegeven.  
- Extrusie‑ of diepte‑instellingen, omdat een vlakke vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De camerarotatie‑waarden staan in graden en de extrusiehoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

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

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het 3‑D Rotatie‑venster. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint 3D‑rotatievenster met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides krijgt u toegang tot de camera via [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch front‑aanzicht en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Gebruik de camera wanneer u wilt veranderen hoe de kijker het object ziet. Het wijzigt niet de 2D‑geometrie van de vorm op de dia, maar wel het 3D‑uitzicht dat PowerPoint en Aspose.Slides bij het renderen gebruiken.

### **Camera‑oriëntatie kopiëren van een sjabloonvorm**

Om de oriëntatie van een sjabloonvorm te evenaren, kopieert u de vooraf ingestelde [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) en leest u de rotatie met [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). Het voorbeeld opent `template.pptx` en kopieert de camera‑oriëntatie van de eerste vorm op de eerste dia naar de tweede vorm. Beide vormen hebben al 3D‑verlichting, en de tweede vorm heeft geen expliciete camera‑rotatie.

De hoeken staan in graden. Indexen `0`, `1` en `2` bevatten respectievelijk de breedtegraad, lengtegraad en omwenteling. Geef ze in die volgorde door aan [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/). Als de bron geen expliciete rotatie heeft, retourneert `get_rotation` `None`, dus laat de doel‑hoeken oningesteld. Als de bron alle drie de hoeken expliciet op nul zet, kopieer die nulwaarden.

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

Wanneer u `camera-copy.pptx` opnieuw opent in PowerPoint, hebben beide vormen dezelfde camera‑preset en rotatie. De pijl rechts gebruikt de oriëntatie die van de rechthoek links is gekopieerd. Beide vormen gebruiken dezelfde verlichting en extrusiediepte.

![Een blauwe 3D‑rechthoek en een rechtse pijl met overeenkomende camera‑oriëntatie, bekeken van boven en rechts](camera-orientation.png)

## **Extrusie en diepte toevoegen**

Extrusie maakt een vorm dik door deze achter de voorzijde uit te strekken. In PowerPoint bepaalt de diepte‑regeling deze zichtbare dikte, en de kleur‑regeling bepaalt de kleur van de zijkanten.

![PowerPoint‑dieptecontroles gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) in voor de dikte en [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) voor de zijkleur. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en roteert de camera om de dikte te tonen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

De eigenschap [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) bepaalt de diepte van een 3D‑vorm. De eigenschap [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) regelt de hoogte van het extrusie‑effect, zoals in dit voorbeeld te zien.

## **Verloop‑ of afbeeldingsvullingen gebruiken met 3D‑effecten**

3D‑opmaak staat los van de vulling van de vorm. U kunt een effen kleur, verloop, patroon of afbeelding toepassen op de voorzijde en toch dezelfde camera, verlichting, materiaal en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorzijde en een donkeroranje kleur op de extrusie van 150 punten. De verloopstops op 0 en 100 markeren het begin en einde van het verloop. De camerarotatie‑waarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

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

Om in plaats daarvan een afbeeldingsvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en kent u deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand genaamd “image.jpg” in de werkmap. Het strekt de foto uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camerarotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

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

De foto wordt gerenderd op de voorzijde, terwijl de extrusie wordt gerenderd als het 3D‑zijoppervlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstframe. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑witte rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). De extrusiehoogte en diepte staan in punten, en de lichtrotatie in graden. De vormvulling en rand zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

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

## **Tekst vlak houden op een 3D‑vorm**

Om tekst leesbaar te houden terwijl de 3D‑uitstraling van een vorm behouden blijft, stelt u [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) in via [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). Wanneer de waarde `True` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `False` is, neemt de tekst deel in de scène en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: camera, verlichting, materiaal en extrusie blijven geconfigureerd via [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/). Het verschilt ook van gewone rotatie. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) roteert de vorm in het dia‑vlak, terwijl [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) de aangepaste rotatie van de tekst binnen zijn begrenzingsvak regelt. Het buiten de 3D‑scene houden van tekst zet geen van beide hoeken terug.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstinstelling verschilt: `False` links en `True` rechts. De camerarotaties staan in graden en de extrusiehoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op het dubbele van de standaardafmetingen.

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

Links volgt de tekst de 3D‑oriëntatie. Rechts blijft hij vlak en beter leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Twee 3D‑rechthoeken naast elkaar: keep_text_flat is False links en True rechts](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of getekend in de uitvoer als een 2D‑resultaat. Dit geldt wanneer u dia’s rendert naar [PNG](/slides/nl/python-net/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/python-net/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/python-net/convert-powerpoint-to-video/).

Houd rekening met de volgende punten:

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet meer door de kijker worden geroteerd.  
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtinrichting, materiaal, extrusie, vulling en diavergroting.  
- Als u de erfenis‑ of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effective shape properties](/slides/nl/python-net/shape-effective-properties/).  
- Sommige uitvoerformaten kunnen geen bewerkbare PowerPoint‑3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**  
Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geëxporteerde afbeeldingen, PDF’s of HTML‑pagina’s niet interaktief; de kijker kan ze niet roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint zolang het formaat het ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**  
Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, balk, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**  
Minimaal moet een camerarotatie en ofwel extrusie of diepte worden ingesteld. In de praktijk stelt men ook een lichtinrichting en materiaal in zodat de gerenderde vlakken duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**  
Ja. Gebruik [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) voor het vormlichaam en [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) voor tekst.

**Zullen 3D‑effecten verschijnen bij export naar afbeeldingen, PDF, HTML of videoframes?**  
Ja. Aspose.Slides rendert 3D‑effecten bij het genereren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat overerving en themainstellingen zijn toegepast?**  
Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/python-net/shape-effective-properties/) om de definitieve camera‑, lichtinrichting‑, balk‑ en gerelateerde 3D‑waarden te lezen.