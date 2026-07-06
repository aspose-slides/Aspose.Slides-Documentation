---
title: Afbeeldingsframes toevoegen aan presentaties met Python
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/python-net/picture-frame/
keywords:
- afbeeldingsframe
- afbeeldingsframe toevoegen
- afbeeldingsframe maken
- afbeelding toevoegen
- afbeelding maken
- afbeelding extraheren
- rasterafbeelding
- vectorafbeelding
- afbeelding bijsnijden
- bijgesneden gebied
- StretchOff‑eigenschap
- opmaak van afbeeldingsframe
- eigenschappen van afbeeldingsframe
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- afbeeldingstransparantie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Voeg afbeeldingsframes toe aan PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python via .NET. Vereenvoudig uw werkstroom en verbeter het ontwerp van dia’s."
---
## **Inleiding**

Afbeeldingsframes in Aspose.Slides for Python laten je raster‑ en vectorafbeeldingen plaatsen en beheren als native dia‑vormen. Je kunt afbeeldingen invoegen vanuit bestanden of streams, ze nauwkeurig positioneren en van grootte wijzigen met precieze coördinaten, rotatie toepassen, transparantie instellen en de z‑volgorde ten opzichte van andere vormen regelen. De API ondersteunt ook bijsnijden, het behouden van beeldverhoudingen, het instellen van randen en effecten, en het vervangen van de onderliggende afbeelding zonder de lay‑out opnieuw op te bouwen. Omdat afbeeldingsframes zich gedragen als gewone vormen, kun je animaties, hyperlinks en alt‑tekst toevoegen, waardoor het eenvoudig is om visueel rijke, toegankelijke presentaties te maken.

## **Afbeeldingsframes maken**

Deze sectie toont hoe je een afbeelding in een dia plaatst door een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) te maken met Aspose.Slides for Python. Je leert hoe je de afbeelding laadt, nauwkeurig op de dia plaatst en de grootte en opmaak ervan controleert.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Haal een dia op via de index.
3. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) aan door de afbeelding toe te voegen aan de [ImageCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/) van de presentatie. Deze afbeelding wordt gebruikt om de vorm te vullen.
4. Specificeer de breedte en hoogte van het frame.
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) van die grootte aan met de methode [add_picture_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Sla de presentatie op als een PPTX‑bestand.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om een PPTX-bestand te vertegenwoordigen.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg de afbeelding toe aan de presentatie.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Voeg een afbeeldingsframe toe met dezelfde afmeting als de afbeelding.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Sla de presentatie op als PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Afbeeldingsframes laten je snel presentatiedia's maken vanuit afbeeldingen. Als je afbeeldingen combineert met Aspose.Slides‑opslagopties, kun je de I/O‑bewerkingen beheren om afbeeldingen van het ene formaat naar het andere te converteren. Zie eventueel de volgende pagina's: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/image-to-jpg/); converteer [JPG naar afbeelding](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-image/); converteer [JPG naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/jpg-to-png/); converteer [PNG naar JPG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-jpg/); converteer [PNG naar SVG](https://products.aspose.com/slides/nl/python-net/conversion/png-to-svg/); converteer [SVG naar PNG](https://products.aspose.com/slides/nl/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Afbeeldingsframes maken met relatieve schaal**

Deze sectie laat zien hoe je een afbeelding op een vaste grootte plaatst en vervolgens procentueel geschaalde breedte‑ en hoogtewaarden onafhankelijk toepast. Omdat de percentages kunnen verschillen, kan de beeldverhouding wijzigen. Schalen gebeurt relatief ten opzichte van de oorspronkelijke afmetingen van de afbeelding.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Haal een dia op via de index.
3. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) aan door de afbeelding toe te voegen aan de [ImageCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/).
4. Voeg een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) toe aan de dia.
5. Stel de relatieve breedte en hoogte van het afbeeldingsframe in.
6. Sla de presentatie op als een PPTX‑bestand.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om een PPTX-bestand te vertegenwoordigen.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Voeg een afbeeldingsframe toe aan de dia.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Stel de relatieve schaalbreedte en -hoogte in.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Sla de presentatie op.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Rasterafbeeldingen uit afbeeldingsframes extraheren**

Je kunt rasterafbeeldingen uit [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/)-objecten extraheren en opslaan in PNG, JPG en andere formaten. Het code‑voorbeeld hieronder laat zien hoe je een afbeelding uit het document “sample.pptx” haalt en opslaat in PNG‑formaat.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **SVG-afbeeldingen uit afbeeldingsframes extraheren**

Wanneer een presentatie SVG‑graphics bevat die in [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/)-vormen zijn geplaatst, laat Aspose.Slides for Python via .NET je de oorspronkelijke vectorafbeeldingen met volledige nauwkeurigheid ophalen. Door de vormcollectie van de dia te doorlopen, kun je elk [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) identificeren, controleren of de onderliggende [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) SVG‑inhoud bevat, en vervolgens die afbeelding opslaan op schijf of in een stream in het native SVG‑formaat.

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

