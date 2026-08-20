---
title: Beheer afbeeldingframes in presentaties met Python
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/python-net/picture-frame/
keywords:
- afbeeldingframe
- afbeeldingframe toevoegen
- afbeeldingframe maken
- ingesloten afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- afbeeldingframe opmaak
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Afbeeldingsframes maken, opmaken, koppelen, bijsnijden, extraheren en comprimeren in presentaties met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Een afbeeldingframe is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingresource en de vorm die deze weergeeft afzonderlijke objecten: een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) bezit ingesloten afbeeldingsresources via zijn [ImageCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/), terwijl een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingseffecten en andere frame‑specifieke instellingen van de afbeelding regelt.

Deze scheiding is nuttig wanneer dezelfde afbeelding meer dan één keer wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/), en gebruik die afbeeldingsresource bij het aanmaken van afbeeldingframes.

Afbeeldingsframes kunnen rasterafbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt de draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is handig om te bepalen hoe de afbeelding moet worden opgeslagen voordat opmaak of optimalisatie wordt toegepast.

## **Een ingesloten afbeelding toevoegen en opmaken**

Voor een ingesloten afbeelding voeg je de afbeeldingsdata toe aan de presentatie en maak je een afbeeldingframe met [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_picture_frame/). De afbeelding wordt onderdeel van het presentatiepakket, waardoor de presentatie zelf‑voorzienend blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een JPEG‑afbeelding toe, maakt een frame met de oorspronkelijke afmetingen van de afbeelding, en past lijnopmaak en rotatie toe:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Het afbeeldingframe bepaalt de weergegeven geometrie; het wijzigen van de framegrootte verandert niet de oorspronkelijke pixeldimensies die in de ingesloten afbeeldingsresource zijn opgeslagen. Dit onderscheid wordt belangrijk bij het later bijsnijden of comprimeren van een afbeelding.

## **Relatieve schaal gebruiken**

[PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) biedt [relative_scale_width](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/relative_scale_width/) en [relative_scale_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/relative_scale_height/) voor het frame. Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldinggrootte. Relatieve schaal is nuttig wanneer een workflow de verhouding tot de bronafbeeldingsgrootte moet behouden in plaats van de uiteindelijke afmetingen handmatig te berekenen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

Relatieve schaal wijzigt de schaalinstellingen van het frame; het sampled of comprimeert de ingesloten afbeelding niet.

## **Ingesloten en gekoppelde afbeeldingen**

Een ingesloten afbeelding slaat afbeeldingsdata op binnen de presentatie en is daardoor de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding slaat een externe locatie op via het [Picture](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picture/)‑koppelpadhoudende pad in plaats van de afbeeldingsdata op dezelfde manier in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in de PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de applicatie die de presentatie opent of rendert. Als het pad verandert, het bestand wordt verplaatst, of de bron niet beschikbaar is, wordt de gekoppelde afbeelding mogelijk niet zoals verwacht weergegeven. Voor presentaties die moeten worden gemaild, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingesloten afbeeldingen doorgaans betrouwbaarder.

### **Een gekoppelde afbeelding toevoegen**

Het volgende voorbeeld maakt een afbeeldingframe en wijst het naar een lokaal afbeeldingsbestand. Het behandelt alleen het koppelen van afbeeldingen; video‑koppeling is een afzonderlijke media‑workflow en wordt opzettelijk niet gemengd in dit voorbeeld.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet alleen als vervanging voor compressie: een kleine PPTX met gebroken afbeeldingsafhankelijkheden is meestal minder nuttig dan een grotere zelf‑voorzienende presentatie.

## **Afbeeldingen uit afbeeldingframes extraheren**

Voordat je een afbeelding uit een bestaande presentatie extraheert, controleer je of een vorm daadwerkelijk een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) is en of deze een ingesloten afbeelding bevat. Gekoppelde afbeeldingframes bevatten mogelijk niet de afbeeldingsbytes die op dezelfde manier geëxtraheerd kunnen worden.

### **Een rasterafbeelding extraheren**

