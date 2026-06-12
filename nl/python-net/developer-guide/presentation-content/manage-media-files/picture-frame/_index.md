---
title: Afbeeldingskaders toevoegen aan presentaties met Python
linktitle: Afbeeldingskader
type: docs
weight: 10
url: /nl/python-net/picture-frame/
keywords:
- afbeeldingskader
- afbeeldingskader toevoegen
- afbeeldingskader maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijsnijgebied
- StretchOff eigenschap
- opmaak van afbeeldingskader
- eigenschappen van afbeeldingskader
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Voeg afbeeldingskaders toe aan PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET. Vereenvoudig uw workflow en verbeter het ontwerp van dia's."
---
## **Inleiding**

Afbeeldingskaders in Aspose.Slides for Python stellen u in staat om raster‑ en vectorafbeeldingen als native dia‑vormen te plaatsen en te beheren. U kunt afbeeldingen invoegen vanuit bestanden of streams, ze positioneren en van grootte wijzigen met precieze coördinaten, rotatie toepassen, transparantie instellen en de z‑volgorde regelen naast andere vormen. De API ondersteunt ook bijsnijden, het behouden van verhoudingen, randen en effecten instellen, en het vervangen van de onderliggende afbeelding zonder de lay‑out opnieuw te bouwen. Omdat afbeeldingskaders zich gedragen als gewone vormen, kunt u animaties, hyperlinks en alternatieve tekst toevoegen, waardoor het eenvoudig is om visueel rijke, toegankelijke presentaties te maken.

## **Afbeeldingskaders maken**

Deze sectie toont hoe u een afbeelding in een dia invoegt door een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) te maken met Aspose.Slides for Python. U leert hoe u de afbeelding laadt, precies op de dia plaatst en de grootte en opmaak beheert.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Haal een dia op op basis van de index.
3. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) door de afbeelding toe te voegen aan de [ImageCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/) van de presentatie. Deze afbeelding wordt gebruikt om de vorm te vullen.
4. Geef de breedte en hoogte van het kader op.
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) van die grootte met de [add_picture_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_picture_frame/)‑methode.
6. Sla de presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe u een afbeeldingskader maakt:

```py
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse om een PPTX‑bestand te vertegenwoordigen.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg de afbeelding toe aan de presentatie.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Voeg een afbeeldingskader toe met de afmetingen van de afbeelding.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Sla de presentatie op als PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Afbeeldingskaders stellen u in staat om snel presentatiedia’s te maken van afbeeldingen. Wanneer u afbeeldingskaders combineert met de opslaan‑opties van Aspose.Slides, kunt u I/O‑bewerkingen regelen om afbeeldingen van het ene formaat naar het andere te converteren. Misschien wilt u deze pagina’s bekijken: converteer [image to JPG](https://products.aspose.com/slides/nl/python-net/conversion/image-to-jpg/); converteer [JPG to image](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-image/); converteer [JPG to PNG](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-png/); converteer [PNG to JPG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-jpg/); converteer [PNG to SVG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-svg/); converteer [SVG to PNG](https://products.aspose.com/slides/nl/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Afbeeldingskaders maken met relatieve schaal**

Deze sectie laat zien hoe u een afbeelding met een vaste grootte plaatst en vervolgens een procentuele schaal toepast op afzonderlijk de breedte en hoogte. Omdat de percentages kunnen verschillen, kan de beeldverhouding veranderen. Schalen gebeurt relatief ten opzichte van de oorspronkelijke afmetingen van de afbeelding.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Haal een dia op op basis van de index.
3. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) door de afbeelding toe te voegen aan de [ImageCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/) van de presentatie.
4. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) toe aan de dia.
5. Stel de relatieve breedte en hoogte van het afbeeldingskader in.
6. Sla de presentatie op als een PPTX‑bestand.

De volgende Python‑code toont hoe u een afbeeldingskader maakt met relatieve schaal:

```py
import aspose.slides as slides

# Instantieer de Presentation‑klasse om een PPTX‑bestand te vertegenwoordigen.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Voeg een afbeeldingskader toe aan de dia.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Stel de relatieve schaalbreedte en -hoogte in.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Sla de presentatie op.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterafbeeldingen uit afbeeldingskaders extraheren**

U kunt rasterafbeeldingen uit [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/)‑objecten extraheren en opslaan in PNG, JPG en andere formaten. Het code‑voorbeeld hieronder laat zien hoe u een afbeelding uit het document “sample.pptx” extraheert en opslaat in PNG‑formaat.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **SVG‑afbeeldingen uit afbeeldingskaders extraheren**