Aspose.Slides laat je het transparantie‑effect dat op een afbeelding is toegepast ophalen. Deze Python‑code demonstreert de bewerking:

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
Alle effecten die op afbeeldingen zijn toegepast, zijn te vinden in [aspose.slides.effects](https://reference.aspose.com/slides/nl/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Helderheid en contrast van een afbeelding ophalen**

Aspose.Slides laat je het helderheids‑ en contrast‑effect dat op een afbeelding is toegepast ophalen. De klasse [Luminance](https://reference.aspose.com/slides/nl/python-net/aspose.slides.effects/luminance/) vertegenwoordigt dit afbeeldings‑transformatie‑effect.

Deze Python‑code toont hoe je de helderheids‑ en contrastinstellingen van een afbeeldingsframe ophaalt:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Opmaak van afbeeldingsframes**

Aspose.Slides biedt tal van opmaakopties die je op een afbeeldingsframe kunt toepassen. Met deze opties kun je een afbeeldingsframe aanpassen aan specifieke eisen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Haal een dia op via de index.
3. Maak een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) aan door de afbeelding toe te voegen aan de [ImageCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/) van de presentatie. Deze afbeelding wordt gebruikt om de vorm te vullen.
4. Specificeer de breedte en hoogte van het frame.
5. Maak een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) van die grootte aan met de methode [add_picture_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_picture_frame/) van de dia.
6. Stel de lijmkleur van het afbeeldingsframe in.
7. Stel de lijnbreedte van het afbeeldingsframe in.
8. Draai het afbeeldingsframe door een positieve (met de klok mee) of negatieve (tegen de klok in) waarde op te geven.
9. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantieer de Presentation-klasse om een PPTX-bestand te representeren.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Voeg een afbeeldingsframe toe met dezelfde grootte als de afbeelding.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Pas opmaak toe op het afbeeldingsframe.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Sla de presentatie op als PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose heeft een gratis [Collage Maker](https://products.aspose.app/slides/nl/collage) ontwikkeld. Als je JPG/JPEG‑ of PNG‑afbeeldingen wilt samenvoegen, of foto‑raster‑layouts wilt maken, kun je deze service gebruiken.
{{% /alert %}}

## **Afbeeldingen als koppelingen toevoegen**

Om presentatiebestanden klein te houden, kun je afbeeldingen of video's via koppelingen toevoegen in plaats van de bestanden rechtstreeks in de presentaties te embedden. De volgende Python‑code laat zien hoe je een afbeelding en een video in een plaatshouder invoegt:

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

In deze sectie leer je hoe je het zichtbare deel van een afbeelding binnen een afbeeldingsframe bijsnijdt zonder het bronbestand te wijzigen. Je leert ook de basismethode voor het toepassen van bijsnijdingsmarges om een nette, gerichte compositie direct op de dia te creëren.

De volgende Python‑code laat zien hoe je een afbeelding op een dia bijsnijdt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Voeg een afbeeldingsframe toe aan de dia.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Bijsnijden van de afbeelding (percentage waarden).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Sla het resultaat op.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Bijsneden delen van afbeeldingen verwijderen**

Wil je de bijgesneden delen van een afbeelding in een frame verwijderen, gebruik dan de methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Deze methode retourneert de bijgesneden afbeelding, of de originele afbeelding als er geen bijsnijden nodig is.

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

{{% alert title="OPMERKING" color="warning" %}}
De methode [delete_picture_cropped_areas](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) voegt de bijgesneden afbeelding toe aan de afbeeldingcollectie van de presentatie. Als de afbeelding alleen in het verwerkte [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) wordt gebruikt, kan dit de presentatiegrootte verkleinen; anders kan het aantal afbeeldingen in de uiteindelijke presentatie toenemen.

Tijdens het bijsnijden converteert deze methode WMF/EMF‑metabestanden naar een raster‑PNG‑afbeelding.
{{% /alert %}}

## **Afbeeldingen comprimeren**

Je kunt een afbeelding in een presentatie comprimeren met de methode [PictureFillFormat.compress_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/compress_image/). Deze methode verkleint een afbeelding door de grootte aan te passen aan de vormgrootte en de opgegeven resolutie, met de optie om bijgesneden delen te verwijderen.

Hij past de grootte en resolutie van de afbeelding aan op dezelfde manier als de PowerPoint‑functie **Afbeeldingsopmaak → Afbeeldingen comprimeren → Resolutie**.

De volgende Python‑voorbeelden tonen hoe je een afbeelding in een presentatie comprimeert door een doelformaat op te geven en eventueel bijgesneden delen te verwijderen:

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

    # Comprimeer de afbeelding tot 150 DPI (webresolutie), waarbij bijgesneden gebieden worden verwijderd.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="OPMERKING" color="warning" %}}
De methode converteert de afbeelding naar een lagere resolutie op basis van de vormgrootte en de opgegeven DPI. Bijsneden regio's kunnen eveneens worden verwijderd om de bestandsgrootte te optimaliseren. Als de afbeelding een metabestand (WMF/EMF) of SVG is, wordt compressie niet toegepast. Ook wordt de JPEG‑kwaliteit bewaard of licht verminderd afhankelijk van de resolutie, vergelijkbaar met hoe PowerPoint hoge‑resolutie JPEG's behandelt.
{{% /alert %}}

## **Vergrendel de beeldverhouding**

Wil je dat een vorm die een afbeelding bevat zijn beeldverhouding behoudt nadat je de afmetingen van de afbeelding wijzigt, stel dan de eigenschap [aspect_ratio_locked](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) in op `True`.

De volgende Python‑code laat zien hoe je de beeldverhouding van een vorm vergrendelt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Vergrendel de beeldverhouding bij het wijzigen van de grootte.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="OPMERKING" color="warning" %}}
Deze instelling *Vergrendel beeldverhouding* behoudt alleen de beeldverhouding van de vorm, niet die van de afbeelding die erin zit.
{{% /alert %}}