De moderne image‑API gebruikt [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) direct. Het volgende voorbeeld vindt de eerste ingesloten rasterafbeelding op een dia en slaat deze op als PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Opslaan via [IImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/iimage/) converteert de geëxtraheerde afbeelding naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes die in de presentatie zijn opgeslagen nodig hebt in plaats van een geconverteerd rasterbestand, gebruik dan de [PPImage.binary_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/binary_data/)‑eigenschap.

### **Een SVG‑afbeelding extraheren**

Voor een SVG‑afbeelding biedt de [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) een [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/)‑object. Hiermee kun je de SVG‑data direct ophalen in plaats van de afbeelding eerst te rasteren.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

SVG‑inhoud als SVG behouden behoudt de vectorbron in de presentatie. Raster‑exports zoals PNG of JPEG renderen die vectorinhoud onvermijdelijk naar pixels. PDF‑ of SVG‑dia‑export is eveneens een renderoperatie, zodat de geëxporteerde graphics niet moeten worden beschouwd als een exacte byte‑voor‑byte kopie van de originele ingesloten SVG; gebruik de ingesloten [SvgImage.svg_data](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/svg_data/) wanneer de originele vectorbron zelf nodig is.

## **Een afbeelding bijsnijden**

Bijsnijden verandert welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/) zijn percentages van de bronafbeeldingsafmetingen. Bijsnijden verwijdert aanvankelijk niet de verborgen pixels van de ingesloten afbeelding; het wijzigt alleen het zichtbare gebied.

Het volgende voorbeeld vindt veilig een afbeeldingframe en past bijsnijdwaarden toe:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Omdat de verborgen afbeeldingsdata nog aanwezig is, kan de bijsnijding later worden gewijzigd zonder de originele pixels te verliezen. Als de bestandsgrootte belangrijker is dan de omkeerbaarheid, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsnijdende afbeeldingsdata verwijderen**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) verwijdert afbeeldingsdata buiten de huidige bijsnijdrechthoek en retourneert de resulterende afbeeldingsresource. Dit kan de bestandsgrootte verkleinen, maar het is een destructieve optimalisatie: na het opslaan van de presentatie zijn de verwijderde pixels niet meer beschikbaar voor een latere 'uncrop'-bewerking.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

De methode kan een nieuwe afbeeldingsresource aan de presentatie toevoegen. Als de oorspronkelijke afbeelding ook door andere afbeeldingframes wordt gebruikt, hebben die frames hun bestaande resource nog steeds nodig, dus het verwijderen van bijgesneden gebieden vermindert niet noodzakelijk het totale aantal afbeeldingen. Het bijsnijden van WMF‑ of EMF‑content met deze methode rastert het bijgesneden resultaat naar PNG.

## **Rasterafbeeldingen comprimeren**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/compress_image/) verlaagt de resolutie van rasterafbeeldingen ten opzichte van de grootte waarin de afbeelding wordt weergegeven. Het kan ook bijgesneden gebieden in dezelfde bewerking verwijderen. De methode retourneert `True` wanneer de afbeelding is aangepast of bijgesneden en `False` wanneer er geen wijziging nodig was.

Gebruik een vooraf gedefinieerde [PicturesCompression](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/picturescompression/)‑waarde wanneer een standaard doelsolutie voldoende is:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Een aangepaste positieve DPI‑waarde kan worden doorgegeven in plaats van een enum‑waarde wanneer een specifiek doel vereist is.

Compressie is bedoeld voor rasterafbeeldingen. SVG‑ en metafile‑content wordt niet gereduceerd door deze raster‑compressieworkflow. Houd er ook rekening mee dat een lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld vanuit de geoptimaliseerde presentatie. Kies een doelsolutie op basis van de grootste grootte waarop de afbeelding daadwerkelijk wordt bekeken of geëxporteerd in plaats van overal de laagste DPI toe te passen.

## **Afbeeldingseffecten inspecteren**