Wanneer een presentatie SVG‑graphics bevat die in [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/)‑vormen zijn geplaatst, laat Aspose.Slides for Python via .NET u de oorspronkelijke vectorafbeeldingen met volledige nauwkeurigheid ophalen. Door de vormcollectie van de dia te doorlopen, kunt u elk [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het native SVG‑formaat.

Het volgende code‑voorbeeld laat zien hoe u een SVG‑afbeelding uit een afbeeldingskader extraheert:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Transparantie van afbeelding ophalen**

Aspose.Slides laat u het transparantieseffect ophalen dat op een afbeelding is toegepast. Deze Python‑code demonstreert de bewerking:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Alle effecten die op afbeeldingen worden toegepast, zijn te vinden in [aspose.slides.effects](https://reference.aspose.com/slides/nl/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Opmaak van afbeeldingskader**

Aspose.Slides biedt vele opmaakopties die u op een afbeeldingskader kunt toepassen. Met deze opties kunt u een afbeeldingskader aanpassen aan specifieke eisen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Haal een dia op op basis van de index.
3. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) door de afbeelding toe te voegen aan de [ImageCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/) van de presentatie. Deze afbeelding wordt gebruikt om de vorm te vullen.
4. Geef de breedte en hoogte van het kader op.
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) van die grootte met de [add_picture_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_picture_frame/)‑methode van de dia.
6. Stel de lijmkleur van het afbeeldingskader in.
7. Stel de lijmdikte van het afbeeldingskader in.
8. Roteer het afbeeldingskader door een positieve (met de klok mee) of negatieve (tegen de klok in) waarde op te geven.
9. Sla de gewijzigde presentatie op als een PPTX‑bestand.