## **Gebruik stretch‑offseteigenschappen**

Met de eigenschappen `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` en `stretch_offset_bottom` van de klasse [PictureFillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/) kun je een vulrechthoek definiëren.

Wanneer streching voor een afbeelding wordt opgegeven, wordt de bronrechthoek geschaald om in de vulrechthoek te passen. Elke rand van de vulrechthoek wordt gedefinieerd door een procentuele offset ten opzichte van de overeenkomstige rand van de begrenzende doos van de vorm. Een positief percentage geeft een inset aan, een negatief percentage een outset.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) aan.
2. Haal een referentie naar een dia op via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) toe.
4. Stel het vultype van de vorm in.
5. Stel de afbeeldingsvulmodus van de vorm in.
6. Laad een afbeelding.
7. Wijs de afbeelding toe om de vorm te vullen.
8. Specificeer afbeeldingsoffsets ten opzichte van de bijbehorende randen van de begrenzende doos van de vorm.
9. Sla de presentatie op als een PPTX‑bestand.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die een PPTX‑bestand representeert.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een rechthoekige AutoShape toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Stel het vultype van de vorm in.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Stel de afbeeldingsvulmethode van de vorm in.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Laad de afbeelding en voeg deze toe aan de presentatie.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Wijs de afbeelding toe om de vorm te vullen.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specificeer afbeeldingsoffsets ten opzichte van de overeenkomstige randen van de begrenzende doos van de vorm.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Sla het PPTX‑bestand op naar de schijf.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose biedt gratis converters — [JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt) — waarmee je snel presentaties uit afbeeldingen kunt maken.
{{% /alert %}}

## **FAQ**

**Hoe kan ik achterhalen welke afbeeldingsformaten ondersteund worden voor PictureFrame?**

Aspose.Slides ondersteunt zowel rasterafbeeldingen (PNG, JPEG, BMP, GIF, enz.) als vectorafbeeldingen (bijvoorbeeld SVG) via het afbeelding‑object dat aan een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) is toegewezen. De lijst met ondersteunde formaten overlapt over het algemeen met de mogelijkheden van de dia‑ en afbeelding‑conversie‑engine.

**Hoe beïnvloedt het toevoegen van tientallen grote afbeeldingen de PPTX‑grootte en -prestaties?**

Het insluiten van grote afbeeldingen vergroot de bestandsgrootte en het geheugenverbruik; het koppelen van afbeeldingen helpt de presentatiegrootte klein te houden, maar vereist dat de externe bestanden toegankelijk blijven. Aspose.Slides biedt de mogelijkheid om afbeeldingen via een koppeling toe te voegen om de bestandsgrootte te reduceren.

**Hoe kan ik een afbeeldingobject vergrendelen tegen per ongeluk verplaatsen of aanpassen van de grootte?**

Gebruik [shape locks](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/picture_frame_lock/) voor een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) (bijvoorbeeld om verplaatsen of aanpassen van de grootte uit te schakelen). Het vergrendelingsmechanisme wordt beschreven voor vormen in een apart artikel over [bescherming](/slides/nl/python-net/applying-protection-to-presentation/) en wordt ondersteund voor diverse vormtypes, waaronder [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/).

**Wordt de vector‑fidelity van SVG behouden bij het exporteren van een presentatie naar PDF/afbeeldingen?**

Aspose.Slides maakt het mogelijk een SVG uit een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) te extraheren als de originele vector. Bij het [exporteren naar PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/) of naar rasterformaten](/slides/nl/python-net/convert-powerpoint-to-png/) kan het resultaat worden gerasterd afhankelijk van de exportinstellingen; het feit dat de originele SVG als vector is opgeslagen, wordt bevestigd door het extractiegedrag.