Afbeeldingseffecten worden opgeslagen op de afbeelding die door het frame wordt gebruikt. De afbeeldingstransformatiereeks kan effecten bevatten zoals vaste alfa‑modulatie voor transparantie en luminantie voor helderheid en contrast. Het voorbeeld hieronder leest veilig beide soorten effecten uit het eerste afbeeldingframe op een dia:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/nl/python-net/aspose.slides.effects/alphamodulatefixed/) en [Luminance](https://reference.aspose.com/slides/nl/python-net/aspose.slides.effects/luminance/) wijzigen hoe de afbeelding in het frame wordt gerenderd; ze herschrijven de originele ingesloten afbeeldingsbytes niet.

## **Afbeeldingsframe‑geometrie vergrendelen**

De [PictureFrameLock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframelock/)‑instellingen bepalen welke bewerkingsoperaties zijn uitgeschakeld voor een afbeeldingframe. Bijvoorbeeld, de [aspect_ratio_locked](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/)‑eigenschap behoudt de verhoudingen van de vorm tijdens het schalen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

De vergrendeling geldt voor de afbeeldingframe‑vorm. Het dwingt de bronafbeelding niet om gere‑sampled te worden of permanent te worden aangepast aan dezelfde beeldverhouding.

## **De StretchOffset‑waarden aanpassen**

Wanneer de afbeelding‑vulmodus 'stretch' is, definiëren de stretch‑offset‑waarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/) het vulrechthoek relatief ten opzichte van de begrenzingsbox van het afbeeldingframe. Positieve percentages creëren een inspringing vanaf een rand, terwijl negatieve percentages een uitstulping creëren.

Dit verschilt van bijsnijden. Bijsnijdwaarden selecteren welk deel van de bronafbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare afbeeldingsvulling wordt uitgerekt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Gebruik stretch‑offsets voor het plaatsen van de vulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om de randen van de bronafbeelding te verbergen.

## **Opslag, bestandsgrootte en exportoverwegingen**

De belangrijkste afwegingen zijn makkelijker te beheren wanneer afbeeldingopslag en afbeeldingframe‑opmaak afzonderlijk worden behandeld:

- **Ingesloten afbeeldingen** maken de presentatie zelf‑voorzienend en zijn het meest betrouwbaar voor delen en server‑side rendering, maar grote rasterafbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die beschikbaar blijven op de opgeslagen paden of locaties.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingesloten totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote rasterafbeeldingen, maar het verliest de bronresolutie. Het moet worden toegepast nadat de beoogde weergavegrootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten als SVG blijven wanneer vectorbehoud belangrijk is. Extraheer de ingesloten SVG direct wanneer je de vectorresource zelf nodig hebt. Raster‑dia‑exports converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten waar mogelijk een bestaande [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑resource hergebruiken in plaats van steeds dezelfde file te laden in de presentatie‑workflow.

Voor grote presentaties is afbeeldingsoptimalisatie gewoonlijk het effectiefst wanneer deze selectief wordt uitgevoerd: houd logo's en diagrammen als vectorinhoud, comprimeer foto’s volgens hun daadwerkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet nodig is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een afbeeldingframe en een beeldresource?**

Een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) vertegenwoordigt een afbeeldingsresource die aan de presentatie is gekoppeld. Een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau geometrie en opmaak opslaat, zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen insluiten of koppelen?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet kunnen worden zonder toegang tot externe bronnen. Koppel afbeeldingen alleen wanneer het opzettelijk is om afbeeldingsbestanden buiten de PPTX te houden en de externe locaties betrouwbaar beheerd kunnen worden.

**Vermindert bijsnijden de PPTX‑bestandsgrootte?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/nl/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) of afbeeldingcompressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden weggegooid.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verlagen, en het verwijderen van bijgesneden regio's gooit afbeeldingsdata weg. Bewaar de originele bronafbeelding buiten de presentatie als later bewerking met hoge resolutie nodig kan zijn.

**Hoe moeten SVG‑afbeeldingen worden behandeld?**

Behoud SVG‑content als SVG wanneer vectornauwkeurigheid belangrijk is. De ingesloten [SvgImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/svgimage/) kan direct worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype voordat je picture‑frame‑specifieke leden gebruikt. Het gebruik van `isinstance(shape, slides.PictureFrame)` voorkomt ongeldige casts en zorgt dat de code dia’s die geen afbeeldingframes bevatten correct afhandelt.