De volgende Python‑code demonstreert het opmaakproces van het afbeeldingskader:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation‑klasse om een PPTX‑bestand te vertegenwoordigen.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg de afbeelding toe aan de afbeeldingencollectie van de presentatie.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Voeg een afbeeldingskader toe met de afmetingen van de afbeelding.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Pas opmaak toe op het afbeeldingskader.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Sla de presentatie op als PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose heeft een gratis [Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als u [JPG/JPEG](https://products.aspose.app/slides/nl/collage/jpg) of PNG‑afbeeldingen wilt [samenvoegen](https://products.aspose.app/slides/nl/collage/jpg) of [fotogalerijen](https://products.aspose.app/slides/nl/collage/photo-grid) wilt maken, kunt u deze dienst gebruiken.
{{% /alert %}}

## **Afbeeldingen toevoegen als koppelingen**

Om presentatiebestanden klein te houden, kunt u afbeeldingen of video's via koppelingen toevoegen in plaats van de bestanden direct in de presentaties in te sluiten. De volgende Python‑code toont hoe u een afbeelding en een video in een placeholder invoegt:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Afbeeldingen bijsnijden**

In deze sectie leert u hoe u het zichtbare deel van een afbeelding binnen een afbeeldingskader kunt bijsnijden zonder het bronbestand te wijzigen. U leert ook de basismethode voor het toepassen van bijsnijdmarges om een schone, gefocuste compositie rechtstreeks op de dia te creëren.

De volgende Python‑code toont hoe u een afbeelding op een dia bijsnijdt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Voeg de afbeelding toe aan de afbeeldingencollectie van de presentatie.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Voeg een afbeeldingskader toe aan de dia.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Bijsnijden van de afbeelding (percentuele waarden).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Sla het resultaat op.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Bijsneden gebieden van afbeeldingen verwijderen**

Als u de bijgesneden gebieden van een afbeelding in een kader wilt verwijderen, gebruikt u de [delete_picture_cropped_areas](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/)‑methode. Deze methode retourneert de bijgesneden afbeelding, of de originele afbeelding als er geen bijsnijden nodig is.

De volgende Python‑code demonstreert de bewerking:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Haal het PictureFrame op van de eerste dia.
    picture_frame = slides.shape[0]

    # Haal het PictureFrame op van de eerste dia.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Sla het resultaat op.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
De [delete_picture_cropped_areas](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/)‑methode voegt de bijgesneden afbeelding toe aan de afbeeldingencollectie van de presentatie. Als de afbeelding alleen in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) wordt gebruikt, kan dit de grootte van de presentatie verminderen; anders kan het aantal afbeeldingen in de resulterende presentatie toenemen.

Tijdens het bijsnijden converteert deze methode WMF/EMF‑metabestanden naar een raster‑PNG‑afbeelding.
{{% /alert %}}

## **Afbeeldingen comprimeren**

U kunt een afbeelding in een presentatie comprimeren met de [PictureFillFormat.compress_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/compress_image/)‑methode.
Deze methode comprimeert een afbeelding door de grootte te verkleinen op basis van de vormgrootte en de opgegeven resolutie, met de optie om bijgesneden gebieden te verwijderen.

Het past de grootte en resolutie van de afbeelding aan op dezelfde manier als de functie **Picture Format -> Compress Pictures -> Resolution** in PowerPoint.

De volgende Python‑voorbeelden tonen hoe u een afbeelding in een presentatie comprimeert door een doelresolutie op te geven en eventueel bijgesneden gebieden te verwijderen:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Comprimeer de afbeelding met een doelresolutie van 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Controleer het resultaat van de compressie.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Of door direct een aangepaste DPI‑waarde te gebruiken:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Comprimeer de afbeelding naar 150 DPI (webresolutie) en verwijder bijgesneden gebieden.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
De methode zet de afbeelding om naar een lagere resolutie op basis van de vormgrootte en de opgegeven DPI. Bijsneden regio’s kunnen ook worden verwijderd om de bestandsgrootte te optimaliseren.
Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook wordt de JPEG‑kwaliteit behouden of lichtjes verminderd op basis van de resolutie, op dezelfde manier als PowerPoint hoge‑resolutie JPEG‑s behandelt.
{{% /alert %}}

## **Aspectverhouding vergrendelen**

Als u wilt dat een vorm die een afbeelding bevat haar aspectverhouding behoudt nadat u de afmetingen van de afbeelding hebt gewijzigd, stelt u de eigenschap [aspect_ratio_locked](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) in op `True`.

De volgende Python‑code toont hoe u de aspectverhouding van een vorm vergrendelt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Vergrendel de beeldverhouding bij het schalen.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Deze *Lock Aspect Ratio*‑instelling behoudt alleen de aspectverhouding van de vorm, niet die van de afbeelding die erin zit.
{{% /alert %}}

## **Stretch‑offset‑eigenschappen gebruiken**

Met de eigenschappen `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` en `stretch_offset_bottom` van de [PictureFillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/)‑klasse kunt u een vulrechthoek definiëren.

Wanneer rekken voor een afbeelding wordt opgegeven, wordt de bronrechthoek geschaald om in de vulrechthoek te passen. Elke rand van de vulrechthoek wordt gedefinieerd door een procentuele offset ten opzichte van de overeenkomstige rand van de begrenzende doos van de vorm. Een positief percentage geeft een inset aan, terwijl een negatief percentage een outset aangeeft.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe.
4. Stel het opvultype van de vorm in.
5. Stel de afbeeldingvullingsmodus van de vorm in.
6. Laad een afbeelding.
7. Wijs de afbeelding toe om de vorm te vullen.
8. Specificeer afbeeldingsoffsets ten opzichte van de overeenkomstige randen van de begrenzende doos van de vorm.
9. Sla de presentatie op als een PPTX‑bestand.

De volgende Python‑code demonstreert hoe u de Stretch‑Offset‑eigenschappen gebruikt:

```py
import aspose.slides as slides

# Instantieer de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een rechthoekige AutoShape toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Stel het vultype van de vorm in.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Stel de afbeeldingvullingsmodus van de vorm in.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Laad de afbeelding en voeg deze toe aan de presentatie.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Ken de afbeelding toe om de vorm te vullen.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specificeer afbeeldingsoffsets ten opzichte van de overeenkomstige randen van de begrenzende doos van de vorm.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Sla het PPTX‑bestand op op schijf.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose biedt gratis converters—[JPEG to PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG to PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die u snel presentaties van afbeeldingen laten maken.
{{% /alert %}}

## **FAQ**

**Hoe kan ik achterhalen welke afbeeldingformaten worden ondersteund voor PictureFrame?**

Aspose.Slides ondersteunt zowel raster‑afbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vector‑afbeeldingen (bijvoorbeeld SVG) via het afbeeldingobject dat is toegewezen aan een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/). De lijst met ondersteunde formaten overlapt doorgaans met de mogelijkheden van de dia‑ en afbeeldingconversie‑engine.

**Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de grootte en prestaties van een PPTX?**

Het insluiten van grote afbeeldingen vergroot de bestandsgrootte en het geheugengebruik; het koppelen van afbeeldingen helpt de presentatiegrootte klein te houden, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een koppeling toe te voegen om de bestandsgrootte te verminderen.

**Hoe kan ik een afbeeldingsobject vergrendelen tegen accidenteel verplaatsen/verkleinen?**

Gebruik [shape locks](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/picture_frame_lock/) voor een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of verkleinen uit te schakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart [protection article](/slides/nl/python-net/applying-protection-to-presentation/) en wordt ondersteund voor verschillende vormtypen, inclusief [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/).

**Wordt de vector‑fideliteit van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk om een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) te extraheren als de originele vector. Bij het [exporteren naar PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/) of [rasterformaten](/slides/nl/python-net/convert-powerpoint-to-png/) kan het resultaat gerasterd zijn afhankelijk van de exportinstellingen; het feit dat de originele SVG als vector is opgeslagen wordt bevestigd door het extractiegedrag.